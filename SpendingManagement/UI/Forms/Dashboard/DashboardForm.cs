using Guna.Charts.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;


namespace SpendingManagement.UI.Forms.Dashboard
{
    public partial class DashboardForm : Form
    {
        public DashboardForm()
        {
            InitializeComponent();
        }

        private void DashboardForm_Load(object sender, EventArgs e)
        {
            // 1. Khởi tạo Dataset ngay trong code (Không cần Add trong Design nữa)
            var barDataset = new Guna.Charts.WinForms.GunaBarDataset();
            barDataset.Label = "Chi tiêu tuần này";

            // 2. Chỉnh màu sắc cho Dataset (Dùng Navy cho chuẩn bài)
            barDataset.FillColors.Add(Color.Navy);

            // 3. Thêm dữ liệu giả
            barDataset.DataPoints.Add("T2", 200);
            barDataset.DataPoints.Add("T3", 450);
            barDataset.DataPoints.Add("T4", 300);
            barDataset.DataPoints.Add("T5", 600);
            barDataset.DataPoints.Add("T6", 150);
            barDataset.DataPoints.Add("T7", 800);
            barDataset.DataPoints.Add("CN", 500);

            // 4. Xóa hết dữ liệu cũ (nếu có) và add dataset mới vào gunaChart1
            gunaChart1.Datasets.Clear();
            gunaChart1.Datasets.Add(barDataset);

            // 5. Cấu hình trục biểu đồ cho đẹp
            gunaChart1.XAxes.GridLines.Display = false; // Tắt lưới dọc cho sạch

            // Cập nhật lại biểu đồ
            gunaChart1.Update();
        }
    }
}
