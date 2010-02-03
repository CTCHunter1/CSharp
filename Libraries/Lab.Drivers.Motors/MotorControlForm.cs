using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Lab.Drivers.Motors
{         
    public partial class MotorControlForm : Form
    {
        Motors motorsObj;

        public MotorControlForm()
        {
            InitializeComponent();

            motorsObj = new Motors();

            if (motorsObj.Axes == null)
            {
                MessageBox.Show("No Motors Found. Exiting");
                Application.Exit();
            }

            // get the position and velocity
            axisComboBox.Items.AddRange(motorsObj.Axes); 
            
            // select the zeroth index
            if (axisComboBox.Items.Count > 0)
                axisComboBox.SelectedIndex = 0;

            positionTextBox.Text = ((IAxis)axisComboBox.SelectedItem).Position.ToString();
            velocityTextBox.Text = ((IAxis)axisComboBox.SelectedItem).Velocity.ToString();
        }

        public IAxis [] Axes
        {
            get
            {
                return (motorsObj.Axes);
            }
        }

        private void gotoButton_Click(object sender, EventArgs e)
        {
            IAxis selectedAxis = (IAxis)axisComboBox.SelectedItem;
            selectedAxis.MoveAbsolute(Convert.ToDouble(positionTextBox.Text));
            positionTextBox.Text = selectedAxis.Position.ToString(); ;
        }

        private void velocitySetButton_Click(object sender, EventArgs e)
        {
            IAxis selectedAxis = (IAxis)axisComboBox.SelectedItem;
            selectedAxis.Velocity = Convert.ToDouble(velocityTextBox.Text);
            velocityTextBox.Text = selectedAxis.Velocity.ToString();
        }
    }
}