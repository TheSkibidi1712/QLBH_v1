using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO_PolyCAfe;
using Microsoft.Data.SqlClient;
namespace DAL_PolyCafe
{
    public class DALThongKe
    {
        public List<TKDoanhThuTheoLoaiSanPham> GetDoanhThuTheoLoaiSP(string maLoaiSP, DateTime tuNgay, DateTime denNgay)
        {
            string sql = "TKDoanhThuTheoLoaiSanPham";
            List<object> thamSo = new List<object>();
            thamSo.Add(maLoaiSP);
            thamSo.Add(tuNgay);
            thamSo.Add(denNgay);
            List<TKDoanhThuTheoLoaiSanPham> result = new List<TKDoanhThuTheoLoaiSanPham>();
            SqlDataReader reader = DBUtil.Query(sql, thamSo, CommandType.StoredProcedure);
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    TKDoanhThuTheoLoaiSanPham tk = new TKDoanhThuTheoLoaiSanPham();
                    tk.MaSanPham = reader["MaSanPham"].ToString();
                    tk.TenSanPham = reader["TenSanPham"].ToString();
                    tk.SoLy = int.Parse(reader["SoLy"].ToString());
                    tk.SoLuongPhieu = int.Parse(reader["SoLuongPhieu"].ToString());
                    tk.NgayBan = DateTime.Parse(reader["NgayBan"].ToString()).ToString("dd/MM/yyyy");
                    tk.TongTien = decimal.Parse(reader["TongTien"].ToString()).ToString("#,0"); ;
                    tk.DaThanhToan = bool.Parse(reader["TrangThai"].ToString()) ? "Đã Thanh Toán" : "Chưa Thanh Toán";
                    result.Add(tk);
                }
            }
            return result;
        }

        public List<TKDoanhThuTheoNhanVien> GetDoanhThuTheoNhanVien(string maNV, DateTime tuNgay, DateTime denNgay)
        {
            string sql = "TKDoanhThuTheoNhanVien";
            List<object> thamSo = new List<object>();
            thamSo.Add(maNV);
            thamSo.Add(tuNgay);
            thamSo.Add(denNgay);
            List<TKDoanhThuTheoNhanVien> result = new List<TKDoanhThuTheoNhanVien>();
            SqlDataReader reader = DBUtil.Query(sql, thamSo, CommandType.StoredProcedure);
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    TKDoanhThuTheoNhanVien tk = new TKDoanhThuTheoNhanVien();
                    tk.MaNhanVien = reader["MaNhanVien"].ToString();
                    tk.HoTen = reader["HoTen"].ToString();
                    tk.SoLy = int.Parse(reader["SoLy"].ToString());
                    tk.SoLuongPhieu = int.Parse(reader["SoLuongPhieu"].ToString());
                    tk.NgayBan = DateTime.Parse(reader["NgayBan"].ToString()).ToString("dd/MM/yyyy");
                    tk.TongTien = decimal.Parse(reader["TongTien"].ToString()).ToString("#,0"); ;
                    tk.DaThanhToan = bool.Parse(reader["TrangThai"].ToString()) ? "Đã Thanh Toán" : "Chưa Thanh Toán";
                    result.Add(tk);
                }
            }
            return result;
        }
    }
}
