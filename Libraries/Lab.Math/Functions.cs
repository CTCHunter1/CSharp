using System;
using System.Collections.Generic;
using System.Text;

namespace Lab.Math
{
    public class Functions
    {
        public static double [] AddArray(double []data1, double[]data2)
        {
            if (data1.Length != data2.Length)
                return (null);

            double[] sum = new double[data1.Length];

            for (int i = 0; i < data1.Length; i++)
            {
                sum[i] = data1[i] + data2[i];
            }

            return (sum);
        }

        public static double[] SubArray(double[] minuend, double []subtrahend)
        {
            if (minuend.Length != subtrahend.Length)
                return (null);

            double[] diff = new double[minuend.Length];

            for (int i = 0; i < minuend.Length; i++)
            {
                diff[i] = minuend[i] + subtrahend[i];
            }

            return (diff);
        }
    }
}
