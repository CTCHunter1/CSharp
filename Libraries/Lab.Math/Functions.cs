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

        public static double[] Diff(double[] x)
        {
            if (x.Length < 2)
                return (null);

            double[] diff_out = new double[x.Length - 1];

            for (int i = 0; i < diff_out.Length; i++)
            {
                diff_out[i] = x[i + 1] - x[i];
            }

            return (diff_out);
        }

        public static double[] SubArray(double[] minuend, double[] subtrahend)
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

        public static double[] ConstAddArray(double a, double[] b)
        {
            if (b == null)
                return (null);

            double[] sum = new double[b.Length];

            for (int i = 0; i < b.Length; i++)
            {
                sum[i] = a + b[i];
            }

            return (sum);
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

        public static double[] MultArray(double[] a, double[] b)
        {
            double[] prod;

            if (a.Length < b.Length)
            {
                prod = new double[a.Length];
                for (int i = 0; i < a.Length; i++)
                {
                    prod[i] = a[i] * b[i];
                }
            }
            else
            {
                prod = new double[b.Length];
                
                for (int i = 0; i < b.Length; i++)
                {
                    prod[i] = a[i] * b[i];
                }
            }

            return (prod);
        }

        public static double[] PowArray(double[] a, double power)
        {
            double[] b = new double[a.Length];

            for (int i = 0; i < a.Length; i++)
            {
                b[i] = System.Math.Pow(a[i], power);
            }

            return (b);
        }

        public static double[] AbsArray(double [] a)
        {
            double[] b = new double[a.Length];

            for (int i = 0; i < a.Length; i++)
            {
                b[i] = System.Math.Abs(a[i]);
            }

            return (b);
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

        public static double SumArray(double[] arr)
        {
            double sum = 0;

            for (int i = 0; i < arr.Length; i++)
            {
                sum += arr[i];
            }

            return (sum);
        }
    }
}
