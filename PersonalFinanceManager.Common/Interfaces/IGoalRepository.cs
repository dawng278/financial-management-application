using System.Collections.Generic;
using PersonalFinanceManager.Models;

namespace PersonalFinanceManager.Common.Interfaces
{
    public interface IGoalRepository
    {
        IEnumerable<Goal> GetAll(int userId);
        Goal GetById(int id);
        int Insert(Goal goal);
        bool Update(Goal goal);
        bool Delete(int id);
        decimal GetTotalTarget(int userId);
        decimal GetTotalCurrent(int userId);
    }
}
