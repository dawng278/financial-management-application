using System;
using System.Collections.Generic;
using PersonalFinanceManager.Models;

namespace PersonalFinanceManager.Common.Interfaces
{
    public interface IGoalService
    {
        IEnumerable<Goal> GetAll();
        Goal GetById(int id);
        bool Add(Goal goal);
        bool Update(Goal goal);
        bool Delete(int id);
        decimal GetTotalTarget();
        decimal GetTotalCurrent();
        event EventHandler GoalChanged;
    }
}
