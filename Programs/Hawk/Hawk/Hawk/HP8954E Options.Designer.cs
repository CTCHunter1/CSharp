namespace Driver
{
    partial class HP8594E_Options
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
            this.gpib_address = new System.Windows.Forms.NumericUpDown();
            this.Text1 = new System.Windows.Forms.Label();
            this.ok_button = new System.Windows.Forms.Button();
            this.cancel_button = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.gpib_address)).BeginInit();
            this.SuspendLayout();
            // 
            // gpib_address
            // 
            this.gpib_address.Location = new System.Drawing.Point(17, 76);
            this.gpib_address.Maximum = new decimal(new int[] {
            31,
            0,
            0,
            0});
            this.gpib_address.Name = "gpib_address";
            this.gpib_address.Size = new System.Drawing.Size(33, 20);
            this.gpib_address.TabIndex = 0;
            this.gpib_address.Value = new decimal(new int[] {
            5,
            0,
            0,
            0});
            // 
            // Text1
            // 
            this.Text1.AutoSize = true;
            this.Text1.Location = new System.Drawing.Point(14, 60);
            this.Text1.Name = "Text1";
            this.Text1.Size = new System.Drawing.Size(73, 13);
            this.Text1.TabIndex = 1;
            this.Text1.Text = "GPIB Address";
            // 
            // ok_button
            // 
            this.ok_button.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.ok_button.Location = new System.Drawing.Point(17, 197);
            this.ok_button.Name = "ok_button";
            this.ok_button.Size = new System.Drawing.Size(75, 23);
            this.ok_button.TabIndex = 2;
            this.ok_button.Text = "OK";
            this.ok_button.UseVisualStyleBackColor = true;
            // 
            // cancel_button
            // 
            this.cancel_button.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cancel_button.Location = new System.Drawing.Point(98, 197);
            this.cancel_button.Name = "cancel_button";
            this.cancel_button.Size = new System.Drawing.Size(75, 23);
            this.cancel_button.TabIndex = 3;
            this.cancel_button.Text = "Cancel";
            this.cancel_button.UseVisualStyleBackColor = true;
            // 
            // HP8594E_Options
            // 
            this.AcceptButton = this.ok_button;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.cancel_button;
            this.ClientSize = new System.Drawing.Size(190, 230);
            this.Controls.Add(this.cancel_button);
            this.Controls.Add(this.ok_button);
            this.Controls.Add(this.Text1);
            this.Controls.Add(this.gpib_address);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "HP8594E_Options";
            this.Text = "HP 8594E Options";
            ((System.ComponentModel.ISupportInitialize)(this.gpib_address)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.NumericUpDown gpib_address;
        private System.Windows.Forms.Label Text1;
        private System.Windows.Forms.Button ok_button;
        private System.Windows.Forms.Button cancel_button;
    }
}