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
            System.Windows.Forms.ListViewItem listViewItem1 = new System.Windows.Forms.ListViewItem("1");
            System.Windows.Forms.ListViewItem listViewItem2 = new System.Windows.Forms.ListViewItem("2");
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.configToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pVCamToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.actonMonToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.motorsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.videoDeviceComboBox = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.startCapture = new System.Windows.Forms.Button();
            this.listView1 = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.label2 = new System.Windows.Forms.Label();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.numScansNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.integrationNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.label4 = new System.Windows.Forms.Label();
            this.acquireButton = new System.Windows.Forms.Button();
            this.stopButton = new System.Windows.Forms.Button();
            this.graphControl1 = new GraphControl.GraphControl();
            this.exposureUnitComboBox = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.selectedCameraComboBox = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.ilNumericsControl1 = new Beluga.TwoDGraphControl();
            this.menuStrip1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numScansNumericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.integrationNumericUpDown)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.configToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(956, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(35, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(103, 22);
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
            this.videoDeviceComboBox.Location = new System.Drawing.Point(12, 55);
            this.videoDeviceComboBox.Name = "videoDeviceComboBox";
            this.videoDeviceComboBox.Size = new System.Drawing.Size(233, 21);
            this.videoDeviceComboBox.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 39);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(71, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Video Device";
            // 
            // startCapture
            // 
            this.startCapture.Location = new System.Drawing.Point(12, 82);
            this.startCapture.Name = "startCapture";
            this.startCapture.Size = new System.Drawing.Size(135, 23);
            this.startCapture.TabIndex = 5;
            this.startCapture.Text = "Start Capture";
            this.startCapture.UseVisualStyleBackColor = true;
            this.startCapture.Click += new System.EventHandler(this.startCapture_Click);
            // 
            // listView1
            // 
            this.listView1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3});
            this.listView1.Items.AddRange(new System.Windows.Forms.ListViewItem[] {
            listViewItem1,
            listViewItem2});
            this.listView1.Location = new System.Drawing.Point(15, 147);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(251, 159);
            this.listView1.TabIndex = 6;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.View = System.Windows.Forms.View.Details;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 131);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(36, 13);
            this.label2.TabIndex = 7;
            this.label2.Text = "Points";
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1});
            this.statusStrip1.Location = new System.Drawing.Point(0, 538);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(956, 22);
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
            this.numScansNumericUpDown.Location = new System.Drawing.Point(556, 456);
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
            this.label3.Location = new System.Drawing.Point(556, 437);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(81, 13);
            this.label3.TabIndex = 10;
            this.label3.Text = "Num Exposures";
            // 
            // integrationNumericUpDown
            // 
            this.integrationNumericUpDown.Location = new System.Drawing.Point(658, 456);
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
            this.label4.Location = new System.Drawing.Point(658, 437);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(97, 13);
            this.label4.TabIndex = 12;
            this.label4.Text = "Integration Time (s)";
            // 
            // acquireButton
            // 
            this.acquireButton.Location = new System.Drawing.Point(556, 489);
            this.acquireButton.Name = "acquireButton";
            this.acquireButton.Size = new System.Drawing.Size(75, 23);
            this.acquireButton.TabIndex = 13;
            this.acquireButton.Text = "Acquire";
            this.acquireButton.UseVisualStyleBackColor = true;
            this.acquireButton.Click += new System.EventHandler(this.acquireButton_Click);
            // 
            // stopButton
            // 
            this.stopButton.Location = new System.Drawing.Point(658, 489);
            this.stopButton.Name = "stopButton";
            this.stopButton.Size = new System.Drawing.Size(75, 23);
            this.stopButton.TabIndex = 14;
            this.stopButton.Text = "Stop";
            this.stopButton.UseVisualStyleBackColor = true;
            this.stopButton.Click += new System.EventHandler(this.stopButton_Click);
            // 
            // graphControl1
            // 
            this.graphControl1.AutoScale = true;
            this.graphControl1.Location = new System.Drawing.Point(304, 39);
            this.graphControl1.Name = "graphControl1";
            this.graphControl1.Size = new System.Drawing.Size(622, 332);
            this.graphControl1.TabIndex = 15;
            this.graphControl1.XLim = new double[] {
        -10D,
        10D};
            this.graphControl1.YLim = new double[] {
        -10D,
        10D};
            // 
            // exposureUnitComboBox
            // 
            this.exposureUnitComboBox.FormattingEnabled = true;
            this.exposureUnitComboBox.Location = new System.Drawing.Point(769, 455);
            this.exposureUnitComboBox.Name = "exposureUnitComboBox";
            this.exposureUnitComboBox.Size = new System.Drawing.Size(157, 21);
            this.exposureUnitComboBox.TabIndex = 16;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(847, 436);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(73, 13);
            this.label5.TabIndex = 17;
            this.label5.Text = "Exposure Unit";
            // 
            // selectedCameraComboBox
            // 
            this.selectedCameraComboBox.FormattingEnabled = true;
            this.selectedCameraComboBox.Location = new System.Drawing.Point(556, 408);
            this.selectedCameraComboBox.Name = "selectedCameraComboBox";
            this.selectedCameraComboBox.Size = new System.Drawing.Size(120, 21);
            this.selectedCameraComboBox.TabIndex = 18;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(556, 389);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(88, 13);
            this.label6.TabIndex = 19;
            this.label6.Text = "Selected Camera";
            // 
            // ilNumericsControl1
            // 
            this.ilNumericsControl1.Location = new System.Drawing.Point(15, 331);
            this.ilNumericsControl1.Name = "ilNumericsControl1";
            this.ilNumericsControl1.Size = new System.Drawing.Size(283, 160);
            this.ilNumericsControl1.TabIndex = 20;
            // 
            // BelugaMainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(956, 560);
            this.Controls.Add(this.ilNumericsControl1);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.selectedCameraComboBox);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.exposureUnitComboBox);
            this.Controls.Add(this.graphControl1);
            this.Controls.Add(this.stopButton);
            this.Controls.Add(this.acquireButton);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.integrationNumericUpDown);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.numScansNumericUpDown);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.listView1);
            this.Controls.Add(this.startCapture);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.videoDeviceComboBox);
            this.Controls.Add(this.menuStrip1);
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
        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.NumericUpDown numScansNumericUpDown;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.NumericUpDown integrationNumericUpDown;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button acquireButton;
        private System.Windows.Forms.Button stopButton;
        private GraphControl.GraphControl graphControl1;
        private System.Windows.Forms.ComboBox exposureUnitComboBox;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox selectedCameraComboBox;
        private System.Windows.Forms.Label label6;
        private TwoDGraphControl ilNumericsControl1;
    }
}

