using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Lab.Drivers.HP8594E
{
    public partial class HP8594E_Options : Form
    {   
        public HP8594E_Options()
        {
            InitializeComponent();

        }

        public int GPIB_Addr
        {
            set
            {
                gpib_address.Value = GPIB_Addr;
            }

            get
            {
                return ((int) gpib_address.Value);
            }
        }
    }
}