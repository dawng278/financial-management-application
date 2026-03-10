using System.Collections.Generic;
using PersonalFinanceManager.Models;

namespace PersonalFinanceManager.Common.Interfaces
{
    public interface ICategoryRepository : IBaseRepository<Category>
    {
        IEnumerable<Category> GetByType(string type); // "Income" hoặc "Expense"
        IEnumerable<Category> GetDefaults();
    }
}