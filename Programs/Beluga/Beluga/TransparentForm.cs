using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Configuration;

using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;


namespace Beluga
{
    public partial class TransparentForm : Form
    {
        Rectangle elipsePosition;
        IFormatter formatter = new BinaryFormatter();
        String configFileName = "TransparentForm.config.bin";
        String fullQualFileName = null;

        public TransparentForm()
        {
            InitializeComponent();
            elipsePosition = new Rectangle(3, 5, 10, 10); 

            Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            String dirName = Path.GetDirectoryName(config.FilePath);
            fullQualFileName = dirName + "\\" + configFileName;            

            try
            {
                
                // build the full file path

                Stream stream = new FileStream(fullQualFileName, FileMode.Open);
                elipsePosition = (Rectangle)formatter.Deserialize(stream);
                stream.Close();
            }
            catch
            {
                elipsePosition = new Rectangle(3, 5, 10, 10); 
            }
        }

        private void TransparentForm_Paint(object sender, PaintEventArgs e)
        {
            // base.OnPaint(e);
            //e.Graphics.DrawEllipse(Pens.White, new Rectangle(30, 30, 10, 10));
            Graphics g = e.Graphics;

            DrawLaserPoint(g);            
        }

        public void DrawLaserPoint(Graphics g)
        {
            Pen p = new Pen(Color.Blue, 2); 
            g.DrawEllipse(p, elipsePosition);
        }

        public Point CirclePosition
        {
            get
            {
                int x = elipsePosition.X + elipsePosition.Width / 2;
                int y = elipsePosition.Y + elipsePosition.Height / 2;

                return (new Point(x, y));
            }
            set
            {
                Point pt = PointToClient(value);
                elipsePosition.X = pt.X - elipsePosition.Width / 2;
                elipsePosition.Y = pt.Y - elipsePosition.Height / 2;

                Stream stream = new FileStream(fullQualFileName, FileMode.OpenOrCreate);
                formatter.Serialize(stream, elipsePosition);
                stream.Close();

                this.Invalidate();
            }
        }

        private void TransparentForm_MouseClick(object sender, MouseEventArgs e)
        {
            this.CirclePosition = e.Location;
        }

        private void mouseHookComponent1_MouseDoubleClick(object sender, Microsoft.Win32.MouseHookEventArgs e)
        {
            /*
            Point pt = new Point(e.X, e.Y);
            this.CirclePosition = PointToClient(pt); */
        }
    }
}
