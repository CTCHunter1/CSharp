using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace GraphControl
{
    public class Border
    {
        // rectagles to draw
        private Rectangle m_top_rect = new Rectangle();
        private Rectangle m_bottom_rect = new Rectangle();
        private Rectangle m_left_rect = new Rectangle();
        private Rectangle m_right_rect = new Rectangle();
        private SolidBrush m_brush = new SolidBrush(Color.Gray);

        public Border()
        {
        }

        public Border(Rectangle outside_rect, Rectangle inside_rect, Color color)
        {
            Resize(outside_rect, inside_rect);
            m_brush.Color = color;
        }

        public Color Color
        {
            get
            {
                return (m_brush.Color);
            }
            set
            {
                m_brush.Color = Color;
            }
        }

        public void Paint(Graphics g)
        {
            // draw the 4 rectangles
            g.FillRectangle(m_brush, m_top_rect);
            g.FillRectangle(m_brush, m_bottom_rect);
            g.FillRectangle(m_brush, m_left_rect);
            g.FillRectangle(m_brush, m_right_rect);
        }

        public void Resize(Rectangle outside_rect, Rectangle inside_rect)
        {
            // Size the 4 rectangles
            m_top_rect.Location = outside_rect.Location;
            m_top_rect.Width = outside_rect.Width;
            m_top_rect.Height = inside_rect.Top - outside_rect.Top;

            m_bottom_rect.X = outside_rect.X;
            m_bottom_rect.Y = inside_rect.Bottom;
            m_bottom_rect.Width = outside_rect.Width;
            m_bottom_rect.Height = outside_rect.Bottom - inside_rect.Bottom;

            m_left_rect.Location = outside_rect.Location;
            m_left_rect.Width = inside_rect.Left - outside_rect.Left;
            m_left_rect.Height = outside_rect.Height;

            m_right_rect.X = inside_rect.Right;
            m_right_rect.Y = outside_rect.Y;
            m_right_rect.Width = outside_rect.Right - inside_rect.Right;
            m_right_rect.Height = outside_rect.Height;
        }
    }
}
