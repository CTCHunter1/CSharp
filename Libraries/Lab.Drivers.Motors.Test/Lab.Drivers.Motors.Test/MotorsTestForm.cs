using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Lab.Drivers.Motors.Test
{
    public partial class MotorsTestForm : Form
    {
        Motors motorsObj;
        IAxis []axes; 

        public MotorsTestForm()
        {
            InitializeComponent();
        }

        private void initalizeButton_Click(object sender, EventArgs e)
        {
            motorsObj = new Motors();

            numAxisTextBox.Text = motorsObj.Axes.Length.ToString();

            axes = motorsObj.Axes;

            axisComboBox.Items.AddRange(axes); // put the axes into the combo box

            if (axes.Length > 0)
                axisComboBox.SelectedIndex = 0;
        }

        private void moveAbsoluteButton_Click(object sender, EventArgs e)
        {
            int index = axisComboBox.SelectedIndex;
            double position = Convert.ToDouble(positionTextBox.Text);

            axes[index].MoveAbsolute(position);

            currentPositionTextBox.Text = axes[index].Position.ToString();
        }

        private void beginMoveButton_Click(object sender, EventArgs e)
        {
            int index = axisComboBox.SelectedIndex;

            callbackTextBox.Text = "";
            currentPositionTextBox.Text = "";

            double position = Convert.ToDouble(beginMoveTextBox.Text);

            callbackTextBox.Text = "";
            AsyncCallback acbObj = new AsyncCallback(CallbackFunction);

            axes[index].BeginMoveAbsolute(position, acbObj, this);
        }

        private void CallbackFunction(IAsyncResult iasrObj)
        {
            int index = axisComboBox.SelectedIndex;  

            // position isn't updated until end is called
            axes[index].EndMoveAbsolute(iasrObj);
                   
            callbackTextBox.Text = "Callback Function Called";
            currentPositionTextBox.Text = axes[index].Position.ToString();

            
        }

        private void MotorsTestForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            motorsObj.Dispose();
;
        }
    }
}