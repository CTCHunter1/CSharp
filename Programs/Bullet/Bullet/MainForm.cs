using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
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
        enum ViewType { CuttingAxis, PlotWaists, PlotWaistsAndCentroid};

        // the scan options form should never be destroyed
        MotorControlForm motorControlFormObj;
        ScanOptionsForm scanOptionsFormObj;
        NI6251ControlForm NIDAQControlFormObj;

        GraphControl.GraphControl waistsGraph = new GraphControl.GraphControl();
        GraphControl.GraphControl centroidGraph = new GraphControl.GraphControl();

        // for the DAQ
        private AsyncCallback analogCallback;
        private IAsyncResult iAsyncResultObj; 
        private AnalogMultiChannelReader analogInReader;
        private AnalogWaveform<double>[] multiChannelWaveformData;

        private ViewType viewTypeObj = ViewType.PlotWaists;

        // TODO: Delete next two lines
        // object to place incoming data in
        //private DataSeries ch1VObj;

        // for the motors
        private AsyncCallback motorDoneCallback;

        private delegate void TraceCompletedDelegate(DataSeries [] dataSeriesArr);
        //TraceCompletedDelegate tcdObj;

        public MainForm()
        {
            InitializeComponent();
            waistsGraph.Hide();
            centroidGraph.Hide();
            
            // add the new control to the UI
            this.Controls.Add(waistsGraph);
            this.Controls.Add(centroidGraph);

            InitalizeListView();
            SizeFormControls();
            motorControlFormObj = new MotorControlForm();
            scanOptionsFormObj = new ScanOptionsForm(motorControlFormObj.Axes);
            

            if (scanOptionsFormObj.ZAxisScan == true)
            {
                zScanToolStripMenuItem.Enabled = true;
            }
            else
            {
                zScanToolStripMenuItem.Enabled = false;
            }

            //tcdObj = new TraceCompletedDelegate(TraceCompletedCallback);
            try
            {
                NIDAQControlFormObj = new NI6251ControlForm();
                NIDAQControlFormObj.Rate = 1000;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();        
        }

        private void scanOptionsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            scanOptionsFormObj.ShowDialog();
            if (scanOptionsFormObj.ZAxisScan == true)
            {
                zScanToolStripMenuItem.Enabled = true;
            }
            else
            {
                zScanToolStripMenuItem.Enabled = false;
            }
        }

        private void motorOptionsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            motorControlFormObj.ShowDialog();
        }

        private void dAQOptionsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                StopAcquire();

                NIDAQControlFormObj.ShowDialog();
                NIDAQControlFormObj.SingleShot = false;
            }
            catch (DaqException ex)
            {
                if (ex.Error == -201003)
                {
                    if (NIDAQControlFormObj != null)
                        NIDAQControlFormObj.Dispose();

                    MessageBox.Show("Error: No DAQ detected.");
                }
                else
                    throw (ex);
            }
        }     

        private void singleScanToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // center the single trace around the current point
            TakeSingleTrace(scanOptionsFormObj.CuttingAxisMotor.Position, new TraceCompletedDelegate(SingleTraceCompletedCallback));
        }

        private void stopToolStripMenuItem_Click(object sender, EventArgs e)
        {
            StopAcquire();
            bZScan = false;
        }


        private void InitalizeListView()
        {
            int channelWidth = (int) (Convert.ToDouble(waistListView.Size.Width)*.595);
            int waistWidth = (int) (Convert.ToDouble(waistListView.Size.Width) * .2);
            int displacementWidth = (int) (Convert.ToDouble(waistListView.Size.Width) * .2);

            waistListView.Columns.Add("Channel", channelWidth, HorizontalAlignment.Left);
            waistListView.Columns.Add("Waist (um)", waistWidth, HorizontalAlignment.Left);
            waistListView.Columns.Add("Displacment (mm)", displacementWidth, HorizontalAlignment.Left);
            
        }

        private void ListViewAddItem(string chnannelName, double waist, double displacement)
        {
            string[] addStrings = new string[3] {chnannelName, waist.ToString(), displacement.ToString()};
            ListViewItem newItem = new ListViewItem(addStrings);
            waistListView.Items.Add(newItem);
        }

        private void zScanToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TakeZScan();
        }

        private void MainForm_Resize(object sender, EventArgs e)
        {
            /*
            Size currintProfileGraphSize = profileGraph.Size;
            currintProfileGraphSize.Width = (int) (Convert.ToDouble(this.Size.Width)*.98);
            // make the waist liust and graph span the horizontal and the waist 
            profileGraph.Size = currintProfileGraphSize;
            */

            SizeFormControls();
        }

        private void SizeFormControls()
        {
                //resize the profile graph
                Size profileGraphSize = cuttingAxisGraph.Size;
                Point profileGraphLocation = cuttingAxisGraph.Location;
                Size waistListViewSize = waistListView.Size;
                Point waistListViewLocation = waistListView.Location;

                int widthOfControls = (int)(Convert.ToDouble(this.Size.Width) * .99);
                int bottomOfProfileGraph = this.Size.Height - waistListViewSize.Height - menuStrip1.Height - statusStrip1.Height - 50;
                profileGraphSize.Height = bottomOfProfileGraph;

                waistListViewSize.Width = widthOfControls; 

                // the view type changes the width of the graph
                switch(viewTypeObj)
                {
                    default:
                    case ViewType.CuttingAxis:
                        // the waist plot isn't shown in this view
                        waistsGraph.Hide();
                        centroidGraph.Hide();

                        // change the width of the profile graph and waist list view to that of the window
                        
                        profileGraphSize.Width = widthOfControls;                                               
                        break;

                    case ViewType.PlotWaists:
                        centroidGraph.Hide();
                        profileGraphSize.Width = widthOfControls/2 - 10; 

                        this.waistsGraph.Location = new System.Drawing.Point(profileGraphSize.Width+10, menuStrip1.Height + 5);
                        this.waistsGraph.Name = "zWaistGraph";
                        this.waistsGraph.Size = new System.Drawing.Size(profileGraphSize.Width, bottomOfProfileGraph);
                        this.waistsGraph.TabIndex = 0;                       
                        this.waistsGraph.Show();
                        break;

                    case ViewType.PlotWaistsAndCentroid:
                        profileGraphSize.Width = widthOfControls / 3 - 10;
                        
                        this.waistsGraph.Location = new System.Drawing.Point(profileGraphSize.Width + 10, menuStrip1.Height + 5);
                        this.waistsGraph.Name = "zWaistGraph";
                        this.waistsGraph.Size = new System.Drawing.Size(profileGraphSize.Width, bottomOfProfileGraph);

                        this.centroidGraph.Location = new System.Drawing.Point(profileGraphSize.Width*2 + 10, menuStrip1.Height + 5);
                        this.centroidGraph.Name = "zCentroidGraph";
                        this.centroidGraph.Size = new System.Drawing.Size(profileGraphSize.Width, bottomOfProfileGraph);
                       
                        this.waistsGraph.Show();
                        this.centroidGraph.Show();
                        break;
                }
                

                // place the top of the profile graph control
                profileGraphLocation.X = 0;
                profileGraphLocation.Y = menuStrip1.Height + 5;
                
                
                // size the waist list view
                waistListViewLocation.Y = bottomOfProfileGraph + 35;
                waistListViewLocation.X = 4;

                // make the waist list and graph span the horizontal and the waist 
                cuttingAxisGraph.Size = profileGraphSize;
                cuttingAxisGraph.Location = profileGraphLocation;
                waistListView.Size = waistListViewSize;
                waistListView.Location = waistListViewLocation;
           
        }
        
    
        private void waistListView_Resize(object sender, EventArgs e)
        {
            int channelWidth = (int)(Convert.ToDouble(waistListView.Size.Width) * .59);
            int waistWidth = (int)(Convert.ToDouble(waistListView.Size.Width) * .2);
            int displacementWidth = (int)(Convert.ToDouble(waistListView.Size.Width) * .2);

            waistListView.Columns[0].Width = channelWidth;
            waistListView.Columns[1].Width = waistWidth;
            waistListView.Columns[2].Width = displacementWidth;
        }

        private void zAxisPofileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            viewTypeObj = ViewType.PlotWaists;
            SizeFormControls();
        }

        private void cuttingProfileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            viewTypeObj = ViewType.CuttingAxis;
            SizeFormControls();
        }

        private void beamWaistAndCentroidProfileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            viewTypeObj = ViewType.PlotWaistsAndCentroid;
            SizeFormControls();
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
           

            SaveFileDialog saveFileDialogObj = new SaveFileDialog();
            // set what file types the dialog shows
            saveFileDialogObj.Filter = "Csv Files (*.csv)|.csv|All Files|";


            if (saveFileDialogObj.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    StreamWriter streamWritterObj = new StreamWriter(saveFileDialogObj.OpenFile());

                    FileIO.WriteSingleScanCSVFile(streamWritterObj, singleScanArr);

                    streamWritterObj.Close();
                }
                catch (IOException ex)
                {
                    MessageBox.Show(ex.Message);
                }                

            }

        }

        private void saveZAxisScanToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialogObj = new SaveFileDialog();
            // set what file types the dialog shows
            saveFileDialogObj.Filter = "Csv Files (*.csv)|.csv|All Files|";


            if (saveFileDialogObj.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    StreamWriter streamWritterObj = new StreamWriter(saveFileDialogObj.OpenFile());

                    FileIO.WriteZScanCSVFile(streamWritterObj, zDataSeriesArr);

                    streamWritterObj.Close();
                }
                catch (IOException ex)
                {
                    MessageBox.Show(ex.Message);
                }

            }
        }
    }
}