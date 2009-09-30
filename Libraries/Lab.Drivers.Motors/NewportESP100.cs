using System;
using System.Collections.Generic;
using System.Text;
using System.IO.Ports;
using System.Threading;


namespace Lab.Drivers.Motors
{
    public class NewportESP100
    {
        private SerialPort sp_obj;
        public bool b_initalize = false;

        public NewportESP100()
        {
            sp_obj = new SerialPort(); 
            // configure the port
            sp_obj.BaudRate = 19200;
            sp_obj.DataBits = 8;
            sp_obj.StopBits = StopBits.One;
            sp_obj.Parity = Parity.None;
            // sp_obj.Handshake = Handshake.RequestToSend; // necessary but don't enable before we know
                                                           // where the contoller is
            sp_obj.NewLine = "\r";                      // all commands are terminated with
            sp_obj.ReadTimeout = 100;                     
        }

        public void Initalize()
        {
            // Search the available com ports for ESP100 controllers
            string[] arr_str_names = SerialPort.GetPortNames();
            
            foreach (string str_port in arr_str_names)
            {
                string str_resp = "";
                char [] temp = new char[40];

                sp_obj.PortName = str_port;
                // open the port
                sp_obj.Open();

                try
                {
                    // the device requires RTS hardware control
                    // if it is enabled before this point it hangs the system
                    sp_obj.RtsEnable = true;
                    sp_obj.WriteLine("VE ?");
                    str_resp = sp_obj.ReadLine();

                    // remove everything but themodel number
                    str_resp = str_resp.Remove(6);

                    if (str_resp == "ESP100")
                    {
                        // we found the controller
                        sp_obj.Handshake = Handshake.RequestToSend;
                        b_initalize = true;
                        // exit this loop
                        return;
                    }
                }
                catch
                {
                    // don't care don't do anything
                }
                
                sp_obj.Close();
            }

            // if we are here there is no contoller, throw a exception
            Exception nocont_ex = new Exception("No ESP100 Controller Found");

            throw (nocont_ex);
        }

    }
}
