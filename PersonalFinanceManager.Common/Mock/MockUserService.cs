using System;
using System.Data.SQLite;
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

                using (var cmd = (SQLiteCommand)conn.CreateCommand())
                {
                    cmd.CommandText = @"SELECT Id, Username, PasswordHash, FullName, Email, CreatedAt, IsActive
                                        FROM Users
                                        WHERE (Username = @u OR Email = @u)
                                          AND PasswordHash = @p
                                          AND IsActive = 1
                                        LIMIT 1";
                    cmd.Parameters.AddWithValue("@u", usernameOrEmail);
                    cmd.Parameters.AddWithValue("@p", plainPassword);

                    using (var reader = cmd.ExecuteReader())
                    {
                        if (!reader.Read()) return false;

                        _currentUser = new User
                        {
                            Id = Convert.ToInt32(reader["Id"]),
                            Username = reader["Username"].ToString(),
                            PasswordHash = reader["PasswordHash"].ToString(),
                            FullName = reader["FullName"] == DBNull.Value ? null : reader["FullName"].ToString(),
                            Email = reader["Email"] == DBNull.Value ? null : reader["Email"].ToString(),
                            CreatedAt = DateTime.TryParse(reader["CreatedAt"].ToString(), out var createdAt)
                                ? createdAt
                                : DateTime.Now,
                            IsActive = Convert.ToInt32(reader["IsActive"]) == 1
                        };

                        CurrentUserId = _currentUser.Id;

                        return true;
                    }
                }
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

                using (var check = (SQLiteCommand)conn.CreateCommand())
                {
                    check.CommandText = "SELECT COUNT(1) FROM Users WHERE Username = @u OR Email = @e";
                    check.Parameters.AddWithValue("@u", user.Username);
                    check.Parameters.AddWithValue("@e", user.Email);
                    var exists = Convert.ToInt32(check.ExecuteScalar()) > 0;
                    if (exists) return false;
                }

                using (var cmd = (SQLiteCommand)conn.CreateCommand())
                {
                    cmd.CommandText = @"INSERT INTO Users (Username, PasswordHash, FullName, Email, CreatedAt, IsActive)
                                        VALUES (@Username, @PasswordHash, @FullName, @Email, @CreatedAt, 1);";
                    cmd.Parameters.AddWithValue("@Username", user.Username);
                    cmd.Parameters.AddWithValue("@PasswordHash", plainPassword);
                    cmd.Parameters.AddWithValue("@FullName", (object)user.FullName ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@Email", (object)user.Email ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@CreatedAt", DateTime.Now.ToString("s"));
                    if (cmd.ExecuteNonQuery() <= 0) return false;
                }

                long newUserId;
                using (var idCmd = (SQLiteCommand)conn.CreateCommand())
                {
                    idCmd.CommandText = "SELECT last_insert_rowid();";
                    newUserId = Convert.ToInt64(idCmd.ExecuteScalar());
                }

                using (var accountCmd = (SQLiteCommand)conn.CreateCommand())
                {
                    accountCmd.CommandText = @"INSERT INTO Accounts (UserId, AccountName, AccountType, Balance, Currency, CreatedAt, IsActive)
                                               VALUES (@UserId, @AccountName, @AccountType, @Balance, @Currency, @CreatedAt, 1);";
                    accountCmd.Parameters.AddWithValue("@UserId", newUserId);
                    accountCmd.Parameters.AddWithValue("@AccountName", "Ví tiền mặt");
                    accountCmd.Parameters.AddWithValue("@AccountType", "Cash");
                    accountCmd.Parameters.AddWithValue("@Balance", 0m);
                    accountCmd.Parameters.AddWithValue("@Currency", "VND");
                    accountCmd.Parameters.AddWithValue("@CreatedAt", DateTime.Now.ToString("s"));
                    accountCmd.ExecuteNonQuery();
                }

                return true;
            }
        }

        public bool UpdateProfile(User user, string newPassword)
        {
            if (_currentUser == null || user == null) return false;

            using (var conn = _dbHelper.CreateConnection())
            {
                conn.Open();

                using (var check = (SQLiteCommand)conn.CreateCommand())
                {
                    check.CommandText = "SELECT COUNT(1) FROM Users WHERE Email = @e AND Id <> @id";
                    check.Parameters.AddWithValue("@e", (object)user.Email ?? DBNull.Value);
                    check.Parameters.AddWithValue("@id", _currentUser.Id);
                    var exists = Convert.ToInt32(check.ExecuteScalar()) > 0;
                    if (exists) return false;
                }

                using (var cmd = (SQLiteCommand)conn.CreateCommand())
                {
                    cmd.CommandText = @"UPDATE Users
                                        SET FullName = @FullName,
                                            Email = @Email,
                                            PasswordHash = @PasswordHash
                                        WHERE Id = @Id";
                    cmd.Parameters.AddWithValue("@FullName", (object)user.FullName ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@Email", (object)user.Email ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@PasswordHash", string.IsNullOrWhiteSpace(newPassword) ? _currentUser.PasswordHash : newPassword);
                    cmd.Parameters.AddWithValue("@Id", _currentUser.Id);

                    var ok = cmd.ExecuteNonQuery() > 0;
                    if (!ok) return false;

                    _currentUser.FullName = user.FullName;
                    _currentUser.Email = user.Email;
                    if (!string.IsNullOrWhiteSpace(newPassword))
                        _currentUser.PasswordHash = newPassword;

                    return true;
                }
            }
        }

        public bool IsEmailTaken(string email)
        {
            using (var conn = _dbHelper.CreateConnection())
            {
                conn.Open();

                using (var cmd = (SQLiteCommand)conn.CreateCommand())
                {
                    cmd.CommandText = "SELECT COUNT(1) FROM Users WHERE Email = @e";
                    cmd.Parameters.AddWithValue("@e", email);
                    return Convert.ToInt32(cmd.ExecuteScalar()) > 0;
                }
            }
        }
    }
}