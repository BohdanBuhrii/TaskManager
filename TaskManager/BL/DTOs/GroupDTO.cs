using System;
using System.Collections.Generic;
using System.Text;

namespace TaskManager.BL.DTOs
{
    public class GroupDTO
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public List<UserDTO> Users { get; set; }
        public List<TaskDTO> Tasks { get; set; }
    }
}
