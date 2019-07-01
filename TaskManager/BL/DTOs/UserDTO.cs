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
        public List<GroupDTO> Groups { get; set; }
        public List<TaskDTO> Tasks { get; set; }
    }
}
