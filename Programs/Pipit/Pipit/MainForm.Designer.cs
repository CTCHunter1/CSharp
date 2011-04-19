namespace Pipit
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
            this.ao0numeric = new System.Windows.Forms.NumericUpDown();
            this.ao1numeric = new System.Windows.Forms.NumericUpDown();
            this.ao2numeric = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.deviceComboBox = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.initalizeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.ao0numeric)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ao1numeric)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ao2numeric)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // ao0numeric
            // 
            this.ao0numeric.DecimalPlaces = 4;
            this.ao0numeric.Increment = new decimal(new int[] {
            1,
            0,
            0,
            131072});
            this.ao0numeric.Location = new System.Drawing.Point(12, 92);
            this.ao0numeric.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.ao0numeric.Name = "ao0numeric";
            this.ao0numeric.Size = new System.Drawing.Size(93, 20);
            this.ao0numeric.TabIndex = 0;
            this.ao0numeric.Value = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.ao0numeric.ValueChanged += new System.EventHandler(this.aonumeric_ValueChanged);
            // 
            // ao1numeric
            // 
            this.ao1numeric.DecimalPlaces = 4;
            this.ao1numeric.Location = new System.Drawing.Point(12, 134);
            this.ao1numeric.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.ao1numeric.Name = "ao1numeric";
            this.ao1numeric.Size = new System.Drawing.Size(93, 20);
            this.ao1numeric.TabIndex = 1;
            this.ao1numeric.ValueChanged += new System.EventHandler(this.aonumeric_ValueChanged);
            // 
            // ao2numeric
            // 
            this.ao2numeric.DecimalPlaces = 4;
            this.ao2numeric.Location = new System.Drawing.Point(12, 179);
            this.ao2numeric.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.ao2numeric.Name = "ao2numeric";
            this.ao2numeric.Size = new System.Drawing.Size(93, 20);
            this.ao2numeric.TabIndex = 2;
            this.ao2numeric.ValueChanged += new System.EventHandler(this.aonumeric_ValueChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 76);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(69, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Analog Out 0";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 118);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(69, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Analog Out 1";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 163);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(69, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Analog Out 2";
            // 
            // deviceComboBox
            // 
            this.deviceComboBox.FormattingEnabled = true;
            this.deviceComboBox.Location = new System.Drawing.Point(12, 52);
            this.deviceComboBox.Name = "deviceComboBox";
            this.deviceComboBox.Size = new System.Drawing.Size(121, 21);
            this.deviceComboBox.TabIndex = 7;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 36);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(41, 13);
            this.label4.TabIndex = 8;
            this.label4.Text = "Device";
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.initalizeToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(157, 24);
            this.menuStrip1.TabIndex = 9;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // initalizeToolStripMenuItem
            // 
            this.initalizeToolStripMenuItem.Name = "initalizeToolStripMenuItem";
            this.initalizeToolStripMenuItem.Size = new System.Drawing.Size(56, 20);
            this.initalizeToolStripMenuItem.Text = "Initalize";
            this.initalizeToolStripMenuItem.Click += new System.EventHandler(this.initalizeToolStripMenuItem_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(157, 249);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.deviceComboBox);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.ao2numeric);
            this.Controls.Add(this.ao1numeric);
            this.Controls.Add(this.ao0numeric);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "MainForm";
            this.Text = "Pipit";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.ao0numeric)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ao1numeric)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ao2numeric)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.NumericUpDown ao0numeric;
        private System.Windows.Forms.NumericUpDown ao1numeric;
        private System.Windows.Forms.NumericUpDown ao2numeric;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox deviceComboBox;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem initalizeToolStripMenuItem;
    }
}

