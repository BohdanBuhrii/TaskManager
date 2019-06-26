using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using TaskManager.Models;

namespace TaskManager.Repository.Concrete
{
    public class TasksRepo : Repository<Task>
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
