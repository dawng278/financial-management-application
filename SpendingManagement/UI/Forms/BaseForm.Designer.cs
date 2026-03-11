namespace SpendingManagement.UI.Forms
{
    partial class BaseForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges5 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges6 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges3 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges4 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges7 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges8 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges9 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges10 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges1 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges2 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Sidebar = new Guna.UI2.WinForms.Guna2Panel();
            btnDashboard = new Guna.UI2.WinForms.Guna2Button();
            pnlContainer = new Guna.UI2.WinForms.Guna2Panel();
            guna2Panel1 = new Guna.UI2.WinForms.Guna2Panel();
            guna2HtmlLabel1 = new Guna.UI2.WinForms.Guna2HtmlLabel();
            btnTransactions = new Guna.UI2.WinForms.Guna2Button();
            Sidebar.SuspendLayout();
            guna2Panel1.SuspendLayout();
            SuspendLayout();
            // 
            // Sidebar
            // 
            Sidebar.BackColor = Color.FromArgb(30, 41, 59);
            Sidebar.Controls.Add(btnTransactions);
            Sidebar.Controls.Add(btnDashboard);
            Sidebar.CustomizableEdges = customizableEdges5;
            Sidebar.Dock = DockStyle.Left;
            Sidebar.Location = new Point(0, 0);
            Sidebar.Name = "Sidebar";
            Sidebar.ShadowDecoration.CustomizableEdges = customizableEdges6;
            Sidebar.Size = new Size(254, 451);
            Sidebar.TabIndex = 0;
            // 
            // btnDashboard
            // 
            btnDashboard.BorderColor = Color.Beige;
            btnDashboard.BorderRadius = 20;
            btnDashboard.BorderThickness = 2;
            btnDashboard.ButtonMode = Guna.UI2.WinForms.Enums.ButtonMode.RadioButton;
            btnDashboard.CheckedState.FillColor = Color.Beige;
            btnDashboard.CheckedState.ForeColor = Color.Navy;
            btnDashboard.CustomizableEdges = customizableEdges3;
            btnDashboard.DisabledState.BorderColor = Color.DarkGray;
            btnDashboard.DisabledState.CustomBorderColor = Color.DarkGray;
            btnDashboard.DisabledState.FillColor = Color.FromArgb(169, 169, 169);
            btnDashboard.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
            btnDashboard.FillColor = Color.Transparent;
            btnDashboard.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            btnDashboard.ForeColor = Color.White;
            btnDashboard.Location = new Point(12, 149);
            btnDashboard.Name = "btnDashboard";
            btnDashboard.ShadowDecoration.CustomizableEdges = customizableEdges4;
            btnDashboard.Size = new Size(225, 56);
            btnDashboard.TabIndex = 0;
            btnDashboard.Text = "Chi tiêu";
            btnDashboard.Click += btnDashboard_Click;
            // 
            // pnlContainer
            // 
            pnlContainer.BackColor = SystemColors.Window;
            pnlContainer.CustomizableEdges = customizableEdges7;
            pnlContainer.Dock = DockStyle.Fill;
            pnlContainer.Location = new Point(254, 67);
            pnlContainer.Name = "pnlContainer";
            pnlContainer.Padding = new Padding(20, 0, 0, 20);
            pnlContainer.ShadowDecoration.CustomizableEdges = customizableEdges8;
            pnlContainer.Size = new Size(567, 384);
            pnlContainer.TabIndex = 0;
            // 
            // guna2Panel1
            // 
            guna2Panel1.BackColor = Color.Beige;
            guna2Panel1.Controls.Add(guna2HtmlLabel1);
            guna2Panel1.CustomizableEdges = customizableEdges9;
            guna2Panel1.Dock = DockStyle.Top;
            guna2Panel1.Location = new Point(254, 0);
            guna2Panel1.Name = "guna2Panel1";
            guna2Panel1.ShadowDecoration.CustomizableEdges = customizableEdges10;
            guna2Panel1.Size = new Size(567, 67);
            guna2Panel1.TabIndex = 1;
            // 
            // guna2HtmlLabel1
            // 
            guna2HtmlLabel1.BackColor = Color.Transparent;
            guna2HtmlLabel1.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            guna2HtmlLabel1.Location = new Point(205, 12);
            guna2HtmlLabel1.Name = "guna2HtmlLabel1";
            guna2HtmlLabel1.Size = new Size(151, 33);
            guna2HtmlLabel1.TabIndex = 0;
            guna2HtmlLabel1.Text = "Bảng Chi Tiêu";
            // 
            // btnTransactions
            // 
            btnTransactions.BorderColor = Color.Beige;
            btnTransactions.BorderRadius = 20;
            btnTransactions.BorderThickness = 2;
            btnTransactions.CustomizableEdges = customizableEdges1;
            btnTransactions.DisabledState.BorderColor = Color.DarkGray;
            btnTransactions.DisabledState.CustomBorderColor = Color.DarkGray;
            btnTransactions.DisabledState.FillColor = Color.FromArgb(169, 169, 169);
            btnTransactions.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
            btnTransactions.FillColor = Color.Transparent;
            btnTransactions.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            btnTransactions.ForeColor = Color.White;
            btnTransactions.Location = new Point(12, 275);
            btnTransactions.Name = "btnTransactions";
            btnTransactions.ShadowDecoration.CustomizableEdges = customizableEdges2;
            btnTransactions.Size = new Size(225, 56);
            btnTransactions.TabIndex = 1;
            btnTransactions.Text = "Giao dịch";
            btnTransactions.Click += this.btnTransactions_Click_1;
            // 
            // BaseForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(821, 451);
            Controls.Add(pnlContainer);
            Controls.Add(guna2Panel1);
            Controls.Add(Sidebar);
            Name = "BaseForm";
            Text = "BaseForms";
            Sidebar.ResumeLayout(false);
            guna2Panel1.ResumeLayout(false);
            guna2Panel1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Guna.UI2.WinForms.Guna2Panel Header;
        private Guna.UI2.WinForms.Guna2Panel Sidebar;
        private Guna.UI2.WinForms.Guna2Panel pnlContainer;
        private Guna.UI2.WinForms.Guna2Button btnDashboard;
        private Guna.UI2.WinForms.Guna2HtmlLabel lblTitle;
        private Guna.UI2.WinForms.Guna2Panel guna2Panel1;
        private Guna.UI2.WinForms.Guna2HtmlLabel guna2HtmlLabel1;
        private Guna.UI2.WinForms.Guna2Button btnTransactions;
    }
}