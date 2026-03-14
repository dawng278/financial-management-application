using System.Drawing;
using System.Windows.Forms;

namespace PersonalFinanceManager.Forms.Auth
{
    partial class LoginForm : Form
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.guna2Elipse1 = new Guna.UI2.WinForms.Guna2Elipse(this.components);
            this.guna2ShadowForm1 = new Guna.UI2.WinForms.Guna2ShadowForm(this.components);
            this.guna2DragControl1 = new Guna.UI2.WinForms.Guna2DragControl(this.components);
            this.panelLeft = new System.Windows.Forms.Panel();
            this.btnClose = new Guna.UI2.WinForms.Guna2Button();
            this.picLogo = new System.Windows.Forms.PictureBox();
            this.lblLogoText = new System.Windows.Forms.Label();
            this.lblTitle = new System.Windows.Forms.Label();
            this.lblSubtitle = new System.Windows.Forms.Label();
            this.lblEmail = new System.Windows.Forms.Label();
            this.txtEmail = new Guna.UI2.WinForms.Guna2TextBox();
            this.lblPassword = new System.Windows.Forms.Label();
            this.txtPassword = new Guna.UI2.WinForms.Guna2TextBox();
            this.chkRemember = new System.Windows.Forms.CheckBox();
            this.lnkForgotPassword = new System.Windows.Forms.LinkLabel();
            this.btnSignIn = new Guna.UI2.WinForms.Guna2Button();
            this.lblNoAccount = new System.Windows.Forms.Label();
            this.lnkSignUp = new System.Windows.Forms.LinkLabel();
            this.pnlSignUpUnderline = new System.Windows.Forms.Panel();
            this.panelRight = new System.Windows.Forms.Panel();
            this.picBackground = new System.Windows.Forms.PictureBox();
            this.panelLeft.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picLogo)).BeginInit();
            this.panelRight.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picBackground)).BeginInit();
            this.SuspendLayout();
            // 
            // guna2Elipse1
            // 
            this.guna2Elipse1.BorderRadius = 16;
            this.guna2Elipse1.TargetControl = this;
            // 
            // guna2ShadowForm1
            // 
            this.guna2ShadowForm1.TargetForm = this;
            // 
            // guna2DragControl1
            // 
            this.guna2DragControl1.DockIndicatorTransparencyValue = 0.6D;
            this.guna2DragControl1.TargetControl = this.panelLeft;
            this.guna2DragControl1.UseTransparentDrag = true;
            // 
            // panelLeft
            // 
            this.panelLeft.BackColor = System.Drawing.Color.White;
            this.panelLeft.Controls.Add(this.btnClose);
            this.panelLeft.Controls.Add(this.picLogo);
            this.panelLeft.Controls.Add(this.lblLogoText);
            this.panelLeft.Controls.Add(this.lblTitle);
            this.panelLeft.Controls.Add(this.lblSubtitle);
            this.panelLeft.Controls.Add(this.lblEmail);
            this.panelLeft.Controls.Add(this.txtEmail);
            this.panelLeft.Controls.Add(this.lblPassword);
            this.panelLeft.Controls.Add(this.txtPassword);
            this.panelLeft.Controls.Add(this.chkRemember);
            this.panelLeft.Controls.Add(this.lnkForgotPassword);
            this.panelLeft.Controls.Add(this.btnSignIn);
            this.panelLeft.Controls.Add(this.lblNoAccount);
            this.panelLeft.Controls.Add(this.lnkSignUp);
            this.panelLeft.Controls.Add(this.pnlSignUpUnderline);
            this.panelLeft.Location = new System.Drawing.Point(0, 0);
            this.panelLeft.Name = "panelLeft";
            this.panelLeft.Size = new System.Drawing.Size(571, 661);
            this.panelLeft.TabIndex = 0;
            // 
            // btnClose
            // 
            this.btnClose.BorderRadius = 14;
            this.btnClose.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnClose.FillColor = System.Drawing.Color.Transparent;
            this.btnClose.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnClose.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(160)))), ((int)(((byte)(160)))), ((int)(((byte)(160)))));
            this.btnClose.HoverState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(75)))), ((int)(((byte)(75)))));
            this.btnClose.HoverState.ForeColor = System.Drawing.Color.White;
            this.btnClose.Location = new System.Drawing.Point(521, 15);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(34, 32);
            this.btnClose.TabIndex = 0;
            this.btnClose.Text = "✕";
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // picLogo
            // 
            this.picLogo.BackColor = System.Drawing.Color.Transparent;
            this.picLogo.Location = new System.Drawing.Point(63, 49);
            this.picLogo.Name = "picLogo";
            this.picLogo.Size = new System.Drawing.Size(41, 38);
            this.picLogo.TabIndex = 1;
            this.picLogo.TabStop = false;
            this.picLogo.Paint += new System.Windows.Forms.PaintEventHandler(this.picLogo_Paint);
            // 
            // lblLogoText
            // 
            this.lblLogoText.Font = new System.Drawing.Font("Segoe UI", 13F, System.Drawing.FontStyle.Bold);
            this.lblLogoText.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(22)))), ((int)(((byte)(22)))));
            this.lblLogoText.Location = new System.Drawing.Point(112, 55);
            this.lblLogoText.Name = "lblLogoText";
            this.lblLogoText.Size = new System.Drawing.Size(227, 58);
            this.lblLogoText.TabIndex = 2;
            this.lblLogoText.Text = "FinancialApp";
            // 
            // lblTitle
            // 
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 22F, System.Drawing.FontStyle.Bold);
            this.lblTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(18)))), ((int)(((byte)(18)))), ((int)(((byte)(18)))));
            this.lblTitle.Location = new System.Drawing.Point(58, 113);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(457, 59);
            this.lblTitle.TabIndex = 3;
            this.lblTitle.Text = "Chào mừng trở lại";
            // 
            // lblSubtitle
            // 
            this.lblSubtitle.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.lblSubtitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(130)))), ((int)(((byte)(130)))), ((int)(((byte)(130)))));
            this.lblSubtitle.Location = new System.Drawing.Point(63, 181);
            this.lblSubtitle.Name = "lblSubtitle";
            this.lblSubtitle.Size = new System.Drawing.Size(434, 42);
            this.lblSubtitle.TabIndex = 4;
            this.lblSubtitle.Text = "Vui lòng nhập thông tin đăng nhập của bạn.";
            // 
            // lblEmail
            // 
            this.lblEmail.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblEmail.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(35)))), ((int)(((byte)(35)))));
            this.lblEmail.Location = new System.Drawing.Point(63, 237);
            this.lblEmail.Name = "lblEmail";
            this.lblEmail.Size = new System.Drawing.Size(229, 21);
            this.lblEmail.TabIndex = 5;
            this.lblEmail.Text = "Email";
            // 
            // txtEmail
            // 
            this.txtEmail.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(210)))), ((int)(((byte)(215)))), ((int)(((byte)(220)))));
            this.txtEmail.BorderRadius = 8;
            this.txtEmail.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtEmail.DefaultText = "";
            this.txtEmail.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(22)))), ((int)(((byte)(22)))));
            this.txtEmail.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.txtEmail.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(35)))), ((int)(((byte)(35)))));
            this.txtEmail.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(160)))), ((int)(((byte)(165)))), ((int)(((byte)(170)))));
            this.txtEmail.Location = new System.Drawing.Point(63, 261);
            this.txtEmail.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.PlaceholderText = "Nhập địa chỉ email";
            this.txtEmail.SelectedText = "";
            this.txtEmail.Size = new System.Drawing.Size(440, 47);
            this.txtEmail.TabIndex = 0;
            // 
            // lblPassword
            // 
            this.lblPassword.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblPassword.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(35)))), ((int)(((byte)(35)))));
            this.lblPassword.Location = new System.Drawing.Point(63, 324);
            this.lblPassword.Name = "lblPassword";
            this.lblPassword.Size = new System.Drawing.Size(229, 21);
            this.lblPassword.TabIndex = 6;
            this.lblPassword.Text = "Mật khẩu";
            // 
            // txtPassword
            // 
            this.txtPassword.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(210)))), ((int)(((byte)(215)))), ((int)(((byte)(220)))));
            this.txtPassword.BorderRadius = 8;
            this.txtPassword.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtPassword.DefaultText = "";
            this.txtPassword.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(22)))), ((int)(((byte)(22)))));
            this.txtPassword.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.txtPassword.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(160)))), ((int)(((byte)(165)))), ((int)(((byte)(170)))));
            this.txtPassword.Location = new System.Drawing.Point(63, 349);
            this.txtPassword.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.PasswordChar = '●';
            this.txtPassword.PlaceholderText = "Nhập mật khẩu";
            this.txtPassword.SelectedText = "";
            this.txtPassword.Size = new System.Drawing.Size(440, 47);
            this.txtPassword.TabIndex = 1;
            this.txtPassword.UseSystemPasswordChar = true;
            // 
            // chkRemember
            // 
            this.chkRemember.Cursor = System.Windows.Forms.Cursors.Hand;
            this.chkRemember.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(181)))), ((int)(((byte)(212)))), ((int)(((byte)(34)))));
            this.chkRemember.FlatAppearance.CheckedBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(181)))), ((int)(((byte)(212)))), ((int)(((byte)(34)))));
            this.chkRemember.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(245)))), ((int)(((byte)(180)))));
            this.chkRemember.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.chkRemember.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.chkRemember.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(65)))), ((int)(((byte)(65)))), ((int)(((byte)(65)))));
            this.chkRemember.Location = new System.Drawing.Point(63, 403);
            this.chkRemember.Name = "chkRemember";
            this.chkRemember.Size = new System.Drawing.Size(254, 48);
            this.chkRemember.TabIndex = 3;
            this.chkRemember.Text = "Ghi nhớ trong 30 ngày";
            // 
            // lnkForgotPassword
            // 
            this.lnkForgotPassword.ActiveLinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(120)))), ((int)(((byte)(120)))), ((int)(((byte)(120)))));
            this.lnkForgotPassword.AutoSize = true;
            this.lnkForgotPassword.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lnkForgotPassword.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lnkForgotPassword.LinkBehavior = System.Windows.Forms.LinkBehavior.NeverUnderline;
            this.lnkForgotPassword.LinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(35)))), ((int)(((byte)(35)))));
            this.lnkForgotPassword.Location = new System.Drawing.Point(351, 417);
            this.lnkForgotPassword.Name = "lnkForgotPassword";
            this.lnkForgotPassword.Size = new System.Drawing.Size(123, 20);
            this.lnkForgotPassword.TabIndex = 7;
            this.lnkForgotPassword.TabStop = true;
            this.lnkForgotPassword.Text = "Quên mật khẩu?";
            this.lnkForgotPassword.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkForgotPassword_LinkClicked);
            // 
            // btnSignIn
            // 
            this.btnSignIn.BorderRadius = 10;
            this.btnSignIn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSignIn.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(181)))), ((int)(((byte)(212)))), ((int)(((byte)(34)))));
            this.btnSignIn.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnSignIn.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(22)))), ((int)(((byte)(22)))));
            this.btnSignIn.HoverState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(158)))), ((int)(((byte)(190)))), ((int)(((byte)(20)))));
            this.btnSignIn.Location = new System.Drawing.Point(63, 468);
            this.btnSignIn.Name = "btnSignIn";
            this.btnSignIn.Size = new System.Drawing.Size(440, 51);
            this.btnSignIn.TabIndex = 2;
            this.btnSignIn.Text = "Đăng nhập";
            this.btnSignIn.Click += new System.EventHandler(this.btnSignIn_Click);
            // 
            // lblNoAccount
            // 
            this.lblNoAccount.AutoSize = true;
            this.lblNoAccount.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblNoAccount.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(130)))), ((int)(((byte)(130)))), ((int)(((byte)(130)))));
            this.lblNoAccount.Location = new System.Drawing.Point(114, 539);
            this.lblNoAccount.Name = "lblNoAccount";
            this.lblNoAccount.Size = new System.Drawing.Size(135, 20);
            this.lblNoAccount.TabIndex = 8;
            this.lblNoAccount.Text = "Chưa có tài khoản?";
            // 
            // lnkSignUp
            // 
            this.lnkSignUp.ActiveLinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(100)))), ((int)(((byte)(100)))));
            this.lnkSignUp.AutoSize = true;
            this.lnkSignUp.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lnkSignUp.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lnkSignUp.LinkBehavior = System.Windows.Forms.LinkBehavior.NeverUnderline;
            this.lnkSignUp.LinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(22)))), ((int)(((byte)(22)))));
            this.lnkSignUp.Location = new System.Drawing.Point(295, 539);
            this.lnkSignUp.Name = "lnkSignUp";
            this.lnkSignUp.Size = new System.Drawing.Size(131, 20);
            this.lnkSignUp.TabIndex = 9;
            this.lnkSignUp.TabStop = true;
            this.lnkSignUp.Text = "Đăng ký miễn phí";
            this.lnkSignUp.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkSignUp_LinkClicked);
            // 
            // pnlSignUpUnderline
            // 
            this.pnlSignUpUnderline.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(181)))), ((int)(((byte)(212)))), ((int)(((byte)(34)))));
            this.pnlSignUpUnderline.Location = new System.Drawing.Point(295, 557);
            this.pnlSignUpUnderline.Name = "pnlSignUpUnderline";
            this.pnlSignUpUnderline.Size = new System.Drawing.Size(119, 2);
            this.pnlSignUpUnderline.TabIndex = 10;
            // 
            // panelRight
            // 
            this.panelRight.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(218)))), ((int)(((byte)(220)))), ((int)(((byte)(216)))));
            this.panelRight.Controls.Add(this.picBackground);
            this.panelRight.Location = new System.Drawing.Point(571, 0);
            this.panelRight.Name = "panelRight";
            this.panelRight.Size = new System.Drawing.Size(571, 661);
            this.panelRight.TabIndex = 1;
            // 
            // picBackground
            // 
            this.picBackground.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(218)))), ((int)(((byte)(220)))), ((int)(((byte)(216)))));
            this.picBackground.Dock = System.Windows.Forms.DockStyle.Fill;
            this.picBackground.Location = new System.Drawing.Point(0, 0);
            this.picBackground.Name = "picBackground";
            this.picBackground.Size = new System.Drawing.Size(571, 661);
            this.picBackground.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picBackground.TabIndex = 0;
            this.picBackground.TabStop = false;
            // 
            // LoginForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1143, 661);
            this.Controls.Add(this.panelLeft);
            this.Controls.Add(this.panelRight);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "LoginForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Đăng Nhập";
            this.panelLeft.ResumeLayout(false);
            this.panelLeft.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picLogo)).EndInit();
            this.panelRight.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.picBackground)).EndInit();
            this.ResumeLayout(false);

        }

        private Guna.UI2.WinForms.Guna2Elipse guna2Elipse1;
        private Guna.UI2.WinForms.Guna2ShadowForm guna2ShadowForm1;
        private Guna.UI2.WinForms.Guna2DragControl guna2DragControl1;
        private System.Windows.Forms.Panel panelLeft;
        private System.Windows.Forms.Panel panelRight;
        private System.Windows.Forms.PictureBox picBackground;
        private Guna.UI2.WinForms.Guna2Button btnClose;
        private System.Windows.Forms.PictureBox picLogo;
        private System.Windows.Forms.Label lblLogoText;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblSubtitle;
        private System.Windows.Forms.Label lblEmail;
        private Guna.UI2.WinForms.Guna2TextBox txtEmail;
        private System.Windows.Forms.Label lblPassword;
        private Guna.UI2.WinForms.Guna2TextBox txtPassword;
        private System.Windows.Forms.CheckBox chkRemember;
        private System.Windows.Forms.LinkLabel lnkForgotPassword;
        private Guna.UI2.WinForms.Guna2Button btnSignIn;
        private System.Windows.Forms.Label lblNoAccount;
        private System.Windows.Forms.LinkLabel lnkSignUp;
        private System.Windows.Forms.Panel pnlSignUpUnderline;
    }
}