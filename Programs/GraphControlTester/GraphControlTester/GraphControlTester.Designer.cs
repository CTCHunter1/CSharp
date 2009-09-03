namespace GraphControlTester
{
    partial class GraphControlTester
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
            this.statusTextBox = new System.Windows.Forms.TextBox();
            this.runTestsButton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.graphControl1 = new GraphControl.GraphControl();
            this.SuspendLayout();
            // 
            // statusTextBox
            // 
            this.statusTextBox.BackColor = System.Drawing.SystemColors.InfoText;
            this.statusTextBox.Font = new System.Drawing.Font("Courier New", 8F);
            this.statusTextBox.ForeColor = System.Drawing.Color.Lime;
            this.statusTextBox.Location = new System.Drawing.Point(28, 432);
            this.statusTextBox.Multiline = true;
            this.statusTextBox.Name = "statusTextBox";
            this.statusTextBox.Size = new System.Drawing.Size(434, 104);
            this.statusTextBox.TabIndex = 1;
            this.statusTextBox.Text = "Test Text";
            // 
            // runTestsButton
            // 
            this.runTestsButton.Location = new System.Drawing.Point(28, 373);
            this.runTestsButton.Name = "runTestsButton";
            this.runTestsButton.Size = new System.Drawing.Size(75, 23);
            this.runTestsButton.TabIndex = 2;
            this.runTestsButton.Text = "Run Tests";
            this.runTestsButton.UseVisualStyleBackColor = true;
            this.runTestsButton.Click += new System.EventHandler(this.button1_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(25, 416);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(37, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Status";
            // 
            // graphControl1
            // 
            this.graphControl1.AutoScale = true;
            this.graphControl1.Location = new System.Drawing.Point(28, 42);
            this.graphControl1.Name = "graphControl1";
            this.graphControl1.Size = new System.Drawing.Size(345, 296);
            this.graphControl1.TabIndex = 0;
            this.graphControl1.XLim = new float[] {
        -10F,
        10F};
            this.graphControl1.YLim = new float[] {
        -10F,
        10F};
            // 
            // GraphControlTester
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(478, 548);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.runTestsButton);
            this.Controls.Add(this.statusTextBox);
            this.Controls.Add(this.graphControl1);
            this.Name = "GraphControlTester";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private GraphControl.GraphControl graphControl1;
        private System.Windows.Forms.TextBox statusTextBox;
        private System.Windows.Forms.Button runTestsButton;
        private System.Windows.Forms.Label label1;
    }
}

