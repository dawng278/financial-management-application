using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using PersonalFinanceManager.Common.Interfaces;
using PersonalFinanceManager.Infrastructure.DI;

namespace PersonalFinanceManager.Forms.Auth
{
    public partial class LoginForm : Form
    {
        private readonly IUserService _userService;

        public LoginForm()
        {
            InitializeComponent();
            _userService = ServiceLocator.UserService;
            this.Load += LoginForm_Load;
        }

        private void LoginForm_Load(object sender, EventArgs e)
        {
            LoadBackgroundImage();
            txtEmail.Focus();
        }

        private void LoadBackgroundImage()
        {
            string[] candidates = new[]
            {
                System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Image.png"),
                System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Resources", "Image.png"),
                System.IO.Path.Combine(Application.StartupPath, "Image.png"),
            };

            foreach (var path in candidates)
            {
                if (System.IO.File.Exists(path))
                {
                    try { picBackground.Image = Image.FromFile(path); return; }
                    catch { }
                }
            }
        }

        // =====================================================
        // VẼ LOGO — hình tròn xanh lá vàng chữ "F"
        // =====================================================
        private void picLogo_Paint(object sender, PaintEventArgs e)
        {
            var g = e.Graphics;
            g.SmoothingMode = SmoothingMode.AntiAlias;
            g.CompositingQuality = CompositingQuality.HighQuality;

            int w = picLogo.Width;
            int h = picLogo.Height;

            // Nền tròn
            using (var bg = new SolidBrush(Color.FromArgb(181, 212, 34)))
                g.FillEllipse(bg, 0, 0, w - 1, h - 1);

            // Overlay nhẹ tạo chiều sâu
            using (var overlay = new SolidBrush(Color.FromArgb(30, 0, 0, 0)))
                g.FillEllipse(overlay, 3, 3, w - 7, h - 7);

            // Chữ "F"
            using (var font = new Font("Segoe UI", 15f, FontStyle.Bold))
            using (var brush = new SolidBrush(Color.FromArgb(22, 22, 22)))
            {
                var sf = new StringFormat
                {
                    Alignment = StringAlignment.Center,
                    LineAlignment = StringAlignment.Center
                };
                g.DrawString("F", font, brush, new RectangleF(0, 0, w, h), sf);
            }
        }

        private void btnClose_Click(object sender, EventArgs e) => Application.Exit();

        private void btnSignIn_Click(object sender, EventArgs e)
        {
            string email = txtEmail.Text.Trim();
            string password = txtPassword.Text;

            if (string.IsNullOrEmpty(email)) { SetError(txtEmail, "Vui lòng nhập email."); return; }
            if (string.IsNullOrEmpty(password)) { SetError(txtPassword, "Vui lòng nhập mật khẩu."); return; }

            ResetErrors();

            bool success = _userService.Login(email, password);

            if (success)
            {
                PersonalFinanceManager.UI.Navigation.FormNavigator.GoToDashboard();
            }
            else
            {
                SetError(txtPassword, "Email hoặc mật khẩu không đúng.");
            }
        }

        private void lnkForgotPassword_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            MessageBox.Show("Tính năng quên mật khẩu sẽ được phát triển sau.",
                "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void lnkSignUp_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            var registerForm = new RegisterForm();
            registerForm.Show();
            this.Hide();
            registerForm.FormClosed += (s, args) => this.Show();
        }

        private void SetError(Guna.UI2.WinForms.Guna2TextBox field, string message)
        {
            field.BorderColor = Color.FromArgb(220, 60, 60);
            field.FocusedState.BorderColor = Color.FromArgb(220, 60, 60);
            MessageBox.Show(message, "Lỗi nhập liệu", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            field.Focus();
        }

        private void ResetErrors()
        {
            txtEmail.BorderColor = Color.FromArgb(210, 215, 220);
            txtEmail.FocusedState.BorderColor = Color.FromArgb(22, 22, 22);
            txtPassword.BorderColor = Color.FromArgb(210, 215, 220);
            txtPassword.FocusedState.BorderColor = Color.FromArgb(22, 22, 22);
        }
    }
}