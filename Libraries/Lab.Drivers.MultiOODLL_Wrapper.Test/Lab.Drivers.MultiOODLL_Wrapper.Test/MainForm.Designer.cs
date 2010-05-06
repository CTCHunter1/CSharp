namespace Lab.Drivers.MultiOOI_DLL.Test
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
            this.start = new System.Windows.Forms.Button();
            this.start_label = new System.Windows.Forms.Label();
            this.exit_button = new System.Windows.Forms.Button();
            this.graphControl2 = new GraphControl.GraphControl();
            this.graphControl1 = new GraphControl.GraphControl();
            this.SuspendLayout();
            // 
            // start
            // 
            this.start.Location = new System.Drawing.Point(683, 523);
            this.start.Name = "start";
            this.start.Size = new System.Drawing.Size(75, 23);
            this.start.TabIndex = 0;
            this.start.Text = "Start";
            this.start.UseVisualStyleBackColor = true;
            this.start.Click += new System.EventHandler(this.Start_Click);
            // 
            // start_label
            // 
            this.start_label.AutoSize = true;
            this.start_label.Location = new System.Drawing.Point(670, 507);
            this.start_label.Name = "start_label";
            this.start_label.Size = new System.Drawing.Size(98, 13);
            this.start_label.TabIndex = 1;
            this.start_label.Text = "Change Start to Init";
            // 
            // exit_button
            // 
            this.exit_button.Location = new System.Drawing.Point(683, 561);
            this.exit_button.Name = "exit_button";
            this.exit_button.Size = new System.Drawing.Size(75, 23);
            this.exit_button.TabIndex = 3;
            this.exit_button.Text = "E&xit";
            this.exit_button.UseVisualStyleBackColor = true;
            this.exit_button.Click += new System.EventHandler(this.exit_button_Click);
            // 
            // graphControl2
            // 
            this.graphControl2.AutoScale = true;
            this.graphControl2.Location = new System.Drawing.Point(43, 327);
            this.graphControl2.Name = "graphControl2";
            this.graphControl2.Size = new System.Drawing.Size(587, 239);
            this.graphControl2.TabIndex = 4;
            this.graphControl2.XLim = new double[] {
        -10F,
        10F};
            this.graphControl2.YLim = new double[] {
        -10F,
        10F};
            // 
            // graphControl1
            // 
            this.graphControl1.AutoScale = true;
            this.graphControl1.Location = new System.Drawing.Point(30, 29);
            this.graphControl1.Name = "graphControl1";
            this.graphControl1.Size = new System.Drawing.Size(688, 277);
            this.graphControl1.TabIndex = 2;
            this.graphControl1.XLim = new double[] {
        -10F,
        10F};
            this.graphControl1.YLim = new double[] {
        -10F,
        10F};
            // 
            // Main_Form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(786, 596);
            this.Controls.Add(this.graphControl2);
            this.Controls.Add(this.exit_button);
            this.Controls.Add(this.graphControl1);
            this.Controls.Add(this.start_label);
            this.Controls.Add(this.start);
            this.Name = "Main_Form";
            this.Text = "Blue Heron";
            this.Load += new System.EventHandler(this.Main_Form_Load);
            this.Resize += new System.EventHandler(this.Main_Form_Resize);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button start;
        private System.Windows.Forms.Label start_label;
        private GraphControl.GraphControl graphControl1;
        private System.Windows.Forms.Button exit_button;
        private GraphControl.GraphControl graphControl2;
    }
}

