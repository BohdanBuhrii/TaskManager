using System;
using TaskManager.BL.DTOs;
using TaskManager.BL.Services;
using TaskManager.PL.ConsoleInterface.Abstract;

namespace TaskManager.PL.ConsoleInterface
{
    public class Menu : ConsoleItem
    {
        private UserDTO user;       
        private readonly TaskManagerBusinessLogic _businessLogic;

        public Menu(UserDTO user) : base()
        {
            this.user = user;
            _businessLogic = new TaskManagerBusinessLogic();
        }


        private void WriteSeparator()//todo argument
        {
            Console.WriteLine("__________________________________________________________________________");
        }

        
        private void ShowTask(TaskDTO task)
        {
            Console.WriteLine( "{0}   {1}     To group {2}",task.PublisherName, task.PublicationDate, task.GroupTitle);
            Console.WriteLine(task.Content);
            Console.WriteLine(task.IsDone);
        }

        private void ShowGroup(GroupDTO group)
        {
            Console.Write("{0},     {1} unresolved tasks", group.Title, group.NumberOfUnresolvedTasks);
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

                var groups = _provider.GetGroupsByUser(user);
                // todo add validation if user has groups
                foreach (GroupDTO group in groups)
                {
                    ShowGroup(group);  Console.WriteLine("({0})", i++);
                    WriteSeparator();
                }

                Console.WriteLine("\nExit (0)");
                WriteSeparator();

                choise = Convert.ToInt32(Console.ReadLine());

                if (choise == 0) break;
                else if (0 < choise && choise <= i) ShowGroupTasks(groups[i-1]);
                WriteSeparator();
                
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

                var tasks = _provider.GetTasksByUser(user);

                // todo add validation if user has tasks
                foreach (TaskDTO task in tasks)
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

        public void ShowGroupTasks(GroupDTO group)
        {
            int choise = 0;
            while (true)
            {
                int i = 1;

                var tasks = _provider.GetTasksByGroup(group);
                foreach (TaskDTO task in tasks)
                {
                    ShowTask(task); Console.WriteLine(i);
                }

                Console.WriteLine("\nExit (0)");

                choise = Convert.ToInt32(Console.ReadLine());

                if (choise == 0) break;
            }
        }

        

        public override void Init()
        {
            int choise = -1;
            while (choise != 0)
            {
                Console.Clear();
                Console.Write("\nSee my groups (1)\n" +
                              "See my tasks (2)\n" +
                              "Log out (3)\n" +
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
                else if (choise == 3) { }
                
            }
        }
    }
}
