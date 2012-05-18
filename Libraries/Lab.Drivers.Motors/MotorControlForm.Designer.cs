namespace Lab.Drivers.Motors
{
    partial class MotorControlForm
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
            this.closeButton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.axisComboBox = new System.Windows.Forms.ComboBox();
            this.positionTextBox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.velocityTextBox = new System.Windows.Forms.TextBox();
            this.gotoButton = new System.Windows.Forms.Button();
            this.velocitySetButton = new System.Windows.Forms.Button();
            this.setZeroButton = new System.Windows.Forms.Button();
            this.goHomeButton = new System.Windows.Forms.Button();
            this.hardwareLimitButton = new System.Windows.Forms.Button();
            this.getButton = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.reinitalizeButton = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label6 = new System.Windows.Forms.Label();
            this.stepSizeNumericUpDown = new NumericUpDownCustomIncrement();
            this.upDownReverseCheckBox = new System.Windows.Forms.CheckBox();
            this.leftRightRevCheckBox = new System.Windows.Forms.CheckBox();
            this.panUpButton = new System.Windows.Forms.Button();
            this.panDownButton = new System.Windows.Forms.Button();
            this.verticalComboBox = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.panLeftButton = new System.Windows.Forms.Button();
            this.horizontalComboBox = new System.Windows.Forms.ComboBox();
            this.panRightButton = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.stepSizeNumericUpDown)).BeginInit();
            this.SuspendLayout();
            // 
            // closeButton
            // 
            this.closeButton.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.closeButton.Location = new System.Drawing.Point(344, 413);
            this.closeButton.Name = "closeButton";
            this.closeButton.Size = new System.Drawing.Size(75, 23);
            this.closeButton.TabIndex = 0;
            this.closeButton.Text = "Close";
            this.closeButton.UseVisualStyleBackColor = true;
            this.closeButton.Click += new System.EventHandler(this.closeButton_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(18, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(34, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "Motor";
            // 
            // axisComboBox
            // 
            this.axisComboBox.FormattingEnabled = true;
            this.axisComboBox.Location = new System.Drawing.Point(133, 17);
            this.axisComboBox.Name = "axisComboBox";
            this.axisComboBox.Size = new System.Drawing.Size(210, 21);
            this.axisComboBox.TabIndex = 4;
            this.axisComboBox.TextChanged += new System.EventHandler(this.axisComboBox_TextChanged);
            // 
            // positionTextBox
            // 
            this.positionTextBox.Location = new System.Drawing.Point(133, 45);
            this.positionTextBox.Name = "positionTextBox";
            this.positionTextBox.Size = new System.Drawing.Size(86, 20);
            this.positionTextBox.TabIndex = 6;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(18, 49);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(69, 13);
            this.label2.TabIndex = 7;
            this.label2.Text = "Position (mm)";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(18, 77);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(109, 13);
            this.label3.TabIndex = 9;
            this.label3.Text = "Move Velocity (mm/s)";
            // 
            // velocityTextBox
            // 
            this.velocityTextBox.Location = new System.Drawing.Point(133, 74);
            this.velocityTextBox.Name = "velocityTextBox";
            this.velocityTextBox.Size = new System.Drawing.Size(86, 20);
            this.velocityTextBox.TabIndex = 8;
            // 
            // gotoButton
            // 
            this.gotoButton.Location = new System.Drawing.Point(276, 45);
            this.gotoButton.Name = "gotoButton";
            this.gotoButton.Size = new System.Drawing.Size(48, 23);
            this.gotoButton.TabIndex = 10;
            this.gotoButton.Text = "Goto";
            this.gotoButton.UseVisualStyleBackColor = true;
            this.gotoButton.Click += new System.EventHandler(this.gotoButton_Click);
            // 
            // velocitySetButton
            // 
            this.velocitySetButton.Location = new System.Drawing.Point(225, 73);
            this.velocitySetButton.Name = "velocitySetButton";
            this.velocitySetButton.Size = new System.Drawing.Size(48, 23);
            this.velocitySetButton.TabIndex = 11;
            this.velocitySetButton.Text = "Set";
            this.velocitySetButton.UseVisualStyleBackColor = true;
            this.velocitySetButton.Click += new System.EventHandler(this.velocitySetButton_Click);
            // 
            // setZeroButton
            // 
            this.setZeroButton.Location = new System.Drawing.Point(330, 45);
            this.setZeroButton.Name = "setZeroButton";
            this.setZeroButton.Size = new System.Drawing.Size(64, 23);
            this.setZeroButton.TabIndex = 13;
            this.setZeroButton.Text = "Set Zero";
            this.setZeroButton.UseVisualStyleBackColor = true;
            this.setZeroButton.Click += new System.EventHandler(this.setZeroButton_Click);
            // 
            // goHomeButton
            // 
            this.goHomeButton.Location = new System.Drawing.Point(225, 102);
            this.goHomeButton.Name = "goHomeButton";
            this.goHomeButton.Size = new System.Drawing.Size(60, 23);
            this.goHomeButton.TabIndex = 14;
            this.goHomeButton.Text = "Go Home";
            this.goHomeButton.UseVisualStyleBackColor = true;
            // 
            // hardwareLimitButton
            // 
            this.hardwareLimitButton.Location = new System.Drawing.Point(291, 102);
            this.hardwareLimitButton.Name = "hardwareLimitButton";
            this.hardwareLimitButton.Size = new System.Drawing.Size(94, 23);
            this.hardwareLimitButton.TabIndex = 15;
            this.hardwareLimitButton.Text = "Hardware Limit";
            this.hardwareLimitButton.UseVisualStyleBackColor = true;
            // 
            // getButton
            // 
            this.getButton.Location = new System.Drawing.Point(225, 45);
            this.getButton.Name = "getButton";
            this.getButton.Size = new System.Drawing.Size(48, 23);
            this.getButton.TabIndex = 16;
            this.getButton.Text = "Get";
            this.getButton.UseVisualStyleBackColor = true;
            this.getButton.Click += new System.EventHandler(this.getButton_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.getButton);
            this.groupBox1.Controls.Add(this.axisComboBox);
            this.groupBox1.Controls.Add(this.hardwareLimitButton);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.goHomeButton);
            this.groupBox1.Controls.Add(this.positionTextBox);
            this.groupBox1.Controls.Add(this.setZeroButton);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.velocitySetButton);
            this.groupBox1.Controls.Add(this.velocityTextBox);
            this.groupBox1.Controls.Add(this.gotoButton);
            this.groupBox1.Location = new System.Drawing.Point(12, 52);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(407, 146);
            this.groupBox1.TabIndex = 17;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Axis Properties";
            // 
            // reinitalizeButton
            // 
            this.reinitalizeButton.Location = new System.Drawing.Point(12, 16);
            this.reinitalizeButton.Name = "reinitalizeButton";
            this.reinitalizeButton.Size = new System.Drawing.Size(75, 23);
            this.reinitalizeButton.TabIndex = 18;
            this.reinitalizeButton.Text = "Reinitalize";
            this.reinitalizeButton.UseVisualStyleBackColor = true;
            this.reinitalizeButton.Click += new System.EventHandler(this.reinitalizeButton_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.stepSizeNumericUpDown);
            this.groupBox2.Controls.Add(this.upDownReverseCheckBox);
            this.groupBox2.Controls.Add(this.leftRightRevCheckBox);
            this.groupBox2.Controls.Add(this.panUpButton);
            this.groupBox2.Controls.Add(this.panDownButton);
            this.groupBox2.Controls.Add(this.verticalComboBox);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.panLeftButton);
            this.groupBox2.Controls.Add(this.horizontalComboBox);
            this.groupBox2.Controls.Add(this.panRightButton);
            this.groupBox2.Location = new System.Drawing.Point(12, 204);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(407, 203);
            this.groupBox2.TabIndex = 19;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Pan Control";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(13, 140);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(75, 13);
            this.label6.TabIndex = 11;
            this.label6.Text = "Step Size (um)";
            // 
            // stepSizeNumericUpDown
            // 
            this.stepSizeNumericUpDown.DecimalPlaces = 2;
            this.stepSizeNumericUpDown.Location = new System.Drawing.Point(13, 157);
            this.stepSizeNumericUpDown.Maximum = new decimal(new int[] {
            10000000,
            0,
            0,
            0});
            this.stepSizeNumericUpDown.Name = "stepSizeNumericUpDown";
            this.stepSizeNumericUpDown.Size = new System.Drawing.Size(120, 20);
            this.stepSizeNumericUpDown.TabIndex = 10;
            this.stepSizeNumericUpDown.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
            // 
            // upDownReverseCheckBox
            // 
            this.upDownReverseCheckBox.AutoSize = true;
            this.upDownReverseCheckBox.Checked = true;
            this.upDownReverseCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.upDownReverseCheckBox.Location = new System.Drawing.Point(14, 57);
            this.upDownReverseCheckBox.Name = "upDownReverseCheckBox";
            this.upDownReverseCheckBox.Size = new System.Drawing.Size(66, 17);
            this.upDownReverseCheckBox.TabIndex = 9;
            this.upDownReverseCheckBox.Text = "Reverse";
            this.upDownReverseCheckBox.UseVisualStyleBackColor = true;
            // 
            // leftRightRevCheckBox
            // 
            this.leftRightRevCheckBox.AutoSize = true;
            this.leftRightRevCheckBox.Checked = true;
            this.leftRightRevCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.leftRightRevCheckBox.Location = new System.Drawing.Point(14, 119);
            this.leftRightRevCheckBox.Name = "leftRightRevCheckBox";
            this.leftRightRevCheckBox.Size = new System.Drawing.Size(66, 17);
            this.leftRightRevCheckBox.TabIndex = 8;
            this.leftRightRevCheckBox.Text = "Reverse";
            this.leftRightRevCheckBox.UseVisualStyleBackColor = true;
            // 
            // panUpButton
            // 
            this.panUpButton.Location = new System.Drawing.Point(257, 46);
            this.panUpButton.Name = "panUpButton";
            this.panUpButton.Size = new System.Drawing.Size(34, 23);
            this.panUpButton.TabIndex = 0;
            this.panUpButton.Text = "Up";
            this.panUpButton.UseVisualStyleBackColor = true;
            this.panUpButton.Click += new System.EventHandler(this.panUpButton_Click);
            // 
            // panDownButton
            // 
            this.panDownButton.Location = new System.Drawing.Point(248, 135);
            this.panDownButton.Name = "panDownButton";
            this.panDownButton.Size = new System.Drawing.Size(50, 23);
            this.panDownButton.TabIndex = 1;
            this.panDownButton.Text = "Down";
            this.panDownButton.UseVisualStyleBackColor = true;
            this.panDownButton.Click += new System.EventHandler(this.panDownButton_Click);
            // 
            // verticalComboBox
            // 
            this.verticalComboBox.FormattingEnabled = true;
            this.verticalComboBox.Location = new System.Drawing.Point(14, 33);
            this.verticalComboBox.Name = "verticalComboBox";
            this.verticalComboBox.Size = new System.Drawing.Size(169, 21);
            this.verticalComboBox.TabIndex = 4;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(14, 17);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(124, 13);
            this.label4.TabIndex = 5;
            this.label4.Text = "Vertical (up/down) Motor";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(14, 79);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(132, 13);
            this.label5.TabIndex = 7;
            this.label5.Text = "Horizontal (left/right) Motor";
            // 
            // panLeftButton
            // 
            this.panLeftButton.Location = new System.Drawing.Point(199, 95);
            this.panLeftButton.Name = "panLeftButton";
            this.panLeftButton.Size = new System.Drawing.Size(29, 23);
            this.panLeftButton.TabIndex = 2;
            this.panLeftButton.Text = "<<";
            this.panLeftButton.UseVisualStyleBackColor = true;
            this.panLeftButton.Click += new System.EventHandler(this.panLeftButton_Click);
            // 
            // horizontalComboBox
            // 
            this.horizontalComboBox.FormattingEnabled = true;
            this.horizontalComboBox.Location = new System.Drawing.Point(14, 95);
            this.horizontalComboBox.Name = "horizontalComboBox";
            this.horizontalComboBox.Size = new System.Drawing.Size(169, 21);
            this.horizontalComboBox.TabIndex = 6;
            // 
            // panRightButton
            // 
            this.panRightButton.Location = new System.Drawing.Point(325, 96);
            this.panRightButton.Name = "panRightButton";
            this.panRightButton.Size = new System.Drawing.Size(28, 23);
            this.panRightButton.TabIndex = 3;
            this.panRightButton.Text = ">>";
            this.panRightButton.UseVisualStyleBackColor = true;
            this.panRightButton.Click += new System.EventHandler(this.panRightButton_Click);
            // 
            // MotorControlForm
            // 
            this.AcceptButton = this.closeButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(433, 442);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.reinitalizeButton);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.closeButton);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "MotorControlForm";
            this.Text = "MotorControlForm";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MotorControlForm_FormClosing);
            this.Load += new System.EventHandler(this.MotorControlForm_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.stepSizeNumericUpDown)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button closeButton;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox axisComboBox;
        private System.Windows.Forms.TextBox positionTextBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox velocityTextBox;
        private System.Windows.Forms.Button gotoButton;
        private System.Windows.Forms.Button velocitySetButton;
        private System.Windows.Forms.Button setZeroButton;
        private System.Windows.Forms.Button goHomeButton;
        private System.Windows.Forms.Button hardwareLimitButton;
        private System.Windows.Forms.Button getButton;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button reinitalizeButton;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.CheckBox upDownReverseCheckBox;
        private System.Windows.Forms.CheckBox leftRightRevCheckBox;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox horizontalComboBox;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox verticalComboBox;
        private System.Windows.Forms.Button panRightButton;
        private System.Windows.Forms.Button panLeftButton;
        private System.Windows.Forms.Button panDownButton;
        private System.Windows.Forms.Button panUpButton;
        private System.Windows.Forms.Label label6;
        private NumericUpDownCustomIncrement stepSizeNumericUpDown;
    }
}