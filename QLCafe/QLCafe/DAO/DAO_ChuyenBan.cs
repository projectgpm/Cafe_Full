using QLCafe.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLCafe.DAO
{
    public class DAO_ChuyenBan
    {
        /// <summary>
        /// truyền IDBan
        /// </summary>
        /// <param name="IDBan"></param>
        /// <returns></returns>
        public static int LayIDKhuVuc(int IDBan)
        {
            string sTruyVan = string.Format(@"SELECT IDKhuVuc FROM [CF_Ban] WHERE [ID] = {0} ", IDBan);
            DataTable data = new DataTable();
            data = DataProvider.TruyVanLayDuLieu(sTruyVan);
            if (data.Rows.Count > 0)
            {
                DataRow dr = data.Rows[0];
                return Int32.Parse(dr["IDKhuVuc"].ToString());
            }
            return -1;
        }
        /// <summary>
        /// truyền IDKhuVuc
        /// </summary>
        /// <param name="IDKhuVuc"></param>
        /// <returns></returns>
        public static string LayTenKhuVuc(int IDKhuVuc)
        {
            string sTruyVan = string.Format(@"SELECT TenKhuVuc FROM [CF_KhuVuc] WHERE [ID] = {0} ", IDKhuVuc);
            DataTable data = new DataTable();
            data = DataProvider.TruyVanLayDuLieu(sTruyVan);
            if (data.Rows.Count > 0)
            {
                DataRow dr = data.Rows[0];
                return dr["TenKhuVuc"].ToString();
            }
            return null;
        }

        /// <summary>
        /// truyền IDBan
        /// </summary>
        /// <param name="IDBan"></param>
        /// <returns></returns>
        public static string LayTenBan(int IDBan)
        {
            string sTruyVan = string.Format(@"SELECT * FROM [CF_Ban] WHERE ID = {0} ", IDBan);
            DataTable data = new DataTable();
            data = DataProvider.TruyVanLayDuLieu(sTruyVan);
            if (data.Rows.Count > 0)
            {
                DataRow dr = data.Rows[0];
                return dr["TenBan"].ToString();
            }
            return null;
        }


        public static List<DTO_BAN> DanhSachBanTheoKhuVuc(int IDKhuVuc, int TrangThai, int IDBan)
        {
            List<DTO_BAN> tablelist = new List<DTO_BAN>();
            string sTruyVan = string.Format(@"SELECT * FROM [CF_Ban] WHERE IDKhuVuc = {0} AND ('" + TrangThai + "' = -1 OR [TrangThai] = {1}) AND [ID] != {2} ", IDKhuVuc, TrangThai, IDBan);
            DataTable data = new DataTable();
            data = DataProvider.TruyVanLayDuLieu(sTruyVan);
            foreach (DataRow item in data.Rows)
            {
                DTO_BAN table = new DTO_BAN(item);
                tablelist.Add(table);
            }
            return tablelist;
        }

        /// <summary>
        /// xóa chi tiết idhoadon 
        /// </summary>
        /// <param name="IDHoaDon"></param>
        /// <param name="IDBanCu"></param>
        /// <returns></returns>
        public static bool XoaChiTietBanCu(int IDHoaDon, int IDBanCu)
        {
            string sTruyVan = string.Format(@"DELETE [CF_ChiTietHoaDon_Temp]  WHERE IDHoaDon = {0} AND IDBan = {1}", IDHoaDon, IDBanCu);
            return DataProvider.TruyVanKhongLayDuLieu(sTruyVan);
        }

        /// <summary>
        /// cập nhật hóa đơn
        /// </summary>
        /// <param name="IDHoaDon"></param>
        /// <param name="IDBanMoi"></param>
        /// <returns></returns>
        public static bool CapNhatHoaDon(int IDHoaDon, int IDBanMoi)
        {
            string sTruyVan = string.Format(@"UPDATE [CF_HoaDon] SET [IDBan] = {0} WHERE ID = {1}", IDBanMoi, IDHoaDon);
            return DataProvider.TruyVanKhongLayDuLieu(sTruyVan);
        }

        /// <summary>
        /// cạp nhật idbanmoi
        /// </summary>
        /// <param name="idban"></param>
        /// <returns></returns>
        public static bool CapNhatIDBanMoi(int IDBanMoi, int ID, string IDChiNhanh)
        {
            string sTruyVan = string.Format(@"UPDATE [CF_ChiTietHoaDon_Temp] SET [IDBan] = '{0}' WHERE ID = {1} AND [IDChiNhanh] = '{2}'", IDBanMoi, ID, IDChiNhanh);
            return DataProvider.TruyVanKhongLayDuLieu(sTruyVan);
        }
    }
}
