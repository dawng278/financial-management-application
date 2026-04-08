    using System.Drawing;
using System.Windows.Forms;
namespace PersonalFinanceManager.UI.Forms.Shell
{
    partial class BaseForm
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
            
            this.pnlSidebar = new ReaLTaiizor.Controls.Panel();
            this.pnlTopAppBar = new ReaLTaiizor.Controls.Panel();
            this.pnlContent = new System.Windows.Forms.Panel();
            
            // Sidebar Elements
            this.lblLogo = new System.Windows.Forms.Label();
            this.lblLogoSubtitle = new System.Windows.Forms.Label();
            this.btnNavDashboard = new ReaLTaiizor.Controls.HopeButton();
            this.btnNavTransactions = new ReaLTaiizor.Controls.HopeButton();
            this.btnNavAccounts = new ReaLTaiizor.Controls.HopeButton();
            this.btnNavCategories = new ReaLTaiizor.Controls.HopeButton();
            this.btnNavGoals = new ReaLTaiizor.Controls.HopeButton();
            this.btnNavReports = new ReaLTaiizor.Controls.HopeButton();
            this.btnNavSettings = new ReaLTaiizor.Controls.HopeButton();
            this.btnNavLogout = new ReaLTaiizor.Controls.HopeButton();
            
            // TopAppBar Elements
            this.lblUserName = new System.Windows.Forms.Label();
            this.btnCloseForm = new ReaLTaiizor.Controls.HopeButton();
            this.pnlSidebar.SuspendLayout();
            this.pnlTopAppBar.SuspendLayout();
            this.SuspendLayout();
            // 
            // 
            // 
            // 
            // 
            // 
            
            // 
            // pnlSidebar
            // 
            this.pnlSidebar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(249)))), ((int)(((byte)(250)))));
            this.pnlSidebar.Controls.Add(this.lblLogo);
            this.pnlSidebar.Controls.Add(this.lblLogoSubtitle);
            this.pnlSidebar.Controls.Add(this.btnNavDashboard);
            this.pnlSidebar.Controls.Add(this.btnNavTransactions);
            this.pnlSidebar.Controls.Add(this.btnNavAccounts);
            this.pnlSidebar.Controls.Add(this.btnNavCategories);
            this.pnlSidebar.Controls.Add(this.btnNavGoals);
            this.pnlSidebar.Controls.Add(this.btnNavReports);
            this.pnlSidebar.Controls.Add(this.btnNavSettings);
            this.pnlSidebar.Controls.Add(this.btnNavLogout);
            this.pnlSidebar.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlSidebar.Location = new System.Drawing.Point(0, 0);
            this.pnlSidebar.Name = "pnlSidebar";
            this.pnlSidebar.Size = new System.Drawing.Size(256, 768);
            this.pnlSidebar.TabIndex = 0;
            
            // 
            // pnlTopAppBar
            // 
            this.pnlTopAppBar.BackColor = System.Drawing.Color.White;
            this.pnlTopAppBar.Controls.Add(this.picAvatar);
            this.pnlTopAppBar.Controls.Add(this.lblUserName);
            // this.pnlTopAppBar.Controls.Add(this.btnCloseForm);
            this.pnlTopAppBar.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlTopAppBar.Location = new System.Drawing.Point(256, 0);
            this.pnlTopAppBar.Name = "pnlTopAppBar";
            this.pnlTopAppBar.Size = new System.Drawing.Size(1110, 64);
            this.pnlTopAppBar.TabIndex = 1;
            
            // 
            // pnlContent
            // 
            this.pnlContent.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(249)))), ((int)(((byte)(250)))));
            this.pnlContent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlContent.Location = new System.Drawing.Point(256, 64);
            this.pnlContent.Name = "pnlContent";
            this.pnlContent.Size = new System.Drawing.Size(1110, 704);
            this.pnlContent.TabIndex = 2;
            // 
            // lblLogo
            // 
            this.lblLogo.Font = new System.Drawing.Font("Manrope", 15.5F, System.Drawing.FontStyle.Bold);
            this.lblLogo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(67)))), ((int)(((byte)(96)))), ((int)(((byte)(109)))));
            this.lblLogo.Location = new System.Drawing.Point(30, 25);
            this.lblLogo.Name = "lblLogo";
            this.lblLogo.Size = new System.Drawing.Size(200, 30);
            this.lblLogo.TabIndex = 1;
            this.lblLogo.Text = "Executive Finance";
            
            // 
            // lblLogoSubtitle
            // 
            this.lblLogoSubtitle.Font = new System.Drawing.Font("Inter", 8.5F, System.Drawing.FontStyle.Bold);
            this.lblLogoSubtitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(160)))), ((int)(((byte)(165)))), ((int)(((byte)(170)))));
            this.lblLogoSubtitle.Location = new System.Drawing.Point(30, 55);
            this.lblLogoSubtitle.Name = "lblLogoSubtitle";
            this.lblLogoSubtitle.Size = new System.Drawing.Size(180, 20);
            this.lblLogoSubtitle.TabIndex = 2;
            this.lblLogoSubtitle.Text = "PREMIUM WORKSPACE";
            // 
            // btnNavDashboard
            // 


            this.btnNavDashboard.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnNavDashboard.Font = new System.Drawing.Font("Manrope", 11F, System.Drawing.FontStyle.Bold);
            this.btnNavDashboard.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(67)))), ((int)(((byte)(96)))), ((int)(((byte)(109)))));
            this.btnNavDashboard.Location = new System.Drawing.Point(0, 120);
            this.btnNavDashboard.Name = "btnNavDashboard";
            this.btnNavDashboard.Size = new System.Drawing.Size(230, 44);
            this.btnNavDashboard.TabIndex = 0;
            this.btnNavDashboard.Text = "      Dashboard";
            this.btnNavDashboard.Anchor = AnchorStyles.Top | AnchorStyles.Left;
            this.btnNavDashboard.Click += new System.EventHandler(this.BtnNavDashboard_Click);
            // 
            // btnNavTransactions
            // 


            this.btnNavTransactions.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnNavTransactions.Font = new System.Drawing.Font("Manrope", 11F, System.Drawing.FontStyle.Bold);
            this.btnNavTransactions.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(67)))), ((int)(((byte)(96)))), ((int)(((byte)(109)))));
            this.btnNavTransactions.Location = new System.Drawing.Point(0, 170);
            this.btnNavTransactions.Name = "btnNavTransactions";
            this.btnNavTransactions.Size = new System.Drawing.Size(230, 44);
            this.btnNavTransactions.TabIndex = 1;
            this.btnNavTransactions.Text = "      Transactions";
            this.btnNavTransactions.Anchor = AnchorStyles.Top | AnchorStyles.Left;
            this.btnNavTransactions.Click += new System.EventHandler(this.BtnNavTransactions_Click);
            // 
            // btnNavAccounts
            // 


            this.btnNavAccounts.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnNavAccounts.Font = new System.Drawing.Font("Manrope", 11F, System.Drawing.FontStyle.Bold);
            this.btnNavAccounts.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(67)))), ((int)(((byte)(96)))), ((int)(((byte)(109)))));
            this.btnNavAccounts.Location = new System.Drawing.Point(0, 220);
            this.btnNavAccounts.Name = "btnNavAccounts";
            this.btnNavAccounts.Size = new System.Drawing.Size(230, 44);
            this.btnNavAccounts.TabIndex = 2;
            this.btnNavAccounts.Text = "      Accounts";
            this.btnNavAccounts.Anchor = AnchorStyles.Top | AnchorStyles.Left;
            this.btnNavAccounts.Click += new System.EventHandler(this.BtnNavAccounts_Click);
            // 
            // btnNavCategories
            // 


            this.btnNavCategories.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnNavCategories.Font = new System.Drawing.Font("Manrope", 11F, System.Drawing.FontStyle.Bold);
            this.btnNavCategories.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(67)))), ((int)(((byte)(96)))), ((int)(((byte)(109)))));
            this.btnNavCategories.Location = new System.Drawing.Point(0, 270);
            this.btnNavCategories.Name = "btnNavCategories";
            this.btnNavCategories.Size = new System.Drawing.Size(230, 44);
            this.btnNavCategories.TabIndex = 3;
            this.btnNavCategories.Text = "      Categories";
            this.btnNavCategories.Anchor = AnchorStyles.Top | AnchorStyles.Left;
            this.btnNavCategories.Click += new System.EventHandler(this.BtnNavCategories_Click);
            // 
            // btnNavGoals
            // 


            this.btnNavGoals.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnNavGoals.Font = new System.Drawing.Font("Manrope", 11F, System.Drawing.FontStyle.Bold);
            this.btnNavGoals.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(67)))), ((int)(((byte)(96)))), ((int)(((byte)(109)))));
            this.btnNavGoals.Location = new System.Drawing.Point(0, 320);
            this.btnNavGoals.Name = "btnNavGoals";
            this.btnNavGoals.Size = new System.Drawing.Size(230, 44);
            this.btnNavGoals.TabIndex = 4;
            this.btnNavGoals.Text = "      Goals";
            this.btnNavGoals.Anchor = AnchorStyles.Top | AnchorStyles.Left;
            this.btnNavGoals.Click += new System.EventHandler(this.BtnNavGoals_Click);
            // 
            // btnNavReports
            // 


            this.btnNavReports.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnNavReports.Font = new System.Drawing.Font("Manrope", 11F, System.Drawing.FontStyle.Bold);
            this.btnNavReports.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(67)))), ((int)(((byte)(96)))), ((int)(((byte)(109)))));
            this.btnNavReports.Location = new System.Drawing.Point(0, 370);
            this.btnNavReports.Name = "btnNavReports";
            this.btnNavReports.Size = new System.Drawing.Size(230, 44);
            this.btnNavReports.TabIndex = 5;
            this.btnNavReports.Text = "      Reports";
            this.btnNavReports.Anchor = AnchorStyles.Top | AnchorStyles.Left;
            this.btnNavReports.Click += new System.EventHandler(this.BtnNavReports_Click);
            // 
            // btnNavSettings
            // 


            this.btnNavSettings.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnNavSettings.Font = new System.Drawing.Font("Manrope", 11F, System.Drawing.FontStyle.Bold);
            this.btnNavSettings.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(67)))), ((int)(((byte)(96)))), ((int)(((byte)(109)))));
            this.btnNavSettings.Location = new System.Drawing.Point(0, 420);
            this.btnNavSettings.Name = "btnNavSettings";
            this.btnNavSettings.Size = new System.Drawing.Size(230, 44);
            this.btnNavSettings.TabIndex = 6;
            this.btnNavSettings.Text = "      Settings";
            this.btnNavSettings.Anchor = AnchorStyles.Top | AnchorStyles.Left;
            this.btnNavSettings.Click += new System.EventHandler(this.BtnNavSettings_Click);
            // 
            // btnNavLogout
            // 


            this.btnNavLogout.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnNavLogout.Font = new System.Drawing.Font("Manrope", 11F, System.Drawing.FontStyle.Bold);
            this.btnNavLogout.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(186)))), ((int)(((byte)(26)))), ((int)(((byte)(26)))));
            this.btnNavLogout.Location = new System.Drawing.Point(0, 680);
            this.btnNavLogout.Name = "btnNavLogout";
            this.btnNavLogout.Size = new System.Drawing.Size(230, 44);
            this.btnNavLogout.TabIndex = 7;
            this.btnNavLogout.Text = "      Logout";
            this.btnNavLogout.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            this.btnNavLogout.Click += new System.EventHandler(this.BtnNavLogout_Click);
            // 
            // picAvatar
            // 
            this.picAvatar = new ReaLTaiizor.Controls.HopePictureBox();
            this.picAvatar.BackColor = System.Drawing.Color.Transparent;
            this.picAvatar.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            this.picAvatar.Location = new System.Drawing.Point(860, 14);
            this.picAvatar.Name = "picAvatar";
            this.picAvatar.Size = new System.Drawing.Size(36, 36);
            this.picAvatar.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picAvatar.TabIndex = 6;
            this.picAvatar.TabStop = false;
            // 
            // lblUserName
            // 
            this.lblUserName.Font = new System.Drawing.Font("Inter", 10.5F, System.Drawing.FontStyle.Bold);
            this.lblUserName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(28)))), ((int)(((byte)(29)))));
            this.lblUserName.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            this.lblUserName.Location = new System.Drawing.Point(905, 22);
            this.lblUserName.Name = "lblUserName";
            this.lblUserName.Size = new System.Drawing.Size(150, 20);
            this.lblUserName.TabIndex = 4;
            this.lblUserName.Text = "Administrator";
            // 
            // btnCloseForm
            // 
            this.btnCloseForm.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCloseForm.Font = new System.Drawing.Font("Inter", 11F, System.Drawing.FontStyle.Bold);
            this.btnCloseForm.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(100)))), ((int)(((byte)(100)))));
            this.btnCloseForm.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            this.btnCloseForm.Location = new System.Drawing.Point(1070, 16);
            this.btnCloseForm.Name = "btnCloseForm";
            this.btnCloseForm.Size = new System.Drawing.Size(30, 30);
            this.btnCloseForm.TabIndex = 5;
            this.btnCloseForm.Text = "✕";
            this.btnCloseForm.Click += new System.EventHandler(this.btnCloseForm_Click);
            // 
            // BaseForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(1366, 768);
            this.Controls.Add(this.pnlContent);
            this.Controls.Add(this.pnlTopAppBar);
            this.Controls.Add(this.pnlSidebar);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "BaseForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "BaseForm";
            
            this.pnlSidebar.ResumeLayout(false);
            this.pnlTopAppBar.ResumeLayout(false);
            this.ResumeLayout(false);
        }
        private ReaLTaiizor.Controls.HopeButton CreateNavButton(string text, int y)
        {
            var btn = new ReaLTaiizor.Controls.HopeButton();


            btn.Cursor = System.Windows.Forms.Cursors.Hand;
            btn.Font = new System.Drawing.Font("Manrope", 11F, System.Drawing.FontStyle.Bold);
            btn.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(67)))), ((int)(((byte)(96)))), ((int)(((byte)(109)))));
            btn.Location = new System.Drawing.Point(0, y);
            btn.Name = "btnNav" + text;
            btn.Size = new System.Drawing.Size(230, 44);
            btn.TabIndex = 0;
            btn.Text = "      " + text;
            btn.Anchor = AnchorStyles.Top | AnchorStyles.Left;
            return btn;
        }
        private ReaLTaiizor.Controls.Panel pnlSidebar;
        private ReaLTaiizor.Controls.Panel pnlTopAppBar;
        private System.Windows.Forms.Panel pnlContent;
        
        private System.Windows.Forms.Label lblLogo;
        private System.Windows.Forms.Label lblLogoSubtitle;
        
        private ReaLTaiizor.Controls.HopeButton btnNavDashboard;
        private ReaLTaiizor.Controls.HopeButton btnNavTransactions;
        private ReaLTaiizor.Controls.HopeButton btnNavAccounts;
        private ReaLTaiizor.Controls.HopeButton btnNavCategories;
        private ReaLTaiizor.Controls.HopeButton btnNavGoals;
        private ReaLTaiizor.Controls.HopeButton btnNavReports;
        private ReaLTaiizor.Controls.HopeButton btnNavSettings;
        private ReaLTaiizor.Controls.HopeButton btnNavLogout;
        private ReaLTaiizor.Controls.HopePictureBox picAvatar;
        private System.Windows.Forms.Label lblUserName;
        private ReaLTaiizor.Controls.HopeButton btnCloseForm;
    }
}
