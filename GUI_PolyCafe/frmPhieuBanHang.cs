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
using UTIL_PolyCafe;

namespace GUI_PolyCafe
{

    public partial class frmPhieuBanHang : Form
    {
        private bool isLoadingTheLuuDongData = true;
        public frmPhieuBanHang()
        {
            InitializeComponent();
        }
        private void ClearForm(string msThe)
        {
            btnThem.Enabled = true;
            btnSua.Enabled = false;
            btnXoa.Enabled = true;
            txtMaPhieu.Clear();
            cboMaNhanVien.Enabled = true;
            dtpNgayTao.Enabled = true;
            dtpNgayTao.Value = DateTime.Now;
            rdoChoXacNhan.Enabled = true;
            rdoDaThanhToan.Enabled = true;
            dtpNgayTao.Value = DateTime.Now;
            rdoChoXacNhan.Checked = true;
        }
        private void LoadNhanVien()
        {
            try
            {
                BUSNhanVien busNhanVien = new BUSNhanVien();
                List<NhanVien> dsLoai = busNhanVien.GetNhanVienList();
                if (AuthUtil.user.VaiTro)
                {
                    dsLoai.Insert(0, new NhanVien() { MaNhanVien = string.Empty, HoTen = string.Format("--Vui lòng chọn nhân viên--") });
                }
                else
                {
                    dsLoai = dsLoai.Where(x => x.MaNhanVien == AuthUtil.user.MaNhanVien).ToList();
                    cboMaNhanVien.Enabled = false;
                }
                cboMaNhanVien.DataSource = dsLoai;
                cboMaNhanVien.ValueMember = "MaNhanVien";
                cboMaNhanVien.DisplayMember = "HoTen";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải danh sách loại sản phẩm" + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadTheLuuDong()
        {
            BUSTheLuuDong busTheLuuDong = new BUSTheLuuDong();
            List<TheLuuDong> lst = busTheLuuDong.GetTheLuuDongList();
            lst.Insert(0, new TheLuuDong() { MaThe = string.Empty, ChuSoHuu = string.Format("--Tất Cả--") });
            cboMaThe.DataSource = lst;
            cboMaThe.ValueMember = "MaThe";
            cboMaThe.DisplayMember = "ChuSoHuu";
            isLoadingTheLuuDongData = false;
        }

        private void LoadDanhSachPhieu(string maThe)
        {
            BUSPhieuBanHang busPhieuBanHang = new BUSPhieuBanHang();
            List<PhieuBanHang> lst = busPhieuBanHang.GetListPhieuBanHang(maThe);
            if (!AuthUtil.user.VaiTro)
            {
                lst = lst.Where(x => x.MaNhanVien == AuthUtil.user.MaNhanVien).ToList();
                cboMaNhanVien.Enabled = false;
            }
            dgvPhieuBanHang.DataSource = lst;


            DataGridViewImageColumn buttonColumn = new DataGridViewImageColumn();
            buttonColumn.Name = "ThanhToan";
            buttonColumn.DefaultCellStyle.BackColor = Color.LightBlue;
            buttonColumn.DefaultCellStyle.ForeColor = Color.DarkBlue;

            buttonColumn.DefaultCellStyle.Font = new Font("Arial", 10, FontStyle.Bold);

            if (!dgvPhieuBanHang.Columns.Contains("ThanhToan"))
            {
                dgvPhieuBanHang.Columns.Add(buttonColumn);
            }
            dgvPhieuBanHang.Columns["ThanhToan"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dgvPhieuBanHang.RowTemplate.Height = 50;

            dgvPhieuBanHang.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        private void dgvPhieuBanHang_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            string maPhieu = dgvPhieuBanHang.Rows[e.RowIndex].Cells["MaPhieu"].Value.ToString();
            string maThe = dgvPhieuBanHang.Rows[e.RowIndex].Cells["MaThe"].Value.ToString();
            string maNV = dgvPhieuBanHang.Rows[e.RowIndex].Cells["MaNhanVien"].Value.ToString();
            PhieuBanHang phieu = (PhieuBanHang)dgvPhieuBanHang.CurrentRow.DataBoundItem;
            TheLuuDong the = new TheLuuDong();
            NhanVien nv = new NhanVien();
            foreach (TheLuuDong item in cboMaThe.Items)
            {
                if (item.MaThe == maThe)
                {
                    the = item;
                    break;
                }
            }

            foreach (NhanVien item in cboMaNhanVien.Items)
            {
                if (item.MaNhanVien == maNV)
                {
                    nv = item;
                    break;
                }
            }
            frmChiTietPhieu frmChiTiet = new frmChiTietPhieu(the, phieu, nv);
            frmChiTiet.ShowDialog();
        }

        private void dgvPhieuBanHang_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            isLoadingTheLuuDongData = true;
            DataGridViewRow row = dgvPhieuBanHang.Rows[e.RowIndex];
            cboMaThe.SelectedValue = row.Cells["MaThe"].Value.ToString();
            cboMaNhanVien.SelectedValue = row.Cells["MaNhanVien"].Value.ToString();
            dtpNgayTao.Text = row.Cells["NgayTao"].Value.ToString();
            txtMaPhieu.Text = row.Cells["MaPhieu"].Value.ToString();

            bool trangThai = Convert.ToBoolean(row.Cells["TrangThai"].Value);
            if (trangThai)
            {
                rdoDaThanhToan.Checked = true;
                rdoDaThanhToan.Enabled = false;
                rdoChoXacNhan.Enabled = false;
                cboMaNhanVien.Enabled = false;
                dtpNgayTao.Enabled = false;
                btnThem.Enabled = false;
                btnSua.Enabled = false;
                btnXoa.Enabled = false;

            }
            else
            {
                rdoDaThanhToan.Checked = false;
                rdoDaThanhToan.Enabled = true;
                rdoChoXacNhan.Enabled = true;
                cboMaNhanVien.Enabled = true;
                rdoChoXacNhan.Checked = true;
                rdoChoXacNhan.Enabled = true;
                dtpNgayTao.Enabled = true;
                btnThem.Enabled = false;
                btnSua.Enabled = true;
                btnXoa.Enabled = true;
            }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            string maThe = cboMaThe.SelectedValue?.ToString();
            string maNhanVien = cboMaNhanVien.SelectedValue?.ToString();
            DateTime ngayTao = dtpNgayTao.Value;

            bool trangThai;
            if (rdoChoXacNhan.Checked)
            {
                trangThai = false;
            }
            else
            {
                trangThai = true;
            }
            if (string.IsNullOrEmpty(maNhanVien) || string.IsNullOrEmpty(maThe))
            {
                MessageBox.Show("Vui lòng điền đầy đủ thông tin phiếu bán hàng.");
                return;
            }

            PhieuBanHang theLuuDong = new PhieuBanHang
            {
                MaThe = maThe,
                MaNhanVien = maNhanVien,
                NgayTao = ngayTao,
                TrangThai = trangThai
            };
            BUSPhieuBanHang bus = new BUSPhieuBanHang();
            string result = bus.InsertPhieuBanHang(theLuuDong);

            if (string.IsNullOrEmpty(result))
            {
                MessageBox.Show("Cập nhật thông tin thành công");
                ClearForm(maThe);
                LoadTheLuuDong();
                LoadNhanVien();
                LoadDanhSachPhieu("");
                cboMaThe.SelectedValue = maThe;
            }
            else
            {
                MessageBox.Show(result);
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            string maThe = cboMaThe.SelectedValue?.ToString();
            string maPhieu = txtMaPhieu.Text;
            string maNhanVien = cboMaNhanVien.SelectedValue?.ToString();
            DateTime ngayTao = dtpNgayTao.Value;

            bool trangThai;
            if (rdoChoXacNhan.Checked)
            {
                trangThai = false;
            }
            else


            {
                trangThai = true;
            }
            if (string.IsNullOrEmpty(maNhanVien) || string.IsNullOrEmpty(maThe))
            {
                MessageBox.Show("Vui lòng điền đầy đủ thông tin phiếu bán hàng.");
                return;
            }

            PhieuBanHang theLuuDong = new PhieuBanHang
            {
                MaPhieu = maPhieu,
                MaThe = maThe,
                MaNhanVien = maNhanVien,
                NgayTao = ngayTao,
                TrangThai = trangThai
            };
            BUSPhieuBanHang bus = new BUSPhieuBanHang();
            string result = bus.UpdatePhieuBanHang(theLuuDong);

            if (string.IsNullOrEmpty(result))
            {
                MessageBox.Show("Cập nhật thông tin thành công");
                ClearForm(maThe);
                LoadTheLuuDong();
                LoadNhanVien();
                LoadDanhSachPhieu("");
                cboMaThe.SelectedValue = maThe;
            }
            else
            {
                MessageBox.Show(result);
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            string maPhieu = txtMaPhieu.Text.Trim();
            string maThe = cboMaThe.SelectedValue?.ToString();
            string chuSoHuu = cboMaThe.Text;
            if (string.IsNullOrEmpty(maPhieu))
            {
                if (dgvPhieuBanHang.SelectedRows.Count > 0)
                {
                    DataGridViewRow selectedRow = dgvPhieuBanHang.SelectedRows[0];
                    maPhieu = selectedRow.Cells["MaPhieu"].Value.ToString();
                    maThe = selectedRow.Cells["MaThe"].Value.ToString();
                    chuSoHuu = selectedRow.Cells["ChuSoHuu"].Value.ToString();
                }
                else
                {
                    MessageBox.Show("Vui lòng chọn thông tin phiếu bán hàng cần xóa xóa!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }

            if (string.IsNullOrEmpty(maPhieu))
            {
                MessageBox.Show("Xóa không thành công.");
                return;
            }

            DialogResult result = MessageBox.Show($"Bạn có chắc chắn muốn xóa phiếu bán hàng {maPhieu} - {chuSoHuu}?", "Xác nhận xóa",
                MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (result == DialogResult.Yes)
            {
                BUSPhieuBanHang bus = new BUSPhieuBanHang();
                string kq = bus.DeletePhieuBanHang(maPhieu);

                if (string.IsNullOrEmpty(kq))
                {
                    MessageBox.Show($"Xóa thông tin phiếu bán hàng {maPhieu} - {chuSoHuu} thành công!", "Thông báo",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ClearForm(maThe);
                    LoadTheLuuDong();
                    LoadNhanVien();
                    LoadDanhSachPhieu("");

                    cboMaThe.SelectedValue = maThe;
                }
                else
                {
                    MessageBox.Show(kq, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }
        }

        private void frmPhieuBanHang_Load(object sender, EventArgs e)
        {
            ClearForm("");
            LoadTheLuuDong();
            LoadNhanVien();
            LoadDanhSachPhieu("");
            LoadMSP();
        }

        private void btnMoi_Click(object sender, EventArgs e)
        {
            ClearForm("");
            LoadTheLuuDong();
            LoadNhanVien();
            LoadDanhSachPhieu("");
            LoadMSP();
        }
        private void LoadMSP()
        {
            BUSSanPham busSanPham = new BUSSanPham();
            List<SanPham> lst = busSanPham.GetSanPhamList(1);
            cboMaSanPham.DataSource = lst;
            cboMaSanPham.ValueMember = "MaSanPham";
            cboMaSanPham.DisplayMember = "TenSanPham";
        }
        private void btnThanhToan_Click(object sender, EventArgs e)
        {
            PhieuBanHang pbh = new PhieuBanHang
            {
                MaPhieu = txtMaPhieu.Text,
                MaThe = cboMaThe.SelectedValue.ToString(),
                MaNhanVien = cboMaNhanVien.SelectedValue.ToString(),
                NgayTao = dtpNgayTao.Value,
                TrangThai = rdoDaThanhToan.Checked
            };
            ChiTietPhieu chiTiet = new ChiTietPhieu
            {
                MaSanPham = cboMaSanPham.SelectedValue.ToString(),
                DonGia = decimal.Parse(txtDonGia.Text),
                SoLuong = int.Parse(txtSoLuong.Text),
            };
            BusChiTietPhieu busChiTietPhieu = new BusChiTietPhieu();
            string result = busChiTietPhieu.InsertChiTietPhieu(chiTiet);
            MessageBox.Show("Thêm chi tiết phiếu thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
