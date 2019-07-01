using System.Collections.Generic;


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
