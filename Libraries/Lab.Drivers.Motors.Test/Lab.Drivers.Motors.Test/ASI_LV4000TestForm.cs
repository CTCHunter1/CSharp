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

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                
                ASILV4000.MoveStatus status = asilv4000_obj.ReadMovementStatus();

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
                double[] pos = asilv4000_obj.ReadPosition();
                xPosNumericUpDown.Value = Convert.ToDecimal(pos[0]);
                yPosNumericUpDown.Value = Convert.ToDecimal(pos[1]);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void moveButton_Click(object sender, EventArgs e)
        {
            try
            {
                asilv4000_obj.Move(Convert.ToDouble(xPosNumericUpDown.Value), Convert.ToDouble(yPosNumericUpDown.Value));
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }



    }
}
