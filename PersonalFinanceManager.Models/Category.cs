using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonalFinanceManager.Models
{
    public class Category
    {
        public int Id { get; set; }
        public string Name { get; set; }           // VD: "Ăn uống", "Đi lại"
        public string Type { get; set; }           // Income | Expense
        public string IconName { get; set; }       // Tên icon Guna
        public string ColorHex { get; set; }       // VD: "#FF5733"
        public bool IsDefault { get; set; }        // Category hệ thống, không xóa được
        public int? ParentCategoryId { get; set; } // Cho phép category con (tương lai)
        public decimal BudgetLimit { get; set; }   // Giới hạn ngân sách
        public int UserId { get; set; }            // User owner
    }
}
