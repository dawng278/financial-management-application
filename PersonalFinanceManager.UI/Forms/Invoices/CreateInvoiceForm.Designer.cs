namespace PersonalFinanceManager.Forms.Invoices
{
    partial class CreateInvoiceForm
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            this.guna2Drag = new Guna.UI2.WinForms.Guna2DragControl(this.components);
            this.pnlTopBar = new System.Windows.Forms.Panel();
            this.lblPageTitle = new System.Windows.Forms.Label();
            this.picAvatar = new System.Windows.Forms.PictureBox();
            this.lblUsername = new System.Windows.Forms.Label();
            this.btnMinimize = new Guna.UI2.WinForms.Guna2Button();
            this.btnMaximize = new Guna.UI2.WinForms.Guna2Button();
            this.btnClose = new Guna.UI2.WinForms.Guna2Button();
            this.pnlSidebar = new System.Windows.Forms.Panel();
            this.picLogo = new System.Windows.Forms.PictureBox();
            this.lblAppName = new System.Windows.Forms.Label();
            this.btnNavDashboard = new Guna.UI2.WinForms.Guna2Button();
            this.btnNavTransactions = new Guna.UI2.WinForms.Guna2Button();
            this.btnNavInvoices = new Guna.UI2.WinForms.Guna2Button();
            this.btnNavWallets = new Guna.UI2.WinForms.Guna2Button();
            this.btnNavSettings = new Guna.UI2.WinForms.Guna2Button();
            this.btnNavHelp = new Guna.UI2.WinForms.Guna2Button();
            this.btnNavLogout = new Guna.UI2.WinForms.Guna2Button();
            this.pnlContent = new System.Windows.Forms.Panel();
            this.pnlMain = new System.Windows.Forms.Panel();
            this.pnlLeft = new System.Windows.Forms.Panel();
            this.pnlHeader = new System.Windows.Forms.Panel();
            this.lblCoName = new System.Windows.Forms.Label();
            this.lblCoEmail = new System.Windows.Forms.Label();
            this.lblCoAddr = new System.Windows.Forms.Label();
            this.pnlInvInfo = new System.Windows.Forms.Panel();
            this.lblInvNumLbl = new System.Windows.Forms.Label();
            this.txtInvNum = new Guna.UI2.WinForms.Guna2TextBox();
            this.lblIssuedLbl = new System.Windows.Forms.Label();
            this.dtpIssued = new Guna.UI2.WinForms.Guna2DateTimePicker();
            this.lblDueLbl = new System.Windows.Forms.Label();
            this.dtpDue = new Guna.UI2.WinForms.Guna2DateTimePicker();
            this.lblBilledLbl = new System.Windows.Forms.Label();
            this.txtBilledName = new Guna.UI2.WinForms.Guna2TextBox();
            this.txtBilledAddr1 = new Guna.UI2.WinForms.Guna2TextBox();
            this.txtBilledAddr2 = new Guna.UI2.WinForms.Guna2TextBox();
            this.pnlItems = new System.Windows.Forms.Panel();
            this.lblItemsTitle = new System.Windows.Forms.Label();
            this.lblItemsSub = new System.Windows.Forms.Label();
            this.dgvItems = new System.Windows.Forms.DataGridView();
            this.lnkAddItem = new System.Windows.Forms.LinkLabel();
            this.pnlTotals = new System.Windows.Forms.Panel();
            this.pnlRight = new System.Windows.Forms.Panel();
            this.pnlClientCard = new System.Windows.Forms.Panel();
            this.lblClientTitle = new System.Windows.Forms.Label();
            this.lblClientNameLbl = new System.Windows.Forms.Label();
            this.txtClientName = new Guna.UI2.WinForms.Guna2TextBox();
            this.lblClientEmailLbl = new System.Windows.Forms.Label();
            this.txtClientEmail = new Guna.UI2.WinForms.Guna2TextBox();
            this.lblClientCompanyLbl = new System.Windows.Forms.Label();
            this.txtClientCompany = new Guna.UI2.WinForms.Guna2TextBox();
            this.lblClientAddrLbl = new System.Windows.Forms.Label();
            this.txtClientAddr = new Guna.UI2.WinForms.Guna2TextBox();
            this.btnAddCustomer = new Guna.UI2.WinForms.Guna2Button();
            this.pnlBasicInfo = new System.Windows.Forms.Panel();
            this.lblBasicTitle = new System.Windows.Forms.Label();
            this.lblInvDateLbl = new System.Windows.Forms.Label();
            this.dtpInvoiceDate = new Guna.UI2.WinForms.Guna2DateTimePicker();
            this.lblDueDateLbl = new System.Windows.Forms.Label();
            this.dtpDueDate = new Guna.UI2.WinForms.Guna2DateTimePicker();
            this.btnSend = new Guna.UI2.WinForms.Guna2Button();
            this.btnPreview = new Guna.UI2.WinForms.Guna2Button();
            this.btnDownload = new Guna.UI2.WinForms.Guna2Button();
            this.pnlTopBar.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picAvatar)).BeginInit();
            this.pnlSidebar.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picLogo)).BeginInit();
            this.pnlContent.SuspendLayout();
            this.pnlMain.SuspendLayout();
            this.pnlLeft.SuspendLayout();
            this.pnlHeader.SuspendLayout();
            this.pnlInvInfo.SuspendLayout();
            this.pnlItems.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvItems)).BeginInit();
            this.pnlRight.SuspendLayout();
            this.pnlClientCard.SuspendLayout();
            this.pnlBasicInfo.SuspendLayout();
            this.SuspendLayout();
            // 
            // guna2Drag
            // 
            this.guna2Drag.DockIndicatorTransparencyValue = 0.6D;
            this.guna2Drag.TargetControl = this.pnlTopBar;
            this.guna2Drag.UseTransparentDrag = true;
            // 
            // pnlTopBar
            // 
            this.pnlTopBar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(248)))), ((int)(((byte)(252)))));
            this.pnlTopBar.Controls.Add(this.lblPageTitle);
            this.pnlTopBar.Controls.Add(this.picAvatar);
            this.pnlTopBar.Controls.Add(this.lblUsername);
            this.pnlTopBar.Controls.Add(this.btnMinimize);
            this.pnlTopBar.Controls.Add(this.btnMaximize);
            this.pnlTopBar.Controls.Add(this.btnClose);
            this.pnlTopBar.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlTopBar.Location = new System.Drawing.Point(0, 0);
            this.pnlTopBar.Name = "pnlTopBar";
            this.pnlTopBar.Size = new System.Drawing.Size(1378, 76);
            this.pnlTopBar.TabIndex = 1;
            this.pnlTopBar.Paint += new System.Windows.Forms.PaintEventHandler(this.pnlTopBar_Paint);
            // 
            // lblPageTitle
            // 
            this.lblPageTitle.Font = new System.Drawing.Font("Segoe UI", 17F, System.Drawing.FontStyle.Bold);
            this.lblPageTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(18)))), ((int)(((byte)(20)))), ((int)(((byte)(28)))));
            this.lblPageTitle.Location = new System.Drawing.Point(20, 18);
            this.lblPageTitle.Name = "lblPageTitle";
            this.lblPageTitle.Size = new System.Drawing.Size(571, 48);
            this.lblPageTitle.TabIndex = 0;
            this.lblPageTitle.Text = "New Invoice";
            // 
            // picAvatar
            // 
            this.picAvatar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.picAvatar.BackColor = System.Drawing.Color.Transparent;
            this.picAvatar.Location = new System.Drawing.Point(1160, 13);
            this.picAvatar.Name = "picAvatar";
            this.picAvatar.Size = new System.Drawing.Size(39, 36);
            this.picAvatar.TabIndex = 1;
            this.picAvatar.TabStop = false;
            this.picAvatar.Paint += new System.Windows.Forms.PaintEventHandler(this.picAvatar_Paint);
            // 
            // lblUsername
            // 
            this.lblUsername.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblUsername.AutoSize = true;
            this.lblUsername.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblUsername.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(28)))), ((int)(((byte)(42)))));
            this.lblUsername.Location = new System.Drawing.Point(1160, 20);
            this.lblUsername.Name = "lblUsername";
            this.lblUsername.Size = new System.Drawing.Size(56, 20);
            this.lblUsername.TabIndex = 2;
            this.lblUsername.Text = "Admin";
            // 
            // btnMinimize
            // 
            this.btnMinimize.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnMinimize.BorderRadius = 7;
            this.btnMinimize.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnMinimize.FillColor = System.Drawing.Color.Transparent;
            this.btnMinimize.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.btnMinimize.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(120)))), ((int)(((byte)(125)))), ((int)(((byte)(142)))));
            this.btnMinimize.HoverState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(234)))), ((int)(((byte)(240)))));
            this.btnMinimize.Location = new System.Drawing.Point(1160, 15);
            this.btnMinimize.Name = "btnMinimize";
            this.btnMinimize.Size = new System.Drawing.Size(34, 32);
            this.btnMinimize.TabIndex = 3;
            this.btnMinimize.Text = "-";
            this.btnMinimize.Click += new System.EventHandler(this.btnMinimize_Click);
            // 
            // btnMaximize
            // 
            this.btnMaximize.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnMaximize.BorderRadius = 7;
            this.btnMaximize.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnMaximize.FillColor = System.Drawing.Color.Transparent;
            this.btnMaximize.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnMaximize.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(120)))), ((int)(((byte)(125)))), ((int)(((byte)(142)))));
            this.btnMaximize.HoverState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(234)))), ((int)(((byte)(240)))));
            this.btnMaximize.Location = new System.Drawing.Point(1160, 15);
            this.btnMaximize.Name = "btnMaximize";
            this.btnMaximize.Size = new System.Drawing.Size(34, 32);
            this.btnMaximize.TabIndex = 4;
            this.btnMaximize.Text = "[]";
            this.btnMaximize.Click += new System.EventHandler(this.btnMaximize_Click);
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.BorderRadius = 7;
            this.btnClose.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnClose.FillColor = System.Drawing.Color.Transparent;
            this.btnClose.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnClose.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(120)))), ((int)(((byte)(125)))), ((int)(((byte)(142)))));
            this.btnClose.HoverState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
            this.btnClose.HoverState.ForeColor = System.Drawing.Color.White;
            this.btnClose.Location = new System.Drawing.Point(1160, 15);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(34, 32);
            this.btnClose.TabIndex = 5;
            this.btnClose.Text = "X";
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // pnlSidebar
            // 
            this.pnlSidebar.BackColor = System.Drawing.Color.White;
            this.pnlSidebar.Controls.Add(this.picLogo);
            this.pnlSidebar.Controls.Add(this.lblAppName);
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
            this.pnlSidebar.Size = new System.Drawing.Size(183, 819);
            this.pnlSidebar.TabIndex = 1;
            this.pnlSidebar.Paint += new System.Windows.Forms.PaintEventHandler(this.pnlSidebar_Paint);
            // 
            // picLogo
            // 
            this.picLogo.BackColor = System.Drawing.Color.Transparent;
            this.picLogo.Location = new System.Drawing.Point(16, 19);
            this.picLogo.Name = "picLogo";
            this.picLogo.Size = new System.Drawing.Size(43, 41);
            this.picLogo.TabIndex = 0;
            this.picLogo.TabStop = false;
            this.picLogo.Paint += new System.Windows.Forms.PaintEventHandler(this.picLogo_Paint);
            // 
            // lblAppName
            // 
            this.lblAppName.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lblAppName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(18)))), ((int)(((byte)(20)))), ((int)(((byte)(28)))));
            this.lblAppName.Location = new System.Drawing.Point(66, 26);
            this.lblAppName.Name = "lblAppName";
            this.lblAppName.Size = new System.Drawing.Size(103, 26);
            this.lblAppName.TabIndex = 1;
            this.lblAppName.Text = "Maglo.";
            // 
            // btnNavDashboard
            // 
            this.btnNavDashboard.BorderRadius = 9;
            this.btnNavDashboard.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnNavDashboard.FillColor = System.Drawing.Color.Transparent;
            this.btnNavDashboard.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnNavDashboard.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(115)))), ((int)(((byte)(120)))), ((int)(((byte)(140)))));
            this.btnNavDashboard.HoverState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(246)))), ((int)(((byte)(250)))));
            this.btnNavDashboard.HoverState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(24)))), ((int)(((byte)(35)))));
            this.btnNavDashboard.Location = new System.Drawing.Point(9, 102);
            this.btnNavDashboard.Name = "btnNavDashboard";
            this.btnNavDashboard.Size = new System.Drawing.Size(165, 41);
            this.btnNavDashboard.TabIndex = 2;
            this.btnNavDashboard.Text = "  Dashboard";
            this.btnNavDashboard.Click += new System.EventHandler(this.btnNavDashboard_Click);
            // 
            // btnNavTransactions
            // 
            this.btnNavTransactions.BorderRadius = 9;
            this.btnNavTransactions.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnNavTransactions.FillColor = System.Drawing.Color.Transparent;
            this.btnNavTransactions.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnNavTransactions.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(115)))), ((int)(((byte)(120)))), ((int)(((byte)(140)))));
            this.btnNavTransactions.HoverState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(246)))), ((int)(((byte)(250)))));
            this.btnNavTransactions.HoverState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(24)))), ((int)(((byte)(35)))));
            this.btnNavTransactions.Location = new System.Drawing.Point(9, 149);
            this.btnNavTransactions.Name = "btnNavTransactions";
            this.btnNavTransactions.Size = new System.Drawing.Size(165, 41);
            this.btnNavTransactions.TabIndex = 3;
            this.btnNavTransactions.Text = "  Transactions";
            this.btnNavTransactions.Click += new System.EventHandler(this.btnNavTransactions_Click);
            // 
            // btnNavInvoices
            // 
            this.btnNavInvoices.BorderRadius = 9;
            this.btnNavInvoices.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnNavInvoices.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(181)))), ((int)(((byte)(212)))), ((int)(((byte)(34)))));
            this.btnNavInvoices.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnNavInvoices.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(24)))), ((int)(((byte)(35)))));
            this.btnNavInvoices.HoverState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(165)))), ((int)(((byte)(196)))), ((int)(((byte)(20)))));
            this.btnNavInvoices.HoverState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(24)))), ((int)(((byte)(35)))));
            this.btnNavInvoices.Location = new System.Drawing.Point(9, 196);
            this.btnNavInvoices.Name = "btnNavInvoices";
            this.btnNavInvoices.Size = new System.Drawing.Size(165, 41);
            this.btnNavInvoices.TabIndex = 4;
            this.btnNavInvoices.Text = "  Invoices";
            this.btnNavInvoices.Click += new System.EventHandler(this.btnNavInvoices_Click);
            // 
            // btnNavWallets
            // 
            this.btnNavWallets.BorderRadius = 9;
            this.btnNavWallets.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnNavWallets.FillColor = System.Drawing.Color.Transparent;
            this.btnNavWallets.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnNavWallets.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(115)))), ((int)(((byte)(120)))), ((int)(((byte)(140)))));
            this.btnNavWallets.HoverState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(246)))), ((int)(((byte)(250)))));
            this.btnNavWallets.HoverState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(24)))), ((int)(((byte)(35)))));
            this.btnNavWallets.Location = new System.Drawing.Point(9, 243);
            this.btnNavWallets.Name = "btnNavWallets";
            this.btnNavWallets.Size = new System.Drawing.Size(165, 41);
            this.btnNavWallets.TabIndex = 5;
            this.btnNavWallets.Text = "  My Wallets";
            // 
            // btnNavSettings
            // 
            this.btnNavSettings.BorderRadius = 9;
            this.btnNavSettings.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnNavSettings.FillColor = System.Drawing.Color.Transparent;
            this.btnNavSettings.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnNavSettings.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(115)))), ((int)(((byte)(120)))), ((int)(((byte)(140)))));
            this.btnNavSettings.HoverState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(246)))), ((int)(((byte)(250)))));
            this.btnNavSettings.HoverState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(24)))), ((int)(((byte)(35)))));
            this.btnNavSettings.Location = new System.Drawing.Point(9, 290);
            this.btnNavSettings.Name = "btnNavSettings";
            this.btnNavSettings.Size = new System.Drawing.Size(165, 41);
            this.btnNavSettings.TabIndex = 6;
            this.btnNavSettings.Text = "  Settings";
            // 
            // btnNavHelp
            // 
            this.btnNavHelp.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnNavHelp.BorderRadius = 9;
            this.btnNavHelp.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnNavHelp.FillColor = System.Drawing.Color.Transparent;
            this.btnNavHelp.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnNavHelp.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(115)))), ((int)(((byte)(120)))), ((int)(((byte)(140)))));
            this.btnNavHelp.HoverState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(246)))), ((int)(((byte)(250)))));
            this.btnNavHelp.HoverState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(24)))), ((int)(((byte)(35)))));
            this.btnNavHelp.Location = new System.Drawing.Point(9, 1433);
            this.btnNavHelp.Name = "btnNavHelp";
            this.btnNavHelp.Size = new System.Drawing.Size(165, 41);
            this.btnNavHelp.TabIndex = 7;
            this.btnNavHelp.Text = "  Help";
            // 
            // btnNavLogout
            // 
            this.btnNavLogout.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnNavLogout.BorderRadius = 9;
            this.btnNavLogout.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnNavLogout.FillColor = System.Drawing.Color.Transparent;
            this.btnNavLogout.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnNavLogout.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(210)))), ((int)(((byte)(55)))), ((int)(((byte)(55)))));
            this.btnNavLogout.HoverState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(238)))), ((int)(((byte)(238)))));
            this.btnNavLogout.HoverState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(190)))), ((int)(((byte)(35)))), ((int)(((byte)(35)))));
            this.btnNavLogout.Location = new System.Drawing.Point(9, 1482);
            this.btnNavLogout.Name = "btnNavLogout";
            this.btnNavLogout.Size = new System.Drawing.Size(165, 41);
            this.btnNavLogout.TabIndex = 8;
            this.btnNavLogout.Text = "  Logout";
            this.btnNavLogout.Click += new System.EventHandler(this.btnNavLogout_Click);
            // 
            // pnlContent
            // 
            this.pnlContent.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(248)))), ((int)(((byte)(252)))));
            this.pnlContent.Controls.Add(this.pnlMain);
            this.pnlContent.Controls.Add(this.pnlTopBar);
            this.pnlContent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlContent.Location = new System.Drawing.Point(183, 0);
            this.pnlContent.Name = "pnlContent";
            this.pnlContent.Size = new System.Drawing.Size(1378, 819);
            this.pnlContent.TabIndex = 0;
            // 
            // pnlMain
            // 
            this.pnlMain.AutoScroll = true;
            this.pnlMain.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(248)))), ((int)(((byte)(252)))));
            this.pnlMain.Controls.Add(this.pnlLeft);
            this.pnlMain.Controls.Add(this.pnlRight);
            this.pnlMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlMain.Location = new System.Drawing.Point(0, 76);
            this.pnlMain.Name = "pnlMain";
            this.pnlMain.Padding = new System.Windows.Forms.Padding(23, 17, 23, 21);
            this.pnlMain.Size = new System.Drawing.Size(1378, 743);
            this.pnlMain.TabIndex = 0;
            // 
            // pnlLeft
            // 
            this.pnlLeft.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.pnlLeft.BackColor = System.Drawing.Color.Transparent;
            this.pnlLeft.Controls.Add(this.pnlHeader);
            this.pnlLeft.Controls.Add(this.pnlInvInfo);
            this.pnlLeft.Controls.Add(this.pnlItems);
            this.pnlLeft.Location = new System.Drawing.Point(0, 0);
            this.pnlLeft.Name = "pnlLeft";
            this.pnlLeft.Size = new System.Drawing.Size(846, 1553);
            this.pnlLeft.TabIndex = 0;
            // 
            // pnlHeader
            // 
            this.pnlHeader.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlHeader.BackColor = System.Drawing.Color.Transparent;
            this.pnlHeader.Controls.Add(this.lblCoName);
            this.pnlHeader.Controls.Add(this.lblCoEmail);
            this.pnlHeader.Controls.Add(this.lblCoAddr);
            this.pnlHeader.Location = new System.Drawing.Point(0, 20);
            this.pnlHeader.Name = "pnlHeader";
            this.pnlHeader.Size = new System.Drawing.Size(823, 141);
            this.pnlHeader.TabIndex = 0;
            this.pnlHeader.Paint += new System.Windows.Forms.PaintEventHandler(this.pnlHeader_Paint);
            // 
            // lblCoName
            // 
            this.lblCoName.AutoSize = true;
            this.lblCoName.BackColor = System.Drawing.Color.Transparent;
            this.lblCoName.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.lblCoName.ForeColor = System.Drawing.Color.White;
            this.lblCoName.Location = new System.Drawing.Point(75, 26);
            this.lblCoName.Name = "lblCoName";
            this.lblCoName.Size = new System.Drawing.Size(87, 32);
            this.lblCoName.TabIndex = 0;
            this.lblCoName.Text = "Maglo";
            // 
            // lblCoEmail
            // 
            this.lblCoEmail.AutoSize = true;
            this.lblCoEmail.BackColor = System.Drawing.Color.Transparent;
            this.lblCoEmail.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblCoEmail.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(165)))), ((int)(((byte)(178)))), ((int)(((byte)(198)))));
            this.lblCoEmail.Location = new System.Drawing.Point(77, 72);
            this.lblCoEmail.Name = "lblCoEmail";
            this.lblCoEmail.Size = new System.Drawing.Size(130, 20);
            this.lblCoEmail.TabIndex = 1;
            this.lblCoEmail.Text = "sales@maglo.com";
            // 
            // lblCoAddr
            // 
            this.lblCoAddr.BackColor = System.Drawing.Color.Transparent;
            this.lblCoAddr.Font = new System.Drawing.Font("Segoe UI", 8.5F);
            this.lblCoAddr.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(148)))), ((int)(((byte)(162)))), ((int)(((byte)(184)))));
            this.lblCoAddr.Location = new System.Drawing.Point(457, 17);
            this.lblCoAddr.Name = "lblCoAddr";
            this.lblCoAddr.Size = new System.Drawing.Size(343, 83);
            this.lblCoAddr.TabIndex = 2;
            this.lblCoAddr.Text = "1333 Grey Fox Farm Road\r\nHouston, TX 77060\r\nBloomfield Hills, Michigan(MI), 48301" +
    "";
            this.lblCoAddr.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // pnlInvInfo
            // 
            this.pnlInvInfo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlInvInfo.BackColor = System.Drawing.Color.Transparent;
            this.pnlInvInfo.Controls.Add(this.lblInvNumLbl);
            this.pnlInvInfo.Controls.Add(this.txtInvNum);
            this.pnlInvInfo.Controls.Add(this.lblIssuedLbl);
            this.pnlInvInfo.Controls.Add(this.dtpIssued);
            this.pnlInvInfo.Controls.Add(this.lblDueLbl);
            this.pnlInvInfo.Controls.Add(this.dtpDue);
            this.pnlInvInfo.Controls.Add(this.lblBilledLbl);
            this.pnlInvInfo.Controls.Add(this.txtBilledName);
            this.pnlInvInfo.Controls.Add(this.txtBilledAddr1);
            this.pnlInvInfo.Controls.Add(this.txtBilledAddr2);
            this.pnlInvInfo.Location = new System.Drawing.Point(0, 175);
            this.pnlInvInfo.Name = "pnlInvInfo";
            this.pnlInvInfo.Size = new System.Drawing.Size(823, 289);
            this.pnlInvInfo.TabIndex = 1;
            this.pnlInvInfo.Paint += new System.Windows.Forms.PaintEventHandler(this.pnlWhiteCard_Paint);
            // 
            // lblInvNumLbl
            // 
            this.lblInvNumLbl.AutoSize = true;
            this.lblInvNumLbl.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.lblInvNumLbl.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(25)))), ((int)(((byte)(40)))));
            this.lblInvNumLbl.Location = new System.Drawing.Point(27, 19);
            this.lblInvNumLbl.Name = "lblInvNumLbl";
            this.lblInvNumLbl.Size = new System.Drawing.Size(133, 21);
            this.lblInvNumLbl.TabIndex = 0;
            this.lblInvNumLbl.Text = "Invoice Number";
            // 
            // txtInvNum
            // 
            this.txtInvNum.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(218)))), ((int)(((byte)(222)))), ((int)(((byte)(235)))));
            this.txtInvNum.BorderRadius = 8;
            this.txtInvNum.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtInvNum.DefaultText = "";
            this.txtInvNum.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(246)))), ((int)(((byte)(252)))));
            this.txtInvNum.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(181)))), ((int)(((byte)(212)))), ((int)(((byte)(34)))));
            this.txtInvNum.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.txtInvNum.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(33)))), ((int)(((byte)(50)))));
            this.txtInvNum.Location = new System.Drawing.Point(27, 42);
            this.txtInvNum.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtInvNum.Name = "txtInvNum";
            this.txtInvNum.PlaceholderText = "e.g. MAG 2541420";
            this.txtInvNum.SelectedText = "";
            this.txtInvNum.Size = new System.Drawing.Size(224, 38);
            this.txtInvNum.TabIndex = 1;
            // 
            // lblIssuedLbl
            // 
            this.lblIssuedLbl.AutoSize = true;
            this.lblIssuedLbl.Font = new System.Drawing.Font("Segoe UI", 8.5F);
            this.lblIssuedLbl.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(145)))), ((int)(((byte)(150)))), ((int)(((byte)(170)))));
            this.lblIssuedLbl.Location = new System.Drawing.Point(27, 98);
            this.lblIssuedLbl.Name = "lblIssuedLbl";
            this.lblIssuedLbl.Size = new System.Drawing.Size(86, 20);
            this.lblIssuedLbl.TabIndex = 2;
            this.lblIssuedLbl.Text = "Issued Date";
            // 
            // dtpIssued
            // 
            this.dtpIssued.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(218)))), ((int)(((byte)(222)))), ((int)(((byte)(235)))));
            this.dtpIssued.BorderRadius = 8;
            this.dtpIssued.Checked = true;
            this.dtpIssued.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(246)))), ((int)(((byte)(252)))));
            this.dtpIssued.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.dtpIssued.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(33)))), ((int)(((byte)(50)))));
            this.dtpIssued.Format = System.Windows.Forms.DateTimePickerFormat.Long;
            this.dtpIssued.Location = new System.Drawing.Point(27, 119);
            this.dtpIssued.MaxDate = new System.DateTime(9998, 12, 31, 0, 0, 0, 0);
            this.dtpIssued.MinDate = new System.DateTime(1753, 1, 1, 0, 0, 0, 0);
            this.dtpIssued.Name = "dtpIssued";
            this.dtpIssued.Size = new System.Drawing.Size(224, 38);
            this.dtpIssued.TabIndex = 3;
            this.dtpIssued.Value = new System.DateTime(2026, 3, 14, 13, 18, 30, 611);
            // 
            // lblDueLbl
            // 
            this.lblDueLbl.AutoSize = true;
            this.lblDueLbl.Font = new System.Drawing.Font("Segoe UI", 8.5F);
            this.lblDueLbl.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(145)))), ((int)(((byte)(150)))), ((int)(((byte)(170)))));
            this.lblDueLbl.Location = new System.Drawing.Point(26, 176);
            this.lblDueLbl.Name = "lblDueLbl";
            this.lblDueLbl.Size = new System.Drawing.Size(72, 20);
            this.lblDueLbl.TabIndex = 4;
            this.lblDueLbl.Text = "Due Date";
            // 
            // dtpDue
            // 
            this.dtpDue.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(218)))), ((int)(((byte)(222)))), ((int)(((byte)(235)))));
            this.dtpDue.BorderRadius = 8;
            this.dtpDue.Checked = true;
            this.dtpDue.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(246)))), ((int)(((byte)(252)))));
            this.dtpDue.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.dtpDue.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(33)))), ((int)(((byte)(50)))));
            this.dtpDue.Format = System.Windows.Forms.DateTimePickerFormat.Long;
            this.dtpDue.Location = new System.Drawing.Point(26, 197);
            this.dtpDue.MaxDate = new System.DateTime(9998, 12, 31, 0, 0, 0, 0);
            this.dtpDue.MinDate = new System.DateTime(1753, 1, 1, 0, 0, 0, 0);
            this.dtpDue.Name = "dtpDue";
            this.dtpDue.Size = new System.Drawing.Size(224, 38);
            this.dtpDue.TabIndex = 5;
            this.dtpDue.Value = new System.DateTime(2026, 3, 14, 13, 18, 30, 648);
            // 
            // lblBilledLbl
            // 
            this.lblBilledLbl.AutoSize = true;
            this.lblBilledLbl.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.lblBilledLbl.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(25)))), ((int)(((byte)(40)))));
            this.lblBilledLbl.Location = new System.Drawing.Point(428, 19);
            this.lblBilledLbl.Name = "lblBilledLbl";
            this.lblBilledLbl.Size = new System.Drawing.Size(74, 21);
            this.lblBilledLbl.TabIndex = 6;
            this.lblBilledLbl.Text = "Billed to";
            // 
            // txtBilledName
            // 
            this.txtBilledName.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(218)))), ((int)(((byte)(222)))), ((int)(((byte)(235)))));
            this.txtBilledName.BorderRadius = 8;
            this.txtBilledName.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtBilledName.DefaultText = "";
            this.txtBilledName.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(246)))), ((int)(((byte)(252)))));
            this.txtBilledName.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(181)))), ((int)(((byte)(212)))), ((int)(((byte)(34)))));
            this.txtBilledName.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.txtBilledName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(33)))), ((int)(((byte)(50)))));
            this.txtBilledName.Location = new System.Drawing.Point(432, 42);
            this.txtBilledName.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtBilledName.Name = "txtBilledName";
            this.txtBilledName.PlaceholderText = "Client name";
            this.txtBilledName.SelectedText = "";
            this.txtBilledName.Size = new System.Drawing.Size(266, 38);
            this.txtBilledName.TabIndex = 7;
            // 
            // txtBilledAddr1
            // 
            this.txtBilledAddr1.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(218)))), ((int)(((byte)(222)))), ((int)(((byte)(235)))));
            this.txtBilledAddr1.BorderRadius = 8;
            this.txtBilledAddr1.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtBilledAddr1.DefaultText = "";
            this.txtBilledAddr1.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(246)))), ((int)(((byte)(252)))));
            this.txtBilledAddr1.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(181)))), ((int)(((byte)(212)))), ((int)(((byte)(34)))));
            this.txtBilledAddr1.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtBilledAddr1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(33)))), ((int)(((byte)(50)))));
            this.txtBilledAddr1.Location = new System.Drawing.Point(432, 119);
            this.txtBilledAddr1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtBilledAddr1.Name = "txtBilledAddr1";
            this.txtBilledAddr1.PlaceholderText = "Address line 1";
            this.txtBilledAddr1.SelectedText = "";
            this.txtBilledAddr1.Size = new System.Drawing.Size(352, 38);
            this.txtBilledAddr1.TabIndex = 8;
            // 
            // txtBilledAddr2
            // 
            this.txtBilledAddr2.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(218)))), ((int)(((byte)(222)))), ((int)(((byte)(235)))));
            this.txtBilledAddr2.BorderRadius = 8;
            this.txtBilledAddr2.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtBilledAddr2.DefaultText = "";
            this.txtBilledAddr2.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(246)))), ((int)(((byte)(252)))));
            this.txtBilledAddr2.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(181)))), ((int)(((byte)(212)))), ((int)(((byte)(34)))));
            this.txtBilledAddr2.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtBilledAddr2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(33)))), ((int)(((byte)(50)))));
            this.txtBilledAddr2.Location = new System.Drawing.Point(432, 197);
            this.txtBilledAddr2.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtBilledAddr2.Name = "txtBilledAddr2";
            this.txtBilledAddr2.PlaceholderText = "City, State ZIP";
            this.txtBilledAddr2.SelectedText = "";
            this.txtBilledAddr2.Size = new System.Drawing.Size(270, 38);
            this.txtBilledAddr2.TabIndex = 9;
            // 
            // pnlItems
            // 
            this.pnlItems.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlItems.BackColor = System.Drawing.Color.Transparent;
            this.pnlItems.Controls.Add(this.lblItemsTitle);
            this.pnlItems.Controls.Add(this.lblItemsSub);
            this.pnlItems.Controls.Add(this.dgvItems);
            this.pnlItems.Controls.Add(this.lnkAddItem);
            this.pnlItems.Controls.Add(this.pnlTotals);
            this.pnlItems.Location = new System.Drawing.Point(0, 470);
            this.pnlItems.Name = "pnlItems";
            this.pnlItems.Size = new System.Drawing.Size(823, 1080);
            this.pnlItems.TabIndex = 2;
            this.pnlItems.Paint += new System.Windows.Forms.PaintEventHandler(this.pnlWhiteCard_Paint);
            // 
            // lblItemsTitle
            // 
            this.lblItemsTitle.AutoSize = true;
            this.lblItemsTitle.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.lblItemsTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(23)))), ((int)(((byte)(38)))));
            this.lblItemsTitle.Location = new System.Drawing.Point(25, 17);
            this.lblItemsTitle.Name = "lblItemsTitle";
            this.lblItemsTitle.Size = new System.Drawing.Size(116, 25);
            this.lblItemsTitle.TabIndex = 0;
            this.lblItemsTitle.Text = "Item Details";
            // 
            // lblItemsSub
            // 
            this.lblItemsSub.AutoSize = true;
            this.lblItemsSub.Font = new System.Drawing.Font("Segoe UI", 8.5F);
            this.lblItemsSub.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(152)))), ((int)(((byte)(158)))), ((int)(((byte)(178)))));
            this.lblItemsSub.Location = new System.Drawing.Point(25, 41);
            this.lblItemsSub.Name = "lblItemsSub";
            this.lblItemsSub.Size = new System.Drawing.Size(190, 20);
            this.lblItemsSub.TabIndex = 1;
            this.lblItemsSub.Text = "Details item with more info";
            // 
            // dgvItems
            // 
            this.dgvItems.AllowUserToAddRows = false;
            this.dgvItems.AllowUserToDeleteRows = false;
            this.dgvItems.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvItems.BackgroundColor = System.Drawing.Color.White;
            this.dgvItems.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvItems.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dgvItems.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Bold);
            dataGridViewCellStyle5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(148)))), ((int)(((byte)(153)))), ((int)(((byte)(172)))));
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.Color.White;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvItems.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle5;
            this.dgvItems.ColumnHeadersHeight = 38;
            this.dgvItems.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            dataGridViewCellStyle6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(33)))), ((int)(((byte)(50)))));
            dataGridViewCellStyle6.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(246)))), ((int)(((byte)(252)))), ((int)(((byte)(230)))));
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(24)))), ((int)(((byte)(35)))));
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvItems.DefaultCellStyle = dataGridViewCellStyle6;
            this.dgvItems.EnableHeadersVisualStyles = false;
            this.dgvItems.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.dgvItems.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(240)))), ((int)(((byte)(248)))));
            this.dgvItems.Location = new System.Drawing.Point(0, 64);
            this.dgvItems.Name = "dgvItems";
            this.dgvItems.RowHeadersVisible = false;
            this.dgvItems.RowHeadersWidth = 51;
            this.dgvItems.RowTemplate.Height = 50;
            this.dgvItems.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.dgvItems.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvItems.Size = new System.Drawing.Size(823, 235);
            this.dgvItems.TabIndex = 2;
            // 
            // lnkAddItem
            // 
            this.lnkAddItem.ActiveLinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(145)))), ((int)(((byte)(75)))));
            this.lnkAddItem.AutoSize = true;
            this.lnkAddItem.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lnkAddItem.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.lnkAddItem.LinkBehavior = System.Windows.Forms.LinkBehavior.NeverUnderline;
            this.lnkAddItem.LinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(175)))), ((int)(((byte)(100)))));
            this.lnkAddItem.Location = new System.Drawing.Point(25, 309);
            this.lnkAddItem.Name = "lnkAddItem";
            this.lnkAddItem.Size = new System.Drawing.Size(95, 21);
            this.lnkAddItem.TabIndex = 3;
            this.lnkAddItem.TabStop = true;
            this.lnkAddItem.Text = "+ Add Item";
            this.lnkAddItem.Click += new System.EventHandler(this.lnkAddItem_Click);
            // 
            // pnlTotals
            // 
            this.pnlTotals.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlTotals.BackColor = System.Drawing.Color.Transparent;
            this.pnlTotals.Location = new System.Drawing.Point(0, 339);
            this.pnlTotals.Name = "pnlTotals";
            this.pnlTotals.Size = new System.Drawing.Size(823, 158);
            this.pnlTotals.TabIndex = 4;
            this.pnlTotals.Paint += new System.Windows.Forms.PaintEventHandler(this.pnlTotals_Paint);
            // 
            // pnlRight
            // 
            this.pnlRight.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlRight.BackColor = System.Drawing.Color.Transparent;
            this.pnlRight.Controls.Add(this.pnlClientCard);
            this.pnlRight.Controls.Add(this.pnlBasicInfo);
            this.pnlRight.Location = new System.Drawing.Point(2018, 0);
            this.pnlRight.Name = "pnlRight";
            this.pnlRight.Size = new System.Drawing.Size(411, 1553);
            this.pnlRight.TabIndex = 1;
            // 
            // pnlClientCard
            // 
            this.pnlClientCard.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlClientCard.BackColor = System.Drawing.Color.Transparent;
            this.pnlClientCard.Controls.Add(this.lblClientTitle);
            this.pnlClientCard.Controls.Add(this.lblClientNameLbl);
            this.pnlClientCard.Controls.Add(this.txtClientName);
            this.pnlClientCard.Controls.Add(this.lblClientEmailLbl);
            this.pnlClientCard.Controls.Add(this.txtClientEmail);
            this.pnlClientCard.Controls.Add(this.lblClientCompanyLbl);
            this.pnlClientCard.Controls.Add(this.txtClientCompany);
            this.pnlClientCard.Controls.Add(this.lblClientAddrLbl);
            this.pnlClientCard.Controls.Add(this.txtClientAddr);
            this.pnlClientCard.Controls.Add(this.btnAddCustomer);
            this.pnlClientCard.Location = new System.Drawing.Point(0, 0);
            this.pnlClientCard.Name = "pnlClientCard";
            this.pnlClientCard.Size = new System.Drawing.Size(398, 384);
            this.pnlClientCard.TabIndex = 0;
            this.pnlClientCard.Paint += new System.Windows.Forms.PaintEventHandler(this.pnlWhiteCard_Paint);
            // 
            // lblClientTitle
            // 
            this.lblClientTitle.AutoSize = true;
            this.lblClientTitle.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.lblClientTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(23)))), ((int)(((byte)(38)))));
            this.lblClientTitle.Location = new System.Drawing.Point(23, 19);
            this.lblClientTitle.Name = "lblClientTitle";
            this.lblClientTitle.Size = new System.Drawing.Size(127, 25);
            this.lblClientTitle.TabIndex = 0;
            this.lblClientTitle.Text = "Client Details";
            // 
            // lblClientNameLbl
            // 
            this.lblClientNameLbl.AutoSize = true;
            this.lblClientNameLbl.Font = new System.Drawing.Font("Segoe UI", 8.5F);
            this.lblClientNameLbl.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(145)))), ((int)(((byte)(150)))), ((int)(((byte)(170)))));
            this.lblClientNameLbl.Location = new System.Drawing.Point(23, 55);
            this.lblClientNameLbl.Name = "lblClientNameLbl";
            this.lblClientNameLbl.Size = new System.Drawing.Size(91, 20);
            this.lblClientNameLbl.TabIndex = 1;
            this.lblClientNameLbl.Text = "Client Name";
            // 
            // txtClientName
            // 
            this.txtClientName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtClientName.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(218)))), ((int)(((byte)(222)))), ((int)(((byte)(235)))));
            this.txtClientName.BorderRadius = 8;
            this.txtClientName.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtClientName.DefaultText = "";
            this.txtClientName.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(246)))), ((int)(((byte)(252)))));
            this.txtClientName.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(181)))), ((int)(((byte)(212)))), ((int)(((byte)(34)))));
            this.txtClientName.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.txtClientName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(33)))), ((int)(((byte)(50)))));
            this.txtClientName.Location = new System.Drawing.Point(22, 74);
            this.txtClientName.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtClientName.Name = "txtClientName";
            this.txtClientName.PlaceholderText = "e.g. Sajib Rahman";
            this.txtClientName.SelectedText = "";
            this.txtClientName.Size = new System.Drawing.Size(346, 38);
            this.txtClientName.TabIndex = 2;
            // 
            // lblClientEmailLbl
            // 
            this.lblClientEmailLbl.AutoSize = true;
            this.lblClientEmailLbl.Font = new System.Drawing.Font("Segoe UI", 8.5F);
            this.lblClientEmailLbl.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(145)))), ((int)(((byte)(150)))), ((int)(((byte)(170)))));
            this.lblClientEmailLbl.Location = new System.Drawing.Point(23, 126);
            this.lblClientEmailLbl.Name = "lblClientEmailLbl";
            this.lblClientEmailLbl.Size = new System.Drawing.Size(88, 20);
            this.lblClientEmailLbl.TabIndex = 3;
            this.lblClientEmailLbl.Text = "Client Email";
            // 
            // txtClientEmail
            // 
            this.txtClientEmail.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtClientEmail.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(218)))), ((int)(((byte)(222)))), ((int)(((byte)(235)))));
            this.txtClientEmail.BorderRadius = 8;
            this.txtClientEmail.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtClientEmail.DefaultText = "";
            this.txtClientEmail.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(246)))), ((int)(((byte)(252)))));
            this.txtClientEmail.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(181)))), ((int)(((byte)(212)))), ((int)(((byte)(34)))));
            this.txtClientEmail.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.txtClientEmail.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(33)))), ((int)(((byte)(50)))));
            this.txtClientEmail.Location = new System.Drawing.Point(22, 143);
            this.txtClientEmail.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtClientEmail.Name = "txtClientEmail";
            this.txtClientEmail.PlaceholderText = "email@example.com";
            this.txtClientEmail.SelectedText = "";
            this.txtClientEmail.Size = new System.Drawing.Size(346, 38);
            this.txtClientEmail.TabIndex = 4;
            // 
            // lblClientCompanyLbl
            // 
            this.lblClientCompanyLbl.AutoSize = true;
            this.lblClientCompanyLbl.Font = new System.Drawing.Font("Segoe UI", 8.5F);
            this.lblClientCompanyLbl.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(145)))), ((int)(((byte)(150)))), ((int)(((byte)(170)))));
            this.lblClientCompanyLbl.Location = new System.Drawing.Point(23, 196);
            this.lblClientCompanyLbl.Name = "lblClientCompanyLbl";
            this.lblClientCompanyLbl.Size = new System.Drawing.Size(72, 20);
            this.lblClientCompanyLbl.TabIndex = 5;
            this.lblClientCompanyLbl.Text = "Company";
            // 
            // txtClientCompany
            // 
            this.txtClientCompany.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtClientCompany.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(218)))), ((int)(((byte)(222)))), ((int)(((byte)(235)))));
            this.txtClientCompany.BorderRadius = 8;
            this.txtClientCompany.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtClientCompany.DefaultText = "";
            this.txtClientCompany.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(246)))), ((int)(((byte)(252)))));
            this.txtClientCompany.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(181)))), ((int)(((byte)(212)))), ((int)(((byte)(34)))));
            this.txtClientCompany.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.txtClientCompany.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(33)))), ((int)(((byte)(50)))));
            this.txtClientCompany.Location = new System.Drawing.Point(22, 212);
            this.txtClientCompany.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtClientCompany.Name = "txtClientCompany";
            this.txtClientCompany.PlaceholderText = "Company name";
            this.txtClientCompany.SelectedText = "";
            this.txtClientCompany.Size = new System.Drawing.Size(346, 38);
            this.txtClientCompany.TabIndex = 6;
            // 
            // lblClientAddrLbl
            // 
            this.lblClientAddrLbl.AutoSize = true;
            this.lblClientAddrLbl.Font = new System.Drawing.Font("Segoe UI", 8.5F);
            this.lblClientAddrLbl.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(145)))), ((int)(((byte)(150)))), ((int)(((byte)(170)))));
            this.lblClientAddrLbl.Location = new System.Drawing.Point(23, 267);
            this.lblClientAddrLbl.Name = "lblClientAddrLbl";
            this.lblClientAddrLbl.Size = new System.Drawing.Size(62, 20);
            this.lblClientAddrLbl.TabIndex = 7;
            this.lblClientAddrLbl.Text = "Address";
            // 
            // txtClientAddr
            // 
            this.txtClientAddr.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtClientAddr.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(218)))), ((int)(((byte)(222)))), ((int)(((byte)(235)))));
            this.txtClientAddr.BorderRadius = 8;
            this.txtClientAddr.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtClientAddr.DefaultText = "";
            this.txtClientAddr.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(246)))), ((int)(((byte)(252)))));
            this.txtClientAddr.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(181)))), ((int)(((byte)(212)))), ((int)(((byte)(34)))));
            this.txtClientAddr.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtClientAddr.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(33)))), ((int)(((byte)(50)))));
            this.txtClientAddr.Location = new System.Drawing.Point(23, 286);
            this.txtClientAddr.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtClientAddr.Name = "txtClientAddr";
            this.txtClientAddr.PlaceholderText = "Client address";
            this.txtClientAddr.SelectedText = "";
            this.txtClientAddr.Size = new System.Drawing.Size(352, 38);
            this.txtClientAddr.TabIndex = 8;
            // 
            // btnAddCustomer
            // 
            this.btnAddCustomer.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAddCustomer.BorderRadius = 10;
            this.btnAddCustomer.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAddCustomer.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(252)))), ((int)(((byte)(215)))));
            this.btnAddCustomer.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.btnAddCustomer.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(148)))), ((int)(((byte)(75)))));
            this.btnAddCustomer.HoverState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(210)))), ((int)(((byte)(242)))), ((int)(((byte)(185)))));
            this.btnAddCustomer.HoverState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(125)))), ((int)(((byte)(60)))));
            this.btnAddCustomer.Location = new System.Drawing.Point(23, 335);
            this.btnAddCustomer.Name = "btnAddCustomer";
            this.btnAddCustomer.Size = new System.Drawing.Size(352, 38);
            this.btnAddCustomer.TabIndex = 9;
            this.btnAddCustomer.Text = "Add Customer";
            // 
            // pnlBasicInfo
            // 
            this.pnlBasicInfo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlBasicInfo.BackColor = System.Drawing.Color.Transparent;
            this.pnlBasicInfo.Controls.Add(this.lblBasicTitle);
            this.pnlBasicInfo.Controls.Add(this.lblInvDateLbl);
            this.pnlBasicInfo.Controls.Add(this.dtpInvoiceDate);
            this.pnlBasicInfo.Controls.Add(this.lblDueDateLbl);
            this.pnlBasicInfo.Controls.Add(this.dtpDueDate);
            this.pnlBasicInfo.Controls.Add(this.btnSend);
            this.pnlBasicInfo.Controls.Add(this.btnPreview);
            this.pnlBasicInfo.Controls.Add(this.btnDownload);
            this.pnlBasicInfo.Location = new System.Drawing.Point(0, 399);
            this.pnlBasicInfo.Name = "pnlBasicInfo";
            this.pnlBasicInfo.Size = new System.Drawing.Size(398, 341);
            this.pnlBasicInfo.TabIndex = 1;
            this.pnlBasicInfo.Paint += new System.Windows.Forms.PaintEventHandler(this.pnlWhiteCard_Paint);
            // 
            // lblBasicTitle
            // 
            this.lblBasicTitle.AutoSize = true;
            this.lblBasicTitle.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.lblBasicTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(23)))), ((int)(((byte)(38)))));
            this.lblBasicTitle.Location = new System.Drawing.Point(23, 19);
            this.lblBasicTitle.Name = "lblBasicTitle";
            this.lblBasicTitle.Size = new System.Drawing.Size(98, 25);
            this.lblBasicTitle.TabIndex = 0;
            this.lblBasicTitle.Text = "Basic Info";
            // 
            // lblInvDateLbl
            // 
            this.lblInvDateLbl.AutoSize = true;
            this.lblInvDateLbl.Font = new System.Drawing.Font("Segoe UI", 8.5F);
            this.lblInvDateLbl.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(145)))), ((int)(((byte)(150)))), ((int)(((byte)(170)))));
            this.lblInvDateLbl.Location = new System.Drawing.Point(23, 58);
            this.lblInvDateLbl.Name = "lblInvDateLbl";
            this.lblInvDateLbl.Size = new System.Drawing.Size(92, 20);
            this.lblInvDateLbl.TabIndex = 1;
            this.lblInvDateLbl.Text = "Invoice Date";
            // 
            // dtpInvoiceDate
            // 
            this.dtpInvoiceDate.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dtpInvoiceDate.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(218)))), ((int)(((byte)(222)))), ((int)(((byte)(235)))));
            this.dtpInvoiceDate.BorderRadius = 10;
            this.dtpInvoiceDate.Checked = true;
            this.dtpInvoiceDate.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(246)))), ((int)(((byte)(252)))));
            this.dtpInvoiceDate.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.dtpInvoiceDate.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(33)))), ((int)(((byte)(50)))));
            this.dtpInvoiceDate.Format = System.Windows.Forms.DateTimePickerFormat.Long;
            this.dtpInvoiceDate.Location = new System.Drawing.Point(23, 77);
            this.dtpInvoiceDate.MaxDate = new System.DateTime(9998, 12, 31, 0, 0, 0, 0);
            this.dtpInvoiceDate.MinDate = new System.DateTime(1753, 1, 1, 0, 0, 0, 0);
            this.dtpInvoiceDate.Name = "dtpInvoiceDate";
            this.dtpInvoiceDate.Size = new System.Drawing.Size(352, 43);
            this.dtpInvoiceDate.TabIndex = 2;
            this.dtpInvoiceDate.Value = new System.DateTime(2026, 3, 14, 13, 18, 30, 761);
            // 
            // lblDueDateLbl
            // 
            this.lblDueDateLbl.AutoSize = true;
            this.lblDueDateLbl.Font = new System.Drawing.Font("Segoe UI", 8.5F);
            this.lblDueDateLbl.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(145)))), ((int)(((byte)(150)))), ((int)(((byte)(170)))));
            this.lblDueDateLbl.Location = new System.Drawing.Point(23, 134);
            this.lblDueDateLbl.Name = "lblDueDateLbl";
            this.lblDueDateLbl.Size = new System.Drawing.Size(72, 20);
            this.lblDueDateLbl.TabIndex = 3;
            this.lblDueDateLbl.Text = "Due Date";
            // 
            // dtpDueDate
            // 
            this.dtpDueDate.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dtpDueDate.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(218)))), ((int)(((byte)(222)))), ((int)(((byte)(235)))));
            this.dtpDueDate.BorderRadius = 10;
            this.dtpDueDate.Checked = true;
            this.dtpDueDate.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(246)))), ((int)(((byte)(252)))));
            this.dtpDueDate.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.dtpDueDate.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(33)))), ((int)(((byte)(50)))));
            this.dtpDueDate.Format = System.Windows.Forms.DateTimePickerFormat.Long;
            this.dtpDueDate.Location = new System.Drawing.Point(23, 154);
            this.dtpDueDate.MaxDate = new System.DateTime(9998, 12, 31, 0, 0, 0, 0);
            this.dtpDueDate.MinDate = new System.DateTime(1753, 1, 1, 0, 0, 0, 0);
            this.dtpDueDate.Name = "dtpDueDate";
            this.dtpDueDate.Size = new System.Drawing.Size(352, 43);
            this.dtpDueDate.TabIndex = 4;
            this.dtpDueDate.Value = new System.DateTime(2026, 3, 14, 13, 18, 30, 802);
            // 
            // btnSend
            // 
            this.btnSend.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSend.BorderRadius = 12;
            this.btnSend.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSend.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(181)))), ((int)(((byte)(212)))), ((int)(((byte)(34)))));
            this.btnSend.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.btnSend.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(24)))), ((int)(((byte)(35)))));
            this.btnSend.HoverState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(162)))), ((int)(((byte)(193)))), ((int)(((byte)(18)))));
            this.btnSend.Location = new System.Drawing.Point(23, 215);
            this.btnSend.Name = "btnSend";
            this.btnSend.Size = new System.Drawing.Size(352, 51);
            this.btnSend.TabIndex = 5;
            this.btnSend.Text = "Send Invoice";
            this.btnSend.Click += new System.EventHandler(this.btnSend_Click);
            // 
            // btnPreview
            // 
            this.btnPreview.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(214)))), ((int)(((byte)(218)))), ((int)(((byte)(232)))));
            this.btnPreview.BorderRadius = 10;
            this.btnPreview.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnPreview.FillColor = System.Drawing.Color.White;
            this.btnPreview.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.btnPreview.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(165)))), ((int)(((byte)(90)))));
            this.btnPreview.HoverState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(252)))), ((int)(((byte)(230)))));
            this.btnPreview.Location = new System.Drawing.Point(23, 279);
            this.btnPreview.Name = "btnPreview";
            this.btnPreview.Size = new System.Drawing.Size(167, 43);
            this.btnPreview.TabIndex = 6;
            this.btnPreview.Text = "Preview";
            // 
            // btnDownload
            // 
            this.btnDownload.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(214)))), ((int)(((byte)(218)))), ((int)(((byte)(232)))));
            this.btnDownload.BorderRadius = 10;
            this.btnDownload.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnDownload.FillColor = System.Drawing.Color.White;
            this.btnDownload.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.btnDownload.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(150)))), ((int)(((byte)(225)))));
            this.btnDownload.HoverState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(244)))), ((int)(((byte)(255)))));
            this.btnDownload.Location = new System.Drawing.Point(208, 279);
            this.btnDownload.Name = "btnDownload";
            this.btnDownload.Size = new System.Drawing.Size(167, 43);
            this.btnDownload.TabIndex = 7;
            this.btnDownload.Text = "Download";
            this.btnDownload.Click += new System.EventHandler(this.btnDownload_Click);
            // 
            // CreateInvoiceForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(248)))), ((int)(((byte)(252)))));
            this.ClientSize = new System.Drawing.Size(1561, 819);
            this.Controls.Add(this.pnlContent);
            this.Controls.Add(this.pnlSidebar);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "CreateInvoiceForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "New Invoice";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.pnlTopBar.ResumeLayout(false);
            this.pnlTopBar.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picAvatar)).EndInit();
            this.pnlSidebar.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.picLogo)).EndInit();
            this.pnlContent.ResumeLayout(false);
            this.pnlMain.ResumeLayout(false);
            this.pnlLeft.ResumeLayout(false);
            this.pnlHeader.ResumeLayout(false);
            this.pnlHeader.PerformLayout();
            this.pnlInvInfo.ResumeLayout(false);
            this.pnlInvInfo.PerformLayout();
            this.pnlItems.ResumeLayout(false);
            this.pnlItems.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvItems)).EndInit();
            this.pnlRight.ResumeLayout(false);
            this.pnlClientCard.ResumeLayout(false);
            this.pnlClientCard.PerformLayout();
            this.pnlBasicInfo.ResumeLayout(false);
            this.pnlBasicInfo.PerformLayout();
            this.ResumeLayout(false);

        }

        // ── Designer fields ───────────────────────────────────────────────────────
        private Guna.UI2.WinForms.Guna2DragControl guna2Drag;
        private System.Windows.Forms.Panel pnlSidebar, pnlContent, pnlTopBar, pnlMain;
        private System.Windows.Forms.Panel pnlLeft, pnlHeader, pnlInvInfo, pnlItems, pnlTotals;
        private System.Windows.Forms.Panel pnlRight, pnlClientCard, pnlBasicInfo;
        private System.Windows.Forms.PictureBox picLogo, picAvatar;
        private System.Windows.Forms.Label lblAppName, lblPageTitle, lblUsername;
        private System.Windows.Forms.Label lblCoName, lblCoEmail, lblCoAddr;
        private System.Windows.Forms.Label lblInvNumLbl, lblBilledLbl, lblIssuedLbl, lblDueLbl;
        private System.Windows.Forms.Label lblItemsTitle, lblItemsSub;
        private System.Windows.Forms.Label lblClientTitle, lblClientNameLbl, lblClientEmailLbl;
        private System.Windows.Forms.Label lblClientCompanyLbl, lblClientAddrLbl;
        private System.Windows.Forms.Label lblBasicTitle, lblInvDateLbl, lblDueDateLbl;
        private Guna.UI2.WinForms.Guna2Button btnNavDashboard, btnNavTransactions, btnNavInvoices, btnNavWallets, btnNavSettings;
        private Guna.UI2.WinForms.Guna2Button btnNavHelp, btnNavLogout;
        private Guna.UI2.WinForms.Guna2Button btnMinimize, btnMaximize, btnClose;
        private Guna.UI2.WinForms.Guna2TextBox txtInvNum, txtBilledName, txtBilledAddr1, txtBilledAddr2;
        private Guna.UI2.WinForms.Guna2TextBox txtClientName, txtClientEmail, txtClientCompany, txtClientAddr;
        private Guna.UI2.WinForms.Guna2DateTimePicker dtpIssued, dtpDue, dtpInvoiceDate, dtpDueDate;
        private System.Windows.Forms.DataGridView dgvItems;
        private System.Windows.Forms.LinkLabel lnkAddItem;
        private Guna.UI2.WinForms.Guna2Button btnAddCustomer;
        private Guna.UI2.WinForms.Guna2Button btnSend, btnPreview, btnDownload;
    }
}