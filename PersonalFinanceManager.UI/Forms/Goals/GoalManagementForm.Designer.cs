using System;
using System.Drawing;
using System.Windows.Forms;

namespace PersonalFinanceManager.UI.Forms.Goals
{
    partial class GoalManagementForm
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
            this.txtSearch = new ReaLTaiizor.Controls.HopeTextBox();
            this.btnAddGoal = new ReaLTaiizor.Controls.HopeButton();
            
            this.pnlTotalProgress = new System.Windows.Forms.Panel();
            this.lblTotalSub = new System.Windows.Forms.Label();
            this.lblTotalAmt = new System.Windows.Forms.Label();
            this.pnlProgressBg = new System.Windows.Forms.Panel();
            this.pnlProgressFill = new System.Windows.Forms.Panel();
            this.lblTotalPct = new System.Windows.Forms.Label();
            this.lblTotalGain = new System.Windows.Forms.Label();
            this.lblTotalTarget = new System.Windows.Forms.Label();

            this.pnlProjection = new System.Windows.Forms.Panel();
            this.lblProjTitle = new System.Windows.Forms.Label();
            this.lblProjDate = new System.Windows.Forms.Label();
            this.lblProjSub = new System.Windows.Forms.Label();
            
            this.lblActiveTitle = new System.Windows.Forms.Label();
            this.btnFilter = new ReaLTaiizor.Controls.HopeButton();
            this.btnGrid = new ReaLTaiizor.Controls.HopeButton();
            this.flpGoals = new System.Windows.Forms.FlowLayoutPanel();
            
            this.lblActivityTitle = new System.Windows.Forms.Label();
            this.pnlActivity = new System.Windows.Forms.Panel();
            this.pnlAdvice = new System.Windows.Forms.Panel();
            this.btnOptimize = new ReaLTaiizor.Controls.HopeButton();

            this.pnlScrollContext.SuspendLayout();
            this.pnlTotalProgress.SuspendLayout();
            this.pnlProgressBg.SuspendLayout();
            this.pnlProjection.SuspendLayout();
            this.SuspendLayout();

            // Form
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(248, 249, 250);
            this.ClientSize = new System.Drawing.Size(1110, 704);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Padding = new Padding(0);

            // pnlScrollContext
            this.pnlScrollContext.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlScrollContext.AutoScroll = true;
            this.pnlScrollContext.BackColor = System.Drawing.Color.FromArgb(248, 249, 252);
            
            // Context adding
            this.pnlScrollContext.Controls.Add(this.lblPageTitle);
            this.pnlScrollContext.Controls.Add(this.txtSearch);
            this.pnlScrollContext.Controls.Add(this.btnAddGoal);
            this.pnlScrollContext.Controls.Add(this.pnlTotalProgress);
            this.pnlScrollContext.Controls.Add(this.pnlProjection);
            this.pnlScrollContext.Controls.Add(this.lblActiveTitle);
            this.pnlScrollContext.Controls.Add(this.btnFilter);
            this.pnlScrollContext.Controls.Add(this.btnGrid);
            this.pnlScrollContext.Controls.Add(this.flpGoals);
            this.pnlScrollContext.Controls.Add(this.lblActivityTitle);
            this.pnlScrollContext.Controls.Add(this.pnlActivity);
            this.pnlScrollContext.Controls.Add(this.pnlAdvice);

            // lblPageTitle
            this.lblPageTitle.AutoSize = true;
            this.lblPageTitle.Font = new System.Drawing.Font("Segoe UI", 20F, System.Drawing.FontStyle.Bold);
            this.lblPageTitle.ForeColor = System.Drawing.Color.FromArgb(25, 45, 65);
            this.lblPageTitle.Location = new System.Drawing.Point(30, 20);
            this.lblPageTitle.Text = "Financial Goals";

            // txtSearch
            this.txtSearch.Location = new System.Drawing.Point(360, 25);
            this.txtSearch.Size = new System.Drawing.Size(400, 36);
            this.txtSearch.Text = "  Search goals...";

            // btnAddGoal
            this.btnAddGoal.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.btnAddGoal.PrimaryColor = System.Drawing.Color.FromArgb(183, 0, 82);
            this.btnAddGoal.ForeColor = System.Drawing.Color.White;
            this.btnAddGoal.Location = new System.Drawing.Point(880, 25);
            this.btnAddGoal.Size = new System.Drawing.Size(180, 40);
            this.btnAddGoal.Text = "+ Add New Goal";
            this.btnAddGoal.Cursor = System.Windows.Forms.Cursors.Hand;

            // pnlTotalProgress
            this.pnlTotalProgress.Location = new System.Drawing.Point(30, 90);
            this.pnlTotalProgress.Size = new System.Drawing.Size(700, 180);
            this.pnlTotalProgress.BackColor = System.Drawing.Color.Transparent;
            this.pnlTotalProgress.Paint += new System.Windows.Forms.PaintEventHandler(this.pnlTotalProgress_Paint);

            this.lblTotalSub.Text = "TOTAL SAVINGS PROGRESS";
            this.lblTotalSub.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblTotalSub.ForeColor = System.Drawing.Color.Gray;
            this.lblTotalSub.Location = new System.Drawing.Point(30, 30);
            this.lblTotalSub.AutoSize = true;

            this.lblTotalAmt.Text = "$142,500.00";
            this.lblTotalAmt.Font = new System.Drawing.Font("Segoe UI", 28F, System.Drawing.FontStyle.Bold);
            this.lblTotalAmt.ForeColor = System.Drawing.Color.FromArgb(20, 50, 70);
            this.lblTotalAmt.Location = new System.Drawing.Point(25, 60);
            this.lblTotalAmt.AutoSize = true;
            
            this.lblTotalTarget.Text = "of $250,000.00 goal";
            this.lblTotalTarget.Font = new System.Drawing.Font("Segoe UI", 10.5F, System.Drawing.FontStyle.Regular);
            this.lblTotalTarget.ForeColor = System.Drawing.Color.FromArgb(100, 100, 100);
            this.lblTotalTarget.Location = new System.Drawing.Point(320, 85);
            this.lblTotalTarget.AutoSize = true;

            this.pnlProgressBg.Location = new System.Drawing.Point(30, 130);
            this.pnlProgressBg.Size = new System.Drawing.Size(640, 12);
            this.pnlProgressBg.BackColor = System.Drawing.Color.FromArgb(235, 235, 235);
            this.pnlProgressFill.Location = new System.Drawing.Point(0, 0);
            this.pnlProgressFill.Size = new System.Drawing.Size(380, 12);
            this.pnlProgressFill.BackColor = System.Drawing.Color.FromArgb(183, 0, 82);
            this.pnlProgressBg.Controls.Add(this.pnlProgressFill);

            this.lblTotalPct.Text = "57% Achieved";
            this.lblTotalPct.Font = new System.Drawing.Font("Segoe UI", 8.5F);
            this.lblTotalPct.ForeColor = System.Drawing.Color.Gray;
            this.lblTotalPct.Location = new System.Drawing.Point(30, 150);
            this.lblTotalPct.AutoSize = true;

            this.lblTotalGain.Text = "↗ +$4,200 this month";
            this.lblTotalGain.Font = new System.Drawing.Font("Segoe UI", 8.5F, System.Drawing.FontStyle.Bold);
            this.lblTotalGain.ForeColor = System.Drawing.Color.FromArgb(40, 140, 60);
            this.lblTotalGain.Location = new System.Drawing.Point(540, 150);
            this.lblTotalGain.AutoSize = true;

            this.pnlTotalProgress.Controls.Add(this.lblTotalSub);
            this.pnlTotalProgress.Controls.Add(this.lblTotalAmt);
            this.pnlTotalProgress.Controls.Add(this.lblTotalTarget);
            this.pnlTotalProgress.Controls.Add(this.pnlProgressBg);
            this.pnlTotalProgress.Controls.Add(this.lblTotalPct);
            this.pnlTotalProgress.Controls.Add(this.lblTotalGain);

            // pnlProjection
            this.pnlProjection.Location = new System.Drawing.Point(750, 90);
            this.pnlProjection.Size = new System.Drawing.Size(330, 180);
            this.pnlProjection.BackColor = System.Drawing.Color.Transparent;
            this.pnlProjection.Paint += new System.Windows.Forms.PaintEventHandler(this.pnlProjection_Paint);

            this.lblProjTitle.Text = "On track to reach all goals by";
            this.lblProjTitle.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.lblProjTitle.ForeColor = System.Drawing.Color.White;
            this.lblProjTitle.Location = new System.Drawing.Point(20, 70);
            this.lblProjTitle.AutoSize = true;

            this.lblProjDate.Text = "Oct 2026";
            this.lblProjDate.Font = new System.Drawing.Font("Segoe UI", 24F, System.Drawing.FontStyle.Bold);
            this.lblProjDate.ForeColor = System.Drawing.Color.White;
            this.lblProjDate.Location = new System.Drawing.Point(15, 95);
            this.lblProjDate.AutoSize = true;

            this.lblProjSub.Text = "Keep maintaining your current monthly\ndeposit of $2,500 to stay ahead.";
            this.lblProjSub.Font = new System.Drawing.Font("Segoe UI", 8.5F);
            this.lblProjSub.ForeColor = System.Drawing.Color.LightGray;
            this.lblProjSub.Location = new System.Drawing.Point(20, 145);
            this.lblProjSub.AutoSize = true;

            this.pnlProjection.Controls.Add(this.lblProjTitle);
            this.pnlProjection.Controls.Add(this.lblProjDate);
            this.pnlProjection.Controls.Add(this.lblProjSub);

            // Middle Section (Goals)
            this.lblActiveTitle.Text = "Active Savings Goals";
            this.lblActiveTitle.Font = new System.Drawing.Font("Segoe UI", 13F, System.Drawing.FontStyle.Bold);
            this.lblActiveTitle.ForeColor = System.Drawing.Color.FromArgb(40, 70, 90);
            this.lblActiveTitle.Location = new System.Drawing.Point(30, 300);
            this.lblActiveTitle.AutoSize = true;

            this.btnFilter.Text = "≡";
            this.btnFilter.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.btnFilter.PrimaryColor = System.Drawing.Color.FromArgb(230, 230, 230);
            this.btnFilter.ForeColor = System.Drawing.Color.Gray;
            this.btnFilter.Location = new System.Drawing.Point(1000, 290);
            this.btnFilter.Size = new System.Drawing.Size(35, 35);
            
            this.btnGrid.Text = "⊞";
            this.btnGrid.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.btnGrid.PrimaryColor = System.Drawing.Color.FromArgb(230, 230, 230);
            this.btnGrid.ForeColor = System.Drawing.Color.Gray;
            this.btnGrid.Location = new System.Drawing.Point(1045, 290);
            this.btnGrid.Size = new System.Drawing.Size(35, 35);

            this.flpGoals.Location = new System.Drawing.Point(30, 340);
            this.flpGoals.Size = new System.Drawing.Size(1050, 220);
            this.flpGoals.WrapContents = false;
            this.flpGoals.AutoScroll = true;

            // Lower Section
            this.lblActivityTitle.Text = "Recent Goal Activity";
            this.lblActivityTitle.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lblActivityTitle.Location = new System.Drawing.Point(30, 580);
            this.lblActivityTitle.AutoSize = true;

            this.pnlActivity.Location = new System.Drawing.Point(30, 620);
            this.pnlActivity.Size = new System.Drawing.Size(740, 200);
            this.pnlActivity.BackColor = System.Drawing.Color.Transparent;
            this.pnlActivity.Paint += new System.Windows.Forms.PaintEventHandler(this.pnlActivity_Paint);

            this.pnlAdvice.Location = new System.Drawing.Point(820, 580);
            this.pnlAdvice.Size = new System.Drawing.Size(260, 240);
            this.pnlAdvice.BackColor = System.Drawing.Color.Transparent;
            this.pnlAdvice.Paint += new System.Windows.Forms.PaintEventHandler(this.pnlAdvice_Paint);

            this.btnOptimize.Text = "Optimize\nSavings";
            this.btnOptimize.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnOptimize.PrimaryColor = System.Drawing.Color.White;
            this.btnOptimize.ForeColor = System.Drawing.Color.FromArgb(40, 70, 90);
            this.btnOptimize.Location = new System.Drawing.Point(30, 175);
            this.btnOptimize.Size = new System.Drawing.Size(200, 45);
            this.pnlAdvice.Controls.Add(this.btnOptimize);

            this.Controls.Add(this.pnlScrollContext);

            this.pnlScrollContext.ResumeLayout(false);
            this.pnlScrollContext.PerformLayout();
            this.pnlTotalProgress.ResumeLayout(false);
            this.pnlTotalProgress.PerformLayout();
            this.pnlProgressBg.ResumeLayout(false);
            this.pnlProjection.ResumeLayout(false);
            this.pnlProjection.PerformLayout();
            this.ResumeLayout(false);
        }

        private System.Windows.Forms.Panel pnlScrollContext;
        private System.Windows.Forms.Label lblPageTitle;
        private ReaLTaiizor.Controls.HopeTextBox txtSearch;
        private ReaLTaiizor.Controls.HopeButton btnAddGoal;
        
        private System.Windows.Forms.Panel pnlTotalProgress;
        private System.Windows.Forms.Label lblTotalSub;
        private System.Windows.Forms.Label lblTotalAmt;
        private System.Windows.Forms.Label lblTotalTarget;
        private System.Windows.Forms.Panel pnlProgressBg;
        private System.Windows.Forms.Panel pnlProgressFill;
        private System.Windows.Forms.Label lblTotalPct;
        private System.Windows.Forms.Label lblTotalGain;

        private System.Windows.Forms.Panel pnlProjection;
        private System.Windows.Forms.Label lblProjTitle;
        private System.Windows.Forms.Label lblProjDate;
        private System.Windows.Forms.Label lblProjSub;

        private System.Windows.Forms.Label lblActiveTitle;
        private ReaLTaiizor.Controls.HopeButton btnFilter;
        private ReaLTaiizor.Controls.HopeButton btnGrid;
        private System.Windows.Forms.FlowLayoutPanel flpGoals;
        
        private System.Windows.Forms.Label lblActivityTitle;
        private System.Windows.Forms.Panel pnlActivity;
        
        private System.Windows.Forms.Panel pnlAdvice;
        private ReaLTaiizor.Controls.HopeButton btnOptimize;
    }
}
