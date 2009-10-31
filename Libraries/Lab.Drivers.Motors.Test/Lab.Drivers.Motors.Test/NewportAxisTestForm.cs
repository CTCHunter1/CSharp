using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Lab.Drivers.Motors.Test
{
    public partial class NewportAxisTestForm : Form
    {
        NewportESP100Axis [] axes;
        NewportESP100Axis selectedAxis;

        public NewportAxisTestForm()
        {
            InitializeComponent();
        }

        private void initializeButton_Click(object sender, EventArgs e)
        {
            try
            {
                NewportESP100 newportESP100obj = new NewportESP100();

                axes = newportESP100obj.Axes;

                axisNumberComboBox.Items.Clear();

                axisNumberComboBox.Items.AddRange(axes);

                if (axes != null)
                {
                    axisNumberComboBox.SelectedIndex = 0;
                    selectedAxis = axes[0];
                } 
            
            }
            catch (Exception ex)
            {
                exceptionTextBox.Text = ex.Message;
            }
        }

        private void updateParametersButton_Click(object sender, EventArgs e)
        {
            serialNumberTextBox.Text = selectedAxis.SerialNumber;
            modelNumberTextBox.Text = selectedAxis.ModelNumber;
            descriptionTextBox.Text = selectedAxis.Description;
            homeTextBox.Text = selectedAxis.Home.ToString();
            currentPositionTextBox.Text = selectedAxis.Position.ToString();
            velocityTextBox.Text = selectedAxis.Velocity.ToString();
        }

        private void moveAbsoluteButton_Click(object sender, EventArgs e)
        {
            double position = Convert.ToDouble(absolutePositionTextBox.Text);
            
            selectedAxis.MoveAbsolute(position);

            currentPositionTextBox.Text = selectedAxis.Position.ToString();
        }

        private void beginMoveAbsoluteButton_Click(object sender, EventArgs e)
        {
            double position = Convert.ToDouble(beginMovePositionTextBox.Text);

            callbackTextBox.Text = "";
            AsyncCallback acbObj = new AsyncCallback(CallbackFunction);

            selectedAxis.BeginMoveAbsolute(position, acbObj, this);

        }

        private void CallbackFunction(IAsyncResult iarObj)
        {
            callbackTextBox.Text = "Callback Called";

            currentPositionTextBox.Text = selectedAxis.Position.ToString();
            selectedAxis.EndMoveAbsolute(iarObj);
        }

        private void setVelocityButton_Click(object sender, EventArgs e)
        {
            selectedAxis.Velocity = Convert.ToDouble(velocityTextBox.Text);
        }

    }
}