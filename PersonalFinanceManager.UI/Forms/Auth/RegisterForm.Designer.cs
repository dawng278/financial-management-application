using System.Drawing;
using System.Windows.Forms;

namespace PersonalFinanceManager.Forms.Auth
{
    partial class RegisterForm : Form
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
            this.lblFullName = new System.Windows.Forms.Label();
            this.txtFullName = new Guna.UI2.WinForms.Guna2TextBox();
            this.lblEmail = new System.Windows.Forms.Label();
            this.txtEmail = new Guna.UI2.WinForms.Guna2TextBox();
            this.lblPassword = new System.Windows.Forms.Label();
            this.txtPassword = new Guna.UI2.WinForms.Guna2TextBox();
            this.lblConfirmPwd = new System.Windows.Forms.Label();
            this.txtConfirmPwd = new Guna.UI2.WinForms.Guna2TextBox();
            this.btnRegister = new Guna.UI2.WinForms.Guna2Button();
            this.lblHaveAccount = new System.Windows.Forms.Label();
            this.lnkSignIn = new System.Windows.Forms.LinkLabel();
            this.pnlSignInUnderline = new System.Windows.Forms.Panel();
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
            this.panelLeft.Controls.Add(this.lblFullName);
            this.panelLeft.Controls.Add(this.txtFullName);
            this.panelLeft.Controls.Add(this.lblEmail);
            this.panelLeft.Controls.Add(this.txtEmail);
            this.panelLeft.Controls.Add(this.lblPassword);
            this.panelLeft.Controls.Add(this.txtPassword);
            this.panelLeft.Controls.Add(this.lblConfirmPwd);
            this.panelLeft.Controls.Add(this.txtConfirmPwd);
            this.panelLeft.Controls.Add(this.btnRegister);
            this.panelLeft.Controls.Add(this.lblHaveAccount);
            this.panelLeft.Controls.Add(this.lnkSignIn);
            this.panelLeft.Controls.Add(this.pnlSignInUnderline);
            this.panelLeft.Location = new System.Drawing.Point(0, 0);
            this.panelLeft.Name = "panelLeft";
            this.panelLeft.Size = new System.Drawing.Size(640, 747);
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
            this.btnClose.Location = new System.Drawing.Point(590, 17);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(37, 34);
            this.btnClose.TabIndex = 0;
            this.btnClose.Text = "✕";
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // picLogo
            // 
            this.picLogo.BackColor = System.Drawing.Color.Transparent;
            this.picLogo.Location = new System.Drawing.Point(91, 49);
            this.picLogo.Name = "picLogo";
            this.picLogo.Size = new System.Drawing.Size(46, 43);
            this.picLogo.TabIndex = 1;
            this.picLogo.TabStop = false;
            this.picLogo.Paint += new System.Windows.Forms.PaintEventHandler(this.picLogo_Paint);
            // 
            // lblLogoText
            // 
            this.lblLogoText.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.lblLogoText.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(22)))), ((int)(((byte)(22)))));
            this.lblLogoText.Location = new System.Drawing.Point(143, 49);
            this.lblLogoText.Name = "lblLogoText";
            this.lblLogoText.Size = new System.Drawing.Size(282, 45);
            this.lblLogoText.TabIndex = 2;
            this.lblLogoText.Text = "FinancialApp";
            // 
            // lblTitle
            // 
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 26F, System.Drawing.FontStyle.Bold);
            this.lblTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(18)))), ((int)(((byte)(18)))), ((int)(((byte)(18)))));
            this.lblTitle.Location = new System.Drawing.Point(91, 110);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(503, 71);
            this.lblTitle.TabIndex = 3;
            this.lblTitle.Text = "Tạo tài khoản mới";
            // 
            // lblSubtitle
            // 
            this.lblSubtitle.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblSubtitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(140)))), ((int)(((byte)(140)))), ((int)(((byte)(140)))));
            this.lblSubtitle.Location = new System.Drawing.Point(91, 181);
            this.lblSubtitle.Name = "lblSubtitle";
            this.lblSubtitle.Size = new System.Drawing.Size(480, 37);
            this.lblSubtitle.TabIndex = 4;
            this.lblSubtitle.Text = "Vui lòng điền đầy đủ thông tin bên dưới.";
            // 
            // lblFullName
            // 
            this.lblFullName.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.lblFullName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(35)))), ((int)(((byte)(35)))));
            this.lblFullName.Location = new System.Drawing.Point(91, 229);
            this.lblFullName.Name = "lblFullName";
            this.lblFullName.Size = new System.Drawing.Size(229, 23);
            this.lblFullName.TabIndex = 5;
            this.lblFullName.Text = "Họ và tên";
            // 
            // txtFullName
            // 
            this.txtFullName.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(210)))), ((int)(((byte)(215)))), ((int)(((byte)(220)))));
            this.txtFullName.BorderRadius = 10;
            this.txtFullName.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtFullName.DefaultText = "";
            this.txtFullName.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(22)))), ((int)(((byte)(22)))));
            this.txtFullName.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtFullName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(35)))), ((int)(((byte)(35)))));
            this.txtFullName.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(150)))), ((int)(((byte)(155)))), ((int)(((byte)(160)))));
            this.txtFullName.Location = new System.Drawing.Point(91, 257);
            this.txtFullName.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.txtFullName.Name = "txtFullName";
            this.txtFullName.PlaceholderText = "Nhập họ và tên đầy đủ";
            this.txtFullName.SelectedText = "";
            this.txtFullName.Size = new System.Drawing.Size(457, 51);
            this.txtFullName.TabIndex = 0;
            // 
            // lblEmail
            // 
            this.lblEmail.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.lblEmail.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(35)))), ((int)(((byte)(35)))));
            this.lblEmail.Location = new System.Drawing.Point(91, 327);
            this.lblEmail.Name = "lblEmail";
            this.lblEmail.Size = new System.Drawing.Size(229, 23);
            this.lblEmail.TabIndex = 6;
            this.lblEmail.Text = "Email";
            // 
            // txtEmail
            // 
            this.txtEmail.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(210)))), ((int)(((byte)(215)))), ((int)(((byte)(220)))));
            this.txtEmail.BorderRadius = 10;
            this.txtEmail.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtEmail.DefaultText = "";
            this.txtEmail.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(22)))), ((int)(((byte)(22)))));
            this.txtEmail.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtEmail.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(35)))), ((int)(((byte)(35)))));
            this.txtEmail.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(150)))), ((int)(((byte)(155)))), ((int)(((byte)(160)))));
            this.txtEmail.Location = new System.Drawing.Point(91, 355);
            this.txtEmail.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.PlaceholderText = "example@gmail.com";
            this.txtEmail.SelectedText = "";
            this.txtEmail.Size = new System.Drawing.Size(457, 51);
            this.txtEmail.TabIndex = 1;
            // 
            // lblPassword
            // 
            this.lblPassword.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.lblPassword.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(35)))), ((int)(((byte)(35)))));
            this.lblPassword.Location = new System.Drawing.Point(91, 426);
            this.lblPassword.Name = "lblPassword";
            this.lblPassword.Size = new System.Drawing.Size(229, 23);
            this.lblPassword.TabIndex = 7;
            this.lblPassword.Text = "Mật khẩu";
            // 
            // txtPassword
            // 
            this.txtPassword.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(210)))), ((int)(((byte)(215)))), ((int)(((byte)(220)))));
            this.txtPassword.BorderRadius = 10;
            this.txtPassword.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtPassword.DefaultText = "";
            this.txtPassword.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(22)))), ((int)(((byte)(22)))));
            this.txtPassword.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtPassword.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(150)))), ((int)(((byte)(155)))), ((int)(((byte)(160)))));
            this.txtPassword.Location = new System.Drawing.Point(91, 453);
            this.txtPassword.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.PasswordChar = '●';
            this.txtPassword.PlaceholderText = "Nhập mật khẩu";
            this.txtPassword.SelectedText = "";
            this.txtPassword.Size = new System.Drawing.Size(457, 51);
            this.txtPassword.TabIndex = 2;
            this.txtPassword.UseSystemPasswordChar = true;
            // 
            // lblConfirmPwd
            // 
            this.lblConfirmPwd.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.lblConfirmPwd.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(35)))), ((int)(((byte)(35)))));
            this.lblConfirmPwd.Location = new System.Drawing.Point(91, 524);
            this.lblConfirmPwd.Name = "lblConfirmPwd";
            this.lblConfirmPwd.Size = new System.Drawing.Size(286, 23);
            this.lblConfirmPwd.TabIndex = 8;
            this.lblConfirmPwd.Text = "Xác nhận mật khẩu";
            // 
            // txtConfirmPwd
            // 
            this.txtConfirmPwd.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(210)))), ((int)(((byte)(215)))), ((int)(((byte)(220)))));
            this.txtConfirmPwd.BorderRadius = 10;
            this.txtConfirmPwd.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtConfirmPwd.DefaultText = "";
            this.txtConfirmPwd.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(22)))), ((int)(((byte)(22)))));
            this.txtConfirmPwd.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtConfirmPwd.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(150)))), ((int)(((byte)(155)))), ((int)(((byte)(160)))));
            this.txtConfirmPwd.Location = new System.Drawing.Point(91, 551);
            this.txtConfirmPwd.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.txtConfirmPwd.Name = "txtConfirmPwd";
            this.txtConfirmPwd.PasswordChar = '●';
            this.txtConfirmPwd.PlaceholderText = "Nhập lại mật khẩu";
            this.txtConfirmPwd.SelectedText = "";
            this.txtConfirmPwd.Size = new System.Drawing.Size(457, 51);
            this.txtConfirmPwd.TabIndex = 3;
            this.txtConfirmPwd.UseSystemPasswordChar = true;
            // 
            // btnRegister
            // 
            this.btnRegister.BorderRadius = 12;
            this.btnRegister.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnRegister.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(181)))), ((int)(((byte)(212)))), ((int)(((byte)(34)))));
            this.btnRegister.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.btnRegister.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(22)))), ((int)(((byte)(22)))));
            this.btnRegister.HoverState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(158)))), ((int)(((byte)(190)))), ((int)(((byte)(20)))));
            this.btnRegister.Location = new System.Drawing.Point(91, 624);
            this.btnRegister.Name = "btnRegister";
            this.btnRegister.Size = new System.Drawing.Size(457, 55);
            this.btnRegister.TabIndex = 4;
            this.btnRegister.Text = "Tạo tài khoản";
            this.btnRegister.Click += new System.EventHandler(this.btnRegister_Click);
            // 
            // lblHaveAccount
            // 
            this.lblHaveAccount.AutoSize = true;
            this.lblHaveAccount.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.lblHaveAccount.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(130)))), ((int)(((byte)(130)))), ((int)(((byte)(130)))));
            this.lblHaveAccount.Location = new System.Drawing.Point(145, 694);
            this.lblHaveAccount.Name = "lblHaveAccount";
            this.lblHaveAccount.Size = new System.Drawing.Size(124, 21);
            this.lblHaveAccount.TabIndex = 9;
            this.lblHaveAccount.Text = "Đã có tài khoản?";
            // 
            // lnkSignIn
            // 
            this.lnkSignIn.ActiveLinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(100)))), ((int)(((byte)(100)))));
            this.lnkSignIn.AutoSize = true;
            this.lnkSignIn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lnkSignIn.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.lnkSignIn.LinkBehavior = System.Windows.Forms.LinkBehavior.NeverUnderline;
            this.lnkSignIn.LinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(22)))), ((int)(((byte)(22)))));
            this.lnkSignIn.Location = new System.Drawing.Point(354, 694);
            this.lnkSignIn.Name = "lnkSignIn";
            this.lnkSignIn.Size = new System.Drawing.Size(94, 21);
            this.lnkSignIn.TabIndex = 10;
            this.lnkSignIn.TabStop = true;
            this.lnkSignIn.Text = "Đăng nhập";
            this.lnkSignIn.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkSignIn_LinkClicked);
            // 
            // pnlSignInUnderline
            // 
            this.pnlSignInUnderline.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(181)))), ((int)(((byte)(212)))), ((int)(((byte)(34)))));
            this.pnlSignInUnderline.Location = new System.Drawing.Point(358, 718);
            this.pnlSignInUnderline.Name = "pnlSignInUnderline";
            this.pnlSignInUnderline.Size = new System.Drawing.Size(82, 2);
            this.pnlSignInUnderline.TabIndex = 11;
            // 
            // panelRight
            // 
            this.panelRight.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(218)))), ((int)(((byte)(220)))), ((int)(((byte)(216)))));
            this.panelRight.Controls.Add(this.picBackground);
            this.panelRight.Location = new System.Drawing.Point(640, 0);
            this.panelRight.Name = "panelRight";
            this.panelRight.Size = new System.Drawing.Size(700, 747);
            this.panelRight.TabIndex = 1;
            // 
            // picBackground
            // 
            this.picBackground.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(218)))), ((int)(((byte)(220)))), ((int)(((byte)(216)))));
            this.picBackground.Dock = System.Windows.Forms.DockStyle.Fill;
            this.picBackground.Location = new System.Drawing.Point(0, 0);
            this.picBackground.Name = "picBackground";
            this.picBackground.Size = new System.Drawing.Size(731, 747);
            this.picBackground.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picBackground.TabIndex = 0;
            this.picBackground.TabStop = false;
            // 
            // RegisterForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1320, 747);
            this.Controls.Add(this.panelLeft);
            this.Controls.Add(this.panelRight);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "RegisterForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Đăng Ký";
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
        private System.Windows.Forms.Label lblFullName;
        private Guna.UI2.WinForms.Guna2TextBox txtFullName;
        private System.Windows.Forms.Label lblEmail;
        private Guna.UI2.WinForms.Guna2TextBox txtEmail;
        private System.Windows.Forms.Label lblPassword;
        private Guna.UI2.WinForms.Guna2TextBox txtPassword;
        private System.Windows.Forms.Label lblConfirmPwd;
        private Guna.UI2.WinForms.Guna2TextBox txtConfirmPwd;
        private Guna.UI2.WinForms.Guna2Button btnRegister;
        private System.Windows.Forms.Label lblHaveAccount;
        private System.Windows.Forms.LinkLabel lnkSignIn;
        private System.Windows.Forms.Panel pnlSignInUnderline;
    }
}