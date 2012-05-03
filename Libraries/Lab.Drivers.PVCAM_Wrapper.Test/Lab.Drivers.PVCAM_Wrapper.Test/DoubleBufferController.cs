using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using System.Text;
using System.Threading;

using Lab_Drivers_PVCAM_Wrapper;

namespace Lab.Drivers.PVCAM_Wrapper.Test
{
    class DoubleBufferController
    {
        PVCAM_Wrapper_Class PVCAMObj;
        UIUpdateGraphDelegate uiUpdateGraphDelegate;
        UIFinished uiFinishedScanDelegate;

        private volatile bool isRunning = false;
        private volatile bool runScan = false;

        Thread scanThreadObj;

        public DoubleBufferController(PVCAM_Wrapper_Class PVCAMObj,
            UIUpdateGraphDelegate uiUpdateGraphDelegate,
            UIFinished uiFinishedScanDelegate)
        {
            this.PVCAMObj = PVCAMObj;
            this.uiUpdateGraphDelegate = uiUpdateGraphDelegate;
            this.uiFinishedScanDelegate = uiFinishedScanDelegate;
        }

        public void StartDBAcq(ContainerControl sender)
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

            PVCAMObj.StartDoubleBuffer(250);

            while (runScan == true)
            {
                ushort[] data = PVCAMObj.GetDoubleBufferFrame();

                double[] xvals = new double[data.Length];
                double[] yvals = new double[data.Length];

                for (int i = 0; i < data.Length; i++)
                {
                    xvals[i] = i + 1;
                    yvals[i] = Convert.ToDouble(data[i]);
                }

                sender.BeginInvoke(uiUpdateGraphDelegate, new object[] { xvals, yvals });
            }

            PVCAMObj.StopDoubleBufferAcq();

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
                scanThreadObj.Join();
            }
        }

    }
}
