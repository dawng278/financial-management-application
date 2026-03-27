using System;
using System.Data;
using System.Data.SQLite;
using System.IO;

namespace PersonalFinanceManager.Common.Helpers
{
    public class DbHelper
    {
        private readonly string _connectionString;
        private readonly string _dbPath;

        public DbHelper()
        {
            _dbPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "PersonalFinance.db");
            _connectionString = $"Data Source={_dbPath};Version=3;";

            EnsureDatabaseInitialized();
        }

        public IDbConnection CreateConnection()
        {
            return new SQLiteConnection(_connectionString);
        }

        public bool DatabaseExists()
        {
            return File.Exists(_dbPath);
        }

        private void EnsureDatabaseInitialized()
        {
            if (!File.Exists(_dbPath))
            {
                SQLiteConnection.CreateFile(_dbPath);
            }

            using (var conn = new SQLiteConnection(_connectionString))
            {
                conn.Open();

                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandText = @"
CREATE TABLE IF NOT EXISTS Users (
    Id INTEGER PRIMARY KEY AUTOINCREMENT,
    Username TEXT NOT NULL UNIQUE,
    PasswordHash TEXT NOT NULL,
    FullName TEXT,
    Email TEXT UNIQUE,
    CreatedAt TEXT NOT NULL,
    IsActive INTEGER NOT NULL DEFAULT 1
);

CREATE TABLE IF NOT EXISTS Accounts (
    Id INTEGER PRIMARY KEY AUTOINCREMENT,
    UserId INTEGER NOT NULL,
    AccountName TEXT NOT NULL,
    AccountType TEXT NOT NULL,
    Balance REAL NOT NULL DEFAULT 0,
    Currency TEXT NOT NULL DEFAULT 'VND',
    CreatedAt TEXT NOT NULL,
    IsActive INTEGER NOT NULL DEFAULT 1
);

CREATE TABLE IF NOT EXISTS Categories (
    Id INTEGER PRIMARY KEY AUTOINCREMENT,
    Name TEXT NOT NULL,
    Type TEXT NOT NULL,
    IconName TEXT,
    ColorHex TEXT,
    IsDefault INTEGER NOT NULL DEFAULT 0,
    ParentCategoryId INTEGER NULL,
    BudgetLimit REAL NOT NULL DEFAULT 0
);

CREATE TABLE IF NOT EXISTS Transactions (
    Id INTEGER PRIMARY KEY AUTOINCREMENT,
    AccountId INTEGER NOT NULL,
    CategoryId INTEGER NOT NULL,
    UserId INTEGER NOT NULL,
    Amount REAL NOT NULL,
    Type TEXT NOT NULL,
    Note TEXT,
    TransactionDate TEXT NOT NULL,
    CreatedAt TEXT NOT NULL,
    ImportSource TEXT
);

CREATE TABLE IF NOT EXISTS Invoices (
    Id INTEGER PRIMARY KEY AUTOINCREMENT,
    UserId INTEGER NOT NULL,
    InvoiceNumber TEXT NOT NULL,
    ClientName TEXT NOT NULL,
    BilledTo TEXT,
    InvoiceDate TEXT NOT NULL,
    DueDate TEXT,
    OrderType TEXT,
    Amount REAL NOT NULL,
    Status TEXT NOT NULL,
    CreatedAt TEXT NOT NULL
);

CREATE TABLE IF NOT EXISTS Goals (
    Id INTEGER PRIMARY KEY AUTOINCREMENT,
    UserId INTEGER NOT NULL,
    Title TEXT NOT NULL,
    TargetDate TEXT NOT NULL,
    TargetAmount REAL NOT NULL,
    CurrentAmount REAL NOT NULL DEFAULT 0,
    ColorHex TEXT,
    CreatedAt TEXT NOT NULL
);";
                    cmd.ExecuteNonQuery();

                    // Migration for Categories table
                    try
                    {
                        cmd.CommandText = "ALTER TABLE Categories ADD COLUMN BudgetLimit REAL NOT NULL DEFAULT 0;";
                        cmd.ExecuteNonQuery();
                    }
                    catch { /* Column might already exist */ }

                    cmd.CommandText = @"
INSERT INTO Users (Username, PasswordHash, FullName, Email, CreatedAt, IsActive)
SELECT 'admin', 'admin', 'Administrator', 'admin', datetime('now'), 1
WHERE NOT EXISTS (SELECT 1 FROM Users WHERE Username = 'admin');

INSERT INTO Accounts (UserId, AccountName, AccountType, Balance, Currency, CreatedAt, IsActive)
SELECT 1, 'Ví tiền mặt', 'Cash', 0, 'VND', datetime('now'), 1
WHERE NOT EXISTS (SELECT 1 FROM Accounts WHERE Id = 1);";
                    cmd.ExecuteNonQuery();
                }
            }
        }
    }
}
