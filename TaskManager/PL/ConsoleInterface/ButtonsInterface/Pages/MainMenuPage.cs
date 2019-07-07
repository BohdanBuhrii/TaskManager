using System;
using TaskManager.BL.DTOs;

namespace TaskManager.PL.ConsoleInterface.ButtonsInterface.Pages
{
    public class MainMenuPage : Page
    {
        private readonly UserDTO _user;

        public MainMenuPage(UserDTO user)
        {
            _user = user;

            buttons.Add(new Button { Content = "See my groups", ButtonAction = ShowGroups });
            buttons.Add(new Button { Content = "See my tasks", ButtonAction = ShowTasks });
            buttons.Add(new Button { Content = "Log out", ButtonAction = LogOut });
            buttons.Add(new Button { Content = "Exit", ButtonAction = Exit });
        }

        public void ShowGroups()
        {
            GroupListPage groupsPage = new GroupListPage(_user);
            groupsPage.Init();
        }

        public void ShowTasks()
        {
            TaskListPage tasksPage = new TaskListPage(_user);
            tasksPage.Init();
        }

        public void LogOut()
        {
            Console.Clear();
            AuthenticationPage authentication = new AuthenticationPage();
            authentication.Init();
        }
    }
}
