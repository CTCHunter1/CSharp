namespace Beluga
{
    partial class BelugaMainForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(BelugaMainForm));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.configToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pVCamToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.actonMonToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.motorsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.videoDeviceComboBox = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.startCapture = new System.Windows.Forms.Button();
            this.acqPointListView = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.numScansNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.integrationNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.label4 = new System.Windows.Forms.Label();
            this.acquireButton = new System.Windows.Forms.Button();
            this.stopButton = new System.Windows.Forms.Button();
            this.exposureUnitComboBox = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.selectedCameraComboBox = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.addGridButton = new System.Windows.Forms.Button();
            this.label13 = new System.Windows.Forms.Label();
            this.stepSizeYNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.label12 = new System.Windows.Forms.Label();
            this.stepSizeXNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.label11 = new System.Windows.Forms.Label();
            this.numPtsAx2NumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.label10 = new System.Windows.Forms.Label();
            this.numPtsAx1NumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.label9 = new System.Windows.Forms.Label();
            this.motorAxis2ComboBox = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.motorAxis1ComboBox = new System.Windows.Forms.ComboBox();
            this.addButton = new System.Windows.Forms.Button();
            this.acquireSeqButton = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.numExposureSeqnumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.acquoreContinousButton = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.pathSelectButton = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.savePathTextBox = new System.Windows.Forms.TextBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.usePVCamRadioButton = new System.Windows.Forms.RadioButton();
            this.useWebCamRadioButton = new System.Windows.Forms.RadioButton();
            this.deleteButton = new System.Windows.Forms.Button();
            this.clearButton = new System.Windows.Forms.Button();
            this.resetButton = new System.Windows.Forms.Button();
            this.stopSeqButton = new System.Windows.Forms.Button();
            this.menuStrip1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numScansNumericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.integrationNumericUpDown)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.stepSizeYNumericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.stepSizeXNumericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numPtsAx2NumericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numPtsAx1NumericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numExposureSeqnumericUpDown)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.configToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(940, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.saveToolStripMenuItem,
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(35, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // saveToolStripMenuItem
            // 
            this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            this.saveToolStripMenuItem.Size = new System.Drawing.Size(112, 22);
            this.saveToolStripMenuItem.Text = "S&ave ";
            this.saveToolStripMenuItem.Click += new System.EventHandler(this.saveToolStripMenuItem_Click);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(112, 22);
            this.exitToolStripMenuItem.Text = "E&xit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // configToolStripMenuItem
            // 
            this.configToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.pVCamToolStripMenuItem,
            this.actonMonToolStripMenuItem,
            this.motorsToolStripMenuItem});
            this.configToolStripMenuItem.Name = "configToolStripMenuItem";
            this.configToolStripMenuItem.Size = new System.Drawing.Size(50, 20);
            this.configToolStripMenuItem.Text = "Config";
            // 
            // pVCamToolStripMenuItem
            // 
            this.pVCamToolStripMenuItem.Name = "pVCamToolStripMenuItem";
            this.pVCamToolStripMenuItem.Size = new System.Drawing.Size(191, 22);
            this.pVCamToolStripMenuItem.Text = "PVCam";
            // 
            // actonMonToolStripMenuItem
            // 
            this.actonMonToolStripMenuItem.Name = "actonMonToolStripMenuItem";
            this.actonMonToolStripMenuItem.Size = new System.Drawing.Size(191, 22);
            this.actonMonToolStripMenuItem.Text = "Acton Monochromator";
            this.actonMonToolStripMenuItem.Click += new System.EventHandler(this.actonMonToolStripMenuItem_Click);
            // 
            // motorsToolStripMenuItem
            // 
            this.motorsToolStripMenuItem.Name = "motorsToolStripMenuItem";
            this.motorsToolStripMenuItem.Size = new System.Drawing.Size(191, 22);
            this.motorsToolStripMenuItem.Text = "Motors";
            this.motorsToolStripMenuItem.Click += new System.EventHandler(this.motorsToolStripMenuItem_Click);
            // 
            // videoDeviceComboBox
            // 
            this.videoDeviceComboBox.FormattingEnabled = true;
            this.videoDeviceComboBox.Location = new System.Drawing.Point(14, 103);
            this.videoDeviceComboBox.Name = "videoDeviceComboBox";
            this.videoDeviceComboBox.Size = new System.Drawing.Size(233, 21);
            this.videoDeviceComboBox.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(14, 87);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(71, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Video Device";
            // 
            // startCapture
            // 
            this.startCapture.Location = new System.Drawing.Point(14, 130);
            this.startCapture.Name = "startCapture";
            this.startCapture.Size = new System.Drawing.Size(135, 23);
            this.startCapture.TabIndex = 5;
            this.startCapture.Text = "Start Capture";
            this.startCapture.UseVisualStyleBackColor = true;
            this.startCapture.Click += new System.EventHandler(this.startCapture_Click);
            // 
            // acqPointListView
            // 
            this.acqPointListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3,
            this.columnHeader4});
            this.acqPointListView.FullRowSelect = true;
            this.acqPointListView.Location = new System.Drawing.Point(13, 19);
            this.acqPointListView.Name = "acqPointListView";
            this.acqPointListView.Size = new System.Drawing.Size(550, 160);
            this.acqPointListView.TabIndex = 6;
            this.acqPointListView.UseCompatibleStateImageBehavior = false;
            this.acqPointListView.View = System.Windows.Forms.View.Details;
            this.acqPointListView.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.acqPointListView_KeyPress);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "#";
            this.columnHeader1.Width = 31;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Location";
            this.columnHeader2.Width = 306;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Num Exposures";
            this.columnHeader3.Width = 86;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "Complete";
            this.columnHeader4.Width = 121;
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1});
            this.statusStrip1.Location = new System.Drawing.Point(0, 621);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(940, 22);
            this.statusStrip1.TabIndex = 8;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(0, 17);
            // 
            // numScansNumericUpDown
            // 
            this.numScansNumericUpDown.Location = new System.Drawing.Point(10, 40);
            this.numScansNumericUpDown.Name = "numScansNumericUpDown";
            this.numScansNumericUpDown.Size = new System.Drawing.Size(81, 20);
            this.numScansNumericUpDown.TabIndex = 9;
            this.numScansNumericUpDown.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(10, 21);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(81, 13);
            this.label3.TabIndex = 10;
            this.label3.Text = "Num Exposures";
            // 
            // integrationNumericUpDown
            // 
            this.integrationNumericUpDown.Location = new System.Drawing.Point(136, 56);
            this.integrationNumericUpDown.Maximum = new decimal(new int[] {
            50000,
            0,
            0,
            0});
            this.integrationNumericUpDown.Name = "integrationNumericUpDown";
            this.integrationNumericUpDown.Size = new System.Drawing.Size(81, 20);
            this.integrationNumericUpDown.TabIndex = 11;
            this.integrationNumericUpDown.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(136, 37);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(97, 13);
            this.label4.TabIndex = 12;
            this.label4.Text = "Integration Time (s)";
            // 
            // acquireButton
            // 
            this.acquireButton.Location = new System.Drawing.Point(10, 71);
            this.acquireButton.Name = "acquireButton";
            this.acquireButton.Size = new System.Drawing.Size(75, 23);
            this.acquireButton.TabIndex = 13;
            this.acquireButton.Text = "Acquire";
            this.acquireButton.UseVisualStyleBackColor = true;
            this.acquireButton.Click += new System.EventHandler(this.acquireButton_Click);
            // 
            // stopButton
            // 
            this.stopButton.Location = new System.Drawing.Point(10, 144);
            this.stopButton.Name = "stopButton";
            this.stopButton.Size = new System.Drawing.Size(75, 23);
            this.stopButton.TabIndex = 14;
            this.stopButton.Text = "Stop";
            this.stopButton.UseVisualStyleBackColor = true;
            this.stopButton.Click += new System.EventHandler(this.stopButton_Click);
            // 
            // exposureUnitComboBox
            // 
            this.exposureUnitComboBox.FormattingEnabled = true;
            this.exposureUnitComboBox.Location = new System.Drawing.Point(232, 56);
            this.exposureUnitComboBox.Name = "exposureUnitComboBox";
            this.exposureUnitComboBox.Size = new System.Drawing.Size(157, 21);
            this.exposureUnitComboBox.TabIndex = 16;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(310, 37);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(73, 13);
            this.label5.TabIndex = 17;
            this.label5.Text = "Exposure Unit";
            // 
            // selectedCameraComboBox
            // 
            this.selectedCameraComboBox.FormattingEnabled = true;
            this.selectedCameraComboBox.Location = new System.Drawing.Point(10, 55);
            this.selectedCameraComboBox.Name = "selectedCameraComboBox";
            this.selectedCameraComboBox.Size = new System.Drawing.Size(120, 21);
            this.selectedCameraComboBox.TabIndex = 18;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(10, 36);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(88, 13);
            this.label6.TabIndex = 19;
            this.label6.Text = "Selected Camera";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.addGridButton);
            this.groupBox1.Controls.Add(this.label13);
            this.groupBox1.Controls.Add(this.stepSizeYNumericUpDown);
            this.groupBox1.Controls.Add(this.label12);
            this.groupBox1.Controls.Add(this.stepSizeXNumericUpDown);
            this.groupBox1.Controls.Add(this.label11);
            this.groupBox1.Controls.Add(this.numPtsAx2NumericUpDown);
            this.groupBox1.Controls.Add(this.label10);
            this.groupBox1.Controls.Add(this.numPtsAx1NumericUpDown);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.motorAxis2ComboBox);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.motorAxis1ComboBox);
            this.groupBox1.Location = new System.Drawing.Point(481, 185);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(241, 242);
            this.groupBox1.TabIndex = 21;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Add Grid of Points";
            // 
            // addGridButton
            // 
            this.addGridButton.Location = new System.Drawing.Point(9, 213);
            this.addGridButton.Name = "addGridButton";
            this.addGridButton.Size = new System.Drawing.Size(75, 23);
            this.addGridButton.TabIndex = 12;
            this.addGridButton.Text = "Add Grid";
            this.addGridButton.UseVisualStyleBackColor = true;
            this.addGridButton.Click += new System.EventHandler(this.addGridButton_Click);
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(6, 187);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(75, 13);
            this.label13.TabIndex = 11;
            this.label13.Text = "Distance (um):";
            // 
            // stepSizeYNumericUpDown
            // 
            this.stepSizeYNumericUpDown.DecimalPlaces = 2;
            this.stepSizeYNumericUpDown.Location = new System.Drawing.Point(84, 185);
            this.stepSizeYNumericUpDown.Maximum = new decimal(new int[] {
            2000,
            0,
            0,
            0});
            this.stepSizeYNumericUpDown.Name = "stepSizeYNumericUpDown";
            this.stepSizeYNumericUpDown.Size = new System.Drawing.Size(69, 20);
            this.stepSizeYNumericUpDown.TabIndex = 10;
            this.stepSizeYNumericUpDown.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(6, 92);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(75, 13);
            this.label12.TabIndex = 9;
            this.label12.Text = "Distance (um):";
            // 
            // stepSizeXNumericUpDown
            // 
            this.stepSizeXNumericUpDown.DecimalPlaces = 2;
            this.stepSizeXNumericUpDown.Location = new System.Drawing.Point(84, 90);
            this.stepSizeXNumericUpDown.Maximum = new decimal(new int[] {
            2000,
            0,
            0,
            0});
            this.stepSizeXNumericUpDown.Name = "stepSizeXNumericUpDown";
            this.stepSizeXNumericUpDown.Size = new System.Drawing.Size(69, 20);
            this.stepSizeXNumericUpDown.TabIndex = 8;
            this.stepSizeXNumericUpDown.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(6, 163);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(50, 13);
            this.label11.TabIndex = 7;
            this.label11.Text = "Num Pts:";
            // 
            // numPtsAx2NumericUpDown
            // 
            this.numPtsAx2NumericUpDown.Location = new System.Drawing.Point(60, 161);
            this.numPtsAx2NumericUpDown.Maximum = new decimal(new int[] {
            2000,
            0,
            0,
            0});
            this.numPtsAx2NumericUpDown.Name = "numPtsAx2NumericUpDown";
            this.numPtsAx2NumericUpDown.Size = new System.Drawing.Size(48, 20);
            this.numPtsAx2NumericUpDown.TabIndex = 6;
            this.numPtsAx2NumericUpDown.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(6, 66);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(50, 13);
            this.label10.TabIndex = 5;
            this.label10.Text = "Num Pts:";
            // 
            // numPtsAx1NumericUpDown
            // 
            this.numPtsAx1NumericUpDown.Location = new System.Drawing.Point(60, 64);
            this.numPtsAx1NumericUpDown.Maximum = new decimal(new int[] {
            2000,
            0,
            0,
            0});
            this.numPtsAx1NumericUpDown.Name = "numPtsAx1NumericUpDown";
            this.numPtsAx1NumericUpDown.Size = new System.Drawing.Size(48, 20);
            this.numPtsAx1NumericUpDown.TabIndex = 4;
            this.numPtsAx1NumericUpDown.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(6, 118);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(103, 13);
            this.label9.TabIndex = 3;
            this.label9.Text = "Y Axis - Motor Axis 2";
            // 
            // motorAxis2ComboBox
            // 
            this.motorAxis2ComboBox.FormattingEnabled = true;
            this.motorAxis2ComboBox.Location = new System.Drawing.Point(6, 134);
            this.motorAxis2ComboBox.Name = "motorAxis2ComboBox";
            this.motorAxis2ComboBox.Size = new System.Drawing.Size(227, 21);
            this.motorAxis2ComboBox.TabIndex = 2;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(6, 21);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(103, 13);
            this.label8.TabIndex = 1;
            this.label8.Text = "X Axis - Motor Axis 1";
            // 
            // motorAxis1ComboBox
            // 
            this.motorAxis1ComboBox.FormattingEnabled = true;
            this.motorAxis1ComboBox.Location = new System.Drawing.Point(6, 37);
            this.motorAxis1ComboBox.Name = "motorAxis1ComboBox";
            this.motorAxis1ComboBox.Size = new System.Drawing.Size(227, 21);
            this.motorAxis1ComboBox.TabIndex = 0;
            // 
            // addButton
            // 
            this.addButton.Location = new System.Drawing.Point(10, 243);
            this.addButton.Name = "addButton";
            this.addButton.Size = new System.Drawing.Size(75, 23);
            this.addButton.TabIndex = 22;
            this.addButton.Text = "Add";
            this.addButton.UseVisualStyleBackColor = true;
            this.addButton.Click += new System.EventHandler(this.addButton_Click);
            // 
            // acquireSeqButton
            // 
            this.acquireSeqButton.Location = new System.Drawing.Point(217, 201);
            this.acquireSeqButton.Name = "acquireSeqButton";
            this.acquireSeqButton.Size = new System.Drawing.Size(75, 36);
            this.acquireSeqButton.TabIndex = 23;
            this.acquireSeqButton.Text = "Acquire Sequence";
            this.acquireSeqButton.UseVisualStyleBackColor = true;
            this.acquireSeqButton.Click += new System.EventHandler(this.acquireSeqButton_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(10, 193);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(81, 13);
            this.label7.TabIndex = 25;
            this.label7.Text = "Num Exposures";
            // 
            // numExposureSeqnumericUpDown
            // 
            this.numExposureSeqnumericUpDown.Location = new System.Drawing.Point(10, 212);
            this.numExposureSeqnumericUpDown.Name = "numExposureSeqnumericUpDown";
            this.numExposureSeqnumericUpDown.Size = new System.Drawing.Size(81, 20);
            this.numExposureSeqnumericUpDown.TabIndex = 24;
            this.numExposureSeqnumericUpDown.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.acquoreContinousButton);
            this.groupBox2.Controls.Add(this.acquireButton);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.numScansNumericUpDown);
            this.groupBox2.Controls.Add(this.stopButton);
            this.groupBox2.Location = new System.Drawing.Point(754, 166);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(107, 173);
            this.groupBox2.TabIndex = 26;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Single Position";
            // 
            // acquoreContinousButton
            // 
            this.acquoreContinousButton.Location = new System.Drawing.Point(10, 98);
            this.acquoreContinousButton.Name = "acquoreContinousButton";
            this.acquoreContinousButton.Size = new System.Drawing.Size(75, 42);
            this.acquoreContinousButton.TabIndex = 15;
            this.acquoreContinousButton.Text = "Acquire Continous";
            this.acquoreContinousButton.UseVisualStyleBackColor = true;
            this.acquoreContinousButton.Click += new System.EventHandler(this.acquireContinousButton_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.pathSelectButton);
            this.groupBox3.Controls.Add(this.label2);
            this.groupBox3.Controls.Add(this.groupBox1);
            this.groupBox3.Controls.Add(this.savePathTextBox);
            this.groupBox3.Controls.Add(this.groupBox4);
            this.groupBox3.Controls.Add(this.deleteButton);
            this.groupBox3.Controls.Add(this.clearButton);
            this.groupBox3.Controls.Add(this.resetButton);
            this.groupBox3.Controls.Add(this.stopSeqButton);
            this.groupBox3.Controls.Add(this.label7);
            this.groupBox3.Controls.Add(this.numExposureSeqnumericUpDown);
            this.groupBox3.Controls.Add(this.acquireSeqButton);
            this.groupBox3.Controls.Add(this.addButton);
            this.groupBox3.Controls.Add(this.acqPointListView);
            this.groupBox3.Location = new System.Drawing.Point(10, 166);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(728, 452);
            this.groupBox3.TabIndex = 27;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Exposure Sequence";
            // 
            // pathSelectButton
            // 
            this.pathSelectButton.Location = new System.Drawing.Point(420, 413);
            this.pathSelectButton.Name = "pathSelectButton";
            this.pathSelectButton.Size = new System.Drawing.Size(40, 23);
            this.pathSelectButton.TabIndex = 34;
            this.pathSelectButton.Text = "..";
            this.pathSelectButton.UseVisualStyleBackColor = true;
            this.pathSelectButton.Click += new System.EventHandler(this.pathSelectButton_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(9, 399);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(76, 13);
            this.label2.TabIndex = 33;
            this.label2.Text = "Save File Path";
            // 
            // savePathTextBox
            // 
            this.savePathTextBox.Location = new System.Drawing.Point(10, 415);
            this.savePathTextBox.Name = "savePathTextBox";
            this.savePathTextBox.Size = new System.Drawing.Size(404, 20);
            this.savePathTextBox.TabIndex = 32;
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.usePVCamRadioButton);
            this.groupBox4.Controls.Add(this.useWebCamRadioButton);
            this.groupBox4.Location = new System.Drawing.Point(569, 19);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(109, 68);
            this.groupBox4.TabIndex = 31;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Acquire Camera";
            // 
            // usePVCamRadioButton
            // 
            this.usePVCamRadioButton.AutoSize = true;
            this.usePVCamRadioButton.Checked = true;
            this.usePVCamRadioButton.Location = new System.Drawing.Point(6, 19);
            this.usePVCamRadioButton.Name = "usePVCamRadioButton";
            this.usePVCamRadioButton.Size = new System.Drawing.Size(81, 17);
            this.usePVCamRadioButton.TabIndex = 30;
            this.usePVCamRadioButton.TabStop = true;
            this.usePVCamRadioButton.Text = "Use PVcam";
            this.usePVCamRadioButton.UseVisualStyleBackColor = true;
            // 
            // useWebCamRadioButton
            // 
            this.useWebCamRadioButton.AutoSize = true;
            this.useWebCamRadioButton.Location = new System.Drawing.Point(6, 40);
            this.useWebCamRadioButton.Name = "useWebCamRadioButton";
            this.useWebCamRadioButton.Size = new System.Drawing.Size(90, 17);
            this.useWebCamRadioButton.TabIndex = 29;
            this.useWebCamRadioButton.Text = "Use Webcam";
            this.useWebCamRadioButton.UseVisualStyleBackColor = true;
            // 
            // deleteButton
            // 
            this.deleteButton.Location = new System.Drawing.Point(10, 275);
            this.deleteButton.Name = "deleteButton";
            this.deleteButton.Size = new System.Drawing.Size(75, 23);
            this.deleteButton.TabIndex = 28;
            this.deleteButton.Text = "Delete";
            this.deleteButton.UseVisualStyleBackColor = true;
            this.deleteButton.Click += new System.EventHandler(this.deleteButton_Click);
            // 
            // clearButton
            // 
            this.clearButton.Location = new System.Drawing.Point(112, 243);
            this.clearButton.Name = "clearButton";
            this.clearButton.Size = new System.Drawing.Size(75, 23);
            this.clearButton.TabIndex = 27;
            this.clearButton.Text = "Clear";
            this.clearButton.UseVisualStyleBackColor = true;
            this.clearButton.Click += new System.EventHandler(this.clearButton_Click);
            // 
            // resetButton
            // 
            this.resetButton.Location = new System.Drawing.Point(112, 205);
            this.resetButton.Name = "resetButton";
            this.resetButton.Size = new System.Drawing.Size(75, 23);
            this.resetButton.TabIndex = 26;
            this.resetButton.Text = "Reset";
            this.resetButton.UseVisualStyleBackColor = true;
            this.resetButton.Click += new System.EventHandler(this.resetButton_Click);
            // 
            // stopSeqButton
            // 
            this.stopSeqButton.Location = new System.Drawing.Point(217, 243);
            this.stopSeqButton.Name = "stopSeqButton";
            this.stopSeqButton.Size = new System.Drawing.Size(75, 23);
            this.stopSeqButton.TabIndex = 15;
            this.stopSeqButton.Text = "Stop";
            this.stopSeqButton.UseVisualStyleBackColor = true;
            this.stopSeqButton.Click += new System.EventHandler(this.stopButton_Click);
            // 
            // BelugaMainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(940, 643);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.selectedCameraComboBox);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.exposureUnitComboBox);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.integrationNumericUpDown);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.startCapture);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.videoDeviceComboBox);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "BelugaMainForm";
            this.Text = "BelugaMainForm";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.BelugaMainForm_FormClosed);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numScansNumericUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.integrationNumericUpDown)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.stepSizeYNumericUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.stepSizeXNumericUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numPtsAx2NumericUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numPtsAx1NumericUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numExposureSeqnumericUpDown)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem configToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem pVCamToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem actonMonToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem motorsToolStripMenuItem;
        private System.Windows.Forms.ComboBox videoDeviceComboBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button startCapture;
        private System.Windows.Forms.ListView acqPointListView;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.NumericUpDown numScansNumericUpDown;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.NumericUpDown integrationNumericUpDown;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button acquireButton;
        private System.Windows.Forms.Button stopButton;
        private System.Windows.Forms.ComboBox exposureUnitComboBox;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox selectedCameraComboBox;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button addButton;
        private System.Windows.Forms.Button acquireSeqButton;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.NumericUpDown numExposureSeqnumericUpDown;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button stopSeqButton;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.Button resetButton;
        private System.Windows.Forms.Button clearButton;
        private System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem;
        private System.Windows.Forms.Button deleteButton;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.RadioButton usePVCamRadioButton;
        private System.Windows.Forms.RadioButton useWebCamRadioButton;
        private System.Windows.Forms.Button pathSelectButton;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox savePathTextBox;
        private System.Windows.Forms.Button acquoreContinousButton;
        private System.Windows.Forms.Button addGridButton;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.NumericUpDown stepSizeYNumericUpDown;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.NumericUpDown stepSizeXNumericUpDown;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.NumericUpDown numPtsAx2NumericUpDown;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.NumericUpDown numPtsAx1NumericUpDown;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.ComboBox motorAxis2ComboBox;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ComboBox motorAxis1ComboBox;
    }
}

