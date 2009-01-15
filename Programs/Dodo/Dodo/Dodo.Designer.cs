namespace Dodo
{
    partial class Dodo
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
            this.aquire_btn = new System.Windows.Forms.Button();
            this.graphControl_time = new GraphControl.GraphControl();
            this.graphControl_freq = new GraphControl.GraphControl();
            this.SuspendLayout();
            // 
            // aquire_btn
            // 
            this.aquire_btn.Location = new System.Drawing.Point(765, 546);
            this.aquire_btn.Name = "aquire_btn";
            this.aquire_btn.Size = new System.Drawing.Size(75, 23);
            this.aquire_btn.TabIndex = 0;
            this.aquire_btn.Text = "Acquire";
            this.aquire_btn.UseVisualStyleBackColor = true;
            this.aquire_btn.Click += new System.EventHandler(this.aquire_btn_Click);
            // 
            // graphControl_time
            // 
            this.graphControl_time.AutoScale = true;
            this.graphControl_time.Location = new System.Drawing.Point(69, 12);
            this.graphControl_time.Name = "graphControl_time";
            this.graphControl_time.Size = new System.Drawing.Size(686, 224);
            this.graphControl_time.TabIndex = 1;
            this.graphControl_time.XLim = new float[] {
        -10F,
        10F};
            this.graphControl_time.YLim = new float[] {
        -10F,
        10F};
            // 
            // graphControl_freq
            // 
            this.graphControl_freq.AutoScale = true;
            this.graphControl_freq.Location = new System.Drawing.Point(69, 261);
            this.graphControl_freq.Name = "graphControl_freq";
            this.graphControl_freq.Size = new System.Drawing.Size(686, 225);
            this.graphControl_freq.TabIndex = 2;
            this.graphControl_freq.XLim = new float[] {
        -10F,
        10F};
            this.graphControl_freq.YLim = new float[] {
        -10F,
        10F};
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(863, 581);
            this.Controls.Add(this.graphControl_freq);
            this.Controls.Add(this.graphControl_time);
            this.Controls.Add(this.aquire_btn);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button aquire_btn;
        private GraphControl.GraphControl graphControl_time;
        private GraphControl.GraphControl graphControl_freq;
    }
}

