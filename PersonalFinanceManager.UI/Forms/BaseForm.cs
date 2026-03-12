using Guna.UI2.WinForms;
using PersonalFinanceManager.Theme;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using PersonalFinanceManager.UI.Mock; 
using Guna.Charts.WinForms;


namespace PersonalFinanceManager.Forms
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



        private void btnTransactions_Click_1(object sender, EventArgs e)
        {
            container(new PersonalFinanceManager.Forms.Transactions.TransactionListForm()); // Nạp cái TransactionListForm cậu vừa làm xong
            guna2HtmlLabel1.Text = "Giao Dịch";
        }

        private void btnDashboard_Click_1(object sender, EventArgs e)
        {
            container(new PersonalFinanceManager.Forms.Dashboard.DashboardForm()); // Nạp cái Dashboard cậu vừa làm xong
            guna2HtmlLabel1.Text = "Chi Tiêu";
        }
    }
}
