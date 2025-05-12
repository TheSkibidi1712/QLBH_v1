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
using DTO_PolyCafe;
using DTO_PolyCAfe;

namespace GUI_PolyCafe
{
    public partial class frmThongKeTheoNhanVien : Form
    {
        public frmThongKeTheoNhanVien()
        {
            InitializeComponent();
        }

        private void btnThongKe_Click(object sender, EventArgs e)
        {
            string mnv = cboMaNhanVien.SelectedValue.ToString();
            DateTime bd = dtpTuNgay.Value.Date;
            DateTime kt = dtpDenNgay.Value.Date;

            BUSThongKe busThongKe = new BUSThongKe();
            List<TKDoanhThuTheoNhanVien> result = busThongKe.getThongKeNhanVien(mnv, bd, kt);
            dgvThongKe.DataSource = result;
        }

        private void frmThongKeTheoNhanVien_Load(object sender, EventArgs e)
        {
            BUSNhanVien bUSNhanVien = new BUSNhanVien();
            List<NhanVien> NhanViens = bUSNhanVien.GetNhanVienList();
            cboMaNhanVien.Items.Clear();
            cboMaNhanVien.DataSource = NhanViens;
            cboMaNhanVien.DisplayMember = "HoTen";
            cboMaNhanVien.ValueMember = "MaNhanVien";
        }
    }
}
