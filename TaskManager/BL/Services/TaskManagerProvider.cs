using TaskManager.DAL.Repository.Abstract;

namespace TaskManager.BL.Services
{
    public class TaskManagerProvider
    {
        private IUnitOfWork db;

        public TaskManagerProvider(IUnitOfWork unitOfWork)
        {
            db = unitOfWork;
        }


    }
}
