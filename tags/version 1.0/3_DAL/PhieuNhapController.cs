using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using _4_DTO;

namespace _3_DAL
{
    public class PhieuNhapController
    {
        static QLNSModelDataContext db = new QLNSModelDataContext();

        public static void InsertPNDAL(PHIEUNHAP item)
        {
            db.PHIEUNHAPs.InsertOnSubmit(item);

            db.SubmitChanges();
        }

        public static DataTable SellectAllPhieuNhaps_DAL()
        {
            DataTable dt = new DataTable();

            var query = from pn in db.PHIEUNHAPs
                        select new
                        {
                            pn.MaPN,
                            pn.NgayNhap
                        };
            dt.Columns.Add("STT", typeof(int));
            dt.Columns.Add("Mã phiếu nhập", typeof(string));
            dt.Columns.Add("Ngày nhập", typeof(DateTime));
            int stt = 1;
            foreach (var item in query)
            {
                dt.Rows.Add(stt, item.MaPN, item.NgayNhap);
                stt++;
            }

            return dt;
        }

        //Lay Phiếu nhập từ DataGridView
        public static PHIEUNHAP SelectPhieuNhapDAL(string key)
        {
            PHIEUNHAP query = db.PHIEUNHAPs.Single(i => i.MaPN.Equals(key));
            return query;
        }

        public static void DeletePNsDAL(List<string> keys)
        {
            //Take PNs in Nhaps which have maPN equal listPN
            var lstPNs = from b in db.PHIEUNHAPs
                           where keys.Contains(b.MaPN)
                           select b;
            //Take PNs in CTPN which have maPN equal lstPNs.MAPN
            var lstctpns = from b in db.CTPNs
                           join ln in lstPNs on b.MaPN equals ln.MaPN
                           select b;

            //Delete on CTPN
            db.CTPNs.DeleteAllOnSubmit(lstctpns);


            //Delete on NHAP
            db.PHIEUNHAPs.DeleteAllOnSubmit(lstPNs);

            //Confirm database
            db.SubmitChanges();

        }

        public static bool checkMaPNDAL(string key)
        {
            var query = from sc in db.PHIEUNHAPs
                        where sc.MaPN.Equals(key)
                        select sc;

            if (query.Count() <= 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        //kiểm tra lại
        public static void UpdatePNDAL(PHIEUNHAP item)
        {
            var query = db.PHIEUNHAPs.Single(sa => sa.MaPN == item.MaPN);
            query.NgayNhap = item.NgayNhap;
            db.SubmitChanges();
        }

        public static DataTable SearchPNsDAL(string key)
        {
            var query = from pn in db.PHIEUNHAPs
                        where
                        (
                           pn.MaPN.StartsWith(key) ||
                           pn.MaPN.EndsWith(key) ||
                           pn.MaPN.Contains(key) ||
                           pn.NgayNhap.ToString().StartsWith(key) ||
                           pn.NgayNhap.ToString().EndsWith(key) ||
                           pn.NgayNhap.ToString().Contains(key)
                        )
                        select new
                        {
                            pn.MaPN,
                            pn.NgayNhap,
                        };


            DataTable dt = new DataTable();
            dt.Columns.Add("STT", typeof(int));
            dt.Columns.Add("Mã phiếu nhập", typeof(string));
            dt.Columns.Add("Ngày Nhập", typeof(DateTime));
            int stt = 1;
            foreach (var item in query)
            {
                dt.Rows.Add(stt, item.MaPN, item.NgayNhap);
                stt++;
            }

            return dt;
        }
    }
}
