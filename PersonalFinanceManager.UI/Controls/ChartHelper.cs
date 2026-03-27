using LiveCharts;
using LiveCharts.Wpf;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Media;

namespace PersonalFinanceManager.Controls
{
    public static class ChartHelper
    {
        public static void SetupPieData(LiveCharts.WinForms.PieChart chart, Dictionary<string, double> data)
        {
            SeriesCollection series = new SeriesCollection();

            foreach (var item in data)
            {
                series.Add(new PieSeries
                {
                    Title = item.Key,
                    Values = new ChartValues<double> { item.Value },
                    DataLabels = true,
                    LabelPoint = p => $"{p.SeriesView.Title}: {p.Y} ({p.Participation:P1})"
                });
            }

            chart.Series = series;
            chart.LegendLocation = LegendLocation.Right;
        }

        public static void SetupBarChart(LiveCharts.WinForms.CartesianChart chart, List<double> values, string[] months)
        {
            // 1. Định nghĩa dữ liệu cột (Series)
            chart.Series = new SeriesCollection
        {
            new ColumnSeries
            {
                Title = "Số tiền",
                Values = new ChartValues<double>(values),
                DataLabels = true, // Hiển thị số tiền trên đầu cột
                Fill = System.Windows.Media.Brushes.DodgerBlue // Màu sắc cinematic
            }
        };

            // 2. Cấu hình Trục X (Tháng)
            chart.AxisX.Clear(); // Xóa cũ để tránh bị đè dữ liệu
            chart.AxisX.Add(new Axis
            {
                Title = "Tháng trong năm",
                Labels = months,
                Separator = new Separator { Step = 1, IsEnabled = false } // Ẩn lưới dọc cho thoáng
            });

            // 3. Cấu hình Trục Y (Số tiền)
            chart.AxisY.Clear();
            chart.AxisY.Add(new Axis
            {
                Title = "Số dư (VNĐ)",
                LabelFormatter = value => PersonalFinanceManager.Common.Helpers.ConfigHelper.FormatGlobalCurrency((decimal)value) // Định dạng số: 1.000.000
            });

            chart.LegendLocation = LegendLocation.Top;
        }

        public static void SetupLineChart(LiveCharts.WinForms.CartesianChart chart, List<double> values, string[] days)
        {
            chart.Series = new SeriesCollection
        {
            new LineSeries
            {
                Title = "Xu hướng",
                Values = new ChartValues<double>(values),
                PointGeometrySize = 10,       // Kích thước điểm nút
                LineSmoothness = 1,           // Độ mượt (1 là cong mềm mại, 0 là đường thẳng gấp khúc)
                StrokeThickness = 3,
                Stroke = Brushes.DeepSkyBlue, // Màu đường kẻ
                Fill = new SolidColorBrush(Color.FromArgb(30, 0, 191, 255)) // Đổ màu bóng mờ dưới đường kẻ
            }
        };

            chart.AxisX.Clear();
            chart.AxisX.Add(new Axis
            {
                Title = "Ngày",
                Labels = days,
                Separator = new Separator { IsEnabled = false }
            });

            chart.AxisY.Clear();
            chart.AxisY.Add(new Axis
            {
                Title = "Số dư",
                LabelFormatter = value => PersonalFinanceManager.Common.Helpers.ConfigHelper.FormatGlobalCurrency((decimal)value)
            });
        }
    }
}
