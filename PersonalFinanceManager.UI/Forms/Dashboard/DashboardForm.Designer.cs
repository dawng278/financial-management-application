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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            Guna.UI2.AnimatorNS.Animation animation2 = new Guna.UI2.AnimatorNS.Animation();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DashboardForm));
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
            this.pnlTransactions = new System.Windows.Forms.Panel();
            this.lblTransTitle = new System.Windows.Forms.Label();
            this.lnkViewAllTrans = new System.Windows.Forms.LinkLabel();
            this.dgvTransactions = new System.Windows.Forms.DataGridView();
            this.guna2Panel1 = new Guna.UI2.WinForms.Guna2Panel();
            this.pnlChart = new Guna.UI2.WinForms.Guna2Panel();
            this.cartesianTrend = new LiveCharts.WinForms.CartesianChart();
            this.cartesianMonthly = new LiveCharts.WinForms.CartesianChart();
            this.pieChart = new LiveCharts.WinForms.PieChart();
            this.pnlCardBalance = new System.Windows.Forms.Panel();
            this.pnlCardSpending = new System.Windows.Forms.Panel();
            this.pnlCardSaved = new System.Windows.Forms.Panel();
            this.pnlChartArea = new System.Windows.Forms.Panel();
            this.lblChartTitle = new System.Windows.Forms.Label();
            this.pnlChartLegend = new System.Windows.Forms.Panel();
            this.chartWorkingCapital = new LiveCharts.WinForms.CartesianChart();
            this.pnlRight = new System.Windows.Forms.Panel();
            this.lblWallet = new System.Windows.Forms.Label();
            this.pnlCard1 = new System.Windows.Forms.Panel();
            this.pnlCard2 = new System.Windows.Forms.Panel();
            this.lblScheduledTitle = new System.Windows.Forms.Label();
            this.lnkViewAllTrf = new System.Windows.Forms.LinkLabel();
            this.pnlTransferList = new System.Windows.Forms.Panel();
            this.pnlContent = new System.Windows.Forms.Panel();
            this.guna2Transition1 = new Guna.UI2.WinForms.Guna2Transition();
            this.pnlTopBar.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picAvatar)).BeginInit();
            this.pnlSidebar.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picSidebarLogo)).BeginInit();
            this.pnlMain.SuspendLayout();
            this.pnlTransactions.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTransactions)).BeginInit();
            this.guna2Panel1.SuspendLayout();
            this.pnlChart.SuspendLayout();
            this.pnlChartArea.SuspendLayout();
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
            this.guna2Transition1.SetDecoration(this.pnlTopBar, Guna.UI2.AnimatorNS.DecorationType.None);
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
            this.guna2Transition1.SetDecoration(this.lblPageTitle, Guna.UI2.AnimatorNS.DecorationType.None);
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
            this.picAvatar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.guna2Transition1.SetDecoration(this.picAvatar, Guna.UI2.AnimatorNS.DecorationType.None);
            this.picAvatar.Location = new System.Drawing.Point(624, 0);
            this.picAvatar.Name = "picAvatar";
            this.picAvatar.Size = new System.Drawing.Size(41, 38);
            this.picAvatar.TabIndex = 1;
            this.picAvatar.TabStop = false;
            this.picAvatar.Click += new System.EventHandler(this.picAvatar_Click);
            this.picAvatar.Paint += new System.Windows.Forms.PaintEventHandler(this.picAvatar_Paint);
            // 
            // lblUsername
            // 
            this.lblUsername.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblUsername.AutoSize = true;
            this.lblUsername.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(246)))), ((int)(((byte)(250)))));
            this.guna2Transition1.SetDecoration(this.lblUsername, Guna.UI2.AnimatorNS.DecorationType.None);
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
            this.guna2Transition1.SetDecoration(this.btnMinimize, Guna.UI2.AnimatorNS.DecorationType.None);
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
            this.guna2Transition1.SetDecoration(this.btnMaximize, Guna.UI2.AnimatorNS.DecorationType.None);
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
            this.guna2Transition1.SetDecoration(this.btnClose, Guna.UI2.AnimatorNS.DecorationType.None);
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
            this.guna2Transition1.SetDecoration(this.pnlSidebar, Guna.UI2.AnimatorNS.DecorationType.None);
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
            this.guna2Transition1.SetDecoration(this.picSidebarLogo, Guna.UI2.AnimatorNS.DecorationType.None);
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
            this.guna2Transition1.SetDecoration(this.lblSidebarAppName, Guna.UI2.AnimatorNS.DecorationType.None);
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
            this.guna2Transition1.SetDecoration(this.btnNavDashboard, Guna.UI2.AnimatorNS.DecorationType.None);
            this.btnNavDashboard.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(181)))), ((int)(((byte)(212)))), ((int)(((byte)(34)))));
            this.btnNavDashboard.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.btnNavDashboard.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(22)))), ((int)(((byte)(22)))));
            this.btnNavDashboard.HoverState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(158)))), ((int)(((byte)(190)))), ((int)(((byte)(20)))));
            this.btnNavDashboard.HoverState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(22)))), ((int)(((byte)(22)))));
            this.btnNavDashboard.Location = new System.Drawing.Point(11, 115);
            this.btnNavDashboard.Name = "btnNavDashboard";
            this.btnNavDashboard.Size = new System.Drawing.Size(274, 45);
            this.btnNavDashboard.TabIndex = 2;
            this.btnNavDashboard.Text = "  🏠  Tổng quan";
            this.btnNavDashboard.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            // 
            // btnNavTransactions
            // 
            this.btnNavTransactions.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnNavTransactions.BorderRadius = 10;
            this.btnNavTransactions.Cursor = System.Windows.Forms.Cursors.Hand;
            this.guna2Transition1.SetDecoration(this.btnNavTransactions, Guna.UI2.AnimatorNS.DecorationType.None);
            this.btnNavTransactions.FillColor = System.Drawing.Color.Transparent;
            this.btnNavTransactions.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.btnNavTransactions.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(155)))), ((int)(((byte)(160)))), ((int)(((byte)(170)))));
            this.btnNavTransactions.HoverState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(38)))), ((int)(((byte)(50)))));
            this.btnNavTransactions.HoverState.ForeColor = System.Drawing.Color.White;
            this.btnNavTransactions.Location = new System.Drawing.Point(11, 165);
            this.btnNavTransactions.Name = "btnNavTransactions";
            this.btnNavTransactions.Size = new System.Drawing.Size(274, 45);
            this.btnNavTransactions.TabIndex = 3;
            this.btnNavTransactions.Text = "  ↔  Giao dịch";
            this.btnNavTransactions.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            // 
            // btnNavInvoices
            // 
            this.btnNavInvoices.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnNavInvoices.BorderRadius = 10;
            this.btnNavInvoices.Cursor = System.Windows.Forms.Cursors.Hand;
            this.guna2Transition1.SetDecoration(this.btnNavInvoices, Guna.UI2.AnimatorNS.DecorationType.None);
            this.btnNavInvoices.FillColor = System.Drawing.Color.Transparent;
            this.btnNavInvoices.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.btnNavInvoices.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(155)))), ((int)(((byte)(160)))), ((int)(((byte)(170)))));
            this.btnNavInvoices.HoverState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(38)))), ((int)(((byte)(50)))));
            this.btnNavInvoices.HoverState.ForeColor = System.Drawing.Color.White;
            this.btnNavInvoices.Location = new System.Drawing.Point(11, 215);
            this.btnNavInvoices.Name = "btnNavInvoices";
            this.btnNavInvoices.Size = new System.Drawing.Size(274, 45);
            this.btnNavInvoices.TabIndex = 4;
            this.btnNavInvoices.Text = "  🗒  Hóa đơn";
            this.btnNavInvoices.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            // 
            // btnNavWallets
            // 
            this.btnNavWallets.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnNavWallets.BorderRadius = 10;
            this.btnNavWallets.Cursor = System.Windows.Forms.Cursors.Hand;
            this.guna2Transition1.SetDecoration(this.btnNavWallets, Guna.UI2.AnimatorNS.DecorationType.None);
            this.btnNavWallets.FillColor = System.Drawing.Color.Transparent;
            this.btnNavWallets.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.btnNavWallets.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(155)))), ((int)(((byte)(160)))), ((int)(((byte)(170)))));
            this.btnNavWallets.HoverState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(38)))), ((int)(((byte)(50)))));
            this.btnNavWallets.HoverState.ForeColor = System.Drawing.Color.White;
            this.btnNavWallets.Location = new System.Drawing.Point(11, 266);
            this.btnNavWallets.Name = "btnNavWallets";
            this.btnNavWallets.Size = new System.Drawing.Size(274, 45);
            this.btnNavWallets.TabIndex = 5;
            this.btnNavWallets.Text = "  💳  Ví của tôi";
            this.btnNavWallets.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            // 
            // btnNavSettings
            // 
            this.btnNavSettings.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnNavSettings.BorderRadius = 10;
            this.btnNavSettings.Cursor = System.Windows.Forms.Cursors.Hand;
            this.guna2Transition1.SetDecoration(this.btnNavSettings, Guna.UI2.AnimatorNS.DecorationType.None);
            this.btnNavSettings.FillColor = System.Drawing.Color.Transparent;
            this.btnNavSettings.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.btnNavSettings.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(155)))), ((int)(((byte)(160)))), ((int)(((byte)(170)))));
            this.btnNavSettings.HoverState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(38)))), ((int)(((byte)(50)))));
            this.btnNavSettings.HoverState.ForeColor = System.Drawing.Color.White;
            this.btnNavSettings.Location = new System.Drawing.Point(11, 316);
            this.btnNavSettings.Name = "btnNavSettings";
            this.btnNavSettings.Size = new System.Drawing.Size(274, 45);
            this.btnNavSettings.TabIndex = 6;
            this.btnNavSettings.Text = "  ⚙  Cài đặt";
            this.btnNavSettings.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            // 
            // btnNavHelp
            // 
            this.btnNavHelp.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnNavHelp.BorderRadius = 10;
            this.btnNavHelp.Cursor = System.Windows.Forms.Cursors.Hand;
            this.guna2Transition1.SetDecoration(this.btnNavHelp, Guna.UI2.AnimatorNS.DecorationType.None);
            this.btnNavHelp.FillColor = System.Drawing.Color.Transparent;
            this.btnNavHelp.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.btnNavHelp.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(155)))), ((int)(((byte)(160)))), ((int)(((byte)(170)))));
            this.btnNavHelp.HoverState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(38)))), ((int)(((byte)(50)))));
            this.btnNavHelp.HoverState.ForeColor = System.Drawing.Color.White;
            this.btnNavHelp.Location = new System.Drawing.Point(10, 672);
            this.btnNavHelp.Name = "btnNavHelp";
            this.btnNavHelp.Size = new System.Drawing.Size(274, 45);
            this.btnNavHelp.TabIndex = 7;
            this.btnNavHelp.Text = "  ❓  Trợ giúp";
            this.btnNavHelp.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            // 
            // btnNavLogout
            // 
            this.btnNavLogout.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnNavLogout.BorderRadius = 10;
            this.btnNavLogout.Cursor = System.Windows.Forms.Cursors.Hand;
            this.guna2Transition1.SetDecoration(this.btnNavLogout, Guna.UI2.AnimatorNS.DecorationType.None);
            this.btnNavLogout.FillColor = System.Drawing.Color.Transparent;
            this.btnNavLogout.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.btnNavLogout.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(80)))), ((int)(((byte)(80)))));
            this.btnNavLogout.HoverState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(80)))), ((int)(((byte)(80)))));
            this.btnNavLogout.HoverState.ForeColor = System.Drawing.Color.White;
            this.btnNavLogout.Location = new System.Drawing.Point(10, 720);
            this.btnNavLogout.Name = "btnNavLogout";
            this.btnNavLogout.Size = new System.Drawing.Size(274, 45);
            this.btnNavLogout.TabIndex = 8;
            this.btnNavLogout.Text = "  ⏻  Đăng xuất";
            this.btnNavLogout.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.btnNavLogout.Click += new System.EventHandler(this.btnNavLogout_Click);
            // 
            // pnlMain
            // 
            this.pnlMain.AutoScroll = true;
            this.pnlMain.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(246)))), ((int)(((byte)(250)))));
            this.pnlMain.Controls.Add(this.pnlTransactions);
            this.pnlMain.Controls.Add(this.guna2Panel1);
            this.pnlMain.Controls.Add(this.pnlCardBalance);
            this.pnlMain.Controls.Add(this.pnlCardSpending);
            this.pnlMain.Controls.Add(this.pnlCardSaved);
            this.pnlMain.Controls.Add(this.pnlChartArea);
            this.guna2Transition1.SetDecoration(this.pnlMain, Guna.UI2.AnimatorNS.DecorationType.None);
            this.pnlMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlMain.Location = new System.Drawing.Point(0, 79);
            this.pnlMain.Name = "pnlMain";
            this.pnlMain.Padding = new System.Windows.Forms.Padding(32, 23, 32, 23);
            this.pnlMain.Size = new System.Drawing.Size(853, 740);
            this.pnlMain.TabIndex = 0;
            // 
            // pnlTransactions
            // 
            this.pnlTransactions.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlTransactions.BackColor = System.Drawing.Color.White;
            this.pnlTransactions.Controls.Add(this.lblTransTitle);
            this.pnlTransactions.Controls.Add(this.lnkViewAllTrans);
            this.pnlTransactions.Controls.Add(this.dgvTransactions);
            this.guna2Transition1.SetDecoration(this.pnlTransactions, Guna.UI2.AnimatorNS.DecorationType.None);
            this.pnlTransactions.Location = new System.Drawing.Point(0, 471);
            this.pnlTransactions.Name = "pnlTransactions";
            this.pnlTransactions.Size = new System.Drawing.Size(3496, 227);
            this.pnlTransactions.TabIndex = 4;
            this.pnlTransactions.Paint += new System.Windows.Forms.PaintEventHandler(this.pnlWhiteCard_Paint);
            // 
            // lblTransTitle
            // 
            this.lblTransTitle.BackColor = System.Drawing.Color.White;
            this.guna2Transition1.SetDecoration(this.lblTransTitle, Guna.UI2.AnimatorNS.DecorationType.None);
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
            this.guna2Transition1.SetDecoration(this.lnkViewAllTrans, Guna.UI2.AnimatorNS.DecorationType.None);
            this.lnkViewAllTrans.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.lnkViewAllTrans.LinkBehavior = System.Windows.Forms.LinkBehavior.NeverUnderline;
            this.lnkViewAllTrans.LinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(180)))), ((int)(((byte)(140)))));
            this.lnkViewAllTrans.Location = new System.Drawing.Point(3382, 19);
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
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(160)))), ((int)(((byte)(160)))), ((int)(((byte)(160)))));
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvTransactions.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dgvTransactions.ColumnHeadersHeight = 36;
            this.dgvTransactions.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.guna2Transition1.SetDecoration(this.dgvTransactions, Guna.UI2.AnimatorNS.DecorationType.None);
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            dataGridViewCellStyle4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            dataGridViewCellStyle4.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(248)))), ((int)(((byte)(230)))));
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(22)))), ((int)(((byte)(22)))));
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvTransactions.DefaultCellStyle = dataGridViewCellStyle4;
            this.dgvTransactions.EnableHeadersVisualStyles = false;
            this.dgvTransactions.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.dgvTransactions.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(237)))), ((int)(((byte)(242)))));
            this.dgvTransactions.Location = new System.Drawing.Point(0, 62);
            this.dgvTransactions.Name = "dgvTransactions";
            this.dgvTransactions.ReadOnly = true;
            this.dgvTransactions.RowHeadersVisible = false;
            this.dgvTransactions.RowHeadersWidth = 51;
            this.dgvTransactions.RowTemplate.Height = 54;
            this.dgvTransactions.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.dgvTransactions.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvTransactions.Size = new System.Drawing.Size(3496, 141);
            this.dgvTransactions.TabIndex = 2;
            // 
            // guna2Panel1
            // 
            this.guna2Panel1.Controls.Add(this.pnlChart);
            this.guna2Transition1.SetDecoration(this.guna2Panel1, Guna.UI2.AnimatorNS.DecorationType.None);
            this.guna2Panel1.Location = new System.Drawing.Point(0, 728);
            this.guna2Panel1.Name = "guna2Panel1";
            this.guna2Panel1.Size = new System.Drawing.Size(1321, 655);
            this.guna2Panel1.TabIndex = 5;
            // 
            // pnlChart
            // 
            this.pnlChart.BackColor = System.Drawing.Color.White;
            this.pnlChart.Controls.Add(this.cartesianTrend);
            this.pnlChart.Controls.Add(this.cartesianMonthly);
            this.pnlChart.Controls.Add(this.pieChart);
            this.guna2Transition1.SetDecoration(this.pnlChart, Guna.UI2.AnimatorNS.DecorationType.None);
            this.pnlChart.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlChart.Location = new System.Drawing.Point(0, 0);
            this.pnlChart.Name = "pnlChart";
            this.pnlChart.Size = new System.Drawing.Size(1321, 655);
            this.pnlChart.TabIndex = 1;
            // 
            // cartesianTrend
            // 
            this.guna2Transition1.SetDecoration(this.cartesianTrend, Guna.UI2.AnimatorNS.DecorationType.None);
            this.cartesianTrend.Location = new System.Drawing.Point(854, 84);
            this.cartesianTrend.Name = "cartesianTrend";
            this.cartesianTrend.Size = new System.Drawing.Size(432, 228);
            this.cartesianTrend.TabIndex = 2;
            this.cartesianTrend.Text = "cartesianChart1";
            // 
            // cartesianMonthly
            // 
            this.guna2Transition1.SetDecoration(this.cartesianMonthly, Guna.UI2.AnimatorNS.DecorationType.None);
            this.cartesianMonthly.Location = new System.Drawing.Point(465, 84);
            this.cartesianMonthly.Name = "cartesianMonthly";
            this.cartesianMonthly.Size = new System.Drawing.Size(360, 243);
            this.cartesianMonthly.TabIndex = 1;
            this.cartesianMonthly.Text = "cartesianChart1";
            // 
            // pieChart
            // 
            this.guna2Transition1.SetDecoration(this.pieChart, Guna.UI2.AnimatorNS.DecorationType.None);
            this.pieChart.Font = new System.Drawing.Font("Microsoft Sans Serif", 6F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pieChart.Location = new System.Drawing.Point(28, 84);
            this.pieChart.Name = "pieChart";
            this.pieChart.Size = new System.Drawing.Size(414, 257);
            this.pieChart.TabIndex = 0;
            this.pieChart.Text = "pieChart1";
            // 
            // pnlCardBalance
            // 
            this.pnlCardBalance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(246)))), ((int)(((byte)(250)))));
            this.guna2Transition1.SetDecoration(this.pnlCardBalance, Guna.UI2.AnimatorNS.DecorationType.None);
            this.pnlCardBalance.Location = new System.Drawing.Point(0, 0);
            this.pnlCardBalance.Name = "pnlCardBalance";
            this.pnlCardBalance.Size = new System.Drawing.Size(264, 137);
            this.pnlCardBalance.TabIndex = 0;
            this.pnlCardBalance.Paint += new System.Windows.Forms.PaintEventHandler(this.pnlCardBalance_Paint);
            // 
            // pnlCardSpending
            // 
            this.pnlCardSpending.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(246)))), ((int)(((byte)(250)))));
            this.guna2Transition1.SetDecoration(this.pnlCardSpending, Guna.UI2.AnimatorNS.DecorationType.None);
            this.pnlCardSpending.Location = new System.Drawing.Point(270, 0);
            this.pnlCardSpending.Name = "pnlCardSpending";
            this.pnlCardSpending.Size = new System.Drawing.Size(263, 137);
            this.pnlCardSpending.TabIndex = 1;
            this.pnlCardSpending.Paint += new System.Windows.Forms.PaintEventHandler(this.pnlCardSpending_Paint);
            // 
            // pnlCardSaved
            // 
            this.pnlCardSaved.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(246)))), ((int)(((byte)(250)))));
            this.guna2Transition1.SetDecoration(this.pnlCardSaved, Guna.UI2.AnimatorNS.DecorationType.None);
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
            this.guna2Transition1.SetDecoration(this.pnlChartArea, Guna.UI2.AnimatorNS.DecorationType.None);
            this.pnlChartArea.Location = new System.Drawing.Point(0, 143);
            this.pnlChartArea.Name = "pnlChartArea";
            this.pnlChartArea.Size = new System.Drawing.Size(3496, 309);
            this.pnlChartArea.TabIndex = 3;
            this.pnlChartArea.Paint += new System.Windows.Forms.PaintEventHandler(this.pnlWhiteCard_Paint);
            // 
            // lblChartTitle
            // 
            this.lblChartTitle.BackColor = System.Drawing.Color.White;
            this.guna2Transition1.SetDecoration(this.lblChartTitle, Guna.UI2.AnimatorNS.DecorationType.None);
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
            this.guna2Transition1.SetDecoration(this.pnlChartLegend, Guna.UI2.AnimatorNS.DecorationType.None);
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
            this.guna2Transition1.SetDecoration(this.chartWorkingCapital, Guna.UI2.AnimatorNS.DecorationType.None);
            this.chartWorkingCapital.Location = new System.Drawing.Point(0, 55);
            this.chartWorkingCapital.Name = "chartWorkingCapital";
            this.chartWorkingCapital.Size = new System.Drawing.Size(3496, 250);
            this.chartWorkingCapital.TabIndex = 2;
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
            this.guna2Transition1.SetDecoration(this.pnlRight, Guna.UI2.AnimatorNS.DecorationType.None);
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
            this.guna2Transition1.SetDecoration(this.lblWallet, Guna.UI2.AnimatorNS.DecorationType.None);
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
            this.guna2Transition1.SetDecoration(this.pnlCard1, Guna.UI2.AnimatorNS.DecorationType.None);
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
            this.guna2Transition1.SetDecoration(this.pnlCard2, Guna.UI2.AnimatorNS.DecorationType.None);
            this.pnlCard2.Location = new System.Drawing.Point(0, 220);
            this.pnlCard2.Name = "pnlCard2";
            this.pnlCard2.Size = new System.Drawing.Size(377, 160);
            this.pnlCard2.TabIndex = 2;
            this.pnlCard2.Paint += new System.Windows.Forms.PaintEventHandler(this.pnlCard2_Paint);
            // 
            // lblScheduledTitle
            // 
            this.lblScheduledTitle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(246)))), ((int)(((byte)(250)))));
            this.guna2Transition1.SetDecoration(this.lblScheduledTitle, Guna.UI2.AnimatorNS.DecorationType.None);
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
            this.guna2Transition1.SetDecoration(this.lnkViewAllTrf, Guna.UI2.AnimatorNS.DecorationType.None);
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
            this.guna2Transition1.SetDecoration(this.pnlTransferList, Guna.UI2.AnimatorNS.DecorationType.None);
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
            this.guna2Transition1.SetDecoration(this.pnlContent, Guna.UI2.AnimatorNS.DecorationType.None);
            this.pnlContent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlContent.Location = new System.Drawing.Point(297, 0);
            this.pnlContent.Name = "pnlContent";
            this.pnlContent.Size = new System.Drawing.Size(853, 819);
            this.pnlContent.TabIndex = 0;
            // 
            // guna2Transition1
            // 
            this.guna2Transition1.AnimationType = Guna.UI2.AnimatorNS.AnimationType.Scale;
            this.guna2Transition1.Cursor = null;
            animation2.AnimateOnlyDifferences = true;
            animation2.BlindCoeff = ((System.Drawing.PointF)(resources.GetObject("animation2.BlindCoeff")));
            animation2.LeafCoeff = 0F;
            animation2.MaxTime = 1F;
            animation2.MinTime = 0F;
            animation2.MosaicCoeff = ((System.Drawing.PointF)(resources.GetObject("animation2.MosaicCoeff")));
            animation2.MosaicShift = ((System.Drawing.PointF)(resources.GetObject("animation2.MosaicShift")));
            animation2.MosaicSize = 0;
            animation2.Padding = new System.Windows.Forms.Padding(0);
            animation2.RotateCoeff = 0F;
            animation2.RotateLimit = 0F;
            animation2.ScaleCoeff = ((System.Drawing.PointF)(resources.GetObject("animation2.ScaleCoeff")));
            animation2.SlideCoeff = ((System.Drawing.PointF)(resources.GetObject("animation2.SlideCoeff")));
            animation2.TimeCoeff = 0F;
            animation2.TransparencyCoeff = 0F;
            this.guna2Transition1.DefaultAnimation = animation2;
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
            this.guna2Transition1.SetDecoration(this, Guna.UI2.AnimatorNS.DecorationType.None);
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
            this.pnlTransactions.ResumeLayout(false);
            this.pnlTransactions.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTransactions)).EndInit();
            this.guna2Panel1.ResumeLayout(false);
            this.pnlChart.ResumeLayout(false);
            this.pnlChartArea.ResumeLayout(false);
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
        private Guna.UI2.WinForms.Guna2Panel guna2Panel1;
        private Guna.UI2.WinForms.Guna2Panel pnlChart;
        private LiveCharts.WinForms.PieChart pieChart;
        private LiveCharts.WinForms.CartesianChart cartesianMonthly;
        private LiveCharts.WinForms.CartesianChart cartesianTrend;
        private Guna.UI2.WinForms.Guna2Transition guna2Transition1;
    }
}