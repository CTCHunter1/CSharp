namespace Lab.Drivers.Motors.Test
{
    partial class NewportAxisTestForm
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
            this.initializeButton = new System.Windows.Forms.Button();
            this.exceptionTextBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.axisNumberComboBox = new System.Windows.Forms.ComboBox();
            this.updateParametersButton = new System.Windows.Forms.Button();
            this.serialNumberTextBox = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.modelNumberTextBox = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.homeTextBox = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.currentPositionTextBox = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.velocityTextBox = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.descriptionTextBox = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.callbackTextBox = new System.Windows.Forms.TextBox();
            this.beginMovePositionTextBox = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.beginMoveAbsoluteButton = new System.Windows.Forms.Button();
            this.absolutePositionTextBox = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.moveAbsoluteButton = new System.Windows.Forms.Button();
            this.setVelocityButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // closeButton
            // 
            this.closeButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.closeButton.Location = new System.Drawing.Point(29, 542);
            this.closeButton.Name = "closeButton";
            this.closeButton.Size = new System.Drawing.Size(68, 23);
            this.closeButton.TabIndex = 0;
            this.closeButton.Text = "Close";
            this.closeButton.UseVisualStyleBackColor = true;
            // 
            // initializeButton
            // 
            this.initializeButton.Location = new System.Drawing.Point(12, 27);
            this.initializeButton.Name = "initializeButton";
            this.initializeButton.Size = new System.Drawing.Size(75, 23);
            this.initializeButton.TabIndex = 1;
            this.initializeButton.Text = "Initalize";
            this.initializeButton.UseVisualStyleBackColor = true;
            this.initializeButton.Click += new System.EventHandler(this.initializeButton_Click);
            // 
            // exceptionTextBox
            // 
            this.exceptionTextBox.Location = new System.Drawing.Point(12, 477);
            this.exceptionTextBox.Multiline = true;
            this.exceptionTextBox.Name = "exceptionTextBox";
            this.exceptionTextBox.Size = new System.Drawing.Size(275, 52);
            this.exceptionTextBox.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 461);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(99, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Exception message";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(9, 64);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(66, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Axis Number";
            // 
            // axisNumberComboBox
            // 
            this.axisNumberComboBox.FormattingEnabled = true;
            this.axisNumberComboBox.Location = new System.Drawing.Point(12, 80);
            this.axisNumberComboBox.Name = "axisNumberComboBox";
            this.axisNumberComboBox.Size = new System.Drawing.Size(275, 21);
            this.axisNumberComboBox.Sorted = true;
            this.axisNumberComboBox.TabIndex = 4;
            // 
            // updateParametersButton
            // 
            this.updateParametersButton.Location = new System.Drawing.Point(12, 116);
            this.updateParametersButton.Name = "updateParametersButton";
            this.updateParametersButton.Size = new System.Drawing.Size(108, 23);
            this.updateParametersButton.TabIndex = 6;
            this.updateParametersButton.Text = "Update Parameters";
            this.updateParametersButton.UseVisualStyleBackColor = true;
            this.updateParametersButton.Click += new System.EventHandler(this.updateParametersButton_Click);
            // 
            // serialNumberTextBox
            // 
            this.serialNumberTextBox.Location = new System.Drawing.Point(12, 166);
            this.serialNumberTextBox.Name = "serialNumberTextBox";
            this.serialNumberTextBox.Size = new System.Drawing.Size(241, 20);
            this.serialNumberTextBox.TabIndex = 9;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(9, 150);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(73, 13);
            this.label3.TabIndex = 8;
            this.label3.Text = "Serial Number";
            // 
            // modelNumberTextBox
            // 
            this.modelNumberTextBox.Location = new System.Drawing.Point(12, 247);
            this.modelNumberTextBox.Name = "modelNumberTextBox";
            this.modelNumberTextBox.Size = new System.Drawing.Size(241, 20);
            this.modelNumberTextBox.TabIndex = 11;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(9, 231);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(76, 13);
            this.label4.TabIndex = 10;
            this.label4.Text = "Model Number";
            // 
            // homeTextBox
            // 
            this.homeTextBox.Location = new System.Drawing.Point(70, 287);
            this.homeTextBox.Name = "homeTextBox";
            this.homeTextBox.Size = new System.Drawing.Size(52, 20);
            this.homeTextBox.TabIndex = 13;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(67, 271);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(35, 13);
            this.label5.TabIndex = 12;
            this.label5.Text = "Home";
            // 
            // currentPositionTextBox
            // 
            this.currentPositionTextBox.Location = new System.Drawing.Point(128, 287);
            this.currentPositionTextBox.Name = "currentPositionTextBox";
            this.currentPositionTextBox.Size = new System.Drawing.Size(52, 20);
            this.currentPositionTextBox.TabIndex = 15;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(125, 271);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(81, 13);
            this.label6.TabIndex = 14;
            this.label6.Text = "Current Position";
            // 
            // velocityTextBox
            // 
            this.velocityTextBox.Location = new System.Drawing.Point(12, 287);
            this.velocityTextBox.Name = "velocityTextBox";
            this.velocityTextBox.Size = new System.Drawing.Size(52, 20);
            this.velocityTextBox.TabIndex = 17;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(9, 271);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(44, 13);
            this.label7.TabIndex = 16;
            this.label7.Text = "Velocity";
            // 
            // descriptionTextBox
            // 
            this.descriptionTextBox.Location = new System.Drawing.Point(12, 208);
            this.descriptionTextBox.Name = "descriptionTextBox";
            this.descriptionTextBox.Size = new System.Drawing.Size(241, 20);
            this.descriptionTextBox.TabIndex = 19;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(9, 192);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(60, 13);
            this.label8.TabIndex = 18;
            this.label8.Text = "Description";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(185, 382);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(80, 13);
            this.label9.TabIndex = 27;
            this.label9.Text = "Callback Called";
            // 
            // callbackTextBox
            // 
            this.callbackTextBox.Location = new System.Drawing.Point(188, 398);
            this.callbackTextBox.Name = "callbackTextBox";
            this.callbackTextBox.Size = new System.Drawing.Size(102, 20);
            this.callbackTextBox.TabIndex = 26;
            // 
            // beginMovePositionTextBox
            // 
            this.beginMovePositionTextBox.Location = new System.Drawing.Point(108, 398);
            this.beginMovePositionTextBox.Name = "beginMovePositionTextBox";
            this.beginMovePositionTextBox.Size = new System.Drawing.Size(52, 20);
            this.beginMovePositionTextBox.TabIndex = 25;
            this.beginMovePositionTextBox.Text = "0.0";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(105, 382);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(60, 13);
            this.label10.TabIndex = 24;
            this.label10.Text = "To Position";
            // 
            // beginMoveAbsoluteButton
            // 
            this.beginMoveAbsoluteButton.Location = new System.Drawing.Point(12, 386);
            this.beginMoveAbsoluteButton.Name = "beginMoveAbsoluteButton";
            this.beginMoveAbsoluteButton.Size = new System.Drawing.Size(90, 42);
            this.beginMoveAbsoluteButton.TabIndex = 23;
            this.beginMoveAbsoluteButton.Text = "Begin Move Absolute";
            this.beginMoveAbsoluteButton.UseVisualStyleBackColor = true;
            this.beginMoveAbsoluteButton.Click += new System.EventHandler(this.beginMoveAbsoluteButton_Click);
            // 
            // absolutePositionTextBox
            // 
            this.absolutePositionTextBox.Location = new System.Drawing.Point(108, 345);
            this.absolutePositionTextBox.Name = "absolutePositionTextBox";
            this.absolutePositionTextBox.Size = new System.Drawing.Size(52, 20);
            this.absolutePositionTextBox.TabIndex = 22;
            this.absolutePositionTextBox.Text = "0.0";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(105, 329);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(60, 13);
            this.label11.TabIndex = 21;
            this.label11.Text = "To Position";
            // 
            // moveAbsoluteButton
            // 
            this.moveAbsoluteButton.Location = new System.Drawing.Point(12, 345);
            this.moveAbsoluteButton.Name = "moveAbsoluteButton";
            this.moveAbsoluteButton.Size = new System.Drawing.Size(90, 23);
            this.moveAbsoluteButton.TabIndex = 20;
            this.moveAbsoluteButton.Text = "Move Absolute";
            this.moveAbsoluteButton.UseVisualStyleBackColor = true;
            this.moveAbsoluteButton.Click += new System.EventHandler(this.moveAbsoluteButton_Click);
            // 
            // setVelocityButton
            // 
            this.setVelocityButton.Location = new System.Drawing.Point(12, 313);
            this.setVelocityButton.Name = "setVelocityButton";
            this.setVelocityButton.Size = new System.Drawing.Size(90, 23);
            this.setVelocityButton.TabIndex = 28;
            this.setVelocityButton.Text = "Set Velocity";
            this.setVelocityButton.UseVisualStyleBackColor = true;
            this.setVelocityButton.Click += new System.EventHandler(this.setVelocityButton_Click);
            // 
            // NewportAxisTestForm
            // 
            this.AcceptButton = this.closeButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.closeButton;
            this.ClientSize = new System.Drawing.Size(520, 570);
            this.Controls.Add(this.setVelocityButton);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.callbackTextBox);
            this.Controls.Add(this.beginMovePositionTextBox);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.beginMoveAbsoluteButton);
            this.Controls.Add(this.absolutePositionTextBox);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.moveAbsoluteButton);
            this.Controls.Add(this.descriptionTextBox);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.velocityTextBox);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.currentPositionTextBox);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.homeTextBox);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.modelNumberTextBox);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.serialNumberTextBox);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.updateParametersButton);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.axisNumberComboBox);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.exceptionTextBox);
            this.Controls.Add(this.initializeButton);
            this.Controls.Add(this.closeButton);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "NewportAxisTestForm";
            this.Text = "NewportAxisTestForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button closeButton;
        private System.Windows.Forms.Button initializeButton;
        private System.Windows.Forms.TextBox exceptionTextBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox axisNumberComboBox;
        private System.Windows.Forms.Button updateParametersButton;
        private System.Windows.Forms.TextBox serialNumberTextBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox modelNumberTextBox;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox homeTextBox;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox currentPositionTextBox;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox velocityTextBox;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox descriptionTextBox;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox callbackTextBox;
        private System.Windows.Forms.TextBox beginMovePositionTextBox;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Button beginMoveAbsoluteButton;
        private System.Windows.Forms.TextBox absolutePositionTextBox;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Button moveAbsoluteButton;
        private System.Windows.Forms.Button setVelocityButton;
    }
}