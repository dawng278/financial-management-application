using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace PersonalFinanceManager.Theme
{
    public static class GunaThemeConfig
    {
        // Màu Navy Blue cậu thích cho Sidebar
        public static Color SidebarColor = Color.FromArgb(24, 30, 54);
        // Màu nền chính cho App
        public static Color BackgroundColor = Color.FromArgb(46, 51, 73);
        // Màu các nút bấm khi được chọn (Accent)
        public static Color AccentColor = Color.FromArgb(0, 126, 249);
        // Màu chữ trắng
        public static Color TextColor = Color.White;

        public static Color HeaderColor = Color.FromArgb(46, 51, 73);

        // Màu khi di chuột vào nút (Sáng hơn AccentColor một chút)
        public static Color HoverColor = Color.FromArgb(46, 150, 255);
        // Màu cho các vùng chứa nội dung (Card/Panel) để tách biệt với nền chính
        public static Color CardColor = Color.FromArgb(37, 42, 64);
    }
}
