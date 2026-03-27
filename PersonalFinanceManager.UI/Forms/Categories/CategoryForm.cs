using System;
using System.Collections.Generic;
using System.Linq;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using PersonalFinanceManager.Infrastructure.DI;
using PersonalFinanceManager.Common.Helpers;
using PersonalFinanceManager.Models;

namespace PersonalFinanceManager.Forms.Categories
{
    public partial class CategoryForm : Form
    {
        private List<decimal> _chartPoints = new List<decimal>();
        
        public CategoryForm()
        {
            InitializeComponent();
            
            // Layout adjustments
            this.btnAddCategory.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            this.pnlToggle.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            
            // Adjust header elements based on width
            Action layoutHeader = () => {
                int rightEdge = pnlMain.Width - 30;
                pnlToggle.Left = rightEdge - pnlToggle.Width;
                btnAddCategory.Left = pnlToggle.Left - btnAddCategory.Width - 20;
            };
            this.pnlMain.SizeChanged += (s, e) => layoutHeader();
            
            this.btnAddCategory.BringToFront();
            this.pnlToggle.BringToFront();
            
            this.pnlChart.Paint += pnlChart_Paint;
            this.pnlToggle.Paint += pnlToggle_Paint;
            this.pnlMain.SizeChanged += (s, e) => {
                RepositionSecondaryControls();
                pnlChart.Invalidate();
            };
            this.flpCategories.SizeChanged += (s, e) => RepositionSecondaryControls();
            this.HandleCreated += (s, e) => {
                RepositionSecondaryControls();
                LoadCategories();
            };

            SetupClickHandlers();
            UpdateTranslations();
            
            PersonalFinanceManager.Common.Helpers.ConfigHelper.LanguageChanged += (s, ev) => 
            {
                if (this.IsHandleCreated) this.Invoke(new Action(() => {
                    UpdateHeaderTranslations();
                    LoadCategories();
                    pnlChart.Invalidate();
                }));
            };

            PersonalFinanceManager.Common.Helpers.ConfigHelper.ThemeChanged += (s, ev) =>
            {
                if (this.IsHandleCreated) this.Invoke(new Action(() => {
                    ApplyTheme();
                }));
            };

            ServiceLocator.TransactionService.TransactionChanged += (s, ev) => 
            {
                if (this.IsHandleCreated) this.Invoke(new Action(() => LoadCategories()));
            };
            
            ApplyTheme();
        }

        private void ApplyTheme()
        {
            ThemeHelper.ApplyTheme(this);
            pnlToggle.Invalidate();
            pnlChart.Invalidate();
            foreach (Control c in flpCategories.Controls) c.Invalidate();
        }

        private void SetupClickHandlers()
        {
            if (btnAddCategory != null)
            {
                btnAddCategory.Click += (s, e) => {
                    using (var frm = new CategoryEditForm())
                    {
                        if (frm.ShowDialog() == DialogResult.OK)
                        {
                            var newCat = frm.ResultCategory;
                            if (newCat != null)
                            {
                                if (ServiceLocator.CategoryService.Add(newCat))
                                {
                                    LoadCategories();
                                }
                            }
                        }
                    }
                };
            }
        }

        private void UpdateHeaderTranslations()
        {
            var t = new Func<string, string>(ConfigHelper.Translate);
            lblTitle.Text = t("Budget Categories");
            lblSubtitle.Text = t("Organize your flow with semantic buckets");
            btnIncome.Text = t("Income");
            btnExpenses.Text = t("Expenses");
            btnAddCategory.Text = t("+ Add Category");
            lblSpendDensityTitle.Text = t("Spend Density");
        }

        private void UpdateTranslations()
        {
            UpdateHeaderTranslations();
        }

        private void LoadCategories()
        {
            flpCategories.Controls.Clear();
            var categories = ServiceLocator.CategoryService.GetAll();
            
            foreach (var cat in categories)
            {
                var card = CreateCategoryCard(cat);
                flpCategories.Controls.Add(card);
            }

            // Load real chart data (last 20 days)
            var expenses = ServiceLocator.TransactionService.GetByDateRange(DateTime.Today.AddDays(-20), DateTime.MaxValue)
                                .Where(t => string.Equals(t.Type, "Expense", StringComparison.OrdinalIgnoreCase))
                                .ToList();
            
            _chartPoints.Clear();
            for(int i = 0; i < 20; i++)
            {
                var d = DateTime.Today.AddDays(-19 + i);
                var sum = expenses.Where(t => t.TransactionDate.Date == d.Date).Sum(x => x.Amount);
                _chartPoints.Add(Math.Abs(sum));
            }

            RepositionSecondaryControls();
            pnlChart.Invalidate();
        }

        private void RepositionSecondaryControls()
        {
            if (flpCategories == null || lblSpendDensityTitle == null || pnlChart == null) return;
            
            int margin = 30;
            int spacing = 40;
            
            // Re-align to margin
            lblSpendDensityTitle.Left = margin;
            pnlChart.Left = margin;
            
            // Place Spend Density title below categories
            lblSpendDensityTitle.Top = flpCategories.Bottom + spacing;
            
            // Make chart height dynamic or at least larger
            int dynamicChartHeight = 280;
            pnlChart.Top = lblSpendDensityTitle.Bottom + 15;
            pnlChart.Height = dynamicChartHeight;
            pnlChart.Width = Math.Max(pnlMain.Width - (margin * 2), 600); 

            // Important: Force pnlMain to recognize the bottom-most point for scrolling
            int bottomMargin = 100;
            pnlMain.AutoScrollMinSize = new Size(0, pnlChart.Bottom + bottomMargin);
        }

        private Control CreateCategoryCard(Category cat)
        {
            int marginX = 15;
            int gap = 20;
            int containerWidth = Math.Max(flpCategories.Width, 800);
            
            int cardsPerRow = 3;
            if (containerWidth > 1600) cardsPerRow = 5;
            else if (containerWidth > 1200) cardsPerRow = 4;
            
            int cardW = (containerWidth / cardsPerRow) - (gap) - (marginX / cardsPerRow);
            if (cardW < 280) cardW = 280;

            var pnl = new Panel { Size = new Size(cardW, 145), Margin = new Padding(0, 0, gap, gap), BackColor = Color.Transparent };
            
            // Calculate real-time budget utilization
            decimal spent = Math.Abs(ServiceLocator.TransactionService.GetMonthlySpentByCategory(cat.Id, DateTime.Now.Year, DateTime.Now.Month));
            float pct = (cat.BudgetLimit > 0) ? (float)(spent / cat.BudgetLimit * 100m) : 0;
            int displayPct = (int)Math.Min(pct, 100);

            string status = pct >= 100 ? "CRITICAL" : (pct > 80 ? "WARNING" : "STABLE");
            Color statusColor = pct >= 100 ? Color.Red : (pct > 80 ? Color.Orange : Color.FromArgb(40, 160, 40));
            Color accentColor = ColorTranslator.FromHtml(cat.ColorHex ?? "#0078D4");

            if (!cat.IsDefault)
            {
                var btnDelete = new Label
                {
                    Text = "✕",
                    ForeColor = Color.Gray,
                    Cursor = Cursors.Hand,
                    TextAlign = ContentAlignment.MiddleCenter,
                    Size = new Size(24, 24),
                    Location = new Point(cardW - 32, 8),
                    BackColor = Color.Transparent,
                    Font = new Font("Segoe UI", 9F, FontStyle.Bold)
                };
                btnDelete.MouseEnter += (s, e) => btnDelete.ForeColor = Color.Red;
                btnDelete.MouseLeave += (s, e) => btnDelete.ForeColor = Color.Gray;
                btnDelete.Click += (s, e) => 
                {
                    var msg = string.Format(ConfigHelper.Translate("Are you sure you want to delete category '{0}'?"), cat.Name);
                    if (MessageBox.Show(msg, ConfigHelper.Translate("Confirm Delete"), MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                    {
                        if (ServiceLocator.CategoryService.Delete(cat.Id))
                        {
                            LoadCategories();
                        }
                    }
                };
                pnl.Controls.Add(btnDelete);
            }

            pnl.Paint += (s, e) => {
                var g = e.Graphics;
                g.SmoothingMode = SmoothingMode.AntiAlias;
                var rect = new Rectangle(0, 0, pnl.Width - 1, pnl.Height - 1);

                using (var path = RoundedRect(rect, 15)) 
                { 
                    g.FillPath(new SolidBrush(ThemeHelper.CardBackground), path); 
                    g.DrawPath(new Pen(ThemeHelper.Border, 1), path);
                }

                using (var brush = new SolidBrush(accentColor))
                {
                    g.FillRectangle(brush, 0, 10, 6, pnl.Height - 20);
                }

                g.DrawString(status, new Font("Segoe UI", 7.5F, FontStyle.Bold), new SolidBrush(statusColor), pnl.Width - 80, 25);
                g.DrawString(cat.Name, new Font("Segoe UI", 12F, FontStyle.Bold), new SolidBrush(ThemeHelper.Text), 25, 60);
                g.DrawString(ConfigHelper.Translate("Budget Utilization"), new Font("Segoe UI", 8F), new SolidBrush(ThemeHelper.SubText), 25, 90);
                g.DrawString($"{(int)pct}%", new Font("Segoe UI", 8F, FontStyle.Bold), new SolidBrush(ThemeHelper.Text), pnl.Width - 45, 90);

                g.FillRectangle(new SolidBrush(Color.FromArgb(235, 235, 235)), 25, 120, pnl.Width - 55, 6);
                g.FillRectangle(new SolidBrush(accentColor), 25, 120, (pnl.Width - 55) * (displayPct / 100f), 6);
            };

            return pnl;
        }

        private void pnlToggle_Paint(object sender, PaintEventArgs e)
        {
            var g = e.Graphics;
            g.SmoothingMode = SmoothingMode.AntiAlias;
            var rect = new Rectangle(0, 0, pnlToggle.Width - 1, pnlToggle.Height - 1);
            using (var path = RoundedRect(rect, 10))
            {
                g.FillPath(new SolidBrush(ThemeHelper.CardBackground), path);
                g.DrawPath(new Pen(ThemeHelper.Border, 1), path);
            }
        }

        private void pnlChart_Paint(object sender, PaintEventArgs e)
        {
            var g = e.Graphics;
            g.SmoothingMode = SmoothingMode.AntiAlias;
            var rect = new Rectangle(0, 0, pnlChart.Width - 1, pnlChart.Height - 1);
            
            using (var path = RoundedRect(rect, 15))
            {
                g.FillPath(new SolidBrush(Color.FromArgb(252, 253, 255)), path);
                g.DrawPath(new Pen(ThemeHelper.Border, 1), path);
            }

            if (pnlChart.Width > 100 && _chartPoints.Count > 0)
            {
                int pointCount = _chartPoints.Count; 
                var points = new Point[pointCount];
                int marginH = 50;
                int chartWidth = pnlChart.Width - (marginH * 2);
                
                decimal maxVal = _chartPoints.Max();
                if (maxVal < 100) maxVal = 1000; // Min scale for empty/low data

                for(int i = 0; i < pointCount; i++)
                {
                    int x = marginH + (i * chartWidth / (pointCount - 1));
                    // Scale value to chart height (inverted Y)
                    float ratio = (float)(_chartPoints[i] / maxVal);
                    int y = (int)(pnlChart.Height * 0.8f - (pnlChart.Height * 0.6f * ratio));
                    points[i] = new Point(x, y);
                }

                // Smooth Gradient Area
                using (var areaPath = new GraphicsPath())
                {
                    areaPath.AddCurve(points, 0.4F);
                    areaPath.AddLine(points[points.Length - 1].X, pnlChart.Height, points[0].X, pnlChart.Height);
                    areaPath.CloseFigure();
                    using (var brush = new LinearGradientBrush(new Rectangle(0, 0, pnlChart.Width, pnlChart.Height), 
                                       Color.FromArgb(120, 200, 20, 80), Color.Transparent, 90F))
                    {
                        g.FillPath(brush, areaPath);
                    }
                }

                using (var pen = new Pen(Color.FromArgb(200, 20, 80), 3.0F)) 
                {
                    g.DrawCurve(pen, points, 0.4f);
                }

                foreach (var p in points.Where((x, idx) => _chartPoints[idx] > 0)) 
                {
                    g.FillEllipse(Brushes.White, p.X - 4, p.Y - 4, 8, 8);
                    g.DrawEllipse(new Pen(Color.FromArgb(200, 20, 80), 1.5F), p.X - 4, p.Y - 4, 8, 8);

                    // Add numerical values above the points
                    int idx = Array.IndexOf(points, p);
                    string valText = ConfigHelper.FormatGlobalCurrency(_chartPoints[idx]);
                    var size = g.MeasureString(valText, new Font("Segoe UI", 7F, FontStyle.Bold));
                    g.DrawString(valText, new Font("Segoe UI", 7F, FontStyle.Bold), new SolidBrush(Color.FromArgb(60, 60, 60)), p.X - (size.Width / 2), p.Y - 20);
                }

                // Draw some date labels at the bottom for context
                for (int i = 0; i < pointCount; i += 5) 
                {
                    var d = DateTime.Today.AddDays(-19 + i);
                    string dateText = d.ToString("dd MMM").ToUpper();
                    int x = marginH + (i * chartWidth / (pointCount - 1));
                    g.DrawString(dateText, new Font("Segoe UI", 7F), new SolidBrush(Color.FromArgb(160, 160, 160)), x - 20, pnlChart.Height - 25);
                }
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
