using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL_PolyCafe;
using DTO_PolyCafe;
using DTO_PolyCAfe;

namespace BLL_PolyCafe
{
    public class BUSLoaiSanPham
    {
        DALLoaiSanPham dalLoaiSanPham = new DALLoaiSanPham();

        public List<LoaiSanPham> GetLoaiSanPhamList()
        {
            return dalLoaiSanPham.selectAll();
        }

      
        public string InsertLoaiSanPham(LoaiSanPham loaiSP)
        {
            try
            {
                loaiSP.MaLoai = dalLoaiSanPham.generateMaLoaiSanPham();
                if (string.IsNullOrEmpty(loaiSP.MaLoai))
                {
                    return "Mã loại sản phẩm không hợp lệ.";
                }

                dalLoaiSanPham.insertLoaiSanPham(loaiSP);
                return string.Empty;
            }
            catch (Exception ex)
            {
                //return "Thêm mới không thành công.";
                return "Lỗi: " + ex.Message;
            }
        }

        public string UpdateLoaiSanPham(LoaiSanPham loaiSP)
        {
            try
            {
                if (string.IsNullOrEmpty(loaiSP.MaLoai))
                {
                    return "Mã loại sản phẩm không hợp lệ.";
                }

                dalLoaiSanPham.updateLoaiSanPham(loaiSP);
                return string.Empty;
            }
            catch (Exception ex)
            {
                //return "Cập nhật không thành công.";
                return "Lỗi: " + ex.Message;
            }
        }

        public string DeleteLoaiSanPham(string maloaiSP)
        {
            try
            {
                if (string.IsNullOrEmpty(maloaiSP))
                {
                    return "Mã loại sản phẩm không hợp lệ.";
                }

                dalLoaiSanPham.deleteLoaiSanPham(maloaiSP);
                return string.Empty;
            }
            catch (Exception ex)
            {
                //return "Xóa không thành công.";
                return "Lỗi: " + ex.Message;
            }
        }
    }
}
