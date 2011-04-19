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
        DTDaq dtDaqObj; 

        public MainForm()
        {
            InitializeComponent();

            dtDaqObj = new DTDaq();
            
            
            deviceComboBox.Items.AddRange(dtDaqObj.DAQDevices);             // and populate them into the device combo box

            if (dtDaqObj.DAQDevices.Length > 0)
            {
                deviceComboBox.SelectedIndex = 0;
                SetVoltageFromControls();
            }
            else
            {
                MessageBox.Show("No Output Channels");
            }
        }

        public void InitalizeDTDAQ()
        {
            dtDaqObj.Initalize();

            // if the device has less than 3 channels 
            // enable the numbe of channels numeric only for the number of channels in use
            if (dtDaqObj.NumberOutputChannels <= 3)
            {
                if (dtDaqObj.NumberOutputChannels <= 0)
                {
                    ao0numeric.Enabled = false;
                    ao1numeric.Enabled = false;
                    ao2numeric.Enabled = false;
                }
                else
                {
                    switch (dtDaqObj.NumberOutputChannels)
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

        public void Exit()
        {
            if (dtDaqObj != null)
            {
                dtDaqObj.Dispose();
                dtDaqObj = null;
            }
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            Exit();
        }

        private void setVoltageButton_Click(object sender, EventArgs e)
        {
            SetVoltageFromControls();
        }

        private void SetVoltageFromControls()
        {
            // populate the array with the voltage values
            // don't worry about if the channel doesn't exist
            // that problem is dealt with in the voltage output
            double[] volts = new double[3];

            volts[0] = Convert.ToDouble(ao0numeric.Value);
            volts[1] = Convert.ToDouble(ao1numeric.Value);
            volts[2] = Convert.ToDouble(ao2numeric.Value);

            dtDaqObj.SetDAQVoltagesArr(volts);         
        }

        private void aonumeric_ValueChanged(object sender, EventArgs e)
        {
            SetVoltageFromControls();
        }

        private void initalizeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            dtDaqObj.Initalize();

            if (dtDaqObj.Initalized == true)
            {
                deviceComboBox.Items.Clear();
                deviceComboBox.Items.AddRange(dtDaqObj.DAQDevices);

                SetVoltageFromControls();
            }
        }

    }
}
