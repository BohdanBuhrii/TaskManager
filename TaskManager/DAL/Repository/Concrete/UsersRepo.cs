using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using TaskManager.DAL.Models;
using TaskManager.DAL.Repository.Abstract.AbstractsForConcrete;

namespace TaskManager.DAL.Repository.Concrete
{
    public class UsersRepo : Repository<User>, IUsersRepo
    {
        public UsersRepo(DbContext context) : base(context) { }

        /// <inheritdoc/>
        public override User GetByKey(int key)
        {
            return _entities.Include(u => u.Tasks).Include(u => u.UserGroups).ThenInclude(ug => ug.Group).AsNoTracking().SingleOrDefault(u => u.Id == key);
        }

        /// <inheritdoc/>
        public override IEnumerable<User> Get(Expression<Func<User, bool>> predicate)
        {
            return _entities.Where(predicate).Include(e => e.Tasks).Include(e => e.UserGroups).ThenInclude(ug => ug.Group).AsNoTracking();
        }

        /// <inheritdoc/>
        public override IEnumerable<User> GetAll()
        {
            return _entities.Include(e => e.Tasks).Include(e => e.UserGroups).ThenInclude(ug => ug.Group).AsNoTracking().ToList();
        }

        /// <inheritdoc/>
        public User GetByEmail(string email)
        {
            return this.Get(u => u.Email == email).FirstOrDefault();
        }
    }
}
