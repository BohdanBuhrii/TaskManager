using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using TaskManager.Models;

namespace TaskManager.Repository
{
    public class UnitOfWork : IDisposable
    {
        private readonly DbContext context;
        private Repository<User> _usersRepo;
        private Repository<Group> _groupsRepo;
        private Repository<Task> _tasksRepo;
        private bool disposed = false;

        public Repository<User> UsersRepo { get {
                if (_usersRepo == null) _usersRepo = new Repository<User>(context);
                return _usersRepo; } }

        public Repository<Group> GroupsRepo { get {
                if (_groupsRepo == null) _groupsRepo = new Repository<Group>(context);
                return _groupsRepo; } }

        public Repository<Task> TasksRepo { get {
                if (_tasksRepo == null) _tasksRepo = new Repository<Task>(context);
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
