using QLCafe.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLCafe.DAO
{
    public class DAO_BAN
    {
        public List<DTO_BAN> LoadTableList(string IDKhuVuc, string IDChiNhanh)
        {
            List<DTO_BAN> tablelist = new List<DTO_BAN>();
            string sTruyVan = string.Format(@"SELECT * FROM [CF_Ban] WHERE IDKhuVuc = {0} AND [IDChiNhanh] = '{1}' ", IDKhuVuc, IDChiNhanh);
            DataTable data = new DataTable();
            data = DataProvider.TruyVanLayDuLieu(sTruyVan);
            foreach (DataRow item in data.Rows)
            {
                DTO_BAN table = new DTO_BAN(item);
                tablelist.Add(table);
            }
            return tablelist;
        }
        public static DataTable DanhSachBan(string IDKhuVuc)
        {
            string sTruyVan = string.Format(@"SELECT * FROM [CF_Ban] WHERE IDKhuVuc = {0} ", IDKhuVuc);
            DataTable data = new DataTable();
            data = DataProvider.TruyVanLayDuLieu(sTruyVan);
            return data;
        }
        public static int ThongKeBan(string IDChiNhanh, int TrangThai)
        {
            string sTruyVan = string.Format(@"SELECT * FROM [CF_Ban] WHERE IDChiNhanh = {0} AND [TrangThai] = {1}", IDChiNhanh, TrangThai);
            DataTable data = new DataTable();
            data = DataProvider.TruyVanLayDuLieu(sTruyVan);
            return data.Rows.Count;
        }
        private static DAO_BAN instance;

        public static DAO_BAN Instance
        {
            get { if (instance == null) instance = new DAO_BAN(); return DAO_BAN.instance; }
            private set { DAO_BAN.instance = value; }
        }
        private DAO_BAN() { }

        public static bool DoiTrangThaiDatBan(int idban)
        {
            string sTruyVan = string.Format(@"UPDATE [CF_Ban] SET [TrangThai] = 1 WHERE ID = {0}", idban);
            return DataProvider.TruyVanKhongLayDuLieu(sTruyVan);
        }
        public static bool DoiTrangThaiBanCoNguoi(int idban)
        {
            string sTruyVan = string.Format(@"UPDATE [CF_Ban] SET [TrangThai] = 2 WHERE ID = {0}", idban);
            return DataProvider.TruyVanKhongLayDuLieu(sTruyVan);
        }
        public static bool XoaBanVeMatDinh(int idban, string IDChiNhanh)
        {
            string sTruyVan = string.Format(@"UPDATE [CF_Ban] SET [TrangThai] = 0 WHERE ID = {0} AND [IDChiNhanh] = '{1}'", idban, IDChiNhanh);
            return DataProvider.TruyVanKhongLayDuLieu(sTruyVan);
        }
        public static bool ThemKhachDatBan(string TenKhachHang, string DienThoai, DateTime GioDat, int idban, string IDChiNhanh)
        {
            string sTruyVan = string.Format(@"INSERT INTO CF_DatBan(TenKhachHang,DienThoai,GioDat,IDBan,IDChiNhanh) VALUES (N'{0}',N'{1}','{2}','{3}','{4}')", TenKhachHang, DienThoai, GioDat.ToString("yyyy-MM-dd hh:mm:ss tt"), idban, IDChiNhanh);
            return DataProvider.TruyVanKhongLayDuLieu(sTruyVan);
        }
        public static int TrangThaiBan(int IDBan)
        {
            string sTruyVan = string.Format(@"SELECT TrangThai FROM [CF_Ban] WHERE ID = {0}", IDBan);
            DataTable data = new DataTable();
            data = DataProvider.TruyVanLayDuLieu(sTruyVan);
            if (data.Rows.Count > 0)
            {
                DataRow dr = data.Rows[0];
                return Int32.Parse(dr["TrangThai"].ToString());
            }
            else
            {
                return -1;
            }
        }
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
        public static string LenTenBan(int IDBan)
        {
            string sTruyVan = string.Format(@"SELECT TenBan FROM [CF_Ban] WHERE [ID] = {0} ", IDBan);
            DataTable data = new DataTable();
            data = DataProvider.TruyVanLayDuLieu(sTruyVan);
            if (data.Rows.Count > 0)
            {
                DataRow dr = data.Rows[0];
                return dr["TenBan"].ToString();
            }
            return null;
        }
    }
}
