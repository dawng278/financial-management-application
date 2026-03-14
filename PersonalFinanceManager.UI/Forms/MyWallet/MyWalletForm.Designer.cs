namespace PersonalFinanceManager.Forms.MyWallet
{
    partial class MyWalletForm
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

            // Left panel
            this.pnlLeft = new System.Windows.Forms.Panel();
            this.pnlCardsStack = new System.Windows.Forms.Panel();
            this.pnlCard1 = new System.Windows.Forms.Panel();
            this.pnlCard2 = new System.Windows.Forms.Panel();
            this.pnlBalanceCard = new System.Windows.Forms.Panel();
            this.lblBalanceLbl = new System.Windows.Forms.Label();
            this.lblBalanceVal = new System.Windows.Forms.Label();
            this.lblBalanceUp = new System.Windows.Forms.Label();
            this.lblBalanceDown = new System.Windows.Forms.Label();
            this.lblCurrencyLbl = new System.Windows.Forms.Label();
            this.lblCurrencyVal = new System.Windows.Forms.Label();
            this.lblStatusLbl = new System.Windows.Forms.Label();
            this.lblStatusVal = new System.Windows.Forms.Label();
            this.pnlAddCard = new System.Windows.Forms.Panel();
            this.pnlBalanceDivider = new System.Windows.Forms.Panel();
            this.lnkAddCard = new System.Windows.Forms.LinkLabel();

            // Right panel
            this.pnlRight = new System.Windows.Forms.Panel();
            this.lblPaymentsTitle = new System.Windows.Forms.Label();
            this.pnlTabs = new System.Windows.Forms.Panel();
            this.btnTabAll = new Guna.UI2.WinForms.Guna2Button();
            this.btnTabRegular = new Guna.UI2.WinForms.Guna2Button();
            this.txtSearchPayment = new Guna.UI2.WinForms.Guna2TextBox();
            this.lblSectionToday = new System.Windows.Forms.Label();
            this.pnlPaymentList = new System.Windows.Forms.Panel();
            this.lblSectionUpcoming = new System.Windows.Forms.Label();
            this.lblNextMonth = new System.Windows.Forms.Label();
            this.pnlUpcomingList = new System.Windows.Forms.Panel();

            this.pnlSidebar.SuspendLayout();
            this.pnlContent.SuspendLayout();
            this.pnlTopBar.SuspendLayout();
            this.pnlMain.SuspendLayout();
            this.pnlLeft.SuspendLayout();
            this.pnlRight.SuspendLayout();
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
            this.Name = "MyWalletForm";
            this.Text = "My Wallets";
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

            // Nav – My Wallets (ACTIVE)
            this.btnNavWallets.Text = "  My Wallets";
            this.btnNavWallets.Location = new System.Drawing.Point(14, 252);
            this.btnNavWallets.Size = new System.Drawing.Size(212, 42);
            this.btnNavWallets.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left;
            this.btnNavWallets.BorderRadius = 10;
            this.btnNavWallets.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.btnNavWallets.FillColor = System.Drawing.Color.FromArgb(181, 212, 34);
            this.btnNavWallets.ForeColor = System.Drawing.Color.FromArgb(22, 24, 35);
            this.btnNavWallets.HoverState.FillColor = System.Drawing.Color.FromArgb(165, 196, 20);
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
            this.lblPageTitle.Size = new System.Drawing.Size(300, 40);
            this.lblPageTitle.AutoSize = false;
            this.lblPageTitle.Text = "My Wallets";

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
            this.pnlMain.AutoScroll = false;
            this.pnlMain.Padding = new System.Windows.Forms.Padding(28, 16, 28, 16);

            // ══════════════════════════════════════════════════════════════════════
            // LEFT PANEL  (cards + balance)
            // ══════════════════════════════════════════════════════════════════════
            this.pnlLeft.BackColor = System.Drawing.Color.Transparent;
            this.pnlLeft.Location = new System.Drawing.Point(0, 0);
            this.pnlLeft.Size = new System.Drawing.Size(360, 680);
            this.pnlLeft.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Bottom;

            // ── Cards stack panel (stacked look)  H=310 ───────────────────────────
            this.pnlCardsStack.Location = new System.Drawing.Point(0, 0);
            this.pnlCardsStack.Size = new System.Drawing.Size(350, 320);
            this.pnlCardsStack.BackColor = System.Drawing.Color.Transparent;
            this.pnlCardsStack.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;

            // Card 2 – Commercial Bank (white, slightly offset down, behind)
            this.pnlCard2.Location = new System.Drawing.Point(10, 140);
            this.pnlCard2.Size = new System.Drawing.Size(330, 175);
            this.pnlCard2.BackColor = System.Drawing.Color.Transparent;
            this.pnlCard2.Paint += new System.Windows.Forms.PaintEventHandler(this.pnlCard2_Paint);

            // Card 1 – Universal Bank (dark, on top)
            this.pnlCard1.Location = new System.Drawing.Point(0, 0);
            this.pnlCard1.Size = new System.Drawing.Size(350, 200);
            this.pnlCard1.BackColor = System.Drawing.Color.Transparent;
            this.pnlCard1.Paint += new System.Windows.Forms.PaintEventHandler(this.pnlCard1_Paint);

            // Add card2 first (behind), then card1 (front)
            this.pnlCardsStack.Controls.Add(this.pnlCard2);
            this.pnlCardsStack.Controls.Add(this.pnlCard1);

            // ── Balance info card  H=160  Y=328 ──────────────────────────────────
            this.pnlBalanceCard.Location = new System.Drawing.Point(0, 328);
            this.pnlBalanceCard.Size = new System.Drawing.Size(350, 168);
            this.pnlBalanceCard.BackColor = System.Drawing.Color.Transparent;
            this.pnlBalanceCard.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            this.pnlBalanceCard.Paint += new System.Windows.Forms.PaintEventHandler(this.pnlWhiteCard_Paint);

            // Your Balance
            this.lblBalanceLbl.Font = new System.Drawing.Font("Segoe UI", 8.5F);
            this.lblBalanceLbl.ForeColor = System.Drawing.Color.FromArgb(145, 150, 170);
            this.lblBalanceLbl.Location = new System.Drawing.Point(22, 18);
            this.lblBalanceLbl.AutoSize = true;
            this.lblBalanceLbl.Text = "Your Balance";

            this.lblBalanceVal.Font = new System.Drawing.Font("Segoe UI", 22F, System.Drawing.FontStyle.Bold);
            this.lblBalanceVal.ForeColor = System.Drawing.Color.FromArgb(18, 20, 32);
            this.lblBalanceVal.Location = new System.Drawing.Point(20, 38);
            this.lblBalanceVal.AutoSize = true;
            this.lblBalanceVal.Text = "$5240.00";

            // Up/Down indicators
            this.lblBalanceUp.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblBalanceUp.ForeColor = System.Drawing.Color.FromArgb(34, 168, 95);
            this.lblBalanceUp.Location = new System.Drawing.Point(168, 52);
            this.lblBalanceUp.AutoSize = true;
            this.lblBalanceUp.Text = "↑ 23.65%";

            this.lblBalanceDown.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblBalanceDown.ForeColor = System.Drawing.Color.FromArgb(210, 55, 55);
            this.lblBalanceDown.Location = new System.Drawing.Point(248, 52);
            this.lblBalanceDown.AutoSize = true;
            this.lblBalanceDown.Text = "↓ 10.40%";

            // Divider line between balance and currency/status
            this.pnlBalanceDivider.Location = new System.Drawing.Point(22, 88);
            this.pnlBalanceDivider.Size = new System.Drawing.Size(306, 1);
            this.pnlBalanceDivider.BackColor = System.Drawing.Color.FromArgb(230, 232, 242);

            // Currency
            this.lblCurrencyLbl.Font = new System.Drawing.Font("Segoe UI", 8.5F);
            this.lblCurrencyLbl.ForeColor = System.Drawing.Color.FromArgb(145, 150, 170);
            this.lblCurrencyLbl.Location = new System.Drawing.Point(22, 100);
            this.lblCurrencyLbl.AutoSize = true;
            this.lblCurrencyLbl.Text = "Currency";

            this.lblCurrencyVal.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.lblCurrencyVal.ForeColor = System.Drawing.Color.FromArgb(22, 25, 40);
            this.lblCurrencyVal.Location = new System.Drawing.Point(22, 118);
            this.lblCurrencyVal.AutoSize = true;
            this.lblCurrencyVal.Text = "USD / US Dollar";

            // Status
            this.lblStatusLbl.Font = new System.Drawing.Font("Segoe UI", 8.5F);
            this.lblStatusLbl.ForeColor = System.Drawing.Color.FromArgb(145, 150, 170);
            this.lblStatusLbl.Location = new System.Drawing.Point(190, 100);
            this.lblStatusLbl.AutoSize = true;
            this.lblStatusLbl.Text = "Status";

            this.lblStatusVal.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.lblStatusVal.ForeColor = System.Drawing.Color.FromArgb(22, 25, 40);
            this.lblStatusVal.Location = new System.Drawing.Point(190, 118);
            this.lblStatusVal.AutoSize = true;
            this.lblStatusVal.Text = "Active";

            this.pnlBalanceCard.Controls.Add(this.lblBalanceLbl);
            this.pnlBalanceCard.Controls.Add(this.lblBalanceVal);
            this.pnlBalanceCard.Controls.Add(this.lblBalanceUp);
            this.pnlBalanceCard.Controls.Add(this.lblBalanceDown);
            this.pnlBalanceCard.Controls.Add(this.pnlBalanceDivider);
            this.pnlBalanceCard.Controls.Add(this.lblCurrencyLbl);
            this.pnlBalanceCard.Controls.Add(this.lblCurrencyVal);
            this.pnlBalanceCard.Controls.Add(this.lblStatusLbl);
            this.pnlBalanceCard.Controls.Add(this.lblStatusVal);

            // ── Add New Card button  Y=510 ────────────────────────────────────────
            this.pnlAddCard.Location = new System.Drawing.Point(0, 510);
            this.pnlAddCard.Size = new System.Drawing.Size(350, 56);
            this.pnlAddCard.BackColor = System.Drawing.Color.Transparent;
            this.pnlAddCard.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            this.pnlAddCard.Paint += new System.Windows.Forms.PaintEventHandler(this.pnlWhiteCard_Paint);

            this.lnkAddCard.AutoSize = true;
            this.lnkAddCard.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lnkAddCard.LinkColor = System.Drawing.Color.FromArgb(45, 165, 90);
            this.lnkAddCard.ActiveLinkColor = System.Drawing.Color.FromArgb(30, 130, 65);
            this.lnkAddCard.LinkBehavior = System.Windows.Forms.LinkBehavior.NeverUnderline;
            this.lnkAddCard.Location = new System.Drawing.Point(118, 18);
            this.lnkAddCard.Text = "+  Add New Card";
            this.lnkAddCard.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lnkAddCard.Click += new System.EventHandler(this.lnkAddCard_Click);

            this.pnlAddCard.Controls.Add(this.lnkAddCard);

            this.pnlLeft.Controls.Add(this.pnlCardsStack);
            this.pnlLeft.Controls.Add(this.pnlBalanceCard);
            this.pnlLeft.Controls.Add(this.pnlAddCard);

            // ══════════════════════════════════════════════════════════════════════
            // RIGHT PANEL  (payments)
            // ══════════════════════════════════════════════════════════════════════
            this.pnlRight.BackColor = System.Drawing.Color.Transparent;
            this.pnlRight.Location = new System.Drawing.Point(390, 0);
            this.pnlRight.Size = new System.Drawing.Size(680, 680);
            this.pnlRight.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right | System.Windows.Forms.AnchorStyles.Bottom;

            // Title "My Payments"
            this.lblPaymentsTitle.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold);
            this.lblPaymentsTitle.ForeColor = System.Drawing.Color.FromArgb(18, 20, 32);
            this.lblPaymentsTitle.Location = new System.Drawing.Point(0, 0);
            this.lblPaymentsTitle.AutoSize = true;
            this.lblPaymentsTitle.Text = "My Payments";

            // Tabs panel  H=40  Y=36
            this.pnlTabs.Location = new System.Drawing.Point(0, 36);
            this.pnlTabs.Size = new System.Drawing.Size(680, 42);
            this.pnlTabs.BackColor = System.Drawing.Color.Transparent;
            this.pnlTabs.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            this.pnlTabs.Paint += new System.Windows.Forms.PaintEventHandler(this.pnlTabs_Paint);

            // Tab – All Payments (active)
            this.btnTabAll.Text = "All Payments";
            this.btnTabAll.Location = new System.Drawing.Point(0, 6);
            this.btnTabAll.Size = new System.Drawing.Size(120, 30);
            this.btnTabAll.BorderRadius = 0;
            this.btnTabAll.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.btnTabAll.FillColor = System.Drawing.Color.Transparent;
            this.btnTabAll.ForeColor = System.Drawing.Color.FromArgb(22, 24, 35);
            this.btnTabAll.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnTabAll.Click += new System.EventHandler(this.btnTabAll_Click);

            // Tab – Regular Payments
            this.btnTabRegular.Text = "Regular Payments";
            this.btnTabRegular.Location = new System.Drawing.Point(128, 6);
            this.btnTabRegular.Size = new System.Drawing.Size(140, 30);
            this.btnTabRegular.BorderRadius = 0;
            this.btnTabRegular.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.btnTabRegular.FillColor = System.Drawing.Color.Transparent;
            this.btnTabRegular.ForeColor = System.Drawing.Color.FromArgb(148, 153, 172);
            this.btnTabRegular.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnTabRegular.Click += new System.EventHandler(this.btnTabRegular_Click);

            // Search box (right-aligned in tabs row)
            this.txtSearchPayment.Location = new System.Drawing.Point(480, 4);
            this.txtSearchPayment.Size = new System.Drawing.Size(196, 34);
            this.txtSearchPayment.BorderRadius = 18;
            this.txtSearchPayment.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtSearchPayment.FillColor = System.Drawing.Color.White;
            this.txtSearchPayment.ForeColor = System.Drawing.Color.FromArgb(148, 153, 172);
            this.txtSearchPayment.BorderColor = System.Drawing.Color.FromArgb(220, 223, 235);
            this.txtSearchPayment.FocusedState.BorderColor = System.Drawing.Color.FromArgb(181, 212, 34);
            this.txtSearchPayment.PlaceholderText = "Search";
            this.txtSearchPayment.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            this.txtSearchPayment.TextChanged += new System.EventHandler(this.txtSearchPayment_TextChanged);

            this.pnlTabs.Controls.Add(this.btnTabAll);
            this.pnlTabs.Controls.Add(this.btnTabRegular);
            this.pnlTabs.Controls.Add(this.txtSearchPayment);

            // "Today" section label  Y=92
            this.lblSectionToday.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblSectionToday.ForeColor = System.Drawing.Color.FromArgb(145, 150, 170);
            this.lblSectionToday.Location = new System.Drawing.Point(0, 92);
            this.lblSectionToday.AutoSize = true;
            this.lblSectionToday.Text = "Today";

            // Payment list panel (today)  Y=116
            this.pnlPaymentList.Location = new System.Drawing.Point(0, 114);
            this.pnlPaymentList.Size = new System.Drawing.Size(680, 280);
            this.pnlPaymentList.BackColor = System.Drawing.Color.Transparent;
            this.pnlPaymentList.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;

            // "Upcoming Payments" label  Y=408
            this.lblSectionUpcoming.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold);
            this.lblSectionUpcoming.ForeColor = System.Drawing.Color.FromArgb(18, 20, 32);
            this.lblSectionUpcoming.Location = new System.Drawing.Point(0, 406);
            this.lblSectionUpcoming.AutoSize = true;
            this.lblSectionUpcoming.Text = "Upcoming Payments";

            // "Next month" label  Y=436
            this.lblNextMonth.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblNextMonth.ForeColor = System.Drawing.Color.FromArgb(145, 150, 170);
            this.lblNextMonth.Location = new System.Drawing.Point(0, 436);
            this.lblNextMonth.AutoSize = true;
            this.lblNextMonth.Text = "Next month";

            // Upcoming list panel  Y=460
            this.pnlUpcomingList.Location = new System.Drawing.Point(0, 458);
            this.pnlUpcomingList.Size = new System.Drawing.Size(680, 180);
            this.pnlUpcomingList.BackColor = System.Drawing.Color.Transparent;
            this.pnlUpcomingList.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;

            this.pnlRight.Controls.Add(this.lblPaymentsTitle);
            this.pnlRight.Controls.Add(this.pnlTabs);
            this.pnlRight.Controls.Add(this.lblSectionToday);
            this.pnlRight.Controls.Add(this.pnlPaymentList);
            this.pnlRight.Controls.Add(this.lblSectionUpcoming);
            this.pnlRight.Controls.Add(this.lblNextMonth);
            this.pnlRight.Controls.Add(this.pnlUpcomingList);

            this.pnlMain.Controls.Add(this.pnlLeft);
            this.pnlMain.Controls.Add(this.pnlRight);

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
            this.pnlLeft.ResumeLayout(false);
            this.pnlRight.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.picLogo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picAvatar)).EndInit();
            this.ResumeLayout(false);
        }

        // ── Designer fields ───────────────────────────────────────────────────────
        private Guna.UI2.WinForms.Guna2DragControl guna2Drag;
        private System.Windows.Forms.Panel pnlSidebar, pnlContent, pnlTopBar, pnlMain;
        private System.Windows.Forms.Panel pnlLeft, pnlCardsStack, pnlCard1, pnlCard2;
        private System.Windows.Forms.Panel pnlBalanceCard, pnlAddCard, pnlBalanceDivider;
        private System.Windows.Forms.Panel pnlRight, pnlTabs, pnlPaymentList, pnlUpcomingList;
        private System.Windows.Forms.PictureBox picLogo, picAvatar;
        private System.Windows.Forms.Label lblAppName, lblPageTitle, lblUsername;
        private System.Windows.Forms.Label lblBalanceLbl, lblBalanceVal, lblBalanceUp, lblBalanceDown;
        private System.Windows.Forms.Label lblCurrencyLbl, lblCurrencyVal, lblStatusLbl, lblStatusVal;
        private System.Windows.Forms.Label lblPaymentsTitle, lblSectionToday, lblSectionUpcoming, lblNextMonth;
        private System.Windows.Forms.LinkLabel lnkAddCard;
        private Guna.UI2.WinForms.Guna2Button btnNavDashboard, btnNavTransactions, btnNavInvoices, btnNavWallets, btnNavSettings;
        private Guna.UI2.WinForms.Guna2Button btnNavHelp, btnNavLogout;
        private Guna.UI2.WinForms.Guna2Button btnMinimize, btnMaximize, btnClose;
        private Guna.UI2.WinForms.Guna2Button btnTabAll, btnTabRegular;
        private Guna.UI2.WinForms.Guna2TextBox txtSearchPayment;
    }
}