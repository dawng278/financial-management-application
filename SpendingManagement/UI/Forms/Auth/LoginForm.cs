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
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            var userService = new MockUserService();

            if (userService.Authenticate(txtUsername.Text, txtPassword.Text))
            {
                MessageBox.Show("Chào mừng quay trở lại!");
                new BaseForm().Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Sai tài khoản!", "Lỗi");
            }
        }

        private void txtPassword_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnexit_Click(object sender, EventArgs e)
        {
            Application.Exit(); // Thoát hoàn toàn ứng dụng
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            RegisterForm register = new RegisterForm();
            register.Show();
            this.Hide();
        }
    }
}
