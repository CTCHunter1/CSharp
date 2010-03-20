using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using Lab.Drivers.DAQ;
using Lab.Drivers.Motors;
using NationalInstruments;
using NationalInstruments.DAQmx;

namespace Squid
{
    public partial class MainForm : Form
    {
        ChopperMotorControlForm motorControlFromObj = new ChopperMotorControlForm();
        NI6251ControlForm NIDAQControlFormObj = new NI6251ControlForm();
        MotorControlForm motorControlFormObj;
        SquidOptionsForm squidOptionsFormObj;
        
        Decimator decimatorObj;
        
        AcquisitionController acquisitionControllerObj;
        

        // UI Update Delegates old
        // delegate void UIUpdateStatusDelegate(String str_msg, int i_precent_comp);

        public MainForm()
        {
            // Required for Windows Form Designer Support
            InitializeComponent();

            // configure the NIDAQControlForm
            NIDAQControlFormObj.UseSamplesPerChannelPow2 = false;
                        
            motorControlFormObj = new MotorControlForm();
            squidOptionsFormObj = new SquidOptionsForm(motorControlFormObj.Axes);
            decimatorObj = new Decimator(squidOptionsFormObj.NumReducedSamples, squidOptionsFormObj.NumPretriggerSamples);       
        
            AcquisitionController.UIUpdateGraphDelegate uiUpdateReducedDelegate = new AcquisitionController.UIUpdateGraphDelegate(UpdateReducedGraph);
            AcquisitionController.UIUpdateGraphDelegate uiUpdateDaqDelegate = new AcquisitionController.UIUpdateGraphDelegate(UpdateDAQGraph);
            AcquisitionController.UIFinishedContinousScan uiFinishedDelegate = new AcquisitionController.UIFinishedContinousScan(EnableContinousScan);

            acquisitionControllerObj = new AcquisitionController(squidOptionsFormObj,
                NIDAQControlFormObj,
                decimatorObj,
                uiUpdateDaqDelegate,
                uiUpdateReducedDelegate,
                uiFinishedDelegate);


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
                acquisitionControllerObj.StopContinousUpdate();                
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
            acquisitionControllerObj.StopContinousUpdate();            
            
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

            // start the data acuisition, this will happen in a new thread
            acquisitionControllerObj.StartContinousUpdate(this);
        }

        private void UpdateDAQGraph(DataSeries[] dataSeriesArr)
        {
            double[] freqHalfArr = null;

            if (squidOptionsFormObj.PlotDCFrequency == false)
            {
                freqHalfArr = new double[dataSeriesArr[0].FrequencyHalfArr.Length - 2];

                for (int i = 0; i < dataSeriesArr[0].FrequencyHalfArr.Length - 2; i++)
                {
                    freqHalfArr[i] = dataSeriesArr[0].FrequencyHalfArr[i + 2];
                }
            }

            for (int i = 0; i < dataSeriesArr.Length; i++)
            {
                if (origionalRadioButton1.Checked & enableCheckBox1.Checked)
                {
                    timeAxisGraphControl.Plot("Data" + i.ToString(), dataSeriesArr[i].TimeArr, dataSeriesArr[i].Y_t, GetColorByIndex(i));
                }

                if (origionalRadioButton2.Checked && dataSeriesArr[i].HasFFT == true & enableCheckBox2.Checked)
                {
                    if (squidOptionsFormObj.PlotDCFrequency == true)
                    {
                        frequencyAxisGraphControl.Plot("Data" + i.ToString(), dataSeriesArr[i].FrequencyHalfArr, dataSeriesArr[i].YAbs_fHalf, GetColorByIndex(i));
                    }
                    else
                    {
                        // we need to copy out the array minus the first two numbers
                        double[] YAbs_HalfArr = new double[dataSeriesArr[i].YAbs_fHalf.Length - 2];

                        // copy out starting after first two points
                        for (int j = 0; j < dataSeriesArr[i].YAbs_fHalf.Length - 2; j++)
                        {
                            YAbs_HalfArr[j] = dataSeriesArr[i].YAbs_fHalf[j + 2];
                        }

                        frequencyAxisGraphControl.Plot("Data" + i.ToString(), freqHalfArr, YAbs_HalfArr, GetColorByIndex(i));
                    }
                }
            }
        }

        private void UpdateReducedGraph(DataSeries[] dataSeriesArr)
        {
            double[] freqHalfArr = null;

            if (squidOptionsFormObj.PlotDCFrequency == false)
            {
                freqHalfArr = new double[dataSeriesArr[0].FrequencyHalfArr.Length - 2];

                for (int i = 0; i < dataSeriesArr[0].FrequencyHalfArr.Length - 2; i++)
                {
                    freqHalfArr[i] = dataSeriesArr[0].FrequencyHalfArr[i + 2];
                }
            }

            for (int i = 0; i < dataSeriesArr.Length; i++)
            {
                if (reducedRadioButton1.Checked && enableCheckBox1.Checked)
                {
                    timeAxisGraphControl.Plot("Data" + i.ToString(), dataSeriesArr[i].TimeArr, dataSeriesArr[i].Y_t, GetColorByIndex(i));
                }

                if (reducedRadioButton1.Checked && dataSeriesArr[i].HasFFT == true && enableCheckBox2.Checked)
                {
                    if (squidOptionsFormObj.PlotDCFrequency == true)
                    {
                        frequencyAxisGraphControl.Plot("Data" + i.ToString(), dataSeriesArr[i].FrequencyHalfArr, dataSeriesArr[i].YAbs_fHalf, GetColorByIndex(i));
                    }
                    else
                    {
                        // we need to copy out the array minus the first two numbers
                        double[] YAbs_HalfArr = new double[dataSeriesArr[i].YAbs_fHalf.Length - 2];

                        // copy out starting after first two points
                        for (int j = 0; j < dataSeriesArr[i].YAbs_fHalf.Length - 2; j++)
                        {
                            YAbs_HalfArr[j] = dataSeriesArr[i].YAbs_fHalf[j + 2];
                        }

                        frequencyAxisGraphControl.Plot("Data" + i.ToString(), freqHalfArr, YAbs_HalfArr, GetColorByIndex(i));
                    }                        
                }
            }
        }
        
        private void EnableContinousScan()
        {
            startContinousToolStripMenuItem.Enabled = true;
        }
 

        private void stopContinousScanToolStripMenuItem_Click(object sender, EventArgs e)
        {
            acquisitionControllerObj.StopContinousUpdate();
        }

        private void squidOptionsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            squidOptionsFormObj.ShowDialog();

            decimatorObj.PretriggerPoints = squidOptionsFormObj.NumPretriggerSamples;
            decimatorObj.NumPoints = squidOptionsFormObj.NumReducedSamples;
            decimatorObj.TriggerRising = squidOptionsFormObj.TriggerRising;
        }

        private void startZScanToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void stagesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            motorControlFormObj.ShowDialog();
        }

        private void takeSingleTraceToolStripMenuItem_Click(object sender, EventArgs e)
        {
            acquisitionControllerObj.TakeSingleTrace(this);
        }

        private void takeReducedButton_Click(object sender, EventArgs e)
        {
            DataSeries[] dataArr = acquisitionControllerObj.ReducedTrace;

            if (dataArr != null)
            {
                for (int i = 0; i < dataArr.Length; i++)
                {
                    graphControlSingle.Plot("Data" + i.ToString(), dataArr[i].TimeArr, dataArr[i].Y_t, GetColorByIndex(i));
                }
            }
        }
    }
}