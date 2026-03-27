using System;
using System.Drawing;
using System.Windows.Forms;
using PersonalFinanceManager.UI.Navigation;
using PersonalFinanceManager.Infrastructure.DI;
namespace PersonalFinanceManager.UI.Forms.Shell
{
    public partial class BaseForm : Form
    {
        private static BaseForm _instance;
        public static BaseForm Instance
        {
            get
            {
                if (_instance == null || _instance.IsDisposed)
                    _instance = new BaseForm();
                return _instance;
            }
        }
        private Form _activeChildForm;
        public Form ActiveChildForm => _activeChildForm;
        // Colors
        private readonly Color NavActiveBg = Color.White;
        private readonly Color NavActiveFg = Color.FromArgb(183, 0, 82); // #B70052 Secondary
        private Color NavInactiveFg = Color.Black;
        private Color NavInactiveBg = Color.Transparent;
        private Panel navHighlighter;

        public BaseForm()
        {
            InitializeComponent();
            this.WindowState = FormWindowState.Maximized;
            this.Load += BaseForm_Load;
            this.FormClosed += (s, e) => Application.Exit();
            
            navHighlighter = new Panel();
            navHighlighter.Width = 4;
            navHighlighter.BackColor = NavActiveFg;
            this.pnlSidebar.Controls.Add(navHighlighter);
        }
        private void BaseForm_Load(object sender, EventArgs e)
        {
            var user = ServiceLocator.UserService.GetCurrentUser();
            if (user != null)
            {
                lblUserName.Text = user.FullName ?? user.Email;
            }
            // Setup Menus with Outline Icons (Segoe MDL2 Assets library pre-installed on Win10+)
            ReaLTaiizor.Controls.HopeButton[] navBtns = {
                btnNavDashboard, btnNavTransactions, btnNavAccounts, 
                btnNavCategories, btnNavGoals, btnNavReports, btnNavSettings, btnNavLogout
            };
            string[] iconCodes = { "\uE80F", "\uE8C7", "\uE8D7", "\uE8B7", "\uE8CB", "\uE9F9", "\uE713", "\uE7E8" };

            for(int i = 0; i < navBtns.Length; i++)
            {
                var b = navBtns[i];
                
                // Override background to flat gray mapping Sidebar
                b.PrimaryColor = pnlSidebar.BackColor; // Flat appearance
                
                // Logout explicit mapping
                if (b == btnNavLogout) {
                    b.ForeColor = Color.IndianRed;
                    b.TextColor = Color.IndianRed;
                }
                
                
                var iconLbl = new Label {
                    Text = iconCodes[i],
                    Font = new Font("Segoe MDL2 Assets", 13.5F),
                    ForeColor = b.ForeColor,
                    BackColor = Color.Transparent,
                    AutoSize = true,
                    Cursor = Cursors.Hand
                };
                
                // Add to sidebar tightly mapping bounding coords
                this.pnlSidebar.Controls.Add(iconLbl);
                iconLbl.BringToFront();
                iconLbl.Location = new Point(b.Left + 25, b.Top + (b.Height - iconLbl.PreferredHeight) / 2 - 2);
                
                // Synchronize colors whenever the button state trips
                b.ForeColorChanged += (s, ev) => {
                    iconLbl.ForeColor = b.ForeColor;
                    b.TextColor = b.ForeColor;
                };

                // Ensure icon overlaps trigger underlying routines seamlessly
                iconLbl.Click += (s, ev) => { 
                    if (b == btnNavDashboard) BtnNavDashboard_Click(s, ev);
                    else if (b == btnNavTransactions) BtnNavTransactions_Click(s, ev);
                    else if (b == btnNavAccounts) BtnNavAccounts_Click(s, ev);
                    else if (b == btnNavCategories) BtnNavCategories_Click(s, ev);
                    else if (b == btnNavGoals) BtnNavGoals_Click(s, ev);
                    else if (b == btnNavReports) BtnNavReports_Click(s, ev);
                    else if (b == btnNavSettings) BtnNavSettings_Click(s, ev);
                    else if (b == btnNavLogout) BtnNavLogout_Click(s, ev);
                };
                
                // Unify Hooks natively
                b.MouseEnter += (s, ev) => { b_MouseEnterWrapper(b); };
                b.MouseLeave += (s, ev) => { b_MouseLeaveWrapper(b); };
                iconLbl.MouseEnter += (s, ev) => { b_MouseEnterWrapper(b); };
                iconLbl.MouseLeave += (s, ev) => { b_MouseLeaveWrapper(b); };
            }
            
            // Set Dashboard active visually but loading is handled by FormNavigator
            SetActiveRoute(btnNavDashboard);
            
            PersonalFinanceManager.Common.Helpers.ConfigHelper.LanguageChanged += (s, ev) => 
            {
                try {
                    this.Invoke(new Action(() => UpdateTranslations()));
                } catch { UpdateTranslations(); }
            };
            UpdateTranslations();

            PersonalFinanceManager.Common.Helpers.ConfigHelper.ThemeChanged += (s, ev) =>
            {
                if (this.IsHandleCreated) this.Invoke(new Action(() => {
                    ApplyTheme();
                }));
            };
            ApplyTheme();
        }

        private void ApplyTheme()
        {
            bool isDark = PersonalFinanceManager.Common.Helpers.ThemeHelper.IsDarkMode;
            
            this.BackColor = PersonalFinanceManager.Common.Helpers.ThemeHelper.Background;
            pnlSidebar.BackColor = isDark ? Color.FromArgb(28, 28, 36) : Color.FromArgb(238, 239, 242);
            pnlTopAppBar.BackColor = PersonalFinanceManager.Common.Helpers.ThemeHelper.Background;
            pnlContent.BackColor = PersonalFinanceManager.Common.Helpers.ThemeHelper.Background;

            NavInactiveFg = isDark ? Color.FromArgb(180, 180, 190) : Color.FromArgb(60, 60, 70);
            
            lblUserName.ForeColor = PersonalFinanceManager.Common.Helpers.ThemeHelper.Text;
            
            // Update sidebar buttons
            ReaLTaiizor.Controls.HopeButton[] navBtns = {
                btnNavDashboard, btnNavTransactions, btnNavAccounts, 
                btnNavCategories, btnNavGoals, btnNavReports, btnNavSettings, btnNavLogout
            };

            foreach (var b in navBtns)
            {
                b.PrimaryColor = pnlSidebar.BackColor;
                // If the button is currently active, it will have special colors from SetActiveRoute
            }
            
            ResetNavButtons();
            
            // Find active route and re-apply
            HighlightRouteFromActiveForm();
        }

        private void HighlightRouteFromActiveForm()
        {
            if (_activeChildForm == null) return;
            string formName = _activeChildForm.GetType().Name;
            if (formName.Contains("Dashboard")) SetActiveRoute(btnNavDashboard);
            else if (formName.Contains("Transaction")) SetActiveRoute(btnNavTransactions);
            else if (formName.Contains("Account")) SetActiveRoute(btnNavAccounts);
            else if (formName.Contains("Category")) SetActiveRoute(btnNavCategories);
            else if (formName.Contains("Goal")) SetActiveRoute(btnNavGoals);
            else if (formName.Contains("Report")) SetActiveRoute(btnNavReports);
            else if (formName.Contains("Settings")) SetActiveRoute(btnNavSettings);
        }

        private void UpdateTranslations()
        {
            var t = new Func<string, string>(PersonalFinanceManager.Common.Helpers.ConfigHelper.Translate);

            if (lblLogo != null) lblLogo.Text = t("Executive");
            if (lblLogoSubtitle != null) lblLogoSubtitle.Text = t("PREMIUM WORKSPACE");

            btnNavDashboard.Text = $"          {t("Dashboard")}";
            btnNavTransactions.Text = $"          {t("Transactions")}";
            btnNavAccounts.Text = $"          {t("Accounts")}";
            btnNavCategories.Text = $"          {t("Categories")}";
            btnNavGoals.Text = $"          {t("Goals")}";
            btnNavReports.Text = $"          {t("Reports")}";
            btnNavSettings.Text = $"          {t("Settings")}";
            btnNavLogout.Text = $"          {t("Logout")}";
        }

        private void b_MouseEnterWrapper(ReaLTaiizor.Controls.HopeButton b) {
            if (b.ForeColor != NavActiveFg && b != btnNavLogout) {
                b.PrimaryColor = PersonalFinanceManager.Common.Helpers.ThemeHelper.IsDarkMode ? Color.FromArgb(50, 60, 80) : Color.FromArgb(220, 230, 245);
                b.ForeColor = PersonalFinanceManager.Common.Helpers.ThemeHelper.IsDarkMode ? Color.White : Color.FromArgb(20, 20, 30);
                b.TextColor = b.ForeColor;
            } else if (b == btnNavLogout) {
                b.PrimaryColor = Color.FromArgb(255, 230, 230);
            }
        }
        
        private void b_MouseLeaveWrapper(ReaLTaiizor.Controls.HopeButton b) {
            if (b.ForeColor != NavActiveFg && b != btnNavLogout) {
                b.PrimaryColor = pnlSidebar.BackColor;
                b.ForeColor = NavInactiveFg;
                b.TextColor = NavInactiveFg;
            } else if (b == btnNavLogout) {
                b.PrimaryColor = pnlSidebar.BackColor;
                b.ForeColor = Color.IndianRed;
                b.TextColor = Color.IndianRed;
            }
        }
        public void LoadChildForm(Form childForm)
        {
            if (_activeChildForm != null)
            {
                _activeChildForm.Hide();
            }
            
            _activeChildForm = childForm;
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;
            childForm.AutoScroll = true;
            this.pnlContent.Controls.Add(childForm);
            this.pnlContent.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();
        }
        private void ResetNavButtons()
        {
            ReaLTaiizor.Controls.HopeButton[] btns = { 
                btnNavDashboard, btnNavTransactions, btnNavAccounts, 
                btnNavCategories, btnNavGoals, btnNavReports, btnNavSettings 
            };
            foreach (var b in btns)
            {
                b.PrimaryColor = pnlSidebar.BackColor;
                b.ForeColor = NavInactiveFg;
                b.TextColor = NavInactiveFg;
                b.Font = new Font("Manrope", 11F, FontStyle.Bold);
            }
        }

        public void SetActiveRoute(ReaLTaiizor.Controls.HopeButton activeBtn)
        {
            ResetNavButtons();
            activeBtn.PrimaryColor = PersonalFinanceManager.Common.Helpers.ThemeHelper.IsDarkMode ? Color.FromArgb(40, 45, 60) : Color.FromArgb(230, 245, 255);
            activeBtn.ForeColor = NavActiveFg;
            activeBtn.TextColor = NavActiveFg;

            if (navHighlighter != null)
            {
                navHighlighter.Height = activeBtn.Height;
                navHighlighter.Top = activeBtn.Top;
                navHighlighter.Left = 0;
                navHighlighter.BringToFront();
            }
        }
        public void HighlightRoute(string routeName)
        {
            switch (routeName)
            {
                case "Dashboard": SetActiveRoute(btnNavDashboard); break;
                case "Transactions": SetActiveRoute(btnNavTransactions); break;
                case "Accounts": SetActiveRoute(btnNavAccounts); break;
                case "Categories": SetActiveRoute(btnNavCategories); break;
                case "Goals": SetActiveRoute(btnNavGoals); break;
                case "Reports": SetActiveRoute(btnNavReports); break;
                case "Settings": SetActiveRoute(btnNavSettings); break;
            }
        }
        private void BtnNavDashboard_Click(object sender, EventArgs e)
        {
            SetActiveRoute(btnNavDashboard);
            FormNavigator.GoToDashboard();
        }
        private void BtnNavTransactions_Click(object sender, EventArgs e)
        {
            SetActiveRoute(btnNavTransactions);
            FormNavigator.GoToTransactions();
        }
        private void BtnNavAccounts_Click(object sender, EventArgs e)
        {
            SetActiveRoute(btnNavAccounts);
            FormNavigator.GoToAccounts();
        }
        private void BtnNavCategories_Click(object sender, EventArgs e)
        {
            SetActiveRoute(btnNavCategories);
            FormNavigator.GoToCategories();
        }
        private void BtnNavGoals_Click(object sender, EventArgs e)
        {
            SetActiveRoute(btnNavGoals);
            FormNavigator.GoToGoals();
        }
        private void BtnNavReports_Click(object sender, EventArgs e)
        {
            SetActiveRoute(btnNavReports);
            FormNavigator.GoToReports();
        }
        private void BtnNavSettings_Click(object sender, EventArgs e)
        {
            SetActiveRoute(btnNavSettings);
            FormNavigator.GoToSettings();
        }
        private void BtnNavLogout_Click(object sender, EventArgs e)
        {
            FormNavigator.GoToLogin();
        }
        private void btnCloseForm_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
