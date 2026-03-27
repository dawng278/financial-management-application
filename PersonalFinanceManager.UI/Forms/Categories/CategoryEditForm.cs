using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Windows.Forms;
using PersonalFinanceManager.Common.Helpers;
using PersonalFinanceManager.Infrastructure.DI;
using PersonalFinanceManager.Models;
using ReaLTaiizor.Controls;

namespace PersonalFinanceManager.Forms.Categories
{
    public class CategoryEditForm : Form
    {
        public Category ResultCategory { get; private set; }
        private Category _editingCategory;

        private HopeTextBox txtName;
        private HopeComboBox cbType;
        private HopeTextBox txtBudgetLimit;
        private HopeButton btnSave;
        private HopeButton btnCancel;
        private Label lblTitle;
        private Label lblSubTitle;

        public CategoryEditForm(Category cat = null)
        {
            _editingCategory = cat;
            this.FormBorderStyle = FormBorderStyle.None;
            this.Size = new Size(480, 500);
            this.StartPosition = FormStartPosition.CenterParent;
            this.ShowInTaskbar = false;
            
            SetupControls();
            LoadData();
            ApplyTheme();
        }

        private void SetupControls()
        {
            var t = new Func<string, string>(ConfigHelper.Translate);

            // Title Block
            lblTitle = new Label { Text = _editingCategory == null ? t("Add Category") : t("Edit Category"), Font = new Font("Segoe UI", 18F, FontStyle.Bold), Location = new Point(35, 45), AutoSize = true };
            lblSubTitle = new Label { Text = t("Organize your flow with semantic buckets."), Font = new Font("Segoe UI", 9.5F), Location = new Point(35, 85), AutoSize = true, ForeColor = Color.Gray };

            int startY = 140;
            int stepY = 85;
            int fieldW = 410;

            // Name
            var lblName = CreateFieldLabel(t("CATEGORY NAME"), 35, startY);
            txtName = new HopeTextBox { Location = new Point(35, startY + 20), Width = fieldW, Height = 40 };

            // Type
            var lblType = CreateFieldLabel(t("TYPE"), 35, startY + stepY);
            cbType = new HopeComboBox { Location = new Point(35, startY + stepY + 20), Width = fieldW, Height = 40, DropDownStyle = ComboBoxStyle.DropDownList };
            cbType.Items.AddRange(new object[] { "Expense", "Income" });

            // Budget Limit
            var lblBudget = CreateFieldLabel(t("BUDGET LIMIT"), 35, startY + 2 * stepY);
            txtBudgetLimit = new HopeTextBox { Location = new Point(35, startY + 2 * stepY + 20), Width = fieldW, Height = 40, Hint = t("Enter amount (e.g. 1000000)") };

            // Buttons
            btnSave = new HopeButton { Text = t("Save"), Location = new Point(275, 420), Width = 170, Height = 45, PrimaryColor = Color.FromArgb(64, 158, 255), Cursor = Cursors.Hand };
            btnSave.Click += BtnSave_Click;

            btnCancel = new HopeButton { Text = t("Cancel"), Location = new Point(145, 420), Width = 120, Height = 45, PrimaryColor = Color.Gray, Cursor = Cursors.Hand };
            btnCancel.Click += (s, e) => { this.DialogResult = DialogResult.Cancel; this.Close(); };

            this.Controls.Add(lblTitle); this.Controls.Add(lblSubTitle);
            this.Controls.Add(lblName); this.Controls.Add(txtName);
            this.Controls.Add(lblType); this.Controls.Add(cbType);
            this.Controls.Add(lblBudget); this.Controls.Add(txtBudgetLimit);
            this.Controls.Add(btnSave); this.Controls.Add(btnCancel);

            // Drag support
            this.MouseDown += (s, e) => { if (e.Button == MouseButtons.Left) { this.Capture = false; Message msg = Message.Create(this.Handle, 0xA1, new IntPtr(2), IntPtr.Zero); base.WndProc(ref msg); } };
        }

        private Label CreateFieldLabel(string text, int x, int y)
        {
            return new Label { Text = text, Font = new Font("Segoe UI", 8.5F, FontStyle.Bold), ForeColor = Color.Gray, Location = new Point(x, y), AutoSize = true };
        }

        private void LoadData()
        {
            if (_editingCategory == null) { cbType.SelectedIndex = 0; }
            else
            {
                txtName.Text = _editingCategory.Name;
                cbType.SelectedItem = _editingCategory.Type;
                txtBudgetLimit.Text = _editingCategory.BudgetLimit.ToString("G29"); // Use G29 to avoid trailing zeros for decimals
                if (_editingCategory.IsDefault) { txtName.Enabled = false; cbType.Enabled = false; txtBudgetLimit.Enabled = false; lblSubTitle.Text = ConfigHelper.Translate("System Default Category"); }
            }
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

        private void BtnSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtName.Text))
            {
                MessageBox.Show(ConfigHelper.Translate("Please enter a category name."), "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (_editingCategory == null) ResultCategory = new Category();
            else ResultCategory = _editingCategory;

            ResultCategory.Name = txtName.Text.Trim();
            ResultCategory.Type = cbType.SelectedItem?.ToString() ?? "Expense";

            if (string.IsNullOrWhiteSpace(txtBudgetLimit.Text))
            {
                MessageBox.Show(ConfigHelper.Translate("Please enter a budget limit."), "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!decimal.TryParse(txtBudgetLimit.Text, out decimal budgetLimit))
            {
                MessageBox.Show(ConfigHelper.Translate("Invalid budget limit. Please enter a valid number."), "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            ResultCategory.BudgetLimit = budgetLimit;
            
            if (_editingCategory == null) {
                // Assign random premium color
                string[] colors = { "#0078D4", "#FF0080", "#00CC6A", "#FF8C00", "#8E44AD", "#D4AF37", "#E74C3C", "#16A085" };
                ResultCategory.ColorHex = colors[new Random().Next(colors.Length)];
                ResultCategory.IconName = "Tag";
            }

            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}
