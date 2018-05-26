using QLCafe.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLCafe.DAO
{
    public class DAO_HoaDon
    {
        private static DAO_HoaDon instance;

        public static DAO_HoaDon Instance
        {
            get { if (instance == null) instance = new DAO_HoaDon(); return DAO_HoaDon.instance; }
           private set { DAO_HoaDon.instance = value; }
        }
        private DAO_HoaDon() { }

        /// <summary>
        /// Thành công HoaDonID
        /// Thất bại -1;
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public int GetHoaDonByIDBan(int idban)
        {
            string sTruyVan = string.Format(@"SELECT * FROM [CF_HoaDon] WHERE IDBan = {0} AND [TrangThai] = 0", idban);
            DataTable data = new DataTable();
            data = DataProvider.TruyVanLayDuLieu(sTruyVan);
            if (data.Rows.Count > 0)
            {
                DTO_HoaDon hd = new DTO_HoaDon(data.Rows[0]);
                return hd.ID;
            }

            return -1;
        }

        public static float TongTienHoaDon(int IDHoaDon, string IDChiNhanh)
        {
            string sTruyVan = string.Format(@"SELECT TongTien FROM [CF_HoaDon] WHERE ID = {0} AND [IDChiNhanh] = '" + IDChiNhanh + "'", IDHoaDon);
            DataTable data = new DataTable();
            data = DataProvider.TruyVanLayDuLieu(sTruyVan);
            if (data.Rows.Count > 0)
            {
                DataRow dr = data.Rows[0];
                return float.Parse(dr["TongTien"].ToString());
            }
            return 0;
        }
        public static float TienGiamGia(int IDHoaDon,string IDChiNhanh)
        {
            string sTruyVan = string.Format(@"SELECT TienGiamGia FROM [CF_HoaDon] WHERE ID = {0} AND [IDChiNhanh] = '" + IDChiNhanh + "' ", IDHoaDon);
            DataTable data = new DataTable();
            data = DataProvider.TruyVanLayDuLieu(sTruyVan);
            if (data.Rows.Count > 0)
            {
                DataRow dr = data.Rows[0];
                return float.Parse(dr["TienGiamGia"].ToString());
            }
            return 0;
        }
        public static float GiamGia(int IDHoaDon, string IDChiNhanh)
        {
            string sTruyVan = string.Format(@"SELECT TyLeGiamGia FROM [CF_HoaDon] WHERE ID = {0} AND [IDChiNhanh] = '" + IDChiNhanh + "'", IDHoaDon);
            DataTable data = new DataTable();
            data = DataProvider.TruyVanLayDuLieu(sTruyVan);
            if (data.Rows.Count > 0)
            {
                DataRow dr = data.Rows[0];
                return float.Parse(dr["TyLeGiamGia"].ToString());
            }
            return 0;
        }
        public static string HinhThucGiamGia(int IDHoaDon,string IDChiNhanh)
        {
            string sTruyVan = string.Format(@"SELECT HinhThucGiamGia FROM [CF_HoaDon] WHERE ID = {0} AND [IDChiNhanh] = '{1}' ", IDHoaDon, IDChiNhanh);
            DataTable data = new DataTable();
            data = DataProvider.TruyVanLayDuLieu(sTruyVan);
            if (data.Rows.Count > 0)
            {
                DataRow dr = data.Rows[0];
                return dr["HinhThucGiamGia"].ToString();
            }
            return "$";
        }
        public static float TongTienGio(int IDHoaDon)
        {
            string sTruyVan = string.Format(@"SELECT TienGio FROM [CF_HoaDon] WHERE ID = {0} ", IDHoaDon);
            DataTable data = new DataTable();
            data = DataProvider.TruyVanLayDuLieu(sTruyVan);
            if (data.Rows.Count > 0)
            {
                DataRow dr = data.Rows[0];
                return float.Parse(dr["TienGio"].ToString());
            }
            return 0;
        }
        public static float KhachCanTra(int IDHoaDon, string IDChiNhanh)
        {
            string sTruyVan = string.Format(@"SELECT KhachCanTra FROM [CF_HoaDon] WHERE ID = {0} AND [IDChiNhanh] = '" + IDChiNhanh + "'", IDHoaDon);
            DataTable data = new DataTable();
            data = DataProvider.TruyVanLayDuLieu(sTruyVan);
            if (data.Rows.Count > 0)
            {
                DataRow dr = data.Rows[0];
                return float.Parse(dr["KhachCanTra"].ToString());
            }
            return 0;
        }

        public static void XoaDatBan(int IDBan, string IDChiNhanh)
        {
            string sTruyVan = string.Format(@"SELECT * FROM [CF_HoaDon] WHERE IDBan = {0} AND [TrangThai] = 0 AND [IDChiNhanh] = '{1}'", IDBan, IDChiNhanh);
            DataTable data = new DataTable();
            data = DataProvider.TruyVanLayDuLieu(sTruyVan);
            if (data.Rows.Count > 0)
            {
                DTO_HoaDon hd = new DTO_HoaDon(data.Rows[0]);

                sTruyVan = string.Format(@"DELETE FROM [CF_ChiTietHoaDon_Temp] WHERE IDHoaDon = {0} AND IDChiNhanh = '{1}'", hd.ID, hd.IDChiNhanh);
                DataProvider.TruyVanKhongLayDuLieu(sTruyVan);

                sTruyVan = string.Format(@"DELETE FROM [CF_HoaDon] WHERE ID = {0}   AND [TrangThai] = 0 AND IDChiNhanh = '{1}'", hd.ID, hd.IDChiNhanh); 
                DataProvider.TruyVanKhongLayDuLieu(sTruyVan);

                //sTruyVan = string.Format(@"DELETE FROM [CF_ChiTietGio] WHERE IDHoaDon = {0} AND [ThanhToan] = 0", hd.ID);
                //DataProvider.TruyVanKhongLayDuLieu(sTruyVan);
               
            }
        }
        public static bool CapNhatTongTien(int ID, string TongTien, string KhachCanTra, string TienGio)
        {
            string sTruyVan = string.Format(@"UPDATE CF_HoaDon SET [TongTien] = {0}, [KhachCanTra] =  {1}, [TienGio] = {3} WHERE [ID] = {2} ", TongTien, KhachCanTra, ID, TienGio);
            return DataProvider.TruyVanKhongLayDuLieu(sTruyVan);
        }
    }
}
