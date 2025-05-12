using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO_PolyCafe
{
    public class PhieuBanHang
    {
        public string? MaPhieu { get; set; }
        public string? MaThe { get; set; }
        public string? ChuSoHuu { get; set; }
        public string? MaNhanVien { get; set; }
        public string? HoTen { get; set; }
        public DateTime NgayTao { get; set; } = new DateTime();
        public bool TrangThai { get; set; } = true;
    }
}
