using Dapper;
using PersonalFinanceManager.Common.Helpers;
using PersonalFinanceManager.Common.Interfaces;
using PersonalFinanceManager.DAL.Base;
using PersonalFinanceManager.Models;
using System.Collections.Generic;
using System.Linq;

namespace PersonalFinanceManager.DAL.Repositories
{
    public class AccountRepository : BaseRepository<Account>, IAccountRepository
    {
        protected override string TableName => "Accounts";

        public AccountRepository(DbHelper dbHelper) : base(dbHelper) { }

        public IEnumerable<Account> GetByUserId(int userId)
        {
            using (var conn = _dbHelper.CreateConnection())
            {
                string sql = "SELECT * FROM Accounts WHERE UserId = @UserId";
                return conn.Query<Account>(sql, new { UserId = userId }).ToList();
            }
        }

        public bool UpdateBalance(int accountId, decimal newBalance)
        {
            using (var conn = _dbHelper.CreateConnection())
            {
                int r = conn.Execute("UPDATE Accounts SET Balance = @Balance WHERE Id = @Id", new { Balance = newBalance, Id = accountId });
                ClearCache(accountId);
                return r > 0;
            }
        }

        public decimal GetTotalBalanceByUser(int userId)
        {
            using (var conn = _dbHelper.CreateConnection())
            {
                return conn.ExecuteScalar<decimal>("SELECT COALESCE(SUM(Balance), 0) FROM Accounts WHERE UserId = @UserId", new { UserId = userId });
            }
        }

        public override int Insert(Account entity)
        {
            using (var conn = _dbHelper.CreateConnection())
            {
                string sql = @"INSERT INTO Accounts (UserId, AccountName, AccountType, Balance, Currency, IsActive, CreatedAt) 
                               VALUES (@UserId, @AccountName, @AccountType, @Balance, @Currency, @IsActive, @CreatedAt);
                               SELECT last_insert_rowid();";
                entity.Id = conn.ExecuteScalar<int>(sql, entity);
                ClearCache();
                return entity.Id;
            }
        }

        public override bool Update(Account entity)
        {
            using (var conn = _dbHelper.CreateConnection())
            {
                string sql = @"UPDATE Accounts SET 
                                AccountName = @AccountName, AccountType = @AccountType, 
                                Balance = @Balance, Currency = @Currency, 
                                IsActive = @IsActive
                               WHERE Id = @Id";
                int r = conn.Execute(sql, entity);
                ClearCache(entity.Id);
                return r > 0;
            }
        }
    }
}