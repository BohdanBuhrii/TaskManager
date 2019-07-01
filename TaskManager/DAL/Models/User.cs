using System.Collections.Generic;

namespace TaskManager.DAL.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string HashPassword { get; set; }
        public ICollection<UserGroup> UserGroups { get; set; }
        public ICollection<Task> Tasks { get; set; }
    }
}
