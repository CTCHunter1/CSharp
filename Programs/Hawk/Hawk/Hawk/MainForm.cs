using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using Lab.Drivers.HP8594E;
using Lab.Drivers.Motors;

namespace Lab.Programs.Hawk
{
    public partial class MainForm : Form
    {
        // form objects
        MotorControlForm motorControlFormObj;
        ScanOptionsForm scanOptionsFormObj;

        // UI Update Delegates
        delegate void UI_UpdateGraphDelegate(String str, double[] x_data, double[] y_data, Color c);
        delegate void UI_UpdateStatusDelegate(String str_msg, int i_precent_comp);
        delegate void UI_EnableDelegate();
        // Thread Object
        Thread current_sweep_thread_obj;
        Thread singleScanThreadObj;

        UI_UpdateGraphDelegate ui_update_graph_delegate_obj;
        UI_UpdateStatusDelegate ui_update_status_delegate_obj;
        UI_EnableDelegate ui_enable_delegate_obj;

        HP8594E hp_8594e_obj;
        Arroyo arroyo_obj;

        private enum Freq_Units {Hz=1, kHz=3, MHz=6, GHz=9 };
        Freq_Units graph_xunits;
        HP8594E.AmpUnits amp_units;
        double resolution_bandwidth = 0;

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
        double [] d_I0_arr = null;
        double [] d_Im_arr = null;
        double [] d_position_arr = null;
        double [][] d_trace_2D_arr = null;

        public MainForm()
        {
            InitializeComponent();

            aso_obj = new Arroyo_Sweep_Options(d_start,
                                               d_stop,
                                               i_num_pts,
                                               smode,
                                               i_sleep_time_ms);



            // Set the default selected unit to MHz
            comboBox1.SelectedIndex = 2;
            graph_xunits = Freq_Units.MHz;

            // initalize the HP8594E
            try
            {
                hp_8594e_obj = new HP8594E();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error Initalizing HP8594E\r\n" + ex.Message); 
            }

            // initalize the Arroyo Driver
            try
            {
                arroyo_obj = new Arroyo();
                // initalize the equpiment
                //hp_8594e_obj.Initalize();
                arroyo_obj.Connect();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error Initalizing Arroryo\r\n" + ex.Message);
                DisableSweep();
            }

            // initalize the motors
            motorControlFormObj = new MotorControlForm();
            scanOptionsFormObj = new ScanOptionsForm(motorControlFormObj.Axes);


        }

        private void UpdateGraph(string str, double []x_data, double []y_data, Color c)
        {            
            // plot the data to the control
            graphControl1.Plot(str, x_data, y_data, c);
        }

        private void UpdateStatus(string status_str, int i_per_complete)
        {
            toolStripStatusLabel.Text = status_str;
            toolStripProgressBar.Value = i_per_complete;
        }

        private void EnableSingleScan()
        {
            // Disable the take scan button
            singleScanToolStripMenuItem.Enabled = true;
            // disable the save button until this is complete
            saveSingleScanToolStripMenuItem.Enabled = true;
        }

        private void DisableSingleScan()
        {
            // Disable the take scan button
            singleScanToolStripMenuItem.Enabled = false;
            // disable the save button until this is complete
            saveSingleScanToolStripMenuItem.Enabled = false;
        }

        private void EnableSweep()
        {
            current_sweep_button.Enabled = true;
            toolStripSaveSweep.Enabled = true;
        }

        private void DisableSweep()
        {
            current_sweep_button.Enabled = false;
            toolStripSaveSweep.Enabled = false;
        }

        private void gPIPOptionsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            hp_8594e_obj.Show_Options();
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            try
            {
                if (arroyo_obj.Connected == true)
                {
                    // Back to local mode
                    arroyo_obj.Set_Local();
                    arroyo_obj.Disconnect();
                }

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
            // Update the status
            toolStripStatusLabel.Text = "Taking Trace";

            d_trace_arr = hp_8594e_obj.Get_HP_TraceA();
            d_axis_arr = hp_8594e_obj.Get_HP_Axis();
            resolution_bandwidth = hp_8594e_obj.Get_Resolution_Bandwidth();
            amp_units = hp_8594e_obj.Get_Amp_Units();


            // put the axis into the correct units
            double d_scale_fac = System.Math.Pow(10, -((double)graph_xunits));

            // convert the X-axis to the right units
            for (int i = 0; i < d_axis_arr.Length; i++)
            {
                d_axis_arr[i] = d_axis_arr[i] * d_scale_fac;
            }            

            // return control to local
            hp_8594e_obj.Go_Local();
            UpdateGraph("Trace A", d_axis_arr, d_trace_arr, Color.Red);
            
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


        private void comboBox1_TextChanged(object sender, EventArgs e)
        {
            comboBox1_Validated(sender, e);
        }

        private void current_sweep_button_Click(object sender, EventArgs e)
        {
            // Disable this button until this is complete
            current_sweep_button.Enabled = false;
            // disable the save button until this is complete
            toolStripSaveSweep.Enabled = false;

            ui_update_graph_delegate_obj = new UI_UpdateGraphDelegate(UpdateGraph);
            ui_update_status_delegate_obj = new UI_UpdateStatusDelegate(UpdateStatus);
            ui_enable_delegate_obj = new UI_EnableDelegate(EnableSweep);
            current_sweep_thread_obj = new Thread(new ParameterizedThreadStart(Current_Sweep));
            current_sweep_thread_obj.Start((object)new object[] { this, ui_update_graph_delegate_obj, ui_update_status_delegate_obj, ui_enable_delegate_obj });            
           
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

        private void toolStripArroyoOptions_Click(object sender, EventArgs e)
        {
            try
            {
                arroyo_obj.Show_Options();
                EnableSweep();
                
            }
            catch (Exception ex)
            {
                DisableSweep();
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
                sw_obj.WriteLine("Date:\t" + DateTime.Now + "\n");

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
            UI_UpdateGraphDelegate ui_update_graph_obj = (UI_UpdateGraphDelegate) obj_arr[1];
            UI_UpdateStatusDelegate ui_update_status_obj = (UI_UpdateStatusDelegate) obj_arr[2];
            UI_EnableDelegate ui_enable_sweep_obj = (UI_EnableDelegate)obj_arr[3];

            // There are two sweep options, sweeping the I0 and sweeping the Im
            // Deal with each seprately

            // get the number of points to minimize object access
            int i_num_pts = aso_obj.Num_Points;

            // apparently using jagged arrarys is faster than using multi-demension ones, who knew
            d_trace_2D_arr = new double[i_num_pts][];
            d_I0_arr = new double[i_num_pts];
            d_Im_arr = new double[i_num_pts];

            // Find the step size
            double d_step = (aso_obj.Stop - aso_obj.Start) / (double)(i_num_pts-1);
            double d_current = aso_obj.Start;       // The starting point for the current

            arroyo_obj.Set_Output_State(false);

            // get the axis 
            d_axis_arr = hp_8594e_obj.Get_HP_Axis();
            // put the axis into the correct units
            double d_scale_fac = System.Math.Pow(10, -((double)graph_xunits));

            // convert the X-axis to the right units
            for (int i = 0; i < d_axis_arr.Length; i++)
            {
                d_axis_arr[i] = d_axis_arr[i] * d_scale_fac;
            }

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
                        d_I0_arr[i] = d_current;
                        d_Im_arr[i] = arroyo_obj.Get_Im();

                        // get the trace data
                        d_trace_2D_arr[i] = hp_8594e_obj.Get_HP_TraceA();
                        // update the graph with the trace data
                        sender.BeginInvoke(ui_update_graph_obj,
                            new object[] {"Trace A", d_axis_arr, d_trace_2D_arr[i], Color.Red });

                        sender.BeginInvoke(ui_update_status_obj,
                            new object[] { "Current Sweep Point I0 = " + d_current + " (mA)", (i + 1)*100 / i_num_pts });

                        // add the step to the current for the next set point
                        d_current += d_step;
                    }
                    break;

                case Arroyo_Sweep_Options.Mode.Im:                                  
                    // set the arroyo to Im Mode
                    arroyo_obj.Set_Laser_Mode(Arroyo.Laser_Mode.MDI);
                    
                    for (int i = 0; i < i_num_pts; i++)
                    {
                        // set the current
                        arroyo_obj.Set_Im(d_current);
                        d_I0_arr[i] = arroyo_obj.Get_I0();
                        d_Im_arr[i] = d_current;


                        // get the trace data
                        d_trace_2D_arr[i] = hp_8594e_obj.Get_HP_TraceA();
                        // update the UI
                        sender.BeginInvoke(ui_update_graph_obj,
                            new object[] {"Trace A", d_axis_arr, d_trace_2D_arr[i], Color.Red });

                        sender.BeginInvoke(ui_update_status_obj,
                            new object[] { "Current Sweep Point Im = " + d_current + " (uA)", (i + 1)*100 / i_num_pts });

                        // add the step to the current for the next set point
                        d_current += d_step;

                    }
                    break;
            }

            // put the arroyo back to local mode
            arroyo_obj.Set_Local();

            // reenable the sweep button
            sender.BeginInvoke(ui_enable_sweep_obj, new object[] { });
        }

        private void SingleScan(object parameters)
        {
            // get the parameteres
            Object[] obj_arr = (Object[])parameters;
            ContainerControl sender = (ContainerControl)obj_arr[0];
            UI_UpdateGraphDelegate ui_update_graph_obj = (UI_UpdateGraphDelegate)obj_arr[1];
            UI_UpdateStatusDelegate ui_update_status_obj = (UI_UpdateStatusDelegate)obj_arr[2];
            UI_EnableDelegate ui_enable_single_scan_obj = (UI_EnableDelegate)obj_arr[3];

            // apparently using jagged arrarys is faster than using multi-demension ones, who knew
            d_trace_2D_arr = new double[scanOptionsFormObj.CuttingAxisNumPoints][];
            d_position_arr = new double[scanOptionsFormObj.CuttingAxisNumPoints];

            // There are two sweep options, sweeping the I0 and sweeping the Im
            // Deal with each seprately
            double centerPosition = scanOptionsFormObj.CuttingAxisMotor.Position;   // the position of the motor prior to the scan
            double scanDist = 2*scanOptionsFormObj.CuttingAxisRadius/1000;  // put into (mm)
            // FindForm the distance between the points dX
            double dX = scanDist;            
            if (scanOptionsFormObj.CuttingAxisNumPoints > 1)
                dX = scanDist / (scanOptionsFormObj.CuttingAxisNumPoints - 1); // fixes fence post problem
            
            double startingPosition = centerPosition - scanOptionsFormObj.CuttingAxisRadius/1000;

            // get the axis assumes to be constant throughout scan
            d_axis_arr = hp_8594e_obj.Get_HP_Axis();
            // put the axis into the correct units
            double d_scale_fac = System.Math.Pow(10, -((double)graph_xunits));
            d_axis_arr = Lab.Math.Functions.ConstMultArray(d_scale_fac, d_axis_arr);

            // get the amplitude units
            amp_units = hp_8594e_obj.Get_Amp_Units();

            resolution_bandwidth = hp_8594e_obj.Get_Resolution_Bandwidth();


            for (int i = 0; i < scanOptionsFormObj.CuttingAxisNumPoints; i++)
            {
                d_position_arr[i] = startingPosition + dX * i;
                // move the motor to the position to take the trace at
                scanOptionsFormObj.CuttingAxisMotor.MoveAbsolute(d_position_arr[i]);
                // take the trace
                d_trace_2D_arr[i] = hp_8594e_obj.Get_HP_TraceA();

                ui_update_graph_obj.BeginInvoke("Trace A", d_axis_arr, d_trace_2D_arr[i], Color.Red, null, null);
                // update the UI graph
                //sender.BeginInvoke(ui_update_graph_obj,
                //    new object[] { "Trace A", d_axis_arr, d_trace_2D_arr[i], Color.Red });


                //sender.BeginInvoke(ui_update_status_obj,
                //            new object[] { "(" + (i + 1) +  "/" + scanOptionsFormObj.CuttingAxisNumPoints +
                //                "Position = "+  pointPosition.ToString("{0:F4}") + "um"});

            }

            // move back to the starting position
            scanOptionsFormObj.CuttingAxisMotor.MoveAbsolute(centerPosition);

            scanOptionsFormObj.CuttingAxisMotor.EndMoveAbsolute(null);

            // reenable the single scan option button
            sender.BeginInvoke(ui_enable_single_scan_obj, new object[] { });
        }

        private void toolStripSaveSweep_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd_obj = new SaveFileDialog();
            StreamWriter sw_obj;

            if (d_trace_2D_arr == null)
            {
                MessageBox.Show("No Sweep Data to Save. Take a Sweep First");
                return;
            }

            if (sfd_obj.ShowDialog() == DialogResult.OK)
            {
                sw_obj = new StreamWriter(sfd_obj.OpenFile());

                // Write Date Information
                sw_obj.WriteLine("Date:\t" + DateTime.Now + "\n");

                // Write the Header Information
                sw_obj.WriteLine("Freq Axis (" + graph_xunits + ")\tAmp (" + amp_units + ")\n");

                // Write the Im and I0 values for each measurement
                sw_obj.Write("I0 (mA)\t");
                for (int i = 0; i < d_I0_arr.Length; i++)
                {
                    sw_obj.Write("{0:e}\t", d_I0_arr[i]);
                }
                sw_obj.Write("\n");

                sw_obj.Write("Im (uA)\t");
                for (int i = 0; i < d_Im_arr.Length; i++)
                {
                    sw_obj.Write("{0:e}\t", d_Im_arr[i]);
                }
                sw_obj.Write("\n");


                // i think it's faster to copy the length out instead of accessing every loop
                // iteration
                int i_num_pts = d_trace_2D_arr[0].Length;
                // write the trace to the file
                for (int i = 0; i < i_num_pts; i++)
                {
                    // Write the axis
                    sw_obj.Write("{0:e}\t",
                                     d_axis_arr[i]);

                    // each trace in its own column
                    int i_num_traces = d_trace_2D_arr.Length;
                    for (int j = 0; j < i_num_traces; j++)
                    { 
                        sw_obj.Write("{0:e}\t", d_trace_2D_arr[j][i]);
                    }
                    sw_obj.Write("\n");
                }

                // close the file
                sw_obj.Close();
            }
        }

        private void motorScanOptionsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            scanOptionsFormObj.ShowDialog();
        }

        private void motorOptionsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            motorControlFormObj.ShowDialog();
        }

        private void singleScanToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Disable the take scan button
            DisableSingleScan();

            ui_update_graph_delegate_obj = new UI_UpdateGraphDelegate(UpdateGraph);
            ui_update_status_delegate_obj = new UI_UpdateStatusDelegate(UpdateStatus);
            ui_enable_delegate_obj = new UI_EnableDelegate(EnableSingleScan);

            singleScanThreadObj = new Thread(new ParameterizedThreadStart(SingleScan));
            singleScanThreadObj.Start((object)new object[] { this, ui_update_graph_delegate_obj, ui_update_status_delegate_obj, ui_enable_delegate_obj });  
        }

        private void saveSingleScanToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd_obj = new SaveFileDialog();
            sfd_obj.Filter = "Csv Files (*.csv)|*.csv|All Files|*.*";
            StreamWriter sw_obj;

            if (d_trace_2D_arr == null)
            {
                MessageBox.Show("No Sweep Data to Save. Take a Sweep First");
                return;
            }

            if (sfd_obj.ShowDialog() == DialogResult.OK)
            {
                sw_obj = new StreamWriter(sfd_obj.OpenFile());

                // Write Date Information
                sw_obj.WriteLine("Hawk Data File");
                sw_obj.WriteLine("Date:," + DateTime.Now);
                sw_obj.WriteLine("Resolution Bandwidth (Hz): " + resolution_bandwidth);

                // Write the Im and I0 values for each measurement           
                sw_obj.Write("Position (mm),");
                for (int i = 0; i < d_position_arr.Length; i++)
                {
                    sw_obj.Write("{0:e},", d_position_arr[i]);
                }

                sw_obj.Write("\r\n");
                // Write the Header Information
                sw_obj.Write("Freq Axis (" + graph_xunits + "),");

                // i think it's faster to copy the length out instead of accessing every loop
                // iteration
                int i_num_pts = d_trace_2D_arr[0].Length;

                for (int i = 0; i < d_trace_2D_arr.Length; i++)
                {
                    sw_obj.Write("Amp (" + amp_units + "),");              
                }

                sw_obj.Write("\r\n");

                
                // write the trace to the file
                for (int i = 0; i < i_num_pts; i++)
                {
                    // Write the axis
                    sw_obj.Write("{0:e},",
                                     d_axis_arr[i]);

                    // each trace in its own column
                    int i_num_traces = d_trace_2D_arr.Length;
                    for (int j = 0; j < i_num_traces; j++)
                    {
                        sw_obj.Write("{0:e},", d_trace_2D_arr[j][i]);
                    }
                    sw_obj.Write("\r\n");
                }

                // close the file
                sw_obj.Close();
            }
        }
    }
}