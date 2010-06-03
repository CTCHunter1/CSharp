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
        Rectangle control_rect;     // rectangle represents size of contro
        Axis axis_obj;              // object prints the axis
        Border boarder_obj;
        GraphDataList graph_data_list; 
        
        DBGraphics db_graphics_obj; // double buffer object
        bool m_autoscale = true;

        public GraphControl()
        {
            // Initalize Objects
            control_rect = new Rectangle(0, 0, this.Size.Width, this.Size.Height);
            //graph_rect = new Rectangle(25, 10, control_rect.Width - 50, control_rect.Height - 50);
            db_graphics_obj = new DBGraphics();
            db_graphics_obj.CreateDoubleBuffer(this.CreateGraphics(), this.ClientRectangle.Width, this.ClientRectangle.Height);
            axis_obj = new Axis(control_rect, db_graphics_obj.g);
            boarder_obj = new Border(control_rect, axis_obj.Graph_Rect, this.BackColor);
            graph_data_list = new GraphDataList(axis_obj);
            InitializeComponent();            
            // XLim = new double[2]{-10, 30};
        }

        public double [] XLim
        {
            get
            {
                // the interface doesn't suport using double[]. Donno why
                return (new double[2]{axis_obj.XLim[0], axis_obj.XLim[1]});
            }
            set
            {
                axis_obj.XLim = new double[2] { value[0],  value[1]};
                graph_data_list.Resize(axis_obj);
                this.Invalidate();
            }
        }

        public double [] YLim
        {
            get
            {
                return (new double[2] {axis_obj.YLim[0], axis_obj.YLim[1] });
            }
            set
            {
                double[] yLim = new double[2] { value[0], value[1] };

                if (value[0] == value[1])
                {
                    yLim[0] = value[0] - value[0] / 2;
                    yLim[1] = value[1] + value[1] / 2;
                }

                if (value[0] > value[1])
                {
                    yLim[0] = value[1];
                    yLim[1] = value[0];
                }

                  axis_obj.YLim = yLim;
                graph_data_list.Resize(axis_obj);
                this.Invalidate();
            }
        }

        public bool AutoScale
        {
            get
            {
                return (m_autoscale);
            }
            set
            {
                m_autoscale = value;
            }
        }

        protected override void OnPaintBackground(PaintEventArgs e)
        {
            // must be disabled to stop blinking
            //base.OnPaintBackground(e);
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            // for some reason, the double buffer graphics object disappears when the 
            // application is minized, so if the graphics opject doesn't exist reinitalize it
            if (db_graphics_obj.g == null)
            {
                db_graphics_obj = new DBGraphics();
                db_graphics_obj.CreateDoubleBuffer(this.CreateGraphics(), this.ClientRectangle.Width, this.ClientRectangle.Height);
            }
              
             boarder_obj.Paint(db_graphics_obj.g);
             axis_obj.Paint(db_graphics_obj.g);
             graph_data_list.Paint(db_graphics_obj.g);
             if (db_graphics_obj.CanDoubleBuffer() == true)
                db_graphics_obj.Render(e.Graphics);
 	         base.OnPaint(e);
        }

        protected override void OnResize(EventArgs e)
        {
            db_graphics_obj.CreateDoubleBuffer(this.CreateGraphics(), this.ClientRectangle.Width, this.ClientRectangle.Height);
            control_rect.Width = this.Width;
            control_rect.Height = this.Height;
            //graph_rect.Width = control_rect.Width - 100;
            //graph_rect.Height = control_rect.Height - 50;

            axis_obj.Resize(control_rect, db_graphics_obj.g);
            graph_data_list.Resize(axis_obj);
            boarder_obj.Resize(control_rect, axis_obj.Graph_Rect);
            Invalidate(); // Force a repaint after has been resized 
            //base.OnResize(e);
        }

        public void Plot(string str_data_name, double[] x_vals, double[] y_vals, Color color_obj)
        {
            // need two points to plot
            if (x_vals.Length <= 1)
                return;

            if (m_autoscale)
            {
                double x_min_val = Min(x_vals);
                double x_max_val = Max(x_vals);
                double y_min_val = Min(y_vals);
                double y_max_val = Max(y_vals);

                axis_obj.XLim = new double[] {x_min_val, x_max_val};
                axis_obj.YLim = new double[] {y_min_val, y_max_val}; 

                // there is a problem if the minimum and maximum values are euqal
                // spread out the limits by 5% of the values
                if (x_min_val == x_max_val)
                    axis_obj.XLim = new double[] { x_min_val - Math.Abs(x_min_val) * .05, x_max_val + Math.Abs(x_max_val) * .05};
                                
                if (y_min_val == y_max_val)
                    axis_obj.YLim = new double[] { y_min_val - Math.Abs(y_min_val) * .05, y_max_val + Math.Abs(y_max_val) * .05 };                             
                
            }            
            graph_data_list.Add(str_data_name, x_vals, y_vals, color_obj, 1, AxisType.LinLin);
            this.Invalidate();
        }

        public void Semilogx(string str_data_name, double[] x_vals, double[] y_vals, Color color_obj)
        {
            if (m_autoscale)
            {
                double x_min_val = Min(x_vals);
                double x_max_val = Max(x_vals);
                double y_min_val = Min(y_vals);
                double y_max_val = Max(y_vals);

                // check for out of bounds x values
                if((x_min_val <= 0) || (x_max_val <= 0))
                {
                    Exception ex = new Exception("Semilogx limit less than zero invalid\r\n" +
                        "x_min_val = " + x_min_val + "\r\nxmax_val = " +x_max_val);
 
                    throw (ex);
                }
                axis_obj.XLim = new double[] { x_min_val, x_max_val };
                axis_obj.YLim = new double[] { y_min_val, y_max_val };

                // there is a problem if the minimum and maximum values are euqal
                // spread out the limits by 5% of the values
                if (x_min_val == x_max_val)
                    axis_obj.XLim = new double[] { x_min_val - Math.Abs(x_min_val) * .05, x_max_val + Math.Abs(x_max_val) * .05 };

                if (y_min_val == y_max_val)
                    axis_obj.YLim = new double[] { y_min_val - Math.Abs(y_min_val) * .05, y_max_val + Math.Abs(y_max_val) * .05 };
            }

            axis_obj.PlotType = AxisType.LinLog;
            graph_data_list.Add(str_data_name, x_vals, y_vals, color_obj, 1, AxisType.LinLog);
            this.Invalidate();
        }

        public void OnAxisChanged()
        {
            throw new System.NotImplementedException();
        }

        public double Min(double []data)
        {
            // make sure there is data
            
            if (data.Length < 1)
                return (0);

            double l_min = data[0];

            for (int i = 0; i < data.Length; i++)
            {
                if (l_min > data[i])
                    l_min = data[i];
            }

            return (l_min);
        }

        public double Max(double[] data)
        {
            // make sure there is data
            if (data.Length < 1)
                return (0);

            double l_max = data[0];

            for (int i = 0; i < data.Length; 
                
                i++)
            {
                if (l_max < data[i])
                    l_max = data[i];
            }

            return (l_max);
        }
    }
}