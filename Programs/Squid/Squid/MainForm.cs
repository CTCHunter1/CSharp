using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using Lab.Drivers.DAQ;
using NationalInstruments;
using NationalInstruments.DAQmx;

namespace Squid
{
    public partial class MainForm : Form
    {
        MotorControl motorControlFromObj = new MotorControl();
        NI6251ControlForm NIDAQControlFormObj = new NI6251ControlForm();
        SquidOptionsForm squidOptionsFormObj = new SquidOptionsForm();

        private DataSeries[] singleScanArr;
        private DataSeries[] continousScanArr;

        // Threading
        Thread contiousScanThreadObj;

        bool runContousScan = false;

        // UI Update Delegates
        delegate void UIUpdateGraphDelegate(DataSeries [] dataSeriesArr);
        delegate void UIUpdateStatusDelegate(String str_msg, int i_precent_comp);
        delegate void UIEnableDelegate();

        int rnd = 1; // temp
            

        public MainForm()
        {
            // Required for Windows Form Designer Support
            InitializeComponent();

        }

        private void startButton_Click(object sender, EventArgs e)
        {

        }

        private void chopperMotorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            motorControlFromObj.ShowDialog();
        }

        private void stopButton_Click(object sender, EventArgs e)
        {
            motorControlFromObj.Stop();
        }

        private void nI6251ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (contiousScanThreadObj != null)
                {
                    // stop the thread
                    runContousScan = false;
                    // wait for thead to stop running
                    while (contiousScanThreadObj.ThreadState == ThreadState.Running) ;
                }

                NIDAQControlFormObj.SingleShot = true;
                NIDAQControlFormObj.ShowDialog();
            }

            catch (DaqException ex)
            {
                if (ex.Error == -201003)
                {
                    if (NIDAQControlFormObj != null)
                        NIDAQControlFormObj.Dispose();

                    MessageBox.Show("Error: No DAQ detected.");
                }
                else
                    throw (ex);
            }
        }

        private void takeTraceButton_Click(object sender, EventArgs e)
        {           
            NIDAQControlFormObj.TaskObj.Control(TaskAction.Stop);
            
            // create a array to store the read data 
            singleScanArr = DataSeries.CreateDataSeriesArray(NIDAQControlFormObj.AIChannels.Length,
                NIDAQControlFormObj.SamplesPerChannel,
                NIDAQControlFormObj.Rate,
                squidOptionsFormObj.FrequencyAmpUnits,
                50);

            TakeTrace(singleScanArr);

            UpdateGraph(singleScanArr);
        }

        private void TakeTrace(DataSeries[] dataSeriesArr)
        {
            AnalogMultiChannelReader analogInReader;
            AnalogWaveform<double>[] multiChannelWaveformData;

            analogInReader = new AnalogMultiChannelReader(NIDAQControlFormObj.TaskObj.Stream);
            multiChannelWaveformData = analogInReader.ReadWaveform(NIDAQControlFormObj.SamplesPerChannel);

            // copy out the waveform data
            for (int i = 0; i < dataSeriesArr.Length; i++)
            {                
                dataSeriesArr[i].Y_t = multiChannelWaveformData[i].GetScaledData();
                dataSeriesArr[i].UpdateFFT();
            }

            rnd++;
        }

        private Color GetColorByIndex(int index)
        {
            switch (index)
            {
                case 0:
                    return (Color.Blue);

                case 1:
                    return (Color.Green);

                case 2:
                    return (Color.Indigo);

                case 3:
                    return (Color.OrangeRed);

                case 4:
                    return (Color.Violet);

                case 5:
                    return (Color.Turquoise);

                default:
                    return (Color.Red);
            }
        }

        private void MainForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            motorControlFromObj.Stop();
            runContousScan = false;
            if (contiousScanThreadObj != null)
            {
                contiousScanThreadObj.Abort();
            }
            
            Application.Exit();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void starContinousToolStripMenuItem_Click(object sender, EventArgs e)
        {
            startContinousToolStripMenuItem.Enabled = false;
            // add disable for saving here

            UIUpdateGraphDelegate ui_update_graph_delegate_obj = new UIUpdateGraphDelegate(UpdateGraph);
            //ui_update_status_delegate_obj = new UIUpdateStatusDelegate(UpdateStatus);
            UIEnableDelegate ui_enable_delegate_obj = new UIEnableDelegate(EnableContinousScan);

            runContousScan = true;

            NIDAQControlFormObj.SingleShot = true;

            contiousScanThreadObj = new Thread(new ParameterizedThreadStart(ContinousScan));
            contiousScanThreadObj.Start((object)new object[] { this, ui_update_graph_delegate_obj, ui_enable_delegate_obj });  

        }

        private void UpdateGraph(DataSeries [] dataSeriesArr)
        {
            if (dataSeriesArr == null)
                return;

            double [] freqHalfArr = null;

            // create the time array
            if (squidOptionsFormObj.PlotDCFrequency == false)
            {
                freqHalfArr = new double[dataSeriesArr[0].FrequencyHalfArr.Length - 2];

                for (int i = 0; i < dataSeriesArr[0].FrequencyHalfArr.Length - 2; i++)
                {
                    freqHalfArr[i] = dataSeriesArr[0].FrequencyHalfArr[i + 2];
                }
            }

            // plot the data 
            for (int i = 0; i < dataSeriesArr.Length; i++)
            {
                timeAxisGraphControl.AutoScale = true;
                timeAxisGraphControl.Plot("Data" + i.ToString(), dataSeriesArr[i].TimeArr, dataSeriesArr[i].Y_t, GetColorByIndex(i));
                if(squidOptionsFormObj.PlotDCFrequency == true)
                {             
                    frequencyAxisGraphControl.Plot("Data" + i.ToString(), dataSeriesArr[i].FrequencyHalfArr, dataSeriesArr[i].YAbs_fHalf, GetColorByIndex(i));
                }   
                else
                {
                    // we need to copy out the array minus the first two numbers
                    double[] YAbs_HalfArr = new double[dataSeriesArr[i].YAbs_fHalf.Length-2];

                    // copy out starting after first two points
                    for(int j = 0; j < dataSeriesArr[i].YAbs_fHalf.Length-2; j++)
                    {
                        YAbs_HalfArr[j] = dataSeriesArr[i].YAbs_fHalf[j + 2];
                    }

                    frequencyAxisGraphControl.Plot("Data" + i.ToString(), freqHalfArr, YAbs_HalfArr, GetColorByIndex(i));
                }                
           }    
        }
        
        private void EnableContinousScan()
        {
            startContinousToolStripMenuItem.Enabled = true;
        }

        public void ContinousScan(object parameters)
        {
            // get the parameteres
            Object[] obj_arr = (Object[])parameters;
            ContainerControl sender = (ContainerControl)obj_arr[0];


            UIUpdateGraphDelegate uiUpdateGraphObj = (UIUpdateGraphDelegate)obj_arr[1]; 
            UIEnableDelegate uiEnableContinousScanObj = (UIEnableDelegate)obj_arr[2];

            // Create the dataSeriesArray
            // create a array to store the read data 
            continousScanArr = DataSeries.CreateDataSeriesArray(NIDAQControlFormObj.AIChannels.Length,
                NIDAQControlFormObj.SamplesPerChannel,
                NIDAQControlFormObj.Rate,
                squidOptionsFormObj.FrequencyAmpUnits,
                50);


            while (runContousScan)
            {
                TakeTrace(continousScanArr);

                // update the graph in the ui thread
                uiUpdateGraphObj.BeginInvoke(continousScanArr, null, null);
            }

            NIDAQControlFormObj.SingleShot = true;

            // reenable the contious scan button
            sender.BeginInvoke(uiEnableContinousScanObj, new object[] { });
        }

        private void stopContinousScanToolStripMenuItem_Click(object sender, EventArgs e)
        {
            runContousScan = false;
        }

        private void squidOptionsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            squidOptionsFormObj.ShowDialog();
        }
    }
}