using System.Windows.Forms;

namespace PersonalFinanceManager.UI.Navigation
{
    /// <summary>
    /// Quản lý navigation toàn app — đảm bảo chỉ 1 form visible tại 1 thời điểm.
    /// Mỗi form chỉ được khởi tạo 1 lần duy nhất (singleton per type).
    /// </summary>
    public static class FormNavigator
    {
        // ── Singleton instances ───────────────────────────────────────────────────
        private static Forms.Auth.LoginForm _login;
        private static Forms.Dashboard.DashboardForm _dashboard;
        private static Forms.Transactions.TransactionListForm _transaction;
        private static Forms.Invoices.InvoiceListForm _invoiceList;
        private static Forms.Invoices.CreateInvoiceForm _createInvoice;
        private static Forms.MyWallet.MyWalletForm _myWallet;
        private static Forms.Settings.SettingsForm _settings;

        // ═════════════════════════════════════════════════════════════════════════
        // PUBLIC API
        // ═════════════════════════════════════════════════════════════════════════

        public static void GoToLogin()
        {
            DestroyAndNull(ref _dashboard);
            DestroyAndNull(ref _transaction);
            DestroyAndNull(ref _invoiceList);
            DestroyAndNull(ref _createInvoice);
            DestroyAndNull(ref _myWallet);
            DestroyAndNull(ref _settings);
            Show(ref _login, () => new Forms.Auth.LoginForm());
        }

        public static void GoToDashboard()
            => Show(ref _dashboard, () => new Forms.Dashboard.DashboardForm());

        public static void GoToTransactions()
            => Show(ref _transaction, () => new Forms.Transactions.TransactionListForm());

        public static void GoToInvoices()
        {
            // Khi quay về list, hủy CreateInvoice để data luôn fresh
            DestroyAndNull(ref _createInvoice);
            Show(ref _invoiceList, () => new Forms.Invoices.InvoiceListForm());
        }

        public static void GoToCreateInvoice()
        {
            // Tạo mới mỗi lần để số invoice unique
            DestroyAndNull(ref _createInvoice);
            Show(ref _createInvoice, () => new Forms.Invoices.CreateInvoiceForm());
        }

        public static void GoToMyWallet()
            => Show(ref _myWallet, () => new Forms.MyWallet.MyWalletForm());

        public static void GoToSettings()
            => Show(ref _settings, () => new Forms.Settings.SettingsForm());

        // ═════════════════════════════════════════════════════════════════════════
        // CORE — ẩn TẤT CẢ form khác, chỉ hiện form target
        // ═════════════════════════════════════════════════════════════════════════

        private static void Show<T>(ref T field, System.Func<T> factory) where T : Form
        {
            if (field == null || field.IsDisposed)
                field = factory();

            HideAll(except: field);

            field.Show();
            field.BringToFront();
            field.WindowState = FormWindowState.Maximized;
        }

        private static void HideAll(Form except)
        {
            SafeHide(_login, except);
            SafeHide(_dashboard, except);
            SafeHide(_transaction, except);
            SafeHide(_invoiceList, except);
            SafeHide(_createInvoice, except);
            SafeHide(_myWallet, except);
            SafeHide(_settings, except);
        }

        private static void SafeHide(Form f, Form except)
        {
            if (f != null && !f.IsDisposed && f != except && f.Visible)
                f.Hide();
        }

        private static void DestroyAndNull<T>(ref T field) where T : Form
        {
            if (field != null && !field.IsDisposed)
            {
                field.Hide();
                field.Dispose();
            }
            field = null;
        }
    }
}