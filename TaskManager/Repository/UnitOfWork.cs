﻿using System;
using System.Data.Entity;
using TaskManager.Context;
using TaskManager.Repository.Abstract;
using TaskManager.Repository.Abstract.AbstrctsForConcrete;
using TaskManager.Repository.Concrete;

namespace TaskManager.Repository
{
    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        private bool disposed = false;
        private UsersRepo _usersRepo;
        private GroupsRepo _groupsRepo;
        private TasksRepo _tasksRepo;
        private readonly DbContext _context;
        private static readonly UnitOfWork _unitOfWork = new UnitOfWork();


        private UnitOfWork()
        {
            _context = new TaskManagerContext();
        }


        public UsersRepo UsersRepo { get {
                if (_usersRepo == null) _usersRepo = new UsersRepo(_context);
                return _usersRepo; } }

        public GroupsRepo GroupsRepo { get {
                if (_groupsRepo == null) _groupsRepo = new GroupsRepo(_context);
                return _groupsRepo; } }

        public TasksRepo TasksRepo { get {
                if (_tasksRepo == null) _tasksRepo = new TasksRepo(_context);
                return _tasksRepo; } }


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

        public static UnitOfWork GetUnit()
        {
            return _unitOfWork;
        }

        
        ~UnitOfWork()
        {
            Dispose(false);
        }
    }
}
