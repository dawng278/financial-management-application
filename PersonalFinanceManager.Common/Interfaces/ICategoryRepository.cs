using System.Collections.Generic;
using PersonalFinanceManager.Models;

namespace PersonalFinanceManager.Common.Interfaces
{
    public interface ICategoryRepository : IBaseRepository<Category>
    {
        IEnumerable<Category> GetByUserId(int userId);
        IEnumerable<Category> GetByType(int userId, string type); // "Income" hoặc "Expense"
        IEnumerable<Category> GetDefaults();
    }
}