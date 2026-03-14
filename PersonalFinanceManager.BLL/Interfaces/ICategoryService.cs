using System.Collections.Generic;
using PersonalFinanceManager.Models;

namespace PersonalFinanceManager.BLL.Interfaces
{
    public interface ICategoryService
    {
        IEnumerable<Category> GetAll();
        IEnumerable<Category> GetByType(string type);   // "Income" hoặc "Expense"
        IEnumerable<Category> GetDefaults();
        bool Add(Category category);
        bool Update(Category category);
        bool Delete(int id);
    }
}
