using MultipleChoiceQuestionGenerator.Common;
using MultipleChoiceQuestionGenerator.Model;
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
    public partial class frmHome : Form
    {
        public frmHome()
        {
            InitializeComponent();
        }
        
        int quesConfigCount = 2;
        int getTheLastQuestionId = 0;
        private void aToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmSubject frm = new frmSubject();
            frm.ShowDialog();
        }

        private void setUpSubjectToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmSubject frm = new frmSubject();
            frm.ShowDialog();
        }

        private void questionsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form1 frm = new Form1();
            frm.MdiParent = this;
            frm.Show();
        }

        private void frmHome_Load(object sender, EventArgs e)
        {
            Com.MODopenDB();
        }

        Question entity = new Question();
        List<int> generatedQuestId = new List<int>();
        private void btnStart_Click(object sender, EventArgs e)
        {
            generatedQuestId.Clear();
            getTheLastQuestionId = Convert.ToInt32(QuestionService.GenerateId());
            GenerateQuestion();
        }

        private void GenerateQuestion()
        {
            Random rnd = new Random();
            for (int i = 0; i < getTheLastQuestionId; i++)
            {
                int randomQuestId = rnd.Next(1, getTheLastQuestionId - 1);

                bool tfHas = generatedQuestId.Contains(randomQuestId);
                if (tfHas)
                {
                    i--;
                }
                else
                {
                    entity = QuestionService.service.GetById(randomQuestId);

                    if (entity.QuestId > 0)
                    {
                        generatedQuestId.Add(randomQuestId);

                        txtQuest.Text = entity.Quest;
                        txtAnsA.Text = entity.AnswerA;
                        txtAnsB.Text = entity.AnswerB;
                        txtAnsC.Text = entity.AnswerC;
                        break;
                    }
                }
            }
        }

        private void btnAnsA_Click(object sender, EventArgs e)
        {            
            Button btn = (Button)sender;
            if (entity.CorrectAnswer.Equals(Convert.ToChar(btn.Text)))
            {
                MessageBox.Show("Correct");
            }            
            else
            {
                MessageBox.Show("Not Correct");
            }
            if(quesConfigCount > generatedQuestId.Count())
            {
                GenerateQuestion();
            }
            else
            {
                MessageBox.Show("End");
            }
        } 
    }
}
