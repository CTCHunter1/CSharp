using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Hawk
{
    public partial class Arroyo_Options_Form : Form
    {
        public Arroyo_Options_Form(int i_com_port)
        {
            InitializeComponent();
            port_num.Value = i_com_port;
        }

        public int Com_Port
        {         
            get{
                return (int) port_num.Value;
            }
        }
    }
}