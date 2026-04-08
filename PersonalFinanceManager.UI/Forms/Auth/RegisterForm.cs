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
            
            PersonalFinanceManager.Common.Helpers.ConfigHelper.LanguageChanged += (s, e) => {
                if (this.IsHandleCreated) this.Invoke(new Action(UpdateTranslations));
            };
            UpdateTranslations();
        }

        private void UpdateTranslations()
        {
            lblLogo.Text = tr("Executive Finance");
            lblTitle.Text = tr("Join the\nElite Circle of\nWealth\nManagement.");
            lblSubtitle.Text = tr("Elevate your financial trajectory with our precision-engineered executive workspace.");
            lblFeature1.Text = tr(".   Bank-grade encryption protocol");
            lblFeature2.Text = tr(".   Real-time market synchronization");
            lblRightTitle.Text = tr("Create Account");
            lblRightSub.Text = tr("Initialize your premium financial profile.");
            lblName.Text = tr("Full Name");
            lblEmail.Text = tr("Email Address");
            lblExecId.Text = tr("Executive ID");
            lblPass.Text = tr("Password");
            lblConfPass.Text = tr("Confirm Password");
            chkTerms.Text = tr("I acknowledge the Executive Terms of Service and consent to the data protocols.");
            btnRegister.Text = tr("Create Account");
            lnkSignIn.Text = tr("Already have an account? Back to Login");
            lblFooterCopy.Text = tr("2024 EXECUTIVE FINANCE GLOBAL");
            lblFooterPriv.Text = tr("PRIVACY POLICY");
            lblFooterReg.Text = tr("REGULATORY DISCLOSURE");
        }

        // =====================================================
        // LOAD
        // =====================================================
        private void RegisterForm_Load(object sender, EventArgs e)
        {
            txtFullName.Focus();
        }

        // =====================================================
        // CLOSE
        // =====================================================
        private void btnClose_Click(object sender, EventArgs e) => Application.Exit();

        // =====================================================
        // REGISTER
        // =====================================================
        private void btnRegister_Click(object sender, EventArgs e)
        {
            ResetAllErrors();

            string fullName = txtFullName.Text.Trim();
            string email = txtEmail.Text.Trim();
            string executiveId = txtExecutiveId.Text.Trim();
            string password = txtPassword.Text;
            string confirmPwd = txtConfirmPwd.Text;

            // --- Validation ---
            if (string.IsNullOrEmpty(fullName))
            {
                SetError(txtFullName, tr("Please enter your full name."));
                return;
            }

            if (string.IsNullOrEmpty(email))
            {
                SetError(txtEmail, tr("Please enter your email."));
                return;
            }

            if (!IsValidEmail(email))
            {
                SetError(txtEmail, tr("Invalid email address."));
                return;
            }

            if (string.IsNullOrEmpty(password))
            {
                SetError(txtPassword, tr("Please enter your password."));
                return;
            }

            // (NEW) Executive ID is optional, if empty it uses email as username in backend, but good to have if user filled it
            
            if (password.Length < 6)
            {
                SetError(txtPassword, tr("Password must be at least 6 characters."));
                return;
            }

            if (confirmPwd != password)
            {
                SetError(txtConfirmPwd, tr("Confirm password does not match."));
                return;
            }

            // --- Create User object and call service ---
            var newUser = new User
            {
                FullName = fullName,
                Email = email,
                Username = string.IsNullOrEmpty(executiveId) ? email : executiveId,
                CreatedAt = DateTime.Now
            };

            bool success = _userService.Register(newUser, password);

            if (success)
            {
                MessageBox.Show(
                    tr("Account created successfully!\nPlease log in to continue."),
                    tr("Success"),
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);

                PersonalFinanceManager.UI.Navigation.FormNavigator.GoToLogin();
            }
            else
            {
                SetError(txtEmail, tr("This email is already in use. Please try another."));
            }
        }

        // =====================================================
        // BACK TO LOGIN
        // =====================================================
        private void lnkSignIn_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            PersonalFinanceManager.UI.Navigation.FormNavigator.GoToLogin();
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

        private void SetError(ReaLTaiizor.Controls.HopeTextBox field, string message)
        {
            MessageBox.Show(message, tr("Input Error"),
                MessageBoxButtons.OK, MessageBoxIcon.Warning);
            field.Focus();
        }

        private string tr(string key) => PersonalFinanceManager.Common.Helpers.ConfigHelper.Translate(key);

        private void ResetAllErrors()
        {
            // Reset logic if needed
        }
    }
}
