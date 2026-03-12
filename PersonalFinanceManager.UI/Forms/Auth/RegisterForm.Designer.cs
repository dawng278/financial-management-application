using System.Drawing;
using System.Windows.Forms;

namespace PersonalFinanceManager.Forms.Auth
{
    partial class RegisterForm
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

        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.guna2Elipse1 = new Guna.UI2.WinForms.Guna2Elipse(this.components);
            this.guna2ShadowForm1 = new Guna.UI2.WinForms.Guna2ShadowForm(this.components);
            this.guna2DragControl1 = new Guna.UI2.WinForms.Guna2DragControl(this.components);
            this.txtUsernameR = new Guna.UI2.WinForms.Guna2TextBox();
            this.txtPasswordR = new Guna.UI2.WinForms.Guna2TextBox();
            this.btnRegiser = new Guna.UI2.WinForms.Guna2Button();
            this.label1 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.txtPassword2R = new Guna.UI2.WinForms.Guna2TextBox();
            this.linkLabel1 = new System.Windows.Forms.LinkLabel();
            this.SuspendLayout();
            // 
            // guna2Elipse1
            // 
            this.guna2Elipse1.BorderRadius = 20;
            this.guna2Elipse1.TargetControl = this;
            // 
            // guna2ShadowForm1
            // 
            this.guna2ShadowForm1.TargetForm = this;
            // 
            // guna2DragControl1
            // 
            this.guna2DragControl1.DockIndicatorTransparencyValue = 0.6D;
            this.guna2DragControl1.TargetControl = this;
            this.guna2DragControl1.UseTransparentDrag = true;
            // 
            // txtUsernameR
            // 
            this.txtUsernameR.BorderRadius = 10;
            this.txtUsernameR.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtUsernameR.DefaultText = "";
            this.txtUsernameR.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtUsernameR.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtUsernameR.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtUsernameR.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtUsernameR.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtUsernameR.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtUsernameR.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtUsernameR.Location = new System.Drawing.Point(47, 83);
            this.txtUsernameR.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtUsernameR.Name = "txtUsernameR";
            this.txtUsernameR.PlaceholderText = "Tên đăng ký";
            this.txtUsernameR.SelectedText = "";
            this.txtUsernameR.Size = new System.Drawing.Size(286, 48);
            this.txtUsernameR.TabIndex = 0;
            // 
            // txtPasswordR
            // 
            this.txtPasswordR.BorderRadius = 10;
            this.txtPasswordR.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtPasswordR.DefaultText = "";
            this.txtPasswordR.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtPasswordR.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtPasswordR.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtPasswordR.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtPasswordR.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtPasswordR.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtPasswordR.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtPasswordR.Location = new System.Drawing.Point(47, 145);
            this.txtPasswordR.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtPasswordR.Name = "txtPasswordR";
            this.txtPasswordR.PasswordChar = '●';
            this.txtPasswordR.PlaceholderText = "Mật khẩu";
            this.txtPasswordR.SelectedText = "";
            this.txtPasswordR.Size = new System.Drawing.Size(286, 48);
            this.txtPasswordR.TabIndex = 0;
            this.txtPasswordR.UseSystemPasswordChar = true;
            // 
            // btnRegiser
            // 
            this.btnRegiser.BorderRadius = 10;
            this.btnRegiser.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnRegiser.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnRegiser.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnRegiser.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnRegiser.FillColor = System.Drawing.Color.Navy;
            this.btnRegiser.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnRegiser.ForeColor = System.Drawing.Color.White;
            this.btnRegiser.Location = new System.Drawing.Point(77, 296);
            this.btnRegiser.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnRegiser.Name = "btnRegiser";
            this.btnRegiser.Size = new System.Drawing.Size(225, 45);
            this.btnRegiser.TabIndex = 1;
            this.btnRegiser.Text = "ĐĂNG KÝ";
            this.btnRegiser.Click += new System.EventHandler(this.btnRegiser_Click_1);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.label1.Location = new System.Drawing.Point(133, 27);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(123, 32);
            this.label1.TabIndex = 2;
            this.label1.Text = "ĐĂNG KÝ";
            // 
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.button1.Location = new System.Drawing.Point(358, 10);
            this.button1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(30, 24);
            this.button1.TabIndex = 3;
            this.button1.Text = "X";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // txtPassword2R
            // 
            this.txtPassword2R.BorderRadius = 10;
            this.txtPassword2R.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtPassword2R.DefaultText = "";
            this.txtPassword2R.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtPassword2R.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtPassword2R.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtPassword2R.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtPassword2R.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtPassword2R.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtPassword2R.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtPassword2R.Location = new System.Drawing.Point(47, 206);
            this.txtPassword2R.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtPassword2R.Name = "txtPassword2R";
            this.txtPassword2R.PasswordChar = '●';
            this.txtPassword2R.PlaceholderText = "Nhập lại mật khẩu";
            this.txtPassword2R.SelectedText = "";
            this.txtPassword2R.Size = new System.Drawing.Size(286, 48);
            this.txtPassword2R.TabIndex = 0;
            this.txtPassword2R.UseSystemPasswordChar = true;
            // 
            // linkLabel1
            // 
            this.linkLabel1.AutoSize = true;
            this.linkLabel1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.linkLabel1.LinkColor = System.Drawing.Color.Navy;
            this.linkLabel1.Location = new System.Drawing.Point(59, 350);
            this.linkLabel1.Name = "linkLabel1";
            this.linkLabel1.Size = new System.Drawing.Size(274, 20);
            this.linkLabel1.TabIndex = 4;
            this.linkLabel1.TabStop = true;
            this.linkLabel1.Text = "Bạn đã có tài khoản? Đăng nhập ngay.";
            this.linkLabel1.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel1_LinkClicked_1);
            // 
            // RegisterForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Beige;
            this.ClientSize = new System.Drawing.Size(400, 400);
            this.Controls.Add(this.linkLabel1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnRegiser);
            this.Controls.Add(this.txtPassword2R);
            this.Controls.Add(this.txtPasswordR);
            this.Controls.Add(this.txtUsernameR);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "RegisterForm";
            this.Text = "LoginForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

      

        private Guna.UI2.WinForms.Guna2Elipse guna2Elipse1;
        private Guna.UI2.WinForms.Guna2ShadowForm guna2ShadowForm1;
        private Guna.UI2.WinForms.Guna2DragControl guna2DragControl1;
        private Guna.UI2.WinForms.Guna2Button btnRegiser;
        private Guna.UI2.WinForms.Guna2TextBox txtPasswordR;
        private Guna.UI2.WinForms.Guna2TextBox txtUsernameR;
        private Label label1;
        private Button button1;
        private Guna.UI2.WinForms.Guna2TextBox txtPassword2R;
        private LinkLabel linkLabel1;
    }
}