using System;
using System.Collections.Generic;
using System.Text;

namespace TaskManager.BL.DTOs
{
    public class GroupDTO
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public ICollection<UserDTO> Users { get; set; }
        public ICollection<TaskDTO> Tasks { get; set; }
    }
}
