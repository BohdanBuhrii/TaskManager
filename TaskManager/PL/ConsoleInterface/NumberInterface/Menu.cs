using System;
using System.Collections.Generic;
using TaskManager.BL.DTOs;
using TaskManager.BL.Services;
using TaskManager.PL.ConsoleInterface.Abstract;

namespace TaskManager.PL.ConsoleInterface
{
    public class Menu : ConsoleItem
    {
        private readonly UserDTO _user;
        private readonly TaskManagerBusinessLogic _businessLogic;

        public Menu(UserDTO user) : base()
        {
            this._user = user;
            _businessLogic = new TaskManagerBusinessLogic();
        }

        private void WriteSeparator() // todo argument
        {
            Console.WriteLine("=========================================================");
        }

        private void ShowTask(TaskDTO task)
        {
            Console.WriteLine("{0}   {1}     To group {2}", task.PublisherName, task.PublicationDate, task.GroupTitle);
            Console.WriteLine(task.Content);
            Console.WriteLine(task.IsDone);
        }

        private void ShowGroup(GroupDTO group)
        {
            Console.Write("{0},     {1} unresolved tasks", group.Title, group.NumberOfUnresolvedTasks);
        }

        public void ShowGroups()
        {
            while (true)
            {
                Console.Clear();
                WriteSeparator();
                Console.WriteLine("Choose ");
                WriteSeparator();
                int i = 0;
                List<GroupDTO> groups = new List<GroupDTO>();

                try
                {
                    groups = _provider.GetGroupsByUser(_user);

                    // todo add validation if user has groups
                    foreach (GroupDTO group in groups)
                    {
                        ShowGroup(group);
                        Console.WriteLine("({0})", ++i);
                        WriteSeparator();
                    }
                }
                catch (Exception)
                {
                    Console.WriteLine("You have no groups");
                }

                Console.WriteLine("\nExit (0)");
                WriteSeparator();

                ReadChoise(0, i);

                if (choise == 0)
                {
                    break;
                }
                else
                {
                    ShowGroupTasks(groups[i - 2]);
                    break;
                }
            }
        }

        public void ShowUserTasks()
        {
            while (true)
            {
                Console.Clear();
                WriteSeparator();
                Console.WriteLine("Choose ");
                WriteSeparator();
                int i = 1;

                List<TaskDTO> tasks = _provider.GetTasksByUser(_user);

                // todo add validation if user has tasks
                foreach (TaskDTO task in tasks)
                {
                    ShowTask(task);
                    Console.WriteLine("({0})", i++);
                    WriteSeparator();
                }

                Console.WriteLine("\nExit (0)");
                WriteSeparator();

                ReadChoise(0, i);

                if (choise == 0)
                {
                    break;
                }
                else
                {
                    EditTask(tasks[i - 1]);
                }
            }
        }

        public void ShowGroupTasks(GroupDTO group)
        {
            while (true)
            {
                int i = 1;

                var tasks = _provider.GetTasksByGroup(group);
                foreach (TaskDTO task in tasks)
                {
                    ShowTask(task);
                    Console.WriteLine(i);
                }

                Console.WriteLine("\nExit (0)");

                ReadChoise(0, i);

                if (choise == 0)
                {
                    break;
                }
                else
                {
                    EditTask(tasks[i - 1]);
                }
            }
        }

        public void EditTask(TaskDTO task)
        {
            if (task.IsDone)
            {
                Console.WriteLine("This task is done");
            }
            else
            {
                Console.WriteLine("If you want to mark this task \"done\" press (1), " +
                    "else press any other key");
                if (Console.ReadLine() == "1")
                {
                    _provider.MarkTaskAsDone(ref task);
                }
                Console.Clear();
            }

            
        }

        public override void Init()
        {
            while (true)
            {
                Console.Clear();
                Console.Write("\nSee my groups (1)\n" +
                              "See my tasks (2)\n" +
                              "Log out (3)\n" +
                              "Exit (0)\n");

                choise = Convert.ToInt32(Console.ReadLine());
                Console.Clear();
                if (choise == 0)
                {
                    break;
                }
                else if (choise == 1)
                {
                    ShowGroups();
                }
                else if (choise == 2)
                {
                    ShowUserTasks();
                }
                else if (choise == 3)
                {
                    Console.Clear();
                    Authentication authentication = new Authentication();
                    authentication.Init();
                    break;
                }
            }
        }
    }
}
