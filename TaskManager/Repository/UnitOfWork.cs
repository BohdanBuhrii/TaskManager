using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using TaskManager.Context;
using TaskManager.Models;
using TaskManager.Repository.Concrete;

namespace TaskManager.Repository
{
    public class UnitOfWork : IDisposable
    {
        private readonly DbContext context;
        //private Repository<User> _usersRepo;
        //private Repository<Group> _groupsRepo;
        //private Repository<Task> _tasksRepo;
        private UsersRepo _usersRepo;
        private GroupsRepo _groupsRepo;
        private TasksRepo _tasksRepo;
        private bool disposed = false;

        public UnitOfWork()
        {
            context = new TaskManagerContext();
        }

        public UsersRepo UsersRepo { get {
                if (_usersRepo == null) _usersRepo = new UsersRepo(context);//Repository<User>(context);
                return _usersRepo; } }

        public GroupsRepo GroupsRepo { get {
                if (_groupsRepo == null) _groupsRepo = new GroupsRepo(context); //Repository<Group>(context);
                return _groupsRepo; } }

        public TasksRepo TasksRepo { get {
                if (_tasksRepo == null) _tasksRepo = new TasksRepo(context);//Repository<Task>(context);
                return _tasksRepo; } }

        public void SaveChanges()
        {
            context.SaveChanges();
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!disposed)
            {
                if (disposing)
                {
                    context.Dispose();
                }

                // Note disposing has been done.
                disposed = true;
            }
        }

        ~UnitOfWork()
        {
            Dispose(false);
        }
    }
}
