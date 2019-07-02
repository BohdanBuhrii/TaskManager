using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using TaskManager.DAL.Models;
using TaskManager.DAL.Repository.Abstract.AbstrctsForConcrete;

namespace TaskManager.DAL.Repository.Concrete
{
    public class GroupsRepo : Repository<Group>, IGroupsRepo
    {
        public GroupsRepo(DbContext context) : base(context) { }

        public override IEnumerable<Group> Get(Expression<Func<Group, bool>> predicate)
        {
            return _entities.Where(predicate).Include(e => e.Tasks).Include(e => e.UserGroups).ThenInclude(ug => ug.User);
        }

        public override IEnumerable<Group> GetAll()
        {
            return _entities.Include(e => e.Tasks).Include(e => e.UserGroups).ThenInclude(ug => ug.User).ToList();
        } 
    }
}
