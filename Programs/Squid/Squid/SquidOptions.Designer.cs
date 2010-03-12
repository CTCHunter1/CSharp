namespace Squid
{
    partial class SquidOptionsForm
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
            this.okButton = new System.Windows.Forms.Button();
            this.cancelButton = new System.Windows.Forms.Button();
            this.DCFrequencyCheckBox = new System.Windows.Forms.CheckBox();
            this.ampUnitsComboBox = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // okButton
            // 
            this.okButton.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.okButton.Location = new System.Drawing.Point(12, 238);
            this.okButton.Name = "okButton";
            this.okButton.Size = new System.Drawing.Size(75, 23);
            this.okButton.TabIndex = 0;
            this.okButton.Text = "OK";
            this.okButton.UseVisualStyleBackColor = true;
            // 
            // cancelButton
            // 
            this.cancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cancelButton.Location = new System.Drawing.Point(205, 238);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(75, 23);
            this.cancelButton.TabIndex = 1;
            this.cancelButton.Text = "Cancel";
            this.cancelButton.UseVisualStyleBackColor = true;
            this.cancelButton.Click += new System.EventHandler(this.cancelButton_Click);
            // 
            // DCFrequencyCheckBox
            // 
            this.DCFrequencyCheckBox.AutoSize = true;
            this.DCFrequencyCheckBox.Location = new System.Drawing.Point(12, 66);
            this.DCFrequencyCheckBox.Name = "DCFrequencyCheckBox";
            this.DCFrequencyCheckBox.Size = new System.Drawing.Size(115, 17);
            this.DCFrequencyCheckBox.TabIndex = 2;
            this.DCFrequencyCheckBox.Text = "Plot DC Frequency";
            this.DCFrequencyCheckBox.UseVisualStyleBackColor = true;
            // 
            // ampUnitsComboBox
            // 
            this.ampUnitsComboBox.FormattingEnabled = true;
            this.ampUnitsComboBox.Location = new System.Drawing.Point(12, 39);
            this.ampUnitsComboBox.Name = "ampUnitsComboBox";
            this.ampUnitsComboBox.Size = new System.Drawing.Size(121, 21);
            this.ampUnitsComboBox.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(108, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Frequency Amp Units";
            // 
            // SquidOptionsForm
            // 
            this.AcceptButton = this.okButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.cancelButton;
            this.ClientSize = new System.Drawing.Size(292, 273);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.ampUnitsComboBox);
            this.Controls.Add(this.DCFrequencyCheckBox);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.okButton);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "SquidOptionsForm";
            this.Text = "Squid Options";
            this.Shown += new System.EventHandler(this.SquidOptions_Shown);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button okButton;
        private System.Windows.Forms.Button cancelButton;
        private System.Windows.Forms.CheckBox DCFrequencyCheckBox;
        private System.Windows.Forms.ComboBox ampUnitsComboBox;
        private System.Windows.Forms.Label label1;
    }
}