using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TaskManager.Models;
using TaskManager.Context;
using TaskManager.Repository;

namespace TaskManager
{
    
    class Program
    {
        static void FillData()
        {
            using (UnitOfWork db = UnitOfWork.GetUnit())
            {
                var groups = new Group[] { new Group { Title = "Family" },
                                           new Group { Title = "Lv-420.Net" } };
                db.GroupsRepo.AddRange(groups);
                
                var users = new User[] { new User { Email = "bohdan@gmail.com", Name = "Bohdan", HashPassword="1" },
                                        new User { Name="Mom", Email="Mom@gmail.com", HashPassword="1"}};
                db.UsersRepo.AddRange(users);

                //var tasks = new Task[] { new Task { Content = "buy bread", Group =  } };

                db.SaveChanges();
            } 
        }

        static void Main(string[] args)
        {
            //FillData();
            using (UnitOfWork db = UnitOfWork.GetUnit())
            {
                //var a=db.GroupsRepo.GetAll();
                //db.TasksRepo.Add(new Task {
                //    Content ="test task", Group=db.GroupsRepo.Get(e=>e.Id==1).First(),
                //    Publisher = db.UsersRepo.Get(e => e.Name == "Bohdan").First() });
                //User u=db.UsersRepo.Get(e => e.Name=="bohdan").FirstOrDefault();
                

                
                

                ConsoleMenu.Menu menu = new ConsoleMenu.Menu(db.UsersRepo.Get(e => e.Name == "Bohdan").First());
                //var user = db.UsersRepo.Get(e => e.Name == "Bohdan").First();
                menu.Init();

                db.SaveChanges();
                
            }
        }
    }
}
