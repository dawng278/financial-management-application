using System;
using System.Collections.Generic;
using System.Text;

namespace SpendingManagement.UI.Mock
{
    public class MockUserService
    {
        // Giả lập kiểm tra đăng nhập
        public bool Authenticate(string username, string password)
        {
            // Để test giao diện, cứ admin/123 là cho qua nhé
            return username == "admin" && password == "123";
        }

        // Giả lập lưu đăng ký
        public bool Register(string username, string password)
        {
            return true; // Luôn trả về thành công để test UI
        }
    }
}
