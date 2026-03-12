using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using PersonalFinanceManager.UI.Mock;

namespace PersonalFinanceManager.Forms.Transactions
{
    public partial class TransactionListForm : Form
    {
        public TransactionListForm()
        {
            InitializeComponent();
        }

        private void TransactionListForm_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        public void LoadData()
        {
            // Đổ dữ liệu từ Mock Service vào Grid
            dgvTransactions.DataSource = null; // Reset để cập nhật lại
            dgvTransactions.DataSource = MockTransactionService.GetData();

            // Tùy chỉnh tiêu đề cột cho đẹp
            dgvTransactions.Columns["Id"].HeaderText = "Mã";
            dgvTransactions.Columns["Ngay"].HeaderText = "Ngày GD";
            dgvTransactions.Columns["MoTa"].HeaderText = "Mô Tả";
            dgvTransactions.Columns["SoTien"].HeaderText = "Số Tiền";
            dgvTransactions.Columns["Loai"].HeaderText = "Loại";
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            var editForm = new AddEditTransactionForm();
            if (editForm.ShowDialog() == DialogResult.OK)
            {
                LoadData(); // Load lại grid sau khi thêm thành công
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            // 1. Kiểm tra xem người dùng đã chọn dòng nào chưa
            if (dgvTransactions.SelectedRows.Count > 0)
            {
                // 2. Lấy đối tượng TransactionMock từ dòng đang chọn
                var selectedItem = (TransactionMock)dgvTransactions.SelectedRows[0].DataBoundItem;

                // 3. Mở AddEditTransactionForm và truyền đối tượng này vào
                var editForm = new AddEditTransactionForm(selectedItem);

                if (editForm.ShowDialog() == DialogResult.OK)
                {
                    LoadData(); // Load lại Grid để thấy thay đổi
                }
            }
            else
            {
                MessageBox.Show("Vui lòng chọn một giao dịch để sửa!");
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dgvTransactions.SelectedRows.Count > 0)
            {
                // Lấy tên hoặc mô tả để hiển thị trong câu hỏi cho thân thiện
                var selectedItem = (TransactionMock)dgvTransactions.SelectedRows[0].DataBoundItem;

                var confirmResult = MessageBox.Show(
                    $"Bạn có chắc chắn muốn xóa giao dịch '{selectedItem.MoTa}' không?",
                    "Xác nhận xóa",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Warning);

                if (confirmResult == DialogResult.Yes)
                {
                    // Gọi Service để xóa
                    MockTransactionService.Delete(selectedItem.Id);

                    // Load lại bảng
                    LoadData();
                }
            }
            else
            {
                MessageBox.Show("Vui lòng chọn dòng cần xóa!");
            }
        }
    }
}
