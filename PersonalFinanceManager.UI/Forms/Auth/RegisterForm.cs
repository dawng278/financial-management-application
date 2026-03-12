using PersonalFinanceManager.UI.Mock;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PersonalFinanceManager.Forms.Auth
{
    public partial class RegisterForm : Form
    {

        public RegisterForm()
        {
            InitializeComponent();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnRegiser_Click_1(object sender, EventArgs e)
        {
            // Lấy dữ liệu từ 3 TextBox duy nhất có trong Designer của cậu
            string username = txtUsernameR.Text;
            string password = txtPasswordR.Text;
            string confirmPass = txtPassword2R.Text;

            // 1. Kiểm tra không được để trống thông tin
            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ Tài khoản và Mật khẩu!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // 2. Kiểm tra mật khẩu nhập lại có khớp với mật khẩu ban đầu không
            if (password != confirmPass)
            {
                MessageBox.Show("Mật khẩu nhập lại không chính xác!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // 3. Thực hiện đăng ký vào hệ thống Mock
            // Vì không có ô Full Name, tớ sẽ lấy luôn Username làm tên hiển thị
            if (MockUserService.Register(username, password, username))
            {
                MessageBox.Show("Đăng ký tài khoản thành công!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Sau khi thành công, quay lại Form đăng nhập
                LoginForm login = new LoginForm();
                login.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Tên tài khoản này đã tồn tại, vui lòng chọn tên khác!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void linkLabel1_LinkClicked_1(object sender, LinkLabelLinkClickedEventArgs e)
        {
            // Quay lại màn hình đăng nhập khi nhấn "Đã có tài khoản"
            LoginForm login = new LoginForm();
            login.Show();
            this.Hide();
        }
    }
}