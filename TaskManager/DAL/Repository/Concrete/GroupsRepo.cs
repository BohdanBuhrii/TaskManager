using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using TaskManager.DAL.Models;
using TaskManager.DAL.Repository.Abstract.AbstractsForConcrete;

namespace TaskManager.DAL.Repository.Concrete
{
    public class GroupsRepo : Repository<Group>, IGroupsRepo
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="GroupsRepo"/> class.
        /// </summary>
        /// <param name="context">Database context. </param>
        public GroupsRepo(DbContext context) : base(context) { }

        /// <inheritdoc/>
        public override Group GetByKey(int key)
        {
            return _entities.Include(g => g.Tasks).Include(g => g.UserGroups).SingleOrDefault(g => g.Id == key);
        }

        /// <inheritdoc/>
        public override IEnumerable<Group> Get(Expression<Func<Group, bool>> predicate)
        {
            return _entities.Where(predicate).Include(e => e.Tasks).Include(e => e.UserGroups).ThenInclude(ug => ug.User).AsNoTracking();
        }

        /// <inheritdoc/>
        public override IEnumerable<Group> GetAll()
        {
            return _entities.Include(e => e.Tasks).Include(e => e.UserGroups).ThenInclude(ug => ug.User).AsNoTracking().ToList();
        }
    }
}
