using MultipleChoiceQuestionGenerator.Common;
using MultipleChoiceQuestionGenerator.Model;
using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultipleChoiceQuestionGenerator.Data
{
    public class QuestionData : IGenericCrudByIntegerKey<Question>
    {
        public void Add(Question entity)
        {
            string insertQuery = "INSERT INTO [Question] (Quest, AnswerA, AnswerB, AnswerC, CorrectAnswer, SubjectId) Values('" + entity.Quest + "','" + entity.AnswerA + "','" + entity.AnswerB + "','" + entity.AnswerC + "','" + entity.CorrectAnswer + "'," + entity.SubjectId + ")";
            Com.modSetData(insertQuery);
        }

        public void Delete(Question entity)
        {
            string deleteQuery = "DELETE * FROM [Question] WHERE QuestId=" + entity.QuestId + ";";
            Com.modSetData(deleteQuery);
        }

        public void Edit(int id, Question entity)
        {
            string editQuery = "UPDATE [Question] SET(Quest='" + entity.Quest + "', AnswerA='" + entity.AnswerA + "',AnswerB='" + entity.AnswerB + "',AnswerC='" + entity.AnswerC + "',CorrectAnswer='" + entity.CorrectAnswer + "',SubjectId=" + entity.SubjectId + ") WHERE QuestId=" + id + ";";
            Com.modSetData(editQuery);
        }

        public IEnumerable<Question> GetAll()
        {
            string selectQuery = "SELECT * FROM [Question]";
            OleDbDataReader rstauto = Com.modGetDataReader(selectQuery);
            List<Question> lst = new List<Question>();
            if (rstauto.HasRows)
            {
                rstauto.Read();
                do
                {
                    Question quest = new Question
                    {
                        QuestId = Convert.ToInt32(rstauto[0]),
                        Quest = rstauto[1].ToString(),
                        AnswerA = rstauto[2].ToString(),
                        AnswerB = rstauto[3].ToString(),
                        AnswerC = rstauto[4].ToString(),
                        CorrectAnswer = Convert.ToChar(rstauto[5]),
                        SubjectId = Convert.ToInt32(rstauto[6])
                    };
                    lst.Add(quest);
                } while (rstauto.Read());
                rstauto.Close();
            }

            return lst.ToList();
        }

        public Question GetById(int id)
        {
            Question quest = new Question();
            string selectQuery = "SELECT * FROM Question WHERE QuestId=" + id + ";";
            OleDbDataReader rstauto = Com.modGetDataReader(selectQuery);
            if (rstauto.HasRows)
            {
                while (rstauto.Read())
                {
                    quest.QuestId = Convert.ToInt32(rstauto[0]);
                    quest.Quest = rstauto[1].ToString();
                    quest.AnswerA = rstauto[2].ToString();
                    quest.AnswerB = rstauto[3].ToString();
                    quest.AnswerC = rstauto[4].ToString();
                    quest.CorrectAnswer = Convert.ToChar(rstauto[5]);
                    quest.SubjectId = Convert.ToInt32(rstauto[6]);
                    break;
                }

                rstauto.Close();
            }

            return quest;
        }
    }
}
