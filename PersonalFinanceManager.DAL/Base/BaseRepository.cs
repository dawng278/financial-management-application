using System.Collections.Generic;
using Dapper;
using PersonalFinanceManager.Common.Helpers;
using PersonalFinanceManager.Common.Interfaces;

namespace PersonalFinanceManager.DAL.Base
{
    /// <summary>
    /// Class cha cho tất cả Repository.
    /// B kế thừa: class AccountRepository : BaseRepository<Account>, IAccountRepository
    /// </summary>
    public abstract class BaseRepository<T> : IBaseRepository<T> where T : class
    {
        // DbHelper được inject vào — không new() trực tiếp trong đây
        protected readonly DbHelper _dbHelper;

        // Tên bảng trong SQLite, class con tự khai báo
        // VD: AccountRepository sẽ set TableName = "Accounts"
        protected abstract string TableName { get; }

        protected BaseRepository(DbHelper dbHelper)
        {
            _dbHelper = dbHelper;
        }

        public virtual T GetById(int id)
        {
            using (var conn = _dbHelper.CreateConnection())
            {
                string sql = $"SELECT * FROM {TableName} WHERE Id = @Id";
                return conn.QueryFirstOrDefault<T>(sql, new { Id = id });
            }
        }

        public virtual IEnumerable<T> GetAll()
        {
            using (var conn = _dbHelper.CreateConnection())
            {
                string sql = $"SELECT * FROM {TableName}";
                return conn.Query<T>(sql);
            }
        }

        public virtual int Insert(T entity)
        {
            // Class con PHẢI override cái này vì mỗi bảng có cột khác nhau
            // Nếu B quên override, app sẽ báo lỗi rõ ràng thay vì chạy sai
            throw new System.NotImplementedException(
                $"{GetType().Name} phải override phương thức Insert()");
        }

        public virtual bool Update(T entity)
        {
            throw new System.NotImplementedException(
                $"{GetType().Name} phải override phương thức Update()");
        }

        public virtual bool Delete(int id)
        {
            using (var conn = _dbHelper.CreateConnection())
            {
                string sql = $"DELETE FROM {TableName} WHERE Id = @Id";
                int rows = conn.Execute(sql, new { Id = id });
                return rows > 0;
            }
        }
    }
}