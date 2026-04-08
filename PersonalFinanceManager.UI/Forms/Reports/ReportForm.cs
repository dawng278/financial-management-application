using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using System.Linq;
using System.Collections.Generic;
using PersonalFinanceManager.Infrastructure.DI;
using PersonalFinanceManager.Models;
using LiveCharts;
using LiveCharts.WinForms;
using LiveCharts.Wpf;
using Panel = System.Windows.Forms.Panel;

namespace PersonalFinanceManager.Forms.Reports
{
    public class ComboItem { public string Text { get; set; } public int Value { get; set; } public override string ToString() => Text; }

    public partial class ReportForm : Form
    {
        private decimal _income = 0m;
        private decimal _expense = 0m;
        private decimal _savings = 0m;
        private LiveCharts.WinForms.CartesianChart _fiscalChart;

        public ReportForm()
        {
            InitializeComponent();
            ApplyResponsiveLayout();
            this.Load += ReportForm_Load;
        }

        private void ReportForm_Load(object sender, EventArgs e)
        {
            dtpStart.Value = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
            dtpEnd.Value = DateTime.Now.AddDays(1);

            try {
                var t = new Func<string, string>(PersonalFinanceManager.Common.Helpers.ConfigHelper.Translate);
                var cats = ServiceLocator.CategoryService.GetAll();
                cboCategory.Items.Clear();
                cboCategory.Items.Add(new ComboItem { Text = t("All Categories"), Value = 0 });
                foreach(var c in cats) cboCategory.Items.Add(new ComboItem { Text = c.Name, Value = c.Id });
                cboCategory.SelectedIndex = 0;

                var accs = ServiceLocator.AccountService.GetByCurrentUser();
                cboAccount.Items.Clear();
                cboAccount.Items.Add(new ComboItem { Text = t("All Accounts"), Value = 0 });
                foreach(var a in accs) cboAccount.Items.Add(new ComboItem { Text = a.AccountName, Value = a.Id });
                cboAccount.SelectedIndex = 0;
            } catch { }

            _fiscalChart = new LiveCharts.WinForms.CartesianChart
            {
                Location = new Point(20, 60),
                Size = new Size(pnlChart.Width - 40, pnlChart.Height - 80),
                Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right,
                LegendLocation = LegendLocation.Top,
                Hoverable = true
            };
            pnlChart.Controls.Add(_fiscalChart);
            _fiscalChart.BringToFront();

            LoadDataGridLayout();

            btnApply.Click += (s, ev) => LoadData();

            btnExportExcel.Click += (s, ev) => {
                using (var sfd = new SaveFileDialog { Filter = "Excel Workbook|*.xlsx", FileName = "FinancialReport_" + DateTime.Now.ToString("yyyyMMdd") })
                {
                    if (sfd.ShowDialog() == DialogResult.OK)
                    {
                        try {
                            PersonalFinanceManager.Controls.ExportHelper.ExportToExcel(dgvLedger, sfd.FileName);
                            MessageBox.Show(PersonalFinanceManager.Common.Helpers.ConfigHelper.Translate("Export successful!"), PersonalFinanceManager.Common.Helpers.ConfigHelper.Translate("Success"), MessageBoxButtons.OK, MessageBoxIcon.Information);
                        } catch (Exception ex) {
                            MessageBox.Show(ex.Message, PersonalFinanceManager.Common.Helpers.ConfigHelper.Translate("Error"), MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            };

            btnExportPdf.Click += (s, ev) => {
                using (var sfd = new SaveFileDialog { Filter = "PDF Document|*.pdf", FileName = "FinancialReport_" + DateTime.Now.ToString("yyyyMMdd") })
                {
                    if (sfd.ShowDialog() == DialogResult.OK)
                    {
                        try {
                            PersonalFinanceManager.Controls.ExportHelper.ExportToPdf(dgvLedger, sfd.FileName);
                            MessageBox.Show(PersonalFinanceManager.Common.Helpers.ConfigHelper.Translate("Export successful!"), PersonalFinanceManager.Common.Helpers.ConfigHelper.Translate("Success"), MessageBoxButtons.OK, MessageBoxIcon.Information);
                        } catch (Exception ex) {
                            MessageBox.Show(ex.Message, PersonalFinanceManager.Common.Helpers.ConfigHelper.Translate("Error"), MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            };

            PersonalFinanceManager.Common.Helpers.ConfigHelper.CurrencyChanged += (s, ev) => 
            {
                if (this.IsHandleCreated) this.Invoke(new Action(() => {
                    LoadData();
                }));
            };

            PersonalFinanceManager.Common.Helpers.ConfigHelper.LanguageChanged += (s, ev) => 
            {
                if (this.IsHandleCreated) this.Invoke(new Action(() => {
                    UpdateTranslations();
                }));
            };

            UpdateTranslations();
            LoadData();

            PersonalFinanceManager.Common.Helpers.ConfigHelper.ThemeChanged += (s, ev) =>
            {
                if (this.IsHandleCreated) this.Invoke(new Action(() => {
                    ApplyTheme();
                }));
            };
            ApplyTheme();
        }

        private void ApplyTheme()
        {
            PersonalFinanceManager.Common.Helpers.ThemeHelper.ApplyTheme(this);
            pnlFilter.Invalidate();
            pnlIncome.Invalidate();
            pnlExpense.Invalidate();
            pnlSavings.Invalidate();
            pnlChart.Invalidate();
            pnlLedger.Invalidate();
            dgvLedger.BackgroundColor = PersonalFinanceManager.Common.Helpers.ThemeHelper.CardBackground;
            dgvLedger.ColumnHeadersDefaultCellStyle.BackColor = PersonalFinanceManager.Common.Helpers.ThemeHelper.CardBackground;
            dgvLedger.DefaultCellStyle.BackColor = PersonalFinanceManager.Common.Helpers.ThemeHelper.CardBackground;
            dgvLedger.DefaultCellStyle.ForeColor = PersonalFinanceManager.Common.Helpers.ThemeHelper.Text;
            this.Refresh();
        }

        private void UpdateTranslations()
        {
            var t = new Func<string, string>(PersonalFinanceManager.Common.Helpers.ConfigHelper.Translate);
            
            var lblPageTitle = this.Controls.Find("lblPageTitle", true).Length > 0 ? this.Controls.Find("lblPageTitle", true)[0] as Label : null;
            if (lblPageTitle != null) lblPageTitle.Text = t("Financial Report Designer");

            var lblPageSub = this.Controls.Find("lblPageSub", true).Length > 0 ? this.Controls.Find("lblPageSub", true)[0] as Label : null;
            if (lblPageSub != null) lblPageSub.Text = t("Configure your fiscal summary using high-precision filters and multi-dimensional analytics. Data refreshes in real-time.");

            var lblFilterStart = this.Controls.Find("lblFilterStart", true).Length > 0 ? this.Controls.Find("lblFilterStart", true)[0] as Label : null;
            if (lblFilterStart != null) lblFilterStart.Text = t("START DATE");

            var lblFilterEnd = this.Controls.Find("lblFilterEnd", true).Length > 0 ? this.Controls.Find("lblFilterEnd", true)[0] as Label : null;
            if (lblFilterEnd != null) lblFilterEnd.Text = t("END DATE");

            var lblFilterCat = this.Controls.Find("lblFilterCat", true).Length > 0 ? this.Controls.Find("lblFilterCat", true)[0] as Label : null;
            if (lblFilterCat != null) lblFilterCat.Text = t("CATEGORY");

            var lblFilterAcc = this.Controls.Find("lblFilterAcc", true).Length > 0 ? this.Controls.Find("lblFilterAcc", true)[0] as Label : null;
            if (lblFilterAcc != null) lblFilterAcc.Text = t("ACCOUNT");

            var btnApply = this.Controls.Find("btnApply", true).Length > 0 ? this.Controls.Find("btnApply", true)[0] as ReaLTaiizor.Controls.HopeButton : null;
            if (btnApply != null) btnApply.Text = t("▼ Apply");

            var lblChartTitle = this.Controls.Find("lblChartTitle", true).Length > 0 ? this.Controls.Find("lblChartTitle", true)[0] as Label : null;
            if (lblChartTitle != null) lblChartTitle.Text = t("Fiscal Velocity");

            var lblChartSub = this.Controls.Find("lblChartSub", true).Length > 0 ? this.Controls.Find("lblChartSub", true)[0] as Label : null;
            if (lblChartSub != null) lblChartSub.Text = t("Monthly Income vs Expense comparison");

            var lblLedgerTitle = this.Controls.Find("lblLedgerTitle", true).Length > 0 ? this.Controls.Find("lblLedgerTitle", true)[0] as Label : null;
            if (lblLedgerTitle != null) lblLedgerTitle.Text = t("Transaction Ledger");

            if (dgvLedger.Columns.Count >= 5)
            {
                dgvLedger.Columns[0].HeaderText = t("Date");
                dgvLedger.Columns[1].HeaderText = t("Description");
                dgvLedger.Columns[2].HeaderText = t("Category");
                dgvLedger.Columns[3].HeaderText = t("Account");
                dgvLedger.Columns[4].HeaderText = t("Amount");
            }

            // Refresh everything so dynamic labels update too
            LoadData();
        }

        private void LoadData()
        {
            try
            {
                int catId = (cboCategory.SelectedItem as ComboItem)?.Value ?? 0;
                int accId = (cboAccount.SelectedItem as ComboItem)?.Value ?? 0;

                var txs = ServiceLocator.TransactionService.GetByDateRange(dtpStart.Value, dtpEnd.Value);

                if (catId > 0) txs = txs.Where(t => t.CategoryId == catId);
                if (accId > 0) txs = txs.Where(t => t.AccountId == accId);

                var txList = txs.ToList();

                _income = txList.Where(t => string.Equals(t.Type, "Income", StringComparison.OrdinalIgnoreCase)).Sum(t => t.Amount);
                _expense = txList.Where(t => !string.Equals(t.Type, "Income", StringComparison.OrdinalIgnoreCase)).Sum(t => t.Amount);
                _savings = _income - _expense;

                pnlIncome.Invalidate();
                pnlExpense.Invalidate();
                pnlSavings.Invalidate();

                dgvLedger.Rows.Clear();
                foreach(var tx in txList.OrderByDescending(t => t.TransactionDate))
                {
                    var t = new Func<string, string>(PersonalFinanceManager.Common.Helpers.ConfigHelper.Translate);
                    bool isExpense = string.Equals(tx.Type, "Expense", StringComparison.OrdinalIgnoreCase);
                    string amt = (isExpense ? "-" : "+") + PersonalFinanceManager.Common.Helpers.ConfigHelper.FormatGlobalCurrency(Math.Abs(tx.Amount));
                    
                    string catName = tx.CategoryName ?? t("Other");
                    string note = string.IsNullOrWhiteSpace(tx.Note) ? t("Transaction") : tx.Note;
                    string accName = tx.AccountName ?? (t("Account #") + tx.AccountId);
                    
                    int idx = dgvLedger.Rows.Add(tx.TransactionDate.ToString("dd/MM/yyyy"), t(note), t(catName).ToUpper(), accName, amt);
                    dgvLedger.Rows[idx].Tag = tx;
                }

                lblPaginator.Text = string.Format(PersonalFinanceManager.Common.Helpers.ConfigHelper.Translate("Showing {0} entries"), txList.Count);
                UpdateLiveChart(txList);
            }
            catch { }
        }

        private void UpdateLiveChart(List<Transaction> transactions)
        {
            if (_fiscalChart == null) return;
            
            var groups = transactions
                .GroupBy(t => new { t.TransactionDate.Year, t.TransactionDate.Month })
                .OrderBy(g => g.Key.Year).ThenBy(g => g.Key.Month)
                .ToList();

            var labels = new List<string>();
            var incomeValues = new ChartValues<double>();
            var expenseValues = new ChartValues<double>();

            if (groups.Count == 0)
            {
                labels.Add(dtpStart.Value.ToString("MM/yyyy"));
                incomeValues.Add(0); expenseValues.Add(0);
            }
            else 
            {
                foreach(var g in groups)
                {
                    labels.Add(new DateTime(g.Key.Year, g.Key.Month, 1).ToString("MM/yyyy"));
                    incomeValues.Add((double)g.Where(t => string.Equals(t.Type, "Income", StringComparison.OrdinalIgnoreCase)).Sum(t => t.Amount));
                    expenseValues.Add((double)g.Where(t => !string.Equals(t.Type, "Income", StringComparison.OrdinalIgnoreCase)).Sum(t => t.Amount));
                }
            }

            _fiscalChart.Series = new SeriesCollection
            {
                new ColumnSeries { Title = PersonalFinanceManager.Common.Helpers.ConfigHelper.Translate("Income"), Values = incomeValues, Fill = new System.Windows.Media.SolidColorBrush(System.Windows.Media.Color.FromRgb(24, 106, 34)) },
                new ColumnSeries { Title = PersonalFinanceManager.Common.Helpers.ConfigHelper.Translate("Expense"), Values = expenseValues, Fill = new System.Windows.Media.SolidColorBrush(System.Windows.Media.Color.FromRgb(183, 30, 80)) }
            };

            _fiscalChart.AxisX.Clear();
            _fiscalChart.AxisX.Add(new Axis { Labels = labels, Separator = new Separator { Step = 1, IsEnabled = false } });
            _fiscalChart.AxisY.Clear();
            _fiscalChart.AxisY.Add(new Axis { LabelFormatter = value => PersonalFinanceManager.Common.Helpers.ConfigHelper.FormatGlobalCurrency((decimal)value) });
        }

        private void ApplyResponsiveLayout()
        {
            pnlFilter.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            pnlChart.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            pnlLedger.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            
            btnApply.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            cboAccount.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            lblFilterAcc.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            cboCategory.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            lblFilterCat.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            
            btnExportPdf.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnExportExcel.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            dgvLedger.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Bottom;
            
            pnlScrollContext.SizeChanged += (s, e) => {
                int w = (pnlFilter.Width - 40) / 3;
                pnlIncome.Width = w;
                pnlExpense.Width = w;
                pnlSavings.Width = w;
                pnlExpense.Left = pnlIncome.Right + 20;
                pnlSavings.Left = pnlExpense.Right + 20;
            };
        }

        private void LoadDataGridLayout()
        {
            dgvLedger.ColumnCount = 5;
            dgvLedger.Columns[0].Name = "Date";
            dgvLedger.Columns[1].Name = "Description";
            dgvLedger.Columns[2].Name = "Category";
            dgvLedger.Columns[3].Name = "Account";
            dgvLedger.Columns[4].Name = "Amount";
            dgvLedger.Columns[4].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

            dgvLedger.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dgvLedger.EnableHeadersVisualStyles = false;
            dgvLedger.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dgvLedger.ColumnHeadersDefaultCellStyle.BackColor = Color.White;
            dgvLedger.ColumnHeadersDefaultCellStyle.ForeColor = Color.Gray;
            dgvLedger.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            dgvLedger.DefaultCellStyle.SelectionBackColor = Color.FromArgb(240,240,245);
            dgvLedger.DefaultCellStyle.SelectionForeColor = PersonalFinanceManager.Common.Helpers.ThemeHelper.Text;
            dgvLedger.BackgroundColor = PersonalFinanceManager.Common.Helpers.ThemeHelper.CardBackground;
            dgvLedger.RowTemplate.Height = 40;

            foreach (DataGridViewColumn col in dgvLedger.Columns)
                col.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

            dgvLedger.CellPainting += DgvLedger_CellPainting;
        }

        private void DgvLedger_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            if (e.RowIndex < 0) return;
            e.PaintBackground(e.CellBounds, true);

            var font = new Font("Segoe UI", 9F);
            var color = Color.Black;

            if (e.ColumnIndex == 4)
            {
                var val = e.Value?.ToString() ?? "";
                if (val.StartsWith("+")) color = Color.FromArgb(24, 106, 34);
                else color = Color.FromArgb(183, 30, 80);
                font = new Font("Segoe UI", 9F);
                
                using (var stringFormat = new StringFormat() { Alignment = StringAlignment.Far, LineAlignment = StringAlignment.Center })
                {
                    e.Graphics.DrawString(val, font, new SolidBrush(color), new Rectangle(e.CellBounds.X, e.CellBounds.Y, e.CellBounds.Width - 10, e.CellBounds.Height), stringFormat);
                }
                e.Handled = true;
            }
            else if (e.ColumnIndex == 2)
            {
                var tx = dgvLedger.Rows[e.RowIndex].Tag as Transaction;
                var val = e.Value?.ToString() ?? "";
                
                // Defaults (Income color)
                var bg = Color.FromArgb(235, 245, 235);
                var fg = Color.FromArgb(40, 110, 40);
                
                // Expense color
                if (tx != null && !string.Equals(tx.Type, "Income", StringComparison.OrdinalIgnoreCase)) 
                {
                    bg = Color.FromArgb(250, 230, 240);
                    fg = Color.FromArgb(183, 30, 80);
                }

                e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
                var pillRect = new Rectangle(e.CellBounds.X + 10, e.CellBounds.Y + 10, e.CellBounds.Width - 30, 20);
                using (var path = RoundedRect(pillRect, 5))
                {
                    e.Graphics.FillPath(new SolidBrush(bg), path);
                }
                
                using (var sf = new StringFormat() { Alignment = StringAlignment.Center, LineAlignment = StringAlignment.Center })
                {
                    e.Graphics.DrawString(val, new Font("Segoe UI", 7F), new SolidBrush(fg), pillRect, sf);
                }
                e.Handled = true;
            }
            else
            {
                using (var stringFormat = new StringFormat() { Alignment = StringAlignment.Near, LineAlignment = StringAlignment.Center })
                {
                    e.Graphics.DrawString(e.Value?.ToString(), font, Brushes.Black, new Rectangle(e.CellBounds.X + 10, e.CellBounds.Y, e.CellBounds.Width - 10, e.CellBounds.Height), stringFormat);
                }
                e.Handled = true;
            }
        }

        private void pnlFilter_Paint(object sender, PaintEventArgs e)
        {
            var g = e.Graphics; g.SmoothingMode = SmoothingMode.AntiAlias;
            using (var path = RoundedRect(new Rectangle(0, 0, pnlFilter.Width - 1, pnlFilter.Height - 1), 10))
            {
                 g.FillPath(new SolidBrush(PersonalFinanceManager.Common.Helpers.ThemeHelper.CardBackground), path);
                 g.DrawPath(new Pen(PersonalFinanceManager.Common.Helpers.ThemeHelper.Border, 1), path);
            }
        }

        private void pnlIncome_Paint(object sender, PaintEventArgs e)
        {
            var t = new Func<string, string>(PersonalFinanceManager.Common.Helpers.ConfigHelper.Translate);
            DrawMetricCard(e.Graphics, pnlIncome.ClientRectangle, t("TOTAL INCOME"), PersonalFinanceManager.Common.Helpers.ConfigHelper.FormatGlobalCurrency(_income), t("Calculated statically"), Color.FromArgb(24, 106, 34), Color.FromArgb(230, 245, 235), "?");
        }

        private void pnlExpense_Paint(object sender, PaintEventArgs e)
        {
            var t = new Func<string, string>(PersonalFinanceManager.Common.Helpers.ConfigHelper.Translate);
            DrawMetricCard(e.Graphics, pnlExpense.ClientRectangle, t("TOTAL EXPENSES"), PersonalFinanceManager.Common.Helpers.ConfigHelper.FormatGlobalCurrency(_expense), t("Calculated statically"), Color.FromArgb(183, 30, 80), Color.FromArgb(250, 230, 235), "?");
        }

        private void pnlSavings_Paint(object sender, PaintEventArgs e)
        {
            var t = new Func<string, string>(PersonalFinanceManager.Common.Helpers.ConfigHelper.Translate);
            DrawMetricCard(e.Graphics, pnlSavings.ClientRectangle, t("NET SAVINGS"), PersonalFinanceManager.Common.Helpers.ConfigHelper.FormatGlobalCurrency(_savings), "", Color.FromArgb(160, 20, 50), Color.FromArgb(250, 230, 240), "??");
        }

        private void DrawMetricCard(Graphics g, Rectangle r, string title, string val, string sub, Color themeColor, Color pillColor, string icon)
        {
            g.SmoothingMode = SmoothingMode.AntiAlias;
            using (var path = RoundedRect(new Rectangle(r.X, r.Y, r.Width - 1, r.Height - 1), 10))
            {
                g.FillPath(new SolidBrush(PersonalFinanceManager.Common.Helpers.ThemeHelper.CardBackground), path);
                g.DrawPath(new Pen(PersonalFinanceManager.Common.Helpers.ThemeHelper.Border, 1), path);
            }
                
            g.FillRectangle(new SolidBrush(themeColor), 0, 10, 4, r.Height - 20);

            g.DrawString(title, new Font("Segoe UI", 8F, FontStyle.Bold), Brushes.Gray, 20, 15);
            g.DrawString(val, new Font("Segoe UI", 20F, FontStyle.Bold), new SolidBrush(themeColor), 15, 35);
            g.DrawString(sub, new Font("Segoe UI", 8F), new SolidBrush(themeColor), 20, 75);

            g.FillPath(new SolidBrush(pillColor), RoundedRect(new Rectangle(r.Width - 50, 20, 35, 35), 8));
            g.DrawString(icon, new Font("Segoe UI", 12F, FontStyle.Bold), new SolidBrush(themeColor), r.Width - 43, 27);
        }

        private void pnlChart_Paint(object sender, PaintEventArgs e)
        {
            var g = e.Graphics; g.SmoothingMode = SmoothingMode.AntiAlias;
            using (var path = RoundedRect(new Rectangle(0, 0, pnlChart.Width - 1, pnlChart.Height - 1), 10))
            {
                 g.FillPath(new SolidBrush(PersonalFinanceManager.Common.Helpers.ThemeHelper.CardBackground), path);
                 g.DrawPath(new Pen(PersonalFinanceManager.Common.Helpers.ThemeHelper.Border, 1), path);
            }
        }

        private void pnlLedger_Paint(object sender, PaintEventArgs e)
        {
            var g = e.Graphics; g.SmoothingMode = SmoothingMode.AntiAlias;
            using (var path = RoundedRect(new Rectangle(0, 0, pnlLedger.Width - 1, pnlLedger.Height - 1), 10))
            {
                 g.FillPath(new SolidBrush(PersonalFinanceManager.Common.Helpers.ThemeHelper.CardBackground), path);
                 g.DrawPath(new Pen(PersonalFinanceManager.Common.Helpers.ThemeHelper.Border, 1), path);
            }
        }

        private static GraphicsPath RoundedRect(Rectangle r, int radius)
        {
            var path = new GraphicsPath();
            int d = radius * 2;
            path.AddArc(r.X, r.Y, d, d, 180, 90);
            path.AddArc(r.Right - d, r.Y, d, d, 270, 90);
            path.AddArc(r.Right - d, r.Bottom - d, d, d, 0, 90);
            path.AddArc(r.X, r.Bottom - d, d, d, 90, 90);
            path.CloseFigure();
            return path;
        }
    }
}
