using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Lab.Drivers.Motors;

namespace Lab.Programs.Bullet
{
    public partial class MainForm : Form
    {
        NewportESP100 esp100driver_obj = new NewportESP100();
         
        public MainForm()
        {
            InitializeComponent();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        
        }

        private void button1_Click(object sender, EventArgs e)
        {
            esp100driver_obj.Initalize();
        }
    }
}