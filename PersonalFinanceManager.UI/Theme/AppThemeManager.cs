using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
namespace PersonalFinanceManager.UI.Theme
{
    /// <summary>
    /// Central theme manager – handles Light/Dark mode and propagates changes
    /// to all open forms via the ThemeChanged event.
    /// </summary>
    public static class AppThemeManager
    {
        private static readonly string ThemePath =
            Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "app_theme.cfg");
        private static bool _isDark = false;
        public static bool IsDark
        {
            get { EnsureLoaded(); return _isDark; }
        }
        // ── Per-theme colour tokens ──────────────────────────────────────────
        public static Color Background    => _isDark ? Color.FromArgb(18, 24, 34)    : Color.FromArgb(245, 247, 250);
        public static Color Surface       => _isDark ? Color.FromArgb(28, 36, 50)    : Color.White;
        public static Color SurfaceAlt    => _isDark ? Color.FromArgb(36, 46, 60)    : Color.FromArgb(240, 243, 247);
        public static Color TextPrimary   => _isDark ? Color.FromArgb(230, 235, 242) : Color.FromArgb(30, 40, 50);
        public static Color TextMuted     => _isDark ? Color.FromArgb(130, 150, 170) : Color.FromArgb(110, 126, 140);
        public static Color Border        => _isDark ? Color.FromArgb(45, 58, 75)    : Color.FromArgb(220, 226, 232);
        public static Color InputBg       => _isDark ? Color.FromArgb(32, 42, 56)    : Color.FromArgb(240, 243, 246);
        public static Color Accent        => Color.FromArgb(220, 20, 60);   // always crimson
        public static Color Primary       => Color.FromArgb(67, 96, 109);
        /// <summary>Fired when the theme changes – subscribe in every form.</summary>
        public static event EventHandler ThemeChanged;
        public static void SetTheme(bool dark)
        {
            _isDark = dark;
            try { File.WriteAllText(ThemePath, dark ? "dark" : "light"); } catch { }
            ThemeChanged?.Invoke(null, EventArgs.Empty);
        }
        private static bool _loaded = false;
        private static void EnsureLoaded()
        {
            if (_loaded) return;
            _loaded = true;
            try
            {
                if (File.Exists(ThemePath))
                    _isDark = File.ReadAllText(ThemePath).Trim().ToLower() == "dark";
            }
            catch { }
        }
        /// <summary>
        /// Recursively applies current theme colours to every Control in a form.
        /// Knows how to handle Panel, HopeButton, HopeTextBox, HopeComboBox,
        /// HopeToggle, DataGridView, Label, and Panel.
        /// </summary>
        public static void ApplyToForm(Form form)
        {
            if (form == null || form.IsDisposed) return;
            ApplyToControl(form);
        }
        private static void ApplyToControl(Control ctrl)
        {
            // Form / plain Panel / UserControl background
            if (ctrl is Form || ctrl is Panel)
            {
                if (!(ctrl is ReaLTaiizor.Controls.Panel))
                    ctrl.BackColor = Background;
            }
            // Guna panels (cards)
            if (ctrl is ReaLTaiizor.Controls.Panel gp)
            {
                // Don't override accent-coloured panels (e.g. sidebar color strip)
                if (gp.BackColor != Accent && gp.BackColor.R < 220)
                    gp.BackColor = Surface;
            }
            // Text inputs
            if (ctrl is ReaLTaiizor.Controls.HopeTextBox gtb)
            {
                gtb.ForeColor  = TextPrimary;
            }
            // ComboBoxes
            if (ctrl is ReaLTaiizor.Controls.HopeComboBox gcb)
            {
                gcb.ForeColor  = TextPrimary;
            }
            // DataGridView
            if (ctrl is DataGridView dgv)
            {
                dgv.BackgroundColor      = Surface;
                dgv.DefaultCellStyle.BackColor  = Surface;
                dgv.DefaultCellStyle.ForeColor  = TextPrimary;
                dgv.ColumnHeadersDefaultCellStyle.BackColor = SurfaceAlt;
                dgv.ColumnHeadersDefaultCellStyle.ForeColor = TextPrimary;
                dgv.GridColor = Border;
            }
            // Labels
            if (ctrl is Label lbl && lbl.BackColor == Color.Transparent)
            {
                // Only override if not a badge or accent-colored label
                if (lbl.ForeColor != Accent && lbl.ForeColor.R < 220)
                {
                    bool isMuted = lbl.Font != null && lbl.Font.Size <= 9f;
                    lbl.ForeColor = isMuted ? TextMuted : TextPrimary;
                }
            }
            // Recurse
            foreach (Control child in ctrl.Controls)
                ApplyToControl(child);
        }
    }
}
