using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using Lab.Drivers.Motors;

namespace Lab.Drivers.Motors.Test
{
    public partial class ASI_LV4000TestForm : Form
    {
        ASILV4000 asilv4000_obj = null;

        public ASI_LV4000TestForm()
        {
            InitializeComponent();
        }


        private void createLV4000_Click(object sender, EventArgs e)
        {
            createdTextBox.Text = "";

            try
            {
                asilv4000_obj = new ASILV4000();
                createdTextBox.Text = "Created Successfully";
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void getStatusButton_Click(object sender, EventArgs e)
        {
            try
            {
                
                ASILV4000.MoveStatus status = asilv4000_obj.ReadMovementStatusXY();

                if (status == ASILV4000.MoveStatus.STOPED)
                    statusTextBox.Text = "Ready";
                if (status == ASILV4000.MoveStatus.MOVING)
                    statusTextBox.Text = "Moving";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

       }

        private void getPositionButton_Click(object sender, EventArgs e)
        {           
            try
            {
                double[] pos = asilv4000_obj.ReadPositionXY();
                xPosNumericUpDown.Value = Convert.ToDecimal(pos[0]);
                yPosNumericUpDown.Value = Convert.ToDecimal(pos[1]);
            }
            catch (Exception ex)
            {
                exceptionTextBox.Text = ex.ToString();
            }
        }

        private void moveButton_Click(object sender, EventArgs e)
        {
            try
            {
                asilv4000_obj.MoveXY(Convert.ToDouble(xPosNumericUpDown.Value), Convert.ToDouble(yPosNumericUpDown.Value));
            }
            catch (Exception ex)
            {
                exceptionTextBox.Text = ex.ToString();
            }
        }

        private void clearButton_Click(object sender, EventArgs e)
        {
            exceptionTextBox.Text = "";
        }

        private void ASI_LV4000TestForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (asilv4000_obj != null)
            {
                asilv4000_obj.Dispose();
            }
        }

        private void moveRelbutton_Click(object sender, EventArgs e)
        {
            try
            {
                asilv4000_obj.MoveRelativeXY(Convert.ToDouble(xPosNumericUpDown.Value), Convert.ToDouble(yPosNumericUpDown.Value));
            }
            catch (Exception ex)
            {
                exceptionTextBox.Text = ex.ToString();
            }
        }

        private void moveZbutton_Click(object sender, EventArgs e)
        {
            try
            {
                asilv4000_obj.MoveZ(Convert.ToDouble(zPositionUpDown.Value));
            }
            catch (Exception ex)
            {
                exceptionTextBox.Text = ex.ToString();
            }
        }

        private void moveZRelbutton_Click(object sender, EventArgs e)
        {
            try
            {
                asilv4000_obj.MoveRelativeZ(Convert.ToDouble(zPositionUpDown.Value));
            }
            catch (Exception ex)
            {
                exceptionTextBox.Text = ex.ToString();
            }     
        }

        private void getZPositionButton_Click(object sender, EventArgs e)
        {
            try
            {
                double pos = asilv4000_obj.ReadPositionZ();
                zPositionUpDown.Value = Convert.ToDecimal(pos);
            }
            catch (Exception ex)
            {
                exceptionTextBox.Text = ex.ToString();
            }
        }

        private void haltZButton_Click(object sender, EventArgs e)
        {
            try
            {
                asilv4000_obj.HaltZ();
            }
            catch (Exception ex)
            {
                exceptionTextBox.Text = ex.ToString();
            }
        }

        private void haltXYbutton_Click(object sender, EventArgs e)
        {
            try
            {
                asilv4000_obj.HaltXY();
            }
            catch (Exception ex)
            {
                exceptionTextBox.Text = ex.ToString();
            }
        }

        private void zeroZButton_Click(object sender, EventArgs e)
        {
            try
            {
                asilv4000_obj.ZeroZ();
            }
            catch (Exception ex)
            {
                exceptionTextBox.Text = ex.ToString();
            }
        }

        private void zeroXYButton_Click(object sender, EventArgs e)
        {
            try
            {
                asilv4000_obj.ZeroXY();
            }
            catch (Exception ex)
            {
                exceptionTextBox.Text = ex.ToString();
            }
        }

        private void getSpeedButton_Click(object sender, EventArgs e)
        {
            try
            {
                double []speed = asilv4000_obj.ReadSpeedXY();
                xSpeedNumericUpDown.Value = Convert.ToDecimal(speed[0]);
                ySpeedNumericUpDown.Value = Convert.ToDecimal(speed[1]);
            }
            catch (Exception ex)
            {
                exceptionTextBox.Text = ex.ToString();
            }
        }

        private void getZSpeedButton_Click(object sender, EventArgs e)
        {
            try
            {
                double speed = asilv4000_obj.ReadSpeedZ();
                zspeedUpDown.Value = Convert.ToDecimal(speed);
            }
            catch (Exception ex)
            {
                exceptionTextBox.Text = ex.ToString();
            }
        }

        private void setSpeedXYButton_Click(object sender, EventArgs e)
        {
            try
            {
               asilv4000_obj.SetSpeedXY(Convert.ToDouble(xSpeedNumericUpDown.Value), 
                    Convert.ToDouble(ySpeedNumericUpDown.Value));
            }
            catch (Exception ex)
            {
                exceptionTextBox.Text = ex.ToString();
            }
        }

        private void setZSpeedButton_Click(object sender, EventArgs e)
        {
            try
            {
                asilv4000_obj.SetSpeedZ(Convert.ToDouble(zspeedUpDown.Value));
            }
            catch (Exception ex)
            {
                exceptionTextBox.Text = ex.ToString();
            }
        }

        private void getXSpeedbutton_Click(object sender, EventArgs e)
        {
            try
            {
                double speed = asilv4000_obj.ReadSpeedX();
                xSpeedNumericUpDown.Value = Convert.ToDecimal(speed);
            }
            catch (Exception ex)
            {
                exceptionTextBox.Text = ex.ToString();
            }
        }

        private void getYSpeedbutton_Click(object sender, EventArgs e)
        {
            try
            {
                double speed = asilv4000_obj.ReadSpeedY();
                ySpeedNumericUpDown.Value = Convert.ToDecimal(speed);
            }
            catch (Exception ex)
            {
                exceptionTextBox.Text = ex.ToString();
            }
        }

        private void setXSpeedButton_Click(object sender, EventArgs e)
        {
            try
            {
                asilv4000_obj.SetSpeedX(Convert.ToDouble(xSpeedNumericUpDown.Value));
            }
            catch (Exception ex)
            {
                exceptionTextBox.Text = ex.ToString();
            }
        }

        private void setYSpeedButton_Click(object sender, EventArgs e)
        {
            try
            {
                asilv4000_obj.SetSpeedY(Convert.ToDouble(ySpeedNumericUpDown.Value));
            }
            catch (Exception ex)
            {
                exceptionTextBox.Text = ex.ToString();
            }
        }

        private void getXPosButton_Click(object sender, EventArgs e)
        {
            try
            {
                double pos = asilv4000_obj.ReadPositionX();
                xPosNumericUpDown.Value = Convert.ToDecimal(pos);
            }
            catch (Exception ex)
            {
                exceptionTextBox.Text = ex.ToString();
            }
        }

        private void getYPosButton_Click(object sender, EventArgs e)
        {
            try
            {
                double pos = asilv4000_obj.ReadPositionY();
                yPosNumericUpDown.Value = Convert.ToDecimal(pos);
            }
            catch (Exception ex)
            {
                exceptionTextBox.Text = ex.ToString();
            }
        }

        private void moveXButton_Click(object sender, EventArgs e)
        {
            try
            {
                asilv4000_obj.MoveX(Convert.ToDouble(xPosNumericUpDown.Value));
            }
            catch (Exception ex)
            {
                exceptionTextBox.Text = ex.ToString();
            }
        }

        private void moveYButton_Click(object sender, EventArgs e)
        {
            try
            {
                asilv4000_obj.MoveY(Convert.ToDouble(yPosNumericUpDown.Value));
            }
            catch (Exception ex)
            {
                exceptionTextBox.Text = ex.ToString();
            }
        }

        private void moveXRelButton_Click(object sender, EventArgs e)
        {
            try
            {
                asilv4000_obj.MoveRelativeX(Convert.ToDouble(relMoveXnumericUpDown.Value));
            }
            catch (Exception ex)
            {
                exceptionTextBox.Text = ex.ToString();
            }
        }

        private void moveYRelButton_Click(object sender, EventArgs e)
        {
            try
            {
                asilv4000_obj.MoveRelativeY(Convert.ToDouble(relMoveYNumericUpDown.Value));
            }
            catch (Exception ex)
            {
                exceptionTextBox.Text = ex.ToString();
            }
        }
        

    }
}
