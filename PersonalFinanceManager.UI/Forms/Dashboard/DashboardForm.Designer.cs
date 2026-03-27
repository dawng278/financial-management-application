namespace PersonalFinanceManager.Forms.Dashboard
{
    partial class DashboardForm
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle cellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle cellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            
            this.pnlMain = new System.Windows.Forms.Panel();

            this.txtSearch = new ReaLTaiizor.Controls.HopeTextBox();
            this.btnAddTransaction = new ReaLTaiizor.Controls.HopeButton();

            this.pnlCardBalance = new System.Windows.Forms.Panel();
            this.lblBalanceLabel = new System.Windows.Forms.Label();
            this.lblBalance = new System.Windows.Forms.Label();
            
            this.pnlCardIncome = new System.Windows.Forms.Panel();
            this.lblIncomeLabel = new System.Windows.Forms.Label();
            this.lblIncome = new System.Windows.Forms.Label();
            
            this.pnlCardExpense = new System.Windows.Forms.Panel();
            this.lblExpenseLabel = new System.Windows.Forms.Label();
            this.lblExpense = new System.Windows.Forms.Label();

            this.pnlTrend = new System.Windows.Forms.Panel();
            this.lblTrendTitle = new System.Windows.Forms.Label();
            this.chartTrend = new LiveCharts.WinForms.CartesianChart();

            this.pnlUsage = new System.Windows.Forms.Panel();
            this.chartDonut = new LiveCharts.WinForms.PieChart();
            this.lblUsageTitle = new System.Windows.Forms.Label();
            this.lblUsagePercent = new System.Windows.Forms.Label();

            this.pnlRecent = new System.Windows.Forms.Panel();
            this.lblRecentTitle = new System.Windows.Forms.Label();
            this.dgvTrans = new System.Windows.Forms.DataGridView();

            this.pnlMain.SuspendLayout();
            this.pnlCardBalance.SuspendLayout();
            this.pnlCardIncome.SuspendLayout();
            this.pnlCardExpense.SuspendLayout();
            this.pnlTrend.SuspendLayout();
            this.pnlUsage.SuspendLayout();
            this.pnlRecent.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTrans)).BeginInit();
            this.SuspendLayout();

            // 
            // DashboardForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(248, 249, 252);
            this.ClientSize = new System.Drawing.Size(1110, 704);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;

            // ----------------------------------------------------
            // MAIN CONTENT (CARDS)
            // ----------------------------------------------------
            this.pnlMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlMain.BackColor = System.Drawing.Color.FromArgb(248, 249, 252);

            // ACTIONS
            this.txtSearch.Location = new System.Drawing.Point(30, 20);
            this.txtSearch.Size = new System.Drawing.Size(340, 40);
            this.txtSearch.Text = "Search transactions, reports...";
            
            this.btnAddTransaction.Location = new System.Drawing.Point(900, 20);
            this.btnAddTransaction.Size = new System.Drawing.Size(180, 40);
            this.btnAddTransaction.PrimaryColor = System.Drawing.Color.FromArgb(200, 20, 80);
            this.btnAddTransaction.Text = "+ Add Transaction";

            this.pnlMain.Controls.Add(this.txtSearch);
            this.pnlMain.Controls.Add(this.btnAddTransaction);

            // CARD 1: BALANCE
            this.pnlCardBalance.Location = new System.Drawing.Point(30, 80);
            this.pnlCardBalance.Size = new System.Drawing.Size(340, 140);
            this.pnlCardBalance.BackColor = System.Drawing.Color.Transparent;
            this.pnlCardBalance.Paint += new System.Windows.Forms.PaintEventHandler(this.Card_Paint);

            System.Windows.Forms.Panel accent1 = new System.Windows.Forms.Panel();
            accent1.Location = new System.Drawing.Point(0, 0);
            accent1.Width = 340;
            accent1.Height = 4;
            accent1.Tag = "Dark";
            accent1.Paint += new System.Windows.Forms.PaintEventHandler(this.TopAccent_Paint);
            this.pnlCardBalance.Controls.Add(accent1);

            this.lblBalanceLabel.Location = new System.Drawing.Point(20, 25);
            this.lblBalanceLabel.AutoSize = true;
            this.lblBalanceLabel.Text = "Total Balance";
            this.lblBalanceLabel.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular);
            this.lblBalanceLabel.ForeColor = System.Drawing.Color.Gray;

            this.lblBalance.Location = new System.Drawing.Point(20, 50);
            this.lblBalance.AutoSize = true;
            this.lblBalance.Text = "$124,592.00";
            this.lblBalance.Font = new System.Drawing.Font("Segoe UI", 24F, System.Drawing.FontStyle.Bold);
            this.lblBalance.ForeColor = System.Drawing.Color.FromArgb(20, 30, 60);

            this.pnlCardBalance.Controls.Add(this.lblBalanceLabel);
            this.pnlCardBalance.Controls.Add(this.lblBalance);

            // CARD 2: INCOME
            this.pnlCardIncome.Location = new System.Drawing.Point(385, 80);
            this.pnlCardIncome.Size = new System.Drawing.Size(340, 140);
            this.pnlCardIncome.BackColor = System.Drawing.Color.Transparent;
            this.pnlCardIncome.Paint += new System.Windows.Forms.PaintEventHandler(this.Card_Paint);

            System.Windows.Forms.Panel accent2 = new System.Windows.Forms.Panel();
            accent2.Location = new System.Drawing.Point(0, 0);
            accent2.Width = 340;
            accent2.Height = 4;
            accent2.Tag = "Green";
            accent2.Paint += new System.Windows.Forms.PaintEventHandler(this.TopAccent_Paint);
            this.pnlCardIncome.Controls.Add(accent2);

            this.lblIncomeLabel.Location = new System.Drawing.Point(20, 25);
            this.lblIncomeLabel.AutoSize = true;
            this.lblIncomeLabel.Text = "Monthly Income";
            this.lblIncomeLabel.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblIncomeLabel.ForeColor = System.Drawing.Color.Gray;

            this.lblIncome.Location = new System.Drawing.Point(20, 50);
            this.lblIncome.AutoSize = true;
            this.lblIncome.Text = "$12,400.00";
            this.lblIncome.Font = new System.Drawing.Font("Segoe UI", 24F, System.Drawing.FontStyle.Bold);
            this.lblIncome.ForeColor = System.Drawing.Color.FromArgb(20, 30, 60);

            this.pnlCardIncome.Controls.Add(this.lblIncomeLabel);
            this.pnlCardIncome.Controls.Add(this.lblIncome);

            // CARD 3: EXPENSE
            this.pnlCardExpense.Location = new System.Drawing.Point(740, 80);
            this.pnlCardExpense.Size = new System.Drawing.Size(340, 140);
            this.pnlCardExpense.BackColor = System.Drawing.Color.Transparent;
            this.pnlCardExpense.Paint += new System.Windows.Forms.PaintEventHandler(this.Card_Paint);

            System.Windows.Forms.Panel accent3 = new System.Windows.Forms.Panel();
            accent3.Location = new System.Drawing.Point(0, 0);
            accent3.Width = 340;
            accent3.Height = 4;
            accent3.Tag = "Red";
            accent3.Paint += new System.Windows.Forms.PaintEventHandler(this.TopAccent_Paint);
            this.pnlCardExpense.Controls.Add(accent3);

            this.lblExpenseLabel.Location = new System.Drawing.Point(20, 25);
            this.lblExpenseLabel.AutoSize = true;
            this.lblExpenseLabel.Text = "Monthly Expense";
            this.lblExpenseLabel.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblExpenseLabel.ForeColor = System.Drawing.Color.Gray;

            this.lblExpense.Location = new System.Drawing.Point(20, 50);
            this.lblExpense.AutoSize = true;
            this.lblExpense.Text = "$4,821.50";
            this.lblExpense.Font = new System.Drawing.Font("Segoe UI", 24F, System.Drawing.FontStyle.Bold);
            this.lblExpense.ForeColor = System.Drawing.Color.FromArgb(20, 30, 60);

            this.pnlCardExpense.Controls.Add(this.lblExpenseLabel);
            this.pnlCardExpense.Controls.Add(this.lblExpense);

            // SPENDING TREND CHART PANEL
            this.pnlTrend.Location = new System.Drawing.Point(30, 240);
            this.pnlTrend.Size = new System.Drawing.Size(695, 270);
            this.pnlTrend.BackColor = System.Drawing.Color.Transparent;
            this.pnlTrend.Paint += new System.Windows.Forms.PaintEventHandler(this.Card_Paint);

            this.lblTrendTitle.Location = new System.Drawing.Point(20, 20);
            this.lblTrendTitle.AutoSize = true;
            this.lblTrendTitle.Text = "Spending Trend\nLast 30 days of financial activity";
            this.lblTrendTitle.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);

            this.chartTrend.Location = new System.Drawing.Point(20, 70);
            this.chartTrend.Size = new System.Drawing.Size(655, 180);

            this.pnlTrend.Controls.Add(this.lblTrendTitle);
            this.pnlTrend.Controls.Add(this.chartTrend);

            // BUDGET USAGE DONUT PANEL
            this.pnlUsage.Location = new System.Drawing.Point(740, 240);
            this.pnlUsage.Size = new System.Drawing.Size(340, 270);
            this.pnlUsage.BackColor = System.Drawing.Color.Transparent;
            this.pnlUsage.Paint += new System.Windows.Forms.PaintEventHandler(this.Card_Paint);

            this.lblUsageTitle.Location = new System.Drawing.Point(20, 20);
            this.lblUsageTitle.AutoSize = true;
            this.lblUsageTitle.Text = "Budget Usage\nMonthly allocation spent";
            this.lblUsageTitle.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);

            this.chartDonut.Location = new System.Drawing.Point(70, 70);
            this.chartDonut.Size = new System.Drawing.Size(200, 180);

            this.lblUsagePercent.Location = new System.Drawing.Point(120, 140);
            this.lblUsagePercent.AutoSize = true;
            this.lblUsagePercent.Text = "72%";
            this.lblUsagePercent.Font = new System.Drawing.Font("Segoe UI", 24F, System.Drawing.FontStyle.Bold);
            this.lblUsagePercent.BackColor = System.Drawing.Color.White;

            this.pnlUsage.Controls.Add(this.lblUsageTitle);
            this.pnlUsage.Controls.Add(this.lblUsagePercent);
            this.pnlUsage.Controls.Add(this.chartDonut);

            // RECENT TRANSACTIONS LIST
            this.pnlRecent.Location = new System.Drawing.Point(30, 530);
            this.pnlRecent.Size = new System.Drawing.Size(1050, 400);
            this.pnlRecent.BackColor = System.Drawing.Color.Transparent;
            this.pnlRecent.Paint += new System.Windows.Forms.PaintEventHandler(this.Card_Paint);

            this.lblRecentTitle.Location = new System.Drawing.Point(20, 20);
            this.lblRecentTitle.AutoSize = true;
            this.lblRecentTitle.Text = "Recent Transactions";
            this.lblRecentTitle.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);

            this.dgvTrans.Location = new System.Drawing.Point(20, 60);
            this.dgvTrans.Size = new System.Drawing.Size(1010, 320);
            this.dgvTrans.BackgroundColor = System.Drawing.Color.White;
            this.dgvTrans.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvTrans.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dgvTrans.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.dgvTrans.EnableHeadersVisualStyles = false;
            this.dgvTrans.RowHeadersVisible = false;
            this.dgvTrans.AllowUserToAddRows = false;
            this.dgvTrans.ReadOnly = true;
            
            cellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            cellStyle1.BackColor = System.Drawing.Color.FromArgb(248, 249, 252);
            cellStyle1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            cellStyle1.ForeColor = System.Drawing.Color.Gray;
            cellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            cellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            this.dgvTrans.ColumnHeadersDefaultCellStyle = cellStyle1;
            this.dgvTrans.ColumnHeadersHeight = 40;

            cellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            cellStyle2.BackColor = System.Drawing.Color.White;
            cellStyle2.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            cellStyle2.ForeColor = System.Drawing.Color.FromArgb(50, 50, 50);
            cellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(240, 245, 255);
            cellStyle2.SelectionForeColor = System.Drawing.Color.FromArgb(50, 50, 50);
            this.dgvTrans.DefaultCellStyle = cellStyle2;
            this.dgvTrans.RowTemplate.Height = 50;
            this.dgvTrans.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dgvTrans_CellFormatting);

            this.pnlRecent.Controls.Add(this.lblRecentTitle);
            this.pnlRecent.Controls.Add(this.dgvTrans);

            this.pnlMain.Controls.Add(this.pnlCardBalance);
            this.pnlMain.Controls.Add(this.pnlCardIncome);
            this.pnlMain.Controls.Add(this.pnlCardExpense);
            this.pnlMain.Controls.Add(this.pnlTrend);
            this.pnlMain.Controls.Add(this.pnlUsage);
            this.pnlMain.Controls.Add(this.pnlRecent);

            // BINDING
            this.Controls.Add(this.pnlMain);

            this.pnlMain.ResumeLayout(false);
            this.pnlCardBalance.ResumeLayout(false);
            this.pnlCardBalance.PerformLayout();
            this.pnlCardIncome.ResumeLayout(false);
            this.pnlCardIncome.PerformLayout();
            this.pnlCardExpense.ResumeLayout(false);
            this.pnlCardExpense.PerformLayout();
            this.pnlTrend.ResumeLayout(false);
            this.pnlTrend.PerformLayout();
            this.pnlUsage.ResumeLayout(false);
            this.pnlUsage.PerformLayout();
            this.pnlRecent.ResumeLayout(false);
            this.pnlRecent.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTrans)).EndInit();
            this.ResumeLayout(false);
        }

        private System.Windows.Forms.Panel pnlMain;

        private ReaLTaiizor.Controls.HopeTextBox txtSearch;
        private ReaLTaiizor.Controls.HopeButton btnAddTransaction;

        private System.Windows.Forms.Panel pnlCardBalance;
        private System.Windows.Forms.Label lblBalanceLabel;
        private System.Windows.Forms.Label lblBalance;
        
        private System.Windows.Forms.Panel pnlCardIncome;
        private System.Windows.Forms.Label lblIncomeLabel;
        private System.Windows.Forms.Label lblIncome;
        
        private System.Windows.Forms.Panel pnlCardExpense;
        private System.Windows.Forms.Label lblExpenseLabel;
        private System.Windows.Forms.Label lblExpense;

        private System.Windows.Forms.Panel pnlTrend;
        private System.Windows.Forms.Label lblTrendTitle;
        private LiveCharts.WinForms.CartesianChart chartTrend;

        private System.Windows.Forms.Panel pnlUsage;
        private System.Windows.Forms.Label lblUsageTitle;
        private System.Windows.Forms.Label lblUsagePercent;
        private LiveCharts.WinForms.PieChart chartDonut;

        private System.Windows.Forms.Panel pnlRecent;
        private System.Windows.Forms.Label lblRecentTitle;
        private System.Windows.Forms.DataGridView dgvTrans;
    }
}
