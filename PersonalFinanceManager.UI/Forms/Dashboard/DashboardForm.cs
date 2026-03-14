using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using LiveCharts;
using LiveCharts.Wpf;
using PersonalFinanceManager.Infrastructure.DI;
using System.Collections.Generic;
using System.Linq;
using PersonalFinanceManager.Models;

namespace PersonalFinanceManager.Forms.Dashboard
{
    public partial class DashboardForm : Form
    {
        // ── Guna helpers not in Designer (avoid design-time NullRef) ──
        private Guna.UI2.WinForms.Guna2Elipse _elipse;
        private Guna.UI2.WinForms.Guna2ShadowForm _shadow;

        private static readonly Color Accent = Color.FromArgb(181, 212, 34);
        private static readonly Color AccentHov = Color.FromArgb(158, 190, 20);
        private static readonly Color DarkCard = Color.FromArgb(30, 33, 42);
        private static readonly Color Teal = Color.FromArgb(0, 180, 140);
        private static readonly Color BgLight = Color.FromArgb(245, 246, 250);

        private decimal _totalBalance = 0m;
        private decimal _totalSpending = 0m;
        private decimal _totalSaved = 0m;
        private List<TransferItem> _recentTransfers = new List<TransferItem>();

        private class TransferItem
        {
            public string Name { get; set; }
            public DateTime Date { get; set; }
            public decimal Amount { get; set; }
            public bool IsExpense { get; set; }
        }

        public DashboardForm()
        {
            InitializeComponent();

            // Init Guna effects only at runtime, never in Designer
            if (!this.DesignMode)
            {
                _elipse = new Guna.UI2.WinForms.Guna2Elipse();
                _elipse.BorderRadius = 0;      // fullscreen = no rounding
                _elipse.TargetControl = this;

                _shadow = new Guna.UI2.WinForms.Guna2ShadowForm();
                _shadow.TargetForm = this;
            }

            this.Load += DashboardForm_Load;
            this.SizeChanged += DashboardForm_SizeChanged;
            this.pnlMain.SizeChanged += PnlMain_SizeChanged;

            // Nav clicks
            this.btnNavTransactions.Click += (s, e) => NavigateTo("transactions");
            this.btnNavInvoices.Click += (s, e) => NavigateTo("invoices");
            this.btnNavWallets.Click += (s, e) => NavigateTo("wallets");
            this.btnNavSettings.Click += (s, e) => NavigateTo("settings");
            this.btnNavDashboard.Click += (s, e) => NavigateTo("dashboard");
            this.lnkViewAllTrf.Text = "Thêm bill";
            this.lnkViewAllTrf.LinkClicked += lnkViewAllTrf_LinkClicked;
        }

        // ══════════════════════════════════════════════
        // LOAD
        // ══════════════════════════════════════════════
        private void DashboardForm_Load(object sender, EventArgs e)
        {
            try
            {
                var user = ServiceLocator.UserService.GetCurrentUser();
                if (user != null)
                    lblUsername.Text = user.FullName ?? user.Email ?? "Người dùng";
            }
            catch { }

            LayoutTopBarButtons();
            LoadDashboardData();
            SetupChart();
            SetupTransactionGrid();
        }

        private void LoadDashboardData()
        {
            try
            {
                var all = ServiceLocator.TransactionService
                    .GetByDateRange(DateTime.MinValue.AddYears(1), DateTime.MaxValue.AddYears(-1))
                    .ToList();

                decimal income = all
                    .Where(t => string.Equals(t.Type, "Income", StringComparison.OrdinalIgnoreCase))
                    .Sum(t => t.Amount);

                decimal expense = all
                    .Where(t => !string.Equals(t.Type, "Income", StringComparison.OrdinalIgnoreCase))
                    .Sum(t => t.Amount);

                _totalSpending = expense;
                _totalBalance = income - expense;
                _totalSaved = _totalBalance > 0 ? _totalBalance : 0m;

                _recentTransfers = all
                    .OrderByDescending(t => t.TransactionDate)
                    .Take(5)
                    .Select(t => new TransferItem
                    {
                        Name = string.IsNullOrWhiteSpace(t.CategoryName) ? "Giao dịch" : t.CategoryName,
                        Date = t.TransactionDate,
                        Amount = t.Amount,
                        IsExpense = !string.Equals(t.Type, "Income", StringComparison.OrdinalIgnoreCase)
                    })
                    .ToList();
            }
            catch
            {
                _totalSpending = 0m;
                _totalBalance = 0m;
                _totalSaved = 0m;
                _recentTransfers = new List<TransferItem>();
            }

            pnlCardBalance.Invalidate();
            pnlCardSpending.Invalidate();
            pnlCardSaved.Invalidate();
            pnlTransferList.Invalidate();
        }

        // ══════════════════════════════════════════════
        // RESPONSIVE — topbar buttons
        // ══════════════════════════════════════════════
        private void DashboardForm_SizeChanged(object sender, EventArgs e) => LayoutTopBarButtons();

        private void LayoutTopBarButtons()
        {
            int w = pnlTopBar.Width;
            int btnY = (pnlTopBar.Height - 30) / 2;

            btnClose.Location = new Point(w - 40, btnY);
            btnMaximize.Location = new Point(w - 74, btnY);
            btnMinimize.Location = new Point(w - 108, btnY);
            lblUsername.Location = new Point(w - 230, (pnlTopBar.Height - lblUsername.PreferredHeight) / 2);
            picAvatar.Location = new Point(w - 270, (pnlTopBar.Height - 36) / 2);
        }

        // ══════════════════════════════════════════════
        // RESPONSIVE — reflow on pnlMain resize
        // ══════════════════════════════════════════════
        private void PnlMain_SizeChanged(object sender, EventArgs e)
        {
            int pad = pnlMain.Padding.Left;
            int avail = pnlMain.ClientSize.Width - pad * 2;
            if (avail <= 0) return;

            // Stat cards: 3 equal columns, max 240px each
            int cardW = Math.Min(240, (avail - 32) / 3);
            int cardGap = avail > cardW * 3 ? (avail - cardW * 3) / 2 : 16;

            pnlCardBalance.Width = cardW;
            pnlCardSpending.Width = cardW;
            pnlCardSaved.Width = cardW;
            pnlCardBalance.Location = new Point(0, 0);
            pnlCardSpending.Location = new Point(cardW + cardGap, 0);
            pnlCardSaved.Location = new Point((cardW + cardGap) * 2, 0);

            // Chart & transactions stretch full width
            int fullW = avail;
            pnlChartArea.Width = fullW;
            chartWorkingCapital.Width = fullW;
            pnlTransactions.Width = fullW;
            dgvTransactions.Width = fullW;

            if (lnkViewAllTrans.IsHandleCreated)
                lnkViewAllTrans.Location = new Point(fullW - lnkViewAllTrans.Width - 16, 18);
        }

        // ══════════════════════════════════════════════
        // LIVECHARTS
        // ══════════════════════════════════════════════
        private void SetupChart()
        {
            var labels = new List<string>();
            var incomeData = new ChartValues<double>();
            var expenseData = new ChartValues<double>();

            try
            {
                var txs = ServiceLocator.TransactionService
                    .GetByDateRange(DateTime.MinValue.AddYears(1), DateTime.MaxValue.AddYears(-1))
                    .ToList();

                var months = Enumerable.Range(0, 6)
                    .Select(i => new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1).AddMonths(-5 + i))
                    .ToList();

                foreach (var m in months)
                {
                    var from = m;
                    var to = m.AddMonths(1).AddTicks(-1);
                    var monthTx = txs.Where(t => t.TransactionDate >= from && t.TransactionDate <= to);

                    var incomeValue = monthTx
                        .Where(t => string.Equals(t.Type, "Income", StringComparison.OrdinalIgnoreCase))
                        .Sum(t => t.Amount);
                    var expenseValue = monthTx
                        .Where(t => !string.Equals(t.Type, "Income", StringComparison.OrdinalIgnoreCase))
                        .Sum(t => t.Amount);

                    labels.Add("T" + m.Month);
                    incomeData.Add((double)incomeValue);
                    expenseData.Add((double)expenseValue);
                }
            }
            catch
            {
                labels = new List<string> { "T1", "T2", "T3", "T4", "T5", "T6" };
                incomeData = new ChartValues<double> { 0, 0, 0, 0, 0, 0 };
                expenseData = new ChartValues<double> { 0, 0, 0, 0, 0, 0 };
            }

            var incomeSeries = new LineSeries
            {
                Title = "Thu nhập",
                Values = incomeData,
                Stroke = Brush(0, 180, 140),
                StrokeThickness = 2.5,
                PointGeometrySize = 8,
                Fill = BrushA(25, 0, 180, 140),
                LineSmoothness = 0.8
            };
            var expensesSeries = new LineSeries
            {
                Title = "Chi tiêu",
                Values = expenseData,
                Stroke = Brush(181, 212, 34),
                StrokeThickness = 2.5,
                PointGeometrySize = 8,
                Fill = BrushA(25, 181, 212, 34),
                LineSmoothness = 0.8
            };

            chartWorkingCapital.Series = new SeriesCollection { incomeSeries, expensesSeries };
            chartWorkingCapital.AxisX.Add(new Axis
            {
                Labels = labels,
                Separator = new Separator { StrokeThickness = 0 },
                Foreground = Brush(160, 160, 160)
            });
            chartWorkingCapital.AxisY.Add(new Axis
            {
                LabelFormatter = v => (v / 1000).ToString("0") + "K",
                Separator = new Separator { StrokeThickness = 1, Stroke = BrushA(40, 0, 0, 0) },
                Foreground = Brush(160, 160, 160)
            });
            chartWorkingCapital.LegendLocation = LegendLocation.None;
            chartWorkingCapital.Zoom = ZoomingOptions.None;
            chartWorkingCapital.DisableAnimations = false;
        }

        private void lnkViewAllTrf_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            ShowAddTransferDialog();
        }

        private void ShowAddTransferDialog()
        {
            using (var dlg = new Form())
            {
                dlg.Text = "Thêm bill chuyển khoản";
                dlg.StartPosition = FormStartPosition.CenterParent;
                dlg.FormBorderStyle = FormBorderStyle.FixedDialog;
                dlg.ClientSize = new Size(360, 230);
                dlg.MaximizeBox = false;
                dlg.MinimizeBox = false;

                var lblType = new Label { Text = "Loại", Left = 20, Top = 20, Width = 80 };
                var cboType = new ComboBox { Left = 110, Top = 16, Width = 220, DropDownStyle = ComboBoxStyle.DropDownList };
                cboType.Items.AddRange(new object[] { "Income", "Expense" });
                cboType.SelectedIndex = 1;

                var lblAmount = new Label { Text = "Số tiền", Left = 20, Top = 60, Width = 80 };
                var txtAmount = new TextBox { Left = 110, Top = 56, Width = 220 };

                var lblNote = new Label { Text = "Ghi chú", Left = 20, Top = 100, Width = 80 };
                var txtNote = new TextBox { Left = 110, Top = 96, Width = 220 };

                var lblDate = new Label { Text = "Ngày", Left = 20, Top = 140, Width = 80 };
                var dtp = new DateTimePicker { Left = 110, Top = 136, Width = 220, Format = DateTimePickerFormat.Short, Value = DateTime.Now };

                var btnSave = new Button { Text = "Lưu", Left = 174, Top = 180, Width = 75, DialogResult = DialogResult.OK };
                var btnCancel = new Button { Text = "Hủy", Left = 255, Top = 180, Width = 75, DialogResult = DialogResult.Cancel };

                dlg.Controls.AddRange(new Control[] { lblType, cboType, lblAmount, txtAmount, lblNote, txtNote, lblDate, dtp, btnSave, btnCancel });
                dlg.AcceptButton = btnSave;
                dlg.CancelButton = btnCancel;

                if (dlg.ShowDialog(this) != DialogResult.OK) return;

                if (!decimal.TryParse(txtAmount.Text.Trim(), out var amount) || amount <= 0)
                {
                    MessageBox.Show("Số tiền không hợp lệ.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                var tx = new Transaction
                {
                    Amount = amount,
                    Type = cboType.Text,
                    Note = txtNote.Text.Trim(),
                    TransactionDate = dtp.Value,
                    CreatedAt = DateTime.Now,
                    CategoryId = 1, // Default expense/income category id
                    AccountId = 1, // Require binding to existing Wallet in SQLite
                    UserId = ServiceLocator.UserService.GetCurrentUser()?.Id ?? 1
                };

                var ok = ServiceLocator.TransactionService.Add(tx);
                if (!ok)
                {
                    MessageBox.Show("Không thể lưu bill chuyển khoản.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                LoadDashboardData();
                SetupChart();
                SetupTransactionGrid();
                MessageBox.Show("Đã thêm bill chuyển khoản.", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        // ══════════════════════════════════════════════
        // DATAGRIDVIEW
        // ══════════════════════════════════════════════
        private void SetupTransactionGrid()
        {
            dgvTransactions.Columns.Clear();
            dgvTransactions.Columns.Add(new DataGridViewTextBoxColumn
            {
                HeaderText = "TÊN / ĐƠN VỊ",
                Name = "colName",
                AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill,
                SortMode = DataGridViewColumnSortMode.NotSortable
            });
            dgvTransactions.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "LOẠI", Name = "colType", Width = 150, SortMode = DataGridViewColumnSortMode.NotSortable, DefaultCellStyle = { ForeColor = Color.FromArgb(130, 130, 130), Alignment = DataGridViewContentAlignment.MiddleCenter } });
            dgvTransactions.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "SỐ TIỀN", Name = "colAmount", Width = 160, SortMode = DataGridViewColumnSortMode.NotSortable, DefaultCellStyle = { Font = new Font("Segoe UI", 9.5f, FontStyle.Bold), Alignment = DataGridViewContentAlignment.MiddleCenter } });
            dgvTransactions.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "NGÀY", Name = "colDate", Width = 155, SortMode = DataGridViewColumnSortMode.NotSortable, DefaultCellStyle = { ForeColor = Color.FromArgb(130, 130, 130), Alignment = DataGridViewContentAlignment.MiddleCenter } });

            dgvTransactions.Rows.Clear();

            try
            {
                var rows = ServiceLocator.TransactionService.GetRecent(8);
                foreach (var tx in rows)
                {
                    bool isExpense = string.Equals(tx.Type, "Expense", StringComparison.OrdinalIgnoreCase);
                    string amount = (isExpense ? "- " : "+ ") + tx.Amount.ToString("N0") + " ₫";
                    string title = (string.IsNullOrWhiteSpace(tx.CategoryName) ? "Transaction" : tx.CategoryName)
                                   + "  •  "
                                   + (string.IsNullOrWhiteSpace(tx.Note) ? "-" : tx.Note);

                    dgvTransactions.Rows.Add(
                        title,
                        tx.Type,
                        amount,
                        tx.TransactionDate.ToString("dd MMM yyyy"));
                }
            }
            catch { }
        }

        // ══════════════════════════════════════════════
        // PAINT — TopBar
        // ══════════════════════════════════════════════
        private void pnlTopBar_Paint(object sender, PaintEventArgs e)
        {
            using (var pen = new Pen(Color.FromArgb(18, 0, 0, 0), 1))
                e.Graphics.DrawLine(pen, 0, pnlTopBar.Height - 1, pnlTopBar.Width, pnlTopBar.Height - 1);
        }

        // ══════════════════════════════════════════════
        // PAINT — Sidebar
        // ══════════════════════════════════════════════
        private void pnlSidebar_Paint(object sender, PaintEventArgs e)
        {
            int h = pnlSidebar.Height;
            using (var pen = new Pen(Color.FromArgb(40, 255, 255, 255), 1))
            {
                e.Graphics.DrawLine(pen, 16, 98, 204, 98);
                e.Graphics.DrawLine(pen, 16, h - 90, 204, h - 90);
            }
        }

        private void picSidebarLogo_Paint(object sender, PaintEventArgs e)
        {
            var g = e.Graphics;
            g.SmoothingMode = SmoothingMode.AntiAlias;
            int w = picSidebarLogo.Width, h = picSidebarLogo.Height;
            using (var bg = new SolidBrush(Accent)) g.FillEllipse(bg, 0, 0, w - 1, h - 1);
            using (var f = new Font("Segoe UI", 14f, FontStyle.Bold))
            using (var b = new SolidBrush(Color.FromArgb(22, 22, 22)))
                g.DrawString("F", f, b, new RectangleF(0, 0, w, h),
                    new StringFormat { Alignment = StringAlignment.Center, LineAlignment = StringAlignment.Center });
        }

        // ══════════════════════════════════════════════
        // PAINT — Avatar
        // ══════════════════════════════════════════════
        private void picAvatar_Paint(object sender, PaintEventArgs e)
        {
            var g = e.Graphics;
            g.SmoothingMode = SmoothingMode.AntiAlias;
            int w = picAvatar.Width, h = picAvatar.Height;
            using (var grd = new LinearGradientBrush(new Rectangle(0, 0, w, h), Accent, Teal, 45f))
                g.FillEllipse(grd, 0, 0, w - 1, h - 1);
            using (var f = new Font("Segoe UI", 12f, FontStyle.Bold))
                g.DrawString("U", f, Brushes.White, new RectangleF(0, 0, w, h),
                    new StringFormat { Alignment = StringAlignment.Center, LineAlignment = StringAlignment.Center });
        }

        // ══════════════════════════════════════════════
        // PAINT — Stat cards
        // ══════════════════════════════════════════════
        private void pnlCardBalance_Paint(object sender, PaintEventArgs e) => DrawStatCard(e.Graphics, pnlCardBalance.Width, pnlCardBalance.Height, true, "Tổng số dư", _totalBalance.ToString("N0") + " ₫", "💰");
        private void pnlCardSpending_Paint(object sender, PaintEventArgs e) => DrawStatCard(e.Graphics, pnlCardSpending.Width, pnlCardSpending.Height, false, "Tổng chi tiêu", _totalSpending.ToString("N0") + " ₫", "💸");
        private void pnlCardSaved_Paint(object sender, PaintEventArgs e) => DrawStatCard(e.Graphics, pnlCardSaved.Width, pnlCardSaved.Height, false, "Tổng tiết kiệm", _totalSaved.ToString("N0") + " ₫", "🏦");

        private void DrawStatCard(Graphics g, int w, int h, bool dark, string label, string value, string icon)
        {
            g.SmoothingMode = SmoothingMode.AntiAlias;
            var rect = new Rectangle(0, 0, w - 1, h - 1);
            using (var path = RoundedRect(rect, 16))
            {
                if (dark)
                {
                    using (var bg = new SolidBrush(DarkCard)) g.FillPath(bg, path);
                    using (var grd = new LinearGradientBrush(rect, Color.FromArgb(55, 181, 212, 34), Color.Transparent, 135f)) g.FillPath(grd, path);
                }
                else
                {
                    using (var bg = new SolidBrush(Color.White)) g.FillPath(bg, path);
                    using (var pen = new Pen(Color.FromArgb(10, 0, 0, 0), 1)) g.DrawPath(pen, path);
                }
            }
            var ir = new Rectangle(18, 16, 40, 40);
            using (var ib = new SolidBrush(dark ? Color.FromArgb(55, 181, 212, 34) : Color.FromArgb(30, 181, 212, 34))) g.FillEllipse(ib, ir);
            using (var ef = new Font("Segoe UI Emoji", 13f))
                g.DrawString(icon, ef, dark ? Brushes.White : new SolidBrush(Color.FromArgb(60, 60, 60)),
                    new RectangleF(ir.X, ir.Y, ir.Width, ir.Height), new StringFormat { Alignment = StringAlignment.Center, LineAlignment = StringAlignment.Center });
            using (var lf = new Font("Segoe UI", 8.5f))
            using (var lb = new SolidBrush(dark ? Color.FromArgb(160, 190, 210) : Color.FromArgb(140, 140, 140)))
                g.DrawString(label, lf, lb, new PointF(18, 64));
            using (var vf = new Font("Segoe UI", 14f, FontStyle.Bold))
            using (var vb = new SolidBrush(dark ? Color.White : Color.FromArgb(22, 22, 22)))
                g.DrawString(value, vf, vb, new PointF(14, 82));
        }

        // ══════════════════════════════════════════════
        // PAINT — White card panels
        // ══════════════════════════════════════════════
        private void pnlWhiteCard_Paint(object sender, PaintEventArgs e)
        {
            var pnl = (Panel)sender;
            var g = e.Graphics;
            g.SmoothingMode = SmoothingMode.AntiAlias;
            var rect = new Rectangle(0, 0, pnl.Width - 1, pnl.Height - 1);
            using (var path = RoundedRect(rect, 16))
            {
                using (var bg = new SolidBrush(Color.White)) g.FillPath(bg, path);
                using (var pen = new Pen(Color.FromArgb(10, 0, 0, 0), 1)) g.DrawPath(pen, path);
            }
        }

        // ══════════════════════════════════════════════
        // PAINT — Wallet cards
        // ══════════════════════════════════════════════
        private void pnlCard1_Paint(object sender, PaintEventArgs e)
        {
            var g = e.Graphics; g.SmoothingMode = SmoothingMode.AntiAlias;
            int w = pnlCard1.Width, h = pnlCard1.Height;
            var rect = new Rectangle(0, 0, w - 1, h - 1);
            using (var path = RoundedRect(rect, 18))
            {
                using (var grd = new LinearGradientBrush(rect, Color.FromArgb(38, 42, 56), Color.FromArgb(22, 26, 36), 135f)) g.FillPath(grd, path);
                using (var c = new SolidBrush(Color.FromArgb(18, 255, 255, 255))) { g.FillEllipse(c, w - 80, -25, 120, 120); g.FillEllipse(c, w - 50, 45, 85, 85); }
                using (var f = new Font("Segoe UI", 10f, FontStyle.Bold)) using (var b = new SolidBrush(Color.White)) g.DrawString("FinancialApp.", f, b, new PointF(16, 14));
                using (var f = new Font("Segoe UI", 8f)) using (var b = new SolidBrush(Color.FromArgb(150, 190, 210))) g.DrawString("Universal Bank", f, b, new PointF(140, 17));
                using (var f = new Font("Courier New", 12f, FontStyle.Bold)) using (var b = new SolidBrush(Color.White)) g.DrawString("5495  7381  3759  2321", f, b, new PointF(16, 82));
                using (var pen = new Pen(Color.FromArgb(170, 255, 255, 255), 2))
                { g.DrawArc(pen, w - 46, 14, 20, 20, -90, 180); g.DrawArc(pen, w - 38, 18, 12, 12, -90, 180); g.DrawArc(pen, w - 30, 22, 6, 6, -90, 180); }
            }
        }

        private void pnlCard2_Paint(object sender, PaintEventArgs e)
        {
            var g = e.Graphics; g.SmoothingMode = SmoothingMode.AntiAlias;
            int w = pnlCard2.Width, h = pnlCard2.Height;
            var rect = new Rectangle(0, 0, w - 1, h - 1);
            using (var path = RoundedRect(rect, 18))
            {
                using (var bg = new SolidBrush(Color.FromArgb(240, 242, 246))) g.FillPath(bg, path);
                using (var b1 = new SolidBrush(Color.FromArgb(80, 181, 212, 34))) g.FillEllipse(b1, w - 75, -18, 95, 95);
                using (var b2 = new SolidBrush(Color.FromArgb(70, 255, 100, 80))) g.FillEllipse(b2, w - 44, 12, 65, 65);
                using (var f = new Font("Segoe UI", 10f, FontStyle.Bold)) using (var b = new SolidBrush(Color.FromArgb(40, 40, 40))) g.DrawString("FinancialApp.", f, b, new PointF(16, 14));
                using (var f = new Font("Segoe UI", 8f)) using (var b = new SolidBrush(Color.FromArgb(120, 120, 120))) g.DrawString("Commercial Bank", f, b, new PointF(140, 17));
                using (var f = new Font("Courier New", 12f, FontStyle.Bold)) using (var b = new SolidBrush(Color.FromArgb(50, 50, 50))) g.DrawString("85952548  ****", f, b, new PointF(16, 62));
                using (var f = new Font("Segoe UI", 8f)) using (var b = new SolidBrush(Color.FromArgb(120, 120, 120))) g.DrawString("09/25", f, b, new PointF(16, 90));
                using (var f = new Font("Arial", 11f, FontStyle.Bold | FontStyle.Italic)) using (var b = new SolidBrush(Color.FromArgb(26, 31, 113))) g.DrawString("VISA", f, b, new PointF(w - 56, h - 36));
                using (var pen = new Pen(Color.FromArgb(100, 50, 50, 50), 2))
                { int nx = w - 46, ny = 52; g.DrawArc(pen, nx, ny, 20, 20, -90, 180); g.DrawArc(pen, nx + 8, ny + 4, 12, 12, -90, 180); g.DrawArc(pen, nx + 16, ny + 8, 6, 6, -90, 180); }
            }
        }

        // ══════════════════════════════════════════════
        // PAINT — Transfer list
        // ══════════════════════════════════════════════
        private void pnlTransferList_Paint(object sender, PaintEventArgs e)
        {
            var g = e.Graphics; g.SmoothingMode = SmoothingMode.AntiAlias;
            var data = _recentTransfers ?? new List<TransferItem>();

            if (data.Count == 0)
            {
                using (var f = new Font("Segoe UI", 9.5f))
                using (var b = new SolidBrush(Color.FromArgb(150, 150, 150)))
                    g.DrawString("Chưa có giao dịch", f, b, new PointF(8, 12));
                return;
            }

            int rowH = 72, lw = pnlTransferList.Width;
            for (int i = 0; i < data.Count; i++)
            {
                int y = i * rowH;
                var ar = new Rectangle(0, y + 14, 40, 40);
                using (var grd = new LinearGradientBrush(ar, Accent, Teal, 45f)) g.FillEllipse(grd, ar);
                using (var f = new Font("Segoe UI", 11f, FontStyle.Bold))
                    g.DrawString(data[i].Name.Substring(0, 1), f, Brushes.White, new RectangleF(ar.X, ar.Y, ar.Width, ar.Height),
                        new StringFormat { Alignment = StringAlignment.Center, LineAlignment = StringAlignment.Center });
                using (var f = new Font("Segoe UI", 9.5f, FontStyle.Bold)) using (var b = new SolidBrush(Color.FromArgb(35, 35, 35))) g.DrawString(data[i].Name, f, b, new PointF(50, y + 16));
                string dateText = data[i].Date.ToString("dd MMM yyyy 'lúc' HH:mm");
                using (var f = new Font("Segoe UI", 8f))
                using (var b = new SolidBrush(Color.FromArgb(150, 150, 150)))
                    g.DrawString(dateText, f, b, new PointF(50, y + 36));

                string amountText = (data[i].IsExpense ? "- " : "+ ") + data[i].Amount.ToString("N0") + " ₫";
                Color amountColor = data[i].IsExpense ? Color.FromArgb(200, 60, 60) : Color.FromArgb(25, 135, 84);
                using (var f = new Font("Segoe UI", 9.5f, FontStyle.Bold))
                using (var b = new SolidBrush(amountColor))
                    g.DrawString(amountText, f, b, new PointF(lw - 120, y + 24));

                if (i < data.Count - 1) using (var pen = new Pen(Color.FromArgb(18, 0, 0, 0), 1)) g.DrawLine(pen, 0, y + rowH - 1, lw, y + rowH - 1);
            }
        }

        // ══════════════════════════════════════════════
        // HELPER
        // ══════════════════════════════════════════════
        private static GraphicsPath RoundedRect(Rectangle r, int rad)
        {
            var p = new GraphicsPath(); int d = rad * 2;
            p.AddArc(r.X, r.Y, d, d, 180, 90);
            p.AddArc(r.Right - d, r.Y, d, d, 270, 90);
            p.AddArc(r.Right - d, r.Bottom - d, d, d, 0, 90);
            p.AddArc(r.X, r.Bottom - d, d, d, 90, 90);
            p.CloseFigure(); return p;
        }

        private static System.Windows.Media.SolidColorBrush Brush(byte r, byte g, byte b)
            => new System.Windows.Media.SolidColorBrush(System.Windows.Media.Color.FromRgb(r, g, b));
        private static System.Windows.Media.SolidColorBrush BrushA(byte a, byte r, byte g, byte b)
            => new System.Windows.Media.SolidColorBrush(System.Windows.Media.Color.FromArgb(a, r, g, b));

        // ══════════════════════════════════════════════
        // NAVIGATION
        // ══════════════════════════════════════════════
        private void NavigateTo(string page)
        {
            switch (page)
            {
                case "transactions":
                    PersonalFinanceManager.UI.Navigation.FormNavigator.GoToTransactions();
                    break;
                case "invoices":
                    PersonalFinanceManager.UI.Navigation.FormNavigator.GoToInvoices();
                    break;
                case "wallets":
                    PersonalFinanceManager.UI.Navigation.FormNavigator.GoToMyWallet();
                    break;
                case "settings":
                    PersonalFinanceManager.UI.Navigation.FormNavigator.GoToSettings();
                    break;
                case "dashboard":
                default:
                    SetActiveNav("dashboard");
                    break;
            }
        }

        private void SetActiveNav(string active)
        {
            var accentColor = Color.FromArgb(181, 212, 34);
            var darkText = Color.FromArgb(22, 22, 22);
            var transparent = Color.Transparent;
            var grayText = Color.FromArgb(155, 160, 170);

            btnNavDashboard.FillColor = active == "dashboard" ? accentColor : transparent;
            btnNavDashboard.ForeColor = active == "dashboard" ? darkText : grayText;
            btnNavTransactions.FillColor = active == "transactions" ? accentColor : transparent;
            btnNavTransactions.ForeColor = active == "transactions" ? darkText : grayText;
            btnNavInvoices.FillColor = active == "invoices" ? accentColor : transparent;
            btnNavInvoices.ForeColor = active == "invoices" ? darkText : grayText;
            btnNavWallets.FillColor = active == "wallets" ? accentColor : transparent;
            btnNavWallets.ForeColor = active == "wallets" ? darkText : grayText;
            btnNavSettings.FillColor = active == "settings" ? accentColor : transparent;
            btnNavSettings.ForeColor = active == "settings" ? darkText : grayText;
        }

        // ══════════════════════════════════════════════
        // EVENTS
        // ══════════════════════════════════════════════
        private void btnClose_Click(object sender, EventArgs e) => Application.Exit();
        private void btnMinimize_Click(object sender, EventArgs e) => this.WindowState = FormWindowState.Minimized;
        private void btnMaximize_Click(object sender, EventArgs e)
            => this.WindowState = this.WindowState == FormWindowState.Maximized
                ? FormWindowState.Normal
                : FormWindowState.Maximized;

        private void btnNavLogout_Click(object sender, EventArgs e)
        {
            ServiceLocator.UserService.Logout();
            PersonalFinanceManager.UI.Navigation.FormNavigator.GoToLogin();
        }

        // Stub: nếu Designer cũ có pnlChartLegend thì method này tránh CS1061
        private void pnlChartLegend_Paint(object sender, System.Windows.Forms.PaintEventArgs e) { }
    }
}