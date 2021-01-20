using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultipleChoiceQuestionGenerator.Common
{
    public class GenericCrudByIntegerKey<T> where T : new()
    {
        private IGenericCrudByIntegerKey<T> _crud;
        public GenericCrudByIntegerKey(IGenericCrudByIntegerKey<T> crud)
        {
            _crud = crud;
        }

        public void Add(T entity)
        {
            _crud.Add(entity);
        }

        public void Edit(int id, T entity)
        {
            T getEntity = _crud.GetById(id);
            _crud.Delete(getEntity);
            _crud.Add(entity);
        }

        public void Delete(T entity)
        {
            _crud.Delete(entity);
        }

        public IEnumerable<T> GetAll()
        {
            return _crud.GetAll();
        }

        public T GetById(int id)
        {
            return _crud.GetById(id);
        }
    }
}
