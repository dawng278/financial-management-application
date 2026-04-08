using System;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using PersonalFinanceManager.Infrastructure.DI;
namespace PersonalFinanceManager.Forms.Settings
{
    public partial class    SettingsForm : Form
    {
        public SettingsForm()
        {
            InitializeComponent();
            this.Load += SettingsForm_Load;
            
            PersonalFinanceManager.Common.Helpers.ConfigHelper.LanguageChanged += (s, ev) => 
            {
                if (this.IsHandleCreated) this.Invoke(new Action(() => {
                    UpdateTranslations();
                }));
            };

            PersonalFinanceManager.Common.Helpers.ConfigHelper.ThemeChanged += (s, ev) =>
            {
                if (this.IsHandleCreated) this.Invoke(new Action(() => {
                    ApplyTheme();
                    this.Refresh(); // Force redraw of custom painted cards
                }));
            };

            ApplyResponsiveLayout();
        }

        private void UpdateTranslations()
        {
            var t = new Func<string, string>(PersonalFinanceManager.Common.Helpers.ConfigHelper.Translate);

            // Using reflection or exact name matches to update labels
            var lblPageTitle = this.Controls.Find("lblPageTitle", true).Length > 0 ? this.Controls.Find("lblPageTitle", true)[0] as Label : null;
            if (lblPageTitle != null) lblPageTitle.Text = t("Settings");

            var lblPageSub = this.Controls.Find("lblPageSub", true).Length > 0 ? this.Controls.Find("lblPageSub", true)[0] as Label : null;
            if (lblPageSub != null) lblPageSub.Text = t("Manage your account preferences and system configuration.");

            var btnEditProfile = this.Controls.Find("btnEditProfile", true).Length > 0 ? this.Controls.Find("btnEditProfile", true)[0] as ReaLTaiizor.Controls.HopeButton : null;
            if (btnEditProfile != null) btnEditProfile.Text = t("Edit Profile");

            var lblEmailLbl = this.Controls.Find("lblEmailLbl", true).Length > 0 ? this.Controls.Find("lblEmailLbl", true)[0] as Label : null;
            if (lblEmailLbl != null) lblEmailLbl.Text = t("EMAIL ADDRESS");

            var lblPhoneLbl = this.Controls.Find("lblPhoneLbl", true).Length > 0 ? this.Controls.Find("lblPhoneLbl", true)[0] as Label : null;
            if (lblPhoneLbl != null) lblPhoneLbl.Text = t("PHONE NUMBER");

            var lblLocLbl = this.Controls.Find("lblLocLbl", true).Length > 0 ? this.Controls.Find("lblLocLbl", true)[0] as Label : null;
            if (lblLocLbl != null) lblLocLbl.Text = t("LOCATION");

            var lblTimeLbl = this.Controls.Find("lblTimeLbl", true).Length > 0 ? this.Controls.Find("lblTimeLbl", true)[0] as Label : null;
            if (lblTimeLbl != null) lblTimeLbl.Text = t("TIMEZONE");

            var lblAppTitle = this.Controls.Find("lblAppTitle", true).Length > 0 ? this.Controls.Find("lblAppTitle", true)[0] as Label : null;
            if (lblAppTitle != null) lblAppTitle.Text = t("Appearance");

            var lblLightMode = this.Controls.Find("lblLightMode", true).Length > 0 ? this.Controls.Find("lblLightMode", true)[0] as Label : null;
            if (lblLightMode != null) lblLightMode.Text = t("Light Mode");

            var lblDarkMode = this.Controls.Find("lblDarkMode", true).Length > 0 ? this.Controls.Find("lblDarkMode", true)[0] as Label : null;
            if (lblDarkMode != null) lblDarkMode.Text = t("Dark Mode");

            var lblSecTitle = this.Controls.Find("lblSecTitle", true).Length > 0 ? this.Controls.Find("lblSecTitle", true)[0] as Label : null;
            if (lblSecTitle != null) lblSecTitle.Text = t("Security & Privacy");

            var lblChangePass = this.Controls.Find("lblChangePass", true).Length > 0 ? this.Controls.Find("lblChangePass", true)[0] as Label : null;
            if (lblChangePass != null) lblChangePass.Text = t("CHANGE PASSWORD");

            var txtCurrentPass = this.Controls.Find("txtCurrentPass", true).FirstOrDefault() as ReaLTaiizor.Controls.HopeTextBox;
            if (txtCurrentPass != null) txtCurrentPass.Hint = t("Enter current password");

            var txtNewPass = this.Controls.Find("txtNewPass", true).FirstOrDefault() as ReaLTaiizor.Controls.HopeTextBox;
            if (txtNewPass != null) txtNewPass.Hint = t("Enter new password");

            var txtConfirmPass = this.Controls.Find("txtConfirmPass", true).FirstOrDefault() as ReaLTaiizor.Controls.HopeTextBox;
            if (txtConfirmPass != null) txtConfirmPass.Hint = t("Confirm new password");

            var btnUpdatePassword = this.Controls.Find("btnUpdatePassword", true).FirstOrDefault() as ReaLTaiizor.Controls.HopeButton;
            if (btnUpdatePassword != null) btnUpdatePassword.Text = t("Update Password");


            var lblLang = this.Controls.Find("lblLang", true).Length > 0 ? this.Controls.Find("lblLang", true)[0] as Label : null;
            if (lblLang != null) lblLang.Text = t("LANGUAGE");

            var lblCurr = this.Controls.Find("lblCurr", true).Length > 0 ? this.Controls.Find("lblCurr", true)[0] as Label : null;
            if (lblCurr != null) lblCurr.Text = t("CURRENCY FORMAT");

            var lblExport = this.Controls.Find("lblExport", true).Length > 0 ? this.Controls.Find("lblExport", true)[0] as Label : null;
            if (lblExport != null) lblExport.Text = t("Export Account Data");

            var btnFactoryReset = this.Controls.Find("btnFactoryReset", true).Length > 0 ? this.Controls.Find("btnFactoryReset", true)[0] as ReaLTaiizor.Controls.HopeButton : null;
            if (btnFactoryReset != null) btnFactoryReset.Text = t("Factory Reset");

            // Privacy & Security extras
            var lblPrivacyTitle = this.Controls.Find("lblPrivacyTitle", true).FirstOrDefault() as Label;
            if (lblPrivacyTitle != null) lblPrivacyTitle.Text = t("Account Privacy");

            var lblPrivacyDesc = this.Controls.Find("lblPrivacyDesc", true).FirstOrDefault() as Label;
            if (lblPrivacyDesc != null) lblPrivacyDesc.Text = t("Making your profile private will hide your transaction summaries from shared circles.");

            var lbl2FA = this.Controls.Find("lbl2FA", true).FirstOrDefault() as Label;
            if (lbl2FA != null) lbl2FA.Text = t("Two-Factor \nAuthentication");

            var lbl2FADesc = this.Controls.Find("lbl2FADesc", true).FirstOrDefault() as Label;
            if (lbl2FADesc != null) lbl2FADesc.Text = t("Add an extra layer of security to your account by requiring a verification code.");

            // Notifications
            var lblNotifTitle = this.Controls.Find("lblNotifTitle", true).FirstOrDefault() as Label;
            if (lblNotifTitle != null) lblNotifTitle.Text = t("Notifications");

            var lblDepAlert = this.Controls.Find("lblDepAlert", true).FirstOrDefault() as Label;
            if (lblDepAlert != null) lblDepAlert.Text = t("Deposit Alerts");

            var lblDepDesc = this.Controls.Find("lblDepDesc", true).FirstOrDefault() as Label;
            if (lblDepDesc != null) lblDepDesc.Text = t("Notify when funds arrive");

            var lblBudgAlert = this.Controls.Find("lblBudgAlert", true).FirstOrDefault() as Label;
            if (lblBudgAlert != null) lblBudgAlert.Text = t("Budget Warnings");

            var lblBudgDesc = this.Controls.Find("lblBudgDesc", true).FirstOrDefault() as Label;
            if (lblBudgDesc != null) lblBudgDesc.Text = t("When limits are reached");

            var lblMonthAlert = this.Controls.Find("lblMonthAlert", true).FirstOrDefault() as Label;
            if (lblMonthAlert != null) lblMonthAlert.Text = t("Monthly Reports");

            var lblMonthDesc = this.Controls.Find("lblMonthDesc", true).FirstOrDefault() as Label;
            if (lblMonthDesc != null) lblMonthDesc.Text = t("Summary of your finances");

            var btnConfigEmail = this.Controls.Find("btnConfigEmail", true).FirstOrDefault() as ReaLTaiizor.Controls.HopeButton;
            if (btnConfigEmail != null) btnConfigEmail.Text = t("Configure Email Alerts");
        }

        private void ApplyResponsiveLayout()
        {
            // Security Password Fields Stretch
            txtCurrentPass.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            txtNewPass.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            txtConfirmPass.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            btnUpdatePassword.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;

            pnlPrivacy.Anchor = AnchorStyles.Top | AnchorStyles.Right;

            // Layout Split geometry dynamically centering a 2x2 symmetrical grid
            this.SizeChanged += (s, e) => {
                int margin = 40;
                int gap = 40;
                int colW = (this.ClientSize.Width - margin * 2 - gap) / 2;
                if (colW < 300) colW = 300;

                // Adjust the 4 Main Cards
                pnlProfile.Width = colW;
                pnlSecurity.Width = colW;
                
                pnlAppearance.Width = colW;
                pnlAppearance.Left = pnlProfile.Right + gap;

                // Dynamically slice the 2-column fields inside Profile Card
                int profileGap = 20;
                int profileFieldW = (colW - 40 - profileGap) / 2;

                txtEmail.Width = profileFieldW;
                txtPhone.Width = profileFieldW;
                txtPhone.Left = txtEmail.Right + profileGap;
                var lblPhoneLbl = this.Controls.Find("lblPhoneLbl", true).FirstOrDefault() as Label;
                if (lblPhoneLbl != null) lblPhoneLbl.Left = txtPhone.Left;

                txtLocation.Width = profileFieldW;
                txtTimezone.Width = profileFieldW;
                txtTimezone.Left = txtLocation.Right + profileGap;
                
                var lblTimeLbl = this.Controls.Find("lblTimeLbl", true).FirstOrDefault() as Label;
                if (lblTimeLbl != null) lblTimeLbl.Left = txtTimezone.Left;

                // Move Appearance dark mode card safely depending on width
                var pnlLightMode = this.Controls.Find("pnlLightMode", true).FirstOrDefault() as Panel;
                var pnlDarkMode = this.Controls.Find("pnlDarkMode", true).FirstOrDefault() as Panel;
                var lblDarkMode = this.Controls.Find("lblDarkMode", true).FirstOrDefault() as Label;
                
                if (pnlLightMode != null && pnlDarkMode != null && lblDarkMode != null)
                {
                    pnlDarkMode.Left = pnlLightMode.Right + profileGap;
                    lblDarkMode.Left = pnlDarkMode.Left + (pnlDarkMode.Width / 2) - (lblDarkMode.Width / 2);
                }

                // Invalidate for clean paint
                pnlProfile.Invalidate();
                pnlSecurity.Invalidate();
                pnlAppearance.Invalidate();
            };
        }

        private void SettingsForm_Load(object sender, EventArgs e)
        {
            ApplyTheme();
            
            // Clear default text to show hints
            var txtCurrentPass = this.Controls.Find("txtCurrentPass", true).FirstOrDefault() as ReaLTaiizor.Controls.HopeTextBox;
            var txtNewPass = this.Controls.Find("txtNewPass", true).FirstOrDefault() as ReaLTaiizor.Controls.HopeTextBox;
            var txtConfirmPass = this.Controls.Find("txtConfirmPass", true).FirstOrDefault() as ReaLTaiizor.Controls.HopeTextBox;
            if (txtCurrentPass != null) txtCurrentPass.Text = "";
            if (txtNewPass != null) txtNewPass.Text = "";
            if (txtConfirmPass != null) txtConfirmPass.Text = "";
            
            // Apply Premium Aesthetics to Designer Controls
            foreach (Control c in this.Controls)
            {
                if (c is Panel p && p.BackColor == Color.White)
                {
                    p.BackColor = Color.Transparent;
                    p.Paint += Card_Paint;
                }
            }

            // Bind Button Themes
            var primaryColor = Color.FromArgb(183, 0, 82);
            var darkTheme = Color.FromArgb(40, 45, 60);

            var btnEditProfile = this.Controls.Find("btnEditProfile", true).FirstOrDefault() as ReaLTaiizor.Controls.HopeButton;
            var btnUpdatePassword = this.Controls.Find("btnUpdatePassword", true).FirstOrDefault() as ReaLTaiizor.Controls.HopeButton;
            var btnFactoryReset = this.Controls.Find("btnFactoryReset", true).FirstOrDefault() as ReaLTaiizor.Controls.HopeButton;

            Action<ReaLTaiizor.Controls.HopeButton> RoundButton = (btn) => {
                if (btn == null) return;
                var setRgn = new Action(() => btn.Region = new Region(RoundedRect(new Rectangle(0, 0, btn.Width, btn.Height), 6)));
                setRgn();
                btn.SizeChanged += (s, ev) => setRgn();
            };

            if (btnEditProfile != null) { btnEditProfile.PrimaryColor = darkTheme; btnEditProfile.Cursor = Cursors.Hand; btnEditProfile.Click += BtnEditProfile_Click; RoundButton(btnEditProfile); }
            if (btnUpdatePassword != null) { btnUpdatePassword.PrimaryColor = primaryColor; btnUpdatePassword.Cursor = Cursors.Hand; RoundButton(btnUpdatePassword); }
            if (btnFactoryReset != null) { btnFactoryReset.PrimaryColor = Color.FromArgb(200, 30, 50); btnFactoryReset.Cursor = Cursors.Hand; RoundButton(btnFactoryReset); }

            // Bind Interactive Light/Dark Pnl Handlers
            var pnlLightMode = this.Controls.Find("pnlLightMode", true).FirstOrDefault() as Panel;
            var pnlDarkMode = this.Controls.Find("pnlDarkMode", true).FirstOrDefault() as Panel;
            var lblLightMode = this.Controls.Find("lblLightMode", true).FirstOrDefault() as Label;
            var lblDarkMode = this.Controls.Find("lblDarkMode", true).FirstOrDefault() as Label;

            if (pnlLightMode != null) { pnlLightMode.Cursor = Cursors.Hand; pnlLightMode.Paint += ThemeBox_Paint; pnlLightMode.Click += Theme_Click; }
            if (pnlDarkMode != null) { pnlDarkMode.Cursor = Cursors.Hand; pnlDarkMode.Paint += ThemeBox_Paint; pnlDarkMode.Click += Theme_Click; }
            if (lblLightMode != null) { lblLightMode.Cursor = Cursors.Hand; lblLightMode.Click += Theme_Click; }
            if (lblDarkMode != null) { lblDarkMode.Cursor = Cursors.Hand; lblDarkMode.Click += Theme_Click; }

            // Bind Settings
            var cboCurr = this.Controls.Find("cboCurr", true).FirstOrDefault() as ReaLTaiizor.Controls.HopeComboBox;
            var cboLang = this.Controls.Find("cboLang", true).FirstOrDefault() as ReaLTaiizor.Controls.HopeComboBox;
            if (cboCurr != null)
            {
                cboCurr.Items.Clear();
                cboCurr.Items.Add("VND (đ) - Đồng");
                cboCurr.Items.Add("USD ($) - Dollar");
                cboCurr.Items.Add("EUR (€) - Euro");
                cboCurr.SelectedItem = PersonalFinanceManager.Common.Helpers.ConfigHelper.GlobalCurrency == "USD" ? "USD ($) - Dollar" : (PersonalFinanceManager.Common.Helpers.ConfigHelper.GlobalCurrency == "EUR" ? "EUR (€) - Euro" : "VND (đ) - Đồng");
                cboCurr.SelectedIndexChanged += CboCurr_SelectedIndexChanged;
            }

            if (cboLang != null)
            {
                cboLang.Items.Clear();
                cboLang.Items.Add("English (EN)");
                cboLang.Items.Add("Tiếng Việt (VI)");
                cboLang.SelectedItem = PersonalFinanceManager.Common.Helpers.ConfigHelper.GlobalLanguage == "VI" ? "Tiếng Việt (VI)" : "English (EN)";
                cboLang.SelectedIndexChanged += CboLang_SelectedIndexChanged;
            }

            try
            {
                var u = ServiceLocator.UserService.GetCurrentUser();
                if (u != null)
                {
                    var lblProfileName = this.Controls.Find("lblProfileName", true).FirstOrDefault() as Label;
                    var txtEmail = this.Controls.Find("txtEmail", true).FirstOrDefault() as ReaLTaiizor.Controls.HopeTextBox;
                    if (lblProfileName != null) lblProfileName.Text = u.FullName ?? u.Username;
                    if (txtEmail != null) txtEmail.Text = u.Email ?? "";
                }
            }
            catch { }
            
            UpdateTranslations();
        }

        private void ApplyTheme()
        {
            PersonalFinanceManager.Common.Helpers.ThemeHelper.ApplyTheme(this);
            
            // Overrides for specific labels
            var lblPageTitle = this.Controls.Find("lblPageTitle", true).FirstOrDefault() as Label;
            if (lblPageTitle != null) lblPageTitle.ForeColor = PersonalFinanceManager.Common.Helpers.ThemeHelper.Text;
            
            var lblPageSub = this.Controls.Find("lblPageSub", true).FirstOrDefault() as Label;
            if (lblPageSub != null) lblPageSub.ForeColor = PersonalFinanceManager.Common.Helpers.ThemeHelper.SubText;

            // SYNC ALL TOGGLES BACKGROUND WITH THE PARENT CARD (Anti-WhiteBox Fix)
            SyncTogglesBackground(this);
        }

        private void SyncTogglesBackground(Control parent)
        {
            foreach (Control c in parent.Controls)
            {
                if (c is ReaLTaiizor.Controls.HopeToggle tg)
                {
                    tg.BackColor = PersonalFinanceManager.Common.Helpers.ThemeHelper.CardBackground;
                    tg.BaseColor = PersonalFinanceManager.Common.Helpers.ThemeHelper.CardBackground;
                    tg.BaseColorA = PersonalFinanceManager.Common.Helpers.ThemeHelper.IsDarkMode ? Color.FromArgb(45, 45, 60) : Color.FromArgb(220, 223, 230);
                    tg.HeadColorB = PersonalFinanceManager.Common.Helpers.ThemeHelper.CardBackground;
                }
                else if (c is ReaLTaiizor.Controls.HopeSwitch sw)
                {
                    sw.BackColor = PersonalFinanceManager.Common.Helpers.ThemeHelper.CardBackground;
                    sw.BaseColor = PersonalFinanceManager.Common.Helpers.ThemeHelper.CardBackground;
                }
                if (c.HasChildren)
                {
                    SyncTogglesBackground(c);
                }
            }
        }

        private void CboCurr_SelectedIndexChanged(object sender, EventArgs e)
        {
            var cbo = sender as ReaLTaiizor.Controls.HopeComboBox;
            if (cbo == null || cbo.SelectedItem == null) return;
            string cur = "VND";
            if (cbo.SelectedItem.ToString().Contains("USD")) cur = "USD";
            if (cbo.SelectedItem.ToString().Contains("EUR")) cur = "EUR";
            PersonalFinanceManager.Common.Helpers.ConfigHelper.SaveRates(PersonalFinanceManager.Common.Helpers.ConfigHelper.RateUsdToVnd, PersonalFinanceManager.Common.Helpers.ConfigHelper.RateEurToVnd, cur);
            var t = new Func<string, string>(PersonalFinanceManager.Common.Helpers.ConfigHelper.Translate);
            MessageBox.Show(string.Format(t("Currency format changed to {0}."), cur), t("Settings Applied"), MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void CboLang_SelectedIndexChanged(object sender, EventArgs e)
        {
            var cbo = sender as ReaLTaiizor.Controls.HopeComboBox;
            if (cbo == null || cbo.SelectedItem == null) return;
            string lang = cbo.SelectedItem.ToString().Contains("VI") ? "VI" : "EN";
            PersonalFinanceManager.Common.Helpers.ConfigHelper.SaveLanguage(lang);
        }

        private void BtnEditProfile_Click(object sender, EventArgs e)
        {
            var txtEmail = this.Controls.Find("txtEmail", true).FirstOrDefault() as ReaLTaiizor.Controls.HopeTextBox;
            var u = ServiceLocator.UserService.GetCurrentUser();
            if (u != null && txtEmail != null)
            {
                var t = new Func<string, string>(PersonalFinanceManager.Common.Helpers.ConfigHelper.Translate);
                u.Email = txtEmail.Text;
                bool ok = ServiceLocator.UserService.UpdateProfile(u, null);
                if (ok) MessageBox.Show(t("Profile successfully saved."), t("Profile"), MessageBoxButtons.OK, MessageBoxIcon.Information);
                else MessageBox.Show(t("Failed to save profile. Email might be in use."), t("Error"), MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void Theme_Click(object sender, EventArgs e)
        {
            string ctrlName = (sender as Control)?.Name ?? "";
            string theme = ctrlName.Contains("Light") ? "LIGHT" : "DARK";
            PersonalFinanceManager.Common.Helpers.ConfigHelper.SaveTheme(theme);
            
            this.Refresh(); // Refresh the theme boxes
        }

        private void ThemeBox_Paint(object sender, PaintEventArgs e)
        {
            var pnl = sender as Panel;
            var g = e.Graphics;
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;

            using (var path = RoundedRect(new Rectangle(0, 0, pnl.Width - 1, pnl.Height - 1), 10))
            {
                bool isThisOne = (pnl.Name == "pnlLightMode" && !PersonalFinanceManager.Common.Helpers.ThemeHelper.IsDarkMode) ||
                                (pnl.Name == "pnlDarkMode" && PersonalFinanceManager.Common.Helpers.ThemeHelper.IsDarkMode);

                g.FillPath(new SolidBrush(pnl.Name == "pnlLightMode" ? Color.FromArgb(245,245,250) : Color.FromArgb(25,25,35)), path);
                
                if (isThisOne)
                {
                    g.DrawPath(new Pen(PersonalFinanceManager.Common.Helpers.ThemeHelper.Primary, 2), path);
                }
                else
                {
                    g.DrawPath(new Pen(Color.FromArgb(200, 200, 210), 1), path);
                }

                // Draw pseudo UI inside
                g.FillRectangle(new SolidBrush(pnl.Name == "pnlLightMode" ? Color.White : Color.FromArgb(40,45,60)), 15, 10, 40, pnl.Height - 20); // Sidebar pseudo
                g.FillRectangle(new SolidBrush(pnl.Name == "pnlLightMode" ? Color.FromArgb(220,225,235) : Color.FromArgb(50,55,75)), 65, 20, pnl.Width - 85, 15); // Line pseudo
                g.FillRectangle(new SolidBrush(pnl.Name == "pnlLightMode" ? Color.FromArgb(220,225,235) : Color.FromArgb(50,55,75)), 65, 45, pnl.Width - 110, 15); // Line pseudo
            }
        }

        private void Card_Paint(object sender, PaintEventArgs e)
        {
            var pnl = sender as Panel;
            var g = e.Graphics;
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
            using (var path = RoundedRect(new Rectangle(0, 0, pnl.Width - 5, pnl.Height - 5), 15))
            {
                // Soft shadow offset if light mode
                if (!PersonalFinanceManager.Common.Helpers.ThemeHelper.IsDarkMode)
                    g.FillPath(new SolidBrush(Color.FromArgb(10, 0, 0, 0)), RoundedRect(new Rectangle(3, 3, pnl.Width - 5, pnl.Height - 5), 15));
                
                g.FillPath(new SolidBrush(PersonalFinanceManager.Common.Helpers.ThemeHelper.CardBackground), path);
                g.DrawPath(new Pen(PersonalFinanceManager.Common.Helpers.ThemeHelper.Border, 1), path); // Crisp border
            }
        }

        private static System.Drawing.Drawing2D.GraphicsPath RoundedRect(Rectangle r, int radius)
        {
            var path = new System.Drawing.Drawing2D.GraphicsPath();
            int d = radius * 2;
            path.AddArc(r.X, r.Y, d, d, 180, 90);
            path.AddArc(r.Right - d, r.Y, d, d, 270, 90);
            path.AddArc(r.Right - d, r.Bottom - d, d, d, 0, 90);
            path.AddArc(r.X, r.Bottom - d, d, d, 90, 90);
            path.CloseFigure();
            return path;
        }

        private void btnUpdatePassword_Click(object sender, EventArgs e)
        {
            var txtCurrent = this.Controls.Find("txtCurrentPass", true).FirstOrDefault() as ReaLTaiizor.Controls.HopeTextBox;
            var txtNew = this.Controls.Find("txtNewPass", true).FirstOrDefault() as ReaLTaiizor.Controls.HopeTextBox;
            var txtConfirm = this.Controls.Find("txtConfirmPass", true).FirstOrDefault() as ReaLTaiizor.Controls.HopeTextBox;
            
            if (txtCurrent == null || txtNew == null || txtConfirm == null) return;

            var u = ServiceLocator.UserService.GetCurrentUser();
            if (u == null) return;

            if (u.PasswordHash != txtCurrent.Text && !string.IsNullOrWhiteSpace(txtCurrent.Text))
            {
                MessageBox.Show(PersonalFinanceManager.Common.Helpers.ConfigHelper.Translate("Incorrect current password."), 
                                PersonalFinanceManager.Common.Helpers.ConfigHelper.Translate("Error"), 
                                MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (txtNew.Text != txtConfirm.Text)
            {
                MessageBox.Show(PersonalFinanceManager.Common.Helpers.ConfigHelper.Translate("New passwords do not match."), 
                                PersonalFinanceManager.Common.Helpers.ConfigHelper.Translate("Error"), 
                                MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (string.IsNullOrWhiteSpace(txtNew.Text) || txtNew.Text.Length < 4)
            {
                MessageBox.Show(PersonalFinanceManager.Common.Helpers.ConfigHelper.Translate("Password is too weak. Must be at least 4 characters."), 
                                PersonalFinanceManager.Common.Helpers.ConfigHelper.Translate("Security"), 
                                MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (ServiceLocator.UserService.UpdateProfile(u, txtNew.Text))
            {
                MessageBox.Show(PersonalFinanceManager.Common.Helpers.ConfigHelper.Translate("Password updated successfully. Logging out..."), 
                                PersonalFinanceManager.Common.Helpers.ConfigHelper.Translate("Success"), 
                                MessageBoxButtons.OK, MessageBoxIcon.Information);
                
                // Logout by restarting application
                Application.Restart();
            }
            else
            {
                MessageBox.Show(PersonalFinanceManager.Common.Helpers.ConfigHelper.Translate("Failed to update password."), 
                                PersonalFinanceManager.Common.Helpers.ConfigHelper.Translate("Error"), 
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnFactoryReset_Click(object sender, EventArgs e)
        {
            var t = new Func<string, string>(PersonalFinanceManager.Common.Helpers.ConfigHelper.Translate);
            if (MessageBox.Show(t("Are you sure you want to completely erase all transaction and goal data? This cannot be undone."), t("Factory Reset"), MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                try
                {
                    var dbHelper = new PersonalFinanceManager.Common.Helpers.DbHelper();
                    using (var conn = dbHelper.CreateConnection())
                    {
                        conn.Open();
                        using (var cmd = conn.CreateCommand())
                        {
                            cmd.CommandText = "DELETE FROM Transactions; DELETE FROM Goals;";
                            cmd.ExecuteNonQuery();
                        }
                    }
                    MessageBox.Show(t("All transactional data has been reset."), t("Reset Complete"), MessageBoxButtons.OK, MessageBoxIcon.Information);
                    
                    Application.Restart();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error resetting data: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }

}
