using PersonalFinanceManager.Common.Models;
using System.Collections.Generic;
using System.Linq;

namespace PersonalFinanceManager.BLL.Services
{
    public class StatisticsService
    {
        // Giả sử bạn đã có Repository để lấy dữ liệu từ DAL
        public StatisticsDto GetDashboardStats(int userId)
        {
            // Logic mẫu:
            return new StatisticsDto
            {
                AverageSpending = 5000000, // Gọi hàm CalculateAverage()
                TopCategories = new List<CategorySummary>(), // Gọi GetTopCategories()
                MonthlyTrends = new List<MonthlyTrendItem>() // Gọi MonthlyTrend()
            };
        }
    }
}