using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using TaskManager.DAL.Repository.Abstract;

namespace TaskManager.DAL.Repository
{
    /// <summary>
    /// Implements generic repository interface.
    /// </summary>
    /// <typeparam name="T">Database entity. </typeparam>
    public class Repository<T> : IRepository<T> where T : class
    {
        /// <summary>
        /// Set of database entities.
        /// </summary>
        protected readonly DbSet<T> _entities;

        /// <summary>
        /// Initializes a new instance of the <see cref="Repository{T}"/> class.
        /// </summary>
        /// <param name="dbContext">Database context. </param>
        public Repository(DbContext dbContext)
        {
            _entities = dbContext.Set<T>();
        }

        /// <summary>
        /// Gets entity by primary Key.
        /// </summary>
        /// <param name="key"> Primary Key. </param>
        /// <returns> Database entity. </returns>
        public virtual T GetByKey(int key)
        {
            return _entities.Find(key);
        }

        /// <summary>
        /// Get entities by LINQ expression.
        /// </summary>
        /// <param name="predicate"> LINQ expression. </param>
        /// <returns> Collection of entities. </returns>
        public virtual IEnumerable<T> Get(Expression<Func<T, bool>> predicate)
        {
            return _entities.Where(predicate).AsNoTracking();
        }

        /// <summary>
        /// Get all entities.
        /// </summary>
        /// <returns>Collection of entities. </returns>
        public virtual IEnumerable<T> GetAll()
        {
            return _entities.AsNoTracking().ToList();
        }

        /// <summary>
        /// Add new entity to database.
        /// </summary>
        /// <param name="entity">Database entity. </param>
        public virtual void Add(T entity)
        {
            _entities.Add(entity);
        }

        /// <summary>
        /// Add range of new entities to database.
        /// </summary>
        /// <param name="entities"> Collection of database entities. </param>
        public virtual void AddRange(IEnumerable<T> entities)
        {
            _entities.AddRange(entities);
        }

        /// <summary>
        /// Delete entity from database.
        /// </summary>
        /// <param name="entity">Database entity.</param>
        public virtual void Delete(T entity)
        {
            _entities.Remove(entity);
        }

        /// <summary>
        /// Delete range of entities from database.
        /// </summary>
        /// <param name="entities">Collection of database entities.</param>
        public virtual void DeleteRange(IEnumerable<T> entities)
        {
            _entities.RemoveRange(entities);
        }

        /// <summary>
        /// Update entity in database.
        /// </summary>
        /// <param name="entity"> Entity. </param>
        public virtual void Update(T entity)
        {
            _entities.Update(entity);
        }
    }
}
