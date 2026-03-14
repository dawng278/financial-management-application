using PersonalFinanceManager.Models;

namespace PersonalFinanceManager.Common.Interfaces
{
    public interface IUserService
    {
        bool Login(string username, string password);
        bool Register(User user, string plainPassword);
        User GetCurrentUser();
        void Logout();
    }
}