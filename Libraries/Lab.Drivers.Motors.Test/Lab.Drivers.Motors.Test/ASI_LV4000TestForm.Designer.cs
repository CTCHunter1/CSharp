namespace Lab.Drivers.Motors.Test
{
    partial class ASI_LV4000TestForm
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
            this.createLV4000 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.statusTextBox = new System.Windows.Forms.TextBox();
            this.createdTextBox = new System.Windows.Forms.TextBox();
            this.getPositionButton = new System.Windows.Forms.Button();
            this.xPosNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.yPosNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.moveButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.xPosNumericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.yPosNumericUpDown)).BeginInit();
            this.SuspendLayout();
            // 
            // createLV4000
            // 
            this.createLV4000.Location = new System.Drawing.Point(22, 22);
            this.createLV4000.Name = "createLV4000";
            this.createLV4000.Size = new System.Drawing.Size(75, 23);
            this.createLV4000.TabIndex = 0;
            this.createLV4000.Text = "Create Obj";
            this.createLV4000.UseVisualStyleBackColor = true;
            this.createLV4000.Click += new System.EventHandler(this.createLV4000_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(22, 61);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 1;
            this.button1.Text = "Get Status";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // statusTextBox
            // 
            this.statusTextBox.Location = new System.Drawing.Point(125, 64);
            this.statusTextBox.Name = "statusTextBox";
            this.statusTextBox.Size = new System.Drawing.Size(87, 20);
            this.statusTextBox.TabIndex = 2;
            // 
            // createdTextBox
            // 
            this.createdTextBox.Location = new System.Drawing.Point(125, 25);
            this.createdTextBox.Name = "createdTextBox";
            this.createdTextBox.Size = new System.Drawing.Size(87, 20);
            this.createdTextBox.TabIndex = 3;
            // 
            // getPositionButton
            // 
            this.getPositionButton.Location = new System.Drawing.Point(22, 104);
            this.getPositionButton.Name = "getPositionButton";
            this.getPositionButton.Size = new System.Drawing.Size(75, 23);
            this.getPositionButton.TabIndex = 4;
            this.getPositionButton.Text = "Get Position";
            this.getPositionButton.UseVisualStyleBackColor = true;
            this.getPositionButton.Click += new System.EventHandler(this.getPositionButton_Click);
            // 
            // xPosNumericUpDown
            // 
            this.xPosNumericUpDown.Location = new System.Drawing.Point(125, 107);
            this.xPosNumericUpDown.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.xPosNumericUpDown.Minimum = new decimal(new int[] {
            100000,
            0,
            0,
            -2147483648});
            this.xPosNumericUpDown.Name = "xPosNumericUpDown";
            this.xPosNumericUpDown.Size = new System.Drawing.Size(70, 20);
            this.xPosNumericUpDown.TabIndex = 5;
            // 
            // yPosNumericUpDown
            // 
            this.yPosNumericUpDown.Location = new System.Drawing.Point(216, 107);
            this.yPosNumericUpDown.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.yPosNumericUpDown.Minimum = new decimal(new int[] {
            100000,
            0,
            0,
            -2147483648});
            this.yPosNumericUpDown.Name = "yPosNumericUpDown";
            this.yPosNumericUpDown.Size = new System.Drawing.Size(70, 20);
            this.yPosNumericUpDown.TabIndex = 6;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(122, 91);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 7;
            this.label1.Text = "X Pos";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(213, 91);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 13);
            this.label2.TabIndex = 8;
            this.label2.Text = "Y Pos";
            // 
            // moveButton
            // 
            this.moveButton.Location = new System.Drawing.Point(22, 148);
            this.moveButton.Name = "moveButton";
            this.moveButton.Size = new System.Drawing.Size(75, 23);
            this.moveButton.TabIndex = 9;
            this.moveButton.Text = "Move";
            this.moveButton.UseVisualStyleBackColor = true;
            this.moveButton.Click += new System.EventHandler(this.moveButton_Click);
            // 
            // ASI_LV4000TestForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(354, 561);
            this.Controls.Add(this.moveButton);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.yPosNumericUpDown);
            this.Controls.Add(this.xPosNumericUpDown);
            this.Controls.Add(this.getPositionButton);
            this.Controls.Add(this.createdTextBox);
            this.Controls.Add(this.statusTextBox);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.createLV4000);
            this.Name = "ASI_LV4000TestForm";
            this.Text = "ASILV4000TestForm";
            ((System.ComponentModel.ISupportInitialize)(this.xPosNumericUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.yPosNumericUpDown)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button createLV4000;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox statusTextBox;
        private System.Windows.Forms.TextBox createdTextBox;
        private System.Windows.Forms.Button getPositionButton;
        private System.Windows.Forms.NumericUpDown xPosNumericUpDown;
        private System.Windows.Forms.NumericUpDown yPosNumericUpDown;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button moveButton;
    }
}