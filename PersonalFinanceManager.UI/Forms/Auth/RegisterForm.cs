using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using PersonalFinanceManager.Common.Interfaces;
using PersonalFinanceManager.Infrastructure.DI;
using PersonalFinanceManager.Models;

namespace PersonalFinanceManager.Forms.Auth
{
    public partial class RegisterForm : Form
    {
        private readonly IUserService _userService;

        public RegisterForm()
        {
            InitializeComponent();
            _userService = ServiceLocator.UserService;
            this.Load += RegisterForm_Load;
        }

        // =====================================================
        // LOAD
        // =====================================================
        private void RegisterForm_Load(object sender, EventArgs e)
        {
            LoadBackgroundImage();
            txtFullName.Focus();
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
        // VẼ LOGO
        // =====================================================
        private void picLogo_Paint(object sender, PaintEventArgs e)
        {
            var g = e.Graphics;
            g.SmoothingMode = SmoothingMode.AntiAlias;
            g.CompositingQuality = CompositingQuality.HighQuality;

            int w = picLogo.Width;
            int h = picLogo.Height;

            using (var bg = new SolidBrush(Color.FromArgb(181, 212, 34)))
                g.FillEllipse(bg, 0, 0, w - 1, h - 1);

            using (var overlay = new SolidBrush(Color.FromArgb(30, 0, 0, 0)))
                g.FillEllipse(overlay, 3, 3, w - 7, h - 7);

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

        // =====================================================
        // CLOSE
        // =====================================================
        private void btnClose_Click(object sender, EventArgs e) => Application.Exit();

        // =====================================================
        // TẠO TÀI KHOẢN
        // =====================================================
        private void btnRegister_Click(object sender, EventArgs e)
        {
            ResetAllErrors();

            string fullName = txtFullName.Text.Trim();
            string email = txtEmail.Text.Trim();
            string password = txtPassword.Text;
            string confirmPwd = txtConfirmPwd.Text;

            // --- Validation ---
            if (string.IsNullOrEmpty(fullName))
            {
                SetError(txtFullName, "Vui lòng nhập họ và tên.");
                return;
            }

            if (string.IsNullOrEmpty(email))
            {
                SetError(txtEmail, "Vui lòng nhập email.");
                return;
            }

            if (!IsValidEmail(email))
            {
                SetError(txtEmail, "Địa chỉ email không hợp lệ.");
                return;
            }

            if (string.IsNullOrEmpty(password))
            {
                SetError(txtPassword, "Vui lòng nhập mật khẩu.");
                return;
            }

            if (password.Length < 6)
            {
                SetError(txtPassword, "Mật khẩu phải có ít nhất 6 ký tự.");
                return;
            }

            if (confirmPwd != password)
            {
                SetError(txtConfirmPwd, "Xác nhận mật khẩu không khớp.");
                return;
            }

            // --- Tạo User object rồi gọi service ---
            var newUser = new User
            {
                FullName = fullName,
                Email = email,
                CreatedAt = DateTime.Now
            };

            bool success = _userService.Register(newUser, password);

            if (success)
            {
                MessageBox.Show(
                    "Tài khoản đã được tạo thành công!\nVui lòng đăng nhập để tiếp tục.",
                    "Đăng ký thành công",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);

                var loginForm = new LoginForm();
                loginForm.Show();
                this.Close();
            }
            else
            {
                SetError(txtEmail, "Email này đã được sử dụng. Vui lòng thử email khác.");
            }
        }

        // =====================================================
        // CHUYỂN VỀ ĐĂNG NHẬP
        // =====================================================
        private void lnkSignIn_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            var loginForm = new LoginForm();
            loginForm.Show();
            this.Close();
        }

        // =====================================================
        // HELPERS
        // =====================================================
        private bool IsValidEmail(string email)
        {
            return Regex.IsMatch(email,
                @"^[^@\s]+@[^@\s]+\.[^@\s]+$",
                RegexOptions.IgnoreCase);
        }

        private void SetError(Guna.UI2.WinForms.Guna2TextBox field, string message)
        {
            field.BorderColor = Color.FromArgb(220, 60, 60);
            field.FocusedState.BorderColor = Color.FromArgb(220, 60, 60);
            MessageBox.Show(message, "Lỗi nhập liệu",
                MessageBoxButtons.OK, MessageBoxIcon.Warning);
            field.Focus();
        }

        private void ResetAllErrors()
        {
            var normal = Color.FromArgb(210, 215, 220);
            var focus = Color.FromArgb(22, 22, 22);

            foreach (var tb in new[] { txtFullName, txtEmail, txtPassword, txtConfirmPwd })
            {
                tb.BorderColor = normal;
                tb.FocusedState.BorderColor = focus;
            }
        }
    }
}