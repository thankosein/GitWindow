using MultipleChoiceQuestionGenerator.Common;
using MultipleChoiceQuestionGenerator.Model;
using MultipleChoiceQuestionGenerator.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultipleChoiceQuestionGenerator.Data
{
    public class GradeCrud : IGenericCrudByIntegerKey<Grade>
    {
        List<Grade> _lst = GradeData.DataList;

        public void Add(Grade entity)
        {
            _lst.Add(entity);
        }

        public void Delete(Grade entity)
        {
            _lst.Remove(entity);
        }

        public void Edit(int id, Grade entity)
        {
            Grade g = _lst.Where(x => x.GradeId == id).FirstOrDefault();
            _lst.Remove(g);
            _lst.Add(entity);
        }

        public IEnumerable<Grade> GetAll()
        {
            return _lst.ToList();
        }

        public Grade GetById(int id)
        {
            return _lst.Where(x => x.GradeId == id).FirstOrDefault();
        }
    }
}
