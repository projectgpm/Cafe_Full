using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLCafe.DAO
{
    class DAO_KhuVuc
    {
        public static DataTable DanhSachKhuVuc(string IDChiNhanh)
        {
            string sTruyVan = string.Format(@"SELECT * FROM [CF_KhuVuc] WHERE IDChiNhanh = {0} AND DAXOA = 0", IDChiNhanh);
            DataTable data = new DataTable();
            data = DataProvider.TruyVanLayDuLieu(sTruyVan);
            return data;
        }

        public static float LayGiaTheoKhuVuc(int IDKhuVuc)
        {
            string sTruyVan = string.Format(@"SELECT GiaKhuVuc FROM [CF_KhuVuc] WHERE [ID] = {0} ", IDKhuVuc);
            DataTable data = new DataTable();
            data = DataProvider.TruyVanLayDuLieu(sTruyVan);
            if (data.Rows.Count > 0)
            {
                DataRow dr = data.Rows[0];
                return float.Parse(dr["GiaKhuVuc"].ToString());
            }
            return 0;
        }
    }
}
