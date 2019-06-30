using System;
using System.Collections.Generic;
using System.Text;

namespace TaskManager.BL.DTOs
{
    public class TaskDTO
    {
        public int Id { get; set; }
        public string Content { get; set; }
        public DateTime PublicationDate { get; set; }
        public bool IsDone { get; set; }
        public UserDTO Publisher { get; set; }
        public GroupDTO Group { get; set; }
    }
}
