namespace PersonalFinanceManager.Forms.Settings
{
    partial class SettingsForm
    {
        private System.ComponentModel.IContainer components = null;
        protected override void Dispose(bool disposing)
        {
            if (disposing && components != null) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.guna2Drag = new Guna.UI2.WinForms.Guna2DragControl(this.components);
            this.pnlSidebar = new System.Windows.Forms.Panel();
            this.pnlContent = new System.Windows.Forms.Panel();
            this.pnlTopBar = new System.Windows.Forms.Panel();
            this.pnlMain = new System.Windows.Forms.Panel();
            this.picLogo = new System.Windows.Forms.PictureBox();
            this.lblAppName = new System.Windows.Forms.Label();
            this.btnNavDashboard = new Guna.UI2.WinForms.Guna2Button();
            this.btnNavTransactions = new Guna.UI2.WinForms.Guna2Button();
            this.btnNavInvoices = new Guna.UI2.WinForms.Guna2Button();
            this.btnNavWallets = new Guna.UI2.WinForms.Guna2Button();
            this.btnNavSettings = new Guna.UI2.WinForms.Guna2Button();
            this.btnNavHelp = new Guna.UI2.WinForms.Guna2Button();
            this.btnNavLogout = new Guna.UI2.WinForms.Guna2Button();
            this.lblPageTitle = new System.Windows.Forms.Label();
            this.picAvatar = new System.Windows.Forms.PictureBox();
            this.lblUsername = new System.Windows.Forms.Label();
            this.btnMinimize = new Guna.UI2.WinForms.Guna2Button();
            this.btnMaximize = new Guna.UI2.WinForms.Guna2Button();
            this.btnClose = new Guna.UI2.WinForms.Guna2Button();
            this.pnlSettingsWrap = new System.Windows.Forms.Panel();
            this.lblSectionTitle = new System.Windows.Forms.Label();
            this.lblSectionSub = new System.Windows.Forms.Label();
            this.pnlFormCard = new System.Windows.Forms.Panel();
            this.lblPersonalInfo = new System.Windows.Forms.Label();
            this.btnEdit = new Guna.UI2.WinForms.Guna2Button();
            this.pnlDivider = new System.Windows.Forms.Panel();
            this.lblFirstNameLbl = new System.Windows.Forms.Label();
            this.lblLastLbl = new System.Windows.Forms.Label();
            this.txtFirstName = new Guna.UI2.WinForms.Guna2TextBox();
            this.txtLast = new Guna.UI2.WinForms.Guna2TextBox();
            this.lblDobLbl = new System.Windows.Forms.Label();
            this.lblMobileLbl = new System.Windows.Forms.Label();
            this.dtpDob = new Guna.UI2.WinForms.Guna2DateTimePicker();
            this.txtMobile = new Guna.UI2.WinForms.Guna2TextBox();
            this.lblEmailLbl = new System.Windows.Forms.Label();
            this.txtEmail = new Guna.UI2.WinForms.Guna2TextBox();
            this.lblNewPassLbl = new System.Windows.Forms.Label();
            this.lblConfirmPassLbl = new System.Windows.Forms.Label();
            this.txtNewPass = new Guna.UI2.WinForms.Guna2TextBox();
            this.txtConfirmPass = new Guna.UI2.WinForms.Guna2TextBox();
            this.btnUpdate = new Guna.UI2.WinForms.Guna2Button();

            this.pnlSidebar.SuspendLayout();
            this.pnlContent.SuspendLayout();
            this.pnlTopBar.SuspendLayout();
            this.pnlMain.SuspendLayout();
            this.pnlSettingsWrap.SuspendLayout();
            this.pnlFormCard.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picLogo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picAvatar)).BeginInit();
            this.SuspendLayout();

            // ── FORM ──────────────────────────────────────────────────────────────
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(247, 248, 252);
            this.ClientSize = new System.Drawing.Size(1366, 768);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Name = "SettingsForm";
            this.Text = "Settings";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.guna2Drag.TargetControl = this.pnlTopBar;
            this.guna2Drag.UseTransparentDrag = true;

            // ── SIDEBAR ───────────────────────────────────────────────────────────
            this.pnlSidebar.BackColor = System.Drawing.Color.White;
            this.pnlSidebar.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlSidebar.Width = 240;
            this.pnlSidebar.Paint += new System.Windows.Forms.PaintEventHandler(this.pnlSidebar_Paint);

            this.picLogo.Location = new System.Drawing.Point(20, 22);
            this.picLogo.Size = new System.Drawing.Size(42, 42);
            this.picLogo.BackColor = System.Drawing.Color.Transparent;
            this.picLogo.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.picLogo.Paint += new System.Windows.Forms.PaintEventHandler(this.picLogo_Paint);

            this.lblAppName.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.lblAppName.ForeColor = System.Drawing.Color.FromArgb(18, 20, 28);
            this.lblAppName.Location = new System.Drawing.Point(70, 28);
            this.lblAppName.Size = new System.Drawing.Size(140, 28);
            this.lblAppName.AutoSize = false;
            this.lblAppName.Text = "Maglo.";

            // Nav – Dashboard
            this.btnNavDashboard.Text = "  Dashboard";
            this.btnNavDashboard.Location = new System.Drawing.Point(14, 108);
            this.btnNavDashboard.Size = new System.Drawing.Size(212, 42);
            this.btnNavDashboard.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left;
            this.btnNavDashboard.BorderRadius = 10;
            this.btnNavDashboard.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.btnNavDashboard.FillColor = System.Drawing.Color.Transparent;
            this.btnNavDashboard.ForeColor = System.Drawing.Color.FromArgb(115, 120, 140);
            this.btnNavDashboard.HoverState.FillColor = System.Drawing.Color.FromArgb(245, 246, 250);
            this.btnNavDashboard.HoverState.ForeColor = System.Drawing.Color.FromArgb(22, 24, 35);
            this.btnNavDashboard.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnNavDashboard.Click += new System.EventHandler(this.btnNavDashboard_Click);

            // Nav – Transactions
            this.btnNavTransactions.Text = "  Transactions";
            this.btnNavTransactions.Location = new System.Drawing.Point(14, 156);
            this.btnNavTransactions.Size = new System.Drawing.Size(212, 42);
            this.btnNavTransactions.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left;
            this.btnNavTransactions.BorderRadius = 10;
            this.btnNavTransactions.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.btnNavTransactions.FillColor = System.Drawing.Color.Transparent;
            this.btnNavTransactions.ForeColor = System.Drawing.Color.FromArgb(115, 120, 140);
            this.btnNavTransactions.HoverState.FillColor = System.Drawing.Color.FromArgb(245, 246, 250);
            this.btnNavTransactions.HoverState.ForeColor = System.Drawing.Color.FromArgb(22, 24, 35);
            this.btnNavTransactions.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnNavTransactions.Click += new System.EventHandler(this.btnNavTransactions_Click);

            // Nav – Invoices
            this.btnNavInvoices.Text = "  Invoices";
            this.btnNavInvoices.Location = new System.Drawing.Point(14, 204);
            this.btnNavInvoices.Size = new System.Drawing.Size(212, 42);
            this.btnNavInvoices.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left;
            this.btnNavInvoices.BorderRadius = 10;
            this.btnNavInvoices.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.btnNavInvoices.FillColor = System.Drawing.Color.Transparent;
            this.btnNavInvoices.ForeColor = System.Drawing.Color.FromArgb(115, 120, 140);
            this.btnNavInvoices.HoverState.FillColor = System.Drawing.Color.FromArgb(245, 246, 250);
            this.btnNavInvoices.HoverState.ForeColor = System.Drawing.Color.FromArgb(22, 24, 35);
            this.btnNavInvoices.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnNavInvoices.Click += new System.EventHandler(this.btnNavInvoices_Click);

            // Nav – My Wallets
            this.btnNavWallets.Text = "  My Wallets";
            this.btnNavWallets.Location = new System.Drawing.Point(14, 252);
            this.btnNavWallets.Size = new System.Drawing.Size(212, 42);
            this.btnNavWallets.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left;
            this.btnNavWallets.BorderRadius = 10;
            this.btnNavWallets.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.btnNavWallets.FillColor = System.Drawing.Color.Transparent;
            this.btnNavWallets.ForeColor = System.Drawing.Color.FromArgb(115, 120, 140);
            this.btnNavWallets.HoverState.FillColor = System.Drawing.Color.FromArgb(245, 246, 250);
            this.btnNavWallets.HoverState.ForeColor = System.Drawing.Color.FromArgb(22, 24, 35);
            this.btnNavWallets.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnNavWallets.Click += new System.EventHandler(this.btnNavWallets_Click);

            // Nav – Settings (ACTIVE)
            this.btnNavSettings.Text = "  Settings";
            this.btnNavSettings.Location = new System.Drawing.Point(14, 300);
            this.btnNavSettings.Size = new System.Drawing.Size(212, 42);
            this.btnNavSettings.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left;
            this.btnNavSettings.BorderRadius = 10;
            this.btnNavSettings.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.btnNavSettings.FillColor = System.Drawing.Color.FromArgb(181, 212, 34);
            this.btnNavSettings.ForeColor = System.Drawing.Color.FromArgb(22, 24, 35);
            this.btnNavSettings.HoverState.FillColor = System.Drawing.Color.FromArgb(165, 196, 20);
            this.btnNavSettings.HoverState.ForeColor = System.Drawing.Color.FromArgb(22, 24, 35);
            this.btnNavSettings.Cursor = System.Windows.Forms.Cursors.Hand;

            // Nav – Help (bottom)
            this.btnNavHelp.Text = "  Help";
            this.btnNavHelp.Location = new System.Drawing.Point(14, 676);
            this.btnNavHelp.Size = new System.Drawing.Size(212, 42);
            this.btnNavHelp.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left;
            this.btnNavHelp.BorderRadius = 10;
            this.btnNavHelp.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.btnNavHelp.FillColor = System.Drawing.Color.Transparent;
            this.btnNavHelp.ForeColor = System.Drawing.Color.FromArgb(115, 120, 140);
            this.btnNavHelp.HoverState.FillColor = System.Drawing.Color.FromArgb(245, 246, 250);
            this.btnNavHelp.HoverState.ForeColor = System.Drawing.Color.FromArgb(22, 24, 35);
            this.btnNavHelp.Cursor = System.Windows.Forms.Cursors.Hand;

            // Nav – Logout (bottom, red)
            this.btnNavLogout.Text = "  Logout";
            this.btnNavLogout.Location = new System.Drawing.Point(14, 722);
            this.btnNavLogout.Size = new System.Drawing.Size(212, 42);
            this.btnNavLogout.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left;
            this.btnNavLogout.BorderRadius = 10;
            this.btnNavLogout.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.btnNavLogout.FillColor = System.Drawing.Color.Transparent;
            this.btnNavLogout.ForeColor = System.Drawing.Color.FromArgb(210, 55, 55);
            this.btnNavLogout.HoverState.FillColor = System.Drawing.Color.FromArgb(255, 238, 238);
            this.btnNavLogout.HoverState.ForeColor = System.Drawing.Color.FromArgb(190, 35, 35);
            this.btnNavLogout.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnNavLogout.Click += new System.EventHandler(this.btnNavLogout_Click);

            this.pnlSidebar.Controls.Add(this.picLogo);
            this.pnlSidebar.Controls.Add(this.lblAppName);
            this.pnlSidebar.Controls.Add(this.btnNavDashboard);
            this.pnlSidebar.Controls.Add(this.btnNavTransactions);
            this.pnlSidebar.Controls.Add(this.btnNavInvoices);
            this.pnlSidebar.Controls.Add(this.btnNavWallets);
            this.pnlSidebar.Controls.Add(this.btnNavSettings);
            this.pnlSidebar.Controls.Add(this.btnNavHelp);
            this.pnlSidebar.Controls.Add(this.btnNavLogout);

            // ── TOPBAR ────────────────────────────────────────────────────────────
            this.pnlTopBar.BackColor = System.Drawing.Color.FromArgb(247, 248, 252);
            this.pnlTopBar.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlTopBar.Height = 64;
            this.pnlTopBar.Paint += new System.Windows.Forms.PaintEventHandler(this.pnlTopBar_Paint);

            this.lblPageTitle.Font = new System.Drawing.Font("Segoe UI", 22F, System.Drawing.FontStyle.Bold);
            this.lblPageTitle.ForeColor = System.Drawing.Color.FromArgb(18, 20, 28);
            this.lblPageTitle.Location = new System.Drawing.Point(28, 12);
            this.lblPageTitle.Size = new System.Drawing.Size(260, 40);
            this.lblPageTitle.AutoSize = false;
            this.lblPageTitle.Text = "Settings";

            this.picAvatar.Size = new System.Drawing.Size(36, 36);
            this.picAvatar.Location = new System.Drawing.Point(10, 14);
            this.picAvatar.BackColor = System.Drawing.Color.Transparent;
            this.picAvatar.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.picAvatar.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            this.picAvatar.Paint += new System.Windows.Forms.PaintEventHandler(this.picAvatar_Paint);

            this.lblUsername.AutoSize = true;
            this.lblUsername.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.lblUsername.ForeColor = System.Drawing.Color.FromArgb(25, 28, 42);
            this.lblUsername.Location = new System.Drawing.Point(10, 22);
            this.lblUsername.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            this.lblUsername.Text = "Admin";

            this.btnMinimize.FillColor = System.Drawing.Color.Transparent;
            this.btnMinimize.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.btnMinimize.ForeColor = System.Drawing.Color.FromArgb(120, 125, 142);
            this.btnMinimize.Location = new System.Drawing.Point(10, 17);
            this.btnMinimize.Size = new System.Drawing.Size(30, 30);
            this.btnMinimize.Text = "-";
            this.btnMinimize.BorderRadius = 7;
            this.btnMinimize.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            this.btnMinimize.HoverState.FillColor = System.Drawing.Color.FromArgb(232, 234, 240);
            this.btnMinimize.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnMinimize.Click += new System.EventHandler(this.btnMinimize_Click);

            this.btnMaximize.FillColor = System.Drawing.Color.Transparent;
            this.btnMaximize.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnMaximize.ForeColor = System.Drawing.Color.FromArgb(120, 125, 142);
            this.btnMaximize.Location = new System.Drawing.Point(10, 17);
            this.btnMaximize.Size = new System.Drawing.Size(30, 30);
            this.btnMaximize.Text = "[]";
            this.btnMaximize.BorderRadius = 7;
            this.btnMaximize.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            this.btnMaximize.HoverState.FillColor = System.Drawing.Color.FromArgb(232, 234, 240);
            this.btnMaximize.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnMaximize.Click += new System.EventHandler(this.btnMaximize_Click);

            this.btnClose.FillColor = System.Drawing.Color.Transparent;
            this.btnClose.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnClose.ForeColor = System.Drawing.Color.FromArgb(120, 125, 142);
            this.btnClose.Location = new System.Drawing.Point(10, 17);
            this.btnClose.Size = new System.Drawing.Size(30, 30);
            this.btnClose.Text = "X";
            this.btnClose.BorderRadius = 7;
            this.btnClose.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            this.btnClose.HoverState.FillColor = System.Drawing.Color.FromArgb(235, 60, 60);
            this.btnClose.HoverState.ForeColor = System.Drawing.Color.White;
            this.btnClose.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);

            this.pnlTopBar.Controls.Add(this.lblPageTitle);
            this.pnlTopBar.Controls.Add(this.picAvatar);
            this.pnlTopBar.Controls.Add(this.lblUsername);
            this.pnlTopBar.Controls.Add(this.btnMinimize);
            this.pnlTopBar.Controls.Add(this.btnMaximize);
            this.pnlTopBar.Controls.Add(this.btnClose);

            // ── MAIN ──────────────────────────────────────────────────────────────
            this.pnlMain.BackColor = System.Drawing.Color.FromArgb(247, 248, 252);
            this.pnlMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlMain.AutoScroll = true;
            this.pnlMain.Padding = new System.Windows.Forms.Padding(36, 20, 36, 24);

            // ── SETTINGS WRAP ─────────────────────────────────────────────────────
            this.pnlSettingsWrap.BackColor = System.Drawing.Color.Transparent;
            this.pnlSettingsWrap.Location = new System.Drawing.Point(0, 0);
            this.pnlSettingsWrap.Size = new System.Drawing.Size(860, 700);
            this.pnlSettingsWrap.Anchor = System.Windows.Forms.AnchorStyles.Top |
                                             System.Windows.Forms.AnchorStyles.Left |
                                             System.Windows.Forms.AnchorStyles.Right;

            this.lblSectionTitle.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.lblSectionTitle.ForeColor = System.Drawing.Color.FromArgb(18, 20, 32);
            this.lblSectionTitle.Location = new System.Drawing.Point(0, 0);
            this.lblSectionTitle.AutoSize = true;
            this.lblSectionTitle.Text = "Account Information";

            this.lblSectionSub.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblSectionSub.ForeColor = System.Drawing.Color.FromArgb(148, 153, 172);
            this.lblSectionSub.Location = new System.Drawing.Point(0, 30);
            this.lblSectionSub.AutoSize = true;
            this.lblSectionSub.Text = "Update your account information";

            // ── WHITE FORM CARD ───────────────────────────────────────────────────
            this.pnlFormCard.BackColor = System.Drawing.Color.Transparent;
            this.pnlFormCard.Location = new System.Drawing.Point(0, 68);
            this.pnlFormCard.Size = new System.Drawing.Size(860, 560);
            this.pnlFormCard.Anchor = System.Windows.Forms.AnchorStyles.Top |
                                         System.Windows.Forms.AnchorStyles.Left |
                                         System.Windows.Forms.AnchorStyles.Right;
            this.pnlFormCard.Paint += new System.Windows.Forms.PaintEventHandler(this.pnlWhiteCard_Paint);

            // Personal Information label
            this.lblPersonalInfo.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lblPersonalInfo.ForeColor = System.Drawing.Color.FromArgb(18, 20, 32);
            this.lblPersonalInfo.Location = new System.Drawing.Point(28, 22);
            this.lblPersonalInfo.AutoSize = true;
            this.lblPersonalInfo.Text = "Personal Information";

            // Edit button
            this.btnEdit.Text = "  ✎  Edit";
            this.btnEdit.Location = new System.Drawing.Point(730, 16);
            this.btnEdit.Size = new System.Drawing.Size(102, 36);
            this.btnEdit.BorderRadius = 9;
            this.btnEdit.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.btnEdit.FillColor = System.Drawing.Color.Transparent;
            this.btnEdit.ForeColor = System.Drawing.Color.FromArgb(34, 160, 95);
            this.btnEdit.BorderColor = System.Drawing.Color.Transparent;
            this.btnEdit.HoverState.FillColor = System.Drawing.Color.FromArgb(232, 252, 215);
            this.btnEdit.HoverState.ForeColor = System.Drawing.Color.FromArgb(25, 135, 75);
            this.btnEdit.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnEdit.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);

            // Divider
            this.pnlDivider.Location = new System.Drawing.Point(28, 62);
            this.pnlDivider.Size = new System.Drawing.Size(804, 1);
            this.pnlDivider.BackColor = System.Drawing.Color.FromArgb(230, 232, 244);
            this.pnlDivider.Anchor = System.Windows.Forms.AnchorStyles.Top |
                                        System.Windows.Forms.AnchorStyles.Left |
                                        System.Windows.Forms.AnchorStyles.Right;

            // ── ROW 1: First Name (left=28) | Last (right=452)  Y=82/104 ─────────
            this.lblFirstNameLbl.Font = new System.Drawing.Font("Segoe UI", 8.5F);
            this.lblFirstNameLbl.ForeColor = System.Drawing.Color.FromArgb(145, 150, 170);
            this.lblFirstNameLbl.Location = new System.Drawing.Point(28, 82);
            this.lblFirstNameLbl.AutoSize = true;
            this.lblFirstNameLbl.Text = "First Name";

            this.txtFirstName.Location = new System.Drawing.Point(28, 104);
            this.txtFirstName.Size = new System.Drawing.Size(360, 44);
            this.txtFirstName.BorderRadius = 8;
            this.txtFirstName.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtFirstName.FillColor = System.Drawing.Color.White;
            this.txtFirstName.ForeColor = System.Drawing.Color.FromArgb(22, 25, 40);
            this.txtFirstName.BorderColor = System.Drawing.Color.FromArgb(218, 222, 235);
            this.txtFirstName.FocusedState.BorderColor = System.Drawing.Color.FromArgb(181, 212, 34);
            this.txtFirstName.PlaceholderText = "First name";
            this.txtFirstName.Text = "Mahfuzul Islam";
            this.txtFirstName.ReadOnly = true;
            this.txtFirstName.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left;

            this.lblLastLbl.Font = new System.Drawing.Font("Segoe UI", 8.5F);
            this.lblLastLbl.ForeColor = System.Drawing.Color.FromArgb(145, 150, 170);
            this.lblLastLbl.Location = new System.Drawing.Point(452, 82);
            this.lblLastLbl.AutoSize = true;
            this.lblLastLbl.Text = "Last";

            this.txtLast.Location = new System.Drawing.Point(452, 104);
            this.txtLast.Size = new System.Drawing.Size(360, 44);
            this.txtLast.BorderRadius = 8;
            this.txtLast.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtLast.FillColor = System.Drawing.Color.White;
            this.txtLast.ForeColor = System.Drawing.Color.FromArgb(22, 25, 40);
            this.txtLast.BorderColor = System.Drawing.Color.FromArgb(218, 222, 235);
            this.txtLast.FocusedState.BorderColor = System.Drawing.Color.FromArgb(181, 212, 34);
            this.txtLast.PlaceholderText = "Last name";
            this.txtLast.Text = "Nabil";
            this.txtLast.ReadOnly = true;
            this.txtLast.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left;

            // ── ROW 2: Date of Birth (left) | Mobile (right)  Y=174/196 ──────────
            this.lblDobLbl.Font = new System.Drawing.Font("Segoe UI", 8.5F);
            this.lblDobLbl.ForeColor = System.Drawing.Color.FromArgb(145, 150, 170);
            this.lblDobLbl.Location = new System.Drawing.Point(28, 174);
            this.lblDobLbl.AutoSize = true;
            this.lblDobLbl.Text = "Date of Birth";

            this.dtpDob.Location = new System.Drawing.Point(28, 196);
            this.dtpDob.Size = new System.Drawing.Size(360, 44);
            this.dtpDob.BorderRadius = 8;
            this.dtpDob.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.dtpDob.FillColor = System.Drawing.Color.White;
            this.dtpDob.ForeColor = System.Drawing.Color.FromArgb(22, 25, 40);
            this.dtpDob.BorderColor = System.Drawing.Color.FromArgb(218, 222, 235);
            this.dtpDob.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpDob.Value = new System.DateTime(1998, 9, 27);
            this.dtpDob.Enabled = false;
            this.dtpDob.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left;

            this.lblMobileLbl.Font = new System.Drawing.Font("Segoe UI", 8.5F);
            this.lblMobileLbl.ForeColor = System.Drawing.Color.FromArgb(145, 150, 170);
            this.lblMobileLbl.Location = new System.Drawing.Point(452, 174);
            this.lblMobileLbl.AutoSize = true;
            this.lblMobileLbl.Text = "Mobile Number";

            this.txtMobile.Location = new System.Drawing.Point(452, 196);
            this.txtMobile.Size = new System.Drawing.Size(360, 44);
            this.txtMobile.BorderRadius = 8;
            this.txtMobile.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtMobile.FillColor = System.Drawing.Color.White;
            this.txtMobile.ForeColor = System.Drawing.Color.FromArgb(22, 25, 40);
            this.txtMobile.BorderColor = System.Drawing.Color.FromArgb(218, 222, 235);
            this.txtMobile.FocusedState.BorderColor = System.Drawing.Color.FromArgb(181, 212, 34);
            this.txtMobile.PlaceholderText = "+1 xxx xxx xxxx";
            this.txtMobile.Text = "+123 456 7890";
            this.txtMobile.ReadOnly = true;
            this.txtMobile.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left;

            // ── ROW 3: Email full-width  Y=268/290 ───────────────────────────────
            this.lblEmailLbl.Font = new System.Drawing.Font("Segoe UI", 8.5F);
            this.lblEmailLbl.ForeColor = System.Drawing.Color.FromArgb(145, 150, 170);
            this.lblEmailLbl.Location = new System.Drawing.Point(28, 268);
            this.lblEmailLbl.AutoSize = true;
            this.lblEmailLbl.Text = "Email";

            this.txtEmail.Location = new System.Drawing.Point(28, 290);
            this.txtEmail.Size = new System.Drawing.Size(804, 44);
            this.txtEmail.BorderRadius = 8;
            this.txtEmail.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtEmail.FillColor = System.Drawing.Color.White;
            this.txtEmail.ForeColor = System.Drawing.Color.FromArgb(22, 25, 40);
            this.txtEmail.BorderColor = System.Drawing.Color.FromArgb(218, 222, 235);
            this.txtEmail.FocusedState.BorderColor = System.Drawing.Color.FromArgb(181, 212, 34);
            this.txtEmail.PlaceholderText = "email@example.com";
            this.txtEmail.Text = "hellouihut@gmail.com";
            this.txtEmail.ReadOnly = true;
            this.txtEmail.Anchor = System.Windows.Forms.AnchorStyles.Top |
                                                     System.Windows.Forms.AnchorStyles.Left |
                                                     System.Windows.Forms.AnchorStyles.Right;

            // ── ROW 4: New Password (left) | Confirm Password (right)  Y=362/384 ─
            this.lblNewPassLbl.Font = new System.Drawing.Font("Segoe UI", 8.5F);
            this.lblNewPassLbl.ForeColor = System.Drawing.Color.FromArgb(145, 150, 170);
            this.lblNewPassLbl.Location = new System.Drawing.Point(28, 362);
            this.lblNewPassLbl.AutoSize = true;
            this.lblNewPassLbl.Text = "New Password";

            this.txtNewPass.Location = new System.Drawing.Point(28, 384);
            this.txtNewPass.Size = new System.Drawing.Size(360, 44);
            this.txtNewPass.BorderRadius = 8;
            this.txtNewPass.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtNewPass.FillColor = System.Drawing.Color.White;
            this.txtNewPass.ForeColor = System.Drawing.Color.FromArgb(22, 25, 40);
            this.txtNewPass.BorderColor = System.Drawing.Color.FromArgb(218, 222, 235);
            this.txtNewPass.FocusedState.BorderColor = System.Drawing.Color.FromArgb(181, 212, 34);
            this.txtNewPass.PlaceholderText = "New password";
            this.txtNewPass.UseSystemPasswordChar = true;
            this.txtNewPass.ReadOnly = true;
            this.txtNewPass.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left;

            this.lblConfirmPassLbl.Font = new System.Drawing.Font("Segoe UI", 8.5F);
            this.lblConfirmPassLbl.ForeColor = System.Drawing.Color.FromArgb(145, 150, 170);
            this.lblConfirmPassLbl.Location = new System.Drawing.Point(452, 362);
            this.lblConfirmPassLbl.AutoSize = true;
            this.lblConfirmPassLbl.Text = "Confirm Password";

            this.txtConfirmPass.Location = new System.Drawing.Point(452, 384);
            this.txtConfirmPass.Size = new System.Drawing.Size(360, 44);
            this.txtConfirmPass.BorderRadius = 8;
            this.txtConfirmPass.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtConfirmPass.FillColor = System.Drawing.Color.White;
            this.txtConfirmPass.ForeColor = System.Drawing.Color.FromArgb(22, 25, 40);
            this.txtConfirmPass.BorderColor = System.Drawing.Color.FromArgb(218, 222, 235);
            this.txtConfirmPass.FocusedState.BorderColor = System.Drawing.Color.FromArgb(181, 212, 34);
            this.txtConfirmPass.PlaceholderText = "Confirm password";
            this.txtConfirmPass.UseSystemPasswordChar = true;
            this.txtConfirmPass.ReadOnly = true;
            this.txtConfirmPass.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left;

            // ── Update button  Y=460 ──────────────────────────────────────────────
            this.btnUpdate.Location = new System.Drawing.Point(28, 460);
            this.btnUpdate.Size = new System.Drawing.Size(170, 48);
            this.btnUpdate.BorderRadius = 12;
            this.btnUpdate.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.btnUpdate.FillColor = System.Drawing.Color.FromArgb(160, 180, 160);
            this.btnUpdate.ForeColor = System.Drawing.Color.White;
            this.btnUpdate.HoverState.FillColor = System.Drawing.Color.FromArgb(160, 180, 160);
            this.btnUpdate.HoverState.ForeColor = System.Drawing.Color.White;
            this.btnUpdate.Text = "Update";
            this.btnUpdate.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnUpdate.Enabled = false;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);

            this.pnlFormCard.Controls.Add(this.lblPersonalInfo);
            this.pnlFormCard.Controls.Add(this.btnEdit);
            this.pnlFormCard.Controls.Add(this.pnlDivider);
            this.pnlFormCard.Controls.Add(this.lblFirstNameLbl);
            this.pnlFormCard.Controls.Add(this.txtFirstName);
            this.pnlFormCard.Controls.Add(this.lblLastLbl);
            this.pnlFormCard.Controls.Add(this.txtLast);
            this.pnlFormCard.Controls.Add(this.lblDobLbl);
            this.pnlFormCard.Controls.Add(this.dtpDob);
            this.pnlFormCard.Controls.Add(this.lblMobileLbl);
            this.pnlFormCard.Controls.Add(this.txtMobile);
            this.pnlFormCard.Controls.Add(this.lblEmailLbl);
            this.pnlFormCard.Controls.Add(this.txtEmail);
            this.pnlFormCard.Controls.Add(this.lblNewPassLbl);
            this.pnlFormCard.Controls.Add(this.txtNewPass);
            this.pnlFormCard.Controls.Add(this.lblConfirmPassLbl);
            this.pnlFormCard.Controls.Add(this.txtConfirmPass);
            this.pnlFormCard.Controls.Add(this.btnUpdate);

            this.pnlSettingsWrap.Controls.Add(this.lblSectionTitle);
            this.pnlSettingsWrap.Controls.Add(this.lblSectionSub);
            this.pnlSettingsWrap.Controls.Add(this.pnlFormCard);

            this.pnlMain.Controls.Add(this.pnlSettingsWrap);

            // ── CONTENT ───────────────────────────────────────────────────────────
            this.pnlContent.BackColor = System.Drawing.Color.FromArgb(247, 248, 252);
            this.pnlContent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlContent.Controls.Add(this.pnlMain);
            this.pnlContent.Controls.Add(this.pnlTopBar);

            this.Controls.Add(this.pnlContent);
            this.Controls.Add(this.pnlSidebar);

            this.pnlSidebar.ResumeLayout(false);
            this.pnlContent.ResumeLayout(false);
            this.pnlTopBar.ResumeLayout(false);
            this.pnlMain.ResumeLayout(false);
            this.pnlSettingsWrap.ResumeLayout(false);
            this.pnlFormCard.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.picLogo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picAvatar)).EndInit();
            this.ResumeLayout(false);
        }

        // ── Designer fields ───────────────────────────────────────────────────────
        private Guna.UI2.WinForms.Guna2DragControl guna2Drag;
        private System.Windows.Forms.Panel pnlSidebar, pnlContent, pnlTopBar, pnlMain;
        private System.Windows.Forms.Panel pnlSettingsWrap, pnlFormCard, pnlDivider;
        private System.Windows.Forms.PictureBox picLogo, picAvatar;
        private System.Windows.Forms.Label lblAppName, lblPageTitle, lblUsername;
        private System.Windows.Forms.Label lblSectionTitle, lblSectionSub, lblPersonalInfo;
        private System.Windows.Forms.Label lblFirstNameLbl, lblLastLbl;
        private System.Windows.Forms.Label lblDobLbl, lblMobileLbl;
        private System.Windows.Forms.Label lblEmailLbl;
        private System.Windows.Forms.Label lblNewPassLbl, lblConfirmPassLbl;
        private Guna.UI2.WinForms.Guna2Button btnNavDashboard, btnNavTransactions, btnNavInvoices;
        private Guna.UI2.WinForms.Guna2Button btnNavWallets, btnNavSettings, btnNavHelp, btnNavLogout;
        private Guna.UI2.WinForms.Guna2Button btnMinimize, btnMaximize, btnClose;
        private Guna.UI2.WinForms.Guna2Button btnEdit, btnUpdate;
        private Guna.UI2.WinForms.Guna2TextBox txtFirstName, txtLast;
        private Guna.UI2.WinForms.Guna2TextBox txtMobile, txtEmail;
        private Guna.UI2.WinForms.Guna2TextBox txtNewPass, txtConfirmPass;
        private Guna.UI2.WinForms.Guna2DateTimePicker dtpDob;
    }
}