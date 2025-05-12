
using DTO_PolyCafe;

namespace UTIL_PolyCafe
{
    public class AuthUtil
    {
        public static NhanVien user = null;
        public static bool IsLogin()
        {
            if (user == null)
            {
                return false;
            }
            if (string.IsNullOrWhiteSpace(user.MaNhanVien))
            {
                return false;
            }
            return true;
        }
    }
}
