using Microsoft.EntityFrameworkCore;
using System;
using TaskManager.DAL.Context;
using TaskManager.DAL.Repository.Abstract;
using TaskManager.DAL.Repository.Abstract.AbstractsForConcrete;
using TaskManager.DAL.Repository.Concrete;

namespace TaskManager.DAL.Repository
{
    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        private bool disposed = false;
        private IUsersRepo _usersRepo;
        private IGroupsRepo _groupsRepo;
        private ITasksRepo _tasksRepo;
        private IUserGroupsRepo _userGroupsRepo;
        private readonly DbContext _context;
        private static readonly IUnitOfWork _unitOfWork = new UnitOfWork();

        private UnitOfWork()
        {
            _context = new TaskManagerContext();
        }

        public IUsersRepo UsersRepo
        {
            get
            {
                if (_usersRepo == null)
                {
                    _usersRepo = new UsersRepo(_context);
                }

                return _usersRepo;
            }
        }

        public IGroupsRepo GroupsRepo
        {
            get
            {
                if (_groupsRepo == null)
                {
                    _groupsRepo = new GroupsRepo(_context);
                }

                return _groupsRepo;
            }
        }

        public ITasksRepo TasksRepo
        {
            get
            {
                if (_tasksRepo == null)
                {
                    _tasksRepo = new TasksRepo(_context);
                }

                return _tasksRepo;
            }
        }

        public IUserGroupsRepo UserGroupsRepo
        {
            get
            {
                if (_userGroupsRepo == null)
                {
                    _userGroupsRepo = new UserGroupsRepo(_context);
                }

                return _userGroupsRepo;
            }
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!disposed)
            {
                if (disposing)
                {
                    _context.Dispose();
                }

                // Note disposing has been done.
                disposed = true;
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }

        public static IUnitOfWork GetUnit()
        {
            return _unitOfWork;
        }

        ~UnitOfWork()
        {
            Dispose(false);
        }
    }
}
