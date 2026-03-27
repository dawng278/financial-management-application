using System;
using System.ComponentModel;
using System.Windows.Forms;

namespace PersonalFinanceManager.Forms.Auth
{
    partial class RegisterForm
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            // Left Panel elements
            this.pnlLeft = new System.Windows.Forms.Panel();
            this.lblLogo = new System.Windows.Forms.Label();
            this.lblTitle = new System.Windows.Forms.Label();
            this.lblSubtitle = new System.Windows.Forms.Label();
            this.lblFeature1 = new System.Windows.Forms.Label();
            this.lblFeature2 = new System.Windows.Forms.Label();

            // Right Panel (Content)
            this.pnlRight = new System.Windows.Forms.Panel();
            this.btnClose = new ReaLTaiizor.Controls.HopeButton();
            this.lblRightTitle = new System.Windows.Forms.Label();
            this.lblRightSub = new System.Windows.Forms.Label();

            this.lblName = new System.Windows.Forms.Label();
            this.txtFullName = new ReaLTaiizor.Controls.HopeTextBox();

            this.lblEmail = new System.Windows.Forms.Label();
            this.txtEmail = new ReaLTaiizor.Controls.HopeTextBox();

            this.lblExecId = new System.Windows.Forms.Label();
            this.txtExecutiveId = new ReaLTaiizor.Controls.HopeTextBox();

            this.lblPass = new System.Windows.Forms.Label();
            this.txtPassword = new ReaLTaiizor.Controls.HopeTextBox();

            this.lblConfPass = new System.Windows.Forms.Label();
            this.txtConfirmPwd = new ReaLTaiizor.Controls.HopeTextBox();

            this.chkTerms = new System.Windows.Forms.CheckBox();
            this.btnRegister = new ReaLTaiizor.Controls.HopeButton();

            this.lnkSignIn = new System.Windows.Forms.LinkLabel();

            // Footer
            this.lblFooterCopy = new System.Windows.Forms.Label();
            this.lblFooterPriv = new System.Windows.Forms.Label();
            this.lblFooterReg = new System.Windows.Forms.Label();

            this.pnlLeft.SuspendLayout();
            this.pnlRight.SuspendLayout();
            this.SuspendLayout();

            // 
            // RegisterForm Base
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1100, 750);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;

            // ----------------------------------------------------
            // LEFT PANEL
            // ----------------------------------------------------
            this.pnlLeft.BackColor = System.Drawing.Color.FromArgb(52, 75, 90);
            this.pnlLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlLeft.Width = 450;
            this.pnlLeft.Controls.Add(this.lblLogo);
            this.pnlLeft.Controls.Add(this.lblTitle);
            this.pnlLeft.Controls.Add(this.lblSubtitle);
            this.pnlLeft.Controls.Add(this.lblFeature1);
            this.pnlLeft.Controls.Add(this.lblFeature2);

            this.lblLogo.AutoSize = true;
            this.lblLogo.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lblLogo.ForeColor = System.Drawing.Color.White;
            this.lblLogo.Location = new System.Drawing.Point(40, 50);
            this.lblLogo.Text = "Executive Finance";

            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 32F, System.Drawing.FontStyle.Bold);
            this.lblTitle.ForeColor = System.Drawing.Color.White;
            this.lblTitle.Location = new System.Drawing.Point(30, 200);
            this.lblTitle.Size = new System.Drawing.Size(380, 200);
            this.lblTitle.Text = "Join the\nElite Circle of\nWealth\nManagement.";

            this.lblSubtitle.AutoSize = true;
            this.lblSubtitle.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.lblSubtitle.ForeColor = System.Drawing.Color.FromArgb(200, 210, 220);
            this.lblSubtitle.Location = new System.Drawing.Point(40, 480);
            this.lblSubtitle.Size = new System.Drawing.Size(350, 45);
            this.lblSubtitle.Text = "Elevate your financial trajectory with our precision-engineered executive workspace.";

            this.lblFeature1.AutoSize = true;
            this.lblFeature1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblFeature1.ForeColor = System.Drawing.Color.FromArgb(180, 200, 210);
            this.lblFeature1.Location = new System.Drawing.Point(40, 640);
            this.lblFeature1.Text = ".   Bank-grade encryption protocol";

            this.lblFeature2.AutoSize = true;
            this.lblFeature2.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblFeature2.ForeColor = System.Drawing.Color.FromArgb(180, 200, 210);
            this.lblFeature2.Location = new System.Drawing.Point(40, 680);
            this.lblFeature2.Text = ".   Real-time market synchronization";

            // ----------------------------------------------------
            // RIGHT PANEL
            // ----------------------------------------------------
            this.pnlRight.BackColor = System.Drawing.Color.White;
            this.pnlRight.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlRight.Controls.Add(this.btnClose);
            this.pnlRight.Controls.Add(this.lblRightTitle);
            this.pnlRight.Controls.Add(this.lblRightSub);
            this.pnlRight.Controls.Add(this.lblName);
            this.pnlRight.Controls.Add(this.txtFullName);
            this.pnlRight.Controls.Add(this.lblEmail);
            this.pnlRight.Controls.Add(this.txtEmail);
            this.pnlRight.Controls.Add(this.lblExecId);
            this.pnlRight.Controls.Add(this.txtExecutiveId);
            this.pnlRight.Controls.Add(this.lblPass);
            this.pnlRight.Controls.Add(this.txtPassword);
            this.pnlRight.Controls.Add(this.lblConfPass);
            this.pnlRight.Controls.Add(this.txtConfirmPwd);
            this.pnlRight.Controls.Add(this.chkTerms);
            this.pnlRight.Controls.Add(this.btnRegister);
            this.pnlRight.Controls.Add(this.lnkSignIn);
            this.pnlRight.Controls.Add(this.lblFooterCopy);
            this.pnlRight.Controls.Add(this.lblFooterPriv);
            this.pnlRight.Controls.Add(this.lblFooterReg);

            this.btnClose.Location = new System.Drawing.Point(590, 20);
            this.btnClose.Size = new System.Drawing.Size(40, 40);
            this.btnClose.Text = "X";
            this.btnClose.PrimaryColor = System.Drawing.Color.FromArgb(230, 230, 230);
            this.btnClose.ForeColor = System.Drawing.Color.Gray;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);

            this.lblRightTitle.AutoSize = true;
            this.lblRightTitle.Font = new System.Drawing.Font("Segoe UI", 24F, System.Drawing.FontStyle.Bold);
            this.lblRightTitle.ForeColor = System.Drawing.Color.FromArgb(40, 60, 80);
            this.lblRightTitle.Location = new System.Drawing.Point(50, 80);
            this.lblRightTitle.Text = "Create Account";

            this.lblRightSub.AutoSize = true;
            this.lblRightSub.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblRightSub.ForeColor = System.Drawing.Color.Gray;
            this.lblRightSub.Location = new System.Drawing.Point(55, 130);
            this.lblRightSub.Text = "Initialize your premium financial profile.";

            // Row 1: Full Name
            this.lblName.AutoSize = true;
            this.lblName.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Bold);
            this.lblName.ForeColor = System.Drawing.Color.Gray;
            this.lblName.Location = new System.Drawing.Point(50, 190);
            this.lblName.Text = "Full Name";

            this.txtFullName.Location = new System.Drawing.Point(50, 210);
            this.txtFullName.Size = new System.Drawing.Size(540, 40);
            this.txtFullName.Text = "";

            // Row 2: Email & Exec ID
            this.lblEmail.AutoSize = true;
            this.lblEmail.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Bold);
            this.lblEmail.ForeColor = System.Drawing.Color.Gray;
            this.lblEmail.Location = new System.Drawing.Point(50, 275);
            this.lblEmail.Text = "Email Address";

            this.txtEmail.Location = new System.Drawing.Point(50, 295);
            this.txtEmail.Size = new System.Drawing.Size(260, 40);
            this.txtEmail.Text = "";

            this.lblExecId.AutoSize = true;
            this.lblExecId.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Bold);
            this.lblExecId.ForeColor = System.Drawing.Color.Gray;
            this.lblExecId.Location = new System.Drawing.Point(330, 275);
            this.lblExecId.Text = "Executive ID";

            this.txtExecutiveId.Location = new System.Drawing.Point(330, 295);
            this.txtExecutiveId.Size = new System.Drawing.Size(260, 40);
            this.txtExecutiveId.Text = "";

            // Row 3: Passwords
            this.lblPass.AutoSize = true;
            this.lblPass.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Bold);
            this.lblPass.ForeColor = System.Drawing.Color.Gray;
            this.lblPass.Location = new System.Drawing.Point(50, 360);
            this.lblPass.Text = "Password";

            this.txtPassword.Location = new System.Drawing.Point(50, 380);
            this.txtPassword.Size = new System.Drawing.Size(260, 40);
            this.txtPassword.UseSystemPasswordChar = true;

            this.lblConfPass.AutoSize = true;
            this.lblConfPass.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Bold);
            this.lblConfPass.ForeColor = System.Drawing.Color.Gray;
            this.lblConfPass.Location = new System.Drawing.Point(330, 360);
            this.lblConfPass.Text = "Confirm Password";

            this.txtConfirmPwd.Location = new System.Drawing.Point(330, 380);
            this.txtConfirmPwd.Size = new System.Drawing.Size(260, 40);
            this.txtConfirmPwd.UseSystemPasswordChar = true;

            // Row 4: Checkbox
            this.chkTerms.AutoSize = true;
            this.chkTerms.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.chkTerms.ForeColor = System.Drawing.Color.FromArgb(80, 80, 80);
            this.chkTerms.Location = new System.Drawing.Point(50, 450);
            this.chkTerms.Text = "I acknowledge the Executive Terms of Service and consent to the data protocols.";
            this.chkTerms.Checked = true;

            // Row 5: Submit Button
            this.btnRegister.Location = new System.Drawing.Point(50, 495);
            this.btnRegister.Size = new System.Drawing.Size(540, 45);
            this.btnRegister.PrimaryColor = System.Drawing.Color.FromArgb(200, 20, 80);
            this.btnRegister.Text = "Create Account ->";
            this.btnRegister.Click += new System.EventHandler(this.btnRegister_Click);

            // Row 6: Link
            this.lnkSignIn.AutoSize = true;
            this.lnkSignIn.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lnkSignIn.LinkColor = System.Drawing.Color.FromArgb(80, 80, 100);
            this.lnkSignIn.LinkBehavior = System.Windows.Forms.LinkBehavior.NeverUnderline;
            this.lnkSignIn.Location = new System.Drawing.Point(180, 560);
            this.lnkSignIn.Text = "Already have an account? Back to Login ->";
            this.lnkSignIn.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkSignIn_LinkClicked);

            // Row 7: Footer
            this.lblFooterCopy.AutoSize = true;
            this.lblFooterCopy.Font = new System.Drawing.Font("Segoe UI", 7F);
            this.lblFooterCopy.ForeColor = System.Drawing.Color.Silver;
            this.lblFooterCopy.Location = new System.Drawing.Point(50, 680);
            this.lblFooterCopy.Text = "2024 EXECUTIVE FINANCE GLOBAL";

            this.lblFooterPriv.AutoSize = true;
            this.lblFooterPriv.Font = new System.Drawing.Font("Segoe UI", 7F);
            this.lblFooterPriv.ForeColor = System.Drawing.Color.Silver;
            this.lblFooterPriv.Location = new System.Drawing.Point(350, 680);
            this.lblFooterPriv.Text = "PRIVACY POLICY";

            this.lblFooterReg.AutoSize = true;
            this.lblFooterReg.Font = new System.Drawing.Font("Segoe UI", 7F);
            this.lblFooterReg.ForeColor = System.Drawing.Color.Silver;
            this.lblFooterReg.Location = new System.Drawing.Point(470, 680);
            this.lblFooterReg.Text = "REGULATORY DISCLOSURE";

            this.Controls.Add(this.pnlRight);
            this.Controls.Add(this.pnlLeft);

            this.pnlLeft.ResumeLayout(false);
            this.pnlLeft.PerformLayout();
            this.pnlRight.ResumeLayout(false);
            this.pnlRight.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private System.Windows.Forms.Panel pnlLeft;
        private System.Windows.Forms.Label lblLogo;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblSubtitle;
        private System.Windows.Forms.Label lblFeature1;
        private System.Windows.Forms.Label lblFeature2;

        private System.Windows.Forms.Panel pnlRight;
        private ReaLTaiizor.Controls.HopeButton btnClose;
        private System.Windows.Forms.Label lblRightTitle;
        private System.Windows.Forms.Label lblRightSub;
        
        private System.Windows.Forms.Label lblName;
        private ReaLTaiizor.Controls.HopeTextBox txtFullName;
        private System.Windows.Forms.Label lblEmail;
        private ReaLTaiizor.Controls.HopeTextBox txtEmail;
        private System.Windows.Forms.Label lblExecId;
        private ReaLTaiizor.Controls.HopeTextBox txtExecutiveId;
        private System.Windows.Forms.Label lblPass;
        private ReaLTaiizor.Controls.HopeTextBox txtPassword;
        private System.Windows.Forms.Label lblConfPass;
        private ReaLTaiizor.Controls.HopeTextBox txtConfirmPwd;
        private System.Windows.Forms.CheckBox chkTerms;
        private ReaLTaiizor.Controls.HopeButton btnRegister;
        private System.Windows.Forms.LinkLabel lnkSignIn;
        private System.Windows.Forms.Label lblFooterCopy;
        private System.Windows.Forms.Label lblFooterPriv;
        private System.Windows.Forms.Label lblFooterReg;
    }
}
