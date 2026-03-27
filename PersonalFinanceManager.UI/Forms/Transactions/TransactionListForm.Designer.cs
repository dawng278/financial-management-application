using System.Drawing;
using System.Windows.Forms;

namespace PersonalFinanceManager.Forms.Transactions
{
    partial class TransactionListForm
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
            
            this.pnlFilter = new System.Windows.Forms.Panel();
            this.txtSearch = new ReaLTaiizor.Controls.HopeTextBox();
            this.cbCategory = new ReaLTaiizor.Controls.HopeComboBox();
            this.btnFilter = new ReaLTaiizor.Controls.HopeButton();

            this.pnlGrid = new System.Windows.Forms.Panel();
            this.dgvTransactions = new System.Windows.Forms.DataGridView();

            this.pnlLiquidity = new System.Windows.Forms.Panel();
            this.lblNetTitle = new System.Windows.Forms.Label();
            this.lblNetValue = new System.Windows.Forms.Label();
            this.lblNetTrend = new System.Windows.Forms.Label();

            this.pnlPagination = new System.Windows.Forms.Panel();
            this.btnFloatingAdd = new ReaLTaiizor.Controls.HopeButton();

            this.pnlMain.SuspendLayout();
            this.pnlFilter.SuspendLayout();
            this.pnlGrid.SuspendLayout();
            this.pnlLiquidity.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTransactions)).BeginInit();
            this.SuspendLayout();

            // 
            // TransactionListForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(248, 249, 252);
            this.ClientSize = new System.Drawing.Size(1110, 704);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;

            // pnlMain
            this.pnlMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlMain.BackColor = System.Drawing.Color.FromArgb(248, 249, 252);
            this.pnlMain.Padding = new System.Windows.Forms.Padding(30, 20, 30, 20);

            // Filter Panel
            this.pnlFilter.Location = new System.Drawing.Point(30, 20);
            this.pnlFilter.Size = new System.Drawing.Size(1050, 60);
            this.pnlFilter.BackColor = System.Drawing.Color.Transparent;

            this.txtSearch.Location = new System.Drawing.Point(0, 10);
            this.txtSearch.Size = new System.Drawing.Size(460, 40);
            this.txtSearch.Text = "Search transactions, tags or accounts...";

            this.cbCategory.Location = new System.Drawing.Point(830, 10);
            this.cbCategory.Size = new System.Drawing.Size(160, 40);

            this.btnFilter.Location = new System.Drawing.Point(994, 10);
            this.btnFilter.Size = new System.Drawing.Size(46, 38);
            this.btnFilter.PrimaryColor = System.Drawing.Color.FromArgb(55, 75, 85);
            this.btnFilter.Text = "⚙";

            this.pnlFilter.Controls.Add(this.txtSearch);
            this.pnlFilter.Controls.Add(this.cbCategory);
            this.pnlFilter.Controls.Add(this.btnFilter);

            // Grid Panel
            this.pnlGrid.Location = new System.Drawing.Point(30, 90);
            this.pnlGrid.Size = new System.Drawing.Size(1050, 420);
            this.pnlGrid.BackColor = System.Drawing.Color.White;

            this.dgvTransactions.Location = new System.Drawing.Point(0, 0);
            this.dgvTransactions.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvTransactions.BackgroundColor = System.Drawing.Color.White;
            this.dgvTransactions.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvTransactions.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dgvTransactions.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.dgvTransactions.EnableHeadersVisualStyles = false;
            this.dgvTransactions.RowHeadersVisible = false;
            this.dgvTransactions.AllowUserToAddRows = false;
            this.dgvTransactions.ReadOnly = true;
            this.dgvTransactions.GridColor = System.Drawing.Color.FromArgb(240, 240, 240);
            
            cellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            cellStyle1.BackColor = System.Drawing.Color.FromArgb(55, 75, 85);
            cellStyle1.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            cellStyle1.ForeColor = System.Drawing.Color.White;
            cellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(55, 75, 85);
            cellStyle1.SelectionForeColor = System.Drawing.Color.White;
            this.dgvTransactions.ColumnHeadersDefaultCellStyle = cellStyle1;
            this.dgvTransactions.ColumnHeadersHeight = 50;
            this.dgvTransactions.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;

            cellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            cellStyle2.BackColor = System.Drawing.Color.White;
            cellStyle2.Font = new System.Drawing.Font("Segoe UI", 10F);
            cellStyle2.ForeColor = System.Drawing.Color.FromArgb(80, 80, 80);
            cellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(248, 249, 252);
            cellStyle2.SelectionForeColor = System.Drawing.Color.FromArgb(80, 80, 80);
            this.dgvTransactions.DefaultCellStyle = cellStyle2;
            this.dgvTransactions.RowTemplate.Height = 60;
            this.dgvTransactions.CellPainting += new System.Windows.Forms.DataGridViewCellPaintingEventHandler(this.dgvTransactions_CellPainting);
            this.pnlGrid.Controls.Add(this.dgvTransactions);

            // Pagination Panel
            this.pnlPagination.Location = new System.Drawing.Point(30, 530);
            this.pnlPagination.Size = new System.Drawing.Size(300, 40);
            this.pnlPagination.BackColor = System.Drawing.Color.Transparent;
            this.pnlPagination.Paint += new System.Windows.Forms.PaintEventHandler(this.pnlPagination_Paint);

            // Liquidity Card
            this.pnlLiquidity.Location = new System.Drawing.Point(740, 470);
            this.pnlLiquidity.Size = new System.Drawing.Size(340, 140);
            this.pnlLiquidity.BackColor = System.Drawing.Color.Transparent;
            this.pnlLiquidity.Paint += new System.Windows.Forms.PaintEventHandler(this.pnlLiquidity_Paint);

            this.lblNetTitle.Text = "TOTAL NET LIQUIDITY";
            this.lblNetTitle.ForeColor = System.Drawing.Color.LightGray;
            this.lblNetTitle.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.lblNetTitle.Location = new System.Drawing.Point(0, 25);
            this.lblNetTitle.AutoSize = false;
            this.lblNetTitle.Size = new System.Drawing.Size(340, 25);
            this.lblNetTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;

            this.lblNetValue.Text = "$242,509.80";
            this.lblNetValue.ForeColor = System.Drawing.Color.White;
            this.lblNetValue.Font = new System.Drawing.Font("Segoe UI", 26F, System.Drawing.FontStyle.Bold);
            this.lblNetValue.Location = new System.Drawing.Point(0, 50);
            this.lblNetValue.AutoSize = false;
            this.lblNetValue.Size = new System.Drawing.Size(340, 50);
            this.lblNetValue.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;

            this.lblNetTrend.Text = "↗ +2.4% from last month";
            this.lblNetTrend.ForeColor = System.Drawing.Color.FromArgb(170, 220, 200);
            this.lblNetTrend.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.lblNetTrend.Location = new System.Drawing.Point(0, 100);
            this.lblNetTrend.AutoSize = false;
            this.lblNetTrend.Size = new System.Drawing.Size(340, 25);
            this.lblNetTrend.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;

            this.pnlLiquidity.Controls.Add(this.lblNetTitle);
            this.pnlLiquidity.Controls.Add(this.lblNetValue);
            this.pnlLiquidity.Controls.Add(this.lblNetTrend);

            // Floating Add Button
            this.btnFloatingAdd.Location = new System.Drawing.Point(1000, 620);
            this.btnFloatingAdd.Size = new System.Drawing.Size(60, 60);
            this.btnFloatingAdd.PrimaryColor = System.Drawing.Color.FromArgb(183, 0, 82);
            this.btnFloatingAdd.Text = "+";
            this.btnFloatingAdd.Font = new System.Drawing.Font("Segoe UI", 20F, System.Drawing.FontStyle.Regular);
            this.btnFloatingAdd.Click += new System.EventHandler(this.BtnFloatingAdd_Click);

            this.pnlMain.Controls.Add(this.btnFloatingAdd);
            this.pnlMain.Controls.Add(this.pnlLiquidity);
            this.pnlMain.Controls.Add(this.pnlPagination);
            this.pnlMain.Controls.Add(this.pnlFilter);
            this.pnlMain.Controls.Add(this.pnlGrid);

            this.Controls.Add(this.pnlMain);

            this.pnlMain.ResumeLayout(false);
            this.pnlFilter.ResumeLayout(false);
            this.pnlGrid.ResumeLayout(false);
            this.pnlLiquidity.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvTransactions)).EndInit();
            this.ResumeLayout(false);
        }

        private System.Windows.Forms.Panel pnlMain;
        private System.Windows.Forms.Panel pnlFilter;
        private ReaLTaiizor.Controls.HopeTextBox txtSearch;
        private ReaLTaiizor.Controls.HopeComboBox cbCategory;
        private ReaLTaiizor.Controls.HopeButton btnFilter;
        private System.Windows.Forms.Panel pnlGrid;
        private System.Windows.Forms.DataGridView dgvTransactions;
        private System.Windows.Forms.Panel pnlLiquidity;
        private System.Windows.Forms.Label lblNetTitle;
        private System.Windows.Forms.Label lblNetValue;
        private System.Windows.Forms.Label lblNetTrend;
        private System.Windows.Forms.Panel pnlPagination;
        private ReaLTaiizor.Controls.HopeButton btnFloatingAdd;
    }
}
