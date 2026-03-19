using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Management;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PersonalFinanceManager.Forms.Categories
{
    public partial class CategoryForm : Form
    {
        List<Category> categoryList = new List<Category>();
        private string selectedID = "";
        public CategoryForm()
        {
            InitializeComponent();
        }

        private void LoadDataGridView()
        {
            dgvCategory.DataSource = null; // Reset lại nguồn
            dgvCategory.DataSource = categoryList;

            // Tinh chỉnh hiển thị
            dgvCategory.Columns["ID"].Visible = false; // Ẩn ID nếu không cần thiết
            dgvCategory.Columns["Name"].HeaderText = "Tên Danh Mục";
            dgvCategory.Columns["Type"].HeaderText = "Loại";
            dgvCategory.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtCategoryName.Text))
            {
                MessageBox.Show("Vui lòng nhập tên danh mục!");
                return;
            }

            var newCat = new Category
            {
                ID = Guid.NewGuid().ToString(), // Tạo ID duy nhất
                Name = txtCategoryName.Text,
                Type = cboType.SelectedItem.ToString()
            };

            categoryList.Add(newCat);
            LoadDataGridView();
            ClearInputs();
        }

        private void dgvCategory_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvCategory.Rows[e.RowIndex];
                txtCategoryName.Text = row.Cells["Name"].Value.ToString();
                cboType.SelectedItem = row.Cells["Type"].Value.ToString();
                // Lưu lại ID đang chọn vào một biến tạm để Sửa/Xóa
                selectedID = row.Cells["ID"].Value.ToString();
            }
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            var item = categoryList.FirstOrDefault(x => x.ID == selectedID);
            if (item != null)
            {
                item.Name = txtCategoryName.Text;
                item.Type = cboType.SelectedItem.ToString();
                LoadDataGridView();
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            var confirm = MessageBox.Show("Bạn có chắc muốn xóa?", "Xác nhận", MessageBoxButtons.YesNo);
            if (confirm == DialogResult.Yes)
            {
                categoryList.RemoveAll(x => x.ID == selectedID);
                LoadDataGridView();
                ClearInputs();
            }
        }
        private void ClearInputs()
        {
            txtCategoryName.Clear();
            cboType.SelectedIndex = 0;
            selectedID = "";
        }
    }
}
