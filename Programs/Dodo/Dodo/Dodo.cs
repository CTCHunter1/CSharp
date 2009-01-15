using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Text;
using System.Windows.Forms;
using OpenLayers.Base;
using MathNet;
using MathNet.Numerics;
using MathNet.Numerics.Transformations;

namespace Dodo
{
    public partial class Dodo : Form
    {
        delegate void UpdateGraphDelegate(string data_str, double[] x_data, double[] y_data, Color c);

        UpdateGraphDelegate updateGraphDelegate_obj;
        
        AnalogInputSubsystem ais_obj = null;
        AnalogOutputSubsystem aos_obj = null;
        
        double Ts = 1;          // the sampling speed in seconds
        int i_dac_counts = 0;
        StreamWriter sw_obj = null;
        int i_entry = 0;
        int i_max_counts = 0;

        public Dodo()
        {
            InitializeComponent();
            updateGraphDelegate_obj = new UpdateGraphDelegate(UpdateGraph);

            graphControl_time.AutoScale = false;
            graphControl_time.YLim = new float[] { 0, 5 };

            // initalize the Analog Input and Output Sub-systems
            DeviceMgr devmgr_obj = DeviceMgr.Get();
            string[] dev_names = devmgr_obj.GetDeviceNames();
            Device dev_obj = devmgr_obj.GetDevice(dev_names[0]);

            aos_obj = dev_obj.AnalogOutputSubsystem(0);
            aos_obj.DataFlow = DataFlow.SingleValue;
            aos_obj.Config();

            i_max_counts = aos_obj.VoltsToRawValue(5.0, 1);

            ais_obj = dev_obj.AnalogInputSubsystem(0);
            ais_obj.DataFlow = DataFlow.Continuous;
            ais_obj.ChannelList.Clear();
            ais_obj.ChannelList.Add(0);
            ais_obj.ChannelList.Add(1);
            ais_obj.ChannelList[0].Gain = 2;
            ais_obj.ChannelList[1].Gain = 2;

            // set the timebase
            ais_obj.Clock.Frequency = ais_obj.Clock.MaxFrequency;
            Ts = 1 / ais_obj.Clock.Frequency;


            ais_obj.Config();

            OlBuffer ol_buf1 = new OlBuffer(32768, ais_obj);
            OlBuffer ol_buf2 = new OlBuffer(32768, ais_obj);

            ais_obj.BufferQueue.QueueBuffer(ol_buf1);
            ais_obj.BufferQueue.QueueBuffer(ol_buf2);

            ais_obj.BufferDoneEvent += new BufferDoneHandler(MyBufferDone);
        }

        private void aquire_btn_Click(object sender, EventArgs e)
        {
            SaveFileDialog fd_obj = new SaveFileDialog();
            fd_obj.ShowDialog();

            sw_obj = new StreamWriter(fd_obj.OpenFile());

            aos_obj.SetSingleValueAsRaw(0, i_dac_counts);                    
            ais_obj.Start();                    
        }

        private void UpdateGraph(string str, double[] x_data, double[] y_data, Color c)
        {
            graphControl_time.Plot(str, x_data, y_data, c);
        }

        public void MyBufferDone(object sender, BufferDoneEventArgs eventArgs)
        {
            if (i_entry == 0)
            {
                double[] d_ch1_volt = eventArgs.OlBuffer.GetDataAsVolts(ais_obj.ChannelList[0]);
                double[] d_ch2_volt = eventArgs.OlBuffer.GetDataAsVolts(ais_obj.ChannelList[1]);

                double[] d_x = new double[d_ch1_volt.Length];
                Complex[] c_arr = new Complex[d_ch1_volt.Length];


                // compute the time base
                for (int i = 0; i < d_ch1_volt.Length; i++)
                {
                    d_x[i] = (double)i * Ts;
                }

                graphControl_time.XLim = new float[] { (float)d_x[0], (float)d_x[d_x.Length - 1] };


                // create the array to FFT
                for (int i = 0; i < d_ch1_volt.Length; i++)
                {
                    c_arr[i].Real = d_ch1_volt[i];
                }



                ComplexFourierTransformation cf = new ComplexFourierTransformation();
                //cf.TransformForward(c_arr);

                // unpack the fft
                for (int i = 0; i < d_ch1_volt.Length; i++)
                {
                    d_ch1_volt[i] = c_arr[i].Modulus;
                }

                this.BeginInvoke(updateGraphDelegate_obj, new object[] { "data1", d_x, d_ch1_volt, Color.Red });
                this.BeginInvoke(updateGraphDelegate_obj, new object[] { "data2", d_x, d_ch2_volt, Color.Blue });


                if (i_dac_counts < i_max_counts)
                {
                    sw_obj.WriteLine("{0:e}\t{1:e}\t{2:e}\n",
                                     aos_obj.RawValueToVolts(i_dac_counts, 1),
                                     Mean(d_ch1_volt),
                                     Mean(d_ch2_volt));

                    i_dac_counts += 1;


                    aos_obj.SetSingleValueAsRaw(0, i_dac_counts);
                    i_entry = 1;

                }
                else
                {
                    sw_obj.Close();
                }
            }
            else
            {
                // this causes drops the data after the dac incrments
                i_entry = 0;
            }


            // requeue the buffer
            ais_obj.BufferQueue.QueueBuffer(eventArgs.OlBuffer);
        }

        double Mean(double [] d_arr)
        {
            double d_sum = 0;

            for (int i = 0; i < d_arr.Length; i++)
            {
                d_sum += d_arr[i];
            }

            return (d_sum / d_arr.Length);
        }
    }
}