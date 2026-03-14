using System.Drawing;
using System.Windows.Forms;

namespace PersonalFinanceManager.Forms.Dashboard 
{
    partial class DashboardForm : Form
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            this.guna2Elipse1 = new Guna.UI2.WinForms.Guna2Elipse(this.components);
            this.guna2ShadowForm1 = new Guna.UI2.WinForms.Guna2ShadowForm(this.components);
            this.guna2DragControl1 = new Guna.UI2.WinForms.Guna2DragControl(this.components);
            this.pnlTopBar = new System.Windows.Forms.Panel();
            this.lblPageTitle = new System.Windows.Forms.Label();
            this.picAvatar = new System.Windows.Forms.PictureBox();
            this.lblUsername = new System.Windows.Forms.Label();
            this.btnMinimize = new Guna.UI2.WinForms.Guna2Button();
            this.btnMaximize = new Guna.UI2.WinForms.Guna2Button();
            this.btnClose = new Guna.UI2.WinForms.Guna2Button();
            this.pnlSidebar = new System.Windows.Forms.Panel();
            this.picSidebarLogo = new System.Windows.Forms.PictureBox();
            this.lblSidebarAppName = new System.Windows.Forms.Label();
            this.btnNavDashboard = new Guna.UI2.WinForms.Guna2Button();
            this.btnNavTransactions = new Guna.UI2.WinForms.Guna2Button();
            this.btnNavInvoices = new Guna.UI2.WinForms.Guna2Button();
            this.btnNavWallets = new Guna.UI2.WinForms.Guna2Button();
            this.btnNavSettings = new Guna.UI2.WinForms.Guna2Button();
            this.btnNavHelp = new Guna.UI2.WinForms.Guna2Button();
            this.btnNavLogout = new Guna.UI2.WinForms.Guna2Button();
            this.pnlMain = new System.Windows.Forms.Panel();
            this.pnlCardBalance = new System.Windows.Forms.Panel();
            this.pnlCardSpending = new System.Windows.Forms.Panel();
            this.pnlCardSaved = new System.Windows.Forms.Panel();
            this.pnlChartArea = new System.Windows.Forms.Panel();
            this.lblChartTitle = new System.Windows.Forms.Label();
            this.pnlChartLegend = new System.Windows.Forms.Panel();
            this.chartWorkingCapital = new LiveCharts.WinForms.CartesianChart();
            this.pnlTransactions = new System.Windows.Forms.Panel();
            this.lblTransTitle = new System.Windows.Forms.Label();
            this.lnkViewAllTrans = new System.Windows.Forms.LinkLabel();
            this.dgvTransactions = new System.Windows.Forms.DataGridView();
            this.pnlRight = new System.Windows.Forms.Panel();
            this.lblWallet = new System.Windows.Forms.Label();
            this.pnlCard1 = new System.Windows.Forms.Panel();
            this.pnlCard2 = new System.Windows.Forms.Panel();
            this.lblScheduledTitle = new System.Windows.Forms.Label();
            this.lnkViewAllTrf = new System.Windows.Forms.LinkLabel();
            this.pnlTransferList = new System.Windows.Forms.Panel();
            this.pnlContent = new System.Windows.Forms.Panel();
            this.pnlTopBar.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picAvatar)).BeginInit();
            this.pnlSidebar.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picSidebarLogo)).BeginInit();
            this.pnlMain.SuspendLayout();
            this.pnlChartArea.SuspendLayout();
            this.pnlTransactions.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTransactions)).BeginInit();
            this.pnlRight.SuspendLayout();
            this.pnlContent.SuspendLayout();
            this.SuspendLayout();
            // 
            // guna2Elipse1
            // 
            this.guna2Elipse1.BorderRadius = 0;
            this.guna2Elipse1.TargetControl = this;
            // 
            // guna2ShadowForm1
            // 
            this.guna2ShadowForm1.TargetForm = this;
            // 
            // guna2DragControl1
            // 
            this.guna2DragControl1.DockIndicatorTransparencyValue = 0.6D;
            this.guna2DragControl1.TargetControl = this.pnlTopBar;
            this.guna2DragControl1.UseTransparentDrag = true;
            // 
            // pnlTopBar
            // 
            this.pnlTopBar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(246)))), ((int)(((byte)(250)))));
            this.pnlTopBar.Controls.Add(this.lblPageTitle);
            this.pnlTopBar.Controls.Add(this.picAvatar);
            this.pnlTopBar.Controls.Add(this.lblUsername);
            this.pnlTopBar.Controls.Add(this.btnMinimize);
            this.pnlTopBar.Controls.Add(this.btnMaximize);
            this.pnlTopBar.Controls.Add(this.btnClose);
            this.pnlTopBar.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlTopBar.Location = new System.Drawing.Point(0, 0);
            this.pnlTopBar.Name = "pnlTopBar";
            this.pnlTopBar.Size = new System.Drawing.Size(853, 79);
            this.pnlTopBar.TabIndex = 1;
            this.pnlTopBar.Paint += new System.Windows.Forms.PaintEventHandler(this.pnlTopBar_Paint);
            // 
            // lblPageTitle
            // 
            this.lblPageTitle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(246)))), ((int)(((byte)(250)))));
            this.lblPageTitle.Font = new System.Drawing.Font("Segoe UI", 20F, System.Drawing.FontStyle.Bold);
            this.lblPageTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(22)))), ((int)(((byte)(22)))));
            this.lblPageTitle.Location = new System.Drawing.Point(23, 9);
            this.lblPageTitle.Name = "lblPageTitle";
            this.lblPageTitle.Size = new System.Drawing.Size(343, 59);
            this.lblPageTitle.TabIndex = 0;
            this.lblPageTitle.Text = "Tổng quan";
            // 
            // picAvatar
            // 
            this.picAvatar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.picAvatar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(246)))), ((int)(((byte)(250)))));
            this.picAvatar.Location = new System.Drawing.Point(624, 0);
            this.picAvatar.Name = "picAvatar";
            this.picAvatar.Size = new System.Drawing.Size(41, 38);
            this.picAvatar.TabIndex = 1;
            this.picAvatar.TabStop = false;
            this.picAvatar.Paint += new System.Windows.Forms.PaintEventHandler(this.picAvatar_Paint);
            // 
            // lblUsername
            // 
            this.lblUsername.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblUsername.AutoSize = true;
            this.lblUsername.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(246)))), ((int)(((byte)(250)))));
            this.lblUsername.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblUsername.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(35)))), ((int)(((byte)(35)))));
            this.lblUsername.Location = new System.Drawing.Point(624, 0);
            this.lblUsername.Name = "lblUsername";
            this.lblUsername.Size = new System.Drawing.Size(108, 23);
            this.lblUsername.TabIndex = 2;
            this.lblUsername.Text = "Người dùng";
            // 
            // btnMinimize
            // 
            this.btnMinimize.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnMinimize.BorderRadius = 8;
            this.btnMinimize.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnMinimize.FillColor = System.Drawing.Color.Transparent;
            this.btnMinimize.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.btnMinimize.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(130)))), ((int)(((byte)(130)))), ((int)(((byte)(130)))));
            this.btnMinimize.HoverState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(210)))), ((int)(((byte)(212)))), ((int)(((byte)(218)))));
            this.btnMinimize.HoverState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.btnMinimize.Location = new System.Drawing.Point(624, 0);
            this.btnMinimize.Name = "btnMinimize";
            this.btnMinimize.Size = new System.Drawing.Size(34, 32);
            this.btnMinimize.TabIndex = 3;
            this.btnMinimize.Text = "─";
            this.btnMinimize.Click += new System.EventHandler(this.btnMinimize_Click);
            // 
            // btnMaximize
            // 
            this.btnMaximize.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnMaximize.BorderRadius = 8;
            this.btnMaximize.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnMaximize.FillColor = System.Drawing.Color.Transparent;
            this.btnMaximize.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnMaximize.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(130)))), ((int)(((byte)(130)))), ((int)(((byte)(130)))));
            this.btnMaximize.HoverState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(210)))), ((int)(((byte)(212)))), ((int)(((byte)(218)))));
            this.btnMaximize.HoverState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.btnMaximize.Location = new System.Drawing.Point(624, 0);
            this.btnMaximize.Name = "btnMaximize";
            this.btnMaximize.Size = new System.Drawing.Size(34, 32);
            this.btnMaximize.TabIndex = 4;
            this.btnMaximize.Text = "□";
            this.btnMaximize.Click += new System.EventHandler(this.btnMaximize_Click);
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.BorderRadius = 8;
            this.btnClose.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnClose.FillColor = System.Drawing.Color.Transparent;
            this.btnClose.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnClose.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(130)))), ((int)(((byte)(130)))), ((int)(((byte)(130)))));
            this.btnClose.HoverState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(75)))), ((int)(((byte)(75)))));
            this.btnClose.HoverState.ForeColor = System.Drawing.Color.White;
            this.btnClose.Location = new System.Drawing.Point(624, 0);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(34, 32);
            this.btnClose.TabIndex = 5;
            this.btnClose.Text = "✕";
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // pnlSidebar
            // 
            this.pnlSidebar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(26)))), ((int)(((byte)(32)))));
            this.pnlSidebar.Controls.Add(this.picSidebarLogo);
            this.pnlSidebar.Controls.Add(this.lblSidebarAppName);
            this.pnlSidebar.Controls.Add(this.btnNavDashboard);
            this.pnlSidebar.Controls.Add(this.btnNavTransactions);
            this.pnlSidebar.Controls.Add(this.btnNavInvoices);
            this.pnlSidebar.Controls.Add(this.btnNavWallets);
            this.pnlSidebar.Controls.Add(this.btnNavSettings);
            this.pnlSidebar.Controls.Add(this.btnNavHelp);
            this.pnlSidebar.Controls.Add(this.btnNavLogout);
            this.pnlSidebar.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlSidebar.Location = new System.Drawing.Point(0, 0);
            this.pnlSidebar.Name = "pnlSidebar";
            this.pnlSidebar.Size = new System.Drawing.Size(297, 819);
            this.pnlSidebar.TabIndex = 2;
            this.pnlSidebar.Paint += new System.Windows.Forms.PaintEventHandler(this.pnlSidebar_Paint);
            // 
            // picSidebarLogo
            // 
            this.picSidebarLogo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(26)))), ((int)(((byte)(32)))));
            this.picSidebarLogo.Location = new System.Drawing.Point(25, 26);
            this.picSidebarLogo.Name = "picSidebarLogo";
            this.picSidebarLogo.Size = new System.Drawing.Size(43, 41);
            this.picSidebarLogo.TabIndex = 0;
            this.picSidebarLogo.TabStop = false;
            this.picSidebarLogo.Paint += new System.Windows.Forms.PaintEventHandler(this.picSidebarLogo_Paint);
            // 
            // lblSidebarAppName
            // 
            this.lblSidebarAppName.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(26)))), ((int)(((byte)(32)))));
            this.lblSidebarAppName.Font = new System.Drawing.Font("Segoe UI", 13F, System.Drawing.FontStyle.Bold);
            this.lblSidebarAppName.ForeColor = System.Drawing.Color.White;
            this.lblSidebarAppName.Location = new System.Drawing.Point(78, 26);
            this.lblSidebarAppName.Name = "lblSidebarAppName";
            this.lblSidebarAppName.Size = new System.Drawing.Size(189, 41);
            this.lblSidebarAppName.TabIndex = 1;
            this.lblSidebarAppName.Text = "FinancialApp";
            // 
            // btnNavDashboard
            // 
            this.btnNavDashboard.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnNavDashboard.BorderRadius = 10;
            this.btnNavDashboard.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnNavDashboard.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(181)))), ((int)(((byte)(212)))), ((int)(((byte)(34)))));
            this.btnNavDashboard.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.btnNavDashboard.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.btnNavDashboard.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(22)))), ((int)(((byte)(22)))));
            this.btnNavDashboard.HoverState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(158)))), ((int)(((byte)(190)))), ((int)(((byte)(20)))));
            this.btnNavDashboard.HoverState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(22)))), ((int)(((byte)(22)))));
            this.btnNavDashboard.Location = new System.Drawing.Point(11, 115);
            this.btnNavDashboard.Name = "btnNavDashboard";
            this.btnNavDashboard.Size = new System.Drawing.Size(274, 45);
            this.btnNavDashboard.TabIndex = 2;
            this.btnNavDashboard.Text = "  🏠  Tổng quan";
            // 
            // btnNavTransactions
            // 
            this.btnNavTransactions.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnNavTransactions.BorderRadius = 10;
            this.btnNavTransactions.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnNavTransactions.FillColor = System.Drawing.Color.Transparent;
            this.btnNavTransactions.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.btnNavTransactions.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.btnNavTransactions.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(155)))), ((int)(((byte)(160)))), ((int)(((byte)(170)))));
            this.btnNavTransactions.HoverState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(38)))), ((int)(((byte)(50)))));
            this.btnNavTransactions.HoverState.ForeColor = System.Drawing.Color.White;
            this.btnNavTransactions.Location = new System.Drawing.Point(11, 165);
            this.btnNavTransactions.Name = "btnNavTransactions";
            this.btnNavTransactions.Size = new System.Drawing.Size(274, 45);
            this.btnNavTransactions.TabIndex = 3;
            this.btnNavTransactions.Text = "  ↔  Giao dịch";
            // 
            // btnNavInvoices
            // 
            this.btnNavInvoices.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnNavInvoices.BorderRadius = 10;
            this.btnNavInvoices.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnNavInvoices.FillColor = System.Drawing.Color.Transparent;
            this.btnNavInvoices.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.btnNavInvoices.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.btnNavInvoices.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(155)))), ((int)(((byte)(160)))), ((int)(((byte)(170)))));
            this.btnNavInvoices.HoverState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(38)))), ((int)(((byte)(50)))));
            this.btnNavInvoices.HoverState.ForeColor = System.Drawing.Color.White;
            this.btnNavInvoices.Location = new System.Drawing.Point(11, 215);
            this.btnNavInvoices.Name = "btnNavInvoices";
            this.btnNavInvoices.Size = new System.Drawing.Size(274, 45);
            this.btnNavInvoices.TabIndex = 4;
            this.btnNavInvoices.Text = "  🗒  Hóa đơn";
            // 
            // btnNavWallets
            // 
            this.btnNavWallets.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnNavWallets.BorderRadius = 10;
            this.btnNavWallets.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnNavWallets.FillColor = System.Drawing.Color.Transparent;
            this.btnNavWallets.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.btnNavWallets.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.btnNavWallets.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(155)))), ((int)(((byte)(160)))), ((int)(((byte)(170)))));
            this.btnNavWallets.HoverState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(38)))), ((int)(((byte)(50)))));
            this.btnNavWallets.HoverState.ForeColor = System.Drawing.Color.White;
            this.btnNavWallets.Location = new System.Drawing.Point(11, 266);
            this.btnNavWallets.Name = "btnNavWallets";
            this.btnNavWallets.Size = new System.Drawing.Size(274, 45);
            this.btnNavWallets.TabIndex = 5;
            this.btnNavWallets.Text = "  💳  Ví của tôi";
            // 
            // btnNavSettings
            // 
            this.btnNavSettings.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnNavSettings.BorderRadius = 10;
            this.btnNavSettings.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnNavSettings.FillColor = System.Drawing.Color.Transparent;
            this.btnNavSettings.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.btnNavSettings.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.btnNavSettings.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(155)))), ((int)(((byte)(160)))), ((int)(((byte)(170)))));
            this.btnNavSettings.HoverState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(38)))), ((int)(((byte)(50)))));
            this.btnNavSettings.HoverState.ForeColor = System.Drawing.Color.White;
            this.btnNavSettings.Location = new System.Drawing.Point(11, 316);
            this.btnNavSettings.Name = "btnNavSettings";
            this.btnNavSettings.Size = new System.Drawing.Size(274, 45);
            this.btnNavSettings.TabIndex = 6;
            this.btnNavSettings.Text = "  ⚙  Cài đặt";
            // 
            // btnNavHelp
            // 
            this.btnNavHelp.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnNavHelp.BorderRadius = 10;
            this.btnNavHelp.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnNavHelp.FillColor = System.Drawing.Color.Transparent;
            this.btnNavHelp.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.btnNavHelp.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.btnNavHelp.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(155)))), ((int)(((byte)(160)))), ((int)(((byte)(170)))));
            this.btnNavHelp.HoverState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(38)))), ((int)(((byte)(50)))));
            this.btnNavHelp.HoverState.ForeColor = System.Drawing.Color.White;
            this.btnNavHelp.Location = new System.Drawing.Point(10, 672);
            this.btnNavHelp.Name = "btnNavHelp";
            this.btnNavHelp.Size = new System.Drawing.Size(274, 45);
            this.btnNavHelp.TabIndex = 7;
            this.btnNavHelp.Text = "  ❓  Trợ giúp";
            // 
            // btnNavLogout
            // 
            this.btnNavLogout.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnNavLogout.BorderRadius = 10;
            this.btnNavLogout.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnNavLogout.FillColor = System.Drawing.Color.Transparent;
            this.btnNavLogout.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.btnNavLogout.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.btnNavLogout.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(80)))), ((int)(((byte)(80)))));
            this.btnNavLogout.HoverState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(80)))), ((int)(((byte)(80)))));
            this.btnNavLogout.HoverState.ForeColor = System.Drawing.Color.White;
            this.btnNavLogout.Location = new System.Drawing.Point(10, 720);
            this.btnNavLogout.Name = "btnNavLogout";
            this.btnNavLogout.Size = new System.Drawing.Size(274, 45);
            this.btnNavLogout.TabIndex = 8;
            this.btnNavLogout.Text = "  ⏻  Đăng xuất";
            this.btnNavLogout.Click += new System.EventHandler(this.btnNavLogout_Click);
            // 
            // pnlMain
            // 
            this.pnlMain.AutoScroll = true;
            this.pnlMain.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(246)))), ((int)(((byte)(250)))));
            this.pnlMain.Controls.Add(this.pnlCardBalance);
            this.pnlMain.Controls.Add(this.pnlCardSpending);
            this.pnlMain.Controls.Add(this.pnlCardSaved);
            this.pnlMain.Controls.Add(this.pnlChartArea);
            this.pnlMain.Controls.Add(this.pnlTransactions);
            this.pnlMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlMain.Location = new System.Drawing.Point(0, 79);
            this.pnlMain.Name = "pnlMain";
            this.pnlMain.Padding = new System.Windows.Forms.Padding(32, 23, 32, 23);
            this.pnlMain.Size = new System.Drawing.Size(853, 740);
            this.pnlMain.TabIndex = 0;
            // 
            // pnlCardBalance
            // 
            this.pnlCardBalance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(246)))), ((int)(((byte)(250)))));
            this.pnlCardBalance.Location = new System.Drawing.Point(0, 0);
            this.pnlCardBalance.Name = "pnlCardBalance";
            this.pnlCardBalance.Size = new System.Drawing.Size(264, 137);
            this.pnlCardBalance.TabIndex = 0;
            this.pnlCardBalance.Paint += new System.Windows.Forms.PaintEventHandler(this.pnlCardBalance_Paint);
            // 
            // pnlCardSpending
            // 
            this.pnlCardSpending.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(246)))), ((int)(((byte)(250)))));
            this.pnlCardSpending.Location = new System.Drawing.Point(270, 0);
            this.pnlCardSpending.Name = "pnlCardSpending";
            this.pnlCardSpending.Size = new System.Drawing.Size(263, 137);
            this.pnlCardSpending.TabIndex = 1;
            this.pnlCardSpending.Paint += new System.Windows.Forms.PaintEventHandler(this.pnlCardSpending_Paint);
            // 
            // pnlCardSaved
            // 
            this.pnlCardSaved.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(246)))), ((int)(((byte)(250)))));
            this.pnlCardSaved.Location = new System.Drawing.Point(539, 0);
            this.pnlCardSaved.Name = "pnlCardSaved";
            this.pnlCardSaved.Size = new System.Drawing.Size(258, 137);
            this.pnlCardSaved.TabIndex = 2;
            this.pnlCardSaved.Paint += new System.Windows.Forms.PaintEventHandler(this.pnlCardSaved_Paint);
            // 
            // pnlChartArea
            // 
            this.pnlChartArea.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlChartArea.BackColor = System.Drawing.Color.White;
            this.pnlChartArea.Controls.Add(this.lblChartTitle);
            this.pnlChartArea.Controls.Add(this.pnlChartLegend);
            this.pnlChartArea.Controls.Add(this.chartWorkingCapital);
            this.pnlChartArea.Location = new System.Drawing.Point(0, 143);
            this.pnlChartArea.Name = "pnlChartArea";
            this.pnlChartArea.Size = new System.Drawing.Size(1571, 309);
            this.pnlChartArea.TabIndex = 3;
            this.pnlChartArea.Paint += new System.Windows.Forms.PaintEventHandler(this.pnlWhiteCard_Paint);
            // 
            // lblChartTitle
            // 
            this.lblChartTitle.BackColor = System.Drawing.Color.White;
            this.lblChartTitle.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lblChartTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(22)))), ((int)(((byte)(22)))));
            this.lblChartTitle.Location = new System.Drawing.Point(23, 17);
            this.lblChartTitle.Name = "lblChartTitle";
            this.lblChartTitle.Size = new System.Drawing.Size(229, 42);
            this.lblChartTitle.TabIndex = 0;
            this.lblChartTitle.Text = "Vốn lưu động";
            // 
            // pnlChartLegend
            // 
            this.pnlChartLegend.BackColor = System.Drawing.Color.White;
            this.pnlChartLegend.Location = new System.Drawing.Point(261, 17);
            this.pnlChartLegend.Name = "pnlChartLegend";
            this.pnlChartLegend.Size = new System.Drawing.Size(240, 28);
            this.pnlChartLegend.TabIndex = 1;
            this.pnlChartLegend.Paint += new System.Windows.Forms.PaintEventHandler(this.pnlChartLegend_Paint);
            // 
            // chartWorkingCapital
            // 
            this.chartWorkingCapital.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.chartWorkingCapital.BackColor = System.Drawing.Color.White;
            this.chartWorkingCapital.Location = new System.Drawing.Point(0, 55);
            this.chartWorkingCapital.Name = "chartWorkingCapital";
            this.chartWorkingCapital.Size = new System.Drawing.Size(1571, 250);
            this.chartWorkingCapital.TabIndex = 2;
            // 
            // pnlTransactions
            // 
            this.pnlTransactions.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlTransactions.BackColor = System.Drawing.Color.White;
            this.pnlTransactions.Controls.Add(this.lblTransTitle);
            this.pnlTransactions.Controls.Add(this.lnkViewAllTrans);
            this.pnlTransactions.Controls.Add(this.dgvTransactions);
            this.pnlTransactions.Location = new System.Drawing.Point(0, 471);
            this.pnlTransactions.Name = "pnlTransactions";
            this.pnlTransactions.Size = new System.Drawing.Size(1571, 320);
            this.pnlTransactions.TabIndex = 4;
            this.pnlTransactions.Paint += new System.Windows.Forms.PaintEventHandler(this.pnlWhiteCard_Paint);
            // 
            // lblTransTitle
            // 
            this.lblTransTitle.BackColor = System.Drawing.Color.White;
            this.lblTransTitle.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lblTransTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(22)))), ((int)(((byte)(22)))));
            this.lblTransTitle.Location = new System.Drawing.Point(23, 17);
            this.lblTransTitle.Name = "lblTransTitle";
            this.lblTransTitle.Size = new System.Drawing.Size(343, 42);
            this.lblTransTitle.TabIndex = 0;
            this.lblTransTitle.Text = "Giao dịch gần đây";
            // 
            // lnkViewAllTrans
            // 
            this.lnkViewAllTrans.ActiveLinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(140)))), ((int)(((byte)(110)))));
            this.lnkViewAllTrans.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lnkViewAllTrans.AutoSize = true;
            this.lnkViewAllTrans.BackColor = System.Drawing.Color.White;
            this.lnkViewAllTrans.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lnkViewAllTrans.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.lnkViewAllTrans.LinkBehavior = System.Windows.Forms.LinkBehavior.NeverUnderline;
            this.lnkViewAllTrans.LinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(180)))), ((int)(((byte)(140)))));
            this.lnkViewAllTrans.Location = new System.Drawing.Point(1457, 19);
            this.lnkViewAllTrans.Name = "lnkViewAllTrans";
            this.lnkViewAllTrans.Size = new System.Drawing.Size(100, 21);
            this.lnkViewAllTrans.TabIndex = 1;
            this.lnkViewAllTrans.TabStop = true;
            this.lnkViewAllTrans.Text = "Xem tất cả ›";
            // 
            // dgvTransactions
            // 
            this.dgvTransactions.AllowUserToAddRows = false;
            this.dgvTransactions.AllowUserToDeleteRows = false;
            this.dgvTransactions.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvTransactions.BackgroundColor = System.Drawing.Color.White;
            this.dgvTransactions.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvTransactions.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dgvTransactions.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle7.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle7.Font = new System.Drawing.Font("Segoe UI", 8.5F, System.Drawing.FontStyle.Bold);
            dataGridViewCellStyle7.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(160)))), ((int)(((byte)(160)))), ((int)(((byte)(160)))));
            dataGridViewCellStyle7.SelectionBackColor = System.Drawing.Color.White;
            dataGridViewCellStyle7.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvTransactions.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle7;
            this.dgvTransactions.ColumnHeadersHeight = 36;
            this.dgvTransactions.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle8.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle8.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            dataGridViewCellStyle8.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            dataGridViewCellStyle8.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            dataGridViewCellStyle8.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(248)))), ((int)(((byte)(230)))));
            dataGridViewCellStyle8.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(22)))), ((int)(((byte)(22)))));
            dataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvTransactions.DefaultCellStyle = dataGridViewCellStyle8;
            this.dgvTransactions.EnableHeadersVisualStyles = false;
            this.dgvTransactions.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.dgvTransactions.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(237)))), ((int)(((byte)(242)))));
            this.dgvTransactions.Location = new System.Drawing.Point(0, 55);
            this.dgvTransactions.Name = "dgvTransactions";
            this.dgvTransactions.ReadOnly = true;
            this.dgvTransactions.RowHeadersVisible = false;
            this.dgvTransactions.RowHeadersWidth = 51;
            this.dgvTransactions.RowTemplate.Height = 54;
            this.dgvTransactions.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.dgvTransactions.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvTransactions.Size = new System.Drawing.Size(1571, 260);
            this.dgvTransactions.TabIndex = 2;
            // 
            // pnlRight
            // 
            this.pnlRight.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(246)))), ((int)(((byte)(250)))));
            this.pnlRight.Controls.Add(this.lblWallet);
            this.pnlRight.Controls.Add(this.pnlCard1);
            this.pnlRight.Controls.Add(this.pnlCard2);
            this.pnlRight.Controls.Add(this.lblScheduledTitle);
            this.pnlRight.Controls.Add(this.lnkViewAllTrf);
            this.pnlRight.Controls.Add(this.pnlTransferList);
            this.pnlRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.pnlRight.Location = new System.Drawing.Point(1150, 0);
            this.pnlRight.Name = "pnlRight";
            this.pnlRight.Padding = new System.Windows.Forms.Padding(16, 23, 16, 21);
            this.pnlRight.Size = new System.Drawing.Size(411, 819);
            this.pnlRight.TabIndex = 1;
            // 
            // lblWallet
            // 
            this.lblWallet.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(246)))), ((int)(((byte)(250)))));
            this.lblWallet.Font = new System.Drawing.Font("Segoe UI", 13F, System.Drawing.FontStyle.Bold);
            this.lblWallet.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(22)))), ((int)(((byte)(22)))));
            this.lblWallet.Location = new System.Drawing.Point(6, 9);
            this.lblWallet.Name = "lblWallet";
            this.lblWallet.Size = new System.Drawing.Size(206, 38);
            this.lblWallet.TabIndex = 0;
            this.lblWallet.Text = "Ví của tôi";
            // 
            // pnlCard1
            // 
            this.pnlCard1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlCard1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(246)))), ((int)(((byte)(250)))));
            this.pnlCard1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pnlCard1.Location = new System.Drawing.Point(0, 46);
            this.pnlCard1.Name = "pnlCard1";
            this.pnlCard1.Size = new System.Drawing.Size(377, 164);
            this.pnlCard1.TabIndex = 1;
            this.pnlCard1.Paint += new System.Windows.Forms.PaintEventHandler(this.pnlCard1_Paint);
            // 
            // pnlCard2
            // 
            this.pnlCard2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlCard2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(246)))), ((int)(((byte)(250)))));
            this.pnlCard2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pnlCard2.Location = new System.Drawing.Point(0, 220);
            this.pnlCard2.Name = "pnlCard2";
            this.pnlCard2.Size = new System.Drawing.Size(377, 160);
            this.pnlCard2.TabIndex = 2;
            this.pnlCard2.Paint += new System.Windows.Forms.PaintEventHandler(this.pnlCard2_Paint);
            // 
            // lblScheduledTitle
            // 
            this.lblScheduledTitle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(246)))), ((int)(((byte)(250)))));
            this.lblScheduledTitle.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lblScheduledTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(22)))), ((int)(((byte)(22)))));
            this.lblScheduledTitle.Location = new System.Drawing.Point(0, 388);
            this.lblScheduledTitle.Name = "lblScheduledTitle";
            this.lblScheduledTitle.Size = new System.Drawing.Size(206, 42);
            this.lblScheduledTitle.TabIndex = 3;
            this.lblScheduledTitle.Text = "Chuyển khoản";
            // 
            // lnkViewAllTrf
            // 
            this.lnkViewAllTrf.ActiveLinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(140)))), ((int)(((byte)(110)))));
            this.lnkViewAllTrf.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lnkViewAllTrf.AutoSize = true;
            this.lnkViewAllTrf.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(246)))), ((int)(((byte)(250)))));
            this.lnkViewAllTrf.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lnkViewAllTrf.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.lnkViewAllTrf.LinkBehavior = System.Windows.Forms.LinkBehavior.NeverUnderline;
            this.lnkViewAllTrf.LinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(180)))), ((int)(((byte)(140)))));
            this.lnkViewAllTrf.Location = new System.Drawing.Point(229, 392);
            this.lnkViewAllTrf.Name = "lnkViewAllTrf";
            this.lnkViewAllTrf.Size = new System.Drawing.Size(100, 21);
            this.lnkViewAllTrf.TabIndex = 4;
            this.lnkViewAllTrf.TabStop = true;
            this.lnkViewAllTrf.Text = "Xem tất cả ›";
            // 
            // pnlTransferList
            // 
            this.pnlTransferList.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlTransferList.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(246)))), ((int)(((byte)(250)))));
            this.pnlTransferList.Location = new System.Drawing.Point(0, 427);
            this.pnlTransferList.Name = "pnlTransferList";
            this.pnlTransferList.Size = new System.Drawing.Size(377, 427);
            this.pnlTransferList.TabIndex = 5;
            this.pnlTransferList.Paint += new System.Windows.Forms.PaintEventHandler(this.pnlTransferList_Paint);
            // 
            // pnlContent
            // 
            this.pnlContent.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(246)))), ((int)(((byte)(250)))));
            this.pnlContent.Controls.Add(this.pnlMain);
            this.pnlContent.Controls.Add(this.pnlTopBar);
            this.pnlContent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlContent.Location = new System.Drawing.Point(297, 0);
            this.pnlContent.Name = "pnlContent";
            this.pnlContent.Size = new System.Drawing.Size(853, 819);
            this.pnlContent.TabIndex = 0;
            // 
            // DashboardForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(246)))), ((int)(((byte)(250)))));
            this.ClientSize = new System.Drawing.Size(1561, 819);
            this.Controls.Add(this.pnlContent);
            this.Controls.Add(this.pnlRight);
            this.Controls.Add(this.pnlSidebar);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "DashboardForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Dashboard";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.pnlTopBar.ResumeLayout(false);
            this.pnlTopBar.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picAvatar)).EndInit();
            this.pnlSidebar.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.picSidebarLogo)).EndInit();
            this.pnlMain.ResumeLayout(false);
            this.pnlChartArea.ResumeLayout(false);
            this.pnlTransactions.ResumeLayout(false);
            this.pnlTransactions.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTransactions)).EndInit();
            this.pnlRight.ResumeLayout(false);
            this.pnlRight.PerformLayout();
            this.pnlContent.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        private Guna.UI2.WinForms.Guna2Elipse guna2Elipse1;
        private Guna.UI2.WinForms.Guna2ShadowForm guna2ShadowForm1;
        private Guna.UI2.WinForms.Guna2DragControl guna2DragControl1;
        private System.Windows.Forms.Panel pnlSidebar;
        private System.Windows.Forms.Panel pnlTopBar;
        private System.Windows.Forms.Panel pnlContent;
        private System.Windows.Forms.Panel pnlMain;
        private System.Windows.Forms.Panel pnlRight;
        private System.Windows.Forms.PictureBox picSidebarLogo;
        private System.Windows.Forms.Label lblSidebarAppName;
        private Guna.UI2.WinForms.Guna2Button btnNavDashboard;
        private Guna.UI2.WinForms.Guna2Button btnNavTransactions;
        private Guna.UI2.WinForms.Guna2Button btnNavInvoices;
        private Guna.UI2.WinForms.Guna2Button btnNavWallets;
        private Guna.UI2.WinForms.Guna2Button btnNavSettings;
        private Guna.UI2.WinForms.Guna2Button btnNavHelp;
        private Guna.UI2.WinForms.Guna2Button btnNavLogout;
        private System.Windows.Forms.Label lblPageTitle;
        private System.Windows.Forms.PictureBox picAvatar;
        private System.Windows.Forms.Label lblUsername;
        private Guna.UI2.WinForms.Guna2Button btnMinimize;
        private Guna.UI2.WinForms.Guna2Button btnMaximize;
        private Guna.UI2.WinForms.Guna2Button btnClose;
        private System.Windows.Forms.Panel pnlCardBalance;
        private System.Windows.Forms.Panel pnlCardSpending;
        private System.Windows.Forms.Panel pnlCardSaved;
        private System.Windows.Forms.Panel pnlChartArea;
        private System.Windows.Forms.Label lblChartTitle;
        private System.Windows.Forms.Panel pnlChartLegend;
        private LiveCharts.WinForms.CartesianChart chartWorkingCapital;
        private System.Windows.Forms.Panel pnlTransactions;
        private System.Windows.Forms.Label lblTransTitle;
        private System.Windows.Forms.LinkLabel lnkViewAllTrans;
        private System.Windows.Forms.DataGridView dgvTransactions;
        private System.Windows.Forms.Label lblWallet;
        private System.Windows.Forms.Panel pnlCard1;
        private System.Windows.Forms.Panel pnlCard2;
        private System.Windows.Forms.Label lblScheduledTitle;
        private System.Windows.Forms.LinkLabel lnkViewAllTrf;
        private System.Windows.Forms.Panel pnlTransferList;
    }
}