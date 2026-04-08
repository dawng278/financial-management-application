using System;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using ReaLTaiizor.Controls;

namespace PersonalFinanceManager.Helpers
{
    public static class UIHelper
    {
        private const int EM_SETCUEBANNER = 0x1501;

        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        private static extern IntPtr SendMessage(IntPtr hWnd, int msg, int wParam, [MarshalAs(UnmanagedType.LPWStr)] string lParam);

        public static void SetPlaceholder(this Control control, string text)
        {
            if (control == null) return;

            if (control is HopeTextBox hopeTextBox)
            {
                foreach (Control child in hopeTextBox.Controls)
                {
                    if (child is TextBoxBase)
                    {
                        SendMessage(child.Handle, EM_SETCUEBANNER, 0, text);
                        return;
                    }
                }
                SendMessage(hopeTextBox.Handle, EM_SETCUEBANNER, 0, text);
            }
            else if (control is TextBoxBase textBox)
            {
                SendMessage(textBox.Handle, EM_SETCUEBANNER, 0, text);
            }
        }
    }
}
