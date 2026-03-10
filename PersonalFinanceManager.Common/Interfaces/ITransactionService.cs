using System;
using System.Collections.Generic;
using PersonalFinanceManager.Models;

namespace PersonalFinanceManager.Common.Interfaces
{
    public interface ITransactionService
    {
        IEnumerable<Transaction> GetRecent(int count);
        IEnumerable<Transaction> GetByDateRange(DateTime from, DateTime to);
        bool Add(Transaction transaction);
        bool Update(Transaction transaction);
        bool Delete(int id);
        decimal GetTotalIncome(DateTime from, DateTime to);
        decimal GetTotalExpense(DateTime from, DateTime to);
    }
}