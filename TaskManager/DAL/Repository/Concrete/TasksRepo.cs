using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using TaskManager.DAL.Models;
using TaskManager.DAL.Repository.Abstract.AbstrctsForConcrete;

namespace TaskManager.DAL.Repository.Concrete
{
    public class TasksRepo : Repository<Task>, ITasksRepo
    {
        public TasksRepo(DbContext context) : base(context) { }

        public override IEnumerable<Task> Get(Expression<Func<Task, bool>> predicate)
        {
            return _entities.Where(predicate).Include(e => e.Group).Include(e => e.Publisher);
        }

        public override IEnumerable<Task> GetAll()
        {
            return _entities.Include(e => e.Group).Include(e => e.Publisher).ToList();
        }
    }
}
