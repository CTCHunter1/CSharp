using System;
using System.Collections.Generic;
using System.Text;
using System.IO.Ports;
using System.Threading;

// Modified from NewportESP100.cs

namespace Lab.Drivers.Motors
{
    

    public class ASILV4000 : IDisposable
    {
        public const int InfiniteTimeout = SerialPort.InfiniteTimeout;
        private SerialPort spObj;
        public bool b_initalize = false;

        ASILV4000Axis[] axisArr = null;
        int numAxis = 0;

        public enum MoveStatus { STOPED, MOVING };
        int invalidRespCount = 0;


        public ASILV4000()
        {
            spObj = new SerialPort(); 
            // configure the port
            spObj.BaudRate = 115200;
            spObj.DataBits = 8;
            spObj.StopBits = StopBits.One;
            spObj.Parity = Parity.None;
            // sp_obj.Handshake = Handshake.RequestToSend; // necessary but don't enable before we know
                                                           // where the contoller is

            // controller sends \r \n EOT(End of Text) after each line
            spObj.NewLine = "\r\n" + Convert.ToChar(0x03);      // all commands are terminated with for the ASI controller
            //spObj.NewLine = "\r\n";  
            
            // this makes them execute
            spObj.ReadTimeout = 100;
            
            Initalize();       

        }

        // destructor releases the com port
        // not sure if it's necessary
        ~ASILV4000()
        {
            spObj.Close();
        }


        public void Initalize()
        {
            // Search the available com ports for ESP100 controllers
            string[] arr_str_names = SerialPort.GetPortNames();
            
            foreach (string str_port in arr_str_names)
            {
                
                try
                {
                    spObj.PortName = str_port;
                    // open the port
                    spObj.Open();

                    // clear the com port object
                    spObj.DiscardInBuffer();

                    ReadMovementStatusXY();
                    
                    //spObj.BaseStream.Flush();                   
                    

                    return;                  
                }
                catch (Exception ex)
                {
                    if(spObj.IsOpen == true)
                       spObj.BaseStream.Flush();   // this can only be performed on an open port
                    
                    spObj.Close();
                }
            }

            // if we are here there is no contoller, throw a exception
            Exception nocont_ex = new Exception("No ASI LV4000 Controller Found");

            throw (nocont_ex);
        }

     
        public ASILV4000Axis [] GetAxes()
        {
           spObj.DiscardInBuffer();
           spObj.DiscardOutBuffer();

            
           List<ASILV4000Axis> axisList =  new List<ASILV4000Axis>();
           for(int i = 1; i <= 3; i++)
           {
               try
               {
                   ASILV4000Axis newAxisObj = new ASILV4000Axis(i, this);
                   axisList.Add(newAxisObj);
               }
               catch { }
           }

           // return all the axis found
           if (axisList.Count >= 1)
           {
               return (axisList.ToArray());
           }
           else
           {
               return (null);
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

        public MoveStatus ReadMovementStatusXY()
        {
            // clear the com port object
            //spObj.DiscardInBuffer();
            //spObj.BaseStream.Flush();
            spObj.Write("2H/\r");

            string returnString = "";
            
            try
            {
                returnString = spObj.ReadLine();
                //string returnString = spObj.ReadExisting();

                //string returnStringLine2 = spObj.ReadLine();

                char c1 = '\0';
                char c2 = '\0';

                if (returnString.Length >= 2)
                {
                    c1 = returnString[0];
                    c2 = returnString[1];
                }

                if (returnString == "B")
                {
                    invalidRespCount = 0; // reset the counter
                    return (MoveStatus.MOVING);
                }
                if (returnString == "N")
                {
                    invalidRespCount = 0; // reset the counter
                    return (MoveStatus.STOPED);
                }

                // retry the get status command up to 3 times
                if (invalidRespCount <= 3)
                {
                    invalidRespCount++;
                    return (ReadMovementStatusXY());
                }
            }
            catch
            {
                if (invalidRespCount <= 3)
                {
                    invalidRespCount++;
                    return (ReadMovementStatusXY());
                }
            }
            Exception ex = new Exception("Invalid Response - Response: " + returnString);
            throw (ex);
        }

        public MoveStatus ReadMovementStatusZ()
        {
            // clear the com port object
            //spObj.DiscardInBuffer();
            //spObj.BaseStream.Flush();
            spObj.Write("1H/\r");

            try
            {
                string returnString = spObj.ReadLine();
                //string returnString = spObj.ReadExisting();

                //string returnStringLine2 = spObj.ReadLine();

                char c1 = '\0';
                char c2 = '\0';

                if (returnString.Length >= 2)
                {
                    c1 = returnString[0];
                    c2 = returnString[1];
                }

                if (returnString == "B")
                {
                    invalidRespCount = 0;
                    return (MoveStatus.MOVING);
                }

                if (returnString == "N")
                {
                    invalidRespCount = 0;
                    return (MoveStatus.STOPED);
                }

                Exception ex = new Exception("Invalid Response");
                throw (ex); 
            }
            catch (Exception ex)
            {
                // retry the get status command up to 3 times
                if (invalidRespCount <= 3)
                {
                    invalidRespCount++;
                    return (ReadMovementStatusZ());
                }
                else
                {
                    throw (ex);
                }
            }
        }
 
        public double [] ReadPositionXY()
        {
            // clear the com port object
            //spObj.BaseStream.Flush();
           // spObj.DiscardInBuffer();

            char[] delimiterChars = { ' ' };
            
            spObj.Write("2HW X Y\r");                   
            string returnString = spObj.ReadLine();

            string [] stringArr = returnString.Split(delimiterChars);

            double[] statePos = new double[2];

            statePos[0] = Convert.ToDouble(stringArr[1]);
            statePos[1] = Convert.ToDouble(stringArr[2]);

            return (statePos);            
        }

        public double[] ReadSpeedXY()
        {
            // clear the com port object
            //spObj.BaseStream.Flush();
            // spObj.DiscardInBuffer();

            char[] delimiterChars = { ' ', '=' };

            spObj.Write("2HS X? Y?\r");
            string returnString = spObj.ReadLine();

            string[] stringArr = returnString.Split(delimiterChars);

            double[] statePos = new double[2];

            statePos[0] = Convert.ToDouble(stringArr[2]);
            statePos[1] = Convert.ToDouble(stringArr[4]);

            return (statePos);
        }

        public double ReadSpeedX()
        {
            // clear the com port object
            //spObj.BaseStream.Flush();
            // spObj.DiscardInBuffer();

            char[] delimiterChars = { ' ', '=' };

            spObj.Write("2HS X? \r");
            string returnString = spObj.ReadLine();

            string[] stringArr = returnString.Split(delimiterChars);
            double statePos = 0;

            try
            {
                statePos = Convert.ToDouble(stringArr[2]);
            }
            catch(Exception ex)
            {
                if (invalidRespCount <= 3)
                {
                    invalidRespCount++;
                    return (ReadSpeedX());
                }
                else
                {
                    throw (ex);
                }
            }

            invalidRespCount = 0;
            return (statePos);
        }

        public double ReadSpeedY()
        {
            // clear the com port object
            //spObj.BaseStream.Flush();
            // spObj.DiscardInBuffer();

            char[] delimiterChars = { ' ', '=' };

            spObj.Write("2HS Y?\r");
            string returnString = spObj.ReadLine();

            string[] stringArr = returnString.Split(delimiterChars);
            double statePos = 0;

            try
            {
                 statePos = Convert.ToDouble(stringArr[2]);
            }
            catch (Exception ex)
            {
                if (invalidRespCount < 3)
                {
                    spObj.BaseStream.Flush();
                    return (ReadSpeedY());
                }
                else
                {
                    throw (ex);
                }
            }

            invalidRespCount = 0;
            return (statePos);
        }

        public double ReadSpeedZ()
        {
            // clear the com port object
            //spObj.BaseStream.Flush();
            // spObj.DiscardInBuffer();

            char[] delimiterChars = { ' ', '=' };

            spObj.Write("1HS Z?\r");
            string returnString = spObj.ReadLine();

            string[] stringArr = returnString.Split(delimiterChars);

            double statePos = 0;

            try
            {
                statePos = Convert.ToDouble(stringArr[2]);
            }
            catch (Exception ex)
            {
                if (invalidRespCount < 3)
                {
                    spObj.BaseStream.Flush();
                    return (ReadSpeedY());
                }
                else
                {
                    throw (ex);
                }
            }

            return (statePos);
        }

        public void SetSpeedXY(double xSpeed, double ySpeed)
        {
            string moveCmd = string.Format("2HS X={0} Y={1}\r", Math.Round(xSpeed, 2), Math.Round(ySpeed, 2));

            spObj.Write(moveCmd);

            char c = Convert.ToChar(spObj.ReadChar());

            if (c == ':')
            {

                string returnString = spObj.ReadLine();

                // expected return string
                if (returnString == "A ")
                {
                    return;
                }
                else
                {
                    Exception ex = new Exception(returnString);
                    throw (ex);
                }
            }
        }

        public void SetSpeedX(double speed)
        {
            string moveCmd = string.Format("2HS X={0}\r", Math.Round(speed, 2));

            spObj.Write(moveCmd);

            char c = Convert.ToChar(spObj.ReadChar());

            if (c == ':')
            {

                string returnString = spObj.ReadLine();

                // expected return string
                if (returnString.Contains("A") == true)
                {
                    return;
                }
                else
                {
                    Exception ex = new Exception(returnString);
                    throw (ex);
                }
            }
        }

        public void SetSpeedY(double speed)
        {
            string moveCmd = string.Format("2HS Y={0}\r", Math.Round(speed, 2));

            spObj.Write(moveCmd);

            char c = Convert.ToChar(spObj.ReadChar());

            if (c == ':')
            {

                string returnString = spObj.ReadLine();

                // expected return string
                if (returnString.Contains("A") == true)
                {
                    return;
                }
                else
                {
                    Exception ex = new Exception(returnString);
                    throw (ex);
                }
            }
        }

        public void SetSpeedZ(double speed)
        {
            string moveCmd = string.Format("1HS Z={0}\r", Math.Round(speed, 2));

            spObj.Write(moveCmd);

            char c = Convert.ToChar(spObj.ReadChar());

            if (c == ':')
            {

                string returnString = spObj.ReadLine();

                // expected return string
                if (returnString == "A ")
                {
                    return;
                }
                else
                {
                    Exception ex = new Exception(returnString);
                    throw (ex);
                }
            }
        }

        public double ReadPositionX()
        {
            // clear the com port object
            //spObj.BaseStream.Flush();
            // spObj.DiscardInBuffer();

            char[] delimiterChars = { ' ', '=' };

            spObj.Write("2HW X\r");
            string returnString = spObj.ReadLine();

            string[] stringArr = returnString.Split(delimiterChars);

            double pos = 0;

            if (stringArr.Length == 3)
            {
                pos = Convert.ToDouble(stringArr[1]);
            }
            else if (stringArr.Length == 4)
            {
                pos = Convert.ToDouble(stringArr[2]);
            }
           
            return (pos);
        }

        public double ReadPositionY()
        {
            // clear the com port object
            //spObj.BaseStream.Flush();
            // spObj.DiscardInBuffer();

            char[] delimiterChars = { ' ', '=' };


            spObj.Write("2HW Y\r");

            string returnString = spObj.ReadLine();

            string[] stringArr = returnString.Split(delimiterChars);

            double pos = 0;


            if (stringArr.Length == 3)
            {
                pos = Convert.ToDouble(stringArr[1]);
            }
            else if (stringArr.Length == 4)
            {
                pos = Convert.ToDouble(stringArr[2]);
            }

            return (pos);
        }

        public double ReadPositionZ()
        {
            // clear the com port object
            //spObj.BaseStream.Flush();
            // spObj.DiscardInBuffer();

            char[] delimiterChars = { ' ', '=' };
            
            spObj.Write("1HW Z\r");
            string returnString = spObj.ReadLine();

            string[] stringArr = returnString.Split(delimiterChars);

            double pos = 0;


            if (stringArr.Length == 3)
            {
                pos = Convert.ToDouble(stringArr[1]);
            }
            else if (stringArr.Length == 4)
            {
                pos = Convert.ToDouble(stringArr[2]);
            }

            return (pos);
        }

        public void MoveX(double pos)
        {
            // clear the com port object
            // spObj.BaseStream.Flush();
            // spObj.DiscardInBuffer();

            string moveCmd = string.Format("2HM X={0} \r", Math.Round(pos, 1));

            spObj.Write(moveCmd);

            try
            {
                string returnString = spObj.ReadLine();


                // expected return string
                if (returnString.Contains("A") == true)
                {
                    invalidRespCount = 0;
                    return;
                }
                else
                {
                    Exception ex = new Exception(returnString);
                    throw (ex);
                }
            }
            catch (Exception ex)
            {
                invalidRespCount++;
                if (invalidRespCount <= 3)
                {
                    spObj.BaseStream.Flush();
                    MoveX(pos);
                }
                else
                {
                    throw (ex);
                }
            }
            
        }

        public void MoveY(double pos)
        {
            // clear the com port object
            // spObj.BaseStream.Flush();
            // spObj.DiscardInBuffer();

            string moveCmd = string.Format("2HM Y={0}\r", Math.Round(pos, 1));

            spObj.Write(moveCmd);

            try
            {
                string returnString = spObj.ReadLine();

                // expected return string
                if (returnString.Contains("A") == true)
                {
                    invalidRespCount = 0;
                    return;

                }
                else
                {
                    Exception ex = new Exception(returnString);
                    throw (ex);
                }
            }
            catch (Exception ex)
            {
                invalidRespCount++;
                if (invalidRespCount <= 3)
                {
                    MoveX(pos);
                }
                else
                {
                    throw (ex);
                }
            }
        }

        public void MoveZ(double zPos)
        {
            // clear the com port object
            // spObj.BaseStream.Flush();
            // spObj.DiscardInBuffer();

            string moveCmd = string.Format("1HM Z={0}\r", Math.Round(zPos, 1));

            spObj.Write(moveCmd);

            char c = Convert.ToChar(spObj.ReadChar());

            if (c == ':')
            {

                string returnString = spObj.ReadLine();

                // expected return string
                if (returnString.Contains("A") == true)
                {
                    return;
                }
                else
                {
                    Exception ex = new Exception(returnString);
                    throw (ex);
                }
            }
        }

        public void MoveRelativeX(double pos)
        {
            // clear the com port object
            // spObj.BaseStream.Flush();
            // spObj.DiscardInBuffer();

            string moveCmd = string.Format("2HR X={0}\r", Math.Round(pos, 1));

            spObj.Write(moveCmd);

            char c = Convert.ToChar(spObj.ReadChar());

            if (c == ':')
            {

                string returnString = spObj.ReadLine();

                // expected return string
                if (returnString == "A " || returnString == "A")
                {
                    return;
                }
                else
                {
                    Exception ex = new Exception(returnString);
                    throw (ex);
                }
            }
        }

        public void MoveRelativeY(double pos)
        {
            // clear the com port object
            // spObj.BaseStream.Flush();
            // spObj.DiscardInBuffer();

            string moveCmd = string.Format("2HR Y={0}\r", Math.Round(pos, 1));

            spObj.Write(moveCmd);

            char c = Convert.ToChar(spObj.ReadChar());

            if (c == ':')
            {

                string returnString = spObj.ReadLine();

                // expected return string
                if (returnString == "A " || returnString == "A")
                {
                    return;
                }
                else
                {
                    Exception ex = new Exception(returnString);
                    throw (ex);
                }
            }
        }
    
        public void MoveRelativeZ(double zPos)
        {
            // clear the com port object
            // spObj.BaseStream.Flush();
            // spObj.DiscardInBuffer();

            string moveCmd = string.Format("1HR Z={0}\r", Math.Round(zPos, 1));

            spObj.Write(moveCmd);

            char c = Convert.ToChar(spObj.ReadChar());

            if (c == ':')
            {

                string returnString = spObj.ReadLine();

                // expected return string
                if (returnString == "A ")
                {
                    return;
                }
                else
                {
                    Exception ex = new Exception(returnString);
                    throw (ex);
                }
            }
        }

        public void MoveXY(double xPos, double yPos)
        {

            // clear the com port object
           // spObj.BaseStream.Flush();
           // spObj.DiscardInBuffer();

            string moveCmd = string.Format("2HM X={0} Y={1}\r", Math.Round(xPos,1), Math.Round(yPos,1));

            spObj.Write(moveCmd);

            char c = Convert.ToChar(spObj.ReadChar());

            if (c == ':')
            {

                string returnString = spObj.ReadLine();

                // expected return string
                if (returnString == "A ")
                {
                    return;
                }
                else
                {
                    Exception ex = new Exception(returnString);
                    throw (ex);
                }
            }
        }

        public void MoveRelativeXY(double xPos, double yPos)
        {

            // clear the com port object
            // spObj.BaseStream.Flush();
            // spObj.DiscardInBuffer();

            string moveCmd = string.Format("2HR X={0} Y={1}\r", Math.Round(xPos, 1), Math.Round(yPos, 1));

            spObj.Write(moveCmd);

            char c = Convert.ToChar(spObj.ReadChar());

            if (c == ':')
            {

                string returnString = spObj.ReadLine();

                // expected return string
                if (returnString == "A ")
                {
                    return;
                }
                else if (returnString == "A")
                {
                    return;
                }
                else
                {
                    Exception ex = new Exception(returnString);
                    throw (ex);
                }
            }
        }

        public void ZeroXY()
        {
            spObj.Write("2HZ\r");

            char c = Convert.ToChar(spObj.ReadChar());

            if (c == ':')
            {

                string returnString = spObj.ReadLine();

                // expected return string
                if (returnString == "A ")
                {
                    return;
                }
                else if (returnString == "A")
                {
                    return;
                }
                else
                {
                    Exception ex = new Exception("Unexpected Response to Zero: " + returnString);
                    throw (ex);
                }
            }
        }

        public void ZeroZ()
        {
            spObj.Write("1HZ\r");

            char c = Convert.ToChar(spObj.ReadChar());

            if (c == ':')
            {

                string returnString = spObj.ReadLine();

                // expected return string
                if (returnString == "A ")
                {
                    return;
                }
                else if (returnString == "A")
                {
                    return;
                }
                else
                {
                    Exception ex = new Exception("Unexpected Response to Zero: " + returnString);
                    throw (ex);
                }
            }
        }

        public void HaltZ()
        {
            spObj.Write("1H\\\r");

            char c = Convert.ToChar(spObj.ReadChar());

            if (c == ':')
            {

                string returnString = spObj.ReadLine();

                // expected return string
                if (returnString == "N-21 ")
                {
                    return;
                }
                else if (returnString == "N-21")
                {
                    return;
                }
                else if (returnString == "A")
                {
                    return;
                }
                else
                {
                    Exception ex = new Exception(returnString);
                    throw (ex);
                }
            }
        }


        public void HaltXY()
        {
            spObj.Write("2H\\\r");

            char c = Convert.ToChar(spObj.ReadChar());

            if (c == ':')
            {

                string returnString = spObj.ReadLine();

                // expected return string
                if (returnString == "N-21")
                {
                    return;
                }
                else if (returnString == "N-21")
                {
                    return;
                }
                else if (returnString.Contains("A") == true)
                {
                    // device is not moving
                    return;
                }
                else
                {
                    Exception ex = new Exception("Unexpected Reply: " + returnString);
                    throw (ex);
                }
            }
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
