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
    public class DALTheLuuDong
    {
        public List<TheLuuDong> SelectBySql(string sql, List<object> args, CommandType cmdType = CommandType.Text)
        {
            List<TheLuuDong> list = new List<TheLuuDong>();
            try
            {
                SqlDataReader reader = DBUtil.Query(sql, args);
                while (reader.Read())
                {
                    TheLuuDong entity = new TheLuuDong();
                    entity.MaThe = reader.GetString("MaThe");
                    entity.ChuSoHuu = reader.GetString("ChuSoHuu");
                    entity.TrangThai = reader.GetBoolean("TrangThai");
                    list.Add(entity);
                }
            }
            catch (Exception)
            {
                throw;
            }
            return list;
        }

        public List<TheLuuDong> selectAll()
        {
            String sql = "SELECT * FROM TheLuuDong";
            return SelectBySql(sql, new List<object>());
        }

        public string generateMaTheLuuDong()
        {
            string prefix = "THE";
            string sql = "SELECT MAX(MaThe) FROM TheLuuDong";
            List<object> thamSo = new List<object>();
            object result = DBUtil.ScalarQuery(sql, thamSo);
            if (result != null && result.ToString().StartsWith(prefix))
            {
                string maxCode = result.ToString().Substring(3);
                int newNumber = int.Parse(maxCode) + 1;
                return $"{prefix}{newNumber:D3}";
            }

            return $"{prefix}001";
        }

        public void insertTheLuuDong(TheLuuDong the)
        {
            try
            {
                string sql = @"INSERT INTO TheLuuDong (MaThe, ChuSoHuu, TrangThai) 
                   VALUES (@0, @1, @2)";
                List<object> thamSo = new List<object>();
                thamSo.Add(the.MaThe);
                thamSo.Add(the.ChuSoHuu);
                thamSo.Add(the.TrangThai);
                DBUtil.Update(sql, thamSo);
            }
            catch (Exception e)
            {
                throw;
            }
        }

        public void updateTheLuuDong(TheLuuDong the)
        {
            try
            {
                string sql = @"UPDATE TheLuuDong 
                   SET ChuSoHuu = @1, TrangThai = @2
                   WHERE MaThe = @0";
                List<object> thamSo = new List<object>();
                thamSo.Add(the.MaThe);
                thamSo.Add(the.ChuSoHuu);
                thamSo.Add(the.TrangThai);
                DBUtil.Update(sql, thamSo);
            }
            catch (Exception e) { throw; }
        }

        public void deleteTheLuuDong(string maThe)
        {
            try
            {
                string sql = "DELETE FROM TheLuuDong WHERE MaThe = @0";
                List<object> thamSo = new List<object>();
                thamSo.Add(maThe);
                DBUtil.Update(sql, thamSo);
            }
            catch (Exception e)
            {
                throw;
            }
        }
    }
}
