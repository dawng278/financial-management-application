using System;
using System.Collections.Generic;
using System.Data.SQLite;
using PersonalFinanceManager.Common.Interfaces;
using PersonalFinanceManager.Common.Helpers;
using PersonalFinanceManager.Models;

namespace PersonalFinanceManager.Common.Mock
{
    public class MockTransactionService : ITransactionService
    {
        private readonly DbHelper _dbHelper = new DbHelper();

        public IEnumerable<Transaction> GetRecent(int count)
        {
            var currentUserId = MockUserService.CurrentUserId;
            if (currentUserId <= 0) return new List<Transaction>();

            var result = new List<Transaction>();
            using (var conn = _dbHelper.CreateConnection())
            {
                conn.Open();

                using (var cmd = (SQLiteCommand)conn.CreateCommand())
                {
                    cmd.CommandText = @"SELECT t.Id, t.AccountId, t.CategoryId, t.UserId, t.Amount, t.Type, t.Note,
                                               t.TransactionDate, t.CreatedAt, t.ImportSource,
                                               c.Name AS CategoryName
                                        FROM Transactions t
                                        LEFT JOIN Categories c ON c.Id = t.CategoryId
                                        WHERE t.UserId = @uid
                                        ORDER BY datetime(t.TransactionDate) DESC
                                        LIMIT @count";
                    cmd.Parameters.AddWithValue("@uid", currentUserId);
                    cmd.Parameters.AddWithValue("@count", count);

                    using (var r = cmd.ExecuteReader())
                    {
                        while (r.Read()) result.Add(MapTransaction(r));
                    }
                }
            }

            return result;
        }

        public IEnumerable<Transaction> GetByDateRange(DateTime from, DateTime to)
        {
            var currentUserId = MockUserService.CurrentUserId;
            if (currentUserId <= 0) return new List<Transaction>();

            var result = new List<Transaction>();
            using (var conn = _dbHelper.CreateConnection())
            {
            conn.Open();
            using (var cmd = (SQLiteCommand)conn.CreateCommand())
            {
                cmd.CommandText = @"SELECT t.Id, t.AccountId, t.CategoryId, t.UserId, t.Amount, t.Type, t.Note,
                                           t.TransactionDate, t.CreatedAt, t.ImportSource,
                                           c.Name AS CategoryName
                                    FROM Transactions t
                                    LEFT JOIN Categories c ON c.Id = t.CategoryId
                                    WHERE t.UserId = @uid
                                      AND datetime(t.TransactionDate) BETWEEN datetime(@from) AND datetime(@to)
                                    ORDER BY datetime(t.TransactionDate) DESC";
                cmd.Parameters.AddWithValue("@uid", currentUserId);
                cmd.Parameters.AddWithValue("@from", from.ToString("s"));
                cmd.Parameters.AddWithValue("@to", to.ToString("s"));

                using (var r = cmd.ExecuteReader())
                {
                    while (r.Read()) result.Add(MapTransaction(r));
                }
            }
            }

            return result;
        }

        public bool Add(Transaction transaction)
        {
            if (transaction == null || transaction.Amount <= 0) return false;
            var currentUserId = MockUserService.CurrentUserId;
            if (currentUserId <= 0) return false;

            using (var conn = _dbHelper.CreateConnection())
            {
                conn.Open();

            int accountId = transaction.AccountId > 0 ? transaction.AccountId : 0;
            if (accountId <= 0)
            {
                using (var accountCmd = (SQLiteCommand)conn.CreateCommand())
                {
                    accountCmd.CommandText = "SELECT Id FROM Accounts WHERE UserId = @uid ORDER BY Id LIMIT 1";
                    accountCmd.Parameters.AddWithValue("@uid", currentUserId);
                    var accountObj = accountCmd.ExecuteScalar();
                    if (accountObj == null || accountObj == DBNull.Value) return false;
                    accountId = Convert.ToInt32(accountObj);
                }
            }

            using (var cmd = (SQLiteCommand)conn.CreateCommand())
            {
                cmd.CommandText = @"INSERT INTO Transactions
                                    (AccountId, CategoryId, UserId, Amount, Type, Note, TransactionDate, CreatedAt, ImportSource)
                                    VALUES (@AccountId, @CategoryId, @UserId, @Amount, @Type, @Note, @TransactionDate, @CreatedAt, @ImportSource)";
                cmd.Parameters.AddWithValue("@AccountId", accountId);
                cmd.Parameters.AddWithValue("@CategoryId", transaction.CategoryId > 0 ? transaction.CategoryId : 1);
                cmd.Parameters.AddWithValue("@UserId", currentUserId);
                cmd.Parameters.AddWithValue("@Amount", transaction.Amount);
                cmd.Parameters.AddWithValue("@Type", transaction.Type ?? "Expense");
                cmd.Parameters.AddWithValue("@Note", (object)transaction.Note ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@TransactionDate", (transaction.TransactionDate == default(DateTime) ? DateTime.Now : transaction.TransactionDate).ToString("s"));
                cmd.Parameters.AddWithValue("@CreatedAt", (transaction.CreatedAt == default(DateTime) ? DateTime.Now : transaction.CreatedAt).ToString("s"));
                cmd.Parameters.AddWithValue("@ImportSource", (object)transaction.ImportSource ?? DBNull.Value);

                return cmd.ExecuteNonQuery() > 0;
            }
            }
        }

        public bool Update(Transaction transaction)
        {
            if (transaction == null || transaction.Id <= 0) return false;
            var currentUserId = MockUserService.CurrentUserId;
            if (currentUserId <= 0) return false;

            using (var conn = _dbHelper.CreateConnection())
            {
                conn.Open();

            using (var cmd = (SQLiteCommand)conn.CreateCommand())
            {
                cmd.CommandText = @"UPDATE Transactions
                                    SET AccountId = @AccountId,
                                        CategoryId = @CategoryId,
                                        UserId = @UserId,
                                        Amount = @Amount,
                                        Type = @Type,
                                        Note = @Note,
                                        TransactionDate = @TransactionDate,
                                        ImportSource = @ImportSource
                                    WHERE Id = @Id AND UserId = @CurrentUserId";
                cmd.Parameters.AddWithValue("@Id", transaction.Id);
                cmd.Parameters.AddWithValue("@AccountId", transaction.AccountId > 0 ? transaction.AccountId : 1);
                cmd.Parameters.AddWithValue("@CategoryId", transaction.CategoryId > 0 ? transaction.CategoryId : 1);
                cmd.Parameters.AddWithValue("@UserId", currentUserId);
                cmd.Parameters.AddWithValue("@CurrentUserId", currentUserId);
                cmd.Parameters.AddWithValue("@Amount", transaction.Amount);
                cmd.Parameters.AddWithValue("@Type", transaction.Type ?? "Expense");
                cmd.Parameters.AddWithValue("@Note", (object)transaction.Note ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@TransactionDate", (transaction.TransactionDate == default(DateTime) ? DateTime.Now : transaction.TransactionDate).ToString("s"));
                cmd.Parameters.AddWithValue("@ImportSource", (object)transaction.ImportSource ?? DBNull.Value);

                return cmd.ExecuteNonQuery() > 0;
            }
            }
        }

        public bool Delete(int id)
        {
            if (id <= 0) return false;
            var currentUserId = MockUserService.CurrentUserId;
            if (currentUserId <= 0) return false;

            using (var conn = _dbHelper.CreateConnection())
            {
                conn.Open();

            using (var cmd = (SQLiteCommand)conn.CreateCommand())
            {
                cmd.CommandText = "DELETE FROM Transactions WHERE Id = @Id AND UserId = @CurrentUserId";
                cmd.Parameters.AddWithValue("@Id", id);
                cmd.Parameters.AddWithValue("@CurrentUserId", currentUserId);
                return cmd.ExecuteNonQuery() > 0;
            }
            }
        }

        public decimal GetTotalIncome(DateTime from, DateTime to)
            => GetTotalByType("Income", from, to);

        public decimal GetTotalExpense(DateTime from, DateTime to)
            => GetTotalByType("Expense", from, to);

        private decimal GetTotalByType(string type, DateTime from, DateTime to)
        {
            var currentUserId = MockUserService.CurrentUserId;
            if (currentUserId <= 0) return 0m;

            using (var conn = _dbHelper.CreateConnection())
            {
                conn.Open();

            using (var cmd = (SQLiteCommand)conn.CreateCommand())
            {
                cmd.CommandText = @"SELECT IFNULL(SUM(Amount), 0)
                                    FROM Transactions
                                    WHERE Type = @type
                                      AND UserId = @uid
                                      AND datetime(TransactionDate) BETWEEN datetime(@from) AND datetime(@to)";
                cmd.Parameters.AddWithValue("@type", type);
                cmd.Parameters.AddWithValue("@uid", currentUserId);
                cmd.Parameters.AddWithValue("@from", from.ToString("s"));
                cmd.Parameters.AddWithValue("@to", to.ToString("s"));

                return Convert.ToDecimal(cmd.ExecuteScalar());
            }
            }
        }

        private static Transaction MapTransaction(SQLiteDataReader r)
        {
            return new Transaction
            {
                Id = Convert.ToInt32(r["Id"]),
                AccountId = Convert.ToInt32(r["AccountId"]),
                CategoryId = Convert.ToInt32(r["CategoryId"]),
                UserId = Convert.ToInt32(r["UserId"]),
                Amount = Convert.ToDecimal(r["Amount"]),
                Type = r["Type"].ToString(),
                Note = r["Note"] == DBNull.Value ? null : r["Note"].ToString(),
                TransactionDate = DateTime.TryParse(r["TransactionDate"].ToString(), out var txDate) ? txDate : DateTime.Now,
                CreatedAt = DateTime.TryParse(r["CreatedAt"].ToString(), out var createdAt) ? createdAt : DateTime.Now,
                ImportSource = r["ImportSource"] == DBNull.Value ? null : r["ImportSource"].ToString(),
                CategoryName = r["CategoryName"] == DBNull.Value ? null : r["CategoryName"].ToString()
            };
        }
    }
}