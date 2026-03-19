using Guna.UI2.WinForms;
using PersonalFinanceManager.Forms.Categories;
using PersonalFinanceManager.Forms.Dashboard;
using PersonalFinanceManager.Forms.Reports;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PersonalFinanceManager.Forms.Accounts
{
    public partial class AccountForm : Form
    {
        private Form currentChildForm = null;
        public AccountForm()
        {
            InitializeComponent();
        }
        bool isShowing = false;
        string realBalance = "15.000.000 đ";
        private void btnShowHide_Click(object sender, EventArgs e)
        {
            isShowing = !isShowing; // Đảo trạng thái

            if (isShowing)
            {
                lblBalance.Text = realBalance;
                // Đổi sang icon "con mắt mở"
                btnShowHide.Image = Properties.Resources.icons8_eye_50;
            }
            else
            {
                lblBalance.Text = "**********";
                // Đổi sang icon "con mắt gạch chéo"
                btnShowHide.Image = Properties.Resources.icons8_closed_eye_50;
            }
        }
        private void showForm(Form childForm)
        {
            // Xóa các nội dung cũ trong Panel hiển thị (giả sử tên Panel của cậu là mainPanel)
            // Nếu cậu đặt tên Panel khác thì đổi 'mainPanel' thành tên đó nhé
            mainPanel.Controls.Clear();

            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;

            mainPanel.Controls.Add(childForm);
            mainPanel.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();
        }
        private void btnDanhMuc_Click(object sender, EventArgs e)
        {
            showForm(new CategoryForm());
        }

        
        private void guna2CircleButton3_Click(object sender, EventArgs e)
        {
            // Tạo mới instance của ReportForm
            ReportForm report = new ReportForm();

            // Nếu muốn Form báo cáo hiện ra giữa màn hình
            report.StartPosition = FormStartPosition.CenterScreen;

            // Hiển thị Form
            report.Show();

            // (Tùy chọn) Nếu muốn ẩn form Account đi:
            // this.Hide();
        }

        private void btnNavDashboard_Click(object sender, EventArgs e)
        {
            // Giả sử Form tổng quan của cậu tên là MainForm hoặc DashboardForm
            DashboardForm main = new DashboardForm();
            main.StartPosition = FormStartPosition.CenterScreen;
            main.Show();

            // Đóng hẳn cái AccountForm này lại
            this.Close();
        }
    }
}
