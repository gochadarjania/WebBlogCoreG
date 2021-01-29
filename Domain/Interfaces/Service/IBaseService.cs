using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Domain.Interfaces.Service
{
    public interface IBaseService<T> where T : class
    {
        void Add(T obj);
        T Find(object id);
        IQueryable<T> Set();
        void Remove(T item);
        void Commit();
    }
}
