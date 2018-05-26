using QLCafe.DAO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLCafe.BUS
{
    class BUS_KhuVuc
    {
        public static DataTable DanhSachBanTheoKhuVuc(string IDChiNhanh)
        {
            return DAO_KhuVuc.DanhSachKhuVuc(IDChiNhanh);
        }
    }
}
