using MultipleChoiceQuestionGenerator.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultipleChoiceQuestionGenerator.Service
{
    public class GenericClass<T>
    {
        public List<T> lst;

        public GenericClass(List<T> lst)
        {
            this.lst = lst;
        }

        public string AddGeneric(T t)
        {   
            lst.Add(t);
            return "Successfully Added";
        }

        public string RemoveGeneric(T t)
        {
            lst.Remove(t);
            return "Successfully removed";
        }

        public string EditGeneric(T t, T n)
        {
            if(n.Equals(t))
            {
                return "All data are the same.";
            }
            lst.Remove(t);
            lst.Add(n);

            return "Successfully edited";
        }

        public List<T> ReadGeneric(List<T> lst)
        {
            return lst.ToList();
        }
    }
}
