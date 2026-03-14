// File: PersonalFinanceManager.Common/Security/PasswordHasher.cs
using BCrypt.Net;

namespace PersonalFinanceManager.Common.Security
{
    public static class PasswordHasher
    {
        [cite_start]// Tạo chuỗi Hash từ mật khẩu thuần 
        public static string HashPassword(string password)
        {
            return BCrypt.Net.BCrypt.HashPassword(password, workFactor: 12);
        }

        [cite_start]// Kiểm tra mật khẩu nhập vào có khớp với Hash không 
        public static bool VerifyPassword(string password, string hashedPassword)
        {
            return BCrypt.Net.BCrypt.Verify(password, hashedPassword);
        }
    }
}