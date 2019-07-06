using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace TaskManager.DAL.Repository.Abstract
{
    /// <summary>
    /// Generic interface for repository.
    /// </summary>
    /// <typeparam name="T"> Database entity. </typeparam>
    public interface IRepository<T> where T : class
    {
        /// <summary>
        /// Gets entity by primary Key.
        /// </summary>
        /// <param name="key"> Primary Key. </param>
        /// <returns> Database entity. </returns>
        T GetByKey(int key);

        /// <summary>
        /// Get entities by LINQ expression.
        /// </summary>
        /// <param name="predicate"> LINQ expression. </param>
        /// <returns> Collection of entities. </returns>
        IEnumerable<T> Get(Expression<Func<T, bool>> predicate);

        /// <summary>
        /// Get all entities.
        /// </summary>
        /// <returns>Collection of entities. </returns>
        IEnumerable<T> GetAll();

        /// <summary>
        /// Add new entity to database.
        /// </summary>
        /// <param name="entity">Database entity. </param>
        void Add(T entity);

        /// <summary>
        /// Add range of new entities to database.
        /// </summary>
        /// <param name="entities"> Collection of database entities. </param>
        void AddRange(IEnumerable<T> entities);

        /// <summary>
        /// Delete entity from database.
        /// </summary>
        /// <param name="entity">Database entity.</param>
        void Delete(T entity);

        /// <summary>
        /// Delete range of entities from database.
        /// </summary>
        /// <param name="entities">Collection of database entities.</param>
        void DeleteRange(IEnumerable<T> entities);

        /// <summary>
        /// Update entity in database.
        /// </summary>
        /// <param name="entity"> Entity. </param>
        void Update(T entity);
    }
}
