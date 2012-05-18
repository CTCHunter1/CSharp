namespace Beluga
{
    partial class VideoPreviewForm
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(VideoPreviewForm));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.captureAFrameToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.configToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.stopToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.setLaserPosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.previewPanel = new System.Windows.Forms.Panel();
            this.mouseHookComponent1 = new Microsoft.Win32.MouseHookComponent(this.components);
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.captureAFrameToolStripMenuItem,
            this.configToolStripMenuItem,
            this.stopToolStripMenuItem,
            this.setLaserPosToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(374, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // captureAFrameToolStripMenuItem
            // 
            this.captureAFrameToolStripMenuItem.Name = "captureAFrameToolStripMenuItem";
            this.captureAFrameToolStripMenuItem.Size = new System.Drawing.Size(100, 20);
            this.captureAFrameToolStripMenuItem.Text = "Capture a Frame";
            this.captureAFrameToolStripMenuItem.Click += new System.EventHandler(this.captureAFrameToolStripMenuItem_Click);
            // 
            // configToolStripMenuItem
            // 
            this.configToolStripMenuItem.Name = "configToolStripMenuItem";
            this.configToolStripMenuItem.Size = new System.Drawing.Size(50, 20);
            this.configToolStripMenuItem.Text = "Config";
            this.configToolStripMenuItem.Click += new System.EventHandler(this.configToolStripMenuItem_Click);
            // 
            // stopToolStripMenuItem
            // 
            this.stopToolStripMenuItem.Name = "stopToolStripMenuItem";
            this.stopToolStripMenuItem.Size = new System.Drawing.Size(41, 20);
            this.stopToolStripMenuItem.Text = "Stop";
            // 
            // setLaserPosToolStripMenuItem
            // 
            this.setLaserPosToolStripMenuItem.Name = "setLaserPosToolStripMenuItem";
            this.setLaserPosToolStripMenuItem.Size = new System.Drawing.Size(104, 20);
            this.setLaserPosToolStripMenuItem.Text = "Set Laser Position";
            this.setLaserPosToolStripMenuItem.Click += new System.EventHandler(this.setLaserPosToolStripMenuItem_Click);
            // 
            // previewPanel
            // 
            this.previewPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.previewPanel.Location = new System.Drawing.Point(0, 24);
            this.previewPanel.Name = "previewPanel";
            this.previewPanel.Size = new System.Drawing.Size(374, 335);
            this.previewPanel.TabIndex = 1;
            this.previewPanel.MouseClick += new System.Windows.Forms.MouseEventHandler(this.previewPanel_MouseClick);
            this.previewPanel.Resize += new System.EventHandler(this.previewPanel_Resize);
            
            // 
            // VideoPreviewForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(374, 359);
            this.Controls.Add(this.previewPanel);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "VideoPreviewForm";
            this.Text = "VideoPreviewWindow";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.VideoPreviewForm_FormClosing);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.VideoPreviewForm_FormClosed);
            this.Shown += new System.EventHandler(this.VideoPreviewForm_Shown);
            this.MouseClick += new System.Windows.Forms.MouseEventHandler(this.VideoPreviewForm_MouseClick);
            this.Move += new System.EventHandler(this.VideoPreviewForm_Move);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem captureAFrameToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem stopToolStripMenuItem;
        private System.Windows.Forms.Panel previewPanel;
        private System.Windows.Forms.ToolStripMenuItem configToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem setLaserPosToolStripMenuItem;
        private Microsoft.Win32.MouseHookComponent mouseHookComponent1;
    }
}