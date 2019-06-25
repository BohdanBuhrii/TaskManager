using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TaskManager.Models;
//using TaskManager.Models.Additional_models;
using TaskManager.Repository;

namespace TaskManager.ConsoleMenu
{
    public class Menu
    {
        //private BusinessLogic.TaskManager taskManager;
        private UnitOfWork db;
        private User user;

        public Menu(User user)
        {
            this.user = user;
            //taskManager = new BusinessLogic.TaskManager();
            db = new UnitOfWork();
        }

        private void ShowTask(Task task)
        {
            Console.WriteLine( "{0}{1}",task.Publisher.Name, task.PublicationDate);
            Console.WriteLine(task.Content);
            Console.WriteLine(task.IsDone);
        }

        private void ShowGroup(Group group)
        {
            Console.Write("{0}, {1}", group.Title, group.Tasks.Count);
        }

        public void ShowGroups()
        {
            int choise=0;

            while (true)
            {
                Console.WriteLine("Choose ");

                int i = 1;
                // todo add validation if user has groups
                User u1=db.UsersRepo.Get(u => u.Name == user.Name).First();
                List<Group> groups = db.GroupsRepo.Get(e => e.).ToList();
                foreach (Group group in groups)
                {
                    ShowGroup(group);  Console.WriteLine("({0})", i++);
                }

                Console.WriteLine("\nExit (0)");

                choise = Convert.ToInt32(Console.ReadLine());

                if (choise == 0) break;
                else if (choise < 0 && choise <= i) ShowGroupTasks(user.Groups[choise - 1]);
            }
        }

        public void ShowUserTasks()
        { }

        public void ShowGroupTasks(Group group)
        {
            int choise = 0;
            int i = 1;
            foreach (Task task in group.Tasks)
            {
                ShowTask(task); Console.WriteLine(i);
            }
            choise = Convert.ToInt32(Console.ReadLine());
        }

        

        public void Init()
        {
            int choise = -1;
            while (choise != 0)
            {
                Console.Write("\nSee my groups (1)\n" +
                              "See my tasks (2)\n" +
                              //"Log out (3)\n" +
                              "Exit (0)\n");

                choise = Convert.ToInt32(Console.ReadLine());
                Console.Clear();
                if (choise == 1)
                {
                    ShowGroups();
                }
                else if (choise == 2)
                {
                    ShowUserTasks();
                }
                //else if (choise == 3) { }
                
            }
        }
    }
}
