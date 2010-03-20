using System;
using System.Collections.Generic;
using System.Text;

namespace Squid
{
    public class Decimator
    {
        int numPoints;              // number of points to collect
        int numPretriggerPts;       // in ticks
        
        bool triggerRising = true;

        public Decimator(int numPoints, int numPretriggerPts)
        {
            this.numPoints = numPoints;
            this.numPretriggerPts = numPretriggerPts;
        }

        public int PretriggerPoints
        {
            set
            {
                numPretriggerPts = value;
            }

            get
            {
                return (numPretriggerPts);
            }
        }


        public int NumPoints
        {
            set
            {
                numPoints = value;
            }
            get 
            {
                return (numPoints);
            }
        }

        public bool TriggerRising
        {
            set
            {
                triggerRising = value;
            }
            get 
            {
                return (triggerRising);
            }
        }

        public double [] Reduce(DataSeries dataSeries, bool [] timingArr)
        {
            // created the reduced array
            double[] reducedArr = new double[numPoints];
            int dataSeriesIndex = 0;
            int reducedArrIndex = 0;

            // find the trigger
            for(;dataSeriesIndex < dataSeries.NumPoints - 1; dataSeriesIndex++)
            {
                if(triggerRising == true)
                {
                    if((timingArr[dataSeriesIndex] == false) && 
                       (timingArr[dataSeriesIndex+1] == true))
                    {
                        // triggered
                        // advance to pretrigger
                        dataSeriesIndex += numPretriggerPts;
                        for (; dataSeriesIndex < dataSeries.NumPoints; dataSeriesIndex++)
                        {
                            reducedArr[reducedArrIndex] = dataSeries.Y_t[dataSeriesIndex];
                            reducedArrIndex++;

                            if (reducedArrIndex > (numPoints -1))
                            {
                                return (reducedArr);
                            }
                        }
                    }
                }
                else
                {
                    if ((timingArr[dataSeriesIndex] == true) &&
                       (timingArr[dataSeriesIndex + 1] == false))
                    {
                        // triggered
                        // advance to pretrigger
                        dataSeriesIndex += numPretriggerPts;
                        for (; dataSeriesIndex < dataSeries.NumPoints; dataSeriesIndex++)
                        {
                            reducedArr[reducedArrIndex] = dataSeries.Y_t[dataSeriesIndex];
                            reducedArrIndex++;
                            
                            if (reducedArrIndex > (numPoints - 1))
                            {
                                return (reducedArr);
                            }
                        }                        
                    }
                }   
            }

            return (reducedArr);
        }
    }
}
