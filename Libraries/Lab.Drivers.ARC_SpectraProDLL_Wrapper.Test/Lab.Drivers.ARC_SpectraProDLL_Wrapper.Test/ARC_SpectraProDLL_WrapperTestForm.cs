using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using Lab_Drivers_ARC_SpectraProDLL_ManagedWrapper;

namespace Lab.Drivers.ARC_SpectraProDLL_Wrapper.Test
{
    public partial class ARC_SpectraProDLL_WrapperTestForm : Form
    {
        ARC_SpectraProDLL_ManagedWrapperClass specObj = null;
        List<Mono> monoList = null;
        private bool bSubForm = false;   // set to true if is form of larger app

        public ARC_SpectraProDLL_WrapperTestForm()
        {
            InitializeComponent();

            freqUnitsComboBox.DataSource = Enum.GetValues(typeof(FreqUnits));
            freqUnitsComboBox.SelectedItem = FreqUnits.nm;

            Initalize();
        }



        private void Initalize()
        {
            specObj = new ARC_SpectraProDLL_ManagedWrapperClass();

            specObj.Initalize();
            resultTextBox.Text = specObj.VersionNumber + "\r\n";


            monoList = specObj.MonoList;
            resultTextBox.Text += monoList[0].ModelName + "\r\n";

            resultTextBox.Text += "Serial Num: " + monoList[0].SerialNum + "\r\n";
            resultTextBox.Text += "Focal Length: " + monoList[0].FocalLength.ToString() + "\r\n";
            resultTextBox.Text += "Detector Angle: " + monoList[0].DetectorAngle.ToString() + "\r\n";
            resultTextBox.Text += "Half Angle: " + monoList[0].HalfAngle.ToString() + "\r\n";
            resultTextBox.Text += "Is Double Mono: " + monoList[0].IsDoubleMono.ToString() + "\r\n";

            resultTextBox.Text += "Turret: " + monoList[0].Turret.ToString() + "\r\n";
            resultTextBox.Text += "Grating: " + monoList[0].GratingNum.ToString() + "\r\n";
            resultTextBox.Text += "Grating Per Turret: " + monoList[0].GratingPerTurret.ToString() + "\r\n";
            resultTextBox.Text += "Has Embeeded Shutter: " + monoList[0].HasEmbeededShutter.ToString() + "\r\n";
            resultTextBox.Text += "Drive Percision (nm): " + monoList[0].DrivePrecisionNm.ToString() + "\r\n";
            resultTextBox.Text += "Startup Scan Rate (nm): " + monoList[0].StartupScanRateNM.ToString() + "\r\n";
            resultTextBox.Text += "Startup Grating Num: " + monoList[0].StartupGratingNum.ToString() + "\r\n";
            resultTextBox.Text += "Startup Wavelength (nm): " + monoList[0].StartuplWavelengthNM.ToString() + "\r\n";


            relCm1NumericUpDown.Value = (decimal) monoList[0].RelCM1_Zero_In_nm;



            gratingComboBox.Items.AddRange(monoList[0].InstalledGratings);
            gratingComboBox.SelectedIndex = specObj.MonoList[0].GratingNum-1;


            freqUnitsComboBox.SelectedItem = monoList[0].FrequencyUnit;
            waveLengthNumericUpDown.Value = (decimal) monoList[0].Wavelengh;
        }

        private void relCm1NumericUpDown_ValueChanged(object sender, EventArgs e)
        {
            monoList[0].RelCM1_Zero_In_nm = (double)relCm1NumericUpDown.Value;
        }

        private void freqUnitsComboBox_SelectedValueChanged(object sender, EventArgs e)
        {
            if (monoList != null)
            {
                monoList[0].FrequencyUnit = (FreqUnits)freqUnitsComboBox.SelectedItem;
            }  
        }

        private void waveLengthNumericUpDown_ValueChanged(object sender, EventArgs e)
        {
           // done with the set button
           // monoList[0].Wavelengh = (double) waveLengthNumericUpDown.Value;
        }

        private void getWavelengthButton_Click(object sender, EventArgs e)
        {
            waveLengthNumericUpDown.Value = (decimal) monoList[0].Wavelengh;
        }

        private void setWavelengthButton_Click(object sender, EventArgs e)
        {
            monoList[0].Wavelengh = (double) waveLengthNumericUpDown.Value;
        }

        private void gratingComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            Grating gratObj = (Grating) gratingComboBox.SelectedItem;

            monoList[0].GratingNum = gratObj.GratingNum;
        }


        // Set to True if this is a subform of a larger program
        // cause close box to hide the form instead of dispose of it
        public bool IsSubForm
        {
            get {
                return (bSubForm);
            }
            set {
                bSubForm = value;
            }
        }

        private void ARC_SpectraProDLL_WrapperTestForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            // hide the form instead of closing it. 
            if (bSubForm == true)
            {
                this.Hide();
                e.Cancel = true;
            }
        }
    }
}
