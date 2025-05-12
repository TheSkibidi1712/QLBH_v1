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
using DTO_PolyCafe;
using DTO_PolyCAfe;

namespace GUI_PolyCafe
{
    public partial class frmChiTietPhieu : Form
    {
        private TheLuuDong theLuuDong;
        private PhieuBanHang phieuBanHang;
        private NhanVien nhanVien;
        private List<ChiTietPhieu> lstChiTiet;
        private List<SanPham> lstSanPham;
        bool isActive = true;
        public frmChiTietPhieu(TheLuuDong the, PhieuBanHang phieu, NhanVien nv)
        {
            InitializeComponent();
            theLuuDong = the;
            phieuBanHang = phieu;
            nhanVien = nv;
            lstChiTiet = new List<ChiTietPhieu>();
            lstSanPham = new List<SanPham>();
            isActive = phieu.TrangThai;
        }
        private void activeTranfer()
        {
            if (isActive)
            {
                btnThemChiTiet.Enabled = false;
                btnXoaChiTiet.Enabled = false;
                txtPhanTram.Enabled = false;
            }
        }

        private void LoadInfo()
        {
            lblChuSoHuu.Text = $"{theLuuDong.MaThe} - {theLuuDong.ChuSoHuu}";
            lblMaPhieu.Text = phieuBanHang.MaPhieu;
            lblNgayLap.Text = phieuBanHang.NgayTao.ToString("dd/MM/yyyy");
        }
        private void loadSanPham()
        {
            BUSSanPham sp = new BUSSanPham();
            lstSanPham = sp.GetSanPhamList(1);
            dgvSanPham.DataSource = lstSanPham;
            dgvSanPham.Columns["MaSanPham"].HeaderText = "Mã Sản Phẩm";
            dgvSanPham.Columns["TenSanPham"].HeaderText = "Tên Sản Phẩm";
            dgvSanPham.Columns["DonGia"].HeaderText = "Đơn Gía";
            dgvSanPham.Columns["MaLoai"].HeaderText = "Loại Sản Phẩm";
            dgvSanPham.Columns["HinhAnh"].HeaderText = "Hình Ảnh";


            dgvSanPham.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        private void loadChiTietPhieu(string maPhieu)
        {
            BusChiTietPhieu bus = new BusChiTietPhieu();
            lstChiTiet = bus.GetChiTietPhieuList(maPhieu);
            dgvChiTiet.DataSource = lstChiTiet;
            dgvChiTiet.Columns["MaChiTiet"].Visible = false;
            dgvChiTiet.Columns["MaPhieu"].Visible = false;
            dgvChiTiet.Columns["MaSanPham"].Visible = false;
            dgvChiTiet.Columns["SoLuong"].HeaderText = "Số Lượng";
            dgvChiTiet.Columns["DonGia"].HeaderText = "Đơn Giá";
            dgvChiTiet.Columns["SoLuong"].ReadOnly = false;

            dgvChiTiet.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            foreach (DataGridViewColumn col in dgvChiTiet.Columns)
            {
                col.ReadOnly = true;
            }
            dgvChiTiet.Columns["SoLuong"].ReadOnly = false;
        }
        private void transfer(SanPham sp, int soLuong = 1)
        {
            if (isActive)
            {
                return;
            }
            if (sp != null)
            {
                BusChiTietPhieu bus = new BusChiTietPhieu();
                ChiTietPhieu existingItem = lstChiTiet.FirstOrDefault(item => item.MaSanPham == sp.MaSanPham);
                if (existingItem != null)
                {
                    existingItem.SoLuong += soLuong;
                    string result = bus.UpdateSoLuong(existingItem);
                    if (!string.IsNullOrEmpty(result))
                    {
                        MessageBox.Show("Thêm sản phẩm không thành công.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }

                }
                else
                {
                    ChiTietPhieu ct = new ChiTietPhieu()
                    {
                        MaPhieu = phieuBanHang.MaPhieu,
                        MaSanPham = sp.MaSanPham,
                        SoLuong = soLuong,
                        DonGia = sp.DonGia,
                    };
                    string result = bus.InsertChiTietPhieu(ct);
                    if (!string.IsNullOrEmpty(result))
                    {
                        MessageBox.Show("Thêm sản phẩm không thành công.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                loadChiTietPhieu(phieuBanHang.MaPhieu);

            }
        }

        private void deleteChiTiet()
        {
            if (dgvChiTiet.CurrentRow != null)
            {
                string id = Convert.ToString(dgvChiTiet.CurrentRow.Cells["MaChiTiet"].Value);
                string name = Convert.ToString(dgvChiTiet.CurrentRow.Cells["TenSanPham"].Value);
                DialogResult result = MessageBox.Show($"Bạn có chắc chắn muốn xóa sản phầm {name}?", "Xác nhận xóa",
                MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                if (result == DialogResult.Yes)
                {
                    BusChiTietPhieu bus = new BusChiTietPhieu();
                    string kq = bus.DeleteChiTiet(id); ;
                    if (string.IsNullOrEmpty(kq))
                    {
                        loadChiTietPhieu(phieuBanHang.MaPhieu);
                    }
                }
            }
        }
        private void loadThanhToan()
        {
            if ( dgvChiTiet.Rows.Count > 0)
            {
                decimal tongTien = 0;

                foreach (DataGridViewRow row in dgvChiTiet.Rows)
                {
                    // Bỏ qua dòng mới (dòng trống cuối cùng)
                    if (row.IsNewRow) continue;

                    // Lấy số lượng và đơn giá
                    decimal soLuong = 0;
                    decimal donGia = 0;

                    decimal.TryParse(Convert.ToString(row.Cells["SoLuong"].Value), out soLuong);
                    decimal.TryParse(Convert.ToString(row.Cells["DonGia"].Value), out donGia);

                    // Cộng vào tổng tiền
                    tongTien += soLuong * donGia;
                }

                // Gán vào TextBox
                txtTong.Text = tongTien.ToString("N0"); // Định dạng có dấu phân cách hàng nghìn

                //Tính phần trăm
                decimal phanTram = 0;
                decimal.TryParse(txtPhanTram.Text, out phanTram);
                phanTram /= 100;

                //Tính tiền giảm giá
                decimal giamGia = 0;
                giamGia = tongTien * phanTram;
                txtGiamGia.Text = giamGia.ToString("N0");

                //Tính thành tiền
                decimal thanhTien = 0;
                thanhTien = Math.Round(tongTien - giamGia);
                txtThanhTien.Text = thanhTien.ToString("N0");
            }
            else
            {
                txtTong.Text = "0";
                txtPhanTram.Text = "0";
                txtGiamGia.Text= "0";
                txtThanhTien.Text= "0";
                txtDichVu.Text= "0";
            }    
        }

        private void frmChiTietPhieu_Load(object sender, EventArgs e)
        {
            loadThanhToan();
            LoadInfo();
            loadSanPham();
            loadChiTietPhieu(phieuBanHang.MaPhieu);
            activeTranfer();
        }

        private void dgvSanPham_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (isActive)
            {
                return;
            }
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvSanPham.Rows[e.RowIndex];

                // Tạo đối tượng từ dữ liệu hàng
                SanPham sanPham = new SanPham
                {
                    MaSanPham = row.Cells["MaSanPham"].Value.ToString(),
                    TenSanPham = row.Cells["TenSanPham"].Value.ToString(),
                    DonGia = Convert.ToInt32(row.Cells["DonGia"].Value)
                };

                transfer(sanPham);
            }
            loadThanhToan() ;
        }

        private void dgvSanPham_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (isActive)
            {
                return;
            }

            if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                BusChiTietPhieu bus = new BusChiTietPhieu();
                ChiTietPhieu ct = lstChiTiet[e.RowIndex];
                int newQuantity;
                if (int.TryParse(dgvChiTiet.Rows[e.RowIndex].Cells["SoLuong"].Value.ToString(), out newQuantity))
                {
                    ct.SoLuong = newQuantity;
                    string result = bus.UpdateSoLuong(ct);
                    if (!string.IsNullOrEmpty(result))
                    {
                        MessageBox.Show("Thêm sản phẩm không thành công.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    //Đảm bảo ko lỗi khi đang edit mà chuyển ô
                    this.BeginInvoke((Action)(() =>
                    {
                        loadChiTietPhieu(phieuBanHang.MaPhieu);
                    }));
                }
                else
                {
                    MessageBox.Show("Vui lòng nhập số hợp lệ!", "Lỗi nhập liệu", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }

        private void btnXoaChiTiet_Click(object sender, EventArgs e)
        {
            if (isActive)
            {
                return;
            }
            deleteChiTiet();
        }

        private void btnThemChiTiet_Click(object sender, EventArgs e)
        {
            if (isActive)
            {
                return;
            }
            if (dgvSanPham.CurrentRow != null)
            {
                string id = Convert.ToString(dgvSanPham.CurrentRow.Cells["MaSanPham"].Value);
                string ten = Convert.ToString(dgvSanPham.CurrentRow.Cells["TenSanPham"].Value);
                decimal dongia = Convert.ToDecimal(dgvSanPham.CurrentRow.Cells["DonGia"].Value);
                SanPham sanPham = new SanPham
                {
                    MaSanPham = id,
                    TenSanPham = ten,
                    DonGia = dongia
                };

                transfer(sanPham);
            }
        }
    }
}
