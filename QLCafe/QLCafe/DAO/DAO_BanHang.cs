using DevExpress.XtraTab;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QLCafe.DAO
{
   public  class DAO_BanHang
    {

       public static int KiemTraLayIDGioBatDau(int IDHoaDon, int IDBan)
       {
           string sTruyVan = string.Format(@"SELECT ID FROM [CF_ChiTietGio] WHERE [IDHoaDon] = {0} AND [IDBan] = {1} AND [TrangThai] = 0 AND [ThanhToan] = 0", IDHoaDon, IDBan);
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
       public static bool CapNhatChiTietGio(int IDHoaDon, DateTime GioBatDau, int IDBan, int IDGio)
       {
           string sTruyVan = string.Format(@"UPDATE [CF_ChiTietGio] SET [GioBatDau] = '{0}' WHERE [IDHoaDon] = {1}  AND [ID] = {2} AND [IDBan] = {3}", GioBatDau.ToString("yyyy-MM-dd H:mm:ss tt") ,IDHoaDon,IDGio, IDBan);
           return DataProvider.TruyVanKhongLayDuLieu(sTruyVan);
       }
       public static bool ThemChiTietGio(object IDHoaDon, DateTime GioBatDau, float DonGia, int IDBan)
       {
           string sTruyVan = string.Format(@"INSERT INTO CF_ChiTietGio(IDHoaDon,GioBatDau,DonGia,IDBan) VALUES ('{0}','{1}','{2}','{3}')", IDHoaDon, GioBatDau.ToString("yyyy-MM-dd H:mm:ss tt"), DonGia, IDBan);
           return DataProvider.TruyVanKhongLayDuLieu(sTruyVan);
       }
       public static bool CapNhatChiTietGio(int IDHoaDon, int IDBan, DateTime GioKetThuc, string TongGioChoi, double ThanhTien, int IDGio)
       {
           string sTruyVan = string.Format(@"UPDATE CF_ChiTietGio SET [GioKetThuc] = '{0}' , [TongGioChoi] = N'{1}',[ThanhTien] = '{2}', [TrangThai] = 1 WHERE [IDHoaDon] ='{3}' AND [IDBan] = '{4}' AND [ID] = {5}", GioKetThuc.ToString("yyyy-MM-dd H:mm:ss tt"), TongGioChoi, ThanhTien, IDHoaDon, IDBan, IDGio);
           return DataProvider.TruyVanKhongLayDuLieu(sTruyVan);
       }
       public static bool CapNhatTienGio(int IDHoaDon, double TienGio, int IDBan)
       {
           string sTruyVan = string.Format(@"UPDATE CF_HoaDon SET [TienGio] = [TienGio] + '{0}' WHERE [ID] ='{1}' AND [IDBan] = '{2}'", TienGio, IDHoaDon, IDBan);
           return DataProvider.TruyVanKhongLayDuLieu(sTruyVan);
       }
       public static void AddTabControll(XtraTabControl xtratabparent, string name, string ID, FlowLayoutPanel layout)
       {
           XtraTabPage xtratab = new XtraTabPage();
           xtratab.Name = ID;
           xtratab.Text = name;
           //xtratab.Tooltip = ten;
           xtratab.Controls.Add(layout);
           xtratabparent.TabPages.Add(xtratab);
           
       }
       public static DateTime GioVao_IDBan(int IDBan)
       {
           string sTruyVan = string.Format(@"SELECT GioVao FROM [CF_HoaDon] WHERE IDBan = {0} AND [TrangThai] = 0", IDBan);
           DataTable data = new DataTable();
           data = DataProvider.TruyVanLayDuLieu(sTruyVan);
           if (data.Rows.Count > 0)
           {
               DataRow dr = data.Rows[0];
               return DateTime.Parse(dr["GioVao"].ToString());
           }
           return DateTime.Parse(DateTime.Now.ToString("yyyy-MM-dd H:mm:ss"));
       }

       public static int IDHoaDon(int IDBan)
       {
           string sTruyVan = string.Format(@"SELECT ID FROM [CF_HoaDon] WHERE IDBan = {0} AND [TrangThai] = 0", IDBan);
           DataTable data = new DataTable();
           data = DataProvider.TruyVanLayDuLieu(sTruyVan);
           if (data.Rows.Count > 0)
           {
               DataRow dr = data.Rows[0];
               return Int32.Parse(dr["ID"].ToString());
           }
           return 0;
       }

       public static bool XoaMonAn(string ID)
       {
           string sTruyVan = string.Format(@"DELETE FROM [CF_ChiTietHoaDon_Temp] WHERE ID = '{0}'", ID);
           return DataProvider.TruyVanKhongLayDuLieu(sTruyVan);
       }
       public static DateTime GioBatDauBiDa(int IDBan, int IDHoaDon)
       {
           string sTruyVan = string.Format(@"SELECT GioBatDau FROM [CF_ChiTietGio] WHERE IDBan = {0} AND [TrangThai] = 0 AND [IDHoaDon] = {1}", IDBan, IDHoaDon);
           DataTable data = new DataTable();
           data = DataProvider.TruyVanLayDuLieu(sTruyVan);
           if (data.Rows.Count > 0)
           {
               DataRow dr = data.Rows[0];
               return DateTime.Parse(dr["GioBatDau"].ToString());
           }
           return DateTime.Parse(DateTime.Now.ToString("yyyy-MM-dd H:mm"));
       }
    }
}
