using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BLL_PolyCafe;
using UTIL_PolyCafe;

namespace GUI_PolyCafe
{
    public partial class frmDoiMatKhau : Form
    {
        BUSNhanVien nvBUS = new BUSNhanVien();
        public frmDoiMatKhau()
        {
            InitializeComponent();
        }

        private void frmDoiMatKhau_Load(object sender, EventArgs e)
        {
            if (AuthUtil.IsLogin())
            {
                txtMaNV.Text = AuthUtil.user.MaNhanVien;
                txtHoTen.Text = AuthUtil.user.HoTen;
            }
        }

        private void chkMatKhauCu_CheckedChanged(object sender, EventArgs e)
        {
            txtMatKhauCu.PasswordChar = chkMatKhauCu.Checked ? '\0' : '*';
        }

        private void chkMatKhauMoi_CheckedChanged(object sender, EventArgs e)
        {
            txtMatKhauMoi.PasswordChar = chkMatKhauMoi.Checked ? '\0' : '*';
        }

        private void chkXacNhanMatKhau_CheckedChanged(object sender, EventArgs e)
        {
            txtXacNhanMatKhau.PasswordChar = chkXacNhanMatKhau.Checked ? '\0' : '*';
        }

        private void btnMatKhau_Click(object sender, EventArgs e)
        {
            if (!AuthUtil.user.MatKhau.Equals(txtMatKhauCu.Text))
            {
                MessageBox.Show(this, "Mật khẩu cũ chưa đúng!!!");
            }
            else
            {
                if (!txtMatKhauMoi.Text.Equals(txtXacNhanMatKhau.Text))
                {
                    MessageBox.Show(this, "Xác nhận mật khẩu mới chưa trùng khớp!!!");
                }
                else
                {
                    AuthUtil.user.MatKhau = txtMatKhauMoi.Text;

                    if (nvBUS.ResetMatKhau(AuthUtil.user.Email, txtMatKhauMoi.Text))
                    {
                        MessageBox.Show("Cập nhật mật khẩu thành công!!!");
                    }
                    else MessageBox.Show("Đổi mật khẩu thất bại, vui lòng kiểm tra lại!!!");
                }
            }
        }
    }
}
