namespace Lab.Programs.Hawk
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSaveTrace = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSaveSweep = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveSingleScanToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.gPIPOptionsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripArroyoOptions = new System.Windows.Forms.ToolStripMenuItem();
            this.arroyoSweepOptionsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.motorScanOptionsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.motorOptionsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.controlToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.singleScanToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.graphControl1 = new GraphControl.GraphControl();
            this.take_trace_button = new System.Windows.Forms.Button();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.current_sweep_button = new System.Windows.Forms.Button();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripProgressBar = new System.Windows.Forms.ToolStripProgressBar();
            this.menuStrip1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.editToolStripMenuItem,
            this.controlToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(552, 24);
            this.menuStrip1.TabIndex = 3;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripSaveTrace,
            this.toolStripSaveSweep,
            this.saveSingleScanToolStripMenuItem,
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(35, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // toolStripSaveTrace
            // 
            this.toolStripSaveTrace.Name = "toolStripSaveTrace";
            this.toolStripSaveTrace.Size = new System.Drawing.Size(184, 22);
            this.toolStripSaveTrace.Text = "Save Trace";
            this.toolStripSaveTrace.Click += new System.EventHandler(this.toolStripSaveTrace_Click);
            // 
            // toolStripSaveSweep
            // 
            this.toolStripSaveSweep.Name = "toolStripSaveSweep";
            this.toolStripSaveSweep.Size = new System.Drawing.Size(184, 22);
            this.toolStripSaveSweep.Text = "Save Current Sweep";
            this.toolStripSaveSweep.Click += new System.EventHandler(this.toolStripSaveSweep_Click);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(184, 22);
            this.exitToolStripMenuItem.Text = "E&xit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // saveSingleScanToolStripMenuItem
            // 
            this.saveSingleScanToolStripMenuItem.Name = "saveSingleScanToolStripMenuItem";
            this.saveSingleScanToolStripMenuItem.Size = new System.Drawing.Size(184, 22);
            this.saveSingleScanToolStripMenuItem.Text = "Save Single Scan";
            this.saveSingleScanToolStripMenuItem.Click += new System.EventHandler(this.saveSingleScanToolStripMenuItem_Click);
            // 
            // editToolStripMenuItem
            // 
            this.editToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.gPIPOptionsToolStripMenuItem,
            this.toolStripArroyoOptions,
            this.arroyoSweepOptionsToolStripMenuItem,
            this.motorScanOptionsToolStripMenuItem,
            this.motorOptionsToolStripMenuItem});
            this.editToolStripMenuItem.Name = "editToolStripMenuItem";
            this.editToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.editToolStripMenuItem.Text = "Edit";
            // 
            // gPIPOptionsToolStripMenuItem
            // 
            this.gPIPOptionsToolStripMenuItem.Name = "gPIPOptionsToolStripMenuItem";
            this.gPIPOptionsToolStripMenuItem.Size = new System.Drawing.Size(197, 22);
            this.gPIPOptionsToolStripMenuItem.Text = "GPIP Options";
            this.gPIPOptionsToolStripMenuItem.Click += new System.EventHandler(this.gPIPOptionsToolStripMenuItem_Click);
            // 
            // toolStripArroyoOptions
            // 
            this.toolStripArroyoOptions.Name = "toolStripArroyoOptions";
            this.toolStripArroyoOptions.Size = new System.Drawing.Size(197, 22);
            this.toolStripArroyoOptions.Text = "Arroyo Options";
            this.toolStripArroyoOptions.Click += new System.EventHandler(this.toolStripArroyoOptions_Click);
            // 
            // arroyoSweepOptionsToolStripMenuItem
            // 
            this.arroyoSweepOptionsToolStripMenuItem.Name = "arroyoSweepOptionsToolStripMenuItem";
            this.arroyoSweepOptionsToolStripMenuItem.Size = new System.Drawing.Size(197, 22);
            this.arroyoSweepOptionsToolStripMenuItem.Text = "Current Sweep Options";
            this.arroyoSweepOptionsToolStripMenuItem.Click += new System.EventHandler(this.arroyoSweepOptionsToolStripMenuItem_Click);
            // 
            // motorScanOptionsToolStripMenuItem
            // 
            this.motorScanOptionsToolStripMenuItem.Name = "motorScanOptionsToolStripMenuItem";
            this.motorScanOptionsToolStripMenuItem.Size = new System.Drawing.Size(197, 22);
            this.motorScanOptionsToolStripMenuItem.Text = "Motor Scan Options";
            this.motorScanOptionsToolStripMenuItem.Click += new System.EventHandler(this.motorScanOptionsToolStripMenuItem_Click);
            // 
            // motorOptionsToolStripMenuItem
            // 
            this.motorOptionsToolStripMenuItem.Name = "motorOptionsToolStripMenuItem";
            this.motorOptionsToolStripMenuItem.Size = new System.Drawing.Size(197, 22);
            this.motorOptionsToolStripMenuItem.Text = "Motor Options";
            this.motorOptionsToolStripMenuItem.Click += new System.EventHandler(this.motorOptionsToolStripMenuItem_Click);
            // 
            // controlToolStripMenuItem
            // 
            this.controlToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.singleScanToolStripMenuItem});
            this.controlToolStripMenuItem.Name = "controlToolStripMenuItem";
            this.controlToolStripMenuItem.Size = new System.Drawing.Size(54, 20);
            this.controlToolStripMenuItem.Text = "Control";
            // 
            // singleScanToolStripMenuItem
            // 
            this.singleScanToolStripMenuItem.Name = "singleScanToolStripMenuItem";
            this.singleScanToolStripMenuItem.Size = new System.Drawing.Size(139, 22);
            this.singleScanToolStripMenuItem.Text = "Single Scan";
            this.singleScanToolStripMenuItem.Click += new System.EventHandler(this.singleScanToolStripMenuItem_Click);
            // 
            // graphControl1
            // 
            this.graphControl1.AutoScale = true;
            this.graphControl1.Location = new System.Drawing.Point(12, 36);
            this.graphControl1.Name = "graphControl1";
            this.graphControl1.Size = new System.Drawing.Size(475, 374);
            this.graphControl1.TabIndex = 0;
            this.graphControl1.XLim = new double[] {
        -10,
        10};
            this.graphControl1.YLim = new double[] {
        -10,
        10};
            // 
            // take_trace_button
            // 
            this.take_trace_button.Location = new System.Drawing.Point(12, 479);
            this.take_trace_button.Name = "take_trace_button";
            this.take_trace_button.Size = new System.Drawing.Size(75, 23);
            this.take_trace_button.TabIndex = 4;
            this.take_trace_button.Text = "Take Trace";
            this.take_trace_button.UseVisualStyleBackColor = true;
            this.take_trace_button.Click += new System.EventHandler(this.take_trace_button_Click);
            // 
            // comboBox1
            // 
            this.comboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "Hz",
            "kHz",
            "MHz",
            "GHz"});
            this.comboBox1.Location = new System.Drawing.Point(355, 434);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(121, 21);
            this.comboBox1.TabIndex = 5;
            this.comboBox1.Validated += new System.EventHandler(this.comboBox1_Validated);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(352, 418);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(84, 13);
            this.label1.TabIndex = 6;
            this.label1.Text = "Frequency Units";
            // 
            // current_sweep_button
            // 
            this.current_sweep_button.Location = new System.Drawing.Point(355, 479);
            this.current_sweep_button.Name = "current_sweep_button";
            this.current_sweep_button.Size = new System.Drawing.Size(120, 23);
            this.current_sweep_button.TabIndex = 7;
            this.current_sweep_button.Text = "Take Current Sweep";
            this.current_sweep_button.UseVisualStyleBackColor = true;
            this.current_sweep_button.Click += new System.EventHandler(this.current_sweep_button_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel,
            this.toolStripProgressBar});
            this.statusStrip1.Location = new System.Drawing.Point(0, 533);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.statusStrip1.Size = new System.Drawing.Size(552, 22);
            this.statusStrip1.TabIndex = 8;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel
            // 
            this.toolStripStatusLabel.AccessibleRole = System.Windows.Forms.AccessibleRole.None;
            this.toolStripStatusLabel.Name = "toolStripStatusLabel";
            this.toolStripStatusLabel.Overflow = System.Windows.Forms.ToolStripItemOverflow.Never;
            this.toolStripStatusLabel.Size = new System.Drawing.Size(385, 17);
            this.toolStripStatusLabel.Spring = true;
            this.toolStripStatusLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // toolStripProgressBar
            // 
            this.toolStripProgressBar.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.toolStripProgressBar.Name = "toolStripProgressBar";
            this.toolStripProgressBar.Size = new System.Drawing.Size(150, 16);
            // 
            // MainForm
            // 
            this.AccessibleRole = System.Windows.Forms.AccessibleRole.None;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(552, 555);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.current_sweep_button);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.take_trace_button);
            this.Controls.Add(this.graphControl1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "MainForm";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form1_FormClosed);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private GraphControl.GraphControl graphControl1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem editToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem gPIPOptionsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.Button take_trace_button;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button current_sweep_button;
        private System.Windows.Forms.ToolStripMenuItem arroyoSweepOptionsToolStripMenuItem;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel;
        private System.Windows.Forms.ToolStripProgressBar toolStripProgressBar;
        private System.Windows.Forms.ToolStripMenuItem toolStripArroyoOptions;
        private System.Windows.Forms.ToolStripMenuItem toolStripSaveTrace;
        private System.Windows.Forms.ToolStripMenuItem toolStripSaveSweep;
        private System.Windows.Forms.ToolStripMenuItem motorScanOptionsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem motorOptionsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem controlToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem singleScanToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveSingleScanToolStripMenuItem;
    }
}

