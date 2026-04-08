using System;
using System.Data;
using Dapper;
using PersonalFinanceManager.Common.Interfaces;
using PersonalFinanceManager.Common.Helpers;
using PersonalFinanceManager.Models;

namespace PersonalFinanceManager.Common.Mock
{
    /// <summary>
    /// DB-backed user service.
    /// Giữ tên MockUserService để không phá DI hiện tại.
    /// </summary>
    public class MockUserService : IUserService
    {
        private readonly DbHelper _dbHelper = new DbHelper();
        public static int CurrentUserId { get; private set; }

        private User _currentUser = null;

        // ── IUserService ────────────────────────────────────────────
        public bool Login(string usernameOrEmail, string plainPassword)
        {
            using (var conn = _dbHelper.CreateConnection())
            {
                conn.Open();

                var sql = @"SELECT Id, Username, PasswordHash, FullName, Email, CreatedAt, IsActive
                            FROM Users
                            WHERE (Username = @u OR Email = @u)
                              AND PasswordHash = @p
                              AND IsActive = 1
                            LIMIT 1";

                var user = conn.QueryFirstOrDefault<User>(sql, new { u = usernameOrEmail, p = plainPassword });

                if (user == null) return false;

                _currentUser = user;
                CurrentUserId = _currentUser.Id;

                return true;
            }
        }

        public void Logout()
        {
            _currentUser = null;
            CurrentUserId = 0;
        }

        public User GetCurrentUser()
        {
            return _currentUser;
        }

        public bool Register(User user, string plainPassword)
        {
            if (user == null || string.IsNullOrWhiteSpace(user.Email) || string.IsNullOrWhiteSpace(plainPassword))
                return false;

            // UI hiện tại chưa nhập Username, nên dùng email làm username mặc định.
            if (string.IsNullOrWhiteSpace(user.Username))
            {
                user.Username = user.Email.Trim();
            }

            using (var conn = _dbHelper.CreateConnection())
            {
                conn.Open();

                var exists = conn.ExecuteScalar<int>("SELECT COUNT(1) FROM Users WHERE Username = @u OR Email = @e", 
                    new { u = user.Username, e = user.Email }) > 0;
                if (exists) return false;

                var sqlUser = @"INSERT INTO Users (Username, PasswordHash, FullName, Email, CreatedAt, IsActive)
                               VALUES (@Username, @PasswordHash, @FullName, @Email, @CreatedAt, 1);";
                
                int rows = conn.Execute(sqlUser, new { 
                    user.Username, 
                    PasswordHash = plainPassword, 
                    FullName = user.FullName ?? (object)DBNull.Value, 
                    Email = user.Email ?? (object)DBNull.Value, 
                    CreatedAt = DateTime.Now.ToString("s") 
                });

                if (rows <= 0) return false;

                long newUserId = conn.ExecuteScalar<long>("SELECT last_insert_rowid();");

                var sqlAccount = @"INSERT INTO Accounts (UserId, AccountName, AccountType, Balance, Currency, CreatedAt, IsActive)
                                  VALUES (@UserId, @AccountName, @AccountType, @Balance, @Currency, @CreatedAt, 1);";
                
                conn.Execute(sqlAccount, new { 
                    UserId = newUserId, 
                    AccountName = "Ví tiền mặt", 
                    AccountType = "Cash", 
                    Balance = 0m, 
                    Currency = "VND", 
                    CreatedAt = DateTime.Now.ToString("s") 
                });

                InitializeDefaultCategories(conn, newUserId);

                return true;
            }
        }

        private void InitializeDefaultCategories(IDbConnection conn, long userId)
        {
            var defaults = new[]
            {
                new { Name = "Ăn uống", Type = "Expense", Icon = "Food", Color = "#FF5733" },
                new { Name = "Di chuyển", Type = "Expense", Icon = "Car", Color = "#2ECC71" },
                new { Name = "Mua sắm", Type = "Expense", Icon = "Shopping", Color = "#3498DB" },
                new { Name = "Lương", Type = "Income", Icon = "Salary", Color = "#F1C40F" },
                new { Name = "Giải trí", Type = "Expense", Icon = "Gamepad", Color = "#9B59B6" },
                new { Name = "Y tế", Type = "Expense", Icon = "HeartPulse", Color = "#E74C3C" },
                new { Name = "Tiền nhà", Type = "Expense", Icon = "Home", Color = "#34495E" },
                new { Name = "Linh tinh", Type = "Expense", Icon = "Layers", Color = "#95A5A6" }
            };

            var sql = @"INSERT INTO Categories (Name, Type, IconName, ColorHex, IsDefault, UserId)
                        VALUES (@Name, @Type, @Icon, @Color, 1, @UserId)";

            foreach (var cat in defaults)
            {
                conn.Execute(sql, new { cat.Name, cat.Type, Icon = cat.Icon, Color = cat.Color, UserId = userId });
            }
        }

        public bool UpdateProfile(User user, string newPassword)
        {
            if (_currentUser == null || user == null) return false;

            using (var conn = _dbHelper.CreateConnection())
            {
                conn.Open();

                var exists = conn.ExecuteScalar<int>("SELECT COUNT(1) FROM Users WHERE Email = @e AND Id <> @id", 
                    new { e = user.Email, id = _currentUser.Id }) > 0;
                if (exists) return false;

                var sql = @"UPDATE Users
                            SET FullName = @FullName,
                                Email = @Email,
                                PasswordHash = @PasswordHash
                            WHERE Id = @Id";

                var ok = conn.Execute(sql, new { 
                    FullName = user.FullName ?? (object)DBNull.Value, 
                    Email = user.Email ?? (object)DBNull.Value, 
                    PasswordHash = string.IsNullOrWhiteSpace(newPassword) ? _currentUser.PasswordHash : newPassword,
                    Id = _currentUser.Id
                }) > 0;

                if (!ok) return false;

                _currentUser.FullName = user.FullName;
                _currentUser.Email = user.Email;
                if (!string.IsNullOrWhiteSpace(newPassword))
                    _currentUser.PasswordHash = newPassword;

                return true;
            }
        }

        public bool IsEmailTaken(string email)
        {
            using (var conn = _dbHelper.CreateConnection())
            {
                conn.Open();
                return conn.ExecuteScalar<int>("SELECT COUNT(1) FROM Users WHERE Email = @e", new { e = email }) > 0;
            }
        }
    }
}