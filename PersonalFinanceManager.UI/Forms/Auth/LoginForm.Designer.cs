using System;
using System.ComponentModel;
using System.Windows.Forms;

namespace PersonalFinanceManager.Forms.Auth
{
    partial class LoginForm
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.btnClose = new ReaLTaiizor.Controls.HopeButton();
            // Header
            this.pnlLogo = new System.Windows.Forms.Panel();
            this.lblTitle = new System.Windows.Forms.Label();
            this.lblSubtitle = new System.Windows.Forms.Label();

            // Card
            this.pnlCard = new System.Windows.Forms.Panel();
            this.lblUserLabel = new System.Windows.Forms.Label();
            this.txtEmail = new ReaLTaiizor.Controls.HopeTextBox();
            this.lblPassLabel = new System.Windows.Forms.Label();
            this.txtPassword = new ReaLTaiizor.Controls.HopeTextBox();
            this.chkRemember = new System.Windows.Forms.CheckBox();
            this.lnkForgotPassword = new System.Windows.Forms.LinkLabel();
            this.btnSignIn = new ReaLTaiizor.Controls.HopeButton();

            // Footer
            this.lblNew = new System.Windows.Forms.Label();
            this.lnkRequest = new System.Windows.Forms.LinkLabel();
            this.lnkSignUp = new System.Windows.Forms.LinkLabel();
            this.lblSecure = new System.Windows.Forms.Label();

            this.pnlCard.SuspendLayout();
            this.SuspendLayout();

            // 
            // LoginForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(242, 243, 247);
            this.ClientSize = new System.Drawing.Size(1024, 768);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Login - Executive Finance";

            // btnClose
            this.btnClose.Location = new System.Drawing.Point(970, 20);
            this.btnClose.Size = new System.Drawing.Size(40, 40);
            this.btnClose.Text = "X";
            this.btnClose.PrimaryColor = System.Drawing.Color.FromArgb(200, 200, 200);
            this.btnClose.ForeColor = System.Drawing.Color.Gray;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);

            // ----------------------------------------------------------------
            // HEADER
            // ----------------------------------------------------------------
            this.pnlLogo.BackColor = System.Drawing.Color.FromArgb(52, 75, 90);
            this.pnlLogo.Location = new System.Drawing.Point(472, 80);
            this.pnlLogo.Size = new System.Drawing.Size(80, 80);

            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 24F, System.Drawing.FontStyle.Bold);
            this.lblTitle.ForeColor = System.Drawing.Color.FromArgb(10, 15, 20);
            this.lblTitle.Location = new System.Drawing.Point(340, 180);
            this.lblTitle.Text = "Executive Finance";
            this.lblTitle.Size = new System.Drawing.Size(344, 45);
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;

            this.lblSubtitle.AutoSize = true;
            this.lblSubtitle.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.lblSubtitle.ForeColor = System.Drawing.Color.FromArgb(120, 120, 120);
            this.lblSubtitle.Location = new System.Drawing.Point(410, 235);
            this.lblSubtitle.Text = "Premium Workspace Access";
            this.lblSubtitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;

            // ----------------------------------------------------------------
            // CARD
            // ----------------------------------------------------------------
            this.pnlCard.BackColor = System.Drawing.Color.White;
            this.pnlCard.Location = new System.Drawing.Point(312, 290);
            this.pnlCard.Size = new System.Drawing.Size(400, 320);

            this.lblUserLabel.AutoSize = true;
            this.lblUserLabel.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Bold);
            this.lblUserLabel.ForeColor = System.Drawing.Color.Gray;
            this.lblUserLabel.Location = new System.Drawing.Point(30, 30);
            this.lblUserLabel.Text = "USERNAME / EXECUTIVE ID";

            this.txtEmail.Location = new System.Drawing.Point(30, 55);
            this.txtEmail.Size = new System.Drawing.Size(340, 40);
            this.txtEmail.Text = "";
            
            this.lblPassLabel.AutoSize = true;
            this.lblPassLabel.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Bold);
            this.lblPassLabel.ForeColor = System.Drawing.Color.Gray;
            this.lblPassLabel.Location = new System.Drawing.Point(30, 115);
            this.lblPassLabel.Text = "SECURE PASSWORD";

            this.txtPassword.Location = new System.Drawing.Point(30, 140);
            this.txtPassword.Size = new System.Drawing.Size(340, 40);
            this.txtPassword.UseSystemPasswordChar = true;

            this.chkRemember.AutoSize = true;
            this.chkRemember.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.chkRemember.ForeColor = System.Drawing.Color.FromArgb(80, 80, 80);
            this.chkRemember.Location = new System.Drawing.Point(30, 195);
            this.chkRemember.Text = "Remember me";

            this.lnkForgotPassword.AutoSize = true;
            this.lnkForgotPassword.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lnkForgotPassword.LinkColor = System.Drawing.Color.FromArgb(80, 80, 100);
            this.lnkForgotPassword.LinkBehavior = System.Windows.Forms.LinkBehavior.NeverUnderline;
            this.lnkForgotPassword.Location = new System.Drawing.Point(260, 197);
            this.lnkForgotPassword.Text = "Forgot password?";
            this.lnkForgotPassword.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkForgotPassword_LinkClicked);

            this.btnSignIn.Location = new System.Drawing.Point(30, 240);
            this.btnSignIn.Size = new System.Drawing.Size(340, 45);
            this.btnSignIn.PrimaryColor = System.Drawing.Color.FromArgb(250, 20, 120); // Vibrant Pink
            this.btnSignIn.Text = "Login Now";
            this.btnSignIn.Click += new System.EventHandler(this.btnSignIn_Click);

            this.pnlCard.Controls.Add(this.lblUserLabel);
            this.pnlCard.Controls.Add(this.txtEmail);
            this.pnlCard.Controls.Add(this.lblPassLabel);
            this.pnlCard.Controls.Add(this.txtPassword);
            this.pnlCard.Controls.Add(this.chkRemember);
            this.pnlCard.Controls.Add(this.lnkForgotPassword);
            this.pnlCard.Controls.Add(this.btnSignIn);

            // ----------------------------------------------------------------
            // FOOTER
            // ----------------------------------------------------------------
            this.lblNew.AutoSize = true;
            this.lblNew.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblNew.ForeColor = System.Drawing.Color.Gray;
            this.lblNew.Location = new System.Drawing.Point(435, 630);
            this.lblNew.Text = "New to the executive tier?";

            this.lnkRequest.AutoSize = true;
            this.lnkRequest.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lnkRequest.LinkColor = System.Drawing.Color.FromArgb(250, 20, 120);
            this.lnkRequest.LinkBehavior = System.Windows.Forms.LinkBehavior.NeverUnderline;
            this.lnkRequest.Location = new System.Drawing.Point(400, 660);
            this.lnkRequest.Text = "Request Access";

            this.lnkSignUp.AutoSize = true;
            this.lnkSignUp.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lnkSignUp.LinkColor = System.Drawing.Color.FromArgb(40, 50, 60);
            this.lnkSignUp.LinkBehavior = System.Windows.Forms.LinkBehavior.NeverUnderline;
            this.lnkSignUp.Location = new System.Drawing.Point(520, 660);
            this.lnkSignUp.Text = "Sign Up Now";
            this.lnkSignUp.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkSignUp_LinkClicked);

            this.lblSecure.AutoSize = true;
            this.lblSecure.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Bold);
            this.lblSecure.ForeColor = System.Drawing.Color.FromArgb(160, 160, 160);
            this.lblSecure.Location = new System.Drawing.Point(420, 715);
            this.lblSecure.Text = "VERIFIED SECURE      AES-256 AUTH";

            // this.Controls.Add(this.btnClose);
            this.Controls.Add(this.pnlLogo);
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.lblSubtitle);
            this.Controls.Add(this.pnlCard);
            this.Controls.Add(this.lblNew);
            this.Controls.Add(this.lnkRequest);
            this.Controls.Add(this.lnkSignUp);
            this.Controls.Add(this.lblSecure);

            this.pnlCard.ResumeLayout(false);
            this.pnlCard.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private ReaLTaiizor.Controls.HopeButton btnClose;
        private System.Windows.Forms.Panel pnlLogo;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblSubtitle;
        private System.Windows.Forms.Panel pnlCard;
        private System.Windows.Forms.Label lblUserLabel;
        private ReaLTaiizor.Controls.HopeTextBox txtEmail;
        private System.Windows.Forms.Label lblPassLabel;
        private ReaLTaiizor.Controls.HopeTextBox txtPassword;
        private System.Windows.Forms.CheckBox chkRemember;
        private System.Windows.Forms.LinkLabel lnkForgotPassword;
        private ReaLTaiizor.Controls.HopeButton btnSignIn;
        private System.Windows.Forms.Label lblNew;
        private System.Windows.Forms.LinkLabel lnkRequest;
        private System.Windows.Forms.LinkLabel lnkSignUp;
        private System.Windows.Forms.Label lblSecure;
    }
}
