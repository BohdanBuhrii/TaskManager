using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManager.Models;

namespace TaskManager.Repository.Concrete
{
    public class UsersRepo : Repository<User>
    {
        public UsersRepo(DbContext context) : base(context) { }
    }
}
