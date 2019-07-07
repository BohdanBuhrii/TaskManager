using System;
using System.Collections.Generic;
using TaskManager.BL.DTOs;
using TaskManager.BL.Services;

namespace TaskManager.PL.ConsoleInterface.ButtonsInterface.Pages
{
    public class GroupPage : Page
    {
        private List<TaskDTO> _tasks;
        private readonly GroupDTO _group;
        private readonly UserDTO _user;
        private readonly TaskManagerProvider _provider;

        public GroupPage(GroupDTO group, UserDTO user)
        {
            _group = group;
            _user = user;
            _provider = new TaskManagerProvider();
            buttons.Add(new Button { Content = $"Group : {group.Title}\n", ButtonAction = NullAction, AbilityToChange = false });

            _tasks = _provider.GetTasksByGroup(_group);
            string status = string.Empty;

            foreach (TaskDTO task in _tasks)
            {
                if (task.IsDone)
                {
                    status = "Done";
                }
                else
                {
                    status = "In progress";
                }

                buttons.Add(new Button
                {
                    Content = $"{task.PublisherName}   {task.PublicationDate}   {status} \n{task.Content}",
                    ButtonAction = MarkTaskAsDone
                });
            }

            buttons.Add(new Button { Content = "Add new task", ButtonAction = AddNewTask, AbilityToChange = false });
            buttons.Add(new Button { Content = "Add new user", ButtonAction = AddNewUser, AbilityToChange = false });
            buttons.Add(new Button { Content = "<-- back to groups", ButtonAction = BackToGroups, AbilityToChange = false });
        }

        public void AddNewTask()
        {
            TaskDTO task = new TaskDTO();
            Console.Write("Enter task message : ");
            task.Content = Console.ReadLine();
            task.PublicationDate = DateTime.Now;
            _provider.AddNewTask(task, _user, _group);


            ShowSuccessMessage("Task created successfully! Press any key to continue");
            Console.ReadKey();
            this.Init();
        }

        public void AddNewUser()
        {

        }

        public void MarkTaskAsDone()
        {

        }

        public void BackToGroups()
        {
            GroupListPage groupListPage = new GroupListPage(_user);
            groupListPage.Init();
        }
    }
}
