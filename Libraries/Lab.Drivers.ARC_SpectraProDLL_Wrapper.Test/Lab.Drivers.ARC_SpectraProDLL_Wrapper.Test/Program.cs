using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace Lab.Drivers.ARC_SpectraProDLL_Wrapper.Test
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new ARC_SpectraProDLL_WrapperTestForm());
        }
    }
}
