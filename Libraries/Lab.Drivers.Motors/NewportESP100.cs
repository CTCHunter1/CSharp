using System;
using System.Collections.Generic;
using System.Text;
using System.IO.Ports;
using System.Threading;


namespace Lab.Drivers.Motors
{
    public enum Direction {Positive, Negative};
    public enum HomeSearchMode { ZeroPosition = 0, HomeAndIndex = 1, Home = 2 };

    public class NewportESP100 : IDisposable
    {
        public const int InfiniteTimeout = SerialPort.InfiniteTimeout;
        private SerialPort spObj;
        public bool b_initalize = false;

        NewportESP100Axis[] axisArr = null;
        int numAxis = 0;                


        public NewportESP100()
        {
            spObj = new SerialPort(); 
            // configure the port
            spObj.BaudRate = 19200;
            spObj.DataBits = 8;
            spObj.StopBits = StopBits.One;
            spObj.Parity = Parity.None;
            // sp_obj.Handshake = Handshake.RequestToSend; // necessary but don't enable before we know
                                                           // where the contoller is
            spObj.NewLine = "\r\n";                      // all commands are terminated with
            spObj.ReadTimeout = 100;
            

            Initalize();
        

        }

        // destructor releases the com port
        // not sure if it's necessary
        ~NewportESP100()
        {
            spObj.Close();
        }


        public void Initalize()
        {
            // Search the available com ports for ESP100 controllers
            string[] arr_str_names = SerialPort.GetPortNames();
            
            foreach (string str_port in arr_str_names)
            {
                string str_resp = "";
                char [] temp = new char[40];

                try
                {
                    spObj.PortName = str_port;
                    // open the port
                    spObj.Open();

                    try
                    {
                        // the device requires RTS hardware control
                        // if it is enabled before this point it hangs the system
                        spObj.RtsEnable = true;
                        str_resp = ReadControllerFirmwareVersion();
                        // remove everything but themodel number
                        str_resp = str_resp.Remove(6);

                        if (str_resp == "ESP100")
                        {
                            // we found the controller
                            spObj.Handshake = Handshake.RequestToSend;
                            b_initalize = true;
                            // find the number of axis
                            numAxis = FindNumAxis();

                            axisArr = new NewportESP100Axis[numAxis];

                            // initalize the axis 
                            for (int index = 0; index < numAxis; index++)
                            {
                                axisArr[index] = new NewportESP100Axis(index + 1, this);
                            }

                            // exit this loop
                            return;
                        }
                    }
                    catch
                    {
                        // don't care don't do anything
                    }

                    spObj.Close();
                }
                catch (Exception)
                {
                }
            }

            // if we are here there is no contoller, throw a exception
            Exception nocont_ex = new Exception("No ESP100 Controller Found");

            throw (nocont_ex);
        }

        public int FindNumAxis()
        {
            // loop through and see how many axes there are
            int axisNum = 0;
            string modelNumber;
            string serialNumber;
                       
            do
            {              
                axisNum++;
                ReadStageModelAndSerialNumber(axisNum, out modelNumber, out serialNumber);                                               

            } while (modelNumber != "Unknown"); 

            // the last axis number doesn't exist so decrement by 1;
            axisNum--;

            return (axisNum);
        }

        public NewportESP100Axis []Axes
        {
            get
            {
                return (axisArr);
            }
        }

        public int ReadTimeout
        {
            set
            {
                spObj.ReadTimeout = value;
            }

            get
            {
                return (spObj.ReadTimeout);
            }
        }

        // Begin Newport Interface Functions
        // General Mode Functions
        public void MotorOff(int axis)
        {
            spObj.WriteLine(axis + "MF");
        }

        public void MotorOn(int axis)
        {
            spObj.WriteLine(axis + "MO");
        }


        //Status Functions
        public double ReadDesiredPosition(int axis)
        {
            spObj.WriteLine(axis + "DP?");

            string returnString = spObj.ReadLine();

            return (Convert.ToDouble(returnString));
        }

        public double ReadDesiredVelocity(int axis)
        {
            spObj.WriteLine(axis + "DV");

            string returnString = spObj.ReadLine();

            return (Convert.ToDouble(returnString));    
        }

        public void ReadStageModelAndSerialNumber(int axis, out string modelNumber, out string serialNumber)
        {
            spObj.WriteLine(axis + "ID?");

            string returnString = spObj.ReadLine();

            string[] parsedString = returnString.Split(',');

            // if there is no axis or there is no motor attached the return string will be "Unknown"
            if (returnString == "Unknown" || parsedString.Length < 2)
            {
                modelNumber = "Unknown";
                serialNumber = "Unknown";
            }
            else
            {
                modelNumber = parsedString[0];
                serialNumber = parsedString[1];
            }           
        }

        public bool ReadMotionDoneStatus(int axis)
        {
            spObj.WriteLine(axis + "MD?");

            string returnString = spObj.ReadLine();

            int statusInt = Convert.ToInt32(returnString);

            return(Convert.ToBoolean(statusInt));
        }

        public void ReadErrorMessage(out int errorCode, out int timeStamp, out string message)
        {
            spObj.WriteLine("TB?");

            string returnString = spObj.ReadLine();

            // seperate out the values 
            string[] parsedStrings = returnString.Split(',');

            errorCode = Convert.ToInt32(parsedStrings[0]);
            timeStamp = Convert.ToInt32(parsedStrings[1]);
            message = parsedStrings[2];
        }

        public int ReadErrorCode()
        {
            spObj.WriteLine("TE?");

            string returnString = spObj.ReadLine();

            int errorCode = Convert.ToInt32(returnString);

            return (errorCode);
        }

        public int ReadActualPosition(int axis)
        {
            spObj.WriteLine(axis + "TP");

            string returnString = spObj.ReadLine();

            return (Convert.ToInt32(Convert.ToDouble(returnString)));
        }

        public double ReadActualVelocity(int axis)
        {
            spObj.WriteLine(axis + "TV");

            string returnString = spObj.ReadLine();

            return (Convert.ToDouble(returnString));
        }

        public string ReadControllerFirmwareVersion()
        {
            spObj.WriteLine("VE ?");

            return (spObj.ReadLine());
        }

        public int ReadAvailableMemory()
        {
            spObj.WriteLine("XM");

            string returnString = spObj.ReadLine();

            return (Convert.ToInt32(returnString));    
        }

        // Motion & Position Control
        public void AbortMotion()
        {
            spObj.WriteLine("AB");
        }

        public void DefineHome(int axis, double position)
        {
            spObj.WriteLine(axis + "DH" + position.ToString("F4"));
        }

        public double GetHome(int axis)
        { 
            spObj.WriteLine(axis + "DH?");

            string returnString = spObj.ReadLine();

            return (Convert.ToDouble(returnString));    
        }

        public void MoveToHardwareTravelLimit(int axis, Direction dr)
        {
            switch (dr)
            {
                case Direction.Positive:
                    spObj.WriteLine(axis + "MT+");
                    break;
                
                case Direction.Negative:
                default:
                    spObj.WriteLine(axis + "MT-");
                    break;
            }
        }

        public void MoveIndefinitely(int axis, Direction dr)
        {
            switch (dr)
            {
                case Direction.Positive:
                    spObj.WriteLine(axis + "MV+");
                    break;

                case Direction.Negative:
                default:
                    spObj.WriteLine(axis + "MV-");
                    break;
            }
        }

        public void SearchForHome(int axis, HomeSearchMode hsm)
        {
            spObj.WriteLine(axis + "OR" + hsm);
        }

        public void MoveToAbsolutePosition(int axis, double position)
        {
            spObj.WriteLine(axis + "PA" + position.ToString("F4"));
        }

        public void MoveToRelativePosition(int axis, double position)
        {
            string movePoistion = position.ToString("F4");

            spObj.WriteLine(axis + "PR" + position.ToString("F4"));
        }

        public void StopMotion(int axis)
        {
            spObj.WriteLine(axis + "ST");
        }
        
        // Trajectory Definition
        public void SetAcceleration(int axis, double acceleration)
        {
            spObj.WriteLine(axis + "AC" + acceleration.ToString("F4"));
        }

        public double GetAcceleration(int axis)
        {
            spObj.WriteLine(axis + "AC?");

            string returnString = spObj.ReadLine();

            return (Convert.ToDouble(returnString));
        }

        public void SetEStopDeceleration(int axis, double deceleration)
        {
            spObj.WriteLine(axis + "AE" + deceleration.ToString("F4"));
        }

        public double GetEStopDeceration(int axis)
        {
            spObj.WriteLine(axis + "AE?");

            string returnString = spObj.ReadLine();

            return (Convert.ToDouble(returnString));
        }

        public void SetDeceleration(int axis, double deceleration)
        {
            spObj.WriteLine(axis + "AG" + deceleration.ToString("F4"));
        }

        public double GetDeceleration(int axis)
        {
            spObj.WriteLine(axis + "AG?");

            string returnString = spObj.ReadLine();

            return (Convert.ToDouble(returnString));
        }

        public void SetMaximumAcceleration(int axis, double acceleration)
        {
            spObj.WriteLine(axis + "AU" + acceleration.ToString("F4"));
        }

        public double GetMaximumAcceleration(int axis)
        {
            spObj.WriteLine(axis + "AU?");

            string returnString = spObj.ReadLine();

            return (Convert.ToDouble(returnString));
        }

        // Unimplemented
        // Set Jog High Speed
        // Set Jog Low Speed
        

        public void SetJerkRate(int axis, double jerkRate)
        {
            spObj.WriteLine(axis + "JK" + jerkRate.ToString("F4"));
        }

        public double GetJerkRate(int axis)
        {
            spObj.WriteLine(axis + "JK?");

            string returnString = spObj.ReadLine();

            return (Convert.ToDouble(returnString));
        }

        public void SetHomeSearchHighSpeed(int axis, double speed)
        {
            spObj.WriteLine(axis + "OH" + speed.ToString("F4"));
        }

        public double GetHomeSearchHighSpeed(int axis)
        {
            spObj.WriteLine(axis + "OH?");

            string returnString = spObj.ReadLine();

            return (Convert.ToDouble(returnString));
        }

        public void UpdateServoFilter()
        {
            spObj.WriteLine("UF");
        }

        public void SetVelocity(int axis, double velocity)
        {
            spObj.WriteLine(axis + "VA" + velocity.ToString("F4"));
        }

        public double GetVelocity(int axis)
        {
            spObj.WriteLine(axis + "VA?");
            
            string returnString = spObj.ReadLine();

            return (Convert.ToDouble(returnString));
        }

        public void SetMaximumVelocity(int axis, double velocity)
        {
            spObj.WriteLine(axis + "VU" + velocity.ToString("F4"));
        }

        public double GetMaximumVelocity(int axis)
        {
            spObj.WriteLine(axis + "VU?");
            
            string returnString = spObj.ReadLine();

            return (Convert.ToDouble(returnString));   

        }

        public void SetBaseVelocity(int axis, double velocity)
        {
            spObj.WriteLine(axis + "VB" + velocity.ToString("F4"));
        }

        public double GetBaseVelocity(int axis)
        {
            spObj.WriteLine(axis + "VB?");

            string returnString = spObj.ReadLine();

            return (Convert.ToDouble(returnString));
        }

        // Flow Control and Sequencing

        // **** Unimplemented
        // Define Label
        // Jump to Label

        public void WaitForAbsolutePositionCrossing(int axis, double position)
        {
            spObj.WriteLine(axis + "WP" + position.ToString("F4"));
        }

        public void WaitForMotionStop(int axis, int delay)
        {
            spObj.WriteLine(axis + "WS" + delay);
        }

        public void Wait(int delay)
        {
            spObj.WriteLine("WT" + delay);
        }

        // Unimplemented Functional Groups
        // Group Functions
        // Digital Filters
        // Master-Slave Mode
        // Programing

        #region IDisposable Members

        public void Dispose()
        {
            spObj.Close();
        }

        #endregion
    }
}
