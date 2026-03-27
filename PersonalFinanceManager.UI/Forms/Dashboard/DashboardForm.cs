using LiveCharts;
using LiveCharts.Wpf;
using PersonalFinanceManager.Controls;
using PersonalFinanceManager.Infrastructure.DI;
using PersonalFinanceManager.Models;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Windows.Forms;

namespace PersonalFinanceManager.Forms.Dashboard
{
    public partial class DashboardForm : Form
    {
        private decimal _totalBalance = 0m;
        private decimal _totalIncome = 0m;
        private decimal _totalExpense = 0m;

        public DashboardForm()
        {
            InitializeComponent();
            
            this.Load += DashboardForm_Load;
            this.btnAddTransaction.Click += (s, e) => ShowAddTransaction();
            
            ServiceLocator.TransactionService.TransactionChanged += (s, e) => {
                if (this.IsHandleCreated) this.Invoke(new Action(() => {
                    LoadDashboardData();
                    SetupTrendChart();
                    SetupDonutChart();
                    SetupTransactionGrid();
                }));
            };

            ApplyResponsiveLayout();
        }

        private void DashboardForm_Load(object sender, EventArgs e)
        {
            LoadDashboardData();
            SetupTrendChart();
            SetupDonutChart();
            SetupTransactionGrid();
            
            PersonalFinanceManager.Common.Helpers.ConfigHelper.CurrencyChanged += (s, ev) => 
            {
                if (this.IsHandleCreated) this.Invoke(new Action(() => {
                    LoadDashboardData();
                    SetupTransactionGrid();
                }));
            };

            PersonalFinanceManager.Common.Helpers.ConfigHelper.LanguageChanged += (s, ev) => 
            {
                if (this.IsHandleCreated) this.Invoke(new Action(() => {
                    UpdateTranslations();
                    SetupTransactionGrid();
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
        }

        private void ApplyTheme()
        {
            PersonalFinanceManager.Common.Helpers.ThemeHelper.ApplyTheme(this);
            this.Refresh();
        }

        private void UpdateTranslations()
        {
            lblTrendTitle.Text = PersonalFinanceManager.Common.Helpers.ConfigHelper.Translate("Spending Trend") + "\n" + PersonalFinanceManager.Common.Helpers.ConfigHelper.Translate("Last 30 days of financial activity");
            lblUsageTitle.Text = PersonalFinanceManager.Common.Helpers.ConfigHelper.Translate("Budget Usage") + "\n" + PersonalFinanceManager.Common.Helpers.ConfigHelper.Translate("Monthly allocation spent");
            lblRecentTitle.Text = PersonalFinanceManager.Common.Helpers.ConfigHelper.Translate("Recent Transactions");
            
            _incomeRowText = PersonalFinanceManager.Common.Helpers.ConfigHelper.Translate("Income");
            _expenseRowText = PersonalFinanceManager.Common.Helpers.ConfigHelper.Translate("Expense");

            lblIncomeLabel.Text = _incomeRowText.ToUpper();
            lblExpenseLabel.Text = _expenseRowText.ToUpper();
            lblBalanceLabel.Text = PersonalFinanceManager.Common.Helpers.ConfigHelper.Translate("Total Balance").ToUpper();
        }

        private string _incomeRowText = "Income";
        private string _expenseRowText = "Expense";

        private void LoadDashboardData()
        {
            try
            {
                var all = ServiceLocator.TransactionService
                    .GetByDateRange(DateTime.MinValue.AddYears(1), DateTime.MaxValue.AddYears(-1))
                    .ToList();

                _totalIncome = all
                    .Where(t => string.Equals(t.Type, "Income", StringComparison.OrdinalIgnoreCase))
                    .Sum(t => t.Amount);

                _totalExpense = all
                    .Where(t => !string.Equals(t.Type, "Income", StringComparison.OrdinalIgnoreCase))
                    .Sum(t => t.Amount);

                _totalBalance = _totalIncome + _totalExpense;

                lblBalance.Text = PersonalFinanceManager.Common.Helpers.ConfigHelper.FormatGlobalCurrency(_totalBalance);
                lblIncome.Text = PersonalFinanceManager.Common.Helpers.ConfigHelper.FormatGlobalCurrency(_totalIncome);
                lblExpense.Text = PersonalFinanceManager.Common.Helpers.ConfigHelper.FormatGlobalCurrency(Math.Abs(_totalExpense));
            }
            catch
            {
                lblBalance.Text = PersonalFinanceManager.Common.Helpers.ConfigHelper.FormatGlobalCurrency(0);
                lblIncome.Text = PersonalFinanceManager.Common.Helpers.ConfigHelper.FormatGlobalCurrency(0);
                lblExpense.Text = PersonalFinanceManager.Common.Helpers.ConfigHelper.FormatGlobalCurrency(0);
            }
        }

        private void SetupTrendChart()
        {
            var labels = new List<string>();
            var expenseValues = new ChartValues<double>();
            var incomeValues = new ChartValues<double>();

            try
            {
                var allTxs = ServiceLocator.TransactionService
                    .GetByDateRange(DateTime.Today.AddDays(-30), DateTime.MaxValue)
                    .ToList();

                var expenses = allTxs.Where(t => string.Equals(t.Type, "Expense", StringComparison.OrdinalIgnoreCase)).ToList();
                var incomes = allTxs.Where(t => string.Equals(t.Type, "Income", StringComparison.OrdinalIgnoreCase)).ToList();

                // Aggregate by 5 day chunks roughly
                for (int i = 0; i < 6; i++)
                {
                    var d = DateTime.Today.AddDays(-25 + (i * 5));
                    labels.Add(d.ToString("dd MMM").ToUpper());
                    
                    var expSum = expenses
                        .Where(t => t.TransactionDate.Date > d.AddDays(-5).Date && t.TransactionDate.Date <= d.Date)
                        .Sum(x => x.Amount);

                    var incSum = incomes
                        .Where(t => t.TransactionDate.Date > d.AddDays(-5).Date && t.TransactionDate.Date <= d.Date)
                        .Sum(x => x.Amount);
                        
                    expenseValues.Add((double)Math.Abs(expSum)); 
                    incomeValues.Add((double)Math.Abs(incSum));
                }
            }
            catch 
            {
                labels = new List<string> { "01 OCT", "06 OCT", "15 OCT", "22 OCT", "30 OCT", "NOW" };
                expenseValues = new ChartValues<double> { 120, 250, 180, 450, 290, 310 };
                incomeValues = new ChartValues<double> { 500, 450, 600, 550, 700, 680 };
            }

            var expenseSeries = new LineSeries
            {
                Title = PersonalFinanceManager.Common.Helpers.ConfigHelper.Translate("Expense"),
                Values = expenseValues,
                Stroke = new System.Windows.Media.SolidColorBrush(System.Windows.Media.Color.FromRgb(200, 20, 80)),
                StrokeThickness = 3,
                PointGeometrySize = 8,
                Fill = new System.Windows.Media.SolidColorBrush(System.Windows.Media.Color.FromArgb(20, 200, 20, 80)),
                LineSmoothness = 0.8
            };

            var incomeSeries = new LineSeries
            {
                Title = PersonalFinanceManager.Common.Helpers.ConfigHelper.Translate("Income"),
                Values = incomeValues,
                Stroke = new System.Windows.Media.SolidColorBrush(System.Windows.Media.Color.FromRgb(40, 160, 60)),
                StrokeThickness = 3,
                PointGeometrySize = 8,
                Fill = new System.Windows.Media.SolidColorBrush(System.Windows.Media.Color.FromArgb(20, 40, 160, 60)),
                LineSmoothness = 0.8
            };

            chartTrend.Series = new SeriesCollection { expenseSeries, incomeSeries };
            chartTrend.AxisX.Clear();
            chartTrend.AxisY.Clear();

            chartTrend.AxisX.Add(new Axis
            {
                Labels = labels,
                Separator = new Separator { StrokeThickness = 0 },
                Foreground = new System.Windows.Media.SolidColorBrush(System.Windows.Media.Color.FromRgb(160, 160, 160)),
                FontSize = 10
            });
            chartTrend.AxisY.Add(new Axis
            {
                ShowLabels = false,
                Separator = new Separator { StrokeThickness = 0 }
            });
            chartTrend.LegendLocation = LegendLocation.Bottom;
            chartTrend.Hoverable = true;
        }

        private void SetupDonutChart()
        {
            try
            {
                var spentVal = (double)Math.Abs(_totalExpense);
                var remainingVal = (double)Math.Max(0, _totalBalance);
                
                var dict = new Dictionary<string, double>
                {
                    { "Spent", spentVal },
                    { "Remaining", remainingVal }
                };

                SeriesCollection piechartData = new SeriesCollection();
                var colors = new[] 
                { 
                    System.Windows.Media.Color.FromRgb(200, 20, 80), 
                    System.Windows.Media.Color.FromRgb(220, 220, 230) 
                };
                
                int i = 0;
                foreach (var entry in dict)
                {
                    piechartData.Add(new PieSeries
                    {
                        Title = entry.Key,
                        Values = new ChartValues<double> { entry.Value },
                        DataLabels = false,
                        Fill = new System.Windows.Media.SolidColorBrush(colors[i % colors.Length]),
                        PushOut = 0
                    });
                    i++;
                }
                
                chartDonut.Series = piechartData;
                chartDonut.LegendLocation = LegendLocation.None;
                chartDonut.InnerRadius = 60;

                // Update the percentage label in the center
                int percent = (_totalIncome > 0) ? (int)(spentVal / (double)_totalIncome * 100) : (spentVal > 0 ? 100 : 0);
                lblUsagePercent.Text = $"{percent}%";
                
                // Center the label inside the donut chart
                lblUsagePercent.Left = chartDonut.Left + (chartDonut.Width / 2) - (lblUsagePercent.Width / 2);
                lblUsagePercent.Top = chartDonut.Top + (chartDonut.Height / 2) - (lblUsagePercent.Height / 2) - 5; // -5 for visual optical centering
            }
            catch { }
        }

        private void SetupTransactionGrid()
        {
            var t = new Func<string, string>(PersonalFinanceManager.Common.Helpers.ConfigHelper.Translate);
            
            dgvTrans.Columns.Clear();
            dgvTrans.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = t("TRANSACTION"), Name = "colTrans", AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill });
            dgvTrans.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = t("CATEGORY"), Name = "colCat", Width = 150 });
            dgvTrans.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = t("DATE"), Name = "colDate", Width = 150 });
            dgvTrans.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = t("STATUS"), Name = "colStatus", Width = 120 });
            dgvTrans.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = t("AMOUNT"), Name = "colAmt", Width = 120, DefaultCellStyle = { Alignment = DataGridViewContentAlignment.MiddleRight, Font = new Font("Segoe UI", 9.5f, FontStyle.Bold) } });

            try
            {
                var rows = ServiceLocator.TransactionService.GetRecent(5);
                foreach (var tx in rows)
                {
                    bool isExpense = string.Equals(tx.Type, "Expense", StringComparison.OrdinalIgnoreCase);
                    string amount = (isExpense ? "-" : "+") + PersonalFinanceManager.Common.Helpers.ConfigHelper.FormatGlobalCurrency(Math.Abs(tx.Amount));
                    
                    string catName = string.IsNullOrWhiteSpace(tx.CategoryName) ? "Transaction" : tx.CategoryName;
                    string note = string.IsNullOrWhiteSpace(tx.Note) ? "Miscellaneous" : tx.Note;
                    string title = t(catName) + "\n" + t(note);

                    dgvTrans.Rows.Add(title, t(tx.Type).ToUpper(), tx.TransactionDate.ToString("MMM dd, yyyy"), t("Completed"), amount);
                }
            }
            catch { }
        }

        private void ShowAddTransaction()
        {
            using (var frm = new PersonalFinanceManager.Forms.Transactions.TransactionEditForm())
            {
                frm.OnAddTransaction = (date, catId, accId, desc, amt, type) => 
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
                    if (!success)
                    {
                        var t = new Func<string, string>(PersonalFinanceManager.Common.Helpers.ConfigHelper.Translate);
                        MessageBox.Show(t(ServiceLocator.TransactionService.LastError ?? "Failed to save transaction to database."));
                    }
                };
                frm.ShowDialog();
            }
        }

        // Custom Paints for Shadows and Borders
        private void Card_Paint(object sender, PaintEventArgs e)
        {
            var pnl = (Panel)sender;
            var g = e.Graphics;
            g.SmoothingMode = SmoothingMode.AntiAlias;
            var rect = new Rectangle(0, 0, pnl.Width - 1, pnl.Height - 1);
            using (var path = RoundedRect(rect, 10))
            {
                using (var bg = new SolidBrush(PersonalFinanceManager.Common.Helpers.ThemeHelper.CardBackground)) g.FillPath(bg, path);
                using (var pen = new Pen(PersonalFinanceManager.Common.Helpers.ThemeHelper.Border, 1)) g.DrawPath(pen, path);
            }
        }

        private void TopAccent_Paint(object sender, PaintEventArgs e)
        {
            var pnl = (Panel)sender;
            string tag = pnl.Tag?.ToString();
            Color c = Color.FromArgb(40, 60, 80);
            if (tag == "Green") c = Color.FromArgb(40, 160, 60);
            if (tag == "Red") c = Color.FromArgb(200, 20, 60);

            using (var brush = new SolidBrush(c))
                e.Graphics.FillRectangle(brush, 0, 0, pnl.Width, pnl.Height);
        }

        private static GraphicsPath RoundedRect(Rectangle r, int rad)
        {
            var p = new GraphicsPath(); int d = rad * 2;
            p.AddArc(r.X, r.Y, d, d, 180, 90);
            p.AddArc(r.Right - d, r.Y, d, d, 270, 90);
            p.AddArc(r.Right - d, r.Bottom - d, d, d, 0, 90);
            p.AddArc(r.X, r.Bottom - d, d, d, 90, 90);
            p.CloseFigure(); return p;
        }

        private void dgvTrans_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.ColumnIndex == 4 && e.Value != null)
            {
                string val = e.Value.ToString();
                if (val.StartsWith("-")) e.CellStyle.ForeColor = Color.FromArgb(200, 20, 60);
                else e.CellStyle.ForeColor = Color.FromArgb(40, 160, 60);
            }
        }
    
        private void ApplyResponsiveLayout()
        {
            var contentPanel = this.Controls["pnlScrollContext"] ?? this.Controls["pnlMain"] ?? this;
            if (contentPanel != null)
            {
                contentPanel.Padding = new Padding(0);
                contentPanel.Margin = new Padding(0);
                this.Padding = new Padding(0);

                // Top Actions
                btnAddTransaction.Anchor = AnchorStyles.Top | AnchorStyles.Right;

                // Disable anchors that fight dynamic resizing
                pnlTrend.Anchor = AnchorStyles.Top | AnchorStyles.Left;
                pnlUsage.Anchor = AnchorStyles.Top | AnchorStyles.Left;
                pnlRecent.Anchor = AnchorStyles.Top | AnchorStyles.Left;
                dgvTrans.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
                chartTrend.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;

                Action resizeSource = () => {
                    if (contentPanel.ClientSize.Width == 0) return;
                    int margin = 30;
                    int gap = 20;
                    int w = (contentPanel.ClientSize.Width - margin * 2 - gap * 2) / 3;
                    if (w < 250) w = 250;

                    pnlCardBalance.Width = w;
                    pnlCardIncome.Width = w;
                    pnlCardExpense.Width = w;

                    pnlCardIncome.Left = pnlCardBalance.Right + gap;
                    pnlCardExpense.Left = pnlCardIncome.Right + gap;

                    foreach (Control c in pnlCardBalance.Controls) if (c.Tag?.ToString() == "Dark" || c.Tag?.ToString() == "Green" || c.Tag?.ToString() == "Red") c.Width = w;
                    foreach (Control c in pnlCardIncome.Controls) if (c.Tag?.ToString() == "Dark" || c.Tag?.ToString() == "Green" || c.Tag?.ToString() == "Red") c.Width = w;
                    foreach (Control c in pnlCardExpense.Controls) if (c.Tag?.ToString() == "Dark" || c.Tag?.ToString() == "Green" || c.Tag?.ToString() == "Red") c.Width = w;

                    // Fix missing Usage Donut chart by pinning it explicitly to right edge width
                    int usageW = 340;
                    pnlUsage.Width = usageW;
                    pnlUsage.Left = contentPanel.ClientSize.Width - margin - usageW;
                    
                    pnlTrend.Left = margin;
                    pnlTrend.Width = pnlUsage.Left - gap - pnlTrend.Left;

                    pnlRecent.Left = margin;
                    pnlRecent.Width = contentPanel.ClientSize.Width - margin * 2;
                };

                contentPanel.SizeChanged += (s, e) => resizeSource();
                // Trigger once immediately
                this.HandleCreated += (s, e) => resizeSource();
                if (this.IsHandleCreated) resizeSource();
            }
        }
}
}






