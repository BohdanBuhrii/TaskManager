using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using TaskManager.Models;

namespace TaskManager.Repository.Concrete
{
    public class UsersRepo : Repository<User>
    {
        public UsersRepo(DbContext context) : base(context) { }

        public override IEnumerable<User> Get(Expression<Func<User, bool>> predicate)
        {
            return _entities.Where(predicate).Include(e => e.Tasks).Include(e => e.Tasks);
        }

        public override IEnumerable<User> GetAll()
        {
            return _entities.Include(e => e.Tasks).Include(e => e.Tasks).ToList();
        }
    }
}
