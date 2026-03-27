using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using Panel = System.Windows.Forms.Panel;

namespace PersonalFinanceManager.UI.Forms.Reports
{
    public partial class ReportForm : Form
    {
        public ReportForm()
        {
            InitializeComponent();
            LoadDataGridMock();
        }

        private void LoadDataGridMock()
        {
            dgvLedger.ColumnCount = 5;
            dgvLedger.Columns[0].Name = "Date";
            dgvLedger.Columns[1].Name = "Description";
            dgvLedger.Columns[2].Name = "Category";
            dgvLedger.Columns[3].Name = "Account";
            dgvLedger.Columns[4].Name = "Amount";
            dgvLedger.Columns[4].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

            // Clear borders for modern look
            dgvLedger.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dgvLedger.EnableHeadersVisualStyles = false;
            dgvLedger.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dgvLedger.ColumnHeadersDefaultCellStyle.BackColor = Color.White;
            dgvLedger.ColumnHeadersDefaultCellStyle.ForeColor = Color.Gray;
            dgvLedger.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            dgvLedger.DefaultCellStyle.SelectionBackColor = Color.FromArgb(240,240,245);
            dgvLedger.DefaultCellStyle.SelectionForeColor = Color.Black;
            dgvLedger.BackgroundColor = Color.White;
            dgvLedger.RowTemplate.Height = 40;

            foreach (DataGridViewColumn col in dgvLedger.Columns)
                col.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

            dgvLedger.Rows.Add("Oct 25, 2024", "Q3 Dividends - Tech Portfolio", "INVESTMENT", "Brokerage High-Yield", "+$12,450.00");
            dgvLedger.Rows.Add("Oct 22, 2024", "Amazon Web Services - Infrastructure", "BUSINESS", "Corporate Alpha", "-$2,140.50");
            dgvLedger.Rows.Add("Oct 20, 2024", "Apple Inc. - Hardware Upgrade", "EQUIPMENT", "Corporate Alpha", "-$1,889.00");
            dgvLedger.Rows.Add("Oct 18, 2024", "Global Consulting Group - Retainer", "SERVICE", "Checking Main", "+$5,000.00");
            dgvLedger.Rows.Add("Oct 15, 2024", "Office Rent - Midtown Plaza", "RENT", "Corporate Alpha", "-$4,200.00");

            dgvLedger.CellPainting += DgvLedger_CellPainting;
        }

        private void DgvLedger_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            if (e.RowIndex < 0) return; // Header
            e.PaintBackground(e.CellBounds, true);

            var font = new Font("Segoe UI", 9F);
            var color = Color.Black;

            if (e.ColumnIndex == 4) // Amount
            {
                var val = e.Value?.ToString() ?? "";
                if (val.StartsWith("+")) color = Color.FromArgb(24, 106, 34);
                else color = Color.FromArgb(183, 30, 80);
                font = new Font("Segoe UI", 9F, FontStyle.Bold);
                
                using (var stringFormat = new StringFormat() { Alignment = StringAlignment.Far, LineAlignment = StringAlignment.Center })
                {
                    e.Graphics.DrawString(val, font, new SolidBrush(color), e.CellBounds, stringFormat);
                }
                e.Handled = true;
            }
            else if (e.ColumnIndex == 2) // Category Pillow
            {
                var val = e.Value?.ToString() ?? "";
                var bg = Color.FromArgb(235, 245, 235);
                var fg = Color.FromArgb(40, 110, 40);
                
                if (val == "BUSINESS" || val == "EQUIPMENT" || val == "RENT") 
                {
                    bg = Color.FromArgb(250, 230, 240);
                    fg = Color.FromArgb(183, 30, 80);
                }

                e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
                e.Graphics.FillPath(new SolidBrush(bg), RoundedRect(new Rectangle(e.CellBounds.X + 10, e.CellBounds.Y + 10, e.CellBounds.Width - 50, 20), 5));
                
                using (var sf = new StringFormat() { Alignment = StringAlignment.Center, LineAlignment = StringAlignment.Center })
                {
                    e.Graphics.DrawString(val, new Font("Segoe UI", 7F, FontStyle.Bold), new SolidBrush(fg), new Rectangle(e.CellBounds.X + 10, e.CellBounds.Y + 10, e.CellBounds.Width - 50, 20), sf);
                }
                e.Handled = true;
            }
            else
            {
                using (var stringFormat = new StringFormat() { Alignment = StringAlignment.Near, LineAlignment = StringAlignment.Center })
                {
                    e.Graphics.DrawString(e.Value?.ToString(), font, Brushes.Black, new Rectangle(e.CellBounds.X + 2, e.CellBounds.Y, e.CellBounds.Width, e.CellBounds.Height), stringFormat);
                }
                e.Handled = true;
            }
        }

        private void pnlFilter_Paint(object sender, PaintEventArgs e)
        {
            var g = e.Graphics; g.SmoothingMode = SmoothingMode.AntiAlias;
            using (var path = RoundedRect(new Rectangle(0, 0, pnlFilter.Width - 1, pnlFilter.Height - 1), 10))
                 g.FillPath(new SolidBrush(Color.FromArgb(242, 243, 245)), path);
        }

        private void pnlIncome_Paint(object sender, PaintEventArgs e)
        {
            DrawMetricCard(e.Graphics, pnlIncome.ClientRectangle, "TOTAL INCOME", "$142,500.00", "+12.5% from last period", Color.FromArgb(24, 106, 34), Color.FromArgb(230, 245, 235), "↗");
        }

        private void pnlExpense_Paint(object sender, PaintEventArgs e)
        {
            DrawMetricCard(e.Graphics, pnlExpense.ClientRectangle, "TOTAL EXPENSES", "$84,320.50", "-4.2% from last period", Color.FromArgb(183, 30, 80), Color.FromArgb(250, 230, 235), "↘");
        }

        private void pnlSavings_Paint(object sender, PaintEventArgs e)
        {
            DrawMetricCard(e.Graphics, pnlSavings.ClientRectangle, "NET SAVINGS", "$58,179.50", "", Color.FromArgb(160, 20, 50), Color.FromArgb(250, 230, 240), "🏛");
        }

        private void DrawMetricCard(Graphics g, Rectangle r, string title, string val, string sub, Color themeColor, Color pillColor, string icon)
        {
            g.SmoothingMode = SmoothingMode.AntiAlias;
            using (var path = RoundedRect(new Rectangle(r.X, r.Y, r.Width - 1, r.Height - 1), 10))
                g.FillPath(Brushes.White, path);
                
            g.FillRectangle(new SolidBrush(themeColor), 0, 10, 4, r.Height - 20); // Left border

            g.DrawString(title, new Font("Segoe UI", 8F, FontStyle.Bold), Brushes.Gray, 20, 15);
            g.DrawString(val, new Font("Segoe UI", 20F, FontStyle.Bold), new SolidBrush(themeColor), 15, 35);
            g.DrawString(sub, new Font("Segoe UI", 8F), new SolidBrush(themeColor), 20, 75);

            // Right Box
            g.FillPath(new SolidBrush(pillColor), RoundedRect(new Rectangle(r.Width - 50, 20, 35, 35), 8));
            g.DrawString(icon, new Font("Segoe UI", 12F, FontStyle.Bold), new SolidBrush(themeColor), r.Width - 43, 27);
        }

        private void pnlChart_Paint(object sender, PaintEventArgs e)
        {
            var g = e.Graphics; g.SmoothingMode = SmoothingMode.AntiAlias;
            using (var path = RoundedRect(new Rectangle(0, 0, pnlChart.Width - 1, pnlChart.Height - 1), 10))
                 g.FillPath(Brushes.White, path);

            // Legend
            g.FillEllipse(new SolidBrush(Color.FromArgb(24, 106, 34)), pnlChart.Width - 160, 25, 10, 10);
            g.DrawString("Income", new Font("Segoe UI", 8.5F), Brushes.Gray, pnlChart.Width - 145, 23);
            g.FillEllipse(new SolidBrush(Color.FromArgb(183, 30, 80)), pnlChart.Width - 80, 25, 10, 10);
            g.DrawString("Expense", new Font("Segoe UI", 8.5F), Brushes.Gray, pnlChart.Width - 65, 23);

            // Pseudo Chart X-Axis
            string[] months = { "JAN", "FEB", "MAR", "APR", "MAY", "JUN", "JUL" };
            int step = pnlChart.Width / 8;
            for(int i = 0; i < months.Length; i++)
                g.DrawString(months[i], new Font("Segoe UI", 8F, FontStyle.Bold), Brushes.Gray, step * (i + 1), pnlChart.Height - 30);
        }

        private void pnlLedger_Paint(object sender, PaintEventArgs e)
        {
            var g = e.Graphics; g.SmoothingMode = SmoothingMode.AntiAlias;
            using (var path = RoundedRect(new Rectangle(0, 0, pnlLedger.Width - 1, pnlLedger.Height - 1), 10))
                 g.FillPath(new SolidBrush(Color.FromArgb(250, 251, 252)), path); // Very faint background
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
    }
}
