using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace GraphControlTester
{
    public partial class GraphControlTester : Form
    {
        double [] yData = new double[100]; 
        double [] xData = new double[100]; 


        public GraphControlTester()
        {
            InitializeComponent();
            statusTextBox.Text = "";
        }
       
        // create new linspace of xData
        private double [] Linspace(double min, double max, int len)
        {
            if (len <= 1)
                len = 2;

            double[] retArr = new double[len];
            double dX = (max-min)/(double) (len-1);

            retArr[0] = min;

            for(int i= 1; i < len; i++)
            {
                retArr[i] = retArr[i - 1] + dX;  
            }

            return (retArr);
        }

        private double[] Logspace(double decMin, double decMax, int len)
        {
            if (len <= 1)
                len = 2;

            double[] retArr = new double[len];
            // find the min and max on the log scale
           
            double dXLog = (decMax - decMin) / (double)(len-1);

            // initalize a accumulator
            double accum = decMin;
            // create the data points
            for (int i = 0; i < len; i++)
            {
                retArr[i] = Math.Pow(10, accum);
                accum += dXLog;
            }

            return (retArr);
        }

        private double[] ArrMult(double[] xArr, double y)
        {
            double[] outArr = new double[xArr.Length];

            for (int i = 0; i < xArr.Length; i++)
            {
                outArr[i] = xArr[i] * y;
            }

            return (outArr);
        }

        private double[] ArrAdd(double [] xArr, double y)
        {
            double[] outArr = new double[xArr.Length];

            for (int i = 0; i < xArr.Length; i++)
            {
                outArr[i] = xArr[i] + y;
            }

            return (outArr);
        }

        private double[] ArrPow(double[] xArr, double y)
        {
            double[] outArr = new double[xArr.Length];

            for (int i = 0; i < xArr.Length; i++)
            {
                outArr[i] = Math.Pow(xArr[i], y);
            }

            return (outArr);

        }

        private double[] ArrLog10(double[] xArr)
        {
            double[] outArr = new double[xArr.Length];

            for (int i = 0; i < xArr.Length; i++)
            {
                outArr[i] = Math.Log10(xArr[i]);
            }

            return (outArr);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // tests the functionality of the GraphControl

            xData = Linspace(0, 10, 100);
            yData = ArrMult(xData, 1);
            graphControl1.Plot("Data1", xData, yData, Color.Blue);
            statusTextBox.Text = "Testing Plot y=x x=[0,0]";
            //MessageBox.Show("Correct?", "Result Confirm", MessageBoxButtons.OKCancel);

            xData = Linspace(-10, 10, 100);
            yData = ArrMult(xData, 0);
            statusTextBox.Text = "Testing Plot y=0 x=[-10,10]\r\n" + statusTextBox.Text;
            graphControl1.Plot("Data1", xData, yData, Color.Red);
            //MessageBox.Show("Correct?", "Result Confirm", MessageBoxButtons.OKCancel);


            yData = ArrAdd(yData, 2);
            statusTextBox.Text = "Testing Plot y=2 x=[-10,10]\r\n" + statusTextBox.Text;            
            graphControl1.Plot("Data1", xData, yData, Color.Red);
            //MessageBox.Show("Correct?", "Result Confirm", MessageBoxButtons.OKCancel);


            yData = ArrAdd(yData, -4);
            statusTextBox.Text = "Testing Plot y=-2 x=[-10,10]\r\n" + statusTextBox.Text;           
            graphControl1.Plot("Data1", xData, yData, Color.Blue);
            //MessageBox.Show("Correct?", "Result Confirm", MessageBoxButtons.OKCancel);

            xData = Logspace(-.1, 2.1, 11);
            yData = ArrPow(xData, -1);

            statusTextBox.Text = "Testing Plot y=1/x x=[10%-.1, 10E2.1]\r\n" + statusTextBox.Text;            
            graphControl1.Plot("Data1", xData, yData, Color.Blue);
            //MessageBox.Show("Correct?", "Result Confirm", MessageBoxButtons.OKCancel);

            statusTextBox.Text = "Testing Semilogx y=1/x x=[10%-.1, 10E2.1]\r\n" + statusTextBox.Text;
            graphControl1.Semilogx("Data1", xData, yData, Color.Blue);
            //MessageBox.Show("Correct?", "Result Confirm", MessageBoxButtons.OKCancel);            

            yData = ArrMult(ArrLog10(yData),20);
            statusTextBox.Text = "Testing Semilogx y=20*log10(1/x) x=[10^-.1, 10^2.1]\r\n" + statusTextBox.Text;
            graphControl1.Semilogx("Data1", xData, yData, Color.Blue);
            //MessageBox.Show("Correct?", "Result Confirm", MessageBoxButtons.OKCancel);

            xData = Logspace(-.0001, 2, 11);
            yData = ArrPow(xData, -1);

            statusTextBox.Text = "Testing Plot y=1/x x=[10%-.1, 10E2.1]\r\n" + statusTextBox.Text;
            graphControl1.Plot("Data1", xData, yData, Color.Blue);
            //MessageBox.Show("Correct?", "Result Confirm", MessageBoxButtons.OKCancel);

            statusTextBox.Text = "Testing Semilogx y=1/x x=[10^-.0001, 10^1E2]\r\n" + statusTextBox.Text;
            graphControl1.Semilogx("Data1", xData, yData, Color.Blue);
            //MessageBox.Show("Correct?", "Result Confirm", MessageBoxButtons.OKCancel);

            yData = ArrMult(ArrLog10(yData), 20);
            statusTextBox.Text = "Testing Semilogx y=20*log10(1/x) x=[10^-.0001, 10^1E2]\r\n" + statusTextBox.Text;
            graphControl1.Semilogx("Data1", xData, yData, Color.Blue);
            //MessageBox.Show("Correct?", "Result Confirm", MessageBoxButtons.OKCancel);

            xData = Logspace(-1.001, 2, 11);
            yData = ArrPow(xData, -1);

            yData = ArrMult(ArrLog10(yData), 20);
            statusTextBox.Text = "Testing Semilogx y=20*log10(1/x) x=[10^-1.001, 10^E2]\r\n" + statusTextBox.Text;
            graphControl1.Semilogx("Data1", xData, yData, Color.Blue);
            //MessageBox.Show("Correct?", "Result Confirm", MessageBoxButtons.OKCancel);

            // test if negative x value is givent to SemiLogx
            xData = Linspace(-10, 10, 12);

            try
            {
                statusTextBox.Text = "Testing Semilogx to linspace(-10, 10)" + statusTextBox.Text;
                graphControl1.Semilogx("Data1", xData, yData, Color.Blue);
            }
            catch (Exception ex)
            {

                MessageBox.Show("Correct? Exception: " + ex.Message, "Result Confirm", MessageBoxButtons.OKCancel);
            }
        }
    }
}