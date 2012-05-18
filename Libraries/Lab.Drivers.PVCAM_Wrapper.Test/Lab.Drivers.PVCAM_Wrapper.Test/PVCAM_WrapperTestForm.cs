using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using Lab_Drivers_PVCAM_Wrapper;
using GraphControl;

namespace Lab.Drivers.PVCAM_Wrapper.Test
{
    public delegate void UIUpdateGraphDelegate(double[] xArr, double[] yArr);
    public delegate void UIFinished();

    public enum ExposureResolution { us, ms, s, min };

    public partial class PVCAM_WrapperTestForm : Form
    {
        PVCAM_Wrapper_Class PVCAM_obj = null;
        DoubleBufferController dbCont = null;
        GraphWindow seperateGraphWindow = null;
        bool bSubMenu = false; 


        public PVCAM_WrapperTestForm(PVCAM_Wrapper_Class PVCam_obj)
        {
            InitializeComponent();

            this.PVCAM_obj = PVCam_obj;
            
            ccdClearingControl.PVCAM_Obj = PVCAM_obj;
            ccdClearingControl.PropertyType = "CCD Clearing";
           
            ccdClearingControl.ParamItems = new object[]{PARAMS.PARAM_ANTI_BLOOMING_W,
                                           PARAMS.PARAM_CLEAR_CYCLES_W,
                                           PARAMS.PARAM_CLEAR_MODE_W,
                                           PARAMS.PARAM_CLN_WHILE_EXPO_W,
                                           PARAMS.PARAM_CONT_CLEARS_W,
                                           PARAMS.PARAM_MIN_BLOCK_W,
                                           PARAMS.PARAM_NUM_MIN_BLOCK_W,
                                           PARAMS.PARAM_NUM_OF_STRIPS_PER_CLR_W,
                                           PARAMS.PARAM_PREEXP_CLEANS_W,
                                           PARAMS.PARAM_SKIP_AT_ONCE_BLK_W,
                                           PARAMS.PARAM_SKIP_SREG_CLEAN_W};

            gainPropertyControl.PVCAM_Obj = PVCAM_obj;
            gainPropertyControl.PropertyType = "Gain";
            gainPropertyControl.ParamItems = new object[]{PARAMS.PARAM_GAIN_INDEX_W,
                                           PARAMS.PARAM_GAIN_MULT_ENABLE_W,
                                           PARAMS.PARAM_GAIN_MULT_FACTOR_W,
                                           PARAMS.PARAM_INTENSIFIER_GAIN_W,
                                           PARAMS.PARAM_PREAMP_DELAY_W,
                                           PARAMS.PARAM_PREAMP_OFF_CONTRL_W};

            temperaturePropertyControl.PVCAM_Obj = PVCAM_obj;
            temperaturePropertyControl.PropertyType = "Temperature Control";
            temperaturePropertyControl.ParamItems = new object[]{PARAMS.PARAM_COOLING_FAN_CTRL_W,
                                           PARAMS.PARAM_COOLING_MODE_W,
                                           PARAMS.PARAM_HEAD_COOLING_CTRL_W,
                                           PARAMS.PARAM_TEMP_W,
                                           PARAMS.PARAM_TEMP_SETPOINT_W};

            shutterPropertyControl.PVCAM_Obj = PVCAM_obj;
            shutterPropertyControl.PropertyType = "Shutter Control";
            shutterPropertyControl.ParamItems = new object[]{PARAMS.PARAM_EXPOSURE_MODE_W,
                                           PARAMS.PARAM_PREFLASH_W,
                                           PARAMS.PARAM_SHTR_CLOSE_DELAY_W,
                                           PARAMS.PARAM_SHTR_CLOSE_DELAY_UNIT_W,
                                           PARAMS.PARAM_SHTR_GATE_MODE_W,
                                           PARAMS.PARAM_SHTR_OPEN_DELAY_W,
                                           PARAMS.PARAM_SHTR_OPEN_MODE_W,
                                           PARAMS.PARAM_SHTR_RES_W,
                                           PARAMS.PARAM_SHTR_STATUS_W};

            ADCPropertyControl.PVCAM_Obj = PVCAM_obj;
            ADCPropertyControl.PropertyType = "ADC Control";
            ADCPropertyControl.ParamItems = new object[]{PARAMS.PARAM_ADC_OFFSET_W,
                                           PARAMS.PARAM_BIT_DEPTH_W,
                                           PARAMS.PARAM_SPDTAB_INDEX_W};

            CCDPhysPropertyControl.PVCAM_Obj = PVCAM_obj;
            CCDPhysPropertyControl.PropertyType = "CCD Physical Attribute";
            CCDPhysPropertyControl.ParamItems = new object[]{PARAMS.PARAM_COLOR_MODE_W,
	                                            PARAMS.PARAM_CUSTOM_CHIP_W,
	                                            PARAMS.PARAM_FTSCAN_W,
	                                            PARAMS.PARAM_FWELL_CAPACITY_W,
	                                            PARAMS.PARAM_KIN_WIN_SIZE_W,
	                                            PARAMS.PARAM_PAR_SIZE_W,
	                                            PARAMS.PARAM_PIX_PAR_DIST_W,
	                                            PARAMS.PARAM_PIX_PAR_SIZE_W,
	                                            PARAMS.PARAM_PIX_SER_DIST_W,
	                                            PARAMS.PARAM_PIX_SER_SIZE_W,
	                                            PARAMS.PARAM_POSTMASK_W,
	                                            PARAMS.PARAM_POSTSCAN_W,
	                                            PARAMS.PARAM_PIX_TIME_W,
	                                            PARAMS.PARAM_PREMASK_W,
	                                            PARAMS.PARAM_PRESCAN_W,
	                                            PARAMS.PARAM_SER_SIZE_W,
	                                            PARAMS.PARAM_SUMMING_WELL_W};
                        
            CCDReadOutPropertyControl.PVCAM_Obj = PVCAM_obj;
            CCDReadOutPropertyControl.PropertyType = "CCD Readout";
            CCDReadOutPropertyControl.ParamItems = new object[]{PARAMS.PARAM_CCS_STATUS_W,
	                                            PARAMS.PARAM_CUSTOM_TIMING_W,
	                                            PARAMS.PARAM_EDGE_TRIGGER_W,
	                                            PARAMS.PARAM_PAR_SHIFT_TIME_W,
	                                            PARAMS.PARAM_PAR_SHIFT_INDEX_W,
	                                            PARAMS.PARAM_PBC_W,
	                                            PARAMS.PARAM_PMODE_W,	                                           
                                                PARAMS.PARAM_PIX_PAR_SIZE_W,
	                                            PARAMS.PARAM_READOUT_PORT_W,
	                                            PARAMS.PARAM_READOUT_TIME_W,
	                                            PARAMS.PARAM_SER_SHIFT_TIME_W};

            DataAcqPropertyControl.PVCAM_Obj = PVCAM_obj;
            DataAcqPropertyControl.PropertyType = "Data Acquisition";
            DataAcqPropertyControl.ParamItems = new object[]{PARAMS.PARAM_BOF_EOF_CLR_W,
	                                            PARAMS.PARAM_BOF_EOF_COUNT_W,
	                                            PARAMS.PARAM_BOF_EOF_ENABLE_W,
                                                PARAMS.PARAM_CIRC_BUFFER_W,
	                                            PARAMS.PARAM_EXP_MIN_TIME_W,
	                                            PARAMS.PARAM_EXP_RES_W,
	                                            PARAMS.PARAM_EXP_RES_INDEX_W,
	                                            PARAMS.PARAM_EXP_TIME_W,	                                           
                                                PARAMS.PARAM_HW_AUTOSTOP_W,
	                                            PARAMS.PARAM_HW_AUTOSTOP32_W};

            exposureUnitComboBox.DataSource = Enum.GetValues(typeof(ExposureResolution));
            exposureUnitComboBox.SelectedIndex = 1;

            // not sure I want this here, will init on startup
            initalizeButton_Click(this, EventArgs.Empty);
        }

        public PVCAM_WrapperTestForm() : this(new PVCAM_Wrapper_Class("Camera1"))
        {

        }

        private void initalizeButton_Click(object sender, EventArgs e)
        {
            shutterModeComboBox.DataSource = Enum.GetValues(typeof(SHUTTER_MODE));

            try
            {
                PVCAM_obj.PVCamInit();

                shutterModeComboBox.SelectedItem = PVCAM_obj.ShutterMode2;

                xPixelsNumericUpDown.Value = Convert.ToDecimal(PVCAM_obj.XNumPixels);

                yPixelsNumericUpDown.Value = Convert.ToDecimal(PVCAM_obj.YNumPixels);

                xMinNumericUpDown.Value = 0;
                yMinNumericUpDown.Value = 0;

                xMaxNumericUpDown.Value = Convert.ToDecimal(PVCAM_obj.XNumPixels - 1);
                yMaxNumericUpDown.Value = Convert.ToDecimal(PVCAM_obj.YNumPixels - 1);

                xBinNumericUpDown.Value = Convert.ToDecimal(1);
                yBinNumericUpDown.Value = Convert.ToDecimal(PVCAM_obj.YNumPixels);

                numCamerasNmericUpDown.Value = (decimal)PVCAM_Wrapper_Class.GetNumCameras();

                cameraNamesComboBox.Items.AddRange(PVCAM_Wrapper_Class.GetCameraNames());

                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void ROI_Changed(object sender, EventArgs e)
        {
            PVCAM_obj.SetROI(Convert.ToInt32(xMinNumericUpDown.Value),
                Convert.ToInt32(xMaxNumericUpDown.Value),
                Convert.ToInt32(xBinNumericUpDown.Value),
                Convert.ToInt32(yMinNumericUpDown.Value),
                Convert.ToInt32(yMaxNumericUpDown.Value),
                Convert.ToInt32(yBinNumericUpDown.Value));
        }


        private void setupSingleShotButton_Click(object sender, EventArgs e)
        {
            
        }

        private void acquireSingleShotButton_Click(object sender, EventArgs e)
        {
            int exposureTime = 1;

            if (exposureUnitComboBox.SelectedItem != null)
            {
                switch ((ExposureResolution)exposureUnitComboBox.SelectedItem)
                {
                    // camera only supports us & s, integration tims is a int32
                    case ExposureResolution.us:
                        PVCAM_obj.ExposureRes = EXPOSURE_RES.EXP_RES_ONE_MICROSEC;
                        exposureTime = (int)integrationNumericUpDown.Value;
                        break;

                    case ExposureResolution.ms:
                        PVCAM_obj.ExposureRes = EXPOSURE_RES.EXP_RES_ONE_MILLISEC;
                        exposureTime = (int)integrationNumericUpDown.Value;
                        break;

                    case ExposureResolution.s:
                        PVCAM_obj.ExposureRes = EXPOSURE_RES.EXP_RES_ONE_MILLISEC;
                        exposureTime = (int)integrationNumericUpDown.Value * 1000;
                        break;

                    case ExposureResolution.min:
                        PVCAM_obj.ExposureRes = EXPOSURE_RES.EXP_RES_ONE_MILLISEC;
                        exposureTime = (int)integrationNumericUpDown.Value * 1000 * 60;
                        break;
                }
            }
            else
            {
                PVCAM_obj.ExposureRes = EXPOSURE_RES.EXP_RES_ONE_MILLISEC;
                exposureTime = (int)integrationNumericUpDown.Value;
            }

            PVCAM_obj.SetupCameraSingleShot(exposureTime);

            ushort[,] myBuff = PVCAM_obj.AquireSingleShot();

            // graph control only takes doubles -- needs updating
            double[] xvals = new double[myBuff.Length];
            double[] yvals = new double[myBuff.Length];

            for (int i = 0; i < myBuff.Length; i++)
            {
                xvals[i] = i + 1;
                yvals[i] = Convert.ToDouble(myBuff[i, 0]);
            }


            if (seperateGraphWindow == null)
            {
                seperateGraphWindow = new GraphWindow();
                seperateGraphWindow.Show();
            }

            seperateGraphWindow.GraphWindowPlot("Single Shot Acq", xvals, yvals, Color.Blue);                          
        }

        private void getTempButton_Click(object sender, EventArgs e)
        {
            tempNumericUpDown.Value = Convert.ToDecimal(PVCAM_obj.Temperature);
        }

        private void setTempButton_Click(object sender, EventArgs e)
        {
            PVCAM_obj.Temperature = Convert.ToDouble(tempNumericUpDown.Value);
        }

        private void unIntializeButton_Click(object sender, EventArgs e)
        {
            PVCAM_obj.PVCamUninit();
        }

        private void setupDoubleBuffButton_Click(object sender, EventArgs e)
        {
            PVCAM_obj.SetupCameraDoubleBuffer(250);
        }

        private void acqDoubleBuffer_Click(object sender, EventArgs e)
        {
            UIUpdateGraphDelegate uiUpdateGraphDelegate = new UIUpdateGraphDelegate(UpdateGraph);
            UIFinished uiFinishedDelegate = new UIFinished(FinishedFun);

            dbCont = new DoubleBufferController(PVCAM_obj, uiUpdateGraphDelegate, uiFinishedDelegate);
            dbCont.StartDBAcq(this);

            dBStatusTextBox.Text = "Started";
        }

        private void canDoubleBufButton_Click(object sender, EventArgs e)
        {
            bool canDoubleBuff = PVCAM_obj.CanDoubleBuffer;

            if (canDoubleBuff)
            {
                canDoubleBuffTextBox.Text = "true";
            }
            else
            {
                canDoubleBuffTextBox.Text = "false";
            }
        }

        private void UpdateGraph(double [] xdata, double [] yData)
        {
            if (seperateGraphWindow == null)
            {
                seperateGraphWindow = new GraphWindow();
            }

            seperateGraphWindow.GraphWindowPlot("Delegate Data", xdata, yData, Color.Red);

        }

        private void FinishedFun()
        {
            dBStatusTextBox.Text = "Done";

        }

        private void stopDBAcqButton_Click(object sender, EventArgs e)
        {
            if (dbCont != null)
            {
                dbCont.Stop();
                dbCont = null;
            }            
        }


        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            PVCAM_obj.PVCamUninit();
        }

        private void getTypeButton_Click(object sender, EventArgs e)
        {
           // typeTextBox.Text = PVCAM_obj.GetParamType().ToString();
            
        }

        private void getShutterModeButton_Click(object sender, EventArgs e)
        {
            shutterModeComboBox.SelectedItem = PVCAM_obj.ShutterMode2;
        }

        private void setShutterModeButton_Click(object sender, EventArgs e)
        {
            try
            {
                PVCAM_obj.ShutterMode2 = (SHUTTER_MODE)shutterModeComboBox.SelectedItem;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void PVCAM_WrapperTestForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            // if this object is initalized as a submenu e.g. not a stand alone test app
            // but part of another program
            if (bSubMenu == true)
            {
                this.Hide();
                // this will prevent the object from being disposed & resources released
                e.Cancel = true;
            }                    
        }

        public PVCAM_Wrapper_Class PVCAMObj
        {
            get 
            {
                return (PVCAM_obj);
            }
        }

        // Configures if the resources are released when close button is clicked
        public bool IsSubForm
        {
            get
            {
                return (bSubMenu);
            }
            set
            {
                bSubMenu = value;
            }

        }

        private void PVCAM_WrapperTestForm_Activated(object sender, EventArgs e)
        {
            getShutterModeButton_Click(this, EventArgs.Empty);
        }
    }
}
