using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Imaging;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using System.IO;
using System.Windows.Media.Imaging;


namespace Beluga
{
    public partial class TwoDGraphControl : UserControl
    {        public TwoDGraphControl()
        {
            InitializeComponent();
        }


        public void Plot(double[,] data)
        {
            int width = data.GetLength(0);
            int height = data.GetLength(1);
            ushort[,] usData = new ushort[width, height];


            
            Bitmap bmp = new Bitmap(data.GetLength(0), data.GetLength(1), PixelFormat.Format24bppRgb);
            //BitmapData bits = bmp.LockBits(new Rectangle(0, 0, width, height), ImageLockMode.ReadWrite, bmp.PixelFormat);
            //;IntPtr ptr = bits.Scan0;
            //WriteableBitmap wb = new WriteableBitmap(width, height, 72, 72, PixelFormat.DontCare, null);
            
            
            //System.Runtime.InteropServices.Marshal.Copy(ptr, usData, 0, usData.Length*sizeof(ushort));

            // bits.G
            for (int i = 0; i < width; i++)
            {
                for (int j = 0; j < height; j++)
                {
                    bmp.SetPixel(i, j, Color.FromArgb((int) data[i,j]));   
                }
            }

            Graphics g = this.CreateGraphics();

            g.DrawImage(bmp, new Rectangle(0, 0, this.Width, this.Height));
            //pictureBox1.Image = bmp;

            //m_panel.Graphs.Clear();
            //imagescHandle = m_panel.Graphs.AddImageSCGraph(ilData);

        }
    }
}
