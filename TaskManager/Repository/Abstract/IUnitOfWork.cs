using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManager.Repository.Abstract.AbstrctsForConcrete;

namespace TaskManager.Repository.Abstract
{
    public interface IUnitOfWork
    {

        IUsersRepo UsersRepo { get; }

        IGroupsRepo GroupsRepo { get; }

        ITasksRepo TasksRepo { get; }

        void SaveChanges();

    }
}
