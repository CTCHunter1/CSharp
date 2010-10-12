using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using OpenLayers.Base;

namespace Pipit
{
    public partial class MainForm : Form
    {
        DeviceMgr deviceMgrObj = null;
        Device daqDevice = null;
        AnalogOutputSubsystem aoSubObj = null;

        public MainForm()
        {
            InitializeComponent();

            deviceMgrObj = DeviceMgr.Get();     // first need to get the device manager
            
            string[] deviceNames = deviceMgrObj.GetDeviceNames();   // then get the names of the devices
            deviceComboBox.Items.AddRange(deviceNames);             // and populate them into the device combo box

            
            if (deviceComboBox.Items.Count > 0)
            {
                deviceComboBox.SelectedIndex = 0;

                InitalizeDTDAQ();
            }
        }

        public void InitalizeDTDAQ()
        {
            // this can only be done if there was a device detected
            // there was a device detected of the device combo box is populated
            if (deviceComboBox.Items.Count <= 0)
                return; // no device detected just return

            // if there was already a AO subsystem device dispose of it
            if (aoSubObj != null)
            {
                aoSubObj.Dispose();
                aoSubObj = null;
            }

            // if there was already a daq device dispose of it
            if (daqDevice != null)
            {
                daqDevice.Dispose();
                daqDevice = null;
            }


            daqDevice = deviceMgrObj.GetDevice((string) deviceComboBox.SelectedItem);

            // check if this device has an analog out subsystem
            if (daqDevice.GetNumSubsystemElements(SubsystemType.AnalogOutput) == 0)
            {
                // this device has no analog output subsystems
                Exception ex = new Exception("DT Device Error: Not Analog Output on Device");
                throw(ex);
            }

            // get the first subsystem
            aoSubObj = daqDevice.AnalogOutputSubsystem(0);

            aoSubObj.DataFlow = DataFlow.SingleValue;
            aoSubObj.ChannelType = ChannelType.SingleEnded;
            aoSubObj.Config();

            // if the device has less than 3 channels 
            // enable the numbe of channels numeric only for the number of channels in use
            if (aoSubObj.NumberOfChannels <= 3)
            {
                if (aoSubObj.NumberOfChannels <= 0)
                {
                    ao0numeric.Enabled = false;
                    ao1numeric.Enabled = false;
                    ao2numeric.Enabled = false;
                }
                else
                {
                    switch(aoSubObj.NumberOfChannels)
                    {
                        case 1:
                            ao0numeric.Enabled = true;
                            ao1numeric.Enabled = false;
                            ao2numeric.Enabled = false;
                            break;

                        case 2:
                            ao0numeric.Enabled = true;
                            ao1numeric.Enabled = true;
                            ao2numeric.Enabled = false;
                            break;

                        case 3:
                        default:
                            ao0numeric.Enabled = true;
                            ao1numeric.Enabled = true;
                            ao2numeric.Enabled = true; 
                            break;
                    }
                }
            }
            else
            {
                ao0numeric.Enabled = true;
                ao1numeric.Enabled = true;
                ao2numeric.Enabled = true; 
            }

            // update the voltage values
            setVoltageButton_Click(this, null);
        }

        public void SetDAQVoltages(double []chVolts)
        {
            int numChannels = aoSubObj.NumberOfChannels;

            // iterate through the volts loop to get the channels
            for (int i = 0; i < chVolts.Length && i < numChannels; i++)
            {
                aoSubObj.SetSingleValueAsVolts(i, chVolts[i]);
            }
        }

        public void Exit()
        {
            if (daqDevice != null)
            {
                daqDevice.Dispose();
                daqDevice = null;
            }
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            Exit();
        }

        private void setVoltageButton_Click(object sender, EventArgs e)
        {
            // populate the array with the voltage values
            // don't worry about if the channel doesn't exist
            // that problem is dealt with in the voltage output
            double[] volts = new double[3];

            volts[0] = Convert.ToDouble(ao0numeric.Value);
            volts[1] = Convert.ToDouble(ao1numeric.Value);
            volts[2] = Convert.ToDouble(ao2numeric.Value);

            SetDAQVoltages(volts);
        }
    }
}
