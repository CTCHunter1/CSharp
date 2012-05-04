using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Windows.Forms;

// Webcam
using Microsoft.Expression.Encoder.Devices;
using Microsoft.Expression.Encoder.Live;
using Microsoft.Expression.Encoder;

using System.Runtime.InteropServices;

namespace Beluga
{
    public partial class VideoPreviewForm : Form
    {
        LiveDeviceSource source = null;
        LiveJob job = null;

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

        }

        private void VideoPreviewForm_Shown(object sender, EventArgs e)
        {
            if (job != null & source != null)
            {
                // start streaming the video from the device
                job.ActivateSource(source);
            }
        }

        private void VideoPreviewForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (job != null)
            {
                job.StopEncoding();
                job.RemoveDeviceSource(source);

                source.PreviewWindow = null;
                source = null;
            }
            job = null;
        }

        private void previewPanel_Resize(object sender, EventArgs e)
        {
            if (source.PreviewWindow != null)
            {
                source.PreviewWindow.SetSize(new Size(previewPanel.Size.Width, previewPanel.Size.Height));
            } 
        }

        private void captureAFrameToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Bitmap frame = new Bitmap(previewPanel.Width, previewPanel.Height);
            previewPanel.DrawToBitmap(frame, new Rectangle(0,0, previewPanel.Width, previewPanel.Height));

            frame.Save("Test File.jpeg", ImageFormat.Jpeg);
        }
    }
}
