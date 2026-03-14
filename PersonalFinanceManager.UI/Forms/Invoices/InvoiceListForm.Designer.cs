namespace PersonalFinanceManager.Forms.Invoices
{
    partial class InvoiceListForm
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
            this.pnlToolbar = new System.Windows.Forms.Panel();
            this.txtSearch = new Guna.UI2.WinForms.Guna2TextBox();
            this.btnCreate = new Guna.UI2.WinForms.Guna2Button();
            this.btnFilters = new Guna.UI2.WinForms.Guna2Button();
            this.pnlTableWrap = new System.Windows.Forms.Panel();
            this.dgvInvoices = new System.Windows.Forms.DataGridView();

            this.pnlSidebar.SuspendLayout();
            this.pnlContent.SuspendLayout();
            this.pnlTopBar.SuspendLayout();
            this.pnlMain.SuspendLayout();
            this.pnlToolbar.SuspendLayout();
            this.pnlTableWrap.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picLogo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picAvatar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvInvoices)).BeginInit();
            this.SuspendLayout();

            // ── FORM ──────────────────────────────────────────────────────────────
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(247, 248, 252);
            this.ClientSize = new System.Drawing.Size(1366, 768);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Name = "InvoiceListForm";
            this.Text = "Invoices";
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

            // Nav – Invoices (ACTIVE)
            this.btnNavInvoices.Text = "  Invoices";
            this.btnNavInvoices.Location = new System.Drawing.Point(14, 204);
            this.btnNavInvoices.Size = new System.Drawing.Size(212, 42);
            this.btnNavInvoices.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left;
            this.btnNavInvoices.BorderRadius = 10;
            this.btnNavInvoices.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.btnNavInvoices.FillColor = System.Drawing.Color.FromArgb(181, 212, 34);
            this.btnNavInvoices.ForeColor = System.Drawing.Color.FromArgb(22, 24, 35);
            this.btnNavInvoices.HoverState.FillColor = System.Drawing.Color.FromArgb(165, 196, 20);
            this.btnNavInvoices.HoverState.ForeColor = System.Drawing.Color.FromArgb(22, 24, 35);
            this.btnNavInvoices.Cursor = System.Windows.Forms.Cursors.Hand;

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

            // Nav – Settings
            this.btnNavSettings.Text = "  Settings";
            this.btnNavSettings.Location = new System.Drawing.Point(14, 300);
            this.btnNavSettings.Size = new System.Drawing.Size(212, 42);
            this.btnNavSettings.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left;
            this.btnNavSettings.BorderRadius = 10;
            this.btnNavSettings.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.btnNavSettings.FillColor = System.Drawing.Color.Transparent;
            this.btnNavSettings.ForeColor = System.Drawing.Color.FromArgb(115, 120, 140);
            this.btnNavSettings.HoverState.FillColor = System.Drawing.Color.FromArgb(245, 246, 250);
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
            this.lblPageTitle.Text = "Invoices";

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

            // Window – Minimize
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

            // Window – Maximize
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

            // Window – Close
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
            this.pnlMain.AutoScroll = false;
            this.pnlMain.Padding = new System.Windows.Forms.Padding(28, 16, 28, 16);

            // Toolbar panel
            this.pnlToolbar.BackColor = System.Drawing.Color.Transparent;
            this.pnlToolbar.Location = new System.Drawing.Point(0, 0);
            this.pnlToolbar.Size = new System.Drawing.Size(900, 54);
            this.pnlToolbar.Anchor = System.Windows.Forms.AnchorStyles.Top |
                                        System.Windows.Forms.AnchorStyles.Left |
                                        System.Windows.Forms.AnchorStyles.Right;

            // Search textbox
            this.txtSearch.Location = new System.Drawing.Point(0, 8);
            this.txtSearch.Size = new System.Drawing.Size(280, 38);
            this.txtSearch.BorderRadius = 20;
            this.txtSearch.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.txtSearch.FillColor = System.Drawing.Color.White;
            this.txtSearch.ForeColor = System.Drawing.Color.FromArgb(80, 85, 105);
            this.txtSearch.BorderColor = System.Drawing.Color.FromArgb(220, 223, 232);
            this.txtSearch.FocusedState.BorderColor = System.Drawing.Color.FromArgb(181, 212, 34);
            this.txtSearch.PlaceholderText = "Search invoices";
            this.txtSearch.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left;
            this.txtSearch.TextChanged += new System.EventHandler(this.txtSearch_TextChanged);

            // Create Invoice button
            this.btnCreate.Location = new System.Drawing.Point(660, 8);
            this.btnCreate.Size = new System.Drawing.Size(168, 38);
            this.btnCreate.Text = "  Create Invoice";
            this.btnCreate.BorderRadius = 10;
            this.btnCreate.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.btnCreate.FillColor = System.Drawing.Color.FromArgb(181, 212, 34);
            this.btnCreate.ForeColor = System.Drawing.Color.FromArgb(22, 24, 35);
            this.btnCreate.HoverState.FillColor = System.Drawing.Color.FromArgb(162, 193, 18);
            this.btnCreate.HoverState.ForeColor = System.Drawing.Color.FromArgb(22, 24, 35);
            this.btnCreate.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCreate.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            this.btnCreate.Click += new System.EventHandler(this.btnCreate_Click);

            // Filters button
            this.btnFilters.Location = new System.Drawing.Point(838, 8);
            this.btnFilters.Size = new System.Drawing.Size(100, 38);
            this.btnFilters.Text = "  Filters";
            this.btnFilters.BorderRadius = 10;
            this.btnFilters.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.btnFilters.FillColor = System.Drawing.Color.White;
            this.btnFilters.ForeColor = System.Drawing.Color.FromArgb(55, 58, 75);
            this.btnFilters.BorderColor = System.Drawing.Color.FromArgb(214, 217, 228);
            this.btnFilters.HoverState.FillColor = System.Drawing.Color.FromArgb(243, 244, 248);
            this.btnFilters.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnFilters.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            this.btnFilters.Click += new System.EventHandler(this.btnFilters_Click);

            this.pnlToolbar.Controls.Add(this.txtSearch);
            this.pnlToolbar.Controls.Add(this.btnCreate);
            this.pnlToolbar.Controls.Add(this.btnFilters);

            // Table wrap
            this.pnlTableWrap.BackColor = System.Drawing.Color.White;
            this.pnlTableWrap.Location = new System.Drawing.Point(0, 62);
            this.pnlTableWrap.Size = new System.Drawing.Size(900, 580);
            this.pnlTableWrap.Anchor = System.Windows.Forms.AnchorStyles.Top |
                                          System.Windows.Forms.AnchorStyles.Bottom |
                                          System.Windows.Forms.AnchorStyles.Left |
                                          System.Windows.Forms.AnchorStyles.Right;
            this.pnlTableWrap.Paint += new System.Windows.Forms.PaintEventHandler(this.pnlWhiteCard_Paint);

            // DataGridView
            this.dgvInvoices.BackgroundColor = System.Drawing.Color.White;
            this.dgvInvoices.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvInvoices.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dgvInvoices.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.dgvInvoices.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvInvoices.ColumnHeadersHeight = 44;
            this.dgvInvoices.EnableHeadersVisualStyles = false;
            this.dgvInvoices.RowHeadersVisible = false;
            this.dgvInvoices.AllowUserToAddRows = false;
            this.dgvInvoices.AllowUserToDeleteRows = false;
            this.dgvInvoices.ReadOnly = true;
            this.dgvInvoices.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvInvoices.MultiSelect = false;
            this.dgvInvoices.Location = new System.Drawing.Point(0, 0);
            this.dgvInvoices.Size = new System.Drawing.Size(900, 580);
            this.dgvInvoices.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.dgvInvoices.Anchor = System.Windows.Forms.AnchorStyles.Top |
                                                                            System.Windows.Forms.AnchorStyles.Bottom |
                                                                            System.Windows.Forms.AnchorStyles.Left |
                                                                            System.Windows.Forms.AnchorStyles.Right;
            this.dgvInvoices.ColumnHeadersDefaultCellStyle.BackColor = System.Drawing.Color.White;
            this.dgvInvoices.ColumnHeadersDefaultCellStyle.ForeColor = System.Drawing.Color.FromArgb(148, 153, 172);
            this.dgvInvoices.ColumnHeadersDefaultCellStyle.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Bold);
            this.dgvInvoices.ColumnHeadersDefaultCellStyle.SelectionBackColor = System.Drawing.Color.White;
            this.dgvInvoices.DefaultCellStyle.BackColor = System.Drawing.Color.White;
            this.dgvInvoices.DefaultCellStyle.ForeColor = System.Drawing.Color.FromArgb(35, 38, 55);
            this.dgvInvoices.DefaultCellStyle.SelectionBackColor = System.Drawing.Color.FromArgb(246, 252, 230);
            this.dgvInvoices.DefaultCellStyle.SelectionForeColor = System.Drawing.Color.FromArgb(22, 24, 35);
            this.dgvInvoices.DefaultCellStyle.Padding = new System.Windows.Forms.Padding(12, 0, 0, 0);
            this.dgvInvoices.GridColor = System.Drawing.Color.FromArgb(238, 240, 248);
            this.dgvInvoices.RowTemplate.Height = 68;
            this.dgvInvoices.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.dgvInvoices.Cursor = System.Windows.Forms.Cursors.Hand;

            this.pnlTableWrap.Controls.Add(this.dgvInvoices);
            this.pnlMain.Controls.Add(this.pnlToolbar);
            this.pnlMain.Controls.Add(this.pnlTableWrap);

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
            this.pnlToolbar.ResumeLayout(false);
            this.pnlTableWrap.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.picLogo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picAvatar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvInvoices)).EndInit();
            this.ResumeLayout(false);
        }

        // ── Designer fields ───────────────────────────────────────────────────────
        private Guna.UI2.WinForms.Guna2DragControl guna2Drag;
        private System.Windows.Forms.Panel pnlSidebar, pnlContent, pnlTopBar, pnlMain, pnlToolbar, pnlTableWrap;
        private System.Windows.Forms.PictureBox picLogo, picAvatar;
        private System.Windows.Forms.Label lblAppName, lblPageTitle, lblUsername;
        private Guna.UI2.WinForms.Guna2Button btnNavDashboard, btnNavTransactions, btnNavInvoices, btnNavWallets, btnNavSettings;
        private Guna.UI2.WinForms.Guna2Button btnNavHelp, btnNavLogout;
        private Guna.UI2.WinForms.Guna2Button btnMinimize, btnMaximize, btnClose;
        private Guna.UI2.WinForms.Guna2TextBox txtSearch;
        private Guna.UI2.WinForms.Guna2Button btnCreate, btnFilters;
        private System.Windows.Forms.DataGridView dgvInvoices;
    }
}