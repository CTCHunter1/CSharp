namespace Lab.Drivers.PVCAM_Wrapper.Test
{
    partial class PVCAM_WrapperTestForm
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
            this.initalizeButton = new System.Windows.Forms.Button();
            this.xPixelsNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.yPixelsNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label6 = new System.Windows.Forms.Label();
            this.yBinNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.label7 = new System.Windows.Forms.Label();
            this.yMaxNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.label8 = new System.Windows.Forms.Label();
            this.yMinNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.label5 = new System.Windows.Forms.Label();
            this.xBinNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.label4 = new System.Windows.Forms.Label();
            this.xMaxNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.xMinNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.acquireSingleShotButton = new System.Windows.Forms.Button();
            this.getTempButton = new System.Windows.Forms.Button();
            this.setTempButton = new System.Windows.Forms.Button();
            this.tempNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.unIntializeButton = new System.Windows.Forms.Button();
            this.setupDoubleBuffButton = new System.Windows.Forms.Button();
            this.acqDoubleBuffer = new System.Windows.Forms.Button();
            this.canDoubleBufButton = new System.Windows.Forms.Button();
            this.canDoubleBuffTextBox = new System.Windows.Forms.TextBox();
            this.dBStatusTextBox = new System.Windows.Forms.TextBox();
            this.stopDBAcqButton = new System.Windows.Forms.Button();
            this.getTypeButton = new System.Windows.Forms.Button();
            this.typeTextBox = new System.Windows.Forms.TextBox();
            this.shutterModeComboBox = new System.Windows.Forms.ComboBox();
            this.label9 = new System.Windows.Forms.Label();
            this.getShutterModeButton = new System.Windows.Forms.Button();
            this.setShutterModeButton = new System.Windows.Forms.Button();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.tabPage5 = new System.Windows.Forms.TabPage();
            this.tabPage6 = new System.Windows.Forms.TabPage();
            this.tabPage7 = new System.Windows.Forms.TabPage();
            this.tabPage8 = new System.Windows.Forms.TabPage();
            this.numCamerasNmericUpDown = new System.Windows.Forms.NumericUpDown();
            this.label10 = new System.Windows.Forms.Label();
            this.cameraNamesComboBox = new System.Windows.Forms.ComboBox();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.exposureUnitComboBox = new System.Windows.Forms.ComboBox();
            this.label13 = new System.Windows.Forms.Label();
            this.integrationNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.ccdClearingControl = new Lab.Drivers.PVCAM_Wrapper.Test.PropertyControl();
            this.gainPropertyControl = new Lab.Drivers.PVCAM_Wrapper.Test.PropertyControl();
            this.temperaturePropertyControl = new Lab.Drivers.PVCAM_Wrapper.Test.PropertyControl();
            this.shutterPropertyControl = new Lab.Drivers.PVCAM_Wrapper.Test.PropertyControl();
            this.ADCPropertyControl = new Lab.Drivers.PVCAM_Wrapper.Test.PropertyControl();
            this.CCDPhysPropertyControl = new Lab.Drivers.PVCAM_Wrapper.Test.PropertyControl();
            this.CCDReadOutPropertyControl = new Lab.Drivers.PVCAM_Wrapper.Test.PropertyControl();
            this.DataAcqPropertyControl = new Lab.Drivers.PVCAM_Wrapper.Test.PropertyControl();
            ((System.ComponentModel.ISupportInitialize)(this.xPixelsNumericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.yPixelsNumericUpDown)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.yBinNumericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.yMaxNumericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.yMinNumericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.xBinNumericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.xMaxNumericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.xMinNumericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tempNumericUpDown)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.tabPage4.SuspendLayout();
            this.tabPage5.SuspendLayout();
            this.tabPage6.SuspendLayout();
            this.tabPage7.SuspendLayout();
            this.tabPage8.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numCamerasNmericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.integrationNumericUpDown)).BeginInit();
            this.SuspendLayout();
            // 
            // initalizeButton
            // 
            this.initalizeButton.Location = new System.Drawing.Point(22, 28);
            this.initalizeButton.Name = "initalizeButton";
            this.initalizeButton.Size = new System.Drawing.Size(75, 23);
            this.initalizeButton.TabIndex = 0;
            this.initalizeButton.Text = "Initalize";
            this.initalizeButton.UseVisualStyleBackColor = true;
            this.initalizeButton.Click += new System.EventHandler(this.initalizeButton_Click);
            // 
            // xPixelsNumericUpDown
            // 
            this.xPixelsNumericUpDown.Location = new System.Drawing.Point(121, 30);
            this.xPixelsNumericUpDown.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.xPixelsNumericUpDown.Name = "xPixelsNumericUpDown";
            this.xPixelsNumericUpDown.Size = new System.Drawing.Size(120, 20);
            this.xPixelsNumericUpDown.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(121, 11);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(44, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "X Pixels";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(121, 56);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(44, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Y Pixels";
            // 
            // yPixelsNumericUpDown
            // 
            this.yPixelsNumericUpDown.Location = new System.Drawing.Point(121, 75);
            this.yPixelsNumericUpDown.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.yPixelsNumericUpDown.Name = "yPixelsNumericUpDown";
            this.yPixelsNumericUpDown.Size = new System.Drawing.Size(120, 20);
            this.yPixelsNumericUpDown.TabIndex = 3;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.yBinNumericUpDown);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.yMaxNumericUpDown);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.yMinNumericUpDown);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.xBinNumericUpDown);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.xMaxNumericUpDown);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.xMinNumericUpDown);
            this.groupBox1.Location = new System.Drawing.Point(22, 101);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(252, 130);
            this.groupBox1.TabIndex = 5;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Region of Interest";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(172, 73);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(32, 13);
            this.label6.TabIndex = 17;
            this.label6.Text = "Y Bin";
            // 
            // yBinNumericUpDown
            // 
            this.yBinNumericUpDown.Location = new System.Drawing.Point(172, 92);
            this.yBinNumericUpDown.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.yBinNumericUpDown.Name = "yBinNumericUpDown";
            this.yBinNumericUpDown.Size = new System.Drawing.Size(68, 20);
            this.yBinNumericUpDown.TabIndex = 16;
            this.yBinNumericUpDown.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.yBinNumericUpDown.ValueChanged += new System.EventHandler(this.ROI_Changed);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(98, 73);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(37, 13);
            this.label7.TabIndex = 15;
            this.label7.Text = "Y Max";
            // 
            // yMaxNumericUpDown
            // 
            this.yMaxNumericUpDown.Location = new System.Drawing.Point(98, 92);
            this.yMaxNumericUpDown.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.yMaxNumericUpDown.Minimum = new decimal(new int[] {
            100,
            0,
            0,
            -2147483648});
            this.yMaxNumericUpDown.Name = "yMaxNumericUpDown";
            this.yMaxNumericUpDown.Size = new System.Drawing.Size(68, 20);
            this.yMaxNumericUpDown.TabIndex = 14;
            this.yMaxNumericUpDown.ValueChanged += new System.EventHandler(this.ROI_Changed);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(22, 73);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(34, 13);
            this.label8.TabIndex = 13;
            this.label8.Text = "Y Min";
            // 
            // yMinNumericUpDown
            // 
            this.yMinNumericUpDown.Location = new System.Drawing.Point(22, 92);
            this.yMinNumericUpDown.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.yMinNumericUpDown.Minimum = new decimal(new int[] {
            100,
            0,
            0,
            -2147483648});
            this.yMinNumericUpDown.Name = "yMinNumericUpDown";
            this.yMinNumericUpDown.Size = new System.Drawing.Size(68, 20);
            this.yMinNumericUpDown.TabIndex = 12;
            this.yMinNumericUpDown.ValueChanged += new System.EventHandler(this.ROI_Changed);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(173, 22);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(32, 13);
            this.label5.TabIndex = 11;
            this.label5.Text = "X Bin";
            // 
            // xBinNumericUpDown
            // 
            this.xBinNumericUpDown.Location = new System.Drawing.Point(173, 41);
            this.xBinNumericUpDown.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.xBinNumericUpDown.Name = "xBinNumericUpDown";
            this.xBinNumericUpDown.Size = new System.Drawing.Size(68, 20);
            this.xBinNumericUpDown.TabIndex = 10;
            this.xBinNumericUpDown.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.xBinNumericUpDown.ValueChanged += new System.EventHandler(this.ROI_Changed);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(99, 22);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(37, 13);
            this.label4.TabIndex = 9;
            this.label4.Text = "X Max";
            // 
            // xMaxNumericUpDown
            // 
            this.xMaxNumericUpDown.Location = new System.Drawing.Point(99, 41);
            this.xMaxNumericUpDown.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.xMaxNumericUpDown.Minimum = new decimal(new int[] {
            100,
            0,
            0,
            -2147483648});
            this.xMaxNumericUpDown.Name = "xMaxNumericUpDown";
            this.xMaxNumericUpDown.Size = new System.Drawing.Size(68, 20);
            this.xMaxNumericUpDown.TabIndex = 8;
            this.xMaxNumericUpDown.ValueChanged += new System.EventHandler(this.ROI_Changed);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(23, 22);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(34, 13);
            this.label3.TabIndex = 7;
            this.label3.Text = "X Min";
            // 
            // xMinNumericUpDown
            // 
            this.xMinNumericUpDown.Location = new System.Drawing.Point(23, 41);
            this.xMinNumericUpDown.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.xMinNumericUpDown.Minimum = new decimal(new int[] {
            100,
            0,
            0,
            -2147483648});
            this.xMinNumericUpDown.Name = "xMinNumericUpDown";
            this.xMinNumericUpDown.Size = new System.Drawing.Size(68, 20);
            this.xMinNumericUpDown.TabIndex = 6;
            this.xMinNumericUpDown.ValueChanged += new System.EventHandler(this.ROI_Changed);
            // 
            // acquireSingleShotButton
            // 
            this.acquireSingleShotButton.Location = new System.Drawing.Point(292, 221);
            this.acquireSingleShotButton.Name = "acquireSingleShotButton";
            this.acquireSingleShotButton.Size = new System.Drawing.Size(152, 23);
            this.acquireSingleShotButton.TabIndex = 7;
            this.acquireSingleShotButton.Text = "Acquire Single Shot";
            this.acquireSingleShotButton.UseVisualStyleBackColor = true;
            this.acquireSingleShotButton.Click += new System.EventHandler(this.acquireSingleShotButton_Click);
            // 
            // getTempButton
            // 
            this.getTempButton.Location = new System.Drawing.Point(10, 21);
            this.getTempButton.Name = "getTempButton";
            this.getTempButton.Size = new System.Drawing.Size(75, 23);
            this.getTempButton.TabIndex = 9;
            this.getTempButton.Text = "Get";
            this.getTempButton.UseVisualStyleBackColor = true;
            this.getTempButton.Click += new System.EventHandler(this.getTempButton_Click);
            // 
            // setTempButton
            // 
            this.setTempButton.Location = new System.Drawing.Point(10, 50);
            this.setTempButton.Name = "setTempButton";
            this.setTempButton.Size = new System.Drawing.Size(75, 23);
            this.setTempButton.TabIndex = 10;
            this.setTempButton.Text = "Set";
            this.setTempButton.UseVisualStyleBackColor = true;
            this.setTempButton.Click += new System.EventHandler(this.setTempButton_Click);
            // 
            // tempNumericUpDown
            // 
            this.tempNumericUpDown.DecimalPlaces = 3;
            this.tempNumericUpDown.Location = new System.Drawing.Point(98, 24);
            this.tempNumericUpDown.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.tempNumericUpDown.Minimum = new decimal(new int[] {
            100,
            0,
            0,
            -2147483648});
            this.tempNumericUpDown.Name = "tempNumericUpDown";
            this.tempNumericUpDown.Size = new System.Drawing.Size(97, 20);
            this.tempNumericUpDown.TabIndex = 11;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.tempNumericUpDown);
            this.groupBox2.Controls.Add(this.setTempButton);
            this.groupBox2.Controls.Add(this.getTempButton);
            this.groupBox2.Location = new System.Drawing.Point(282, 17);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(201, 84);
            this.groupBox2.TabIndex = 12;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Temperture";
            // 
            // unIntializeButton
            // 
            this.unIntializeButton.Location = new System.Drawing.Point(22, 67);
            this.unIntializeButton.Name = "unIntializeButton";
            this.unIntializeButton.Size = new System.Drawing.Size(75, 23);
            this.unIntializeButton.TabIndex = 13;
            this.unIntializeButton.Text = "Uninitalize";
            this.unIntializeButton.UseVisualStyleBackColor = true;
            this.unIntializeButton.Click += new System.EventHandler(this.unIntializeButton_Click);
            // 
            // setupDoubleBuffButton
            // 
            this.setupDoubleBuffButton.Location = new System.Drawing.Point(564, 175);
            this.setupDoubleBuffButton.Name = "setupDoubleBuffButton";
            this.setupDoubleBuffButton.Size = new System.Drawing.Size(152, 23);
            this.setupDoubleBuffButton.TabIndex = 14;
            this.setupDoubleBuffButton.Text = "Setup Camera Double Buffer";
            this.setupDoubleBuffButton.UseVisualStyleBackColor = true;
            this.setupDoubleBuffButton.Click += new System.EventHandler(this.setupDoubleBuffButton_Click);
            // 
            // acqDoubleBuffer
            // 
            this.acqDoubleBuffer.Location = new System.Drawing.Point(564, 208);
            this.acqDoubleBuffer.Name = "acqDoubleBuffer";
            this.acqDoubleBuffer.Size = new System.Drawing.Size(152, 41);
            this.acqDoubleBuffer.TabIndex = 15;
            this.acqDoubleBuffer.Text = "Acquire Camera Double Buffer";
            this.acqDoubleBuffer.UseVisualStyleBackColor = true;
            this.acqDoubleBuffer.Click += new System.EventHandler(this.acqDoubleBuffer_Click);
            // 
            // canDoubleBufButton
            // 
            this.canDoubleBufButton.Location = new System.Drawing.Point(564, 114);
            this.canDoubleBufButton.Name = "canDoubleBufButton";
            this.canDoubleBufButton.Size = new System.Drawing.Size(152, 23);
            this.canDoubleBufButton.TabIndex = 16;
            this.canDoubleBufButton.Text = "Can Double Buffer?";
            this.canDoubleBufButton.UseVisualStyleBackColor = true;
            this.canDoubleBufButton.Click += new System.EventHandler(this.canDoubleBufButton_Click);
            // 
            // canDoubleBuffTextBox
            // 
            this.canDoubleBuffTextBox.Location = new System.Drawing.Point(564, 149);
            this.canDoubleBuffTextBox.Name = "canDoubleBuffTextBox";
            this.canDoubleBuffTextBox.Size = new System.Drawing.Size(100, 20);
            this.canDoubleBuffTextBox.TabIndex = 17;
            // 
            // dBStatusTextBox
            // 
            this.dBStatusTextBox.Location = new System.Drawing.Point(739, 229);
            this.dBStatusTextBox.Name = "dBStatusTextBox";
            this.dBStatusTextBox.Size = new System.Drawing.Size(100, 20);
            this.dBStatusTextBox.TabIndex = 18;
            // 
            // stopDBAcqButton
            // 
            this.stopDBAcqButton.Location = new System.Drawing.Point(722, 172);
            this.stopDBAcqButton.Name = "stopDBAcqButton";
            this.stopDBAcqButton.Size = new System.Drawing.Size(152, 41);
            this.stopDBAcqButton.TabIndex = 19;
            this.stopDBAcqButton.Text = "Stop Double Buffer";
            this.stopDBAcqButton.UseVisualStyleBackColor = true;
            this.stopDBAcqButton.Click += new System.EventHandler(this.stopDBAcqButton_Click);
            // 
            // getTypeButton
            // 
            this.getTypeButton.Location = new System.Drawing.Point(508, 27);
            this.getTypeButton.Name = "getTypeButton";
            this.getTypeButton.Size = new System.Drawing.Size(75, 23);
            this.getTypeButton.TabIndex = 20;
            this.getTypeButton.Text = "Get Type";
            this.getTypeButton.UseVisualStyleBackColor = true;
            this.getTypeButton.Click += new System.EventHandler(this.getTypeButton_Click);
            // 
            // typeTextBox
            // 
            this.typeTextBox.Location = new System.Drawing.Point(600, 27);
            this.typeTextBox.Name = "typeTextBox";
            this.typeTextBox.Size = new System.Drawing.Size(100, 20);
            this.typeTextBox.TabIndex = 21;
            // 
            // shutterModeComboBox
            // 
            this.shutterModeComboBox.FormattingEnabled = true;
            this.shutterModeComboBox.Location = new System.Drawing.Point(292, 123);
            this.shutterModeComboBox.Name = "shutterModeComboBox";
            this.shutterModeComboBox.Size = new System.Drawing.Size(185, 21);
            this.shutterModeComboBox.TabIndex = 22;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(289, 104);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(71, 13);
            this.label9.TabIndex = 23;
            this.label9.Text = "Shutter Mode";
            // 
            // getShutterModeButton
            // 
            this.getShutterModeButton.Location = new System.Drawing.Point(292, 150);
            this.getShutterModeButton.Name = "getShutterModeButton";
            this.getShutterModeButton.Size = new System.Drawing.Size(75, 23);
            this.getShutterModeButton.TabIndex = 24;
            this.getShutterModeButton.Text = "Get";
            this.getShutterModeButton.UseVisualStyleBackColor = true;
            this.getShutterModeButton.Click += new System.EventHandler(this.getShutterModeButton_Click);
            // 
            // setShutterModeButton
            // 
            this.setShutterModeButton.Location = new System.Drawing.Point(380, 150);
            this.setShutterModeButton.Name = "setShutterModeButton";
            this.setShutterModeButton.Size = new System.Drawing.Size(75, 23);
            this.setShutterModeButton.TabIndex = 25;
            this.setShutterModeButton.Text = "Set";
            this.setShutterModeButton.UseVisualStyleBackColor = true;
            this.setShutterModeButton.Click += new System.EventHandler(this.setShutterModeButton_Click);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Controls.Add(this.tabPage4);
            this.tabControl1.Controls.Add(this.tabPage5);
            this.tabControl1.Controls.Add(this.tabPage6);
            this.tabControl1.Controls.Add(this.tabPage7);
            this.tabControl1.Controls.Add(this.tabPage8);
            this.tabControl1.Location = new System.Drawing.Point(12, 255);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(603, 346);
            this.tabControl1.TabIndex = 28;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.ccdClearingControl);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(595, 320);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "CCD Clearing";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.gainPropertyControl);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(595, 320);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Gain";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.temperaturePropertyControl);
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(595, 320);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Temperature";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // tabPage4
            // 
            this.tabPage4.Controls.Add(this.shutterPropertyControl);
            this.tabPage4.Location = new System.Drawing.Point(4, 22);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage4.Size = new System.Drawing.Size(595, 320);
            this.tabPage4.TabIndex = 3;
            this.tabPage4.Text = "Shutter";
            this.tabPage4.UseVisualStyleBackColor = true;
            // 
            // tabPage5
            // 
            this.tabPage5.Controls.Add(this.ADCPropertyControl);
            this.tabPage5.Location = new System.Drawing.Point(4, 22);
            this.tabPage5.Name = "tabPage5";
            this.tabPage5.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage5.Size = new System.Drawing.Size(595, 320);
            this.tabPage5.TabIndex = 4;
            this.tabPage5.Text = "ADC Attributes";
            this.tabPage5.UseVisualStyleBackColor = true;
            // 
            // tabPage6
            // 
            this.tabPage6.Controls.Add(this.CCDPhysPropertyControl);
            this.tabPage6.Location = new System.Drawing.Point(4, 22);
            this.tabPage6.Name = "tabPage6";
            this.tabPage6.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage6.Size = new System.Drawing.Size(595, 320);
            this.tabPage6.TabIndex = 5;
            this.tabPage6.Text = "CCD Phys. Attr.";
            this.tabPage6.UseVisualStyleBackColor = true;
            // 
            // tabPage7
            // 
            this.tabPage7.Controls.Add(this.CCDReadOutPropertyControl);
            this.tabPage7.Location = new System.Drawing.Point(4, 22);
            this.tabPage7.Name = "tabPage7";
            this.tabPage7.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage7.Size = new System.Drawing.Size(595, 320);
            this.tabPage7.TabIndex = 6;
            this.tabPage7.Text = "CCD Readout";
            this.tabPage7.UseVisualStyleBackColor = true;
            // 
            // tabPage8
            // 
            this.tabPage8.Controls.Add(this.DataAcqPropertyControl);
            this.tabPage8.Location = new System.Drawing.Point(4, 22);
            this.tabPage8.Name = "tabPage8";
            this.tabPage8.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage8.Size = new System.Drawing.Size(595, 320);
            this.tabPage8.TabIndex = 7;
            this.tabPage8.Text = "Data Acquisition";
            this.tabPage8.UseVisualStyleBackColor = true;
            // 
            // numCamerasNmericUpDown
            // 
            this.numCamerasNmericUpDown.Location = new System.Drawing.Point(736, 282);
            this.numCamerasNmericUpDown.Name = "numCamerasNmericUpDown";
            this.numCamerasNmericUpDown.Size = new System.Drawing.Size(120, 20);
            this.numCamerasNmericUpDown.TabIndex = 29;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(736, 267);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(73, 13);
            this.label10.TabIndex = 30;
            this.label10.Text = "Num Cameras";
            // 
            // cameraNamesComboBox
            // 
            this.cameraNamesComboBox.FormattingEnabled = true;
            this.cameraNamesComboBox.Location = new System.Drawing.Point(736, 326);
            this.cameraNamesComboBox.Name = "cameraNamesComboBox";
            this.cameraNamesComboBox.Size = new System.Drawing.Size(121, 21);
            this.cameraNamesComboBox.TabIndex = 31;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(736, 310);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(79, 13);
            this.label11.TabIndex = 32;
            this.label11.Text = "Camera Names";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(481, 175);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(73, 13);
            this.label12.TabIndex = 36;
            this.label12.Text = "Exposure Unit";
            // 
            // exposureUnitComboBox
            // 
            this.exposureUnitComboBox.FormattingEnabled = true;
            this.exposureUnitComboBox.Location = new System.Drawing.Point(403, 194);
            this.exposureUnitComboBox.Name = "exposureUnitComboBox";
            this.exposureUnitComboBox.Size = new System.Drawing.Size(157, 21);
            this.exposureUnitComboBox.TabIndex = 35;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(292, 176);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(97, 13);
            this.label13.TabIndex = 34;
            this.label13.Text = "Integration Time (s)";
            // 
            // integrationNumericUpDown
            // 
            this.integrationNumericUpDown.Location = new System.Drawing.Point(292, 195);
            this.integrationNumericUpDown.Maximum = new decimal(new int[] {
            50000,
            0,
            0,
            0});
            this.integrationNumericUpDown.Name = "integrationNumericUpDown";
            this.integrationNumericUpDown.Size = new System.Drawing.Size(81, 20);
            this.integrationNumericUpDown.TabIndex = 33;
            this.integrationNumericUpDown.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // ccdClearingControl
            // 
            this.ccdClearingControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ccdClearingControl.Location = new System.Drawing.Point(3, 3);
            this.ccdClearingControl.Name = "ccdClearingControl";
            this.ccdClearingControl.Size = new System.Drawing.Size(589, 314);
            this.ccdClearingControl.TabIndex = 28;
            // 
            // gainPropertyControl
            // 
            this.gainPropertyControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gainPropertyControl.Location = new System.Drawing.Point(3, 3);
            this.gainPropertyControl.Name = "gainPropertyControl";
            this.gainPropertyControl.Size = new System.Drawing.Size(589, 314);
            this.gainPropertyControl.TabIndex = 0;
            // 
            // temperaturePropertyControl
            // 
            this.temperaturePropertyControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.temperaturePropertyControl.Location = new System.Drawing.Point(3, 3);
            this.temperaturePropertyControl.Name = "temperaturePropertyControl";
            this.temperaturePropertyControl.Size = new System.Drawing.Size(589, 314);
            this.temperaturePropertyControl.TabIndex = 0;
            // 
            // shutterPropertyControl
            // 
            this.shutterPropertyControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.shutterPropertyControl.Location = new System.Drawing.Point(3, 3);
            this.shutterPropertyControl.Name = "shutterPropertyControl";
            this.shutterPropertyControl.Size = new System.Drawing.Size(589, 314);
            this.shutterPropertyControl.TabIndex = 0;
            // 
            // ADCPropertyControl
            // 
            this.ADCPropertyControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ADCPropertyControl.Location = new System.Drawing.Point(3, 3);
            this.ADCPropertyControl.Name = "ADCPropertyControl";
            this.ADCPropertyControl.Size = new System.Drawing.Size(589, 314);
            this.ADCPropertyControl.TabIndex = 0;
            // 
            // CCDPhysPropertyControl
            // 
            this.CCDPhysPropertyControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.CCDPhysPropertyControl.Location = new System.Drawing.Point(3, 3);
            this.CCDPhysPropertyControl.Name = "CCDPhysPropertyControl";
            this.CCDPhysPropertyControl.Size = new System.Drawing.Size(589, 314);
            this.CCDPhysPropertyControl.TabIndex = 0;
            // 
            // CCDReadOutPropertyControl
            // 
            this.CCDReadOutPropertyControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.CCDReadOutPropertyControl.Location = new System.Drawing.Point(3, 3);
            this.CCDReadOutPropertyControl.Name = "CCDReadOutPropertyControl";
            this.CCDReadOutPropertyControl.Size = new System.Drawing.Size(589, 314);
            this.CCDReadOutPropertyControl.TabIndex = 0;
            // 
            // DataAcqPropertyControl
            // 
            this.DataAcqPropertyControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DataAcqPropertyControl.Location = new System.Drawing.Point(3, 3);
            this.DataAcqPropertyControl.Name = "DataAcqPropertyControl";
            this.DataAcqPropertyControl.Size = new System.Drawing.Size(589, 314);
            this.DataAcqPropertyControl.TabIndex = 1;
            // 
            // PVCAM_WrapperTestForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(886, 608);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.exposureUnitComboBox);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.integrationNumericUpDown);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.cameraNamesComboBox);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.numCamerasNmericUpDown);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.setShutterModeButton);
            this.Controls.Add(this.getShutterModeButton);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.shutterModeComboBox);
            this.Controls.Add(this.typeTextBox);
            this.Controls.Add(this.getTypeButton);
            this.Controls.Add(this.stopDBAcqButton);
            this.Controls.Add(this.dBStatusTextBox);
            this.Controls.Add(this.canDoubleBuffTextBox);
            this.Controls.Add(this.canDoubleBufButton);
            this.Controls.Add(this.acqDoubleBuffer);
            this.Controls.Add(this.setupDoubleBuffButton);
            this.Controls.Add(this.unIntializeButton);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.acquireSingleShotButton);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.yPixelsNumericUpDown);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.xPixelsNumericUpDown);
            this.Controls.Add(this.initalizeButton);
            this.Name = "PVCAM_WrapperTestForm";
            this.Text = "PVCAM";
            this.Activated += new System.EventHandler(this.PVCAM_WrapperTestForm_Activated);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.PVCAM_WrapperTestForm_FormClosing);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form1_FormClosed);
            ((System.ComponentModel.ISupportInitialize)(this.xPixelsNumericUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.yPixelsNumericUpDown)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.yBinNumericUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.yMaxNumericUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.yMinNumericUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.xBinNumericUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.xMaxNumericUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.xMinNumericUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tempNumericUpDown)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.tabPage3.ResumeLayout(false);
            this.tabPage4.ResumeLayout(false);
            this.tabPage5.ResumeLayout(false);
            this.tabPage6.ResumeLayout(false);
            this.tabPage7.ResumeLayout(false);
            this.tabPage8.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.numCamerasNmericUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.integrationNumericUpDown)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button initalizeButton;
        private System.Windows.Forms.NumericUpDown xPixelsNumericUpDown;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown yPixelsNumericUpDown;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.NumericUpDown xMinNumericUpDown;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.NumericUpDown xMaxNumericUpDown;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.NumericUpDown xBinNumericUpDown;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.NumericUpDown yBinNumericUpDown;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.NumericUpDown yMaxNumericUpDown;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.NumericUpDown yMinNumericUpDown;
        private System.Windows.Forms.Button acquireSingleShotButton;
        private System.Windows.Forms.Button getTempButton;
        private System.Windows.Forms.Button setTempButton;
        private System.Windows.Forms.NumericUpDown tempNumericUpDown;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button unIntializeButton;
        private System.Windows.Forms.Button setupDoubleBuffButton;
        private System.Windows.Forms.Button acqDoubleBuffer;
        private System.Windows.Forms.Button canDoubleBufButton;
        private System.Windows.Forms.TextBox canDoubleBuffTextBox;
        private System.Windows.Forms.TextBox dBStatusTextBox;
        private System.Windows.Forms.Button stopDBAcqButton;
        private System.Windows.Forms.Button getTypeButton;
        private System.Windows.Forms.TextBox typeTextBox;
        private System.Windows.Forms.ComboBox shutterModeComboBox;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Button getShutterModeButton;
        private System.Windows.Forms.Button setShutterModeButton;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private PropertyControl ccdClearingControl;
        private System.Windows.Forms.TabPage tabPage2;
        private PropertyControl gainPropertyControl;
        private System.Windows.Forms.TabPage tabPage3;
        private PropertyControl temperaturePropertyControl;
        private System.Windows.Forms.TabPage tabPage4;
        private PropertyControl shutterPropertyControl;
        private System.Windows.Forms.TabPage tabPage5;
        private PropertyControl ADCPropertyControl;
        private System.Windows.Forms.TabPage tabPage6;
        private PropertyControl CCDPhysPropertyControl;
        private System.Windows.Forms.TabPage tabPage7;
        private PropertyControl CCDReadOutPropertyControl;
        private System.Windows.Forms.TabPage tabPage8;
        private PropertyControl DataAcqPropertyControl;
        private System.Windows.Forms.NumericUpDown numCamerasNmericUpDown;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.ComboBox cameraNamesComboBox;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.ComboBox exposureUnitComboBox;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.NumericUpDown integrationNumericUpDown;
    }
}

