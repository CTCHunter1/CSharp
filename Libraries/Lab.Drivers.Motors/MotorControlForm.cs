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
        Motors motorsObj = null;
        bool bSubForm = false; /// set to true if this is a sub form of larger program

        public MotorControlForm()
        {
            InitializeComponent();
            InitalizeMotors();
        }

        private void InitalizeMotors()
        {
            try
            {
                axisComboBox.Items.Clear(); // clear because this could be a reinit
                verticalComboBox.Items.Clear();
                horizontalComboBox.Items.Clear();

                if (motorsObj != null)
                {
                    motorsObj.Dispose();
                    motorsObj = null;
                }

                motorsObj = new Motors();
            
                if (motorsObj.Axes == null)
                {
                    MessageBox.Show("No Motors Found");
                }
                else 
                {

                    axisComboBox.Items.AddRange(motorsObj.Axes);
                    verticalComboBox.Items.AddRange(motorsObj.Axes);
                    horizontalComboBox.Items.AddRange(motorsObj.Axes);
                }

                // select the zeroth index
                if (axisComboBox.Items.Count > 0)
                {
                    axisComboBox.SelectedIndex = 0;
                    horizontalComboBox.SelectedIndex = 0; // will be overwritten if there are 2 axes
                    verticalComboBox.SelectedIndex = 0; 
                }

                if (axisComboBox.Items.Count > 1)
                {
                    horizontalComboBox.SelectedIndex = 1;
                }   

                // get positoin and velocity
                UpdateProperties();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void UpdateProperties()
        {
            // if motors do not init then motorsObj will be null
            if (motorsObj != null)
            {
                if (motorsObj.Axes != null)
                {

                    positionTextBox.Text = ((IAxis)axisComboBox.SelectedItem).Position.ToString();
                    velocityTextBox.Text = ((IAxis)axisComboBox.SelectedItem).Velocity.ToString();
                }
            }
        }

        public IAxis [] Axes
        {
            get
            {
                if (motorsObj == null)
                    return (null);

                return (motorsObj.Axes);
            }
        }

        /// <summary>
        /// Get the current position of all the motors in millimeters
        /// </summary>
        public double[] CurrentPositions
        {
            get
            {
                if (motorsObj == null)
                    return (null);

                if (motorsObj.Axes == null)
                    return (null);

                int numMotors = motorsObj.Axes.Length;

                if (numMotors == 0)
                    return (null);

                double[] positions = new double[numMotors];

                for (int i = 0; i < numMotors; i++)
                {
                    positions[i] = motorsObj.Axes[i].Position;
                }

                return (positions);
            }
        }

        private void gotoButton_Click(object sender, EventArgs e)
        {
            try
            {
                IAxis selectedAxis = (IAxis)axisComboBox.SelectedItem;
                selectedAxis.MoveAbsolute(Convert.ToDouble(positionTextBox.Text));
                positionTextBox.Text = selectedAxis.Position.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void velocitySetButton_Click(object sender, EventArgs e)
        {
            IAxis selectedAxis = (IAxis)axisComboBox.SelectedItem;
            selectedAxis.Velocity = Convert.ToDouble(velocityTextBox.Text);
            velocityTextBox.Text = selectedAxis.Velocity.ToString();
        }

        private void MotorControlForm_Load(object sender, EventArgs e)
        {
            UpdateProperties();
        }

        private void getButton_Click(object sender, EventArgs e)
        {
            UpdateProperties();
        }

        private void axisComboBox_TextChanged(object sender, EventArgs e)
        {
            UpdateProperties(); // don't know if this is what change event should be used
        }

        private void setZeroButton_Click(object sender, EventArgs e)
        {
            IAxis selectedAxis = (IAxis)axisComboBox.SelectedItem;
            selectedAxis.SetZero();
        }

        private void closeButton_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void MotorControlForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (bSubForm == true)
            {
                this.Hide();
                e.Cancel = true; // cancel dispose
            } 
        }

        // set to true if this a subform of a larger program
        public bool IsSubForm
        {
            get
            {
                return (bSubForm);
            }
            set
            {
                bSubForm = value;
            }
        }

        private void reinitalizeButton_Click(object sender, EventArgs e)
        {
            InitalizeMotors();
        }

        private void panUpButton_Click(object sender, EventArgs e)
        {
            IAxis selectedAxis = (IAxis)verticalComboBox.SelectedItem;
            double curPosition_mm = selectedAxis.Position;
            double stepSize_um = (double)stepSizeNumericUpDown.Value;

            // reverse
            if (upDownReverseCheckBox.Checked == true)
                stepSize_um = -stepSize_um;

            double newPosition_mm = curPosition_mm + stepSize_um / 1000;


            selectedAxis.MoveAbsolute(newPosition_mm);
        }

        private void panDownButton_Click(object sender, EventArgs e)
        {
            IAxis selectedAxis = (IAxis) verticalComboBox.SelectedItem;
            double curPosition_mm = selectedAxis.Position;
            double stepSize_um = (double) stepSizeNumericUpDown.Value;

            // reverse
            if (upDownReverseCheckBox.Checked == true)
                stepSize_um = -stepSize_um;

            double newPosition_mm = curPosition_mm - stepSize_um / 1000;


            selectedAxis.MoveAbsolute(newPosition_mm);
        }

        private void panRightButton_Click(object sender, EventArgs e)
        {
            IAxis selectedAxis = (IAxis) horizontalComboBox.SelectedItem;
            double curPosition_mm = selectedAxis.Position;
            double stepSize_um = (double)stepSizeNumericUpDown.Value;

            // reverse
            if (leftRightRevCheckBox.Checked == true)
                stepSize_um = -stepSize_um;

            double newPosition_mm = curPosition_mm + stepSize_um / 1000;

            try
            {
                selectedAxis.MoveAbsolute(newPosition_mm);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
       }
        

        private void panLeftButton_Click(object sender, EventArgs e)
        {
            IAxis selectedAxis = (IAxis) horizontalComboBox.SelectedItem;
            double curPosition_mm = selectedAxis.Position;
            double stepSize_um = (double)stepSizeNumericUpDown.Value;

            // reverse
            if (leftRightRevCheckBox.Checked == true)
                stepSize_um = -stepSize_um;

            double newPosition_mm = curPosition_mm - stepSize_um / 1000;

            try
            {

                selectedAxis.MoveAbsolute(newPosition_mm);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

      
    }
}