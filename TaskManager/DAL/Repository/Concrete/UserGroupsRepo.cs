

using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using TaskManager.DAL.Models;
using TaskManager.DAL.Repository.Abstract.AbstractsForConcrete;

namespace TaskManager.DAL.Repository.Concrete
{
    public class UserGroupsRepo : Repository<UserGroup>, IUserGroupsRepo
    {
        public UserGroupsRepo(DbContext context) : base(context) { }

        
        public override IEnumerable<UserGroup> Get(Expression<Func<UserGroup, bool>> predicate)
        {
            return _entities.Where(predicate).Include(ug => ug.Group).Include(ug => ug.User).AsNoTracking();
        }

        public override IEnumerable<UserGroup> GetAll()
        {
            return _entities.Include(ug => ug.Group).Include(ug => ug.User).AsNoTracking().ToList();
        }
    }
}
