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
    public partial class frmQLLoaiSanPham : Form
    {
        public frmQLLoaiSanPham()
        {
            InitializeComponent();
        }
        private void LoadDSLSP()
        {
            BUSLoaiSanPham busLSP = new BUSLoaiSanPham();
            dgvDSLSP.DataSource = null;
            dgvDSLSP.DataSource = busLSP.GetLoaiSanPhamList();
        }
        private void ClearForm()
        {
            btnThem.Enabled = true;
            btnSua.Enabled = false;
            btnXoa.Enabled = true;
            txtMaLoai.Clear();
            txtTenLoai.Clear();
            txtGhiChu.Clear();
            txtMaLoai.Enabled = true;
            txtMaLoai.ReadOnly = false;
        }
        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            ClearForm();
            LoadDSLSP();
        }

        private void frmQLLoaiSanPham_Load(object sender, EventArgs e)
        {
            LoadDSLSP();
            ClearForm();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            try
            {
                string MaLoai = txtMaLoai.Text.Trim();
                string TenLoai = txtTenLoai.Text.Trim();
                string GhiChu = txtGhiChu.Text.Trim();
                if (string.IsNullOrEmpty(MaLoai) || string.IsNullOrEmpty(TenLoai) || string.IsNullOrEmpty(GhiChu))
                {
                    MessageBox.Show("Vui lòng nhập đầy đủ thông tin!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                LoaiSanPham lsp = new LoaiSanPham()
                {
                    MaLoai = MaLoai,
                    TenLoai = TenLoai,
                    GhiChu = GhiChu
                };
                BUSLoaiSanPham busLSP = new BUSLoaiSanPham();
                busLSP.InsertLoaiSanPham(lsp);
                MessageBox.Show("Thêm loại sản phẩm thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ClearForm();
                LoadDSLSP();
            }
            catch (Exception ex)
            {

                MessageBox.Show("Lỗi: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            try
            {
                string MaLoai = txtMaLoai.Text.Trim();
                string TenLoai = txtTenLoai.Text.Trim();
                string GhiChu = txtGhiChu.Text.Trim();
                if (string.IsNullOrEmpty(MaLoai) || string.IsNullOrEmpty(TenLoai) || string.IsNullOrEmpty(GhiChu))
                {
                    MessageBox.Show("Vui lòng nhập đầy đủ thông tin!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                LoaiSanPham lsp = new LoaiSanPham()
                {
                    MaLoai = MaLoai,
                    TenLoai = TenLoai,
                    GhiChu = GhiChu
                };
                BUSLoaiSanPham busLSP = new BUSLoaiSanPham();
                busLSP.UpdateLoaiSanPham(lsp);
                MessageBox.Show("Cập nhật loại sản phẩm thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ClearForm();
                LoadDSLSP();
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            try
            {
                string MaLoai = txtMaLoai.Text.Trim();
                string TenLoai = txtTenLoai.Text.Trim();
                string GhiChu = txtGhiChu.Text.Trim();
                if (string.IsNullOrEmpty(MaLoai))
                {
                    if (dgvDSLSP.Rows.Count > 0)
                    {
                        DataGridViewRow selectedRow = dgvDSLSP.SelectedRows[0];
                        MaLoai = selectedRow.Cells["MaLoai"].Value.ToString();
                        TenLoai = selectedRow.Cells["TenLoai"].Value.ToString();
                        GhiChu = selectedRow.Cells["GhiChu"].Value.ToString();
                    }
                    else
                    {
                        MessageBox.Show("Vui lòng chọn một loại sản phẩm để xóa!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }
                else
                {
                    TenLoai = txtTenLoai.Text.ToString();
                }
                if (string.IsNullOrEmpty(MaLoai))
                {
                    MessageBox.Show("Xóa không thành công.");
                    return;
                }
                DialogResult result = MessageBox.Show($"Bạn có chắc chắn muốn xóa loại sản phẩm {MaLoai} - {TenLoai}?", "Xác nhận xóa",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                if (result == DialogResult.Yes)
                {
                    BUSLoaiSanPham busLSP = new BUSLoaiSanPham();
                    string kq = busLSP.DeleteLoaiSanPham(MaLoai);

                    if (string.IsNullOrEmpty(kq))
                    {

                        MessageBox.Show($"Xóa thông tin loại sản phẩm {MaLoai} - {TenLoai} thành công!", "Thông báo",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                        ClearForm();
                        LoadDSLSP();
                    }
                    else
                    {
                        MessageBox.Show(kq, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }

                }
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        private void dgvDSLSP_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow rows = dgvDSLSP.Rows[e.RowIndex];
            txtMaLoai.Text = rows.Cells["MaLoai"].Value.ToString();
            txtTenLoai.Text = rows.Cells["TenLoai"].Value.ToString();
            txtGhiChu.Text = rows.Cells["GhiChu"].Value.ToString();
            btnThem.Enabled = false;
            btnSua.Enabled = true;
            btnXoa.Enabled = true;
            txtMaLoai.Enabled = false;
            txtMaLoai.ReadOnly = true;
        }
    }
}
