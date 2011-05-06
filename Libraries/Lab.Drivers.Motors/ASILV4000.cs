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

        NewportESP100Axis[] axisArr = null;
        int numAxis = 0;

        public enum MoveStatus { STOPED, MOVING }; 


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
            spObj.NewLine = "\r\n";                        // all commands are terminated with for the ASI controller
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

                    ReadMovementStatus();
                    
                    //spObj.BaseStream.Flush();                   
                    

                    return;                  
                }
                catch (Exception ex)
                {
                    spObj.BaseStream.Flush();  
                    spObj.Close();
                }
            }

            // if we are here there is no contoller, throw a exception
            Exception nocont_ex = new Exception("No ASI LV4000 Controller Found");

            throw (nocont_ex);
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

        public MoveStatus ReadMovementStatus()
        {
            // clear the com port object
            // spObj.DiscardInBuffer();
            spObj.BaseStream.Flush();
            spObj.Write("2H/\r");
            
            string returnString = spObj.ReadLine();

            if (returnString.Length >= 2)
            {
                char c1 = returnString[0];
                char c2 = returnString[1];
            }

            if (returnString == "B")
                return (MoveStatus.MOVING);

            if (returnString == "N")
                return (MoveStatus.STOPED);

            Exception ex = new Exception("Invalid Response");
            throw (ex);
        }
 
        public double [] ReadPosition()
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

        public void Move(double xPos, double yPos)
        {
            // clear the com port object
           // spObj.BaseStream.Flush();
           // spObj.DiscardInBuffer();

            string moveCmd = string.Format("2HM X={0} Y={1}\r", xPos, yPos);

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
