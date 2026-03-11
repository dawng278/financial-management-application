using Guna.UI2.WinForms;
using SpendingManagement.UI.Forms.Dashboard;
using SpendingManagement.UI.Forms.Transactions;
using SpendingManagement.UI.Theme;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace SpendingManagement.UI.Forms
{
    public partial class BaseForm : Form
    {
        public BaseForm()
        {
            InitializeComponent();

            if (Sidebar != null) Sidebar.FillColor = GunaThemeConfig.SidebarColor;
            if (Header != null) Header.FillColor = GunaThemeConfig.HeaderColor;
        }

        // Hàm dùng để nạp các Form con vào Panel nội dung (pnlContainer)
        public void container(Form childForm)
        {
            pnlContainer.Controls.Clear();
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;

            // DÒNG QUAN TRỌNG NHẤT ĐỂ CO GIÃN:
            childForm.Dock = DockStyle.Fill;

            pnlContainer.Controls.Add(childForm);
            childForm.Show();
        }

        private void btnDashboard_Click(object sender, EventArgs e)
        {
            container(new DashboardForm()); // Mở form dashboard vào panel chính
            guna2HtmlLabel1.Text = "DashBoard";
        }

        private void btnTransactions_Click_1(object sender, EventArgs e)
        {
            container(new TransactionListForm());
            guna2HtmlLabel1.Text = "DANH SÁCH GIAO DỊCH";
        }
    }
}
