using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.ML.Data;

namespace PersonalFinanceManager.BLL.ML.Models
{
    public class SpendingData
    {
        [LoadColumn(0)] public float Month { get; set; }
        [LoadColumn(1)] public float Year { get; set; }
        [LoadColumn(2)] public float CategoryId { get; set; } // Thêm danh mục để dự báo chính xác hơn
        [LoadColumn(3)] public float TotalSpent { get; set; } // Đây là giá trị cần dự báo (Label)
    }

    public class SpendingPrediction
    {
        [ColumnName("Score")]
        public float PredictedSpent { get; set; }
    }
}
