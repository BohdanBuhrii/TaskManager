using System;
using System.Collections.Generic;
using TaskManager.BL.DTOs;
using TaskManager.BL.Services;

namespace TaskManager.PL.ConsoleInterface.ButtonsInterface.Pages
{
    public class GroupPage : ListView
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
            buttons.Add(new Button { Content = "Add new user", ButtonAction = AddNewUserToGroup, AbilityToChange = false });
            buttons.Add(new Button { Content = "Leave group", ButtonAction = LeaveGroup, AbilityToChange = false });
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
            GroupPage groupPage = new GroupPage(_group, _user);
            groupPage.Init();
        }

        public void AddNewUserToGroup()
        {
            while (true)
            {
                Console.Write("Enter user email : ");
                string email = Console.ReadLine();
                if (_provider.IsEmailExist(email))
                {
                    UserDTO newMember = _provider.GetUserByEmail(email);

                    _provider.AddUserToGroup(newMember, _group);

                    ShowSuccessMessage($"{newMember.Name} successfully joined to group, press any key to continue");
                    Console.ReadKey();
                    buttons[CurrentPosition].ToUsual();
                    _currentPosition = 0;
                    this.Init();
                    break;
                }
                else
                {
                    ShowErrorMessage("User with this email not found, press Enter to try again, press any other key to go back");

                    if (Console.ReadKey().Key != ConsoleKey.Enter)
                    {

                        buttons[CurrentPosition].ToUsual();
                        _currentPosition = 0;
                        this.Init();
                        break;
                    }
                    else
                    {
                        //Console.WriteLine();
                    }
                }
            }
        }

        public void MarkTaskAsDone()
        {
            TaskDTO task = _tasks[CurrentPosition - 1];
            _provider.MarkTaskAsDone(task);

            GroupPage groupPage = new GroupPage(_group, _user);
            groupPage.Init();
        }

        public void LeaveGroup()
        {
            _provider.DeleteUserFromGroup(_user, _group);
            GroupListPage groupListPage = new GroupListPage(_user);
            groupListPage.Init();
        }

        public void BackToGroups()
        {
            GroupListPage groupListPage = new GroupListPage(_user);
            groupListPage.Init();
        }
    }
}
