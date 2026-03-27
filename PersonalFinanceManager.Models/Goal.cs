using System;

namespace PersonalFinanceManager.Models
{
    public class Goal
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string Title { get; set; }
        public DateTime TargetDate { get; set; }
        public decimal TargetAmount { get; set; }
        public decimal CurrentAmount { get; set; }
        public string ColorHex { get; set; }
        public DateTime CreatedAt { get; set; }
        
        public int ProgressPercentage
        {
            get
            {
                if (TargetAmount <= 0) return 0;
                int pct = (int)(CurrentAmount / TargetAmount * 100);
                return pct > 100 ? 100 : pct;
            }
        }
    }
}
