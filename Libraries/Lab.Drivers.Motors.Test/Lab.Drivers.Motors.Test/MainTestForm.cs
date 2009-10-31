using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Lab.Drivers.Motors.Test
{
    public partial class MainTestForm : Form
    {
        public MainTestForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ZabberDLLWrapperTestForm formObj = new ZabberDLLWrapperTestForm();
            formObj.ShowDialog();
        }

        private void zaberTLAButton_Click(object sender, EventArgs e)
        {
            ZaberTLATestForm formObj = new ZaberTLATestForm();

            formObj.ShowDialog();
        }

        private void newportAxisButton_Click(object sender, EventArgs e)
        {
            NewportAxisTestForm formObj = new NewportAxisTestForm();

            formObj.ShowDialog();
        }

        private void zaberAxisButton_Click(object sender, EventArgs e)
        {
            ZaberAxisTestForm formObj = new ZaberAxisTestForm();

            formObj.ShowDialog();
        }

        private void motorsButton_Click(object sender, EventArgs e)
        {
            MotorsTestForm formObj = new MotorsTestForm();

            formObj.ShowDialog();
        }

        private void motorControlFormButton_Click(object sender, EventArgs e)
        {
            MotorControlForm formObj = new MotorControlForm();

            formObj.ShowDialog();
        }
    }
}