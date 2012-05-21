using System;
using System.Collections.Generic;
using System.Drawing.Imaging;
using System.Linq;
using System.Windows.Forms;
using System.Text;
using System.Threading;

using Lab_Drivers_PVCAM_Wrapper;
using Lab.Drivers.Motors;

namespace Beluga
{
    class AcqController
    {
        PVCAM_Wrapper_Class PVCAMObj;
        VideoPreviewForm vpfObj;
        UIUpdateGraphDelegate uiUpdateGraphDelegate;
        UIUpdateStatusDelegate uiUpdateStatusDelegate;
        UIFinished uiFinishedScanDelegate;
        UIUpdateSequenceDelegate uiUpdateSequenceDelegate;

        int numberScans = 1;
        int exposureTime = 1;

        private volatile bool isRunning = false;
        private volatile bool runScan = false;

        Thread scanThreadObj;

        List<DataSeries> dataArr = null;

        public AcqController(PVCAM_Wrapper_Class PVCAMObj,
            UIUpdateGraphDelegate uiUpdateGraphDelegate,
            UIUpdateStatusDelegate uiUpdateStatusDelegate,
            UIFinished uiFinishedScanDelegate,
            UIUpdateSequenceDelegate uiUpdateSequenceDelegate)
        {
            this.PVCAMObj = PVCAMObj;
            this.uiUpdateGraphDelegate = uiUpdateGraphDelegate;
            this.uiFinishedScanDelegate = uiFinishedScanDelegate;
            this.uiUpdateStatusDelegate = uiUpdateStatusDelegate;
            this.uiUpdateSequenceDelegate = uiUpdateSequenceDelegate;
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

        public void StartAcq(ContainerControl sender, PVCAM_Wrapper_Class pvcamObj)
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
            scanThreadObj.Start((object)new object[] {sender, pvcamObj});

        }

        public void StartAcqContinous(ContainerControl sender, PVCAM_Wrapper_Class pvcamObj)
        {
            // if is running just return
            if (isRunning == true)
            {
                runScan = true;
                return;
            }

            scanThreadObj = new Thread(new ParameterizedThreadStart(ParameterizedThreadStartContinousScan));
            // contiousScanThreadObj.Priority = ThreadPriority.BelowNormal;
            runScan = true;
            isRunning = true;
            scanThreadObj.Start((object)new object[] {sender, pvcamObj});
        }

        public void StartAcqSeq(ContainerControl sender, IAxis[] motorAxes, DataLocation [] ptArr, PVCAM_Wrapper_Class pvcamObj)
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
            scanThreadObj.Start((object)new object[] { sender, pvcamObj, motorAxes, ptArr });
        }

        public void StartAcqSeq(ContainerControl sender, IAxis[] motorAxes, DataLocation[] ptArr, PVCAM_Wrapper_Class pvcamObj, String savePath)
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
            scanThreadObj.Start((object)new object[] { sender, pvcamObj, motorAxes, ptArr, savePath});
        }

        public void StartAcqSeq(ContainerControl sender, IAxis[] motorAxes, DataLocation[] ptArr, VideoPreviewForm vpfObj, String path)
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
            scanThreadObj.Start((object)new object[] { sender, vpfObj, motorAxes, ptArr, path});
        }

        private void ParameterizedThreadStartScan(object parameters)
        {
            // this function is ment to be called in the newly created thread
            // mabye microsoft will fix the parameterized thread start

            Object[] objArr = (Object[]) parameters;
            // pull out the parameters
            ContainerControl sender = (ContainerControl) objArr[0];
            PVCAMObj = objArr[1] as PVCAM_Wrapper_Class; // the third parameter is 1 of these 2 depending on what we're doing
            vpfObj = objArr[1] as VideoPreviewForm;      // as keyword causes this cast to be null if not true 
            IAxis[] motorAxes = null;
            DataLocation[] ptArr = null;
            double[] readPositions = null;
            bool bAcqSeq = false;  // set to true of this is a sequence acquisition. false for single shot
            int numSeqPts = 1;     // value for single shot acq. overwrite for seequence 
            String path = null;

            // continous run
            if (objArr.Length == 3)
            {

            }

            if (objArr.Length >= 4)
            {
                motorAxes = objArr[2] as IAxis[];
                ptArr = objArr[3] as DataLocation[];
            }

            if (objArr.Length >= 5)
            {
                path = (String)objArr[4];
            }


            if (motorAxes != null && ptArr != null)
            {
                bAcqSeq = true;
                numSeqPts = ptArr.Length; // defaults to 1, the case of single pt. acq. 
            } 
            
            // if no motors were detected 
            if (motorAxes == null)
                bAcqSeq = false;    // doesn't make sense to run in sequence mode            
            
            
            // allocate a list object to store the ushort[,] data arrays coming off of the CCD
            dataArr = new List<DataSeries>();
            int i = 0;
            int k = 0;

            // initalize the camera for this exposure duration
            if(PVCAMObj != null)
            {
                PVCAMObj.SetupCameraSingleShot(exposureTime);
            }

            // interate through the sequence points; numSeqPts = 1 if single shot
            for (k = 0; k < numSeqPts; k++)
            {

                if (bAcqSeq == true)
                {
                    readPositions = new double[motorAxes.Length];
                    // move axes into position
                    for (int j = 0; j < motorAxes.Length; j++)
                    {
                        motorAxes[j].MoveAbsolute(ptArr[k].Positions[j]);
                        readPositions[j] = motorAxes[j].Position;
                    }

                    numberScans = ptArr[k].NumExposures;
                }

                // if there is PVCam object then acuqire a sequence.
                if (PVCAMObj != null)
                {
                    i = 0;
                    for (i = 0; i < numberScans && runScan == true; i++)
                    {
                        StringBuilder statusString = new StringBuilder("Begin acquire - ");
                        // will place message on the Beluga status bar
                        if (bAcqSeq == true)
                            statusString.AppendFormat("Seq. Pt: {0} - ", k + 1);
                        statusString.AppendFormat("Scan # {0} / {1}", i + 1, numberScans);
                        sender.BeginInvoke(uiUpdateStatusDelegate, new object[] { statusString.ToString() });

                        // Get the data from the camera                     
                        ushort[,] data = PVCAMObj.AquireSingleShot();
                        // if this is single shot then readPositions is null..We're still OK
                        DataSeries ds = new DataSeries(data, readPositions, exposureTime);
                        dataArr.Add(ds);

                        if (bAcqSeq == true && data != null)
                        {
                            // update the UI that this point has been acuqired
                            sender.BeginInvoke(uiUpdateSequenceDelegate, new object[] { k, true });
                        }
                        // change this -> stop creating and passing x values during the loop
                        sender.BeginInvoke(uiUpdateGraphDelegate, new object[] { ds });
                    }

                    // save the data into the path
                    if (path != null)
                    {
                        SaveDataArrPriv(path);
                    }
                }

                if (vpfObj != null)
                {
                    if (vpfObj.InvokeRequired == true)
                    {
                        //delegate void ShowDelgate();
                        //ShowDelgate sd = new ShowDelgate(vpfObj.Show);
                        MethodInvoker myCallback = new MethodInvoker(
                        delegate()
                        { 
                            vpfObj.Show();
                            if (path != null)
                            {
                                String saveFileName = String.Format("{0}\\{1}.jpeg", path, k);
                                Thread.Sleep(200); // to prevent bluring
                                vpfObj.SavePicture(saveFileName, ImageFormat.Jpeg);
                            }
                        });

                        // the above functionality needs to be called in the form of orgin
                        vpfObj.Invoke(myCallback, null);
                        //vpfObj.Show(); // if already shown does nothing
                        //vpfObj.SavePicture("Pic1.jpg", ImageFormat.Jpeg);
                    }
                }
            }

            // the scan was terminated by the user
            if (runScan == false)
            {
                StringBuilder statusString = new StringBuilder("Acq Stoped - ");
                // will place message on the Beluga status bar
                if (bAcqSeq == true)
                    statusString.AppendFormat("Seq. Pt: {0} / {1}", k + 1, numSeqPts);
                
                if(PVCAMObj != null)
                    statusString.AppendFormat("Scan # {0} / {1}", i + 1, numberScans);

                

                sender.BeginInvoke(uiUpdateStatusDelegate, new object[] { String.Format(statusString.ToString()) });
            }
            else 
            {
                StringBuilder statusString = new StringBuilder("Acq Complete - ");
                // will place message on the Beluga status bar
                if (bAcqSeq == true)
                    statusString.AppendFormat("Seq. Pts: {0} - ", numSeqPts);
                
                if( PVCAMObj != null)
                    statusString.AppendFormat("Scans # {0}", numberScans);

                
                sender.BeginInvoke(uiUpdateStatusDelegate, new object[] { statusString.ToString() });


                sender.BeginInvoke(uiFinishedScanDelegate, new object[] { statusString.ToString() });
            }


            sender.BeginInvoke(uiFinishedScanDelegate, new object[] { null });
            isRunning = false;
            runScan = false;
        }


        // Continous acquistion routine
        private void ParameterizedThreadStartContinousScan(object parameters)
        {
            // this function is ment to be called in the newly created thread
            // mabye microsoft will fix the parameterized thread start

            Object[] objArr = (Object[])parameters;
            // pull out the parameters
            ContainerControl sender = (ContainerControl)objArr[0];
            PVCAMObj = objArr[1] as PVCAM_Wrapper_Class; // the third parameter is 1 of these 2 depending on what we're doing
            
            PVCAMObj.SetupCameraSingleShot(exposureTime);

            // if there is PVCam object then acuqire a sequence.
            while(runScan == true) 
            {
                    StringBuilder statusString = new StringBuilder("Acquiring Pt. ");
                    // will place message on the Beluga status bar
                    
                    // Get the data from the camera                     
                    ushort[,] data = PVCAMObj.AquireSingleShot();

                    if (data != null)
                    {
                        // if this is single shot then readPositions is null..We're still OK
                        DataSeries ds = new DataSeries(data, null, exposureTime);

                        // change this -> stop creating and passing x values during the loop
                        sender.BeginInvoke(uiUpdateGraphDelegate, new object[] { ds });
                    }

            }
            
            sender.BeginInvoke(uiUpdateStatusDelegate, new object[] { "Continous Acq. Stoped"});           

            sender.BeginInvoke(uiFinishedScanDelegate, new object[] { });
            isRunning = false;
            runScan = false;
        }

        public void Stop()
        {
            if (scanThreadObj != null)
            {
                runScan = false;
                // wait for other thread to terminate
                scanThreadObj.Abort();
                scanThreadObj.Join();
                //scanThreadObj.ThreadState = ThreadState.S
            }            
        }

        private void SaveDataArrPriv(String path)
        {
            String fullFileName = null;
            // save the dataList
            for (int i = 0; i < dataArr.Count; i++)
            {
                // this could be cleaned up
                if (dataArr[i].Positions == null)
                {
                    fullFileName = String.Format("{0}\\{1}.txt", path, i + 1);
                }
                else
                {
                    if (dataArr[i].Positions.Length >= 2)
                    {
                        fullFileName = String.Format("{0}\\{1} x={2},y={3}.txt", path, i + 1, dataArr[i].Positions[0], dataArr[i].Positions[1]);
                    }
                    else
                    {
                        fullFileName = String.Format("{0}\\{1}.txt", path, i + 1);
                    }
                }

                if (fullFileName != null)
                    dataArr[i].Save(fullFileName);
            }
        }

        // saves all the points in the data Array to a given path
        public void SaveDataArr(String path)
        {
            if (isRunning == true)
            {
                Exception ex = new Exception("Acq. In progress. Wait for completion before saving.");
                throw (ex);
            }
            
            SaveDataArrPriv(path);                        
        }
    }
}
