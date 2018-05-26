using QLCafe.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLCafe.DAO
{
    public class DAO_NguyenLieu
    {
        private static DAO_NguyenLieu instance;

        public static DAO_NguyenLieu Instance
        {
            get { if (instance == null) instance = new DAO_NguyenLieu(); return DAO_NguyenLieu.instance; }
            private set { DAO_NguyenLieu.instance = value; }
        }
      
        public DAO_NguyenLieu() { }
        public List<DTO_NguyenLieu> LoadNguyenLieu(int IDHangHoa)
        {
            List<DTO_NguyenLieu> tablelist = new List<DTO_NguyenLieu>();
            string sTruyVan = string.Format(@"SELECT * FROM [CF_HangHoa_ChiTiet] WHERE IDHangHoa = {0} ", IDHangHoa);
            DataTable data = new DataTable();
            data = DataProvider.TruyVanLayDuLieu(sTruyVan);
            foreach (DataRow item in data.Rows)
            {
                DTO_NguyenLieu table = new DTO_NguyenLieu(item);
                tablelist.Add(table);
            }
            return tablelist;
        }
    }
}
