using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Lab.Drivers.PVCAM_Wrapper.Test
{
    public partial class GraphWindow : Form
    {
        public GraphWindow()
        {
            InitializeComponent();
        }

        public void GraphWindowPlot(String name, double[] xVals, double[] yVals, Color colorObj)
        {
            graphControl1.Plot(name, xVals, yVals, colorObj);
        }
    }
}
