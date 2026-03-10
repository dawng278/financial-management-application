using System.Collections.Generic;
using PersonalFinanceManager.Models;

namespace PersonalFinanceManager.Common.Interfaces
{
    public interface IAccountRepository : IBaseRepository<Account>
    {
        IEnumerable<Account> GetByUserId(int userId);
        bool UpdateBalance(int accountId, decimal newBalance);
        decimal GetTotalBalanceByUser(int userId);
    }
}