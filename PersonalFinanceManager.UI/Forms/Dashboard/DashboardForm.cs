using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using PersonalFinanceManager.UI.Mock;
using Guna.Charts.WinForms;

namespace PersonalFinanceManager.Forms.Dashboard
{
    public partial class DashboardForm : Form
    {
        public DashboardForm()
        {
            InitializeComponent();
        }

        private void DashboardForm_Load(object sender, EventArgs e)
        {
            RenderDashboard();
            AdjustLabelPositions();
        }

        private void RenderDashboard()
        {
            try
            {
                // 1. Lấy dữ liệu từ file MockTransactionService.cs
                var list = MockTransactionService.GetData();
                double totalBalance = 0, totalThu = 0, totalChi = 0;

                // 2. Khởi tạo 2 Dataset để so sánh Thu và Chi theo ngày
                var thuDataset = new GunaBarDataset();
                thuDataset.Label = "Thu nhập";
                thuDataset.FillColors.Add(Color.FromArgb(0, 126, 249)); // Màu xanh sáng
                thuDataset.TargetChart = gunaChart1;

                var chiDataset = new GunaBarDataset();
                chiDataset.Label = "Chi tiêu";
                chiDataset.FillColors.Add(Color.FromArgb(46, 51, 73)); // Màu tối hơn (Navy đậm)
                chiDataset.TargetChart = gunaChart1;

                // 3. Xử lý logic gom nhóm theo Ngày (Ngay)
                // Lấy danh sách các ngày duy nhất để làm trục X
                var dates = list.Select(x => x.Ngay).Distinct().OrderBy(x => x).ToList();

                foreach (var date in dates)
                {
                    // Tính tổng thu và tổng chi của ngày đó
                    double thuTrongNgay = list.Where(x => x.Ngay == date && x.SoTien > 0).Sum(x => x.SoTien);
                    double chiTrongNgay = Math.Abs(list.Where(x => x.Ngay == date && x.SoTien < 0).Sum(x => x.SoTien));

                    // Thêm dữ liệu vào biểu đồ
                    thuDataset.DataPoints.Add(date, thuTrongNgay);
                    chiDataset.DataPoints.Add(date, chiTrongNgay);
                }

                // 4. Tính toán tổng số để hiển thị lên các Label
                foreach (var item in list)
                {
                    totalBalance += item.SoTien;
                    if (item.SoTien > 0) totalThu += item.SoTien;
                    else totalChi += Math.Abs(item.SoTien);
                }

                if (label4 != null) label4.Text = totalBalance.ToString("N0") + " VND";
                if (label5 != null) label5.Text = "+" + totalThu.ToString("N0") + " VND";
                if (label6 != null) label6.Text = "-" + totalChi.ToString("N0") + " VND";

                // 5. CẤU HÌNH BIỂU ĐỒ
                if (gunaChart1 != null)
                {
                    gunaChart1.Datasets.Clear();
                    gunaChart1.Datasets.Add(thuDataset);
                    gunaChart1.Datasets.Add(chiDataset);

                    // Tự động giãn trục Y theo số tiền lớn nhất (Lương 2tr)
                    gunaChart1.YAxes.Ticks.Minimum = 0;
                    gunaChart1.YAxes.GridLines.Display = true;

                    // Cấu hình chú thích (Legend) để phân biệt Thu/Chi
                    gunaChart1.Legend.Display = true;
                    gunaChart1.Legend.Position = LegendPosition.Top;

                    gunaChart1.Update();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi hiển thị: " + ex.Message);
            }
        }

        private void AdjustLabelPositions()
        {
            if (label4 != null && label1 != null)
                label4.Location = new Point(label1.Location.X, label1.Location.Y + 25);
            if (label5 != null && label2 != null)
                label5.Location = new Point(label2.Location.X, label2.Location.Y + 25);
            if (label6 != null && label3 != null)
                label6.Location = new Point(label3.Location.X, label3.Location.Y + 25);
        }
    }
}