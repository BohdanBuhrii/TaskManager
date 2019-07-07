using System;
using System.Collections.Generic;
using TaskManager.BL.DTOs;
using TaskManager.BL.Services;

namespace TaskManager.PL.ConsoleInterface.ButtonsInterface.Pages
{
    public class GroupListPage : ListView
    {
        private List<GroupDTO> _groups;
        private TaskManagerProvider _provider;
        private readonly UserDTO _user;

        public GroupListPage(UserDTO user)
        {
            _user = user;
            _provider = new TaskManagerProvider();

            try
            {
                _groups = _provider.GetGroupsByUser(_user);
                foreach (GroupDTO group in _groups)
                {
                    buttons.Add(
                        new Button
                        {
                            Content = $"{group.Title} \n {group.NumberOfUnresolvedTasks} unresolved tasks",
                            ButtonAction = ShowGroup
                        });
                }
            }
            catch (Exception)
            {
                buttons.Add(new Button
                {
                    Content = "No groups",
                    ButtonAction = NullAction,
                    AbilityToChange = false,
                    BackgroundColor = ConsoleColor.Red
                });
            }

            buttons.Add(new Button
            {
                Content = "Add new group",
                ButtonAction = AddNewGroup,
                AbilityToChange = false,
                BackgroundColor = ConsoleColor.DarkYellow
            });

            buttons.Add(new Button
            {
                Content = "<-- back to Main Menu",
                ButtonAction = BackToMainMenu,
                AbilityToChange = false,
                BackgroundColor = ConsoleColor.DarkYellow
            });
        }

        public void AddNewGroup()
        {
            Console.Clear();
            GroupDTO newGroup = new GroupDTO();
            Console.Write("Enter group title : ");
            newGroup.Title = Console.ReadLine();
            newGroup.NumberOfUnresolvedTasks = 0;

            _provider.AddNewGroup(newGroup, _user);

            ShowSuccessMessage("Group created successfully, press any key to continue");

            buttons.Insert(buttons.Count-2, new Button
            {
                Content = $"{newGroup.Title} \n {newGroup.NumberOfUnresolvedTasks} unresolved tasks",
                ButtonAction = ShowGroup
            });

            //RemoveButton("No groups");

            Console.ReadKey();
            this.Init();
        }

        public void BackToMainMenu()
        {
            MainMenuPage mainMenuPage = new MainMenuPage(_user);
            mainMenuPage.Init();
        }

        public void ShowGroup()
        {
            GroupPage groupPage = new GroupPage(_groups[_currentPosition], _user);
            groupPage.Init();
        }
    }
}