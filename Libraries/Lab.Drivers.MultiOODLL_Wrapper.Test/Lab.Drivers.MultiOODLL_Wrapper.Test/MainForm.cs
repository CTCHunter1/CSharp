using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using Lab.Drivers.MultiOOIDLL_Wrapper;
using GraphControl;

namespace Lab.Drivers.MultiOOI_DLL.Test
{

    public partial class MainForm : Form
    {
        Thread AquireThreadObj;

        delegate void UpdateGraphDelegate(double[] x_data, double[] y_data);

        UpdateGraphDelegate updateGraphDelegate1_obj;
        UpdateGraphDelegate updateGraphDelegate2_obj;

        public MainForm()
        {
            InitializeComponent();

            updateGraphDelegate1_obj = new UpdateGraphDelegate(UpdateGraph);
            updateGraphDelegate2_obj = new UpdateGraphDelegate(UpdateTimeGraph);
            AquireThreadObj = new Thread(new ParameterizedThreadStart(Program.Aquire));
        }

        private void Start_Click(object sender, EventArgs e)
        {
            MultiOOIDLL.Hardware_Options(this.Handle); 
        }

        private void UpdateGraph(double[] x_data, double[] y_data)
        {
            graphControl1.Plot("Data1", x_data, y_data, Color.Blue);
        }

        private void UpdateTimeGraph(double[] x_data, double[] y_data)
        {
            graphControl2.Plot("Data1", x_data, y_data, Color.Red);
        }

        private void Start_ThreadedAquire()
        {
            
            int i_error = MultiOOIDLL.Hardware_Init((IntPtr)null, (IntPtr)null);

            // If there is an error dump it to the screen
            MultiOOIDLL.Hardware_ErrorMessage(this.Handle, i_error);

            if (i_error == 0)
            {
                // start takes one object, to pass more cast object array
                AquireThreadObj.Start((object)new object[] { this, updateGraphDelegate1_obj, updateGraphDelegate2_obj });
            }           
        }

        private void exit_button_Click(object sender, EventArgs e)
        {
            Program.m_thread_exit = true;

            // wait for the worker thread to terminate
            if (AquireThreadObj.ThreadState == ThreadState.Running)
            {
                AquireThreadObj.Join();
            }

            Application.Exit();                    
        }

        private void Main_Form_Load(object sender, EventArgs e)
        {
            //OnResize(e);
            Start_ThreadedAquire();  
        }

        private void Main_Form_Resize(object sender, EventArgs e)
        {
            // prelim resize
            //Size graph_size = this.Size;
            //graph_size.Height -= 100;
            //graph_size.Width -= 200;
            //graphControl1.Size = graph_size;

        }
    }
}