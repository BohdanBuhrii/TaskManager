using System;
using TaskManager.DAL.Repository.Abstract.AbstrctsForConcrete;

namespace TaskManager.DAL.Repository.Abstract
{
    public interface IUnitOfWork : IDisposable
    {

        IUsersRepo UsersRepo { get; }

        IGroupsRepo GroupsRepo { get; }

        ITasksRepo TasksRepo { get; }

        void SaveChanges();

    }
}
