using System;
using System.Data;
using System.Data.SQLite;
using System.IO;

namespace PersonalFinanceManager.Common.Helpers
{
    public class DbHelper
    {
        private readonly string _connectionString;

        public DbHelper()
        {
            // Database nằm cùng thư mục với file .exe
            string dbPath = Path.Combine(
                AppDomain.CurrentDomain.BaseDirectory,
                "PersonalFinance.db"
            );
            _connectionString = $"Data Source={dbPath};Version=3;";
        }

        /// <summary>
        /// Mở connection - Dapper/Repository sẽ tự đóng sau khi dùng xong
        /// </summary>
        public IDbConnection CreateConnection()
        {
            return new SQLiteConnection(_connectionString);
        }

        /// <summary>
        /// Kiểm tra database có tồn tại không - dùng khi app khởi động
        /// </summary>
        public bool DatabaseExists()
        {
            string dbPath = Path.Combine(
                AppDomain.CurrentDomain.BaseDirectory,
                "PersonalFinance.db"
            );
            return File.Exists(dbPath);
        }
    }
}