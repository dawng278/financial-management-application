using Microsoft.VisualBasic;
using SpendingManagement.UI.Mock;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Management;
using System.Text;
using System.Windows.Forms;
using System.ComponentModel; // Thêm dòng này ở trên cùng file

namespace SpendingManagement.UI.Forms.Transactions
{
    public partial class AddEditTransactionForm : Form
    {
        public AddEditTransactionForm()
        {
            InitializeComponent();
        }



        // Trong class AddEditTransactionForm
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public TransactionMock NewTransaction { get; set; }
        private void btnSave_Click(object sender, EventArgs e)
        {
            // 1. Kiểm tra nhập liệu
            if (string.IsNullOrEmpty(txtAmount.Text))
            {
                MessageBox.Show("Vui lòng nhập số tiền!"); return;
            }

            // 2. Tạo đối tượng mới từ thông tin trên Form
            NewTransaction = new TransactionMock
            {
                Id = Guid.NewGuid().ToString().Substring(0, 5), // Tạo ID ngẫu nhiên
                Ngay = dtpDate.Value.ToString("dd/MM/yyyy"),
                MoTa = txtNote.Text,
                SoTien = double.Parse(txtAmount.Text),
                Loai = cboType.Text // Thu hoặc Chi
            };

            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void txtAmount_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Chỉ cho phép nhập số và phím xóa (backspace)
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void btnCancel_Click_1(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void AddEditTransactionForm_Load(object sender, EventArgs e)
        {
            cboType.Items.Clear();
            cboType.Items.AddRange(new object[] { "Thu", "Chi" });
            cboType.SelectedIndex = 0;
        }
    }
}
