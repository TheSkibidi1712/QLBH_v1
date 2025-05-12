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
using DAL_PolyCafe;
using DTO_PolyCAfe;

namespace GUI_PolyCafe
{
    public partial class frmThongKeTheoLoaiSanPham : Form
    {
        public frmThongKeTheoLoaiSanPham()
        {
            InitializeComponent();
        }
        private void frmThongKeTheoLoaiSanPham_Load(object sender, EventArgs e)
        {
            BUSLoaiSanPham loaiSanPham = new BUSLoaiSanPham();
            List<LoaiSanPham> loaiSanPhams = loaiSanPham.GetLoaiSanPhamList();
            cboLoaiSanPham.Items.Clear();
            cboLoaiSanPham.DataSource = loaiSanPhams;
            cboLoaiSanPham.DisplayMember = "TenLoai";
            cboLoaiSanPham.ValueMember = "MaLoai";
        }

        private void btnThongKe_Click(object sender, EventArgs e)
        {
            string loai = cboLoaiSanPham.SelectedValue.ToString();
            DateTime bd = dtpTuNgay.Value.Date;
            DateTime kt = dtpDenNgay.Value.Date;

            BUSThongKe busThongKe = new BUSThongKe();
            List<TKDoanhThuTheoLoaiSanPham> result = busThongKe.getThongKeLoaiSP(loai, bd, kt);
            dgvThongKe.DataSource = result;
        }
    }
}
