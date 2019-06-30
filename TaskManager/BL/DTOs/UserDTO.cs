using System;
using System.Collections.Generic;
using System.Text;

namespace TaskManager.BL.DTOs
{
    public class UserDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public ICollection<GroupDTO> Groups { get; set; }
        public ICollection<TaskDTO> Tasks { get; set; }
    }
}
