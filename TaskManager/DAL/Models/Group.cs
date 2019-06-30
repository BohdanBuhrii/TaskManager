using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskManager.DAL.Models
{
    public class Group
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public ICollection<UserGroup> UserGroups { get; set; }
        public ICollection<Task> Tasks { get; set; }
    }
}
