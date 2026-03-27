using System;
using System.Collections.Generic;
using PersonalFinanceManager.Common.Interfaces;
using PersonalFinanceManager.Models;

namespace PersonalFinanceManager.BLL.Services
{
    public class GoalService : IGoalService
    {
        private readonly IGoalRepository _goalRepository;
        private readonly IUserService _userService;

        public event EventHandler GoalChanged;

        public GoalService(IGoalRepository goalRepository, IUserService userService)
        {
            _goalRepository = goalRepository;
            _userService = userService;
        }

        private int GetCurrentUserId()
        {
            var user = _userService?.GetCurrentUser();
            return user?.Id ?? 0;
        }

        public IEnumerable<Goal> GetAll()
        {
            return _goalRepository.GetAll(GetCurrentUserId());
        }

        public Goal GetById(int id)
        {
            return _goalRepository.GetById(id);
        }

        public bool Add(Goal goal)
        {
            goal.UserId = GetCurrentUserId();
            bool result = _goalRepository.Insert(goal) > 0;
            if (result) GoalChanged?.Invoke(this, EventArgs.Empty);
            return result;
        }

        public bool Update(Goal goal)
        {
            bool result = _goalRepository.Update(goal);
            if (result) GoalChanged?.Invoke(this, EventArgs.Empty);
            return result;
        }

        public bool Delete(int id)
        {
            bool result = _goalRepository.Delete(id);
            if (result) GoalChanged?.Invoke(this, EventArgs.Empty);
            return result;
        }

        public decimal GetTotalTarget()
        {
            return _goalRepository.GetTotalTarget(GetCurrentUserId());
        }

        public decimal GetTotalCurrent()
        {
            return _goalRepository.GetTotalCurrent(GetCurrentUserId());
        }
    }
}
