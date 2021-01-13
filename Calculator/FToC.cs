using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Calculator
{
    public partial class FToC : Form
    {
        public FToC()
        {
            InitializeComponent();
        }

        private void txtF_KeyUp(object sender, KeyEventArgs e)
        {
            //txtC.Text = txtF.Text;
            //(32°F − 32) × 5/9 = 0°C

            //F to C
            double fer = txtF.Text != "" ? double.Parse(txtF.Text) : 0;
            double res = (fer - 32) * 5/9;
            txtC.Text = res.ToString("0.00");
        }


        private void txtC_KeyUp(object sender, KeyEventArgs e)
        {
            //txtF.Text = txtC.Text;
            //C to F {Formula	(32°C × 9 / 5) +32 = 89.6°F }
            double cel = txtC.Text != "" ? double.Parse(txtC.Text) : 0;
            txtF.Text = ((cel * 9 / 5) + 32).ToString("0.00");

        }

        private void txtF_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) &&
        (e.KeyChar != '.'))
            {
                e.Handled = true;
            }

            // only allow one decimal point
            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
        }

        private void txtC_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) &&
            (e.KeyChar != '.'))
            {
                e.Handled = true;
            }

            // only allow one decimal point
            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
        }
    }
}
