using Domain.Interfaces.Core;
using Domain.Interfaces.Repository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Repository
{
    public class BaseRepository<T> : IBaseRepository<T>
          where T : class
    {
        protected BlogDbContext _context;
        protected DbSet<T> _dbSet;

        public BaseRepository(BlogDbContext context)
        {
            _context = context;
            _dbSet = _context.Set<T>();

        }

        public IQueryable<T> Set()
        {
            return _dbSet;
        }

        public void Add(T obj)
        {
            _dbSet.Add(obj);
        }

        public void Remove(T item)
        {
            //_dbSet.Remove(item);
            if (item is IEntity) { (item as IEntity).SystemFields.IsDeleted = true; }            //else            //{            //    _dbSet.Remove(item);            //}
            //item.GetType().GetProperty("ID").SetValue(item, true);
            //_dbSet.Contains(item).GetType().GetProperty("ID").SetValue(item, true);
        }

        public T Find(object id)
        {
            return _dbSet.Find(id);
        }

        public void Commit()
        {
            _context.SaveChanges();
        }
    }
}
