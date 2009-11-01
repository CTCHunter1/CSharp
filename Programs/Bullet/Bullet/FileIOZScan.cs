using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Lab.Programs.Bullet
{
    public partial class FileIO
    {
        public static void WriteZScanCSVFile(StreamWriter streamWritterObj,
            ZDataSeries []zDataSeriesArr)
        {
            streamWritterObj.NewLine = "\r\n";

            WriteZScanHeader(streamWritterObj, zDataSeriesArr);
            WriteZScanWaistData(streamWritterObj, zDataSeriesArr);
            WriteZScanChannelData(streamWritterObj, zDataSeriesArr);
        }


        private static void WriteZScanHeader(StreamWriter streamWritterObj,
            ZDataSeries[] zDataSeriesArr)
        {
            streamWritterObj.WriteLine("Timestamp:," + DateTime.Now);
            streamWritterObj.WriteLine("Title:," + "Bullet Single Shot File");
            streamWritterObj.WriteLine("Number of Channels:," + zDataSeriesArr.Length.ToString());
            streamWritterObj.WriteLine("Number of Z Points:," + zDataSeriesArr[0].ZPositions.Length);
            streamWritterObj.WriteLine("");

            WriteZScanHeaderLine(streamWritterObj, "Physical Channel Name:", GetPhysicalChannelArray(zDataSeriesArr));           
            WriteZDataHeader(streamWritterObj, zDataSeriesArr);
        }

        private static void WriteZScanWaistData(StreamWriter streamWriterObj,
            ZDataSeries[] zDataSeriesArr)
        {
            // assume all data series are the same length
            int dataLength = zDataSeriesArr[0].ZPositions.Length;
            
            // loop through each z data point
            for (int i = 0; i < dataLength; i++)
            {
                // write the z position
                streamWriterObj.Write(zDataSeriesArr[0].ZPositions[i].ToString() + ",");
                // loop through each channel
                for(int j = 0; j < zDataSeriesArr.Length; j++)
                {                    
                    // write the waist
                    streamWriterObj.Write(zDataSeriesArr[j].Waists[i].ToString() + ",");
                    // write the centroid displacement
                    streamWriterObj.Write(zDataSeriesArr[j].CentroidDisplacements[i].ToString() + ","); 
                }

                // start the next line
                streamWriterObj.Write("\r\n");
            }
        }

        private static void WriteZScanChannelData(StreamWriter streamWritterObj, 
            ZDataSeries[] zDataSeriesArr)
        {
            // for each channel write the daq data
            for (int i = 0; i < zDataSeriesArr.Length; i++)
            {
                WriteSingleScanHeader(streamWritterObj, zDataSeriesArr[i].DataSeries);
                WriteSingleScanData(streamWritterObj, zDataSeriesArr[i].DataSeries);
            }
        }

        private static string[] GetPhysicalChannelArray(ZDataSeries[] zDataSeriesArr)
        {
            string[] returnArr = new string[zDataSeriesArr.Length];

            for (int i = 0; i < zDataSeriesArr.Length; i++)
            {
                // assume at least 1 dataseries
                returnArr[i] = zDataSeriesArr[i].DataSeries[0].AIVoltageChannel.PhysicalChannelName;
            }

            return (returnArr);
        }

        // The next three functions write header lines into the file
        private static void WriteZScanHeaderLine(StreamWriter streamWriterObj,
            string headerTitle,
            string[] valuesArray)
        {
            streamWriterObj.Write(","); // Shift Past the positons

            // write a header entry for each of the values in value array
            for (int i = 0; i < valuesArray.Length; i++)
            {
                streamWriterObj.Write(headerTitle + "," + valuesArray[i] + ",");
            }

            streamWriterObj.Write("\r\n");
        }

        private static void WriteZDataHeader(StreamWriter streamWriterObj, 
            ZDataSeries[] zDataSeriesArr)
        {
            streamWriterObj.Write("Z Position (mm),");

            for (int i = 0; i < zDataSeriesArr.Length; i++)
            {
                streamWriterObj.Write("Waist (um), Centroid Position (mm),");
            }

            streamWriterObj.Write("\r\n");
        }
    }
}
