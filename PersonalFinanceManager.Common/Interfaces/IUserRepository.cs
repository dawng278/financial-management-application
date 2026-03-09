using PersonalFinanceManager.Models;

namespace PersonalFinanceManager.Common.Interfaces
{
    public interface IUserRepository : IBaseRepository<User>
    {
        User GetByUsername(string username);
        bool UsernameExists(string username);
        bool EmailExists(string email);
    }
}