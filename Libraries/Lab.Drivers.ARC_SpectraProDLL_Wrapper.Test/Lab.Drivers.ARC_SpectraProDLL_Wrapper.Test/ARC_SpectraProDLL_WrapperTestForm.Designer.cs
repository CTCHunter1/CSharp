namespace Lab.Drivers.ARC_SpectraProDLL_Wrapper.Test
{
    partial class ARC_SpectraProDLL_WrapperTestForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.resultTextBox = new System.Windows.Forms.TextBox();
            this.gratingComboBox = new System.Windows.Forms.ComboBox();
            this.relCm1NumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.freqUnitsComboBox = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.waveLengthNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.getWavelengthButton = new System.Windows.Forms.Button();
            this.setWavelengthButton = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.relCm1NumericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.waveLengthNumericUpDown)).BeginInit();
            this.SuspendLayout();
            // 
            // resultTextBox
            // 
            this.resultTextBox.Location = new System.Drawing.Point(12, 181);
            this.resultTextBox.Multiline = true;
            this.resultTextBox.Name = "resultTextBox";
            this.resultTextBox.ReadOnly = true;
            this.resultTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.resultTextBox.Size = new System.Drawing.Size(253, 153);
            this.resultTextBox.TabIndex = 1;
            // 
            // gratingComboBox
            // 
            this.gratingComboBox.FormattingEnabled = true;
            this.gratingComboBox.Location = new System.Drawing.Point(20, 31);
            this.gratingComboBox.Name = "gratingComboBox";
            this.gratingComboBox.Size = new System.Drawing.Size(121, 21);
            this.gratingComboBox.TabIndex = 2;
            this.gratingComboBox.SelectedIndexChanged += new System.EventHandler(this.gratingComboBox_SelectedIndexChanged);
            // 
            // relCm1NumericUpDown
            // 
            this.relCm1NumericUpDown.DecimalPlaces = 4;
            this.relCm1NumericUpDown.Location = new System.Drawing.Point(20, 77);
            this.relCm1NumericUpDown.Maximum = new decimal(new int[] {
            2500,
            0,
            0,
            0});
            this.relCm1NumericUpDown.Minimum = new decimal(new int[] {
            100,
            0,
            0,
            -2147483648});
            this.relCm1NumericUpDown.Name = "relCm1NumericUpDown";
            this.relCm1NumericUpDown.Size = new System.Drawing.Size(120, 20);
            this.relCm1NumericUpDown.TabIndex = 3;
            this.relCm1NumericUpDown.ValueChanged += new System.EventHandler(this.relCm1NumericUpDown_ValueChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(20, 58);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(108, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Rel CM1 Zero In (nm)";
            // 
            // freqUnitsComboBox
            // 
            this.freqUnitsComboBox.FormattingEnabled = true;
            this.freqUnitsComboBox.Location = new System.Drawing.Point(147, 123);
            this.freqUnitsComboBox.Name = "freqUnitsComboBox";
            this.freqUnitsComboBox.Size = new System.Drawing.Size(53, 21);
            this.freqUnitsComboBox.TabIndex = 5;
            this.freqUnitsComboBox.SelectedValueChanged += new System.EventHandler(this.freqUnitsComboBox_SelectedValueChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(147, 104);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(31, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "Units";
            // 
            // waveLengthNumericUpDown
            // 
            this.waveLengthNumericUpDown.Location = new System.Drawing.Point(21, 123);
            this.waveLengthNumericUpDown.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.waveLengthNumericUpDown.Minimum = new decimal(new int[] {
            20,
            0,
            0,
            -2147483648});
            this.waveLengthNumericUpDown.Name = "waveLengthNumericUpDown";
            this.waveLengthNumericUpDown.Size = new System.Drawing.Size(120, 20);
            this.waveLengthNumericUpDown.TabIndex = 7;
            this.waveLengthNumericUpDown.ValueChanged += new System.EventHandler(this.waveLengthNumericUpDown_ValueChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(21, 103);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(65, 13);
            this.label3.TabIndex = 8;
            this.label3.Text = "Wavelength";
            // 
            // getWavelengthButton
            // 
            this.getWavelengthButton.Location = new System.Drawing.Point(20, 149);
            this.getWavelengthButton.Name = "getWavelengthButton";
            this.getWavelengthButton.Size = new System.Drawing.Size(75, 23);
            this.getWavelengthButton.TabIndex = 9;
            this.getWavelengthButton.Text = "Get";
            this.getWavelengthButton.UseVisualStyleBackColor = true;
            this.getWavelengthButton.Click += new System.EventHandler(this.getWavelengthButton_Click);
            // 
            // setWavelengthButton
            // 
            this.setWavelengthButton.Location = new System.Drawing.Point(125, 150);
            this.setWavelengthButton.Name = "setWavelengthButton";
            this.setWavelengthButton.Size = new System.Drawing.Size(75, 23);
            this.setWavelengthButton.TabIndex = 10;
            this.setWavelengthButton.Text = "Set";
            this.setWavelengthButton.UseVisualStyleBackColor = true;
            this.setWavelengthButton.Click += new System.EventHandler(this.setWavelengthButton_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(21, 12);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(62, 13);
            this.label4.TabIndex = 11;
            this.label4.Text = "Sel. Grating";
            // 
            // ARC_SpectraProDLL_WrapperTestForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(293, 364);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.setWavelengthButton);
            this.Controls.Add(this.getWavelengthButton);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.waveLengthNumericUpDown);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.freqUnitsComboBox);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.relCm1NumericUpDown);
            this.Controls.Add(this.gratingComboBox);
            this.Controls.Add(this.resultTextBox);
            this.Name = "ARC_SpectraProDLL_WrapperTestForm";
            this.Text = "Acton Monochromator";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ARC_SpectraProDLL_WrapperTestForm_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.relCm1NumericUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.waveLengthNumericUpDown)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox resultTextBox;
        private System.Windows.Forms.ComboBox gratingComboBox;
        private System.Windows.Forms.NumericUpDown relCm1NumericUpDown;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox freqUnitsComboBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown waveLengthNumericUpDown;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button getWavelengthButton;
        private System.Windows.Forms.Button setWavelengthButton;
        private System.Windows.Forms.Label label4;
    }
}

