using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace GraphControl
{
    public class GraphData
    {
        public string m_data_name;
        private Pen m_pen;
        private Point []m_pixel_cords;
        private double []m_x_vals;
        private double []m_y_vals;

        public GraphData(string str_data, Axis axis_obj, Color color_obj, int width, double []x_vals, double []y_vals)
        {
            m_data_name = str_data;
            m_pen = new Pen(color_obj, width);
            m_x_vals = x_vals;
            m_y_vals = y_vals;
            Resize(axis_obj);            
        }

        public void Resize(Axis axis_obj)
        {
            m_pixel_cords = axis_obj.DataPtsToPixelCords(m_x_vals, m_y_vals);
        }

        public void Paint(Graphics g)
        {
            g.DrawLines(m_pen, m_pixel_cords);
        }
    }

    public class GraphDataList
    {
        List <GraphData> data_list = new List<GraphData>();
        Axis m_axis_obj;

        public GraphDataList(Axis axis_obj)
        {
            m_axis_obj = axis_obj;
        }

        public void Add(string data_name, double []m_x_vals, double []m_y_vals, Color color_obj, int width)
        {
            GraphData d_rm = (GraphData) null;

            // if this name already exists remove it
            foreach (GraphData data_obj in data_list)
            {
                if (data_obj.m_data_name.Equals(data_name))
                {
                    d_rm = data_obj;
                }
            }
            
            if (d_rm != null)
                data_list.Remove(d_rm);

            data_list.Add(new GraphData(data_name, m_axis_obj, color_obj, width, m_x_vals, m_y_vals));
        }

        public void Resize(Axis axis_obj)
        {
            m_axis_obj = axis_obj;

            foreach (GraphData d_obj in data_list)
            {
                d_obj.Resize(axis_obj);
            }
        }

        public void Paint(Graphics g)
        {
            foreach (GraphData d_obj in data_list)
            {
                d_obj.Paint(g);
            }
        }
    }
}
