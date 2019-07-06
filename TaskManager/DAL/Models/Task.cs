using System;

namespace TaskManager.DAL.Models
{
    /// <summary>
    /// Defines entity Task.
    /// </summary>
    public class Task
    {
        /// <summary>
        /// Gets or sets primary Key.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets task's message.
        /// </summary>
        public string Content { get; set; }

        /// <summary>
        /// Gets or sets date when task was created.
        /// </summary>
        public DateTime PublicationDate { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether the task is done.
        /// </summary>
        public bool IsDone { get; set; }

        /// <summary>
        /// Gets or sets id of user who created this task.
        /// </summary>
        public int PublisherId { get; set; }

        /// <summary>
        /// Gets or sets user who created this task.
        /// </summary>
        public User Publisher { get; set; }

        /// <summary>
        /// Gets or sets  id of group for which this task was created.
        /// </summary>
        public int GroupId { get; set; }

        /// <summary>
        /// Gets or sets group for which this task was created.
        /// </summary>
        public Group Group { get; set; }
    }
}
