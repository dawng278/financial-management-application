using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonalFinanceManager.Models
{
    public class Transaction
    {
        public int Id { get; set; }
        public int AccountId { get; set; }
        public int CategoryId { get; set; }
        public int UserId { get; set; }
        public decimal Amount { get; set; }
        public string Type { get; set; }           // Income | Expense | Transfer
        public string Note { get; set; }
        public DateTime TransactionDate { get; set; }
        public DateTime CreatedAt { get; set; }
        public string ImportSource { get; set; }   // null = nhập tay, "CSV" = import

        // Navigation (không map DB, dùng để bind UI)
        public string CategoryName { get; set; }
        public string AccountName { get; set; }
    }
}
