namespace Lab.Drivers.Motors.Test
{
    partial class ASILV4000AxisTestForm
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
            this.closeButton = new System.Windows.Forms.Button();
            this.exceptionTextBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.initalizeButton = new System.Windows.Forms.Button();
            this.getAxesButton = new System.Windows.Forms.Button();
            this.axisComboBox = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.clearButton = new System.Windows.Forms.Button();
            this.getPosButton = new System.Windows.Forms.Button();
            this.positionNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.moveAbsoluteButton = new System.Windows.Forms.Button();
            this.velocityNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.label4 = new System.Windows.Forms.Label();
            this.getVelocityButton = new System.Windows.Forms.Button();
            this.setVelocityButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.positionNumericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.velocityNumericUpDown)).BeginInit();
            this.SuspendLayout();
            // 
            // closeButton
            // 
            this.closeButton.Location = new System.Drawing.Point(211, 374);
            this.closeButton.Name = "closeButton";
            this.closeButton.Size = new System.Drawing.Size(75, 23);
            this.closeButton.TabIndex = 0;
            this.closeButton.Text = "Close";
            this.closeButton.UseVisualStyleBackColor = true;
            this.closeButton.Click += new System.EventHandler(this.closeButton_Click);
            // 
            // exceptionTextBox
            // 
            this.exceptionTextBox.Location = new System.Drawing.Point(12, 290);
            this.exceptionTextBox.Multiline = true;
            this.exceptionTextBox.Name = "exceptionTextBox";
            this.exceptionTextBox.Size = new System.Drawing.Size(223, 55);
            this.exceptionTextBox.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 274);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(54, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Exception";
            // 
            // initalizeButton
            // 
            this.initalizeButton.Location = new System.Drawing.Point(12, 24);
            this.initalizeButton.Name = "initalizeButton";
            this.initalizeButton.Size = new System.Drawing.Size(75, 23);
            this.initalizeButton.TabIndex = 3;
            this.initalizeButton.Text = "Initalize";
            this.initalizeButton.UseVisualStyleBackColor = true;
            this.initalizeButton.Click += new System.EventHandler(this.initalizeButton_Click);
            // 
            // getAxesButton
            // 
            this.getAxesButton.Location = new System.Drawing.Point(12, 53);
            this.getAxesButton.Name = "getAxesButton";
            this.getAxesButton.Size = new System.Drawing.Size(75, 23);
            this.getAxesButton.TabIndex = 4;
            this.getAxesButton.Text = "Get Axes";
            this.getAxesButton.UseVisualStyleBackColor = true;
            this.getAxesButton.Click += new System.EventHandler(this.getAxesButton_Click);
            // 
            // axisComboBox
            // 
            this.axisComboBox.FormattingEnabled = true;
            this.axisComboBox.Location = new System.Drawing.Point(114, 53);
            this.axisComboBox.Name = "axisComboBox";
            this.axisComboBox.Size = new System.Drawing.Size(121, 21);
            this.axisComboBox.TabIndex = 5;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(111, 37);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(26, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "Axis";
            // 
            // clearButton
            // 
            this.clearButton.Location = new System.Drawing.Point(12, 351);
            this.clearButton.Name = "clearButton";
            this.clearButton.Size = new System.Drawing.Size(101, 23);
            this.clearButton.TabIndex = 7;
            this.clearButton.Text = "Clear Exception";
            this.clearButton.UseVisualStyleBackColor = true;
            this.clearButton.Click += new System.EventHandler(this.clearButton_Click);
            // 
            // getPosButton
            // 
            this.getPosButton.Location = new System.Drawing.Point(12, 100);
            this.getPosButton.Name = "getPosButton";
            this.getPosButton.Size = new System.Drawing.Size(75, 23);
            this.getPosButton.TabIndex = 8;
            this.getPosButton.Text = "Get Position";
            this.getPosButton.UseVisualStyleBackColor = true;
            this.getPosButton.Click += new System.EventHandler(this.getPosButton_Click);
            // 
            // positionNumericUpDown
            // 
            this.positionNumericUpDown.Location = new System.Drawing.Point(114, 103);
            this.positionNumericUpDown.Maximum = new decimal(new int[] {
            200000,
            0,
            0,
            0});
            this.positionNumericUpDown.Minimum = new decimal(new int[] {
            2000000,
            0,
            0,
            -2147483648});
            this.positionNumericUpDown.Name = "positionNumericUpDown";
            this.positionNumericUpDown.Size = new System.Drawing.Size(104, 20);
            this.positionNumericUpDown.TabIndex = 9;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(111, 87);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(44, 13);
            this.label3.TabIndex = 10;
            this.label3.Text = "Position";
            // 
            // moveAbsoluteButton
            // 
            this.moveAbsoluteButton.Location = new System.Drawing.Point(12, 129);
            this.moveAbsoluteButton.Name = "moveAbsoluteButton";
            this.moveAbsoluteButton.Size = new System.Drawing.Size(75, 23);
            this.moveAbsoluteButton.TabIndex = 11;
            this.moveAbsoluteButton.Text = "Move Absolute";
            this.moveAbsoluteButton.UseVisualStyleBackColor = true;
            this.moveAbsoluteButton.Click += new System.EventHandler(this.moveAbsoluteButton_Click);
            // 
            // velocityNumericUpDown
            // 
            this.velocityNumericUpDown.DecimalPlaces = 2;
            this.velocityNumericUpDown.Location = new System.Drawing.Point(75, 177);
            this.velocityNumericUpDown.Name = "velocityNumericUpDown";
            this.velocityNumericUpDown.Size = new System.Drawing.Size(104, 20);
            this.velocityNumericUpDown.TabIndex = 12;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(72, 161);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(44, 13);
            this.label4.TabIndex = 13;
            this.label4.Text = "Velocity";
            // 
            // getVelocityButton
            // 
            this.getVelocityButton.Location = new System.Drawing.Point(12, 203);
            this.getVelocityButton.Name = "getVelocityButton";
            this.getVelocityButton.Size = new System.Drawing.Size(75, 23);
            this.getVelocityButton.TabIndex = 14;
            this.getVelocityButton.Text = "Get Velocity";
            this.getVelocityButton.UseVisualStyleBackColor = true;
            this.getVelocityButton.Click += new System.EventHandler(this.getVelocityButton_Click);
            // 
            // setVelocityButton
            // 
            this.setVelocityButton.Location = new System.Drawing.Point(114, 203);
            this.setVelocityButton.Name = "setVelocityButton";
            this.setVelocityButton.Size = new System.Drawing.Size(75, 23);
            this.setVelocityButton.TabIndex = 15;
            this.setVelocityButton.Text = "Set Velocity";
            this.setVelocityButton.UseVisualStyleBackColor = true;
            this.setVelocityButton.Click += new System.EventHandler(this.setVelocityButton_Click);
            // 
            // ASILV4000AxisTestForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(298, 409);
            this.Controls.Add(this.setVelocityButton);
            this.Controls.Add(this.getVelocityButton);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.velocityNumericUpDown);
            this.Controls.Add(this.moveAbsoluteButton);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.positionNumericUpDown);
            this.Controls.Add(this.getPosButton);
            this.Controls.Add(this.clearButton);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.axisComboBox);
            this.Controls.Add(this.getAxesButton);
            this.Controls.Add(this.initalizeButton);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.exceptionTextBox);
            this.Controls.Add(this.closeButton);
            this.Name = "ASILV4000AxisTestForm";
            this.Text = "ASILV4000AxisTestForm";
            ((System.ComponentModel.ISupportInitialize)(this.positionNumericUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.velocityNumericUpDown)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button closeButton;
        private System.Windows.Forms.TextBox exceptionTextBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button initalizeButton;
        private System.Windows.Forms.Button getAxesButton;
        private System.Windows.Forms.ComboBox axisComboBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button clearButton;
        private System.Windows.Forms.Button getPosButton;
        private System.Windows.Forms.NumericUpDown positionNumericUpDown;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button moveAbsoluteButton;
        private System.Windows.Forms.NumericUpDown velocityNumericUpDown;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button getVelocityButton;
        private System.Windows.Forms.Button setVelocityButton;
    }
}