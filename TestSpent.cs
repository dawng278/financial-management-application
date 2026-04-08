using System;
using System.Linq;
using PersonalFinanceManager.Common.Helpers;
using PersonalFinanceManager.Infrastructure.DI;
using PersonalFinanceManager.Models;
using PersonalFinanceManager.BLL.Services;
using PersonalFinanceManager.DAL.Repositories;

class Program {
    static void Main() {
        var dbHelper = new DbHelper();
        var repo = new TransactionRepository(dbHelper);
        
        // Mock session manager or just call repo directly with UserId 1
        int userId = 1;
        int catId = 7; // aa
        int year = 2026;
        int month = 4;
        
        decimal spent = repo.GetTotalByCategoryAndMonth(userId, catId, "Expense", year, month);
        Console.WriteLine($"Spent for Category 7 in 04/2026: {spent}");
    }
}
