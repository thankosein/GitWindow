using MultipleChoiceQuestionGenerator.Common;
using MultipleChoiceQuestionGenerator.Data;
using MultipleChoiceQuestionGenerator.Model;

namespace MultipleChoiceQuestionGenerator.Service
{
    public static class StudentService
    {
        public static GenericCrudByIntegerKey<Student> service;
        static StudentService()
        {
            service = new GenericCrudByIntegerKey<Student>(new StudentCrud());
        }
    }
}
