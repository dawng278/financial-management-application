
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using PersonalFinanceManager.UI.Mock;

namespace PersonalFinanceManager.Forms.Auth
{
    public partial class LoginForm : Form
    {
        
        public LoginForm()
        {
            InitializeComponent();
        }

        private void btnexit_Click_1(object sender, EventArgs e)
        {
            Application.Exit(); // Thoát hoàn toàn ứng dụng
        }

        private void btnLogin_Click_1(object sender, EventArgs e)
        {
            string user = txtUsernameL.Text;
            string pass = txtPasswordL.Text;

            // Gọi MockUserService để kiểm tra
            if (MockUserService.Authenticate(user, pass))
            {
                MessageBox.Show("Đăng nhập thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                BaseForm baseForm = new BaseForm();
                baseForm.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Sai tài khoản hoặc mật khẩu!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtPasswordL.Clear();
                txtUsernameL.Focus();
            }
        }

        private void linkLabel1_LinkClicked_1(object sender, LinkLabelLinkClickedEventArgs e)
        {
            RegisterForm register = new RegisterForm();
            register.Show();
            this.Hide();
        }
    }
}
