using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace TaskManager.Repository.Abstract
{
    interface IRepository<T> where T : class
    {
        IEnumerable<T> Get(Expression<Func<T,bool>> predicate);

        IEnumerable<T> GetAll();

        void Add(T entity);

        void AddRange(IEnumerable<T> entites);

        void Delete(T entity);

        void DeleteRange(IEnumerable<T> entites);

        void Update(T entity);
    }
}
