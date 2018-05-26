using QLCafe.DAO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLCafe.BUS
{
    class BUS_HangHoa
    {
        public static DataTable DSHangHoa(string IDNhom)
        {
            return DAO_HangHoa.DanhSachHangHoa(IDNhom);
        }
        public static DataTable DSHangHoa_Full(string IDChiNhanh)
        {
            return DAO_HangHoa.DanhSachHangHoa_Full(IDChiNhanh);
        }
        public static DataTable DSHangHoaTimKiem(string TenHangHoa, string IDChiNhanh)
        {
            return DAO_HangHoa.DanhSachHangHoaTimKiem(TenHangHoa, IDChiNhanh);
        }
    }
}
