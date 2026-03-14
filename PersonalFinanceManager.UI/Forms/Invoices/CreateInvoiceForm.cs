using PersonalFinanceManager.Infrastructure.DI;
using PersonalFinanceManager.Common.Helpers;
using System;
using System.Data.SQLite;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace PersonalFinanceManager.Forms.Invoices
{
    public partial class CreateInvoiceForm : Form
    {
        private decimal _subtotal = 0m;

        public CreateInvoiceForm()
        {
            InitializeComponent();
            BuildItemColumns();
            AddEmptyRow();
            AddEmptyRow();

            this.Load += CreateInvoiceForm_Load;
            this.SizeChanged += CreateInvoiceForm_SizeChanged;
        }

        // =====================================================================
        // LOAD
        // =====================================================================
        private void CreateInvoiceForm_Load(object sender, EventArgs e)
        {
            try
            {
                var u = ServiceLocator.UserService.GetCurrentUser();
                if (u != null) lblUsername.Text = u.FullName ?? u.Email ?? "Admin";
            }
            catch { }

            txtInvNum.Text = "MAG " + DateTime.Now.ToString("yyyyMMddHH");
            lblPageTitle.Text = "New Invoices:  " + txtInvNum.Text;

            dtpIssued.Value = DateTime.Now;
            dtpDue.Value = DateTime.Now.AddDays(10);
            dtpInvoiceDate.Value = DateTime.Now;
            dtpDueDate.Value = DateTime.Now.AddDays(10);

            LayoutTopBar();
            LayoutSidebarBottom();
            LayoutPanels();
        }

        // =====================================================================
        // ITEMS GRID
        // =====================================================================
        private void BuildItemColumns()
        {
            dgvItems.Columns.Clear();

            var cItem = new DataGridViewTextBoxColumn
            {
                Name = "cItem",
                HeaderText = "ITEM",
                AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            };
            cItem.DefaultCellStyle.Padding = new Padding(10, 0, 0, 0);

            var cOrder = new DataGridViewTextBoxColumn
            {
                Name = "cOrder",
                HeaderText = "ORDER/TYPE",
                Width = 130
            };
            cOrder.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            cOrder.DefaultCellStyle.ForeColor = Color.FromArgb(140, 145, 168);

            var cRate = new DataGridViewTextBoxColumn
            {
                Name = "cRate",
                HeaderText = "RATE",
                Width = 110
            };
            cRate.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            cRate.DefaultCellStyle.Padding = new Padding(0, 0, 12, 0);

            var cAmount = new DataGridViewTextBoxColumn
            {
                Name = "cAmount",
                HeaderText = "AMOUNT",
                Width = 120,
                ReadOnly = true
            };
            cAmount.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            cAmount.DefaultCellStyle.Padding = new Padding(0, 0, 12, 0);
            cAmount.DefaultCellStyle.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            cAmount.DefaultCellStyle.ForeColor = Color.FromArgb(22, 25, 40);

            var cDel = new DataGridViewButtonColumn
            {
                Name = "cDel",
                HeaderText = "",
                Width = 42,
                Text = "×",
                UseColumnTextForButtonValue = true,
                FlatStyle = FlatStyle.Flat
            };
            cDel.DefaultCellStyle.BackColor = Color.White;
            cDel.DefaultCellStyle.ForeColor = Color.FromArgb(195, 55, 55);
            cDel.DefaultCellStyle.Font = new Font("Segoe UI", 13F, FontStyle.Bold);
            cDel.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            cDel.DefaultCellStyle.SelectionBackColor = Color.FromArgb(255, 232, 232);
            cDel.DefaultCellStyle.SelectionForeColor = Color.FromArgb(195, 55, 55);

            dgvItems.Columns.AddRange(cItem, cOrder, cRate, cAmount, cDel);
            dgvItems.CellValueChanged += DgvItems_CellValueChanged;
            dgvItems.CellClick += DgvItems_CellClick;
        }

        private void AddEmptyRow()
        {
            int i = dgvItems.Rows.Add("", "01", "", "$0.00");
            dgvItems.Rows[i].Tag = 0m;
        }

        private void lnkAddItem_Click(object sender, EventArgs e)
        {
            AddEmptyRow();
            int last = dgvItems.Rows.Count - 1;
            dgvItems.CurrentCell = dgvItems.Rows[last].Cells["cItem"];
            dgvItems.BeginEdit(true);
        }

        private void DgvItems_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            if (e.ColumnIndex == dgvItems.Columns["cRate"].Index)
            {
                string raw = (dgvItems.Rows[e.RowIndex].Cells["cRate"].Value?.ToString() ?? "")
                             .Replace("$", "").Replace(",", "").Trim();
                if (decimal.TryParse(raw, System.Globalization.NumberStyles.Any,
                    System.Globalization.CultureInfo.InvariantCulture, out decimal rate))
                {
                    dgvItems.Rows[e.RowIndex].Cells["cAmount"].Value = "$" + rate.ToString("0.00");
                    dgvItems.Rows[e.RowIndex].Tag = rate;
                }
            }
            RecalcTotals();
        }

        private void DgvItems_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex != dgvItems.Columns["cDel"].Index) return;
            if (dgvItems.Rows.Count > 1)
            {
                dgvItems.Rows.RemoveAt(e.RowIndex);
                RecalcTotals();
            }
        }

        private void RecalcTotals()
        {
            _subtotal = 0m;
            foreach (DataGridViewRow row in dgvItems.Rows)
                if (row.Tag is decimal d) _subtotal += d;
            pnlTotals.Invalidate();
        }

        // =====================================================================
        // SEND / DOWNLOAD
        // =====================================================================
        private void btnSend_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtInvNum.Text) ||
                string.IsNullOrWhiteSpace(txtClientName.Text))
            {
                MessageBox.Show("Please fill Invoice Number and Client Name.", "Validation",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!SaveInvoice())
            {
                MessageBox.Show("Unable to save invoice.", "Invoice",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            MessageBox.Show(
                $"Invoice Sent!\n\nInvoice #: {txtInvNum.Text}\nBilled to: {txtBilledName.Text}\nClient: {txtClientName.Text}\nTotal: ${_subtotal:0.00}",
                "Invoice Sent", MessageBoxButtons.OK, MessageBoxIcon.Information);

            UI.Navigation.FormNavigator.GoToInvoices();
        }

        private bool SaveInvoice()
        {
            int currentUserId = ResolveCurrentUserId();
            if (currentUserId <= 0) return false;

            decimal total = _subtotal;
            if (total <= 0m) return false;

            var db = new DbHelper();
            using (var conn = db.CreateConnection())
            {
                conn.Open();
                using (var cmd = (SQLiteCommand)conn.CreateCommand())
                {
                    cmd.CommandText = @"INSERT INTO Invoices
                                        (UserId, InvoiceNumber, ClientName, BilledTo, InvoiceDate, DueDate, OrderType, Amount, Status, CreatedAt)
                                        VALUES
                                        (@UserId, @InvoiceNumber, @ClientName, @BilledTo, @InvoiceDate, @DueDate, @OrderType, @Amount, @Status, @CreatedAt)";
                    cmd.Parameters.AddWithValue("@UserId", currentUserId);
                    cmd.Parameters.AddWithValue("@InvoiceNumber", txtInvNum.Text.Trim());
                    cmd.Parameters.AddWithValue("@ClientName", txtClientName.Text.Trim());
                    cmd.Parameters.AddWithValue("@BilledTo", (object)txtBilledName.Text.Trim() ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@InvoiceDate", dtpInvoiceDate.Value.ToString("s"));
                    cmd.Parameters.AddWithValue("@DueDate", dtpDueDate.Value.ToString("s"));
                    cmd.Parameters.AddWithValue("@OrderType", "Invoice");
                    cmd.Parameters.AddWithValue("@Amount", total);
                    cmd.Parameters.AddWithValue("@Status", "Pending");
                    cmd.Parameters.AddWithValue("@CreatedAt", DateTime.Now.ToString("s"));
                    return cmd.ExecuteNonQuery() > 0;
                }
            }
        }

        private int ResolveCurrentUserId()
        {
            var user = ServiceLocator.UserService.GetCurrentUser();
            if (user != null && user.Id > 0) return user.Id;
            return PersonalFinanceManager.Common.Mock.MockUserService.CurrentUserId;
        }

        private void btnDownload_Click(object sender, EventArgs e)
            => MessageBox.Show("Download feature coming in Sprint 2.", "Download",
                MessageBoxButtons.OK, MessageBoxIcon.Information);

        // =====================================================================
        // LAYOUT
        // =====================================================================
        private void CreateInvoiceForm_SizeChanged(object sender, EventArgs e)
        {
            LayoutTopBar();
            LayoutSidebarBottom();
            LayoutPanels();
        }

        private void LayoutTopBar()
        {
            int w = pnlTopBar.Width, by = (pnlTopBar.Height - 30) / 2;
            btnClose.Location = new Point(w - 40, by);
            btnMaximize.Location = new Point(w - 74, by);
            btnMinimize.Location = new Point(w - 108, by);
            lblUsername.Location = new Point(w - 218, (pnlTopBar.Height - lblUsername.Height) / 2);
            picAvatar.Location = new Point(w - 258, (pnlTopBar.Height - 36) / 2);
        }

        private void LayoutSidebarBottom()
        {
            int sH = pnlSidebar.Height;
            btnNavLogout.Location = new Point(14, sH - 48);
            btnNavHelp.Location = new Point(14, sH - 96);
            pnlSidebar.Invalidate();
        }

        private void LayoutPanels()
        {
            int pad = pnlMain.Padding.Left;
            int avail = pnlMain.ClientSize.Width - pad * 2;
            int high = pnlMain.ClientSize.Height - pad;
            int rightW = 360;
            int gap = 20;
            int leftW = avail - rightW - gap;

            // Left panel
            pnlLeft.Size = new Size(leftW, Math.Max(860, high));
            pnlLeft.Location = new Point(0, 0);
            pnlHeader.Width = leftW;
            pnlInvInfo.Width = leftW;
            // Update right-half textboxes width inside pnlInvInfo
            int billedW = leftW - 460 - 24;
            if (billedW > 60)
            {
                txtBilledName.Width = billedW;
                txtBilledAddr1.Width = billedW;
                txtBilledAddr2.Width = billedW;
                lblCoAddr.Location = new System.Drawing.Point(leftW - 310, 16);
                lblCoAddr.Width = 290;
            }
            pnlItems.Width = leftW;
            pnlItems.Height = Math.Max(480, high - 328);
            dgvItems.Width = leftW;
            pnlTotals.Width = leftW;

            // Right panel
            pnlRight.Location = new Point(leftW + gap, 0);
            pnlRight.Size = new Size(rightW, Math.Max(700, high));
            int innerW = rightW - 40;
            pnlClientCard.Width = rightW;
            pnlBasicInfo.Width = rightW;
            txtClientName.Width = innerW;
            txtClientEmail.Width = innerW;
            txtClientCompany.Width = innerW;
            txtClientAddr.Width = innerW;
            btnAddCustomer.Width = innerW;
            dtpInvoiceDate.Width = innerW;
            dtpDueDate.Width = innerW;
            btnSend.Width = innerW;
            btnPreview.Width = (innerW - 8) / 2;
            btnDownload.Location = new Point(20 + btnPreview.Width + 8, btnDownload.Top);
            btnDownload.Width = innerW - btnPreview.Width - 8;
        }

        // =====================================================================
        // NAVIGATION
        // =====================================================================
        private void btnNavDashboard_Click(object sender, EventArgs e)
            => UI.Navigation.FormNavigator.GoToDashboard();

        private void btnNavTransactions_Click(object sender, EventArgs e)
            => UI.Navigation.FormNavigator.GoToTransactions();

        private void btnNavInvoices_Click(object sender, EventArgs e)
            => UI.Navigation.FormNavigator.GoToInvoices();

        private void btnNavLogout_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có muốn đăng xuất không?", "Đăng xuất",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                ServiceLocator.UserService.Logout();
                UI.Navigation.FormNavigator.GoToLogin();
            }
        }

        private void btnClose_Click(object sender, EventArgs e) => Application.Exit();
        private void btnMinimize_Click(object sender, EventArgs e) => WindowState = FormWindowState.Minimized;
        private void btnMaximize_Click(object sender, EventArgs e)
            => WindowState = WindowState == FormWindowState.Maximized
               ? FormWindowState.Normal : FormWindowState.Maximized;

        // =====================================================================
        // PAINT
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
            var g = e.Graphics; g.SmoothingMode = SmoothingMode.AntiAlias;
            using (var b = new SolidBrush(Color.FromArgb(18, 20, 28)))
                g.FillEllipse(b, 0, 0, 41, 41);
            using (var f = new Font("Segoe UI", 15F, FontStyle.Bold))
            using (var sf = new StringFormat { Alignment = StringAlignment.Center, LineAlignment = StringAlignment.Center })
                g.DrawString("m", f, Brushes.White, new RectangleF(0, 0, 41, 41), sf);
        }

        private void picAvatar_Paint(object sender, PaintEventArgs e)
        {
            var g = e.Graphics; g.SmoothingMode = SmoothingMode.AntiAlias;
            using (var grd = new LinearGradientBrush(new Rectangle(0, 0, 36, 36),
                Color.FromArgb(100, 175, 255), Color.FromArgb(58, 95, 225), 45f))
                g.FillEllipse(grd, 0, 0, 35, 35);
            using (var f = new Font("Segoe UI", 12F, FontStyle.Bold))
            using (var sf = new StringFormat { Alignment = StringAlignment.Center, LineAlignment = StringAlignment.Center })
                g.DrawString("A", f, Brushes.White, new RectangleF(0, 0, 36, 36), sf);
        }

        private void pnlTopBar_Paint(object sender, PaintEventArgs e)
        {
            using (var pen = new Pen(Color.FromArgb(228, 231, 242), 1))
                e.Graphics.DrawLine(pen, 0, pnlTopBar.Height - 1, pnlTopBar.Width, pnlTopBar.Height - 1);
        }

        private void pnlHeader_Paint(object sender, PaintEventArgs e)
        {
            var g = e.Graphics; g.SmoothingMode = SmoothingMode.AntiAlias;
            var ctrl = (Control)sender;
            using (var path = RR(new Rectangle(0, 0, ctrl.Width - 1, ctrl.Height - 1), 14))
            using (var b = new SolidBrush(Color.FromArgb(26, 30, 42)))
                g.FillPath(b, path);
            // White logo circle
            g.FillEllipse(Brushes.White, 18, 30, 36, 36);
            using (var f = new Font("Segoe UI", 13F, FontStyle.Bold))
            using (var sf = new StringFormat { Alignment = StringAlignment.Center, LineAlignment = StringAlignment.Center })
                g.DrawString("m", f, new SolidBrush(Color.FromArgb(26, 30, 42)),
                    new RectangleF(18, 30, 36, 36), sf);
        }

        private void pnlWhiteCard_Paint(object sender, PaintEventArgs e)
        {
            var g = e.Graphics; g.SmoothingMode = SmoothingMode.AntiAlias;
            var c = (Control)sender;
            using (var path = RR(new Rectangle(0, 0, c.Width - 1, c.Height - 1), 14))
            {
                using (var b = new SolidBrush(Color.White)) g.FillPath(b, path);
                using (var pen = new Pen(Color.FromArgb(226, 229, 242), 1)) g.DrawPath(pen, path);
            }
        }

        private void pnlTotals_Paint(object sender, PaintEventArgs e)
        {
            var g = e.Graphics;
            int x1 = pnlTotals.Width - 260;
            int xR = pnlTotals.Width - 14;
            int y = 4;

            using (var fLbl = new Font("Segoe UI", 9.5F))
            using (var fBold = new Font("Segoe UI", 9.5F, FontStyle.Bold))
            using (var bLbl = new SolidBrush(Color.FromArgb(110, 115, 138)))
            using (var bVal = new SolidBrush(Color.FromArgb(22, 25, 40)))
            using (var bGrn = new SolidBrush(Color.FromArgb(45, 165, 90)))
            using (var sfR = new StringFormat { Alignment = StringAlignment.Far })
            {
                // Subtotal
                g.DrawString("Subtotal", fLbl, bLbl, x1, y);
                g.DrawString("$" + _subtotal.ToString("0.00"), fBold, bVal,
                    new RectangleF(x1, y, xR - x1, 20), sfR);
                y += 28;
                using (var pen = new Pen(Color.FromArgb(236, 238, 248)))
                    g.DrawLine(pen, 0, y, pnlTotals.Width, y);
                y += 8;

                // Discount
                g.DrawString("Discount", fLbl, bLbl, x1, y);
                g.DrawString("Add", fBold, bGrn, new RectangleF(x1, y, xR - x1, 20), sfR);
                y += 28;
                using (var pen = new Pen(Color.FromArgb(236, 238, 248)))
                    g.DrawLine(pen, 0, y, pnlTotals.Width, y);
                y += 8;

                // Tax
                g.DrawString("Tax", fLbl, bLbl, x1, y);
                g.DrawString("Add", fBold, bGrn, new RectangleF(x1, y, xR - x1, 20), sfR);
                y += 28;
                using (var pen = new Pen(Color.FromArgb(210, 214, 230), 1.5f))
                    g.DrawLine(pen, 0, y, pnlTotals.Width, y);
                y += 10;

                // Total
                using (var fTotal = new Font("Segoe UI", 11F, FontStyle.Bold))
                {
                    g.DrawString("Total", fTotal, bVal, x1, y);
                        g.DrawString("$" + _subtotal.ToString("0.00"), fTotal, bVal,
                            new RectangleF(x1, y, xR - x1, 26), sfR);
                }
            }
        }

        private static GraphicsPath RR(Rectangle r, int rad)
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