using PersonalFinanceManager.Common.Helpers;
using PersonalFinanceManager.Common.Interfaces;
using PersonalFinanceManager.DAL.Base;
using PersonalFinanceManager.Models;
using System.Collections.Generic;

namespace PersonalFinanceManager.DAL.Repositories
{
    public class AccountRepository : BaseRepository<Account>, IAccountRepository
    {
        protected override string TableName => "Accounts";

        public AccountRepository(DbHelper dbHelper) : base(dbHelper) { }

        // B sẽ implement đầy đủ trong task B2
        public IEnumerable<Account> GetByUserId(int userId) => new List<Account>();
        public bool UpdateBalance(int accountId, decimal newBalance) { ClearCache(accountId); return false; }
        public decimal GetTotalBalanceByUser(int userId) => 0m;

        public override int Insert(Account entity) { ClearCache(); return 0; }
        public override bool Update(Account entity) { ClearCache(entity.Id); return false; }
    }
}