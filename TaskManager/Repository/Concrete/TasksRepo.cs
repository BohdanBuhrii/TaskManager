using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using TaskManager.Models;

namespace TaskManager.Repository.Concrete
{
    public class TasksRepo : Repository<Task>
    {
        public TasksRepo(DbContext context) : base(context) { }
    }
}
