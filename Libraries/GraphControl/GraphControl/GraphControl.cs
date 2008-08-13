using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace GraphControl
{

  
    public partial class GraphControl : UserControl
    {        
        // p is for private
        private float[] pXlim = new float[2]{-10, 10};
        private float[] pYlim = new float[2] { -10, 10};
        private int num_hashs = 11;

        private float mX;
        private float mY;

        private RectangleF clip_rect_obj;
        private RectangleF graph_rect_obj;
        private PointF[] XAxis = new PointF[2];
        private PointF[] YAxis = new PointF[2];
        private float[] XHashPos;
        private float[] YHashPos;
        private PointF[,] LeftRule;
        private PointF[,] RightRule;
        private PointF[,] TopRule;
        private PointF[,] BottomRule;
        private RectangleF[] XHashLabelRects;
        private RectangleF[] YHashLabelRects;

        // used to format the axis labels
        private StringFormat horzDrawString = new StringFormat();
        private StringFormat virtDrawString = new StringFormat();

        private Font horzAxisFont = new Font("Arial", 10, FontStyle.Regular, GraphicsUnit.Pixel);
        private Font virtAxisFont;

        List<data_set> data_list_obj = new List<data_set>();

        public GraphControl()
        {
            InitializeComponent();
            horzDrawString.Alignment = StringAlignment.Center;
            virtDrawString.Alignment = StringAlignment.Far;
            virtAxisFont = horzAxisFont;
        }

        public float[] Xlim
        {
            set
            {
                pXlim = value;
                Calc_Obj_Postitions();
                this.Invalidate();
            }

            get
            {
                return (pXlim);
            }
        }

        public float[] Ylim
        {
            set
            {
                pYlim = value;
                Calc_Obj_Postitions();
                this.Invalidate();
            }
            get
            {
                return (pYlim);
            }
        }

        public int NumHashes
        {
            set
            {
                num_hashs = value;
                Calc_Obj_Postitions();
                this.Invalidate();
            }
            get
            {
                return (num_hashs);
            }
        }

        public void Plot(string str_data_name, double[] Xpts, double[] Ypts, Color color_obj)
        {
            // check the data area if the data set name already occurs
            // if it occurs over write it
            // otherwise create it
            data_set d_rm = null;

            foreach (data_set d in data_list_obj)
            {
                if (str_data_name.Equals(d.name))
                {
                    d_rm = d;
                }
            }
            if (d_rm != null)
                data_list_obj.Remove(d_rm);
            

            data_set data_obj = new data_set(str_data_name, Xpts, Ypts, color_obj);
            data_obj.cords = PointsToCordinates(Xpts, Ypts);
            // add the new data set to the end of the list
            data_list_obj.Add(data_obj);

            this.Invalidate(); // redraw the control
        }

        // calculates the object positions
        // needs to be done when
        // the canvas changes size
        // the limits change size
        private void Calc_Obj_Postitions()
        {
            graph_rect_obj = new RectangleF(25, 10, clip_rect_obj.Width-40, clip_rect_obj.Height - 40);

            mX = graph_rect_obj.Width / (pXlim[1] - pXlim[0]);
            mY = graph_rect_obj.Height / (pYlim[1] - pYlim[0]);

            // points for axis
            if ((pXlim[0] < 0) && (pXlim[1] > 0))
            {
                float pixX = (0 - pXlim[0]) * mX;

                // top point 
                XAxis[0].X = pixX + graph_rect_obj.Left;
                XAxis[0].Y = graph_rect_obj.Top;
                // bottom point
                XAxis[1].X = pixX + graph_rect_obj.Left;
                XAxis[1].Y = graph_rect_obj.Bottom;                
            }

            if ((pYlim[0] < 0) && (pYlim[1] > 0))
            {
                float pixY = (0 - pYlim[0]) * mY;

                YAxis[0].X = graph_rect_obj.Left;
                YAxis[0].Y = pixY + graph_rect_obj.Top;

                YAxis[1].X = graph_rect_obj.Right;
                YAxis[1].Y = pixY + graph_rect_obj.Top;
            }

            // determines spacing for 10 hash marks
            float hashXSpace = (pXlim[1] - pXlim[0]) / (num_hashs -1);
            float hashYSpace = (pYlim[1] - pYlim[0]) / (num_hashs -1);
            

            float hash_length = graph_rect_obj.Height * .02f;

            float j = pXlim[0];
            float k = pYlim[0];

            XHashPos = new float[num_hashs];
            YHashPos = new float[num_hashs];
            TopRule = new PointF[num_hashs,2];
            BottomRule = new PointF[num_hashs, 2];
            LeftRule = new PointF[num_hashs, 2];
            RightRule = new PointF[num_hashs, 2];
            XHashLabelRects = new RectangleF[num_hashs];
            YHashLabelRects = new RectangleF[num_hashs];

            float XHashCords = 0;
            float YHashCords = 0;

            // determine the hash tick positions
            for (int i = 0; i < num_hashs; i++)
            {
                // need to save the cordinates to label the graph
                XHashCords = (j - pXlim[0]) * mX;
                YHashCords = (k - pYlim[0]) * mY;
                
                XHashPos[i] = (float) j;
                YHashPos[i] = (float) k;

                TopRule[i, 0].X = XHashCords + graph_rect_obj.Left;
                TopRule[i, 0].Y = graph_rect_obj.Top;
                TopRule[i, 1].X = XHashCords + graph_rect_obj.Left;
                TopRule[i, 1].Y = graph_rect_obj.Top + hash_length;

                BottomRule[i, 0].X = XHashCords + graph_rect_obj.Left;
                BottomRule[i, 0].Y = graph_rect_obj.Bottom - hash_length;
                BottomRule[i, 1].X = XHashCords + graph_rect_obj.Left;
                BottomRule[i, 1].Y = graph_rect_obj.Bottom;

                LeftRule[i, 0].X = graph_rect_obj.Left;
                LeftRule[i, 0].Y = graph_rect_obj.Bottom - YHashCords;
                LeftRule[i, 1].X = graph_rect_obj.Left + hash_length;
                LeftRule[i, 1].Y = graph_rect_obj.Bottom - YHashCords;

                RightRule[i, 0].X = graph_rect_obj.Right - hash_length;
                RightRule[i, 0].Y = graph_rect_obj.Bottom - YHashCords;
                RightRule[i, 1].X = graph_rect_obj.Right;
                RightRule[i, 1].Y = graph_rect_obj.Bottom - YHashCords;

                XHashLabelRects[i].X = XHashCords + graph_rect_obj.Left - 20;
                XHashLabelRects[i].Y = graph_rect_obj.Bottom + 2;
                XHashLabelRects[i].Width = 40;
                XHashLabelRects[i].Height= 14;

                YHashLabelRects[i].X = graph_rect_obj.Left - 42;
                YHashLabelRects[i].Y = graph_rect_obj.Bottom - YHashCords - 6;
                YHashLabelRects[i].Width = 40;
                YHashLabelRects[i].Height = 14;


                j += hashXSpace;
                k += hashYSpace;               
            }

            foreach (data_set d in data_list_obj)
            {
                d.cords = PointsToCordinates(d.x_vals, d.x_vals);
            }
        }

        private PointF[] PointsToCordinates(double[] x, double[] y)
        {
            // Assume x & y are of same length
            PointF []cords = new PointF[x.Length];
            for (int i = 0; i < x.Length; i++)
            {
                cords[i].X = (float) (x[i] - Xlim[0])*mX + graph_rect_obj.Left;
                cords[i].Y = (float) (graph_rect_obj.Bottom - (y[i] - Ylim[0])* mY) ;
                
                // do something if x or y exceed the size of the graph           
            }
            return cords;
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            // Get the graphics and the area to draw in
            RectangleF clipf = e.ClipRectangle;
            Graphics g = e.Graphics;

            // determine if the position of the axis need to be recalculated
            if (e.ClipRectangle != clip_rect_obj)
            {
                clip_rect_obj = e.ClipRectangle;
                Calc_Obj_Postitions();                
            }
                                       
            // Fill the rectangle and draw a box around it
            g.FillRectangle(Brushes.White, graph_rect_obj);
            g.DrawRectangle(Pens.Black, Rectangle.Round(graph_rect_obj));
          

            g.DrawLine(Pens.Black, XAxis[0], XAxis[1]);
            g.DrawLine(Pens.Black, YAxis[0], YAxis[1]);
           
            // draw the rulled hash lines;
            for(int i = 0; i < num_hashs; i++)
            {
                g.DrawLine(Pens.Black, TopRule[i,0], TopRule[i,1]);              
                g.DrawLine(Pens.Black, BottomRule[i,0], BottomRule[i,1]);
                g.DrawLine(Pens.Black, LeftRule[i,0], LeftRule[i,1]);              
                g.DrawLine(Pens.Black, RightRule[i,0], RightRule[i,1]);
                g.DrawString(XHashPos[i].ToString("0.0"), horzAxisFont, Brushes.Black, XHashLabelRects[i], horzDrawString);
                g.DrawString(YHashPos[i].ToString("0.0"), virtAxisFont, Brushes.Black, YHashLabelRects[i], virtDrawString); 
            }

            foreach (data_set d in data_list_obj)
            {
                Pen p = new Pen(d.color_obj, 2);
                if (d.x_vals.Length > 2)
                {
                    g.DrawLines(p, d.cords);
                }
            }

            g.Dispose();

            base.OnPaint(e);
        }
    }

    class data_set
    {
        public string name = "";
        public double[] x_vals;
        public double[] y_vals;
        public PointF[] cords;
        public Color color_obj;

        public data_set()
        {
        }

        public data_set(string str_name, double[] XData, double[] YData, Color c)
        {
            name = str_name;
            x_vals = XData;
            y_vals = YData;
            color_obj = c;
        }
    }
}