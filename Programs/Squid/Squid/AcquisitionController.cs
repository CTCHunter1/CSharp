using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Windows.Forms;

using Lab.Drivers.DAQ;
using NationalInstruments;
using NationalInstruments.DAQmx;

namespace Squid
{
    public class AcquisitionController
    {
        public delegate void UIUpdateGraphDelegate(DataSeries [] dataSeriesArr);
        public delegate void UIFinishedContinousScan();
        UIUpdateGraphDelegate uiDataSeriesUpdateDelegate;
        UIUpdateGraphDelegate uiReducedDataSeriesUpdateDelegate;
        UIFinishedContinousScan uiFinishedContinousScanDelegate;

        private volatile bool isRunning = false;
        private volatile bool runContinousScan = false;
        NI6251ControlForm nidaqControlObj;
        SquidOptionsForm squidOptionsObj;

        private Decimator decimatorObj;

        Mutex dataArrMutex;
        private DataSeries[] continousScanArr;
        private DataSeries[] reducedScanArr;
        
        private PrecisionDateTime timeStamp; // The time of the last taken sample

        Task digitalTask;

        double[] digitalData;
        bool[] digitalDataBool;

        Thread continousScanThreadObj;
         

        public AcquisitionController(SquidOptionsForm squidOptionsObj,
            NI6251ControlForm  nidaqControlObj,
            UIUpdateGraphDelegate uiDataSeriesUpdateDelegte,
            UIUpdateGraphDelegate uiReduceDataSeriesUpdateDelegate,
            UIFinishedContinousScan uiFinishedContinousScanDelegate)
        {
            this.nidaqControlObj = nidaqControlObj;
            this.squidOptionsObj = squidOptionsObj;
            this.decimatorObj = squidOptionsObj.DecimatorObj;
            this.uiDataSeriesUpdateDelegate = uiDataSeriesUpdateDelegte;
            this.uiReducedDataSeriesUpdateDelegate = uiReduceDataSeriesUpdateDelegate;
            this.uiFinishedContinousScanDelegate = uiFinishedContinousScanDelegate;

            // create a task for the digital IO
            digitalTask = new Task();

            digitalTask.DIChannels.CreateChannel("Dev1/port0/line1", "", ChannelLineGrouping.OneChannelForEachLine);
            digitalTask.Timing.ConfigureSampleClock("/Dev1/ai/SampleClock", nidaqControlObj.Rate, SampleClockActiveEdge.Rising,
                SampleQuantityMode.ContinuousSamples, nidaqControlObj.SamplesPerChannel);
            digitalTask.Control(TaskAction.Verify);

            dataArrMutex = new Mutex();
        }

        public bool IsRunning
        {
            get
            {
                return (isRunning);
            }
            set
            {
                isRunning = value;
            }
        }

        
        public ZDataPoint ReducedTrace
        {
            get
            {
                /// get the data array
                dataArrMutex.WaitOne();
                DataSeries[] returnDataSeries = reducedScanArr;
                // create a new data series array to replace this one with
                reducedScanArr = DataSeries.CreateDataSeriesArray(nidaqControlObj.AIChannels.Length,
                squidOptionsObj.NumReducedSamples,
                nidaqControlObj.Rate,
                squidOptionsObj.FrequencyAmpUnits,
                50);

                ZDataPoint returnDataPoint = new ZDataPoint(returnDataSeries, timeStamp);

                dataArrMutex.ReleaseMutex();

                return (returnDataPoint);
            }
        }

        public ZDataPoint CurrentTrace
        {
            get
            {
                dataArrMutex.WaitOne();
                DataSeries[] returnDataSeries = continousScanArr;
                // create a new data series array to replace this one with
                continousScanArr = continousScanArr = DataSeries.CreateDataSeriesArray(nidaqControlObj.AIChannels.Length,
                nidaqControlObj.SamplesPerChannel,
                nidaqControlObj.Rate,
                squidOptionsObj.FrequencyAmpUnits,
                50);

                ZDataPoint returnDataPoint = new ZDataPoint(returnDataSeries, timeStamp);

                dataArrMutex.ReleaseMutex();

                return (returnDataPoint);
            }
        }

        public double TimeDuration_s
        {
            get{
                return (nidaqControlObj.SamplesPerChannel / nidaqControlObj.Rate);
            }
        }

        public DataSeries[] TakeSingleTrace(ContainerControl sender)
        {
            StartContinousUpdate(sender);
            StopContinousUpdate();
                       
            return (reducedScanArr);
        }

        private void TakeTrace(DataSeries[] dataSeriesArr, DataSeries[] reducedDataSeries)
        {
            AnalogMultiChannelReader analogInReader = new AnalogMultiChannelReader(nidaqControlObj.TaskObj.Stream);
            AnalogWaveform<double>[] multiChannelWaveformData = analogInReader.ReadWaveform(nidaqControlObj.SamplesPerChannel);           

            DigitalSingleChannelReader digitalReader = new DigitalSingleChannelReader(digitalTask.Stream);
            DigitalWaveform digitalWaveform = digitalReader.ReadWaveform(nidaqControlObj.SamplesPerChannel);
            

            
            digitalData = new double[digitalWaveform.Samples.Count];
            digitalDataBool = new bool[digitalWaveform.Samples.Count];

            // copy out the digital waveform data
            for (int i = 0; i < digitalData.Length; i++)
            {
                if (digitalWaveform.Signals[0].States[i] == DigitalState.ForceUp)
                {
                    digitalData[i] = 1;
                    digitalDataBool[i] = true;
                }
                else
                {
                    digitalData[i] = 0;
                    digitalDataBool[i] = false;
                }
            }

            // copy out the analog waveform data and reduce to the trigger
            for (int i = 0; i < dataSeriesArr.Length; i++)
            {
                dataSeriesArr[i].Y_t = multiChannelWaveformData[i].GetScaledData();
                reducedDataSeries[i].Y_t = decimatorObj.Reduce(dataSeriesArr[i], digitalDataBool);

                dataSeriesArr[i].UpdateFFT();
                reducedDataSeries[i].UpdateFFT();

            }

            if (dataSeriesArr.Length > 0)
            {
                timeStamp = multiChannelWaveformData[0].PrecisionTiming.TimeStamp;
            }               
        }

        public void StartContinousUpdate(ContainerControl sender)
        {
            // if it is already running then don't do anything
            if (isRunning == true)
            {
                runContinousScan = true;
                return;
            }

            nidaqControlObj.SingleShot = false;            

            continousScanThreadObj = new Thread(new ParameterizedThreadStart(ContinousScan));
            // contiousScanThreadObj.Priority = ThreadPriority.BelowNormal;
            runContinousScan = true;
            isRunning = true;
            continousScanThreadObj.Start((object)new object[] { sender });  
        }

        public void ContinousScan(object parameters)
        {
            // get the parameteres
            Object[] obj_arr = (Object[])parameters;
            ContainerControl sender = (ContainerControl)obj_arr[0];
          
            //digitalTask.Timing.SampleQuantityMode = SampleQuantityMode.ContinuousSamples;
            //digitalTask.Control(TaskAction.Verify);

            // Create the dataSeriesArray
            // create a array to store the read data
            // one data series for each channel
            continousScanArr = DataSeries.CreateDataSeriesArray(nidaqControlObj.AIChannels.Length,
                nidaqControlObj.SamplesPerChannel,
                nidaqControlObj.Rate,
                squidOptionsObj.FrequencyAmpUnits,
                50);

            reducedScanArr = DataSeries.CreateDataSeriesArray(nidaqControlObj.AIChannels.Length,
                squidOptionsObj.NumReducedSamples,
                nidaqControlObj.Rate,
                squidOptionsObj.FrequencyAmpUnits,
                50);


            try
            {
                do
                {
                    // we don't want the arrays to disappear while taking the trace
                    dataArrMutex.WaitOne();

                    TakeTrace(continousScanArr, reducedScanArr);

                    // update the graph in the ui thread
                    sender.BeginInvoke(uiDataSeriesUpdateDelegate, new object[] { continousScanArr});
                    sender.BeginInvoke(uiReducedDataSeriesUpdateDelegate, new object[]{ reducedScanArr});
                    // must call BeginInovke using the sender not the delegate, would be nice if it could
                    // just be called on the delegate
                    dataArrMutex.ReleaseMutex();
                } while(runContinousScan);
            }
            catch (DaqException ex)
            {
                MessageBox.Show(ex.Message);
                dataArrMutex.ReleaseMutex();
            }

            // stop the task
            nidaqControlObj.TaskObj.Stop();
            digitalTask.Stop();

            // reenable the contious scan button
            if (uiFinishedContinousScanDelegate != null)
                sender.BeginInvoke(uiFinishedContinousScanDelegate, new object[] { });

            isRunning = false;
        }

        public void StopContinousUpdate()
        {
            if(isRunning == true)
            {
                runContinousScan = false;
                // wait for other thread to terminate
                continousScanThreadObj.Join();    
            }        
        }
    }
}
