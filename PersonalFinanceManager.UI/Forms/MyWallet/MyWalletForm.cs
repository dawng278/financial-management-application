using PersonalFinanceManager.Infrastructure.DI;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Windows.Forms;

namespace PersonalFinanceManager.Forms.MyWallet
{
    public partial class MyWalletForm : Form
    {
        // ── Payment model ─────────────────────────────────────────────────────────
        public class PaymentRow
        {
            public string Name { get; set; }
            public DateTime Date { get; set; }
            public decimal Amount { get; set; }
            public bool IsIncome { get; set; }   // true = green +, false = red -
            public bool IsUpcoming { get; set; }
            public Color IconBg { get; set; }
            public string IconText { get; set; }   // single letter or symbol drawn
            public Color IconFg { get; set; }
        }

        private List<PaymentRow> _allPayments;
        private bool _showAll = true;  // tab state

        // ── Active tab underline colour ───────────────────────────────────────────
        private static readonly Color Accent = Color.FromArgb(181, 212, 34);

        public MyWalletForm()
        {
            InitializeComponent();
            LoadMockData();

            this.Load += MyWalletForm_Load;
            this.SizeChanged += MyWalletForm_SizeChanged;
        }

        // =====================================================================
        // LOAD
        // =====================================================================
        private void MyWalletForm_Load(object sender, EventArgs e)
        {
            try
            {
                var u = ServiceLocator.UserService.GetCurrentUser();
                if (u != null) lblUsername.Text = u.FullName ?? u.Email ?? "Admin";
            }
            catch { }

            LayoutTopBar();
            LayoutSidebarBottom();
            LayoutPanels();
            BuildPaymentRows();
        }

        // =====================================================================
        // MOCK DATA
        // =====================================================================
        private void LoadMockData()
        {
            _allPayments = new List<PaymentRow>
            {
                // Today
                new PaymentRow { Name="Payoneer",     Date=new DateTime(2022,4,20,18,55,0), Amount=4800.24m,  IsIncome=true,  IsUpcoming=false, IconBg=Color.White,                      IconText="P",  IconFg=Color.FromArgb(255,150,0)  },
                new PaymentRow { Name="Remitly",      Date=new DateTime(2022,4,18, 8,58,0), Amount=1800.24m,  IsIncome=false, IsUpcoming=false, IconBg=Color.FromArgb(235,250,242),      IconText="R",  IconFg=Color.FromArgb(30,160,90)  },
                new PaymentRow { Name="Wise",         Date=new DateTime(2022,4,15, 2,55,0), Amount=24.32m,    IsIncome=false, IsUpcoming=false, IconBg=Color.FromArgb(232,248,255),      IconText="W",  IconFg=Color.FromArgb(30,140,220) },
                new PaymentRow { Name="Paypal",       Date=new DateTime(2022,4,14, 7,40,0), Amount=400.32m,   IsIncome=false, IsUpcoming=false, IconBg=Color.FromArgb(228,238,255),      IconText="P",  IconFg=Color.FromArgb(0,60,180)   },
                // Upcoming
                new PaymentRow { Name="Facebooks Ads",Date=new DateTime(2022,4,20,18,55,0), Amount=400.00m,   IsIncome=false, IsUpcoming=true,  IconBg=Color.FromArgb(24,119,242),       IconText="f",  IconFg=Color.White                 },
                new PaymentRow { Name="LinkedIn Ads", Date=new DateTime(2022,4,18, 8,58,0), Amount=200.50m,   IsIncome=false, IsUpcoming=true,  IconBg=Color.FromArgb(0,119,181),        IconText="in", IconFg=Color.White                 },
            };
        }

        // =====================================================================
        // BUILD PAYMENT ROWS  (dynamic panel rows)
        // =====================================================================
        private void BuildPaymentRows()
        {
            pnlPaymentList.Controls.Clear();
            pnlUpcomingList.Controls.Clear();

            string q = txtSearchPayment.Text.Trim().ToLower();

            var today = _allPayments.Where(p => !p.IsUpcoming &&
                           (string.IsNullOrEmpty(q) || p.Name.ToLower().Contains(q))).ToList();
            var upcoming = _allPayments.Where(p => p.IsUpcoming &&
                           (string.IsNullOrEmpty(q) || p.Name.ToLower().Contains(q))).ToList();

            if (!_showAll)
            {
                today = today.Where(p => !p.IsIncome).ToList();
                upcoming = upcoming.ToList();
            }

            int yT = 0;
            foreach (var row in today)
            {
                var r = MakePaymentRow(row, yT, pnlPaymentList.Width);
                pnlPaymentList.Controls.Add(r);
                yT += 72;
            }
            pnlPaymentList.Height = Math.Max(72, yT);

            int yU = 0;
            foreach (var row in upcoming)
            {
                var r = MakePaymentRow(row, yU, pnlUpcomingList.Width);
                pnlUpcomingList.Controls.Add(r);
                yU += 72;
            }
            pnlUpcomingList.Height = Math.Max(72, yU);

            // Shift upcoming section label
            int upcomingY = pnlPaymentList.Top + pnlPaymentList.Height + 24;
            lblSectionUpcoming.Top = upcomingY;
            lblNextMonth.Top = upcomingY + 30;
            pnlUpcomingList.Top = upcomingY + 54;
        }

        private Panel MakePaymentRow(PaymentRow data, int y, int width)
        {
            var pnl = new Panel
            {
                Location = new Point(0, y),
                Size = new Size(width, 68),
                BackColor = Color.Transparent
            };
            pnl.Paint += (s, e) =>
            {
                var g = e.Graphics;
                g.SmoothingMode = SmoothingMode.AntiAlias;

                // Icon circle
                int d = 44;
                using (var b = new SolidBrush(data.IconBg))
                    g.FillEllipse(b, 0, 12, d, d);

                // Special Payoneer rainbow ring
                if (data.Name == "Payoneer")
                {
                    using (var pen = new Pen(Color.FromArgb(255, 80, 80), 3)) g.DrawArc(pen, 4, 16, 36, 36, 180, 90);
                    using (var pen = new Pen(Color.FromArgb(255, 200, 0), 3)) g.DrawArc(pen, 4, 16, 36, 36, 270, 90);
                    using (var pen = new Pen(Color.FromArgb(80, 200, 120), 3)) g.DrawArc(pen, 4, 16, 36, 36, 0, 90);
                    using (var pen = new Pen(Color.FromArgb(80, 140, 255), 3)) g.DrawArc(pen, 4, 16, 36, 36, 90, 90);
                }
                else
                {
                    using (var f = new Font("Segoe UI", data.IconText.Length > 1 ? 9F : 13F, FontStyle.Bold))
                    using (var sf = new StringFormat { Alignment = StringAlignment.Center, LineAlignment = StringAlignment.Center })
                    using (var fb = new SolidBrush(data.IconFg))
                        g.DrawString(data.IconText, f, fb, new RectangleF(0, 12, d, d), sf);
                }

                // Name
                using (var fN = new Font("Segoe UI", 10F, FontStyle.Bold))
                using (var bN = new SolidBrush(Color.FromArgb(18, 22, 40)))
                    g.DrawString(data.Name, fN, bN, 54, 14);

                // Date
                using (var fD = new Font("Segoe UI", 8.5F))
                using (var bD = new SolidBrush(Color.FromArgb(148, 153, 175)))
                    g.DrawString(data.Date.ToString("dd MMM yyyy, hh:mm tt"), fD, bD, 54, 36);

                // Amount (right-aligned)
                string amtText = data.IsUpcoming
                    ? "$" + data.Amount.ToString("0.00")
                    : (data.IsIncome ? "+ $" : "- $") + data.Amount.ToString("0.00");
                Color amtColor = data.IsUpcoming
                    ? Color.FromArgb(22, 25, 40)
                    : data.IsIncome ? Color.FromArgb(22, 168, 90) : Color.FromArgb(205, 50, 50);

                using (var fA = new Font("Segoe UI", 10F, FontStyle.Bold))
                using (var sfR = new StringFormat { Alignment = StringAlignment.Far })
                using (var bA = new SolidBrush(amtColor))
                    g.DrawString(amtText, fA, bA, new RectangleF(0, 22, pnl.Width - 4, 24), sfR);

                // Bottom divider
                using (var pen = new Pen(Color.FromArgb(236, 238, 248)))
                    g.DrawLine(pen, 0, 67, pnl.Width, 67);
            };
            return pnl;
        }

        // =====================================================================
        // TAB SWITCHING
        // =====================================================================
        private void btnTabAll_Click(object sender, EventArgs e)
        {
            _showAll = true;
            btnTabAll.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            btnTabAll.ForeColor = Color.FromArgb(22, 24, 35);
            btnTabRegular.Font = new Font("Segoe UI", 9.5F);
            btnTabRegular.ForeColor = Color.FromArgb(148, 153, 172);
            pnlTabs.Invalidate();
            BuildPaymentRows();
        }

        private void btnTabRegular_Click(object sender, EventArgs e)
        {
            _showAll = false;
            btnTabRegular.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            btnTabRegular.ForeColor = Color.FromArgb(22, 24, 35);
            btnTabAll.Font = new Font("Segoe UI", 9.5F);
            btnTabAll.ForeColor = Color.FromArgb(148, 153, 172);
            pnlTabs.Invalidate();
            BuildPaymentRows();
        }

        private void txtSearchPayment_TextChanged(object sender, EventArgs e) => BuildPaymentRows();

        // =====================================================================
        // ADD NEW CARD
        // =====================================================================
        private void lnkAddCard_Click(object sender, EventArgs e)
            => MessageBox.Show("Add New Card feature coming soon.", "Add Card",
                MessageBoxButtons.OK, MessageBoxIcon.Information);

        // =====================================================================
        // LAYOUT
        // =====================================================================
        private void MyWalletForm_SizeChanged(object sender, EventArgs e)
        {
            LayoutTopBar();
            LayoutSidebarBottom();
            LayoutPanels();
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

        private void LayoutPanels()
        {
            int pad = pnlMain.Padding.Left;
            int avail = pnlMain.ClientSize.Width - pad * 2;
            int high = pnlMain.ClientSize.Height - pad * 2;

            int leftW = 360;
            int gap = 30;
            int rightW = avail - leftW - gap;

            pnlLeft.Location = new Point(pad, pad);
            pnlLeft.Size = new Size(leftW, Math.Max(580, high));

            pnlCardsStack.Width = leftW;
            pnlCard1.Width = leftW;
            pnlCard2.Width = leftW - 20;
            pnlBalanceCard.Width = leftW;
            pnlAddCard.Width = leftW;
            lnkAddCard.Location = new Point((leftW - lnkAddCard.Width) / 2, 18);

            pnlRight.Location = new Point(pad + leftW + gap, pad);
            pnlRight.Size = new Size(rightW, Math.Max(580, high));

            pnlTabs.Width = rightW;
            txtSearchPayment.Location = new Point(rightW - 200, 4);
            pnlPaymentList.Width = rightW;
            pnlUpcomingList.Width = rightW;

            BuildPaymentRows();
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

        // ── Credit card 1: Dark (Universal Bank) ─────────────────────────────────
        private void pnlCard1_Paint(object sender, PaintEventArgs e)
        {
            var g = e.Graphics; g.SmoothingMode = SmoothingMode.AntiAlias;
            var c = (Control)sender;
            var r = new Rectangle(0, 0, c.Width - 1, c.Height - 1);

            // Dark rounded card body
            using (var path = RR(r, 18))
            using (var b = new LinearGradientBrush(r,
                Color.FromArgb(38, 42, 58), Color.FromArgb(28, 30, 44), 135f))
                g.FillPath(b, path);

            // Subtle shine overlay
            using (var shine = new LinearGradientBrush(
                new Rectangle(0, 0, c.Width, c.Height / 2),
                Color.FromArgb(30, 255, 255, 255), Color.Transparent, 90f))
            using (var path = RR(new Rectangle(0, 0, c.Width - 1, c.Height / 2), 18))
                g.FillPath(shine, path);

            // Bank name + separator
            using (var fB = new Font("Segoe UI", 10F, FontStyle.Bold))
                g.DrawString("Maglo.", fB, Brushes.White, 20, 18);
            using (var fSep = new Font("Segoe UI", 9F))
            using (var bSep = new SolidBrush(Color.FromArgb(130, 140, 165)))
                g.DrawString("Universal Bank", fSep, bSep, 90, 20);

            // Chip icon (rounded rect)
            using (var chipPath = RR(new Rectangle(20, 52, 38, 28), 5))
            using (var b = new SolidBrush(Color.FromArgb(200, 185, 100)))
            {
                g.FillPath(b, chipPath);
                using (var pen = new Pen(Color.FromArgb(170, 155, 80), 1))
                    g.DrawPath(pen, chipPath);
                // Chip lines
                using (var pen = new Pen(Color.FromArgb(160, 140, 70), 1))
                {
                    g.DrawLine(pen, 39, 52, 39, 80);
                    g.DrawLine(pen, 20, 66, 58, 66);
                }
            }

            // NFC icon (arcs)
            using (var pen = new Pen(Color.FromArgb(160, 180, 200), 2f))
            {
                g.DrawArc(pen, c.Width - 46, 52, 12, 28, 300, 120);
                g.DrawArc(pen, c.Width - 38, 48, 14, 36, 300, 120);
                g.DrawArc(pen, c.Width - 30, 44, 16, 44, 300, 120);
            }

            // Card number
            using (var fN = new Font("Segoe UI", 15F, FontStyle.Bold))
            using (var bN = new SolidBrush(Color.FromArgb(220, 225, 240)))
                g.DrawString("5495   7381   3759   2321", fN, bN, 20, 106);

            // Maglo label bottom-left (no expiry on dark card)
            using (var fL = new Font("Segoe UI", 9F, FontStyle.Bold))
                g.DrawString("Maglo.", fL, Brushes.White, 20, 155);
        }

        // ── Credit card 2: White (Commercial Bank) ────────────────────────────────
        private void pnlCard2_Paint(object sender, PaintEventArgs e)
        {
            var g = e.Graphics; g.SmoothingMode = SmoothingMode.AntiAlias;
            var c = (Control)sender;
            var r = new Rectangle(0, 0, c.Width - 1, c.Height - 1);

            // White card body
            using (var path = RR(r, 18))
            using (var b = new LinearGradientBrush(r,
                Color.FromArgb(240, 243, 250), Color.FromArgb(250, 252, 255), 135f))
                g.FillPath(b, path);
            using (var path = RR(r, 18))
            using (var pen = new Pen(Color.FromArgb(215, 220, 235), 1))
                g.DrawPath(pen, path);

            // Bank name
            using (var fB = new Font("Segoe UI", 10F, FontStyle.Bold))
            using (var bB = new SolidBrush(Color.FromArgb(28, 32, 50)))
                g.DrawString("Maglo.", fB, bB, 20, 14);
            using (var fSep = new Font("Segoe UI", 9F))
            using (var bSep = new SolidBrush(Color.FromArgb(145, 150, 170)))
                g.DrawString("Commercial Bank", fSep, bSep, 88, 16);

            // Chip
            using (var chipPath = RR(new Rectangle(20, 46, 36, 26), 5))
            using (var b = new SolidBrush(Color.FromArgb(195, 180, 95)))
            {
                g.FillPath(b, chipPath);
                using (var pen = new Pen(Color.FromArgb(165, 150, 75), 1))
                    g.DrawPath(pen, chipPath);
                using (var pen = new Pen(Color.FromArgb(155, 140, 65), 1))
                {
                    g.DrawLine(pen, 38, 46, 38, 72);
                    g.DrawLine(pen, 20, 59, 56, 59);
                }
            }

            // NFC
            using (var pen = new Pen(Color.FromArgb(170, 175, 195), 2f))
            {
                g.DrawArc(pen, c.Width - 44, 46, 12, 28, 300, 120);
                g.DrawArc(pen, c.Width - 36, 42, 14, 36, 300, 120);
                g.DrawArc(pen, c.Width - 28, 38, 16, 44, 300, 120);
            }

            // Masked card number
            using (var fN = new Font("Segoe UI", 14F, FontStyle.Bold))
            using (var bN = new SolidBrush(Color.FromArgb(38, 42, 60)))
                g.DrawString("85952548****", fN, bN, 20, 92);

            // Expiry
            using (var fE = new Font("Segoe UI", 9F))
            using (var bE = new SolidBrush(Color.FromArgb(145, 150, 175)))
                g.DrawString("09/25", fE, bE, 20, 122);

            // Visa logo (simplified text badge)
            var visaRect = new Rectangle(c.Width - 72, 122, 58, 26);
            using (var vb = new SolidBrush(Color.FromArgb(26, 31, 113)))
                g.FillRectangle(vb, visaRect);
            using (var vf = new Font("Arial", 11F, FontStyle.Bold | FontStyle.Italic))
            using (var sf = new StringFormat { Alignment = StringAlignment.Center, LineAlignment = StringAlignment.Center })
                g.DrawString("VISA", vf, Brushes.White, visaRect, sf);
        }

        // ── Tabs underline ────────────────────────────────────────────────────────
        private void pnlTabs_Paint(object sender, PaintEventArgs e)
        {
            // Bottom border line across full width
            using (var pen = new Pen(Color.FromArgb(228, 231, 242), 1))
                e.Graphics.DrawLine(pen, 0, pnlTabs.Height - 1, pnlTabs.Width, pnlTabs.Height - 1);

            // Active tab underline
            int ux = _showAll ? btnTabAll.Left : btnTabRegular.Left;
            int uw = _showAll ? btnTabAll.Width : btnTabRegular.Width;
            using (var pen = new Pen(Accent, 3))
                e.Graphics.DrawLine(pen, ux, pnlTabs.Height - 1, ux + uw, pnlTabs.Height - 1);
        }

        // ── White card (rounded, white bg + subtle border) ────────────────────────
        private void pnlWhiteCard_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
            var c = (Control)sender;
            var r = new Rectangle(0, 0, c.Width - 1, c.Height - 1);
            using (var path = RR(r, 14))
            {
                using (var b = new SolidBrush(Color.White)) e.Graphics.FillPath(b, path);
                using (var pen = new Pen(Color.FromArgb(226, 229, 242), 1)) e.Graphics.DrawPath(pen, path);
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