namespace PersonalFinanceManager.Forms.Dashboard
{
    partial class DashboardForm
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
            Guna.Charts.WinForms.ChartFont chartFont1 = new Guna.Charts.WinForms.ChartFont();
            Guna.Charts.WinForms.ChartFont chartFont2 = new Guna.Charts.WinForms.ChartFont();
            Guna.Charts.WinForms.ChartFont chartFont3 = new Guna.Charts.WinForms.ChartFont();
            Guna.Charts.WinForms.ChartFont chartFont4 = new Guna.Charts.WinForms.ChartFont();
            Guna.Charts.WinForms.Grid grid1 = new Guna.Charts.WinForms.Grid();
            Guna.Charts.WinForms.Tick tick1 = new Guna.Charts.WinForms.Tick();
            Guna.Charts.WinForms.ChartFont chartFont5 = new Guna.Charts.WinForms.ChartFont();
            Guna.Charts.WinForms.Grid grid2 = new Guna.Charts.WinForms.Grid();
            Guna.Charts.WinForms.Tick tick2 = new Guna.Charts.WinForms.Tick();
            Guna.Charts.WinForms.ChartFont chartFont6 = new Guna.Charts.WinForms.ChartFont();
            Guna.Charts.WinForms.Grid grid3 = new Guna.Charts.WinForms.Grid();
            Guna.Charts.WinForms.PointLabel pointLabel1 = new Guna.Charts.WinForms.PointLabel();
            Guna.Charts.WinForms.ChartFont chartFont7 = new Guna.Charts.WinForms.ChartFont();
            Guna.Charts.WinForms.Tick tick3 = new Guna.Charts.WinForms.Tick();
            Guna.Charts.WinForms.ChartFont chartFont8 = new Guna.Charts.WinForms.ChartFont();
            this.label1 = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.label2 = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.label3 = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.gunaChart1 = new Guna.Charts.WinForms.GunaChart();
            this.label4 = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.label5 = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.label6 = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = false;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Location = new System.Drawing.Point(36, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(74, 18);
            this.label1.TabIndex = 0;
            this.label1.Text = "Tổng số dư:";
            // 
            // label2
            // 
            this.label2.AutoSize = false;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Location = new System.Drawing.Point(260, 26);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(62, 18);
            this.label2.TabIndex = 0;
            this.label2.Text = "Thu nhập:";
            // 
            // label3
            // 
            this.label3.AutoSize = false;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Location = new System.Drawing.Point(467, 26);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(72, 18);
            this.label3.TabIndex = 0;
            this.label3.Text = "Chi tiêu:";
            // 
            // gunaChart1
            // 
            chartFont1.FontName = "Arial";
            this.gunaChart1.Legend.LabelFont = chartFont1;
            this.gunaChart1.Location = new System.Drawing.Point(88, 118);
            this.gunaChart1.Name = "gunaChart1";
            this.gunaChart1.Size = new System.Drawing.Size(419, 260);
            this.gunaChart1.TabIndex = 1;
            chartFont2.FontName = "Arial";
            chartFont2.Size = 12;
            chartFont2.Style = Guna.Charts.WinForms.ChartFontStyle.Bold;
            this.gunaChart1.Title.Font = chartFont2;
            chartFont3.FontName = "Arial";
            this.gunaChart1.Tooltips.BodyFont = chartFont3;
            chartFont4.FontName = "Arial";
            chartFont4.Size = 9;
            chartFont4.Style = Guna.Charts.WinForms.ChartFontStyle.Bold;
            this.gunaChart1.Tooltips.TitleFont = chartFont4;
            this.gunaChart1.XAxes.GridLines = grid1;
            chartFont5.FontName = "Arial";
            tick1.Font = chartFont5;
            this.gunaChart1.XAxes.Ticks = tick1;
            this.gunaChart1.YAxes.GridLines = grid2;
            chartFont6.FontName = "Arial";
            tick2.Font = chartFont6;
            tick2.Maximum = 0D;
            this.gunaChart1.YAxes.Ticks = tick2;
            this.gunaChart1.ZAxes.GridLines = grid3;
            chartFont7.FontName = "Arial";
            pointLabel1.Font = chartFont7;
            this.gunaChart1.ZAxes.PointLabels = pointLabel1;
            chartFont8.FontName = "Arial";
            tick3.Font = chartFont8;
            this.gunaChart1.ZAxes.Ticks = tick3;
            // 
            // label4
            // 
            this.label4.AutoSize = false;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Location = new System.Drawing.Point(129, 26);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(103, 18);
            this.label4.TabIndex = 0;
            this.label4.Text = "0";
            // 
            // label5
            // 
            this.label5.AutoSize = false;
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.Location = new System.Drawing.Point(328, 26);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(95, 18);
            this.label5.TabIndex = 0;
            this.label5.Text = "0";
            // 
            // label6
            // 
            this.label6.AutoSize = false;
            this.label6.BackColor = System.Drawing.Color.Transparent;
            this.label6.Location = new System.Drawing.Point(523, 26);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(142, 18);
            this.label6.TabIndex = 0;
            this.label6.Text = "0";
            // 
            // DashboardForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.gunaChart1);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label1);
            this.Name = "DashboardForm";
            this.Text = "DashboardForm";
            this.Load += new System.EventHandler(this.DashboardForm_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private Guna.UI2.WinForms.Guna2HtmlLabel label1;
        private Guna.UI2.WinForms.Guna2HtmlLabel label2;
        private Guna.UI2.WinForms.Guna2HtmlLabel label3;
        private Guna.Charts.WinForms.GunaChart gunaChart1;
        private Guna.UI2.WinForms.Guna2HtmlLabel label4;
        private Guna.UI2.WinForms.Guna2HtmlLabel label5;
        private Guna.UI2.WinForms.Guna2HtmlLabel label6;
    }
}