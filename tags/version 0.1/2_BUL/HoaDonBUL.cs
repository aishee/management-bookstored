
using _3_DAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2_BUL
{
    public class HoaDonBUL
    {
        public static DataTable SellectAllHoaDonBUL()
        {
            return HoaDonDAL.SellectAllHoaDonDAL();
        }

        public static void DeleteHoaDonsBUL(List<string> keys)
        {
            HoaDonDAL.DeleteHoaDonsDAL(keys);
        }

        public static HOADON SelectHoaDonBUL(string key)
        {
            return HoaDonDAL.SelectHoaDonDAL(key);
        }

        public static void InsertHoaDonBUL(HOADON item)
        {
            HoaDonDAL.InsertHoaDonDAL(item);
        }

        public static bool checkMaHDBUL(string key)
        {
            return HoaDonDAL.checkMaHDDAL(key);
        }

        public static void UpdateHoaDonBUL(HOADON item)
        {
            HoaDonDAL.UpdateHoaDonDAL(item);
        }

        public static DataTable SearchHoaDonsBUL(string key)
        {
            return HoaDonDAL.SearchHoaDonsDAL(key);
        }
    }
}
