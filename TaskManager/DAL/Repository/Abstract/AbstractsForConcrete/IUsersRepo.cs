using TaskManager.DAL.Models;

namespace TaskManager.DAL.Repository.Abstract.AbstractsForConcrete
{
    /// <summary>
    /// Defines interface for repository with users.
    /// </summary>
    public interface IUsersRepo : IRepository<User>
    {
        /// <summary>
        /// Gets User by email.
        /// </summary>
        /// <param name="email"> User's email. </param>
        /// <returns>User wiht current email.</returns>
        User GetByEmail(string email);
    }
}
