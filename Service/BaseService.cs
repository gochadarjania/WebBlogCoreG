using Domain.Interfaces.Repository;
using Domain.Interfaces.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Service
{
    public class BaseService<T> : IBaseService<T> where T : class
    {
        protected IBaseRepository<T> _repository;
        public BaseService(IBaseRepository<T> repository)
        {
            _repository = repository;
        }

        public void Add(T obj)
        {
            _repository.Add(obj);
        }

        public void Commit()
        {
            _repository.Commit();
        }

        public T Find(object id)
        {
            return _repository.Find(id);
        }

        public void Remove(T item)
        {
            _repository.Remove(item);
        }

        public IQueryable<T> Set()
        {
            return _repository.Set();
        }
    }
}
