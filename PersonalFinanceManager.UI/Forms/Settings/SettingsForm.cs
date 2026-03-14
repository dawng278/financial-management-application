using PersonalFinanceManager.Infrastructure.DI;
using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Windows.Forms;

namespace PersonalFinanceManager.Forms.Settings
{
    public partial class SettingsForm : Form
    {
        private bool _editMode = false;

        // Readonly field style
        private static readonly Color ReadBorder = Color.FromArgb(218, 222, 235);
        private static readonly Color ReadFill = Color.White;
        // Edit mode field style
        private static readonly Color EditBorder = Color.FromArgb(181, 212, 34);
        private static readonly Color EditFill = Color.FromArgb(250, 252, 245);

        public SettingsForm()
        {
            InitializeComponent();
            this.Load += SettingsForm_Load;
            this.SizeChanged += SettingsForm_SizeChanged;
            btnNavHelp.Click += btnNavHelp_Click;
        }

        // =====================================================================
        // LOAD
        // =====================================================================
        private void SettingsForm_Load(object sender, EventArgs e)
        {
            try
            {
                var u = ServiceLocator.UserService.GetCurrentUser();
                if (u != null)
                {
                    lblUsername.Text = u.FullName ?? u.Email ?? "Admin";
                    // Pre-fill fields from user data if available
                    if (!string.IsNullOrEmpty(u.FullName))
                    {
                        var parts = u.FullName.Split(' ');
                        txtFirstName.Text = parts.Length > 0 ? parts[0] : u.FullName;
                        txtLast.Text = parts.Length > 1 ? string.Join(" ", parts, 1, parts.Length - 1) : "";
                    }

                    if (!string.IsNullOrEmpty(u.Email))
                        txtEmail.Text = u.Email;
                }
            }
            catch { }

            LayoutTopBar();
            LayoutSidebarBottom();
            ResizeContent();
            SetEditMode(false);
        }

        // =====================================================================
        // EDIT / VIEW TOGGLE
        // =====================================================================
        private void btnEdit_Click(object sender, EventArgs e)
        {
            SetEditMode(!_editMode);
        }

        private void SetEditMode(bool edit)
        {
            _editMode = edit;

            // Toggle button label
            btnEdit.Text = edit ? "  ✕  Cancel" : "  ✎  Edit";
            btnEdit.ForeColor = edit
                ? Color.FromArgb(195, 45, 45)
                : Color.FromArgb(34, 160, 95);
            btnEdit.HoverState.FillColor = edit
                ? Color.FromArgb(255, 235, 235)
                : Color.FromArgb(232, 252, 215);
            btnEdit.HoverState.ForeColor = edit
                ? Color.FromArgb(160, 30, 30)
                : Color.FromArgb(25, 135, 75);

            // Toggle field readonly state + style
            SetFieldEditable(txtFirstName, edit);
            SetFieldEditable(txtLast, edit);
            SetFieldEditable(txtMobile, edit);
            SetFieldEditable(txtEmail, edit);
            SetFieldEditable(txtNewPass, edit);
            SetFieldEditable(txtConfirmPass, edit);

            dtpDob.Enabled = edit;
            dtpDob.BorderColor = edit ? EditBorder : ReadBorder;

            // Update button only active in edit mode
            btnUpdate.Enabled = edit;
            btnUpdate.FillColor = edit
                ? Color.FromArgb(34, 160, 95)
                : Color.FromArgb(160, 180, 160);
            btnUpdate.HoverState.FillColor = edit
                ? Color.FromArgb(26, 135, 78)
                : Color.FromArgb(160, 180, 160);
        }

        private void SetFieldEditable(Guna.UI2.WinForms.Guna2TextBox tb, bool edit)
        {
            tb.ReadOnly = !edit;
            tb.BorderColor = edit ? EditBorder : ReadBorder;
            tb.FillColor = edit ? EditFill : ReadFill;
        }

        // =====================================================================
        // UPDATE
        // =====================================================================
        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (!_editMode) return;

            // Basic validation
            if (string.IsNullOrWhiteSpace(txtFirstName.Text))
            { ShowError("First name cannot be empty."); return; }

            if (string.IsNullOrWhiteSpace(txtEmail.Text) || !txtEmail.Text.Contains("@"))
            { ShowError("Please enter a valid email address."); return; }

            if (!string.IsNullOrEmpty(txtNewPass.Text) &&
                txtNewPass.Text != txtConfirmPass.Text)
            { ShowError("Passwords do not match."); return; }

            try
            {
                // Persist via service if available
                var u = ServiceLocator.UserService.GetCurrentUser();
                if (u != null)
                {
                    var updated = new PersonalFinanceManager.Models.User
                    {
                        FullName = txtFirstName.Text.Trim() + " " + txtLast.Text.Trim(),
                        Email = txtEmail.Text.Trim()
                    };

                    var userService = ServiceLocator.UserService as PersonalFinanceManager.Common.Mock.MockUserService;
                    if (userService == null || !userService.UpdateProfile(updated, txtNewPass.Text.Trim()))
                    {
                        ShowError("Unable to update profile. Email may already be used.");
                        return;
                    }
                }
            }
            catch { }

            MessageBox.Show("Profile updated successfully.", "Settings",
                MessageBoxButtons.OK, MessageBoxIcon.Information);

            SetEditMode(false);
        }

        private void ShowError(string msg)
            => MessageBox.Show(msg, "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);

        // =====================================================================
        // LAYOUT
        // =====================================================================
        private void SettingsForm_SizeChanged(object sender, EventArgs e)
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

            pnlSettingsWrap.Location = new Point(pad, pad);
            pnlSettingsWrap.Width = avail;
            pnlFormCard.Width = avail;

            // Stretch full-width controls inside card
            int innerW = avail - 56;   // 28px padding each side
            pnlDivider.Width = innerW;
            txtEmail.Width = innerW;

            // Recalculate two-column widths
            int half = (innerW - 16) / 2;   // 16px gap between columns
            int col2 = 28 + half + 16;

            txtFirstName.Width = half;
            txtLast.Width = half;
            txtLast.Location = new Point(col2, txtLast.Top);
            lblLastLbl.Location = new Point(col2, lblLastLbl.Top);

            dtpDob.Width = half;
            txtMobile.Width = half;
            txtMobile.Location = new Point(col2, txtMobile.Top);
            lblMobileLbl.Location = new Point(col2, lblMobileLbl.Top);

            txtNewPass.Width = half;
            txtConfirmPass.Width = half;
            txtConfirmPass.Location = new Point(col2, txtConfirmPass.Top);
            lblConfirmPassLbl.Location = new Point(col2, lblConfirmPassLbl.Top);

            // Edit button always anchored right inside card
            btnEdit.Location = new Point(avail - 56 - btnEdit.Width, btnEdit.Top);

            pnlFormCard.Invalidate();
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

        private void btnNavWallets_Click(object sender, EventArgs e)
            => UI.Navigation.FormNavigator.GoToMyWallet();

        private void btnNavLogout_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có muốn đăng xuất không?", "Đăng xuất",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                ServiceLocator.UserService.Logout();
                UI.Navigation.FormNavigator.GoToLogin();
            }
        }

        private void btnNavHelp_Click(object sender, EventArgs e)
        {
            var choice = MessageBox.Show(
                "Yes: Backup database\nNo: Restore database",
                "Database Tools",
                MessageBoxButtons.YesNoCancel,
                MessageBoxIcon.Question);

            if (choice == DialogResult.Yes)
            {
                BackupDatabase();
            }
            else if (choice == DialogResult.No)
            {
                RestoreDatabase();
            }
        }

        private void BackupDatabase()
        {
            using (var dialog = new FolderBrowserDialog())
            {
                dialog.Description = "Chọn thư mục lưu backup";
                if (dialog.ShowDialog() != DialogResult.OK) return;

                try
                {
                    var backupFile = CreateBackup(dialog.SelectedPath);
                    MessageBox.Show("Backup thành công:\n" + backupFile, "Backup",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Backup thất bại:\n" + ex.Message, "Backup",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void RestoreDatabase()
        {
            using (var dialog = new OpenFileDialog())
            {
                dialog.Filter = "SQLite Database (*.db)|*.db|All files (*.*)|*.*";
                dialog.Title = "Chọn file backup để restore";

                if (dialog.ShowDialog() != DialogResult.OK) return;

                var confirm = MessageBox.Show(
                    "Restore sẽ ghi đè database hiện tại. Tiếp tục?",
                    "Xác nhận restore",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Warning);

                if (confirm != DialogResult.Yes) return;

                try
                {
                    RestoreBackup(dialog.FileName);
                    MessageBox.Show("Restore thành công. Vui lòng khởi động lại ứng dụng.", "Restore",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Restore thất bại:\n" + ex.Message, "Restore",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private static string GetDbPath()
        {
            return Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "PersonalFinance.db");
        }

        private static string CreateBackup(string destinationFolder)
        {
            var dbPath = GetDbPath();
            if (!File.Exists(dbPath))
                throw new FileNotFoundException("Không tìm thấy file database.", dbPath);

            Directory.CreateDirectory(destinationFolder);
            var backupFile = Path.Combine(destinationFolder,
                "PersonalFinance_backup_" + DateTime.Now.ToString("yyyyMMdd_HHmmss") + ".db");

            File.Copy(dbPath, backupFile, true);
            return backupFile;
        }

        private static void RestoreBackup(string backupFilePath)
        {
            if (!File.Exists(backupFilePath))
                throw new FileNotFoundException("Không tìm thấy file backup.", backupFilePath);

            File.Copy(backupFilePath, GetDbPath(), true);
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