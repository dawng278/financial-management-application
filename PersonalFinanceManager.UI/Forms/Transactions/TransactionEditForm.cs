using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using PersonalFinanceManager.Common.Helpers;
using PersonalFinanceManager.Infrastructure.DI;
using PersonalFinanceManager.Models;
using ReaLTaiizor.Controls;
using System.Linq;

namespace PersonalFinanceManager.Forms.Transactions
{
    public class TransactionEditForm : Form
    {
        private HopeTextBox txtDesc;
        private HopeTextBox txtAmount;
        private HopeComboBox cbCategory;
        private HopeComboBox cbAccount;
        private HopeComboBox cbType;
        private DateTimePicker dtpDate;
        private HopeButton btnSave;
        private HopeButton btnCancel;
        private Label lblTitle;
        private Label lblSubTitle;
        
        public Action<DateTime, int, int, string, decimal, string> OnAddTransaction;

        public TransactionEditForm()
        {
            this.FormBorderStyle = FormBorderStyle.None;
            this.Size = new Size(480, 760);
            this.StartPosition = FormStartPosition.CenterParent;
            this.ShowInTaskbar = false;
            
            SetupControls();
            ApplyTheme();
        }

        private void SetupControls()
        {
            var t = new Func<string, string>(ConfigHelper.Translate);

            // Title Block
            lblTitle = new Label { Text = t("+ Add Transaction"), Font = new Font("Segoe UI", 18F, FontStyle.Bold), Location = new Point(35, 45), AutoSize = true };
            lblSubTitle = new Label { Text = t("Track your spending and optimize your flow."), Font = new Font("Segoe UI", 9.5F), Location = new Point(35, 85), AutoSize = true, ForeColor = Color.Gray };

            int startY = 140;
            int stepY = 85;
            int fieldW = 410;

            // Type
            var lblType = CreateFieldLabel(t("TRANSACTION TYPE"), 35, startY);
            cbType = new HopeComboBox { Location = new Point(35, startY + 20), Width = fieldW, Height = 40, DropDownStyle = ComboBoxStyle.DropDownList };
            cbType.Items.Add(t("Income"));
            cbType.Items.Add(t("Expense"));
            cbType.SelectedIndex = 1; // Default to Expense

            // Date
            var lblDate = CreateFieldLabel(t("TRANSACTION DATE"), 35, startY + stepY);
            dtpDate = new DateTimePicker { Location = new Point(35, startY + stepY + 20), Width = fieldW, Font = new Font("Segoe UI", 12F) };

            // Category
            var lblCat = CreateFieldLabel(t("CATEGORY"), 35, startY + stepY * 2);
            cbCategory = new HopeComboBox { Location = new Point(35, startY + stepY * 2 + 20), Width = fieldW, Height = 40, DropDownStyle = ComboBoxStyle.DropDownList };
            var cats = ServiceLocator.CategoryService.GetAll();
            if (cats != null && cats.Any()) { cbCategory.DataSource = cats.ToList(); cbCategory.DisplayMember = "Name"; cbCategory.ValueMember = "Id"; }
            else { cbCategory.Items.AddRange(new[] { "Food", "Transport", "Shopping", "Salary", "Other" }); }

            // Account
            var lblAcc = CreateFieldLabel(t("ACCOUNT"), 35, startY + stepY * 3);
            cbAccount = new HopeComboBox { Location = new Point(35, startY + stepY * 3 + 20), Width = fieldW, Height = 40, DropDownStyle = ComboBoxStyle.DropDownList };
            var accounts = ServiceLocator.AccountService.GetByCurrentUser();
            if (accounts != null && accounts.Any()) { cbAccount.DataSource = accounts.ToList(); cbAccount.DisplayMember = "AccountName"; cbAccount.ValueMember = "Id"; }
            else { cbAccount.Items.AddRange(new[] { "Main Wallet", "Default Account" }); }

            // Amount
            var lblAmt = CreateFieldLabel(t("AMOUNT"), 35, startY + stepY * 4);
            txtAmount = new HopeTextBox { Location = new Point(35, startY + stepY * 4 + 20), Width = fieldW, Height = 40, Text = "0" };

            // Description
            var lblDesc = CreateFieldLabel(t("DESCRIPTION / NOTES"), 35, startY + stepY * 5);
            txtDesc = new HopeTextBox { Location = new Point(35, startY + stepY * 5 + 20), Width = fieldW, Height = 40 };

            // Buttons
            btnSave = new HopeButton { Text = t("Apply"), Location = new Point(275, 680), Width = 170, Height = 45, PrimaryColor = Color.FromArgb(40, 180, 80), Cursor = Cursors.Hand };
            btnSave.Click += (s, e) => {
                if(decimal.TryParse(txtAmount.Text, out decimal amt)) {
                    int catId = 0; int accId = 0;
                    if(cbCategory.SelectedValue != null) int.TryParse(cbCategory.SelectedValue.ToString(), out catId);
                    if(cbAccount.SelectedValue != null) int.TryParse(cbAccount.SelectedValue.ToString(), out accId);
                    
                    string selectedType = cbType.SelectedIndex == 0 ? "Income" : "Expense";
                    OnAddTransaction?.Invoke(dtpDate.Value, catId, accId, txtDesc.Text, amt, selectedType);
                    this.Close();
                } else {
                    MessageBox.Show(t("Invalid amount format."));
                }
            };

            btnCancel = new HopeButton { Text = t("Cancel"), Location = new Point(145, 680), Width = 120, Height = 45, PrimaryColor = Color.Gray, Cursor = Cursors.Hand };
            btnCancel.Click += (s, e) => this.Close();

            this.Controls.Add(lblTitle); this.Controls.Add(lblSubTitle);
            this.Controls.Add(lblType); this.Controls.Add(cbType);
            this.Controls.Add(lblDate); this.Controls.Add(dtpDate);
            this.Controls.Add(lblCat); this.Controls.Add(cbCategory);
            this.Controls.Add(lblAcc); this.Controls.Add(cbAccount);
            this.Controls.Add(lblAmt); this.Controls.Add(txtAmount);
            this.Controls.Add(lblDesc); this.Controls.Add(txtDesc);
            this.Controls.Add(btnSave); this.Controls.Add(btnCancel);

            // Drag support
            this.MouseDown += (s, e) => { if (e.Button == MouseButtons.Left) { this.Capture = false; Message msg = Message.Create(this.Handle, 0xA1, new IntPtr(2), IntPtr.Zero); base.WndProc(ref msg); } };
        }

        private Label CreateFieldLabel(string text, int x, int y)
        {
            return new Label { Text = text, Font = new Font("Segoe UI", 8.5F, FontStyle.Bold), ForeColor = Color.Gray, Location = new Point(x, y), AutoSize = true };
        }

        private void ApplyTheme()
        {
            bool isDark = ThemeHelper.IsDarkMode;
            this.BackColor = ThemeHelper.Background;
            lblTitle.ForeColor = ThemeHelper.Text;
            lblSubTitle.ForeColor = ThemeHelper.SubText;
            foreach (Control c in this.Controls) { if (c is Label lbl && lbl != lblTitle && lbl != lblSubTitle) lbl.ForeColor = ThemeHelper.SubText; }
            ThemeHelper.ApplyTheme(this);
            btnSave.PrimaryColor = Color.FromArgb(40, 180, 80); // Success green for transactions
            btnCancel.PrimaryColor = isDark ? Color.FromArgb(60, 60, 75) : Color.FromArgb(200, 200, 210);
            btnCancel.TextColor = isDark ? Color.White : Color.FromArgb(60, 60, 70);
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
            using (var path = RoundedRect(new Rectangle(0, 0, this.Width - 1, this.Height - 1), 20))
            {
                this.Region = new Region(path);
                using (var pen = new Pen(ThemeHelper.Border, 2)) { e.Graphics.DrawPath(pen, path); }
            }
        }

        private static GraphicsPath RoundedRect(Rectangle r, int radius)
        {
            var path = new GraphicsPath(); int d = radius * 2;
            path.AddArc(r.X, r.Y, d, d, 180, 90); path.AddArc(r.Right - d, r.Y, d, d, 270, 90);
            path.AddArc(r.Right - d, r.Bottom - d, d, d, 0, 90); path.AddArc(r.X, r.Bottom - d, d, d, 90, 90);
            path.CloseFigure(); return path;
        }
    }
}
