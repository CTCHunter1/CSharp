using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using Lab.FileIO;

namespace Lab.FileIO.Test
{
    public partial class TestForm : Form
    {
        public TestForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MATLABIO matlabioObj = new MATLABIO(testFileNameTextBox.Text);      

            // call the test functions
            Test1DReal(matlabioObj);
            Test1DComplex(matlabioObj);
            Test2DReal(matlabioObj);
            Test2DComplex(matlabioObj);
            
            matlabioObj.WriteClose();
        }

        private void Test1DReal(MATLABIO matlabIOObj)
        {
            double [] data = new double[]{1, 2, 3, 4, 5};

            matlabIOObj.Write1DReal(real1DVarNameTextBox.Text, data);
        }

        private void Test1DComplex(MATLABIO matlabIOObj)
        {
            double[] realData = new double[] { 1, 2, 3, 4, 5 };
            double[] imagData = new double[] { 6, 7, 8, 9, 10};

            matlabIOObj.Write1DComplex(complex1DVarNameTextBox.Text,
                realData,
                imagData);
        }

        private void Test2DReal(MATLABIO matlabIOObj)
        {
            double[,] realData = new double[,] {{1.00, 2.00, 3.00, 4.00},
                                               {10.00, 20.00, 30.00, 40.00}};

            matlabIOObj.Write2DReal(real2DVasNameTextBox.Text,
                realData);
        }

        private void Test2DComplex(MATLABIO matlabIOObj)
        {
            double[,] realData = new double[,] {{1.00, 2.00, 3.00, 4.00},
                                               {10.00, 20.00, 30.00, 40.00}};           


            matlabIOObj.Write2dComplex(complex2DVarNameTextBox.Text,
                realData,
                realData);
        }
    }
}