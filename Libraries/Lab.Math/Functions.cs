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

        public static double[] ConstMultArray(double a, double[] b)
        {
            if (b == null)
                return (null);

            double[] prod = new double[b.Length];

            for (int i = 0; i < b.Length; i++)
            {
                prod[i] = a * b[i];
            }

            return (prod);
        }

        // a min call without the index parameter
        public static double Min(double[] arr)
        {
            int index;

            return (Min(arr, out index));
        }

        public static double Min(double[] arr, out int index)
        {
            index = 0;

            // some simple error checking
            if (arr == null)
                return 0;

            if (arr.Length == 0)
                return 0;

            double min = arr[0];
          
            for (int i = 0; i < arr.Length; i++)
            {
                if (arr[i] < min)
                {
                    min = arr[i];
                    index = i;
                }
            }

            return (min);
        }

        // a max call witout the index paramter
        public static double Max(double []arr)
        {
            int index;

            return (Max(arr, out index));
        }

        public static double Max(double[] arr, out int index)
        {
            index = 0;

            // some simple error checking
            if (arr == null)
                return 0;

            if (arr.Length == 0)
                return 0;

            double max = arr[0];

            for (int i = 0; i < arr.Length; i++)
            {
                if (arr[i] > max)
                {
                    max = arr[i];
                    index = i;
                }
            }

            return (max);
        }

        public static double Mean(double[] arr)
        {
            if (arr == null)
                return (0);

            double dSum = 0;

            for (int i = 0; i < arr.Length; i++)
            {
                dSum += arr[i];
            }

            return (dSum / arr.Length);
        }
    }
}
