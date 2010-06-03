namespace Squid
{
    partial class ChirpControl
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
            this.timingParametersGroupBox = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.durationNumeric = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.stopFreqNumeric = new System.Windows.Forms.NumericUpDown();
            this.startFreqNumeric = new System.Windows.Forms.NumericUpDown();
            this.frequencyLabel = new System.Windows.Forms.Label();
            this.channelParametersGroupBox = new System.Windows.Forms.GroupBox();
            this.maxValueNumeric = new System.Windows.Forms.NumericUpDown();
            this.minValueNumeric = new System.Windows.Forms.NumericUpDown();
            this.physicalChannelComboBox = new System.Windows.Forms.ComboBox();
            this.physicalChannelLabel = new System.Windows.Forms.Label();
            this.maximumLabel = new System.Windows.Forms.Label();
            this.minimumLabel = new System.Windows.Forms.Label();
            this.OK_button = new System.Windows.Forms.Button();
            this.cancelButton = new System.Windows.Forms.Button();
            this.timingParametersGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.durationNumeric)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.stopFreqNumeric)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.startFreqNumeric)).BeginInit();
            this.channelParametersGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.maxValueNumeric)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.minValueNumeric)).BeginInit();
            this.SuspendLayout();
            // 
            // timingParametersGroupBox
            // 
            this.timingParametersGroupBox.Controls.Add(this.label2);
            this.timingParametersGroupBox.Controls.Add(this.durationNumeric);
            this.timingParametersGroupBox.Controls.Add(this.label1);
            this.timingParametersGroupBox.Controls.Add(this.stopFreqNumeric);
            this.timingParametersGroupBox.Controls.Add(this.startFreqNumeric);
            this.timingParametersGroupBox.Controls.Add(this.frequencyLabel);
            this.timingParametersGroupBox.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.timingParametersGroupBox.Location = new System.Drawing.Point(26, 165);
            this.timingParametersGroupBox.Name = "timingParametersGroupBox";
            this.timingParametersGroupBox.Size = new System.Drawing.Size(247, 127);
            this.timingParametersGroupBox.TabIndex = 6;
            this.timingParametersGroupBox.TabStop = false;
            this.timingParametersGroupBox.Text = "Chirp Parameters";
            // 
            // label2
            // 
            this.label2.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.label2.Location = new System.Drawing.Point(16, 91);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(104, 18);
            this.label2.TabIndex = 6;
            this.label2.Text = "Duration (s)";
            // 
            // durationNumeric
            // 
            this.durationNumeric.DecimalPlaces = 3;
            this.durationNumeric.Location = new System.Drawing.Point(126, 89);
            this.durationNumeric.Name = "durationNumeric";
            this.durationNumeric.Size = new System.Drawing.Size(112, 20);
            this.durationNumeric.TabIndex = 5;
            this.durationNumeric.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // label1
            // 
            this.label1.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.label1.Location = new System.Drawing.Point(16, 56);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(104, 18);
            this.label1.TabIndex = 4;
            this.label1.Text = "Stop Frequency (Hz):";
            // 
            // stopFreqNumeric
            // 
            this.stopFreqNumeric.Location = new System.Drawing.Point(126, 54);
            this.stopFreqNumeric.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.stopFreqNumeric.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.stopFreqNumeric.Name = "stopFreqNumeric";
            this.stopFreqNumeric.Size = new System.Drawing.Size(112, 20);
            this.stopFreqNumeric.TabIndex = 3;
            this.stopFreqNumeric.Value = new decimal(new int[] {
            100,
            0,
            0,
            0});
            // 
            // startFreqNumeric
            // 
            this.startFreqNumeric.Location = new System.Drawing.Point(126, 24);
            this.startFreqNumeric.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.startFreqNumeric.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.startFreqNumeric.Name = "startFreqNumeric";
            this.startFreqNumeric.Size = new System.Drawing.Size(112, 20);
            this.startFreqNumeric.TabIndex = 1;
            this.startFreqNumeric.Value = new decimal(new int[] {
            100,
            0,
            0,
            0});
            // 
            // frequencyLabel
            // 
            this.frequencyLabel.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.frequencyLabel.Location = new System.Drawing.Point(16, 26);
            this.frequencyLabel.Name = "frequencyLabel";
            this.frequencyLabel.Size = new System.Drawing.Size(104, 18);
            this.frequencyLabel.TabIndex = 0;
            this.frequencyLabel.Text = "Start Frequency (Hz):";
            // 
            // channelParametersGroupBox
            // 
            this.channelParametersGroupBox.Controls.Add(this.maxValueNumeric);
            this.channelParametersGroupBox.Controls.Add(this.minValueNumeric);
            this.channelParametersGroupBox.Controls.Add(this.physicalChannelComboBox);
            this.channelParametersGroupBox.Controls.Add(this.physicalChannelLabel);
            this.channelParametersGroupBox.Controls.Add(this.maximumLabel);
            this.channelParametersGroupBox.Controls.Add(this.minimumLabel);
            this.channelParametersGroupBox.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.channelParametersGroupBox.Location = new System.Drawing.Point(26, 29);
            this.channelParametersGroupBox.Name = "channelParametersGroupBox";
            this.channelParametersGroupBox.Size = new System.Drawing.Size(247, 128);
            this.channelParametersGroupBox.TabIndex = 5;
            this.channelParametersGroupBox.TabStop = false;
            this.channelParametersGroupBox.Text = "Channel Parameters";
            // 
            // maxValueNumeric
            // 
            this.maxValueNumeric.DecimalPlaces = 3;
            this.maxValueNumeric.Location = new System.Drawing.Point(118, 94);
            this.maxValueNumeric.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.maxValueNumeric.Minimum = new decimal(new int[] {
            10,
            0,
            0,
            -2147483648});
            this.maxValueNumeric.Name = "maxValueNumeric";
            this.maxValueNumeric.Size = new System.Drawing.Size(114, 20);
            this.maxValueNumeric.TabIndex = 6;
            this.maxValueNumeric.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // minValueNumeric
            // 
            this.minValueNumeric.DecimalPlaces = 3;
            this.minValueNumeric.Location = new System.Drawing.Point(118, 60);
            this.minValueNumeric.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.minValueNumeric.Minimum = new decimal(new int[] {
            10,
            0,
            0,
            -2147483648});
            this.minValueNumeric.Name = "minValueNumeric";
            this.minValueNumeric.Size = new System.Drawing.Size(114, 20);
            this.minValueNumeric.TabIndex = 5;
            this.minValueNumeric.Value = new decimal(new int[] {
            1,
            0,
            0,
            -2147483648});
            // 
            // physicalChannelComboBox
            // 
            this.physicalChannelComboBox.Location = new System.Drawing.Point(120, 24);
            this.physicalChannelComboBox.Name = "physicalChannelComboBox";
            this.physicalChannelComboBox.Size = new System.Drawing.Size(112, 21);
            this.physicalChannelComboBox.TabIndex = 1;
            this.physicalChannelComboBox.Text = "Dev1/ao0";
            // 
            // physicalChannelLabel
            // 
            this.physicalChannelLabel.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.physicalChannelLabel.Location = new System.Drawing.Point(16, 26);
            this.physicalChannelLabel.Name = "physicalChannelLabel";
            this.physicalChannelLabel.Size = new System.Drawing.Size(96, 16);
            this.physicalChannelLabel.TabIndex = 0;
            this.physicalChannelLabel.Text = "Physical Channel:";
            // 
            // maximumLabel
            // 
            this.maximumLabel.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.maximumLabel.Location = new System.Drawing.Point(16, 98);
            this.maximumLabel.Name = "maximumLabel";
            this.maximumLabel.Size = new System.Drawing.Size(112, 16);
            this.maximumLabel.TabIndex = 4;
            this.maximumLabel.Text = "Maximum Value (V):";
            // 
            // minimumLabel
            // 
            this.minimumLabel.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.minimumLabel.Location = new System.Drawing.Point(16, 62);
            this.minimumLabel.Name = "minimumLabel";
            this.minimumLabel.Size = new System.Drawing.Size(104, 16);
            this.minimumLabel.TabIndex = 2;
            this.minimumLabel.Text = "Minimum Value (V):";
            // 
            // OK_button
            // 
            this.OK_button.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.OK_button.Location = new System.Drawing.Point(26, 316);
            this.OK_button.Name = "OK_button";
            this.OK_button.Size = new System.Drawing.Size(75, 23);
            this.OK_button.TabIndex = 7;
            this.OK_button.Text = "OK";
            this.OK_button.UseVisualStyleBackColor = true;
            // 
            // cancelButton
            // 
            this.cancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cancelButton.Location = new System.Drawing.Point(198, 316);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(75, 23);
            this.cancelButton.TabIndex = 8;
            this.cancelButton.Text = "Cancel";
            this.cancelButton.UseVisualStyleBackColor = true;
            // 
            // ChirpControl
            // 
            this.AcceptButton = this.OK_button;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.cancelButton;
            this.ClientSize = new System.Drawing.Size(291, 360);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.OK_button);
            this.Controls.Add(this.timingParametersGroupBox);
            this.Controls.Add(this.channelParametersGroupBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "ChirpControl";
            this.Text = "Chirp Control";
            this.timingParametersGroupBox.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.durationNumeric)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.stopFreqNumeric)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.startFreqNumeric)).EndInit();
            this.channelParametersGroupBox.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.maxValueNumeric)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.minValueNumeric)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox timingParametersGroupBox;
        private System.Windows.Forms.NumericUpDown startFreqNumeric;
        private System.Windows.Forms.Label frequencyLabel;
        private System.Windows.Forms.GroupBox channelParametersGroupBox;
        private System.Windows.Forms.ComboBox physicalChannelComboBox;
        private System.Windows.Forms.Label physicalChannelLabel;
        private System.Windows.Forms.Label maximumLabel;
        private System.Windows.Forms.Label minimumLabel;
        private System.Windows.Forms.Button OK_button;
        private System.Windows.Forms.Button cancelButton;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown durationNumeric;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown stopFreqNumeric;
        private System.Windows.Forms.NumericUpDown maxValueNumeric;
        private System.Windows.Forms.NumericUpDown minValueNumeric;
    }
}