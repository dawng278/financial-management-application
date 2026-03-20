using Microsoft.ML;
using Microsoft.ML.Trainers.FastTree;
using PersonalFinanceManager.BLL.ML.Models;
using System.Collections.Generic;

namespace PersonalFinanceManager.BLL.ML
{
    public class SpendingPredictor
    {
        private readonly MLContext _mlContext;
        private ITransformer _model;

        public SpendingPredictor()
        {
            // Khởi tạo MLContext với một hạt giống (seed) cố định để kết quả ổn định
            _mlContext = new MLContext(seed: 1);
        }

        // 1. Hàm Huấn luyện mô hình
        public void TrainModel(List<SpendingData> trainingData)
        {
            // Chuyển đổi List dữ liệu sang IDataView
            IDataView dataView = _mlContext.Data.LoadFromEnumerable(trainingData);

            // Định nghĩa Pipeline xử lý
            var pipeline = _mlContext.Transforms.Concatenate("Features", "Month", "Year", "CategoryId")
                .Append(_mlContext.Regression.Trainers.FastTree(labelColumnName: "TotalSpent", numberOfTrees: 100));

            // Huấn luyện
            _model = pipeline.Fit(dataView);
        }

        // 2. Hàm Dự báo số tiền chi tiêu
        public float Predict(float month, float year, float categoryId)
        {
            if (_model == null) return 0;

            // Tạo bộ máy dự đoán (Prediction Engine)
            var predictionEngine = _mlContext.Model.CreatePredictionEngine<SpendingData, SpendingPrediction>(_model);

            var input = new SpendingData
            {
                Month = month,
                Year = year,
                CategoryId = categoryId
            };

            var result = predictionEngine.Predict(input);
            return result.PredictedSpent;
        }
    }
}