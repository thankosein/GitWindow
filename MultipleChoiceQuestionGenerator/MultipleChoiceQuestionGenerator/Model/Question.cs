using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultipleChoiceQuestionGenerator.Model
{
    public class Question
    {
        public int QuestId { get; set; }
        public string Quest { get; set; }
        public string AnswerA { get; set; }
        public string AnswerB { get; set; }
        public string AnswerC { get; set; }
        public char CorrectAnswer { get; set; }
        public int SubjectId { get; set; }
    }
}
