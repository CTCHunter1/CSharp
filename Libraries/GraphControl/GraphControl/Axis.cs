using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace GraphControl
{
    public class Axis
    {
        AxisType axisType = AxisType.LinLin;

        private double[] m_xlim = { -10, 10 };
        private double[] m_ylim = { -10, 10 };

        private double m_dX;
        private double m_dY;

        private double m_mX;
        private double m_mY;

        private Font m_vert_axis_font = new Font("Arial", 10, FontStyle.Regular, GraphicsUnit.Pixel);
        private Font m_horz_axis_font = new Font("Arial", 10, FontStyle.Regular, GraphicsUnit.Pixel);

        // the data positions for each of the hashes
        private double [] m_xhash_DataPos;
        private double [] m_yhash_DataPos;

        private Point[,] m_top_rule;
        private Point[,] m_bottom_rule;
        private Point[,] m_left_rule;
        private Point[,] m_right_rule;

        private Rectangle []m_x_hash_labels;
        private Rectangle []m_y_hash_labels;
        private double[] m_x_hash_labelPos;

        private Point []m_xIntercept = new Point[2];
        private Point []m_yIntercept = new Point[2];
        
        private Rectangle m_control_rect;
        private Rectangle m_graph_rect = new Rectangle();

        private SolidBrush m_graph_bkgnd = new SolidBrush(Color.White);

        private StringFormat m_horz_draw_string = new StringFormat();       // formats the string for horz ticks
        private StringFormat m_virt_draw_string = new StringFormat();       // formats the string for virt ticks

        private SizeF m_horz_sz;
        private SizeF m_vert_sz;

        private Graphics g_obj;         // used to measure string sizes
        
        public Axis()
        {
        }

        public Axis(Rectangle control_rect, Graphics g)
        {
            m_horz_draw_string.Alignment = StringAlignment.Center;
            m_virt_draw_string.Alignment = StringAlignment.Far;
           

            // get the size of these strings on the display
            m_horz_sz = g.MeasureString("-000.00", m_horz_axis_font);
            m_vert_sz = g.MeasureString("-000.00", m_vert_axis_font);

            Resize(control_rect, g);

            CreateIntercepts();
            CreateHashes();
        }

        public double[] XLim
        {
            get
            {
                switch(axisType)
                {   
                    case AxisType.LinLog:
                        return (new double[2] { Math.Pow(10, m_xlim[0]), Math.Pow(10, m_xlim[1]) });

                    case AxisType.LinLin:
                    default:
                    return (m_xlim);
                }
            }
            set
            {
                switch(axisType)
                {
                    case AxisType.LinLog:
                        m_xlim = new double[2] { Math.Log10(value[0]), Math.Log10(value[1]) };
                        break;

                    case AxisType.LinLin:
                    default:
                        m_xlim = value;
                        break;
                }
                Resize(m_control_rect, g_obj);                        
            }
        }

        public double[] YLim
        {
            get
            {
                return (m_ylim);
            }
            set
            {
                m_ylim = value;
                Resize(m_control_rect, g_obj);
            }
        }

        public Font VertAxisFont
        {
            get
            {
                return (m_vert_axis_font);
            }
            set
            {
                m_vert_axis_font = value;
            }
        }

        public Font HorzAxisFont
        {
            get
            {
                return (m_horz_axis_font);
            }
            set
            {
                m_horz_axis_font = value;
            }
        }

        public Color GraphBackground
        {
            get
            {
                return (m_graph_bkgnd.Color);
            }
            set
            {
                m_graph_bkgnd.Color = value;
            }
        }

        public Rectangle Graph_Rect
        {
            get
            {
                return (m_graph_rect);
            }
        }

        public AxisType PlotType
        {
            get
            {
                return axisType;
            }
            set
            {
                // do nothing
                if (value == axisType)
                    return;
                
                switch (value)
                {
                    case AxisType.LinLog:
                        m_xlim[0] = Math.Log10(this.XLim[0]);
                        m_xlim[1] = Math.Log10(this.XLim[1]);
                        break;


                    case AxisType.LinLin:
                    default:
                        m_xlim[0] = this.XLim[0];
                        m_xlim[1] = this.XLim[1];
                        break;
                }

                axisType = value;                
                Resize(m_control_rect, g_obj);
            }
        }

        // Resize reinitalized the controll too
        public void Resize(Rectangle control_rect, Graphics g)
        {
            g_obj = g;
            m_control_rect = control_rect;

            m_graph_rect.X = Convert.ToInt32(m_vert_sz.Width*1.1);
            m_graph_rect.Y = Convert.ToInt32(m_vert_sz.Height/2);
            m_graph_rect.Width = control_rect.Width - m_graph_rect.X - (int) m_horz_sz.Width/2;
            m_graph_rect.Height = Convert.ToInt32(control_rect.Height - m_horz_sz.Height * 1.5 - m_graph_rect.Y);

            m_dX = m_xlim[1] - m_xlim[0];
            m_dY = m_ylim[1] - m_ylim[0];
            
            if (m_dX != 0)
            {
                m_mX = (double)m_graph_rect.Width / m_dX;
            }
            if (m_dY != 0)
            {
                m_mY = (double)m_graph_rect.Height / m_dY;
            }

            CreateIntercepts();
                    
            switch(axisType)
            {
                case AxisType.LinLog:
                    CreateHashes();

                    break;


                case AxisType.LinLin:
                default:
                    CreateHashes();
                break;
            }
        }

        public void Rescale()
        {
            
        }
        
        public void Paint(Graphics g)
        {
            g_obj = g;

            //fill the graph rectangle
            g.FillRectangle(m_graph_bkgnd, m_graph_rect);

            // Draw black line around graph rectangle
            g.DrawRectangle(Pens.Black, m_graph_rect);
            

            // paint x & y intercepts
            // Draw the x & y intercepts
            g.DrawLine(Pens.Black, m_xIntercept[0], m_xIntercept[1]);
            g.DrawLine(Pens.Black, m_yIntercept[0], m_yIntercept[1]);

            int i;

            // draw the x hashes
            for (i = 0; i < m_xhash_DataPos.Length; i++)
            {
                // draw the ticks on the top then those on the bottom
                g.DrawLine(Pens.Black, m_top_rule[i, 0], m_top_rule[i, 1]);
                g.DrawLine(Pens.Black, m_bottom_rule[i, 0], m_bottom_rule[i, 1]);
                // only label the ticks on the bottom
            }

            for (i = 0; i < m_x_hash_labelPos.Length; i++)
            {
                g.DrawString(m_x_hash_labelPos[i].ToString("##0.00"), m_horz_axis_font, Brushes.Black, m_x_hash_labels[i], m_horz_draw_string);                  
            }

            // draw the y hashes
            for (i = 0; i < m_yhash_DataPos.Length; i++)
            {
                // draw the ticks on the right then the one's on the left
                g.DrawLine(Pens.Black, m_left_rule[i, 0], m_left_rule[i, 1]);
                g.DrawLine(Pens.Black, m_right_rule[i, 0], m_right_rule[i, 1]);
                // only label ticks on the left
                g.DrawString(m_yhash_DataPos[i].ToString("##0.00"), m_vert_axis_font, Brushes.Black, m_y_hash_labels[i], m_virt_draw_string);                  

            }

        }

        private void CreateIntercepts()
        {
            // the x intercept
            if ((m_xlim[0] < 0) && (m_xlim[1] > 0)) // check that intercepts are on graph
            {
                switch (axisType)
                {   
                    case AxisType.LinLog:
                        m_xIntercept[0] = DataPtToPixelCord(Math.Pow(10,m_xlim[0]), 0);
                        m_xIntercept[1] = DataPtToPixelCord(Math.Pow(10,m_xlim[1]), 0);
                        break;

                    default:
                    case AxisType.LinLin:
                        m_xIntercept[0] = DataPtToPixelCord(m_xlim[0], 0);
                        m_xIntercept[1] = DataPtToPixelCord(m_xlim[1], 0);   
                        break;
                }
            }
            else
            {   // no intercepts
                m_xIntercept[0] = m_graph_rect.Location;
                m_xIntercept[1] = m_xIntercept[0];
            }
            
            switch(axisType)
            {
                case AxisType.LinLog:
                    // there is no y intercept;
                    m_xIntercept[0] = m_graph_rect.Location;
                    m_xIntercept[1] = m_xIntercept[0];                    
                    break;

                case AxisType.LinLin:
                default:
                    // the y intercept
                    if ((m_ylim[0] < 0) && (m_ylim[1] > 0))
                    {
                        m_yIntercept[0] = DataPtToPixelCord(0, m_ylim[0]);
                        m_yIntercept[1] = DataPtToPixelCord(0, m_ylim[1]);
                    }
                    else
                    {
                        m_yIntercept[0] = m_graph_rect.Location;
                        m_yIntercept[1] = m_yIntercept[0];
                    }
                    break;
            }
        }

        // sensitive code 
        private void CreateHashes()
        {         
            // get the size of these strings on the display
            try
            {
                m_horz_sz = g_obj.MeasureString("-000.00", m_horz_axis_font);
                m_vert_sz = g_obj.MeasureString("-000.00", m_vert_axis_font);
            }
            catch (Exception e)
            {

            }
            
            // calculates how many hases can fit horizontal and verticle
            int i_max_hashes_x = (int)(m_graph_rect.Width / (m_horz_sz.Width * 1));
            int i_max_hashes_y = (int)(m_graph_rect.Width / (m_vert_sz.Height * 2));

            // find where the hashes should be scored in graph units
            switch (axisType)
            {
                case AxisType.LinLog:
                    m_xhash_DataPos = CalcHashPositionsLog(m_xlim);
                    m_yhash_DataPos = CalcHashPositions(m_ylim, i_max_hashes_y);
                    m_x_hash_labelPos = CalcHashLabelsLog(m_xhash_DataPos);
                    m_x_hash_labels = new Rectangle[m_x_hash_labelPos.Length];
                    break;

                case AxisType.LinLin:
                default:
                    m_xhash_DataPos = CalcHashPositions(m_xlim, i_max_hashes_x);
                    m_x_hash_labels = new Rectangle[m_xhash_DataPos.Length];
                    m_yhash_DataPos = CalcHashPositions(m_ylim, i_max_hashes_y);
                    // in this case the labels are at the same points as the hashes
                    m_x_hash_labelPos = m_xhash_DataPos;
                    break;
            }

            // create arrays for hash points for each side of the graph
            m_top_rule = new Point[m_xhash_DataPos.Length, 2];
            m_bottom_rule = new Point[m_xhash_DataPos.Length, 2];

            m_left_rule = new Point[m_yhash_DataPos.Length, 2];
            m_right_rule = new Point[m_yhash_DataPos.Length, 2];

            // create locations rectangles to place the data position lables in for each side of the graph            
            m_y_hash_labels = new Rectangle[m_yhash_DataPos.Length];
     
            int i;  // reusable counter

            switch (axisType)
            {
                case AxisType.LinLog:
                    for (i = 0; i < m_xhash_DataPos.Length; i++)
                    {
                        m_top_rule[i, 0] = DataPtToPixelCord(m_xhash_DataPos[i], m_ylim[1]);
                        m_top_rule[i, 1].X = m_top_rule[i, 0].X;
                        m_top_rule[i, 1].Y = (int)(m_top_rule[i, 0].Y + m_graph_rect.Height * .02);     // plot the ticks to be 2% of the graph

                        m_bottom_rule[i, 0] = DataPtToPixelCord(m_xhash_DataPos[i], m_ylim[0]);
                        m_bottom_rule[i, 1].X = m_bottom_rule[i, 0].X;
                        m_bottom_rule[i, 1].Y = (int)(m_bottom_rule[i, 0].Y - (int)m_graph_rect.Height * .02);
                    }

                    // create rectangles for writting the hash mark positions
                    for (i = 0; i < m_x_hash_labelPos.Length; i++)
                    {
                        Point tempPt = DataPtToPixelCord(m_x_hash_labelPos[i], m_ylim[0]);
                        // create rectangle for text label
                        m_x_hash_labels[i].Width = (int)m_horz_sz.Width;
                        m_x_hash_labels[i].Height = (int)m_horz_sz.Height;
                        m_x_hash_labels[i].X = Convert.ToInt32(tempPt.X - m_horz_sz.Width / 2);
                        m_x_hash_labels[i].Y = Convert.ToInt32(tempPt.Y + 4);
                    }
    
                    // vertically ruled hashes (on the left and right)
                    for (i = 0; i < m_yhash_DataPos.Length; i++)
                    {
                        m_left_rule[i, 0] = DataPtToPixelCord(Math.Pow(10,m_xlim[0]), m_yhash_DataPos[i]);
                        m_left_rule[i, 1].Y = m_left_rule[i, 0].Y;
                        m_left_rule[i, 1].X = (int)(m_left_rule[i, 0].X + (int)m_graph_rect.Width * .02);

                        m_right_rule[i, 0] = DataPtToPixelCord(Math.Pow(10,m_xlim[1]), m_yhash_DataPos[i]);
                        m_right_rule[i, 1].Y = m_right_rule[i, 0].Y;
                        m_right_rule[i, 1].X = (int)(m_right_rule[i, 0].X - (int)m_graph_rect.Width * .02);

                        m_y_hash_labels[i].Width = (int)m_vert_sz.Width;
                        m_y_hash_labels[i].Height = (int)m_vert_sz.Height;
                        m_y_hash_labels[i].X = Convert.ToInt32(m_left_rule[i, 0].X - m_vert_sz.Width - 2);
                        m_y_hash_labels[i].Y = Convert.ToInt32(m_left_rule[i, 0].Y - m_vert_sz.Height / 2);
                    }                
                    break;

                case AxisType.LinLin:
                default:
                    // horizontally ruled hashes (on the top and bottom)
                    for (i = 0; i < m_xhash_DataPos.Length; i++)
                    {
                        m_top_rule[i, 0] = DataPtToPixelCord(m_xhash_DataPos[i], m_ylim[1]);
                        m_top_rule[i, 1].X = m_top_rule[i, 0].X;
                        m_top_rule[i, 1].Y = (int)(m_top_rule[i, 0].Y + m_graph_rect.Height * .02);     // plot the ticks to be 2% of the graph

                        m_bottom_rule[i, 0] = DataPtToPixelCord(m_xhash_DataPos[i], m_ylim[0]);
                        m_bottom_rule[i, 1].X = m_bottom_rule[i, 0].X;
                        m_bottom_rule[i, 1].Y = (int)(m_bottom_rule[i, 0].Y - (int)m_graph_rect.Height * .02);

                        // create rectangle for text label only on the left side
                        m_x_hash_labels[i].Width = (int)m_horz_sz.Width;
                        m_x_hash_labels[i].Height = (int)m_horz_sz.Height;
                        m_x_hash_labels[i].X = Convert.ToInt32(m_bottom_rule[i, 0].X - m_horz_sz.Width / 2);
                        m_x_hash_labels[i].Y = Convert.ToInt32(m_bottom_rule[i, 0].Y + 4);
                    }

                    // vertically ruled hashes (on the left and right)
                    for (i = 0; i < m_yhash_DataPos.Length; i++)
                    {
                        m_left_rule[i, 0] = DataPtToPixelCord(m_xlim[0], m_yhash_DataPos[i]);
                        m_left_rule[i, 1].Y = m_left_rule[i, 0].Y;
                        m_left_rule[i, 1].X = (int)(m_left_rule[i, 0].X + (int)m_graph_rect.Width * .02);

                        m_right_rule[i, 0] = DataPtToPixelCord(m_xlim[1], m_yhash_DataPos[i]);
                        m_right_rule[i, 1].Y = m_right_rule[i, 0].Y;
                        m_right_rule[i, 1].X = (int)(m_right_rule[i, 0].X - (int)m_graph_rect.Width * .02);

                        // create rectangle for text lable only on right side
                        m_y_hash_labels[i].Width = (int) m_vert_sz.Width;
                        m_y_hash_labels[i].Height = (int) m_vert_sz.Height;
                        m_y_hash_labels[i].X = Convert.ToInt32(m_left_rule[i, 0].X - m_vert_sz.Width - 2);
                        m_y_hash_labels[i].Y = Convert.ToInt32(m_left_rule[i, 0].Y - m_vert_sz.Height / 2);
                    }
                break;
            }
        }

        private double[] CalcHashPositions(double[] lims, int i_max_hashes)
        {
            // if the maximum hashes is zero just return
            if (i_max_hashes <= 0)
                return (new double[0]);

            // if the limits are invalid return
            if (lims.Length < 2)
                return (new double[0]);

            // spacings between hash marks
            // after we remove power of 10 width varies betweeen 10-1
            double[] space = new double[] { 5, 2, 1, .5, .2, .1, .05};

            double W = lims[1] - lims[0];               // With of axis
            
            if (W == 0)
                W = 1;
            
            double PW = Math.Floor(Math.Log10(W));      // lowest power of 10 of the width
            double xmin, xmax;                          // minimum and maximum values for the hashes
            double num_hashs = 0;                       // total number of hashes
            int i;                                      // a counter for the loops
                        
            for (i = 0; i < space.Length; i++)
            {
                // find highest and lowest tick position
                xmin = space[i] * Math.Pow(10, PW) * Math.Ceiling(lims[0] / (space[i] * Math.Pow(10, PW)));
                xmax = space[i] * Math.Pow(10, PW) * Math.Floor(lims[1] / (space[i] * Math.Pow(10, PW)));
                num_hashs = (xmax - xmin) / (space[i] * Math.Pow(10, PW)) + 1;
                if ((num_hashs > i_max_hashes) && (xmax > xmin))
                    break;
            }

            if (i > 0)
                i--;    // over incremented by 1

            // recalculate
            xmin = space[i] * Math.Pow(10, PW) * Math.Ceiling(lims[0] / (space[i] * Math.Pow(10, PW)));
            xmax = space[i] * Math.Pow(10, PW) * Math.Floor(lims[1] / (space[i] * Math.Pow(10, PW)));
            num_hashs = (xmax - xmin) / (space[i] * Math.Pow(10, PW)) + 1;

            double[] pos_arr = new double[(int)num_hashs];
            double dX = space[i] * Math.Pow(10, PW);

            for (i = 0; i < (int)num_hashs; i++)
            {
                pos_arr[i] = (double)i * dX + xmin;
            }

            return (pos_arr);
        }

        private double[] CalcHashPositionsLog(double[] lims)
        {
            // if the limits are invalid return
            if (lims.Length < 2)
                return (new double[0]);
    

            double lowOrder = Math.Floor(lims[0]);      // order meaning power of 10
            double highOrder = Math.Floor(lims[1]);

            // find the low tick number, requires searching
            double lowTickValue = 0;
            int iTickLow = 0;
            // find the nearest int to the higher on the lower limit
            for (iTickLow = 1; iTickLow <= 10; iTickLow++)
            {
                if (Math.Log10((double)iTickLow) >= (lims[0] - lowOrder))
                {
                    lowTickValue = (double)iTickLow * Math.Pow(10, lowOrder);
                    break;
                }
            }

            // find the high tick number
            double highTickValue = 0;
            int iTickHigh = 0;
            // find the nearest int to the lower on the upper limit
            for (iTickHigh = 10; iTickHigh >= 1; iTickHigh--)
            {
                if (Math.Log10((double)iTickHigh) <= (lims[1] - highOrder))
                {
                    // i've caught myself multipling by zero here a few times
                    highTickValue = (double)iTickHigh * Math.Pow(10, highOrder);
                    break;
                }
            }
                        
            // if the high tick value is less than the low tick value points are between two ticks
            // no hashes, untested
            if (highTickValue < lowTickValue)
                return (new double[0]);

            // if they are equal there is only 1 tick
            if (highTickValue == lowTickValue)
            {
                return (new double[1]{highTickValue});
            }

            // create ticks from the low tick value to the high tick value
            // Number of ticks
            int iNumTicks = 9*(int)(highOrder - lowOrder)+(iTickHigh - iTickLow + 1);
            double [] retTicks = new double[iNumTicks];
            int index = 0;

            // two cases depending on the order difference
            if ((highOrder - lowOrder) == 0)
            {
                // start at the low tick and work up to the high one
                int iAccum = iTickLow;
                for (index = 0; index < iNumTicks; index++)
                {
                    retTicks[index] = iAccum * Math.Pow(10, lowOrder);
                    iAccum++;
                }

                return (retTicks);
            }

            int iOrderAccum = (int) lowOrder;
            int iTickAccum = iTickLow;
            index = 0;
            // start at the low tick and work up to the decade
            for (; iTickAccum <= 10; iTickAccum++)
            {
                retTicks[index] = iTickAccum * Math.Pow(10, lowOrder);
                index++;
            }
            // increase the order until one behind the high Order
            iOrderAccum++;
            for (; iOrderAccum < highOrder; iOrderAccum++)
            {
                for (iTickAccum = 2; iTickAccum <= 10; iTickAccum++)
                {
                    retTicks[index] = iTickAccum * Math.Pow(10, (double)iOrderAccum);
                    index++;
                }
            }
            // increase to the high tick
            for (iTickAccum = 2; iTickAccum <= iTickHigh; iTickAccum++)
            {
                retTicks[index] = iTickAccum * Math.Pow(10, (double)iOrderAccum);
                index++;
            }

            return (retTicks);
        }

        double[] CalcHashLabelsLog(double[] hashes)
        {
            // count the hashes that are log10
            int iCount = 0;

            for (int i = 0; i < hashes.Length; i++)
            {
                if ((Math.Log10(hashes[i]) % 1) == 0)
                    iCount++;
            }

            double [] retArr = new double[iCount];

            int index = 0;
            for (int i = 0; i < hashes.Length; i++)
            {
                if ((Math.Log10(hashes[i]) % 1) == 0)
                {
                    retArr[index] = hashes[i];
                    index++;
                }
            }

            return (retArr);
        }

        public Point DataPtToPixelCord(double x, double y)
        {
            // the functions (try to) prevent off graph_rect drawing
            Point pt = new Point();
            
            switch(axisType)
            {
                case AxisType.LinLog:
                    pt.X = (int) Math.Round(((Math.Log10(x) - m_xlim[0]) * m_mX + m_graph_rect.Left));
                    pt.Y = (int) Math.Ceiling((m_graph_rect.Bottom - (y - m_ylim[0]) * m_mY));
                    break;

                default:
                case AxisType.LinLin:
                    pt.X = (int) Math.Round(((x - m_xlim[0]) * m_mX + m_graph_rect.Left));
                    pt.Y = (int) Math.Ceiling((m_graph_rect.Bottom - (y - m_ylim[0]) * m_mY));
                    break;                    
            }

            return (pt);
        }

        public Point[] DataPtsToPixelCords(double[] x, double[] y)
        {
            // unnecessary code to use the longer of x & y
            int max = x.Length;
            
            if (x.Length > y.Length)
                max = y.Length;

            // if there is no data return empty structure
            if (max < 1)
                return (new Point[0]);

            Point[] pts = new Point[max];

            for (int i = 0; i < max; i++)
            {
                pts[i] = DataPtToPixelCord(x[i], y[i]);
            }

            return (pts);
        }
    }
}
