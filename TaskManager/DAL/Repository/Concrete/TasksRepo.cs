using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using TaskManager.DAL.Models;
using TaskManager.DAL.Repository.Abstract.AbstractsForConcrete;

namespace TaskManager.DAL.Repository.Concrete
{
    public class TasksRepo : Repository<Task>, ITasksRepo
    {
        public TasksRepo(DbContext context) : base(context) { }

        public override Task GetByKey(int key)
        {
            return _entities.Include(t => t.Publisher).Include(t => t.Group).SingleOrDefault(t => t.Id==key);
        }

        public override IEnumerable<Task> Get(Expression<Func<Task, bool>> predicate)
        {
            return _entities.Where(predicate).Include(e => e.Group).Include(e => e.Publisher).AsNoTracking();
        }

        public override IEnumerable<Task> GetAll()
        {
            return _entities.Include(e => e.Group).Include(e => e.Publisher).AsNoTracking().ToList();
        }
    }
}
