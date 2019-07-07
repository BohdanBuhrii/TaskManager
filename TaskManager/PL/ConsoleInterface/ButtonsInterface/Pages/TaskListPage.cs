using System.Collections.Generic;
using TaskManager.BL.DTOs;
using TaskManager.BL.Services;

namespace TaskManager.PL.ConsoleInterface.ButtonsInterface.Pages
{
    public class TaskListPage : ListView
    {
        private List<TaskDTO> _tasks;
        private readonly UserDTO _user;
        private readonly TaskManagerProvider _provider;
        private readonly TaskManagerBusinessLogic _businessLogic;

        public TaskListPage(UserDTO user)
        {
            _user = user;
            _provider = new TaskManagerProvider();
            _businessLogic = new TaskManagerBusinessLogic();

            _tasks = _provider.GetTasksByUser(_user);
            _businessLogic.SortTasks(_tasks);

            string status;

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
                    Content = $"{task.PublisherName}  to group {task.GroupTitle}  \n{task.PublicationDate}    {status} \n{task.Content}",
                    ButtonAction = MarkTaskAsDone
                });
            }

            buttons.Add(new Button { Content = "<-- back to Main Menu", ButtonAction = BackToMainMenu });
        }

        public void BackToMainMenu()
        {
            MainMenuPage mainMenuPage = new MainMenuPage(_user);
            mainMenuPage.Init();
        }

        public void MarkTaskAsDone()
        {
            TaskDTO task = _tasks[CurrentPosition];
            _provider.MarkTaskAsDone(task);

            TaskListPage taskListPage = new TaskListPage(_user);
            taskListPage.Init();
        }
    }
}
