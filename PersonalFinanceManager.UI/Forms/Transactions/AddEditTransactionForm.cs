using PersonalFinanceManager.UI.Mock;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PersonalFinanceManager.Forms.Transactions
{
    public partial class AddEditTransactionForm : Form
    {
        private TransactionMock _editingItem;
        public AddEditTransactionForm()
        {
            InitializeComponent();
            _editingItem = null;
            this.Text = "Thêm Giao Dịch Mới";
        }

        public AddEditTransactionForm(TransactionMock item)
        {
            InitializeComponent();
            _editingItem = item; // Lưu lại đối tượng đang sửa

            // Chỉ cần gọi hàm này, nó sẽ lo việc đổ dữ liệu vào TextBox
            FillData();

            // Cập nhật giao diện
            this.Text = "Chỉnh sửa giao dịch";
            txtId.Enabled = false; // Không cho sửa ID
        }
        private void FillData()
        {
            if (_editingItem != null)
            {
                txtId.Text = _editingItem.Id;
                dtpNgay.Value = DateTime.ParseExact(_editingItem.Ngay, "dd/MM/yyyy", null);
                txtMoTa.Text = _editingItem.MoTa;
                txtSoTien.Text = Math.Abs(_editingItem.SoTien).ToString(); // Hiển thị số dương cho dễ nhìn
                cboLoai.SelectedItem = _editingItem.Loai;
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            // 1. Kiểm tra dữ liệu đầu vào (Validation) sơ bộ
            if (string.IsNullOrEmpty(txtMoTa.Text) || string.IsNullOrEmpty(txtSoTien.Text))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin!");
                return;
            }

            // 2. Thu thập dữ liệu từ các Control
            double soTien = double.Parse(txtSoTien.Text);
            string loai = cboLoai.SelectedItem.ToString();

            // Nếu là "Chi" thì lưu số âm để dễ tính toán sau này
            if (loai == "Chi") soTien = -Math.Abs(soTien);

            if (_editingItem == null) // TRƯỜNG HỢP THÊM MỚI
            {
                var newItem = new TransactionMock
                {
                    Id = (MockTransactionService.GetData().Count + 1).ToString(), // Tạm thời lấy Count + 1 làm ID
                    Ngay = dtpNgay.Value.ToString("dd/MM/yyyy"),
                    MoTa = txtMoTa.Text,
                    SoTien = soTien,
                    Loai = loai
                };
                MockTransactionService.Add(newItem);
            }
            else // TRƯỜNG HỢP CHỈNH SỬA
            {
                _editingItem.Ngay = dtpNgay.Value.ToString("dd/MM/yyyy");
                _editingItem.MoTa = txtMoTa.Text;
                _editingItem.SoTien = soTien;
                _editingItem.Loai = loai;
                // Vì là Mock và dùng chung tham chiếu nên dữ liệu trong List sẽ tự cập nhật
            }

            this.DialogResult = DialogResult.OK; // Đóng form và báo cho Form danh sách biết để load lại Grid
            this.Close();
        }
        private void txtSoTien_KeyPress_1(object sender, KeyPressEventArgs e)
        {
            // Chỉ cho phép nhập số và phím xóa (BackSpace)
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            // Đặt DialogResult là Cancel để Form cha biết không cần làm gì cả
            this.DialogResult = DialogResult.Cancel;

            // Đóng Form hiện tại
            this.Close();
        }

    }
}
