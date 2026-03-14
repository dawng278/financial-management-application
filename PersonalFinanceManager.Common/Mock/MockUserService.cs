using System;
using System.Collections.Generic;
using PersonalFinanceManager.Common.Interfaces;
using PersonalFinanceManager.Models;

namespace PersonalFinanceManager.Common.Mock
{
    /// <summary>
    /// Mock UserService dùng cho Sprint 1.
    /// Tài khoản cố định: admin / admin
    /// </summary>
    public class MockUserService : IUserService
    {
        // ── Tài khoản cứng ──────────────────────────────────────────
        private static readonly List<(string Email, string Password, User User)> _accounts
            = new List<(string, string, User)>
        {
            (
                "admin",
                "admin",
                new User
                {
                    Id        = 1,
                    FullName  = "Administrator",
                    Email     = "admin",
                    CreatedAt = new DateTime(2024, 1, 1)
                }
            )
        };

        private User _currentUser = null;

        // ── IUserService ────────────────────────────────────────────
        public bool Login(string emailOrUsername, string plainPassword)
        {
            foreach (var acc in _accounts)
            {
                if (acc.Email.Equals(emailOrUsername, StringComparison.OrdinalIgnoreCase)
                    && acc.Password == plainPassword)
                {
                    _currentUser = acc.User;
                    return true;
                }
            }
            return false;
        }

        public void Logout()
        {
            _currentUser = null;
        }

        public User GetCurrentUser()
        {
            return _currentUser;
        }

        public bool Register(User user, string plainPassword)
        {
            // Sprint 1: mock — không lưu thật
            _accounts.Add((user.Email, plainPassword, user));
            return true;
        }

        public bool IsEmailTaken(string email)
        {
            foreach (var acc in _accounts)
                if (acc.Email.Equals(email, StringComparison.OrdinalIgnoreCase))
                    return true;
            return false;
        }
    }
}