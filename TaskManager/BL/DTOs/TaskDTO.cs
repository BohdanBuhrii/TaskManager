using System;

namespace TaskManager.BL.DTOs
{
    public class TaskDTO
    {
        public int Id { get; set; }

        public string Content { get; set; }

        public DateTime PublicationDate { get; set; }

        public bool IsDone { get; set; }

        public string PublisherName { get; set; }

        public string GroupTitle { get; set; }
    }
}
