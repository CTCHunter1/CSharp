using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace Beluga
{
    // could also call class Exposure
    public class DataSeries
    {
        ushort[,] ccdData;
        double[] positions; // want to reuse data location but can't because of number of exposures
        double exposureTime_ms;

        public DataSeries(ushort[,] ccdData, double[] positions, double exposureTime_ms)
        {
            this.ccdData = ccdData;
            this.positions = positions;
            this.exposureTime_ms = exposureTime_ms;
        }

        public ushort[,] CCDData
        {
            get
            {
                return (ccdData);
            }
        }

        public double[] Positions
        {
            get
            {
                return (positions);
            }
        }

        public double ExposureTime_ms
        {
            get
            {
                return (exposureTime_ms);
            }
        }

        public int XLength
        {
            get
            {
                return(ccdData.GetLength(0));
            }
        }

        public int YLength
        {
            get
            {
                return (ccdData.GetLength(1));
            }
        }

        public void Save(String fileName)
        {
            StreamWriter swObj = new StreamWriter(fileName);
            int xLen = XLength;
            int yLen = YLength;

            // we want each column to respresnt a channel of the ushort array
            for (int i = 0; i < xLen; i++)
            {
                // first column should be pixel number
                swObj.Write("{0}\t", i + 1);

                // write each point in the array
                for (int j = 0; j < yLen; j++)
                {
                    swObj.Write("{0}\t", ccdData[i, j]);
                }

                swObj.Write("\r\n"); // new line    
            }

            swObj.Close();
        }
    }
}
