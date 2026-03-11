namespace SpendingManagement.UI.Forms.Transactions
{
    partial class TransactionListForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges3 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges4 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges1 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges2 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            guna2Panel1 = new Guna.UI2.WinForms.Guna2Panel();
            dgvTransactions = new Guna.UI2.WinForms.Guna2DataGridView();
            btnAdd = new Guna.UI2.WinForms.Guna2Button();
            guna2Panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvTransactions).BeginInit();
            SuspendLayout();
            // 
            // guna2Panel1
            // 
            guna2Panel1.Controls.Add(dgvTransactions);
            guna2Panel1.Controls.Add(btnAdd);
            guna2Panel1.CustomizableEdges = customizableEdges3;
            guna2Panel1.Location = new Point(12, 12);
            guna2Panel1.Name = "guna2Panel1";
            guna2Panel1.ShadowDecoration.CustomizableEdges = customizableEdges4;
            guna2Panel1.Size = new Size(758, 398);
            guna2Panel1.TabIndex = 1;
            // 
            // dgvTransactions
            // 
            dataGridViewCellStyle1.BackColor = Color.FromArgb(44, 48, 52);
            dgvTransactions.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = Color.FromArgb(15, 16, 18);
            dataGridViewCellStyle2.Font = new Font("Segoe UI", 9F);
            dataGridViewCellStyle2.ForeColor = Color.White;
            dataGridViewCellStyle2.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.True;
            dgvTransactions.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            dgvTransactions.ColumnHeadersHeight = 4;
            dgvTransactions.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = Color.FromArgb(33, 37, 41);
            dataGridViewCellStyle3.Font = new Font("Segoe UI", 9F);
            dataGridViewCellStyle3.ForeColor = Color.White;
            dataGridViewCellStyle3.SelectionBackColor = Color.FromArgb(114, 117, 119);
            dataGridViewCellStyle3.SelectionForeColor = Color.White;
            dataGridViewCellStyle3.WrapMode = DataGridViewTriState.False;
            dgvTransactions.DefaultCellStyle = dataGridViewCellStyle3;
            dgvTransactions.GridColor = Color.FromArgb(50, 56, 62);
            dgvTransactions.Location = new Point(21, 93);
            dgvTransactions.Name = "dgvTransactions";
            dgvTransactions.RowHeadersVisible = false;
            dgvTransactions.RowHeadersWidth = 51;
            dgvTransactions.Size = new Size(686, 256);
            dgvTransactions.TabIndex = 2;
            dgvTransactions.Theme = Guna.UI2.WinForms.Enums.DataGridViewPresetThemes.Dark;
            dgvTransactions.ThemeStyle.AlternatingRowsStyle.BackColor = Color.FromArgb(44, 48, 52);
            dgvTransactions.ThemeStyle.AlternatingRowsStyle.Font = null;
            dgvTransactions.ThemeStyle.AlternatingRowsStyle.ForeColor = Color.Empty;
            dgvTransactions.ThemeStyle.AlternatingRowsStyle.SelectionBackColor = Color.Empty;
            dgvTransactions.ThemeStyle.AlternatingRowsStyle.SelectionForeColor = Color.Empty;
            dgvTransactions.ThemeStyle.BackColor = Color.White;
            dgvTransactions.ThemeStyle.GridColor = Color.FromArgb(50, 56, 62);
            dgvTransactions.ThemeStyle.HeaderStyle.BackColor = Color.FromArgb(15, 16, 18);
            dgvTransactions.ThemeStyle.HeaderStyle.BorderStyle = DataGridViewHeaderBorderStyle.None;
            dgvTransactions.ThemeStyle.HeaderStyle.Font = new Font("Segoe UI", 9F);
            dgvTransactions.ThemeStyle.HeaderStyle.ForeColor = Color.White;
            dgvTransactions.ThemeStyle.HeaderStyle.HeaightSizeMode = DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            dgvTransactions.ThemeStyle.HeaderStyle.Height = 4;
            dgvTransactions.ThemeStyle.ReadOnly = false;
            dgvTransactions.ThemeStyle.RowsStyle.BackColor = Color.FromArgb(33, 37, 41);
            dgvTransactions.ThemeStyle.RowsStyle.BorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dgvTransactions.ThemeStyle.RowsStyle.Font = new Font("Segoe UI", 9F);
            dgvTransactions.ThemeStyle.RowsStyle.ForeColor = Color.White;
            dgvTransactions.ThemeStyle.RowsStyle.Height = 29;
            dgvTransactions.ThemeStyle.RowsStyle.SelectionBackColor = Color.FromArgb(114, 117, 119);
            dgvTransactions.ThemeStyle.RowsStyle.SelectionForeColor = Color.White;
            // 
            // btnAdd
            // 
            btnAdd.CustomizableEdges = customizableEdges1;
            btnAdd.DisabledState.BorderColor = Color.DarkGray;
            btnAdd.DisabledState.CustomBorderColor = Color.DarkGray;
            btnAdd.DisabledState.FillColor = Color.FromArgb(169, 169, 169);
            btnAdd.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
            btnAdd.FillColor = Color.Navy;
            btnAdd.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnAdd.ForeColor = Color.White;
            btnAdd.Location = new Point(21, 25);
            btnAdd.Name = "btnAdd";
            btnAdd.ShadowDecoration.CustomizableEdges = customizableEdges2;
            btnAdd.Size = new Size(206, 51);
            btnAdd.TabIndex = 1;
            btnAdd.Text = "Thêm giao dịch";
            btnAdd.Click += btnAdd_Click;
            // 
            // TransactionListForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(guna2Panel1);
            Name = "TransactionListForm";
            Text = "TransactionListForm";
            Load += TransactionListForm_Load;
            guna2Panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvTransactions).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Guna.UI2.WinForms.Guna2Panel guna2Panel1;
        private Guna.UI2.WinForms.Guna2DataGridView dgvTransactions;
        private Guna.UI2.WinForms.Guna2Button btnAdd;
    }
}