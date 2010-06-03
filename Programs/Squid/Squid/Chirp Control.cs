using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using NationalInstruments.DAQmx;
using NationalInstruments;

namespace Squid
{
    public partial class ChirpControl : Form
    {
        private Task taskObj;
        private double sampleFreq = 0;

        public ChirpControl()
        {
            InitializeComponent();

            physicalChannelComboBox.Items.AddRange(DaqSystem.Local.GetPhysicalChannels(PhysicalChannelTypes.AO, PhysicalChannelAccess.External));
            if (physicalChannelComboBox.Items.Count > 0)
                physicalChannelComboBox.SelectedIndex = 1;
        }

        public double MaxValue
        {
            get
            {
                if(maxValueNumeric.Value < minValueNumeric.Value)
                    return (Convert.ToDouble(minValueNumeric.Value));
                else
                    return (Convert.ToDouble(maxValueNumeric.Value));
            }
        }

        public double MinValue
        {
            get
            {
                if(minValueNumeric.Value > maxValueNumeric.Value)
                    return(Convert.ToDouble(maxValueNumeric.Value));

                else 
                    return (Convert.ToDouble(minValueNumeric.Value));
            }
        }

        public void StartChirp()
        {
            double maxFrequency = Convert.ToDouble(stopFreqNumeric.Value);
            double minFrequency = Convert.ToDouble(startFreqNumeric.Value);

            if(maxFrequency < minFrequency)
            {
                minFrequency = maxFrequency;
                maxFrequency = Convert.ToDouble(startFreqNumeric.Value);
            }
            
            sampleFreq = maxFrequency*10;

            try
            {
                if (taskObj != null)
                    taskObj.WaitUntilDone();

                taskObj = new Task();

                // setup the channel
                taskObj.AOChannels.CreateVoltageChannel(physicalChannelComboBox.Text,
                    "",
                    Convert.ToDouble(minValueNumeric.Value),
                    Convert.ToDouble(maxValueNumeric.Value),
                    AOVoltageUnits.Volts);

                taskObj.Control(TaskAction.Verify);

                // create the waveform, it's length will be used in the sample timing
                double []waveForm = GenerateWaveformData(Convert.ToDouble(startFreqNumeric.Value),
                    Convert.ToDouble(stopFreqNumeric.Value),
                    Convert.ToDouble(durationNumeric.Value),
                    sampleFreq);

                
                // configure the clock
                taskObj.Timing.ConfigureSampleClock("",
                    sampleFreq,
                    SampleClockActiveEdge.Rising,
                    SampleQuantityMode.ContinuousSamples, waveForm.Length);

                taskObj.Timing.SampleTimingType = SampleTimingType.SampleClock;
                
                AnalogSingleChannelWriter writer =
                    new AnalogSingleChannelWriter(taskObj.Stream);

                writer.WriteMultiSample(false, waveForm);
                
                taskObj.Start();                      
            }
            catch (DaqException ex)
            {
                MessageBox.Show(ex.Message);
                taskObj.Dispose();
            }
        }

        private double[] GenerateWaveformData(double fStart, double fStop, double tDuration, double fSample)
        {
            int numSamples = (int) Math.Ceiling(fSample*tDuration);
            double[] y_t = new double[numSamples];

            double minValue = MinValue;
            double maxValue = MaxValue;
            

            double amplitude = maxValue - minValue;
            double offset =  (minValue + maxValue)/2;
            // chirp parameters f = a*t+b
            double b = fStop;
            double a = (fStop - fStart) / tDuration;
            double t = 0;
            double f = fStart;

            for (int i = 0; i < numSamples; i++)
            {
                t = i*fSample; // the time point
                f = a * t + b; // the frequency
                
                // the cosine wave
                y_t[i] = amplitude*Math.Cos(2*Math.PI*f*t) + offset;
            }
            
            return (y_t);
        }
    }
}