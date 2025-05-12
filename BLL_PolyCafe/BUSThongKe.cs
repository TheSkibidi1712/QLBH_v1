using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL_PolyCafe;
using DTO_PolyCAfe;

namespace BLL_PolyCafe
{
    public class BUSThongKe
    {
        DALThongKe DalTK = new DALThongKe();
        public List<TKDoanhThuTheoLoaiSanPham> getThongKeLoaiSP(string loaiSP, DateTime ngayBD, DateTime ngayKt)
        {
            return DalTK.GetDoanhThuTheoLoaiSP(loaiSP, ngayBD, ngayKt);

        }

        public List<TKDoanhThuTheoNhanVien> getThongKeNhanVien(string maNV, DateTime ngayBD, DateTime ngayKt)
        {
            return DalTK.GetDoanhThuTheoNhanVien(maNV, ngayBD, ngayKt);

        }
    }
}
