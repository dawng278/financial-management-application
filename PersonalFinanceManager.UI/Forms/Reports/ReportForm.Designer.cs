using System;
using System.Drawing;
using System.Windows.Forms;

namespace PersonalFinanceManager.Forms.Reports
{
    partial class ReportForm
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
            this.pnlFilter = new System.Windows.Forms.Panel();
            this.lblFilterStart = new System.Windows.Forms.Label();
            this.dtpStart = new ReaLTaiizor.Controls.PoisonDateTime();
            this.lblFilterEnd = new System.Windows.Forms.Label();
            this.dtpEnd = new ReaLTaiizor.Controls.PoisonDateTime();
            this.lblFilterCat = new System.Windows.Forms.Label();
            this.cboCategory = new ReaLTaiizor.Controls.HopeComboBox();
            this.lblFilterAcc = new System.Windows.Forms.Label();
            this.cboAccount = new ReaLTaiizor.Controls.HopeComboBox();
            this.btnApply = new ReaLTaiizor.Controls.HopeButton();
            this.pnlIncome = new System.Windows.Forms.Panel();
            this.pnlExpense = new System.Windows.Forms.Panel();
            this.pnlSavings = new System.Windows.Forms.Panel();
            this.pnlChart = new System.Windows.Forms.Panel();
            this.lblChartTitle = new System.Windows.Forms.Label();
            this.lblChartSub = new System.Windows.Forms.Label();
            this.pnlLedger = new System.Windows.Forms.Panel();
            this.lblLedgerTitle = new System.Windows.Forms.Label();
            this.btnExportExcel = new System.Windows.Forms.Button();
            this.btnExportPdf = new System.Windows.Forms.Button();
            this.dgvLedger = new System.Windows.Forms.DataGridView();
            this.lblPaginator = new System.Windows.Forms.Label();
            this.pnlScrollContext.SuspendLayout();
            this.pnlFilter.SuspendLayout();
            this.pnlChart.SuspendLayout();
            this.pnlLedger.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLedger)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlScrollContext
            // 
            this.pnlScrollContext.AutoScroll = true;
            this.pnlScrollContext.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(249)))), ((int)(((byte)(252)))));
            this.pnlScrollContext.Controls.Add(this.lblPageTitle);
            this.pnlScrollContext.Controls.Add(this.lblPageSub);
            this.pnlScrollContext.Controls.Add(this.pnlFilter);
            this.pnlScrollContext.Controls.Add(this.pnlIncome);
            this.pnlScrollContext.Controls.Add(this.pnlExpense);
            this.pnlScrollContext.Controls.Add(this.pnlSavings);
            this.pnlScrollContext.Controls.Add(this.pnlChart);
            this.pnlScrollContext.Controls.Add(this.pnlLedger);
            this.pnlScrollContext.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlScrollContext.Location = new System.Drawing.Point(0, 0);
            this.pnlScrollContext.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.pnlScrollContext.Name = "pnlScrollContext";
            this.pnlScrollContext.Size = new System.Drawing.Size(832, 572);
            this.pnlScrollContext.TabIndex = 0;
            // 
            // lblPageTitle
            // 
            this.lblPageTitle.AutoSize = true;
            this.lblPageTitle.Font = new System.Drawing.Font("Segoe UI", 20F, System.Drawing.FontStyle.Bold);
            this.lblPageTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(28)))), ((int)(((byte)(29)))));
            this.lblPageTitle.Location = new System.Drawing.Point(22, 16);
            this.lblPageTitle.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblPageTitle.Name = "lblPageTitle";
            this.lblPageTitle.Size = new System.Drawing.Size(347, 37);
            this.lblPageTitle.TabIndex = 0;
            this.lblPageTitle.Text = "Financial Report Designer";
            // 
            // lblPageSub
            // 
            this.lblPageSub.AutoSize = true;
            this.lblPageSub.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.lblPageSub.ForeColor = System.Drawing.Color.Gray;
            this.lblPageSub.Location = new System.Drawing.Point(22, 53);
            this.lblPageSub.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblPageSub.Name = "lblPageSub";
            this.lblPageSub.Size = new System.Drawing.Size(694, 17);
            this.lblPageSub.TabIndex = 1;
            this.lblPageSub.Text = "Configure your fiscal summary using high-precision filters and multi-dimensional " +
    "analytics. Data refreshes in real-time.";
            // 
            // pnlFilter
            // 
            this.pnlFilter.BackColor = System.Drawing.Color.Transparent;
            this.pnlFilter.Controls.Add(this.lblFilterStart);
            this.pnlFilter.Controls.Add(this.dtpStart);
            this.pnlFilter.Controls.Add(this.lblFilterEnd);
            this.pnlFilter.Controls.Add(this.dtpEnd);
            this.pnlFilter.Controls.Add(this.lblFilterCat);
            this.pnlFilter.Controls.Add(this.cboCategory);
            this.pnlFilter.Controls.Add(this.lblFilterAcc);
            this.pnlFilter.Controls.Add(this.cboAccount);
            this.pnlFilter.Controls.Add(this.btnApply);
            this.pnlFilter.Location = new System.Drawing.Point(22, 89);
            this.pnlFilter.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.pnlFilter.Name = "pnlFilter";
            this.pnlFilter.Size = new System.Drawing.Size(788, 81);
            this.pnlFilter.TabIndex = 2;
            this.pnlFilter.Paint += new System.Windows.Forms.PaintEventHandler(this.pnlFilter_Paint);
            // 
            // lblFilterStart
            // 
            this.lblFilterStart.AutoSize = true;
            this.lblFilterStart.Font = new System.Drawing.Font("Segoe UI", 8F);
            this.lblFilterStart.ForeColor = System.Drawing.Color.Gray;
            this.lblFilterStart.Location = new System.Drawing.Point(15, 12);
            this.lblFilterStart.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblFilterStart.Name = "lblFilterStart";
            this.lblFilterStart.Size = new System.Drawing.Size(69, 13);
            this.lblFilterStart.TabIndex = 0;
            this.lblFilterStart.Text = "START DATE";
            // 
            // dtpStart
            // 
            this.dtpStart.CustomFormat = "dd MMM yyyy";
            this.dtpStart.FontSize = ReaLTaiizor.Extension.Poison.PoisonDateTimeSize.Medium;
            this.dtpStart.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpStart.Location = new System.Drawing.Point(15, 32);
            this.dtpStart.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.dtpStart.MinimumSize = new System.Drawing.Size(0, 29);
            this.dtpStart.Name = "dtpStart";
            this.dtpStart.Size = new System.Drawing.Size(151, 29);
            this.dtpStart.TabIndex = 1;
            // 
            // lblFilterEnd
            // 
            this.lblFilterEnd.AutoSize = true;
            this.lblFilterEnd.Font = new System.Drawing.Font("Segoe UI", 8F);
            this.lblFilterEnd.ForeColor = System.Drawing.Color.Gray;
            this.lblFilterEnd.Location = new System.Drawing.Point(180, 12);
            this.lblFilterEnd.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblFilterEnd.Name = "lblFilterEnd";
            this.lblFilterEnd.Size = new System.Drawing.Size(60, 13);
            this.lblFilterEnd.TabIndex = 2;
            this.lblFilterEnd.Text = "END DATE";
            // 
            // dtpEnd
            // 
            this.dtpEnd.CustomFormat = "dd MMM yyyy";
            this.dtpEnd.FontSize = ReaLTaiizor.Extension.Poison.PoisonDateTimeSize.Medium;
            this.dtpEnd.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpEnd.Location = new System.Drawing.Point(180, 32);
            this.dtpEnd.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.dtpEnd.MinimumSize = new System.Drawing.Size(0, 29);
            this.dtpEnd.Name = "dtpEnd";
            this.dtpEnd.Size = new System.Drawing.Size(151, 29);
            this.dtpEnd.TabIndex = 3;
            // 
            // lblFilterCat
            // 
            this.lblFilterCat.AutoSize = true;
            this.lblFilterCat.Font = new System.Drawing.Font("Segoe UI", 8F);
            this.lblFilterCat.ForeColor = System.Drawing.Color.Gray;
            this.lblFilterCat.Location = new System.Drawing.Point(345, 12);
            this.lblFilterCat.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblFilterCat.Name = "lblFilterCat";
            this.lblFilterCat.Size = new System.Drawing.Size(63, 13);
            this.lblFilterCat.TabIndex = 4;
            this.lblFilterCat.Text = "CATEGORY";
            // 
            // cboCategory
            // 
            this.cboCategory.Cursor = System.Windows.Forms.Cursors.Hand;
            this.cboCategory.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cboCategory.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cboCategory.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.cboCategory.ItemHeight = 30;
            this.cboCategory.Items.AddRange(new object[] {
            "All Categories"});
            this.cboCategory.Location = new System.Drawing.Point(345, 32);
            this.cboCategory.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.cboCategory.Name = "cboCategory";
            this.cboCategory.Size = new System.Drawing.Size(151, 36);
            this.cboCategory.TabIndex = 5;
            // 
            // lblFilterAcc
            // 
            this.lblFilterAcc.AutoSize = true;
            this.lblFilterAcc.Font = new System.Drawing.Font("Segoe UI", 8F);
            this.lblFilterAcc.ForeColor = System.Drawing.Color.Gray;
            this.lblFilterAcc.Location = new System.Drawing.Point(510, 12);
            this.lblFilterAcc.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblFilterAcc.Name = "lblFilterAcc";
            this.lblFilterAcc.Size = new System.Drawing.Size(60, 13);
            this.lblFilterAcc.TabIndex = 6;
            this.lblFilterAcc.Text = "ACCOUNT";
            // 
            // cboAccount
            // 
            this.cboAccount.Cursor = System.Windows.Forms.Cursors.Hand;
            this.cboAccount.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cboAccount.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cboAccount.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.cboAccount.ItemHeight = 30;
            this.cboAccount.Items.AddRange(new object[] {
            "Corporate Alpha"});
            this.cboAccount.Location = new System.Drawing.Point(510, 32);
            this.cboAccount.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.cboAccount.Name = "cboAccount";
            this.cboAccount.Size = new System.Drawing.Size(151, 36);
            this.cboAccount.TabIndex = 7;
            // 
            // btnApply
            // 
            this.btnApply.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(223)))), ((int)(((byte)(230)))));
            this.btnApply.ButtonType = ReaLTaiizor.Util.HopeButtonType.Primary;
            this.btnApply.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnApply.DangerColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(108)))), ((int)(((byte)(108)))));
            this.btnApply.DefaultColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.btnApply.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.btnApply.ForeColor = System.Drawing.Color.White;
            this.btnApply.HoverTextColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(49)))), ((int)(((byte)(51)))));
            this.btnApply.InfoColor = System.Drawing.Color.FromArgb(((int)(((byte)(144)))), ((int)(((byte)(147)))), ((int)(((byte)(153)))));
            this.btnApply.Location = new System.Drawing.Point(675, 32);
            this.btnApply.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnApply.Name = "btnApply";
            this.btnApply.PrimaryColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(85)))), ((int)(((byte)(95)))));
            this.btnApply.Size = new System.Drawing.Size(98, 29);
            this.btnApply.SuccessColor = System.Drawing.Color.FromArgb(((int)(((byte)(103)))), ((int)(((byte)(194)))), ((int)(((byte)(58)))));
            this.btnApply.TabIndex = 8;
            this.btnApply.Text = "▼ Apply";
            this.btnApply.TextColor = System.Drawing.Color.White;
            this.btnApply.WarningColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(162)))), ((int)(((byte)(60)))));
            // 
            // pnlIncome
            // 
            this.pnlIncome.BackColor = System.Drawing.Color.Transparent;
            this.pnlIncome.Location = new System.Drawing.Point(22, 187);
            this.pnlIncome.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.pnlIncome.Name = "pnlIncome";
            this.pnlIncome.Size = new System.Drawing.Size(248, 100);
            this.pnlIncome.TabIndex = 3;
            this.pnlIncome.Paint += new System.Windows.Forms.PaintEventHandler(this.pnlIncome_Paint);
            // 
            // pnlExpense
            // 
            this.pnlExpense.BackColor = System.Drawing.Color.Transparent;
            this.pnlExpense.Location = new System.Drawing.Point(292, 187);
            this.pnlExpense.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.pnlExpense.Name = "pnlExpense";
            this.pnlExpense.Size = new System.Drawing.Size(248, 100);
            this.pnlExpense.TabIndex = 4;
            this.pnlExpense.Paint += new System.Windows.Forms.PaintEventHandler(this.pnlExpense_Paint);
            // 
            // pnlSavings
            // 
            this.pnlSavings.BackColor = System.Drawing.Color.Transparent;
            this.pnlSavings.Location = new System.Drawing.Point(562, 187);
            this.pnlSavings.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.pnlSavings.Name = "pnlSavings";
            this.pnlSavings.Size = new System.Drawing.Size(248, 100);
            this.pnlSavings.TabIndex = 5;
            this.pnlSavings.Paint += new System.Windows.Forms.PaintEventHandler(this.pnlSavings_Paint);
            // 
            // pnlChart
            // 
            this.pnlChart.BackColor = System.Drawing.Color.Transparent;
            this.pnlChart.Controls.Add(this.lblChartTitle);
            this.pnlChart.Controls.Add(this.lblChartSub);
            this.pnlChart.Location = new System.Drawing.Point(22, 310);
            this.pnlChart.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.pnlChart.Name = "pnlChart";
            this.pnlChart.Size = new System.Drawing.Size(788, 211);
            this.pnlChart.TabIndex = 6;
            this.pnlChart.Paint += new System.Windows.Forms.PaintEventHandler(this.pnlChart_Paint);
            // 
            // lblChartTitle
            // 
            this.lblChartTitle.AutoSize = true;
            this.lblChartTitle.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lblChartTitle.Location = new System.Drawing.Point(15, 16);
            this.lblChartTitle.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblChartTitle.Name = "lblChartTitle";
            this.lblChartTitle.Size = new System.Drawing.Size(118, 21);
            this.lblChartTitle.TabIndex = 0;
            this.lblChartTitle.Text = "Fiscal Velocity";
            // 
            // lblChartSub
            // 
            this.lblChartSub.AutoSize = true;
            this.lblChartSub.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblChartSub.ForeColor = System.Drawing.Color.Gray;
            this.lblChartSub.Location = new System.Drawing.Point(15, 37);
            this.lblChartSub.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblChartSub.Name = "lblChartSub";
            this.lblChartSub.Size = new System.Drawing.Size(220, 15);
            this.lblChartSub.TabIndex = 1;
            this.lblChartSub.Text = "Monthly Income vs Expense comparison";
            // 
            // pnlLedger
            // 
            this.pnlLedger.BackColor = System.Drawing.Color.White;
            this.pnlLedger.Controls.Add(this.lblLedgerTitle);
            this.pnlLedger.Controls.Add(this.btnExportExcel);
            this.pnlLedger.Controls.Add(this.btnExportPdf);
            this.pnlLedger.Controls.Add(this.dgvLedger);
            this.pnlLedger.Controls.Add(this.lblPaginator);
            this.pnlLedger.Location = new System.Drawing.Point(22, 540);
            this.pnlLedger.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.pnlLedger.Name = "pnlLedger";
            this.pnlLedger.Size = new System.Drawing.Size(788, 244);
            this.pnlLedger.TabIndex = 7;
            this.pnlLedger.Paint += new System.Windows.Forms.PaintEventHandler(this.pnlLedger_Paint);
            // 
            // lblLedgerTitle
            // 
            this.lblLedgerTitle.AutoSize = true;
            this.lblLedgerTitle.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lblLedgerTitle.Location = new System.Drawing.Point(15, 16);
            this.lblLedgerTitle.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblLedgerTitle.Name = "lblLedgerTitle";
            this.lblLedgerTitle.Size = new System.Drawing.Size(154, 21);
            this.lblLedgerTitle.TabIndex = 0;
            this.lblLedgerTitle.Text = "Transaction Ledger";
            // 
            // btnExportExcel
            // 
            this.btnExportExcel.BackColor = System.Drawing.Color.White;
            this.btnExportExcel.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(230)))), ((int)(((byte)(200)))));
            this.btnExportExcel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExportExcel.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnExportExcel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(110)))), ((int)(((byte)(40)))));
            this.btnExportExcel.Location = new System.Drawing.Point(615, 12);
            this.btnExportExcel.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnExportExcel.Name = "btnExportExcel";
            this.btnExportExcel.Size = new System.Drawing.Size(75, 24);
            this.btnExportExcel.TabIndex = 1;
            this.btnExportExcel.Text = "Excel";
            this.btnExportExcel.UseVisualStyleBackColor = false;
            // 
            // btnExportPdf
            // 
            this.btnExportPdf.BackColor = System.Drawing.Color.White;
            this.btnExportPdf.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(200)))), ((int)(((byte)(200)))));
            this.btnExportPdf.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExportPdf.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnExportPdf.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(183)))), ((int)(((byte)(30)))), ((int)(((byte)(80)))));
            this.btnExportPdf.Location = new System.Drawing.Point(698, 12);
            this.btnExportPdf.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnExportPdf.Name = "btnExportPdf";
            this.btnExportPdf.Size = new System.Drawing.Size(75, 24);
            this.btnExportPdf.TabIndex = 2;
            this.btnExportPdf.Text = "PDF";
            this.btnExportPdf.UseVisualStyleBackColor = false;
            // 
            // dgvLedger
            // 
            this.dgvLedger.AllowUserToAddRows = false;
            this.dgvLedger.AllowUserToDeleteRows = false;
            this.dgvLedger.BackgroundColor = System.Drawing.Color.White;
            this.dgvLedger.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvLedger.Location = new System.Drawing.Point(15, 49);
            this.dgvLedger.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.dgvLedger.Name = "dgvLedger";
            this.dgvLedger.ReadOnly = true;
            this.dgvLedger.RowHeadersVisible = false;
            this.dgvLedger.Size = new System.Drawing.Size(758, 162);
            this.dgvLedger.TabIndex = 3;
            // 
            // lblPaginator
            // 
            this.lblPaginator.AutoSize = true;
            this.lblPaginator.Font = new System.Drawing.Font("Segoe UI", 8F);
            this.lblPaginator.ForeColor = System.Drawing.Color.Gray;
            this.lblPaginator.Location = new System.Drawing.Point(15, 219);
            this.lblPaginator.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblPaginator.Name = "lblPaginator";
            this.lblPaginator.Size = new System.Drawing.Size(286, 13);
            this.lblPaginator.TabIndex = 4;
            this.lblPaginator.Text = "Showing 5 of 142 entries                           <   1   2   3   >";
            // 
            // ReportForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(249)))), ((int)(((byte)(250)))));
            this.ClientSize = new System.Drawing.Size(832, 572);
            this.Controls.Add(this.pnlScrollContext);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "ReportForm";
            this.pnlScrollContext.ResumeLayout(false);
            this.pnlScrollContext.PerformLayout();
            this.pnlFilter.ResumeLayout(false);
            this.pnlFilter.PerformLayout();
            this.pnlChart.ResumeLayout(false);
            this.pnlChart.PerformLayout();
            this.pnlLedger.ResumeLayout(false);
            this.pnlLedger.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLedger)).EndInit();
            this.ResumeLayout(false);

        }

        private System.Windows.Forms.Panel pnlScrollContext;
        private System.Windows.Forms.Label lblPageTitle;
        private System.Windows.Forms.Label lblPageSub;
        
        private System.Windows.Forms.Panel pnlFilter;
        private ReaLTaiizor.Controls.PoisonDateTime dtpStart;
        private ReaLTaiizor.Controls.PoisonDateTime dtpEnd;
        private ReaLTaiizor.Controls.HopeComboBox cboCategory;
        private ReaLTaiizor.Controls.HopeComboBox cboAccount;
        private ReaLTaiizor.Controls.HopeButton btnApply;
        private System.Windows.Forms.Label lblFilterStart;
        private System.Windows.Forms.Label lblFilterEnd;
        private System.Windows.Forms.Label lblFilterCat;
        private System.Windows.Forms.Label lblFilterAcc;

        private System.Windows.Forms.Panel pnlIncome;
        private System.Windows.Forms.Panel pnlExpense;
        private System.Windows.Forms.Panel pnlSavings;

        private System.Windows.Forms.Panel pnlChart;
        private System.Windows.Forms.Label lblChartTitle;
        private System.Windows.Forms.Label lblChartSub;

        private System.Windows.Forms.Panel pnlLedger;
        private System.Windows.Forms.Label lblLedgerTitle;
        private System.Windows.Forms.Button btnExportExcel;
        private System.Windows.Forms.Button btnExportPdf;
        private System.Windows.Forms.DataGridView dgvLedger;
        private System.Windows.Forms.Label lblPaginator;
    }
}
