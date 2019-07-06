using TaskManager.DAL.Models;

namespace TaskManager.DAL.Repository.Abstract.AbstractsForConcrete
{
    /// <summary>
    /// Defines interface for repository with tasks.
    /// </summary>
    public interface ITasksRepo : IRepository<Task>
    {
    }
}
