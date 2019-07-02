using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace TaskManager.DAL.Repository.Abstract
{
    public interface IRepository<T> where T : class
    {
        T GetByKey(object key);

        IEnumerable<T> Get(Expression<Func<T,bool>> predicate);

        IEnumerable<T> GetAll();

        void Add(T entity);

        void AddRange(IEnumerable<T> entites);

        void Delete(T entity);

        void DeleteRange(IEnumerable<T> entites);

        void Update(T entity);
    }
}
