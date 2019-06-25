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
            using (UnitOfWork db = new UnitOfWork())
            {
                var groups = new Group[] { new Group { Title = "Family" }, new Group { Title = "Lv-420.Net" } };
                db.GroupsRepo.AddRange(groups);
                
                var users= new User[] { new User { Email = "bohdan@gmail.com", Name = "Bohdan", HashPassword="1" } };


                db.SaveChanges();
            } 
        }

        static void Main(string[] args)
        {
            //FillData();
            using (UnitOfWork db = new UnitOfWork())
            {
                //var a=db.GroupsRepo.GetAll();
                //--db.TasksRepo.Add(new Task { Content="test task", Group=db.GroupsRepo.Get(e=>e.Id==1).First(), Publisher= db.UsersRepo.Get(e => e.Name == "Bohdan").First() });
                //User u=db.UsersRepo.Get(e => e.Name=="bohdan").FirstOrDefault();
                //u.Name = "Bohdan";
                //db.UsersRepo.Add(new User { Name="Mom", Email="Mom@gmail.com", HashPassword="1"});

                //db.SaveChanges();
                ConsoleMenu.Menu menu = new ConsoleMenu.Menu(db.UsersRepo.Get(e => e.Name == "Bohdan").First());
                menu.Init();
            }

        }
    }
}
