using SpendingManagement.UI.Mock;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace SpendingManagement.UI.Forms.Auth
{
    public partial class RegisterForm : Form
    {
        public RegisterForm()
        {
            InitializeComponent();
        }


        private void button1_Click(object sender, EventArgs e)
        {
            Application.Exit(); // Thoát hoàn toàn ứng dụng
        }

        private void btnRegiser_Click(object sender, EventArgs e)
        {
            // 1. Kiểm tra xem các ô có bị trống không
            if (string.IsNullOrEmpty(txtUsername.Text) || string.IsNullOrEmpty(txtPassword.Text))
            {
                MessageBox.Show("Vui lòng điền đầy đủ thông tin!");
                return;
            }

            // 2. Gọi Mock Service để giả lập đăng ký
            var userService = new MockUserService();
            if (userService.Register(txtUsername.Text, txtPassword.Text))
            {
                MessageBox.Show("Đăng ký thành công!");

                // 3. Chuyển về lại LoginForm
                LoginForm login = new LoginForm();
                login.Show();
                this.Hide(); // Đóng form đăng ký
            }
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            LoginForm login = new LoginForm();
            login.Show();
            this.Hide();
        }
    }
}
