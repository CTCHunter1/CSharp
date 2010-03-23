using System;
using System.Collections.Generic;
using System.Text;
using Lab.FileIO;

using NationalInstruments;
using NationalInstruments.DAQmx;

namespace Squid
{
    // used to store dataSeries that are coming out of the aquisition controller
    public class ZDataPoint
    {
        DataSeries[] dataSeriesArr;
        double z0 = 0;
        PrecisionDateTime timeStamp; 

        public ZDataPoint(DataSeries[] dataSeriesArr)
        {
            this.dataSeriesArr = dataSeriesArr;
        }

        public ZDataPoint(DataSeries[] dataSeriesArr, PrecisionDateTime timeStamp)
        {
            this.dataSeriesArr = dataSeriesArr;
            this.timeStamp = timeStamp;
        }

        public ZDataPoint(DataSeries[] dataSeriesArr, double zPosition)
        {
            this.dataSeriesArr = dataSeriesArr;
            this.z0 = zPosition;
        }

        public DataSeries[] DataSeriesArr
        {
            get
            {
                return (dataSeriesArr);
            }
        }

        public double Z0
        {
            get 
            {
                return (z0);
            }
            set
            {
                z0 = value;
            }
        }

        public PrecisionDateTime TimeStamp
        {
            get
            {
                return (timeStamp);
            }
        }

        public void Save(string fileName)
        {
            MATLABIO matlabIOObj = new MATLABIO(fileName);

            for (int i = 0; i < dataSeriesArr.Length; i++)
            {
                // write the data
                matlabIOObj.Write1DReal("t_" + i, dataSeriesArr[i].TimeArr);
                matlabIOObj.Write1DReal("Yt_" + i, dataSeriesArr[i].Y_t);
                matlabIOObj.Write1DReal("f_" + i, dataSeriesArr[i].FrequencyArr);
                matlabIOObj.Write1DReal("Yf_" + i, dataSeriesArr[i].YAbs_f);                
            }

            matlabIOObj.WriteString("TimeStamp", timeStamp.ToString());

            matlabIOObj.WriteClose();
        }
    }
}
