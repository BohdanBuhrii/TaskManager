using System.Collections.Generic;
using TaskManager.BL.DTOs;

namespace TaskManager.BL.Services
{
    public class TaskManagerBusinessLogic
    {
        public void SortTasks(List<TaskDTO> tasks)
        {
            tasks.Sort(new TaskComparer());
        }

        public class TaskComparer : IComparer<TaskDTO>
        {
            public int Compare(TaskDTO x, TaskDTO y)
            {
                if (x.IsDone == y.IsDone)
                {
                    return x.PublicationDate.CompareTo(y.PublicationDate);
                }
                else if (!x.IsDone)
                {
                    return -1;
                }
                else
                {
                    return 1;
                }
            }
        }
    }
}
