using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultipleChoiceQuestionGenerator.Common
{
    public interface IGenericCrud<T>
    {
        void Add(T entity);        
        void Delete(T entity);
        IEnumerable<T> GetAll();     
    }
}
