using System;
using System.Collections.Generic;
using PersonalFinanceManager.Models;

namespace PersonalFinanceManager.Common.Interfaces
{
    public interface ITransactionRepository : IBaseRepository<Transaction>
    {
        // Lọc & tìm kiếm
        IEnumerable<Transaction> GetByUserId(int userId);
        IEnumerable<Transaction> GetByAccountId(int accountId);
        IEnumerable<Transaction> GetByDateRange(int userId, DateTime from, DateTime to);
        IEnumerable<Transaction> GetByCategory(int userId, int categoryId);

        // Thống kê - Member D và C cần
        decimal GetTotalByType(int userId, string type, DateTime from, DateTime to);
        decimal GetTotalByCategoryAndMonth(int userId, int categoryId, string type, int year, int month);
        IEnumerable<Transaction> GetRecent(int userId, int count);
    }
}