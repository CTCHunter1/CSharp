using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using Driver;

namespace Hawk
{
    public partial class Form1 : Form
    {
        // UI Update Delegates
        delegate void UpdateGraphDelegate(String str, double[] x_data, double[] y_data, Color c);
        // Thread Object
        Thread current_sweep_thread_obj; 

        UpdateGraphDelegate update_graph_delegate_obj;

        HP_8594E hp_8594e_obj;
        Arroyo arroyo_obj;

        private enum Freq_Units {Hz=1, kHz=3, MHz=6, GHz=9 };
        Freq_Units graph_xunits;
        HP_8594E.AmpUnits amp_units;

        // Current Sweep Parameters
        double d_start = 10;
        double d_stop = 10;
        int i_num_pts = 2;
        Arroyo_Sweep_Options.Mode smode = Arroyo_Sweep_Options.Mode.I0;
        int i_sleep_time_ms = 0;
        Arroyo_Sweep_Options aso_obj;

        // Trace Variables
        double [] d_trace_arr = null;
        double [] d_axis_arr = null;
        
        // Sweep Variables , d_axis_arr is also used in the sweep
        double [] d_I_arr = null;
        double [][] d_trace_2D_arr = null;

        public Form1()
        {
            InitializeComponent();

            aso_obj = new Arroyo_Sweep_Options(d_start,
                                               d_stop,
                                               i_num_pts,
                                               smode,
                                               i_sleep_time_ms);

            update_graph_delegate_obj = new UpdateGraphDelegate(UpdateGraph);
            current_sweep_thread_obj = new Thread(new ParameterizedThreadStart(Current_Sweep));


            // Set the default selected unit to MHz
            comboBox1.SelectedIndex = 2;
            graph_xunits = Freq_Units.MHz;

            try
            {
                hp_8594e_obj = new HP_8594E();
                arroyo_obj = new Arroyo();
                // initalize the equpiment
                //hp_8594e_obj.Initalize();
                arroyo_obj.Connect();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void UpdateGraph(string str, double []x_data, double []y_data, Color c)
        {
            // plot the data to the control
            graphControl1.Plot(str, x_data, y_data, c);
        }

        private void gPIPOptionsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            hp_8594e_obj.Show_Options();
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            try
            {
                // Back to local mode
                arroyo_obj.Set_Local();
                arroyo_obj.Disconnect();

                hp_8594e_obj.Go_Local();
            }
            catch (Exception ex)
            {
                MessageBox.Show("On Exit Error: \n" + ex.Message);
            }
        }


        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void take_trace_button_Click(object sender, EventArgs e)
        {
            d_trace_arr = hp_8594e_obj.Get_HP_TraceA();
            d_axis_arr = hp_8594e_obj.Get_HP_Axis();

            // Update the status
            toolStripStatusLabel.Text = "Taking Trace";

            double d_scale_fac = Math.Pow(10, -((double) graph_xunits));
            // convert the X-axis to the right units
            for (int i = 0; i < d_axis_arr.Length; i++)
            {
                d_axis_arr[i] = d_axis_arr[i] * d_scale_fac;
            }

            amp_units = hp_8594e_obj.Get_Amp_Units();

            // return control to local
            hp_8594e_obj.Go_Local();
            graphControl1.Plot("Trace A", d_axis_arr, d_trace_arr, Color.Red);
            
            toolStripStatusLabel.Text = "Got Trace. HP8594E Local";
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
            current_sweep_thread_obj.Start((object) new object[]{this, update_graph_delegate_obj});
        }

        private void arroyoSweepOptionsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (aso_obj.ShowDialog() == DialogResult.OK)
            {
                d_start = aso_obj.Start;
                d_stop = aso_obj.Stop;
                i_num_pts = aso_obj.Num_Points;
                smode = aso_obj.Sweep_Mode;
                i_sleep_time_ms = aso_obj.Sleep_Time;
            }
            else
            {
                aso_obj.Start = d_start;
                aso_obj.Stop = d_stop;
                aso_obj.Num_Points = i_num_pts;
                aso_obj.Sweep_Mode = smode;
                aso_obj.Sleep_Time = i_sleep_time_ms;
            }

        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            try
            {
                arroyo_obj.Show_Options();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void toolStripSaveTrace_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd_obj = new SaveFileDialog();
            StreamWriter sw_obj;

            if (d_axis_arr == null)
            {
                MessageBox.Show("No Trace Data to Save. Take a Trace First");
                return;
            }

            if (sfd_obj.ShowDialog() == DialogResult.OK)
            {
                sw_obj = new StreamWriter(sfd_obj.OpenFile());

                // Write Date Information
                sw_obj.WriteLine("Date:\t" + DateTime.Today + "\n");

                // Write the Header Information
                sw_obj.WriteLine("Freq Axis (" + graph_xunits + ")\tAmp ("  + amp_units + ")\n");


                // i think it's faster to copy the length out instead of accessing every loop
                // iteration
                int len = d_axis_arr.Length;
                // write the trace to the file
                for (int i = 0; i < len; i++)
                {
                    sw_obj.WriteLine("{0:e}\t{1:e}\n",
                                     d_axis_arr[i],
                                     d_trace_arr[i]);
                }
                
                // close the file
                sw_obj.Close();
            }
        }

        private void Current_Sweep(object parameters)
        {
            // get the parameteres
            Object [] obj_arr = (Object []) parameters;
            ContainerControl sender = (ContainerControl) obj_arr[0];
            UpdateGraphDelegate ui_update_delegate_obj = (UpdateGraphDelegate) obj_arr[1];

            // There are two sweep options, sweeping the I0 and sweeping the Im
            // Deal with each seprately

            // get the number of points to minimize object access
            int i_num_pts = aso_obj.Num_Points;

            // apparently using jagged arrarys is faster than using multi-demension ones, who knew
            d_trace_2D_arr = new double[i_num_pts][];

            // Find the step size
            double d_step = (aso_obj.Stop - aso_obj.Start) / (double)(i_num_pts-1);
            double d_current = aso_obj.Start;       // The starting point for the current

            arroyo_obj.Set_Output_State(false);

            // get the axis 
            d_axis_arr = hp_8594e_obj.Get_HP_Axis();
            // get the amplitude units
            amp_units = hp_8594e_obj.Get_Amp_Units();

            switch(aso_obj.Sweep_Mode)
            {
                case Arroyo_Sweep_Options.Mode.I0:
                    // set the arroyo to I0 Mode
                    arroyo_obj.Set_Laser_Mode(Arroyo.Laser_Mode.ILBW);
                    
                    for (int i = 0; i < i_num_pts; i++)
                    {
                        // set the current
                        arroyo_obj.Set_I0(d_current);
                        // add the step to the current for the next set point
                        d_current += d_step;

                        // get the trace data
                        d_trace_2D_arr[i] = hp_8594e_obj.Get_HP_TraceA();
                        // update the graph with the trace data
                        sender.BeginInvoke(ui_update_delegate_obj,
                            new object[]{"Data1", d_axis_arr, d_trace_2D_arr[i], Color.Red}); 
                        
                        ui_update_delegate_obj("TraceA", d_axis_arr, d_trace_2D_arr[i], Color.Red);
                    }
                    break;

                case Arroyo_Sweep_Options.Mode.Im:                                  
                    // set the arroyo to Im Mode
                    arroyo_obj.Set_Laser_Mode(Arroyo.Laser_Mode.MDI);
                    
                    for (int i = 0; i < i_num_pts; i++)
                    {
                        // set the current
                        arroyo_obj.Set_Im(d_current);
                        // add the step to the current for the next set point
                        d_current += d_step;

                        // get the trace data
                        d_trace_2D_arr[i] = hp_8594e_obj.Get_HP_TraceA();
                        // update the UI
                        sender.BeginInvoke(ui_update_delegate_obj,
                            new object[]{"Data1", d_axis_arr, d_trace_2D_arr[i], Color.Red});
                    }
                    break;
            }

            // put the arroyo back to local mode
            arroyo_obj.Set_Local();
        }
    }
}