using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Lab.Drivers.MultiOOIDLL_Wrapper;
using MathNet;
using MathNet.Numerics;
using MathNet.Numerics.Transformations;

namespace Lab.Drivers.MultiOOI_DLL.Test
{
    static class Program
    {
        static public bool m_thread_exit = false;
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainForm());
        }


        static public void Aquire(object parameters)
        {
            Object [] obj_arr = (Object []) parameters;
            ContainerControl sender = (ContainerControl) obj_arr[0];
            Delegate UIupdateDelegate = (Delegate) obj_arr[1];
            Delegate UIUpdateTimeDelegate = (Delegate)obj_arr[2];
            const double c_speed_of_light = 3E8 * (1 / 1E15); // units of m/fs
            

            int []pixels = new int[10];

            m_thread_exit = false;

            // expect hardware to already be initalized         
            string str = "SomeText";             
            // get the connected spectrometer and the number of pixels
            MultiOOIDLL.Hardware_GetCapsEx(str, str.Length, pixels, pixels.Length);

            List<double[]> XAxis = new List<double[]>();
            List<double[]> XAxisWavelength = new List<double[]>();
            List<double[]> Spectrum = new List<double[]>();
            Complex[] c_arr = new Complex[4096];

            int j = 0;
            // create jagged array based on the # of pixels
            while (pixels[j] != 0)
            {                
                XAxis.Add(new double[pixels[j]]);
                Spectrum.Add(new double[pixels[j]]);
                XAxisWavelength.Add(new double[pixels[j]]);
                j++;
            }

            int i;

            while(!m_thread_exit)
            {
                MultiOOIDLL.Hardware_GetAxisEx(XAxis, pixels, XAxis.Count);
                
                // change X axis to wavelength
                for(int k = 0; k < XAxis.Count; k++)
                {
                    for (i = 0; i < XAxisWavelength[k].Length; i++)
                    {
                        XAxisWavelength[k][i] =  1E9*c_speed_of_light * 2 * Math.PI / (XAxis[k][i]);
                    }
                }

                MultiOOIDLL.Hardware_GetSpectrumEx(Spectrum, pixels, XAxis.Count);

      
                // copy data into complex structure
                for (i = 0; i < pixels[0]; i++)
                {
                    c_arr[i].Real = Spectrum[0][i];
                }

                ComplexFourierTransformation cf = new ComplexFourierTransformation();
                cf.TransformForward(c_arr);
                double[] d_trans = new double[c_arr.Length];
                double[] d_axis = cf.GenerateTimeScale(XAxis[0][0] * Math.Pow(10, 15) / (2 * Math.PI) - XAxis[0][1] * Math.Pow(10, 15) / (2 * Math.PI), c_arr.Length);

                for (i = 0; i < c_arr.Length; i++)
                {
                    d_trans[i] = c_arr[i].Modulus;
                }

                if (sender.IsHandleCreated == true)
                {

                    sender.BeginInvoke(UIupdateDelegate,
                        new object[] { XAxisWavelength[0], Spectrum[0] });

                    sender.BeginInvoke(UIUpdateTimeDelegate,
                        new object[] { d_axis, d_trans });
                }
            }
                        
            MultiOOIDLL.Hardware_Exit();     
        } 
    }
}