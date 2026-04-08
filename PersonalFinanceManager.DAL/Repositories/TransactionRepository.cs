using System;
using System.Collections.Generic;
using System.Linq;
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

        private const string SelectWithNames = @"
            SELECT T.*, C.Name AS CategoryName, A.AccountName AS AccountName 
            FROM Transactions T
            LEFT JOIN Categories C ON T.CategoryId = C.Id
            LEFT JOIN Accounts A ON T.AccountId = A.Id";

        public IEnumerable<Transaction> GetByUserId(int userId)
        {
            using (var conn = _dbHelper.CreateConnection())
            {
                string sql = $"{SelectWithNames} WHERE T.UserId = @UserId ORDER BY T.TransactionDate DESC";
                return conn.Query<Transaction>(sql, new { UserId = userId }).ToList();
            }
        }

        public IEnumerable<Transaction> GetByAccountId(int userId, int accountId)
        {
            using (var conn = _dbHelper.CreateConnection())
            {
                string sql = $"{SelectWithNames} WHERE T.UserId = @UserId AND T.AccountId = @AccountId ORDER BY T.TransactionDate DESC";
                return conn.Query<Transaction>(sql, new { UserId = userId, AccountId = accountId }).ToList();
            }
        }

        public IEnumerable<Transaction> GetByDateRange(int userId, DateTime from, DateTime to)
        {
            using (var conn = _dbHelper.CreateConnection())
            {
                string sql = $"{SelectWithNames} WHERE T.UserId = @UserId AND T.TransactionDate BETWEEN @FromDate AND @ToDate ORDER BY T.TransactionDate DESC";
                return conn.Query<Transaction>(sql, new { UserId = userId, FromDate = from, ToDate = to }).ToList();
            }
        }

        public IEnumerable<Transaction> GetByCategory(int userId, int categoryId)
        {
            using (var conn = _dbHelper.CreateConnection())
            {
                string sql = $"{SelectWithNames} WHERE T.UserId = @UserId AND T.CategoryId = @CategoryId ORDER BY T.TransactionDate DESC";
                return conn.Query<Transaction>(sql, new { UserId = userId, CategoryId = categoryId }).ToList();
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
                string sql = $"{SelectWithNames} WHERE T.UserId = @UserId ORDER BY T.TransactionDate DESC LIMIT @Count";
                return conn.Query<Transaction>(sql, new { UserId = userId, Count = count }).ToList();
            }
        }

        public decimal GetMonthlySum(int userId, int year, int month, string type)
        {
            using (var conn = _dbHelper.CreateConnection())
            {
                var startDate = new DateTime(year, month, 1);
                var endDate = startDate.AddMonths(1).AddDays(-1);

                string sql = $@"SELECT IFNULL(SUM(Amount), 0)
                                FROM {TableName}
                                WHERE UserId = @UserId
                                  AND Type = @Type
                                  AND TransactionDate BETWEEN @Start AND @End";

                return conn.ExecuteScalar<decimal>(sql, new
                {
                    UserId = userId,
                    Type = type,
                    Start = startDate.ToString("yyyy-MM-dd"),
                    End = endDate.ToString("yyyy-MM-dd") + " 23:59:59"
                });
            }
        }
        
        public decimal GetTotalByCategoryAndMonth(int userId, int categoryId, string type, int year, int month)
        {
            using (var conn = _dbHelper.CreateConnection())
            {
                var startDate = new DateTime(year, month, 1);
                var endDate = startDate.AddMonths(1).AddDays(-1);

                string sql = $@"SELECT IFNULL(SUM(Amount), 0)
                                FROM {TableName}
                                WHERE UserId = @UserId
                                  AND CategoryId = @CategoryId
                                  AND Type = @Type
                                  AND TransactionDate BETWEEN @Start AND @End";

                return conn.ExecuteScalar<decimal>(sql, new
                {
                    UserId = userId,
                    CategoryId = categoryId,
                    Type = type,
                    Start = startDate.ToString("yyyy-MM-dd"),
                    End = endDate.ToString("yyyy-MM-dd") + " 23:59:59"
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
                }).ToList();
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
