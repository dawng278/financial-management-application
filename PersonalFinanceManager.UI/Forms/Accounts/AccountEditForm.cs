using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using PersonalFinanceManager.Infrastructure.DI;
using PersonalFinanceManager.Models;
using PersonalFinanceManager.Common.Helpers;
using ReaLTaiizor.Controls;

namespace PersonalFinanceManager.Forms.Accounts
{
    public partial class AccountEditForm : Form
    {
        private HopeTextBox txtAccountName;
        private HopeComboBox cboAccountType;
        private HopeTextBox txtBalance;
        private HopeComboBox cboCurrency;
        private HopeButton btnSave;
        private HopeButton btnCancel;
        private Label lblTitle;
        private Label lblSubTitle;
        private Account _account;

        public AccountEditForm(Account account)
        {
            _account = account;
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.None;
            this.StartPosition = FormStartPosition.CenterParent;
            this.ShowInTaskbar = false;
            this.Size = new Size(480, 620);
            
            SetupInterface();
            ApplyTheme();
            LoadData();
        }

        private void InitializeComponent()
        {
            this.txtAccountName = new HopeTextBox();
            this.cboAccountType = new HopeComboBox();
            this.txtBalance = new HopeTextBox();
            this.cboCurrency = new HopeComboBox();
            this.btnSave = new HopeButton();
            this.btnCancel = new HopeButton();
            this.lblTitle = new Label();
            this.lblSubTitle = new Label();
        }

        private void SetupInterface()
        {
            var t = new Func<string, string>(ConfigHelper.Translate);

            lblTitle = new Label { Text = t("Edit Account"), Font = new Font("Segoe UI", 18F, FontStyle.Bold), Location = new Point(35, 45), AutoSize = true };
            lblSubTitle = new Label { Text = t("Update your account details and balance."), Font = new Font("Segoe UI", 9.5F), ForeColor = Color.Gray, Location = new Point(35, 85), AutoSize = true };

            int startY = 140;
            int stepY = 85;
            int fieldW = 410;

            var lblName = CreateFieldLabel(t("ACCOUNT NAME"), 35, startY);
            txtAccountName.Location = new Point(35, startY + 20);
            txtAccountName.Size = new Size(fieldW, 40);

            var lblType = CreateFieldLabel(t("ACCOUNT TYPE"), 35, startY + stepY);
            cboAccountType.Location = new Point(35, startY + stepY + 20);
            cboAccountType.Size = new Size(fieldW, 40);
            cboAccountType.Items.AddRange(new object[] { t("Cash"), t("BankAccount"), t("EWallet"), t("Savings"), t("CreditCard") });

            var lblBalance = CreateFieldLabel(t("BALANCE"), 35, startY + stepY * 2);
            txtBalance.Location = new Point(35, startY + stepY * 2 + 20);
            txtBalance.Size = new Size(fieldW, 40);

            var lblCurrency = CreateFieldLabel(t("CURRENCY"), 35, startY + stepY * 3);
            cboCurrency.Location = new Point(35, startY + stepY * 3 + 20);
            cboCurrency.Size = new Size(fieldW, 40);
            cboCurrency.Items.AddRange(new object[] { "VND", "USD", "EUR" });

            btnSave = new HopeButton { Text = t("Update Account"), PrimaryColor = Color.FromArgb(183, 0, 82), Location = new Point(275, 540), Size = new Size(170, 45), Cursor = Cursors.Hand };
            btnSave.Click += BtnSave_Click;

            btnCancel = new HopeButton { Text = t("Cancel"), PrimaryColor = Color.FromArgb(100, 100, 110), Location = new Point(145, 540), Size = new Size(120, 45), Cursor = Cursors.Hand };
            btnCancel.Click += (s, e) => this.Close();

            this.Controls.Add(lblTitle); this.Controls.Add(lblSubTitle);
            this.Controls.Add(lblName); this.Controls.Add(txtAccountName);
            this.Controls.Add(lblType); this.Controls.Add(cboAccountType);
            this.Controls.Add(lblBalance); this.Controls.Add(txtBalance);
            this.Controls.Add(lblCurrency); this.Controls.Add(cboCurrency);
            this.Controls.Add(btnSave); this.Controls.Add(btnCancel);
            
            this.MouseDown += (s, e) => { if (e.Button == MouseButtons.Left) { this.Capture = false; Message msg = Message.Create(this.Handle, 0xA1, new IntPtr(2), IntPtr.Zero); base.WndProc(ref msg); } };
        }

        private void LoadData()
        {
            txtAccountName.Text = _account.AccountName;
            txtBalance.Text = _account.Balance.ToString();
            
            string[] types = { "Cash", "BankAccount", "EWallet", "Savings", "CreditCard" };
            int typeIdx = Array.IndexOf(types, _account.AccountType);
            cboAccountType.SelectedIndex = typeIdx != -1 ? typeIdx : 0;
            
            cboCurrency.SelectedItem = _account.Currency;
            if (cboCurrency.SelectedIndex == -1) cboCurrency.SelectedIndex = 0;
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
            btnSave.PrimaryColor = ThemeHelper.Primary;
            btnCancel.PrimaryColor = isDark ? Color.FromArgb(60, 60, 75) : Color.FromArgb(200, 200, 210);
            btnCancel.TextColor = isDark ? Color.White : Color.FromArgb(60, 60, 70);
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtAccountName.Text)) { MessageBox.Show(ConfigHelper.Translate("Account name cannot be empty."), "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning); return; }
            if (!decimal.TryParse(txtBalance.Text, out decimal balance)) { MessageBox.Show(ConfigHelper.Translate("Invalid balance amount."), "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning); return; }

            string[] types = { "Cash", "BankAccount", "EWallet", "Savings", "CreditCard" };
            _account.AccountName = txtAccountName.Text;
            _account.AccountType = cboAccountType.SelectedIndex != -1 ? types[cboAccountType.SelectedIndex] : "Cash";
            _account.Balance = balance;
            _account.Currency = cboCurrency.SelectedItem?.ToString() ?? "VND";

            if (ServiceLocator.AccountService.Update(_account))
            {
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            else
            {
                MessageBox.Show("Failed to update account.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
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
