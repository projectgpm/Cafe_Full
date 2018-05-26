using QLCafe.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLCafe.DAO
{
    public class DAO_DanhSachGioChuaThanhToan
    {
        private static DAO_DanhSachGioChuaThanhToan instance;

        public static DAO_DanhSachGioChuaThanhToan Instance
        {
            get { if (instance == null) instance = new DAO_DanhSachGioChuaThanhToan(); return DAO_DanhSachGioChuaThanhToan.instance; }
           private set { DAO_DanhSachGioChuaThanhToan.instance = value; }
        }
        private DAO_DanhSachGioChuaThanhToan() { }
       
        public List<DTO_ChiTietGio> GetDanhSachGio(int IDHoaDon, int IDBan)
        {
            List<DTO_ChiTietGio> listMenu = new List<DTO_ChiTietGio>();
            string sTruyVan = string.Format(@"SELECT * FROM  [CF_ChiTietGio] WHERE [IDBan] =  {0} AND [IDHoaDon] = {1} AND [TrangThai] = 1 AND [ThanhToan] = 0", IDBan, IDHoaDon);
            DataTable data = new DataTable();
            data = DataProvider.TruyVanLayDuLieu(sTruyVan);
            foreach (DataRow item in data.Rows)
            {
                DTO_ChiTietGio table = new DTO_ChiTietGio(item);
                listMenu.Add(table);
            }
            return listMenu;
        }
    }
}
