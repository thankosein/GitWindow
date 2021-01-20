using MultipleChoiceQuestionGenerator.Common;
using MultipleChoiceQuestionGenerator.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultipleChoiceQuestionGenerator.Data
{
    class StudentCrud : IGenericCrudByIntegerKey<Student>
    {
        List<Student> _lst = StudentData.DataList;

        public void Add(Student entity)
        {
            _lst.Add(entity);
        }

        public void Delete(Student entity)
        {
            _lst.Remove(entity);
        }

        public void Edit(int id, Student entity)
        {
            Student g = _lst.Where(x => x.StudentId == id).FirstOrDefault();
            _lst.Remove(g);
            _lst.Add(entity);
        }

        public IEnumerable<Student> GetAll()
        {
            return _lst.ToList();
        }

        public Student GetById(int id)
        {
            return _lst.Where(x => x.StudentId == id).FirstOrDefault();
        }
    }
}
