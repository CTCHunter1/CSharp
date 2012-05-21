using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Lab.Drivers.Motors
{
    public class NumericUpDownCustomIncrement : NumericUpDown
    {
        double incrementAmount = .2;

        public override void UpButton()
        {
            // incrmenton a log scale
            if (Control.ModifierKeys != Keys.Control)
            {
                double value = Convert.ToDouble(this.Value);
                double valueLog10 = Math.Log10(value);
                double valueLog10Round = Math.Round(valueLog10);

                this.Value = (decimal)Math.Pow(10, valueLog10 + incrementAmount);
            }
            else
            {
                base.UpButton();
            }

        }

        public override void DownButton()
        {
            // incrmenton a log scale
            if (Control.ModifierKeys != Keys.Control)
            {
                double value = Convert.ToDouble(this.Value);
                double valueLog10 = Math.Log10(value);
                double valueLog10Round = Math.Round(valueLog10);

                this.Value = (decimal)Math.Pow(10, valueLog10 - incrementAmount);
            }
            else
            {
                base.DownButton();
            }
        }        
    }    
}
