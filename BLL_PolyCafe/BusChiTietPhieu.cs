using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL_PolyCafe;
using DTO_PolyCafe;

namespace BLL_PolyCafe
{
    public class BusChiTietPhieu
    {
        DALChiTietPhieu dalChiTietPhieu = new DALChiTietPhieu();

        public List<ChiTietPhieu> GetChiTietPhieuList(string maPhieu)
        {
            return dalChiTietPhieu.selectChiTietByMaPhieu(maPhieu);
        }

        public string InsertChiTietPhieu(ChiTietPhieu ct)
        {
            try
            {
                ct.MaChiTiet = dalChiTietPhieu.generateChiTietID();
                if (string.IsNullOrEmpty(ct.MaChiTiet))
                {
                    return "Mã chi tiết phiếu không hợp lệ.";
                }

                dalChiTietPhieu.insertChiTiet(ct);
                return string.Empty;
            }
            catch (Exception ex)
            {
                //return "Thêm mới không thành công.";
                return "Lỗi: " + ex.Message;
            }
        }

        public string UpdateSoLuong(ChiTietPhieu pbh)
        {
            try
            {
                if (string.IsNullOrEmpty(pbh.MaChiTiet))
                {
                    return "Mã chi tiết phiếu không hợp lệ.";
                }

                dalChiTietPhieu.updateSoluong(pbh);
                return string.Empty;
            }
            catch (Exception ex)
            {
                //return "Cập nhật không thành công.";
                return "Lỗi: " + ex.Message;
            }
        }

        public string DeleteChiTiet(string maPhieu)
        {
            try
            {
                if (string.IsNullOrEmpty(maPhieu))
                {
                    return "Mã phiếu bán hàng không hợp lệ.";
                }

                dalChiTietPhieu.deleteChiTietPhieu(maPhieu);
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

