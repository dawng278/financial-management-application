using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonalFinanceManager.Models
{
    public class Account
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string AccountName { get; set; }   // VD: "Ví tiền mặt", "MB Bank"
        public string AccountType { get; set; }   // Cash, BankAccount, EWallet
        public decimal Balance { get; set; }
        public string Currency { get; set; }       // VND, USD
        public DateTime CreatedAt { get; set; }
        public bool IsActive { get; set; }
    }
}
