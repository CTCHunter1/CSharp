using System;
using System.Collections.Generic;
using System.Text;
using System.IO.Ports;
using System.Threading;


namespace Hawk
{
    class Arroyo
    {
        SerialPort sp_obj;

        public enum Laser_Mode
        {
            ILBW,       // Current Control low bandwidth
            IHBW,       // Current Control high bandwidth
            MDI,        // Photodiode Current Conroled (Monitor Diode Current)
            MDP,        // Photodiode Power Control    (Monitor Diode Power)
            LDV,        // Laser Voltage Control
            PULSE,      // Laser current control, QCW internal trigger
            TRIG
        };      // Laser current control, QCW external trigger

        public Arroyo()
        {
            sp_obj = new SerialPort("COM4", 38400, Parity.None, 8, StopBits.One);
            // set the new line for read line, the default is '\n'
            sp_obj.NewLine = "\r\n";
            sp_obj.ReadTimeout = 1000;

        }

        public void Connect()
        {
            sp_obj.Open();
        }

        public void Disconnect()
        {
            sp_obj.Close();
        }

        public String Get_ID()
        {
            sp_obj.WriteLine("*IDN?");
            String idn_str = sp_obj.ReadLine();

            return (idn_str);
        }

        public Laser_Mode Get_Laser_Mode()
        {
            sp_obj.WriteLine("LASer:MODE?");
            String mode_str = sp_obj.ReadLine();

            switch (mode_str)
            {
                case "ILBW":
                    return Laser_Mode.ILBW;

                case "IHBW":
                    return Laser_Mode.IHBW;

                case "PULSE":
                    return Laser_Mode.PULSE;

                case "TRIG":
                    return Laser_Mode.TRIG;

                case "MDI":
                    return Laser_Mode.MDI;

                case "MDP":
                    return Laser_Mode.MDP;

                case "LDV":
                    return Laser_Mode.LDV;
            }

            // How did we get here. Return Something
            return Laser_Mode.ILBW;
        }

        public void Set_Laser_Mode(Laser_Mode lm)
        {
            // This will be the default mode
            String mode_str = "ILBW";
            
            switch (lm)
            {
                case Laser_Mode.ILBW:
                    mode_str = "ILBW";
                break;

                case Laser_Mode.IHBW:
                    mode_str = "IHBW";
                break;

                case Laser_Mode.PULSE:
                    mode_str = "PULSE";
                break;

                case Laser_Mode.TRIG:
                    mode_str = "TRIG";
                break;

                case Laser_Mode.MDI:
                    mode_str = "MDI";
                break;

                case Laser_Mode.MDP:
                    mode_str = "MDP";
                break;

                case Laser_Mode.LDV:
                    mode_str = "MDV";
                break;
            }
            
            sp_obj.WriteLine("LASer:Mode:" + mode_str);
        }

        public void Set_Output_State(bool b_on_off)
        {
            if (b_on_off)
                sp_obj.WriteLine("LASer:OUTput:1");
            else
                sp_obj.WriteLine("LASer:OUTput:0");
        }

        public bool Get_Output_State()
        {
            sp_obj.WriteLine("LASer:OUTput?");
            String out_str = sp_obj.ReadLine();

            if (out_str == "1")
                return (true);

            return (false);
        }

        public void Set_Local()
        {
            sp_obj.WriteLine("LOCAL");
        }

        public void Beep()
        {
            sp_obj.WriteLine("BEEP 2");
        }

        public double Get_I0()
        {
            sp_obj.WriteLine("LASer:LDI?");
            String I_str = sp_obj.ReadLine();

            return (Convert.ToDouble(I_str));
        }

        public void Set_I0(double i0)
        {
            sp_obj.WriteLine("LASer:LDI " + i0.ToString("0.#"));
            
            // This command hold up the instrument. If there is no wait and the next command comes too fast
            // the instrument will not parse it
            Thread.Sleep(25);            
        }

        public void Set_Im(double im)
        {
            sp_obj.WriteLine("LASer:MDI " + im.ToString("0.#"));

            // This command hold up the instrument. If there is no wait and the next command comes too fast
            // the instrument will not parse it
            Thread.Sleep(25);
        }

        public double Get_Im()
        {
            sp_obj.WriteLine("LASer:MDI?");

            String Im_str = sp_obj.ReadLine();

            return (Convert.ToDouble(Im_str));
        }

        public void Show_Options()
        {
            String i_port_num_str = sp_obj.PortName.Substring(3);
            int i_port_num = Convert.ToInt32(i_port_num_str);
            Arroyo_Options_Form aof_obj = new Arroyo_Options_Form(i_port_num);

            if (aof_obj.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                    // Close the com port
                    // change number
                    // and reopen
                    sp_obj.Close();
                    sp_obj.PortName = "COM" + aof_obj.Com_Port.ToString();
                    sp_obj.Open();        
            }
        }
    }
}
