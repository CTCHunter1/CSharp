using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Lab.Programs.Bullet
{
    public partial class FileIO
    {
        public static void WriteSingleScanCSVFile(StreamWriter streamWritterObj,
            DataSeries[] singleScanArr)
        {
            streamWritterObj.NewLine = "\r\n";

            streamWritterObj.WriteLine("Timestamp:," + DateTime.Now);
            streamWritterObj.WriteLine("Title:," + "Bullet Single Shot File");
            streamWritterObj.WriteLine("Number of Channels:," + singleScanArr.Length.ToString());
            streamWritterObj.WriteLine("");
            WriteSingleScanHeader(streamWritterObj, singleScanArr);
            WriteSingleScanData(streamWritterObj, singleScanArr);
        }

        private static void WriteSingleScanHeader(StreamWriter streamWritterObj,
            DataSeries[] singleScanArr)
        {         
            WriteHeaderLine(streamWritterObj, "Channel: ", GetPhysicalChannelArray(singleScanArr));
            WriteHeaderLine(streamWritterObj, "Number of Points: ", GetNumberofPointsArray(singleScanArr));
            WriteHeaderLine(streamWritterObj, "Velocity (mm/s): ", GetScanVelocityArray(singleScanArr));
            WriteHeaderLine(streamWritterObj, "Z Position (mm):", GetZPositionArray(singleScanArr));
            WriteHeaderLine(streamWritterObj, "Sample Rate (Hz): ", GetSampleRateArray(singleScanArr));
            WriteHeaderLine(streamWritterObj, "Min Voltage: ", GetMinVoltageArray(singleScanArr));
            WriteHeaderLine(streamWritterObj, "Max Voltage: ", GetMaxVoltageArray(singleScanArr));
            WriteHeaderLine(streamWritterObj, "Waist (um): ", GetWaistArray(singleScanArr));
            WriteHeaderLine(streamWritterObj, "Centriod Position (mm): ", GetCentroidPositionArray(singleScanArr));
            WriteHeaderLine(streamWritterObj, "Fit Parameter A: ", GetFitAArray(singleScanArr));
            WriteHeaderLine(streamWritterObj, "Fit Parameter B: ", GetFitBArray(singleScanArr));
            WriteHeaderLine(streamWritterObj, "Fit Parameter C: ", GetFitCArray(singleScanArr));
            WriteHeaderLine(streamWritterObj, "Fit Parameter D: ", GetFitDArray(singleScanArr));
            WriteHeaderLine(streamWritterObj, "Fit Evaluation Count: ", GetFitEvauationCountArray(singleScanArr));
            WriteHeaderLine(streamWritterObj, "Fit Error Value : ", GetFitErrorValueArray(singleScanArr));
            WriteDataHeaderLine(streamWritterObj, singleScanArr);
        }

        // The next few functions extract paramters from the singleScanArray into
        // seprate arrays used to write the file
        private static string[] GetPhysicalChannelArray(DataSeries[] dataSeriesArr)
        {
            string[] returnArr = new string[dataSeriesArr.Length];

            for (int i = 0; i < dataSeriesArr.Length; i++)
            {
                returnArr[i] = dataSeriesArr[i].AIVoltageChannel.PhysicalChannelName;
            }

            return (returnArr);
        }

        private static int[] GetNumberofPointsArray(DataSeries[] dataSeriesArr)
        {
            int[] returnArr = new int[dataSeriesArr.Length];

            for (int i = 0; i < dataSeriesArr.Length; i++)
            {
                returnArr[i] = dataSeriesArr[i].x.Length;
            }

            return (returnArr);
        }

        private static double[] GetScanVelocityArray(DataSeries[] dataSeriesArr)
        {
            double[] returnArr = new double[dataSeriesArr.Length];

            for (int i = 0; i < dataSeriesArr.Length; i++)
            {
                returnArr[i] = dataSeriesArr[i].Velocity;
            }

            return (returnArr);
        }

        private static double[] GetZPositionArray(DataSeries[] dataSeriesArr)
        {
            double[] returnArr = new double[dataSeriesArr.Length];

            for (int i = 0; i < dataSeriesArr.Length; i++)
            {
                returnArr[i] = dataSeriesArr[i].ZPosition;
            }

            return (returnArr);
        }

        private static double[] GetSampleRateArray(DataSeries[] dataSeriesArr)
        {
            double[] returnArr = new double[dataSeriesArr.Length];

            for (int i = 0; i < dataSeriesArr.Length; i++)
            {
                returnArr[i] = dataSeriesArr[i].SampleRate;
            }

            return (returnArr);
        }

        private static double[] GetMinVoltageArray(DataSeries[] dataSeriesArr)
        {
            double[] returnArr = new double[dataSeriesArr.Length];

            for (int i = 0; i < dataSeriesArr.Length; i++)
            {
                returnArr[i] = dataSeriesArr[i].AIVoltageChannel.MinimumVoltage;
            }

            return (returnArr);
        }

        private static double[] GetMaxVoltageArray(DataSeries[] dataSeriesArr)
        {
            double[] returnArr = new double[dataSeriesArr.Length];

            for (int i = 0; i < dataSeriesArr.Length; i++)
            {
                returnArr[i] = dataSeriesArr[i].AIVoltageChannel.MaximumVoltage;
            }

            return (returnArr);
        }

        private static double[] GetWaistArray(DataSeries[] dataSeriesArr)
        {
            double[] returnArr = new double[dataSeriesArr.Length];

            for (int i = 0; i < dataSeriesArr.Length; i++)
            {
                returnArr[i] = dataSeriesArr[i].Waist;
            }

            return (returnArr);
        }

        private static double[] GetCentroidPositionArray(DataSeries[] dataSeriesArr)
        {
            double[] returnArr = new double[dataSeriesArr.Length];

            for (int i = 0; i < dataSeriesArr.Length; i++)
            {
                returnArr[i] = dataSeriesArr[i].CentroidDisplacement;
            }

            return (returnArr);
        }

        private static double[] GetFitAArray(DataSeries[] dataSeriesArr)
        {
            double[] returnArr = new double[dataSeriesArr.Length];

            for (int i = 0; i < dataSeriesArr.Length; i++)
            {
                returnArr[i] = dataSeriesArr[i].ERFFitResult.A;
            }

            return (returnArr);
        }

        private static double[] GetFitBArray(DataSeries[] dataSeriesArr)
        {
            double[] returnArr = new double[dataSeriesArr.Length];

            for (int i = 0; i < dataSeriesArr.Length; i++)
            {
                returnArr[i] = dataSeriesArr[i].ERFFitResult.B;
            }

            return (returnArr);
        }

        private static double[] GetFitCArray(DataSeries[] dataSeriesArr)
        {
            double[] returnArr = new double[dataSeriesArr.Length];

            for (int i = 0; i < dataSeriesArr.Length; i++)
            {
                returnArr[i] = dataSeriesArr[i].ERFFitResult.B;
            }

            return (returnArr);
        }

        private static double[] GetFitDArray(DataSeries[] dataSeriesArr)
        {
            double[] returnArr = new double[dataSeriesArr.Length];

            for (int i = 0; i < dataSeriesArr.Length; i++)
            {
                returnArr[i] = dataSeriesArr[i].ERFFitResult.B;
            }

            return (returnArr);
        }

        private static int[] GetFitEvauationCountArray(DataSeries[] dataSeriesArr)
        {
            int[] returnArr = new int[dataSeriesArr.Length];

            for (int i = 0; i < dataSeriesArr.Length; i++)
            {
                returnArr[i] = dataSeriesArr[i].ERFFitResult.EvaluationCount;
            }

            return (returnArr);
        }

        private static double[] GetFitErrorValueArray(DataSeries[] dataSeriesArr)
        {
            double[] returnArr = new double[dataSeriesArr.Length];

            for (int i = 0; i < dataSeriesArr.Length; i++)
            {
                returnArr[i] = dataSeriesArr[i].ERFFitResult.ErrorValue;
            }

            return (returnArr);
        }

        // The next three functions write header lines into the file
        private static void WriteHeaderLine(StreamWriter streamWriterObj,
            string headerTitle,
            string[] valuesArray)
        {
            // write a header entry for each of the values in value array
            for (int i = 0; i < valuesArray.Length; i++)
            {
                streamWriterObj.Write(headerTitle + "," + valuesArray[i] + ",,");
            }

            streamWriterObj.Write("\r\n");
        }
        
        private static void WriteHeaderLine(StreamWriter streamWriterObj, 
            string headerTitle,
            int[] valuesArray)
        {
            // write a header entry for each of the values in value array
            for (int i = 0; i < valuesArray.Length; i++)
            {
                streamWriterObj.Write(headerTitle + "," + valuesArray[i].ToString() + ",,");
            }

            streamWriterObj.Write("\r\n");
        }

        private static void WriteHeaderLine(StreamWriter streamWriterObj,
            string headerTitle,
            double[] valuesArray)
        {
            // write a header entry for each of the values in value array
            for (int i = 0; i < valuesArray.Length; i++)
            {
                streamWriterObj.Write(headerTitle + "," + valuesArray[i].ToString() + ",,");
            }

            streamWriterObj.Write("\r\n");
        }

        private static void WriteDataHeaderLine(StreamWriter streamWritterObj,
            DataSeries [] dataSeriesArr)
        {
            for (int i = 0; i < dataSeriesArr.Length; i++)
            {
                streamWritterObj.Write("Time,Cutting Position,ATD Value (Volts),");
            }

            streamWritterObj.Write("\r\n");
        }

        private static void WriteSingleScanData(StreamWriter streamWriterObj,
            DataSeries[] dataSeriesArr)
        {
            // assume that all the data series are of the same length
            // reasonable asumption
            int numValues = dataSeriesArr[0].Y.Length;

            for(int j = 0; j < numValues; j++)            
            {
                for (int i = 0; i < dataSeriesArr.Length; i++)
                {
                    // write the time value
                    streamWriterObj.Write(dataSeriesArr[i].t[j].ToString() + ",");
                    // write the position value
                    streamWriterObj.Write(dataSeriesArr[i].x[j].ToString() + ",");
                    // write the voltage value
                    streamWriterObj.Write(dataSeriesArr[i].Y[j].ToString() + ",");
                }   

                // new line
                streamWriterObj.Write("\r\n");
            }            
        }
    }
}
