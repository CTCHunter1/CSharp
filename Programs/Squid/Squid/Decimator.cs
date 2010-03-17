using System;
using System.Collections.Generic;
using System.Text;

namespace Squid
{
    class Decimator
    {
        int numPoints;          // number of points to collect
        int numPretriggerPts;       // in ticks
        int pretriggerIndex;        // this counts down
        double[] reducedTrace;
        int reducedTraceIndex = 0;
        bool takingTrace = false;

        bool previousValue = true;

        public Decimator(int numPoints, int numPretriggerPts)
        {
            this.numPoints = numPoints;
            this.numPretriggerPts = numPretriggerPts;
            this.pretriggerIndex = numPretriggerPts;
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


        public void Update(DataSeries dataSeries, bool [] timingArr)
        {           
            int dataSeriesIndex = 0;

            // still copying out form last trace
            if (takingTrace == true)
            {
                // check if there are enough points in the dataseries to trigger
                if((dataSeries.NumPoints - pretriggerIndex) < 0)
                {
                    // not enough points to trigger advance trigger index
                    pretriggerIndex -= dataSeries.NumPoints;
                    return;
                }
                
                // advance to the pretrigger index then start copying                
                for (dataSeriesIndex = pretriggerIndex; 
                    dataSeriesIndex < dataSeries.Y_t.Length; 
                    dataSeriesIndex++)
                {
                    reducedTrace[reducedTraceIndex] = dataSeries.Y_t[dataSeriesIndex];
                    reducedTraceIndex++;

                    if ((reducedTraceIndex % numPoints) == 0)
                    {
                        takingTrace = false;
                        reducedTraceIndex = 0;
                        pretriggerIndex = numPretriggerPts;
                        break;
                    }
                }
            }

            if (dataSeriesIndex == 0)
            {
                // check the first item in the timing dataseries
                if ((previousValue == false) &&
                    timingArr[dataSeriesIndex] == true)
                {
                    takingTrace = true;

                    // check if there are enough points in the dataseries to trigger
                    if ((dataSeries.NumPoints - pretriggerIndex) < 0)
                    {
                        // not enough points to trigger advance trigger index
                        pretriggerIndex -= dataSeries.NumPoints;
                        return;
                    }

                    // advance to the pretrigger index then start copying                
                    for (dataSeriesIndex = pretriggerIndex;
                        dataSeriesIndex < dataSeries.Y_t.Length;
                        dataSeriesIndex++)
                    {
                        reducedTrace[reducedTraceIndex] = dataSeries.Y_t[dataSeriesIndex];
                        reducedTraceIndex++;

                        // reset the reduced trace
                        if ((reducedTraceIndex % numPoints) == 0)
                        {
                            takingTrace = false;
                            reducedTraceIndex = 0;
                            pretriggerIndex = numPretriggerPts;
                            reducedTrace = new double[numPoints];
                            break;
                        }
                    }
                }
                else
                {
                    dataSeriesIndex++;
                }
            } 
            // 
            for (; dataSeriesIndex < dataSeries.NumPoints; dataSeriesIndex++)
            {
                // trigger on rising edge
                if (timingArr[dataSeriesIndex - 1] == false &&
                    timingArr[dataSeriesIndex] == true)
                {
                    takingTrace = true;

                    // check if there are enough points in the dataseries to trigger
                    if ((dataSeries.NumPoints - pretriggerIndex) < 0)
                    {
                        // not enough points to trigger advance trigger index
                        pretriggerIndex -= dataSeries.NumPoints;
                        return;
                    }

                    // advance to the pretrigger index then start copying                
                    for (dataSeriesIndex = pretriggerIndex;
                        dataSeriesIndex < dataSeries.NumPoints;
                        dataSeriesIndex++)
                    {
                        reducedTrace[reducedTraceIndex] = dataSeries.Y_t[dataSeriesIndex];
                        reducedTraceIndex++;

                        if ((reducedTraceIndex % numPoints) == 0)
                        {
                            takingTrace = false;
                            reducedTraceIndex = 0;
                            pretriggerIndex = numPretriggerPts;
                            reducedTrace = new double[numPoints];
                            break;
                        }
                    }
                }
            }

            previousValue = timingArr[dataSeriesIndex];
        }
    }
}
