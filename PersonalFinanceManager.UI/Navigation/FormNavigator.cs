using System.Windows.Forms;

namespace PersonalFinanceManager.UI.Navigation
{
    public static class FormNavigator
    {
        private static PersonalFinanceManager.Forms.Auth.LoginForm _login;
        private static PersonalFinanceManager.Forms.Auth.RegisterForm _register;
        
        // Modules
        private static PersonalFinanceManager.Forms.Dashboard.DashboardForm _dashboard;
        private static PersonalFinanceManager.Forms.Transactions.TransactionListForm _transaction;
        private static PersonalFinanceManager.Forms.Accounts.AccountForm _account;
        private static PersonalFinanceManager.Forms.Categories.CategoryForm _category;
        private static PersonalFinanceManager.UI.Forms.Goals.GoalManagementForm _goal;
        private static PersonalFinanceManager.Forms.Reports.ReportForm _report;
        private static PersonalFinanceManager.Forms.Settings.SettingsForm _settings;

        public static void GoToLogin()
        {
            HideStandalone(_register);
            PersonalFinanceManager.UI.Forms.Shell.BaseForm.Instance.Hide();
            ShowStandalone(ref _login, () => new PersonalFinanceManager.Forms.Auth.LoginForm());
        }

        public static void GoToRegister()
        {
            HideStandalone(_login);
            PersonalFinanceManager.UI.Forms.Shell.BaseForm.Instance.Hide();
            ShowStandalone(ref _register, () => new PersonalFinanceManager.Forms.Auth.RegisterForm());
        }

        public static void GoToDashboard()
        {
            if (_dashboard == null || _dashboard.IsDisposed)
                _dashboard = new PersonalFinanceManager.Forms.Dashboard.DashboardForm();
            ShowInShell(_dashboard);
            PersonalFinanceManager.UI.Forms.Shell.BaseForm.Instance.HighlightRoute("Dashboard");
        }

        public static void GoToTransactions()
        {
            if (_transaction == null || _transaction.IsDisposed)
                _transaction = new PersonalFinanceManager.Forms.Transactions.TransactionListForm();
            ShowInShell(_transaction);
            PersonalFinanceManager.UI.Forms.Shell.BaseForm.Instance.HighlightRoute("Transactions");
        }

        public static void GoToAccounts()
        {
            if (_account == null || _account.IsDisposed)
                _account = new PersonalFinanceManager.Forms.Accounts.AccountForm();
            ShowInShell(_account);
            PersonalFinanceManager.UI.Forms.Shell.BaseForm.Instance.HighlightRoute("Accounts");
        }

        public static void GoToCategories()
        {
            if (_category == null || _category.IsDisposed)
                _category = new PersonalFinanceManager.Forms.Categories.CategoryForm();
            ShowInShell(_category);
            PersonalFinanceManager.UI.Forms.Shell.BaseForm.Instance.HighlightRoute("Categories");
        }

        public static void GoToGoals()
        {
            if (_goal == null || _goal.IsDisposed)
                _goal = new PersonalFinanceManager.UI.Forms.Goals.GoalManagementForm();
            ShowInShell(_goal);
            PersonalFinanceManager.UI.Forms.Shell.BaseForm.Instance.HighlightRoute("Goals");
        }

        public static void GoToReports()
        {
            if (_report == null || _report.IsDisposed)
                _report = new PersonalFinanceManager.Forms.Reports.ReportForm();
            ShowInShell(_report);
            PersonalFinanceManager.UI.Forms.Shell.BaseForm.Instance.HighlightRoute("Reports");
        }

        public static void GoToSettings()
        {
            if (_settings == null || _settings.IsDisposed)
                _settings = new PersonalFinanceManager.Forms.Settings.SettingsForm();
            ShowInShell(_settings);
            PersonalFinanceManager.UI.Forms.Shell.BaseForm.Instance.HighlightRoute("Settings");
        }

        private static void ShowInShell(Form f)
        {
            if (!PersonalFinanceManager.UI.Forms.Shell.BaseForm.Instance.Visible)
            {
                HideStandalone(_login);
                HideStandalone(_register);
                PersonalFinanceManager.UI.Forms.Shell.BaseForm.Instance.Show();
                PersonalFinanceManager.UI.Forms.Shell.BaseForm.Instance.BringToFront();
            }
            PersonalFinanceManager.UI.Forms.Shell.BaseForm.Instance.LoadChildForm(f);
        }

        private static void ShowStandalone<T>(ref T field, System.Func<T> factory) where T : Form
        {
            if (field == null || field.IsDisposed)
                field = factory();
            field.Show();
            field.BringToFront();
        }

        private static void HideStandalone(Form f)
        {
            if (f != null && !f.IsDisposed && f.Visible)
                f.Hide();
        }

        public static void ClearCacheAndReloadCurrent()
        {
            if (_dashboard != null && !_dashboard.IsDisposed) { _dashboard.Dispose(); _dashboard = null; }
            if (_transaction != null && !_transaction.IsDisposed) { _transaction.Dispose(); _transaction = null; }
            if (_account != null && !_account.IsDisposed) { _account.Dispose(); _account = null; }
            if (_category != null && !_category.IsDisposed) { _category.Dispose(); _category = null; }
            if (_goal != null && !_goal.IsDisposed) { _goal.Dispose(); _goal = null; }
            if (_report != null && !_report.IsDisposed) { _report.Dispose(); _report = null; }
            if (_settings != null && !_settings.IsDisposed) { _settings.Dispose(); _settings = null; }
        }

        public static void ReloadActiveForm()
        {
            var active = PersonalFinanceManager.UI.Forms.Shell.BaseForm.Instance.ActiveChildForm;
            string currentName = active?.GetType().Name;
            
            ClearCacheAndReloadCurrent();
            
            if (currentName == "DashboardForm") GoToDashboard();
            else if (currentName == "TransactionListForm") GoToTransactions();
            else if (currentName == "AccountForm") GoToAccounts();
            else if (currentName == "CategoryForm") GoToCategories();
            else if (currentName == "GoalManagementForm") GoToGoals();
            else if (currentName == "ReportForm") GoToReports();
            else if (currentName == "SettingsForm") GoToSettings();
        }
    }
}
