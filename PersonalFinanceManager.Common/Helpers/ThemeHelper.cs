using System.Drawing;

namespace PersonalFinanceManager.Common.Helpers
{
    public static class ThemeHelper
    {
        // Light Mode Colors (Default)
        public static Color Light_Background = Color.FromArgb(248, 249, 252);
        public static Color Light_CardBackground = Color.White;
        public static Color Light_Text = Color.FromArgb(22, 22, 22);
        public static Color Light_SubText = Color.FromArgb(120, 120, 130);
        public static Color Light_Border = Color.FromArgb(235, 235, 240);
        public static Color Light_Primary = Color.FromArgb(183, 0, 82);
        public static Color Light_DarkTheme = Color.FromArgb(40, 45, 60);

        // Dark Mode Colors
        public static Color Dark_Background = Color.FromArgb(18, 18, 24);
        public static Color Dark_CardBackground = Color.FromArgb(30, 30, 40);
        public static Color Dark_Text = Color.FromArgb(240, 240, 245);
        public static Color Dark_SubText = Color.FromArgb(160, 160, 175);
        public static Color Dark_Border = Color.FromArgb(50, 50, 65);
        public static Color Dark_Primary = Color.FromArgb(220, 20, 100);
        public static Color Dark_DarkTheme = Color.FromArgb(60, 65, 85);

        public static bool IsDarkMode => ConfigHelper.GlobalTheme == "DARK";

        public static Color Background => IsDarkMode ? Dark_Background : Light_Background;
        public static Color CardBackground => IsDarkMode ? Dark_CardBackground : Light_CardBackground;
        public static Color Text => IsDarkMode ? Dark_Text : Light_Text;
        public static Color SubText => IsDarkMode ? Dark_SubText : Light_SubText;
        public static Color Border => IsDarkMode ? Dark_Border : Light_Border;
        public static Color Primary => IsDarkMode ? Dark_Primary : Light_Primary;

        public static void ApplyTheme(System.Windows.Forms.Control parent)
        {
            ApplyToControl(parent);
            foreach (System.Windows.Forms.Control c in parent.Controls)
            {
                ApplyTheme(c);
            }
        }

        private static void ApplyToControl(System.Windows.Forms.Control c)
        {
            bool isDark = IsDarkMode;

            if (c is System.Windows.Forms.Label lbl)
            {
                if (lbl.Name.StartsWith("lblPageTitle") || lbl.Name.EndsWith("Title") || lbl.Name.EndsWith("Name") || lbl.Name.EndsWith("Lbl"))
                {
                    lbl.ForeColor = Text;
                }
                else
                {
                    lbl.ForeColor = SubText;
                }
                
                if (lbl.BackColor == Color.White || lbl.BackColor == Color.FromArgb(248, 249, 252))
                {
                    lbl.BackColor = Color.Transparent;
                }
            }
            else if (c is ReaLTaiizor.Controls.HopeTextBox tb)
            {
                tb.BackColor = isDark ? Color.FromArgb(45, 45, 55) : Color.White;
                tb.ForeColor = Text;
            }
            else if (c is ReaLTaiizor.Controls.HopeComboBox cbo)
            {
                // ComboBox colors are often harder to override in ReaLTaiizor without custom paint
            }
            else if (c is ReaLTaiizor.Controls.HopeToggle tg)
            {
                tg.BackColor = CardBackground;
                tg.BaseColor = CardBackground;
                tg.BaseColorA = isDark ? Color.FromArgb(45, 45, 60) : Color.FromArgb(220, 223, 230);
                tg.HeadColorB = CardBackground;
            }
            else if (c is ReaLTaiizor.Controls.HopeSwitch sw)
            {
                sw.BackColor = CardBackground;
                sw.BaseColor = CardBackground;
            }
            else if (c is System.Windows.Forms.DataGridView dgv)
            {
                dgv.BackgroundColor = Background;
                dgv.GridColor = isDark ? Color.FromArgb(45, 45, 60) : Color.FromArgb(235, 235, 240);
                dgv.BorderStyle = System.Windows.Forms.BorderStyle.None;
                
                // Root Style
                dgv.DefaultCellStyle.BackColor = CardBackground;
                dgv.DefaultCellStyle.ForeColor = Text;
                dgv.DefaultCellStyle.SelectionBackColor = isDark ? Color.FromArgb(55, 65, 120) : Color.FromArgb(230, 240, 255);
                dgv.DefaultCellStyle.SelectionForeColor = isDark ? Color.White : Color.Black;
                
                // Rows
                dgv.RowsDefaultCellStyle.BackColor = CardBackground;
                dgv.RowsDefaultCellStyle.ForeColor = Text;
                dgv.RowsDefaultCellStyle.SelectionBackColor = dgv.DefaultCellStyle.SelectionBackColor;
                dgv.RowsDefaultCellStyle.SelectionForeColor = dgv.DefaultCellStyle.SelectionForeColor;
                
                // Alternating
                dgv.AlternatingRowsDefaultCellStyle.BackColor = isDark ? Color.FromArgb(35, 35, 45) : Color.FromArgb(250, 250, 252);
                dgv.AlternatingRowsDefaultCellStyle.ForeColor = Text;
                dgv.AlternatingRowsDefaultCellStyle.SelectionBackColor = dgv.DefaultCellStyle.SelectionBackColor;
                dgv.AlternatingRowsDefaultCellStyle.SelectionForeColor = dgv.DefaultCellStyle.SelectionForeColor;

                // Headers
                dgv.ColumnHeadersDefaultCellStyle.BackColor = isDark ? Color.FromArgb(25, 25, 35) : Color.FromArgb(240, 240, 245);
                dgv.ColumnHeadersDefaultCellStyle.ForeColor = Text;
                dgv.ColumnHeadersDefaultCellStyle.SelectionBackColor = dgv.ColumnHeadersDefaultCellStyle.BackColor;
                dgv.ColumnHeadersDefaultCellStyle.SelectionForeColor = Text;
                dgv.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
                dgv.EnableHeadersVisualStyles = false;
            }
            else if (c is System.Windows.Forms.Panel pnl)
            {
                // ALL layout panels, scroll containers, or form-level containers should follow Background
                // OR if it's the root panel of Dashboard/Reports
                if (pnl.Name.StartsWith("pnlMain") || pnl.Name.StartsWith("pnlScroll") || 
                    pnl.Name.StartsWith("pnlContent") || pnl.Name == "pnlSidebar" ||
                    pnl.Name.StartsWith("pnlDashboard") || pnl.Name.EndsWith("Root"))
                {
                     pnl.BackColor = Background;
                }
                else if (pnl.Name.StartsWith("pnlCard") || pnl.Name.StartsWith("pnlTrend") || 
                         pnl.Name.StartsWith("pnlUsage") || pnl.Name.StartsWith("pnlRecent") ||
                         pnl.Name.StartsWith("pnlChart") || pnl.Name.StartsWith("pnlInfo"))
                {
                    // These are explicitly card-like panels
                    pnl.BackColor = CardBackground;
                }
                else if (pnl.Parent is System.Windows.Forms.Form)
                {
                    // Direct child of a form that isn't a card is a layout panel
                    pnl.BackColor = Background;
                }
                else
                {
                    // Fallback to Background for better consistency in Dark Mode
                    pnl.BackColor = Background;
                }
            }
            else if (c is System.Windows.Forms.Form frm)
            {
                frm.BackColor = Background;
            }
        }
    }
}
