using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CitiesInOurCountry.UI
{
    public partial class frmCitiy : Form
    {
        public frmCitiy()
        {
            InitializeComponent();
        }

        private void CreateGrid()
        {
            DataGridViewCellStyle coloumHeader = new DataGridViewCellStyle();
            coloumHeader.BackColor = Color.AliceBlue;
            coloumHeader.Font = new Font("Pyidaungsu", 10.2F, System.Drawing.FontStyle.Bold);
            dgv.ColumnHeadersDefaultCellStyle = coloumHeader;
            dgv.RowHeadersVisible = false;
            dgv.AllowUserToAddRows = false;
            dgv.MultiSelect = false;
            dgv.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgv.ColumnCount = 3;

            dgv.Columns[0].HeaderText = "City Id";
            dgv.Columns[0].Width = 65;
            dgv.Columns[0].ReadOnly = true;

            dgv.Columns[1].HeaderText = "Name";
            dgv.Columns[1].Width = 100;
            dgv.Columns[1].ReadOnly = true;

            dgv.Columns[2].HeaderText = "State Id";
            dgv.Columns[2].Width = 100;
            dgv.Columns[2].ReadOnly = true;
        }

        private void frmCitiy_Load(object sender, EventArgs e)
        {
            CreateGrid();
        }
    }
}
