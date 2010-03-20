namespace Squid
{
    partial class ChopperMotorControlForm
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
            this.voltageOutput = new System.Windows.Forms.TextBox();
            this.startButton = new System.Windows.Forms.Button();
            this.voltageOutputLabel = new System.Windows.Forms.Label();
            this.physicalChannelComboBox = new System.Windows.Forms.ComboBox();
            this.physicalChannelLabel = new System.Windows.Forms.Label();
            this.stopButton = new System.Windows.Forms.Button();
            this.reverseCheckBox = new System.Windows.Forms.CheckBox();
            this.close = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // voltageOutput
            // 
            this.voltageOutput.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.voltageOutput.Location = new System.Drawing.Point(120, 60);
            this.voltageOutput.Name = "voltageOutput";
            this.voltageOutput.Size = new System.Drawing.Size(89, 20);
            this.voltageOutput.TabIndex = 6;
            this.voltageOutput.Text = "0";
            // 
            // startButton
            // 
            this.startButton.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.startButton.Location = new System.Drawing.Point(19, 119);
            this.startButton.Name = "startButton";
            this.startButton.Size = new System.Drawing.Size(75, 23);
            this.startButton.TabIndex = 4;
            this.startButton.Text = "&Start";
            this.startButton.Click += new System.EventHandler(this.startButton_Click);
            // 
            // voltageOutputLabel
            // 
            this.voltageOutputLabel.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.voltageOutputLabel.Location = new System.Drawing.Point(16, 60);
            this.voltageOutputLabel.Name = "voltageOutputLabel";
            this.voltageOutputLabel.Size = new System.Drawing.Size(104, 16);
            this.voltageOutputLabel.TabIndex = 5;
            this.voltageOutputLabel.Text = "Voltage Output (V):";
            // 
            // physicalChannelComboBox
            // 
            this.physicalChannelComboBox.Location = new System.Drawing.Point(120, 25);
            this.physicalChannelComboBox.Name = "physicalChannelComboBox";
            this.physicalChannelComboBox.Size = new System.Drawing.Size(160, 21);
            this.physicalChannelComboBox.TabIndex = 8;
            this.physicalChannelComboBox.Text = "Dev1/ao0";
            // 
            // physicalChannelLabel
            // 
            this.physicalChannelLabel.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.physicalChannelLabel.Location = new System.Drawing.Point(16, 27);
            this.physicalChannelLabel.Name = "physicalChannelLabel";
            this.physicalChannelLabel.Size = new System.Drawing.Size(104, 16);
            this.physicalChannelLabel.TabIndex = 7;
            this.physicalChannelLabel.Text = "Physical Channel:";
            // 
            // stopButton
            // 
            this.stopButton.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.stopButton.Location = new System.Drawing.Point(120, 119);
            this.stopButton.Name = "stopButton";
            this.stopButton.Size = new System.Drawing.Size(75, 23);
            this.stopButton.TabIndex = 9;
            this.stopButton.Text = "&Stop";
            this.stopButton.Click += new System.EventHandler(this.stopButton_Click);
            // 
            // reverseCheckBox
            // 
            this.reverseCheckBox.AutoSize = true;
            this.reverseCheckBox.Location = new System.Drawing.Point(214, 86);
            this.reverseCheckBox.Name = "reverseCheckBox";
            this.reverseCheckBox.Size = new System.Drawing.Size(66, 17);
            this.reverseCheckBox.TabIndex = 10;
            this.reverseCheckBox.Text = "Reverse";
            this.reverseCheckBox.UseVisualStyleBackColor = true;
            this.reverseCheckBox.CheckedChanged += new System.EventHandler(this.reverseCheckBox_CheckedChanged);
            // 
            // close
            // 
            this.close.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.close.Location = new System.Drawing.Point(214, 119);
            this.close.Name = "close";
            this.close.Size = new System.Drawing.Size(75, 23);
            this.close.TabIndex = 11;
            this.close.Text = "&Close";
            this.close.Click += new System.EventHandler(this.close_Click);
            // 
            // MotorControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(302, 158);
            this.Controls.Add(this.close);
            this.Controls.Add(this.reverseCheckBox);
            this.Controls.Add(this.stopButton);
            this.Controls.Add(this.physicalChannelComboBox);
            this.Controls.Add(this.physicalChannelLabel);
            this.Controls.Add(this.voltageOutput);
            this.Controls.Add(this.startButton);
            this.Controls.Add(this.voltageOutputLabel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "MotorControl";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox voltageOutput;
        private System.Windows.Forms.Button startButton;
        private System.Windows.Forms.Label voltageOutputLabel;
        private System.Windows.Forms.ComboBox physicalChannelComboBox;
        private System.Windows.Forms.Label physicalChannelLabel;
        private System.Windows.Forms.Button stopButton;
        private System.Windows.Forms.CheckBox reverseCheckBox;
        private System.Windows.Forms.Button close;
    }
}