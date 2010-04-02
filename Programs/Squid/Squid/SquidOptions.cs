using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Lab.Drivers.Motors;

namespace Squid
{
    public partial class SquidOptionsForm : Form
    {
        bool backupDCFrquencyCheckBox;
        DataSeries.AmpUnits backupAmpUnits;
        decimal backupPretriggerSamples;
        decimal backupNumReducedSamplesPow2;
        bool backupRisingTrigger;
        Decimator decimatorObj;

        public SquidOptionsForm(IAxis[] iAxisArr)
        {
            InitializeComponent();

            decimatorObj = new Decimator(NumReducedSamples, NumPretriggerSamples);   

            ampUnitsComboBox.Items.Add(DataSeries.AmpUnits.V);
            ampUnitsComboBox.Items.Add(DataSeries.AmpUnits.dBmV);
            ampUnitsComboBox.Items.Add(DataSeries.AmpUnits.dBm);

            ampUnitsComboBox.SelectedItem = DataSeries.AmpUnits.V;

            reducedSamplesPow2numeric_ValueChanged(null, null);

            // add the motors to the combo box
            if (iAxisArr != null)
            {
                zAxisMotorComboBox.Items.AddRange(iAxisArr);
                                
                if (iAxisArr.Length > 0)
                {
                    zAxisMotorComboBox.SelectedIndex = 0;
                    // enable the z axis controls
                    zAxisMotorComboBox.Enabled = true;
                    zAxisRadiusNumericUpDown.Enabled = true;
                    zAxisNumPointsNumericUpDown.Enabled = true;
                                        
                }
            }            
        }

        private void SquidOptions_Shown(object sender, EventArgs e)
        {
            backupDCFrquencyCheckBox = DCFrequencyCheckBox.Checked;
            backupAmpUnits = (DataSeries.AmpUnits) ampUnitsComboBox.SelectedItem;
            backupPretriggerSamples = pretriggerNumeric.Value;
            backupNumReducedSamplesPow2 = reducedSamplesPow2numeric.Value;
            backupRisingTrigger = risingRadioButton.Checked;
            UpdateDecimator();
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            DCFrequencyCheckBox.Checked = backupDCFrquencyCheckBox;
            ampUnitsComboBox.SelectedItem = backupAmpUnits;
            pretriggerNumeric.Value = backupPretriggerSamples;
            reducedSamplesPow2numeric.Value = backupNumReducedSamplesPow2;
            risingRadioButton.Checked = backupRisingTrigger;
            fallingRadioButton.Checked = !backupRisingTrigger;
            UpdateDecimator();
        }

        public bool PlotDCFrequency
        {
            get
            {
                return (DCFrequencyCheckBox.Checked);
            }
        }

        public DataSeries.AmpUnits FrequencyAmpUnits
        {
            get
            {
                return (DataSeries.AmpUnits) ampUnitsComboBox.SelectedItem;
            }
        }

        public int NumPretriggerSamples
        {
            get
            {
                return (Convert.ToInt32(pretriggerNumeric.Value));
            }
        }

        public int NumReducedSamples
        {
            get
            {
                return (Convert.ToInt32(Math.Pow(2, (Convert.ToDouble(reducedSamplesPow2numeric.Value)))));
            }
        }

        public bool TriggerRising
        {
            get
            {
                return (risingRadioButton.Checked);
            }
        }

        private void reducedSamplesPow2numeric_ValueChanged(object sender, EventArgs e)
        {
            numReducedSamplesLabel.Text = this.NumReducedSamples.ToString("0");
            UpdateDecimator();
        }

        public IAxis ZAxis
        {
            get
            {
                return ((IAxis) zAxisMotorComboBox.SelectedItem);
            }
        }

        public double ZScanRadius
        {
            get
            {
                return Convert.ToDouble((zAxisRadiusNumericUpDown.Value)) / 1000;
            }
        }

        public int ZScanNumPoints
        {
            get
            {
                return (Convert.ToInt32(zAxisNumPointsNumericUpDown.Value));
            }
        }

        private void UpdateDecimator()
        {
            decimatorObj.NumPoints = NumReducedSamples;
            decimatorObj.PretriggerPoints = NumPretriggerSamples;
            decimatorObj.TriggerRising = TriggerRising;
        }

        public Decimator DecimatorObj
        {
            get
            {
                return (decimatorObj);
            }
        }

        private void pretriggerNumeric_ValueChanged(object sender, EventArgs e)
        {
            UpdateDecimator();
        }

        private void risingRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            UpdateDecimator();
        }
    }
}