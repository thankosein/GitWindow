using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultipleChoiceQuestionGenerator.Common
{
    public interface IGenericCrudByIntegerKey<T> : IGenericCrud<T>
    {
        void Edit(int id, T entity);
        T GetById(int id);
    }
}
