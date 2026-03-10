using System;
using System.Windows.Forms;
using PersonalFinanceManager.Infrastructure.DI;

namespace PersonalFinanceManager.UI
{
    static class Program
    {
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            try
            {
                // Bước 1: Khởi tạo DI - phải chạy TRƯỚC KHI mở bất kỳ Form nào
                DependencyContainer.Initialize();

                // Bước 2: Mở form đầu tiên
                Application.Run(new Form());
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    $"Lỗi khởi động ứng dụng:\n{ex.Message}",
                    "Lỗi",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }
    }
}