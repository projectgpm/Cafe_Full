using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Management;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace QLCafe.DAO
{
    class DAO_Setting
    {
        public static string LayMaHangHoa_IDHH(string IDHangHoa)
        {
            string sTruyVan = string.Format(@"SELECT MaHangHoa FROM [CF_HangHoa] WHERE [ID] = {0} ", IDHangHoa);
            DataTable data = new DataTable();
            data = DataProvider.TruyVanLayDuLieu(sTruyVan);
            if (data.Rows.Count > 0)
            {
                DataRow dr = data.Rows[0];
                return dr["MaHangHoa"].ToString();
            }
            else
                return "";
        }
        /// <summary>
        /// Thông tin của hàng
        /// </summary>
        /// <returns></returns>
        public static DataTable ThongTinCuaHang(string IDChiNhanh)
        {
            string sTruyVan = string.Format(@"SELECT * FROM [CF_ChiNhanh] WHERE ID = '" + IDChiNhanh + "'");
            DataTable data = new DataTable();
            return data = DataProvider.TruyVanLayDuLieu(sTruyVan);
        }
        /// <summary>
        /// 1: cấu hình xong, 0 chưa cấu hình
        /// </summary>
        /// <returns></returns>
        public static int KiemTraCauHinhServer()
        {
            string sTruyVan = string.Format(@"SELECT CauHinhServer FROM [Setting] Where ID = 1");
            DataTable data = new DataTable();
            data = DataProvider.TruyVanLayDuLieu(sTruyVan);
            if (data.Rows.Count > 0)
            {
                DataRow dr = data.Rows[0];
                return Int32.Parse(dr["CauHinhServer"].ToString());
            }
            else
                return 0;
        }
        /// <summary>
        /// lấy giao diện nào để hiển thị
        /// </summary>
        /// <returns></returns>
        public static int KiemtraGiaDien(string IDChiNhanh)
        {
            string sTruyVan = string.Format(@"SELECT GiaoDienApDung FROM [CF_ChiNhanh] Where ID = '" + IDChiNhanh + "'");
            DataTable data = new DataTable();
            data = DataProvider.TruyVanLayDuLieu(sTruyVan);
            if (data.Rows.Count > 0)
            {
                DataRow dr = data.Rows[0];
                return Int32.Parse(dr["GiaoDienApDung"].ToString());
            }
            else
                return 0;
        }
        /// <summary>
        ///  hàm kiểm tra key
        /// </summary>
        /// <param name="Key"></param>
        /// <param name="user"></param>
        /// <returns></returns>
        public static int setKeyCode(string Key, string user)
        {
            string sx = GetHardDiskSerialNo();

            string strAddress = sx + "GPM";

            if (KiemTraTenKey(Key) != "")
            {
                string sha1Address = GetSHA1HashData(strAddress);
                string sTruyVan = string.Format(@"INSERT INTO  [CF_KeyCode] (GetKey,NgayKichHoat) VALUES('{0}',getdate())", sha1Address);
                DataProvider.TruyVanKhongLayDuLieu(sTruyVan);
                string sTruyVan1 = string.Format(@"Update CF_KeyKichHoat set [SoLanKichHoat] = [SoLanKichHoat] - 1 where TenKey = N'{0}'", Key);
                DataProvider.TruyVanKhongLayDuLieu(sTruyVan1);

                return 1;
            }
            return -1;

        }

        /// <summary>
        /// hàm lấy key
        /// </summary>
        /// <param name="CD"></param>
        /// <returns></returns>
        public static string KiemTraTenKey(string TenKey)
        {
            string sTruyVan = string.Format(@"SELECT TenKey FROM [CF_KeyKichHoat] Where TenKey = N'{0}' AND [SoLanKichHoat] > 0", TenKey);
            DataTable data = new DataTable();
            data = DataProvider.TruyVanLayDuLieu(sTruyVan);
            if (data.Rows.Count > 0)
            {
                DataRow dr = data.Rows[0];
                return dr["TenKey"].ToString();
            }
            else
                return "";
        }

        /// <summary>
        /// lấy số lần còn lại để kích hoạt
        /// </summary>
        /// <param name="CD"></param>
        /// <returns></returns>
        /// 
        public static int KiemTraSoLanKichHoat(string TenKey)
        {
            string sTruyVan = string.Format(@"SELECT SoLanKichHoat FROM [CF_KeyKichHoat] Where TenKey = N'{0}'", TenKey);
            DataTable data = new DataTable();
            data = DataProvider.TruyVanLayDuLieu(sTruyVan);
            if (data.Rows.Count > 0)
            {
                DataRow dr = data.Rows[0];
                return Int32.Parse(dr["SoLanKichHoat"].ToString());
            }
            else
                return 0;
        }


        public static int getData_Setting(string CD)
        {
            string sTruyVan = string.Format(@"SELECT GetKey FROM [CF_KeyCode] WHERE GetKey  = '" + CD + "'");
            DataTable data = new DataTable();
            data = DataProvider.TruyVanLayDuLieu(sTruyVan);
            if (data.Rows.Count > 0)
            {
                return 1;
            }
            else
                return 0;
        }
        public static string GetHardDiskSerialNo()
        {
            return System.Environment.MachineName;
            //string drive = "C";
            //ManagementObject disk = new ManagementObject("win32_logicaldisk.deviceid=\"" + drive + ":\"");
            //disk.Get();
            //return disk["VolumeSerialNumber"].ToString();
        }
        public static int getKeyCode()
        {
            string sx = GetHardDiskSerialNo();
            string strAddress = sx + "GPM";

            string sha1Address = GetSHA1HashData(strAddress);
            if (getData_Setting(sha1Address) == 1)
                return 1;
            return -1;
        }
        public static bool IsNumber(string pValue)
        {
            foreach (Char c in pValue)
            {
                if (!Char.IsDigit(c))
                    return false;
            }
            return true;
        }
        public static string GetSHA1HashData(string data)
        {
            SHA1 sha1 = SHA1.Create();
            byte[] hashData = sha1.ComputeHash(System.Text.Encoding.UTF8.GetBytes(data + 123));
            System.Text.StringBuilder returnValue = new System.Text.StringBuilder();
            for (int i = 0; i < hashData.Length; i++)
            {
                returnValue.Append(hashData[i].ToString("x"));
            }
            return returnValue.ToString();
        }
        public static string convertDauSangKhongDau(string s)
        {
            Regex regex = new Regex("\\p{IsCombiningDiacriticalMarks}+");
            string temp = s.Normalize(NormalizationForm.FormD);
            return regex.Replace(temp, String.Empty).Replace('\u0111', 'd').Replace('\u0110', 'D').ToUpper();
        }

        public static int LayIDHangHoa(string MaHangHoa)
        {
            string sTruyVan = string.Format(@"SELECT ID FROM [CF_HangHoa] WHERE [MaHangHoa] = {0} ", MaHangHoa);
            DataTable data = new DataTable();
            data = DataProvider.TruyVanLayDuLieu(sTruyVan);
            if (data.Rows.Count > 0)
            {
                DataRow dr = data.Rows[0];
                return Int32.Parse(dr["ID"].ToString());
            }
            else
                return 0;
        }
        public static int LayIDHangHoaTuChon(string MaNguyenLieu)
        {
            string sTruyVan = string.Format(@"SELECT ID FROM [CF_NguyenLieu] WHERE [MaNguyenLieu] = {0} ", MaNguyenLieu);
            DataTable data = new DataTable();
            data = DataProvider.TruyVanLayDuLieu(sTruyVan);
            if (data.Rows.Count > 0)
            {
                DataRow dr = data.Rows[0];
                return Int32.Parse(dr["ID"].ToString());
            }
            else
                return 0;
        }
        public static int TrangThaiTinhGio()
        {
            string sTruyVan = string.Format(@"SELECT TinhGio FROM [Setting]");
            DataTable data = new DataTable();
            data = DataProvider.TruyVanLayDuLieu(sTruyVan);
            if (data.Rows.Count > 0)
            {
                DataRow dr = data.Rows[0];
                return Int32.Parse(dr["TinhGio"].ToString());
            }
            else
                return 0;
        }
        public static float LayGiaBanTheoKhuVuc(int IDBan)
        {
            string sTruyVan = string.Format(@"SELECT [CF_KhuVuc].GiaKhuVuc FROM [CF_Ban],[CF_KhuVuc] WHERE [CF_KhuVuc].ID =  [CF_Ban].IDKhuVuc AND [CF_Ban].ID = {0} ", IDBan);
            DataTable data = new DataTable();
            data = DataProvider.TruyVanLayDuLieu(sTruyVan);
            if (data.Rows.Count > 0)
            {
                DataRow dr = data.Rows[0];
                return float.Parse(dr["GiaKhuVuc"].ToString());
            }
            else
                return 0;
        }
        public static bool TruTonKho(int IDNguyenLieu, string IDChiNhanh, double TrongLuong)
        {
            string sTruyVan = string.Format(@"UPDATE [CF_TonKho] SET  [TrongLuong] = [TrongLuong] - {0} WHERE IDNguyenLieu = {1} AND [IDChiNhanh] = {2}", TrongLuong, IDNguyenLieu, IDChiNhanh);
            return DataProvider.TruyVanKhongLayDuLieu(sTruyVan);
        }

        public static int LayIDDonViTinh(string MaHangHoa)
        {
            string sTruyVan = string.Format(@"SELECT IDDonViTinh FROM [CF_HangHoa] WHERE [MaHangHoa] = {0} ", MaHangHoa);
            DataTable data = new DataTable();
            data = DataProvider.TruyVanLayDuLieu(sTruyVan);
            if (data.Rows.Count > 0)
            {
                DataRow dr = data.Rows[0];
                return Int32.Parse(dr["IDDonViTinh"].ToString());
            }
            else
                return 0;
        }
        public static int LayIDDonViTinhTuChon(string MaNguyenLieu)
        {
            string sTruyVan = string.Format(@"SELECT IDDonViTinh FROM [CF_NguyenLieu] WHERE [MaNguyenLieu] = {0} ", MaNguyenLieu);
            DataTable data = new DataTable();
            data = DataProvider.TruyVanLayDuLieu(sTruyVan);
            if (data.Rows.Count > 0)
            {
                DataRow dr = data.Rows[0];
                return Int32.Parse(dr["IDDonViTinh"].ToString());
            }
            else
                return 0;
        }
        public static string TenCongTy()
        {
            string sTruyVan = string.Format(@"SELECT CongTy FROM [Setting] ");
            DataTable data = new DataTable();
            data = DataProvider.TruyVanLayDuLieu(sTruyVan);
            if (data.Rows.Count > 0)
            {
                DataRow dr = data.Rows[0];
                return dr["CongTy"].ToString();
            }
            else
                return "";
        }
        public static string DiaChiCongTy()
        {
            string sTruyVan = string.Format(@"SELECT DiaChi FROM [Setting] ");
            DataTable data = new DataTable();
            data = DataProvider.TruyVanLayDuLieu(sTruyVan);
            if (data.Rows.Count > 0)
            {
                DataRow dr = data.Rows[0];
                return dr["DiaChi"].ToString();
            }
            else
                return "";
        }
        public static string TestDuKieu()
        {
            string sTruyVan = string.Format(@"SELECT TestDuLieu FROM [Setting] ");
            DataTable data = new DataTable();
            data = DataProvider.TruyVanLayDuLieu(sTruyVan);
            if (data.Rows.Count > 0)
            {
                DataRow dr = data.Rows[0];
                return dr["TestDuLieu"].ToString();
            }
            else
                return "";
        }
        public static string LayTenMayInBill(string IDChiNhanh)
        {
            string sTruyVan = string.Format(@"SELECT MayIn FROM [CF_ChiNhanh] WHERE [ID] = '" + IDChiNhanh + "'");
            DataTable data = new DataTable();
            data = DataProvider.TruyVanLayDuLieu(sTruyVan);
            if (data.Rows.Count > 0)
            {
                DataRow dr = data.Rows[0];
                return dr["MayIn"].ToString();
            }
            else
                return "";
        }

        public static bool CapNhatMayInBill(string TenMayIn, string KhoGiay, string CongTy, string DiaChi, string SDT, string GiaoDienApDung,string IDChiNhanh)
        {
            string sTruyVan = string.Format(@"UPDATE [CF_ChiNhanh] SET [MayIn] = '{0}',[ReportBill] = '{1}',[TenChiNhanh] = N'{2}',[DiaChi] = N'{3}',[DienThoai] = '{4}',[GiaoDienApDung] = '{5}' WHERE ID = '" + IDChiNhanh + "'", TenMayIn, KhoGiay, CongTy, DiaChi, SDT, GiaoDienApDung);
            return DataProvider.TruyVanKhongLayDuLieu(sTruyVan);
        }

        public static bool CapNhatBillInTemp(string ID)
        {
            string sTruyVan = string.Format(@"UPDATE [CF_HoaDon] SET [LanIn] = [LanIn] + 1 WHERE ID = {0}",ID);
            return DataProvider.TruyVanKhongLayDuLieu(sTruyVan);
        }

        public static string DienThoaiCongTy()
        {
            string sTruyVan = string.Format(@"SELECT SDT FROM [Setting] ");
            DataTable data = new DataTable();
            data = DataProvider.TruyVanLayDuLieu(sTruyVan);
            if (data.Rows.Count > 0)
            {
                DataRow dr = data.Rows[0];
                return dr["SDT"].ToString();
            }
            else
                return "";
        }
        public static int ReportBill(string IDChiNhanh)
        {
            string sTruyVan = string.Format(@"SELECT ReportBill FROM [CF_ChiNhanh]  WHERE [ID] = '" + IDChiNhanh + "'");
            DataTable data = new DataTable();
            data = DataProvider.TruyVanLayDuLieu(sTruyVan);
            if (data.Rows.Count > 0)
            {
                DataRow dr = data.Rows[0];
                return Int32.Parse(dr["ReportBill"].ToString());
            }
            else
                return 58;
        }

        public static int KTHoaDon(string IDHoaDon)
        {
            int r1 = 0, r2 = 0;
            
            string sTruyVan1 = string.Format(@"SELECT * FROM [CF_ChiTietHoaDon] WHERE IDHoaDon = '" + IDHoaDon + "'");
            string sTruyVan2 = string.Format(@"SELECT * FROM [CF_ChiTietGio] WHERE IDHoaDon = '" + IDHoaDon + "'");
            DataTable data1 = new DataTable();
            data1 = DataProvider.TruyVanLayDuLieu(sTruyVan1);
            if (data1.Rows.Count > 0)
            {
                r1 = 1;
            }

            DataTable data2 = new DataTable();
            data2 = DataProvider.TruyVanLayDuLieu(sTruyVan2);
            if (data2.Rows.Count > 0)
            {
                r2 = 1;
            }

            if (r1 == 1 && r2 == 1)
                return 0;
            else if (r1 == 1) return 1;
            else return 2;
        }

        public static int KTHoaDon_Temp(string IDHoaDon)
        {
            int r1 = 0, r2 = 0;

            string sTruyVan1 = string.Format(@"SELECT * FROM [CF_ChiTietHoaDon_Temp] WHERE IDHoaDon = '" + IDHoaDon + "'");
            string sTruyVan2 = string.Format(@"SELECT * FROM [CF_ChiTietGio] WHERE IDHoaDon = '" + IDHoaDon + "'");
            DataTable data1 = new DataTable();
            data1 = DataProvider.TruyVanLayDuLieu(sTruyVan1);
            if (data1.Rows.Count > 0)
            {
                r1 = 1;
            }

            DataTable data2 = new DataTable();
            data2 = DataProvider.TruyVanLayDuLieu(sTruyVan2);
            if (data2.Rows.Count > 0)
            {
                r2 = 1;
            }

            if (r1 == 1 && r2 == 1)
                return 0;
            else if (r1 == 1) return 1;
            else return 2;
        }

        public static bool ThemLichSuTruyCap(int IDNhanVien, int IDNhom, string IDChiNhanh, string Menu, string HanhDong)
        {
            string sTruyVan = string.Format(@"INSERT INTO [CF_LichSuTruyCap](IDChiNhanh,IDNhom,IDNguoiDung,Menu,HanhDong,ThoiGian) VALUES ('{0}','{1}','{2}',N'{3}',N'{4}',getdate())", IDChiNhanh, IDNhom, IDNhanVien, Menu, HanhDong);
            return DataProvider.TruyVanKhongLayDuLieu(sTruyVan);
        }
        //public static float LayDiemQuyDoiTien()
        //{
        //    string sTruyVan = string.Format(@"SELECT SoTienQuyDoi FROM [GPM_Setting] ");
        //    DataTable data = new DataTable();
        //    data = DataProvider.TruyVanLayDuLieu(sTruyVan);
        //    if (data.Rows.Count > 0)
        //    {
        //        DataRow dr = data.Rows[0];
        //        return float.Parse(dr["SoTienQuyDoi"].ToString());
        //    }
        //    else
        //    {
        //        return 0;
        //    }
        //}

        //public static float LayTienQuyDoiDiem()
        //{
        //    string sTruyVan = string.Format(@"SELECT SoTienTichLuy FROM [GPM_Setting] ");
        //    DataTable data = new DataTable();
        //    data = DataProvider.TruyVanLayDuLieu(sTruyVan);
        //    if (data.Rows.Count > 0)
        //    {
        //        DataRow dr = data.Rows[0];
        //        return float.Parse(dr["SoTienTichLuy"].ToString());
        //    }
        //    return 0;
        //}

        //public static float DiemTichLuy(string IDKhachHang)
        //{
        //    string sTruyVan = string.Format(@"SELECT DiemTichLuy FROM [GPM_KhachHang] WHERE [ID] = {0}", IDKhachHang);
        //    DataTable data = new DataTable();
        //    data = DataProvider.TruyVanLayDuLieu(sTruyVan);
        //    if (data.Rows.Count > 0)
        //    {
        //        DataRow dr = data.Rows[0];
        //        return float.Parse(dr["DiemTichLuy"].ToString());
        //    }
        //    else
        //    {
        //        return 0;
        //    }
        //}
    }
}
