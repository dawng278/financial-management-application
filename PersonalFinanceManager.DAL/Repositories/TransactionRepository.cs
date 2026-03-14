using System;
using System.Collections.Generic;
using Dapper;
using PersonalFinanceManager.Common.Helpers;
using PersonalFinanceManager.Common.Interfaces;
using PersonalFinanceManager.DAL.Base;
using PersonalFinanceManager.Models;

namespace PersonalFinanceManager.DAL.Repositories
{
    public class TransactionRepository : BaseRepository<Transaction>, ITransactionRepository
    {
        protected override string TableName => "Transactions";

        public TransactionRepository(DbHelper dbHelper) : base(dbHelper) { }

        public IEnumerable<Transaction> GetByUserId(int userId)
        {
            using (var conn = _dbHelper.CreateConnection())
            {
                string sql = $"SELECT * FROM {TableName} WHERE UserId = @UserId ORDER BY TransactionDate DESC";
                return conn.Query<Transaction>(sql, new { UserId = userId });
            }
        }

        public IEnumerable<Transaction> GetByAccountId(int accountId)
        {
            using (var conn = _dbHelper.CreateConnection())
            {
                string sql = $"SELECT * FROM {TableName} WHERE AccountId = @AccountId ORDER BY TransactionDate DESC";
                return conn.Query<Transaction>(sql, new { AccountId = accountId });
            }
        }

        public IEnumerable<Transaction> GetByDateRange(int userId, DateTime from, DateTime to)
        {
            using (var conn = _dbHelper.CreateConnection())
            {
                string sql = $"SELECT * FROM {TableName} WHERE UserId = @UserId AND TransactionDate BETWEEN @FromDate AND @ToDate ORDER BY TransactionDate DESC";
                return conn.Query<Transaction>(sql, new { UserId = userId, FromDate = from, ToDate = to });
            }
        }

        public IEnumerable<Transaction> GetByCategory(int userId, int categoryId)
        {
            using (var conn = _dbHelper.CreateConnection())
            {
                string sql = $"SELECT * FROM {TableName} WHERE UserId = @UserId AND CategoryId = @CategoryId ORDER BY TransactionDate DESC";
                return conn.Query<Transaction>(sql, new { UserId = userId, CategoryId = categoryId });
            }
        }

        public decimal GetTotalByType(int userId, string type, DateTime from, DateTime to)
        {
            using (var conn = _dbHelper.CreateConnection())
            {
                string sql = $"SELECT IFNULL(SUM(Amount), 0) FROM {TableName} WHERE UserId = @UserId AND Type = @Type AND TransactionDate BETWEEN @FromDate AND @ToDate";
                return conn.ExecuteScalar<decimal>(sql, new { UserId = userId, Type = type, FromDate = from, ToDate = to });
            }
        }

        public IEnumerable<Transaction> GetRecent(int userId, int count)
        {
            using (var conn = _dbHelper.CreateConnection())
            {
                string sql = $"SELECT * FROM {TableName} WHERE UserId = @UserId ORDER BY TransactionDate DESC LIMIT @Count";
                return conn.Query<Transaction>(sql, new { UserId = userId, Count = count });
            }
        }

        public decimal GetMonthlySum(int userId, int year, int month, string type)
        {
            using (var conn = _dbHelper.CreateConnection())
            {
                string sql = $@"SELECT IFNULL(SUM(Amount), 0)
                                FROM {TableName}
                                WHERE UserId = @UserId
                                  AND Type = @Type
                                  AND strftime('%Y', TransactionDate) = @Year
                                  AND strftime('%m', TransactionDate) = @Month";

                return conn.ExecuteScalar<decimal>(sql, new
                {
                    UserId = userId,
                    Type = type,
                    Year = year.ToString("0000"),
                    Month = month.ToString("00")
                });
            }
        }

        public IEnumerable<TransactionCategorySummary> GetCategorySummary(int userId, DateTime from, DateTime to)
        {
            using (var conn = _dbHelper.CreateConnection())
            {
                string sql = $@"SELECT CategoryId,
                                       Type,
                                       IFNULL(SUM(Amount), 0) AS TotalAmount,
                                       COUNT(1) AS TransactionCount
                                FROM {TableName}
                                WHERE UserId = @UserId
                                  AND TransactionDate BETWEEN @FromDate AND @ToDate
                                GROUP BY CategoryId, Type";

                return conn.Query<TransactionCategorySummary>(sql, new
                {
                    UserId = userId,
                    FromDate = from,
                    ToDate = to
                });
            }
        }

        public override int Insert(Transaction entity)
        {
            using (var conn = _dbHelper.CreateConnection())
            {
                string sql = $@"INSERT INTO {TableName}
                                (AccountId, CategoryId, UserId, Amount, Type, Note, TransactionDate, CreatedAt, ImportSource)
                                VALUES
                                (@AccountId, @CategoryId, @UserId, @Amount, @Type, @Note, @TransactionDate, @CreatedAt, @ImportSource);
                                SELECT last_insert_rowid();";

                var id = conn.ExecuteScalar<long>(sql, new
                {
                    entity.AccountId,
                    entity.CategoryId,
                    entity.UserId,
                    entity.Amount,
                    entity.Type,
                    entity.Note,
                    entity.TransactionDate,
                    entity.CreatedAt,
                    entity.ImportSource
                });
                ClearCache();
                return (int)id;
            }
        }

        public override bool Update(Transaction entity)
        {
            using (var conn = _dbHelper.CreateConnection())
            {
                string sql = $@"UPDATE {TableName}
                                SET AccountId = @AccountId,
                                    CategoryId = @CategoryId,
                                    UserId = @UserId,
                                    Amount = @Amount,
                                    Type = @Type,
                                    Note = @Note,
                                    TransactionDate = @TransactionDate,
                                    ImportSource = @ImportSource
                                WHERE Id = @Id";

                int rows = conn.Execute(sql, new
                {
                    entity.AccountId,
                    entity.CategoryId,
                    entity.UserId,
                    entity.Amount,
                    entity.Type,
                    entity.Note,
                    entity.TransactionDate,
                    entity.ImportSource,
                    entity.Id
                });
                if (rows > 0) ClearCache(entity.Id);
                return rows > 0;
            }
        }

        public class TransactionCategorySummary
        {
            public int CategoryId { get; set; }
            public string Type { get; set; }
            public decimal TotalAmount { get; set; }
            public int TransactionCount { get; set; }
        }
    }
}
