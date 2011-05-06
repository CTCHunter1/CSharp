namespace Lab.Drivers.Motors.Test
{
    partial class MainTestForm
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
            this.zaberTLAButton = new System.Windows.Forms.Button();
            this.newportAxisButton = new System.Windows.Forms.Button();
            this.zaberAxisButton = new System.Windows.Forms.Button();
            this.motorsButton = new System.Windows.Forms.Button();
            this.motorControlFormButton = new System.Windows.Forms.Button();
            this.asiControlForm = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(12, 23);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(131, 23);
            this.button1.TabIndex = 2;
            this.button1.Text = "ZaberDLLWrapper";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // zaberTLAButton
            // 
            this.zaberTLAButton.Location = new System.Drawing.Point(12, 52);
            this.zaberTLAButton.Name = "zaberTLAButton";
            this.zaberTLAButton.Size = new System.Drawing.Size(131, 23);
            this.zaberTLAButton.TabIndex = 3;
            this.zaberTLAButton.Text = "ZaberTLA Class";
            this.zaberTLAButton.UseVisualStyleBackColor = true;
            this.zaberTLAButton.Click += new System.EventHandler(this.zaberTLAButton_Click);
            // 
            // newportAxisButton
            // 
            this.newportAxisButton.Location = new System.Drawing.Point(12, 81);
            this.newportAxisButton.Name = "newportAxisButton";
            this.newportAxisButton.Size = new System.Drawing.Size(131, 23);
            this.newportAxisButton.TabIndex = 4;
            this.newportAxisButton.Text = "Newport Axis";
            this.newportAxisButton.UseVisualStyleBackColor = true;
            this.newportAxisButton.Click += new System.EventHandler(this.newportAxisButton_Click);
            // 
            // zaberAxisButton
            // 
            this.zaberAxisButton.Location = new System.Drawing.Point(12, 110);
            this.zaberAxisButton.Name = "zaberAxisButton";
            this.zaberAxisButton.Size = new System.Drawing.Size(131, 23);
            this.zaberAxisButton.TabIndex = 5;
            this.zaberAxisButton.Text = "Zaber Axis";
            this.zaberAxisButton.UseVisualStyleBackColor = true;
            this.zaberAxisButton.Click += new System.EventHandler(this.zaberAxisButton_Click);
            // 
            // motorsButton
            // 
            this.motorsButton.Location = new System.Drawing.Point(12, 139);
            this.motorsButton.Name = "motorsButton";
            this.motorsButton.Size = new System.Drawing.Size(131, 23);
            this.motorsButton.TabIndex = 6;
            this.motorsButton.Text = "Motors";
            this.motorsButton.UseVisualStyleBackColor = true;
            this.motorsButton.Click += new System.EventHandler(this.motorsButton_Click);
            // 
            // motorControlFormButton
            // 
            this.motorControlFormButton.Location = new System.Drawing.Point(12, 168);
            this.motorControlFormButton.Name = "motorControlFormButton";
            this.motorControlFormButton.Size = new System.Drawing.Size(131, 23);
            this.motorControlFormButton.TabIndex = 7;
            this.motorControlFormButton.Text = "Motor Control Form";
            this.motorControlFormButton.UseVisualStyleBackColor = true;
            this.motorControlFormButton.Click += new System.EventHandler(this.motorControlFormButton_Click);
            // 
            // asiControlForm
            // 
            this.asiControlForm.Location = new System.Drawing.Point(12, 197);
            this.asiControlForm.Name = "asiControlForm";
            this.asiControlForm.Size = new System.Drawing.Size(131, 25);
            this.asiControlForm.TabIndex = 8;
            this.asiControlForm.Text = "ASI_LV4000";
            this.asiControlForm.UseVisualStyleBackColor = true;
            this.asiControlForm.Click += new System.EventHandler(this.asiControlForm_Click);
            // 
            // MainTestForm
            // 
            this.ClientSize = new System.Drawing.Size(159, 383);
            this.Controls.Add(this.asiControlForm);
            this.Controls.Add(this.motorControlFormButton);
            this.Controls.Add(this.motorsButton);
            this.Controls.Add(this.zaberAxisButton);
            this.Controls.Add(this.newportAxisButton);
            this.Controls.Add(this.zaberTLAButton);
            this.Controls.Add(this.button1);
            this.Name = "MainTestForm";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button zaberTLAButton;
        private System.Windows.Forms.Button newportAxisButton;
        private System.Windows.Forms.Button zaberAxisButton;
        private System.Windows.Forms.Button motorsButton;
        private System.Windows.Forms.Button motorControlFormButton;
        private System.Windows.Forms.Button asiControlForm;
    }
}