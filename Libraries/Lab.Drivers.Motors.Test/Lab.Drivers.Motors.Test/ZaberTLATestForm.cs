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
    public partial class ZaberTLATestForm : Form
    {
        ZaberTLA zaberTLAObj = new ZaberTLA();

        int sendDeviceNumber;
        int sendData;

        public ZaberTLATestForm()
        {
            InitializeComponent();
        }

        private void createZaberTLAObjButton_Click(object sender, EventArgs e)
        {
            zaberTLAObj.Dispose();
            zaberTLAObj = new ZaberTLA();
        }

        private void disposeZaberTLAObjButton_Click(object sender, EventArgs e)
        {
            zaberTLAObj.Dispose();
        }

        private void resetButton_Click(object sender, EventArgs e)
        {
            zaberTLAObj.Reset(sendDeviceNumber);
        }


        private void sendDeviceNumberTextBox_TextChanged(object sender, EventArgs e)
        {
            try
            {
                sendDeviceNumber = Convert.ToInt32(sendDeviceNumberTextBox.Text);
            }
            catch
            {
            }
        }
            

        private void sendDataTextBox_TextChanged(object sender, EventArgs e)
        {
            try
            {
                sendData = Convert.ToInt32(sendDataTextBox.Text);
            }
            catch
            {

            }
        }

        private void renumberButton_Click(object sender, EventArgs e)
        {
            zaberTLAObj.Renumber(sendDeviceNumber, sendData);
        }

        private void moveAbsoluteButton_Click(object sender, EventArgs e)
        {
            try
            {
                int position = zaberTLAObj.MoveAbsolute(sendDeviceNumber, sendData);

                absolutePositionTextBox.Text = position.ToString();
            }
            catch (Exception ex)
            {
                exceptionTextBox.Text = ex.Message;
            }
        }

        private void moveRelativeButton_Click(object sender, EventArgs e)
        {
            try
            {
                int position = zaberTLAObj.MoveRelative(sendDeviceNumber, sendData);
                relativePositionTextBox.Text = position.ToString();
            }
            catch (Exception ex)
            {
                exceptionTextBox.Text = ex.Message;
            }
        }

        private void stopButton_Click(object sender, EventArgs e)
        {
            zaberTLAObj.Stop(sendDeviceNumber);
        }

        private void readWriteEEpromButton_Click(object sender, EventArgs e)
        {
           // zaberTLAObj.ReadWriteEEPROM();
        }

        private void restoreFactoryDefaultButton_Click(object sender, EventArgs e)
        {
            zaberTLAObj.RestoreFactoryDefaultSettings(sendDeviceNumber);
        }

        private void setDeviceModeButton_Click(object sender, EventArgs e)
        {
            // this will be harder to implement
            //zaberTLAObj.SetDeviceMode(sendDeviceNumber, ZaberTLA.Mode.ANTI_BACKLASH, (bool) sendData);
        }

        private void setStartSpeedButton_Click(object sender, EventArgs e)
        {
            zaberTLAObj.SetStartSpeed(sendDeviceNumber, sendData);
        }

        private void setAccelerationButton_Click(object sender, EventArgs e)
        {
            zaberTLAObj.SetAcceleration(sendDeviceNumber, sendData);
        }

        private void setRangeButton_Click(object sender, EventArgs e)
        {
            zaberTLAObj.SetRange(sendDeviceNumber, sendData);
        }

        private void setMaximumRelativeMoveButton_Click(object sender, EventArgs e)
        {
            zaberTLAObj.SetMaximumRelativeMove(sendDeviceNumber, sendData);
        }

        private void setAliasButton_Click(object sender, EventArgs e)
        {
            zaberTLAObj.SetAlias(sendDeviceNumber, sendData);
        }

        private void returnDeviceIDButton_Click(object sender, EventArgs e)
        {
            zaberTLAObj.ReturnDeviceID(sendDeviceNumber);
        }

        private void retrunFirmwareVersionButton_Click(object sender, EventArgs e)
        {
            zaberTLAObj.ReturnFirmwareVersion(sendDeviceNumber);
        }

        private void returnPowerSupplyVoltageButton_Click(object sender, EventArgs e)
        {
            zaberTLAObj.ReturnSetting(sendDeviceNumber, sendData);
        }

        private void returnSettingButton_Click(object sender, EventArgs e)
        {
            zaberTLAObj.ReturnSetting(sendDeviceNumber, sendData);
        }

        private void returnCurrentPosition_Click(object sender, EventArgs e)
        {
            try
            {
                int currentPosition = zaberTLAObj.ReturnCurrentPosition(sendDeviceNumber);

                currentPositionTextBox.Text = currentPosition.ToString();
            }
            catch (Exception ex)
            {
                exceptionTextBox.Text = ex.Message;
            }
        }

        private void TestForm1_Load(object sender, EventArgs e)
        {
            sendDeviceNumber = Convert.ToInt32(sendDeviceNumberTextBox.Text);
            sendData = Convert.ToInt32(sendDataTextBox.Text);
        }

        private void ClearExceptionBoxButton_Click(object sender, EventArgs e)
        {
            exceptionTextBox.Text = "";
        }

        private void readUntilTimeout_Click(object sender, EventArgs e)
        {
            readDataTextBox.Text = "";

            byte[] bytes = zaberTLAObj.ReadUntilTimeout(20);
                      
            string byteStr = System.Text.ASCIIEncoding.ASCII.GetString(bytes);


            readDataTextBox.Text = byteStr;
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }
    }
}