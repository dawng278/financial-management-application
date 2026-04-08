using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using ReaLTaiizor.Controls;
using Panel = System.Windows.Forms.Panel;
using PersonalFinanceManager.Helpers;
using System.Linq;

namespace PersonalFinanceManager.UI.Forms.Goals
{
    public partial class GoalManagementForm : Form
    {
        private string t(string key) => PersonalFinanceManager.Common.Helpers.ConfigHelper.Translate(key);
        private System.Collections.Generic.List<PersonalFinanceManager.Models.Transaction> _recentGoalActivities = new System.Collections.Generic.List<PersonalFinanceManager.Models.Transaction>();

        public GoalManagementForm()

        {
            InitializeComponent();
            lblTotalAmt.Text = PersonalFinanceManager.Common.Helpers.ConfigHelper.FormatGlobalCurrency(0);
            LoadGoals();
            ApplyResponsiveLayout();

            txtSearch.TextChanged += (s, e) => LoadGoals();
            
            // Link Add Button
            btnAddGoal.Click += (s, e) => {
                using (var frm = new GoalAddForm())
                {
                    if (frm.ShowDialog() == DialogResult.OK)
                    {
                        LoadGoals();
                    }
                }
            };

            Infrastructure.DI.ServiceLocator.GoalService.GoalChanged += (s, ev) => {
                if (this.IsHandleCreated) this.Invoke(new Action(() => LoadGoals()));
            };

            Infrastructure.DI.ServiceLocator.TransactionService.TransactionChanged += (s, ev) => {
                if (this.IsHandleCreated) this.Invoke(new Action(() => LoadGoals()));
            };

            
            PersonalFinanceManager.Common.Helpers.ConfigHelper.CurrencyChanged += (s, ev) => 
            {
                if (this.IsHandleCreated) this.Invoke(new Action(() => {
            lblTotalAmt.Text = PersonalFinanceManager.Common.Helpers.ConfigHelper.FormatGlobalCurrency(0);
            flpGoals.Controls.Clear();
            LoadGoals();
                    pnlActivity.Invalidate();
                    pnlAdvice.Invalidate();
                }));
            };

            PersonalFinanceManager.Common.Helpers.ConfigHelper.LanguageChanged += (s, ev) => 
            {
                if (this.IsHandleCreated) this.Invoke(new Action(() => {
                    UpdateTranslations();
                }));
            };
            UpdateTranslations();

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
            pnlTotalProgress.Invalidate();
            pnlActivity.Invalidate();
            
            // Re-render goal cards with new theme colors if needed (or just invalidate their parents)
            flpGoals.Controls.Clear();
            LoadGoals();
            this.Refresh();
        }

        private void UpdateTranslations()
        {
            if (this.lblPageTitle != null) this.lblPageTitle.Text = t("Financial Goals");
            if (this.txtSearch != null) 
            {
                this.txtSearch.Text = "";
                this.txtSearch.SetPlaceholder(t("Search goals..."));
            }
            if (this.btnAddGoal != null) this.btnAddGoal.Text = t("+ Add Goal");
            if (this.lblTotalSub != null) this.lblTotalSub.Text = t("TOTAL SAVINGS PROGRESS");
            if (this.lblActiveTitle != null) this.lblActiveTitle.Text = t("Active Savings Goals");
            if (this.lblActivityTitle != null) this.lblActivityTitle.Text = t("Recent Goal Activity");
            if (this.btnOptimize != null) this.btnOptimize.Text = t("Optimize\nSavings");

            // Rebuild goals list for nested dynamic components
            flpGoals.Controls.Clear();
            LoadGoals();

            pnlActivity.Invalidate();
        }

        private void LoadGoals()
        {
            flpGoals.Controls.Clear();

            var goals = Infrastructure.DI.ServiceLocator.GoalService.GetAll();
            string q = txtSearch?.Text?.Trim().ToLower();
            if (!string.IsNullOrEmpty(q))
            {
                goals = goals.Where(g => g.Title.ToLower().Contains(q)).ToList();
            }
            
            decimal totalSaved = 0;
            decimal totalTarget = 0;

            foreach (var goal in goals)
            {
                totalSaved += goal.CurrentAmount;
                totalTarget += goal.TargetAmount;

                // Simple color cycling based on goal title/id
                Color themeColor = Color.FromArgb(183, 30, 80); // Default Red
                Color iconBgColor = Color.FromArgb(250, 230, 240);
                
                if (goal.Id % 3 == 1) { themeColor = Color.FromArgb(40, 110, 40); iconBgColor = Color.FromArgb(230, 245, 230); } // Green
                else if (goal.Id % 3 == 2) { themeColor = Color.FromArgb(80, 100, 120); iconBgColor = Color.FromArgb(235, 240, 245); } // Blue-gray

                flpGoals.Controls.Add(CreateGoalCard(goal, themeColor, iconBgColor));
            }


            lblTotalAmt.Text = PersonalFinanceManager.Common.Helpers.ConfigHelper.FormatGlobalCurrency(totalSaved);
            lblTotalTarget.Text = string.Format(t("of {0} goal"), 
                PersonalFinanceManager.Common.Helpers.ConfigHelper.FormatGlobalCurrency(totalTarget));
            
            int totalPct = totalTarget > 0 ? (int)(totalSaved / totalTarget * 100) : 0;
            lblTotalPct.Text = string.Format(t("{0}% Achieved"), Math.Min(totalPct, 100));
            
            // Fetch real recent activity
            try
            {
                var recentTxs = Infrastructure.DI.ServiceLocator.TransactionService.GetRecent(50);
                _recentGoalActivities = System.Linq.Enumerable.ToList(
                    System.Linq.Enumerable.Take(
                        System.Linq.Enumerable.OrderByDescending(
                            System.Linq.Enumerable.Where(recentTxs, tx => 
                                (tx.Note != null && (
                                    tx.Note.IndexOf("goal", StringComparison.OrdinalIgnoreCase) >= 0 || 
                                    tx.Note.IndexOf("mục tiêu", StringComparison.OrdinalIgnoreCase) >= 0 ||
                                    tx.Note.IndexOf("nạp tiền", StringComparison.OrdinalIgnoreCase) >= 0 ||
                                    tx.Note.IndexOf("deposit", StringComparison.OrdinalIgnoreCase) >= 0
                                )) || 
                                tx.ImportSource == "GoalDeposit" ||
                                tx.ImportSource == "Milestone"
                            ), 
                            tx => tx.TransactionDate
                        ), 
                        8
                    )
                );
            }
            catch { _recentGoalActivities.Clear(); }

            pnlTotalProgress.Invalidate();
            pnlActivity.Invalidate();
        }

        private Panel CreateGoalCard(PersonalFinanceManager.Models.Goal goal, Color themeColor, Color iconBgColor)
        {
            var pnl = new Panel { Size = new Size(330, 250), Margin = new Padding(0, 0, 30, 0), BackColor = Color.Transparent };
            
            var lblTitle = new Label { Text = goal.Title, Font = new Font("Segoe UI", 12F, FontStyle.Bold), ForeColor = PersonalFinanceManager.Common.Helpers.ThemeHelper.Text, Location = new Point(25, 75), AutoSize = true };
            var lblTarget = new Label { Text = t("Target: ") + goal.TargetDate.ToString("MMMM yyyy"), Font = new Font("Segoe UI", 8.5F), ForeColor = PersonalFinanceManager.Common.Helpers.ThemeHelper.SubText, Location = new Point(25, 100), AutoSize = true };
            
            var lblSaved = new Label { Text = PersonalFinanceManager.Common.Helpers.ConfigHelper.FormatGlobalCurrency(goal.CurrentAmount), Font = new Font("Segoe UI", 9.5F, FontStyle.Bold), ForeColor = themeColor, Location = new Point(25, 130), AutoSize = true };
            var lblLimit = new Label { Text = " / " + PersonalFinanceManager.Common.Helpers.ConfigHelper.FormatGlobalCurrency(goal.TargetAmount), Font = new Font("Segoe UI", 9F), ForeColor = Color.Gray, Location = new Point(lblSaved.Right + 5, 131), AutoSize = true };
            var lblPct = new Label { Text = $"{goal.ProgressPercentage}%", Font = new Font("Segoe UI", 9F, FontStyle.Bold), ForeColor = Color.FromArgb(40, 40, 40), Location = new Point(285, 131), AutoSize = true };


            var btnDeposit = new HopeButton
            {
                Text = t("Make a Deposit"),
                Font = new Font("Segoe UI", 9F, FontStyle.Bold),
                PrimaryColor = themeColor,
                ForeColor = Color.White,
                Location = new Point(25, 175),
                Size = new Size(280, 35),
                Cursor = Cursors.Hand
            };

            btnDeposit.Click += (s, e) => {
                using (var frm = new GoalDepositForm(goal))
                {
                    if (frm.ShowDialog() == DialogResult.OK)
                    {
                        LoadGoals();
                    }
                }
            };

            if (goal.CurrentAmount >= goal.TargetAmount)
            {
                btnDeposit.Text = "★ " + t("Goal Achieved!");
                btnDeposit.Enabled = false;
                btnDeposit.PrimaryColor = Color.FromArgb(40, 110, 40);
                btnDeposit.ForeColor = Color.White;
            }

            pnl.Controls.Add(btnDeposit);


            pnl.Paint += (s, e) => {
                var g = e.Graphics; g.SmoothingMode = SmoothingMode.AntiAlias;
                var rect = new Rectangle(0, 0, pnl.Width - 1, pnl.Height - 1);
                
                // Card bg
                using (var path = RoundedRect(rect, 15)) 
                {
                    g.FillPath(new SolidBrush(PersonalFinanceManager.Common.Helpers.ThemeHelper.CardBackground), path);
                    g.DrawPath(new Pen(PersonalFinanceManager.Common.Helpers.ThemeHelper.Border, 1), path);
                }
                
                // Top Left Icon Box
                g.FillPath(new SolidBrush(iconBgColor), RoundedRect(new Rectangle(25, 20, 45, 45), 10));
                
                // Progress Bar Background
                g.FillPath(new SolidBrush(Color.FromArgb(235,235,235)), RoundedRect(new Rectangle(25, 155, 280, 6), 3));
                // Custom filled bar
                g.FillPath(new SolidBrush(themeColor), RoundedRect(new Rectangle(25, 155, (int)(280 * (goal.ProgressPercentage/100.0)), 6), 3));
            };

            pnl.Controls.Add(lblTitle); pnl.Controls.Add(lblTarget);
            pnl.Controls.Add(lblSaved); pnl.Controls.Add(lblLimit); pnl.Controls.Add(lblPct);
            return pnl;
        }

        private void pnlTotalProgress_Paint(object sender, PaintEventArgs e)
        {
            var g = e.Graphics; g.SmoothingMode = SmoothingMode.AntiAlias;
            using (var path = RoundedRect(new Rectangle(0, 0, pnlTotalProgress.Width - 1, pnlTotalProgress.Height - 1), 15))
            {
                 g.FillPath(new SolidBrush(PersonalFinanceManager.Common.Helpers.ThemeHelper.CardBackground), path);
                 g.DrawPath(new Pen(PersonalFinanceManager.Common.Helpers.ThemeHelper.Border, 1), path);
            }
        }

        private void pnlProjection_Paint(object sender, PaintEventArgs e)
        {
            var g = e.Graphics; g.SmoothingMode = SmoothingMode.AntiAlias;
            using (var path = RoundedRect(new Rectangle(0, 0, pnlProjection.Width - 1, pnlProjection.Height - 1), 15))
                 g.FillPath(new SolidBrush(Color.FromArgb(60, 85, 95)), path); // Slate background

            // Star icon box
            g.FillPath(new SolidBrush(Color.FromArgb(90, 110, 120)), RoundedRect(new Rectangle(20, 20, 35, 35), 8));
            g.DrawString("âœ¦", new Font("Segoe UI", 12F), Brushes.White, 25, 25);

            // PROJECTION pill
            g.FillPath(new SolidBrush(Color.FromArgb(100, 120, 130)), RoundedRect(new Rectangle(220, 25, 90, 24), 12));
            using(var sf = new StringFormat{Alignment = StringAlignment.Center, LineAlignment = StringAlignment.Center})
                g.DrawString("PROJECTION", new Font("Segoe UI", 7F, FontStyle.Bold), Brushes.White, new Rectangle(220, 25, 90, 24), sf);
        }

        private void pnlActivity_Paint(object sender, PaintEventArgs e)
        {
            var g = e.Graphics; g.SmoothingMode = SmoothingMode.AntiAlias;
            int rightAlign = pnlActivity.Width - 140;
            
            if (_recentGoalActivities.Count == 0)
            {
                // Draw empty state message
                g.DrawString(t("No recent goal activity recorded."), new Font("Segoe UI", 10F, FontStyle.Italic), Brushes.Gray, 20, 20);
                return;
            }

            int yOffset = 0;
            foreach (var activity in _recentGoalActivities)
            {
                // card backgrounds
                using (var path = RoundedRect(new Rectangle(0, yOffset, pnlActivity.Width - 1, 75), 10))
                {
                    g.FillPath(new SolidBrush(PersonalFinanceManager.Common.Helpers.ThemeHelper.CardBackground), path);
                    g.DrawPath(new Pen(PersonalFinanceManager.Common.Helpers.ThemeHelper.Border, 1), path);
                }

                // Thick side borders
                bool isPositive = activity.Amount >= 0;
                bool isMilestone = activity.Type == "Milestone";
                Color accentColor = isMilestone ? Color.FromArgb(212, 175, 55) : (isPositive ? Color.FromArgb(40, 110, 40) : Color.FromArgb(183, 30, 80));
                g.FillRectangle(new SolidBrush(accentColor), 0, yOffset + 10, 4, 55); 
                
                // Icon circles
                Color iconBg = isMilestone ? Color.FromArgb(255, 245, 200) : (isPositive ? Color.FromArgb(220, 240, 220) : Color.FromArgb(250, 220, 230));
                g.FillEllipse(new SolidBrush(iconBg), 20, yOffset + 20, 35, 35);
                
                string iconChar = isMilestone ? "★" : (isPositive ? "+" : "₿"); 
                if (!isMilestone && !isPositive && activity.Note.Contains(t("goal"))) iconChar = "↗"; 

                g.DrawString(iconChar, new Font("Segoe UI", isMilestone ? 16F : 14F, FontStyle.Bold), new SolidBrush(accentColor), isMilestone ? 24 : 26, yOffset + (isMilestone ? 20 : 23));

                // Activity Text
                g.DrawString(activity.Note, new Font("Segoe UI", 10F, FontStyle.Bold), new SolidBrush(PersonalFinanceManager.Common.Helpers.ThemeHelper.Text), 70, yOffset + 20);
                
                string subText = isMilestone ? t("Goal Achieved!") : (activity.Type == "Expense" ? t("Funding target goal") : t("Direct contribution"));
                g.DrawString(subText, new Font("Segoe UI", 8.5F), new SolidBrush(PersonalFinanceManager.Common.Helpers.ThemeHelper.SubText), 70, yOffset + 42);
                
                string amtText = isMilestone ? t("Completed") : ((activity.Amount > 0 ? "+" : "-") + PersonalFinanceManager.Common.Helpers.ConfigHelper.FormatGlobalCurrency(Math.Abs(activity.Amount)));
                g.DrawString(amtText, new Font("Segoe UI", 10.5F, FontStyle.Bold), new SolidBrush(accentColor), rightAlign, yOffset + 20);
                
                string dateText = activity.TransactionDate.Date == DateTime.Today ? t("Today") : activity.TransactionDate.ToString("dd/MM/yyyy");
                g.DrawString(dateText + ", " + activity.TransactionDate.ToString("HH:mm"), new Font("Segoe UI", 8F), new SolidBrush(PersonalFinanceManager.Common.Helpers.ThemeHelper.SubText), rightAlign, yOffset + 42);

                yOffset += 95;
            }
        }

        private void pnlAdvice_Paint(object sender, PaintEventArgs e)
        {
            var g = e.Graphics; g.SmoothingMode = SmoothingMode.AntiAlias;
            using (var path = RoundedRect(new Rectangle(0, 0, pnlAdvice.Width - 1, pnlAdvice.Height - 1), 15))
                 g.FillPath(new SolidBrush(Color.FromArgb(55, 80, 90)), path); // Slate background

            // Piggybank generic mockup box icon 
            g.FillPath(Brushes.White, RoundedRect(new Rectangle(110, 20, 40, 30), 5));
            g.DrawString("Smart Savings\nAdvice", new Font("Segoe UI", 12F, FontStyle.Bold), Brushes.White, new Point(65, 65));
            
            var adviceFormat = new StringFormat{ Alignment = StringAlignment.Center };
            g.DrawString($"Based on your spending,\nwe found {PersonalFinanceManager.Common.Helpers.ConfigHelper.FormatGlobalCurrency(240)} extra you\ncould contribute to your\n'New Car' goal this month.", new Font("Segoe UI", 8.5F), Brushes.LightGray, new Rectangle(10, 115, 240, 60), adviceFormat);
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

                // Hide the cards requested to be removed
                pnlProjection.Visible = false;
                pnlAdvice.Visible = false;

                // Ensure right-aligned buttons track perfectly
                txtSearch.Anchor = AnchorStyles.Top | AnchorStyles.Right;
                btnAddGoal.Anchor = AnchorStyles.Top | AnchorStyles.Right;
                btnFilter.Anchor = AnchorStyles.Top | AnchorStyles.Right;
                btnGrid.Anchor = AnchorStyles.Top | AnchorStyles.Right;
                
                // Track internal progress elements
                pnlProgressBg.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
                lblTotalPct.Anchor = AnchorStyles.Top | AnchorStyles.Right;

                contentPanel.SizeChanged += (s, e) => {
                    int w = contentPanel.ClientSize.Width;
                    int margin = 30;

                    // Stretch logic: Panels fill the full width since the right-side cards are gone
                    pnlTotalProgress.Width = w - margin * 2;
                    pnlActivity.Width = w - margin * 2;

                    // Flow layout targets the entire bounds allowing cards to gracefully flow
                    flpGoals.Width = w - margin * 2;
                    
                    pnlActivity.Invalidate(); 
                };
            }
        }
}
}


