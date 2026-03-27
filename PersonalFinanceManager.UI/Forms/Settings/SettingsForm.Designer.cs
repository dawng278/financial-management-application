using System;
using System.ComponentModel;
using System.Windows.Forms;

namespace PersonalFinanceManager.Forms.Settings
{
    partial class SettingsForm
    {
        private System.ComponentModel.IContainer components = null;
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.lblPageTitle = new System.Windows.Forms.Label();
            this.lblPageSub = new System.Windows.Forms.Label();
            this.pnlProfile = new System.Windows.Forms.Panel();
            this.picAvatar = new ReaLTaiizor.Controls.HopePictureBox();
            this.lblProfileName = new System.Windows.Forms.Label();
            this.lblRole = new System.Windows.Forms.Label();
            this.btnEditProfile = new ReaLTaiizor.Controls.HopeButton();
            this.lblEmailLbl = new System.Windows.Forms.Label();
            this.txtEmail = new ReaLTaiizor.Controls.HopeTextBox();
            this.lblPhoneLbl = new System.Windows.Forms.Label();
            this.txtPhone = new ReaLTaiizor.Controls.HopeTextBox();
            this.lblLocLbl = new System.Windows.Forms.Label();
            this.txtLocation = new ReaLTaiizor.Controls.HopeTextBox();
            this.lblTimeLbl = new System.Windows.Forms.Label();
            this.txtTimezone = new ReaLTaiizor.Controls.HopeTextBox();
            this.pnlAppearance = new System.Windows.Forms.Panel();
            this.lblAppTitle = new System.Windows.Forms.Label();
            this.pnlLightMode = new System.Windows.Forms.Panel();
            this.lblLightMode = new System.Windows.Forms.Label();
            this.pnlDarkMode = new System.Windows.Forms.Panel();
            this.lblDarkMode = new System.Windows.Forms.Label();
            this.pnlSecurity = new System.Windows.Forms.Panel();
            this.lblSecTitle = new System.Windows.Forms.Label();
            this.lblChangePass = new System.Windows.Forms.Label();
            this.txtCurrentPass = new ReaLTaiizor.Controls.HopeTextBox();
            this.txtNewPass = new ReaLTaiizor.Controls.HopeTextBox();
            this.txtConfirmPass = new ReaLTaiizor.Controls.HopeTextBox();
            this.btnUpdatePassword = new ReaLTaiizor.Controls.HopeButton();
            this.lbl2FA = new System.Windows.Forms.Label();
            this.tg2FA = new ReaLTaiizor.Controls.HopeToggle();
            this.lbl2FADesc = new System.Windows.Forms.Label();
            this.pnlPrivacy = new System.Windows.Forms.Panel();
            this.lblPrivacyTitle = new System.Windows.Forms.Label();
            this.lblPrivacyDesc = new System.Windows.Forms.Label();
            this.pnlNotifications = new System.Windows.Forms.Panel();
            this.lblNotifTitle = new System.Windows.Forms.Label();
            this.lblDepAlert = new System.Windows.Forms.Label();
            this.lblDepDesc = new System.Windows.Forms.Label();
            this.tgDeposit = new ReaLTaiizor.Controls.HopeToggle();
            this.lblBudgAlert = new System.Windows.Forms.Label();
            this.lblBudgDesc = new System.Windows.Forms.Label();
            this.tgBudget = new ReaLTaiizor.Controls.HopeToggle();
            this.lblMonthAlert = new System.Windows.Forms.Label();
            this.lblMonthDesc = new System.Windows.Forms.Label();
            this.tgMonthly = new ReaLTaiizor.Controls.HopeToggle();
            this.btnConfigEmail = new ReaLTaiizor.Controls.HopeButton();
            this.lblLang = new System.Windows.Forms.Label();
            this.cboLang = new ReaLTaiizor.Controls.HopeComboBox();
            this.lblCurr = new System.Windows.Forms.Label();
            this.cboCurr = new ReaLTaiizor.Controls.HopeComboBox();
            this.lblExport = new System.Windows.Forms.Label();
            this.btnFactoryReset = new ReaLTaiizor.Controls.HopeButton();
            this.pnlProfile.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picAvatar)).BeginInit();
            this.pnlAppearance.SuspendLayout();
            this.pnlSecurity.SuspendLayout();
            this.pnlPrivacy.SuspendLayout();
            this.pnlNotifications.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblPageTitle
            // 
            this.lblPageTitle.AutoSize = true;
            this.lblPageTitle.Font = new System.Drawing.Font("Segoe UI", 24F, System.Drawing.FontStyle.Bold);
            this.lblPageTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(18)))), ((int)(((byte)(20)))), ((int)(((byte)(28)))));
            this.lblPageTitle.Location = new System.Drawing.Point(40, 20);
            this.lblPageTitle.Name = "lblPageTitle";
            this.lblPageTitle.Size = new System.Drawing.Size(141, 45);
            this.lblPageTitle.TabIndex = 0;
            this.lblPageTitle.Text = "Settings";
            // 
            // lblPageSub
            // 
            this.lblPageSub.AutoSize = true;
            this.lblPageSub.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblPageSub.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(87)))), ((int)(((byte)(89)))), ((int)(((byte)(98)))));
            this.lblPageSub.Location = new System.Drawing.Point(43, 65);
            this.lblPageSub.Name = "lblPageSub";
            this.lblPageSub.Size = new System.Drawing.Size(379, 19);
            this.lblPageSub.TabIndex = 1;
            this.lblPageSub.Text = "Manage your account preferences and system configuration.";
            // 
            // pnlProfile
            // 
            this.pnlProfile.BackColor = System.Drawing.Color.White;
            this.pnlProfile.Controls.Add(this.picAvatar);
            this.pnlProfile.Controls.Add(this.lblProfileName);
            this.pnlProfile.Controls.Add(this.lblRole);
            this.pnlProfile.Controls.Add(this.btnEditProfile);
            this.pnlProfile.Controls.Add(this.lblEmailLbl);
            this.pnlProfile.Controls.Add(this.txtEmail);
            this.pnlProfile.Controls.Add(this.lblPhoneLbl);
            this.pnlProfile.Controls.Add(this.txtPhone);
            this.pnlProfile.Controls.Add(this.lblLocLbl);
            this.pnlProfile.Controls.Add(this.txtLocation);
            this.pnlProfile.Controls.Add(this.lblTimeLbl);
            this.pnlProfile.Controls.Add(this.txtTimezone);
            this.pnlProfile.Location = new System.Drawing.Point(40, 110);
            this.pnlProfile.Name = "pnlProfile";
            this.pnlProfile.Size = new System.Drawing.Size(490, 250);
            this.pnlProfile.TabIndex = 2;
            // 
            // picAvatar
            // 
            this.picAvatar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(200)))), ((int)(((byte)(150)))));
            this.picAvatar.Location = new System.Drawing.Point(20, 20);
            this.picAvatar.Name = "picAvatar";
            this.picAvatar.PixelOffsetType = System.Drawing.Drawing2D.PixelOffsetMode.HighQuality;
            this.picAvatar.Size = new System.Drawing.Size(70, 70);
            this.picAvatar.SmoothingType = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
            this.picAvatar.TabIndex = 0;
            this.picAvatar.TabStop = false;
            this.picAvatar.TextRenderingType = System.Drawing.Text.TextRenderingHint.ClearTypeGridFit;
            // 
            // lblProfileName
            // 
            this.lblProfileName.AutoSize = true;
            this.lblProfileName.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold);
            this.lblProfileName.Location = new System.Drawing.Point(100, 20);
            this.lblProfileName.Name = "lblProfileName";
            this.lblProfileName.Size = new System.Drawing.Size(127, 30);
            this.lblProfileName.TabIndex = 1;
            this.lblProfileName.Text = "Alex Rivers";
            // 
            // lblRole
            // 
            this.lblRole.AutoSize = true;
            this.lblRole.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblRole.ForeColor = System.Drawing.Color.Gray;
            this.lblRole.Location = new System.Drawing.Point(103, 50);
            this.lblRole.Name = "lblRole";
            this.lblRole.Size = new System.Drawing.Size(152, 19);
            this.lblRole.TabIndex = 2;
            this.lblRole.Text = "Senior Financial Analyst";
            // 
            // btnEditProfile
            // 
            this.btnEditProfile.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(223)))), ((int)(((byte)(230)))));
            this.btnEditProfile.ButtonType = ReaLTaiizor.Util.HopeButtonType.Primary;
            this.btnEditProfile.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnEditProfile.DangerColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(108)))), ((int)(((byte)(108)))));
            this.btnEditProfile.DefaultColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.btnEditProfile.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.btnEditProfile.HoverTextColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(49)))), ((int)(((byte)(51)))));
            this.btnEditProfile.InfoColor = System.Drawing.Color.FromArgb(((int)(((byte)(144)))), ((int)(((byte)(147)))), ((int)(((byte)(153)))));
            this.btnEditProfile.Location = new System.Drawing.Point(360, 30);
            this.btnEditProfile.Name = "btnEditProfile";
            this.btnEditProfile.PrimaryColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(158)))), ((int)(((byte)(255)))));
            this.btnEditProfile.Size = new System.Drawing.Size(110, 36);
            this.btnEditProfile.SuccessColor = System.Drawing.Color.FromArgb(((int)(((byte)(103)))), ((int)(((byte)(194)))), ((int)(((byte)(58)))));
            this.btnEditProfile.TabIndex = 3;
            this.btnEditProfile.Text = "Edit Profile";
            this.btnEditProfile.TextColor = System.Drawing.Color.White;
            this.btnEditProfile.WarningColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(162)))), ((int)(((byte)(60)))));
            // 
            // lblEmailLbl
            // 
            this.lblEmailLbl.AutoSize = true;
            this.lblEmailLbl.ForeColor = System.Drawing.Color.Gray;
            this.lblEmailLbl.Location = new System.Drawing.Point(20, 110);
            this.lblEmailLbl.Name = "lblEmailLbl";
            this.lblEmailLbl.Size = new System.Drawing.Size(94, 13);
            this.lblEmailLbl.TabIndex = 4;
            this.lblEmailLbl.Text = "EMAIL ADDRESS";
            // 
            // txtEmail
            // 
            this.txtEmail.BackColor = System.Drawing.Color.White;
            this.txtEmail.BaseColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(55)))), ((int)(((byte)(66)))));
            this.txtEmail.BorderColorA = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(158)))), ((int)(((byte)(255)))));
            this.txtEmail.BorderColorB = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(223)))), ((int)(((byte)(230)))));
            this.txtEmail.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.txtEmail.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(49)))), ((int)(((byte)(51)))));
            this.txtEmail.Hint = "";
            this.txtEmail.Location = new System.Drawing.Point(20, 130);
            this.txtEmail.MaxLength = 32767;
            this.txtEmail.Multiline = false;
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.PasswordChar = '\0';
            this.txtEmail.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txtEmail.SelectedText = "";
            this.txtEmail.SelectionLength = 0;
            this.txtEmail.SelectionStart = 0;
            this.txtEmail.Size = new System.Drawing.Size(210, 38);
            this.txtEmail.TabIndex = 5;
            this.txtEmail.TabStop = false;
            this.txtEmail.Text = "alex.rivers@zenith.com";
            this.txtEmail.UseSystemPasswordChar = false;
            // 
            // lblPhoneLbl
            // 
            this.lblPhoneLbl.AutoSize = true;
            this.lblPhoneLbl.ForeColor = System.Drawing.Color.Gray;
            this.lblPhoneLbl.Location = new System.Drawing.Point(250, 110);
            this.lblPhoneLbl.Name = "lblPhoneLbl";
            this.lblPhoneLbl.Size = new System.Drawing.Size(95, 13);
            this.lblPhoneLbl.TabIndex = 6;
            this.lblPhoneLbl.Text = "PHONE NUMBER";
            // 
            // txtPhone
            // 
            this.txtPhone.BackColor = System.Drawing.Color.White;
            this.txtPhone.BaseColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(55)))), ((int)(((byte)(66)))));
            this.txtPhone.BorderColorA = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(158)))), ((int)(((byte)(255)))));
            this.txtPhone.BorderColorB = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(223)))), ((int)(((byte)(230)))));
            this.txtPhone.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.txtPhone.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(49)))), ((int)(((byte)(51)))));
            this.txtPhone.Hint = "";
            this.txtPhone.Location = new System.Drawing.Point(250, 130);
            this.txtPhone.MaxLength = 32767;
            this.txtPhone.Multiline = false;
            this.txtPhone.Name = "txtPhone";
            this.txtPhone.PasswordChar = '\0';
            this.txtPhone.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txtPhone.SelectedText = "";
            this.txtPhone.SelectionLength = 0;
            this.txtPhone.SelectionStart = 0;
            this.txtPhone.Size = new System.Drawing.Size(220, 38);
            this.txtPhone.TabIndex = 7;
            this.txtPhone.TabStop = false;
            this.txtPhone.Text = "+1 (555) 012-3456";
            this.txtPhone.UseSystemPasswordChar = false;
            // 
            // lblLocLbl
            // 
            this.lblLocLbl.AutoSize = true;
            this.lblLocLbl.ForeColor = System.Drawing.Color.Gray;
            this.lblLocLbl.Location = new System.Drawing.Point(20, 180);
            this.lblLocLbl.Name = "lblLocLbl";
            this.lblLocLbl.Size = new System.Drawing.Size(61, 13);
            this.lblLocLbl.TabIndex = 8;
            this.lblLocLbl.Text = "LOCATION";
            // 
            // txtLocation
            // 
            this.txtLocation.BackColor = System.Drawing.Color.White;
            this.txtLocation.BaseColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(55)))), ((int)(((byte)(66)))));
            this.txtLocation.BorderColorA = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(158)))), ((int)(((byte)(255)))));
            this.txtLocation.BorderColorB = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(223)))), ((int)(((byte)(230)))));
            this.txtLocation.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.txtLocation.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(49)))), ((int)(((byte)(51)))));
            this.txtLocation.Hint = "";
            this.txtLocation.Location = new System.Drawing.Point(20, 200);
            this.txtLocation.MaxLength = 32767;
            this.txtLocation.Multiline = false;
            this.txtLocation.Name = "txtLocation";
            this.txtLocation.PasswordChar = '\0';
            this.txtLocation.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txtLocation.SelectedText = "";
            this.txtLocation.SelectionLength = 0;
            this.txtLocation.SelectionStart = 0;
            this.txtLocation.Size = new System.Drawing.Size(210, 38);
            this.txtLocation.TabIndex = 9;
            this.txtLocation.TabStop = false;
            this.txtLocation.Text = "San Francisco, CA";
            this.txtLocation.UseSystemPasswordChar = false;
            // 
            // lblTimeLbl
            // 
            this.lblTimeLbl.AutoSize = true;
            this.lblTimeLbl.ForeColor = System.Drawing.Color.Gray;
            this.lblTimeLbl.Location = new System.Drawing.Point(250, 180);
            this.lblTimeLbl.Name = "lblTimeLbl";
            this.lblTimeLbl.Size = new System.Drawing.Size(63, 13);
            this.lblTimeLbl.TabIndex = 10;
            this.lblTimeLbl.Text = "TIMEZONE";
            // 
            // txtTimezone
            // 
            this.txtTimezone.BackColor = System.Drawing.Color.White;
            this.txtTimezone.BaseColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(55)))), ((int)(((byte)(66)))));
            this.txtTimezone.BorderColorA = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(158)))), ((int)(((byte)(255)))));
            this.txtTimezone.BorderColorB = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(223)))), ((int)(((byte)(230)))));
            this.txtTimezone.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.txtTimezone.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(49)))), ((int)(((byte)(51)))));
            this.txtTimezone.Hint = "";
            this.txtTimezone.Location = new System.Drawing.Point(250, 200);
            this.txtTimezone.MaxLength = 32767;
            this.txtTimezone.Multiline = false;
            this.txtTimezone.Name = "txtTimezone";
            this.txtTimezone.PasswordChar = '\0';
            this.txtTimezone.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txtTimezone.SelectedText = "";
            this.txtTimezone.SelectionLength = 0;
            this.txtTimezone.SelectionStart = 0;
            this.txtTimezone.Size = new System.Drawing.Size(220, 38);
            this.txtTimezone.TabIndex = 11;
            this.txtTimezone.TabStop = false;
            this.txtTimezone.Text = "PST (UTC -8)";
            this.txtTimezone.UseSystemPasswordChar = false;
            // 
            // pnlAppearance
            // 
            this.pnlAppearance.BackColor = System.Drawing.Color.White;
            this.pnlAppearance.Controls.Add(this.lblAppTitle);
            this.pnlAppearance.Controls.Add(this.pnlLightMode);
            this.pnlAppearance.Controls.Add(this.lblLightMode);
            this.pnlAppearance.Controls.Add(this.pnlDarkMode);
            this.pnlAppearance.Controls.Add(this.lblDarkMode);
            this.pnlAppearance.Location = new System.Drawing.Point(550, 110);
            this.pnlAppearance.Name = "pnlAppearance";
            this.pnlAppearance.Size = new System.Drawing.Size(520, 250);
            this.pnlAppearance.TabIndex = 3;
            // 
            // lblAppTitle
            // 
            this.lblAppTitle.AutoSize = true;
            this.lblAppTitle.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lblAppTitle.Location = new System.Drawing.Point(20, 20);
            this.lblAppTitle.Name = "lblAppTitle";
            this.lblAppTitle.Size = new System.Drawing.Size(101, 21);
            this.lblAppTitle.TabIndex = 0;
            this.lblAppTitle.Text = "Appearance";
            // 
            // pnlLightMode
            // 
            this.pnlLightMode.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(245)))));
            this.pnlLightMode.Location = new System.Drawing.Point(40, 60);
            this.pnlLightMode.Name = "pnlLightMode";
            this.pnlLightMode.Size = new System.Drawing.Size(200, 120);
            this.pnlLightMode.TabIndex = 1;
            // 
            // lblLightMode
            // 
            this.lblLightMode.AutoSize = true;
            this.lblLightMode.Location = new System.Drawing.Point(100, 190);
            this.lblLightMode.Name = "lblLightMode";
            this.lblLightMode.Size = new System.Drawing.Size(60, 13);
            this.lblLightMode.TabIndex = 2;
            this.lblLightMode.Text = "Light Mode";
            // 
            // pnlDarkMode
            // 
            this.pnlDarkMode.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(25)))), ((int)(((byte)(40)))));
            this.pnlDarkMode.Location = new System.Drawing.Point(280, 60);
            this.pnlDarkMode.Name = "pnlDarkMode";
            this.pnlDarkMode.Size = new System.Drawing.Size(200, 120);
            this.pnlDarkMode.TabIndex = 3;
            // 
            // lblDarkMode
            // 
            this.lblDarkMode.AutoSize = true;
            this.lblDarkMode.Location = new System.Drawing.Point(340, 190);
            this.lblDarkMode.Name = "lblDarkMode";
            this.lblDarkMode.Size = new System.Drawing.Size(60, 13);
            this.lblDarkMode.TabIndex = 4;
            this.lblDarkMode.Text = "Dark Mode";
            // 
            // pnlSecurity
            // 
            this.pnlSecurity.BackColor = System.Drawing.Color.White;
            this.pnlSecurity.Controls.Add(this.lblSecTitle);
            this.pnlSecurity.Controls.Add(this.lblChangePass);
            this.pnlSecurity.Controls.Add(this.txtCurrentPass);
            this.pnlSecurity.Controls.Add(this.txtNewPass);
            this.pnlSecurity.Controls.Add(this.txtConfirmPass);
            this.pnlSecurity.Controls.Add(this.btnUpdatePassword);
            this.pnlSecurity.Controls.Add(this.pnlPrivacy);
            this.pnlSecurity.Location = new System.Drawing.Point(40, 380);
            this.pnlSecurity.Name = "pnlSecurity";
            this.pnlSecurity.Size = new System.Drawing.Size(490, 310);
            this.pnlSecurity.TabIndex = 4;
            // 
            // lblSecTitle
            // 
            this.lblSecTitle.AutoSize = true;
            this.lblSecTitle.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lblSecTitle.Location = new System.Drawing.Point(20, 20);
            this.lblSecTitle.Name = "lblSecTitle";
            this.lblSecTitle.Size = new System.Drawing.Size(136, 21);
            this.lblSecTitle.TabIndex = 0;
            this.lblSecTitle.Text = "Security & Privacy";
            // 
            // lblChangePass
            // 
            this.lblChangePass.AutoSize = true;
            this.lblChangePass.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(90)))), ((int)(((byte)(120)))));
            this.lblChangePass.Location = new System.Drawing.Point(20, 60);
            this.lblChangePass.Name = "lblChangePass";
            this.lblChangePass.Size = new System.Drawing.Size(118, 13);
            this.lblChangePass.TabIndex = 1;
            this.lblChangePass.Text = "CHANGE PASSWORD";
            // 
            // txtCurrentPass
            // 
            this.txtCurrentPass.BackColor = System.Drawing.Color.White;
            this.txtCurrentPass.BaseColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(55)))), ((int)(((byte)(66)))));
            this.txtCurrentPass.BorderColorA = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(158)))), ((int)(((byte)(255)))));
            this.txtCurrentPass.BorderColorB = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(223)))), ((int)(((byte)(230)))));
            this.txtCurrentPass.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.txtCurrentPass.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(49)))), ((int)(((byte)(51)))));
            this.txtCurrentPass.Hint = "";
            this.txtCurrentPass.Location = new System.Drawing.Point(20, 90);
            this.txtCurrentPass.MaxLength = 32767;
            this.txtCurrentPass.Multiline = false;
            this.txtCurrentPass.Name = "txtCurrentPass";
            this.txtCurrentPass.PasswordChar = '\0';
            this.txtCurrentPass.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txtCurrentPass.SelectedText = "";
            this.txtCurrentPass.SelectionLength = 0;
            this.txtCurrentPass.SelectionStart = 0;
            this.txtCurrentPass.Size = new System.Drawing.Size(220, 38);
            this.txtCurrentPass.TabIndex = 2;
            this.txtCurrentPass.TabStop = false;
            this.txtCurrentPass.Text = "Current Password";
            this.txtCurrentPass.UseSystemPasswordChar = true;
            // 
            // txtNewPass
            // 
            this.txtNewPass.BackColor = System.Drawing.Color.White;
            this.txtNewPass.BaseColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(55)))), ((int)(((byte)(66)))));
            this.txtNewPass.BorderColorA = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(158)))), ((int)(((byte)(255)))));
            this.txtNewPass.BorderColorB = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(223)))), ((int)(((byte)(230)))));
            this.txtNewPass.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.txtNewPass.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(49)))), ((int)(((byte)(51)))));
            this.txtNewPass.Hint = "";
            this.txtNewPass.Location = new System.Drawing.Point(20, 140);
            this.txtNewPass.MaxLength = 32767;
            this.txtNewPass.Multiline = false;
            this.txtNewPass.Name = "txtNewPass";
            this.txtNewPass.PasswordChar = '\0';
            this.txtNewPass.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txtNewPass.SelectedText = "";
            this.txtNewPass.SelectionLength = 0;
            this.txtNewPass.SelectionStart = 0;
            this.txtNewPass.Size = new System.Drawing.Size(220, 38);
            this.txtNewPass.TabIndex = 3;
            this.txtNewPass.TabStop = false;
            this.txtNewPass.Text = "New Password";
            this.txtNewPass.UseSystemPasswordChar = true;
            // 
            // txtConfirmPass
            // 
            this.txtConfirmPass.BackColor = System.Drawing.Color.White;
            this.txtConfirmPass.BaseColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(55)))), ((int)(((byte)(66)))));
            this.txtConfirmPass.BorderColorA = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(158)))), ((int)(((byte)(255)))));
            this.txtConfirmPass.BorderColorB = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(223)))), ((int)(((byte)(230)))));
            this.txtConfirmPass.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.txtConfirmPass.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(49)))), ((int)(((byte)(51)))));
            this.txtConfirmPass.Hint = "";
            this.txtConfirmPass.Location = new System.Drawing.Point(20, 190);
            this.txtConfirmPass.MaxLength = 32767;
            this.txtConfirmPass.Multiline = false;
            this.txtConfirmPass.Name = "txtConfirmPass";
            this.txtConfirmPass.PasswordChar = '\0';
            this.txtConfirmPass.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txtConfirmPass.SelectedText = "";
            this.txtConfirmPass.SelectionLength = 0;
            this.txtConfirmPass.SelectionStart = 0;
            this.txtConfirmPass.Size = new System.Drawing.Size(220, 38);
            this.txtConfirmPass.TabIndex = 4;
            this.txtConfirmPass.TabStop = false;
            this.txtConfirmPass.Text = "Confirm New Password";
            this.txtConfirmPass.UseSystemPasswordChar = true;
            // 
            // btnUpdatePassword
            // 
            this.btnUpdatePassword.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(223)))), ((int)(((byte)(230)))));
            this.btnUpdatePassword.ButtonType = ReaLTaiizor.Util.HopeButtonType.Primary;
            this.btnUpdatePassword.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnUpdatePassword.DangerColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(108)))), ((int)(((byte)(108)))));
            this.btnUpdatePassword.DefaultColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.btnUpdatePassword.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.btnUpdatePassword.HoverTextColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(49)))), ((int)(((byte)(51)))));
            this.btnUpdatePassword.InfoColor = System.Drawing.Color.FromArgb(((int)(((byte)(144)))), ((int)(((byte)(147)))), ((int)(((byte)(153)))));
            this.btnUpdatePassword.Location = new System.Drawing.Point(20, 250);
            this.btnUpdatePassword.Name = "btnUpdatePassword";
            this.btnUpdatePassword.PrimaryColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(158)))), ((int)(((byte)(255)))));
            this.btnUpdatePassword.Size = new System.Drawing.Size(220, 40);
            this.btnUpdatePassword.SuccessColor = System.Drawing.Color.FromArgb(((int)(((byte)(103)))), ((int)(((byte)(194)))), ((int)(((byte)(58)))));
            this.btnUpdatePassword.TabIndex = 5;
            this.btnUpdatePassword.Text = "Update Password";
            this.btnUpdatePassword.TextColor = System.Drawing.Color.White;
            this.btnUpdatePassword.WarningColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(162)))), ((int)(((byte)(60)))));
            this.btnUpdatePassword.Click += new System.EventHandler(this.btnUpdatePassword_Click);
            // 
            // lbl2FA
            // 
            this.lbl2FA.AutoSize = true;
            this.lbl2FA.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lbl2FA.Location = new System.Drawing.Point(260, 60);
            this.lbl2FA.Name = "lbl2FA";
            this.lbl2FA.Size = new System.Drawing.Size(106, 38);
            this.lbl2FA.TabIndex = 6;
            this.lbl2FA.Text = "Two-Factor \nAuthentication";
            // 
            // tg2FA
            // 
            this.tg2FA.BaseColor = System.Drawing.Color.White;
            this.tg2FA.BaseColorA = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(223)))), ((int)(((byte)(230)))));
            this.tg2FA.BaseColorB = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(64)))), ((int)(((byte)(158)))), ((int)(((byte)(255)))));
            this.tg2FA.Checked = true;
            this.tg2FA.CheckState = System.Windows.Forms.CheckState.Checked;
            this.tg2FA.Cursor = System.Windows.Forms.Cursors.Hand;
            this.tg2FA.HeadColorA = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(223)))), ((int)(((byte)(230)))));
            this.tg2FA.HeadColorB = System.Drawing.Color.White;
            this.tg2FA.HeadColorC = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(158)))), ((int)(((byte)(255)))));
            this.tg2FA.HeadColorD = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(158)))), ((int)(((byte)(255)))));
            this.tg2FA.Location = new System.Drawing.Point(430, 60);
            this.tg2FA.Name = "tg2FA";
            this.tg2FA.Size = new System.Drawing.Size(48, 20);
            this.tg2FA.TabIndex = 7;
            // 
            // lbl2FADesc
            // 
            this.lbl2FADesc.ForeColor = System.Drawing.Color.Gray;
            this.lbl2FADesc.Location = new System.Drawing.Point(260, 100);
            this.lbl2FADesc.Name = "lbl2FADesc";
            this.lbl2FADesc.Size = new System.Drawing.Size(210, 45);
            this.lbl2FADesc.TabIndex = 8;
            this.lbl2FADesc.Text = "Add an extra layer of security to your account by requiring a verification code.";
            // 
            // pnlPrivacy
            // 
            this.pnlPrivacy.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(253)))), ((int)(((byte)(232)))), ((int)(((byte)(232)))));
            this.pnlPrivacy.Controls.Add(this.lblPrivacyTitle);
            this.pnlPrivacy.Controls.Add(this.lblPrivacyDesc);
            this.pnlPrivacy.Location = new System.Drawing.Point(260, 60);
            this.pnlPrivacy.Name = "pnlPrivacy";
            this.pnlPrivacy.Size = new System.Drawing.Size(210, 100);
            this.pnlPrivacy.TabIndex = 9;
            // 
            // lblPrivacyTitle
            // 
            this.lblPrivacyTitle.AutoSize = true;
            this.lblPrivacyTitle.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblPrivacyTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(180)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.lblPrivacyTitle.Location = new System.Drawing.Point(10, 10);
            this.lblPrivacyTitle.Name = "lblPrivacyTitle";
            this.lblPrivacyTitle.Size = new System.Drawing.Size(96, 15);
            this.lblPrivacyTitle.TabIndex = 0;
            this.lblPrivacyTitle.Text = "Account Privacy";
            // 
            // lblPrivacyDesc
            // 
            this.lblPrivacyDesc.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(180)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.lblPrivacyDesc.Location = new System.Drawing.Point(10, 35);
            this.lblPrivacyDesc.Name = "lblPrivacyDesc";
            this.lblPrivacyDesc.Size = new System.Drawing.Size(190, 50);
            this.lblPrivacyDesc.TabIndex = 1;
            this.lblPrivacyDesc.Text = "Making your profile private will hide your transaction summaries from shared circ" +
    "les.";
            // 
            // pnlNotifications
            // 
            this.pnlNotifications.BackColor = System.Drawing.Color.White;
            this.pnlNotifications.Controls.Add(this.lblNotifTitle);
            this.pnlNotifications.Controls.Add(this.lblDepAlert);
            this.pnlNotifications.Controls.Add(this.lblDepDesc);
            this.pnlNotifications.Controls.Add(this.tgDeposit);
            this.pnlNotifications.Controls.Add(this.lblBudgAlert);
            this.pnlNotifications.Controls.Add(this.lblBudgDesc);
            this.pnlNotifications.Controls.Add(this.tgBudget);
            this.pnlNotifications.Controls.Add(this.lblMonthAlert);
            this.pnlNotifications.Controls.Add(this.lblMonthDesc);
            this.pnlNotifications.Controls.Add(this.tgMonthly);
            this.pnlNotifications.Controls.Add(this.btnConfigEmail);
            this.pnlNotifications.Location = new System.Drawing.Point(550, 380);
            this.pnlNotifications.Name = "pnlNotifications";
            this.pnlNotifications.Size = new System.Drawing.Size(520, 310);
            this.pnlNotifications.TabIndex = 5;
            // 
            // lblNotifTitle
            // 
            this.lblNotifTitle.AutoSize = true;
            this.lblNotifTitle.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lblNotifTitle.Location = new System.Drawing.Point(20, 20);
            this.lblNotifTitle.Name = "lblNotifTitle";
            this.lblNotifTitle.Size = new System.Drawing.Size(110, 21);
            this.lblNotifTitle.TabIndex = 0;
            this.lblNotifTitle.Text = "Notifications";
            // 
            // lblDepAlert
            // 
            this.lblDepAlert.AutoSize = true;
            this.lblDepAlert.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblDepAlert.Location = new System.Drawing.Point(20, 70);
            this.lblDepAlert.Name = "lblDepAlert";
            this.lblDepAlert.Size = new System.Drawing.Size(103, 19);
            this.lblDepAlert.TabIndex = 1;
            this.lblDepAlert.Text = "Deposit Alerts";
            // 
            // lblDepDesc
            // 
            this.lblDepDesc.AutoSize = true;
            this.lblDepDesc.ForeColor = System.Drawing.Color.Gray;
            this.lblDepDesc.Location = new System.Drawing.Point(20, 90);
            this.lblDepDesc.Name = "lblDepDesc";
            this.lblDepDesc.Size = new System.Drawing.Size(121, 13);
            this.lblDepDesc.TabIndex = 2;
            this.lblDepDesc.Text = "Notify when funds arrive";
            // 
            // tgDeposit
            // 
            this.tgDeposit.BaseColor = System.Drawing.Color.White;
            this.tgDeposit.BaseColorA = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(223)))), ((int)(((byte)(230)))));
            this.tgDeposit.BaseColorB = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(64)))), ((int)(((byte)(158)))), ((int)(((byte)(255)))));
            this.tgDeposit.Checked = true;
            this.tgDeposit.CheckState = System.Windows.Forms.CheckState.Checked;
            this.tgDeposit.Cursor = System.Windows.Forms.Cursors.Hand;
            this.tgDeposit.HeadColorA = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(223)))), ((int)(((byte)(230)))));
            this.tgDeposit.HeadColorB = System.Drawing.Color.White;
            this.tgDeposit.HeadColorC = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(158)))), ((int)(((byte)(255)))));
            this.tgDeposit.HeadColorD = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(158)))), ((int)(((byte)(255)))));
            this.tgDeposit.Location = new System.Drawing.Point(450, 75);
            this.tgDeposit.Name = "tgDeposit";
            this.tgDeposit.Size = new System.Drawing.Size(48, 20);
            this.tgDeposit.TabIndex = 3;
            // 
            // lblBudgAlert
            // 
            this.lblBudgAlert.AutoSize = true;
            this.lblBudgAlert.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblBudgAlert.Location = new System.Drawing.Point(20, 130);
            this.lblBudgAlert.Name = "lblBudgAlert";
            this.lblBudgAlert.Size = new System.Drawing.Size(123, 19);
            this.lblBudgAlert.TabIndex = 4;
            this.lblBudgAlert.Text = "Budget Warnings";
            // 
            // lblBudgDesc
            // 
            this.lblBudgDesc.AutoSize = true;
            this.lblBudgDesc.ForeColor = System.Drawing.Color.Gray;
            this.lblBudgDesc.Location = new System.Drawing.Point(20, 150);
            this.lblBudgDesc.Name = "lblBudgDesc";
            this.lblBudgDesc.Size = new System.Drawing.Size(121, 13);
            this.lblBudgDesc.TabIndex = 5;
            this.lblBudgDesc.Text = "When limits are reached";
            // 
            // tgBudget
            // 
            this.tgBudget.BaseColor = System.Drawing.Color.White;
            this.tgBudget.BaseColorA = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(223)))), ((int)(((byte)(230)))));
            this.tgBudget.BaseColorB = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(64)))), ((int)(((byte)(158)))), ((int)(((byte)(255)))));
            this.tgBudget.Checked = true;
            this.tgBudget.CheckState = System.Windows.Forms.CheckState.Checked;
            this.tgBudget.Cursor = System.Windows.Forms.Cursors.Hand;
            this.tgBudget.HeadColorA = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(223)))), ((int)(((byte)(230)))));
            this.tgBudget.HeadColorB = System.Drawing.Color.White;
            this.tgBudget.HeadColorC = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(158)))), ((int)(((byte)(255)))));
            this.tgBudget.HeadColorD = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(158)))), ((int)(((byte)(255)))));
            this.tgBudget.Location = new System.Drawing.Point(450, 135);
            this.tgBudget.Name = "tgBudget";
            this.tgBudget.Size = new System.Drawing.Size(48, 20);
            this.tgBudget.TabIndex = 6;
            // 
            // lblMonthAlert
            // 
            this.lblMonthAlert.AutoSize = true;
            this.lblMonthAlert.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblMonthAlert.Location = new System.Drawing.Point(20, 190);
            this.lblMonthAlert.Name = "lblMonthAlert";
            this.lblMonthAlert.Size = new System.Drawing.Size(120, 19);
            this.lblMonthAlert.TabIndex = 7;
            this.lblMonthAlert.Text = "Monthly Reports";
            // 
            // lblMonthDesc
            // 
            this.lblMonthDesc.AutoSize = true;
            this.lblMonthDesc.ForeColor = System.Drawing.Color.Gray;
            this.lblMonthDesc.Location = new System.Drawing.Point(20, 210);
            this.lblMonthDesc.Name = "lblMonthDesc";
            this.lblMonthDesc.Size = new System.Drawing.Size(128, 13);
            this.lblMonthDesc.TabIndex = 8;
            this.lblMonthDesc.Text = "Summary of your finances";
            // 
            // tgMonthly
            // 
            this.tgMonthly.BaseColor = System.Drawing.Color.White;
            this.tgMonthly.BaseColorA = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(223)))), ((int)(((byte)(230)))));
            this.tgMonthly.BaseColorB = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(64)))), ((int)(((byte)(158)))), ((int)(((byte)(255)))));
            this.tgMonthly.Cursor = System.Windows.Forms.Cursors.Hand;
            this.tgMonthly.HeadColorA = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(223)))), ((int)(((byte)(230)))));
            this.tgMonthly.HeadColorB = System.Drawing.Color.White;
            this.tgMonthly.HeadColorC = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(158)))), ((int)(((byte)(255)))));
            this.tgMonthly.HeadColorD = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(158)))), ((int)(((byte)(255)))));
            this.tgMonthly.Location = new System.Drawing.Point(450, 195);
            this.tgMonthly.Name = "tgMonthly";
            this.tgMonthly.Size = new System.Drawing.Size(48, 20);
            this.tgMonthly.TabIndex = 9;
            // 
            // btnConfigEmail
            // 
            this.btnConfigEmail.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(223)))), ((int)(((byte)(230)))));
            this.btnConfigEmail.ButtonType = ReaLTaiizor.Util.HopeButtonType.Primary;
            this.btnConfigEmail.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnConfigEmail.DangerColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(108)))), ((int)(((byte)(108)))));
            this.btnConfigEmail.DefaultColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.btnConfigEmail.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.btnConfigEmail.HoverTextColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(49)))), ((int)(((byte)(51)))));
            this.btnConfigEmail.InfoColor = System.Drawing.Color.FromArgb(((int)(((byte)(144)))), ((int)(((byte)(147)))), ((int)(((byte)(153)))));
            this.btnConfigEmail.Location = new System.Drawing.Point(20, 250);
            this.btnConfigEmail.Name = "btnConfigEmail";
            this.btnConfigEmail.PrimaryColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(158)))), ((int)(((byte)(255)))));
            this.btnConfigEmail.Size = new System.Drawing.Size(470, 40);
            this.btnConfigEmail.SuccessColor = System.Drawing.Color.FromArgb(((int)(((byte)(103)))), ((int)(((byte)(194)))), ((int)(((byte)(58)))));
            this.btnConfigEmail.TabIndex = 10;
            this.btnConfigEmail.Text = "Configure Email Alerts";
            this.btnConfigEmail.TextColor = System.Drawing.Color.White;
            this.btnConfigEmail.WarningColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(162)))), ((int)(((byte)(60)))));
            // 
            // lblLang
            // 
            this.lblLang.AutoSize = true;
            this.lblLang.ForeColor = System.Drawing.Color.Gray;
            this.lblLang.Location = new System.Drawing.Point(40, 710);
            this.lblLang.Name = "lblLang";
            this.lblLang.Size = new System.Drawing.Size(66, 13);
            this.lblLang.TabIndex = 6;
            this.lblLang.Text = "LANGUAGE";
            // 
            // cboLang
            // 
            this.cboLang.Cursor = System.Windows.Forms.Cursors.Hand;
            this.cboLang.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cboLang.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cboLang.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.cboLang.ItemHeight = 30;
            this.cboLang.Items.AddRange(new object[] {
            "English (United States)"});
            this.cboLang.Location = new System.Drawing.Point(40, 730);
            this.cboLang.Name = "cboLang";
            this.cboLang.Size = new System.Drawing.Size(180, 36);
            this.cboLang.TabIndex = 7;
            // 
            // lblCurr
            // 
            this.lblCurr.AutoSize = true;
            this.lblCurr.ForeColor = System.Drawing.Color.Gray;
            this.lblCurr.Location = new System.Drawing.Point(240, 710);
            this.lblCurr.Name = "lblCurr";
            this.lblCurr.Size = new System.Drawing.Size(115, 13);
            this.lblCurr.TabIndex = 8;
            this.lblCurr.Text = "CURRENCY FORMAT";
            // 
            // cboCurr
            // 
            this.cboCurr.Cursor = System.Windows.Forms.Cursors.Hand;
            this.cboCurr.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cboCurr.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cboCurr.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.cboCurr.ItemHeight = 30;
            this.cboCurr.Items.AddRange(new object[] {
            "USD ($) - Dollar"});
            this.cboCurr.Location = new System.Drawing.Point(240, 730);
            this.cboCurr.Name = "cboCurr";
            this.cboCurr.Size = new System.Drawing.Size(180, 36);
            this.cboCurr.TabIndex = 9;
            // 
            // lblExport
            // 
            this.lblExport.AutoSize = true;
            this.lblExport.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblExport.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.lblExport.Location = new System.Drawing.Point(600, 740);
            this.lblExport.Name = "lblExport";
            this.lblExport.Size = new System.Drawing.Size(146, 19);
            this.lblExport.TabIndex = 10;
            this.lblExport.Text = "Export Account Data";
            // 
            // btnFactoryReset
            // 
            this.btnFactoryReset.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(223)))), ((int)(((byte)(230)))));
            this.btnFactoryReset.ButtonType = ReaLTaiizor.Util.HopeButtonType.Primary;
            this.btnFactoryReset.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnFactoryReset.DangerColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(108)))), ((int)(((byte)(108)))));
            this.btnFactoryReset.DefaultColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.btnFactoryReset.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.btnFactoryReset.ForeColor = System.Drawing.Color.White;
            this.btnFactoryReset.HoverTextColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(49)))), ((int)(((byte)(51)))));
            this.btnFactoryReset.InfoColor = System.Drawing.Color.FromArgb(((int)(((byte)(144)))), ((int)(((byte)(147)))), ((int)(((byte)(153)))));
            this.btnFactoryReset.Location = new System.Drawing.Point(880, 730);
            this.btnFactoryReset.Name = "btnFactoryReset";
            this.btnFactoryReset.PrimaryColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(158)))), ((int)(((byte)(255)))));
            this.btnFactoryReset.Size = new System.Drawing.Size(190, 36);
            this.btnFactoryReset.SuccessColor = System.Drawing.Color.FromArgb(((int)(((byte)(103)))), ((int)(((byte)(194)))), ((int)(((byte)(58)))));
            this.btnFactoryReset.TabIndex = 11;
            this.btnFactoryReset.Text = "Factory Reset";
            this.btnFactoryReset.TextColor = System.Drawing.Color.White;
            this.btnFactoryReset.WarningColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(162)))), ((int)(((byte)(60)))));
            this.btnFactoryReset.Click += new System.EventHandler(this.btnFactoryReset_Click);
            // 
            // SettingsForm
            // 
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(248)))), ((int)(((byte)(252)))));
            this.ClientSize = new System.Drawing.Size(1110, 780);
            this.Controls.Add(this.lblPageTitle);
            this.Controls.Add(this.lblPageSub);
            this.Controls.Add(this.pnlProfile);
            this.Controls.Add(this.pnlAppearance);
            this.Controls.Add(this.pnlSecurity);
            this.Controls.Add(this.lblLang);
            this.Controls.Add(this.cboLang);
            this.Controls.Add(this.lblCurr);
            this.Controls.Add(this.cboCurr);
            this.Controls.Add(this.lblExport);
            this.Controls.Add(this.btnFactoryReset);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "SettingsForm";
            this.Text = "Settings";
            this.pnlProfile.ResumeLayout(false);
            this.pnlProfile.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picAvatar)).EndInit();
            this.pnlAppearance.ResumeLayout(false);
            this.pnlAppearance.PerformLayout();
            this.pnlSecurity.ResumeLayout(false);
            this.pnlSecurity.PerformLayout();
            this.pnlPrivacy.ResumeLayout(false);
            this.pnlPrivacy.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private System.Windows.Forms.Label lblPageTitle, lblPageSub;
        private System.Windows.Forms.Panel pnlProfile;
        private ReaLTaiizor.Controls.HopePictureBox picAvatar;
        private System.Windows.Forms.Label lblProfileName, lblRole;
        private ReaLTaiizor.Controls.HopeButton btnEditProfile;
        private System.Windows.Forms.Label lblEmailLbl, lblPhoneLbl, lblLocLbl, lblTimeLbl;
        private ReaLTaiizor.Controls.HopeTextBox txtEmail, txtPhone, txtLocation, txtTimezone;

        private System.Windows.Forms.Panel pnlAppearance;
        private System.Windows.Forms.Label lblAppTitle;
        private System.Windows.Forms.Panel pnlLightMode, pnlDarkMode;
        private System.Windows.Forms.Label lblLightMode, lblDarkMode;

        private System.Windows.Forms.Panel pnlSecurity;
        private System.Windows.Forms.Label lblSecTitle, lblChangePass;
        private ReaLTaiizor.Controls.HopeTextBox txtCurrentPass, txtNewPass, txtConfirmPass;
        private ReaLTaiizor.Controls.HopeButton btnUpdatePassword;
        private System.Windows.Forms.Label lbl2FA, lbl2FADesc;
        private ReaLTaiizor.Controls.HopeToggle tg2FA;
        private System.Windows.Forms.Panel pnlPrivacy;
        private System.Windows.Forms.Label lblPrivacyTitle, lblPrivacyDesc;

        private System.Windows.Forms.Panel pnlNotifications;
        private System.Windows.Forms.Label lblNotifTitle;
        private System.Windows.Forms.Label lblDepAlert, lblDepDesc;
        private ReaLTaiizor.Controls.HopeToggle tgDeposit;
        private System.Windows.Forms.Label lblBudgAlert, lblBudgDesc;
        private ReaLTaiizor.Controls.HopeToggle tgBudget;
        private System.Windows.Forms.Label lblMonthAlert, lblMonthDesc;
        private ReaLTaiizor.Controls.HopeToggle tgMonthly;
        private ReaLTaiizor.Controls.HopeButton btnConfigEmail;

        private System.Windows.Forms.Label lblLang, lblCurr, lblExport;
        private ReaLTaiizor.Controls.HopeComboBox cboLang, cboCurr;
        private ReaLTaiizor.Controls.HopeButton btnFactoryReset;
    }
}
