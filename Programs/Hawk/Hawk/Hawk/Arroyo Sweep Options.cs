using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Hawk
{
    public partial class Arroyo_Sweep_Options : Form
    {
        public enum Mode { I0, Im };

        public Arroyo_Sweep_Options(double d_start, double d_stop, int i_num_pts, Mode sm, int i_sleep_time)
        {
            InitializeComponent();

            Start = d_start;
            Stop = d_stop;
            Num_Points = i_num_pts;
            Sweep_Mode = sm;
            mode_combo.SelectedIndex = 0;
            Sleep_Time = i_sleep_time;
        }

        public double Start{
            get
            {
                return ((double) start_numeric.Value);
            }
            set
            {
                start_numeric.Value = (decimal) value;
            }
        }

        public double Stop
        {
            get
            {
                return ((double)stop_numeric.Value);
            }
            set
            {
                stop_numeric.Value = (decimal) value;
            }
        }

        public int Num_Points
        {
            get
            {
                return ((int)num_pts_numeric.Value);
            }
            set
            {
                num_pts_numeric.Value = (int)value;
            }
        }


        public Mode Sweep_Mode
        {
            get
            {
                switch (mode_combo.SelectedIndex)
                {
                    case 0:
                        return (Mode.I0);

                    case 1:
                        return (Mode.Im);
                }

                // Default return
                return Mode.I0;
            }

            set
            {
                switch (value)
                {
                    case Mode.I0:
                        mode_combo.SelectedIndex = 0;
                        break;

                    case Mode.Im:
                        mode_combo.SelectedIndex = 1;
                        break;
                }
            }
        }

        public int Sleep_Time
        {
            get
            {
                return (int)sleep_time_numeric.Value;
            }
            set
            {
                sleep_time_numeric.Value = (decimal)value;
            }
        }

        private void mode_combo_TextChanged(object sender, EventArgs e)
        {
            switch (mode_combo.SelectedIndex)
            {
                case 0:
                    // Change the units to mA
                    start_label.Text = "mA";
                    stop_label.Text = "mA";
                    break;
                
                case 1:
                    // Change the units to uA
                    start_label.Text = "uA";
                    stop_label.Text = "uA";
                    break;
            }
        }

    }
}