using TaskManager.DAL.Models;

namespace TaskManager.DAL.Repository.Abstract.AbstrctsForConcrete
{
    public interface IUsersRepo : IRepository<User>
    {
        User GetByEmail(string email);
    }
}
