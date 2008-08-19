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
        private bool pAutoScale = true;
        private int num_hashs = 11;

        private float mX;
        private float mY;

        private RectangleF control_rect_obj;
        private RectangleF graph_rect_obj;
        private PointF[] XAxis = new PointF[2];
        private PointF[] YAxis = new PointF[2];
        private double[] XHashPos;
        private double[] YHashPos;
        private PointF[,] LeftRule;
        private PointF[,] RightRule;
        private PointF[,] TopRule;
        private PointF[,] BottomRule;
        private RectangleF[] XHashLabelRects;
        private RectangleF[] YHashLabelRects;

        private RectangleF top_rect;
        private RectangleF bottom_rect;
        private RectangleF left_rect; 
        private RectangleF right_rect;

        // used to format the axis labels
        private StringFormat horzDrawString = new StringFormat();
        private StringFormat virtDrawString = new StringFormat();

        private Font horzAxisFont = new Font("Arial", 10, FontStyle.Regular, GraphicsUnit.Pixel);
        private Font virtAxisFont;

        List<data_set> data_list_obj = new List<data_set>();

        DBGraphics mem_graphic;

        public GraphControl()
        {
            mem_graphic = new DBGraphics();
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

        public bool AutoScale
        {
            set
            {
                pAutoScale = value;
            }
            get
            {
                return(pAutoScale);
            }
        }

        private void AutoScaler(double[] Xpts, double[] Ypts)
        {
           this.Xlim = new float[2]{FindMin(Xpts), FindMax(Xpts)};
           this.Ylim = new float[2]{FindMin(Ypts), FindMax(Ypts)};
           //Calc_Obj_Postitions();
        }

        private float FindMax(double []pts)
        {
            double d = pts[0];

            foreach (double p in pts)
            {
                if (p > d)
                    d = p;
            }

            return ((float) d);
        }

        private float FindMin(double[] pts)
        {
            double d = pts[0];

            foreach (double p in pts)
            {
                if (p < d)
                    d = p;
            }

            return ((float) d);
        }

        protected override void OnResize(EventArgs e)
        {
            // On Rezise called imediatly after load
            mem_graphic.CreateDoubleBuffer(this.CreateGraphics(), this.ClientRectangle.Width, this.ClientRectangle.Height);
            Invalidate(); // Force a repaint after has been resized 
            base.OnResize(e);
        }

        protected override void OnPaintBackground(PaintEventArgs e)
        {
            //base.OnPaintBackground(e);
        }

        public void Plot(string str_data_name, double[] Xpts, double[] Ypts, Color color_obj)
        {
            // check the data area if the data set name already occurs
            // if it occurs over write it
            // otherwise create it
            data_set d_rm = null;

            if (pAutoScale == true)
                AutoScaler(Xpts, Ypts);

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
            // data_obj.cords = PointsToCordinates(Xpts, Ypts);
            // add the new data set to the end of the list
            data_list_obj.Add(data_obj);
            Calc_Obj_Postitions();

            this.Invalidate(); // redraw the control
        }

        // calculates the object positions
        // needs to be done when
        // the canvas changes size
        // the limits change size
        private void Calc_Obj_Postitions()
        {   
            // rectangles that suround graph_rect_obj and paint the background color
            top_rect = new RectangleF(0, 0, control_rect_obj.Width, graph_rect_obj.Top - control_rect_obj.Top);
            bottom_rect = new RectangleF(0, graph_rect_obj.Bottom, control_rect_obj.Width, control_rect_obj.Bottom - graph_rect_obj.Bottom);
            left_rect = new RectangleF(0, 0, graph_rect_obj.Left - control_rect_obj.Left, control_rect_obj.Height);
            right_rect = new RectangleF(graph_rect_obj.Right, 0, control_rect_obj.Right - graph_rect_obj.Right, control_rect_obj.Height);
            
            // The data window inside the cotrol
            graph_rect_obj = new RectangleF(25, 10, control_rect_obj.Width-50, control_rect_obj.Height - 50);
            if (graph_rect_obj.Width < 0)
                graph_rect_obj.Width = 10;
            if (graph_rect_obj.Height < 0)
                graph_rect_obj.Height = 10;


            // calculate pixels per x & y point
            if ((pXlim[1] - pXlim[0]) != 0)
                mX = graph_rect_obj.Width / (pXlim[1] - pXlim[0]);
            else
                mX = 0;

            if ((pYlim[1] - pYlim[0]) != 0)
                mY = graph_rect_obj.Height / (pYlim[1] - pYlim[0]);
            else
                mY = 0;

            // calculate x intercept
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
            else 
            {
                // put the line on the edge of the graph
                XAxis[0].X = graph_rect_obj.Left;
                XAxis[0].Y = graph_rect_obj.Bottom;
                XAxis[1].X = graph_rect_obj.Right;
                XAxis[1].Y = graph_rect_obj.Bottom;
            }

            // calculate y intercept
            if ((pYlim[0] < 0) && (pYlim[1] > 0))
            {
                float pixY = (0 - pYlim[0]) * mY;

                YAxis[0].X = graph_rect_obj.Left;
                YAxis[0].Y = pixY + graph_rect_obj.Top;

                YAxis[1].X = graph_rect_obj.Right;
                YAxis[1].Y = pixY + graph_rect_obj.Top;
            }
            else
            {
                // put line on edge of graph
                YAxis[0].X = graph_rect_obj.Left;
                YAxis[0].Y = graph_rect_obj.Top;
                YAxis[1].X = graph_rect_obj.Left;
                YAxis[1].Y = graph_rect_obj.Bottom;
            }

            // determine number of pixels for each string
            float num_pix = mem_graphic.g.MeasureString("000.000", horzAxisFont).Width;
            num_hashs = (int) Math.Floor((double) graph_rect_obj.Width / (num_pix));


            // part that needs rewrite
            // determines spacing for 10 hash marks
            float hashXSpace = (pXlim[1] - pXlim[0]) / (num_hashs -1);
            float hashYSpace = (pYlim[1] - pYlim[0]) / (num_hashs -1);            

            float hash_length = graph_rect_obj.Height * .02f;

            float j = pXlim[0];
            float k = pYlim[0];

            if (num_hashs > 0)
            {
                XHashPos = CalcAxPos(Xlim, num_hashs);
                YHashPos = CalcAxPos(Ylim, num_hashs);
            }

            TopRule = new PointF[num_hashs,2];
            BottomRule = new PointF[num_hashs, 2];
            LeftRule = new PointF[num_hashs, 2];
            RightRule = new PointF[num_hashs, 2];
            XHashLabelRects = new RectangleF[num_hashs];
            YHashLabelRects = new RectangleF[num_hashs];

            float XHashCords = 0;
            float YHashCords = 0;
            int i;

            // determine the hash tick positions
            if (XHashPos != null)
            {
                for (i = 0; i < XHashPos.Length; i++)
                {
                    // need to save the cordinates to label the graph
                    XHashCords = (float)(XHashPos[i] - pXlim[0]) * mX;

                    TopRule[i, 0].X = XHashCords + graph_rect_obj.Left;
                    TopRule[i, 0].Y = graph_rect_obj.Top;
                    TopRule[i, 1].X = XHashCords + graph_rect_obj.Left;
                    TopRule[i, 1].Y = graph_rect_obj.Top + hash_length;

                    BottomRule[i, 0].X = XHashCords + graph_rect_obj.Left;
                    BottomRule[i, 0].Y = graph_rect_obj.Bottom - hash_length;
                    BottomRule[i, 1].X = XHashCords + graph_rect_obj.Left;
                    BottomRule[i, 1].Y = graph_rect_obj.Bottom;

                    XHashLabelRects[i].X = XHashCords + graph_rect_obj.Left - 20;
                    XHashLabelRects[i].Y = graph_rect_obj.Bottom + 2;
                    XHashLabelRects[i].Width = 40;
                    XHashLabelRects[i].Height = 14;
                }

                for (i = 0; i < YHashPos.Length; i++)
                {
                    YHashCords = (float)(YHashPos[i] - pYlim[0]) * mY;

                    LeftRule[i, 0].X = graph_rect_obj.Left;
                    LeftRule[i, 0].Y = graph_rect_obj.Bottom - YHashCords;
                    LeftRule[i, 1].X = graph_rect_obj.Left + hash_length;
                    LeftRule[i, 1].Y = graph_rect_obj.Bottom - YHashCords;

                    RightRule[i, 0].X = graph_rect_obj.Right - hash_length;
                    RightRule[i, 0].Y = graph_rect_obj.Bottom - YHashCords;
                    RightRule[i, 1].X = graph_rect_obj.Right;
                    RightRule[i, 1].Y = graph_rect_obj.Bottom - YHashCords;

                    YHashLabelRects[i].X = graph_rect_obj.Left - 42;
                    YHashLabelRects[i].Y = graph_rect_obj.Bottom - YHashCords - 6;
                    YHashLabelRects[i].Width = 40;
                    YHashLabelRects[i].Height = 14;
                }
            }
            RemoveExponentEngr(XHashPos, Xlim); 

            // convert the data to plot into pixel values
            for(i = 0; i < data_list_obj.Count; i++)
            {
                data_list_obj[i].cords = PointsToCordinates(data_list_obj[i].x_vals, data_list_obj[i].y_vals);
                //d.cords = PointsToCordinates(d.x_vals, d.x_vals);
            }
        }

        private double[] CalcAxPos(float[] lims, int i_max_ticks)
        {
            double dX = lims[1] - lims[0];
            double PdX = Math.Floor(Math.Log10(dX));
            double[] space = new double[] { 5, 2, 1, .5 };
            double xmin, xmax;
            double num_pts = 0;
            int i;

            for(i = 0; i < space.Length; i++)
            {
                xmin = space[i] * Math.Pow(10, PdX) * Math.Ceiling(lims[0] / (space[i] * Math.Pow(10, PdX)));
                xmax = space[i] * Math.Pow(10, PdX) * Math.Floor(lims[1] / (space[i] * Math.Pow(10, PdX)));
                num_pts = (xmax - xmin) / (space[i] * Math.Pow(10, PdX)) + 1.0;
                if ((num_pts > i_max_ticks) && (xmax > xmin))
                    break;
            }

            if (i > 0)
                i--; // decrement counter by 1

            xmin = space[i] * Math.Pow(10, PdX) * Math.Ceiling(lims[0] / (space[i] * Math.Pow(10, PdX)));
            xmax = space[i] * Math.Pow(10, PdX) * Math.Floor(lims[1] / (space[i] * Math.Pow(10, PdX)));
            num_pts = (xmax - xmin) / (space[i] * Math.Pow(10, PdX)) + 1.0;

            double[] ticks = new double[(int) num_pts];
            dX = space[i] * Math.Pow(10, PdX);

            for (i = 0; i < (int) num_pts; i++)
            {
                ticks[i] = (float)i * dX + xmin;
            }

            return (ticks);
        }

        private Point[] PointsToCordinates(double[] x, double[] y)
        {
            // Assume x & y are of same length
            Point []cords = new Point[x.Length];
            for (int i = 0; i < x.Length; i++)
            {
                cords[i].X = (int)Math.Round((x[i] - Xlim[0]) * mX + graph_rect_obj.Left);
                cords[i].Y = (int)Math.Round(graph_rect_obj.Bottom - (y[i] - Ylim[0]) * mY);
                if (cords[i].X > graph_rect_obj.Right)
                    cords[i].X = (int) graph_rect_obj.Right;
                if (cords[i].Y < graph_rect_obj.Top + 10) // the +10 is a hack graph_rect_obj.Top should 
                                                          // be the top of the box
                    cords[i].Y = (int) graph_rect_obj.Top +10;
            }
            return cords;
        }

        private int RemoveExponentEngr(double[] data, float[] lim)
        {
            double d_abs_max;
            if (Math.Abs(lim[0]) > Math.Abs(lim[1]))
            {
                d_abs_max = Math.Abs(lim[0]);
            }
            else
            {
                d_abs_max = Math.Abs(lim[1]);
            }

            double l_exponent = Math.Log10(d_abs_max);

            int l_botttom = (int)Math.Floor(l_exponent) - 1;

            l_botttom = (int)Math.Floor((double)l_botttom / 3);

            // rescale the data
            if (data != null)
            {
                for (int i = 0; i < data.Length; i++)
                {
                    data[i] = data[i] / (float)Math.Pow(10.0, l_botttom * 3);
                }
            }

            return (l_botttom);
        }

        private double Min(double[] data_arr)
        {
            double l_min = data_arr[0];

            foreach(double d in data_arr)
            {
                if( d < l_min)
                {
                    l_min = d;
                }
            }

            return(l_min);
        }

        private double Max(double[] data_arr)
        {
            double l_max = data_arr[0];

            foreach (double d in data_arr)
            {
                if (d < l_max)
                {
                    l_max = d;
                }
            }
            return (l_max);
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            // required to view control in windows form editor
            if (mem_graphic.CanDoubleBuffer() == false)
            {
                mem_graphic.CreateDoubleBuffer(this.CreateGraphics(), this.ClientRectangle.Width, this.ClientRectangle.Height);
            }

            if (mem_graphic.CanDoubleBuffer())
            {
                // if the size of the control changed everything needs to be recalulated
                if ((this.Size.Height != control_rect_obj.Height)
                    || (this.Size.Width != control_rect_obj.Width))
                {
                    //control_rect_obj = e.ClipRectangle;
                    control_rect_obj.Height = this.Size.Height;
                    control_rect_obj.Width = this.Size.Width;
                    Calc_Obj_Postitions();
                }

                // Control rectangle contains subrectagle for data called
                // grah_rect_obj. This paints the background surrounding
                // this rectangle. 
                SolidBrush b_obj = new SolidBrush(this.BackColor);

                mem_graphic.g.FillRectangle(b_obj, top_rect);
                mem_graphic.g.FillRectangle(b_obj, bottom_rect);
                mem_graphic.g.FillRectangle(b_obj, left_rect);
                mem_graphic.g.FillRectangle(b_obj, right_rect);


                // Draw the graph_rect_obj, graph rectangle inside of control
                mem_graphic.g.FillRectangle(Brushes.White, graph_rect_obj);
                mem_graphic.g.DrawRectangle(Pens.Black, Rectangle.Round(graph_rect_obj));

                // Draw the x & y intercepts
                mem_graphic.g.DrawLine(Pens.Black, XAxis[0], XAxis[1]);
                mem_graphic.g.DrawLine(Pens.Black, YAxis[0], YAxis[1]);

                int i;
                // TODO: rescale tickmarks withs size of font
                // rule the graph window with tick marks
                for (i = 0; i < XHashPos.Length; i++)
                {
                    mem_graphic.g.DrawLine(Pens.Black, TopRule[i, 0], TopRule[i, 1]);
                    mem_graphic.g.DrawLine(Pens.Black, BottomRule[i, 0], BottomRule[i, 1]);                                      
                    mem_graphic.g.DrawString(XHashPos[i].ToString("###.000"), horzAxisFont, Brushes.Black, XHashLabelRects[i], horzDrawString);
                }
                for (i = 0; i < YHashPos.Length; i++)
                {     
                    mem_graphic.g.DrawLine(Pens.Black, LeftRule[i, 0], LeftRule[i, 1]);
                    mem_graphic.g.DrawLine(Pens.Black, RightRule[i, 0], RightRule[i, 1]);
                    mem_graphic.g.DrawString(YHashPos[i].ToString("###.000"), virtAxisFont, Brushes.Black, YHashLabelRects[i], virtDrawString);
                }


                // draw the data
                foreach (data_set d in data_list_obj)
                {
                    Pen p = new Pen(d.color_obj, 2);
                    if (d.x_vals.Length > 2)
                    {
                        mem_graphic.g.DrawLines(p, d.cords);
                        foreach (Point p2 in d.cords)
                            if (p2.Y < graph_rect_obj.Top)
                                MessageBox.Show("error");
                    }
                }
            }
            // render the double buffer onto the screen
            mem_graphic.Render(e.Graphics);            
            base.OnPaint(e);
        }
    }

    class data_set
    {
        public string name = "";
        public double[] x_vals;
        public double[] y_vals;
        public Point[] cords;
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