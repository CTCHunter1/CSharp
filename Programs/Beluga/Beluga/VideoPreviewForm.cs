using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Runtime.InteropServices;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;

// Webcam
using Microsoft.Expression.Encoder.Devices;
using Microsoft.Expression.Encoder.Live;
using Microsoft.Expression.Encoder;

//using DirectShowLib;

namespace Beluga
{
    public partial class VideoPreviewForm : Form
    {
        LiveDeviceSource source = null;
        LiveJob job = null;
        private bool bSubForm = false;   // set to true if this form is to peresit on close
        private bool bIsShown = false;
        TransparentForm tf = new TransparentForm();

        public VideoPreviewForm(LiveJob job, LiveDeviceSource source)
        {
            InitializeComponent();


            this.source = source;
            this.job = job;
            
            // this is where the source size is set
            SourceProperties sp = source.SourcePropertiesSnapshot();
            Size sourceSize = new Size(sp.Size.Width, sp.Size.Height);
           
            source.PreviewWindow = new PreviewWindow(new HandleRef(previewPanel, previewPanel.Handle));
            
            
            source.PreviewWindow.SetSize(sourceSize);
            previewPanel.Size = sourceSize;

            int curWidth = this.Width;
            int curHeight = this.Height;
            // we want the preview pannel resized to the size of the source           
            this.Width = curWidth - previewPanel.Width + sourceSize.Width;
            this.Height = curHeight - previewPanel.Height + sourceSize.Height;

            tf.TopMost = true;
        }

        private void VideoPreviewForm_Shown(object sender, EventArgs e)
        {
            if (job != null & source != null)
            {
                if (bIsShown == false)
                {
                    // start streaming the video from the device
                    job.ActivateSource(source);
                    // To DO: Change this to use DirectShow                
                    //DsDevice [] dev = DsDevice.GetDevicesOfCat(FilterCategory.VideoInputDevice);
                    //AMMediaType media = new AMMediaType();               


                    //job.AddDeviceSource(source.VideoDevice, source.AudioDevice);
                    //job.S
                    //job.StartEncoding();
                    bIsShown = true;

                    PreviewWindowRecenterAndScale();
                    tf.Show();  
                }
            }
        }

        private void PreviewWindowRecenterAndScale()
        {
            Point loc = PointToScreen(previewPanel.Location);
            tf.Location = loc;
            tf.Size = previewPanel.Size;
            tf.BringToFront();
        }

        private void VideoPreviewForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (job != null)
            {
                if (bIsShown == true)
                {
                    job.StopEncoding();
                    job.RemoveDeviceSource(source);

                    source.PreviewWindow = null;
                    source = null;

                    tf.Hide();

                    bIsShown = false;
                }
            }
            job = null;
        }

        private void previewPanel_Resize(object sender, EventArgs e)
        {
            if (source.PreviewWindow != null)
            {
                source.PreviewWindow.SetSize(new Size(previewPanel.Size.Width, previewPanel.Size.Height));
            }
            PreviewWindowRecenterAndScale();
        }

        private void captureAFrameToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog svd = new SaveFileDialog();
            svd.Filter = "jpeg (*.jpeg)|*.jpeg|tiff (*.tiff)|*.tiff|png (*.png)|*.png|bmp (*.bmp)|*.bmp|All Files (*.*)|*.*";
            svd.FilterIndex = 0;                       

            if (svd.ShowDialog() == DialogResult.OK)
            {
                switch (svd.FilterIndex)
                {
                    default:
                    case 1:
                        SavePicture(svd.FileName, ImageFormat.Jpeg);
                        break;

                    case 2:
                        SavePicture(svd.FileName, ImageFormat.Tiff);
                        break;

                    case 3:
                        SavePicture(svd.FileName, ImageFormat.Png);
                        break;

                    case 4:
                        SavePicture(svd.FileName, ImageFormat.Bmp);
                        break;
                }
            }
        }

        public void SavePicture(String fileName, ImageFormat type)
        {            
            using (Bitmap frame = new Bitmap(previewPanel.Width, previewPanel.Height))
            {
                using (Graphics g = Graphics.FromImage(frame))
                {
                    this.TopMost = true;
                    //tf.BringToFront();                    
                    Refresh(); // redraw the preview box - prevents closing dialogs from appearing in the picture
                    
                    Rectangle rectanglePreviewPan = previewPanel.Bounds;
                    Point sceenPt = PointToScreen(previewPanel.Location);
                    g.CopyFromScreen(sceenPt, Point.Empty, rectanglePreviewPan.Size);
                    // now draw the laser location
                    tf.DrawLaserPoint(g);

                    frame.Save(fileName, type);
                    this.TopMost = false;
                }
            } 
        }

        private void configToolStripMenuItem_Click(object sender, EventArgs e)
        {
            source.ShowConfigurationDialog(ConfigurationDialog.VideoCaptureDialog, new HandleRef(this, this.Handle));
        }

        // Set to True if this is a subform of a larger program
        // cause close box to hide the form instead of dispose of it
        public bool IsSubForm
        {
            get
            {
                return (bSubForm);
            }
            set
            {
                bSubForm = value;
            }

        }

        private void VideoPreviewForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            // hide the form instead of closing it. 
            if (bSubForm == true)
            {
                this.Hide();
                e.Cancel = true;
            }
        }
        
        private void transparentFormToolStripMenuItem_Click(object sender, EventArgs e)
        {
                           
        }

        private void VideoPreviewForm_Move(object sender, EventArgs e)
        {
            PreviewWindowRecenterAndScale();
        }

        private void previewPanel_Click(object sender, EventArgs e)
        {
            Point clientPosition = PointToClient(MousePosition);
            tf.CirclePosition = clientPosition;
        }

        private void VideoPreviewForm_MouseClick(object sender, MouseEventArgs e)
        {
            tf.CirclePosition = e.Location;
        }

        private void previewPanel_MouseClick(object sender, MouseEventArgs e)
        {
            Point clientPosition = PointToClient(MousePosition);
            tf.CirclePosition = clientPosition;
        }

        private void mouseHookComponent1_MouseDoubleClick(object sender, Microsoft.Win32.MouseHookEventArgs e)
        {
            Point pt = new Point(e.X, e.Y);

            tf.CirclePosition = MousePosition;
            PreviewWindowRecenterAndScale();
        }
        
        private void setLaserPosToolStripMenuItem_Click(object sender, EventArgs e)
        {         
            if (setLaserPosToolStripMenuItem.BackColor != Color.Blue)
            {
                this.mouseHookComponent1.MouseDoubleClick += new Microsoft.Win32.MouseHookEventHandler(this.mouseHookComponent1_MouseDoubleClick);
                setLaserPosToolStripMenuItem.BackColor = Color.Blue;
            }
            else
            {
                setLaserPosToolStripMenuItem.BackColor = captureAFrameToolStripMenuItem.BackColor;
                this.mouseHookComponent1.MouseDoubleClick -= new Microsoft.Win32.MouseHookEventHandler(this.mouseHookComponent1_MouseDoubleClick);
            }
        }
    }
}
