using QLCafe.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLCafe.DAO
{
    public class DAO_NhomHang
    {
        public static DataTable DanhSachNhomHang()
        {
            string sTruyVan = string.Format(@"SELECT * FROM [CF_NhomHangHoa] ");
            DataTable data = new DataTable();
            data = DataProvider.TruyVanLayDuLieu(sTruyVan);
            return data;
        }
        private static DAO_NhomHang instance;

        public static DAO_NhomHang Instance
        {
            get { if (instance == null) instance = new DAO_NhomHang(); return DAO_NhomHang.instance; }
            private set { DAO_NhomHang.instance = value; }
        }
        public DAO_NhomHang() { }
        public List<DTO_NhomHangHoa> DanhSanhNhomHangFull(string IDChiNhanh)
        {
            List<DTO_NhomHangHoa> tablelist = new List<DTO_NhomHangHoa>();
            string sTruyVan = string.Format(@"SELECT * FROM [CF_NhomHangHoa] WHERE IDChiNhanh = '" + IDChiNhanh + "'");
            DataTable data = new DataTable();
            data = DataProvider.TruyVanLayDuLieu(sTruyVan);
            foreach (DataRow item in data.Rows)
            {
                DTO_NhomHangHoa table = new DTO_NhomHangHoa(item);
                tablelist.Add(table);
            }
            return tablelist;
        }

    }
}
