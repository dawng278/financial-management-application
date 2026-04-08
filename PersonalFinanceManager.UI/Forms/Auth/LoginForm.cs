using System;
using System.Drawing;
using System.Windows.Forms;
using PersonalFinanceManager.Common.Interfaces;
using PersonalFinanceManager.Infrastructure.DI;

namespace PersonalFinanceManager.Forms.Auth
{
    public partial class LoginForm : Form
    {
        private readonly IUserService _userService;
        private readonly string _rememberConfig = System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "remember_me.cfg");

        public LoginForm()
        {
            InitializeComponent();
            _userService = ServiceLocator.UserService;
            this.Load += LoginForm_Load;
            
            // 1. Enter key support
            this.KeyPreview = true;
            this.AcceptButton = btnSignIn as IButtonControl;
            
            // 2. Anchor close button to top right
            btnClose.Anchor = AnchorStyles.Top | AnchorStyles.Right;

            PersonalFinanceManager.Common.Helpers.ConfigHelper.LanguageChanged += (s, e) => {
                if (this.IsHandleCreated) this.Invoke(new Action(UpdateTranslations));
            };
            UpdateTranslations();
        }

        // Responsive centering logic
        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);
            CenterLayout();
        }

        private void CenterLayout()
        {
            if (pnlCard == null) return;
            this.SuspendLayout();

            int centerX = this.ClientSize.Width / 2;
            int centerY = this.ClientSize.Height / 2;

            // Positioning relative to center
            pnlCard.Location = new Point(centerX - pnlCard.Width / 2, centerY - pnlCard.Height / 2 + 20);
            pnlLogo.Location = new Point(centerX - pnlLogo.Width / 2, pnlCard.Top - 180);
            lblTitle.Location = new Point(centerX - lblTitle.Width / 2, pnlLogo.Bottom + 15);
            lblSubtitle.Location = new Point(centerX - lblSubtitle.Width / 2, lblTitle.Bottom + 5);

            lblNew.Location = new Point(centerX - lblNew.Width / 2, pnlCard.Bottom + 30);
            int linksWidth = lnkRequest.Width + lnkSignUp.Width + 10;
            lnkRequest.Location = new Point(centerX - linksWidth / 2, lblNew.Bottom + 10);
            lnkSignUp.Location = new Point(lnkRequest.Right + 10, lblNew.Bottom + 10);

            lblSecure.Location = new Point(centerX - lblSecure.Width / 2, this.ClientSize.Height - 50);

            this.ResumeLayout();
        }

        protected override void OnKeyDown(KeyEventArgs e)
        {
            base.OnKeyDown(e);
            if (e.KeyCode == Keys.Enter)
            {
                btnSignIn_Click(btnSignIn, EventArgs.Empty);
                e.Handled = true;
                e.SuppressKeyPress = true;
            }
        }

        private void LoginForm_Load(object sender, EventArgs e)
        {
            UpdateTranslations();
            if (System.IO.File.Exists(_rememberConfig))
            {
                try
                {
                    string savedUser = System.IO.File.ReadAllText(_rememberConfig).Trim();
                    if (!string.IsNullOrEmpty(savedUser))
                    {
                        txtEmail.Text = savedUser;
                        chkRemember.Checked = true;
                    }
                }
                catch { }
            }

            if (string.IsNullOrEmpty(txtEmail.Text))
                txtEmail.Focus();
            else
                txtPassword.Focus();
        }

        private void UpdateTranslations()
        {
            this.Text = tr("Login - Executive Finance");
            lblTitle.Text = tr("Executive Finance");
            lblSubtitle.Text = tr("Premium Workspace Access");
            lblUserLabel.Text = tr("USERNAME / EXECUTIVE ID");
            lblPassLabel.Text = tr("SECURE PASSWORD");
            chkRemember.Text = tr("Remember me");
            lnkForgotPassword.Text = tr("Forgot password?");
            btnSignIn.Text = tr("Login Now");
            lblNew.Text = tr("New to the executive tier?");
            lnkRequest.Text = tr("Request Access");
            lnkSignUp.Text = tr("Sign Up Now");
            lblSecure.Text = tr("VERIFIED SECURE      AES-256 AUTH");
            CenterLayout();
        }

        private void btnClose_Click(object sender, EventArgs e) => Application.Exit();

        private void btnSignIn_Click(object sender, EventArgs e)
        {
            // The field can be either Email or Executive ID (Username)
            string identifier = txtEmail.Text.Trim();
            string password = txtPassword.Text;

            if (string.IsNullOrEmpty(identifier)) { SetError(txtEmail, tr("Please enter your Username / Executive ID.")); return; }
            if (string.IsNullOrEmpty(password)) { SetError(txtPassword, tr("Please enter your password.")); return; }

            bool success = _userService.Login(identifier, password);

            if (success)
            {
                if (chkRemember.Checked)
                {
                    try { System.IO.File.WriteAllText(_rememberConfig, identifier); } catch { }
                }
                else
                {
                    try { if (System.IO.File.Exists(_rememberConfig)) System.IO.File.Delete(_rememberConfig); } catch { }
                }

                PersonalFinanceManager.UI.Navigation.FormNavigator.GoToDashboard();
            }
            else
            {
                SetError(txtPassword, tr("Invalid credentials or unauthorized tier."));
            }
        }

        private void lnkForgotPassword_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            MessageBox.Show(tr("Forgot password recovery process will go here."), tr("Notification"), MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void lnkSignUp_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            PersonalFinanceManager.UI.Navigation.FormNavigator.GoToRegister();
        }

        private void SetError(ReaLTaiizor.Controls.HopeTextBox field, string message)
        {
            MessageBox.Show(message, tr("Authentication Error"), MessageBoxButtons.OK, MessageBoxIcon.Warning);
            field.Focus();
        }

        private string tr(string key) => PersonalFinanceManager.Common.Helpers.ConfigHelper.Translate(key);
    }
}
