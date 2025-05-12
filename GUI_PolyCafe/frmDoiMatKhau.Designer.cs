namespace GUI_PolyCafe
{
    partial class frmDoiMatKhau
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
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            label6 = new Label();
            txtMaNV = new TextBox();
            txtHoTen = new TextBox();
            txtMatKhauCu = new TextBox();
            txtMatKhauMoi = new TextBox();
            txtXacNhanMatKhau = new TextBox();
            chkMatKhauCu = new CheckBox();
            chkMatKhauMoi = new CheckBox();
            chkXacNhanMatKhau = new CheckBox();
            btnMatKhau = new Button();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 25F);
            label1.ForeColor = SystemColors.ActiveCaption;
            label1.Location = new Point(16, 6);
            label1.Name = "label1";
            label1.Size = new Size(318, 57);
            label1.TabIndex = 0;
            label1.Text = "ĐỔI MẬT KHẨU";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(205, 147);
            label2.Name = "label2";
            label2.Size = new Size(133, 28);
            label2.TabIndex = 1;
            label2.Text = "Mã nhân viên:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(205, 289);
            label3.Name = "label3";
            label3.Size = new Size(123, 28);
            label3.TabIndex = 2;
            label3.Text = "Mật khẩu cũ:";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(205, 217);
            label4.Name = "label4";
            label4.Size = new Size(134, 28);
            label4.TabIndex = 3;
            label4.Text = "Tên nhân viên:";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(205, 360);
            label5.Name = "label5";
            label5.Size = new Size(137, 28);
            label5.TabIndex = 4;
            label5.Text = "Mật khẩu mới:";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(205, 433);
            label6.Name = "label6";
            label6.Size = new Size(181, 28);
            label6.TabIndex = 5;
            label6.Text = "Xác nhận mật khẩu:";
            // 
            // txtMaNV
            // 
            txtMaNV.Enabled = false;
            txtMaNV.Location = new Point(388, 147);
            txtMaNV.Name = "txtMaNV";
            txtMaNV.ReadOnly = true;
            txtMaNV.Size = new Size(316, 34);
            txtMaNV.TabIndex = 6;
            // 
            // txtHoTen
            // 
            txtHoTen.Enabled = false;
            txtHoTen.Location = new Point(388, 217);
            txtHoTen.Name = "txtHoTen";
            txtHoTen.ReadOnly = true;
            txtHoTen.Size = new Size(316, 34);
            txtHoTen.TabIndex = 7;
            // 
            // txtMatKhauCu
            // 
            txtMatKhauCu.Location = new Point(388, 289);
            txtMatKhauCu.Name = "txtMatKhauCu";
            txtMatKhauCu.Size = new Size(316, 34);
            txtMatKhauCu.TabIndex = 8;
            // 
            // txtMatKhauMoi
            // 
            txtMatKhauMoi.Location = new Point(388, 360);
            txtMatKhauMoi.Name = "txtMatKhauMoi";
            txtMatKhauMoi.Size = new Size(316, 34);
            txtMatKhauMoi.TabIndex = 9;
            // 
            // txtXacNhanMatKhau
            // 
            txtXacNhanMatKhau.Location = new Point(388, 430);
            txtXacNhanMatKhau.Name = "txtXacNhanMatKhau";
            txtXacNhanMatKhau.Size = new Size(316, 34);
            txtXacNhanMatKhau.TabIndex = 10;
            // 
            // chkMatKhauCu
            // 
            chkMatKhauCu.AutoSize = true;
            chkMatKhauCu.Location = new Point(724, 291);
            chkMatKhauCu.Name = "chkMatKhauCu";
            chkMatKhauCu.Size = new Size(102, 32);
            chkMatKhauCu.TabIndex = 11;
            chkMatKhauCu.Text = "Hiển thị";
            chkMatKhauCu.UseVisualStyleBackColor = true;
            chkMatKhauCu.CheckedChanged += chkMatKhauCu_CheckedChanged;
            // 
            // chkMatKhauMoi
            // 
            chkMatKhauMoi.AutoSize = true;
            chkMatKhauMoi.Location = new Point(724, 362);
            chkMatKhauMoi.Name = "chkMatKhauMoi";
            chkMatKhauMoi.Size = new Size(102, 32);
            chkMatKhauMoi.TabIndex = 12;
            chkMatKhauMoi.Text = "Hiển thị";
            chkMatKhauMoi.UseVisualStyleBackColor = true;
            chkMatKhauMoi.CheckedChanged += chkMatKhauMoi_CheckedChanged;
            // 
            // chkXacNhanMatKhau
            // 
            chkXacNhanMatKhau.AutoSize = true;
            chkXacNhanMatKhau.Location = new Point(724, 432);
            chkXacNhanMatKhau.Name = "chkXacNhanMatKhau";
            chkXacNhanMatKhau.Size = new Size(102, 32);
            chkXacNhanMatKhau.TabIndex = 13;
            chkXacNhanMatKhau.Text = "Hiển thị";
            chkXacNhanMatKhau.UseVisualStyleBackColor = true;
            chkXacNhanMatKhau.CheckedChanged += chkXacNhanMatKhau_CheckedChanged;
            // 
            // btnMatKhau
            // 
            btnMatKhau.Location = new Point(420, 518);
            btnMatKhau.Name = "btnMatKhau";
            btnMatKhau.Size = new Size(167, 54);
            btnMatKhau.TabIndex = 14;
            btnMatKhau.Text = "Đổi mật khẩu";
            btnMatKhau.UseVisualStyleBackColor = true;
            btnMatKhau.Click += btnMatKhau_Click;
            // 
            // frmDoiMatKhau
            // 
            AutoScaleDimensions = new SizeF(11F, 28F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1100, 630);
            Controls.Add(btnMatKhau);
            Controls.Add(chkXacNhanMatKhau);
            Controls.Add(chkMatKhauMoi);
            Controls.Add(chkMatKhauCu);
            Controls.Add(txtXacNhanMatKhau);
            Controls.Add(txtMatKhauMoi);
            Controls.Add(txtMatKhauCu);
            Controls.Add(txtHoTen);
            Controls.Add(txtMaNV);
            Controls.Add(label6);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Font = new Font("Segoe UI", 12F);
            Margin = new Padding(4);
            Name = "frmDoiMatKhau";
            Text = "frmDoiMatKhau";
            Load += frmDoiMatKhau_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
        private Label label6;
        private TextBox txtMaNV;
        private TextBox txtHoTen;
        private TextBox txtMatKhauCu;
        private TextBox txtMatKhauMoi;
        private TextBox txtXacNhanMatKhau;
        private CheckBox chkMatKhauCu;
        private CheckBox chkMatKhauMoi;
        private CheckBox chkXacNhanMatKhau;
        private Button btnMatKhau;
    }
}