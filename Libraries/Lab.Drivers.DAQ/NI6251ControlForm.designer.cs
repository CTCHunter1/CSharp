namespace Lab.Drivers.DAQ
{
    partial class NI6251ControlForm
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
            this.ok_button = new System.Windows.Forms.Button();
            this.cancel_button = new System.Windows.Forms.Button();
            this.channelParametersGroupBox = new System.Windows.Forms.GroupBox();
            this.removeButton = new System.Windows.Forms.Button();
            this.addChannelButton = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.channelsListBox = new System.Windows.Forms.ListBox();
            this.label2 = new System.Windows.Forms.Label();
            this.terminalModeComboBox = new System.Windows.Forms.ComboBox();
            this.physicalChannelComboBox = new System.Windows.Forms.ComboBox();
            this.minimumValueNumeric = new System.Windows.Forms.NumericUpDown();
            this.maximumValueNumeric = new System.Windows.Forms.NumericUpDown();
            this.maximumLabel = new System.Windows.Forms.Label();
            this.minimumLabel = new System.Windows.Forms.Label();
            this.physicalChannelLabel = new System.Windows.Forms.Label();
            this.timingParametersGroupBox = new System.Windows.Forms.GroupBox();
            this.samplesPerChannelLabel = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.rateNumeric = new System.Windows.Forms.NumericUpDown();
            this.samplesLabel = new System.Windows.Forms.Label();
            this.rateLabel = new System.Windows.Forms.Label();
            this.samplesPerChannelNumeric = new System.Windows.Forms.NumericUpDown();
            this.triggerParametersGroupBox = new System.Windows.Forms.GroupBox();
            this.referenceEdgeGroupBox = new System.Windows.Forms.GroupBox();
            this.referenceEdgeRisingButton = new System.Windows.Forms.RadioButton();
            this.referenceEdgeFallingButton = new System.Windows.Forms.RadioButton();
            this.softwareTriggerCheckBox = new System.Windows.Forms.CheckBox();
            this.triggerSourceInfoAsterisk = new System.Windows.Forms.Label();
            this.triggerSourceInfo = new System.Windows.Forms.Label();
            this.referenceTriggerSourceTextBox = new System.Windows.Forms.TextBox();
            this.referenceTriggerSourceLabel = new System.Windows.Forms.Label();
            this.triggerLevelLabel = new System.Windows.Forms.Label();
            this.hysteresisLabel = new System.Windows.Forms.Label();
            this.hysteresisNumeric = new System.Windows.Forms.NumericUpDown();
            this.triggerLevelNumeric = new System.Windows.Forms.NumericUpDown();
            this.label4 = new System.Windows.Forms.Label();
            this.delayNumeric = new System.Windows.Forms.NumericUpDown();
            this.channelParametersGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.minimumValueNumeric)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.maximumValueNumeric)).BeginInit();
            this.timingParametersGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.rateNumeric)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.samplesPerChannelNumeric)).BeginInit();
            this.triggerParametersGroupBox.SuspendLayout();
            this.referenceEdgeGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.hysteresisNumeric)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.triggerLevelNumeric)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.delayNumeric)).BeginInit();
            this.SuspendLayout();
            // 
            // ok_button
            // 
            this.ok_button.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.ok_button.Location = new System.Drawing.Point(22, 718);
            this.ok_button.Name = "ok_button";
            this.ok_button.Size = new System.Drawing.Size(75, 23);
            this.ok_button.TabIndex = 0;
            this.ok_button.Text = "Ok";
            this.ok_button.UseVisualStyleBackColor = true;
            this.ok_button.Click += new System.EventHandler(this.ok_button_Click);
            // 
            // cancel_button
            // 
            this.cancel_button.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cancel_button.Location = new System.Drawing.Point(171, 718);
            this.cancel_button.Name = "cancel_button";
            this.cancel_button.Size = new System.Drawing.Size(75, 23);
            this.cancel_button.TabIndex = 1;
            this.cancel_button.Text = "Cancel";
            this.cancel_button.UseVisualStyleBackColor = true;
            this.cancel_button.Click += new System.EventHandler(this.cancel_button_Click);
            // 
            // channelParametersGroupBox
            // 
            this.channelParametersGroupBox.Controls.Add(this.removeButton);
            this.channelParametersGroupBox.Controls.Add(this.addChannelButton);
            this.channelParametersGroupBox.Controls.Add(this.label3);
            this.channelParametersGroupBox.Controls.Add(this.channelsListBox);
            this.channelParametersGroupBox.Controls.Add(this.label2);
            this.channelParametersGroupBox.Controls.Add(this.terminalModeComboBox);
            this.channelParametersGroupBox.Controls.Add(this.physicalChannelComboBox);
            this.channelParametersGroupBox.Controls.Add(this.minimumValueNumeric);
            this.channelParametersGroupBox.Controls.Add(this.maximumValueNumeric);
            this.channelParametersGroupBox.Controls.Add(this.maximumLabel);
            this.channelParametersGroupBox.Controls.Add(this.minimumLabel);
            this.channelParametersGroupBox.Controls.Add(this.physicalChannelLabel);
            this.channelParametersGroupBox.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.channelParametersGroupBox.Location = new System.Drawing.Point(16, 12);
            this.channelParametersGroupBox.Name = "channelParametersGroupBox";
            this.channelParametersGroupBox.Size = new System.Drawing.Size(269, 270);
            this.channelParametersGroupBox.TabIndex = 3;
            this.channelParametersGroupBox.TabStop = false;
            this.channelParametersGroupBox.Text = "Channel Parameters";
            // 
            // removeButton
            // 
            this.removeButton.Location = new System.Drawing.Point(182, 238);
            this.removeButton.Name = "removeButton";
            this.removeButton.Size = new System.Drawing.Size(75, 23);
            this.removeButton.TabIndex = 11;
            this.removeButton.Text = "Remove";
            this.removeButton.UseVisualStyleBackColor = true;
            this.removeButton.Click += new System.EventHandler(this.removeButton_Click);
            // 
            // addChannelButton
            // 
            this.addChannelButton.Location = new System.Drawing.Point(11, 238);
            this.addChannelButton.Name = "addChannelButton";
            this.addChannelButton.Size = new System.Drawing.Size(75, 23);
            this.addChannelButton.TabIndex = 10;
            this.addChannelButton.Text = "Add";
            this.addChannelButton.UseVisualStyleBackColor = true;
            this.addChannelButton.Click += new System.EventHandler(this.addChannelButton_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(8, 134);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(51, 13);
            this.label3.TabIndex = 9;
            this.label3.Text = "Channels";
            // 
            // channelsListBox
            // 
            this.channelsListBox.FormattingEnabled = true;
            this.channelsListBox.Location = new System.Drawing.Point(11, 150);
            this.channelsListBox.Name = "channelsListBox";
            this.channelsListBox.Size = new System.Drawing.Size(246, 82);
            this.channelsListBox.TabIndex = 8;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(8, 54);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(112, 13);
            this.label2.TabIndex = 7;
            this.label2.Text = "Terminal Configuration";
            // 
            // terminalModeComboBox
            // 
            this.terminalModeComboBox.FormattingEnabled = true;
            this.terminalModeComboBox.Location = new System.Drawing.Point(161, 54);
            this.terminalModeComboBox.Name = "terminalModeComboBox";
            this.terminalModeComboBox.Size = new System.Drawing.Size(96, 21);
            this.terminalModeComboBox.TabIndex = 6;
            // 
            // physicalChannelComboBox
            // 
            this.physicalChannelComboBox.Location = new System.Drawing.Point(161, 26);
            this.physicalChannelComboBox.Name = "physicalChannelComboBox";
            this.physicalChannelComboBox.Size = new System.Drawing.Size(96, 21);
            this.physicalChannelComboBox.TabIndex = 1;
            this.physicalChannelComboBox.Text = "Dev1/ai0";
            // 
            // minimumValueNumeric
            // 
            this.minimumValueNumeric.DecimalPlaces = 2;
            this.minimumValueNumeric.Location = new System.Drawing.Point(161, 81);
            this.minimumValueNumeric.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.minimumValueNumeric.Minimum = new decimal(new int[] {
            10,
            0,
            0,
            -2147483648});
            this.minimumValueNumeric.Name = "minimumValueNumeric";
            this.minimumValueNumeric.Size = new System.Drawing.Size(96, 20);
            this.minimumValueNumeric.TabIndex = 3;
            this.minimumValueNumeric.Value = new decimal(new int[] {
            100,
            0,
            0,
            -2147418112});
            // 
            // maximumValueNumeric
            // 
            this.maximumValueNumeric.DecimalPlaces = 2;
            this.maximumValueNumeric.Location = new System.Drawing.Point(161, 113);
            this.maximumValueNumeric.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.maximumValueNumeric.Minimum = new decimal(new int[] {
            10,
            0,
            0,
            -2147483648});
            this.maximumValueNumeric.Name = "maximumValueNumeric";
            this.maximumValueNumeric.Size = new System.Drawing.Size(96, 20);
            this.maximumValueNumeric.TabIndex = 5;
            this.maximumValueNumeric.Value = new decimal(new int[] {
            100,
            0,
            0,
            65536});
            // 
            // maximumLabel
            // 
            this.maximumLabel.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.maximumLabel.Location = new System.Drawing.Point(16, 113);
            this.maximumLabel.Name = "maximumLabel";
            this.maximumLabel.Size = new System.Drawing.Size(112, 16);
            this.maximumLabel.TabIndex = 4;
            this.maximumLabel.Text = "Maximum Value (V):";
            // 
            // minimumLabel
            // 
            this.minimumLabel.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.minimumLabel.Location = new System.Drawing.Point(16, 81);
            this.minimumLabel.Name = "minimumLabel";
            this.minimumLabel.Size = new System.Drawing.Size(104, 15);
            this.minimumLabel.TabIndex = 2;
            this.minimumLabel.Text = "Minimum Value (V):";
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
            // timingParametersGroupBox
            // 
            this.timingParametersGroupBox.Controls.Add(this.samplesPerChannelLabel);
            this.timingParametersGroupBox.Controls.Add(this.label1);
            this.timingParametersGroupBox.Controls.Add(this.rateNumeric);
            this.timingParametersGroupBox.Controls.Add(this.samplesLabel);
            this.timingParametersGroupBox.Controls.Add(this.rateLabel);
            this.timingParametersGroupBox.Controls.Add(this.samplesPerChannelNumeric);
            this.timingParametersGroupBox.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.timingParametersGroupBox.Location = new System.Drawing.Point(18, 616);
            this.timingParametersGroupBox.Name = "timingParametersGroupBox";
            this.timingParametersGroupBox.Size = new System.Drawing.Size(269, 92);
            this.timingParametersGroupBox.TabIndex = 4;
            this.timingParametersGroupBox.TabStop = false;
            this.timingParametersGroupBox.Text = "Timing Parameters";
            // 
            // samplesPerChannelLabel
            // 
            this.samplesPerChannelLabel.AutoSize = true;
            this.samplesPerChannelLabel.Location = new System.Drawing.Point(117, 29);
            this.samplesPerChannelLabel.Name = "samplesPerChannelLabel";
            this.samplesPerChannelLabel.Size = new System.Drawing.Size(31, 13);
            this.samplesPerChannelLabel.TabIndex = 5;
            this.samplesPerChannelLabel.Text = "1024";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(161, 8);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(37, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Pow 2";
            // 
            // rateNumeric
            // 
            this.rateNumeric.DecimalPlaces = 2;
            this.rateNumeric.Location = new System.Drawing.Point(120, 56);
            this.rateNumeric.Maximum = new decimal(new int[] {
            1250000,
            0,
            0,
            0});
            this.rateNumeric.Name = "rateNumeric";
            this.rateNumeric.Size = new System.Drawing.Size(96, 20);
            this.rateNumeric.TabIndex = 3;
            this.rateNumeric.Value = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            // 
            // samplesLabel
            // 
            this.samplesLabel.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.samplesLabel.Location = new System.Drawing.Point(16, 26);
            this.samplesLabel.Name = "samplesLabel";
            this.samplesLabel.Size = new System.Drawing.Size(104, 16);
            this.samplesLabel.TabIndex = 0;
            this.samplesLabel.Text = "Samples/Channel:";
            // 
            // rateLabel
            // 
            this.rateLabel.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.rateLabel.Location = new System.Drawing.Point(16, 58);
            this.rateLabel.Name = "rateLabel";
            this.rateLabel.Size = new System.Drawing.Size(56, 16);
            this.rateLabel.TabIndex = 2;
            this.rateLabel.Text = "Rate (Hz):";
            // 
            // samplesPerChannelNumeric
            // 
            this.samplesPerChannelNumeric.Location = new System.Drawing.Point(164, 24);
            this.samplesPerChannelNumeric.Maximum = new decimal(new int[] {
            32,
            0,
            0,
            0});
            this.samplesPerChannelNumeric.Name = "samplesPerChannelNumeric";
            this.samplesPerChannelNumeric.Size = new System.Drawing.Size(51, 20);
            this.samplesPerChannelNumeric.TabIndex = 1;
            this.samplesPerChannelNumeric.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.samplesPerChannelNumeric.ValueChanged += new System.EventHandler(this.samplesPerChannelNumeric_ValueChanged);
            // 
            // triggerParametersGroupBox
            // 
            this.triggerParametersGroupBox.Controls.Add(this.label4);
            this.triggerParametersGroupBox.Controls.Add(this.delayNumeric);
            this.triggerParametersGroupBox.Controls.Add(this.referenceEdgeGroupBox);
            this.triggerParametersGroupBox.Controls.Add(this.softwareTriggerCheckBox);
            this.triggerParametersGroupBox.Controls.Add(this.triggerSourceInfoAsterisk);
            this.triggerParametersGroupBox.Controls.Add(this.triggerSourceInfo);
            this.triggerParametersGroupBox.Controls.Add(this.referenceTriggerSourceTextBox);
            this.triggerParametersGroupBox.Controls.Add(this.referenceTriggerSourceLabel);
            this.triggerParametersGroupBox.Controls.Add(this.triggerLevelLabel);
            this.triggerParametersGroupBox.Controls.Add(this.hysteresisLabel);
            this.triggerParametersGroupBox.Controls.Add(this.hysteresisNumeric);
            this.triggerParametersGroupBox.Controls.Add(this.triggerLevelNumeric);
            this.triggerParametersGroupBox.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.triggerParametersGroupBox.Location = new System.Drawing.Point(18, 286);
            this.triggerParametersGroupBox.Name = "triggerParametersGroupBox";
            this.triggerParametersGroupBox.Size = new System.Drawing.Size(267, 313);
            this.triggerParametersGroupBox.TabIndex = 5;
            this.triggerParametersGroupBox.TabStop = false;
            this.triggerParametersGroupBox.Text = "Trigger Parameters";
            // 
            // referenceEdgeGroupBox
            // 
            this.referenceEdgeGroupBox.Controls.Add(this.referenceEdgeRisingButton);
            this.referenceEdgeGroupBox.Controls.Add(this.referenceEdgeFallingButton);
            this.referenceEdgeGroupBox.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.referenceEdgeGroupBox.Location = new System.Drawing.Point(19, 237);
            this.referenceEdgeGroupBox.Name = "referenceEdgeGroupBox";
            this.referenceEdgeGroupBox.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.referenceEdgeGroupBox.Size = new System.Drawing.Size(224, 56);
            this.referenceEdgeGroupBox.TabIndex = 10;
            this.referenceEdgeGroupBox.TabStop = false;
            this.referenceEdgeGroupBox.Text = "Reference Edge:";
            // 
            // referenceEdgeRisingButton
            // 
            this.referenceEdgeRisingButton.Checked = true;
            this.referenceEdgeRisingButton.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.referenceEdgeRisingButton.Location = new System.Drawing.Point(24, 16);
            this.referenceEdgeRisingButton.Name = "referenceEdgeRisingButton";
            this.referenceEdgeRisingButton.Size = new System.Drawing.Size(56, 24);
            this.referenceEdgeRisingButton.TabIndex = 0;
            this.referenceEdgeRisingButton.TabStop = true;
            this.referenceEdgeRisingButton.Text = "Rising";
            this.referenceEdgeRisingButton.CheckedChanged += new System.EventHandler(this.referenceEdgeRisingButton_CheckedChanged);
            // 
            // referenceEdgeFallingButton
            // 
            this.referenceEdgeFallingButton.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.referenceEdgeFallingButton.Location = new System.Drawing.Point(104, 16);
            this.referenceEdgeFallingButton.Name = "referenceEdgeFallingButton";
            this.referenceEdgeFallingButton.Size = new System.Drawing.Size(56, 24);
            this.referenceEdgeFallingButton.TabIndex = 1;
            this.referenceEdgeFallingButton.Text = "Falling";
            // 
            // softwareTriggerCheckBox
            // 
            this.softwareTriggerCheckBox.AutoSize = true;
            this.softwareTriggerCheckBox.Checked = true;
            this.softwareTriggerCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.softwareTriggerCheckBox.Location = new System.Drawing.Point(17, 19);
            this.softwareTriggerCheckBox.Name = "softwareTriggerCheckBox";
            this.softwareTriggerCheckBox.Size = new System.Drawing.Size(104, 17);
            this.softwareTriggerCheckBox.TabIndex = 9;
            this.softwareTriggerCheckBox.Text = "Software Trigger";
            this.softwareTriggerCheckBox.UseVisualStyleBackColor = true;
            this.softwareTriggerCheckBox.CheckedChanged += new System.EventHandler(this.softwareTriggerCheckBox_CheckedChanged);
            // 
            // triggerSourceInfoAsterisk
            // 
            this.triggerSourceInfoAsterisk.Location = new System.Drawing.Point(16, 161);
            this.triggerSourceInfoAsterisk.Name = "triggerSourceInfoAsterisk";
            this.triggerSourceInfoAsterisk.Size = new System.Drawing.Size(8, 23);
            this.triggerSourceInfoAsterisk.TabIndex = 7;
            this.triggerSourceInfoAsterisk.Text = "*";
            // 
            // triggerSourceInfo
            // 
            this.triggerSourceInfo.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.triggerSourceInfo.Location = new System.Drawing.Point(24, 170);
            this.triggerSourceInfo.Name = "triggerSourceInfo";
            this.triggerSourceInfo.Size = new System.Drawing.Size(192, 64);
            this.triggerSourceInfo.TabIndex = 8;
            this.triggerSourceInfo.Text = "APFI0 is the default Analog Trigger pin for M Series devices.  Please refer to yo" +
                "ur device documentation for information regarding valid Analog Triggers for your" +
                " device.";
            // 
            // referenceTriggerSourceTextBox
            // 
            this.referenceTriggerSourceTextBox.Location = new System.Drawing.Point(128, 46);
            this.referenceTriggerSourceTextBox.Name = "referenceTriggerSourceTextBox";
            this.referenceTriggerSourceTextBox.Size = new System.Drawing.Size(88, 20);
            this.referenceTriggerSourceTextBox.TabIndex = 1;
            this.referenceTriggerSourceTextBox.Text = "APFI0";
            // 
            // referenceTriggerSourceLabel
            // 
            this.referenceTriggerSourceLabel.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.referenceTriggerSourceLabel.Location = new System.Drawing.Point(16, 49);
            this.referenceTriggerSourceLabel.Name = "referenceTriggerSourceLabel";
            this.referenceTriggerSourceLabel.Size = new System.Drawing.Size(88, 16);
            this.referenceTriggerSourceLabel.TabIndex = 0;
            this.referenceTriggerSourceLabel.Text = "Trigger Source:*";
            // 
            // triggerLevelLabel
            // 
            this.triggerLevelLabel.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.triggerLevelLabel.Location = new System.Drawing.Point(16, 79);
            this.triggerLevelLabel.Name = "triggerLevelLabel";
            this.triggerLevelLabel.Size = new System.Drawing.Size(96, 16);
            this.triggerLevelLabel.TabIndex = 2;
            this.triggerLevelLabel.Text = "Trigger Level (V):";
            // 
            // hysteresisLabel
            // 
            this.hysteresisLabel.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.hysteresisLabel.Location = new System.Drawing.Point(16, 110);
            this.hysteresisLabel.Name = "hysteresisLabel";
            this.hysteresisLabel.Size = new System.Drawing.Size(96, 16);
            this.hysteresisLabel.TabIndex = 4;
            this.hysteresisLabel.Text = "Hysteresis (V):";
            // 
            // hysteresisNumeric
            // 
            this.hysteresisNumeric.DecimalPlaces = 2;
            this.hysteresisNumeric.Location = new System.Drawing.Point(128, 110);
            this.hysteresisNumeric.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.hysteresisNumeric.Minimum = new decimal(new int[] {
            10,
            0,
            0,
            -2147483648});
            this.hysteresisNumeric.Name = "hysteresisNumeric";
            this.hysteresisNumeric.Size = new System.Drawing.Size(88, 20);
            this.hysteresisNumeric.TabIndex = 5;
            // 
            // triggerLevelNumeric
            // 
            this.triggerLevelNumeric.DecimalPlaces = 2;
            this.triggerLevelNumeric.Location = new System.Drawing.Point(128, 78);
            this.triggerLevelNumeric.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.triggerLevelNumeric.Minimum = new decimal(new int[] {
            10,
            0,
            0,
            -2147483648});
            this.triggerLevelNumeric.Name = "triggerLevelNumeric";
            this.triggerLevelNumeric.Size = new System.Drawing.Size(88, 20);
            this.triggerLevelNumeric.TabIndex = 3;
            // 
            // label4
            // 
            this.label4.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.label4.Location = new System.Drawing.Point(15, 140);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(96, 16);
            this.label4.TabIndex = 11;
            this.label4.Text = "Delay (ms):";
            // 
            // delayNumeric
            // 
            this.delayNumeric.DecimalPlaces = 3;
            this.delayNumeric.Location = new System.Drawing.Point(127, 140);
            this.delayNumeric.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.delayNumeric.Minimum = new decimal(new int[] {
            1000,
            0,
            0,
            -2147483648});
            this.delayNumeric.Name = "delayNumeric";
            this.delayNumeric.Size = new System.Drawing.Size(88, 20);
            this.delayNumeric.TabIndex = 12;
            // 
            // NI6251ControlForm
            // 
            this.AcceptButton = this.ok_button;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.cancel_button;
            this.ClientSize = new System.Drawing.Size(296, 753);
            this.Controls.Add(this.triggerParametersGroupBox);
            this.Controls.Add(this.timingParametersGroupBox);
            this.Controls.Add(this.channelParametersGroupBox);
            this.Controls.Add(this.cancel_button);
            this.Controls.Add(this.ok_button);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "NI6251ControlForm";
            this.Text = "NI6251 Options";
            this.Shown += new System.EventHandler(this.NI6251_Options_Shown);
            this.channelParametersGroupBox.ResumeLayout(false);
            this.channelParametersGroupBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.minimumValueNumeric)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.maximumValueNumeric)).EndInit();
            this.timingParametersGroupBox.ResumeLayout(false);
            this.timingParametersGroupBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.rateNumeric)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.samplesPerChannelNumeric)).EndInit();
            this.triggerParametersGroupBox.ResumeLayout(false);
            this.triggerParametersGroupBox.PerformLayout();
            this.referenceEdgeGroupBox.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.hysteresisNumeric)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.triggerLevelNumeric)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.delayNumeric)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button ok_button;
        private System.Windows.Forms.Button cancel_button;
        private System.Windows.Forms.GroupBox channelParametersGroupBox;
        private System.Windows.Forms.ComboBox physicalChannelComboBox;
        internal System.Windows.Forms.NumericUpDown minimumValueNumeric;
        internal System.Windows.Forms.NumericUpDown maximumValueNumeric;
        private System.Windows.Forms.Label maximumLabel;
        private System.Windows.Forms.Label minimumLabel;
        private System.Windows.Forms.Label physicalChannelLabel;
        private System.Windows.Forms.GroupBox timingParametersGroupBox;
        private System.Windows.Forms.NumericUpDown rateNumeric;
        private System.Windows.Forms.Label samplesLabel;
        private System.Windows.Forms.Label rateLabel;
        private System.Windows.Forms.NumericUpDown samplesPerChannelNumeric;
        private System.Windows.Forms.Label samplesPerChannelLabel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox terminalModeComboBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button addChannelButton;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ListBox channelsListBox;
        private System.Windows.Forms.Button removeButton;
        private System.Windows.Forms.GroupBox triggerParametersGroupBox;
        private System.Windows.Forms.Label triggerSourceInfoAsterisk;
        private System.Windows.Forms.Label triggerSourceInfo;
        private System.Windows.Forms.TextBox referenceTriggerSourceTextBox;
        private System.Windows.Forms.Label referenceTriggerSourceLabel;
        private System.Windows.Forms.Label triggerLevelLabel;
        private System.Windows.Forms.Label hysteresisLabel;
        internal System.Windows.Forms.NumericUpDown hysteresisNumeric;
        internal System.Windows.Forms.NumericUpDown triggerLevelNumeric;
        private System.Windows.Forms.CheckBox softwareTriggerCheckBox;
        private System.Windows.Forms.GroupBox referenceEdgeGroupBox;
        private System.Windows.Forms.RadioButton referenceEdgeRisingButton;
        private System.Windows.Forms.RadioButton referenceEdgeFallingButton;
        private System.Windows.Forms.Label label4;
        internal System.Windows.Forms.NumericUpDown delayNumeric;
    }
}