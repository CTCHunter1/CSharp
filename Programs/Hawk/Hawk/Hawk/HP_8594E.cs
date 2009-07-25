using System;
using System.Collections.Generic;
using System.Text;

namespace Driver
{
    class HP_8594E
    {
        private HP8594E_Options hp8594e_form;
        private int i_brd = 0;      // for multiple GPIP controllers
        private int i_addr = 5;

        // Contains constant and method to decode error messages
        private ICSconstants ICSconts_obj;
        public enum FreqUnits {Hz, kHz, MHz, GHz, NONE}
        public enum AmpUnits {dB, dBm, dBmV, dBuV, V, mV, uV, W, mW, uW, NONE};

        public HP_8594E()
        {
            hp8594e_form = new HP8594E_Options();
            ICSconts_obj = new ICSconstants();
        }

        
        public void Show_Options()
        {
            // Set the Dialog Control to the current(setable) options
            hp8594e_form.GPIB_Addr = i_addr;

            if (hp8594e_form.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                i_addr = hp8594e_form.GPIB_Addr;
            }
        }

        public void Initalize()
        {
            // Sends IFC(Interface Clear Command) and asserts ATN
            GPIB_32.SendIFC(i_brd);
            GPIB_32.copy_globals();

            if (((GPIB_32.ibsta & GPIB_32.EERR) == GPIB_32.EERR) || 
                ((GPIB_32.ibsta & GPIB_32.TIMO) == GPIB_32.TIMO))
            {                
                // Throw a exception
                Exception ex = new Exception(ICSconstants.GPIBerr(
                    "Send IFC error. Is the GPIB Controller Attached?\n"));

                throw (ex);
            }           

            // Assert the (REN) Remote Enable Line
            GPIB_32.ilsre(i_brd, 1);
            GPIB_32.copy_globals();
            if (((GPIB_32.ibsta & GPIB_32.EERR) == GPIB_32.EERR) || 
                ((GPIB_32.ibsta & GPIB_32.TIMO) == GPIB_32.TIMO))            {
                 // Throw a exception
                Exception ex = new Exception(ICSconstants.GPIBerr(
                    "Remote Enable Line Error\n"));

                throw (ex);
            }

            // Set the Controller Time out to 1 second
            GPIB_32.ibtmo(i_brd, GPIB_32.T1s);
            GPIB_32.copy_globals();

            if (((GPIB_32.ibsta & GPIB_32.EERR) == GPIB_32.EERR) ||
                ((GPIB_32.ibsta & GPIB_32.TIMO) == GPIB_32.TIMO))
            {
                // Throw a exception
                Exception ex = new Exception(ICSconstants.GPIBerr(
                    "Timeout Set Error\n"));

                throw (ex);
            }

            Send_HP("ID?;");
            String ID_str = GPIB_32.Receive_String(i_brd, i_addr, 100, GPIB_32.DABend);

            if (ID_str != "HP8594E")
            {
                Exception ex = new Exception("Device not HP8594E but " + ID_str);
                throw (ex);
            }
        }

        public void Set_Center_Freq(double d_val, FreqUnits fu)
        {
            Send_HP("CF " + d_val.ToString() + Append_Freq_Units(fu) + ";");            
        }

        public void Set_Span_Freq(double d_val, FreqUnits fu)
        {
            Send_HP("CF " + d_val.ToString() + Append_Freq_Units(fu) + ";");  
        }

        private String Append_Freq_Units(FreqUnits fu)
        {
            String ret_str = "";

            switch (fu)
            {
                case FreqUnits.Hz:
                    ret_str = "HZ";
                    break;

                case FreqUnits.kHz:
                    ret_str = "KHZ"; 
                    break;

                case FreqUnits.MHz:
                    ret_str = "MHZ";
                    break;

                case FreqUnits.GHz:
                    ret_str = "GHZ";
                    break;
            }

            return (ret_str);
        }

        public AmpUnits Get_Amp_Units()
        {
            Send_HP("AUNITS?;");
            String AUnits = GPIB_32.Receive_String(i_brd, i_addr, 100, GPIB_32.DABend);

            switch (AUnits)
            {
                case "DBM":
                case "DM":
                    return (AmpUnits.dBm);
                    
                case "DBMV":
                    return (AmpUnits.dBmV);
                    
                case "DBUV":
                    return (AmpUnits.dBuV);
                    
                case "V":
                    return (AmpUnits.V);
                    
                case "W":
                    return (AmpUnits.W);
           }

            return (AmpUnits.NONE);
        }

        public void Set_Amp_Units(AmpUnits au)
        {
            String str_tmp = null;

            switch(au)
            {
                case AmpUnits.dBm:
                    str_tmp = "DBM";
                break;

                case AmpUnits.dBmV:
                    str_tmp = "DBMV";
                break;

                case AmpUnits.dBuV:
                    str_tmp = "DBUV";
                break;

                case AmpUnits.V:
                    str_tmp = "V";
                break;

                case AmpUnits.W:
                    str_tmp = "W";
                break;
            }

            // if str_tmp was initalized in the switch statement
            // will only be initalized for valid values
            if (str_tmp != null)
            {
                Send_HP("AUNITS " + str_tmp + ";");
            }
        }

        public void Set_Ref_Level(double d_ref, AmpUnits au)
        {
            // This interface sucks
            switch (au)
            {
                case AmpUnits.dB:
                    Send_HP("RL " + d_ref.ToString() + "DB");
                    break;
               
                // Program Manual says these are the only two units implemented
                default:               
                case AmpUnits.dBm:
                    Send_HP("RL " + d_ref.ToString() + "DM");
                    break;
            }
        }

        public double Get_Ref_Level()
        {
            Send_HP("RL ?;");

            // Data comes back as string
            String rl_str = GPIB_32.Receive_String(i_brd, i_addr, 100, GPIB_32.DABend);
            double d_ref_lev = Convert.ToDouble(rl_str);
            return (d_ref_lev);
        }

        public double[] Get_HP_TraceA()
        {

            double[] d_spec_amp = new double[401];
            double d_ref_lev = 0;
            AmpUnits au = Get_Amp_Units();
        
            int len = d_spec_amp.Length;
         
            // Single sweep, Take Sweep
            Send_HP("SNGLS; TS;");     

            // Set the data mode to binary, and transfer full words
            // Request Trace A
            Send_HP("TDF B; MDS W; TRA?;");
            ushort[] us_data_arr = GPIB_32.Receive_Ushort(i_brd, i_addr, 401, GPIB_32.DABend);

            switch (au)
            {
                // all dB Units
                case AmpUnits.dBm:
                case AmpUnits.dBmV:
                case AmpUnits.dBuV:
                    // put it ito dbm mode
                    Set_Amp_Units(AmpUnits.dBm);
                    // the reference level is needed to convert counts to data
                    d_ref_lev = Get_Ref_Level();
                    for (int i = 0; i < len; i++)
                    {
                        d_spec_amp[i] = (us_data_arr[i] - 8000.0) * .01 + d_ref_lev;
                    }

                    break;
                
                // linear units
                case AmpUnits.V:
                case AmpUnits.W:                    
                // put it ito V mode
                    Set_Amp_Units(AmpUnits.V);
                    // the reference level is needed to convert counts to data
                    d_ref_lev = Get_Ref_Level(); 
                    for (int i = 0; i < len; i++)
                    {
                        d_spec_amp[i] = d_ref_lev / 8000 * us_data_arr[i]; ;
                    }

                    break;                              
            }

            // Set the amplitude back to the old units
            Set_Amp_Units(au);

            Go_Continous_Mode();

            return (d_spec_amp);
        }

        public void Go_Continous_Mode()
        {
            Send_HP("CONTS; TS;");
        }

        public void Go_Local()
        {
            GPIB_32.EnableLocal(i_brd, new short[] { (short)i_addr, GPIB_32.NOADDR });
            GPIB_32.copy_globals();

            GPIB_32.Check_Err("Error returning control to Local");
        }
        
        public double[] Get_HP_Axis()
        {
            // Get the Start Frequency
            Send_HP("FA?;");
            String str_start_freq = GPIB_32.Receive_String(i_brd, i_addr, 100, GPIB_32.DABend);
            // Get the Span
            Send_HP("SP?;");
            String str_span = GPIB_32.Receive_String(i_brd, i_addr, 100, GPIB_32.DABend);

            // convert the strings to doubles
            double d_start_freq = Convert.ToDouble(str_start_freq);
            double d_span = Convert.ToDouble(str_span);

            double d_span_delta = d_span / 401;

            double[] d_axis = new double[401];

            for (int i = 0; i < 401; i++)
            {
                d_axis[i] = d_start_freq + d_span_delta * i;
            }

            return (d_axis);
        }

        private void Send_HP(string send_str)
        {
            GPIB_32.Send(i_brd, i_addr, send_str, send_str.Length, GPIB_32.DABend);
            GPIB_32.copy_globals();

            if (((GPIB_32.ibsta & GPIB_32.EERR) == GPIB_32.EERR) ||
                ((GPIB_32.ibsta & GPIB_32.TIMO) == GPIB_32.TIMO))
            {
                // Throw a exception
                Exception ex = new Exception(ICSconstants.GPIBerr(
                    "Error Sending: " +  send_str + "\n"));
                
                throw (ex);
            }

        }
    }
}
