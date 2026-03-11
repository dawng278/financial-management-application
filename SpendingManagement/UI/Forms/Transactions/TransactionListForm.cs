using SpendingManagement.UI.Mock;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace SpendingManagement.UI.Forms.Transactions
{
    public partial class TransactionListForm : Form
    {
        public TransactionListForm()
        {
            InitializeComponent();
        }

        List<TransactionMock> dataSource = new List<TransactionMock>();
        private void TransactionListForm_Load(object sender, EventArgs e)
        {
            // Lấy dữ liệu ban đầu từ Mock Service
            dataSource = MockTransactionService.GetData();
            dgvTransactions.DataSource = dataSource;
        }

        private void dgvTransactions_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            // Kiểm tra nếu đang ở cột "Loai" (Thu/Chi)
            if (dgvTransactions.Columns[e.ColumnIndex].Name == "Loai" && e.Value != null)
            {
                if (e.Value.ToString() == "Chi")
                    e.CellStyle.ForeColor = Color.Red;
                else
                    e.CellStyle.ForeColor = Color.Green;
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            using (AddEditTransactionForm frm = new AddEditTransactionForm())
            {
                if (frm.ShowDialog() == DialogResult.OK)
                {
                    // Lấy dữ liệu từ Form vừa đóng và thêm vào List chính
                    dataSource.Add(frm.NewTransaction);

                    // Làm mới lại bảng để hiện dòng mới
                    dgvTransactions.DataSource = null;
                    dgvTransactions.DataSource = dataSource;

                    MessageBox.Show("Thêm thành công!");
                }
            }
        }
    }
}
