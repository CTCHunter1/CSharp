using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using System.Text;
using System.Threading;

using Lab_Drivers_PVCAM_Wrapper;

namespace Beluga
{
    class AcqController
    {
        PVCAM_Wrapper_Class PVCAMObj;
        UIUpdateGraphDelegate uiUpdateGraphDelegate;
        UIUpdateStatusDelegate uiUpdateStatueDelegate;
        UIFinished uiFinishedScanDelegate;

        int numberScans = 1;
        int exposureTime = 1;

        private volatile bool isRunning = false;
        private volatile bool runScan = false;

        Thread scanThreadObj;

        List<ushort[]> dataArr = null;

        public AcqController(PVCAM_Wrapper_Class PVCAMObj,
            UIUpdateGraphDelegate uiUpdateGraphDelegate,
            UIUpdateStatusDelegate uiUpdateStatueDelegate,
            UIFinished uiFinishedScanDelegate)
        {
            this.PVCAMObj = PVCAMObj;
            this.uiUpdateGraphDelegate = uiUpdateGraphDelegate;
            this.uiFinishedScanDelegate = uiFinishedScanDelegate;
            this.uiUpdateStatueDelegate = uiUpdateStatueDelegate;
        }

        public int ExposureTime
        {
            get { return (exposureTime); }

            set { exposureTime = value; }
        }

        public int NumExposure
        {
            get { return (numberScans); }

            set { numberScans = value; }
        }

        public void StartAcq(ContainerControl sender)
        {
            // if is running just return
            if (isRunning == true)
            {
                runScan = true;
                return;
            }

            scanThreadObj = new Thread(new ParameterizedThreadStart(ParameterizedThreadStartScan));
            // contiousScanThreadObj.Priority = ThreadPriority.BelowNormal;
            runScan = true;
            isRunning = true;
            scanThreadObj.Start((object)new object[] {sender});

        }

        private void ParameterizedThreadStartScan(object parameters)
        {
            // this function is ment to be called in the newly created thread
            // mabye microsoft will fix the parameterized thread start

            Object[] objArr = (Object[])parameters;
            // pull out the parameters
            ContainerControl sender = (ContainerControl)objArr[0];

            //if(dataArr == null)
            dataArr = new List<ushort[]>();

            PVCAMObj.SetupCameraSingleShot(exposureTime);

            int i = 0;
            for(; i < numberScans && runScan == true; i++)
            {
                sender.BeginInvoke(uiUpdateStatueDelegate, new object[] { String.Format("Acquiring Point {0} / {1}", i + 1, numberScans) });
                ushort [,] data = PVCAMObj.AquireSingleShot();
                double [,] doubleData = new double[data.GetLength(0), data.GetLength(1)];

                for (int k = 0; k < data.GetLength(0); k++)
                {
                    for (int j = 0; j < data.GetLength(1); j++)
                    {
                        doubleData[k, j] = Convert.ToDouble(data[k, j]);
                    }
                }

                double[] xvals = new double[data.GetLength(0)];

                if (data.GetLength(1) == 1)
                {
                    double[] yvals = new double[data.GetLength(0)];
                    ushort[] temp = new ushort[data.GetLength(0)];

                    for (int j = 0; j < data.GetLength(0); j++)
                    {
                        xvals[j] = j + 1;
                        yvals[j] = Convert.ToDouble(data[j, 0]);
                        temp[j] = data[j, 0];
                    }
                                       
                    dataArr.Add(temp);
                }

                sender.BeginInvoke(uiUpdateGraphDelegate, new object[] { xvals, doubleData });
            }

            // the scan was terminated by the user
            if (runScan == false)
            {
                sender.BeginInvoke(uiUpdateStatueDelegate, new object[] { String.Format("Acq Stoped at Point {0} / {1}", i + 1, numberScans) });
            }
            else 
            {
                sender.BeginInvoke(uiUpdateStatueDelegate, new object[] { String.Format("Completed Scan of {0} Points", numberScans) });
            }

          
            sender.BeginInvoke(uiFinishedScanDelegate, new object[] {});
            isRunning = false;
            runScan = false;
        }

        public void Stop()
        {
            if (isRunning == true)
            {
                runScan = false;
                // wait for other thread to terminate
                scanThreadObj.Abort();
                scanThreadObj.Join();
                //scanThreadObj.ThreadState = ThreadState.S
            }
        }

    }
}
