namespace Squid
{
    partial class SquidOptionsForm
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
            this.okButton = new System.Windows.Forms.Button();
            this.cancelButton = new System.Windows.Forms.Button();
            this.DCFrequencyCheckBox = new System.Windows.Forms.CheckBox();
            this.ampUnitsComboBox = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.pretriggerNumeric = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.reducedSamplesPow2numeric = new System.Windows.Forms.NumericUpDown();
            this.numReducedSamplesLabel = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.fallingRadioButton = new System.Windows.Forms.RadioButton();
            this.risingRadioButton = new System.Windows.Forms.RadioButton();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.zAxisNumPointsNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.label9 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.zAxisMotorComboBox = new System.Windows.Forms.ComboBox();
            this.label12 = new System.Windows.Forms.Label();
            this.zAxisRadiusNumericUpDown = new System.Windows.Forms.NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)(this.pretriggerNumeric)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.reducedSamplesPow2numeric)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.zAxisNumPointsNumericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.zAxisRadiusNumericUpDown)).BeginInit();
            this.SuspendLayout();
            // 
            // okButton
            // 
            this.okButton.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.okButton.Location = new System.Drawing.Point(12, 223);
            this.okButton.Name = "okButton";
            this.okButton.Size = new System.Drawing.Size(75, 23);
            this.okButton.TabIndex = 0;
            this.okButton.Text = "OK";
            this.okButton.UseVisualStyleBackColor = true;
            // 
            // cancelButton
            // 
            this.cancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cancelButton.Location = new System.Drawing.Point(306, 223);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(75, 23);
            this.cancelButton.TabIndex = 1;
            this.cancelButton.Text = "Cancel";
            this.cancelButton.UseVisualStyleBackColor = true;
            this.cancelButton.Click += new System.EventHandler(this.cancelButton_Click);
            // 
            // DCFrequencyCheckBox
            // 
            this.DCFrequencyCheckBox.AutoSize = true;
            this.DCFrequencyCheckBox.Checked = true;
            this.DCFrequencyCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.DCFrequencyCheckBox.Location = new System.Drawing.Point(12, 66);
            this.DCFrequencyCheckBox.Name = "DCFrequencyCheckBox";
            this.DCFrequencyCheckBox.Size = new System.Drawing.Size(115, 17);
            this.DCFrequencyCheckBox.TabIndex = 2;
            this.DCFrequencyCheckBox.Text = "Plot DC Frequency";
            this.DCFrequencyCheckBox.UseVisualStyleBackColor = true;
            // 
            // ampUnitsComboBox
            // 
            this.ampUnitsComboBox.FormattingEnabled = true;
            this.ampUnitsComboBox.Location = new System.Drawing.Point(12, 39);
            this.ampUnitsComboBox.Name = "ampUnitsComboBox";
            this.ampUnitsComboBox.Size = new System.Drawing.Size(121, 21);
            this.ampUnitsComboBox.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(108, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Frequency Amp Units";
            // 
            // pretriggerNumeric
            // 
            this.pretriggerNumeric.Location = new System.Drawing.Point(12, 105);
            this.pretriggerNumeric.Maximum = new decimal(new int[] {
            2000,
            0,
            0,
            0});
            this.pretriggerNumeric.Name = "pretriggerNumeric";
            this.pretriggerNumeric.Size = new System.Drawing.Size(120, 20);
            this.pretriggerNumeric.TabIndex = 5;
            this.pretriggerNumeric.ValueChanged += new System.EventHandler(this.pretriggerNumeric_ValueChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 89);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(153, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "Number of Pretriggered Samles";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 179);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(179, 13);
            this.label3.TabIndex = 8;
            this.label3.Text = "Number of Reduced Samples Pow 2";
            // 
            // reducedSamplesPow2numeric
            // 
            this.reducedSamplesPow2numeric.Location = new System.Drawing.Point(15, 197);
            this.reducedSamplesPow2numeric.Maximum = new decimal(new int[] {
            2000,
            0,
            0,
            0});
            this.reducedSamplesPow2numeric.Name = "reducedSamplesPow2numeric";
            this.reducedSamplesPow2numeric.Size = new System.Drawing.Size(42, 20);
            this.reducedSamplesPow2numeric.TabIndex = 7;
            this.reducedSamplesPow2numeric.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.reducedSamplesPow2numeric.ValueChanged += new System.EventHandler(this.reducedSamplesPow2numeric_ValueChanged);
            // 
            // numReducedSamplesLabel
            // 
            this.numReducedSamplesLabel.AutoSize = true;
            this.numReducedSamplesLabel.Location = new System.Drawing.Point(63, 201);
            this.numReducedSamplesLabel.Name = "numReducedSamplesLabel";
            this.numReducedSamplesLabel.Size = new System.Drawing.Size(31, 13);
            this.numReducedSamplesLabel.TabIndex = 9;
            this.numReducedSamplesLabel.Text = "1024";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.fallingRadioButton);
            this.groupBox1.Controls.Add(this.risingRadioButton);
            this.groupBox1.Location = new System.Drawing.Point(12, 131);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(141, 36);
            this.groupBox1.TabIndex = 10;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Trigger Edge";
            // 
            // fallingRadioButton
            // 
            this.fallingRadioButton.AutoSize = true;
            this.fallingRadioButton.Location = new System.Drawing.Point(66, 16);
            this.fallingRadioButton.Name = "fallingRadioButton";
            this.fallingRadioButton.Size = new System.Drawing.Size(55, 17);
            this.fallingRadioButton.TabIndex = 12;
            this.fallingRadioButton.Text = "Falling";
            this.fallingRadioButton.UseVisualStyleBackColor = true;
            // 
            // risingRadioButton
            // 
            this.risingRadioButton.AutoSize = true;
            this.risingRadioButton.Checked = true;
            this.risingRadioButton.Location = new System.Drawing.Point(6, 16);
            this.risingRadioButton.Name = "risingRadioButton";
            this.risingRadioButton.Size = new System.Drawing.Size(54, 17);
            this.risingRadioButton.TabIndex = 11;
            this.risingRadioButton.TabStop = true;
            this.risingRadioButton.Text = "Rising";
            this.risingRadioButton.UseVisualStyleBackColor = true;
            this.risingRadioButton.CheckedChanged += new System.EventHandler(this.risingRadioButton_CheckedChanged);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.zAxisNumPointsNumericUpDown);
            this.groupBox2.Controls.Add(this.label9);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.label8);
            this.groupBox2.Controls.Add(this.zAxisMotorComboBox);
            this.groupBox2.Controls.Add(this.label12);
            this.groupBox2.Controls.Add(this.zAxisRadiusNumericUpDown);
            this.groupBox2.Location = new System.Drawing.Point(194, 23);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(182, 102);
            this.groupBox2.TabIndex = 11;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Z Axis Parameters";
            // 
            // zAxisNumPointsNumericUpDown
            // 
            this.zAxisNumPointsNumericUpDown.Enabled = false;
            this.zAxisNumPointsNumericUpDown.Location = new System.Drawing.Point(13, 72);
            this.zAxisNumPointsNumericUpDown.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.zAxisNumPointsNumericUpDown.Minimum = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.zAxisNumPointsNumericUpDown.Name = "zAxisNumPointsNumericUpDown";
            this.zAxisNumPointsNumericUpDown.Size = new System.Drawing.Size(70, 20);
            this.zAxisNumPointsNumericUpDown.TabIndex = 21;
            this.zAxisNumPointsNumericUpDown.Value = new decimal(new int[] {
            2,
            0,
            0,
            0});
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(89, 74);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(88, 13);
            this.label9.TabIndex = 20;
            this.label9.Text = "Number of Points";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(89, 51);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(40, 13);
            this.label7.TabIndex = 19;
            this.label7.Text = "Radius";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(140, 24);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(34, 13);
            this.label8.TabIndex = 3;
            this.label8.Text = "Motor";
            // 
            // zAxisMotorComboBox
            // 
            this.zAxisMotorComboBox.Enabled = false;
            this.zAxisMotorComboBox.FormattingEnabled = true;
            this.zAxisMotorComboBox.Location = new System.Drawing.Point(13, 19);
            this.zAxisMotorComboBox.Name = "zAxisMotorComboBox";
            this.zAxisMotorComboBox.Size = new System.Drawing.Size(121, 21);
            this.zAxisMotorComboBox.TabIndex = 3;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(135, 51);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(27, 13);
            this.label12.TabIndex = 12;
            this.label12.Text = "(um)";
            // 
            // zAxisRadiusNumericUpDown
            // 
            this.zAxisRadiusNumericUpDown.Enabled = false;
            this.zAxisRadiusNumericUpDown.Location = new System.Drawing.Point(13, 46);
            this.zAxisRadiusNumericUpDown.Maximum = new decimal(new int[] {
            20000,
            0,
            0,
            0});
            this.zAxisRadiusNumericUpDown.Name = "zAxisRadiusNumericUpDown";
            this.zAxisRadiusNumericUpDown.Size = new System.Drawing.Size(70, 20);
            this.zAxisRadiusNumericUpDown.TabIndex = 11;
            this.zAxisRadiusNumericUpDown.Value = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            // 
            // SquidOptionsForm
            // 
            this.AcceptButton = this.okButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.cancelButton;
            this.ClientSize = new System.Drawing.Size(388, 253);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.numReducedSamplesLabel);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.reducedSamplesPow2numeric);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.pretriggerNumeric);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.ampUnitsComboBox);
            this.Controls.Add(this.DCFrequencyCheckBox);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.okButton);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "SquidOptionsForm";
            this.Text = "Squid Options";
            this.Shown += new System.EventHandler(this.SquidOptions_Shown);
            ((System.ComponentModel.ISupportInitialize)(this.pretriggerNumeric)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.reducedSamplesPow2numeric)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.zAxisNumPointsNumericUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.zAxisRadiusNumericUpDown)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button okButton;
        private System.Windows.Forms.Button cancelButton;
        private System.Windows.Forms.CheckBox DCFrequencyCheckBox;
        private System.Windows.Forms.ComboBox ampUnitsComboBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown pretriggerNumeric;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.NumericUpDown reducedSamplesPow2numeric;
        private System.Windows.Forms.Label numReducedSamplesLabel;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton fallingRadioButton;
        private System.Windows.Forms.RadioButton risingRadioButton;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.NumericUpDown zAxisNumPointsNumericUpDown;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ComboBox zAxisMotorComboBox;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.NumericUpDown zAxisRadiusNumericUpDown;
    }
}