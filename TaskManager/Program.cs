using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManager.Models;
using TaskManager.Context;
using TaskManager.Repository;

namespace TaskManager
{
    class Program
    {
        static void Main(string[] args)
        {
            using (UnitOfWork db = new UnitOfWork())
            {
                ConsoleMenu.Menu menu = new ConsoleMenu.Menu(db.UsersRepo.Get(e => e.Email=="aaa").First());
                menu.Init();
            }

        }
    }
}
