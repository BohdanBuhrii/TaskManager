using System;
using TaskManager.DAL.Repository.Abstract.AbstractsForConcrete;

namespace TaskManager.DAL.Repository.Abstract
{
    public interface IUnitOfWork : IDisposable
    {

        IUsersRepo UsersRepo { get; }

        IGroupsRepo GroupsRepo { get; }

        ITasksRepo TasksRepo { get; }

        IUserGroupsRepo UserGroupsRepo { get; }

        void SaveChanges();

    }
}
