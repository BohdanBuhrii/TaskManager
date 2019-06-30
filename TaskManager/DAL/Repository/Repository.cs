using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using TaskManager.DAL.Repository.Abstract;

namespace TaskManager.DAL.Repository
{
    public class Repository<T> : IRepository<T> where T : class
    {
        protected readonly DbSet<T> _entities;

        public Repository(DbContext dbContext)
        {
            _entities = dbContext.Set<T>();
        }

        public virtual IEnumerable<T> Get(Expression<Func<T, bool>> predicate)
        {
            return _entities.Where(predicate);
        }

        public virtual IEnumerable<T> GetAll()
        {
            return _entities.ToList();
        }

        public virtual void Add(T entity)
        {
            _entities.Add(entity);
        }

        public virtual void AddRange(IEnumerable<T> entities)
        {
            _entities.AddRange(entities);
        }

        public virtual void Delete(T entity)
        {
            _entities.Remove(entity);
        }

        public virtual void DeleteRange(IEnumerable<T> entities)
        {
            _entities.RemoveRange(entities);
        }


        public virtual void Update(T entity)
        {
            throw new NotImplementedException();
        }
    }
}
