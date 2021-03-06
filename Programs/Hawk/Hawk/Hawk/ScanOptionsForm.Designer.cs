namespace Lab.Programs.Hawk
{
    partial class ScanOptionsForm
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
            this.OKButton = new System.Windows.Forms.Button();
            this.cancelButton = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.cuttingAxisMotorComboBox = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.cuttingAxisHoldTimeNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.cuttingAxisNumPointsNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.label4 = new System.Windows.Forms.Label();
            this.cuttingAxisSampleAndHoldCheckBox = new System.Windows.Forms.CheckBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cuttingAxisRadiusNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.zAxisNumPointsNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.label9 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.zAxisMotorComboBox = new System.Windows.Forms.ComboBox();
            this.label12 = new System.Windows.Forms.Label();
            this.zAxisRadiusNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.zAxisScanCheckBox = new System.Windows.Forms.CheckBox();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cuttingAxisHoldTimeNumericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cuttingAxisNumPointsNumericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cuttingAxisRadiusNumericUpDown)).BeginInit();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.zAxisNumPointsNumericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.zAxisRadiusNumericUpDown)).BeginInit();
            this.SuspendLayout();
            // 
            // OKButton
            // 
            this.OKButton.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.OKButton.Location = new System.Drawing.Point(12, 411);
            this.OKButton.Name = "OKButton";
            this.OKButton.Size = new System.Drawing.Size(75, 23);
            this.OKButton.TabIndex = 0;
            this.OKButton.Text = "OK";
            this.OKButton.UseVisualStyleBackColor = true;
            // 
            // cancelButton
            // 
            this.cancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cancelButton.Location = new System.Drawing.Point(176, 411);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(75, 23);
            this.cancelButton.TabIndex = 1;
            this.cancelButton.Text = "Cancel";
            this.cancelButton.UseVisualStyleBackColor = true;
            this.cancelButton.Click += new System.EventHandler(this.cancelButton_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.cuttingAxisMotorComboBox);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.cuttingAxisHoldTimeNumericUpDown);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.cuttingAxisNumPointsNumericUpDown);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.cuttingAxisSampleAndHoldCheckBox);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.cuttingAxisRadiusNumericUpDown);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(239, 186);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Cutting Axis Parameters";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(98, 59);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(40, 13);
            this.label6.TabIndex = 19;
            this.label6.Text = "Radius";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(149, 30);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(34, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Motor";
            // 
            // cuttingAxisMotorComboBox
            // 
            this.cuttingAxisMotorComboBox.FormattingEnabled = true;
            this.cuttingAxisMotorComboBox.Location = new System.Drawing.Point(22, 27);
            this.cuttingAxisMotorComboBox.Name = "cuttingAxisMotorComboBox";
            this.cuttingAxisMotorComboBox.Size = new System.Drawing.Size(121, 21);
            this.cuttingAxisMotorComboBox.TabIndex = 3;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(150, 150);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(26, 13);
            this.label5.TabIndex = 18;
            this.label5.Text = "(ms)";
            // 
            // cuttingAxisHoldTimeNumericUpDown
            // 
            this.cuttingAxisHoldTimeNumericUpDown.Enabled = false;
            this.cuttingAxisHoldTimeNumericUpDown.Location = new System.Drawing.Point(22, 148);
            this.cuttingAxisHoldTimeNumericUpDown.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.cuttingAxisHoldTimeNumericUpDown.Name = "cuttingAxisHoldTimeNumericUpDown";
            this.cuttingAxisHoldTimeNumericUpDown.Size = new System.Drawing.Size(70, 20);
            this.cuttingAxisHoldTimeNumericUpDown.TabIndex = 17;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(97, 150);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(55, 13);
            this.label3.TabIndex = 16;
            this.label3.Text = "Hold Time";
            // 
            // cuttingAxisNumPointsNumericUpDown
            // 
            this.cuttingAxisNumPointsNumericUpDown.Enabled = false;
            this.cuttingAxisNumPointsNumericUpDown.Location = new System.Drawing.Point(22, 120);
            this.cuttingAxisNumPointsNumericUpDown.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.cuttingAxisNumPointsNumericUpDown.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.cuttingAxisNumPointsNumericUpDown.Name = "cuttingAxisNumPointsNumericUpDown";
            this.cuttingAxisNumPointsNumericUpDown.Size = new System.Drawing.Size(70, 20);
            this.cuttingAxisNumPointsNumericUpDown.TabIndex = 15;
            this.cuttingAxisNumPointsNumericUpDown.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(98, 122);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(88, 13);
            this.label4.TabIndex = 14;
            this.label4.Text = "Number of Points";
            // 
            // cuttingAxisSampleAndHoldCheckBox
            // 
            this.cuttingAxisSampleAndHoldCheckBox.AutoSize = true;
            this.cuttingAxisSampleAndHoldCheckBox.Checked = true;
            this.cuttingAxisSampleAndHoldCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cuttingAxisSampleAndHoldCheckBox.Enabled = false;
            this.cuttingAxisSampleAndHoldCheckBox.Location = new System.Drawing.Point(22, 97);
            this.cuttingAxisSampleAndHoldCheckBox.Name = "cuttingAxisSampleAndHoldCheckBox";
            this.cuttingAxisSampleAndHoldCheckBox.Size = new System.Drawing.Size(107, 17);
            this.cuttingAxisSampleAndHoldCheckBox.TabIndex = 13;
            this.cuttingAxisSampleAndHoldCheckBox.Text = "Sample and Hold";
            this.cuttingAxisSampleAndHoldCheckBox.UseVisualStyleBackColor = true;
            this.cuttingAxisSampleAndHoldCheckBox.CheckedChanged += new System.EventHandler(this.cuttingAxisSampleAndHoldCheckBox_CheckedChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(144, 59);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(27, 13);
            this.label2.TabIndex = 12;
            this.label2.Text = "(um)";
            // 
            // cuttingAxisRadiusNumericUpDown
            // 
            this.cuttingAxisRadiusNumericUpDown.Location = new System.Drawing.Point(22, 57);
            this.cuttingAxisRadiusNumericUpDown.Maximum = new decimal(new int[] {
            20000,
            0,
            0,
            0});
            this.cuttingAxisRadiusNumericUpDown.Name = "cuttingAxisRadiusNumericUpDown";
            this.cuttingAxisRadiusNumericUpDown.Size = new System.Drawing.Size(70, 20);
            this.cuttingAxisRadiusNumericUpDown.TabIndex = 11;
            this.cuttingAxisRadiusNumericUpDown.Value = new decimal(new int[] {
            1000,
            0,
            0,
            0});
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
            this.groupBox2.Location = new System.Drawing.Point(12, 231);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(239, 145);
            this.groupBox2.TabIndex = 3;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Z Axis Parameters";
            // 
            // zAxisNumPointsNumericUpDown
            // 
            this.zAxisNumPointsNumericUpDown.Enabled = false;
            this.zAxisNumPointsNumericUpDown.Location = new System.Drawing.Point(22, 83);
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
            this.label9.Location = new System.Drawing.Point(98, 85);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(88, 13);
            this.label9.TabIndex = 20;
            this.label9.Text = "Number of Points";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(98, 59);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(40, 13);
            this.label7.TabIndex = 19;
            this.label7.Text = "Radius";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(149, 30);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(34, 13);
            this.label8.TabIndex = 3;
            this.label8.Text = "Motor";
            // 
            // zAxisMotorComboBox
            // 
            this.zAxisMotorComboBox.Enabled = false;
            this.zAxisMotorComboBox.FormattingEnabled = true;
            this.zAxisMotorComboBox.Location = new System.Drawing.Point(22, 27);
            this.zAxisMotorComboBox.Name = "zAxisMotorComboBox";
            this.zAxisMotorComboBox.Size = new System.Drawing.Size(121, 21);
            this.zAxisMotorComboBox.TabIndex = 3;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(144, 59);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(27, 13);
            this.label12.TabIndex = 12;
            this.label12.Text = "(um)";
            // 
            // zAxisRadiusNumericUpDown
            // 
            this.zAxisRadiusNumericUpDown.Enabled = false;
            this.zAxisRadiusNumericUpDown.Location = new System.Drawing.Point(22, 57);
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
            // zAxisScanCheckBox
            // 
            this.zAxisScanCheckBox.AutoSize = true;
            this.zAxisScanCheckBox.Enabled = false;
            this.zAxisScanCheckBox.Location = new System.Drawing.Point(24, 208);
            this.zAxisScanCheckBox.Name = "zAxisScanCheckBox";
            this.zAxisScanCheckBox.Size = new System.Drawing.Size(83, 17);
            this.zAxisScanCheckBox.TabIndex = 4;
            this.zAxisScanCheckBox.Text = "Z Axis Scan";
            this.zAxisScanCheckBox.UseVisualStyleBackColor = true;
            this.zAxisScanCheckBox.CheckedChanged += new System.EventHandler(this.zAxisScanCheckBox_CheckedChanged);
            // 
            // ScanOptionsForm
            // 
            this.AcceptButton = this.OKButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.CancelButton = this.cancelButton;
            this.ClientSize = new System.Drawing.Size(265, 446);
            this.Controls.Add(this.zAxisScanCheckBox);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.OKButton);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "ScanOptionsForm";
            this.Text = "ScanOptions";
            this.Shown += new System.EventHandler(this.ScanOptionsForm_Shown);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cuttingAxisHoldTimeNumericUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cuttingAxisNumPointsNumericUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cuttingAxisRadiusNumericUpDown)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.zAxisNumPointsNumericUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.zAxisRadiusNumericUpDown)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button OKButton;
        private System.Windows.Forms.Button cancelButton;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cuttingAxisMotorComboBox;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.NumericUpDown cuttingAxisHoldTimeNumericUpDown;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.NumericUpDown cuttingAxisNumPointsNumericUpDown;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.CheckBox cuttingAxisSampleAndHoldCheckBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown cuttingAxisRadiusNumericUpDown;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ComboBox zAxisMotorComboBox;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.NumericUpDown zAxisRadiusNumericUpDown;
        private System.Windows.Forms.NumericUpDown zAxisNumPointsNumericUpDown;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.CheckBox zAxisScanCheckBox;
    }
}