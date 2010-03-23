namespace Lab.FileIO.Test
{
    partial class TestForm
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
            this.button1 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.testFileNameTextBox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.real1DVarNameTextBox = new System.Windows.Forms.TextBox();
            this.complex1DVarNameTextBox = new System.Windows.Forms.TextBox();
            this.real2DVasNameTextBox = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.complex2DVarNameTextBox = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(12, 206);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(147, 23);
            this.button1.TabIndex = 0;
            this.button1.Text = "Write Test .Mat File";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 36);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(84, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Test File Name: ";
            // 
            // testFileNameTextBox
            // 
            this.testFileNameTextBox.Location = new System.Drawing.Point(102, 33);
            this.testFileNameTextBox.Name = "testFileNameTextBox";
            this.testFileNameTextBox.Size = new System.Drawing.Size(100, 20);
            this.testFileNameTextBox.TabIndex = 2;
            this.testFileNameTextBox.Text = "Test.mat";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 74);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(0, 13);
            this.label2.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(18, 90);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(99, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Real 1D Var Name:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(18, 113);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(117, 13);
            this.label4.TabIndex = 5;
            this.label4.Text = "Complex 1D Var Name:";
            // 
            // real1DVarNameTextBox
            // 
            this.real1DVarNameTextBox.Location = new System.Drawing.Point(141, 83);
            this.real1DVarNameTextBox.Name = "real1DVarNameTextBox";
            this.real1DVarNameTextBox.Size = new System.Drawing.Size(100, 20);
            this.real1DVarNameTextBox.TabIndex = 6;
            this.real1DVarNameTextBox.Text = "Real1D";
            // 
            // complex1DVarNameTextBox
            // 
            this.complex1DVarNameTextBox.Location = new System.Drawing.Point(141, 106);
            this.complex1DVarNameTextBox.Name = "complex1DVarNameTextBox";
            this.complex1DVarNameTextBox.Size = new System.Drawing.Size(100, 20);
            this.complex1DVarNameTextBox.TabIndex = 7;
            this.complex1DVarNameTextBox.Text = "Complex1D";
            // 
            // real2DVasNameTextBox
            // 
            this.real2DVasNameTextBox.Location = new System.Drawing.Point(141, 132);
            this.real2DVasNameTextBox.Name = "real2DVasNameTextBox";
            this.real2DVasNameTextBox.Size = new System.Drawing.Size(100, 20);
            this.real2DVasNameTextBox.TabIndex = 9;
            this.real2DVasNameTextBox.Text = "Real2D";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(18, 135);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(99, 13);
            this.label5.TabIndex = 8;
            this.label5.Text = "Real 2D Var Name:";
            // 
            // complex2DVarNameTextBox
            // 
            this.complex2DVarNameTextBox.Location = new System.Drawing.Point(141, 158);
            this.complex2DVarNameTextBox.Name = "complex2DVarNameTextBox";
            this.complex2DVarNameTextBox.Size = new System.Drawing.Size(100, 20);
            this.complex2DVarNameTextBox.TabIndex = 11;
            this.complex2DVarNameTextBox.Text = "Complex2D";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(18, 161);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(117, 13);
            this.label6.TabIndex = 10;
            this.label6.Text = "Complex 2D Var Name:";
            // 
            // TestForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(292, 250);
            this.Controls.Add(this.complex2DVarNameTextBox);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.real2DVasNameTextBox);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.complex1DVarNameTextBox);
            this.Controls.Add(this.real1DVarNameTextBox);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.testFileNameTextBox);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button1);
            this.Name = "TestForm";
            this.Text = "Test Form";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox testFileNameTextBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox real1DVarNameTextBox;
        private System.Windows.Forms.TextBox complex1DVarNameTextBox;
        private System.Windows.Forms.TextBox real2DVasNameTextBox;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox complex2DVarNameTextBox;
        private System.Windows.Forms.Label label6;
    }
}

