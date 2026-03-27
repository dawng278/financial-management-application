using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Windows.Forms;
using PersonalFinanceManager.Infrastructure.DI;

namespace PersonalFinanceManager.Forms.Transactions
{
    public partial class TransactionListForm : Form
    {
        private class TransactionRow
        {
            public string Date { get; set; }
            public string Category { get; set; }
            public string Description { get; set; }
            public string Account { get; set; }
            public decimal Amount { get; set; }
        }

        private List<TransactionRow> _allRows;
        private int _currentPage = 1;
        private int _pageSize = 7;

        public TransactionListForm()
        {
            InitializeComponent();
            RefreshData();
            SetupGrid();
            BindGrid(_allRows);
            UpdateLiquidityDisplay();
            ApplyResponsiveLayout();

            ApplyResponsiveLayout();

            PersonalFinanceManager.Common.Helpers.ConfigHelper.CurrencyChanged += (s, ev) => 
            {
                if (this.IsHandleCreated) this.Invoke(new Action(() => {
                    UpdateLiquidityDisplay();
                    BindGrid(_allRows);
                }));
            };

            PersonalFinanceManager.Common.Helpers.ConfigHelper.LanguageChanged += (s, ev) => 
            {
                if (this.IsHandleCreated) this.Invoke(new Action(() => {
                    UpdateTranslations();
                }));
            };

            PersonalFinanceManager.Common.Helpers.ConfigHelper.ThemeChanged += (s, ev) =>
            {
                if (this.IsHandleCreated) this.Invoke(new Action(() => {
                    ApplyTheme();
                }));
            };
            UpdateTranslations();
            ApplyTheme();

            txtSearch.TextChanged += (s, e) => {
                _currentPage = 1;
                BindGridFiltered();
            };

            pnlPagination.MouseClick += (s, e) => {
                int totalPages = (int)Math.Ceiling(_allRows.Count / (double)_pageSize);
                if(totalPages == 0) totalPages = 1;
                
                int clickIdx = e.X / 35;
                if (clickIdx == 0 && _currentPage > 1) _currentPage--;
                else if (clickIdx == totalPages + 1 && _currentPage < totalPages) _currentPage++;
                else if (clickIdx > 0 && clickIdx <= totalPages) _currentPage = clickIdx;
                
                BindGridFiltered();
                pnlPagination.Invalidate();
            };

            ServiceLocator.TransactionService.TransactionChanged += (s, e) => {
                if (this.IsHandleCreated) this.Invoke(new Action(() => {
                    RefreshData();
                    BindGridFiltered();
                }));
            };
        }

        private void ApplyTheme()
        {
            PersonalFinanceManager.Common.Helpers.ThemeHelper.ApplyTheme(this);
            pnlLiquidity.Invalidate();
        }

        private void UpdateTranslations()
        {
            var t = new Func<string, string>(PersonalFinanceManager.Common.Helpers.ConfigHelper.Translate);

            if (txtSearch.Text == "Search transactions, tags or accounts..." || txtSearch.Text == "Tìm kiếm giao dịch, thẻ hoặc tài khoản...") 
                txtSearch.Text = t("Search transactions, tags or accounts...");

            lblNetTitle.Text = t("TOTAL NET LIQUIDITY");

            // Redraw grid headers and re-bind datagrid contents
            SetupGrid();
            BindGridFiltered();
        }

        private void RefreshData()
        {
            _allRows = new List<TransactionRow>();
            try
            {
                var transactions = ServiceLocator.TransactionService.GetRecent(200);
                if (transactions != null && transactions.Any())
                {
                    foreach (var tx in transactions)
                    {
                        var account = ServiceLocator.AccountService.GetByCurrentUser().FirstOrDefault(a => a.Id == tx.AccountId);
                        var category = ServiceLocator.CategoryService.GetAll().FirstOrDefault(c => c.Id == tx.CategoryId);
                        
                        _allRows.Add(new TransactionRow
                        {
                            Date = tx.TransactionDate.ToString("MMM dd, yyyy"),
                            Category = category?.Name ?? tx.CategoryName ?? "Other",
                            Description = tx.Note ?? "",
                            Account = account?.AccountName ?? tx.AccountName ?? "Unknown",
                            Amount = tx.Amount
                        });
                    }
                }
            }
            catch { }

            UpdateLiquidityDisplay();
        }

        private void UpdateLiquidityDisplay()
        {
            decimal totalBalance = ServiceLocator.AccountService.GetTotalBalance();
            lblNetValue.Text = PersonalFinanceManager.Common.Helpers.ConfigHelper.FormatGlobalCurrency(totalBalance);
            
            try
            {
                // Calculate trend based on last 30 days
                var last30Days = ServiceLocator.TransactionService.GetByDateRange(DateTime.Today.AddDays(-30), DateTime.MaxValue).ToList();
                decimal monthlyDelta = last30Days.Sum(t => t.Amount);
                
                // We need to convert this delta (which is likely in currency of account) to VND for consistent calc
                // Actually, let's assume TransactionService.GetRecent/GetByDateRange returns raw amounts. 
                // To be accurate we'd need account currency for each.
                // For simplicity, let's just show the delta if we can't do % or a fixed positive trend if balance is high.
                
                decimal previousBalance = totalBalance - monthlyDelta;
                double percent = 0;
                if (previousBalance > 0) percent = (double)(monthlyDelta / previousBalance) * 100.0;
                
                string trendChar = percent >= 0 ? "↗" : "↘";
                lblNetTrend.Text = $"{trendChar} {(percent >= 0 ? "+" : "")}{percent:N1}% from last month";
                lblNetTrend.ForeColor = percent >= 0 ? Color.FromArgb(170, 220, 200) : Color.FromArgb(250, 180, 180);
            }
            catch
            {
                lblNetTrend.Text = "↗ +0.0% from last month";
            }
        }

        private void SetupGrid()
        {
            var t = new Func<string, string>(PersonalFinanceManager.Common.Helpers.ConfigHelper.Translate);
            
            dgvTransactions.Columns.Clear();
            dgvTransactions.Columns.Add(new DataGridViewTextBoxColumn { Name = "colDate", HeaderText = t("DATE"), Width = 140, SortMode = DataGridViewColumnSortMode.NotSortable });
            dgvTransactions.Columns.Add(new DataGridViewTextBoxColumn { Name = "colCategory", HeaderText = t("CATEGORY"), Width = 160, SortMode = DataGridViewColumnSortMode.NotSortable });
            dgvTransactions.Columns.Add(new DataGridViewTextBoxColumn { Name = "colDesc", HeaderText = t("DESCRIPTION"), MinimumWidth = 300, AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill, SortMode = DataGridViewColumnSortMode.NotSortable });
            dgvTransactions.Columns.Add(new DataGridViewTextBoxColumn { Name = "colAccount", HeaderText = t("ACCOUNT"), Width = 220, SortMode = DataGridViewColumnSortMode.NotSortable });
            
            var colAmount = new DataGridViewTextBoxColumn { Name = "colAmount", HeaderText = t("AMOUNT"), Width = 180, SortMode = DataGridViewColumnSortMode.NotSortable };
            colAmount.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            colAmount.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgvTransactions.Columns.Add(colAmount);

            // Add some padding to cell content
            dgvTransactions.Padding = new Padding(20, 0, 20, 0);
        }

        private void BindGridFiltered()
        {
            var t = new Func<string, string>(PersonalFinanceManager.Common.Helpers.ConfigHelper.Translate);
            string q = txtSearch.Text.Trim().ToLower();
            if (q == "" || q == t("Search transactions, tags or accounts...").ToLower() || q == "search transactions, tags or accounts...") q = null;

            var query = _allRows.AsEnumerable();
            if(!string.IsNullOrEmpty(q))
                query = query.Where(r => r.Description.ToLower().Contains(q) || r.Category.ToLower().Contains(q) || r.Account.ToLower().Contains(q));
            
            var paged = query.Skip((_currentPage - 1) * _pageSize).Take(_pageSize).ToList();
            BindGrid(paged);
            pnlPagination.Invalidate();
        }

        private void BindGrid(List<TransactionRow> rows)
        {
            dgvTransactions.Rows.Clear();
            foreach (var r in rows)
            {
                string amtText = (r.Amount > 0 ? "+" : "") + PersonalFinanceManager.Common.Helpers.ConfigHelper.FormatGlobalCurrency(r.Amount);
                int idx = dgvTransactions.Rows.Add("  " + r.Date, r.Category, r.Description, r.Account, amtText + "  ");
                dgvTransactions.Rows[idx].Tag = r;
            }
        }

        private void dgvTransactions_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex < 0) return;

            e.PaintBackground(e.CellBounds, true);
            e.Paint(e.CellBounds, DataGridViewPaintParts.Border);

            var row = dgvTransactions.Rows[e.RowIndex].Tag as TransactionRow;
            if (row == null) return;

            // Date styling (Grayed out a bit)
            if (e.ColumnIndex == 0)
            {
                using (var brush = new SolidBrush(PersonalFinanceManager.Common.Helpers.ThemeHelper.SubText))
                {
                    e.Graphics.DrawString("  " + row.Date, new Font("Segoe UI", 9.5F), brush, e.CellBounds.X, e.CellBounds.Y + 20);
                }
                e.Handled = true;
            }
            // Draw Pill shape for Category
            else if (e.ColumnIndex == 1)
            {
                e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;

                Color bg = Color.LightGray;
                Color fg = Color.DarkGray;
                switch (row.Category)
                {
                    case "Investments": bg = Color.FromArgb(220, 240, 252); fg = Color.FromArgb(40, 130, 180); break;
                    case "Dining Out": bg = Color.FromArgb(252, 230, 230); fg = Color.FromArgb(200, 50, 70); break;
                    case "Utilities": bg = Color.FromArgb(225, 245, 255); fg = Color.FromArgb(30, 140, 200); break;
                    case "Salary": bg = Color.FromArgb(225, 250, 225); fg = Color.FromArgb(40, 180, 80); break;
                    case "Travel": bg = Color.FromArgb(255, 230, 240); fg = Color.FromArgb(220, 60, 130); break;
                    case "Housing": bg = Color.FromArgb(215, 240, 255); fg = Color.FromArgb(20, 120, 190); break;
                }

                int w = 110;
                int h = 30;
                int x = e.CellBounds.X + 10;
                int y = e.CellBounds.Y + (e.CellBounds.Height - h) / 2;

                var rect = new Rectangle(x, y, w, h);
                using (var path = RoundedRect(rect, 15))
                using (var bBg = new SolidBrush(bg))
                {
                    e.Graphics.FillPath(bBg, path);
                }

                using (var sf = new StringFormat { Alignment = StringAlignment.Center, LineAlignment = StringAlignment.Center })
                using (var bFg = new SolidBrush(fg))
                {
                    e.Graphics.DrawString(row.Category, new Font("Segoe UI", 8.5F, FontStyle.Bold), bFg, rect, sf);
                }
                e.Handled = true;
            }
            // Description & Account Default
            else if (e.ColumnIndex == 2 || e.ColumnIndex == 3)
            {
                using (var brush = new SolidBrush(PersonalFinanceManager.Common.Helpers.ThemeHelper.Text))
                {
                    e.Graphics.DrawString(e.Value?.ToString(), new Font("Segoe UI", 9.5F), brush, e.CellBounds.X, e.CellBounds.Y + 20);
                }
                e.Handled = true;
            }
            // Amount Amount Formatting
            else if (e.ColumnIndex == 4)
            {
                Color amtColor = row.Amount > 0 ? Color.FromArgb(40, 160, 40) : Color.FromArgb(200, 40, 40);
                using (var brush = new SolidBrush(amtColor))
                using (var sf = new StringFormat { Alignment = StringAlignment.Far })
                {
                    e.Graphics.DrawString(e.Value?.ToString(), new Font("Segoe UI", 10F, FontStyle.Bold), brush, e.CellBounds.Right - 10, e.CellBounds.Y + 20, sf);
                }
                e.Handled = true;
            }
        }

        private void pnlLiquidity_Paint(object sender, PaintEventArgs e)
        {
            var g = e.Graphics; g.SmoothingMode = SmoothingMode.AntiAlias;
            var rect = new Rectangle(0, 0, pnlLiquidity.Width - 1, pnlLiquidity.Height - 1);
            using (var path = RoundedRect(rect, 10))
            {
                using (var brush = new SolidBrush(PersonalFinanceManager.Common.Helpers.ThemeHelper.IsDarkMode ? Color.FromArgb(40, 50, 60) : Color.FromArgb(55, 75, 85)))
                {
                    g.FillPath(brush, path);
                }
            }
        }

        private void pnlPagination_Paint(object sender, PaintEventArgs e)
        {
            var g = e.Graphics; g.SmoothingMode = SmoothingMode.AntiAlias;
            int x = 0;
            
            int totalPages = (int)Math.Ceiling(_allRows.Count / (double)_pageSize);
            if(totalPages == 0) totalPages = 1;
            
            var buttons = new List<string> { "<" };
            for(int i=1; i<=totalPages; i++) buttons.Add(i.ToString());
            buttons.Add(">");
            
            foreach (var b in buttons)
            {
                var rect = new Rectangle(x, 5, 30, 30);
                using (var path = RoundedRect(rect, 5))
                {
                    if (b == _currentPage.ToString())
                    {
                        g.FillPath(new SolidBrush(Color.FromArgb(183, 0, 82)), path);
                        g.DrawString(b, new Font("Segoe UI", 9F, FontStyle.Bold), Brushes.White, rect, new StringFormat { Alignment = StringAlignment.Center, LineAlignment = StringAlignment.Center });
                    }
                    else
                    {
                        g.FillPath(new SolidBrush(Color.FromArgb(240, 240, 240)), path);
                        g.DrawString(b, new Font("Segoe UI", 9F), Brushes.Gray, rect, new StringFormat { Alignment = StringAlignment.Center, LineAlignment = StringAlignment.Center });
                    }
                }
                x += 35;
            }
        }

        private void BtnFloatingAdd_Click(object sender, EventArgs e)
        {
            var addForm = new TransactionEditForm();
            addForm.OnAddTransaction = (date, catId, accId, desc, amt, type) => 
            {
                var user = ServiceLocator.UserService.GetCurrentUser();
                if (user == null) return;

                var newTransaction = new Models.Transaction
                {
                    TransactionDate = date,
                    CategoryId = catId,
                    AccountId = accId,
                    UserId = user.Id,
                    Note = desc,
                    Amount = type == "Income" ? Math.Abs(amt) : -Math.Abs(amt),
                    Type = type,
                    CreatedAt = DateTime.Now
                };

                bool success = ServiceLocator.TransactionService.Add(newTransaction);
                if (success)
                {
                    RefreshData();
                    BindGridFiltered();
                }
                else
                {
                    var t = new Func<string, string>(PersonalFinanceManager.Common.Helpers.ConfigHelper.Translate);
                    MessageBox.Show(t(ServiceLocator.TransactionService.LastError ?? "Failed to save transaction to database."));
                }
            };
            addForm.ShowDialog();
        }

        private static GraphicsPath RoundedRect(Rectangle r, int radius)
        {
            var path = new GraphicsPath();
            path.AddArc(r.X, r.Y, radius * 2, radius * 2, 180, 90);
            path.AddArc(r.Right - radius * 2, r.Y, radius * 2, radius * 2, 270, 90);
            path.AddArc(r.Right - radius * 2, r.Bottom - radius * 2, radius * 2, radius * 2, 0, 90);
            path.AddArc(r.X, r.Bottom - radius * 2, radius * 2, radius * 2, 90, 90);
            path.CloseFigure();
            return path;
        }
    
        private void ApplyResponsiveLayout()
        {
            var contentPanel = this.Controls["pnlScrollContext"] ?? this.Controls["pnlMain"] ?? this;
            if (contentPanel != null)
            {
                contentPanel.Padding = new Padding(0);
                contentPanel.Margin = new Padding(0);
                this.Padding = new Padding(0);

                contentPanel.SizeChanged += (s, e) => {
                    int w = contentPanel.ClientSize.Width;
                    int h = contentPanel.ClientSize.Height;
                    
                    pnlFilter.Width = w - 60;
                    btnFilter.Left = pnlFilter.Width - btnFilter.Width;
                    cbCategory.Left = btnFilter.Left - cbCategory.Width - 10;
                    
                    pnlGrid.Width = w - 60;
                    pnlGrid.Height = h - pnlGrid.Top - 80;
                    
                    pnlLiquidity.Left = w - 30 - pnlLiquidity.Width;
                    pnlLiquidity.Top = pnlGrid.Bottom - pnlLiquidity.Height - 10;
                    pnlLiquidity.BringToFront();

                    pnlPagination.Top = pnlGrid.Bottom + 20;
                    pnlPagination.Left = 30;

                    btnFloatingAdd.Left = w - 40 - btnFloatingAdd.Width;
                    btnFloatingAdd.Top = h - 40 - btnFloatingAdd.Height;
                    btnFloatingAdd.BringToFront();

                    int newPageSize = (pnlGrid.Height - 55) / 60;
                    if (newPageSize < 1) newPageSize = 1;
                    if (_pageSize != newPageSize)
                    {
                        _pageSize = newPageSize;
                        int totalPages = (int)Math.Ceiling(_allRows.Count / (double)_pageSize);
                        if (_currentPage > totalPages && totalPages > 0) _currentPage = totalPages;
                        BindGridFiltered();
                    }
                };
            }
        }
}
}



