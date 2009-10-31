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
            this.SuspendLayout();
            // 
            // closeButton
            // 
            this.closeButton.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.closeButton.Location = new System.Drawing.Point(296, 129);
            this.closeButton.Name = "closeButton";
            this.closeButton.Size = new System.Drawing.Size(75, 23);
            this.closeButton.TabIndex = 0;
            this.closeButton.Text = "Close";
            this.closeButton.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(4, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(34, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "Motor";
            // 
            // axisComboBox
            // 
            this.axisComboBox.FormattingEnabled = true;
            this.axisComboBox.Location = new System.Drawing.Point(119, 15);
            this.axisComboBox.Name = "axisComboBox";
            this.axisComboBox.Size = new System.Drawing.Size(210, 21);
            this.axisComboBox.TabIndex = 4;
            // 
            // positionTextBox
            // 
            this.positionTextBox.Location = new System.Drawing.Point(119, 43);
            this.positionTextBox.Name = "positionTextBox";
            this.positionTextBox.Size = new System.Drawing.Size(86, 20);
            this.positionTextBox.TabIndex = 6;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(4, 47);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(69, 13);
            this.label2.TabIndex = 7;
            this.label2.Text = "Position (mm)";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(4, 75);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(109, 13);
            this.label3.TabIndex = 9;
            this.label3.Text = "Move Velocity (mm/s)";
            // 
            // velocityTextBox
            // 
            this.velocityTextBox.Location = new System.Drawing.Point(119, 72);
            this.velocityTextBox.Name = "velocityTextBox";
            this.velocityTextBox.Size = new System.Drawing.Size(86, 20);
            this.velocityTextBox.TabIndex = 8;
            // 
            // gotoButton
            // 
            this.gotoButton.Location = new System.Drawing.Point(211, 42);
            this.gotoButton.Name = "gotoButton";
            this.gotoButton.Size = new System.Drawing.Size(48, 23);
            this.gotoButton.TabIndex = 10;
            this.gotoButton.Text = "Goto";
            this.gotoButton.UseVisualStyleBackColor = true;
            this.gotoButton.Click += new System.EventHandler(this.gotoButton_Click);
            // 
            // velocitySetButton
            // 
            this.velocitySetButton.Location = new System.Drawing.Point(211, 71);
            this.velocitySetButton.Name = "velocitySetButton";
            this.velocitySetButton.Size = new System.Drawing.Size(48, 23);
            this.velocitySetButton.TabIndex = 11;
            this.velocitySetButton.Text = "Set";
            this.velocitySetButton.UseVisualStyleBackColor = true;
            this.velocitySetButton.Click += new System.EventHandler(this.velocitySetButton_Click);
            // 
            // setZeroButton
            // 
            this.setZeroButton.Location = new System.Drawing.Point(265, 42);
            this.setZeroButton.Name = "setZeroButton";
            this.setZeroButton.Size = new System.Drawing.Size(64, 23);
            this.setZeroButton.TabIndex = 13;
            this.setZeroButton.Text = "Set Zero";
            this.setZeroButton.UseVisualStyleBackColor = true;
            // 
            // goHomeButton
            // 
            this.goHomeButton.Location = new System.Drawing.Point(211, 100);
            this.goHomeButton.Name = "goHomeButton";
            this.goHomeButton.Size = new System.Drawing.Size(60, 23);
            this.goHomeButton.TabIndex = 14;
            this.goHomeButton.Text = "Go Home";
            this.goHomeButton.UseVisualStyleBackColor = true;
            // 
            // hardwareLimitButton
            // 
            this.hardwareLimitButton.Location = new System.Drawing.Point(277, 100);
            this.hardwareLimitButton.Name = "hardwareLimitButton";
            this.hardwareLimitButton.Size = new System.Drawing.Size(94, 23);
            this.hardwareLimitButton.TabIndex = 15;
            this.hardwareLimitButton.Text = "Hardware Limit";
            this.hardwareLimitButton.UseVisualStyleBackColor = true;
            // 
            // MotorControlForm
            // 
            this.AcceptButton = this.closeButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(381, 162);
            this.Controls.Add(this.hardwareLimitButton);
            this.Controls.Add(this.goHomeButton);
            this.Controls.Add(this.setZeroButton);
            this.Controls.Add(this.velocitySetButton);
            this.Controls.Add(this.gotoButton);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.velocityTextBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.positionTextBox);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.axisComboBox);
            this.Controls.Add(this.closeButton);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "MotorControlForm";
            this.Text = "MotorControlForm";
            this.ResumeLayout(false);
            this.PerformLayout();

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
    }
}