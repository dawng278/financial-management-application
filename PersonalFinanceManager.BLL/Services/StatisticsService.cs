<<<<<<< HEAD
// File: PersonalFinanceManager.BLL/Services/StatisticsService.cs
=======
using PersonalFinanceManager.Common.Models;
using System.Collections.Generic;
using System.Linq;

>>>>>>> origin/feature2-update
namespace PersonalFinanceManager.BLL.Services
{
    public class StatisticsService
    {
<<<<<<< HEAD
        [cite_start]// Tính tổng chi tiêu theo danh mục 
        public Dictionary<string, decimal> GetSpendingByCategory(int userId, DateTime month)
        {
            // Logic gọi Repository để lấy data và GroupBy danh mục
            [cite_start]// Output này sẽ được Member C dùng để vẽ biểu đồ LiveCharts [cite: 12]
            return new Dictionary<string, decimal>();
=======
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
>>>>>>> origin/feature2-update
        }
    }
}