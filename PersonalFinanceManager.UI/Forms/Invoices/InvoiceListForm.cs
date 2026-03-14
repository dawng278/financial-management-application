using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Windows.Forms;
using PersonalFinanceManager.Common.Helpers;

namespace PersonalFinanceManager.Forms.Invoices
{
    public partial class InvoiceListForm : Form
    {
        // ── Model ─────────────────────────────────────────────────────────────────
        public class InvoiceRow
        {
            public string IconLetter { get; set; }
            public Color IconColor { get; set; }
            public string Name { get; set; }
            public string InvNum { get; set; }
            public DateTime Date { get; set; }
            public string OrderType { get; set; }
            public decimal Amount { get; set; }
            public string Status { get; set; }   // Paid | Pending | Unpaid
        }

        // ── Status colours ────────────────────────────────────────────────────────
        private static readonly Color PaidBg = Color.FromArgb(218, 248, 232);
        private static readonly Color PaidFg = Color.FromArgb(22, 155, 85);
        private static readonly Color PendingBg = Color.FromArgb(255, 238, 215);
        private static readonly Color PendingFg = Color.FromArgb(195, 110, 18);
        private static readonly Color UnpaidBg = Color.FromArgb(255, 225, 225);
        private static readonly Color UnpaidFg = Color.FromArgb(195, 45, 45);

        // ── State ─────────────────────────────────────────────────────────────────
        private List<InvoiceRow> _all = new List<InvoiceRow>();
        private List<InvoiceRow> _filtered = new List<InvoiceRow>();

        // ── Filter panel (built at runtime) ───────────────────────────────────────
        private Panel _pnlFilter;
        private ComboBox _cboStatus, _cboType, _cboSort;
        private bool _filterOpen = false;

        // ── Constructor ───────────────────────────────────────────────────────────
        public InvoiceListForm()
        {
            InitializeComponent();
            LoadFromDatabase();
            BuildColumns();
            BuildFilterPanel();
            Bind(_all);

            this.Load += InvoiceListForm_Load;
            this.SizeChanged += InvoiceListForm_SizeChanged;
        }

        // =====================================================================
        // LOAD
        // =====================================================================
        private void InvoiceListForm_Load(object sender, EventArgs e)
        {
            try
            {
                var u = Infrastructure.DI.ServiceLocator.UserService.GetCurrentUser();
                if (u != null) lblUsername.Text = u.FullName ?? u.Email ?? "Admin";
            }
            catch { }

            LayoutTopBar();
            LayoutSidebarBottom();
            ResizeContent();
        }

        // =====================================================================
        // DATA
        // =====================================================================
        private void LoadFromDatabase()
        {
            _all = new List<InvoiceRow>();

            int currentUserId = ResolveCurrentUserId();
            if (currentUserId <= 0)
            {
                _filtered = new List<InvoiceRow>(_all);
                return;
            }

            var db = new DbHelper();
            using (var conn = db.CreateConnection())
            {
                conn.Open();
                using (var cmd = (SQLiteCommand)conn.CreateCommand())
                {
                    cmd.CommandText = @"SELECT InvoiceNumber, ClientName, InvoiceDate, OrderType, Amount, Status
                                        FROM Invoices
                                        WHERE UserId = @uid
                                        ORDER BY datetime(CreatedAt) DESC";
                    cmd.Parameters.AddWithValue("@uid", currentUserId);

                    using (var r = cmd.ExecuteReader())
                    {
                        while (r.Read())
                        {
                            var name = r["ClientName"].ToString();
                            _all.Add(new InvoiceRow
                            {
                                IconLetter = string.IsNullOrWhiteSpace(name) ? "?" : name.Substring(0, 1).ToUpper(),
                                IconColor = Color.FromArgb(55, 125, 200),
                                Name = name,
                                InvNum = r["InvoiceNumber"].ToString(),
                                Date = DateTime.TryParse(r["InvoiceDate"].ToString(), out var d) ? d : DateTime.Now,
                                OrderType = r["OrderType"].ToString(),
                                Amount = Convert.ToDecimal(r["Amount"]),
                                Status = r["Status"].ToString()
                            });
                        }
                    }
                }
            }

            _filtered = new List<InvoiceRow>(_all);
        }

        private int ResolveCurrentUserId()
        {
            try
            {
                var u = Infrastructure.DI.ServiceLocator.UserService.GetCurrentUser();
                if (u != null && u.Id > 0) return u.Id;
            }
            catch { }

            return PersonalFinanceManager.Common.Mock.MockUserService.CurrentUserId;
        }

        // =====================================================================
        // BUILD COLUMNS
        // =====================================================================
        private void BuildColumns()
        {
            dgvInvoices.Columns.Clear();

            dgvInvoices.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "cAvatar",
                HeaderText = "",
                Width = 62,
                ReadOnly = true,
                Resizable = DataGridViewTriState.False,
                SortMode = DataGridViewColumnSortMode.NotSortable
            });
            dgvInvoices.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "cName",
                HeaderText = "NAME/CLIENT",
                AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill,
                ReadOnly = true,
                SortMode = DataGridViewColumnSortMode.Automatic
            });
            dgvInvoices.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "cDate",
                HeaderText = "DATE",
                Width = 158,
                ReadOnly = true,
                SortMode = DataGridViewColumnSortMode.Automatic
            });

            var cOrder = new DataGridViewTextBoxColumn
            {
                Name = "cOrder",
                HeaderText = "ORDERS/TYPE",
                Width = 150,
                ReadOnly = true,
                SortMode = DataGridViewColumnSortMode.Automatic
            };
            cOrder.DefaultCellStyle.ForeColor = Color.FromArgb(148, 153, 172);
            cOrder.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            cOrder.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvInvoices.Columns.Add(cOrder);

            var cAmount = new DataGridViewTextBoxColumn
            {
                Name = "cAmount",
                HeaderText = "AMOUNT",
                Width = 130,
                ReadOnly = true,
                SortMode = DataGridViewColumnSortMode.Automatic
            };
            cAmount.DefaultCellStyle.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            cAmount.DefaultCellStyle.ForeColor = Color.FromArgb(22, 24, 35);
            dgvInvoices.Columns.Add(cAmount);

            var cStatus = new DataGridViewTextBoxColumn
            {
                Name = "cStatus",
                HeaderText = "STATUS",
                Width = 130,
                ReadOnly = true,
                SortMode = DataGridViewColumnSortMode.Automatic
            };
            cStatus.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            cStatus.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvInvoices.Columns.Add(cStatus);

            var cAction = new DataGridViewTextBoxColumn
            {
                Name = "cAction",
                HeaderText = "ACTION",
                Width = 90,
                ReadOnly = true,
                SortMode = DataGridViewColumnSortMode.NotSortable
            };
            cAction.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            cAction.DefaultCellStyle.ForeColor = Color.FromArgb(95, 155, 235);
            cAction.DefaultCellStyle.Font = new Font("Segoe UI", 13F, FontStyle.Bold);
            cAction.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvInvoices.Columns.Add(cAction);

            dgvInvoices.CellPainting += Dgv_CellPainting;
            dgvInvoices.CellClick += Dgv_CellClick;
        }

        // =====================================================================
        // BIND
        // =====================================================================
        private void Bind(List<InvoiceRow> rows)
        {
            dgvInvoices.Rows.Clear();
            foreach (var r in rows)
            {
                int i = dgvInvoices.Rows.Add(
                    r.IconLetter, "", "", r.OrderType,
                    "$" + r.Amount.ToString("0.00"),
                    r.Status, "···");
                dgvInvoices.Rows[i].Tag = r;
            }
        }

        // =====================================================================
        // CELL PAINTING
        // =====================================================================
        private void Dgv_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            if (e.RowIndex < 0) return;
            var row = dgvInvoices.Rows[e.RowIndex].Tag as InvoiceRow;
            if (row == null) return;

            bool sel = dgvInvoices.Rows[e.RowIndex].Selected;
            Color bg = sel ? Color.FromArgb(246, 252, 230) : Color.White;

            bool custom = e.ColumnIndex == 0 || e.ColumnIndex == 1 ||
                          e.ColumnIndex == 2 || e.ColumnIndex == 5 || e.ColumnIndex == 6;
            if (!custom) return;

            e.Graphics.FillRectangle(new SolidBrush(bg), e.CellBounds);
            using (var pen = new Pen(Color.FromArgb(238, 240, 248)))
                e.Graphics.DrawLine(pen,
                    e.CellBounds.Left, e.CellBounds.Bottom - 1,
                    e.CellBounds.Right, e.CellBounds.Bottom - 1);

            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
            e.Graphics.TextRenderingHint = System.Drawing.Text.TextRenderingHint.ClearTypeGridFit;

            int midY = e.CellBounds.Y + e.CellBounds.Height / 2;

            if (e.ColumnIndex == 0)
            {
                int d = 42, cx = e.CellBounds.X + (e.CellBounds.Width - d) / 2, cy = midY - d / 2;
                using (var b = new SolidBrush(row.IconColor))
                    e.Graphics.FillEllipse(b, cx, cy, d, d);
                using (var f = new Font("Segoe UI", 13F, FontStyle.Bold))
                using (var sf = new StringFormat { Alignment = StringAlignment.Center, LineAlignment = StringAlignment.Center })
                    e.Graphics.DrawString(row.IconLetter, f, Brushes.White, new RectangleF(cx, cy, d, d), sf);
            }
            else if (e.ColumnIndex == 1)
            {
                int px = e.CellBounds.X + 14;
                using (var fN = new Font("Segoe UI", 9.5F, FontStyle.Bold))
                using (var fI = new Font("Segoe UI", 8.5F))
                using (var bN = new SolidBrush(Color.FromArgb(22, 25, 40)))
                using (var bI = new SolidBrush(Color.FromArgb(152, 158, 180)))
                {
                    e.Graphics.DrawString(row.Name, fN, bN, px, midY - 17);
                    e.Graphics.DrawString("Inv: " + row.InvNum, fI, bI, px, midY + 3);
                }
            }
            else if (e.ColumnIndex == 2)
            {
                int px = e.CellBounds.X + 14;
                using (var fD = new Font("Segoe UI", 9.5F, FontStyle.Bold))
                using (var fT = new Font("Segoe UI", 8.5F))
                using (var bD = new SolidBrush(Color.FromArgb(22, 25, 40)))
                using (var bT = new SolidBrush(Color.FromArgb(152, 158, 180)))
                {
                    e.Graphics.DrawString(row.Date.ToString("dd MMM yyyy"), fD, bD, px, midY - 17);
                    e.Graphics.DrawString("at " + row.Date.ToString("h:mm tt"), fT, bT, px, midY + 3);
                }
            }
            else if (e.ColumnIndex == 5)
            {
                Color bbg = row.Status == "Paid" ? PaidBg : row.Status == "Pending" ? PendingBg : UnpaidBg;
                Color bfg = row.Status == "Paid" ? PaidFg : row.Status == "Pending" ? PendingFg : UnpaidFg;
                int bw = 84, bh = 28;
                int bx = e.CellBounds.X + (e.CellBounds.Width - bw) / 2;
                int by = midY - bh / 2;
                var rect = new Rectangle(bx, by, bw, bh);
                using (var path = MakePill(rect, 14))
                using (var bb = new SolidBrush(bbg))
                    e.Graphics.FillPath(bb, path);
                using (var f = new Font("Segoe UI", 8.5F, FontStyle.Bold))
                using (var sf = new StringFormat { Alignment = StringAlignment.Center, LineAlignment = StringAlignment.Center })
                using (var fb = new SolidBrush(bfg))
                    e.Graphics.DrawString(row.Status, f, fb, rect, sf);
            }
            else if (e.ColumnIndex == 6)
            {
                using (var f = new Font("Segoe UI", 14F, FontStyle.Bold))
                using (var sf = new StringFormat { Alignment = StringAlignment.Center, LineAlignment = StringAlignment.Center })
                using (var fb = new SolidBrush(Color.FromArgb(95, 155, 235)))
                    e.Graphics.DrawString("···", f, fb, e.CellBounds, sf);
            }

            e.Handled = true;
        }

        private void Dgv_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex != 6) return;
            var row = dgvInvoices.Rows[e.RowIndex].Tag as InvoiceRow;
            if (row == null) return;
            MessageBox.Show(
                $"Invoice: {row.InvNum}\nClient: {row.Name}\nDate: {row.Date:dd MMM yyyy}\nType: {row.OrderType}\nAmount: ${row.Amount:0.00}\nStatus: {row.Status}",
                "Invoice Detail", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        // =====================================================================
        // SEARCH
        // =====================================================================
        private void txtSearch_TextChanged(object sender, EventArgs e) => ApplyFilter();

        // =====================================================================
        // FILTER PANEL
        // =====================================================================
        private void BuildFilterPanel()
        {
            _pnlFilter = new Panel
            {
                BackColor = Color.White,
                Height = 54,
                Visible = false
            };
            _pnlFilter.Paint += (s, e) =>
            {
                using (var pen = new Pen(Color.FromArgb(220, 223, 236)))
                    e.Graphics.DrawRectangle(pen, 0, 0, _pnlFilter.Width - 1, _pnlFilter.Height - 1);
            };

            AddFilterLabel("STATUS", 12, _pnlFilter);
            _cboStatus = AddFilterCombo(70, new[] { "All", "Paid", "Pending", "Unpaid" }, _pnlFilter);
            _cboStatus.SelectedIndexChanged += (s, e) => ApplyFilter();

            AddFilterLabel("TYPE", 195, _pnlFilter);
            _cboType = AddFilterCombo(240, new[] { "All", "01", "02", "20", "Withdraw", "Technology" }, _pnlFilter);
            _cboType.SelectedIndexChanged += (s, e) => ApplyFilter();

            AddFilterLabel("SORT", 370, _pnlFilter);
            _cboSort = AddFilterCombo(412, new[] { "Date ↓ (newest)", "Date ↑ (oldest)", "Amount ↓", "Amount ↑" }, _pnlFilter);
            _cboSort.SelectedIndexChanged += (s, e) => ApplyFilter();

            var lnkReset = new LinkLabel
            {
                Text = "Reset",
                Font = new Font("Segoe UI", 9F),
                Location = new Point(540, 18),
                AutoSize = true,
                LinkColor = Color.FromArgb(95, 155, 235)
            };
            lnkReset.LinkClicked += (s, e) => ResetFilter();
            _pnlFilter.Controls.Add(lnkReset);

            pnlMain.Controls.Add(_pnlFilter);
            pnlMain.Controls.SetChildIndex(_pnlFilter, 0);
        }

        private void AddFilterLabel(string text, int x, Panel parent)
        {
            parent.Controls.Add(new Label
            {
                Text = text,
                Font = new Font("Segoe UI", 8F, FontStyle.Bold),
                ForeColor = Color.FromArgb(148, 153, 172),
                Location = new Point(x, 8),
                AutoSize = true
            });
        }

        private ComboBox AddFilterCombo(int x, string[] items, Panel parent)
        {
            var c = new ComboBox
            {
                Location = new Point(x, 22),
                Width = 110,
                DropDownStyle = ComboBoxStyle.DropDownList,
                Font = new Font("Segoe UI", 9F),
                FlatStyle = FlatStyle.Flat
            };
            c.Items.AddRange(items);
            c.SelectedIndex = 0;
            parent.Controls.Add(c);
            return c;
        }

        private void ApplyFilter()
        {
            string q = txtSearch.Text.Trim().ToLower();
            string st = (_cboStatus?.SelectedIndex ?? 0) > 0 ? _cboStatus.Text : "";
            string ty = (_cboType?.SelectedIndex ?? 0) > 0 ? _cboType.Text : "";

            _filtered = _all.Where(r =>
                (string.IsNullOrEmpty(q) || r.Name.ToLower().Contains(q) ||
                 r.InvNum.ToLower().Contains(q) || r.Status.ToLower().Contains(q) ||
                 r.OrderType.ToLower().Contains(q)) &&
                (string.IsNullOrEmpty(st) || r.Status == st) &&
                (string.IsNullOrEmpty(ty) || r.OrderType == ty)
            ).ToList();

            switch (_cboSort?.SelectedIndex ?? 0)
            {
                case 1: _filtered = _filtered.OrderBy(r => r.Date).ToList(); break;
                case 2: _filtered = _filtered.OrderByDescending(r => r.Amount).ToList(); break;
                case 3: _filtered = _filtered.OrderBy(r => r.Amount).ToList(); break;
                default: _filtered = _filtered.OrderByDescending(r => r.Date).ToList(); break;
            }

            Bind(_filtered);
        }

        private void ResetFilter()
        {
            txtSearch.Text = "";
            if (_cboStatus != null) _cboStatus.SelectedIndex = 0;
            if (_cboType != null) _cboType.SelectedIndex = 0;
            if (_cboSort != null) _cboSort.SelectedIndex = 0;
            ApplyFilter();
        }

        private void btnFilters_Click(object sender, EventArgs e)
        {
            _filterOpen = !_filterOpen;
            _pnlFilter.Visible = _filterOpen;
            ResizeContent();
        }

        // =====================================================================
        // CREATE INVOICE  →  open styled dialog
        // =====================================================================
        private void btnCreate_Click(object sender, EventArgs e)
            => UI.Navigation.FormNavigator.GoToCreateInvoice();

        // =====================================================================
        // LAYOUT
        // =====================================================================
        private void InvoiceListForm_SizeChanged(object sender, EventArgs e)
        {
            LayoutTopBar();
            LayoutSidebarBottom();
            ResizeContent();
        }

        private void LayoutTopBar()
        {
            int w = pnlTopBar.Width;
            int by = (pnlTopBar.Height - 30) / 2;
            btnClose.Location = new Point(w - 40, by);
            btnMaximize.Location = new Point(w - 74, by);
            btnMinimize.Location = new Point(w - 108, by);
            lblUsername.Location = new Point(w - 220, (pnlTopBar.Height - lblUsername.Height) / 2);
            picAvatar.Location = new Point(w - 258, (pnlTopBar.Height - 36) / 2);
        }

        private void LayoutSidebarBottom()
        {
            int sH = pnlSidebar.Height;
            btnNavLogout.Location = new Point(14, sH - 48);
            btnNavHelp.Location = new Point(14, sH - 96);
            pnlSidebar.Invalidate();
        }

        private void ResizeContent()
        {
            int pad = pnlMain.Padding.Left;
            int avail = pnlMain.ClientSize.Width - pad * 2;
            int top = pad;

            pnlToolbar.Width = avail;
            pnlToolbar.Location = new Point(pad, top);
            top += pnlToolbar.Height + 8;

            if (_pnlFilter != null)
            {
                _pnlFilter.Width = avail;
                _pnlFilter.Location = new Point(pad, top);
                if (_filterOpen) top += _pnlFilter.Height + 8;
            }

            int tableH = Math.Max(200, pnlMain.ClientSize.Height - top - pad);
            pnlTableWrap.Location = new Point(pad, top);
            pnlTableWrap.Width = avail;
            pnlTableWrap.Height = tableH;
            dgvInvoices.Size = new Size(avail, tableH);

            btnCreate.Location = new Point(avail - btnFilters.Width - btnCreate.Width - 10, 8);
            btnFilters.Location = new Point(avail - btnFilters.Width, 8);
        }

        // =====================================================================
        // NAVIGATION
        // =====================================================================
        private void btnNavDashboard_Click(object sender, EventArgs e)
            => UI.Navigation.FormNavigator.GoToDashboard();

        private void btnNavTransactions_Click(object sender, EventArgs e)
            => UI.Navigation.FormNavigator.GoToTransactions();

        private void btnNavLogout_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có muốn đăng xuất không?", "Đăng xuất",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                Infrastructure.DI.ServiceLocator.UserService.Logout();
                UI.Navigation.FormNavigator.GoToLogin();
            }
        }

        private void btnClose_Click(object sender, EventArgs e) => Application.Exit();
        private void btnMinimize_Click(object sender, EventArgs e) => WindowState = FormWindowState.Minimized;
        private void btnMaximize_Click(object sender, EventArgs e)
            => WindowState = WindowState == FormWindowState.Maximized
               ? FormWindowState.Normal : FormWindowState.Maximized;

        // =====================================================================
        // PAINT HELPERS
        // =====================================================================
        private void pnlSidebar_Paint(object sender, PaintEventArgs e)
        {
            using (var pen = new Pen(Color.FromArgb(232, 235, 244), 1))
            {
                e.Graphics.DrawLine(pen, 14, 90, 226, 90);
                e.Graphics.DrawLine(pen, 14, btnNavHelp.Top - 10, 226, btnNavHelp.Top - 10);
                e.Graphics.DrawLine(pen, pnlSidebar.Width - 1, 0, pnlSidebar.Width - 1, pnlSidebar.Height);
            }
        }

        private void picLogo_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
            using (var b = new SolidBrush(Color.FromArgb(18, 20, 28)))
                e.Graphics.FillEllipse(b, 0, 0, 41, 41);
            using (var f = new Font("Segoe UI", 15F, FontStyle.Bold))
            using (var sf = new StringFormat { Alignment = StringAlignment.Center, LineAlignment = StringAlignment.Center })
                e.Graphics.DrawString("m", f, Brushes.White, new RectangleF(0, 0, 41, 41), sf);
        }

        private void picAvatar_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
            using (var grd = new LinearGradientBrush(new Rectangle(0, 0, 36, 36),
                Color.FromArgb(100, 175, 255), Color.FromArgb(58, 95, 225), 45f))
                e.Graphics.FillEllipse(grd, 0, 0, 35, 35);
            using (var f = new Font("Segoe UI", 12F, FontStyle.Bold))
            using (var sf = new StringFormat { Alignment = StringAlignment.Center, LineAlignment = StringAlignment.Center })
                e.Graphics.DrawString("A", f, Brushes.White, new RectangleF(0, 0, 36, 36), sf);
        }

        private void pnlTopBar_Paint(object sender, PaintEventArgs e)
        {
            using (var pen = new Pen(Color.FromArgb(228, 231, 242), 1))
                e.Graphics.DrawLine(pen, 0, pnlTopBar.Height - 1, pnlTopBar.Width, pnlTopBar.Height - 1);
        }

        private void pnlWhiteCard_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
            var c = (Control)sender;
            var r = new Rectangle(0, 0, c.Width - 1, c.Height - 1);
            using (var path = MakePill(r, 14))
            {
                using (var b = new SolidBrush(Color.White)) e.Graphics.FillPath(b, path);
                using (var pen = new Pen(Color.FromArgb(226, 229, 242), 1)) e.Graphics.DrawPath(pen, path);
            }
        }

        private static GraphicsPath MakePill(Rectangle r, int rad)
        {
            var p = new GraphicsPath(); int d = rad * 2;
            p.AddArc(r.X, r.Y, d, d, 180, 90);
            p.AddArc(r.Right - d, r.Y, d, d, 270, 90);
            p.AddArc(r.Right - d, r.Bottom - d, d, d, 0, 90);
            p.AddArc(r.X, r.Bottom - d, d, d, 90, 90);
            p.CloseFigure(); return p;
        }
    }

    // =========================================================================
    // CREATE INVOICE DIALOG  –  full Guna UI2 styled
    // =========================================================================
    public class CreateInvoiceDialog : Form
    {
        public InvoiceListForm.InvoiceRow Result { get; private set; }

        // Drop shadow via WinAPI (no Guna dependency)
        protected override CreateParams CreateParams
        {
            get
            {
                const int CS_DROPSHADOW = 0x00020000;
                var cp = base.CreateParams;
                cp.ClassStyle |= CS_DROPSHADOW;
                return cp;
            }
        }

        // Guna controls
        private Guna.UI2.WinForms.Guna2TextBox _txtName, _txtInvNum, _txtAmount;
        private Guna.UI2.WinForms.Guna2DateTimePicker _dtp;
        private Guna.UI2.WinForms.Guna2ComboBox _cboType, _cboStatus;
        private Guna.UI2.WinForms.Guna2Button _btnSave, _btnCancel;
        private Label _lblError;

        private static readonly Color Accent = Color.FromArgb(181, 212, 34);
        private static readonly Color AccentHov = Color.FromArgb(162, 193, 18);
        private static readonly Color BgColor = Color.FromArgb(247, 248, 252);
        private static readonly Color CardColor = Color.White;
        private static readonly Color BorderClr = Color.FromArgb(220, 223, 232);
        private static readonly Color LabelClr = Color.FromArgb(148, 153, 172);
        private static readonly Color TextClr = Color.FromArgb(22, 25, 40);

        public CreateInvoiceDialog()
        {
            this.Text = "";
            this.Size = new Size(500, 460);
            this.FormBorderStyle = FormBorderStyle.None;
            this.StartPosition = FormStartPosition.CenterParent;
            this.BackColor = BgColor;
            this.Font = new Font("Segoe UI", 9.5F);
            BuildUI();
        }

        private void BuildUI()
        {
            // ── outer card panel ──────────────────────────────────────────────
            var card = new Panel
            {
                BackColor = CardColor,
                Location = new Point(0, 0),
                Size = new Size(500, 460),
                Dock = DockStyle.Fill
            };
            card.Paint += Card_Paint;
            this.Controls.Add(card);

            // ── drag support via Guna2DragControl ─────────────────────────────
            var drag = new Guna.UI2.WinForms.Guna2DragControl();
            drag.TargetControl = card;
            drag.UseTransparentDrag = true;

            // ── top header bar (accent strip) ─────────────────────────────────
            var header = new Panel
            {
                BackColor = Accent,
                Location = new Point(0, 0),
                Size = new Size(500, 56),
                Cursor = Cursors.SizeAll
            };
            drag.TargetControl = header;

            var lblTitle = new Label
            {
                Text = "Create Invoice",
                Font = new Font("Segoe UI", 13F, FontStyle.Bold),
                ForeColor = Color.FromArgb(22, 25, 40),
                Location = new Point(22, 16),
                AutoSize = true
            };

            // Close button in header
            var btnX = new Guna.UI2.WinForms.Guna2Button
            {
                Text = "✕",
                Size = new Size(32, 32),
                Location = new Point(454, 12),
                BorderRadius = 8,
                FillColor = Color.Transparent,
                ForeColor = Color.FromArgb(40, 44, 52),
                Font = new Font("Segoe UI", 10F, FontStyle.Bold),
                Cursor = Cursors.Hand
            };
            btnX.HoverState.FillColor = Color.FromArgb(0, 0, 0, 30);
            btnX.Click += (s, e) => { DialogResult = DialogResult.Cancel; Close(); };

            header.Controls.Add(lblTitle);
            header.Controls.Add(btnX);
            card.Controls.Add(header);

            // ── icon circle ───────────────────────────────────────────────────
            var picIcon = new PictureBox
            {
                Size = new Size(52, 52),
                Location = new Point(22, 72),
                BackColor = Color.Transparent
            };
            picIcon.Paint += (s, e) =>
            {
                e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
                using (var b = new SolidBrush(Color.FromArgb(230, 244, 195)))
                    e.Graphics.FillEllipse(b, 0, 0, 51, 51);
                using (var f = new Font("Segoe UI", 18F))
                using (var sf = new StringFormat { Alignment = StringAlignment.Center, LineAlignment = StringAlignment.Center })
                using (var fb = new SolidBrush(Color.FromArgb(100, 140, 10)))
                    e.Graphics.DrawString("🧾", f, fb, new RectangleF(0, 0, 51, 51), sf);
            };
            card.Controls.Add(picIcon);

            var lblSub = new Label
            {
                Text = "Fill in the details below to add a new invoice.",
                Font = new Font("Segoe UI", 8.5F),
                ForeColor = LabelClr,
                Location = new Point(84, 82),
                AutoSize = true
            };
            card.Controls.Add(lblSub);

            // ── divider ───────────────────────────────────────────────────────
            var div = new Panel { BackColor = BorderClr, Location = new Point(22, 136), Size = new Size(456, 1) };
            card.Controls.Add(div);

            // ── form fields ───────────────────────────────────────────────────
            int lx = 22, rx = 262, fy = 152, rowH = 70;

            // Row 1: Client Name | Invoice No.
            AddFieldLabel("CLIENT NAME", lx, fy, card);
            AddFieldLabel("INVOICE NO.", rx, fy, card);
            _txtName = MakeTextBox(lx, fy + 22, 218, "e.g. Figma Inc.", card);
            _txtInvNum = MakeTextBox(rx, fy + 22, 218, "", card);
            _txtInvNum.Text = "MGL5" + new Random().Next(10000, 99999);
            _txtInvNum.ForeColor = TextClr;
            fy += rowH;

            // Row 2: Date | Amount
            AddFieldLabel("DATE", lx, fy, card);
            AddFieldLabel("AMOUNT ($)", rx, fy, card);

            _dtp = new Guna.UI2.WinForms.Guna2DateTimePicker
            {
                Location = new Point(lx, fy + 22),
                Size = new Size(218, 38),
                Font = new Font("Segoe UI", 9.5F),
                FillColor = CardColor,
                BorderColor = BorderClr,
                ForeColor = TextClr,
                BorderRadius = 8,
                Value = DateTime.Now,
                Format = DateTimePickerFormat.Short
            };
            card.Controls.Add(_dtp);

            _txtAmount = MakeTextBox(rx, fy + 22, 218, "0.00", card);
            fy += rowH;

            // Row 3: Orders/Type | Status
            AddFieldLabel("ORDERS / TYPE", lx, fy, card);
            AddFieldLabel("STATUS", rx, fy, card);

            _cboType = MakeCombo(lx, fy + 22, 218,
                new[] { "01", "02", "20", "Withdraw", "Technology" }, card);
            _cboStatus = MakeCombo(rx, fy + 22, 218,
                new[] { "Pending", "Paid", "Unpaid" }, card);
            fy += rowH;

            // ── error label ───────────────────────────────────────────────────
            _lblError = new Label
            {
                ForeColor = Color.FromArgb(195, 45, 45),
                Location = new Point(lx, fy),
                Size = new Size(456, 18),
                Font = new Font("Segoe UI", 8.5F)
            };
            card.Controls.Add(_lblError);

            // ── footer buttons ────────────────────────────────────────────────
            int footY = 400;

            _btnCancel = new Guna.UI2.WinForms.Guna2Button
            {
                Text = "Cancel",
                Location = new Point(248, footY),
                Size = new Size(108, 38),
                BorderRadius = 9,
                Font = new Font("Segoe UI", 9.5F),
                FillColor = CardColor,
                ForeColor = Color.FromArgb(80, 85, 105),
                BorderColor = BorderClr,
                Cursor = Cursors.Hand
            };
            _btnCancel.HoverState.FillColor = BgColor;
            _btnCancel.Click += (s, e) => { DialogResult = DialogResult.Cancel; Close(); };
            card.Controls.Add(_btnCancel);

            _btnSave = new Guna.UI2.WinForms.Guna2Button
            {
                Text = "Save Invoice",
                Location = new Point(366, footY),
                Size = new Size(112, 38),
                BorderRadius = 9,
                Font = new Font("Segoe UI", 9.5F, FontStyle.Bold),
                FillColor = Accent,
                ForeColor = Color.FromArgb(22, 24, 35),
                Cursor = Cursors.Hand
            };
            _btnSave.HoverState.FillColor = AccentHov;
            _btnSave.Click += BtnSave_Click;
            card.Controls.Add(_btnSave);
        }

        // ── Save ──────────────────────────────────────────────────────────────
        private void BtnSave_Click(object sender, EventArgs e)
        {
            _lblError.Text = "";

            string name = _txtName.Text.Trim();
            string inv = _txtInvNum.Text.Trim();

            if (string.IsNullOrEmpty(name)) { _lblError.Text = "⚠  Client name is required."; return; }
            if (string.IsNullOrEmpty(inv)) { _lblError.Text = "⚠  Invoice number is required."; return; }
            if (!decimal.TryParse(_txtAmount.Text.Replace(",", "."),
                System.Globalization.NumberStyles.Any,
                System.Globalization.CultureInfo.InvariantCulture, out decimal amt) || amt <= 0)
            { _lblError.Text = "⚠  Enter a valid amount greater than 0."; return; }

            var palette = new Color[]
            {
                Color.FromArgb(235, 75, 55), Color.FromArgb(98, 52,180),
                Color.FromArgb(55,125,200),  Color.FromArgb(25,145,198),
                Color.FromArgb(195, 35, 35), Color.FromArgb(238,148,0),
                Color.FromArgb(39,174, 96),  Color.FromArgb(41,128,185)
            };

            Result = new InvoiceListForm.InvoiceRow
            {
                IconLetter = name[0].ToString().ToUpper(),
                IconColor = palette[new Random().Next(palette.Length)],
                Name = name,
                InvNum = inv,
                Date = _dtp.Value,
                OrderType = _cboType.Text,
                Amount = amt,
                Status = _cboStatus.Text
            };

            DialogResult = DialogResult.OK;
            Close();
        }

        // ── Card rounded paint ────────────────────────────────────────────────
        private void Card_Paint(object sender, PaintEventArgs e)
        {
            var g = e.Graphics;
            g.SmoothingMode = SmoothingMode.AntiAlias;
            var r = new Rectangle(0, 0, this.Width - 1, this.Height - 1);
            using (var path = RoundRect(r, 14))
            {
                using (var b = new SolidBrush(CardColor)) g.FillPath(b, path);
                using (var p = new Pen(BorderClr, 1)) g.DrawPath(p, path);
            }
        }

        // ── Guna2 field helpers ───────────────────────────────────────────────
        private void AddFieldLabel(string text, int x, int y, Control parent)
        {
            parent.Controls.Add(new Label
            {
                Text = text,
                Font = new Font("Segoe UI", 8F, FontStyle.Bold),
                ForeColor = LabelClr,
                Location = new Point(x, y),
                AutoSize = true
            });
        }

        private Guna.UI2.WinForms.Guna2TextBox MakeTextBox(int x, int y, int w, string placeholder, Control parent)
        {
            var t = new Guna.UI2.WinForms.Guna2TextBox
            {
                Location = new Point(x, y),
                Size = new Size(w, 38),
                BorderRadius = 8,
                Font = new Font("Segoe UI", 9.5F),
                FillColor = CardColor,
                ForeColor = TextClr,
                BorderColor = BorderClr,
                PlaceholderText = placeholder,
                Cursor = Cursors.IBeam
            };
            t.FocusedState.BorderColor = Accent;
            parent.Controls.Add(t);
            return t;
        }

        private Guna.UI2.WinForms.Guna2ComboBox MakeCombo(int x, int y, int w, string[] items, Control parent)
        {
            var c = new Guna.UI2.WinForms.Guna2ComboBox
            {
                Location = new Point(x, y),
                Size = new Size(w, 38),
                BorderRadius = 8,
                Font = new Font("Segoe UI", 9.5F),
                FillColor = CardColor,
                ForeColor = TextClr,
                BorderColor = BorderClr,
                DropDownStyle = ComboBoxStyle.DropDownList,
                Cursor = Cursors.Hand
            };
            c.FocusedState.BorderColor = Accent;
            foreach (var item in items) c.Items.Add(item);
            c.SelectedIndex = 0;
            parent.Controls.Add(c);
            return c;
        }

        private static GraphicsPath RoundRect(Rectangle r, int rad)
        {
            var p = new GraphicsPath(); int d = rad * 2;
            p.AddArc(r.X, r.Y, d, d, 180, 90);
            p.AddArc(r.Right - d, r.Y, d, d, 270, 90);
            p.AddArc(r.Right - d, r.Bottom - d, d, d, 0, 90);
            p.AddArc(r.X, r.Bottom - d, d, d, 90, 90);
            p.CloseFigure(); return p;
        }
    }
}