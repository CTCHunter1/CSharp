using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using NationalInstruments.DAQmx;

namespace Lab.Drivers.DAQ
{
    public partial class NI6251ControlForm : Form
    {
        // store the current control parameters incase of cancel
        private int backupSelectedChannelIndex;
        private AITerminalConfiguration backupTerminalMode;
        private decimal backupMinValue;
        private decimal backupMaxValue;
        private decimal backupSamplesChannel;
        private decimal backupRate;

        private bool bSingleShot = false;

        private Task taskObj = null;

        
        public NI6251ControlForm()
        {
            InitializeComponent();
        
            // Get the channels available
            physicalChannelComboBox.Items.AddRange(DaqSystem.Local.GetPhysicalChannels(PhysicalChannelTypes.AI, PhysicalChannelAccess.External));
            if( physicalChannelComboBox.Items.Count > 0)
                physicalChannelComboBox.SelectedIndex = 0;

            // add the terminal configuration modes to it's combo box
            terminalModeComboBox.Items.Add(AITerminalConfiguration.Differential);
            terminalModeComboBox.Items.Add(AITerminalConfiguration.Nrse);
            terminalModeComboBox.Items.Add(AITerminalConfiguration.Rse);

            terminalModeComboBox.SelectedItem = AITerminalConfiguration.Differential;

            AddCurrentChannel();

            SetupDevice();
        }

        private void SetupDevice()
        {
            // if there is already a task stop it
            if (taskObj != null)
            {
                taskObj.Control(TaskAction.Stop);
                taskObj.Dispose();
            }
            
            try
            {
                // create a new task
                taskObj = new Task("Task 1");
                
                // add all of the channels in the channels list
                foreach (AIVoltageChannel aivcObj in channelsListBox.Items)
                {

                    taskObj.AIChannels.CreateVoltageChannel(aivcObj.PhysicalChannelName,
                        aivcObj.NameToAssignChannel,
                        aivcObj.AITerminalConfiguration,
                        aivcObj.MinimumVoltage,
                        aivcObj.MaximumVoltage,
                        AIVoltageUnits.Volts);
                }
               
                if (bSingleShot == true)
                {
                    // setup the timing, last value is the number of samples to use in the buffer
                    taskObj.Timing.ConfigureSampleClock("", Convert.ToDouble(rateNumeric.Value),
                        SampleClockActiveEdge.Rising, SampleQuantityMode.FiniteSamples, 2 * Convert.ToInt32(Math.Pow(2, Convert.ToDouble(samplesPerChannelNumeric.Value))));
                }
                else
                {
                    // setup the timing, last value is the number of samples to use in the buffer
                    taskObj.Timing.ConfigureSampleClock("", Convert.ToDouble(rateNumeric.Value),
                        SampleClockActiveEdge.Rising, SampleQuantityMode.ContinuousSamples, 2 * Convert.ToInt32(Math.Pow(2, Convert.ToDouble(samplesPerChannelNumeric.Value))));

                }

                taskObj.Control(TaskAction.Verify);
            }
            catch (Exception Ex)
            {
                // null out the task object
                if(taskObj != null)
                    taskObj.Dispose();
                // throw the error
                throw (Ex);
            }
        }
        
        private void NI6251_Options_Shown(object sender, EventArgs e)
        {
            // when the options dialog is shown back up the options in case of cancel
            backupSelectedChannelIndex = physicalChannelComboBox.SelectedIndex;
            backupMinValue = minimumValueNumeric.Value;
            backupMaxValue = maximumValueNumeric.Value;
            backupSamplesChannel = samplesPerChannelNumeric.Value;
            backupRate = rateNumeric.Value;
            backupTerminalMode = (AITerminalConfiguration) terminalModeComboBox.SelectedItem;

            samplesPerChannelLabel.Text = Math.Pow(2.0, Convert.ToDouble(samplesPerChannelNumeric.Value)).ToString("0");

       
        }

        private void cancel_button_Click(object sender, EventArgs e)
        {
            physicalChannelComboBox.SelectedIndex = backupSelectedChannelIndex;
            terminalModeComboBox.SelectedItem = backupTerminalMode;
            minimumValueNumeric.Value = backupMinValue;
            maximumValueNumeric.Value = backupMaxValue;
            samplesPerChannelNumeric.Value = backupSamplesChannel;
            rateNumeric.Value = backupRate;            
        }

        private void ok_button_Click(object sender, EventArgs e)
        {
            SetupDevice();
        }

        // get the task
        public Task TaskObj
        {
            get
            {
                return (taskObj);
            }
        }

        public int SamplesPerChannel
        {
            get
            {
                return  Convert.ToInt32(Math.Pow(2,(Convert.ToDouble(samplesPerChannelNumeric.Value))));
            }
        }

        public int Rate
        {
            get
            {
                return (Convert.ToInt32(rateNumeric.Value));
            }

            set
            {
                rateNumeric.Value = Convert.ToDecimal(value);
                SetupDevice();
            }
        }

        public bool SingleShot
        {
            set
            {
                bSingleShot = value;
                SetupDevice();
            }
            get
            {
                return (bSingleShot);
            }
        }

        public AIVoltageChannel [] AIChannels
        {
            get
            {
                AIVoltageChannel[] channels = new AIVoltageChannel[channelsListBox.Items.Count];

                // copy out the channesl list and return
                for (int i = 0; i < channelsListBox.Items.Count; i++)
                {
                    channels[i] = (AIVoltageChannel) channelsListBox.Items[i];
                }

                return (channels);
            }
        }

        private void samplesPerChannelNumeric_ValueChanged(object sender, EventArgs e)
        {
            samplesPerChannelLabel.Text = Math.Pow(2.0, Convert.ToDouble(samplesPerChannelNumeric.Value)).ToString("0");            
        }

        private void UpdateChnanelsListBox()
        {
            channelsListBox.Items.Clear();

            foreach (AIChannel aiChannelObj in taskObj.AIChannels)
            {
                channelsListBox.Items.Add(aiChannelObj);
            }
        }

        private void AddCurrentChannel()
        {
            // setup the channel
            AIVoltageChannel aiVoltageChannelObj = new AIVoltageChannel(physicalChannelComboBox.Text,
                "",
                (AITerminalConfiguration)terminalModeComboBox.SelectedItem,
                Convert.ToDouble(minimumValueNumeric.Value),
                Convert.ToDouble(maximumValueNumeric.Value));

            // if this ai channel exists get it's index
            int index = channelsListBox.Items.IndexOf(aiVoltageChannelObj);
            // -1 index means it doesn't exists
            if (index == -1)
            {
                // put the new channel in the channels list
                channelsListBox.Items.Add(aiVoltageChannelObj);
            }
            else
            {
                channelsListBox.Items[index] = aiVoltageChannelObj; // update the channel
            }
        }

        private void addChannelButton_Click(object sender, EventArgs e)
        {
            AddCurrentChannel();
        }

        private void removeButton_Click(object sender, EventArgs e)
        {
            channelsListBox.Items.Remove(channelsListBox.SelectedItem);
        }
    }
}