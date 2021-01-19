using MultipleChoiceQuestionGenerator.Data;
using MultipleChoiceQuestionGenerator.Service;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MultipleChoiceQuestionGenerator.UI
{
    public partial class frmGrade : Form
    {
        public frmGrade()
        {
            InitializeComponent();
        }

        int id = 0;
        private void CreateGrid()
        {
            DataGridViewCellStyle coloumHeader = new DataGridViewCellStyle();
            coloumHeader.BackColor = Color.AliceBlue;
            coloumHeader.Font = new Font("Pyidaungsu", 10.2F, System.Drawing.FontStyle.Bold);
            dgv.ColumnHeadersDefaultCellStyle = coloumHeader;
            dgv.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgv.AllowUserToAddRows = false;
            dgv.RowHeadersVisible = false;
            dgv.ColumnCount = 2;

            dgv.Columns[0].HeaderText = "Id";
            dgv.Columns[0].Visible = true;
            dgv.Columns[0].Width = 65;
            dgv.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

            dgv.Columns[1].HeaderText = "Name";
            dgv.Columns[1].Visible = true;
            dgv.Columns[1].Width = 450;
        }

        private void frmGrade_Load(object sender, EventArgs e)
        {
            lblMessage.Text = "";
            CreateGrid();
            txtId.Text = GenericGradeService.GetGradeId();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            Grade grade = new Grade
            {
                GradeId = Convert.ToInt32(txtId.Text),
                Name = txtName.Text
            };

            GenericGradeService.AddGrade(grade);
            GenericGradeService.ReadData(dgv);
            txtId.Text = GenericGradeService.GetGradeId();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            GenericGradeService.DeleteGrade(id);
            GenericGradeService.ReadData(dgv);
            txtId.Text = GenericGradeService.GetGradeId();
        }

        private void dgv_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            id = 0;
            if(dgv.Rows.Count >0)
            {
                id = Convert.ToInt32(dgv.CurrentRow.Cells[0].Value);
            }
        }
    }
}
