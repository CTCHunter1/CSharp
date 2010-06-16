using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using Lab.Drivers.DAQ;
using NationalInstruments.DAQmx;


namespace Squid
{
    public partial class FeedbackController : Form
    {
        NI6251ControlForm daqFormObj;
        Thread threadObj;
        Task taskObj = null;
        

        bool run = false;
        bool isRunning = false;

        public FeedbackController(NI6251ControlForm daqFormObj)
        {
            InitializeComponent();

            this.daqFormObj = daqFormObj;
            physicalChannelComboBox.Items.AddRange(DaqSystem.Local.GetPhysicalChannels(PhysicalChannelTypes.AO, PhysicalChannelAccess.External));
            if (physicalChannelComboBox.Items.Count > 0)
                physicalChannelComboBox.SelectedIndex = 1;
        }

        public void StartAsyc(ContainerControl sender)
        {
            // if is running just return
            if (isRunning == true)
            {
                return;
            }

            threadObj = new Thread(new ParameterizedThreadStart(ParameterizedThreadStart));
            // contiousScanThreadObj.Priority = ThreadPriority.BelowNormal;
            run = true;
            isRunning = true;
            threadObj.Start((object)new object[] { sender });
        }

        private void ParameterizedThreadStart(object parameters)
        {
            // this function is ment to be called in the newly created thread
            // mabye microsoft will fix the parameterized thread start

            Object[] objArr = (Object[])parameters;
            // pull out the parameters
            ContainerControl sender = (ContainerControl)objArr[0];

            StartControl(sender);
        }

        public void StartControl(ContainerControl sender)
        {
            isRunning = true;
            

            try
            {
                if (taskObj != null)
                {
                    taskObj.WaitUntilDone();
                    taskObj.Dispose();
                }

                taskObj = new Task("Chrip Task");

                // setup the channel
                taskObj.AOChannels.CreateVoltageChannel(physicalChannelComboBox.Text,
                    "",
                    -10,
                    10,
                    AOVoltageUnits.Volts);

                taskObj.Control(TaskAction.Verify);

                AnalogSingleChannelWriter writer = new AnalogSingleChannelWriter(taskObj.Stream);

                daqFormObj.SingleShot = false;
                daqFormObj.SamplesPerChannel = 2;

                taskObj.Start();
                AnalogSingleChannelReader reader = new AnalogSingleChannelReader(daqFormObj.TaskObj.Stream);
                double sample = 0;

                do
                {
                    sample = reader.ReadSingleSample();
                    writer.WriteSingleSample(false, sample);
                } while (run == true);


                taskObj.Stop();
                daqFormObj.TaskObj.Stop();

                isRunning = false;
            }
            catch (DaqException ex)
            {
                MessageBox.Show(ex.Message);
                daqFormObj.TaskObj.Stop();
            }

            taskObj.Dispose();
            taskObj = null;

            isRunning = false;
            run = false;
        }

        public void Stop()
        {
            if (isRunning = true)
            {
                run = false;
                threadObj.Join();
                isRunning = false;
            }
            
        }
    }
}