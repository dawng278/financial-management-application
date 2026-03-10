using PersonalFinanceManager.Common.Interfaces;
using PersonalFinanceManager.Models;

namespace PersonalFinanceManager.Common.Mock
{
    public class MockUserService : IUserService
    {
        private User _currentUser;

        public bool Login(string username, string password)
        {
            _currentUser = new User
            {
                Id = 1,
                Username = username,
                FullName = "Người dùng test",
                Email = "test@example.com"
            };
            return true;
        }

        public bool Register(User user, string plainPassword) => true;
        public User GetCurrentUser() => _currentUser;
        public void Logout() => _currentUser = null;
    }
}