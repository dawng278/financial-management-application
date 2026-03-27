using Panel = System.Windows.Forms.Panel;
using System;
using System.Drawing;
using System.Windows.Forms;
using ReaLTaiizor.Controls;
using ReaLTaiizor.Forms;
using PersonalFinanceManager.UI.Theme;
namespace PersonalFinanceManager.UI.Forms.Goals
{
    public partial class GoalSuccessForm : Form
    {
        public GoalSuccessForm()
        {
            SuspendLayout();
            this.FormBorderStyle = FormBorderStyle.None;
            this.StartPosition = FormStartPosition.CenterParent;
            this.Size = new Size(400, 320);
            this.BackColor = AppThemeManager.Surface;
            this.ShowInTaskbar = false;
            BuildUI();
            ResumeLayout(false);
        }
        private void BuildUI()
        {
            // Success Icon Backing
            var pnlCircle = new Panel
            {
                Size = new Size(80, 80),
                Location = new Point(160, 40),
                BackColor = Color.FromArgb(230, 250, 240)
            };
            
            var lblIcon = new Label
            {
                Text = "✓",
                Font = new Font("Segoe UI", 36F, FontStyle.Bold),
                ForeColor = Color.FromArgb(34, 197, 94),
                AutoSize = false,
                Size = new Size(80, 80),
                
                BackColor = Color.Transparent
            };
            pnlCircle.Controls.Add(lblIcon);
            this.Controls.Add(pnlCircle);
            // Title
            var lblTitle = new Label
            {
                Text = "Goal Created!",
                Font = new Font("Segoe UI", 16F, FontStyle.Bold),
                ForeColor = AppThemeManager.TextPrimary,
                Location = new Point(122, 140),
                AutoSize = true,
                BackColor = Color.Transparent
            };
            this.Controls.Add(lblTitle);
            // Subtitle
            var lblSub = new Label
            {
                Text = "Your new savings target is now active.\nTime to start saving!",
                Font = new Font("Segoe UI", 9.5F),
                ForeColor = AppThemeManager.TextMuted,
                Location = new Point(0, 180),
                Size = new Size(400, 40),
                
                BackColor = Color.Transparent
            };
            this.Controls.Add(lblSub);
            // Button
            var btnDone = new HopeButton
            {
                Text = "Done",
                Size = new Size(160, 40),
                Location = new Point(120, 240),
                
                
                ForeColor = Color.White,
                Font = new Font("Segoe UI", 9.5F, FontStyle.Bold),
                Cursor = Cursors.Hand
            };
            btnDone.Click += (s, e) => { this.DialogResult = DialogResult.OK; this.Close(); };
            this.Controls.Add(btnDone);
        }
    }
}

