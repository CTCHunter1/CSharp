namespace Squid
{
    partial class MainForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveSingleScanToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveZAxisScanToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.controlToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.chopperMotorToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.nI6251ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.squidOptionsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.stagesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.chirpControlToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.controlToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.startContinousToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.stopContinousScanToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.startZScanToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.stopZScanToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.takeSingleTraceToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.chrpWaveformToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.stopChirpWaveformToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.stopButton = new System.Windows.Forms.Button();
            this.enableCheckBox2 = new System.Windows.Forms.CheckBox();
            this.enableCheckBox1 = new System.Windows.Forms.CheckBox();
            this.enableCheckBox3 = new System.Windows.Forms.CheckBox();
            this.dataSelectedGroupBox1 = new System.Windows.Forms.GroupBox();
            this.origionalRadioButton1 = new System.Windows.Forms.RadioButton();
            this.reducedRadioButton1 = new System.Windows.Forms.RadioButton();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.origionalRadioButton2 = new System.Windows.Forms.RadioButton();
            this.reducedRadioButton2 = new System.Windows.Forms.RadioButton();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.timeRadioButton = new System.Windows.Forms.RadioButton();
            this.freqRadioButton = new System.Windows.Forms.RadioButton();
            this.takeReducedButton = new System.Windows.Forms.Button();
            this.zScanGraphControl = new GraphControl.GraphControl();
            this.frequencyAxisGraphControl = new GraphControl.GraphControl();
            this.timeAxisGraphControl = new GraphControl.GraphControl();
            this.autoScaleCheckBox1 = new System.Windows.Forms.CheckBox();
            this.autoScaleCheckBox2 = new System.Windows.Forms.CheckBox();
            this.yAxisMinNumeric = new System.Windows.Forms.NumericUpDown();
            this.yAxisMaxNumeric = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.saveChirpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.dataSelectedGroupBox1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.yAxisMinNumeric)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.yAxisMaxNumeric)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.controlToolStripMenuItem,
            this.controlToolStripMenuItem1});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(600, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.saveSingleScanToolStripMenuItem,
            this.saveZAxisScanToolStripMenuItem,
            this.saveChirpToolStripMenuItem,
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(35, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // saveSingleScanToolStripMenuItem
            // 
            this.saveSingleScanToolStripMenuItem.Name = "saveSingleScanToolStripMenuItem";
            this.saveSingleScanToolStripMenuItem.Size = new System.Drawing.Size(167, 22);
            this.saveSingleScanToolStripMenuItem.Text = "Save Single Scan";
            this.saveSingleScanToolStripMenuItem.Click += new System.EventHandler(this.saveSingleScanToolStripMenuItem_Click);
            // 
            // saveZAxisScanToolStripMenuItem
            // 
            this.saveZAxisScanToolStripMenuItem.Name = "saveZAxisScanToolStripMenuItem";
            this.saveZAxisScanToolStripMenuItem.Size = new System.Drawing.Size(167, 22);
            this.saveZAxisScanToolStripMenuItem.Text = "Save Z Axis Scan";
            this.saveZAxisScanToolStripMenuItem.Click += new System.EventHandler(this.saveZAxisScanToolStripMenuItem_Click);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(167, 22);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // controlToolStripMenuItem
            // 
            this.controlToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.chopperMotorToolStripMenuItem,
            this.nI6251ToolStripMenuItem,
            this.squidOptionsToolStripMenuItem,
            this.stagesToolStripMenuItem,
            this.chirpControlToolStripMenuItem});
            this.controlToolStripMenuItem.Name = "controlToolStripMenuItem";
            this.controlToolStripMenuItem.Size = new System.Drawing.Size(56, 20);
            this.controlToolStripMenuItem.Text = "Options";
            // 
            // chopperMotorToolStripMenuItem
            // 
            this.chopperMotorToolStripMenuItem.Name = "chopperMotorToolStripMenuItem";
            this.chopperMotorToolStripMenuItem.Size = new System.Drawing.Size(157, 22);
            this.chopperMotorToolStripMenuItem.Text = "Chopper Motor";
            this.chopperMotorToolStripMenuItem.Click += new System.EventHandler(this.chopperMotorToolStripMenuItem_Click);
            // 
            // nI6251ToolStripMenuItem
            // 
            this.nI6251ToolStripMenuItem.Name = "nI6251ToolStripMenuItem";
            this.nI6251ToolStripMenuItem.Size = new System.Drawing.Size(157, 22);
            this.nI6251ToolStripMenuItem.Text = "NI-6251";
            this.nI6251ToolStripMenuItem.Click += new System.EventHandler(this.nI6251ToolStripMenuItem_Click);
            // 
            // squidOptionsToolStripMenuItem
            // 
            this.squidOptionsToolStripMenuItem.Name = "squidOptionsToolStripMenuItem";
            this.squidOptionsToolStripMenuItem.Size = new System.Drawing.Size(157, 22);
            this.squidOptionsToolStripMenuItem.Text = "Squid Options";
            this.squidOptionsToolStripMenuItem.Click += new System.EventHandler(this.squidOptionsToolStripMenuItem_Click);
            // 
            // stagesToolStripMenuItem
            // 
            this.stagesToolStripMenuItem.Name = "stagesToolStripMenuItem";
            this.stagesToolStripMenuItem.Size = new System.Drawing.Size(157, 22);
            this.stagesToolStripMenuItem.Text = "Stages";
            this.stagesToolStripMenuItem.Click += new System.EventHandler(this.stagesToolStripMenuItem_Click);
            // 
            // chirpControlToolStripMenuItem
            // 
            this.chirpControlToolStripMenuItem.Name = "chirpControlToolStripMenuItem";
            this.chirpControlToolStripMenuItem.Size = new System.Drawing.Size(157, 22);
            this.chirpControlToolStripMenuItem.Text = "Chirp Control";
            this.chirpControlToolStripMenuItem.Click += new System.EventHandler(this.chirpControlToolStripMenuItem_Click);
            // 
            // controlToolStripMenuItem1
            // 
            this.controlToolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.startContinousToolStripMenuItem,
            this.stopContinousScanToolStripMenuItem,
            this.startZScanToolStripMenuItem,
            this.stopZScanToolStripMenuItem,
            this.takeSingleTraceToolStripMenuItem,
            this.chrpWaveformToolStripMenuItem,
            this.stopChirpWaveformToolStripMenuItem});
            this.controlToolStripMenuItem1.Name = "controlToolStripMenuItem1";
            this.controlToolStripMenuItem1.Size = new System.Drawing.Size(54, 20);
            this.controlToolStripMenuItem1.Text = "Control";
            // 
            // startContinousToolStripMenuItem
            // 
            this.startContinousToolStripMenuItem.Name = "startContinousToolStripMenuItem";
            this.startContinousToolStripMenuItem.Size = new System.Drawing.Size(190, 22);
            this.startContinousToolStripMenuItem.Text = "Start Continous Scan";
            this.startContinousToolStripMenuItem.Click += new System.EventHandler(this.startContinousToolStripMenuItem_Click);
            // 
            // stopContinousScanToolStripMenuItem
            // 
            this.stopContinousScanToolStripMenuItem.Name = "stopContinousScanToolStripMenuItem";
            this.stopContinousScanToolStripMenuItem.Size = new System.Drawing.Size(190, 22);
            this.stopContinousScanToolStripMenuItem.Text = "Stop Continous Scan";
            this.stopContinousScanToolStripMenuItem.Click += new System.EventHandler(this.stopContinousScanToolStripMenuItem_Click);
            // 
            // startZScanToolStripMenuItem
            // 
            this.startZScanToolStripMenuItem.Name = "startZScanToolStripMenuItem";
            this.startZScanToolStripMenuItem.Size = new System.Drawing.Size(190, 22);
            this.startZScanToolStripMenuItem.Text = "Start Z Scan";
            this.startZScanToolStripMenuItem.Click += new System.EventHandler(this.startZScanToolStripMenuItem_Click);
            // 
            // stopZScanToolStripMenuItem
            // 
            this.stopZScanToolStripMenuItem.Name = "stopZScanToolStripMenuItem";
            this.stopZScanToolStripMenuItem.Size = new System.Drawing.Size(190, 22);
            this.stopZScanToolStripMenuItem.Text = "Stop Z Scan";
            this.stopZScanToolStripMenuItem.Click += new System.EventHandler(this.stopZScanToolStripMenuItem_Click);
            // 
            // takeSingleTraceToolStripMenuItem
            // 
            this.takeSingleTraceToolStripMenuItem.Name = "takeSingleTraceToolStripMenuItem";
            this.takeSingleTraceToolStripMenuItem.Size = new System.Drawing.Size(190, 22);
            this.takeSingleTraceToolStripMenuItem.Text = "Take Single Trace";
            this.takeSingleTraceToolStripMenuItem.Click += new System.EventHandler(this.takeSingleTraceToolStripMenuItem_Click);
            // 
            // chrpWaveformToolStripMenuItem
            // 
            this.chrpWaveformToolStripMenuItem.Name = "chrpWaveformToolStripMenuItem";
            this.chrpWaveformToolStripMenuItem.Size = new System.Drawing.Size(190, 22);
            this.chrpWaveformToolStripMenuItem.Text = "Start Chrip Waveform";
            this.chrpWaveformToolStripMenuItem.Click += new System.EventHandler(this.chrpWaveformToolStripMenuItem_Click);
            // 
            // stopChirpWaveformToolStripMenuItem
            // 
            this.stopChirpWaveformToolStripMenuItem.Name = "stopChirpWaveformToolStripMenuItem";
            this.stopChirpWaveformToolStripMenuItem.Size = new System.Drawing.Size(190, 22);
            this.stopChirpWaveformToolStripMenuItem.Text = "Stop Chirp Waveform";
            this.stopChirpWaveformToolStripMenuItem.Click += new System.EventHandler(this.stopChirpWaveformToolStripMenuItem_Click);
            // 
            // stopButton
            // 
            this.stopButton.Location = new System.Drawing.Point(12, 661);
            this.stopButton.Name = "stopButton";
            this.stopButton.Size = new System.Drawing.Size(75, 23);
            this.stopButton.TabIndex = 1;
            this.stopButton.Text = "&Stop";
            this.stopButton.UseVisualStyleBackColor = true;
            this.stopButton.Click += new System.EventHandler(this.stopButton_Click);
            // 
            // enableCheckBox2
            // 
            this.enableCheckBox2.AutoSize = true;
            this.enableCheckBox2.Location = new System.Drawing.Point(28, 255);
            this.enableCheckBox2.Name = "enableCheckBox2";
            this.enableCheckBox2.Size = new System.Drawing.Size(59, 17);
            this.enableCheckBox2.TabIndex = 6;
            this.enableCheckBox2.Text = "Enable";
            this.enableCheckBox2.UseVisualStyleBackColor = true;
            // 
            // enableCheckBox1
            // 
            this.enableCheckBox1.AutoSize = true;
            this.enableCheckBox1.Checked = true;
            this.enableCheckBox1.CheckState = System.Windows.Forms.CheckState.Checked;
            this.enableCheckBox1.Location = new System.Drawing.Point(28, 49);
            this.enableCheckBox1.Name = "enableCheckBox1";
            this.enableCheckBox1.Size = new System.Drawing.Size(59, 17);
            this.enableCheckBox1.TabIndex = 7;
            this.enableCheckBox1.Text = "Enable";
            this.enableCheckBox1.UseVisualStyleBackColor = true;
            // 
            // enableCheckBox3
            // 
            this.enableCheckBox3.AutoSize = true;
            this.enableCheckBox3.Checked = true;
            this.enableCheckBox3.CheckState = System.Windows.Forms.CheckState.Checked;
            this.enableCheckBox3.Location = new System.Drawing.Point(28, 475);
            this.enableCheckBox3.Name = "enableCheckBox3";
            this.enableCheckBox3.Size = new System.Drawing.Size(59, 17);
            this.enableCheckBox3.TabIndex = 8;
            this.enableCheckBox3.Text = "Enable";
            this.enableCheckBox3.UseVisualStyleBackColor = true;
            // 
            // dataSelectedGroupBox1
            // 
            this.dataSelectedGroupBox1.Controls.Add(this.origionalRadioButton1);
            this.dataSelectedGroupBox1.Controls.Add(this.reducedRadioButton1);
            this.dataSelectedGroupBox1.Location = new System.Drawing.Point(93, 43);
            this.dataSelectedGroupBox1.Name = "dataSelectedGroupBox1";
            this.dataSelectedGroupBox1.Size = new System.Drawing.Size(196, 37);
            this.dataSelectedGroupBox1.TabIndex = 9;
            this.dataSelectedGroupBox1.TabStop = false;
            this.dataSelectedGroupBox1.Text = "Data Select";
            // 
            // origionalRadioButton1
            // 
            this.origionalRadioButton1.AutoSize = true;
            this.origionalRadioButton1.Checked = true;
            this.origionalRadioButton1.Location = new System.Drawing.Point(110, 13);
            this.origionalRadioButton1.Name = "origionalRadioButton1";
            this.origionalRadioButton1.Size = new System.Drawing.Size(66, 17);
            this.origionalRadioButton1.TabIndex = 1;
            this.origionalRadioButton1.TabStop = true;
            this.origionalRadioButton1.Text = "Origional";
            this.origionalRadioButton1.UseVisualStyleBackColor = true;
            // 
            // reducedRadioButton1
            // 
            this.reducedRadioButton1.AutoSize = true;
            this.reducedRadioButton1.Location = new System.Drawing.Point(6, 13);
            this.reducedRadioButton1.Name = "reducedRadioButton1";
            this.reducedRadioButton1.Size = new System.Drawing.Size(69, 17);
            this.reducedRadioButton1.TabIndex = 0;
            this.reducedRadioButton1.Text = "Reduced";
            this.reducedRadioButton1.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.origionalRadioButton2);
            this.groupBox1.Controls.Add(this.reducedRadioButton2);
            this.groupBox1.Location = new System.Drawing.Point(93, 244);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(196, 37);
            this.groupBox1.TabIndex = 10;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Data Select";
            // 
            // origionalRadioButton2
            // 
            this.origionalRadioButton2.AutoSize = true;
            this.origionalRadioButton2.Checked = true;
            this.origionalRadioButton2.Location = new System.Drawing.Point(110, 13);
            this.origionalRadioButton2.Name = "origionalRadioButton2";
            this.origionalRadioButton2.Size = new System.Drawing.Size(66, 17);
            this.origionalRadioButton2.TabIndex = 1;
            this.origionalRadioButton2.TabStop = true;
            this.origionalRadioButton2.Text = "Origional";
            this.origionalRadioButton2.UseVisualStyleBackColor = true;
            // 
            // reducedRadioButton2
            // 
            this.reducedRadioButton2.AutoSize = true;
            this.reducedRadioButton2.Location = new System.Drawing.Point(6, 13);
            this.reducedRadioButton2.Name = "reducedRadioButton2";
            this.reducedRadioButton2.Size = new System.Drawing.Size(69, 17);
            this.reducedRadioButton2.TabIndex = 0;
            this.reducedRadioButton2.Text = "Reduced";
            this.reducedRadioButton2.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.timeRadioButton);
            this.groupBox2.Controls.Add(this.freqRadioButton);
            this.groupBox2.Location = new System.Drawing.Point(93, 462);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(203, 37);
            this.groupBox2.TabIndex = 10;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Data Select";
            // 
            // timeRadioButton
            // 
            this.timeRadioButton.AutoSize = true;
            this.timeRadioButton.Checked = true;
            this.timeRadioButton.Location = new System.Drawing.Point(110, 13);
            this.timeRadioButton.Name = "timeRadioButton";
            this.timeRadioButton.Size = new System.Drawing.Size(87, 17);
            this.timeRadioButton.TabIndex = 1;
            this.timeRadioButton.TabStop = true;
            this.timeRadioButton.Text = "Time Domain";
            this.timeRadioButton.UseVisualStyleBackColor = true;
            // 
            // freqRadioButton
            // 
            this.freqRadioButton.AutoSize = true;
            this.freqRadioButton.Location = new System.Drawing.Point(6, 13);
            this.freqRadioButton.Name = "freqRadioButton";
            this.freqRadioButton.Size = new System.Drawing.Size(85, 17);
            this.freqRadioButton.TabIndex = 0;
            this.freqRadioButton.Text = "Freq Domain";
            this.freqRadioButton.UseVisualStyleBackColor = true;
            // 
            // takeReducedButton
            // 
            this.takeReducedButton.Location = new System.Drawing.Point(498, 661);
            this.takeReducedButton.Name = "takeReducedButton";
            this.takeReducedButton.Size = new System.Drawing.Size(75, 23);
            this.takeReducedButton.TabIndex = 11;
            this.takeReducedButton.Text = "Take Reduced Data";
            this.takeReducedButton.UseVisualStyleBackColor = true;
            this.takeReducedButton.Click += new System.EventHandler(this.takeReducedButton_Click);
            // 
            // zScanGraphControl
            // 
            this.zScanGraphControl.AutoScale = true;
            this.zScanGraphControl.Location = new System.Drawing.Point(12, 498);
            this.zScanGraphControl.Name = "zScanGraphControl";
            this.zScanGraphControl.Size = new System.Drawing.Size(561, 143);
            this.zScanGraphControl.TabIndex = 5;
            this.zScanGraphControl.XLim = new double[] {
        -10,
        10};
            this.zScanGraphControl.YLim = new double[] {
        -10,
        10};
            // 
            // frequencyAxisGraphControl
            // 
            this.frequencyAxisGraphControl.AutoScale = true;
            this.frequencyAxisGraphControl.Location = new System.Drawing.Point(12, 278);
            this.frequencyAxisGraphControl.Name = "frequencyAxisGraphControl";
            this.frequencyAxisGraphControl.Size = new System.Drawing.Size(561, 172);
            this.frequencyAxisGraphControl.TabIndex = 4;
            this.frequencyAxisGraphControl.XLim = new double[] {
        -10,
        10};
            this.frequencyAxisGraphControl.YLim = new double[] {
        -10,
        10};
            // 
            // timeAxisGraphControl
            // 
            this.timeAxisGraphControl.AutoScale = true;
            this.timeAxisGraphControl.Location = new System.Drawing.Point(12, 81);
            this.timeAxisGraphControl.Name = "timeAxisGraphControl";
            this.timeAxisGraphControl.Size = new System.Drawing.Size(561, 163);
            this.timeAxisGraphControl.TabIndex = 3;
            this.timeAxisGraphControl.XLim = new double[] {
        -10,
        10};
            this.timeAxisGraphControl.YLim = new double[] {
        -10,
        10};
            // 
            // autoScaleCheckBox1
            // 
            this.autoScaleCheckBox1.AutoSize = true;
            this.autoScaleCheckBox1.Checked = true;
            this.autoScaleCheckBox1.CheckState = System.Windows.Forms.CheckState.Checked;
            this.autoScaleCheckBox1.Location = new System.Drawing.Point(295, 56);
            this.autoScaleCheckBox1.Name = "autoScaleCheckBox1";
            this.autoScaleCheckBox1.Size = new System.Drawing.Size(73, 17);
            this.autoScaleCheckBox1.TabIndex = 12;
            this.autoScaleCheckBox1.Text = "Autoscale";
            this.autoScaleCheckBox1.UseVisualStyleBackColor = true;
            this.autoScaleCheckBox1.CheckedChanged += new System.EventHandler(this.autoScaleCheckBox1_CheckedChanged);
            // 
            // autoScaleCheckBox2
            // 
            this.autoScaleCheckBox2.AutoSize = true;
            this.autoScaleCheckBox2.Checked = true;
            this.autoScaleCheckBox2.CheckState = System.Windows.Forms.CheckState.Checked;
            this.autoScaleCheckBox2.Location = new System.Drawing.Point(295, 258);
            this.autoScaleCheckBox2.Name = "autoScaleCheckBox2";
            this.autoScaleCheckBox2.Size = new System.Drawing.Size(73, 17);
            this.autoScaleCheckBox2.TabIndex = 13;
            this.autoScaleCheckBox2.Text = "Autoscale";
            this.autoScaleCheckBox2.UseVisualStyleBackColor = true;
            // 
            // yAxisMinNumeric
            // 
            this.yAxisMinNumeric.DecimalPlaces = 3;
            this.yAxisMinNumeric.Increment = new decimal(new int[] {
            1,
            0,
            0,
            131072});
            this.yAxisMinNumeric.Location = new System.Drawing.Point(374, 55);
            this.yAxisMinNumeric.Maximum = new decimal(new int[] {
            15,
            0,
            0,
            0});
            this.yAxisMinNumeric.Minimum = new decimal(new int[] {
            15,
            0,
            0,
            -2147483648});
            this.yAxisMinNumeric.Name = "yAxisMinNumeric";
            this.yAxisMinNumeric.Size = new System.Drawing.Size(64, 20);
            this.yAxisMinNumeric.TabIndex = 14;
            this.yAxisMinNumeric.ValueChanged += new System.EventHandler(this.yAxisNumeric_ValueChanged);
            // 
            // yAxisMaxNumeric
            // 
            this.yAxisMaxNumeric.DecimalPlaces = 3;
            this.yAxisMaxNumeric.Increment = new decimal(new int[] {
            1,
            0,
            0,
            131072});
            this.yAxisMaxNumeric.Location = new System.Drawing.Point(480, 55);
            this.yAxisMaxNumeric.Maximum = new decimal(new int[] {
            15,
            0,
            0,
            0});
            this.yAxisMaxNumeric.Minimum = new decimal(new int[] {
            15,
            0,
            0,
            -2147483648});
            this.yAxisMaxNumeric.Name = "yAxisMaxNumeric";
            this.yAxisMaxNumeric.Size = new System.Drawing.Size(65, 20);
            this.yAxisMaxNumeric.TabIndex = 15;
            this.yAxisMaxNumeric.ValueChanged += new System.EventHandler(this.yAxisNumeric_ValueChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(371, 39);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(56, 13);
            this.label1.TabIndex = 16;
            this.label1.Text = "Y Axis Min";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(477, 39);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(59, 13);
            this.label2.TabIndex = 17;
            this.label2.Text = "Y Axis Max";
            // 
            // saveChirpToolStripMenuItem
            // 
            this.saveChirpToolStripMenuItem.Name = "saveChirpToolStripMenuItem";
            this.saveChirpToolStripMenuItem.Size = new System.Drawing.Size(167, 22);
            this.saveChirpToolStripMenuItem.Text = "Save Chirp";
            this.saveChirpToolStripMenuItem.Click += new System.EventHandler(this.saveChirpToolStripMenuItem_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(600, 696);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.yAxisMaxNumeric);
            this.Controls.Add(this.yAxisMinNumeric);
            this.Controls.Add(this.autoScaleCheckBox2);
            this.Controls.Add(this.autoScaleCheckBox1);
            this.Controls.Add(this.takeReducedButton);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.dataSelectedGroupBox1);
            this.Controls.Add(this.enableCheckBox3);
            this.Controls.Add(this.enableCheckBox1);
            this.Controls.Add(this.enableCheckBox2);
            this.Controls.Add(this.zScanGraphControl);
            this.Controls.Add(this.frequencyAxisGraphControl);
            this.Controls.Add(this.timeAxisGraphControl);
            this.Controls.Add(this.stopButton);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "MainForm";
            this.Text = "Squid";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.MainForm_FormClosed);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.dataSelectedGroupBox1.ResumeLayout(false);
            this.dataSelectedGroupBox1.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.yAxisMinNumeric)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.yAxisMaxNumeric)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem controlToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem chopperMotorToolStripMenuItem;
        private System.Windows.Forms.Button stopButton;
        private System.Windows.Forms.ToolStripMenuItem nI6251ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem controlToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem startContinousToolStripMenuItem;
        private GraphControl.GraphControl timeAxisGraphControl;
        private GraphControl.GraphControl frequencyAxisGraphControl;
        private System.Windows.Forms.ToolStripMenuItem stopContinousScanToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem squidOptionsToolStripMenuItem;
        private GraphControl.GraphControl zScanGraphControl;
        private System.Windows.Forms.CheckBox enableCheckBox2;
        private System.Windows.Forms.CheckBox enableCheckBox1;
        private System.Windows.Forms.CheckBox enableCheckBox3;
        private System.Windows.Forms.GroupBox dataSelectedGroupBox1;
        private System.Windows.Forms.RadioButton origionalRadioButton1;
        private System.Windows.Forms.RadioButton reducedRadioButton1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton origionalRadioButton2;
        private System.Windows.Forms.RadioButton reducedRadioButton2;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.RadioButton timeRadioButton;
        private System.Windows.Forms.RadioButton freqRadioButton;
        private System.Windows.Forms.ToolStripMenuItem startZScanToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem stagesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem takeSingleTraceToolStripMenuItem;
        private System.Windows.Forms.Button takeReducedButton;
        private System.Windows.Forms.ToolStripMenuItem saveSingleScanToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveZAxisScanToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem stopZScanToolStripMenuItem;
        private System.Windows.Forms.CheckBox autoScaleCheckBox1;
        private System.Windows.Forms.CheckBox autoScaleCheckBox2;
        private System.Windows.Forms.NumericUpDown yAxisMinNumeric;
        private System.Windows.Forms.NumericUpDown yAxisMaxNumeric;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ToolStripMenuItem chirpControlToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem chrpWaveformToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem stopChirpWaveformToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveChirpToolStripMenuItem;

    }
}

