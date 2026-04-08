using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Windows.Forms;
using System.Collections.Generic;
using PersonalFinanceManager.Infrastructure.DI;
using PersonalFinanceManager.Models;

namespace PersonalFinanceManager.Forms.Accounts
{
    public partial class AccountForm : Form
    {
        private int _currentAccountPage = 0;
        private const int _accountsPerPage = 4;
        private class AccountCardData
        {
            public string Title { get; set; }
            public string Amount { get; set; }
            public string PillText { get; set; }
            public string SyncText { get; set; }
            public Color TrimColor { get; set; }
            public Color PillBg { get; set; }
            public Account OriginalAccount { get; set; }
        }
        private List<AccountCardData> _accountData = new List<AccountCardData>();

        public AccountForm()
        {
            InitializeComponent();
            this.Load += AccountForm_Load;
            ApplyResponsiveLayout();
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

            // Link the Add Account action (Moved to constructor for reliability)
            if (this.btnAddAccount != null)
            {
                this.btnAddAccount.Click += (s, e) => {
                    using (var f = new AccountAddForm())
                    {
                        if (f.ShowDialog() == DialogResult.OK)
                        {
                            LoadAccountCards();
                            LoadInstitutions();
                        }
                    }
                };
            }

            // Portfolio Optimization Action (Mock)
            if (this.btnOptimize != null)
            {
                this.btnOptimize.Click += (s, ev) => {
                    Cursor.Current = Cursors.WaitCursor;
                    System.Threading.Tasks.Task.Delay(1500).ContinueWith(_ => {
                        this.Invoke(new Action(() => {
                            Cursor.Current = Cursors.Default;
                            var t = new Func<string, string>(PersonalFinanceManager.Common.Helpers.ConfigHelper.Translate);
                            MessageBox.Show(t("Analysis complete! Your portfolio is currently performing 15% better than the market average. All savings goals are on track."), t("Portfolio AI Analysis"), MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }));
                    });
                };
            }

            if (this.pnlAccountPagination != null)
            {
                this.pnlAccountPagination.Paint += PnlAccountPagination_Paint;
                this.pnlAccountPagination.MouseClick += PnlAccountPagination_MouseClick;
                this.pnlAccountPagination.Cursor = Cursors.Hand;
            }

            ServiceLocator.TransactionService.TransactionChanged += (s, e) => {
                if (this.IsHandleCreated) this.Invoke(new Action(() => {
                    LoadAccountCards();
                }));
            };
        }

        private void PnlAccountPagination_Paint(object sender, PaintEventArgs e)
        {
            var g = e.Graphics; g.SmoothingMode = SmoothingMode.AntiAlias;
            int totalPages = (int)Math.Ceiling(_accountData.Count / (double)_accountsPerPage);
            if (totalPages <= 1) return;

            int dotSize = 8;
            int spacing = 12;
            int totalWidth = (totalPages * dotSize) + ((totalPages - 1) * spacing);
            int startX = (pnlAccountPagination.Width - totalWidth) / 2;
            int y = (pnlAccountPagination.Height - dotSize) / 2;

            for (int i = 0; i < totalPages; i++)
            {
                Color dotColor = (i == _currentAccountPage) ? Color.FromArgb(183, 0, 82) : Color.LightGray;
                using (var brush = new SolidBrush(dotColor))
                {
                    g.FillEllipse(brush, startX + (i * (dotSize + spacing)), y, dotSize, dotSize);
                }
            }
        }

        private void PnlAccountPagination_MouseClick(object sender, MouseEventArgs e)
        {
            int totalPages = (int)Math.Ceiling(_accountData.Count / (double)_accountsPerPage);
            if (totalPages <= 1) return;

            int dotSize = 8;
            int spacing = 12;
            int totalWidth = (totalPages * dotSize) + ((totalPages - 1) * spacing);
            int startX = (pnlAccountPagination.Width - totalWidth) / 2;

            for (int i = 0; i < totalPages; i++)
            {
                var rect = new Rectangle(startX + (i * (dotSize + spacing)) - 5, 0, dotSize + 10, pnlAccountPagination.Height);
                if (rect.Contains(e.Location))
                {
                    _currentAccountPage = i;
                    RenderAccountCards();
                    pnlAccountPagination.Invalidate();
                    break;
                }
            }
        }

        private void ApplyTheme()
        {
            PersonalFinanceManager.Common.Helpers.ThemeHelper.ApplyTheme(this);
            
            // Override for btnOptimize to keep it readable on the white button bg
            if (this.btnOptimize != null)
            {
                this.btnOptimize.PrimaryColor = Color.White;
                this.btnOptimize.ForeColor = Color.FromArgb(183, 0, 82); // Vibrant Magenta
            }

            // Force insight text to white for contrast on the dark gradient
            if (this.lblInsightTitle != null) this.lblInsightTitle.ForeColor = Color.White;
            if (this.lblInsightText != null) this.lblInsightText.ForeColor = Color.FromArgb(240, 255, 255, 255);
            if (this.lblInsightStatus != null) this.lblInsightStatus.ForeColor = Color.FromArgb(200, 255, 255, 255);
            
            this.Refresh();
        }

        private void UpdateTranslations()
        {
            var t = new Func<string, string>(PersonalFinanceManager.Common.Helpers.ConfigHelper.Translate);

            if (this.lblPageTitle != null) this.lblPageTitle.Text = t("Financial Overview");
            if (this.lblPageSub != null) this.lblPageSub.Text = t("Manage your linked accounts and wallets");
            if (this.btnAddAccount != null) this.btnAddAccount.Text = t("+ Add New Account");

            if (this.lblInsightTitle != null) this.lblInsightTitle.Text = t("⚡ Quick Insights");
            if (this.lblInsightStatus != null) this.lblInsightStatus.Text = t("OPTIMIZATION STATUS        85%");
            if (this.btnOptimize != null) this.btnOptimize.Text = t("OPTIMIZE PORTFOLIO");

            if (this.lblInstTitle != null) this.lblInstTitle.Text = t("Institutional Connections");
            if (this.btnManageInst != null) this.btnManageInst.Text = t("Manage Connections >");

            if (this.lblInsightText != null) this.lblInsightText.Text = t("You've reached your savings goal for \"Main Savings\" 10 days earlier than projected. Consider moving...");

            // Re-render dynamically created strings
            LoadAccountCards();
            pnlInstitutions.Controls.Clear();
            LoadInstitutions();
        }


        private void AccountForm_Load(object sender, EventArgs e)
        {
            LoadAccountCards();
            LoadInstitutions();
            
            PersonalFinanceManager.Common.Helpers.ConfigHelper.CurrencyChanged += (s, ev) => 
            {
                if (this.IsHandleCreated) this.Invoke(new Action(() => {
                    LoadAccountCards();
                }));
            };
        }

        private void LoadInstitutions()
        {
            var t = new Func<string, string>(PersonalFinanceManager.Common.Helpers.ConfigHelper.Translate);
            pnlInstitutions.Controls.Clear();
            
            // Re-draw background card path
            pnlInstitutions.Paint -= pnlInstitutions_Paint;
            pnlInstitutions.Paint += pnlInstitutions_Paint;

            // Display "No active connections" message
            var lblEmpty = new Label 
            { 
                Text = t("No institutional connections found. Add a bank to sync your data."), 
                Font = new Font("Segoe UI", 9.5F, FontStyle.Italic), 
                ForeColor = Color.Gray, 
                TextAlign = ContentAlignment.MiddleCenter,
                Dock = DockStyle.Fill
            };
            pnlInstitutions.Controls.Add(lblEmpty);
            pnlInstitutions.Height = 150;
        }

        private int AddInstitutionRow(string name, string sub, string activeCount, bool encrypted, int yPos)
        {
            var pnlRow = new Panel { Size = new Size(pnlInstitutions.Width - 50, 60), Location = new Point(25, yPos), Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right };

            var lblName = new Label { Text = name, Font = new Font("Segoe UI", 10.5F, FontStyle.Bold), ForeColor = Color.FromArgb(25, 28, 29), Location = new Point(60, 5), AutoSize = true };
            var lblSub = new Label { Text = sub, Font = new Font("Segoe UI", 8.5F), ForeColor = Color.FromArgb(114, 120, 123), Location = new Point(60, 30), AutoSize = true };
            
            var t = new Func<string, string>(PersonalFinanceManager.Common.Helpers.ConfigHelper.Translate);
            var lblAccHead = new Label { Text = t("ACCOUNTS"), Font = new Font("Segoe UI", 7F, FontStyle.Bold), ForeColor = Color.Gray, Location = new Point(pnlRow.Width - 300, 8), AutoSize = true, Anchor = AnchorStyles.Top | AnchorStyles.Right };
            var lblAccVal = new Label { Text = activeCount, Font = new Font("Segoe UI", 10F, FontStyle.Bold), ForeColor = Color.Black, Location = new Point(pnlRow.Width - 300, 25), AutoSize = true, Anchor = AnchorStyles.Top | AnchorStyles.Right };
            
            var lblEnc = new Label { Text = "✔ " + t("Encrypted"), Font = new Font("Segoe UI", 8.5F, FontStyle.Bold), ForeColor = Color.FromArgb(24, 106, 34), Location = new Point(pnlRow.Width - 120, 20), AutoSize = true, Anchor = AnchorStyles.Top | AnchorStyles.Right };
            var lblDots = new Label { Text = "\u22EE", Font = new Font("Segoe UI", 16F, FontStyle.Bold), ForeColor = Color.Black, Location = new Point(pnlRow.Width - 20, 10), AutoSize = true, Cursor = Cursors.Hand, Anchor = AnchorStyles.Top | AnchorStyles.Right };

            pnlRow.Paint += (s, e) => {
                var g = e.Graphics; g.SmoothingMode = SmoothingMode.AntiAlias;
                g.FillPath(new SolidBrush(Color.FromArgb(230,240,245)), RoundedRect(new Rectangle(5, 10, 40, 40), 10)); // Icon block
            };

            pnlRow.Controls.Add(lblName); pnlRow.Controls.Add(lblSub);
            pnlRow.Controls.Add(lblAccHead); pnlRow.Controls.Add(lblAccVal);
            pnlRow.Controls.Add(lblEnc); pnlRow.Controls.Add(lblDots);
            pnlInstitutions.Controls.Add(pnlRow);
            
            var sep = new Panel { Size = new Size(pnlInstitutions.Width - 50, 1), Location = new Point(25, yPos + 65), BackColor = Color.FromArgb(240, 240, 240), Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right };
            pnlInstitutions.Controls.Add(sep);

            return yPos + 75;
        }

        private void LoadAccountCards()
        {
            var t = new Func<string, string>(PersonalFinanceManager.Common.Helpers.ConfigHelper.Translate);
            _accountData.Clear();
            
            try
            {
                var user = ServiceLocator.UserService.GetCurrentUser();
                if (user != null)
                {
                    var accounts = ServiceLocator.AccountService.GetByCurrentUser();
                    foreach (var acc in accounts)
                    {
                        string pillText = acc.IsActive ? t("ACTIVE") : t("INACTIVE");
                        Color pillColor = acc.IsActive ? Color.FromArgb(40, 100, 40) : Color.FromArgb(100, 100, 100);
                        Color pillBg = acc.IsActive ? Color.FromArgb(230, 250, 230) : Color.FromArgb(240, 240, 240);
                        
                        string syncText = t("Synced") + " " + GetRelativeTime(acc.CreatedAt);
                        
                        _accountData.Add(new AccountCardData {
                            Title = acc.AccountName.ToUpper(),
                            Amount = PersonalFinanceManager.Common.Helpers.ConfigHelper.FormatGlobalCurrency(acc.Balance),
                            PillText = pillText,
                            SyncText = syncText,
                            TrimColor = pillColor,
                            PillBg = pillBg,
                            OriginalAccount = acc
                        });
                    }
                }
            }
            catch { }

            if (_accountData.Count == 0)
            {
                _accountData.Add(new AccountCardData { Title = t("MAIN SAVINGS"), Amount = PersonalFinanceManager.Common.Helpers.ConfigHelper.FormatGlobalCurrency(42850.24m), PillText = t("ACTIVE"), SyncText = t("Synced") + " 3" + t("m ago"), TrimColor = Color.FromArgb(40, 100, 40), PillBg = Color.FromArgb(230, 250, 230) });
                _accountData.Add(new AccountCardData { Title = t("AMEX PLATINUM"), Amount = "-" + PersonalFinanceManager.Common.Helpers.ConfigHelper.FormatGlobalCurrency(2140.12m), PillText = t("DUE SOON"), SyncText = t("Synced") + " 1" + t("h ago"), TrimColor = Color.FromArgb(183, 0, 82), PillBg = Color.FromArgb(255, 230, 240) });
            }

            RenderAccountCards();
        }

        private void RenderAccountCards()
        {
            flpAccounts.Controls.Clear();
            int totalPages = (int)Math.Ceiling(_accountData.Count / (double)_accountsPerPage);
            if (_currentAccountPage >= totalPages && totalPages > 0) _currentAccountPage = totalPages - 1;
            if (_currentAccountPage < 0) _currentAccountPage = 0;

            var pageData = _accountData.Skip(_currentAccountPage * _accountsPerPage).Take(_accountsPerPage);
            foreach (var d in pageData)
            {
                flpAccounts.Controls.Add(CreateAccountCard(d));
            }
            pnlAccountPagination.Invalidate();
        }

        private string GetRelativeTime(DateTime dt)
        {
            var t = new Func<string, string>(PersonalFinanceManager.Common.Helpers.ConfigHelper.Translate);
            var span = DateTime.Now - dt;
            if (span.TotalDays > 1) return (int)span.TotalDays + t("d ago");
            if (span.TotalHours > 1) return (int)span.TotalHours + t("h ago");
            if (span.TotalMinutes > 1) return (int)span.TotalMinutes + t("m ago");
            return t("Just now");
        }

        private Panel CreateAccountCard(AccountCardData data)
        {
            var pnl = new Panel { Size = new Size(260, 230), Margin = new Padding(0, 0, 15, 0), BackColor = Color.Transparent };

            var lblTitle = new Label { Text = data.Title, Font = new Font("Segoe UI", 8F, FontStyle.Bold), ForeColor = Color.Gray, Location = new Point(30, 110), AutoSize = true };
            var lblAmount = new Label { Text = data.Amount, Font = new Font("Segoe UI", 18F, FontStyle.Bold), ForeColor = Color.FromArgb(40,80,100), Location = new Point(25, 130), AutoSize = true };

            if (data.OriginalAccount != null)
            {
                var btnEdit = new Label
                {
                    Text = "✎",
                    Font = new Font("Segoe UI", 12F, FontStyle.Bold),
                    ForeColor = Color.DarkGray,
                    Cursor = Cursors.Hand,
                    Location = new Point(225, 185),
                    AutoSize = true,
                    BackColor = Color.Transparent
                };
                btnEdit.MouseEnter += (s, e) => btnEdit.ForeColor = Color.FromArgb(183, 0, 82);
                btnEdit.MouseLeave += (s, e) => btnEdit.ForeColor = Color.DarkGray;
                btnEdit.Click += (s, e) =>
                {
                    using (var f = new AccountEditForm(data.OriginalAccount))
                    {
                        if (f.ShowDialog() == DialogResult.OK)
                        {
                            LoadAccountCards();
                        }
                    }
                };
                pnl.Controls.Add(btnEdit);
            }

            pnl.Paint += (s, e) => {
                var g = e.Graphics; g.SmoothingMode = SmoothingMode.AntiAlias;
                var rect = new Rectangle(0, 0, pnl.Width - 1, pnl.Height - 1);
                // Card bg
                using (var path = RoundedRect(rect, 15)) 
                {
                    g.FillPath(new SolidBrush(PersonalFinanceManager.Common.Helpers.ThemeHelper.CardBackground), path);
                    using (var pen = new Pen(PersonalFinanceManager.Common.Helpers.ThemeHelper.Border, 1)) 
                        g.DrawPath(pen, path);
                }
                
                // Thick Left border
                g.FillRectangle(new SolidBrush(data.TrimColor), 0, 15, 5, pnl.Height - 30);

                // Icon Box
                g.FillPath(new SolidBrush(data.PillBg), RoundedRect(new Rectangle(30,30,40,40), 10));
                
                // Draw pill
                g.FillPath(new SolidBrush(data.PillBg), RoundedRect(new Rectangle(150, 35, 80, 24), 12));
                using(var sf = new StringFormat{Alignment = StringAlignment.Center, LineAlignment = StringAlignment.Center})
                    g.DrawString(data.PillText, new Font("Segoe UI", 7F, FontStyle.Bold), new SolidBrush(data.TrimColor), new Rectangle(150, 35, 80, 24), sf);
                
                g.DrawString(data.SyncText, new Font("Segoe UI", 6.5F), Brushes.Gray, 142, 70);
            };

            pnl.Controls.Add(lblTitle); pnl.Controls.Add(lblAmount);
            return pnl;
        }


        private void pnlInsights_Paint(object sender, PaintEventArgs e)
        {
            var g = e.Graphics; g.SmoothingMode = SmoothingMode.AntiAlias;
            var rect = new Rectangle(0, 0, pnlInsights.Width - 1, pnlInsights.Height - 1);
            using (var path = RoundedRect(rect, 15))
            {
                // Premium Gradient from Deep Indigo to Vibrant Magenta
                using (var brush = new LinearGradientBrush(rect, Color.FromArgb(45, 20, 90), Color.FromArgb(183, 0, 82), 45F))
                {
                    g.FillPath(brush, path);
                }
                
                // Subtle Glow/Inner Border
                using (var pen = new Pen(Color.FromArgb(100, 255, 255, 255), 1))
                {
                    g.DrawPath(pen, path);
                }
            }
        }

        private void pnlInstitutions_Paint(object sender, PaintEventArgs e)
        {
            var g = e.Graphics; g.SmoothingMode = SmoothingMode.AntiAlias;
            using (var path = RoundedRect(new Rectangle(0, 0, pnlInstitutions.Width - 1, pnlInstitutions.Height - 1), 15))
                 g.FillPath(new SolidBrush(PersonalFinanceManager.Common.Helpers.ThemeHelper.CardBackground), path);
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
        
        private static GraphicsPath RoundedRectTop(Rectangle r, int radius)
        {
            var path = new GraphicsPath();
            path.AddArc(r.X, r.Y, radius * 2, radius * 2, 180, 90);
            path.AddArc(r.Right - radius * 2, r.Y, radius * 2, radius * 2, 270, 90);
            path.AddLine(r.Right, r.Bottom, r.X, r.Bottom);
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

                btnAddAccount.Anchor = AnchorStyles.Top | AnchorStyles.Right;
                btnManageInst.Anchor = AnchorStyles.Top | AnchorStyles.Right;
                

                contentPanel.SizeChanged += (s, e) => {
                    int w = contentPanel.ClientSize.Width;
                    int margin = 30;

                    flpAccounts.Width = w - margin * 2;
                    pnlInsights.Width = w - margin * 2;
                    pnlInstitutions.Width = w - margin * 2;
                    
                    pnlInsights.Invalidate();
                    pnlInstitutions.Invalidate();
                };
            }
        }
}
}



