using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PersonalFinanceManager.Models;

namespace PersonalFinanceManager.UI.Mock
{
    public class UserMock
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public string FullName { get; set; }
    }

    // Lớp cung cấp dịch vụ xác thực ảo (C2)
    public static class MockUserService
    {
        private static List<UserMock> _users = new List<UserMock>
        {
            new UserMock { Username = "admin", Password = "123", FullName = "Quản trị viên" },
            new UserMock { Username = "user", Password = "123", FullName = "Người dùng thử" }
        };
        public static bool Authenticate(string username, string password)
        {
            foreach (var user in _users)
            {
                if (user.Username == username && user.Password == password)
                {
                    return true;
                }
            }
            return false;
        }
        // Thêm hàm này vào trong class MockUserService của cậu
        public static bool Register(string username, string password, string fullName)
        {
            // Kiểm tra xem tên đăng nhập đã tồn tại chưa
            foreach (var user in _users)
            {
                if (user.Username.Equals(username, StringComparison.OrdinalIgnoreCase))
                {
                    return false; // Tên tài khoản đã tồn tại
                }
            }

            // Thêm người dùng mới vào danh sách
            _users.Add(new UserMock
            {
                Username = username,
                Password = password,
                FullName = fullName
            });

            return true; // Đăng ký thành công
        }
    }
}
