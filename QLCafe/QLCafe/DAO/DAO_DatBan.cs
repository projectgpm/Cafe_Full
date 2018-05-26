using QLCafe.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLCafe.DAO
{
    public class DAO_DatBan
    {
        private static DAO_DatBan instance;

        public static DAO_DatBan Instance
        {
            get { if (instance == null) instance = new DAO_DatBan(); return DAO_DatBan.instance; }
            private set { DAO_DatBan.instance = value; }
        }
        public List<DTO_DatBan> LoadTableList(int IDBan)
        {
            List<DTO_DatBan> tblDanhSach = new List<DTO_DatBan>();
            string sTruyVan = string.Format(@"SELECT * FROM [CF_DatBan] WHERE IDBan = {0} ", IDBan);
            DataTable data = new DataTable();
            data = DataProvider.TruyVanLayDuLieu(sTruyVan);
            foreach (DataRow item in data.Rows)
            {
                DTO_DatBan table = new DTO_DatBan(item);
                tblDanhSach.Add(table);
            }
            return tblDanhSach;
        }
        public static bool XoaKhachDat(int IDBan, string IDChiNhanh)
        {
            string sTruyVan = string.Format(@"DELETE FROM [CF_DatBan] WHERE IDBan = {0} AND [IDChiNhanh] = '" + IDChiNhanh + "'", IDBan);
            return DataProvider.TruyVanKhongLayDuLieu(sTruyVan);
        }

    }
}
