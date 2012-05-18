using System;
using System.Collections.Generic;
//using System.Collections.Specialized;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Runtime.InteropServices;

// Monochromator
using Lab_Drivers_ARC_SpectraProDLL_ManagedWrapper; //C++/CLI doesn't support doted.subdot namespaces
using Lab.Drivers.ARC_SpectraProDLL_Wrapper.Test;
// Camera
using Lab_Drivers_PVCAM_Wrapper;
using Lab.Drivers.PVCAM_Wrapper.Test;
// Motors
using Lab.Drivers.Motors;


// Webcam
using Microsoft.Expression.Encoder.Devices;
using Microsoft.Expression.Encoder.Live;
using Microsoft.Expression.Encoder;


namespace Beluga
{
    public delegate void UIUpdateGraphDelegate(DataSeries dataSeries);
    public delegate void UIUpdateSequenceDelegate(int seqPt, bool isAquired);
    public delegate void UIUpdateStatusDelegate(String status);
    public delegate void UIFinished();
    public enum ExposureResolution { us, ms, s, min };

    public partial class BelugaMainForm : Form
    {
        PVCAM_WrapperTestForm[] testFormArr = null;
        PVCAM_Wrapper_Class[] cameraArr = null;
        ARC_SpectraProDLL_WrapperTestForm arcFormObj = null;
        MotorControlForm motorsFormObj = null;
        List<EncoderDevice> cameraList = new List<EncoderDevice>();
        LiveJob job =  null;
        LiveDeviceSource devSource = null;
        AcqController acqControllerObj = null;
        String []cameraNames = null;
        GraphWindow seperateGraphWindow;
        VideoPreviewForm prevForm = null;

        public BelugaMainForm()
        {
            InitializeComponent();
            
            try
            {
                cameraNames = PVCAM_Wrapper_Class.GetCameraNames();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }

            int numCameras = cameraNames.Length;
            cameraArr = new PVCAM_Wrapper_Class[numCameras];
            testFormArr = new PVCAM_WrapperTestForm[numCameras];            

            // initalize cameras
            for (int i=0; i < numCameras; i++)
            {
                ToolStripMenuItem cameraMenuItem = new ToolStripMenuItem(cameraNames[i]);
                pVCamToolStripMenuItem.DropDownItems.Add(cameraMenuItem);                
                cameraArr[i] = new PVCAM_Wrapper_Class(cameraNames[i]);                
                testFormArr[i] = new PVCAM_WrapperTestForm(cameraArr[i]);
                testFormArr[i].IsSubForm = true;
                cameraMenuItem.Click += new EventHandler(pVCamToolStripMenuItem_Click);
                selectedCameraComboBox.Items.Add(cameraArr[i]);

                try
                {
                    cameraArr[i].Temperature = -60;
                    cameraArr[i].ShutterMode2 = SHUTTER_MODE.NORMAL; // debug settings
                    cameraArr[i].ShutterMode2 = SHUTTER_MODE.DISABLED_OPEN;
                }
                catch (Exception ex)
                {
                    // if one of these throws and excpetion it kills the driver /need to reinit
                    MessageBox.Show(ex.Message);
                }
            }

            for (int i = 0; i < numCameras; i++)
            {

            }


            if (selectedCameraComboBox.Items.Count > 0)
            {
                selectedCameraComboBox.SelectedIndex = 0; 
            }

            try
            {
                arcFormObj = new ARC_SpectraProDLL_WrapperTestForm();
                arcFormObj.IsSubForm = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "ARC_SpectraProDLL_WrapperTestForm Creation Error: \r\n\r\n" + ex.ToString());
            }

            try
            {
                motorsFormObj = new MotorControlForm();
                motorsFormObj.IsSubForm = true;

                if (motorsFormObj.Axes != null && motorsFormObj.Axes.Length >= 1)
                {
                    motorAxis1ComboBox.Items.AddRange(motorsFormObj.Axes);
                    motorAxis2ComboBox.Items.AddRange(motorsFormObj.Axes);
                    motorAxis1ComboBox.SelectedIndex = 0;
                    motorAxis2ComboBox.SelectedIndex = 0;
                }

                if(motorsFormObj.Axes.Length >= 2)
                {
                    motorAxis1ComboBox.SelectedIndex = 1;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Motors Form Error: \r\n\r\n" + ex.Message);
            }

            // populate the webcam list
            foreach (EncoderDevice edv in EncoderDevices.FindDevices(EncoderDeviceType.Video))
            {
                cameraList.Add(edv);
                videoDeviceComboBox.Items.Add(edv.Name);
            }

            if (videoDeviceComboBox.Items.Count > 0)
                videoDeviceComboBox.SelectedIndex = 0;

            exposureUnitComboBox.DataSource = Enum.GetValues(typeof(ExposureResolution));
            exposureUnitComboBox.SelectedIndex = 1;
            
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
            // MSDN comment on Appllication.Exit() 
            // "Brings application to a screeching halt. Leads to bugs."

        }

        private void pVCamToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // handels all the control form show events
            if (testFormArr != null)
            {
                for (int i = 0; i < testFormArr.Length; i++)
                {
                    if (String.Equals(sender.ToString(), testFormArr[i].PVCAMObj.CameraName) == true)
                    {
                        testFormArr[i].Show();
                    }
                }
            }
        }

        private void actonMonToolStripMenuItem_Click(object sender, EventArgs e)
        {
            arcFormObj.Show();
        }

        private void motorsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            motorsFormObj.Show();
        }
       

        private void startCapture_Click(object sender, EventArgs e)
        {
            if (prevForm == null || prevForm.IsDisposed == true)
            {
                if (job != null)
                {
                    job.Dispose();
                    job = null;
                }

                job = new LiveJob();

                devSource =
                    job.AddDeviceSource(cameraList[videoDeviceComboBox.SelectedIndex], null);

                prevForm = new VideoPreviewForm(job, devSource);
            }
            
            prevForm.Show();
        }

        private void stopCaptureButton_Click(object sender, EventArgs e)
        {
            if (job != null)
            {
                job.StopEncoding();
                job.RemoveDeviceSource(devSource);

                devSource.PreviewWindow = null;
                devSource = null;
            }
            job = null;
        }

        private void UpdateListSequence(int seqPoint, bool isAcquired)
        {
            if (seqPoint > acqPointListView.Items.Count)
                return;

            if (isAcquired == true)
            {
                acqPointListView.Items[seqPoint].SubItems[3].Text = "Yes";
            }
            else
            {
                acqPointListView.Items[seqPoint].SubItems[3].Text = "No";
            }
        }

        double[] xAxesGraphVals = null;
        private void UpdateGraph(DataSeries dataSeries)
        {
            // the graph window only takes values of doubles
            if (dataSeries.YLength == 1)
            {
                int xLen = dataSeries.XLength;
                double[] yValsTemp = new double[xLen];
                ushort[,] ccdData = dataSeries.CCDData; // don't want to keep getting this data through the accessor=slow

                for (int i = 0; i < xLen; i++)
                {
                    yValsTemp[i] = ccdData[i, 0];
                }

                // we don't want to keep recreating the xAxes array(slow)
                if (xAxesGraphVals == null)
                {
                    xAxesGraphVals = new double[xLen];
                    for (int i = 0; i < xLen; i++)
                    {
                        xAxesGraphVals[i] = i + 1;
                    }
                }
                                
                if (seperateGraphWindow == null)
                {
                    seperateGraphWindow = new GraphWindow();                    
                }

                if (seperateGraphWindow.IsDisposed == true)
                {
                    seperateGraphWindow = new GraphWindow(); 
                }

                seperateGraphWindow.Show();
                seperateGraphWindow.GraphWindowPlot("Single Shot Acq", xAxesGraphVals, yValsTemp, Color.Blue);
            }

            // plot the 2D data ilNumericsControl1.Plot(yVals);
        }

        private void UpdateStatus(String status)
        {
            toolStripStatusLabel1.Text = status;
        }

        private void AcqComplete()
        {
            // acqControllerObj = null;
        }
        private void acquireButton_Click(object sender, EventArgs e)
        {
            PVCAM_Wrapper_Class pvcamObj = (PVCAM_Wrapper_Class) selectedCameraComboBox.SelectedItem;
            int exposureTime = 1;

            if (exposureUnitComboBox.SelectedItem != null)
            {
                switch ((ExposureResolution)exposureUnitComboBox.SelectedItem)
                {
                    // camera only supports us & s, integration tims is a int32
                    case ExposureResolution.us:
                        pvcamObj.ExposureRes = EXPOSURE_RES.EXP_RES_ONE_MICROSEC;
                        exposureTime = (int)integrationNumericUpDown.Value;
                        break;

                    case ExposureResolution.ms:
                        pvcamObj.ExposureRes = EXPOSURE_RES.EXP_RES_ONE_MILLISEC;
                        exposureTime = (int)integrationNumericUpDown.Value;
                        break;

                    case ExposureResolution.s:
                        pvcamObj.ExposureRes = EXPOSURE_RES.EXP_RES_ONE_MILLISEC;
                        exposureTime = (int)integrationNumericUpDown.Value * 1000;
                        break;

                    case ExposureResolution.min:
                        pvcamObj.ExposureRes = EXPOSURE_RES.EXP_RES_ONE_MILLISEC;
                        exposureTime = (int)integrationNumericUpDown.Value * 1000 * 60;
                        break;
                }
            }
            else
            {
                pvcamObj.ExposureRes = EXPOSURE_RES.EXP_RES_ONE_MILLISEC;
                exposureTime = (int)integrationNumericUpDown.Value;
            }

            if (acqControllerObj != null)
            {
                acqControllerObj.Stop();
            }
            
            acqControllerObj = new AcqController(pvcamObj,
                new UIUpdateGraphDelegate(UpdateGraph),
                new UIUpdateStatusDelegate(UpdateStatus),
                new UIFinished(AcqComplete),
                new UIUpdateSequenceDelegate(UpdateListSequence));
            

            acqControllerObj.NumExposure = (int)numScansNumericUpDown.Value;
            acqControllerObj.ExposureTime = exposureTime;

            if (seperateGraphWindow == null)
            {
                seperateGraphWindow = new GraphWindow();
            }

            if (seperateGraphWindow.IsDisposed == true)
            {
                seperateGraphWindow = new GraphWindow();
            }

            seperateGraphWindow.Show();
            seperateGraphWindow.BringToFront();

            acqControllerObj.StartAcq(this, pvcamObj);     
     
        }

        private void acquireContinousButton_Click(object sender, EventArgs e)
        {
            PVCAM_Wrapper_Class pvcamObj = (PVCAM_Wrapper_Class)selectedCameraComboBox.SelectedItem;
            int exposureTime = 1;

            if (exposureUnitComboBox.SelectedItem != null)
            {
                switch ((ExposureResolution)exposureUnitComboBox.SelectedItem)
                {
                    // camera only supports us & s, integration tims is a int32
                    case ExposureResolution.us:
                        pvcamObj.ExposureRes = EXPOSURE_RES.EXP_RES_ONE_MICROSEC;
                        exposureTime = (int)integrationNumericUpDown.Value;
                        break;

                    case ExposureResolution.ms:
                        pvcamObj.ExposureRes = EXPOSURE_RES.EXP_RES_ONE_MILLISEC;
                        exposureTime = (int)integrationNumericUpDown.Value;
                        break;

                    case ExposureResolution.s:
                        pvcamObj.ExposureRes = EXPOSURE_RES.EXP_RES_ONE_MILLISEC;
                        exposureTime = (int)integrationNumericUpDown.Value * 1000;
                        break;

                    case ExposureResolution.min:
                        pvcamObj.ExposureRes = EXPOSURE_RES.EXP_RES_ONE_MILLISEC;
                        exposureTime = (int)integrationNumericUpDown.Value * 1000 * 60;
                        break;
                }
            }
            else
            {
                pvcamObj.ExposureRes = EXPOSURE_RES.EXP_RES_ONE_MILLISEC;
                exposureTime = (int)integrationNumericUpDown.Value;
            }

            acqControllerObj = new AcqController(pvcamObj,
                new UIUpdateGraphDelegate(UpdateGraph),
                new UIUpdateStatusDelegate(UpdateStatus),
                new UIFinished(AcqComplete),
                new UIUpdateSequenceDelegate(UpdateListSequence));

            acqControllerObj.ExposureTime = exposureTime;


            if (seperateGraphWindow == null)
            {
                seperateGraphWindow = new GraphWindow();
            }

            if (seperateGraphWindow.IsDisposed == true)
            {
                seperateGraphWindow = new GraphWindow();
            }

            seperateGraphWindow.Show();
            seperateGraphWindow.BringToFront();

            acqControllerObj.StartAcqContinous(this, pvcamObj);     
        }

        private void stopButton_Click(object sender, EventArgs e)
        {
            if (acqControllerObj != null)
            {
                acqControllerObj.Stop();
            }
        }

        private void BelugaMainForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            // make sure the acq has been stoped
            if (acqControllerObj != null)
            {
                acqControllerObj.Stop();
            }
        }

        private void LVRenumber()
        {
            for (int i = 0; i < acqPointListView.Items.Count; i++)
            {
                acqPointListView.Items[i].Text = (i).ToString();
            }
        }

        /// <summary>
        /// Adds a point as new item the list view
        /// </summary>
        /// <param name="position">The position on all the motor axes</param>
        private void AddPointToListView(double[] positions)
        {
            if (positions == null)
                return;

            ListViewItem lvItem = new ListViewItem(acqPointListView.Items.Count.ToString());
            StringBuilder sb = new StringBuilder();

            for (int i = 0; i < positions.Length; i++)
            {
                sb.AppendFormat("Ax{0} = {1}, ", i, positions[i]);
            }

            // add the point description
            lvItem.SubItems.Add(sb.ToString());
            lvItem.SubItems.Add(numExposureSeqnumericUpDown.Value.ToString());

            // would like to make this red dot
            lvItem.SubItems.Add("No");
            lvItem.Tag = positions;

            acqPointListView.Items.Add(lvItem);
        }

        private void addButton_Click(object sender, EventArgs e)
        {
            AddPointToListView(motorsFormObj.CurrentPositions);            
        }
                        
        private void acquireSeqButton_Click(object sender, EventArgs e)
        {
            // this data point is the physical location where the data was taken
            DataLocation [] dataPointArr = new DataLocation[acqPointListView.Items.Count];
            
            for (int i = 0; i < acqPointListView.Items.Count; i++)
            {
                // populate with the positions from the motor object
                dataPointArr[i] = new DataLocation((double[])acqPointListView.Items[i].Tag, Convert.ToInt32(acqPointListView.Items[i].SubItems[2].Text));
            }
            // get the camera object
            PVCAM_Wrapper_Class pvcamObj = (PVCAM_Wrapper_Class)selectedCameraComboBox.SelectedItem;
            int exposureTime = 1;

            if (exposureUnitComboBox.SelectedItem != null)
            {
                switch ((ExposureResolution)exposureUnitComboBox.SelectedItem)
                {
                    // camera only supports us & s, integration tims is a int32
                    case ExposureResolution.us:
                        pvcamObj.ExposureRes = EXPOSURE_RES.EXP_RES_ONE_MICROSEC;
                        exposureTime = (int)integrationNumericUpDown.Value;
                        break;

                    case ExposureResolution.ms:
                        pvcamObj.ExposureRes = EXPOSURE_RES.EXP_RES_ONE_MILLISEC;
                        exposureTime = (int)integrationNumericUpDown.Value;
                        break;

                    case ExposureResolution.s:
                        pvcamObj.ExposureRes = EXPOSURE_RES.EXP_RES_ONE_MILLISEC;
                        exposureTime = (int)integrationNumericUpDown.Value * 1000;
                        break;

                    case ExposureResolution.min:
                        pvcamObj.ExposureRes = EXPOSURE_RES.EXP_RES_ONE_MILLISEC;
                        exposureTime = (int)integrationNumericUpDown.Value * 1000 * 60;
                        break;
                }
            }
            else
            {
                pvcamObj.ExposureRes = EXPOSURE_RES.EXP_RES_ONE_MILLISEC;
                exposureTime = (int)integrationNumericUpDown.Value;
            }


            if (acqControllerObj != null)
            {
                acqControllerObj.Stop();
            }

            acqControllerObj = new AcqController(pvcamObj,
                new UIUpdateGraphDelegate(UpdateGraph),
                new UIUpdateStatusDelegate(UpdateStatus),
                new UIFinished(AcqComplete),
                new UIUpdateSequenceDelegate(UpdateListSequence));

            acqControllerObj.NumExposure = (int)numScansNumericUpDown.Value;
            acqControllerObj.ExposureTime = exposureTime;

            if (usePVCamRadioButton.Checked == true)
            {
                if (seperateGraphWindow == null)
                {
                    seperateGraphWindow = new GraphWindow();
                }

                if (seperateGraphWindow.IsDisposed == true)
                {
                    seperateGraphWindow = new GraphWindow();
                }

                seperateGraphWindow.Show();
                seperateGraphWindow.BringToFront();

                acqControllerObj.StartAcqSeq(this, motorsFormObj.Axes, dataPointArr, pvcamObj);
            }

            if (useWebCamRadioButton.Checked == true)
            {
                if (savePathTextBox.Text == null)
                    pathSelectButton_Click(this, EventArgs.Empty);

                if (savePathTextBox.Text == "")
                    pathSelectButton_Click(this, EventArgs.Empty);

                startCapture_Click(this, EventArgs.Empty); // make sure the caputre has been started
                acqControllerObj.StartAcqSeq(this, motorsFormObj.Axes, dataPointArr, prevForm, savePathTextBox.Text);
            }
        }

        private void resetButton_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < acqPointListView.Items.Count; i++)
            {
                UpdateListSequence(i, false);
            }
        }

        private void clearButton_Click(object sender, EventArgs e)
        {
            acqPointListView.Items.Clear();
        }


        // by putting the dialog here the path won't reset
        FolderBrowserDialog fbDialog = new FolderBrowserDialog();            
        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (fbDialog.ShowDialog() == DialogResult.OK)
            {
                if (acqControllerObj != null)
                {
                    try
                    {
                        acqControllerObj.SaveDataArr(fbDialog.SelectedPath);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }
                else
                {
                    MessageBox.Show("No Data has been acquired to Save");
                }
            }
        }

        private void deleteButton_Click(object sender, EventArgs e)
        {
            if (acqPointListView.SelectedItems != null)
            {
                foreach (ListViewItem i in acqPointListView.SelectedItems)
                {
                    i.Remove();
                }
                // renumber the list view
                LVRenumber();
            }


        }

        private void pathSelectButton_Click(object sender, EventArgs e)
        {
            if (fbDialog.ShowDialog() == DialogResult.OK)
            {
                savePathTextBox.Text = fbDialog.SelectedPath;
            }
        }

        private void addGridButton_Click(object sender, EventArgs e)
        {
            // add points in order x then y
            int xNumPts = (int) numPtsAx1NumericUpDown.Value;
            int yNumPts = (int) numPtsAx2NumericUpDown.Value;
            double xStepSize = (double)stepSizeXNumericUpDown.Value / 1000; // convert to (mm)
            double yStepSize = (double)stepSizeYNumericUpDown.Value / 1000; // convert to (mm)
            int xMotorIndex = motorAxis1ComboBox.SelectedIndex;
            int yMotorIndex = motorAxis1ComboBox.SelectedIndex;


            double[] currentPositions = motorsFormObj.CurrentPositions;
            int numMotors = currentPositions.Length;
            // get the current position of all the motors
            double xOrgin = currentPositions[xMotorIndex];
            double yOrgin = currentPositions[yMotorIndex];

            double rectDistX = xStepSize * (xNumPts - 1); // remember fence post
            double rectDistY = yStepSize * (yNumPts - 1); // remember fence post

            double postionX1 = xOrgin - rectDistX / 2; // the first x point in the rectangle
            double postionY1 = yOrgin - rectDistY / 2; // the first y point in the rectangle
            // add all the points
            for (int i = 0; i < xNumPts; i++) // the x loop
            {
                for (int j = 0; j < yNumPts; j++) // the y loop
                {
                    double[] gridPositions = new double[numMotors];
                    Array.Copy(currentPositions, gridPositions, numMotors);
                    gridPositions[xMotorIndex] = postionX1 + i * (xStepSize);
                    gridPositions[yMotorIndex] = postionY1 + j * (yStepSize);

                    AddPointToListView(gridPositions);
                }
            }            
        }

        private void acqPointListView_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char) Keys.Delete)
            {
                deleteButton_Click(this, EventArgs.Empty);
            }
        }
    }
}
