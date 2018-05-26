using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLCafe.DAO
{
    public class DAO_GopBan
    {
        public static bool XoaHoaDonCu(int IDHoaDon, int IDBanCu)
        {
            string sTruyVan = string.Format(@"DELETE [CF_HoaDon]  WHERE ID = {0} AND IDBan = {1}", IDHoaDon, IDBanCu);
            return DataProvider.TruyVanKhongLayDuLieu(sTruyVan);
        }
    }
}
