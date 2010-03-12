using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Squid
{
    public partial class SquidOptionsForm : Form
    {
        bool backupDCFrquencyCheckBox;
        DataSeries.AmpUnits backupAmpUnits;

        public SquidOptionsForm()
        {
            InitializeComponent();

            ampUnitsComboBox.Items.Add(DataSeries.AmpUnits.V);
            ampUnitsComboBox.Items.Add(DataSeries.AmpUnits.dBmV);
            ampUnitsComboBox.Items.Add(DataSeries.AmpUnits.dBm);

            ampUnitsComboBox.SelectedItem = DataSeries.AmpUnits.V;
        }

        private void SquidOptions_Shown(object sender, EventArgs e)
        {
            backupDCFrquencyCheckBox = DCFrequencyCheckBox.Checked;
            backupAmpUnits = (DataSeries.AmpUnits) ampUnitsComboBox.SelectedItem;
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            DCFrequencyCheckBox.Checked = backupDCFrquencyCheckBox;
            ampUnitsComboBox.SelectedItem = backupAmpUnits;
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
    }
}