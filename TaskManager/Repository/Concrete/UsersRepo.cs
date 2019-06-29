using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using TaskManager.Models;
using TaskManager.Repository.Abstract.AbstrctsForConcrete;

namespace TaskManager.Repository.Concrete
{
    public class UsersRepo : Repository<User>, IUsersRepo
    {
        public UsersRepo(DbContext context) : base(context) { }

        public override IEnumerable<User> Get(Expression<Func<User, bool>> predicate)
        {
            return _entities.Where(predicate).Include(e => e.Groups).Include(e => e.Tasks);
        }

        public override IEnumerable<User> GetAll()
        {
            return _entities.Include(e => e.Groups).Include(e => e.Tasks).ToList();
        }
    }
}
