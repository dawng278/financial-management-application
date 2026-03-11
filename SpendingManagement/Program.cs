using SpendingManagement.UI.Forms;
using SpendingManagement.UI.Forms.Auth;

namespace SpendingManagement
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // 1. Cài đặt hệ thống phải để ĐẦU TIÊN
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.SetHighDpiMode(HighDpiMode.SystemAware);

            // 2. Sau đó mới khởi tạo cấu hình app
            ApplicationConfiguration.Initialize();

            // 3. Cuối cùng mới Run Form
            //Application.Run(new LoginForm());
            //Application.Run(new RegisterForm());
            Application.Run(new BaseForm());
        }
    }
}