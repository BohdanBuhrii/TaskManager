using System;

namespace TaskManager.DAL.Models
{
    public class Task
    {
        public int Id { get; set; }
        public string Content { get; set; }
        public DateTime PublicationDate { get; set; }
        public bool IsDone { get; set; }
        public int PublisherId { get; set; }
        public User Publisher { get; set; }
        public int GroupId { get; set; }
        public Group Group { get; set; }
    }
}
