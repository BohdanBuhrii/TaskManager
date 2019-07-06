using System.Collections.Generic;

namespace TaskManager.DAL.Models
{
    /// <summary>
    /// Defines entity Group.
    /// </summary>
    public class Group
    {
        /// <summary>
        /// Gets or sets primary Key.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets group's Title.
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// Gets or sets collection of User - Group pairs.
        /// </summary>
        public ICollection<UserGroup> UserGroups { get; set; }

        /// <summary>
        /// Gets or sets collection of current group's Tasks.
        /// </summary>
        public ICollection<Task> Tasks { get; set; }
    }
}
