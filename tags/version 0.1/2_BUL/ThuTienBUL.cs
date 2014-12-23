using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _3_DAL;

namespace _2_BUL
{
    public class ThuTienBUL
    {
        public static DataTable SellectAllThuTiensBUL()
        {
            return ThuTienDAL.SellectAllThuTiensDAL();
        }

        public static void DeleteThuTiensBUL(List<string> keys)
        {
            ThuTienDAL.DeleteThuTiensDAL(keys);
        }

        public static THUTIEN SelectThuTienBUL(string key)
        {
            return ThuTienDAL.SelectThuTienDAL(key);
        }

        public static void InsertThuTienBUL(THUTIEN item)
        {
            ThuTienDAL.InsertThuTienDAL(item);
        }

        public static bool checkMaThuTienBUL(string key)
        {
            return ThuTienDAL.checkMaThuTienDAL(key);
        }

        public static void UpdateThuTienBUL(THUTIEN item)
        {
            ThuTienDAL.UpdateThuTienDAL(item);
        }

        public static DataTable SearchThuTiensBUL(string key)
        {
            return ThuTienDAL.SearchThuTiensDAL(key);
        }

        public static bool checkKH_ThuTienBUL(string key)
        {
            return ThuTienDAL.checkKH_ThuTienDAL(key);
        }
    }
}
