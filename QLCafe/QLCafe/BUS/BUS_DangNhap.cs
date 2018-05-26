using QLCafe.DAO;
using QLCafe.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLCafe.BUS
{
    class BUS_DangNhap
    {
        public static bool KiemTraDangNhap(string TenDangNhap , string MatKhau)
        {
            return DAO_DangNhap.LayThongTin(TenDangNhap, MatKhau);
        }
        public static DataTable ThongTin(string TenDangNhap, string MatKhau)
        {
            return DAO_DangNhap.ThongTinNhanVien(TenDangNhap, MatKhau);
        }
        public static bool CapNhatMatKhau(string TenDangNhap, string MatKhau, string MatKhauMoi)
        {
            return DAO_DangNhap.DoiMatKhau(TenDangNhap, MatKhau, MatKhauMoi);
        }
    }
}
