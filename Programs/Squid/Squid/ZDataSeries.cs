using System;
using System.Collections.Generic;
using System.Text;

using Lab.FileIO;

namespace Squid
{
    public class ZDataSeries
    {
        List<ZDataPoint> dataSeriesList = new List<ZDataPoint>(); 

        public ZDataSeries()
        {

        }

        public void Clear()
        {
            dataSeriesList.Clear();
        }

        public void Add(ZDataPoint zDataPoint)
        {
            dataSeriesList.Add(zDataPoint);
        }

        public double[] ZPositions
        {
            get
            {
                double []zPositions = new double[dataSeriesList.Count];

                for (int i = 0; i < zPositions.Length; i++)
                {
                    zPositions[i] = dataSeriesList[i].Z0;
                }

                return (zPositions);
            }
        }

        public ZDataPoint[] ZDataPoints
        {
            get
            {
                return (dataSeriesList.ToArray());
            }
        }

        public void Save(string fileName)
        {
            // some sanity checks
            if (dataSeriesList.Count <= 0)
                return;

            if (dataSeriesList[0].DataSeriesArr == null)
                return;

            if (dataSeriesList[0].DataSeriesArr.Length <= 0)
                return;

            MATLABIO matlabIOObj = new MATLABIO(fileName);

            matlabIOObj.WriteString("TimeStamp", dataSeriesList[0].TimeStamp.ToString());
            matlabIOObj.WriteString("FreqUnits", dataSeriesList[0].DataSeriesArr[0].FrequncyUnits.ToString());

            // write the ZDataSeriesPoints
            matlabIOObj.Write1DReal("Z", ZPositions);
            
            // for each channel in the data series list
            for(int i = 0; i < dataSeriesList[0].DataSeriesArr.Length; i++)
            {
                // write the time and frequency axis
                matlabIOObj.Write1DReal("t" + i.ToString(), dataSeriesList[0].DataSeriesArr[i].TimeArr);
                // write the time and frequency axis
                matlabIOObj.Write1DReal("f" + i.ToString(), dataSeriesList[0].DataSeriesArr[i].FrequencyHalfArr);


                // copy out the zData for the time and frequency variables
                double[,] zData2Dtime = new double[dataSeriesList.Count, dataSeriesList[0].DataSeriesArr[i].Y_t.Length];
                
                // fill in the zdata2Darray
                for (int j = 0; j < dataSeriesList.Count; j++)
                {
                    for (int k = 0; k < dataSeriesList[0].DataSeriesArr[i].Y_t.Length; k++)
                    {
                        zData2Dtime[j,k] = dataSeriesList[j].DataSeriesArr[i].Y_t[k];
                    }
                }
                
                // copy out the zData for the time and frequency variables
                double[,] zData2Dfreq = new double[dataSeriesList.Count, dataSeriesList[0].DataSeriesArr[i].YAbs_fHalf.Length];

                // fill in the zdata2Darray
                for (int j = 0; j < dataSeriesList.Count; j++)
                {
                    double[] yAbsHalf = dataSeriesList[j].DataSeriesArr[i].YAbs_fHalf;
                    for (int k = 0; k < yAbsHalf.Length; k++)
                    {
                        zData2Dfreq[j, k] = yAbsHalf[k];
                    }
                }

                // write the time and frequency arrays
                matlabIOObj.Write2DReal("Y_t" + i.ToString(), zData2Dtime);
                matlabIOObj.Write2DReal("Y_f" + i.ToString(), zData2Dfreq);                  
                            

                matlabIOObj.WriteClose();
            }
        }
    }
}
