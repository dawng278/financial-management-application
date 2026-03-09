using System;
using System.Collections.Generic;
using PersonalFinanceManager.Common.Interfaces;
using PersonalFinanceManager.Models;

namespace PersonalFinanceManager.Common.Mock
{
    public class MockTransactionService : ITransactionService
    {
        public IEnumerable<Transaction> GetRecent(int count)
        {
            return new List<Transaction>
            {
                new Transaction { Id=1, Amount=150000, Type="Expense", CategoryName="Ăn uống",  Note="Cơm trưa",  TransactionDate=DateTime.Today },
                new Transaction { Id=2, Amount=500000, Type="Expense", CategoryName="Đi lại",   Note="Grab",      TransactionDate=DateTime.Today.AddDays(-1) },
                new Transaction { Id=3, Amount=5000000,Type="Income",  CategoryName="Lương",    Note="Tháng 7",   TransactionDate=DateTime.Today.AddDays(-2) },
                new Transaction { Id=4, Amount=200000, Type="Expense", CategoryName="Giải trí", Note="Netflix",   TransactionDate=DateTime.Today.AddDays(-3) },
            };
        }

        public IEnumerable<Transaction> GetByDateRange(DateTime from, DateTime to) => GetRecent(10);
        public bool Add(Transaction transaction) => true;
        public bool Update(Transaction transaction) => true;
        public bool Delete(int id) => true;
        public decimal GetTotalIncome(DateTime from, DateTime to) => 5_000_000m;
        public decimal GetTotalExpense(DateTime from, DateTime to) => 850_000m;
    }
}