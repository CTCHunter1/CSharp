using System;
using System.Collections.Generic;
using System.Text;

namespace Lab.Programs.Bullet
{
    public class ZDataSeries
    {
        List <DataSeries> dataSeriesArr = new List<DataSeries>(); 

        public ZDataSeries()
        {

        }

        public void Clear()
        {
            dataSeriesArr.Clear();
        }

        public void Add(DataSeries dataSeries)
        {
            dataSeriesArr.Add(dataSeries);
        }

        public double[] ZPositions
        {
            get
            {
                double []zPositions = new double[dataSeriesArr.Count];

                for (int i = 0; i < zPositions.Length; i++)
                {
                    zPositions[i] = dataSeriesArr[i].ZPosition;
                }

                return (zPositions);
            }
        }

        public double[] Waists
        {
            get
            {
                double[] waists = new double[dataSeriesArr.Count];

                for (int i = 0; i < waists.Length; i++)
                {
                    waists[i] = dataSeriesArr[i].Waist;
                }

                return (waists);
            }
        }

        public double[] CentroidDisplacements
        {
            get
            {
                double[] displacements = new double[dataSeriesArr.Count];

                for (int i = 0; i < displacements.Length; i++)
                {
                    displacements[i] = dataSeriesArr[i].CentroidDisplacement;
                }

                return (displacements);
            }
        }

        public double[] FirstMoments
        {
            get
            {
                double[] firstMoments = new double[dataSeriesArr.Count];

                for (int i = 0; i < firstMoments.Length; i++)
                {
                    firstMoments[i] = dataSeriesArr[i].FirstMoment;
                }

                return (firstMoments);
            }
        }

        public double[] SecondMoments
        {
            get
            {
                double[] secondMoments = new double[dataSeriesArr.Count];

                for (int i = 0; i < secondMoments.Length; i++)
                {
                    secondMoments[i] = dataSeriesArr[i].SecondMoment;
                }

                return (secondMoments);
            }
        }

            public DataSeries[] DataSeries
        {
            get
            {
                return (dataSeriesArr.ToArray());
            }
        }
    }
}
