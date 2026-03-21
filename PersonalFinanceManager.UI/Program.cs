using System;
using System.Windows.Forms;
using PersonalFinanceManager.Infrastructure.DI;
using PersonalFinanceManager.UI.Navigation;

namespace PersonalFinanceManager.UI
{
    static class Program
    {
        [STAThread]
        static void Main()
        {

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            // Khởi tạo DI container
            DependencyContainer.Initialize();

            // Mở LoginForm qua Navigator — đảm bảo chỉ 1 instance tồn tại
            FormNavigator.GoToLogin();

            // Giữ app chạy cho đến khi tất cả form đóng
            //Application.Run(new PersonalFinanceManager.Forms.Categories.CategoryForm());
            //Application.Run(new PersonalFinanceManager.Forms.Accounts.AccountForm());
            //Application.Run(new PersonalFinanceManager.Forms.Reports.ReportForm());
            Application.Run(new PersonalFinanceManager.Forms.Dashboard.DashboardForm());
        }
    }
}