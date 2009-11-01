using System;
using System.Collections.Generic;
using System.Text;

using Lab.Drivers.DAQ;
using Lab.Math;

namespace Lab.Programs.Bullet
{
    public class DataSeries
    {
        List <double> Y_t = new List<double>();      // the actual data array 
        List <double> t_arr = new List<double>();    // sample time array
        List <double> x_arr = new List<double>();    // position array

        AIVoltageChannel aiVoltageChannelObj;

        double zPosition;   // position on the z axis at scan
        double T0;      // time between points
        double X0;      // Distance between points
        double velocity;
        double fSample;

        ErfFitResult erfFitResultObj;

        public DataSeries(AIVoltageChannel aiVoltageChannelObj, double zPosition, double sampleRate, double movingVelocity)
        {
            fSample = sampleRate;
            velocity = movingVelocity;

            if (sampleRate >= 0)
                T0 = 1 / sampleRate;
            else 
            {
                fSample = 1;
                T0 = 1;
            }

            if (velocity >= 0)
            {
                X0 = velocity * T0;
            }
            else
            {
                X0 = 0;
            }

            this.aiVoltageChannelObj = aiVoltageChannelObj;
            this.zPosition = zPosition;
        }
        
        public double [] Y
        {
            get
            {
                return (Y_t.ToArray());
            }
            set
            {
                Y_t.Clear();
                t_arr.Clear();
                x_arr.Clear();
                AddRange(value);
            }
        }

        public double[] t
        {
            get
            {
                return (t_arr.ToArray());
            }
        }

        public double[] x
        {
            get
            {
                return (x_arr.ToArray());
            }
        }

        // returns the scanning velocity in (mm/s)
        public double Velocity
        {
            get
            {
                return (velocity);
            }
        }

        // returns the sample rate in (Hz)
        public double SampleRate
        {
            get
            {
                return (fSample);
            }
        }

        // returns the waist in (um)
        public double Waist
        {
            get
            {
                if (erfFitResultObj == null)
                    return (0);

                return (System.Math.Sqrt(2)*erfFitResultObj.B);
            }
        }

        // the position of the centroid in (mm)
        public double CentroidDisplacement
        {
            get
            {
                // make sure this doesn't break
                if (erfFitResultObj == null)
                    return (0);

                return (erfFitResultObj.C);
            }
        }

        public ErfFitResult ERFFitResult
        {
            get
            {
                return (erfFitResultObj);
            }
        }

        public AIVoltageChannel AIVoltageChannel
        {
            get
            {
                return (aiVoltageChannelObj);
            }
        }

        public double ZPosition
        {
            get
            {
                return (zPosition);
            }
        }

        public void AddRange(double [] YAdditional)
        {
            Y_t.AddRange(YAdditional);
            
            double lastTime = 0;
            double lastPosition = 0;

            // current last time value
            if (t_arr.Count != 0)
            {

                lastTime = t_arr[t_arr.Count - 1];
                lastPosition = x_arr[x_arr.Count - 1];
            }

            for (int i = 0; i < YAdditional.Length; i++)
            {
                lastTime += T0;
                t_arr.Add(lastTime);

                lastPosition += X0;
                x_arr.Add(lastPosition);
            }
            
        }

        public void GetFit()
        {
            ErfFit erfFitObj = new ErfFit();
            erfFitResultObj = erfFitObj.Fit(x_arr.ToArray(), Y_t.ToArray());
        }
    }
}
