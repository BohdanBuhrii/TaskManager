using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using TaskManager.DAL.Models;
using TaskManager.DAL.Repository.Abstract.AbstrctsForConcrete;

namespace TaskManager.DAL.Repository.Concrete
{
    public class UsersRepo : Repository<User>, IUsersRepo
    {
        public UsersRepo(DbContext context) : base(context) { }

        public override IEnumerable<User> Get(Expression<Func<User, bool>> predicate)
        {
            return _entities.Where(predicate).Include(e => e.Tasks).Include(e => e.UserGroups).ThenInclude(ug => ug.Group);
        }

        public override IEnumerable<User> GetAll()
        {
            return _entities.Include(e => e.Tasks).Include(e => e.UserGroups).ThenInclude(ug => ug.Group).ToList();
        }

        public User GetByEmail(string email)
        {
            return this.Get(u=>u.Email==email).FirstOrDefault();
        }
    }
}
