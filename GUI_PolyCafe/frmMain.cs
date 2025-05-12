using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.DirectoryServices.ActiveDirectory;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GUI_PolyCafe
{
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();
        }

        private void đổiMậtKhẩuToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmDoiMatKhau reset = new frmDoiMatKhau();
            reset.ShowDialog();
        }

        private void thoátToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void thẻLưuĐộngToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmTheLuuDong tld = new frmTheLuuDong();
            tld.ShowDialog();
        }


        private void phiếuBánHàngToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmPhieuBanHang phieuBanHang = new frmPhieuBanHang();
            phieuBanHang.ShowDialog();
        }

        private void thốngKêToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmThongKeTheoLoaiSanPham tktlsp = new frmThongKeTheoLoaiSanPham();
            tktlsp.ShowDialog();
        }

        private void nhânViênToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmQuanLyNhanVien qlnv = new frmQuanLyNhanVien();
            qlnv.ShowDialog();
        }

        private void quảnLíSảnSảnPhẩmToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmQuanLySanPham qlsp = new frmQuanLySanPham();
            qlsp.ShowDialog();
        }

        private void quảnLíLoạiSảnPhẩmToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            frmQLLoaiSanPham qllsp = new frmQLLoaiSanPham();
            qllsp.ShowDialog();
        }

        private void thốngKêTheoNhânViênToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmThongKeTheoNhanVien tknv = new frmThongKeTheoNhanVien();
            tknv.ShowDialog();
        }
    }
}
