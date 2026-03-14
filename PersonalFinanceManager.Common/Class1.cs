using System;

namespace PersonalFinanceManager.Common.Models
{
    public class CsvTransactionDto
    {
        public DateTime TransactionDate { get; set; }
        public decimal Amount { get; set; }
        public string Type { get; set; }
        public string Category { get; set; }
        public string Note { get; set; }
        public string Account { get; set; }
    }
}
