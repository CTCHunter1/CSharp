namespace Lab.Programs.Bullet
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
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.optionsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.motorOptionsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.scanOptionsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dAQOptionsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.controlToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.startToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.zScanToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.stopToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.viewToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cuttingProfileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.zAxisPofileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cuttingAxisGraph = new GraphControl.GraphControl();
            this.waistListView = new System.Windows.Forms.ListView();
            this.saveZAxisScanToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // statusStrip1
            // 
            this.statusStrip1.Location = new System.Drawing.Point(0, 588);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(792, 22);
            this.statusStrip1.TabIndex = 2;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.optionsToolStripMenuItem,
            this.controlToolStripMenuItem,
            this.viewToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(792, 24);
            this.menuStrip1.TabIndex = 3;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.saveToolStripMenuItem,
            this.saveZAxisScanToolStripMenuItem,
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(35, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // saveToolStripMenuItem
            // 
            this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            this.saveToolStripMenuItem.Size = new System.Drawing.Size(167, 22);
            this.saveToolStripMenuItem.Text = "Save Single Scan";
            this.saveToolStripMenuItem.Click += new System.EventHandler(this.saveToolStripMenuItem_Click);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(167, 22);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // optionsToolStripMenuItem
            // 
            this.optionsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.motorOptionsToolStripMenuItem,
            this.scanOptionsToolStripMenuItem,
            this.dAQOptionsToolStripMenuItem});
            this.optionsToolStripMenuItem.Name = "optionsToolStripMenuItem";
            this.optionsToolStripMenuItem.Size = new System.Drawing.Size(56, 20);
            this.optionsToolStripMenuItem.Text = "Options";
            // 
            // motorOptionsToolStripMenuItem
            // 
            this.motorOptionsToolStripMenuItem.Name = "motorOptionsToolStripMenuItem";
            this.motorOptionsToolStripMenuItem.Size = new System.Drawing.Size(153, 22);
            this.motorOptionsToolStripMenuItem.Text = "Motor Options";
            this.motorOptionsToolStripMenuItem.Click += new System.EventHandler(this.motorOptionsToolStripMenuItem_Click);
            // 
            // scanOptionsToolStripMenuItem
            // 
            this.scanOptionsToolStripMenuItem.Name = "scanOptionsToolStripMenuItem";
            this.scanOptionsToolStripMenuItem.Size = new System.Drawing.Size(153, 22);
            this.scanOptionsToolStripMenuItem.Text = "Scan Options";
            this.scanOptionsToolStripMenuItem.Click += new System.EventHandler(this.scanOptionsToolStripMenuItem_Click);
            // 
            // dAQOptionsToolStripMenuItem
            // 
            this.dAQOptionsToolStripMenuItem.Name = "dAQOptionsToolStripMenuItem";
            this.dAQOptionsToolStripMenuItem.Size = new System.Drawing.Size(153, 22);
            this.dAQOptionsToolStripMenuItem.Text = "DAQ Options";
            this.dAQOptionsToolStripMenuItem.Click += new System.EventHandler(this.dAQOptionsToolStripMenuItem_Click);
            // 
            // controlToolStripMenuItem
            // 
            this.controlToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.startToolStripMenuItem,
            this.zScanToolStripMenuItem,
            this.stopToolStripMenuItem});
            this.controlToolStripMenuItem.Name = "controlToolStripMenuItem";
            this.controlToolStripMenuItem.Size = new System.Drawing.Size(54, 20);
            this.controlToolStripMenuItem.Text = "Control";
            // 
            // startToolStripMenuItem
            // 
            this.startToolStripMenuItem.Name = "startToolStripMenuItem";
            this.startToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Space)));
            this.startToolStripMenuItem.Size = new System.Drawing.Size(200, 22);
            this.startToolStripMenuItem.Text = "Single Scan";
            this.startToolStripMenuItem.Click += new System.EventHandler(this.singleScanToolStripMenuItem_Click);
            // 
            // zScanToolStripMenuItem
            // 
            this.zScanToolStripMenuItem.Name = "zScanToolStripMenuItem";
            this.zScanToolStripMenuItem.Size = new System.Drawing.Size(200, 22);
            this.zScanToolStripMenuItem.Text = "Z Scan";
            this.zScanToolStripMenuItem.Click += new System.EventHandler(this.zScanToolStripMenuItem_Click);
            // 
            // stopToolStripMenuItem
            // 
            this.stopToolStripMenuItem.Name = "stopToolStripMenuItem";
            this.stopToolStripMenuItem.Size = new System.Drawing.Size(200, 22);
            this.stopToolStripMenuItem.Text = "Stop";
            this.stopToolStripMenuItem.Click += new System.EventHandler(this.stopToolStripMenuItem_Click);
            // 
            // viewToolStripMenuItem
            // 
            this.viewToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cuttingProfileToolStripMenuItem,
            this.zAxisPofileToolStripMenuItem});
            this.viewToolStripMenuItem.Name = "viewToolStripMenuItem";
            this.viewToolStripMenuItem.Size = new System.Drawing.Size(41, 20);
            this.viewToolStripMenuItem.Text = "View";
            // 
            // cuttingProfileToolStripMenuItem
            // 
            this.cuttingProfileToolStripMenuItem.Name = "cuttingProfileToolStripMenuItem";
            this.cuttingProfileToolStripMenuItem.Size = new System.Drawing.Size(153, 22);
            this.cuttingProfileToolStripMenuItem.Text = "Cutting Profile";
            this.cuttingProfileToolStripMenuItem.Click += new System.EventHandler(this.cuttingProfileToolStripMenuItem_Click);
            // 
            // zAxisPofileToolStripMenuItem
            // 
            this.zAxisPofileToolStripMenuItem.Name = "zAxisPofileToolStripMenuItem";
            this.zAxisPofileToolStripMenuItem.Size = new System.Drawing.Size(153, 22);
            this.zAxisPofileToolStripMenuItem.Text = "Z Axis Pofile";
            this.zAxisPofileToolStripMenuItem.Click += new System.EventHandler(this.zAxisPofileToolStripMenuItem_Click);
            // 
            // cuttingAxisGraph
            // 
            this.cuttingAxisGraph.AutoScale = true;
            this.cuttingAxisGraph.Location = new System.Drawing.Point(0, 27);
            this.cuttingAxisGraph.Name = "cuttingAxisGraph";
            this.cuttingAxisGraph.Size = new System.Drawing.Size(767, 438);
            this.cuttingAxisGraph.TabIndex = 0;
            this.cuttingAxisGraph.XLim = new float[] {
        -10F,
        10F};
            this.cuttingAxisGraph.YLim = new float[] {
        -10F,
        10F};
            // 
            // waistListView
            // 
            this.waistListView.FullRowSelect = true;
            this.waistListView.GridLines = true;
            this.waistListView.Location = new System.Drawing.Point(32, 481);
            this.waistListView.Name = "waistListView";
            this.waistListView.Size = new System.Drawing.Size(735, 79);
            this.waistListView.TabIndex = 4;
            this.waistListView.UseCompatibleStateImageBehavior = false;
            this.waistListView.View = System.Windows.Forms.View.Details;
            this.waistListView.Resize += new System.EventHandler(this.waistListView_Resize);
            // 
            // saveZAxisScanToolStripMenuItem
            // 
            this.saveZAxisScanToolStripMenuItem.Name = "saveZAxisScanToolStripMenuItem";
            this.saveZAxisScanToolStripMenuItem.Size = new System.Drawing.Size(167, 22);
            this.saveZAxisScanToolStripMenuItem.Text = "Save Z Axis Scan";
            this.saveZAxisScanToolStripMenuItem.Click += new System.EventHandler(this.saveZAxisScanToolStripMenuItem_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(792, 610);
            this.Controls.Add(this.waistListView);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.cuttingAxisGraph);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "MainForm";
            this.Text = "Bullet";
            this.Resize += new System.EventHandler(this.MainForm_Resize);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private GraphControl.GraphControl cuttingAxisGraph;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem optionsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem motorOptionsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem scanOptionsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem dAQOptionsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem controlToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem stopToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem zScanToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem startToolStripMenuItem;
        private System.Windows.Forms.ListView waistListView;
        private System.Windows.Forms.ToolStripMenuItem viewToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem cuttingProfileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem zAxisPofileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveZAxisScanToolStripMenuItem;
    }
}

