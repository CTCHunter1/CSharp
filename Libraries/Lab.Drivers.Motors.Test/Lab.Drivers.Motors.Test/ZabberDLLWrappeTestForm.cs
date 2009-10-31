using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using Lab.Drivers.Motors;

namespace Lab.Drivers.Motors.Test
{
    public partial class ZabberDLLWrapperTestForm : Form
    {
        public ZabberDLLWrapperTestForm()
        {
            InitializeComponent();
        }

        private void hardwareInitButton_Click(object sender, EventArgs e)
        {
            ZaberDLLWrapper.Motor_Init((IntPtr)null, (string)null);
        }

        private void motorExitButton_Click(object sender, EventArgs e)
        {
            ZaberDLLWrapper.Motor_Exit();
        }

        private void motorOptionsButton_Click(object sender, EventArgs e)
        {
            ZaberDLLWrapper.Motor_Options(this.Handle);
        }

        private void motorAboutButton_Click(object sender, EventArgs e)
        {
            ZaberDLLWrapper.Motor_About(this.Handle);
        }

        private void motorSetVelocityButton_Click(object sender, EventArgs e)
        {
            double velocity = Convert.ToDouble(velocityTextBox.Text);

            ZaberDLLWrapper.Motor_SetVelocity(velocity);
        }

        private void motorSetZeroButton_Click(object sender, EventArgs e)
        {
            ZaberDLLWrapper.Motor_SetZero();
        }

        private void motorGotoButton_Click(object sender, EventArgs e)
        {
            double position = Convert.ToDouble(positionTextBox.Text);

            ZaberDLLWrapper.Motor_Goto(position);
        }

        private void motorGotoWaitButton_Click(object sender, EventArgs e)
        {
            double position = Convert.ToDouble(gotoWaitTextBox.Text);

            ZaberDLLWrapper.Motor_GotoWait(position);
        }

        private void motorGoHomeButton_Click(object sender, EventArgs e)
        {
            ZaberDLLWrapper.Motor_GoHome();
        }

        private void MotorGoHardwareLimitButton_Click(object sender, EventArgs e)
        {
            ZaberDLLWrapper.Motor_GoHardwareLimit();
        }

        private void motorNumAxisButton_Click(object sender, EventArgs e)
        {
            int numAxis = ZaberDLLWrapper.Motor_NumAxes();

            numAxisTextBox.Text = numAxis.ToString();
        }

        private void motorSetAxisButton_Click(object sender, EventArgs e)
        {
            ZaberDLLWrapper.Motor_SetAxis(Convert.ToInt32(axisTextBox.Text));
        }
    }
}