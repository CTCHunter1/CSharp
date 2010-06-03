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
        ChirpControl chirpContolObj; 

        AcquisitionController acquisitionControllerObj;
        ZScanController zScanControllerObj;

        ZDataPoint zDataPoint = null;

        SaveFileDialog sfdObj = new SaveFileDialog();
            

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
            //decimatorObj = new Decimator(squidOptionsFormObj.NumReducedSamples, squidOptionsFormObj.NumPretriggerSamples);       
        
            AcquisitionController.UIUpdateGraphDelegate uiUpdateReducedDelegate = new AcquisitionController.UIUpdateGraphDelegate(UpdateReducedGraph);
            AcquisitionController.UIUpdateGraphDelegate uiUpdateDaqDelegate = new AcquisitionController.UIUpdateGraphDelegate(UpdateDAQGraph);
            AcquisitionController.UIFinishedContinousScan uiFinishedDelegate = new AcquisitionController.UIFinishedContinousScan(EnableContinousScan);

            acquisitionControllerObj = new AcquisitionController(squidOptionsFormObj,
                NIDAQControlFormObj,
                uiUpdateDaqDelegate,
                uiUpdateReducedDelegate,
                uiFinishedDelegate);

            ZScanController.UIUpdateGraphDelegate uiUpdateZDataDelegate = new ZScanController.UIUpdateGraphDelegate(UpdateZScanGraph);
            ZScanController.UIFinishedScan uiFinishZScanDelegaate = new ZScanController.UIFinishedScan(EnableZScan);

            chirpContolObj = new ChirpControl();

            zScanControllerObj = new ZScanController(acquisitionControllerObj, 
                uiUpdateZDataDelegate,
                uiFinishZScanDelegaate);

            sfdObj.Filter = "Matlab Files (*.mat)|*.mat|All Files|*.*";
            // sets the inital directory for the save file dialog
            sfdObj.InitialDirectory = Environment.CurrentDirectory;

            autoScaleCheckBox1_CheckedChanged(this, null);
            
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
            zScanControllerObj.StopScan();
            acquisitionControllerObj.StopContinousUpdate();
            
            Application.Exit();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
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


            if (autoScaleCheckBox2.Checked)
                frequencyAxisGraphControl.AutoScale = true;
            else
                frequencyAxisGraphControl.AutoScale = false;

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

                if (reducedRadioButton2.Checked && dataSeriesArr[i].HasFFT == true && enableCheckBox2.Checked)
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

        private void UpdateZScanGraph(ZDataPoint zDataPoint)
        {
            // loop through all the data
            DataSeries [] dataSeriesArr = zDataPoint.DataSeriesArr;
            double[] freqHalfArr = null;

            // check that the graph should be updated
            if (enableCheckBox3.Checked == false)
                return; 

            for (int i = 0; i < dataSeriesArr.Length; i++)
            {
                if (freqRadioButton.Checked == true)
                {
                    if (squidOptionsFormObj.PlotDCFrequency == true)
                    {
                        zScanGraphControl.Plot("Data" + i.ToString(),
                            dataSeriesArr[i].FrequencyHalfArr,
                            dataSeriesArr[i].YAbs_fHalf,
                            GetColorByIndex(i));
                    }
                    else
                    {
                        // if the new frequency array hasn't been created then create it
                        if (freqHalfArr == null)
                        {
                            freqHalfArr = new double[dataSeriesArr[0].FrequencyHalfArr.Length - 2];

                            for (int j = 0; i < dataSeriesArr[0].FrequencyHalfArr.Length - 2; j++)
                            {
                                freqHalfArr[j] = dataSeriesArr[0].FrequencyHalfArr[j + 2];
                            }
                        }

                        // we need to copy out the array minus the first two numbers
                        double[] YAbs_HalfArr = new double[dataSeriesArr[i].YAbs_fHalf.Length - 2];

                        // copy out starting after first two points
                        for (int j = 0; j < dataSeriesArr[i].YAbs_fHalf.Length - 2; j++)
                        {
                            YAbs_HalfArr[j] = dataSeriesArr[i].YAbs_fHalf[j + 2];
                        }

                        zScanGraphControl.Plot("Data" + i.ToString(),
                            freqHalfArr,
                            YAbs_HalfArr, 
                            GetColorByIndex(i));
                    }
                }

                if (timeRadioButton.Checked == true)
                {
                    zScanGraphControl.Plot("Data" + i.ToString(),
                            dataSeriesArr[i].TimeArr,
                            dataSeriesArr[i].Y_t,
                            GetColorByIndex(i));
                }
            }
        }

        private void EnableContinousScan()
        {
            startContinousToolStripMenuItem.Enabled = true;
        }

        private void EnableZScan()
        {
            startZScanToolStripMenuItem.Enabled = true;
        }
 
        private void stopContinousScanToolStripMenuItem_Click(object sender, EventArgs e)
        {
            acquisitionControllerObj.StopContinousUpdate();
        }

        private void squidOptionsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            squidOptionsFormObj.ShowDialog();
        }

        private void startZScanToolStripMenuItem_Click(object sender, EventArgs e)
        {
            startContinousToolStripMenuItem.Enabled = false;

            zScanControllerObj.StartScan(this, 
                squidOptionsFormObj.ZAxis, 
                squidOptionsFormObj.ZScanRadius * 2,
                squidOptionsFormObj.ZScanNumPoints);
        }

        private void startContinousToolStripMenuItem_Click(object sender, EventArgs e)
        {
            startContinousToolStripMenuItem.Enabled = false;
            // add disable for saving here

            // start the data acuisition, this will happen in a new thread
            acquisitionControllerObj.StartContinousUpdate(this);
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
            zDataPoint = acquisitionControllerObj.ReducedTrace;
            DataSeries[] dataArr = zDataPoint.DataSeriesArr;

            if (dataArr != null)
            {
                for (int i = 0; i < dataArr.Length; i++)
                {
                    zScanGraphControl.Plot("Data" + i.ToString(), dataArr[i].TimeArr, dataArr[i].Y_t, GetColorByIndex(i));
                }
            }
        }

        private void saveSingleScanToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (zDataPoint == null)
                return;


            if (sfdObj.ShowDialog() == DialogResult.OK)
            {
                zDataPoint.Save(sfdObj.FileName);
            }
        }

        private void saveZAxisScanToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (zScanControllerObj.ZDataSeries == null)
                return;

            if (sfdObj.ShowDialog() == DialogResult.OK)
            {
                zScanControllerObj.ZDataSeries.Save(sfdObj.FileName);
            }
        }

        private void stopZScanToolStripMenuItem_Click(object sender, EventArgs e)
        {
            zScanControllerObj.StopScan();
        }

        private void autoScaleCheckBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (autoScaleCheckBox1.Checked)
            {
                yAxisMaxNumeric.Enabled = false;
                yAxisMinNumeric.Enabled = false;
                timeAxisGraphControl.AutoScale = true;
            }
            else
            {
                timeAxisGraphControl.AutoScale = false;
                
                // Get the y limits
                double[] yLim = timeAxisGraphControl.YLim;

                yAxisMinNumeric.Value = Convert.ToDecimal(yLim[0]);
                yAxisMaxNumeric.Value = Convert.ToDecimal(yLim[1]);
                yAxisMinNumeric.Enabled = true;
                yAxisMaxNumeric.Enabled = true;
            }
        }

        private void yAxisNumeric_ValueChanged(object sender, EventArgs e)
        {
            double[] yLim = new double[2];

            yLim[0] = Convert.ToDouble(yAxisMinNumeric.Value);
            yLim[1] = Convert.ToDouble(yAxisMaxNumeric.Value);

            timeAxisGraphControl.YLim = yLim;
        }

        private void chrpWaveformToolStripMenuItem_Click(object sender, EventArgs e)
        {
            chirpContolObj.StartChirp();
        }
    }
}