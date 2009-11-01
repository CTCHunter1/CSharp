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

        public DataSeries[] DataSeries
        {
            get
            {
                return (dataSeriesArr.ToArray());
            }
        }
    }
}
