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

namespace MultipleChoiceQuestionGenerator
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            //CreateGrid();
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
            QuestionService.ReadData(dgv);
            txtQuesId.Text = QuestionService.GetQuestionId();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            Question objQues = new Question();
            objQues.QuestId = Convert.ToInt32(txtQuesId.Text);
            objQues.Subject = cboSubject.Text;
            objQues.Quest = txtQuest.Text;
            objQues.AnswerA = txtAnsA.Text;
            objQues.AnswerB = txtAnsB.Text;
            objQues.AnswerC = txtAnsC.Text;
            objQues.CorrectAnswer = (rdoA.Checked) ? "A" : 
                (rdoB.Checked) ? "B" : "C";

            QuestionService.AddQuesiton(objQues);

            QuestionService.ReadData(dgv);
            txtQuesId.Text  = QuestionService.GetQuestionId();
        }

        private void btnSubject_Click(object sender, EventArgs e)
        {
            frmSubject frm = new frmSubject();
            frm.ShowDialog();
        }

        private void btnGrade_Click(object sender, EventArgs e)
        {
            frmGrade frm = new frmGrade();
            frm.ShowDialog();
        }
    }
}
