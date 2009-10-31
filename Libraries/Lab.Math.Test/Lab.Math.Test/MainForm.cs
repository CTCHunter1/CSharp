using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Text;
using System.Windows.Forms;

using Lab.Math;
using Lab.Math.NelderMeadSimplex;

namespace Lab.Math.Test
{
    public partial class MainForm : Form
    {
        double[] xData;
        double[] yData;

        double[] yDataFit;

        public MainForm()
        {
            InitializeComponent();
        }

        private void loadDataButton_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofdObj = new OpenFileDialog();
            if (ofdObj.ShowDialog() == DialogResult.OK)
            {

                char[] delimiterChars = { ',' };

                List<double> xData = new List<double>();
                List<double> yData = new List<double>();

                StreamReader srObj = new StreamReader(ofdObj.OpenFile());

                // read until end of stream
                while (srObj.EndOfStream != true)
                {
                    string strLine = srObj.ReadLine();
                    string[] values = strLine.Split(delimiterChars);

                    xData.Add(Convert.ToDouble(values[0]));
                    yData.Add(Convert.ToDouble(values[1]));
                }

                this.xData = xData.ToArray();
                this.yData = yData.ToArray();

                graphControl.Plot("Dat1", this.xData, this.yData, Color.Blue);
            }
        }

        private void fitButton_Click(object sender, EventArgs e)
        {
            ErfFit erfFitObj = new ErfFit();
            ErfFitResult erfFitResultObj = erfFitObj.Fit(xData, yData);

            Alabel.Text = erfFitResultObj.A.ToString();
            Blabel.Text = erfFitResultObj.B.ToString();
            Clabel.Text = erfFitResultObj.C.ToString();
            Dlabel.Text = erfFitResultObj.D.ToString();

            graphControl.Plot("FitData", xData, erfFitResultObj.YDataFit, Color.Red);
        }
    }
}