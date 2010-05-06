namespace Lab.Math.Test
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
            this.loadDataButton = new System.Windows.Forms.Button();
            this.graphControl = new GraphControl.GraphControl();
            this.fitButton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.Alabel = new System.Windows.Forms.Label();
            this.Blabel = new System.Windows.Forms.Label();
            this.Clabel = new System.Windows.Forms.Label();
            this.Dlabel = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // loadDataButton
            // 
            this.loadDataButton.Location = new System.Drawing.Point(6, 21);
            this.loadDataButton.Name = "loadDataButton";
            this.loadDataButton.Size = new System.Drawing.Size(75, 23);
            this.loadDataButton.TabIndex = 0;
            this.loadDataButton.Text = "Load Data Button";
            this.loadDataButton.UseVisualStyleBackColor = true;
            this.loadDataButton.Click += new System.EventHandler(this.loadDataButton_Click);
            // 
            // graphControl
            // 
            this.graphControl.AutoScale = true;
            this.graphControl.Location = new System.Drawing.Point(365, 12);
            this.graphControl.Name = "graphControl";
            this.graphControl.Size = new System.Drawing.Size(422, 425);
            this.graphControl.TabIndex = 1;
            this.graphControl.XLim = new double[] {
        -10F,
        10F};
            this.graphControl.YLim = new double[] {
        -10F,
        10F};
            // 
            // fitButton
            // 
            this.fitButton.Location = new System.Drawing.Point(6, 58);
            this.fitButton.Name = "fitButton";
            this.fitButton.Size = new System.Drawing.Size(75, 23);
            this.fitButton.TabIndex = 2;
            this.fitButton.Text = "Fit";
            this.fitButton.UseVisualStyleBackColor = true;
            this.fitButton.Click += new System.EventHandler(this.fitButton_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(101, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(54, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Constants";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(101, 43);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(17, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "A:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(101, 65);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(17, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "B:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(101, 87);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(17, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "C:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(100, 109);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(18, 13);
            this.label5.TabIndex = 7;
            this.label5.Text = "D:";
            // 
            // Alabel
            // 
            this.Alabel.AutoSize = true;
            this.Alabel.Location = new System.Drawing.Point(123, 43);
            this.Alabel.Name = "Alabel";
            this.Alabel.Size = new System.Drawing.Size(13, 13);
            this.Alabel.TabIndex = 8;
            this.Alabel.Text = "0";
            // 
            // Blabel
            // 
            this.Blabel.AutoSize = true;
            this.Blabel.Location = new System.Drawing.Point(123, 65);
            this.Blabel.Name = "Blabel";
            this.Blabel.Size = new System.Drawing.Size(13, 13);
            this.Blabel.TabIndex = 9;
            this.Blabel.Text = "0";
            // 
            // Clabel
            // 
            this.Clabel.AutoSize = true;
            this.Clabel.Location = new System.Drawing.Point(123, 88);
            this.Clabel.Name = "Clabel";
            this.Clabel.Size = new System.Drawing.Size(13, 13);
            this.Clabel.TabIndex = 10;
            this.Clabel.Text = "0";
            // 
            // Dlabel
            // 
            this.Dlabel.AutoSize = true;
            this.Dlabel.Location = new System.Drawing.Point(123, 110);
            this.Dlabel.Name = "Dlabel";
            this.Dlabel.Size = new System.Drawing.Size(13, 13);
            this.Dlabel.TabIndex = 11;
            this.Dlabel.Text = "0";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.fitButton);
            this.groupBox1.Controls.Add(this.Dlabel);
            this.groupBox1.Controls.Add(this.loadDataButton);
            this.groupBox1.Controls.Add(this.Clabel);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.Blabel);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.Alabel);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Location = new System.Drawing.Point(12, 29);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(273, 227);
            this.groupBox1.TabIndex = 12;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "ERF Fit";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(799, 459);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.graphControl);
            this.Name = "MainForm";
            this.Text = "Lat.Math.Test";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button loadDataButton;
        private GraphControl.GraphControl graphControl;
        private System.Windows.Forms.Button fitButton;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label Alabel;
        private System.Windows.Forms.Label Blabel;
        private System.Windows.Forms.Label Clabel;
        private System.Windows.Forms.Label Dlabel;
        private System.Windows.Forms.GroupBox groupBox1;
    }
}

