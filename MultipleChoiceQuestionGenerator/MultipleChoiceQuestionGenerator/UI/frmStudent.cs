using MultipleChoiceQuestionGenerator.Data;
using MultipleChoiceQuestionGenerator.Model;
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
    public partial class frmStudent : Form
    {
        List<Grade> _lstGrade = new List<Grade>();
        public frmStudent()
        {
            InitializeComponent();
        }

        public static void FillStateComboBox(ComboBox cbo, List<Grade> lst)
        {
            if (lst.Count > 0)
            {
                Dictionary<int, string> cboSource = new Dictionary<int, string>();
                foreach (Grade item in lst)
                {
                    cboSource.Add(item.GradeId, item.Name);
                }

                cbo.DataSource = new BindingSource(cboSource, null);
                cbo.DisplayMember = "Value";
                cbo.ValueMember = "Key";
            }
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
            dgv.ColumnCount = 4;

            dgv.Columns[0].HeaderText = "Id";
            dgv.Columns[0].Visible = true;
            dgv.Columns[0].Width = 65;
            dgv.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

            dgv.Columns[1].HeaderText = "Name";
            dgv.Columns[1].Visible = true;
            dgv.Columns[1].Width = 250;

            dgv.Columns[2].HeaderText = "Result";
            dgv.Columns[2].Visible = true;
            dgv.Columns[2].Width = 250;

            dgv.Columns[3].HeaderText = "Grade";
            dgv.Columns[3].Visible = true;
            dgv.Columns[3].Width = 250;
        }
        private void frmStudent_Load(object sender, EventArgs e)
        {
            lblMessage.Text = "";
            CreateGrid();
            var lstGrade = GradeServiceTwo.service.GetAll();
            if(lstGrade != null)
            {
                _lstGrade = lstGrade.ToList();
            }
            FillStateComboBox(cboGrade, _lstGrade);
            txtId.Text = GetId();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            Student stu = new Student
            {
                StudentId = Convert.ToInt32(txtId.Text),
                Name = txtName.Text,
                Result = 0,
                GradeId = Convert.ToInt32(cboGrade.SelectedValue)
            };

            StudentService.service.Add(stu);
            ReadData(dgv);
            txtId.Text = GetId();
        }

        private static string GetId()
        {
            Student grade = StudentService.service.GetAll().LastOrDefault();
            if (grade == null)
            {
                return "1";
            }
            else
            {
                return (grade.StudentId + 1).ToString();
            }
        }


        private static void ReadData(DataGridView dgv)
        {
            List<Student> _lst = StudentService.service.GetAll().ToList();
            if (_lst != null)
            {
                dgv.Rows.Clear();
                foreach (var item in _lst)
                {
                    string[] row = new string[]
                    {
                    item.StudentId.ToString(),
                    item.Name,
                    item.Result.ToString(),
					GradeServiceTwo.service.GetById(item.GradeId).Name,
                    };
                    dgv.Rows.Add(row);
                }
            }
        }

        private void dgv_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            id = 0;
            if (dgv.Rows.Count > 0)
            {
                id = Convert.ToInt32(dgv.CurrentRow.Cells[0].Value);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            Student student = StudentService.service.GetById(id);
            StudentService.service.Delete(student);
            ReadData(dgv);
            txtId.Text = GetId();
        }
    }
}
