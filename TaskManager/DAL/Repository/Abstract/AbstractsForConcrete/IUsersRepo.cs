using TaskManager.DAL.Models;

namespace TaskManager.DAL.Repository.Abstract.AbstractsForConcrete
{
    public interface IUsersRepo : IRepository<User>
    {
        User GetByEmail(string email);
    }
}
