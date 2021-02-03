using MultipleChoiceQuestionGenerator.Data;
using MultipleChoiceQuestionGenerator.Service;
using MultipleChoiceQuestionGenerator.UI;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MultipleChoiceQuestionGenerator.Common;
using MultipleChoiceQuestionGenerator.Model;

namespace MultipleChoiceQuestionGenerator
{
    public partial class Form1 : Form
    {
        int? questId;
        bool tfNew = false;

        public Form1()
        {
            InitializeComponent();

        }

        private void CreateGrid()
        {
            DataGridViewCellStyle coloumHeader = new DataGridViewCellStyle();
            coloumHeader.BackColor = Color.AliceBlue;
            coloumHeader.Font = new Font("Pyidaungsu", 10.2F, System.Drawing.FontStyle.Bold);
            dgv.ColumnHeadersDefaultCellStyle = coloumHeader;
            dgv.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgv.AllowUserToAddRows = false;
            dgv.ReadOnly = true;
            dgv.RowHeadersVisible = false;
            dgv.ColumnCount = 7;

            dgv.Columns[0].HeaderText = "QuestId";
            dgv.Columns[0].Visible = true;
            dgv.Columns[0].Width = 65;

            dgv.Columns[1].HeaderText = "Subject";
            dgv.Columns[1].Visible = true;
            dgv.Columns[1].Width = 100;

            dgv.Columns[2].HeaderText = "Ques";
            dgv.Columns[2].Visible = true;
            dgv.Columns[2].Width = 310;

            dgv.Columns[3].HeaderText = "A";
            dgv.Columns[3].Visible = true;
            dgv.Columns[3].Width = 310;

            dgv.Columns[4].HeaderText = "B";
            dgv.Columns[4].Visible = true;
            dgv.Columns[4].Width = 310;

            dgv.Columns[5].HeaderText = "C";
            dgv.Columns[5].Visible = true;
            dgv.Columns[5].Width = 310;

            dgv.Columns[6].HeaderText = "Answer";
            dgv.Columns[6].Visible = true;
            dgv.Columns[6].Width = 80;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            InitState();
            CreateGrid();
            Com.comboFillWithKey("SELECT SubjectId, Name FROM Subject ORDER BY Name;", cboSubject);

            QuestionService.ReadDataGrid(dgv);
            BindForm();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (tfNew)
            {
                Question objQuestion = new Question();
                objQuestion.QuestId = Convert.ToInt32(txtQuesId.Text);
                objQuestion.SubjectId = Convert.ToInt32(cboSubject.SelectedValue);
                objQuestion.Quest = txtQuest.Text;
                objQuestion.AnswerA = txtAnsA.Text;
                objQuestion.AnswerB = txtAnsB.Text;
                objQuestion.AnswerC = txtAnsC.Text;
                objQuestion.CorrectAnswer = (rdoA.Checked) ? 'A' :
                    (rdoB.Checked) ? 'B' : 'C';
                QuestionService.service.Add(objQuestion);

                MessageBox.Show("Successfully Saved.");
            }
            else
            {
                if (questId != null)
                {
                    Question objQuestion = new Question();
                    objQuestion.QuestId = Convert.ToInt32(txtQuesId.Text);
                    objQuestion.SubjectId = Convert.ToInt32(cboSubject.SelectedValue);
                    objQuestion.Quest = txtQuest.Text;
                    objQuestion.AnswerA = txtAnsA.Text;
                    objQuestion.AnswerB = txtAnsB.Text;
                    objQuestion.AnswerC = txtAnsC.Text;
                    objQuestion.CorrectAnswer = (rdoA.Checked) ? 'A' :
                        (rdoB.Checked) ? 'B' : 'C';

                    QuestionService.service.Edit(Convert.ToInt32(questId), objQuestion);
                    MessageBox.Show("Successfully Updated.");

                }
            }

            QuestionService.ReadDataGrid(dgv);
            BindForm();
            InitState();
            tfNew = false;
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (questId != null)
            {
                Question entity = QuestionService.service.GetById(Convert.ToInt32(questId));
                QuestionService.service.Delete(entity);
                QuestionService.ReadDataGrid(dgv);                
                BindForm();
                InitState();
                MessageBox.Show("Successfully Deleted.");

            }
            else
            {
                MessageBox.Show("No record selected.");
            }
        }

        private void ChangeReadOnly()
        {

        }

        private void dgv_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgv.SelectedRows.Count > 0)
            {
                questId = Convert.ToInt32(dgv.CurrentRow.Cells[0].Value);
                BindForm();
            }
        }

        private void ClearForm()
        {
            txtQuesId.Text = "";
            txtQuest.Text = "";
            txtAnsA.Text = "";
            txtAnsB.Text = "";
            txtAnsC.Text = "";
            cboSubject.SelectedIndex = 0;

        }

        private void InitState()
        {
            txtAnsA.ReadOnly = true;
            txtAnsB.ReadOnly = true;
            txtAnsC.ReadOnly = true;
            txtQuest.ReadOnly = true;
            cboSubject.Enabled = false;
            rdoA.Enabled = false;
            rdoB.Enabled = false;
            rdoC.Enabled = false;

            btnNew.Enabled = true;
            btnEdit.Enabled = true;
            btnSave.Enabled = false;
            btnDelete.Enabled = false;
            btnCancel.Enabled = false;
        }

        private void NewAndEditState()
        {
            txtAnsA.ReadOnly = false;
            txtAnsB.ReadOnly = false;
            txtAnsC.ReadOnly = false;
            txtQuest.ReadOnly = false;
            cboSubject.Enabled = true;
            rdoA.Enabled = true;
            rdoB.Enabled = true;
            rdoC.Enabled = true;

            btnEdit.Enabled = false;
            btnNew.Enabled = false;
            btnSave.Enabled = true;
            btnDelete.Enabled = true;
            btnCancel.Enabled = true;
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            tfNew = true;
            NewAndEditState();
            btnDelete.Enabled = false;
            ClearForm();
            txtQuesId.Text = QuestionService.GenerateId();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            InitState();
            BindForm();
        }

        private void BindForm()
        {
            if (dgv.SelectedRows.Count > 0)
            {
                txtQuesId.Text = dgv.CurrentRow.Cells[0].Value.ToString();
                cboSubject.Text = dgv.CurrentRow.Cells[1].Value.ToString();
                txtQuest.Text = dgv.CurrentRow.Cells[2].Value.ToString();
                txtAnsA.Text = dgv.CurrentRow.Cells[3].Value.ToString();
                txtAnsB.Text = dgv.CurrentRow.Cells[4].Value.ToString();
                txtAnsC.Text = dgv.CurrentRow.Cells[5].Value.ToString();
                if (dgv.CurrentRow.Cells[6].Value.ToString() == "A")
                {
                    rdoA.Checked = true;
                }
                else if (dgv.CurrentRow.Cells[6].Value.ToString() == "A")
                {
                    rdoB.Checked = true;
                }
                else
                {
                    rdoC.Checked = true;
                }
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            tfNew = false;
            NewAndEditState();
            questId = Convert.ToInt32(txtQuesId.Text);
        }
    }
}
