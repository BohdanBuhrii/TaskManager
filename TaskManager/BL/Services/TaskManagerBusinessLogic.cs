using System.Collections.Generic;
using TaskManager.BL.DTOs;

namespace TaskManager.BL.Services
{
    /// <summary>
    /// Class which defines business logic for this application.
    /// </summary>
    public class TaskManagerBusinessLogic
    {
        /// <summary>
        /// Sort tasks using <see cref="TaskComparer"/>.
        /// </summary>
        /// <param name="tasks"> List of tasks. </param>
        public void SortTasks(List<TaskDTO> tasks)
        {
            tasks.Sort(new TaskComparer());
        }

        /// <summary>
        /// Defines how tasks should be compared.
        /// </summary>
        public class TaskComparer : IComparer<TaskDTO>
        {
            /// <summary>
            /// Compare two tasks.
            /// </summary>
            /// <param name="x"> Task. </param>
            /// <param name="y"> Another task. </param>
            /// <returns> -1 if x is less than y. 0 if x equals y. 1 if x is greater than y. </returns>
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
