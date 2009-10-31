namespace Lab.Drivers.Motors.Test
{
    partial class ZaberAxisTestForm
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
            this.axisNumberComboBox = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.moveAbsoluteButton = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.positionTextBox = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.currentPositionTextBox = new System.Windows.Forms.TextBox();
            this.beginMoveAbsoluteButton = new System.Windows.Forms.Button();
            this.beginMovePositionTextBox = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.callbackTextBox = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // closeButton
            // 
            this.closeButton.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.closeButton.Location = new System.Drawing.Point(12, 408);
            this.closeButton.Name = "closeButton";
            this.closeButton.Size = new System.Drawing.Size(75, 23);
            this.closeButton.TabIndex = 0;
            this.closeButton.Text = "Close";
            this.closeButton.UseVisualStyleBackColor = true;
            // 
            // axisNumberComboBox
            // 
            this.axisNumberComboBox.FormattingEnabled = true;
            this.axisNumberComboBox.Location = new System.Drawing.Point(12, 28);
            this.axisNumberComboBox.Name = "axisNumberComboBox";
            this.axisNumberComboBox.Size = new System.Drawing.Size(75, 21);
            this.axisNumberComboBox.Sorted = true;
            this.axisNumberComboBox.TabIndex = 1;
            this.axisNumberComboBox.SelectedIndexChanged += new System.EventHandler(this.axisNumberComboBox_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(66, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Axis Number";
            // 
            // moveAbsoluteButton
            // 
            this.moveAbsoluteButton.Location = new System.Drawing.Point(12, 109);
            this.moveAbsoluteButton.Name = "moveAbsoluteButton";
            this.moveAbsoluteButton.Size = new System.Drawing.Size(90, 23);
            this.moveAbsoluteButton.TabIndex = 3;
            this.moveAbsoluteButton.Text = "Move Absolute";
            this.moveAbsoluteButton.UseVisualStyleBackColor = true;
            this.moveAbsoluteButton.Click += new System.EventHandler(this.moveAbsoluteButton_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(128, 93);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(44, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Position";
            // 
            // positionTextBox
            // 
            this.positionTextBox.Location = new System.Drawing.Point(131, 109);
            this.positionTextBox.Name = "positionTextBox";
            this.positionTextBox.Size = new System.Drawing.Size(52, 20);
            this.positionTextBox.TabIndex = 5;
            this.positionTextBox.Text = "0.0";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(128, 42);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(81, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Current Position";
            // 
            // currentPositionTextBox
            // 
            this.currentPositionTextBox.Location = new System.Drawing.Point(131, 58);
            this.currentPositionTextBox.Name = "currentPositionTextBox";
            this.currentPositionTextBox.Size = new System.Drawing.Size(52, 20);
            this.currentPositionTextBox.TabIndex = 7;
            // 
            // beginMoveAbsoluteButton
            // 
            this.beginMoveAbsoluteButton.Location = new System.Drawing.Point(12, 150);
            this.beginMoveAbsoluteButton.Name = "beginMoveAbsoluteButton";
            this.beginMoveAbsoluteButton.Size = new System.Drawing.Size(90, 42);
            this.beginMoveAbsoluteButton.TabIndex = 8;
            this.beginMoveAbsoluteButton.Text = "Begin Move Absolute";
            this.beginMoveAbsoluteButton.UseVisualStyleBackColor = true;
            this.beginMoveAbsoluteButton.Click += new System.EventHandler(this.beginMoveAbsoluteButton_Click);
            // 
            // beginMovePositionTextBox
            // 
            this.beginMovePositionTextBox.Location = new System.Drawing.Point(131, 162);
            this.beginMovePositionTextBox.Name = "beginMovePositionTextBox";
            this.beginMovePositionTextBox.Size = new System.Drawing.Size(52, 20);
            this.beginMovePositionTextBox.TabIndex = 10;
            this.beginMovePositionTextBox.Text = "0.0";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(128, 146);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(44, 13);
            this.label4.TabIndex = 9;
            this.label4.Text = "Position";
            // 
            // callbackTextBox
            // 
            this.callbackTextBox.Location = new System.Drawing.Point(211, 162);
            this.callbackTextBox.Name = "callbackTextBox";
            this.callbackTextBox.Size = new System.Drawing.Size(102, 20);
            this.callbackTextBox.TabIndex = 11;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(208, 146);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(80, 13);
            this.label5.TabIndex = 12;
            this.label5.Text = "Callback Called";
            // 
            // ZaberAxisTestForm
            // 
            this.AcceptButton = this.closeButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.closeButton;
            this.ClientSize = new System.Drawing.Size(341, 443);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.callbackTextBox);
            this.Controls.Add(this.beginMovePositionTextBox);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.beginMoveAbsoluteButton);
            this.Controls.Add(this.currentPositionTextBox);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.positionTextBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.moveAbsoluteButton);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.axisNumberComboBox);
            this.Controls.Add(this.closeButton);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "ZaberAxisTestForm";
            this.Text = "ZaberAxisTestForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button closeButton;
        private System.Windows.Forms.ComboBox axisNumberComboBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button moveAbsoluteButton;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox positionTextBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox currentPositionTextBox;
        private System.Windows.Forms.Button beginMoveAbsoluteButton;
        private System.Windows.Forms.TextBox beginMovePositionTextBox;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox callbackTextBox;
        private System.Windows.Forms.Label label5;
    }
}