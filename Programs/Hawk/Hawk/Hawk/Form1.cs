using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Driver;

namespace Hawk
{
    public partial class Form1 : Form
    {
        HP_8594E hp_8594e_obj;
        Arroyo arroyo_obj;

        private enum Freq_Units {Hz=1, kHz=3, MHz=6, GHz=9 };
        Freq_Units graph_xunits;

        // Current Sweep Parameters
        double d_start = 10;
        double d_stop = 10;
        int i_num_pts = 0;
        Arroyo_Sweep_Options.Mode smode = Arroyo_Sweep_Options.Mode.I0;
        Arroyo_Sweep_Options aso_obj;

        public Form1()
        {
            aso_obj = new Arroyo_Sweep_Options(d_start, 
                                               d_stop,
                                               i_num_pts,
                                               smode);

            InitializeComponent();

            // Set the default selected unit to MHz
            comboBox1.SelectedIndex = 2;
            graph_xunits = Freq_Units.MHz;


            hp_8594e_obj = new HP_8594E();
            arroyo_obj = new Arroyo();
            // initalize the equpiment
            hp_8594e_obj.Initalize();
            arroyo_obj.Connect();

        }

        private void gPIPOptionsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            hp_8594e_obj.Show_Options();
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            // Back to local mode
            arroyo_obj.Set_Local();
            arroyo_obj.Disconnect();

            hp_8594e_obj.Go_Local();
        }


        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void take_trace_button_Click(object sender, EventArgs e)
        {
            double[] d_trace_arr = hp_8594e_obj.Get_HP_TraceA();
            double[] d_axis_arr = hp_8594e_obj.Get_HP_Axis();


            double d_scale_fac = Math.Pow(10, -((double) graph_xunits));
            // convert the X-axis to the right units
            for (int i = 0; i < d_axis_arr.Length; i++)
            {
                d_axis_arr[i] = d_axis_arr[i] * d_scale_fac;
            }

            graphControl1.Plot("Trace A", d_axis_arr, d_trace_arr, Color.Red);
        }

        private void comboBox1_Validated(object sender, EventArgs e)
        {
            switch (comboBox1.SelectedIndex)
            {
                case 0:
                    graph_xunits = Freq_Units.Hz;
                    break;

                case 1:
                    graph_xunits = Freq_Units.kHz;
                    break;

                case 2:
                    graph_xunits = Freq_Units.MHz;
                    break;

                case 3:
                    graph_xunits = Freq_Units.GHz;
                    break;
            }
        }

        private void current_sweep_button_Click(object sender, EventArgs e)
        {

        }

        private void arroyoSweepOptionsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (aso_obj.ShowDialog() == DialogResult.OK)
            {
                d_start = aso_obj.Start;
                d_stop = aso_obj.Stop;
                i_num_pts = aso_obj.Num_Points;
                smode = aso_obj.Sweep_Mode;
            }
            else
            {
                aso_obj.Start = d_start;
                aso_obj.Stop = d_stop;
                aso_obj.Num_Points = i_num_pts;
                aso_obj.Sweep_Mode = smode;
            }

        }

    }
}