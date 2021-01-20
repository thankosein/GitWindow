using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultipleChoiceQuestionGenerator.Common
{
    public interface IGenericCrudByStringKey<T> : IGenericCrud<T>
    {
        T GetById(string id);
    }
}
