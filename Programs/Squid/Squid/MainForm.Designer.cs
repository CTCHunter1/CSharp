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
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.controlToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.chopperMotorToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.nI6251ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.controlToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.startContinousToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.stopContinousScanToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.stopButton = new System.Windows.Forms.Button();
            this.takeTraceButton = new System.Windows.Forms.Button();
            this.frequencyAxisGraphControl = new GraphControl.GraphControl();
            this.timeAxisGraphControl = new GraphControl.GraphControl();
            this.squidOptionsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
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
            this.menuStrip1.Size = new System.Drawing.Size(632, 24);
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
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // controlToolStripMenuItem
            // 
            this.controlToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.chopperMotorToolStripMenuItem,
            this.nI6251ToolStripMenuItem,
            this.squidOptionsToolStripMenuItem});
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
            // controlToolStripMenuItem1
            // 
            this.controlToolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.startContinousToolStripMenuItem,
            this.stopContinousScanToolStripMenuItem});
            this.controlToolStripMenuItem1.Name = "controlToolStripMenuItem1";
            this.controlToolStripMenuItem1.Size = new System.Drawing.Size(54, 20);
            this.controlToolStripMenuItem1.Text = "Control";
            // 
            // startContinousToolStripMenuItem
            // 
            this.startContinousToolStripMenuItem.Name = "startContinousToolStripMenuItem";
            this.startContinousToolStripMenuItem.Size = new System.Drawing.Size(186, 22);
            this.startContinousToolStripMenuItem.Text = "Start Continous Scan";
            this.startContinousToolStripMenuItem.Click += new System.EventHandler(this.starContinousToolStripMenuItem_Click);
            // 
            // stopContinousScanToolStripMenuItem
            // 
            this.stopContinousScanToolStripMenuItem.Name = "stopContinousScanToolStripMenuItem";
            this.stopContinousScanToolStripMenuItem.Size = new System.Drawing.Size(186, 22);
            this.stopContinousScanToolStripMenuItem.Text = "Stop Continous Scan";
            this.stopContinousScanToolStripMenuItem.Click += new System.EventHandler(this.stopContinousScanToolStripMenuItem_Click);
            // 
            // stopButton
            // 
            this.stopButton.Location = new System.Drawing.Point(12, 548);
            this.stopButton.Name = "stopButton";
            this.stopButton.Size = new System.Drawing.Size(75, 23);
            this.stopButton.TabIndex = 1;
            this.stopButton.Text = "&Stop";
            this.stopButton.UseVisualStyleBackColor = true;
            this.stopButton.Click += new System.EventHandler(this.stopButton_Click);
            // 
            // takeTraceButton
            // 
            this.takeTraceButton.Location = new System.Drawing.Point(516, 545);
            this.takeTraceButton.Name = "takeTraceButton";
            this.takeTraceButton.Size = new System.Drawing.Size(75, 23);
            this.takeTraceButton.TabIndex = 2;
            this.takeTraceButton.Text = "Take Trace";
            this.takeTraceButton.UseVisualStyleBackColor = true;
            this.takeTraceButton.Click += new System.EventHandler(this.takeTraceButton_Click);
            // 
            // frequencyAxisGraphControl
            // 
            this.frequencyAxisGraphControl.AutoScale = true;
            this.frequencyAxisGraphControl.Location = new System.Drawing.Point(12, 270);
            this.frequencyAxisGraphControl.Name = "frequencyAxisGraphControl";
            this.frequencyAxisGraphControl.Size = new System.Drawing.Size(561, 250);
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
            this.timeAxisGraphControl.Location = new System.Drawing.Point(12, 27);
            this.timeAxisGraphControl.Name = "timeAxisGraphControl";
            this.timeAxisGraphControl.Size = new System.Drawing.Size(561, 237);
            this.timeAxisGraphControl.TabIndex = 3;
            this.timeAxisGraphControl.XLim = new double[] {
        -10,
        10};
            this.timeAxisGraphControl.YLim = new double[] {
        -10,
        10};
            // 
            // squidOptionsToolStripMenuItem
            // 
            this.squidOptionsToolStripMenuItem.Name = "squidOptionsToolStripMenuItem";
            this.squidOptionsToolStripMenuItem.Size = new System.Drawing.Size(157, 22);
            this.squidOptionsToolStripMenuItem.Text = "Squid Options";
            this.squidOptionsToolStripMenuItem.Click += new System.EventHandler(this.squidOptionsToolStripMenuItem_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(632, 593);
            this.Controls.Add(this.frequencyAxisGraphControl);
            this.Controls.Add(this.timeAxisGraphControl);
            this.Controls.Add(this.takeTraceButton);
            this.Controls.Add(this.stopButton);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "MainForm";
            this.Text = "Form1";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.MainForm_FormClosed);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
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
        private System.Windows.Forms.Button takeTraceButton;
        private GraphControl.GraphControl timeAxisGraphControl;
        private GraphControl.GraphControl frequencyAxisGraphControl;
        private System.Windows.Forms.ToolStripMenuItem stopContinousScanToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem squidOptionsToolStripMenuItem;

    }
}

