using System.Collections.Generic;
using Dapper;
using PersonalFinanceManager.Common.Helpers;
using PersonalFinanceManager.Common.Interfaces;
using PersonalFinanceManager.DAL.Base;
using PersonalFinanceManager.Models;

namespace PersonalFinanceManager.DAL.Repositories
{
    public class CategoryRepository : BaseRepository<Category>, ICategoryRepository
    {
        protected override string TableName => "Categories";

        public CategoryRepository(DbHelper dbHelper) : base(dbHelper) { }

        public override int Insert(Category entity)
        {
            using (var conn = _dbHelper.CreateConnection())
            {
                const string sql = @"
                    INSERT INTO Categories (Name, Type, IconName, ColorHex, IsDefault, ParentCategoryId, BudgetLimit, UserId)
                    VALUES (@Name, @Type, @IconName, @ColorHex, @IsDefault, @ParentCategoryId, @BudgetLimit, @UserId);
                    SELECT last_insert_rowid();";
                int newId = conn.ExecuteScalar<int>(sql, entity);
                ClearCache();
                return newId;
            }
        }

        public override bool Update(Category entity)
        {
            using (var conn = _dbHelper.CreateConnection())
            {
                const string sql = @"
                    UPDATE Categories
                    SET Name = @Name,
                        Type = @Type,
                        IconName = @IconName,
                        ColorHex = @ColorHex,
                        IsDefault = @IsDefault,
                        ParentCategoryId = @ParentCategoryId,
                        BudgetLimit = @BudgetLimit,
                        UserId = @UserId
                    WHERE Id = @Id";
                bool updated = conn.Execute(sql, entity) > 0;
                if (updated) ClearCache(entity.Id);
                return updated;
            }
        }

        public IEnumerable<Category> GetByUserId(int userId)
        {
            using (var conn = _dbHelper.CreateConnection())
            {
                const string sql = "SELECT * FROM Categories WHERE UserId = @UserId OR (IsDefault = 1 AND UserId IS NULL)";
                return conn.Query<Category>(sql, new { UserId = userId });
            }
        }

        public IEnumerable<Category> GetByType(int userId, string type)
        {
            using (var conn = _dbHelper.CreateConnection())
            {
                const string sql = "SELECT * FROM Categories WHERE Type = @Type AND (UserId = @UserId OR (IsDefault = 1 AND UserId IS NULL))";
                return conn.Query<Category>(sql, new { Type = type, UserId = userId });
            }
        }

        public IEnumerable<Category> GetDefaults()
        {
            using (var conn = _dbHelper.CreateConnection())
            {
                const string sql = "SELECT * FROM Categories WHERE IsDefault = 1";
                return conn.Query<Category>(sql);
            }
        }
    }
}
