using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Text;
using System.Threading;

using Lab.Drivers.Motors;

namespace Squid
{
    public class ZScanController
    {
        public delegate void UIUpdateGraphDelegate(ZDataPoint zDataPointObj);
        public delegate void UIFinishedScan();

        AcquisitionController acqControllerObj;
        ZDataSeries zDataSeriesObj = new ZDataSeries();

        UIUpdateGraphDelegate uiUpdateGraphDelegate;
        UIFinishedScan uiFinishedScanDelegate;

        private volatile bool isRunning = false;
        private volatile bool runScan = false;

        Thread scanThreadObj;

        public ZScanController(AcquisitionController  acqControllerObj,
            UIUpdateGraphDelegate uiUpdateGraphDelegate,
            UIFinishedScan uiFinishedScanDelegate)
        {
            this.acqControllerObj = acqControllerObj;

            this.uiUpdateGraphDelegate = uiUpdateGraphDelegate;
            this.uiFinishedScanDelegate = uiFinishedScanDelegate;
        }

        // start the threaded scan function
        public void StartScan(ContainerControl sender,
            IAxis axisObj,
            double scanDist,
            int numPoints)
        {
            // if is running just return
            if (isRunning == true)
            {
                runScan = true;
                return;
            }

            // if there is no axis there isn't anything to do
            if (axisObj == null)
            {
                sender.BeginInvoke(uiFinishedScanDelegate, new object[] { });
                return;
            }

            // start the aquisition thread if it isn't already
            acqControllerObj.StartContinousUpdate(sender);

            scanThreadObj = new Thread(new ParameterizedThreadStart(ParameterizedThreadStartScan));
            // contiousScanThreadObj.Priority = ThreadPriority.BelowNormal;
            runScan = true;
            isRunning = true;
            scanThreadObj.Start((object)new object[] {sender,
                axisObj,
                scanDist,
                numPoints});
        }

        private void ParameterizedThreadStartScan(object parameters)
        {
            // this function is ment to be called in the newly created thread
            // mabye microsoft will fix the parameterized thread start

            Object[] objArr = (Object[])parameters;
            // pull out the parameters
            ContainerControl sender = (ContainerControl) objArr[0];
            IAxis axisObj = (IAxis)objArr[1];
            double scanDist = (double)objArr[2];
            int numPoints = (int)objArr[3];

            Scan(sender, axisObj, scanDist, numPoints);
        }

        // scan dist in (mm)
        public void Scan(ContainerControl sender, IAxis axisObj, double scanDist, int numPoints)
        {
            double centerPosition = axisObj.Position;
            
            // Find dX, distance between points
            double dX = scanDist;
            if (numPoints > 1)
                dX = scanDist / (numPoints - 1);    // fixes fence post problem

            double startingPosition = centerPosition - scanDist / 2;
            double position;    // used inside the loop

            // create new zDataSeries
            zDataSeriesObj = new ZDataSeries();
            
            ZDataPoint dataPoint = null;
            ZDataPoint prevDataPoint = null;

            for (int i = 0; i < numPoints && runScan == true; i++)
            {
                // the position for this point
                position = startingPosition + i * dX;
                axisObj.MoveAbsolute(position);
                
                // get the current data point
                dataPoint = acqControllerObj.ReducedTrace;
                
                // make sure the data point taken is new
                if (prevDataPoint != null)
                {
                    while(prevDataPoint == dataPoint)
                        dataPoint = acqControllerObj.ReducedTrace;
                }
 
                dataPoint.Z0 = position;    // set the position

                // add this to the zDataSeriesObject
                zDataSeriesObj.Add(dataPoint);
                prevDataPoint = dataPoint;

                sender.BeginInvoke(uiUpdateGraphDelegate, new object[] { dataPoint });                   
            }

            // return the motor to the starting positon
            axisObj.MoveAbsolute(centerPosition);
            
            // call end move absolute to disengage the motor if newport
            axisObj.EndMoveAbsolute(null);

            sender.BeginInvoke(uiFinishedScanDelegate, new object[] { });

            isRunning = false;
            runScan = false;
        }

        public void StopScan()
        {
            if (isRunning == true)
            {
                runScan = false;
                // wait for other thread to terminate
                scanThreadObj.Join();
            }        
        }

        public ZDataSeries ZDataSeries
        {
            get
            {
                return (zDataSeriesObj);
            }
        }
    }
}
