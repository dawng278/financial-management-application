// File: PersonalFinanceManager.BLL/Services/StatisticsService.cs
namespace PersonalFinanceManager.BLL.Services
{
    public class StatisticsService
    {
        [cite_start]// Tính tổng chi tiêu theo danh mục 
        public Dictionary<string, decimal> GetSpendingByCategory(int userId, DateTime month)
        {
            // Logic gọi Repository để lấy data và GroupBy danh mục
            [cite_start]// Output này sẽ được Member C dùng để vẽ biểu đồ LiveCharts [cite: 12]
            return new Dictionary<string, decimal>();
        }
    }
}