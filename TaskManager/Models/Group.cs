using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskManager.Models
{
    public class Group
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public List<User> Users { get; set; }
    }
}
