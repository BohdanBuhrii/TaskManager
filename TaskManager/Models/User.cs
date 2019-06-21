using System;
using System.Collections.Generic;
using System.Text;

namespace TaskManager.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string HashPassword { get; set; }
        public List<Group> Groups { get; set; }
    }
}
