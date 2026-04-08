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
                _translations = new System.Collections.Generic.Dictionary<string, string>();
                var vi = _translations;
                
                // Navigation
                vi["Dashboard"] = "Trang chủ";
                vi["Transactions"] = "Giao Dịch";
                vi["Accounts"] = "Tài Khoản";
                vi["Categories"] = "Danh Mục";
                vi["Goals"] = "Mục Tiêu";
                vi["Reports"] = "Báo Cáo";
                vi["Logout"] = "Đăng Xuất";
                vi["Executive"] = "Điều Hành";
                vi["Personal Finance"] = "TÀI CHÍNH CÁ NHÂN";
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
                vi["Executive Workspace"] = "Quản Lý Tài Chính";
                vi["Premium Workspace Access"] = "Trang Đăng Nhập";
                vi["USERNAME / EXECUTIVE ID"] = "GMAIL / MÃ ID";
                vi["SECURE PASSWORD"] = "MẬT KHẨU BẢO MẬT";
                vi["Remember me"] = "Ghi nhớ";
                vi["Forgot password?"] = "Quên mật khẩu?";
                vi["Login Now"] = "Đăng nhập";
                vi["New to the executive tier?"] = "Bạn là khách hàng mới?";
                vi["Request Access"] = "Yêu Cầu Truy Cập";
                vi["Sign Up Now"] = "Đăng Ký Ngay";
                vi["VERIFIED SECURE      AES-256 AUTH"] = "ĐÃ XÁC MINH BẢO MẬT      AES-256 AUTH";
                vi["Create Account"] = "Tạo Tài Khoản";
                vi["Initialize your premium financial profile."] = "Khởi tạo hồ sơ tài chính";
                vi["Full Name"] = "Họ và Tên";
                vi["Email Address"] = "Địa Chỉ Email";
                vi["Executive ID"] = "Mã ID (Executive ID)";
                vi["Password"] = "Mật Khẩu";
                vi["Confirm Password"] = "Xác Nhận Mật Khẩu";
                vi["Already have an account? Back to Login"] = "Đã có tài khoản? Trở lại đăng nhập";
                vi["Create Account"] = "Tạo Tài Khoản";
                vi["Join the\nElite Circle of\nWealth\nManagement."] = "Tham gia \nVòng Tròn \nTinh Anh \nQuản Lý \nTài Sản.";
                vi["Elevate your financial trajectory with our precision-engineered executive workspace."] = "Nâng tầm quỹ đạo tài chính của bạn với không gian làm việc chuyên nghiệp.";
                vi[".   Bank-grade encryption protocol"] = ".   Giao thức mã hóa cấp độ ngân hàng";
                vi[".   Real-time market synchronization"] = ".   Đồng bộ hóa thị trường thời gian thực";
                vi["I acknowledge the Executive Terms of Service and consent to the data protocols."] = "Tôi xác nhận Điều khoản dịch vụ và đồng ý với các giao thức dữ liệu.";
                vi["2024 EXECUTIVE FINANCE GLOBAL"] = "2026 QUẢN LÝ TÀI CHÍNH TOÀN CẦU";
                vi["PRIVACY POLICY"] = "CHÍNH SÁCH BẢO MẬT";
                vi["REGULATORY DISCLOSURE"] = "| QUY ĐỊNH";
                vi["Executive Finance"] = "Quản Lý Tài Chính";
                vi["Management"] = "Quản Lý";
                
                // Shell / Navigation
                vi["Executive"] = "QUẢN LÝ";
                vi["PERSONAL FINANCE"] = "TÀI CHÍNH CÁ NHÂN";
                vi["Dashboard"] = "Bảng Điều Khiển";
                vi["Transactions"] = "Giao Dịch";
                vi["Accounts"] = "Tài Khoản";
                vi["Categories"] = "Danh Mục";
                vi["Goals"] = "Mục Tiêu";
                vi["Reports"] = "Báo Cáo";
                vi["Settings"] = "Cài Đặt";
                vi["Logout"] = "Đăng Xuất";

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
                vi["+ Add New Goal"] = "+ Thêm Mục Tiêu";
                vi["TOTAL SAVINGS PROGRESS"] = "TỔNG TIẾN ĐỘ TIẾT KIỆM";
                vi["Active Savings Goals"] = "Mục Tiêu Đang Hoạt Động";
                vi["Optimize\nSavings"] = "Tối Ưu\nTiết Kiệm";

                // Dashboard additions
                vi["Search transactions, reports..."] = "Tìm kiếm giao dịch, báo cáo...";
                vi["Total Balance"] = "TỔNG SỐ DƯ";
                vi["Monthly Income"] = "THU NHẬP HÀNG THÁNG";
                vi["Monthly Expense"] = "CHI TIÊU HÀNG THÁNG";
                vi["Spending Trend"] = "Xu Hướng Chi Tiêu";
                vi["Last 30 days of financial activity"] = "Hoạt động tài chính trong 30 ngày qua";
                vi["Budget Usage"] = "Sử Dụng Ngân Sách";
                vi["Monthly allocation spent"] = "Ngân sách đã chi tiêu trong tháng";
                vi["Recent Transactions"] = "Giao Dịch Gần Đây";
                vi["TRANSACTION"] = "GIAO DỊCH";
                vi["CATEGORY"] = "DANH MỤC";
                vi["DATE"] = "NGÀY";
                vi["STATUS"] = "TRẠNG THÁI";
                vi["AMOUNT"] = "SỐ TIỀN";
                vi["Income"] = "Thu Nhập";
                vi["Expense"] = "Chi Tiêu";
                vi["Completed"] = "Đã Hoàn Thành";
                vi["Remaining"] = "Còn Lại";
                vi["Spent"] = "Đã Chi";
                vi["Miscellaneous"] = "Linh Tinh";
                vi["Transaction"] = "Giao Dịch";
                vi["NOW"] = "HIỆN TẠI";
                vi["Search transactions, accounts..."] = "Tìm kiếm giao dịch, tài khoản...";
                vi["Search transactions, tags or accounts..."] = "Tìm kiếm giao dịch, thẻ hoặc tài khoản...";
                vi["DESCRIPTION"] = "MÔ TẢ";
                vi["DESCRIPTION / NOTES"] = "MÔ TẢ / GHI CHÚ";
                vi["TRANSACTION TYPE"] = "LOẠI GIAO DỊCH";
                vi["TRANSACTION DATE"] = "NGÀY GIAO DỊCH";
                vi["Track your spending and optimize your flow."] = "Theo dõi chi tiêu và tối ưu hóa dòng tiền.";
                vi["Apply"] = "Áp Dụng";
                vi["Cancel"] = "Hủy";
                vi["Invalid amount format."] = "Định dạng số tiền không hợp lệ.";
                vi["+ Add Transaction"] = "+ Thêm Giao Dịch";
                vi["Food"] = "Ăn uống";
                vi["Transport"] = "Di chuyển";
                vi["Shopping"] = "Mua sắm";
                vi["Salary"] = "Lương";
                vi["Other"] = "Khác";
                vi["Main Wallet"] = "Ví chính";
                vi["Default Account"] = "Tài khoản mặc định";
                vi["ACCOUNT"] = "TÀI KHOẢN";
                vi["ACCOUNT NAME"] = "TÊN TÀI KHOẢN";
                vi["ACCOUNT TYPE"] = "LOẠI TÀI KHOẢN";
                vi["INITIAL BALANCE"] = "SỐ DƯ BAN ĐẦU";
                vi["BALANCE"] = "SỐ DƯ";
                vi["CURRENCY"] = "TIỀN TỆ";
                vi["Create New Account"] = "Tạo Tài Khoản Mới";
                vi["Edit Account"] = "Chỉnh Sửa Tài Khoản";
                vi["Update your account details and balance."] = "Cập nhật thông tin tài khoản và số dư.";
                vi["Update Account"] = "Cập Nhật Tài Khoản";
                vi["Account name cannot be empty."] = "Tên tài khoản không được để trống.";
                vi["Invalid balance amount."] = "Số dư không hợp lệ.";
                vi["Account created successfully."] = "Tạo tài khoản thành công.";
                vi["Failed to update account."] = "Cập nhật tài khoản thất bại.";
                vi["Failed to create account."] = "Tạo tài khoản thất bại.";
                vi["Cash"] = "Tiền mặt";
                vi["BankAccount"] = "Tài khoản ngân hàng";
                vi["EWallet"] = "Ví điện tử";
                vi["Savings"] = "Tiết kiệm";
                vi["CreditCard"] = "Thẻ tín dụng";
                vi["Add Category"] = "Thêm Danh Mục";
                vi["Edit Category"] = "Chỉnh Sửa Danh Mục";
                vi["Organize your flow with semantic buckets."] = "Sắp xếp dòng tiền của bạn với các nhóm ý nghĩa.";
                vi["CATEGORY NAME"] = "TÊN DANH MỤC";
                vi["TYPE"] = "LOẠI";
                vi["BUDGET LIMIT"] = "HẠN MỨC CHI TIÊU";
                vi["Enter amount (e.g. 1000000)"] = "Nhập số tiền (VD: 1000000)";
                vi["Save"] = "Lưu";
                vi["Please enter a category name."] = "Vui lòng nhập tên danh mục.";
                vi["Please enter a budget limit."] = "Vui lòng nhập hạn mức chi tiêu.";
                vi["Invalid budget limit. Please enter a valid number."] = "Hạn mức không hợp lệ. Vui lòng nhập một con số.";
                vi["System Default Category"] = "Danh mục mặc định của hệ thống";
                vi["Create Savings Goal"] = "Tạo Mục Tiêu Tiết Kiệm";
                vi["Define your target object and timeline"] = "Xác định mục tiêu và thời gian của bạn";
                vi["GOAL NAME"] = "TÊN MỤC TIÊU";
                vi["TARGET AMOUNT (IN {0})"] = "SỐ TIỀN MỤC TIÊU (THEO {0})";
                vi["TARGET DEADLINE"] = "HẠN CHÓT MỤC TIÊU";
                vi["ICON"] = "BIỂU TƯỢNG";
                vi["Add Goal"] = "Thêm Mục Tiêu";
                vi["e.g. Dream Vacation"] = "VD: Kỳ nghỉ trong mơ";
                vi["Please enter a valid goal name."] = "Vui lòng nhập tên mục tiêu hợp lệ.";
                vi["Please enter a valid target amount."] = "Vui lòng nhập số tiền mục tiêu hợp lệ.";
                vi["Error saving goal"] = "Lỗi khi lưu mục tiêu";
                vi["Validation Error"] = "Lỗi xác thực";
                vi["from last month"] = "so với tháng trước";
                
                // Account Overview
                vi["Financial Overview"] = "Tổng Quan Tài Chính";
                vi["Manage your linked accounts and wallets"] = "Quản lý các tài khoản và ví đã liên kết";
                vi["+ Add New Account"] = "+ Thêm Tài Khoản Mới";
                vi["Quick Insights"] = "Thông Tin Nhanh";
                vi["OPTIMIZATION STATUS        85%"] = "TRẠNG THÁI TỐI ƯU        85%";
                vi["OPTIMIZE PORTFOLIO"] = "TỐI ƯU HÓA DANH MỤC";
                vi["Institutional Connections"] = "Kết Nối Tổ Chức";
                vi["Manage Connections >"] = "Quản Lý Kết Nối >";
                vi["You've reached your savings goal for \"Main Savings\" 10 days earlier than projected. Consider moving..."] = "Bạn đã đạt mục tiêu tiết kiệm \"Tiết Kiệm Chính\" sớm hơn 10 ngày so với dự kiến. Cân nhắc chuyển...";
                vi["No institutional connections found. Add a bank to sync your data."] = "Không tìm thấy kết nối tổ chức nào. Thêm ngân hàng để đồng bộ dữ liệu.";
                vi["ACCOUNTS"] = "TÀI KHOẢN";
                vi["Encrypted"] = "Đã Mã Hóa";
                vi["ACTIVE"] = "ĐANG HOẠT ĐỘNG";
                vi["INACTIVE"] = "KHÔNG HOẠT ĐỘNG";
                vi["DUE SOON"] = "SẮP ĐẾN HẠN";
                vi["Synced"] = "Đã đồng bộ";
                vi["ago"] = "trước";
                vi["Just now"] = "Vừa xong";
                vi["d ago"] = " ngày trước";
                vi["h ago"] = " giờ trước";
                vi["m ago"] = " phút trước";
                vi["MAIN SAVINGS"] = "TIẾT KIỆM CHÍNH";
                vi["AMEX PLATINUM"] = "THẺ AMEX PLATINUM";
                vi["Search accounts..."] = "Tìm kiếm tài khoản...";
                vi["Portfolio AI Analysis"] = "Phân tích AI Danh mục";
                vi["Analysis complete! Your portfolio is currently performing 15% better than the market average. All savings goals are on track."] = "Phân tích hoàn tất! Danh mục của bạn đang hoạt động tốt hơn 15% so với trung bình thị trường. Tất cả mục tiêu tiết kiệm đều đúng tiến độ.";
                
                // Goals Overview
                vi["of {0} goal"] = "của mục tiêu {0}";
                vi["{0}% Achieved"] = "Đã đạt {0}%";
                vi["Target: "] = "Mục tiêu: ";
                vi["Make a Deposit"] = "Nạp tiền";
                vi["Goal Achieved!"] = "Đã đạt mục tiêu!";
                vi["Deposit to {0} goal"] = "Nạp tiền cho mục tiêu {0}";
                vi["No recent goal activity recorded."] = "Không có hoạt động mục tiêu gần đây.";
                vi["goal"] = "mục tiêu";
                vi["Funding target goal"] = "Nạp tiền mục tiêu";
                vi["Direct contribution"] = "Đóng góp trực tiếp";
                vi["Today"] = "Hôm nay";
                vi["Recent Goal Activity"] = "Hoạt động mục tiêu gần đây";
                vi["Add funds to {0}"] = "Nạp thêm tiền vào {0}";
                vi["Confirm Deposit"] = "Xác nhận nạp tiền";
                vi["PAY FROM ACCOUNT"] = "TRÍCH TỪ TÀI KHOẢN";
                vi["Please select an account."] = "Vui lòng chọn một tài khoản.";
                vi["Please enter a valid amount."] = "Vui lòng nhập số tiền hợp lệ.";
                vi["Insufficient funds in this account. Please select another account."] = "Số dư tài khoản không đủ. Vui lòng chọn tài khoản khác.";
                vi["Congratulations! You have reached your goal: {0}"] = "Chúc mừng! Bạn đã đạt được mục tiêu: {0}";
                vi["Could not process transaction."] = "Không thể xử lý giao dịch.";
                vi["Error saving deposit"] = "Lỗi khi lưu khoản nạp";
                
                // Categories
                vi["Organize your flow with semantic buckets"] = "Tổ chức luồng tiền của bạn với các danh mục ý nghĩa";
                vi["Spend Density"] = "Mật độ chi tiêu";
                vi["CRITICAL"] = "NGUY CẤP";
                vi["WARNING"] = "CẢNH BÁO";
                vi["STABLE"] = "ỔN ĐỊNH";
                vi["Are you sure you want to delete category '{0}'?"] = "Bạn có chắc chắn muốn xóa danh mục '{0}'?";
                vi["Confirm Delete"] = "Xác nhận xóa";
                vi["Budget Utilization"] = "Sử dụng ngân sách";
                vi["Last 20 Days Analysis"] = "Phân tích 20 ngày qua";
                
                // Reports
                vi["All Categories"] = "Tất cả danh mục";
                vi["All Accounts"] = "Tất cả tài khoản";
                vi["Export successful!"] = "Xuất dữ liệu thành công!";
                vi["Success"] = "Thành công";
                vi["Financial Report Designer"] = "Thiết Kế Báo Cáo Tài Chính";
                vi["Configure your fiscal summary using high-precision filters and multi-dimensional analytics. Data refreshes in real-time."] = "Cấu hình tóm tắt tài chính của bạn bằng các bộ lọc độ chính xác cao và phân tích đa chiều. Dữ liệu được cập nhật thời gian thực.";
                vi["START DATE"] = "NGÀY BẮT ĐẦU";
                vi["END DATE"] = "NGÀY KẾT THÚC";
                vi["▼ Apply"] = "▼ Áp dụng";
                vi["Fiscal Velocity"] = "Bảng Chi/Thu Tài Chính";
                vi["Monthly Income vs Expense comparison"] = "So sánh Thu nhập và Chi tiêu hàng tháng";
                vi["Transaction Ledger"] = "Sổ Cái Giao Dịch";
                vi["Date"] = "Ngày";
                vi["Description"] = "Mô Tả";
                vi["Category"] = "Danh Mục";
                vi["Account"] = "Tài Khoản";
                vi["Amount"] = "Số Tiền";
                vi["SYSTEM"] = "HỆ THỐNG";
                vi["Account #"] = "Tài khoản #";
                vi["Showing {0} entries"] = "Đang hiển thị {0} mục";
                vi["TOTAL INCOME"] = "TỔNG THU NHẬP";
                vi["TOTAL EXPENSES"] = "TỔNG CHI TIÊU";
                vi["NET SAVINGS"] = "TIẾT KIỆM RÒNG";
                vi["Calculated statically"] = "Được tính toán tĩnh";

                // Settings
                vi["Manage your account preferences and system configuration."] = "Quản lý tùy chọn tài khoản và cấu hình hệ thống.";
                vi["Edit Profile"] = "Chỉnh Sửa Hồ Sơ";
                vi["EMAIL ADDRESS"] = "ĐỊA CHỈ EMAIL";
                vi["PHONE NUMBER"] = "SỐ ĐIỆN THOẠI";
                vi["LOCATION"] = "VỊ TRÍ";
                vi["TIMEZONE"] = "MÚI GIỜ";
                vi["Appearance"] = "Diện Mạo";
                vi["Light Mode"] = "Chế Độ Sáng";
                vi["Dark Mode"] = "Chế Độ Tối";
                vi["Security & Privacy"] = "Bảo Mật & Riêng Tư";
                vi["CHANGE PASSWORD"] = "THAY ĐỔI MẬT KHẨU";
                vi["Enter current password"] = "Nhập mật khẩu hiện tại";
                vi["Enter new password"] = "Nhập mật khẩu mới";
                vi["Confirm new password"] = "Xác nhận mật khẩu mới";
                vi["Update Password"] = "Cập Nhật Mật Khẩu";
                vi["LANGUAGE"] = "NGÔN NGỮ";
                vi["CURRENCY FORMAT"] = "ĐỊNH DẠNG TIỀN TỆ";
                vi["Export Account Data"] = "Xuất Dữ Liệu Tài Khoản";
                vi["Factory Reset"] = "Khôi Phục Cài Đặt Gốc";
                vi["Incorrect current password."] = "Mật khẩu hiện tại không đúng.";
                vi["New passwords do not match."] = "Mật khẩu mới không khớp.";
                vi["Password is too weak. Must be at least 4 characters."] = "Mật khẩu quá yếu. Phải có ít nhất 4 ký tự.";
                vi["Security"] = "Bảo Mật";
                vi["Password updated successfully. Logging out..."] = "Cập nhật mật khẩu thành công. Đang đăng xuất...";
                vi["Failed to update password."] = "Cập nhật mật khẩu thất bại.";
                vi["Are you sure you want to completely erase all transaction and goal data? This cannot be undone."] = "Bạn có chắc chắn muốn xóa hoàn toàn tất cả dữ liệu giao dịch và mục tiêu? Hành động này không thể hoàn tác.";
                vi["All transactional data has been reset."] = "Tất cả dữ liệu giao dịch đã được đặt lại.";
                vi["Reset Complete"] = "Đặt Lại Hoàn Tất";
                vi["Profile successfully saved."] = "Lưu hồ sơ thành công.";
                vi["Profile"] = "Hồ Sơ";
                vi["Failed to save profile. Email might be in use."] = "Không thể lưu hồ sơ. Email có thể đã được sử dụng.";
                vi["Currency format changed to {0}."] = "Định dạng tiền tệ đã thay đổi thành {0}.";
                vi["Settings Applied"] = "Đã Áp Dụng Cài Đặt";
                
                // Account Privacy & Notifications
                vi["Account Privacy"] = "Quyền riêng tư";
                vi["Making your profile private will hide your transaction summaries from shared circles."] = "Việc đặt hồ sơ ở chế độ riêng tư sẽ ẩn tóm tắt giao dịch của bạn.";
                vi["Two-Factor \nAuthentication"] = "Xác thực \n2 yếu tố";
                vi["Add an extra layer of security to your account by requiring a verification code."] = "Thêm một lớp bảo mật bổ sung bằng cách yêu cầu mã xác minh.";
                vi["Notifications"] = "Thông báo";
                vi["Deposit Alerts"] = "Cảnh báo nạp tiền";
                vi["Notify when funds arrive"] = "Thông báo khi có tiền đến";
                vi["Budget Warnings"] = "Cảnh báo ngân sách";
                vi["When limits are reached"] = "Khi đạt đến giới hạn";
                vi["Monthly Reports"] = "Báo cáo hàng tháng";
                vi["Summary of your finances"] = "Tóm tắt tài chính của bạn";
                vi["Configure Email Alerts"] = "Cấu hình cảnh báo Email";

                // Search Placeholders
                vi["Search transactions, tags or accounts..."] = "Tìm kiếm giao dịch, thẻ hoặc tài khoản...";
                vi["Search transactions, accounts..."] = "Tìm kiếm giao dịch, tài khoản...";
                vi["Search goals..."] = "Tìm kiếm mục tiêu...";
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
