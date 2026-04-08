using Panel = System.Windows.Forms.Panel;
using System;
using System.Drawing;
using System.Windows.Forms;
using ReaLTaiizor.Controls;
using ReaLTaiizor.Forms;
using PersonalFinanceManager.Common.Helpers;
using PersonalFinanceManager.UI.Theme;
namespace PersonalFinanceManager.UI.Forms.Goals
{
    public partial class GoalAddForm : Form
    {
        private string t(string key) => PersonalFinanceManager.Common.Helpers.ConfigHelper.Translate(key);
        private HopeTextBox txtName;

        private HopeTextBox txtAmount;
        private PoisonDateTime dtpDeadline;
        private HopeComboBox cbIcon;
        private static Color Accent  => AppThemeManager.Accent;
        private static Color Primary => AppThemeManager.Primary;
        public GoalAddForm()
        {
            SuspendLayout();
            this.BackColor = AppThemeManager.Background;
            this.FormBorderStyle = FormBorderStyle.None;
            this.StartPosition = FormStartPosition.CenterParent;
            this.Size = new Size(500, 520);
            this.ShowInTaskbar = false;
            
            // Allow clicking and dragging
            
            // Border Radius
            
            // Drop Shadow
            BuildUI();
            ResumeLayout(false);
            AppThemeManager.ThemeChanged += (s, e) => SafeInvoke(ApplyTheme);
        }
        private void BuildUI()
        {
            // Title Header

            var lblTitle = new Label
            {
                Text = t("Create Savings Goal"),
                Font = new Font("Segoe UI", 16F, FontStyle.Bold),
                ForeColor = AppThemeManager.TextPrimary,
                Location = new Point(36, 32),
                AutoSize = true,
                BackColor = Color.Transparent
            };
            this.Controls.Add(lblTitle);
            var lblSub = new Label
            {
                Text = t("Define your target object and timeline"),
                Font = new Font("Segoe UI", 9F),
                ForeColor = AppThemeManager.TextMuted,
                Location = new Point(38, 64),
                AutoSize = true,
                BackColor = Color.Transparent
            };
            this.Controls.Add(lblSub);
            // Close button
            var btnClose = new HopeButton
            {
                Text = "✕",
                Font = new Font("Segoe UI", 12F, FontStyle.Bold),
                PrimaryColor = Color.Gray, // Less distracting
                Size = new Size(40, 40),
                Location = new Point(440, 16),
                Cursor = Cursors.Hand
            };
            btnClose.Click += (s, e) => this.Close();
            this.Controls.Add(btnClose);
            // Divider
            var div = new Panel
            {
                BackColor = AppThemeManager.Border,
                Size = new Size(500, 1),
                Location = new Point(0, 100)
            };
            this.Controls.Add(div);
            // Form Inputs 
            int y = 130;
            this.Controls.Add(MakeLabel(t("GOAL NAME"), 36, y));
            txtName = BuildInput(t("e.g. Dream Vacation"), 36, y + 24, 428);
            this.Controls.Add(txtName);
            y += 84;
            this.Controls.Add(MakeLabel(string.Format(t("TARGET AMOUNT (IN {0})"), ConfigHelper.GlobalCurrency), 36, y));
            txtAmount = BuildInput("0.00", 36, y + 24, 428);
            this.Controls.Add(txtAmount);
            y += 84;
            this.Controls.Add(MakeLabel(t("TARGET DEADLINE"), 36, y));
            dtpDeadline = new PoisonDateTime
            {
                Location = new Point(36, y + 24),
                Size = new Size(240, 40),
                
                
                ForeColor = AppThemeManager.TextPrimary,
                Font = new Font("Segoe UI", 9.5F),
                Format = DateTimePickerFormat.Custom,
                CustomFormat = "dd/MM/yyyy"
            };
            this.Controls.Add(dtpDeadline);
            this.Controls.Add(MakeLabel(t("ICON"), 310, y));
            cbIcon = new HopeComboBox
            {
                Location = new Point(310, y + 24),
                Size = new Size(154, 40),
                
                
                ForeColor = AppThemeManager.TextPrimary,
                Font = new Font("Segoe UI Emoji", 12F)
            };
            cbIcon.Items.AddRange(new object[] { "✈", "🛡", "💻", "🏠", "🎓", "🎉", "🍔" });
            cbIcon.SelectedIndex = 0;
            this.Controls.Add(cbIcon);
            y += 100;
            var btnSave = new HopeButton
            {
                Text = t("Add Goal"),
                Size = new Size(428, 44),
                Location = new Point(36, y),
                
                
                ForeColor = Color.White,
                PrimaryColor = Accent, // Matches the premium theme accent
                Font = new Font("Segoe UI", 10F, FontStyle.Bold),
                Cursor = Cursors.Hand
            };
            btnSave.Click += BtnSave_Click;
            this.Controls.Add(btnSave);
        }
        private void BtnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(txtName.Text))
                {
                    MessageBox.Show(ConfigHelper.Translate("Please enter a valid goal name."), ConfigHelper.Translate("Validation Error"), MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                string amtText = txtAmount.Text.Replace(",", "").Replace(".", ""); // Basic cleanup for currency
                if (!decimal.TryParse(amtText, out decimal amount) || amount <= 0)
                {
                    MessageBox.Show(ConfigHelper.Translate("Please enter a valid target amount."), ConfigHelper.Translate("Validation Error"), MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Create goal object
                var goal = new PersonalFinanceManager.Models.Goal
                {
                    Title = txtName.Text,
                    TargetAmount = amount,
                    TargetDate = dtpDeadline.Value,
                    CurrentAmount = 0,
                    ColorHex = "#B71E50",
                    CreatedAt = DateTime.Now
                };

                // Add to database via service
                if (Infrastructure.DI.ServiceLocator.GoalService.Add(goal))
                {
                    // Show success dialog
                    this.Hide();
                    using (var succ = new PersonalFinanceManager.UI.Forms.Goals.GoalSuccessForm())
                    {
                        succ.ShowDialog();
                    }
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"{ConfigHelper.Translate("Error saving goal")}: {ex.Message}", ConfigHelper.Translate("Error"), MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private Label MakeLabel(string text, int x, int y)
        {
            return new Label
            {
                Text = text,
                Font = new Font("Segoe UI", 7.5F, FontStyle.Bold),
                ForeColor = AppThemeManager.TextMuted,
                Location = new Point(x, y),
                AutoSize = true,
                BackColor = Color.Transparent
            };
        }
        private HopeTextBox BuildInput(string placeholder, int x, int y, int w)
        {
            return new HopeTextBox
            {
                
                Size = new Size(w, 40),
                Location = new Point(x, y),
                
                
                ForeColor = AppThemeManager.TextPrimary,
                
                Font = new Font("Segoe UI", 9.5F)
            };
        }
        private void ApplyTheme()
        {
            this.BackColor = AppThemeManager.Background;
            AppThemeManager.ApplyToForm(this);
        }
        private void SafeInvoke(Action act)
        {
            if (IsDisposed) return;
            if (InvokeRequired) { try { Invoke(act); } catch { } }
            else act();
        }
    }
}

