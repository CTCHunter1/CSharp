namespace Lab.Drivers.Motors.Test
{
    partial class ASI_LV4000TestForm
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
            this.createLV4000 = new System.Windows.Forms.Button();
            this.getStatusButton = new System.Windows.Forms.Button();
            this.statusTextBox = new System.Windows.Forms.TextBox();
            this.createdTextBox = new System.Windows.Forms.TextBox();
            this.getPositionButton = new System.Windows.Forms.Button();
            this.xPosNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.yPosNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.moveButton = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.exceptionTextBox = new System.Windows.Forms.TextBox();
            this.clearButton = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.moveRelbutton = new System.Windows.Forms.Button();
            this.moveZbutton = new System.Windows.Forms.Button();
            this.moveZRelbutton = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.zPositionUpDown = new System.Windows.Forms.NumericUpDown();
            this.getZPositionButton = new System.Windows.Forms.Button();
            this.haltZButton = new System.Windows.Forms.Button();
            this.haltXYbutton = new System.Windows.Forms.Button();
            this.zeroXYButton = new System.Windows.Forms.Button();
            this.zeroZButton = new System.Windows.Forms.Button();
            this.getSpeedButton = new System.Windows.Forms.Button();
            this.setSpeedXYButton = new System.Windows.Forms.Button();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.ySpeedNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.xSpeedNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.label8 = new System.Windows.Forms.Label();
            this.zspeedUpDown = new System.Windows.Forms.NumericUpDown();
            this.setZSpeedButton = new System.Windows.Forms.Button();
            this.getZSpeedButton = new System.Windows.Forms.Button();
            this.getXSpeedbutton = new System.Windows.Forms.Button();
            this.setXSpeedButton = new System.Windows.Forms.Button();
            this.getYSpeedbutton = new System.Windows.Forms.Button();
            this.setYSpeedButton = new System.Windows.Forms.Button();
            this.getXPosButton = new System.Windows.Forms.Button();
            this.moveXButton = new System.Windows.Forms.Button();
            this.getYPosButton = new System.Windows.Forms.Button();
            this.moveYButton = new System.Windows.Forms.Button();
            this.moveXRelButton = new System.Windows.Forms.Button();
            this.moveYRelButton = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.relMoveXnumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.label11 = new System.Windows.Forms.Label();
            this.relMoveYNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.movmentStatuszTextBox = new System.Windows.Forms.TextBox();
            this.getZStatusButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.xPosNumericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.yPosNumericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.zPositionUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ySpeedNumericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.xSpeedNumericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.zspeedUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.relMoveXnumericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.relMoveYNumericUpDown)).BeginInit();
            this.SuspendLayout();
            // 
            // createLV4000
            // 
            this.createLV4000.Location = new System.Drawing.Point(22, 12);
            this.createLV4000.Name = "createLV4000";
            this.createLV4000.Size = new System.Drawing.Size(75, 23);
            this.createLV4000.TabIndex = 0;
            this.createLV4000.Text = "Create Obj";
            this.createLV4000.UseVisualStyleBackColor = true;
            this.createLV4000.Click += new System.EventHandler(this.createLV4000_Click);
            // 
            // getStatusButton
            // 
            this.getStatusButton.Location = new System.Drawing.Point(22, 49);
            this.getStatusButton.Name = "getStatusButton";
            this.getStatusButton.Size = new System.Drawing.Size(75, 23);
            this.getStatusButton.TabIndex = 1;
            this.getStatusButton.Text = "Get Status";
            this.getStatusButton.UseVisualStyleBackColor = true;
            this.getStatusButton.Click += new System.EventHandler(this.getStatusButton_Click);
            // 
            // statusTextBox
            // 
            this.statusTextBox.Location = new System.Drawing.Point(125, 52);
            this.statusTextBox.Name = "statusTextBox";
            this.statusTextBox.Size = new System.Drawing.Size(87, 20);
            this.statusTextBox.TabIndex = 2;
            // 
            // createdTextBox
            // 
            this.createdTextBox.Location = new System.Drawing.Point(125, 15);
            this.createdTextBox.Name = "createdTextBox";
            this.createdTextBox.Size = new System.Drawing.Size(87, 20);
            this.createdTextBox.TabIndex = 3;
            // 
            // getPositionButton
            // 
            this.getPositionButton.Location = new System.Drawing.Point(22, 95);
            this.getPositionButton.Name = "getPositionButton";
            this.getPositionButton.Size = new System.Drawing.Size(75, 23);
            this.getPositionButton.TabIndex = 4;
            this.getPositionButton.Text = "Get Position";
            this.getPositionButton.UseVisualStyleBackColor = true;
            this.getPositionButton.Click += new System.EventHandler(this.getPositionButton_Click);
            // 
            // xPosNumericUpDown
            // 
            this.xPosNumericUpDown.DecimalPlaces = 1;
            this.xPosNumericUpDown.Location = new System.Drawing.Point(122, 108);
            this.xPosNumericUpDown.Maximum = new decimal(new int[] {
            1000000,
            0,
            0,
            0});
            this.xPosNumericUpDown.Minimum = new decimal(new int[] {
            1000000,
            0,
            0,
            -2147483648});
            this.xPosNumericUpDown.Name = "xPosNumericUpDown";
            this.xPosNumericUpDown.Size = new System.Drawing.Size(70, 20);
            this.xPosNumericUpDown.TabIndex = 5;
            // 
            // yPosNumericUpDown
            // 
            this.yPosNumericUpDown.DecimalPlaces = 1;
            this.yPosNumericUpDown.Location = new System.Drawing.Point(208, 108);
            this.yPosNumericUpDown.Maximum = new decimal(new int[] {
            1000000,
            0,
            0,
            0});
            this.yPosNumericUpDown.Minimum = new decimal(new int[] {
            1000000,
            0,
            0,
            -2147483648});
            this.yPosNumericUpDown.Name = "yPosNumericUpDown";
            this.yPosNumericUpDown.Size = new System.Drawing.Size(70, 20);
            this.yPosNumericUpDown.TabIndex = 6;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(119, 92);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 7;
            this.label1.Text = "X Pos";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(205, 92);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 13);
            this.label2.TabIndex = 8;
            this.label2.Text = "Y Pos";
            // 
            // moveButton
            // 
            this.moveButton.Location = new System.Drawing.Point(22, 137);
            this.moveButton.Name = "moveButton";
            this.moveButton.Size = new System.Drawing.Size(75, 23);
            this.moveButton.TabIndex = 9;
            this.moveButton.Text = "Move XY";
            this.moveButton.UseVisualStyleBackColor = true;
            this.moveButton.Click += new System.EventHandler(this.moveButton_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(19, 469);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(54, 13);
            this.label3.TabIndex = 10;
            this.label3.Text = "Exception";
            // 
            // exceptionTextBox
            // 
            this.exceptionTextBox.Location = new System.Drawing.Point(22, 485);
            this.exceptionTextBox.Multiline = true;
            this.exceptionTextBox.Name = "exceptionTextBox";
            this.exceptionTextBox.Size = new System.Drawing.Size(281, 84);
            this.exceptionTextBox.TabIndex = 11;
            // 
            // clearButton
            // 
            this.clearButton.Location = new System.Drawing.Point(22, 576);
            this.clearButton.Name = "clearButton";
            this.clearButton.Size = new System.Drawing.Size(75, 23);
            this.clearButton.TabIndex = 12;
            this.clearButton.Text = "Clear";
            this.clearButton.UseVisualStyleBackColor = true;
            this.clearButton.Click += new System.EventHandler(this.clearButton_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(251, 92);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(27, 13);
            this.label4.TabIndex = 13;
            this.label4.Text = "(um)";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(160, 92);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(27, 13);
            this.label5.TabIndex = 14;
            this.label5.Text = "(um)";
            // 
            // moveRelbutton
            // 
            this.moveRelbutton.Location = new System.Drawing.Point(22, 166);
            this.moveRelbutton.Name = "moveRelbutton";
            this.moveRelbutton.Size = new System.Drawing.Size(75, 36);
            this.moveRelbutton.TabIndex = 15;
            this.moveRelbutton.Text = "Move XY Relative";
            this.moveRelbutton.UseVisualStyleBackColor = true;
            this.moveRelbutton.Click += new System.EventHandler(this.moveRelbutton_Click);
            // 
            // moveZbutton
            // 
            this.moveZbutton.Location = new System.Drawing.Point(18, 385);
            this.moveZbutton.Name = "moveZbutton";
            this.moveZbutton.Size = new System.Drawing.Size(75, 23);
            this.moveZbutton.TabIndex = 16;
            this.moveZbutton.Text = "Move Z";
            this.moveZbutton.UseVisualStyleBackColor = true;
            this.moveZbutton.Click += new System.EventHandler(this.moveZbutton_Click);
            // 
            // moveZRelbutton
            // 
            this.moveZRelbutton.Location = new System.Drawing.Point(18, 414);
            this.moveZRelbutton.Name = "moveZRelbutton";
            this.moveZRelbutton.Size = new System.Drawing.Size(75, 44);
            this.moveZRelbutton.TabIndex = 17;
            this.moveZRelbutton.Text = "Move Z Relative";
            this.moveZRelbutton.UseVisualStyleBackColor = true;
            this.moveZRelbutton.Click += new System.EventHandler(this.moveZRelbutton_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(110, 344);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(35, 13);
            this.label6.TabIndex = 19;
            this.label6.Text = "Z Pos";
            // 
            // zPositionUpDown
            // 
            this.zPositionUpDown.DecimalPlaces = 1;
            this.zPositionUpDown.Location = new System.Drawing.Point(108, 360);
            this.zPositionUpDown.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.zPositionUpDown.Minimum = new decimal(new int[] {
            100000,
            0,
            0,
            -2147483648});
            this.zPositionUpDown.Name = "zPositionUpDown";
            this.zPositionUpDown.Size = new System.Drawing.Size(70, 20);
            this.zPositionUpDown.TabIndex = 18;
            // 
            // getZPositionButton
            // 
            this.getZPositionButton.Location = new System.Drawing.Point(18, 339);
            this.getZPositionButton.Name = "getZPositionButton";
            this.getZPositionButton.Size = new System.Drawing.Size(75, 40);
            this.getZPositionButton.TabIndex = 20;
            this.getZPositionButton.Text = "Get Z Position";
            this.getZPositionButton.UseVisualStyleBackColor = true;
            this.getZPositionButton.Click += new System.EventHandler(this.getZPositionButton_Click);
            // 
            // haltZButton
            // 
            this.haltZButton.Location = new System.Drawing.Point(108, 386);
            this.haltZButton.Name = "haltZButton";
            this.haltZButton.Size = new System.Drawing.Size(75, 23);
            this.haltZButton.TabIndex = 21;
            this.haltZButton.Text = "Halt Z";
            this.haltZButton.UseVisualStyleBackColor = true;
            this.haltZButton.Click += new System.EventHandler(this.haltZButton_Click);
            // 
            // haltXYbutton
            // 
            this.haltXYbutton.Location = new System.Drawing.Point(117, 139);
            this.haltXYbutton.Name = "haltXYbutton";
            this.haltXYbutton.Size = new System.Drawing.Size(75, 40);
            this.haltXYbutton.TabIndex = 22;
            this.haltXYbutton.Text = "Halt XY";
            this.haltXYbutton.UseVisualStyleBackColor = true;
            this.haltXYbutton.Click += new System.EventHandler(this.haltXYbutton_Click);
            // 
            // zeroXYButton
            // 
            this.zeroXYButton.Location = new System.Drawing.Point(208, 137);
            this.zeroXYButton.Name = "zeroXYButton";
            this.zeroXYButton.Size = new System.Drawing.Size(75, 23);
            this.zeroXYButton.TabIndex = 23;
            this.zeroXYButton.Text = "Zero XY";
            this.zeroXYButton.UseVisualStyleBackColor = true;
            this.zeroXYButton.Click += new System.EventHandler(this.zeroXYButton_Click);
            // 
            // zeroZButton
            // 
            this.zeroZButton.Location = new System.Drawing.Point(189, 386);
            this.zeroZButton.Name = "zeroZButton";
            this.zeroZButton.Size = new System.Drawing.Size(75, 23);
            this.zeroZButton.TabIndex = 24;
            this.zeroZButton.Text = "Zero Z";
            this.zeroZButton.UseVisualStyleBackColor = true;
            this.zeroZButton.Click += new System.EventHandler(this.zeroZButton_Click);
            // 
            // getSpeedButton
            // 
            this.getSpeedButton.Location = new System.Drawing.Point(299, 66);
            this.getSpeedButton.Name = "getSpeedButton";
            this.getSpeedButton.Size = new System.Drawing.Size(75, 23);
            this.getSpeedButton.TabIndex = 25;
            this.getSpeedButton.Text = "Get Speed";
            this.getSpeedButton.UseVisualStyleBackColor = true;
            this.getSpeedButton.Click += new System.EventHandler(this.getSpeedButton_Click);
            // 
            // setSpeedXYButton
            // 
            this.setSpeedXYButton.Location = new System.Drawing.Point(380, 66);
            this.setSpeedXYButton.Name = "setSpeedXYButton";
            this.setSpeedXYButton.Size = new System.Drawing.Size(75, 23);
            this.setSpeedXYButton.TabIndex = 26;
            this.setSpeedXYButton.Text = "Set Speed";
            this.setSpeedXYButton.UseVisualStyleBackColor = true;
            this.setSpeedXYButton.Click += new System.EventHandler(this.setSpeedXYButton_Click);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(377, 92);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(48, 13);
            this.label9.TabIndex = 30;
            this.label9.Text = "Y Speed";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(301, 92);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(48, 13);
            this.label10.TabIndex = 29;
            this.label10.Text = "X Speed";
            // 
            // ySpeedNumericUpDown
            // 
            this.ySpeedNumericUpDown.DecimalPlaces = 1;
            this.ySpeedNumericUpDown.Location = new System.Drawing.Point(380, 108);
            this.ySpeedNumericUpDown.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.ySpeedNumericUpDown.Minimum = new decimal(new int[] {
            100000,
            0,
            0,
            -2147483648});
            this.ySpeedNumericUpDown.Name = "ySpeedNumericUpDown";
            this.ySpeedNumericUpDown.Size = new System.Drawing.Size(70, 20);
            this.ySpeedNumericUpDown.TabIndex = 28;
            // 
            // xSpeedNumericUpDown
            // 
            this.xSpeedNumericUpDown.DecimalPlaces = 1;
            this.xSpeedNumericUpDown.Location = new System.Drawing.Point(304, 108);
            this.xSpeedNumericUpDown.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.xSpeedNumericUpDown.Minimum = new decimal(new int[] {
            100000,
            0,
            0,
            -2147483648});
            this.xSpeedNumericUpDown.Name = "xSpeedNumericUpDown";
            this.xSpeedNumericUpDown.Size = new System.Drawing.Size(70, 20);
            this.xSpeedNumericUpDown.TabIndex = 27;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(301, 248);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(48, 13);
            this.label8.TabIndex = 35;
            this.label8.Text = "Z Speed";
            // 
            // zspeedUpDown
            // 
            this.zspeedUpDown.DecimalPlaces = 3;
            this.zspeedUpDown.Location = new System.Drawing.Point(304, 264);
            this.zspeedUpDown.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.zspeedUpDown.Minimum = new decimal(new int[] {
            100000,
            0,
            0,
            -2147483648});
            this.zspeedUpDown.Name = "zspeedUpDown";
            this.zspeedUpDown.Size = new System.Drawing.Size(70, 20);
            this.zspeedUpDown.TabIndex = 33;
            // 
            // setZSpeedButton
            // 
            this.setZSpeedButton.Location = new System.Drawing.Point(304, 322);
            this.setZSpeedButton.Name = "setZSpeedButton";
            this.setZSpeedButton.Size = new System.Drawing.Size(75, 23);
            this.setZSpeedButton.TabIndex = 32;
            this.setZSpeedButton.Text = "Set Speed";
            this.setZSpeedButton.UseVisualStyleBackColor = true;
            this.setZSpeedButton.Click += new System.EventHandler(this.setZSpeedButton_Click);
            // 
            // getZSpeedButton
            // 
            this.getZSpeedButton.Location = new System.Drawing.Point(304, 295);
            this.getZSpeedButton.Name = "getZSpeedButton";
            this.getZSpeedButton.Size = new System.Drawing.Size(75, 23);
            this.getZSpeedButton.TabIndex = 31;
            this.getZSpeedButton.Text = "Get Speed";
            this.getZSpeedButton.UseVisualStyleBackColor = true;
            this.getZSpeedButton.Click += new System.EventHandler(this.getZSpeedButton_Click);
            // 
            // getXSpeedbutton
            // 
            this.getXSpeedbutton.Location = new System.Drawing.Point(304, 139);
            this.getXSpeedbutton.Name = "getXSpeedbutton";
            this.getXSpeedbutton.Size = new System.Drawing.Size(75, 40);
            this.getXSpeedbutton.TabIndex = 36;
            this.getXSpeedbutton.Text = "Get X Speed";
            this.getXSpeedbutton.UseVisualStyleBackColor = true;
            this.getXSpeedbutton.Click += new System.EventHandler(this.getXSpeedbutton_Click);
            // 
            // setXSpeedButton
            // 
            this.setXSpeedButton.Location = new System.Drawing.Point(304, 185);
            this.setXSpeedButton.Name = "setXSpeedButton";
            this.setXSpeedButton.Size = new System.Drawing.Size(75, 28);
            this.setXSpeedButton.TabIndex = 37;
            this.setXSpeedButton.Text = "Set X Speed";
            this.setXSpeedButton.UseVisualStyleBackColor = true;
            this.setXSpeedButton.Click += new System.EventHandler(this.setXSpeedButton_Click);
            // 
            // getYSpeedbutton
            // 
            this.getYSpeedbutton.Location = new System.Drawing.Point(380, 139);
            this.getYSpeedbutton.Name = "getYSpeedbutton";
            this.getYSpeedbutton.Size = new System.Drawing.Size(75, 40);
            this.getYSpeedbutton.TabIndex = 38;
            this.getYSpeedbutton.Text = "Get Y Speed";
            this.getYSpeedbutton.UseVisualStyleBackColor = true;
            this.getYSpeedbutton.Click += new System.EventHandler(this.getYSpeedbutton_Click);
            // 
            // setYSpeedButton
            // 
            this.setYSpeedButton.Location = new System.Drawing.Point(380, 185);
            this.setYSpeedButton.Name = "setYSpeedButton";
            this.setYSpeedButton.Size = new System.Drawing.Size(75, 28);
            this.setYSpeedButton.TabIndex = 39;
            this.setYSpeedButton.Text = "Set Y Speed";
            this.setYSpeedButton.UseVisualStyleBackColor = true;
            this.setYSpeedButton.Click += new System.EventHandler(this.setYSpeedButton_Click);
            // 
            // getXPosButton
            // 
            this.getXPosButton.Location = new System.Drawing.Point(117, 190);
            this.getXPosButton.Name = "getXPosButton";
            this.getXPosButton.Size = new System.Drawing.Size(75, 23);
            this.getXPosButton.TabIndex = 40;
            this.getXPosButton.Text = "Get X Pos";
            this.getXPosButton.UseVisualStyleBackColor = true;
            this.getXPosButton.Click += new System.EventHandler(this.getXPosButton_Click);
            // 
            // moveXButton
            // 
            this.moveXButton.Location = new System.Drawing.Point(117, 219);
            this.moveXButton.Name = "moveXButton";
            this.moveXButton.Size = new System.Drawing.Size(75, 23);
            this.moveXButton.TabIndex = 41;
            this.moveXButton.Text = "Move X Abs";
            this.moveXButton.UseVisualStyleBackColor = true;
            this.moveXButton.Click += new System.EventHandler(this.moveXButton_Click);
            // 
            // getYPosButton
            // 
            this.getYPosButton.Location = new System.Drawing.Point(208, 190);
            this.getYPosButton.Name = "getYPosButton";
            this.getYPosButton.Size = new System.Drawing.Size(75, 23);
            this.getYPosButton.TabIndex = 42;
            this.getYPosButton.Text = "Get Y Pos";
            this.getYPosButton.UseVisualStyleBackColor = true;
            this.getYPosButton.Click += new System.EventHandler(this.getYPosButton_Click);
            // 
            // moveYButton
            // 
            this.moveYButton.Location = new System.Drawing.Point(208, 219);
            this.moveYButton.Name = "moveYButton";
            this.moveYButton.Size = new System.Drawing.Size(75, 23);
            this.moveYButton.TabIndex = 43;
            this.moveYButton.Text = "Move Y Abs";
            this.moveYButton.UseVisualStyleBackColor = true;
            this.moveYButton.Click += new System.EventHandler(this.moveYButton_Click);
            // 
            // moveXRelButton
            // 
            this.moveXRelButton.Location = new System.Drawing.Point(117, 248);
            this.moveXRelButton.Name = "moveXRelButton";
            this.moveXRelButton.Size = new System.Drawing.Size(75, 23);
            this.moveXRelButton.TabIndex = 44;
            this.moveXRelButton.Text = "Move X Rel";
            this.moveXRelButton.UseVisualStyleBackColor = true;
            this.moveXRelButton.Click += new System.EventHandler(this.moveXRelButton_Click);
            // 
            // moveYRelButton
            // 
            this.moveYRelButton.Location = new System.Drawing.Point(208, 248);
            this.moveYRelButton.Name = "moveYRelButton";
            this.moveYRelButton.Size = new System.Drawing.Size(75, 23);
            this.moveYRelButton.TabIndex = 45;
            this.moveYRelButton.Text = "Move Y Rel";
            this.moveYRelButton.UseVisualStyleBackColor = true;
            this.moveYRelButton.Click += new System.EventHandler(this.moveYRelButton_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(114, 279);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(54, 13);
            this.label7.TabIndex = 47;
            this.label7.Text = "X Pos Rel";
            // 
            // relMoveXnumericUpDown
            // 
            this.relMoveXnumericUpDown.DecimalPlaces = 1;
            this.relMoveXnumericUpDown.Location = new System.Drawing.Point(117, 295);
            this.relMoveXnumericUpDown.Maximum = new decimal(new int[] {
            1000000,
            0,
            0,
            0});
            this.relMoveXnumericUpDown.Minimum = new decimal(new int[] {
            1000000,
            0,
            0,
            -2147483648});
            this.relMoveXnumericUpDown.Name = "relMoveXnumericUpDown";
            this.relMoveXnumericUpDown.Size = new System.Drawing.Size(70, 20);
            this.relMoveXnumericUpDown.TabIndex = 46;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(210, 279);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(54, 13);
            this.label11.TabIndex = 49;
            this.label11.Text = "Y Pos Rel";
            // 
            // relMoveYNumericUpDown
            // 
            this.relMoveYNumericUpDown.DecimalPlaces = 1;
            this.relMoveYNumericUpDown.Location = new System.Drawing.Point(213, 295);
            this.relMoveYNumericUpDown.Maximum = new decimal(new int[] {
            1000000,
            0,
            0,
            0});
            this.relMoveYNumericUpDown.Minimum = new decimal(new int[] {
            1000000,
            0,
            0,
            -2147483648});
            this.relMoveYNumericUpDown.Name = "relMoveYNumericUpDown";
            this.relMoveYNumericUpDown.Size = new System.Drawing.Size(70, 20);
            this.relMoveYNumericUpDown.TabIndex = 48;
            // 
            // movmentStatuszTextBox
            // 
            this.movmentStatuszTextBox.Location = new System.Drawing.Point(196, 438);
            this.movmentStatuszTextBox.Name = "movmentStatuszTextBox";
            this.movmentStatuszTextBox.Size = new System.Drawing.Size(87, 20);
            this.movmentStatuszTextBox.TabIndex = 51;
            // 
            // getZStatusButton
            // 
            this.getZStatusButton.Location = new System.Drawing.Point(108, 435);
            this.getZStatusButton.Name = "getZStatusButton";
            this.getZStatusButton.Size = new System.Drawing.Size(75, 23);
            this.getZStatusButton.TabIndex = 50;
            this.getZStatusButton.Text = "Get Z Status";
            this.getZStatusButton.UseVisualStyleBackColor = true;
            this.getZStatusButton.Click += new System.EventHandler(this.getZStatusButton_Click);
            // 
            // ASI_LV4000TestForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(490, 612);
            this.Controls.Add(this.movmentStatuszTextBox);
            this.Controls.Add(this.getZStatusButton);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.relMoveYNumericUpDown);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.relMoveXnumericUpDown);
            this.Controls.Add(this.moveYRelButton);
            this.Controls.Add(this.moveXRelButton);
            this.Controls.Add(this.moveYButton);
            this.Controls.Add(this.getYPosButton);
            this.Controls.Add(this.moveXButton);
            this.Controls.Add(this.getXPosButton);
            this.Controls.Add(this.setYSpeedButton);
            this.Controls.Add(this.getYSpeedbutton);
            this.Controls.Add(this.setXSpeedButton);
            this.Controls.Add(this.getXSpeedbutton);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.zspeedUpDown);
            this.Controls.Add(this.setZSpeedButton);
            this.Controls.Add(this.getZSpeedButton);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.ySpeedNumericUpDown);
            this.Controls.Add(this.xSpeedNumericUpDown);
            this.Controls.Add(this.setSpeedXYButton);
            this.Controls.Add(this.getSpeedButton);
            this.Controls.Add(this.zeroZButton);
            this.Controls.Add(this.zeroXYButton);
            this.Controls.Add(this.haltXYbutton);
            this.Controls.Add(this.haltZButton);
            this.Controls.Add(this.getZPositionButton);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.zPositionUpDown);
            this.Controls.Add(this.moveZRelbutton);
            this.Controls.Add(this.moveZbutton);
            this.Controls.Add(this.moveRelbutton);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.clearButton);
            this.Controls.Add(this.exceptionTextBox);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.moveButton);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.yPosNumericUpDown);
            this.Controls.Add(this.xPosNumericUpDown);
            this.Controls.Add(this.getPositionButton);
            this.Controls.Add(this.createdTextBox);
            this.Controls.Add(this.statusTextBox);
            this.Controls.Add(this.getStatusButton);
            this.Controls.Add(this.createLV4000);
            this.Name = "ASI_LV4000TestForm";
            this.Text = "ASILV4000TestForm";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.ASI_LV4000TestForm_FormClosed);
            ((System.ComponentModel.ISupportInitialize)(this.xPosNumericUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.yPosNumericUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.zPositionUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ySpeedNumericUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.xSpeedNumericUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.zspeedUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.relMoveXnumericUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.relMoveYNumericUpDown)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button createLV4000;
        private System.Windows.Forms.Button getStatusButton;
        private System.Windows.Forms.TextBox statusTextBox;
        private System.Windows.Forms.TextBox createdTextBox;
        private System.Windows.Forms.Button getPositionButton;
        private System.Windows.Forms.NumericUpDown xPosNumericUpDown;
        private System.Windows.Forms.NumericUpDown yPosNumericUpDown;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button moveButton;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox exceptionTextBox;
        private System.Windows.Forms.Button clearButton;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button moveRelbutton;
        private System.Windows.Forms.Button moveZbutton;
        private System.Windows.Forms.Button moveZRelbutton;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.NumericUpDown zPositionUpDown;
        private System.Windows.Forms.Button getZPositionButton;
        private System.Windows.Forms.Button haltZButton;
        private System.Windows.Forms.Button haltXYbutton;
        private System.Windows.Forms.Button zeroXYButton;
        private System.Windows.Forms.Button zeroZButton;
        private System.Windows.Forms.Button getSpeedButton;
        private System.Windows.Forms.Button setSpeedXYButton;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.NumericUpDown ySpeedNumericUpDown;
        private System.Windows.Forms.NumericUpDown xSpeedNumericUpDown;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.NumericUpDown zspeedUpDown;
        private System.Windows.Forms.Button setZSpeedButton;
        private System.Windows.Forms.Button getZSpeedButton;
        private System.Windows.Forms.Button getXSpeedbutton;
        private System.Windows.Forms.Button setXSpeedButton;
        private System.Windows.Forms.Button getYSpeedbutton;
        private System.Windows.Forms.Button setYSpeedButton;
        private System.Windows.Forms.Button getXPosButton;
        private System.Windows.Forms.Button moveXButton;
        private System.Windows.Forms.Button getYPosButton;
        private System.Windows.Forms.Button moveYButton;
        private System.Windows.Forms.Button moveXRelButton;
        private System.Windows.Forms.Button moveYRelButton;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.NumericUpDown relMoveXnumericUpDown;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.NumericUpDown relMoveYNumericUpDown;
        private System.Windows.Forms.TextBox movmentStatuszTextBox;
        private System.Windows.Forms.Button getZStatusButton;
    }
}