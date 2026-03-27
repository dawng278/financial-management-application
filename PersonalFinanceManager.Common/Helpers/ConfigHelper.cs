using System;
using System.IO;

namespace PersonalFinanceManager.Common.Helpers
{
    public static class ConfigHelper
    {
        private static readonly string ConfigPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "currency_rates.cfg");
        private static decimal _rateUsd = 25400m;
        private static decimal _rateEur = 27500m;
        private static string _globalCurrency = "VND";
        private static string _globalLanguage = "VI";
        private static string _globalTheme = "LIGHT";
        private static bool _loaded = false;

        public static decimal RateUsdToVnd 
        { 
            get { EnsureLoaded(); return _rateUsd; } 
        }

        public static decimal RateEurToVnd 
        { 
            get { EnsureLoaded(); return _rateEur; } 
        }

        public static string GlobalCurrency
        {
            get { EnsureLoaded(); return _globalCurrency; }
        }

        public static string GlobalLanguage
        {
            get { EnsureLoaded(); return _globalLanguage; }
        }

        public static string GlobalTheme
        {
            get { EnsureLoaded(); return _globalTheme; }
        }

        private static void EnsureLoaded()
        {
            if (_loaded) return;
            _loaded = true;
            try
            {
                if (File.Exists(ConfigPath))
                {
                    string[] lines = File.ReadAllLines(ConfigPath);
                    foreach(var line in lines)
                    {
                        var parts = line.Split('=');
                        if (parts.Length == 2)
                        {
                            if (parts[0] == "USD" && decimal.TryParse(parts[1], out decimal u)) _rateUsd = u;
                            if (parts[0] == "EUR" && decimal.TryParse(parts[1], out decimal e)) _rateEur = e;
                            if (parts[0] == "GLOBAL") _globalCurrency = parts[1];
                            if (parts[0] == "LANGUAGE") _globalLanguage = parts[1];
                            if (parts[0] == "THEME") _globalTheme = parts[1];
                        }
                    }
                }
            }
            catch { }
        }

        public static string FormatGlobalCurrency(decimal baseVndAmount)
        {
            string globCurrency = GlobalCurrency;
            decimal targetBalance = baseVndAmount;

            if (globCurrency == "USD") targetBalance = baseVndAmount / RateUsdToVnd;
            else if (globCurrency == "EUR") targetBalance = baseVndAmount / RateEurToVnd;

            if (globCurrency == "USD") return "$" + targetBalance.ToString("N2");
            if (globCurrency == "EUR") return "€" + targetBalance.ToString("N2");
            return targetBalance.ToString("N0") + " đ";
        }

        public static void SaveRates(decimal rateUsd, decimal rateEur, string globalCurrency)
        {
            _rateUsd = rateUsd;
            _rateEur = rateEur;
            _globalCurrency = string.IsNullOrWhiteSpace(globalCurrency) ? "VND" : globalCurrency;
            try
            {
                File.WriteAllLines(ConfigPath, new string[] { $"USD={rateUsd}", $"EUR={rateEur}", $"GLOBAL={_globalCurrency}", $"LANGUAGE={_globalLanguage}", $"THEME={_globalTheme}" });
            }
            catch { }
            CurrencyChanged?.Invoke(null, EventArgs.Empty);
        }

        public static void SaveLanguage(string lang)
        {
            _globalLanguage = string.IsNullOrWhiteSpace(lang) ? "EN" : lang;
            try
            {
                File.WriteAllLines(ConfigPath, new string[] { $"USD={_rateUsd}", $"EUR={_rateEur}", $"GLOBAL={_globalCurrency}", $"LANGUAGE={_globalLanguage}", $"THEME={_globalTheme}" });
            }
            catch { }
            LanguageChanged?.Invoke(null, EventArgs.Empty);
        }

        public static void SaveTheme(string theme)
        {
            _globalTheme = string.IsNullOrWhiteSpace(theme) ? "LIGHT" : theme.ToUpper();
            try
            {
                File.WriteAllLines(ConfigPath, new string[] { $"USD={_rateUsd}", $"EUR={_rateEur}", $"GLOBAL={_globalCurrency}", $"LANGUAGE={_globalLanguage}", $"THEME={_globalTheme}" });
            }
            catch { }
            ThemeChanged?.Invoke(null, EventArgs.Empty);
        }

        private static System.Collections.Generic.Dictionary<string, string> _translations;
        
        public static string Translate(string key)
        {
            if (_globalLanguage == "EN" || string.IsNullOrWhiteSpace(key)) return key;
            
            if (_translations == null)
            {
                _translations = new System.Collections.Generic.Dictionary<string, string>(StringComparer.OrdinalIgnoreCase);
                var vi = _translations;
                
                // Navigation
                vi["Dashboard"] = "Bảng Điều Khiển";
                vi["Transactions"] = "Giao Dịch";
                vi["Accounts"] = "Tài Khoản";
                vi["Categories"] = "Danh Mục";
                vi["Goals"] = "Mục Tiêu";
                vi["Reports"] = "Báo Cáo";
                vi["Logout"] = "Đăng Xuất";
                vi["Executive"] = "Điều Hành";
                vi["PREMIUM WORKSPACE"] = "KHÔNG GIAN CAO CẤP";
                vi["Settings"] = "Cài Đặt";

                // Settings & Shell
                vi["Manage your account preferences and system configuration."] = "Quản lý tùy chọn và cấu hình hệ thống.";
                vi["Edit Profile"] = "Sửa Hồ Sơ";
                vi["EMAIL ADDRESS"] = "ĐỊA CHỈ EMAIL";
                vi["PHONE NUMBER"] = "SỐ ĐIỆN THOẠI";
                vi["LOCATION"] = "VỊ TRÍ";
                vi["TIMEZONE"] = "MÚI GIỜ";
                vi["Appearance"] = "Giao Diện";
                vi["Light Mode"] = "Chế Độ Sáng";
                vi["Dark Mode"] = "Chế Độ Tối";
                vi["Security & Privacy"] = "Bảo Mật & Riêng Tư";
                vi["CHANGE PASSWORD"] = "ĐỔI MẬT KHẨU";
                vi["Current Password"] = "Mật Khẩu Phụ";
                vi["New Password"] = "Mật Khẩu Mới";
                vi["Confirm New Password"] = "Xác Nhận Mật Khẩu Mới";
                vi["Update Password"] = "Cập Nhật Mật Khẩu";
                vi["LANGUAGE"] = "NGÔN NGỮ";
                vi["CURRENCY FORMAT"] = "ĐỊNH DẠNG TIỀN TỆ";
                vi["Enter current password"] = "Nhập mật khẩu hiện tại";
                vi["Enter new password"] = "Nhập mật khẩu mới";
                vi["Confirm new password"] = "Xác nhận lại mật khẩu mới";
                vi["Incorrect current password."] = "Mật khẩu hiện tại không đúng.";
                vi["Password updated successfully. Logging out..."] = "Đổi mật khẩu thành công. Đang đăng xuất...";

                // Auth
                vi["Premium Workspace Access"] = "Quyền Truy Cập";
                vi["USERNAME / EXECUTIVE ID"] = "TÊN ĐĂNG NHẬP / MÃ ID";
                vi["SECURE PASSWORD"] = "MẬT KHẨU BẢO MẬT";
                vi["Remember me"] = "Ghi nhớ";
                vi["Forgot key?"] = "Quên khóa?";
                vi["Access Workspace   ->"] = "Truy Cập Hệ Thống   ->";
                vi["New to the executive tier?"] = "Bạn là khách hàng mới?";
                vi["Request Access"] = "Yêu Cầu Truy Cập";
                vi["  .  Sign Up Now"] = "  .  Đăng Ký Ngay";
                vi["VERIFIED SECURE      AES-256 AUTH"] = "ĐÃ XÁC MINH BẢO MẬT      AES-256 AUTH";
                vi["Create Account"] = "Tạo Tài Khoản";
                vi["Initialize your premium financial profile."] = "Khởi tạo hồ sơ tài chính cao cấp.";
                vi["Full Name"] = "Họ và Tên";
                vi["Email Address"] = "Địa Chỉ Email";
                vi["Executive ID"] = "Mã ID (Executive ID)";
                vi["Password"] = "Mật Khẩu";
                vi["Confirm Password"] = "Xác Nhận Mật Khẩu";
                vi["Already have an account? Back to Login ->"] = "Đã có tài khoản? Trở lại đăng nhập ->";
                vi["Create Account ->"] = "Tạo Tài Khoản ->";
                vi["Join the\nElite Circle of\nWealth\nManagement."] = "Tham gia\nVòng Tròn Tinh Anh\nQuản Lý\nTài Sản.";
                vi["Elevate your financial trajectory with our precision-engineered executive workspace."] = "Nâng tầm quỹ đạo tài chính của bạn với không gian làm việc chuyên nghiệp.";
                vi[".   Bank-grade encryption protocol"] = ".   Giao thức mã hóa cấp độ ngân hàng";
                vi[".   Real-time market synchronization"] = ".   Đồng bộ hóa thị trường thời gian thực";
                vi["I acknowledge the Executive Terms of Service and consent to the data protocols."] = "Tôi xác nhận Điều khoản dịch vụ và đồng ý với các giao thức dữ liệu.";
                vi["2024 EXECUTIVE FINANCE GLOBAL"] = "2024 EXECUTIVE FINANCE TOÀN CẦU";
                vi["PRIVACY POLICY"] = "CHÍNH SÁCH BẢO MẬT";
                vi["REGULATORY DISCLOSURE"] = "TIẾT LỘ QUY ĐỊNH";
                vi["Executive Finance"] = "Điều Hành Tài Chính";

                // Transactions
                vi["Financial Transactions"] = "Giao Dịch Tài Chính";
                vi["Search transactions..."] = "Tìm kiếm giao dịch...";
                vi["+ Add Transaction"] = "+ Thêm Giao Dịch";
                vi["TOTAL NET LIQUIDITY"] = "TỔNG THANH KHOẢN RÒNG";

                // Accounts
                vi["Asset Overview"] = "Tổng Quan Tài Sản";
                vi["+ Add New Account"] = "+ Thêm Tài Khoản Mới";

                // Categories
                vi["Budget Categories"] = "Danh Mục Ngân Sách";
                vi["+ Add Category"] = "+ Thêm Danh Mục";

                // Goals
                vi["Financial Goals"] = "Mục Tiêu Tài Chính";
                vi["Search goals..."] = "Tìm kiếm mục tiêu...";
                vi["+ Add New Goal"] = "+ Thêm Mục Tiêu Mới";
                vi["TOTAL SAVINGS PROGRESS"] = "TỔNG TIẾN ĐỘ TIẾT KIỆM";
                vi["Active Savings Goals"] = "Mục Tiêu Đang Hoạt Động";
                vi["Optimize\nSavings"] = "Tối Ưu\nTiết Kiệm";
            }

            return _translations.ContainsKey(key) ? _translations[key] : key;
        }

        /// <summary>Forces a re-read from disk on next access.</summary>
        public static void Reload() => _loaded = false;

        /// <summary>Fired after currency settings are saved — subscribe in any form to refresh displays.</summary>
        public static event EventHandler CurrencyChanged;

        /// <summary>Fired after language settings are saved — subscribe in any form to refresh UI labels.</summary>
        public static event EventHandler LanguageChanged;

        /// <summary>Fired after theme settings are saved — subscribe in any form to refresh UI colors.</summary>
        public static event EventHandler ThemeChanged;
    }
}
