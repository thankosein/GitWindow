using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CitiesInOurCountry.UI;

namespace CitiesInOurCountry
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnAddState_Click(object sender, EventArgs e)
        {
            frmState frm = new frmState();
            frm.ShowDialog();
        }

        private void btnAddCity_Click(object sender, EventArgs e)
        {
            frmCitiy frm = new frmCitiy();
            frm.ShowDialog();
        }
    }
}
