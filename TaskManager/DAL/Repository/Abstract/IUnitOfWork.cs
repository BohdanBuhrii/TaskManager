using System;
using TaskManager.DAL.Repository.Abstract.AbstractsForConcrete;

namespace TaskManager.DAL.Repository.Abstract
{
    /// <summary>
    /// Used to group one or more database operations into a single transaction,
    /// so that all operations either pass or fail as one.
    /// </summary>
    public interface IUnitOfWork : IDisposable
    {
        /// <summary>
        /// Gets repository with users.
        /// </summary>
        IUsersRepo UsersRepo { get; }

        /// <summary>
        /// Gets repository with groups.
        /// </summary>
        IGroupsRepo GroupsRepo { get; }

        /// <summary>
        /// Gets repository with tasks.
        /// </summary>
        ITasksRepo TasksRepo { get; }

        /// <summary>
        /// Gets repository with user-group pairs.
        /// </summary>
        IUserGroupsRepo UserGroupsRepo { get; }

        /// <summary>
        /// Save all changes made to the database.
        /// </summary>
        void SaveChanges();
    }
}
