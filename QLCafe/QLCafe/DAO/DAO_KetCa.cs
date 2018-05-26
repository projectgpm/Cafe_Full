using QLCafe.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLCafe.DAO
{
    public class DAO_KetCa
    {
        private static DAO_KetCa instance;

        public static DAO_KetCa Instance
        {
            get { if (instance == null) instance = new DAO_KetCa(); return DAO_KetCa.instance; }
            private set { DAO_KetCa.instance = value; }
        }
        public DAO_KetCa() { }
        public List<DTO_KetCa> DanhSachCaBan(DateTime ThoiGianBatDau, string IDChiNhanh)
        {
            List<DTO_KetCa> tablelist = new List<DTO_KetCa>();
            string sTruyVan = string.Format(@"SELECT [CF_KetCa].*,[CF_NguoiDung].TenNguoiDung FROM [CF_KetCa],[CF_NguoiDung] WHERE [CF_KetCa].IDChiNhanh = {1}  AND [CF_KetCa].IDNhanVien = [CF_NguoiDung].ID  AND '{0}' BETWEEN FORMAT([ThoiGianBatDau],'yyyy-MM-dd') AND FORMAT([ThoiGianKetThuc],'yyyy-MM-dd')", ThoiGianBatDau.ToString("yyyy-MM-dd"), IDChiNhanh);
            DataTable data = new DataTable();
            data = DataProvider.TruyVanLayDuLieu(sTruyVan);
            foreach (DataRow item in data.Rows)
            {
                DTO_KetCa table = new DTO_KetCa(item);
                tablelist.Add(table);
            }
            return tablelist;
        }
        public static double TongTienKetCa(int IDNhanVien)
        {
            string sTruyVan = string.Format(@" SELECT (SUM(TongTien) + SUM(TienGio)) AS TongTienHienTai FROM [CF_HoaDon] WHERE IDNhanVien = {0} AND TrangThai = 1 AND TrangThaiKetCa = 0", IDNhanVien);
            DataTable data = new DataTable();
            data = DataProvider.TruyVanLayDuLieu(sTruyVan);
            if (data.Rows.Count > 0)
            {
                DataRow dr = data.Rows[0];
                if (dr["TongTienHienTai"].ToString() != "")
                {
                    return double.Parse(dr["TongTienHienTai"].ToString());
                } return 0;
            }
            else
                return 0;
        }
        public static double TongTienKetCaTienGio(int IDNhanVien)
        {
            string sTruyVan = string.Format(@" SELECT (SUM(TienGio)) AS TongTienGio FROM [CF_HoaDon] WHERE IDNhanVien = {0} AND TrangThai = 1 AND TrangThaiKetCa = 0", IDNhanVien);
            DataTable data = new DataTable();
            data = DataProvider.TruyVanLayDuLieu(sTruyVan);
            if (data.Rows.Count > 0)
            {
                DataRow dr = data.Rows[0];
                if (dr["TongTienGio"].ToString() != "")
                {
                    return double.Parse(dr["TongTienGio"].ToString());
                } return 0;
            }
            else
                return 0;
        }
        public static double TongTienKetCaTienNuoc(int IDNhanVien)
        {
            string sTruyVan = string.Format(@" SELECT (SUM(TongTien)) AS TongTienNuoc FROM [CF_HoaDon] WHERE IDNhanVien = {0} AND TrangThai = 1 AND TrangThaiKetCa = 0", IDNhanVien);
            DataTable data = new DataTable();
            data = DataProvider.TruyVanLayDuLieu(sTruyVan);
            if (data.Rows.Count > 0)
            {
                DataRow dr = data.Rows[0];
                if (dr["TongTienNuoc"].ToString() != "")
                {
                    return double.Parse(dr["TongTienNuoc"].ToString());
                } return 0;
            }
            else
                return 0;
        }

        public static double TongTienHienTai(int IDNhanVien, string IDChiNhanh)
        {
            string sTruyVan = string.Format(@" SELECT (SUM(TongTien)) AS TongTien FROM [CF_HoaDon] WHERE IDNhanVien = {0} AND TrangThai = 1 AND TrangThaiKetCa = 0 AND [IDChiNhanh] = '{1}'", IDNhanVien, IDChiNhanh);
            DataTable data = new DataTable();
            data = DataProvider.TruyVanLayDuLieu(sTruyVan);
            if (data.Rows.Count > 0)
            {
                DataRow dr = data.Rows[0];
                if (dr["TongTien"].ToString() != "")
                {
                    return double.Parse(dr["TongTien"].ToString());
                } return 0;
            }
            else
                return 0;
        }
        public static double TongTienGiamGiaHienTai(int IDNhanVien, string IDChiNhanh)
        {
            string sTruyVan = string.Format(@" SELECT (SUM(TongTien - KhachCanTra)) AS TongTienGiamGia FROM [CF_HoaDon] WHERE IDNhanVien = {0} AND TrangThai = 1 AND TrangThaiKetCa = 0 AND [IDChiNhanh] = '{1}'", IDNhanVien, IDChiNhanh);
            DataTable data = new DataTable();
            data = DataProvider.TruyVanLayDuLieu(sTruyVan);
            if (data.Rows.Count > 0)
            {
                DataRow dr = data.Rows[0];
                if (dr["TongTienGiamGia"].ToString() != "")
                {
                    return double.Parse(dr["TongTienGiamGia"].ToString());
                } return 0;
            }
            else
                return 0;
        }
        public static bool CapNhatKetCa(int IDNhanVien)
        {
            string sTruyVan = string.Format(@" UPDATE [CF_HoaDon] SET [TrangThaiKetCa] = 1 WHERE IDNhanVien = {0} AND TrangThai = 1 AND TrangThaiKetCa = 0", IDNhanVien);
            return DataProvider.TruyVanKhongLayDuLieu(sTruyVan);
        }
        public static string GioVaoCa(int IDNhanVien)
        {
            string sTruyVan = string.Format(@"SELECT GioRa FROM [CF_HoaDon] WHERE IDNhanVien = {0} AND TrangThai = 1 AND TrangThaiKetCa = 0 ORDER BY ID ASC", IDNhanVien);
            DataTable data = new DataTable();
            data = DataProvider.TruyVanLayDuLieu(sTruyVan);
            if (data.Rows.Count > 0)
            {
                DataRow dr = data.Rows[0];
                return dr["GioRa"].ToString();
            }
            else
                return DateTime.Now.ToString("yyyy-MM-dd H:mm:ss");
        }
        //public static string GioRaCa(int IDNhanVien)
        //{
        //    string sTruyVan = string.Format(@"SELECT GioRa FROM [CF_HoaDon] WHERE IDNhanVien = {0} AND TrangThai = 1 AND TrangThaiKetCa = 0 AND FORMAT(GioVao,'yyyy-MM-dd') = '{1}' ORDER BY GioRa DESC", IDNhanVien, NgayHomNay.ToString("yyyy-MM-dd"));
        //    DataTable data = new DataTable();
        //    data = DataProvider.TruyVanLayDuLieu(sTruyVan);
        //    if (data.Rows.Count > 0)
        //    {
        //        DataRow dr = data.Rows[0];
        //        return dr["GioRa"].ToString();
        //    }
        //    else
        //        return DateTime.Now.ToString("yyyy-MM-dd H:mm:ss");
        //}
        public static bool ThemKetCa(int IDNhanVien, string GioVao, double TongTienSauCa, string IDChiNhanh, double TongTien, double GiamGia)
        {
            string sTruyVan = string.Format(@"INSERT INTO CF_KetCa(ThoiGianBatDau,ThoiGianKetThuc,TongTienSauCa,IDNhanVien,IDChiNhanh,TongTien,GiamGia) VALUES ('{0}',getdate(),'{1}','{2}','{3}','{4}','{5}')", DateTime.Parse(GioVao).ToString("yyyy-MM-dd hh:mm:ss tt"), TongTienSauCa.ToString(), IDNhanVien, IDChiNhanh, TongTien.ToString(), GiamGia.ToString());
            return DataProvider.TruyVanKhongLayDuLieu(sTruyVan);
        }
    }
}
