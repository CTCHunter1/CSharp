namespace Hawk
{
    partial class Arroyo_Sweep_Options
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
            this.start_numeric = new System.Windows.Forms.NumericUpDown();
            this.stop_numeric = new System.Windows.Forms.NumericUpDown();
            this.num_pts_numeric = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.mode_combo = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.Ok_button = new System.Windows.Forms.Button();
            this.cancel_button = new System.Windows.Forms.Button();
            this.start_label = new System.Windows.Forms.Label();
            this.stop_label = new System.Windows.Forms.Label();
            this.sleep_time_numeric = new System.Windows.Forms.NumericUpDown();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.start_numeric)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.stop_numeric)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.num_pts_numeric)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.sleep_time_numeric)).BeginInit();
            this.SuspendLayout();
            // 
            // start_numeric
            // 
            this.start_numeric.Location = new System.Drawing.Point(36, 40);
            this.start_numeric.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.start_numeric.Name = "start_numeric";
            this.start_numeric.Size = new System.Drawing.Size(120, 20);
            this.start_numeric.TabIndex = 0;
            this.start_numeric.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
            // 
            // stop_numeric
            // 
            this.stop_numeric.Location = new System.Drawing.Point(36, 79);
            this.stop_numeric.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.stop_numeric.Name = "stop_numeric";
            this.stop_numeric.Size = new System.Drawing.Size(120, 20);
            this.stop_numeric.TabIndex = 1;
            this.stop_numeric.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
            // 
            // num_pts_numeric
            // 
            this.num_pts_numeric.Location = new System.Drawing.Point(36, 124);
            this.num_pts_numeric.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.num_pts_numeric.Minimum = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.num_pts_numeric.Name = "num_pts_numeric";
            this.num_pts_numeric.Size = new System.Drawing.Size(120, 20);
            this.num_pts_numeric.TabIndex = 2;
            this.num_pts_numeric.Value = new decimal(new int[] {
            2,
            0,
            0,
            0});
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(33, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(29, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Start";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(33, 63);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(29, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Stop";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(33, 108);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(88, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Number of Points";
            // 
            // mode_combo
            // 
            this.mode_combo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.mode_combo.FormattingEnabled = true;
            this.mode_combo.Items.AddRange(new object[] {
            "I0 (Drive Current)",
            "Im (Monitor Current)"});
            this.mode_combo.Location = new System.Drawing.Point(35, 170);
            this.mode_combo.Name = "mode_combo";
            this.mode_combo.Size = new System.Drawing.Size(121, 21);
            this.mode_combo.TabIndex = 6;
            this.mode_combo.TextChanged += new System.EventHandler(this.mode_combo_TextChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(33, 154);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(34, 13);
            this.label4.TabIndex = 7;
            this.label4.Text = "Mode";
            // 
            // Ok_button
            // 
            this.Ok_button.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.Ok_button.Location = new System.Drawing.Point(12, 266);
            this.Ok_button.Name = "Ok_button";
            this.Ok_button.Size = new System.Drawing.Size(75, 23);
            this.Ok_button.TabIndex = 8;
            this.Ok_button.Text = "Ok";
            this.Ok_button.UseVisualStyleBackColor = true;
            // 
            // cancel_button
            // 
            this.cancel_button.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cancel_button.Location = new System.Drawing.Point(114, 266);
            this.cancel_button.Name = "cancel_button";
            this.cancel_button.Size = new System.Drawing.Size(75, 23);
            this.cancel_button.TabIndex = 9;
            this.cancel_button.Text = "Cancel";
            this.cancel_button.UseVisualStyleBackColor = true;
            // 
            // start_label
            // 
            this.start_label.AutoSize = true;
            this.start_label.Location = new System.Drawing.Point(162, 42);
            this.start_label.Name = "start_label";
            this.start_label.Size = new System.Drawing.Size(22, 13);
            this.start_label.TabIndex = 10;
            this.start_label.Text = "mA";
            // 
            // stop_label
            // 
            this.stop_label.AutoSize = true;
            this.stop_label.Location = new System.Drawing.Point(162, 86);
            this.stop_label.Name = "stop_label";
            this.stop_label.Size = new System.Drawing.Size(22, 13);
            this.stop_label.TabIndex = 11;
            this.stop_label.Text = "mA";
            // 
            // sleep_time_numeric
            // 
            this.sleep_time_numeric.Location = new System.Drawing.Point(36, 219);
            this.sleep_time_numeric.Name = "sleep_time_numeric";
            this.sleep_time_numeric.Size = new System.Drawing.Size(120, 20);
            this.sleep_time_numeric.TabIndex = 12;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(33, 203);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(60, 13);
            this.label5.TabIndex = 13;
            this.label5.Text = "Sleep Time";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(162, 226);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(20, 13);
            this.label6.TabIndex = 14;
            this.label6.Text = "ms";
            // 
            // Arroyo_Sweep_Options
            // 
            this.AcceptButton = this.Ok_button;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.cancel_button;
            this.ClientSize = new System.Drawing.Size(229, 313);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.sleep_time_numeric);
            this.Controls.Add(this.stop_label);
            this.Controls.Add(this.start_label);
            this.Controls.Add(this.cancel_button);
            this.Controls.Add(this.Ok_button);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.mode_combo);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.num_pts_numeric);
            this.Controls.Add(this.stop_numeric);
            this.Controls.Add(this.start_numeric);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "Arroyo_Sweep_Options";
            this.Text = "Arroyo Sweep Options";
            ((System.ComponentModel.ISupportInitialize)(this.start_numeric)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.stop_numeric)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.num_pts_numeric)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.sleep_time_numeric)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.NumericUpDown start_numeric;
        private System.Windows.Forms.NumericUpDown stop_numeric;
        private System.Windows.Forms.NumericUpDown num_pts_numeric;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox mode_combo;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button Ok_button;
        private System.Windows.Forms.Button cancel_button;
        private System.Windows.Forms.Label start_label;
        private System.Windows.Forms.Label stop_label;
        private System.Windows.Forms.NumericUpDown sleep_time_numeric;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;

    }
}