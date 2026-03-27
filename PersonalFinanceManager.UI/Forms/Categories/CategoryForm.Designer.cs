using System.Drawing;
using System.Windows.Forms;

namespace PersonalFinanceManager.Forms.Categories
{
    partial class CategoryForm
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.pnlMain = new System.Windows.Forms.Panel();
            this.lblTitle = new System.Windows.Forms.Label();
            this.lblSubtitle = new System.Windows.Forms.Label();
            this.btnAddCategory = new ReaLTaiizor.Controls.HopeButton();
            
            this.pnlToggle = new System.Windows.Forms.Panel();
            this.btnIncome = new System.Windows.Forms.Button();
            this.btnExpenses = new System.Windows.Forms.Button();

            this.flpCategories = new System.Windows.Forms.FlowLayoutPanel();

            this.lblSpendDensityTitle = new System.Windows.Forms.Label();
            this.pnlChart = new System.Windows.Forms.Panel();

            this.pnlMain.SuspendLayout();
            this.pnlToggle.SuspendLayout();
            this.flpCategories.SuspendLayout();
            this.SuspendLayout();

            // pnlMain
            this.pnlMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlMain.AutoScroll = true;
            this.pnlMain.BackColor = System.Drawing.Color.FromArgb(248, 249, 252);
            this.pnlMain.Name = "pnlMain";

            // Header Elements
            this.lblTitle.Text = "Categories";
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 24F, System.Drawing.FontStyle.Bold);
            this.lblTitle.ForeColor = System.Drawing.Color.FromArgb(10, 10, 10);
            this.lblTitle.Location = new System.Drawing.Point(30, 20);
            this.lblTitle.AutoSize = true;

            this.lblSubtitle.Text = "Organize your flow with semantic buckets.";
            this.lblSubtitle.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblSubtitle.ForeColor = System.Drawing.Color.Gray;
            this.lblSubtitle.Location = new System.Drawing.Point(35, 65);
            this.lblSubtitle.AutoSize = true;

            // btnAddCategory
            this.btnAddCategory.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.btnAddCategory.PrimaryColor = System.Drawing.Color.FromArgb(183, 0, 82);
            this.btnAddCategory.ForeColor = System.Drawing.Color.White;
            this.btnAddCategory.Location = new System.Drawing.Point(600, 25);
            this.btnAddCategory.Size = new System.Drawing.Size(200, 45);
            this.btnAddCategory.Text = "+ Add Category";
            this.btnAddCategory.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAddCategory.Anchor = AnchorStyles.Top | AnchorStyles.Right;

            // Toggle Panel
            this.pnlToggle.Location = new System.Drawing.Point(820, 25);
            this.pnlToggle.Size = new System.Drawing.Size(220, 45);
            this.pnlToggle.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            this.pnlToggle.BackColor = System.Drawing.Color.Transparent;

            this.btnIncome.Text = "Income";
            this.btnIncome.Location = new System.Drawing.Point(2, 2);
            this.btnIncome.Size = new System.Drawing.Size(108, 41);
            this.btnIncome.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnIncome.FlatAppearance.BorderSize = 0;
            this.btnIncome.BackColor = System.Drawing.Color.White;
            this.btnIncome.ForeColor = System.Drawing.Color.Gray;
            this.btnIncome.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);

            this.btnExpenses.Text = "Expenses";
            this.btnExpenses.Location = new System.Drawing.Point(110, 2);
            this.btnExpenses.Size = new System.Drawing.Size(108, 41);
            this.btnExpenses.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExpenses.FlatAppearance.BorderSize = 0;
            this.btnExpenses.BackColor = System.Drawing.Color.FromArgb(55, 75, 85);
            this.btnExpenses.ForeColor = System.Drawing.Color.White;
            this.btnExpenses.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);

            this.pnlToggle.Controls.Add(this.btnIncome);
            this.pnlToggle.Controls.Add(this.btnExpenses);

            // flpCategories
            this.flpCategories.Location = new System.Drawing.Point(30, 110);
            this.flpCategories.Size = new System.Drawing.Size(1050, 320);
            this.flpCategories.AutoSize = true;
            this.flpCategories.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.flpCategories.AutoScroll = false;
            this.flpCategories.WrapContents = true;
            this.flpCategories.BackColor = System.Drawing.Color.Transparent;
            this.flpCategories.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;

            // Spend Density
            this.lblSpendDensityTitle.Text = "Spend Density";
            this.lblSpendDensityTitle.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.lblSpendDensityTitle.Location = new System.Drawing.Point(30, 450);
            this.lblSpendDensityTitle.AutoSize = true;

            this.pnlChart.Location = new System.Drawing.Point(30, 490);
            this.pnlChart.Size = new System.Drawing.Size(1050, 180);
            this.pnlChart.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            this.pnlChart.BackColor = System.Drawing.Color.White;

            this.pnlMain.Controls.Add(this.lblTitle);
            this.pnlMain.Controls.Add(this.lblSubtitle);
            this.pnlMain.Controls.Add(this.pnlToggle);
            this.pnlMain.Controls.Add(this.flpCategories);
            this.pnlMain.Controls.Add(this.btnAddCategory);
            this.pnlMain.Controls.Add(this.lblSpendDensityTitle);
            this.pnlMain.Controls.Add(this.pnlChart);

            // CategoryForm
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(248, 249, 252);
            this.ClientSize = new System.Drawing.Size(1110, 704);
            this.Controls.Add(this.pnlMain);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "CategoryForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;

            this.pnlMain.ResumeLayout(false);
            this.pnlMain.PerformLayout();
            this.pnlToggle.ResumeLayout(false);
            this.flpCategories.ResumeLayout(false);
            this.ResumeLayout(false);
        }

        private System.Windows.Forms.Panel pnlMain;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblSubtitle;
        private System.Windows.Forms.Panel pnlToggle;
        private System.Windows.Forms.Button btnIncome;
        private System.Windows.Forms.Button btnExpenses;
        private System.Windows.Forms.FlowLayoutPanel flpCategories;
        private ReaLTaiizor.Controls.HopeButton btnAddCategory;
        private System.Windows.Forms.Label lblSpendDensityTitle;
        private System.Windows.Forms.Panel pnlChart;
    }
}
