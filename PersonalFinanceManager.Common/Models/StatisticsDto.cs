using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonalFinanceManager.Common.Models
{
    public class StatisticsDto
    {
        public decimal AverageSpending { get; set; }
        public List<CategorySummary> TopCategories { get; set; }
        public List<MonthlyTrendItem> MonthlyTrends { get; set; }
    }

    public class CategorySummary { public string Name { get; set; } public decimal Total { get; set; } }
    public class MonthlyTrendItem { public string Month { get; set; } public decimal Amount { get; set; } }
}
