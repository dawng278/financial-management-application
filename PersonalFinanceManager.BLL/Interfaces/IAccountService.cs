using System.Collections.Generic;
using PersonalFinanceManager.Models;

namespace PersonalFinanceManager.BLL.Interfaces
{
    public interface IAccountService
    {
        IEnumerable<Account> GetByCurrentUser();
        Account GetById(int id);
        bool Add(Account account);
        bool Update(Account account);
        bool Delete(int id);
        decimal GetTotalBalance();
    }
}
