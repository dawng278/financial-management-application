using iTextSharp.text;
using iTextSharp.text.pdf;
using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace PersonalFinanceManager.Controls
{
    public static class ExportHelper
    {
        
        public static void ExportToExcel(DataGridView dgv, string filePath)
        {

            // CÁCH VIẾT CHO BẢN 8.5.0:
            ExcelPackage.License.SetNonCommercialPersonal("Personal Finance Manager");

            try
            {
                // Kiểm tra xem file có đang mở không trước khi ghi
                if (File.Exists(filePath))
                {
                    File.Delete(filePath);
                }

                using (var package = new OfficeOpenXml.ExcelPackage())
                {
                    package.Workbook.Properties.Author = "Personal Finance Manager";
                    package.Workbook.Properties.Title = "Báo cáo chi tiêu";
                    var sheet = package.Workbook.Worksheets.Add("Báo cáo");

                    // 1. Xuất tiêu đề cột
                    for (int i = 0; i < dgv.Columns.Count; i++)
                    {
                        sheet.Cells[1, i + 1].Value = dgv.Columns[i].HeaderText;
                        sheet.Cells[1, i + 1].Style.Font.Bold = true;
                    }

                    // 2. Xuất dữ liệu từ các dòng
                    for (int i = 0; i < dgv.Rows.Count; i++)
                    {
                        for (int j = 0; j < dgv.Columns.Count; j++)
                        {
                            sheet.Cells[i + 2, j + 1].Value = dgv.Rows[i].Cells[j].Value;
                        }
                    }

                    sheet.Cells.AutoFitColumns();

                    // 3. Lưu file bằng FileInfo (Cách này an toàn hơn cho bản 8.x)
                    FileInfo fi = new FileInfo(filePath);
                    package.SaveAs(fi);
                }
            }
            catch (IOException)
            {
                throw new Exception("File đang mở bởi chương trình khác. Hãy đóng file và thử lại!");
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi hệ thống: " + ex.Message);
            }
        }

        public static void ExportToPdf(DataGridView dgv, string filePath)
        {
            // 1. Khai báo Font tiếng Việt (Cực kỳ quan trọng)
            // Đường dẫn font mặc định của Windows, bạn có thể đổi sang font khác nếu muốn
            string fontPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Fonts), "Arial.ttf");
            BaseFont bf = BaseFont.CreateFont(fontPath, BaseFont.IDENTITY_H, BaseFont.EMBEDDED);
            Font fontNoiDung = new Font(bf, 10, Font.NORMAL);
            Font fontTieuDe = new Font(bf, 12, Font.BOLD);

            // 2. Tạo đối tượng Document (Khổ giấy A4)
            Document pdfDoc = new Document(PageSize.A4, 10f, 10f, 10f, 0f);

            using (FileStream stream = new FileStream(filePath, FileMode.Create))
            {
                PdfWriter.GetInstance(pdfDoc, stream);
                pdfDoc.Open();

                // 3. Tạo bảng PDF có số cột bằng số cột của DataGridView
                PdfPTable pdfTable = new PdfPTable(dgv.Columns.Count);
                pdfTable.WidthPercentage = 100; // Độ rộng bảng chiếm 100% trang

                // 4. Thêm Header (Tiêu đề cột)
                foreach (DataGridViewColumn column in dgv.Columns)
                {
                    PdfPCell cell = new PdfPCell(new Phrase(column.HeaderText, fontTieuDe));
                    cell.BackgroundColor = new BaseColor(240, 240, 240); // Đổ màu nền xám nhẹ
                    cell.HorizontalAlignment = Element.ALIGN_CENTER;
                    pdfTable.AddCell(cell);
                }

                // 5. Thêm dữ liệu từ các dòng
                foreach (DataGridViewRow row in dgv.Rows)
                {
                    if (row.IsNewRow) continue; // Bỏ qua dòng trống cuối cùng

                    foreach (DataGridViewCell cell in row.Cells)
                    {
                        string cellValue = cell.Value?.ToString() ?? "";
                        pdfTable.AddCell(new PdfPCell(new Phrase(cellValue, fontNoiDung)));
                    }
                }

                // 6. Chèn bảng vào Document và đóng lại
                pdfDoc.Add(pdfTable);
                pdfDoc.Close();
                stream.Close();
            }
        }
    }
}
