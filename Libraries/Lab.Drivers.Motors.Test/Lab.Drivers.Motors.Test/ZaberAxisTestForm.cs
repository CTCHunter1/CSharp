using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Lab.Drivers.Motors.Test
{
    public partial class ZaberAxisTestForm : Form
    {
        ZaberTLAAxis[] zaberAxisArr;
        int selectedAxisIndex = 0;

        public ZaberAxisTestForm()
        {
            InitializeComponent();

            ZaberDLLWrapper.Motor_Init((IntPtr)null, (string)null);
            int numAxis = ZaberDLLWrapper.Motor_NumAxes();

            zaberAxisArr = new ZaberTLAAxis[numAxis];

            // initalize the zaber axes
            for (int i = 0; i < numAxis; i++)
            {
                zaberAxisArr[i] = new ZaberTLAAxis(i);
                axisNumberComboBox.Items.Add(i.ToString());
            }

            if (numAxis > 0)
                axisNumberComboBox.SelectedIndex = 0;
        }

        private void axisNumberComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            selectedAxisIndex = axisNumberComboBox.SelectedIndex;
        }

        private void moveAbsoluteButton_Click(object sender, EventArgs e)
        {
            double position = Convert.ToDouble(positionTextBox.Text);

            zaberAxisArr[selectedAxisIndex].MoveAbsolute(position);

            currentPositionTextBox.Text = zaberAxisArr[0].Position.ToString();

        }

        

        private void beginMoveAbsoluteButton_Click(object sender, EventArgs e)
        {
            double position = Convert.ToDouble(beginMovePositionTextBox.Text);

            callbackTextBox.Text = "";
            AsyncCallback acbObj = new AsyncCallback(CallbackFunction);

            zaberAxisArr[selectedAxisIndex].BeginMoveAbsolute(position, acbObj, this);
        }

        private void CallbackFunction(IAsyncResult iarObj)
        {
            callbackTextBox.Text = "Callback Called";

            currentPositionTextBox.Text = zaberAxisArr[0].Position.ToString();
            zaberAxisArr[selectedAxisIndex].EndMoveAbsolute(iarObj);
        }

    }
}