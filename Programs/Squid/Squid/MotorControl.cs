using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using NationalInstruments.DAQmx;

namespace Squid
{
    public partial class MotorControl : Form
    {
        public MotorControl()
        {
            InitializeComponent();

            physicalChannelComboBox.Items.AddRange(DaqSystem.Local.GetPhysicalChannels(PhysicalChannelTypes.AO, PhysicalChannelAccess.External));
            if (physicalChannelComboBox.Items.Count > 0)
                physicalChannelComboBox.SelectedIndex = 0;
        }

        private void startButton_Click(object sender, EventArgs e)
        {
            try
            {
                using (Task taskObj = new Task())
                {
                    taskObj.AOChannels.CreateVoltageChannel(physicalChannelComboBox.Text, "aoChannel",
                        0, 10,
                        AOVoltageUnits.Volts);
                    AnalogSingleChannelWriter writer = new AnalogSingleChannelWriter(taskObj.Stream);
                    writer.WriteSingleSample(true, Convert.ToDouble(voltageOutput.Text)); 
                }

                using (Task digitalWriteTask = new Task())
                {
                    digitalWriteTask.DOChannels.CreateChannel(DaqSystem.Local.GetPhysicalChannels(PhysicalChannelTypes.DOPort, PhysicalChannelAccess.External)[0], "",
                        ChannelLineGrouping.OneChannelForAllLines);
                    bool[] dataArray = new bool[8];
                    dataArray[0] = reverseCheckBox.Checked;
                    dataArray[1] = reverseCheckBox.Checked;
                    dataArray[2] = reverseCheckBox.Checked;
                    dataArray[3] = reverseCheckBox.Checked;
                    dataArray[4] = reverseCheckBox.Checked;
                    dataArray[5] = reverseCheckBox.Checked;
                    dataArray[6] = reverseCheckBox.Checked;
                    dataArray[7] = reverseCheckBox.Checked;
                    DigitalSingleChannelWriter writer = new DigitalSingleChannelWriter(digitalWriteTask.Stream);
                    writer.WriteSingleSampleMultiLine(true, dataArray);
                }
            }

            catch (DaqException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void stopButton_Click(object sender, EventArgs e)
        {
            Stop();
        }

        public void Stop()
        {
            try
            {
                using (Task taskObj = new Task())
                {
                    taskObj.AOChannels.CreateVoltageChannel(physicalChannelComboBox.Text, "aoChannel",
                        0, 10, AOVoltageUnits.Volts);
                    AnalogSingleChannelWriter writer = new AnalogSingleChannelWriter(taskObj.Stream);
                    writer.WriteSingleSample(true, 0);                    
                }
            }

            catch (DaqException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void close_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void reverseCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            Stop();
        }
    }
}