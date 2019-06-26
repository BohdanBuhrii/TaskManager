using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using TaskManager.Models;

namespace TaskManager.Repository.Concrete
{
    public class GroupsRepo : Repository<Group>
    {
        public GroupsRepo(DbContext context) : base(context) { }

        public override IEnumerable<Group> Get(Expression<Func<Group, bool>> predicate)
        {
            return _entities.Where(predicate).Include(e => e.Tasks).Include(e => e.Users);
        }

        public override IEnumerable<Group> GetAll()
        {
            return _entities.Include(e => e.Tasks).Include(e => e.Users).ToList();
        } 
    }
}
