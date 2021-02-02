using MultipleChoiceQuestionGenerator.Common;
using MultipleChoiceQuestionGenerator.Data;
using MultipleChoiceQuestionGenerator.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MultipleChoiceQuestionGenerator.Service
{
    public static class QuestionService
    {
        public static GenericCrudByIntegerKey<Question> service;
        public static GenericCrudByIntegerKey<Subject> SubjectService;


        static QuestionService()
        {
            service = new GenericCrudByIntegerKey<Question>(new QuestionData());
            SubjectService = new GenericCrudByIntegerKey<Subject>(new SubjectData());
        }

        public static void ReadDataGrid(DataGridView dgv)
        {
            dgv.Rows.Clear();
            List<Subject> lstSubject = SubjectService.GetAll().ToList();
            List<Question> lstQuestion = service.GetAll().ToList();
            foreach (var item in lstQuestion)
            {
                string[] row = new string[]
                {
                    item.QuestId.ToString(),
                    lstSubject.Where(x=>x.SubjectId.Equals(item.SubjectId)).FirstOrDefault().Name,
                    item.Quest,
                    item.AnswerA,
                    item.AnswerB,
                    item.AnswerC,
                    item.CorrectAnswer.ToString(),
                    
                };
                dgv.Rows.Add(row);
            }
        }

        public static string GenerateId()
        {
            List<Question> lstQuestion = service.GetAll().ToList();
            Question quest = lstQuestion.LastOrDefault();
            if (quest == null)
            {
                return "1";
            }
            else
            {
                return (quest.QuestId + 1).ToString();
            }
        }
    }
}
