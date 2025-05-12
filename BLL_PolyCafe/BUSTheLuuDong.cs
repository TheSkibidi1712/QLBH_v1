using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL_PolyCafe;
using DTO_PolyCAfe;

namespace BLL_PolyCafe
{
    public class BUSTheLuuDong
    {
        DALTheLuuDong dalTheLuuDong = new DALTheLuuDong();

        public List<TheLuuDong> GetTheLuuDongList()
        {
            return dalTheLuuDong.selectAll();
        }


        public string InsertTheLuuDong(TheLuuDong the)
        {
            try
            {
                the.MaThe = dalTheLuuDong.generateMaTheLuuDong();
                if (string.IsNullOrEmpty(the.MaThe))
                {
                    return "Mã thẻ lưu động không hợp lệ.";
                }

                dalTheLuuDong.insertTheLuuDong(the);
                return string.Empty;
            }
            catch (Exception ex)
            {
                //return "Thêm mới không thành công.";
                return "Lỗi: " + ex.Message;
            }
        }

        public string UpdateTheLuuDong(TheLuuDong nv)
        {
            try
            {
                if (string.IsNullOrEmpty(nv.MaThe))
                {
                    return "Mã thẻ lưu động không hợp lệ.";
                }

                dalTheLuuDong.updateTheLuuDong(nv);
                return string.Empty;
            }
            catch (Exception ex)
            {
                //return "Cập nhật không thành công.";
                return "Lỗi: " + ex.Message;
            }
        }

        public string DeleteTheLuuDong(string maThe)
        {
            try
            {
                if (string.IsNullOrEmpty(maThe))
                {
                    return "Mã thẻ lưu động không hợp lệ.";
                }

                dalTheLuuDong.deleteTheLuuDong(maThe);
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
