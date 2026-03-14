using PersonalFinanceManager.Infrastructure.DI;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Windows.Forms;

namespace PersonalFinanceManager.Forms.Transactions
{
    public partial class TransactionListForm : Form
    {
        // ── Mock data ──────────────────────────────────────────
        private class TransactionRow
        {
            public string Icon { get; set; }  // first letter for avatar
            public Color IconColor { get; set; }
            public string Name { get; set; }
            public string Business { get; set; }
            public string Type { get; set; }
            public decimal Amount { get; set; }
            public DateTime Date { get; set; }
            public string InvoiceId { get; set; }
        }

        private List<TransactionRow> _allRows;
        private List<TransactionRow> _filteredRows;

        // ── Constructor ────────────────────────────────────────
        public TransactionListForm()
        {
            InitializeComponent();
            LoadDataByCurrentUser();
            SetupGrid();
            BindGrid(_allRows);
        }

        // ── Load event ─────────────────────────────────────────
        private void TransactionListForm_Load(object sender, EventArgs e)
        {
            try
            {
                var user = ServiceLocator.UserService.GetCurrentUser();
                if (user != null)
                    lblUsername.Text = user.FullName ?? user.Email ?? "Người dùng";
            }
            catch { }

            LayoutTopBarButtons();
            LayoutSidebarBottomButtons();
            ResizeTableArea();
        }

        // =====================================================
        // USER DATA
        // =====================================================
        private void LoadDataByCurrentUser()
        {
            _allRows = new List<TransactionRow>();

            try
            {
                var txs = ServiceLocator.TransactionService
                    .GetByDateRange(DateTime.MinValue.AddYears(1), DateTime.MaxValue.AddYears(-1))
                    .OrderByDescending(t => t.TransactionDate)
                    .ToList();

                foreach (var tx in txs)
                {
                    var isExpense = string.Equals(tx.Type, "Expense", StringComparison.OrdinalIgnoreCase);
                    var name = string.IsNullOrWhiteSpace(tx.CategoryName) ? "Transaction" : tx.CategoryName;
                    var business = string.IsNullOrWhiteSpace(tx.Note) ? "-" : tx.Note;

                    _allRows.Add(new TransactionRow
                    {
                        Icon = name.Substring(0, 1),
                        IconColor = isExpense ? Color.FromArgb(211, 47, 47) : Color.FromArgb(46, 125, 50),
                        Name = name,
                        Business = business,
                        Type = tx.Type,
                        Amount = isExpense ? -Math.Abs(tx.Amount) : Math.Abs(tx.Amount),
                        Date = tx.TransactionDate,
                        InvoiceId = "TX" + tx.Id.ToString("000000")
                    });
                }
            }
            catch
            {
                // keep empty list on load failure
            }

            _filteredRows = new List<TransactionRow>(_allRows);
        }

        // =====================================================
        // GRID SETUP
        // =====================================================
        private void SetupGrid()
        {
            dgvTransactions.Columns.Clear();

            var colIcon = new DataGridViewTextBoxColumn
            {
                Name = "colIcon",
                HeaderText = "",
                Width = 52,
                ReadOnly = true,
                Resizable = DataGridViewTriState.False,
                SortMode = DataGridViewColumnSortMode.NotSortable,
            };
            colIcon.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            var colName = new DataGridViewTextBoxColumn
            {
                Name = "colName",
                HeaderText = "TÊN / ĐƠN VỊ",
                AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill,
                ReadOnly = true,
                SortMode = DataGridViewColumnSortMode.Automatic,
            };

            var colType = new DataGridViewTextBoxColumn
            {
                Name = "colType",
                HeaderText = "LOẠI",
                Width = 140,
                ReadOnly = true,
                SortMode = DataGridViewColumnSortMode.Automatic,
            };
            colType.DefaultCellStyle.ForeColor = Color.FromArgb(140, 140, 140);

            var colAmount = new DataGridViewTextBoxColumn
            {
                Name = "colAmount",
                HeaderText = "SỐ TIỀN",
                Width = 150,
                ReadOnly = true,
                SortMode = DataGridViewColumnSortMode.Automatic,
            };
            colAmount.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            colAmount.DefaultCellStyle.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);

            var colDate = new DataGridViewTextBoxColumn
            {
                Name = "colDate",
                HeaderText = "NGÀY",
                Width = 160,
                ReadOnly = true,
                SortMode = DataGridViewColumnSortMode.Automatic,
            };
            colDate.DefaultCellStyle.ForeColor = Color.FromArgb(80, 80, 80);

            var colInvoice = new DataGridViewTextBoxColumn
            {
                Name = "colInvoice",
                HeaderText = "MÃ HÓA ĐƠN",
                Width = 150,
                ReadOnly = true,
                SortMode = DataGridViewColumnSortMode.Automatic,
            };
            colInvoice.DefaultCellStyle.ForeColor = Color.FromArgb(150, 150, 150);

            var colAction = new DataGridViewButtonColumn
            {
                Name = "colAction",
                HeaderText = "THAO TÁC",
                Width = 110,
                Text = "Xem",
                UseColumnTextForButtonValue = true,
                FlatStyle = FlatStyle.Flat,
            };
            colAction.DefaultCellStyle.BackColor = Color.FromArgb(181, 212, 34);
            colAction.DefaultCellStyle.ForeColor = Color.FromArgb(22, 22, 22);
            colAction.DefaultCellStyle.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            colAction.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            colAction.DefaultCellStyle.SelectionBackColor = Color.FromArgb(158, 190, 20);
            colAction.DefaultCellStyle.SelectionForeColor = Color.FromArgb(22, 22, 22);

            dgvTransactions.Columns.AddRange(colIcon, colName, colType, colAmount, colDate, colInvoice, colAction);

            dgvTransactions.CellPainting += DgvTransactions_CellPainting;
            dgvTransactions.CellFormatting += DgvTransactions_CellFormatting;
            dgvTransactions.CellClick += DgvTransactions_CellClick;
        }

        private void BindGrid(List<TransactionRow> rows)
        {
            dgvTransactions.Rows.Clear();
            foreach (var r in rows)
            {
                string amountStr = r.Amount >= 0
                    ? string.Format("{0:N0} đ", r.Amount)
                    : string.Format("- {0:N0} đ", Math.Abs(r.Amount));

                string dateStr = r.Date.ToString("dd MMM yyyy\n'lúc' HH:mm");

                int idx = dgvTransactions.Rows.Add(
                    r.Icon.ToUpper(), r.Name + "\n" + r.Business,
                    r.Type, amountStr, dateStr, r.InvoiceId, "Xem");
                dgvTransactions.Rows[idx].Tag = r;
            }
        }

        // =====================================================
        // CELL PAINTING
        // =====================================================
        private void DgvTransactions_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex < 0) return;
            var row = dgvTransactions.Rows[e.RowIndex].Tag as TransactionRow;
            if (row == null) return;

            if (e.ColumnIndex == 0 || e.ColumnIndex == 1 || e.ColumnIndex == 4 || e.ColumnIndex == 6)
            {
                bool selected = dgvTransactions.Rows[e.RowIndex].Selected;
                Color bgColor = selected ? Color.FromArgb(240, 248, 230) : Color.White;
                e.Graphics.FillRectangle(new SolidBrush(bgColor), e.CellBounds);
                using (var pen = new Pen(Color.FromArgb(235, 237, 242)))
                    e.Graphics.DrawLine(pen, e.CellBounds.Left, e.CellBounds.Bottom - 1, e.CellBounds.Right, e.CellBounds.Bottom - 1);
                e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;

                if (e.ColumnIndex == 0)
                {
                    int d = 36, cx = e.CellBounds.X + (e.CellBounds.Width - d) / 2, cy = e.CellBounds.Y + (e.CellBounds.Height - d) / 2;
                    using (var brush = new SolidBrush(row.IconColor)) e.Graphics.FillEllipse(brush, cx, cy, d, d);
                    using (var sf = new StringFormat { Alignment = StringAlignment.Center, LineAlignment = StringAlignment.Center })
                    using (var font = new Font("Segoe UI", 12F, FontStyle.Bold))
                        e.Graphics.DrawString(row.Icon.ToUpper(), font, Brushes.White, new RectangleF(cx, cy, d, d), sf);
                }
                else if (e.ColumnIndex == 1)
                {
                    int px = e.CellBounds.X + 10, midY = e.CellBounds.Y + e.CellBounds.Height / 2;
                    using (var fName = new Font("Segoe UI", 9.5F, FontStyle.Bold))
                    using (var fBiz = new Font("Segoe UI", 8.5F))
                    using (var bName = new SolidBrush(Color.FromArgb(30, 30, 30)))
                    using (var bBiz = new SolidBrush(Color.FromArgb(155, 155, 155)))
                    { e.Graphics.DrawString(row.Name, fName, bName, px, midY - 18); e.Graphics.DrawString(row.Business, fBiz, bBiz, px, midY + 2); }
                }
                else if (e.ColumnIndex == 4)
                {
                    int px = e.CellBounds.X + 10, midY = e.CellBounds.Y + e.CellBounds.Height / 2;
                    using (var fDate = new Font("Segoe UI", 9.5F, FontStyle.Bold))
                    using (var fTime = new Font("Segoe UI", 8.5F))
                    using (var bDate = new SolidBrush(Color.FromArgb(30, 30, 30)))
                    using (var bTime = new SolidBrush(Color.FromArgb(155, 155, 155)))
                    { e.Graphics.DrawString(row.Date.ToString("dd MMM yyyy"), fDate, bDate, px, midY - 18); e.Graphics.DrawString("lúc " + row.Date.ToString("HH:mm"), fTime, bTime, px, midY + 2); }
                }
                else if (e.ColumnIndex == 6)
                {
                    int bw = 72, bh = 34, bx = e.CellBounds.X + (e.CellBounds.Width - bw) / 2, by = e.CellBounds.Y + (e.CellBounds.Height - bh) / 2;
                    var rect = new Rectangle(bx, by, bw, bh);
                    using (var path = RoundedRect(rect, 8)) using (var brush = new SolidBrush(Color.FromArgb(181, 212, 34))) e.Graphics.FillPath(brush, path);
                    using (var sf = new StringFormat { Alignment = StringAlignment.Center, LineAlignment = StringAlignment.Center })
                    using (var font = new Font("Segoe UI", 9F, FontStyle.Bold))
                        e.Graphics.DrawString("Xem", font, new SolidBrush(Color.FromArgb(22, 22, 22)), rect, sf);
                }
                e.Handled = true;
            }
        }

        private void DgvTransactions_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex != 3) return;
            var row = dgvTransactions.Rows[e.RowIndex].Tag as TransactionRow;
            if (row == null) return;
            e.CellStyle.ForeColor = row.Amount < 0 ? Color.FromArgb(220, 53, 69) : Color.FromArgb(25, 135, 84);
            e.CellStyle.SelectionForeColor = e.CellStyle.ForeColor;
        }

        private void DgvTransactions_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex != 6) return;
            var row = dgvTransactions.Rows[e.RowIndex].Tag as TransactionRow;
            if (row == null) return;
            MessageBox.Show(
                string.Format("Mã hóa đơn: {0}\nSố tiền: {1:N0} đ\nNgày: {2:dd/MM/yyyy}", row.InvoiceId, row.Amount, row.Date),
                "Chi tiết giao dịch", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        // =====================================================
        // SEARCH
        // =====================================================
        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            string q = txtSearch.Text.Trim().ToLower();
            _filteredRows = string.IsNullOrEmpty(q)
                ? new List<TransactionRow>(_allRows)
                : _allRows.Where(r =>
                    r.Name.ToLower().Contains(q) || r.Business.ToLower().Contains(q) ||
                    r.Type.ToLower().Contains(q) || r.InvoiceId.ToLower().Contains(q)
                  ).ToList();
            BindGrid(_filteredRows);
        }

        // =====================================================
        // LAYOUT
        // =====================================================
        private void TransactionListForm_SizeChanged(object sender, EventArgs e)
        {
            LayoutTopBarButtons();
            LayoutSidebarBottomButtons();
            ResizeTableArea();
        }

        private void LayoutTopBarButtons()
        {
            int tbW = pnlTopBar.Width, btnY = (pnlTopBar.Height - 30) / 2;
            btnClose.Location = new Point(tbW - 40, btnY);
            btnMaximize.Location = new Point(tbW - 74, btnY);
            btnMinimize.Location = new Point(tbW - 108, btnY);
            lblUsername.Location = new Point(tbW - 224, (pnlTopBar.Height - lblUsername.Height) / 2 + 1);
            picAvatar.Location = new Point(tbW - 264, (pnlTopBar.Height - 36) / 2);
        }

        private void LayoutSidebarBottomButtons()
        {
            int sH = pnlSidebar.Height;
            btnNavLogout.Location = new Point(10, sH - 48);
            btnNavHelp.Location = new Point(10, sH - 96);
            pnlSidebar.Invalidate();
        }

        private void ResizeTableArea()
        {
            int pad = pnlMain.Padding.Left;
            int avail = pnlMain.ClientSize.Width - pad * 2;
            int high = pnlMain.ClientSize.Height - pad - 62 - 20;
            pnlSearchBar.Width = Math.Min(420, avail);
            pnlTableArea.Width = avail;
            pnlTableArea.Height = Math.Max(200, high);
            dgvTransactions.Size = new Size(pnlTableArea.Width, pnlTableArea.Height);
        }

        // =====================================================
        // NAVIGATION — dùng FormNavigator, không tạo form mới
        // =====================================================
        private void btnNavDashboard_Click(object sender, EventArgs e)
        {
            PersonalFinanceManager.UI.Navigation.FormNavigator.GoToDashboard();
        }

        private void btnNavLogout_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có muốn đăng xuất không?", "Đăng xuất",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                ServiceLocator.UserService.Logout();
                PersonalFinanceManager.UI.Navigation.FormNavigator.GoToLogin();
            }
        }

        // =====================================================
        // WINDOW CONTROLS
        // =====================================================
        private void btnClose_Click(object sender, EventArgs e) => Application.Exit();
        private void btnMinimize_Click(object sender, EventArgs e) => this.WindowState = FormWindowState.Minimized;
        private void btnMaximize_Click(object sender, EventArgs e)
            => this.WindowState = this.WindowState == FormWindowState.Maximized
                ? FormWindowState.Normal : FormWindowState.Maximized;

        // =====================================================
        // PAINT HANDLERS
        // =====================================================
        private void pnlSidebar_Paint(object sender, PaintEventArgs e)
        {
            using (var pen = new Pen(Color.FromArgb(38, 255, 255, 255), 1))
            {
                e.Graphics.DrawLine(pen, 16, 96, 244, 96);
                int divY = btnNavHelp.Top - 8;
                e.Graphics.DrawLine(pen, 16, divY, 244, divY);
            }
        }

        private void picSidebarLogo_Paint(object sender, PaintEventArgs e)
        {
            var g = e.Graphics; g.SmoothingMode = SmoothingMode.AntiAlias;
            using (var brush = new SolidBrush(Color.FromArgb(181, 212, 34))) g.FillEllipse(brush, 0, 0, 38, 38);
            using (var font = new Font("Segoe UI", 15F, FontStyle.Bold))
            using (var sf = new StringFormat { Alignment = StringAlignment.Center, LineAlignment = StringAlignment.Center })
                g.DrawString("F", font, new SolidBrush(Color.FromArgb(22, 22, 22)), new RectangleF(0, 0, 38, 38), sf);
        }

        private void picAvatar_Paint(object sender, PaintEventArgs e)
        {
            var g = e.Graphics; g.SmoothingMode = SmoothingMode.AntiAlias;
            using (var brush = new SolidBrush(Color.FromArgb(40, 167, 69))) g.FillEllipse(brush, 0, 0, 36, 36);
            using (var font = new Font("Segoe UI", 14F, FontStyle.Bold))
            using (var sf = new StringFormat { Alignment = StringAlignment.Center, LineAlignment = StringAlignment.Center })
                g.DrawString("N", font, Brushes.White, new RectangleF(0, 0, 36, 36), sf);
        }

        private void pnlTopBar_Paint(object sender, PaintEventArgs e)
        {
            using (var pen = new Pen(Color.FromArgb(225, 227, 232), 1))
                e.Graphics.DrawLine(pen, 0, pnlTopBar.Height - 1, pnlTopBar.Width, pnlTopBar.Height - 1);
        }

        private void pnlWhiteCard_Paint(object sender, PaintEventArgs e)
        {
            var g = e.Graphics; g.SmoothingMode = SmoothingMode.AntiAlias;
            var ctrl = (Control)sender;
            var rect = new Rectangle(0, 0, ctrl.Width - 1, ctrl.Height - 1);
            using (var path = RoundedRect(rect, 14))
            {
                using (var brush = new SolidBrush(Color.White)) g.FillPath(brush, path);
                using (var pen = new Pen(Color.FromArgb(228, 230, 236), 1)) g.DrawPath(pen, path);
            }
        }

        // =====================================================
        // HELPER
        // =====================================================
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
    }
}