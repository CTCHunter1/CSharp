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

        ErfFitResult erfFitResultObj;   // the fit result object used to generate the waist and displacement
        double firstMoment;
        double secondMoment;

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

                return (System.Math.Sqrt(2)*erfFitResultObj.B*1000);
            }
        }

        // returns the waists in (um) waist computed from moment
        public double SecondMoment
        {
            get
            {

                return (secondMoment);
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

        // the position of the centroind in (um) computed from the moment
        public double FirstMoment
        {
            get
            {

                return (firstMoment);
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
            double [] y_arr = Y_t.ToArray();
            double [] x_arr = this.x_arr.ToArray();

            // we need to try to guess the offset position the beam width and the amplitude
            int minIndex, maxIndex;
            double minValue = Functions.Min(y_arr, out minIndex);
            double maxValue = Functions.Max(y_arr, out maxIndex);

            // the value where the erf is at it's half max
            double spread = maxValue - minValue;

            int x0Index = FindIndex(spread/2, y_arr);
            double x0 = x_arr[x0Index];     // a guess of where the half way point is

            int b0minIndex = FindIndex(spread * .0786, y_arr);
            int b0maxIndex = FindIndex(spread * .9214, y_arr);

            double b0 = 0; // initial guess of the b paramter

            if (b0minIndex < b0maxIndex)
            {
                b0 = (x_arr[b0maxIndex] - x_arr[b0minIndex]) / 2;
            }
            else if (b0minIndex > b0maxIndex)
            {
                b0 = (x_arr[b0minIndex] - x_arr[b0maxIndex]) / 2;
            }
            else
            {
                b0 = x_arr[1] - x_arr[0];   // make the inital guess the step size
            }

            double d = spread/2;   // +1 because the erf ranges from -1 to 1
            double a = spread / 2;                  // /2 becaus the erf ranges from -1 to 1 

            if (minIndex < maxIndex)
            {
                ErfFit erfFitObj = new ErfFit(1E-9,
                    1000,
                    new double[4] { a, b0, x0, d },
                    new double[4] { a * .05, b0 * .05, x0 * .05, d * .1 });

                erfFitResultObj = erfFitObj.Fit(x_arr, y_arr);
            }
            else
            {
                ErfFit erfFitObj = new ErfFit(1E-9,
                    1000,
                    new double[4] { -a, b0, x0, d },
                    new double[4] { a * .05, b0 * .05, x0 * .05, d * .1 });

                erfFitResultObj = erfFitObj.Fit(x_arr, y_arr);
            }
        }

        public void GetFitMoment()
        {
            double [] y_arr = Y_t.ToArray();
            double [] x_arr = this.x_arr.ToArray();
    
            // create the difference array;
            double [] y_array_diff = Functions.Diff(y_arr);
            double Dx = x_arr[2] - x_arr[1];

            // compute y_array diff = dY_t/dx
            y_array_diff = Functions.ConstMultArray(1 / Dx, y_array_diff);


            firstMoment = Functions.SumArray(Functions.MultArray(x_arr, y_array_diff)); // sum(x*I_t)


            double[] diffx = Functions.ConstAddArray(firstMoment, x_arr);  // (x-x0)
            double[] diffx2 = Functions.PowArray(diffx, 2);  // (x-x0)^2;

            secondMoment = Functions.SumArray(Functions.MultArray(diffx2, y_array_diff)); // sum((x-x0)^2*I_t)
        }

        public int FindIndex(double searchValue, double[] yArr)
        {
            // some simple error checking
            if (yArr == null)
                return 0;

            if (yArr.Length < 2)
                return 0;

            int index = 0;

            // two search routines
            if (yArr[0] < searchValue)
            {
                // the ERF function goes from zero to it's max value
                for (index = 0; index < yArr.Length; index++)
                {
                    if (yArr[index] > searchValue)
                        return (index);
                }
            }
            else
            {
                // the ERF function starts at it's max and goes to zero
                for (index = 0; index < yArr.Length; index++)
                {
                    if (yArr[index] < searchValue)
                        return (index);
                }
            }

            // shouldn't ever get to here
            return (0);
        }
    }
}
