using System;
using System.Collections.Generic;
using System.IO.Ports;
using System.Threading;
using System.Text;

namespace Lab.Drivers.Motors
{
    public class ZaberTLA : IDisposable
    {

        SerialPort spObj;
        bool  bInitalized = false;        
        int[] devices;

        int retryCount = 0;                         // number of retrys attempted
        const int maxRetries = 5;                   // maximum ammount of times to retry a command
        const int retrySleepTime = 20;              // time to sleep between retries
        const int readUntilTimeoutTimeout = 20;     //


        // parameters that are returned every time a command is sent
        int returnDevice, returnCommand, returnData;

        public enum Mode { AUTO_REPLY, ANTI_BACKLASH };

        public ZaberTLA()
        {
            spObj = new SerialPort();
            // configure the port
            spObj.BaudRate = 9600;
            spObj.DataBits = 8;
            spObj.StopBits = StopBits.One;
            spObj.Parity = Parity.None;
            spObj.Handshake = Handshake.None; 
            spObj.ReadTimeout = SerialPort.InfiniteTimeout;

            Initalize();
        }


        #region IDisposable Members
        public void Dispose()
        {
            spObj.Close();
        }

        #endregion

        public void Initalize()
        {
            // Search the available com ports for Zaber controllers
            string[] portNames = SerialPort.GetPortNames();

            foreach (string strPort in portNames)
            {
                int returnCommand, returnDevice, returnData;
                
                // set this serial port object to the port name
                spObj.PortName = strPort;

                try
                {
                    spObj.Open();       // attempt to open the port, port could already be open
                    
                    // try to query the version number for all devices in the dongle
                    SendCommand(0, 51, 0);
                    Thread.Sleep(10);       // with out this 10 ms sleep the zaber just returns 1
                    ReadResponse(out returnDevice, out returnCommand, out returnData);

                    // if the return command is 51 then this is a zaber response
                    if (returnCommand == 51)
                    {
                        List<int> deviceList = new List<int>();
                        // add this device number to the device list
                        deviceList.Add(returnDevice);

                        try
                        {
                            do
                            {
                                // try 
                                ReadResponse(out returnDevice, out returnCommand, out returnData);
                                if (returnDevice == 51)
                                    deviceList.Add(returnDevice);
                            } while (returnCommand == 51);
                        }
                        catch (TimeoutException) { }   // time out means there is no more motors on this
                        
                        // zaber motor found break out of the com port opening loop
                        // flush the read buffer
                        SendCommand(0, 0, 0);    // reset the motor
                        Thread.Sleep(500);
                        spObj.DiscardInBuffer();
                        devices = deviceList.ToArray();
                        bInitalized = true;
                        break;
                    }
                }
                catch (UnauthorizedAccessException) {}   // the com port is already open, try the next com port
                catch (TimeoutException) {};             // no zabers were found on this com port
            }
            
            // if this couldn't be initalized throw a exception
            if (bInitalized == false)
            {
                Exception ex = new Exception("No Zaber Found");
                throw (ex);
            }            
        }

        private void SendCommand(int device, int command, int data)
        {
            // commands are sent in byte chunks
            byte [] bytes = new byte[6];

            bytes[0] = Convert.ToByte(device);
            bytes[1] = Convert.ToByte(command);

            byte [] dataBytes = BitConverter.GetBytes(data);

            // data bytes should be 4 bytes long
            if (dataBytes.Length >= 4)
            {
                bytes[2] = dataBytes[0];
                bytes[3] = dataBytes[1];
                bytes[4] = dataBytes[2];
                bytes[5] = dataBytes[3];
            }
            else
            {
                bytes[2] = 0;
                bytes[3] = 0;
                bytes[4] = 0;
                bytes[5] = 0;
            }

            // send the command out the comport
            spObj.Write(bytes, 0, 6);            
        }

        private void ReadResponse(out int device, out int command, out int data)
        {
            byte [] readBuffer = new byte[6];
            spObj.Read(readBuffer, 0, 6);

            device = Convert.ToInt32(readBuffer[0]);
            command = Convert.ToInt32(readBuffer[1]);

            if (command == 255)
            {
                Exception ex = new Exception("Zaber Command Error");
                throw (ex);
            }

            // comvert the remaining part of the return string to a integer
            data = BitConverter.ToInt32(readBuffer, 2);
            
            // clear out anything left
            spObj.DiscardInBuffer();
        }

        public byte[] ReadUntilTimeout(int timeout)
        {
            byte[] bytes = new byte[200];
            int currentTimeout = spObj.ReadTimeout;
             
            try
            {

                spObj.ReadTimeout = timeout;
                spObj.Read(bytes, 0, 200);
            }
            catch (TimeoutException ex)
            {

            }

            spObj.ReadTimeout = currentTimeout;

            return (bytes);
        }


        // Implementing the Zaber interface
        public void Reset(int device)
        {
            SendCommand(device, 0, 0);
        }

        public int Home(int device)
        {
            SendCommand(device, 1, 0);
            // get reply data
            int returnDevice, returnCommand, returnData;
            ReadResponse(out returnDevice, out returnCommand, out returnData);

            return (returnData);
        }

        public int Renumber(int device, int number)
        {
            SendCommand(device, 2, number);

            // get reply data
            Thread.Sleep(500);
            int returnDevice, returnCommand, returnData = 0;

            for (int index = 0; index < devices.Length; index++)
            {
                ReadResponse(out returnDevice, out returnCommand, out returnData);
                if (returnCommand != 2)
                {
                    // clear the input buffer
                    spObj.BaseStream.Flush();
                    spObj.DiscardInBuffer();
                    Exception ex = new Exception("Renumber Command Not 2: Command: " + returnCommand);
                    throw (ex);
                }
            }

            return (returnData);
        }

        public int MoveAbsolute(int device, int position)
        {
            // for the response
            for (retryCount = 0; retryCount < maxRetries; retryCount++)
            {
                // send the move command
                SendCommand(device, 20, position);

                ReadResponse(out returnDevice, out returnCommand, out returnData);

                if (returnDevice == device && returnCommand == 20)
                {
                    retryCount = 0;
                    break;      // it worked - leave
                }

                // it didn't work
                // clear the read buffer                
                // ReadUntilTimeout(readUntilTimeoutTimeout);
                //spObj.BaseStream.Flush();
                //spObj.DiscardInBuffer();
                Thread.Sleep(retrySleepTime);
            }
                        
            if (retryCount >= maxRetries)
            {
                // clear the input buffer
                spObj.BaseStream.Flush();
                spObj.DiscardInBuffer();

                string msg = "Move Absolute: Response Not the same as Command - Device Sent: ";
                msg += device;
                msg += ", Device Received: ";
                msg += returnDevice;
                msg += ", Command Sent: 20, Comand Recived: ";
                msg += returnCommand;
                Exception ex = new Exception(msg);
                throw (ex);

            }
    
            // most of the time the zaber returns the final position
            // sometimes the zaber returns the inital position so reread the current position
            // when the move is complete
            returnData = ReturnCurrentPosition(device);
            
            return (returnData);
        }

        public int MoveRelative(int device, int position)
        {
            // for the response
            
            // send the move command
            SendCommand(device, 21, position);

            ReadResponse(out returnDevice, out returnCommand, out returnData);
                    
            if (returnDevice != device || returnCommand != 21)
            {
                // clear the input buffer
                spObj.BaseStream.Flush();
                spObj.DiscardInBuffer();

                string msg = "Move Absolute: Response Not the same as Command - Device Sent: ";
                msg += device;
                msg += ", Device Received: ";
                msg += returnDevice;
                msg += ", Command Sent: 20, Comand Recived: ";
                msg += returnCommand;
                Exception ex = new Exception(msg);
                throw (ex);

            }

            // the zaber is suposed to return it's final position
            // instead the zaber returns a bogus number
            // read the current position at the end of the move and return that
            returnData = ReturnCurrentPosition(device);

            return (returnData);
        }

        public int Stop(int device)
        {

            return (0);
        }

        public void ReadWriteEEPROM(int device, int address, int data)
        {

        }

        public void RestoreFactoryDefaultSettings(int device)
        {

        }

        public void SetDeviceMode(int device, Mode modeObj, bool enabled)
        {

        }

        public void SetStartSpeed(int device, double speed)
        {

        }

        public void SetTargetSpeed(int device, double speed)
        {

        }

        public void SetAcceleration(int device, double acceleration)
        {
        }

        public void SetRange(int device, int rangeInMicroSteps)
        {

        }

        public void SetCurrentPosition(int device, int position)
        {
        }

        public void SetMaximumRelativeMove(int device, int maximumRelativeMoveInMicroSteps)
        {

        }

        public void SetAlias(int device, int aliasDeviceNumber)
        {

        }

        public int ReturnDeviceID(int device)
        {

            return (0);
        }

        public int ReturnFirmwareVersion(int device)
        {
            return (0);
        }

        public double ReturnPowerSupplyVoltage(int device)
        {
            return (0);
        }

        public int ReturnSetting(int device, int setting)
        {

            return (0);
        }

        public int ReturnCurrentPosition(int device)
        {
            for (retryCount = 0; retryCount < maxRetries; retryCount++)
            {
                SendCommand(device, 60, 0);
                ReadResponse(out returnDevice, out returnCommand, out returnData);

                if ((returnDevice == device) && returnCommand == 60)
                {
                    retryCount = 0;
                    break;      // it worked - leave
                }

                Thread.Sleep(retrySleepTime);
            }

            if (retryCount >= maxRetries)
            {
                // clear the input buffer
                spObj.BaseStream.Flush();
                spObj.DiscardInBuffer();

                string msg = "Return Current Position: Response Not the same as Command \r\nDevice Sent: ";
                msg += device;
                msg += ", Device Received: ";
                msg += returnDevice;
                msg += "\r\nCommand Sent: 60, Comand Recived: ";
                msg += returnCommand;
                msg += "\r\n";
                Exception ex = new Exception(msg);
                throw (ex);
            }
            
            return (returnData);
        }
    }
}
