namespace Beluga
{
    partial class TransparentForm
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
            this.mouseHookComponent1 = new Microsoft.Win32.MouseHookComponent(this.components);
            this.SuspendLayout();
            // 
            // mouseHookComponent1
            // 
            this.mouseHookComponent1.MouseDoubleClick += new Microsoft.Win32.MouseHookEventHandler(this.mouseHookComponent1_MouseDoubleClick);
            // 
            // TransparentForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(292, 273);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "TransparentForm";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "TransparentForm";
            this.TransparencyKey = System.Drawing.SystemColors.Control;
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.TransparentForm_Paint);
            this.MouseClick += new System.Windows.Forms.MouseEventHandler(this.TransparentForm_MouseClick);
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Win32.MouseHookComponent mouseHookComponent1;
    }
}