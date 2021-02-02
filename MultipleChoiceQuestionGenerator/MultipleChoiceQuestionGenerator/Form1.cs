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
            CreateGrid();
            Com.comboFillWithKey("SELECT SubjectId, Name FROM Subject ORDER BY Name;", cboSubject);

            
            txtQuesId.Text = QuestionService.GenerateId();
            QuestionService.ReadDataGrid(dgv);
            
        }

        private void btnSave_Click(object sender, EventArgs e)
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

            QuestionService.ReadDataGrid(dgv);
            txtQuesId.Text  = QuestionService.GenerateId();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            string strValue = cboSubject.SelectedValue.ToString();
            string strText = cboSubject.Text;

            MessageBox.Show(string.Format("value: {0} \n Text: {1}", strValue, strText));
        }

        private void ChangeReadOnly()
        {

        }
    }
}
