using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Lab.Drivers.Motors.Test
{
    public partial class ASILV4000AxisTestForm : Form
    {
        ASILV4000 asilv4000_obj = null;
        ASILV4000Axis [] asiaxis_arr = null;

        public ASILV4000AxisTestForm()
        {
            InitializeComponent();
        }

        private void closeButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void initalizeButton_Click(object sender, EventArgs e)
        {
            try
            {
                asilv4000_obj = new ASILV4000();
            }
            catch(Exception ex) 
            {
                exceptionTextBox.Text = ex.ToString();
            }
        }

        private void getAxesButton_Click(object sender, EventArgs e)
        {
            try
            {
                if (asilv4000_obj == null)
                {
                    asilv4000_obj = new ASILV4000();
                }
                
                asiaxis_arr = asilv4000_obj.GetAxes();

                axisComboBox.Items.Clear();
                 
                if (asiaxis_arr == null)
                {
                    axisComboBox.Items.Add("");
                    axisComboBox.SelectedIndex = 0;
                    exceptionTextBox.Text = "No Axes found on ASI 4000";
                    return;
                }

                axisComboBox.Items.AddRange(asiaxis_arr);
                axisComboBox.SelectedIndex = 0;
            }

            catch (Exception ex)
            {
                exceptionTextBox.Text = ex.ToString();
            }
        }

        private void clearButton_Click(object sender, EventArgs e)
        {
            exceptionTextBox.Clear();
        }

        private void getPosButton_Click(object sender, EventArgs e)
        {
            try
            {
                ASILV4000Axis selectedAxis = (ASILV4000Axis)axisComboBox.SelectedItem;
                double pos = selectedAxis.Position;

                positionNumericUpDown.Value = Convert.ToDecimal(pos);   
            }
            catch (Exception ex)
            {
                exceptionTextBox.Text = ex.ToString();
            }
        }

        private void moveAbsoluteButton_Click(object sender, EventArgs e)
        {
            try
            {                
                ASILV4000Axis selectedAxis = (ASILV4000Axis)axisComboBox.SelectedItem;
               
                selectedAxis.MoveAbsolute(Convert.ToDouble(positionNumericUpDown.Value));
        
            }
            catch (Exception ex)
            {
                exceptionTextBox.Text = ex.ToString();
            }
        }

        private void getVelocityButton_Click(object sender, EventArgs e)
        {
            try
            {
                ASILV4000Axis selectedAxis = (ASILV4000Axis)axisComboBox.SelectedItem;

                double velocity = selectedAxis.Velocity;
                velocityNumericUpDown.Value = Convert.ToDecimal(velocity);                
            }
            catch (Exception ex)
            {
                exceptionTextBox.Text = ex.ToString();
            }
        }

        private void setVelocityButton_Click(object sender, EventArgs e)
        {
            try
            {
                ASILV4000Axis selectedAxis = (ASILV4000Axis)axisComboBox.SelectedItem;
                selectedAxis.Velocity = Convert.ToDouble(velocityNumericUpDown.Value);
            }
            catch (Exception ex)
            {
                exceptionTextBox.Text = ex.ToString();
            }
        }
    }
}
