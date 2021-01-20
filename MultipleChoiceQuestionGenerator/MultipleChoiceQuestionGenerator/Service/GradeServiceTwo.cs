using MultipleChoiceQuestionGenerator.Common;
using MultipleChoiceQuestionGenerator.Data;
using MultipleChoiceQuestionGenerator.Model;

namespace MultipleChoiceQuestionGenerator.Service
{
    public static class GradeServiceTwo
    {
        public static GenericCrudByIntegerKey<Grade> service;
        static GradeServiceTwo()
        {
            service = new GenericCrudByIntegerKey<Grade>(new GradeCrud());
        }
    }    
}
