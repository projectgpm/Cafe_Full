using QLCafe.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLCafe.DAO
{
    class DAO_DangNhap
    {
        static SqlConnection con;
        public static bool LayThongTin(string TenDangNhap, string MatKhau)
        {
            try
            {
                string sTryVan = string.Format(@"SELECT * FROM [CF_NguoiDung] WHERE [TenDangNhap] = N'{0}' AND [DAXOA] = 0 AND [MatKhau] =N'{1}' ", TenDangNhap, MatKhau);
                DataTable data = new DataTable();
                data = DataProvider.TruyVanLayDuLieu(sTryVan);
                if (data.Rows.Count != 0)
                {
                    return true;
                }
                else
                    return false;
            }
            catch
            {
                return false;
            }
        }
        public static DataTable ThongTinNhanVien(string TenDangNhap, string MatKhau)
        {
            string sTryVan = string.Format(@"SELECT * FROM [CF_NguoiDung] WHERE [TenDangNhap] = N'{0}' AND [DAXOA] = 0 AND [MatKhau] =N'{1}'", TenDangNhap, MatKhau);
            DataTable data = new DataTable();
            data = DataProvider.TruyVanLayDuLieu(sTryVan);
            return data;
        }
        public static bool DoiMatKhau(string TenDangNhap, string MatKhau, string MatKhauMoi)
        {
            string sTruyVan = string.Format(@"UPDATE [CF_NguoiDung] SET [MatKhau] = N'{0}' WHERE [TenDangNhap] = N'{1}' AND [MatKhau] = N'{2}'", MatKhauMoi, TenDangNhap, MatKhau);
            return DataProvider.TruyVanKhongLayDuLieu(sTruyVan);
        }

        //public static bool CheckDuLieu(string TenDangNhap, string MatKhau, string MatKhauMoi)
        //{
        //    string sTruyVan = string.Format(@"UPDATE [CF_NguoiDung] SET [MatKhau] = N'{0}' WHERE [TenDangNhap] = N'{1}' AND [MatKhau] = N'{2}'", MatKhauMoi, TenDangNhap, MatKhau);
        //    return DataProvider.TruyVanKhongLayDuLieu(sTruyVan);
        //}

        public static bool ThemKeyKichHoat(string Key)
        {
            string sTruyVan = string.Format(@"UPDATE Setting SET [TestDuLieu] = N'{0}' WHERE ID = 1", Key);
            return DataProvider.TruyVanKhongLayDuLieu(sTruyVan);
        }
        public static DataTable QuanLy(string TenDangNhap, string MatKhau)
        {
            string sTryVan = string.Format(@"SELECT * FROM [CF_NguoiDung] WHERE [TenDangNhap] = N'{0}' AND [DAXOA] = 0 AND [MatKhau] =N'{1}' AND IDNhomNguoiDung = 1", TenDangNhap, MatKhau);
            DataTable data = new DataTable();
            data = DataProvider.TruyVanLayDuLieu(sTryVan);
            return data;
        }
    }
}
