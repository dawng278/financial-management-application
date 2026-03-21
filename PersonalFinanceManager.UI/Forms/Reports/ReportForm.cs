using Guna.UI2.WinForms;
using PersonalFinanceManager.Controls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity.Infrastructure;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Management;
using System.Text;
using System.Threading.Tasks;
using System.Web.Util;
using System.Windows.Forms;

namespace PersonalFinanceManager.Forms.Reports
{
    public partial class ReportForm : Form
    {
        
        public ReportForm()
        {
            InitializeComponent();
        }
        private DataTable GetTransactionData(DateTime fromDate, DateTime toDate, string type)
        {
            // 1. Tạo cấu trúc bảng giống hệt như trong Database thật
            DataTable dt = new DataTable();
            dt.Columns.Add("Ngày", typeof(DateTime));
            dt.Columns.Add("Mô tả", typeof(string));
            dt.Columns.Add("Loại", typeof(string));
            dt.Columns.Add("Số tiền", typeof(decimal));

            // 2. Thêm một vài dòng dữ liệu giả để test
            // Bạn có thể thêm bao nhiêu tùy thích
            dt.Rows.Add(new DateTime(2026, 3, 10), "Mua giáo trình IT", "Chi", 150000);
            dt.Rows.Add(new DateTime(2026, 3, 12), "Lương làm thêm", "Thu", 2000000);
            dt.Rows.Add(new DateTime(2026, 3, 15), "Tiền ăn sáng", "Chi", 30000);
            dt.Rows.Add(new DateTime(2026, 3, 18), "Thưởng dự án C#", "Thu", 500000);
            dt.Rows.Add(new DateTime(2026, 3, 19), "Mua chuột máy tính", "Chi", 350000);

            // 3. Logic lọc dữ liệu giả (để khi bạn chỉnh DatePicker nó vẫn có phản hồi)
            DataTable dtFiltered = dt.Clone(); // Tạo bảng trống có cùng cấu trúc

            foreach (DataRow row in dt.Rows)
            {
                DateTime rowDate = (DateTime)row["Ngày"];
                string rowType = row["Loại"].ToString();

                // Kiểm tra xem dòng này có nằm trong khoảng ngày và đúng loại không
                bool matchDate = rowDate >= fromDate && rowDate <= toDate;
                bool matchType = string.IsNullOrEmpty(type) || type == "Tất cả" || rowType == type;

                if (matchDate && matchType)
                {
                    dtFiltered.ImportRow(row);
                }
            }

            return dtFiltered;
        }
        private void btnFilter_Click(object sender, EventArgs e)
        {
            // Lấy thông tin từ giao diện
            DateTime tuNgay = dtpFrom.Value.Date;
            DateTime denNgay = dtpTo.Value.Date;
            string loai = cboType.SelectedItem?.ToString();

            // Lấy dữ liệu giả
            DataTable dt = GetTransactionData(tuNgay, denNgay, loai);

            // Hiển thị lên DataGridView
            dgvReports.DataSource = dt;

            // Tính tổng tiền (như tớ đã hướng dẫn ở trên)
            CalculateSummary(dt);
        }

        private void CalculateSummary(DataTable dt)
        {
            decimal totalIn = 0;
            decimal totalOut = 0;

            foreach (DataRow row in dt.Rows)
            {
                // Giả sử cột 'Loai' và 'SoTien' tồn tại trong DB
                string type = row["Loại"].ToString();
                decimal amount = Convert.ToDecimal(row["Số Tiền"]);

                if (type == "Thu") totalIn += amount;
                else totalOut += amount;
            }

            lblTotalIn.Text = $"Tổng Thu: {totalIn:N0}đ";
            lblTotalOut.Text = $"Tổng Chi: {totalOut:N0}đ";
            lblBalance.Text = $"Số dư kỳ: {(totalIn - totalOut):N0}đ";
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            // 1. Kiểm tra xem DataGridView có dữ liệu không
            if (dgvReports.Rows.Count == 0)
            {
                MessageBox.Show("Không có dữ liệu để xuất!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // 2. Mở hộp thoại lưu file
            using (SaveFileDialog sfd = new SaveFileDialog())
            {
                sfd.Filter = "Excel Workbook|*.xlsx";
                sfd.FileName = "BaoCao_Excel_" + DateTime.Now.ToString("yyyyMMdd_HHmm");

                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        // GỌI CLASS EXPORT
                        ExportHelper.ExportToExcel(dgvReports, sfd.FileName);

                        MessageBox.Show("Xuất Excel thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Lỗi: " + ex.Message, "Lỗi hệ thống", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void btnExportPdf_Click(object sender, EventArgs e)
        {
            if (dgvReports.Rows.Count == 0)
            {
                MessageBox.Show("Không có dữ liệu để xuất PDF!", "Thông báo");
                return;
            }

            using (SaveFileDialog sfd = new SaveFileDialog())
            {
                sfd.Filter = "PDF File|*.pdf";
                sfd.FileName = "BaoCao_TaiChinh_" + DateTime.Now.ToString("yyyyMMdd");

                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        // GỌI CLASS EXPORT
                        ExportHelper.ExportToPdf(dgvReports, sfd.FileName);

                        MessageBox.Show("Xuất PDF thành công!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        // Gợi ý: Tự động mở file sau khi xuất xong (tùy chọn)
                        // System.Diagnostics.Process.Start(sfd.FileName); 
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Không thể xuất PDF. Chi tiết: " + ex.Message);
                    }
                }
            }
        }

        private void ReportForm_Load(object sender, EventArgs e)
        {
            guna2Transition1.ShowSync(dgvReports);
        }
    }
}
