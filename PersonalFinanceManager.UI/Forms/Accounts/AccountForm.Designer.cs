using System.Drawing;
using System.Windows.Forms;

namespace PersonalFinanceManager.Forms.Accounts
{
    partial class AccountForm
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.pnlScrollContext = new System.Windows.Forms.Panel();
            this.lblPageTitle = new System.Windows.Forms.Label();
            this.lblPageSub = new System.Windows.Forms.Label();
            this.btnAddAccount = new ReaLTaiizor.Controls.HopeButton();
            
            this.flpAccounts = new System.Windows.Forms.FlowLayoutPanel();
            this.pnlAccountPagination = new System.Windows.Forms.Panel();
            
            this.pnlInsights = new System.Windows.Forms.Panel();
            this.lblInsightTitle = new System.Windows.Forms.Label();
            this.lblInsightText = new System.Windows.Forms.Label();
            this.lblInsightStatus = new System.Windows.Forms.Label();
            this.pnlBarBg = new System.Windows.Forms.Panel();
            this.pnlBarFill = new System.Windows.Forms.Panel();
            this.btnOptimize = new ReaLTaiizor.Controls.HopeButton();
            
            this.pnlInstitutions = new System.Windows.Forms.Panel();
            this.lblInstTitle = new System.Windows.Forms.Label();
            this.btnManageInst = new System.Windows.Forms.Button();
            
            this.pnlScrollContext.SuspendLayout();
            this.pnlInsights.SuspendLayout();
            this.pnlAccountPagination.SuspendLayout();
            this.pnlInstitutions.SuspendLayout();
            this.pnlBarBg.SuspendLayout();
            this.SuspendLayout();

            // Form
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(248, 249, 252);
            this.ClientSize = new System.Drawing.Size(1110, 704);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Padding = new Padding(0);

            // pnlScrollContext
            this.pnlScrollContext.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlScrollContext.AutoScroll = true;
            this.pnlScrollContext.BackColor = System.Drawing.Color.FromArgb(248, 249, 252);
            
            this.pnlScrollContext.Controls.Add(this.lblPageTitle);
            this.pnlScrollContext.Controls.Add(this.lblPageSub);
            this.pnlScrollContext.Controls.Add(this.btnAddAccount);
            this.pnlScrollContext.Controls.Add(this.flpAccounts);
            this.pnlScrollContext.Controls.Add(this.pnlInsights);
            this.pnlScrollContext.Controls.Add(this.pnlAccountPagination);
            this.pnlScrollContext.Controls.Add(this.pnlInstitutions);

            // lblPageTitle
            this.lblPageTitle.AutoSize = true;
            this.lblPageTitle.Font = new System.Drawing.Font("Segoe UI", 24F, System.Drawing.FontStyle.Bold);
            this.lblPageTitle.ForeColor = System.Drawing.Color.FromArgb(25, 28, 29);
            this.lblPageTitle.Location = new System.Drawing.Point(30, 20);
            this.lblPageTitle.Text = "Financial Overview";

            // lblPageSub
            this.lblPageSub.AutoSize = true;
            this.lblPageSub.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular);
            this.lblPageSub.ForeColor = System.Drawing.Color.Gray;
            this.lblPageSub.Location = new System.Drawing.Point(35, 85);
            this.lblPageSub.Text = "Manage your linked accounts and wallets";

            // btnAddAccount
            this.btnAddAccount.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.btnAddAccount.PrimaryColor = System.Drawing.Color.FromArgb(183, 0, 82);
            this.btnAddAccount.ForeColor = System.Drawing.Color.White;
            this.btnAddAccount.Location = new System.Drawing.Point(860, 25);
            this.btnAddAccount.Size = new System.Drawing.Size(200, 45);
            this.btnAddAccount.Text = "+ Add New Account";
            this.btnAddAccount.Cursor = System.Windows.Forms.Cursors.Hand;

            // flpAccounts
            this.flpAccounts.Location = new System.Drawing.Point(30, 140);
            this.flpAccounts.Size = new System.Drawing.Size(1090, 230);
            this.flpAccounts.WrapContents = false;
            this.flpAccounts.AutoScroll = false;

            // pnlAccountPagination
            this.pnlAccountPagination.Location = new System.Drawing.Point(30, 360);
            this.pnlAccountPagination.Size = new System.Drawing.Size(1050, 30);
            this.pnlAccountPagination.BackColor = System.Drawing.Color.Transparent;

            

            // pnlInsights
            this.pnlInsights.Location = new System.Drawing.Point(30, 400);
            this.pnlInsights.Size = new System.Drawing.Size(1050, 180);
            this.pnlInsights.BackColor = System.Drawing.Color.Transparent;
            this.pnlInsights.Paint += new System.Windows.Forms.PaintEventHandler(this.pnlInsights_Paint);
            
            this.lblInsightTitle.AutoSize = true;
            this.lblInsightTitle.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.lblInsightTitle.ForeColor = System.Drawing.Color.White;
            this.lblInsightTitle.Location = new System.Drawing.Point(25, 25);
            this.lblInsightTitle.Text = "⚡ Quick Insights";

            this.lblInsightText.Location = new System.Drawing.Point(25, 75);
            this.lblInsightText.Size = new System.Drawing.Size(290, 80);
            this.lblInsightText.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular);
            this.lblInsightText.ForeColor = System.Drawing.Color.FromArgb(240, 255, 255, 255);
            this.lblInsightText.Text = "You\'ve reached your savings goal for \"Main Savings\" 10 days earlier than projected. Consider moving the surplus to \"Crypto Portfolio\".";
            
            this.lblInsightStatus.AutoSize = true;
            this.lblInsightStatus.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Bold);
            this.lblInsightStatus.ForeColor = System.Drawing.Color.FromArgb(200, 255, 255, 255);
            this.lblInsightStatus.Location = new System.Drawing.Point(25, 160);
            this.lblInsightStatus.Text = "OPTIMIZATION STATUS        85%";
            
            this.pnlBarBg.BackColor = System.Drawing.Color.FromArgb(60, 255, 255, 255);
            this.pnlBarBg.Location = new System.Drawing.Point(25, 185);
            this.pnlBarBg.Size = new System.Drawing.Size(290, 6);
            this.pnlBarFill.BackColor = System.Drawing.Color.White;
            this.pnlBarFill.Location = new System.Drawing.Point(0, 0);
            this.pnlBarFill.Size = new System.Drawing.Size(240, 6);
            this.pnlBarBg.Controls.Add(this.pnlBarFill);
            
            this.btnOptimize.PrimaryColor = System.Drawing.Color.White;
            this.btnOptimize.ForeColor = System.Drawing.Color.FromArgb(221, 34, 105);
            this.btnOptimize.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.btnOptimize.Location = new System.Drawing.Point(25, 215);
            this.btnOptimize.Size = new System.Drawing.Size(290, 40);
            this.btnOptimize.Text = "OPTIMIZE PORTFOLIO";
            this.btnOptimize.Cursor = System.Windows.Forms.Cursors.Hand;

            this.pnlInsights.Controls.Add(this.lblInsightTitle);
            this.pnlInsights.Controls.Add(this.lblInsightText);
            this.pnlInsights.Controls.Add(this.lblInsightStatus);
            this.pnlInsights.Controls.Add(this.pnlBarBg);
            this.pnlInsights.Controls.Add(this.btnOptimize);

            // pnlInstitutions
            this.pnlInstitutions.Location = new System.Drawing.Point(30, 600);
            this.pnlInstitutions.Size = new System.Drawing.Size(1050, 200);
            this.pnlInstitutions.BackColor = System.Drawing.Color.White;
            this.pnlInstitutions.Paint += new System.Windows.Forms.PaintEventHandler(this.pnlInstitutions_Paint);
            
            this.lblInstTitle.AutoSize = true;
            this.lblInstTitle.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lblInstTitle.ForeColor = System.Drawing.Color.FromArgb(25, 28, 29);
            this.lblInstTitle.Location = new System.Drawing.Point(30, 20);
            this.lblInstTitle.Text = "Institutional Connections";
            
            this.btnManageInst.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnManageInst.FlatAppearance.BorderSize = 0;
            this.btnManageInst.ForeColor = System.Drawing.Color.FromArgb(67, 96, 109);
            this.btnManageInst.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnManageInst.Location = new System.Drawing.Point(840, 15);
            this.btnManageInst.Size = new System.Drawing.Size(180, 30);
            this.btnManageInst.Text = "Manage Connections >";
            this.btnManageInst.BackColor = System.Drawing.Color.Transparent;
            this.btnManageInst.Cursor = System.Windows.Forms.Cursors.Hand;

            this.pnlInstitutions.Controls.Add(this.lblInstTitle);
            this.pnlInstitutions.Controls.Add(this.btnManageInst);

            // Assembly ///////////////////////////////////////
            this.Controls.Add(this.pnlScrollContext);

            this.pnlScrollContext.ResumeLayout(false);
            this.pnlScrollContext.PerformLayout();
            this.pnlInsights.ResumeLayout(false);
            this.pnlInsights.PerformLayout();
            this.pnlAccountPagination.ResumeLayout(false);
            this.pnlInstitutions.ResumeLayout(false);
            this.pnlInstitutions.PerformLayout();
            this.pnlBarBg.ResumeLayout(false);
            this.ResumeLayout(false);
        }

        private System.Windows.Forms.Panel pnlScrollContext;
        private System.Windows.Forms.Label lblPageTitle;
        private System.Windows.Forms.Label lblPageSub;
        private ReaLTaiizor.Controls.HopeButton btnAddAccount;
        private System.Windows.Forms.FlowLayoutPanel flpAccounts;
        private System.Windows.Forms.Panel pnlAccountPagination;
        private System.Windows.Forms.Panel pnlInsights;
        private System.Windows.Forms.Label lblInsightTitle;
        private System.Windows.Forms.Label lblInsightText;
        private System.Windows.Forms.Label lblInsightStatus;
        private System.Windows.Forms.Panel pnlBarBg;
        private System.Windows.Forms.Panel pnlBarFill;
        private ReaLTaiizor.Controls.HopeButton btnOptimize;
        private System.Windows.Forms.Panel pnlInstitutions;
        private System.Windows.Forms.Label lblInstTitle;
        private System.Windows.Forms.Button btnManageInst;
    }
}
