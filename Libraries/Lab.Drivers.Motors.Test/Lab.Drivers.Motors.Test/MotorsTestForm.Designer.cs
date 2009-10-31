namespace Lab.Drivers.Motors.Test
{
    partial class MotorsTestForm
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
            this.initalizeButton = new System.Windows.Forms.Button();
            this.numAxisTextBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.axisComboBox = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.moveAbsoluteButton = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.positionTextBox = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.currentPositionTextBox = new System.Windows.Forms.TextBox();
            this.beginMoveButton = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.beginMoveTextBox = new System.Windows.Forms.TextBox();
            this.callbackTextBox = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // closeButton
            // 
            this.closeButton.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.closeButton.Location = new System.Drawing.Point(63, 347);
            this.closeButton.Name = "closeButton";
            this.closeButton.Size = new System.Drawing.Size(75, 23);
            this.closeButton.TabIndex = 0;
            this.closeButton.Text = "Close";
            this.closeButton.UseVisualStyleBackColor = true;
            // 
            // initalizeButton
            // 
            this.initalizeButton.Location = new System.Drawing.Point(52, 28);
            this.initalizeButton.Name = "initalizeButton";
            this.initalizeButton.Size = new System.Drawing.Size(75, 23);
            this.initalizeButton.TabIndex = 1;
            this.initalizeButton.Text = "Initalize Button";
            this.initalizeButton.UseVisualStyleBackColor = true;
            this.initalizeButton.Click += new System.EventHandler(this.initalizeButton_Click);
            // 
            // numAxisTextBox
            // 
            this.numAxisTextBox.Location = new System.Drawing.Point(218, 31);
            this.numAxisTextBox.Name = "numAxisTextBox";
            this.numAxisTextBox.Size = new System.Drawing.Size(43, 20);
            this.numAxisTextBox.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(215, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(55, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Num Axes";
            // 
            // axisComboBox
            // 
            this.axisComboBox.FormattingEnabled = true;
            this.axisComboBox.Location = new System.Drawing.Point(52, 74);
            this.axisComboBox.Name = "axisComboBox";
            this.axisComboBox.Size = new System.Drawing.Size(209, 21);
            this.axisComboBox.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(49, 58);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(26, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Axis";
            // 
            // moveAbsoluteButton
            // 
            this.moveAbsoluteButton.Location = new System.Drawing.Point(52, 162);
            this.moveAbsoluteButton.Name = "moveAbsoluteButton";
            this.moveAbsoluteButton.Size = new System.Drawing.Size(86, 23);
            this.moveAbsoluteButton.TabIndex = 6;
            this.moveAbsoluteButton.Text = "Move Absolute";
            this.moveAbsoluteButton.UseVisualStyleBackColor = true;
            this.moveAbsoluteButton.Click += new System.EventHandler(this.moveAbsoluteButton_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(155, 149);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(44, 13);
            this.label3.TabIndex = 8;
            this.label3.Text = "Position";
            // 
            // positionTextBox
            // 
            this.positionTextBox.Location = new System.Drawing.Point(158, 165);
            this.positionTextBox.Name = "positionTextBox";
            this.positionTextBox.Size = new System.Drawing.Size(49, 20);
            this.positionTextBox.TabIndex = 7;
            this.positionTextBox.Text = "0";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(276, 59);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(81, 13);
            this.label4.TabIndex = 10;
            this.label4.Text = "Current Position";
            // 
            // currentPositionTextBox
            // 
            this.currentPositionTextBox.Location = new System.Drawing.Point(279, 75);
            this.currentPositionTextBox.Name = "currentPositionTextBox";
            this.currentPositionTextBox.Size = new System.Drawing.Size(49, 20);
            this.currentPositionTextBox.TabIndex = 9;
            // 
            // beginMoveButton
            // 
            this.beginMoveButton.Location = new System.Drawing.Point(52, 216);
            this.beginMoveButton.Name = "beginMoveButton";
            this.beginMoveButton.Size = new System.Drawing.Size(86, 23);
            this.beginMoveButton.TabIndex = 11;
            this.beginMoveButton.Text = "Begin Move Absolute";
            this.beginMoveButton.UseVisualStyleBackColor = true;
            this.beginMoveButton.Click += new System.EventHandler(this.beginMoveButton_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(155, 200);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(44, 13);
            this.label5.TabIndex = 13;
            this.label5.Text = "Position";
            // 
            // beginMoveTextBox
            // 
            this.beginMoveTextBox.Location = new System.Drawing.Point(158, 216);
            this.beginMoveTextBox.Name = "beginMoveTextBox";
            this.beginMoveTextBox.Size = new System.Drawing.Size(49, 20);
            this.beginMoveTextBox.TabIndex = 12;
            this.beginMoveTextBox.Text = "0";
            // 
            // callbackTextBox
            // 
            this.callbackTextBox.Location = new System.Drawing.Point(237, 218);
            this.callbackTextBox.Name = "callbackTextBox";
            this.callbackTextBox.Size = new System.Drawing.Size(143, 20);
            this.callbackTextBox.TabIndex = 14;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(234, 202);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(93, 13);
            this.label6.TabIndex = 15;
            this.label6.Text = "Callback Text Box";
            // 
            // MotorsTestForm
            // 
            this.AcceptButton = this.closeButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(392, 382);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.callbackTextBox);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.beginMoveTextBox);
            this.Controls.Add(this.beginMoveButton);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.currentPositionTextBox);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.positionTextBox);
            this.Controls.Add(this.moveAbsoluteButton);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.axisComboBox);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.numAxisTextBox);
            this.Controls.Add(this.initalizeButton);
            this.Controls.Add(this.closeButton);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "MotorsTestForm";
            this.Text = "MotorsTestForm";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.MotorsTestForm_FormClosed);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button closeButton;
        private System.Windows.Forms.Button initalizeButton;
        private System.Windows.Forms.TextBox numAxisTextBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox axisComboBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button moveAbsoluteButton;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox positionTextBox;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox currentPositionTextBox;
        private System.Windows.Forms.Button beginMoveButton;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox beginMoveTextBox;
        private System.Windows.Forms.TextBox callbackTextBox;
        private System.Windows.Forms.Label label6;
    }
}