namespace TaskManager.DAL.Models
{
    /// <summary>
    /// Class used for "many to many" relations between Users and Groups.
    /// Cosists of pair User - Group and Ids.
    /// </summary>
    public class UserGroup
    {
        /// <summary>
        /// Gets or sets user's Id (Foreign Key).
        /// </summary>
        public int UserId { get; set; }

        /// <summary>
        /// Gets or sets instance of User.
        /// </summary>
        public User User { get; set; }

        /// <summary>
        /// Gets or sets group's Id (Foreign Key).
        /// </summary>
        public int GroupId { get; set; }

        /// <summary>
        /// Gets or sets instance of Group.
        /// </summary>
        public Group Group { get; set; }
    }
}
