using System;
using System.Collections.Generic;
using System.Linq;
using TaskManager.DAL.Models;
using TaskManager.DAL.Repository;
using TaskManager.DAL.Repository.Abstract;

namespace TaskManager.DAL.ConsoleMenu
{
    public class Menu
    {
        //private BusinessLogic.TaskManager taskManager;
        private readonly int screen;
        private IUnitOfWork db;
        private User user;
        private IEnumerable<User> enumerable;

        public Menu(User user)
        {
            this.user = user;
            //taskManager = new BusinessLogic.TaskManager();
            db = UnitOfWork.GetUnit();
        }


        private void WriteSeparator()//todo argument
        {
            Console.WriteLine("__________________________________________________________________________");
        }
        private void ShowTask(Task task)
        {
            Console.WriteLine( "{0}   {1}     To group {2}",task.Publisher.Name, task.PublicationDate, task.Group.Title);
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
                Console.Clear();
                WriteSeparator();
                Console.WriteLine("Choose ");
                WriteSeparator();
                int i = 1;
                /*
                // todo add validation if user has groups
                foreach (Group group in user.Groups)
                {
                    ShowGroup(group);  Console.WriteLine("({0})", i++);
                    WriteSeparator();
                }

                Console.WriteLine("\nExit (0)");
                WriteSeparator();

                choise = Convert.ToInt32(Console.ReadLine());

                if (choise == 0) break;
                else if (0 < choise && choise <= i) ShowGroupTasks(user.Groups.ElementAt(choise-1));
                WriteSeparator();
                */
            }
        }

        public void ShowUserTasks()
        {
            int choise = 0;

            while (true)
            {
                Console.Clear();
                WriteSeparator();
                Console.WriteLine("Choose ");
                WriteSeparator();
                int i = 1;

                // todo add validation if user has tasks
                foreach (Task task in user.Tasks)
                {
                    ShowTask(task); Console.WriteLine("({0})", i++);
                    WriteSeparator();
                }

                Console.WriteLine("\nExit (0)");
                WriteSeparator();

                choise = Convert.ToInt32(Console.ReadLine());

                if (choise == 0) break;
            }
        }

        public void ShowGroupTasks(Group group)
        {
            int choise = 0;
            while (true)
            {
                int i = 1;
                foreach (Task task in group.Tasks)
                {
                    ShowTask(task); Console.WriteLine(i);
                }

                Console.WriteLine("\nExit (0)");

                choise = Convert.ToInt32(Console.ReadLine());

                if (choise == 0) break;
            }
        }

        

        public void Init()
        {
            int choise = -1;
            while (choise != 0)
            {
                Console.Clear();
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
