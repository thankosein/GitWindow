using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CitiesInOurCountry.Service;

namespace CitiesInOurCountry.UI
{
    public partial class frmState : Form
    {
        public frmState()
        {
            InitializeComponent();
        }

        byte stateId = 0;

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
            dgv.ColumnCount = 2;

            dgv.Columns[0].HeaderText = "State Id";
            dgv.Columns[0].Width = 65;
            dgv.Columns[0].ReadOnly = true;

            dgv.Columns[1].HeaderText = "Name";
            dgv.Columns[1].Width = 170;
            dgv.Columns[1].ReadOnly = true;
        }        

        private void frmState_Load(object sender, EventArgs e)
        {
            CreateGrid();
            AutoFillStateId();
            StateService.ReadData(dgv);
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            byte id = Convert.ToByte(txtStateId.Text);
            string name = txtName.Text;

            lblResult.Text = StateService.AddState(id, name);
            StateService.ReadData(dgv);

            AutoFillStateId();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            lblResult.Text = StateService.Remove(stateId);
            StateService.ReadData(dgv);
            AutoFillStateId();
        }

        private void dgv_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            string selectedStateId = dgv.CurrentRow.Cells[0].Value.ToString();
            stateId = Convert.ToByte(selectedStateId);
        }

        private void AutoFillStateId()
        {
            txtStateId.Text = StateService.GetStateId().ToString();
        }
    }
}
