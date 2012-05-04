using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Runtime.InteropServices;

// Monochromator
using Lab_Drivers_ARC_SpectraProDLL_ManagedWrapper; //C++/CLI doesn't support doted.subdot names spaces
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
    public delegate void UIUpdateGraphDelegate(double[] xArr, double[,] yArr);
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
        AcqController acqControllerObj;
        String []cameraNames = null;
        ToolStripMenuItem[] cameraItems = null;

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

                cameraArr[i].ShutterMode2 = SHUTTER_MODE.DISABLED_OPEN; // debug setting
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
            if (job != null)
            {
                job.Dispose();
                job = null;
            }

            job = new LiveJob();

            devSource =
                job.AddDeviceSource(cameraList[videoDeviceComboBox.SelectedIndex], null);

            VideoPreviewForm prevForm = new VideoPreviewForm(job, devSource);
             
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

        private void UpdateGraph(double[] xVals, double[,] yVals)
        {
            if (yVals.GetLength(1) == 1)
            {
                double[] yValsTemp = new double[yVals.GetLength(0)];

                for (int i = 0; i < yVals.GetLength(0); i++)
                {
                    yValsTemp[i] = yVals[i, 0];
                }

                graphControl1.Plot("Data1", xVals, yValsTemp, Color.Blue);
            }

            ilNumericsControl1.Plot(yVals);
        }

        private void UpdateStatus(String status)
        {
            toolStripStatusLabel1.Text = status;
        }

        private void AcqComplete()
        {
            acqControllerObj = null;
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

            acqControllerObj = new AcqController(pvcamObj, 
                new UIUpdateGraphDelegate(UpdateGraph),
                new UIUpdateStatusDelegate(UpdateStatus),
                new UIFinished(AcqComplete));

            acqControllerObj.NumExposure = (int)numScansNumericUpDown.Value;
            acqControllerObj.ExposureTime = exposureTime;

            acqControllerObj.StartAcq(this);     
     
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

    
    }
}
