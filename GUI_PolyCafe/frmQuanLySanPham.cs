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
using DTO_PolyCAfe;
using GUI_PolyCafe.Helper;

namespace GUI_PolyCafe
{
    public partial class frmQuanLySanPham : Form
    {
        public frmQuanLySanPham()
        {
            InitializeComponent();
        }
        private void ClearForm()
        {
            btnThem.Enabled = true;
            btnSua.Enabled = false;
            btnXoa.Enabled = true;
            txtMaSanPham.Clear();
            txtTenSanPham.Clear();
            txtDonGia.Clear();
            rdoActive.Checked = true;
            pbHinhAnh.Image = null;
            txtMaSanPham.Enabled = true;
            txtMaSanPham.ReadOnly = false;
        }
        private void LoadLoaiSanPham()
        {
            try
            {
                BUSLoaiSanPham bUSLoaiSanPham = new BUSLoaiSanPham();
                List<LoaiSanPham> dsLoai = bUSLoaiSanPham.GetLoaiSanPhamList();
                cboLoaiSanPham.DataSource = dsLoai;
                cboLoaiSanPham.ValueMember = "MaLoai";
                cboLoaiSanPham.DisplayMember = "TenLoai";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải danh sách loại sản phẩm" + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void btnThem_Click(object sender, EventArgs e)
        {
            try
            {
                string MaSanPham = txtMaSanPham.Text.Trim();
                string TenSanPham = txtTenSanPham.Text.Trim();
                string DonGia = txtDonGia.Text.Trim();
                string MaLoai = cboLoaiSanPham.SelectedValue.ToString();
                bool TrangThai = rdoActive.Checked;
                if (string.IsNullOrEmpty(MaSanPham) || string.IsNullOrEmpty(TenSanPham) || string.IsNullOrEmpty(MaLoai))
                {
                    MessageBox.Show("Vui lòng nhập đầy đủ thông tin!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                if (!decimal.TryParse(DonGia, out decimal donGia))
                {
                    MessageBox.Show("Đơn giá không hợp lệ!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                string SavePath = ImageUtil.SaveImage(pbHinhAnh.Image, "Uploads");
                SanPham sp = new SanPham()
                {
                    MaSanPham = MaSanPham,
                    TenSanPham = TenSanPham,
                    DonGia = donGia,
                    MaLoai = MaLoai,
                    HinhAnh = SavePath,
                    TrangThai = TrangThai
                };
                BUSSanPham busSanPham = new BUSSanPham();
                busSanPham.InsertSanPham(sp);
                MessageBox.Show("Thêm sản phẩm thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                ClearForm();
                LoadDSSanPham();


            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void frmQuanLySanPham_Load(object sender, EventArgs e)
        {
            LoadLoaiSanPham();
            LoadDSSanPham();
        }
        private void LoadDSSanPham()
        {
            BUSSanPham busSanPham = new BUSSanPham();
            dgvDSSP.DataSource = null;
            List<SanPham> dsSanPham = busSanPham.GetSanPhamList();
            dgvDSSP.DataSource = dsSanPham;
        }
        private void btnSua_Click(object sender, EventArgs e)
        {
            try
            {
                string MaSanPham = txtMaSanPham.Text.Trim();
                string TenSanPham = txtTenSanPham.Text.Trim();
                string DonGia = txtDonGia.Text.Trim();
                string MaLoai = cboLoaiSanPham.SelectedValue.ToString();
                string HinhAnh = pbHinhAnh.Text.Trim();
                bool TrangThai = rdoActive.Checked;
                if (string.IsNullOrEmpty(MaSanPham) || string.IsNullOrEmpty(TenSanPham) || string.IsNullOrEmpty(MaLoai))
                {
                    MessageBox.Show("Vui lòng nhập đầy đủ thông tin!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                if (!decimal.TryParse(DonGia, out decimal donGia))
                {
                    MessageBox.Show("Đơn giá không hợp lệ!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                SanPham sp = new SanPham()
                {
                    MaSanPham = MaSanPham,
                    TenSanPham = TenSanPham,
                    DonGia = donGia,
                    MaLoai = MaLoai,
                    HinhAnh = HinhAnh,
                    TrangThai = TrangThai
                };
                BUSSanPham busSanPham = new BUSSanPham();
                string result = busSanPham.UpdateSanPham(sp);
                MessageBox.Show("Thêm sản phẩm thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                ClearForm();
                LoadDSSanPham();

            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            try
            {
                string MaSanPham = txtMaSanPham.Text.Trim();
                string TenSanPham = txtTenSanPham.Text.Trim();
                string DonGia = txtDonGia.Text.Trim();
                string HinhAnh = pbHinhAnh.Text.Trim();
                if (string.IsNullOrEmpty(MaSanPham))
                {
                    if (dgvDSSP.SelectedRows.Count > 0)
                    {
                        DataGridViewRow selectedRow = dgvDSSP.SelectedRows[0];
                        MaSanPham = selectedRow.Cells["MaSanPham"].Value.ToString();
                        TenSanPham = selectedRow.Cells["TenSanPham"].Value.ToString();
                        DonGia = selectedRow.Cells["DonGia"].Value.ToString();
                        HinhAnh = selectedRow.Cells["HinhAnh"].Value.ToString();
                    }
                    else
                    {
                        MessageBox.Show("Vui lòng chọn một sản phẩm để xóa!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }
                else
                {
                    TenSanPham = txtTenSanPham.Text.Trim();
                }
                if (string.IsNullOrEmpty(MaSanPham))
                {
                    MessageBox.Show("Xóa không thành công.");
                    return;
                }

                DialogResult result = MessageBox.Show($"Bạn có chắc chắn muốn xóa sản phẩm {MaSanPham} - {TenSanPham}?", "Xác nhận xóa",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                if (result == DialogResult.Yes)
                {
                    BUSSanPham bus = new BUSSanPham();
                    string kq = bus.DeleteSanPham(MaSanPham);

                    if (string.IsNullOrEmpty(kq))
                    {

                        MessageBox.Show($"Xóa thông tin sản phẩm {MaSanPham} - {TenSanPham} thành công!", "Thông báo",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                        ClearForm();
                        LoadDSSanPham();
                    }
                    else
                    {
                        MessageBox.Show(kq, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }

                }
            }
            catch (Exception ex)
            {

                MessageBox.Show("Lỗi: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            ClearForm();
            LoadDSSanPham();
            LoadLoaiSanPham();
        }

        private void dgvDSSP_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow rows = dgvDSSP.Rows[e.RowIndex];
            txtMaSanPham.Text = rows.Cells["MaSanPham"].Value.ToString();
            txtTenSanPham.Text = rows.Cells["TenSanPham"].Value.ToString();
            txtDonGia.Text = rows.Cells["DonGia"].Value.ToString();
            cboLoaiSanPham.SelectedValue = rows.Cells["MaLoai"].Value.ToString();
            pbHinhAnh.Image = ImageUtil.LoadImage(rows.Cells["HinhAnh"].Value.ToString());
            bool TrangThai = Convert.ToBoolean(rows.Cells["TrangThai"].Value);
            if (TrangThai)
            {
                rdoActive.Checked = true;
            }
            else
            {
                rdoDeActive.Checked = true;
            }
            btnThem.Enabled = false;
            btnSua.Enabled = true;
            btnXoa.Enabled = true;
            txtMaSanPham.Enabled = false;
            txtMaSanPham.ReadOnly = true;

        }

        private void btnChonAnh_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp;*.gif";

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                pbHinhAnh.Image = Image.FromFile(openFileDialog.FileName);
            }
        }
    }
}
