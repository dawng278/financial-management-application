using System;

namespace PersonalFinanceManager.Common.Events
{
    public static class GlobalEvents
    {
        public static event EventHandler TransactionAdded;
        public static void OnTransactionAdded() => TransactionAdded?.Invoke(null, EventArgs.Empty);

        public static event EventHandler SettingsSaved;
        public static void OnSettingsSaved() => SettingsSaved?.Invoke(null, EventArgs.Empty);

        public static event EventHandler GoalAdded;
        public static void OnGoalAdded() => GoalAdded?.Invoke(null, EventArgs.Empty);
    }
}
