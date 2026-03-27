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
    public partial class GoalDepositForm : Form
    {
        private HopeTextBox txtAmount;
        private HopeComboBox cbAccount;
        private PersonalFinanceManager.Models.Goal _goal;
        private System.Collections.Generic.List<PersonalFinanceManager.Models.Account> _accounts;


        private string t(string key) => PersonalFinanceManager.Common.Helpers.ConfigHelper.Translate(key);

        public GoalDepositForm(PersonalFinanceManager.Models.Goal goal)
        {
            _goal = goal;
            _accounts = new System.Collections.Generic.List<PersonalFinanceManager.Models.Account>(Infrastructure.DI.ServiceLocator.AccountService.GetByCurrentUser());
            SuspendLayout();

            this.BackColor = AppThemeManager.Background;
            this.FormBorderStyle = FormBorderStyle.None;
            this.StartPosition = FormStartPosition.CenterParent;
            this.Size = new Size(400, 320);
            this.ShowInTaskbar = false;
            
            BuildUI();
            ResumeLayout(false);
            AppThemeManager.ThemeChanged += (s, e) => SafeInvoke(ApplyTheme);
        }

        private void BuildUI()
        {
            // Title Header
            var lblTitle = new Label
            {
                Text = t("Make a Deposit"),
                Font = new Font("Segoe UI", 14F, FontStyle.Bold),
                ForeColor = AppThemeManager.TextPrimary,
                Location = new Point(30, 25),
                AutoSize = true,
                BackColor = Color.Transparent
            };
            this.Controls.Add(lblTitle);

            var lblSub = new Label
            {
                Text = string.Format(t("Add funds to {0}"), _goal.Title),
                Font = new Font("Segoe UI", 9F),
                ForeColor = AppThemeManager.TextMuted,
                Location = new Point(32, 55),
                AutoSize = true,
                BackColor = Color.Transparent
            };
            this.Controls.Add(lblSub);

            // Close button
            var btnClose = new HopeButton
            {
                Text = "✕",
                Font = new Font("Segoe UI", 12F, FontStyle.Bold),
                ForeColor = AppThemeManager.TextMuted,
                Size = new Size(35, 35),
                Location = new Point(350, 15),
                Cursor = Cursors.Hand
            };
            btnClose.Click += (s, e) => this.Close();
            this.Controls.Add(btnClose);

            // Divider
            var div = new Panel
            {
                BackColor = AppThemeManager.Border,
                Size = new Size(400, 1),
                Location = new Point(0, 85)
            };
            this.Controls.Add(div);

            // Input
            int y = 105;
            this.Controls.Add(new Label
            {
                Text = t("PAY FROM ACCOUNT"),
                Font = new Font("Segoe UI", 7.5F, FontStyle.Bold),
                ForeColor = AppThemeManager.TextMuted,
                Location = new Point(30, y),
                AutoSize = true
            });

            cbAccount = new HopeComboBox
            {
                Size = new Size(340, 40),
                Location = new Point(30, y + 20),
                ForeColor = AppThemeManager.TextPrimary,
                Font = new Font("Segoe UI", 9F)
            };
            foreach (var acc in _accounts)
            {
                cbAccount.Items.Add($"{acc.AccountName} ({PersonalFinanceManager.Common.Helpers.ConfigHelper.FormatGlobalCurrency(acc.Balance)})");
            }
            if (cbAccount.Items.Count > 0) cbAccount.SelectedIndex = 0;
            this.Controls.Add(cbAccount);

            y += 85;
            var lblAmt = new Label
            {
                Text = t("AMOUNT"),
                Font = new Font("Segoe UI", 7.5F, FontStyle.Bold),
                ForeColor = AppThemeManager.TextMuted,
                Location = new Point(30, y),
                AutoSize = true
            };
            this.Controls.Add(lblAmt);

            txtAmount = new HopeTextBox
            {
                Size = new Size(340, 40),
                Location = new Point(30, y + 20),
                ForeColor = AppThemeManager.TextPrimary,
                Font = new Font("Segoe UI", 10F),
                Text = "0"
            };
            this.Controls.Add(txtAmount);

            y += 90;
            var btnSave = new HopeButton
            {
                Text = t("Confirm Deposit"),
                Size = new Size(340, 44),
                Location = new Point(30, y),
                ForeColor = Color.White,
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
                if (cbAccount.SelectedIndex == -1)
                {
                    MessageBox.Show(t("Please select an account."), t("Validation Error"), MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                string amtText = txtAmount.Text.Replace(",", "").Replace(".", "");
                if (!decimal.TryParse(amtText, out decimal amount) || amount <= 0)
                {
                    MessageBox.Show(t("Please enter a valid amount."), t("Validation Error"), MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                var selectedAcc = _accounts[cbAccount.SelectedIndex];
                if (selectedAcc.Balance < amount)
                {
                    MessageBox.Show(t("Insufficient funds in this account. Please select another account."), t("Validation Error"), MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Deducting from account balance is now handled by TransactionService.Add below,
                // and adding to goal progress is kept here.
                _goal.CurrentAmount += amount;
                
                // Find a suitable CategoryId for the goal deposit
                int categoryId = 0;
                var categories = Infrastructure.DI.ServiceLocator.CategoryService.GetAll();
                foreach (var cat in categories)
                {
                    if (string.Equals(cat.Name, "Savings", StringComparison.OrdinalIgnoreCase) || 
                        string.Equals(cat.Name, "Tiết kiệm", StringComparison.OrdinalIgnoreCase))
                    {
                        categoryId = cat.Id;
                        break;
                    }
                }
                
                // Fallback to any expense category if no savings category found
                if (categoryId == 0)
                {
                    foreach (var cat in categories)
                    {
                        if (string.Equals(cat.Type, "Expense", StringComparison.OrdinalIgnoreCase))
                        {
                            categoryId = cat.Id;
                            break;
                        }
                    }
                }

                // Track as a transaction in the ledger
                var trans = new PersonalFinanceManager.Models.Transaction
                {
                    Amount = -amount, // Negative for Expense
                    Note = string.Format(t("Deposit to {0} goal"), _goal.Title),
                    TransactionDate = DateTime.Now,
                    AccountId = selectedAcc.Id,
                    CategoryId = categoryId,
                    Type = "Expense",
                    ImportSource = "GoalDeposit"
                };
                
                // Add via service handles balance updates and budget checks
                var success = Infrastructure.DI.ServiceLocator.TransactionService.Add(trans);

                if (success && Infrastructure.DI.ServiceLocator.GoalService.Update(_goal))
                {
                    // Goal completion trigger
                    if (_goal.CurrentAmount >= _goal.TargetAmount)
                    {
                        // Record completion milestone
                        var milestone = new PersonalFinanceManager.Models.Transaction
                        {
                            Amount = 0,
                            Note = string.Format(t("Congratulations! You have reached your goal: {0}"), _goal.Title),
                            TransactionDate = DateTime.Now,
                            AccountId = selectedAcc.Id,
                            CategoryId = categoryId,
                            Type = "Milestone",
                            ImportSource = "Milestone"
                        };
                        Infrastructure.DI.ServiceLocator.TransactionService.Add(milestone);
                        
                        MessageBox.Show(milestone.Note, t("Goal Achieved!"), MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }

                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
                else if (!success)
                {
                    MessageBox.Show(Infrastructure.DI.ServiceLocator.TransactionService.LastError ?? t("Could not process transaction."), t("Error"), MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"{t("Error saving deposit")}: {ex.Message}", t("Error"), MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
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
