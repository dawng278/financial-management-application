using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using PersonalFinanceManager.Common.Helpers;
using PersonalFinanceManager.Common.Interfaces;
using PersonalFinanceManager.Models;

namespace PersonalFinanceManager.DAL.Repositories
{
    public class GoalRepository : IGoalRepository
    {
        private readonly DbHelper _dbHelper;

        public GoalRepository(DbHelper dbHelper)
        {
            _dbHelper = dbHelper;
        }

        public IEnumerable<Goal> GetAll(int userId)
        {
            var goals = new List<Goal>();
            using (var conn = _dbHelper.CreateConnection())
            {
                conn.Open();
                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandText = "SELECT * FROM Goals WHERE UserId = @UserId ORDER BY CreatedAt DESC";
                    var p = cmd.CreateParameter();
                    p.ParameterName = "@UserId";
                    p.Value = userId;
                    cmd.Parameters.Add(p);

                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            goals.Add(MapToGoal(reader));
                        }
                    }
                }
            }
            return goals;
        }

        public Goal GetById(int id)
        {
            using (var conn = _dbHelper.CreateConnection())
            {
                conn.Open();
                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandText = "SELECT * FROM Goals WHERE Id = @Id";
                    var p = cmd.CreateParameter();
                    p.ParameterName = "@Id";
                    p.Value = id;
                    cmd.Parameters.Add(p);

                    using (var reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            return MapToGoal(reader);
                        }
                    }
                }
            }
            return null;
        }

        public int Insert(Goal goal)
        {
            using (var conn = _dbHelper.CreateConnection())
            {
                conn.Open();
                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandText = @"
INSERT INTO Goals (UserId, Title, TargetDate, TargetAmount, CurrentAmount, ColorHex, CreatedAt)
VALUES (@UserId, @Title, @TargetDate, @TargetAmount, @CurrentAmount, @ColorHex, @CreatedAt);
SELECT last_insert_rowid();";
                    
                    cmd.Parameters.Add(CreateParam(cmd, "@UserId", goal.UserId));
                    cmd.Parameters.Add(CreateParam(cmd, "@Title", goal.Title));
                    cmd.Parameters.Add(CreateParam(cmd, "@TargetDate", goal.TargetDate.ToString("yyyy-MM-dd HH:mm:ss")));
                    cmd.Parameters.Add(CreateParam(cmd, "@TargetAmount", goal.TargetAmount));
                    cmd.Parameters.Add(CreateParam(cmd, "@CurrentAmount", goal.CurrentAmount));
                    cmd.Parameters.Add(CreateParam(cmd, "@ColorHex", goal.ColorHex));
                    cmd.Parameters.Add(CreateParam(cmd, "@CreatedAt", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")));

                    return Convert.ToInt32(cmd.ExecuteScalar());
                }
            }
        }

        public bool Update(Goal goal)
        {
            using (var conn = _dbHelper.CreateConnection())
            {
                conn.Open();
                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandText = @"
UPDATE Goals SET 
    Title = @Title, 
    TargetDate = @TargetDate, 
    TargetAmount = @TargetAmount, 
    CurrentAmount = @CurrentAmount, 
    ColorHex = @ColorHex 
WHERE Id = @Id";
                    
                    cmd.Parameters.Add(CreateParam(cmd, "@Title", goal.Title));
                    cmd.Parameters.Add(CreateParam(cmd, "@TargetDate", goal.TargetDate.ToString("yyyy-MM-dd HH:mm:ss")));
                    cmd.Parameters.Add(CreateParam(cmd, "@TargetAmount", goal.TargetAmount));
                    cmd.Parameters.Add(CreateParam(cmd, "@CurrentAmount", goal.CurrentAmount));
                    cmd.Parameters.Add(CreateParam(cmd, "@ColorHex", goal.ColorHex));
                    cmd.Parameters.Add(CreateParam(cmd, "@Id", goal.Id));

                    return cmd.ExecuteNonQuery() > 0;
                }
            }
        }

        public bool Delete(int id)
        {
            using (var conn = _dbHelper.CreateConnection())
            {
                conn.Open();
                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandText = "DELETE FROM Goals WHERE Id = @Id";
                    cmd.Parameters.Add(CreateParam(cmd, "@Id", id));
                    return cmd.ExecuteNonQuery() > 0;
                }
            }
        }

        public decimal GetTotalTarget(int userId)
        {
            using (var conn = _dbHelper.CreateConnection())
            {
                conn.Open();
                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandText = "SELECT SUM(TargetAmount) FROM Goals WHERE UserId = @UserId";
                    cmd.Parameters.Add(CreateParam(cmd, "@UserId", userId));
                    var result = cmd.ExecuteScalar();
                    return result != DBNull.Value ? Convert.ToDecimal(result) : 0;
                }
            }
        }

        public decimal GetTotalCurrent(int userId)
        {
            using (var conn = _dbHelper.CreateConnection())
            {
                conn.Open();
                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandText = "SELECT SUM(CurrentAmount) FROM Goals WHERE UserId = @UserId";
                    cmd.Parameters.Add(CreateParam(cmd, "@UserId", userId));
                    var result = cmd.ExecuteScalar();
                    return result != DBNull.Value ? Convert.ToDecimal(result) : 0;
                }
            }
        }

        private IDbDataParameter CreateParam(IDbCommand cmd, string name, object value)
        {
            var p = cmd.CreateParameter();
            p.ParameterName = name;
            p.Value = value ?? DBNull.Value;
            return p;
        }

        private Goal MapToGoal(IDataReader reader)
        {
            return new Goal
            {
                Id = Convert.ToInt32(reader["Id"]),
                UserId = Convert.ToInt32(reader["UserId"]),
                Title = reader["Title"].ToString(),
                TargetDate = DateTime.ParseExact(reader["TargetDate"].ToString(), "yyyy-MM-dd HH:mm:ss", CultureInfo.InvariantCulture),
                TargetAmount = Convert.ToDecimal(reader["TargetAmount"]),
                CurrentAmount = Convert.ToDecimal(reader["CurrentAmount"]),
                ColorHex = reader["ColorHex"].ToString(),
                CreatedAt = DateTime.ParseExact(reader["CreatedAt"].ToString(), "yyyy-MM-dd HH:mm:ss", CultureInfo.InvariantCulture)
            };
        }
    }
}
