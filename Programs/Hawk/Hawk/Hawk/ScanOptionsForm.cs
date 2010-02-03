using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Lab.Drivers.Motors;

namespace Lab.Programs.Hawk
{
    public partial class ScanOptionsForm : Form
    {
        // cutting axis parameters
        private IAxis backupCuttingAxisMotor;
        private decimal backupCuttingAxisRadius;
        private bool backupSampleAndHold;
        private decimal backupNumPoints;
        private decimal backupHoldTime;

        private bool backupZAxisScan;

        // z axis parameters
        private IAxis backupZAxisMotor;
        private decimal backupZAxisRadius;
        private decimal backupZAxisNumPoints;

        public ScanOptionsForm(IAxis[] iAxisArr)
        {
            InitializeComponent();
            // copy the axis arrays into the combo boxes

            if (iAxisArr != null)
            {
                cuttingAxisMotorComboBox.Items.AddRange(iAxisArr);
                zAxisMotorComboBox.Items.AddRange(iAxisArr);

                if (iAxisArr.Length > 0)
                {
                    cuttingAxisMotorComboBox.SelectedIndex = 0;
                    zAxisMotorComboBox.SelectedIndex = 0;
                }
            }
        }

        private void ScanOptionsForm_Shown(object sender, EventArgs e)
        {
            // cutting axis parameters
            backupCuttingAxisMotor = (IAxis) cuttingAxisMotorComboBox.SelectedItem;
            backupCuttingAxisRadius = cuttingAxisRadiusNumericUpDown.Value;
            backupSampleAndHold = cuttingAxisSampleAndHoldCheckBox.Checked;
            backupNumPoints = cuttingAxisNumPointsNumericUpDown.Value;
            backupHoldTime = cuttingAxisHoldTimeNumericUpDown.Value;

            // z axis parameters
            backupZAxisScan = zAxisScanCheckBox.Checked;
            backupZAxisMotor = (IAxis) zAxisMotorComboBox.SelectedItem;
            backupZAxisRadius = zAxisRadiusNumericUpDown.Value;
            backupZAxisNumPoints = zAxisNumPointsNumericUpDown.Value;

            cuttingAxisSampleAndHoldCheckBox_CheckedChanged(sender, e);
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            // cutting axis parameters
            cuttingAxisMotorComboBox.SelectedItem = backupCuttingAxisMotor;
            cuttingAxisRadiusNumericUpDown.Value = backupCuttingAxisRadius;
            cuttingAxisSampleAndHoldCheckBox.Checked = backupSampleAndHold;
            cuttingAxisNumPointsNumericUpDown.Value = backupNumPoints;
            cuttingAxisHoldTimeNumericUpDown.Value = backupHoldTime;

            // z axis parameters
            zAxisScanCheckBox.Checked = backupZAxisScan;
            zAxisMotorComboBox.SelectedItem = backupZAxisMotor;
            zAxisRadiusNumericUpDown.Value = backupZAxisRadius;
            zAxisNumPointsNumericUpDown.Value = backupZAxisNumPoints;
        }

        private void zAxisScanCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (zAxisScanCheckBox.Checked == true)
            {
                zAxisMotorComboBox.Enabled = true;
                zAxisNumPointsNumericUpDown.Enabled = true;
                zAxisRadiusNumericUpDown.Enabled = true;
            }
            else
            {
                zAxisMotorComboBox.Enabled = false;
                zAxisNumPointsNumericUpDown.Enabled = false;
                zAxisRadiusNumericUpDown.Enabled = false;
            }
        }

        private void cuttingAxisSampleAndHoldCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (cuttingAxisSampleAndHoldCheckBox.Checked == true)
            {
                cuttingAxisNumPointsNumericUpDown.Enabled = true;
                cuttingAxisHoldTimeNumericUpDown.Enabled = true;
            }
            else
            {
                cuttingAxisNumPointsNumericUpDown.Enabled = false;
                cuttingAxisHoldTimeNumericUpDown.Enabled = false;
            }
        }

        // dialog properties
        public IAxis CuttingAxisMotor
        {
            get
            {
                return ((IAxis) cuttingAxisMotorComboBox.SelectedItem);    
            }
        }

        public double CuttingAxisRadius
        {
            get
            {
                return (Convert.ToDouble(cuttingAxisRadiusNumericUpDown.Value));
            }
        }

        public bool CuttingAxisSampleandHold
        {
            get
            {
                return (cuttingAxisSampleAndHoldCheckBox.Checked);
            }
        }

        public int CuttingAxisNumPoints
        {
            get
            {
                return (Convert.ToInt32(cuttingAxisNumPointsNumericUpDown.Value));
            }
        }

        public int CuttingAxisHoldTime
        {
            get
            {
                return (Convert.ToInt32(cuttingAxisHoldTimeNumericUpDown.Value));
            }
        }

        public bool ZAxisScan
        {
            get
            {
                return (zAxisScanCheckBox.Checked);
            }
        }

        public IAxis ZAxisMotor
        {
            get
            {
                return ((IAxis) zAxisMotorComboBox.SelectedItem);
            }
        }

        public double ZAxisRadius
        {
            get
            {
                return (Convert.ToDouble(zAxisRadiusNumericUpDown.Value));
            }
        }

        public int ZAxisNumPoints
        {
            get
            {
                return (Convert.ToInt32(zAxisNumPointsNumericUpDown.Value));
            }
        }
    }
}