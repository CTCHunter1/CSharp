using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using NationalInstruments;
using NationalInstruments.DAQmx;



using Lab.Drivers.Motors;
using Lab.Drivers.DAQ;
using Lab.Math;

namespace Lab.Programs.Bullet
{
    public partial class MainForm : Form
    {
        bool acquireData;

        private TraceCompletedDelegate singleTraceCompletedDelegateObj;
        // object to place incoming data in
        private DataSeries [] singleScanArr;    // each index in this array coresonds to a different channel
        private ZDataSeries[] zDataSeriesArr; 
        //private List <DataSeries[]> zScanArr;   // each index of this array corespoonds to a different z point

        double startingCuttingPosition;
        double sigleScanStartingCuttingPosition;
        double cuttingAxisLeftPosition;
        double startingZPosition;
        double zScanMinPosition;
        double dZ;
        double pointIndex = 0;

        bool bZScan = false;
        bool bSingleScan = false;

        private void TakeSingleTrace(double centerPosition, TraceCompletedDelegate tcdObj)
        {
            singleTraceCompletedDelegateObj = tcdObj;

            bSingleScan = true;

            if (scanOptionsFormObj.CuttingAxisSampleandHold == true)
            {
                TakeSingleTraceSampleandHold();
            }
            else
            {
                // assume cutting axis is currently at starting position
                TakeSingleTraceMoving(centerPosition);
            }
        }

        private void TakeSingleTraceMoving(double centerPosition)
        {
            // store the currently set velocity
            double cuttingAxisVelocity = scanOptionsFormObj.CuttingAxisMotor.Velocity;
            
            // needed more for a single scan
            sigleScanStartingCuttingPosition = scanOptionsFormObj.CuttingAxisMotor.Position;

            // store the current poistion
            double zPosition = scanOptionsFormObj.ZAxisMotor.Position;
            // need to create a data series object for each channel coming in off the DAQ            

            // create a array to store the read data in
            singleScanArr = CreateDataSeriesArray(NIDAQControlFormObj.AIChannels,
                zPosition,
                NIDAQControlFormObj.Rate,
                cuttingAxisVelocity);

            // get the radius to cut through the beam
            double cuttingAxisRadius = scanOptionsFormObj.CuttingAxisRadius / 1000;   // to put in in (mm)

            NIDAQControlFormObj.TaskObj.Control(TaskAction.Stop);

            // Setup the NI-DAQ for the configured task and start aquisition to the analogCallback
            analogInReader = new AnalogMultiChannelReader(NIDAQControlFormObj.TaskObj.Stream);
            analogCallback = new AsyncCallback(AnalogInCallback);       // function to call when data ready
            motorDoneCallback = new AsyncCallback(CuttingMotorDoneCallback);    // function to call when motor is done moving
                        
            scanOptionsFormObj.CuttingAxisMotor.Velocity = 2.5; // up the motor velocity to get to the starting position            
            
            // this needs to be shoved into a thread
            // first synchronously move backward
            cuttingAxisLeftPosition = centerPosition - cuttingAxisRadius;
            scanOptionsFormObj.CuttingAxisMotor.MoveAbsolute(cuttingAxisLeftPosition);
            scanOptionsFormObj.CuttingAxisMotor.EndMoveAbsolute(null);

            scanOptionsFormObj.CuttingAxisMotor.Velocity = cuttingAxisVelocity;
            // start reading the waveform
            iAsyncResultObj = analogInReader.BeginReadWaveform(NIDAQControlFormObj.SamplesPerChannel, analogCallback, NIDAQControlFormObj.TaskObj);
            NIDAQControlFormObj.TaskObj.Stream.Timeout = -1;


            // now asynchronously move forward
            scanOptionsFormObj.CuttingAxisMotor.BeginMoveAbsolute(cuttingAxisLeftPosition + cuttingAxisRadius*2, motorDoneCallback, this);

            acquireData = true;

        }

        private void TakeSingleTraceSampleandHold()
        {

        }


        private void SingleTraceCompletedCallback(DataSeries[] dataSeriesArr)
        {
            // clear the list view
            waistListView.Items.Clear();

            double yMin = Functions.Min(dataSeriesArr[0].Y);
            double yMax = Functions.Min(dataSeriesArr[0].Y);

            // find max and min for all traces needed for scaling
            for (int i = 0; i < dataSeriesArr.Length; i++)
            {
                double yLoopMin = Functions.Min(dataSeriesArr[i].Y);
                double yLoopMax = Functions.Max(dataSeriesArr[i].Y);

                if (yLoopMin < yMin)
                    yMin = yLoopMin;

                if (yLoopMax > yMax)
                    yMax = yLoopMax;
            }

            // turn autoscaling off on the plot
            cuttingAxisGraph.AutoScale = false;
            cuttingAxisGraph.XLim = new double[] {dataSeriesArr[0].x[0], dataSeriesArr[0].x[dataSeriesArr[0].x.Length-1] };
            cuttingAxisGraph.YLim = new double[] {yMin, yMax };

            // invoke the fit erffit for the data series array
            for (int i = 0; i < dataSeriesArr.Length; i++)
            {
                dataSeriesArr[i].GetFit();
                ListViewAddItem(dataSeriesArr[i].AIVoltageChannel.PhysicalChannelName,
                    dataSeriesArr[i].Waist,
                    dataSeriesArr[i].CentroidDisplacement);
                cuttingAxisGraph.AutoScale = false;
                cuttingAxisGraph.Plot("Fit " + i.ToString(), dataSeriesArr[i].x, dataSeriesArr[i].ERFFitResult.YDataFit, Color.Red);
            }
            // move back to the starting cutting position
            scanOptionsFormObj.CuttingAxisMotor.MoveAbsolute(sigleScanStartingCuttingPosition);
            scanOptionsFormObj.CuttingAxisMotor.EndMoveAbsolute(null);

            bSingleScan = false;
        }

        private void TakeZScan()
        {
            waistListView.Items.Clear();

            // assume there are two axis, otherwise this will cause funky behavior
            
            // create a new zScanArray
            zDataSeriesArr = new ZDataSeries[NIDAQControlFormObj.AIChannels.Length];
            // initalize the array
            for (int i = 0; i < zDataSeriesArr.Length; i++)
            {
                zDataSeriesArr[i] = new ZDataSeries();
            }

            bZScan = true;
            pointIndex = 0;
            
            startingCuttingPosition = scanOptionsFormObj.CuttingAxisMotor.Position;
            startingZPosition = scanOptionsFormObj.ZAxisMotor.Position;
            // find the distance between the z_axis points
            dZ = (scanOptionsFormObj.ZAxisRadius * 2) / (1000*(scanOptionsFormObj.ZAxisNumPoints - 1));

            // move to the begining of the scan
            zScanMinPosition = startingZPosition - scanOptionsFormObj.ZAxisRadius/1000;
            scanOptionsFormObj.ZAxisMotor.MoveAbsolute(zScanMinPosition);
            TakeSingleTrace(startingCuttingPosition, new TraceCompletedDelegate(ZScanTraceCompletedCallback));
        }

        private void ZScanTraceCompletedCallback(DataSeries[] dataSeriesArr)
        {
            // add all the data points to their zSeriesArrays
            for (int i = 0; i < dataSeriesArr.Length; i++)
            {
                zDataSeriesArr[i].Add(dataSeriesArr[i]);
            }

            // Get the fit for each of the data points
            for(int i = 0 ; i < dataSeriesArr.Length; i++)
            {
                dataSeriesArr[i].GetFit();
                // put the fit paramters in the list view
                ListViewAddItem(dataSeriesArr[i].AIVoltageChannel.PhysicalChannelName,
                    dataSeriesArr[i].Waist,
                    dataSeriesArr[i].CentroidDisplacement);
            }

            if (viewTypeObj == ViewType.PlotWaistsAndCentroid || viewTypeObj == ViewType.PlotWaists)
            {
                // loop through and find the minumum and maximum
                double yCenterMin = Functions.Min(zDataSeriesArr[0].CentroidDisplacements);
                double yCenterMax = Functions.Max(zDataSeriesArr[0].CentroidDisplacements);
                double yWaistMin = Functions.Min(zDataSeriesArr[0].Waists);
                double yWaistMax = Functions.Max(zDataSeriesArr[0].Waists);

                for (int i = 0; i < zDataSeriesArr.Length; i++)
                {
                    double yCenterMinLoop = Functions.Min(zDataSeriesArr[i].CentroidDisplacements);
                    double yCenterMaxLoop = Functions.Max(zDataSeriesArr[i].CentroidDisplacements);
                    double yWaistMinLoop = Functions.Min(zDataSeriesArr[i].Waists);
                    double yWaistMaxLoop = Functions.Max(zDataSeriesArr[i].Waists);

                    // if the new values are bigger than the max or less than the min
                    // update the min and max with those values
                    if (yCenterMinLoop < yCenterMin)
                        yCenterMin = yCenterMinLoop;

                    if (yCenterMaxLoop > yCenterMax)
                        yCenterMax = yCenterMaxLoop;

                    if (yWaistMinLoop < yWaistMin)
                        yWaistMin = yWaistMinLoop;

                    if(yWaistMaxLoop > yWaistMax)
                        yWaistMax = yWaistMaxLoop;
                }

                // set the centroid graph limits
                waistsGraph.AutoScale = false;
                waistsGraph.XLim = new double[]{zDataSeriesArr[0].ZPositions[0] ,
                    zDataSeriesArr[0].ZPositions[zDataSeriesArr[0].ZPositions.Length - 1]};
                waistsGraph.YLim = new double[] { yWaistMin, yWaistMax };


                // set the centroid graph limits
                centroidGraph.AutoScale = false;
                centroidGraph.XLim = new double[]{zDataSeriesArr[0].ZPositions[0] ,
                    zDataSeriesArr[0].ZPositions[zDataSeriesArr[0].ZPositions.Length - 1]};
                centroidGraph.YLim = new double[] { yCenterMin, yCenterMax };
            }

            // plot the fits and then plot the waist position
            for (int i = 0; i < dataSeriesArr.Length; i++)
            {
                // plot the fit in red
                cuttingAxisGraph.Plot("Fit " + i.ToString(), dataSeriesArr[i].x, dataSeriesArr[i].ERFFitResult.YDataFit, Color.Red);

                if (viewTypeObj == ViewType.PlotWaists || viewTypeObj == ViewType.PlotWaistsAndCentroid)
                {
                   waistsGraph.Plot("Waist" + i.ToString(), zDataSeriesArr[i].ZPositions,
                     zDataSeriesArr[i].Waists, GetColorByIndex(i));

                   // waistsGraph.Plot("SecondMoment" + i.ToString(), zDataSeriesArr[i].ZPositions,
                   //  zDataSeriesArr[i].SecondMoments, GetColorByIndex(2*i+1));
                    //waistsGraph.AutoScale = false;
                   // waistsGraph.YLim = new double[] { Functions.Min(zDataSeriesArr[i].SecondMoments), Functions.Max(zDataSeriesArr[i].SecondMoments) };
            
                }

                // plot the zDataPoints
                if (viewTypeObj == ViewType.PlotWaistsAndCentroid)
                {
                    centroidGraph.Plot("Centroid" + i.ToString(), zDataSeriesArr[i].ZPositions,
                        zDataSeriesArr[i].CentroidDisplacements, GetColorByIndex(i));
                }
            }

            pointIndex++;
            if (pointIndex < scanOptionsFormObj.ZAxisNumPoints && bZScan == true)
            {                             
                // take the next point
                scanOptionsFormObj.ZAxisMotor.MoveAbsolute(zScanMinPosition + pointIndex * dZ);
                TakeSingleTrace(startingCuttingPosition, new TraceCompletedDelegate(ZScanTraceCompletedCallback));
            }
            else
            {
                // move the zaxis motor back to the starting poisition
                scanOptionsFormObj.ZAxisMotor.MoveAbsolute(startingZPosition);
                // move the cutting axis motor back to the starting position
                scanOptionsFormObj.CuttingAxisMotor.MoveAbsolute(startingCuttingPosition);
                scanOptionsFormObj.CuttingAxisMotor.EndMoveAbsolute(null);

                bZScan = false;
            }            
        }

        private void CuttingMotorDoneCallback(IAsyncResult ar)
        {
            StopAcquire();
            scanOptionsFormObj.CuttingAxisMotor.EndMoveAbsolute(ar);
        }

        private void AnalogInCallback(IAsyncResult ar)
        {
            try
            {
                multiChannelWaveformData = analogInReader.EndReadWaveform(ar);

                // copy out the waveform data
                for (int i = 0; i < multiChannelWaveformData.Length; i++)
                {
                    singleScanArr[i].AddRange(multiChannelWaveformData[i].GetScaledData());
                }
                
                // plot the data 
                for (int i = 0; i < singleScanArr.Length; i++)
                {
                    cuttingAxisGraph.AutoScale = true;
                    cuttingAxisGraph.Plot("Data" + i.ToString(), singleScanArr[i].x, singleScanArr[i].Y, GetColorByIndex(i));
                }
                
                if (acquireData == true)
                {
                    iAsyncResultObj = analogInReader.BeginReadWaveform(NIDAQControlFormObj.SamplesPerChannel, analogCallback, NIDAQControlFormObj.TaskObj);
                }
                else
                {

                    this.BeginInvoke(singleTraceCompletedDelegateObj, new object[] { singleScanArr });
                    NIDAQControlFormObj.TaskObj.Stop();
                }

            }
            catch (DaqException ex)
            {
                switch (ex.Error)
                {
                    case -200279:
                        //underread error, restart
                        StopAcquire();
                        break;

                    /*
                case -200284:
                    iAsyncResultObj = analogInReader.BeginReadWaveform(ch1VObj.NumPoints, AnalogInCallback, NIDAQControlFormObj.TaskObj);
                    break;
                    */

                    default:
                        MessageBox.Show(ex.Message);
                        StopAcquire();
                        break;
                }
            }
        }

        private Color GetColorByIndex(int index)
        {
            switch(index)
            {
                case 0:
                    return (Color.Blue);                   

                case 1:
                     return (Color.Green);

                case 2:
                    return (Color.Indigo);

                case 3:
                    return (Color.OrangeRed);

                case 4:
                    return (Color.Violet);

                case 5:
                    return (Color.Turquoise);

                default:
                    return (Color.Red);
            }
        }

        private void StopAcquire()
        {
            if (acquireData == true)
            {
                acquireData = false;
                // spin for operation to complete
                iAsyncResultObj.AsyncWaitHandle.WaitOne();
                NIDAQControlFormObj.TaskObj.Stop();
            }
        }

        // used to initalize the data series array
        private DataSeries[] CreateDataSeriesArray(AIVoltageChannel []channels, double zPosition, double sampleRate, double movingVelocity)
        {
            DataSeries[] dataSeriesArr = new DataSeries[channels.Length];

            // initalize the array
            for (int i = 0; i < channels.Length; i++)
            {
                dataSeriesArr[i] = new DataSeries(channels[i], zPosition, sampleRate, movingVelocity);
            }

            return dataSeriesArr;
        }
    }
}
