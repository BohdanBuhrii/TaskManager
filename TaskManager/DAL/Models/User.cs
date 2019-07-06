using System.Collections.Generic;

namespace TaskManager.DAL.Models
{
    /// <summary>
    /// Defines entity User.
    /// </summary>
    public class User
    {
        /// <summary>
        /// Gets or sets primary Key.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets user's name.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets user's email.
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        /// Gets or sets user's password in hashed form.
        /// </summary>
        public string HashPassword { get; set; }

        /// <summary>
        /// Gets or sets collection of User - Group pairs.
        /// </summary>
        public ICollection<UserGroup> UserGroups { get; set; }

        /// <summary>
        /// Gets or sets collection of tasks created by this user.
        /// </summary>
        public ICollection<Task> Tasks { get; set; }
    }
}
