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
    class BUS_BAN
    {
        public static DataTable DanhSachBanTheoKhuVuc(string IDKhuVuc)
        {
            return DAO_BAN.DanhSachBan(IDKhuVuc);
        }
        public static int DanhSachThongKe(string IDKhuVuc, int TrangThai)
        {
            return DAO_BAN.ThongKeBan(IDKhuVuc, TrangThai);
        }
    }
}
