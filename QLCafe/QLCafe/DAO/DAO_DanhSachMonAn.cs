using QLCafe.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLCafe.DAO
{
    public class DAO_DanhSachMonAn
    {
        private static DAO_DanhSachMonAn instance;

        public static DAO_DanhSachMonAn Instance
        {
            get { if (instance == null) instance = new DAO_DanhSachMonAn(); return DAO_DanhSachMonAn.instance; }
            private set { DAO_DanhSachMonAn.instance = value; }
        }

        private DAO_DanhSachMonAn() { }

        public List<DTO_DanhSachMenu> GetDanhSachMonAn(int IDHoaDon)
        {
            List<DTO_DanhSachMenu> listMenu = new List<DTO_DanhSachMenu>();
            string sTruyVan = string.Format(@"SELECT [CF_HangHoa].MaHangHoa, [CF_HangHoa].TenHangHoa,[CF_DonViTinh].TenDonViTinh,[CF_ChiTietHoaDon_Temp].TrongLuong, [CF_ChiTietHoaDon_Temp].SoLuong,[CF_ChiTietHoaDon_Temp].DonGia,[CF_ChiTietHoaDon_Temp].ThanhTien FROM [CF_ChiTietHoaDon_Temp],[CF_HangHoa],[CF_DonViTinh] WHERE [CF_HangHoa].IDDonViTinh = [CF_DonViTinh].ID AND [CF_ChiTietHoaDon_Temp].IDHangHoa = [CF_HangHoa].ID AND [CF_ChiTietHoaDon_Temp].IDHoaDon = {0}", IDHoaDon);
            DataTable data = new DataTable();
            data = DataProvider.TruyVanLayDuLieu(sTruyVan);
            foreach (DataRow item in data.Rows)
            {
                DTO_DanhSachMenu table = new DTO_DanhSachMenu(item);
                listMenu.Add(table);
            }
            return listMenu;
        }
        public List<DTO_DanhSachMenu> GetMonAnThuong(int IDHoaDon, string IDChiNhanh)
        {
            List<DTO_DanhSachMenu> listMenu = new List<DTO_DanhSachMenu>();
            string sTruyVan = string.Format(@"SELECT [CF_ChiTietHoaDon_Temp].ID,[CF_HangHoa].MaHangHoa, [CF_HangHoa].TenHangHoa,[CF_DonViTinh].TenDonViTinh,[CF_ChiTietHoaDon_Temp].TrongLuong, [CF_ChiTietHoaDon_Temp].SoLuong,[CF_ChiTietHoaDon_Temp].DonGia,[CF_ChiTietHoaDon_Temp].ThanhTien FROM [CF_ChiTietHoaDon_Temp],[CF_HangHoa],[CF_DonViTinh] WHERE [CF_HangHoa].IDDonViTinh = [CF_DonViTinh].ID AND [CF_ChiTietHoaDon_Temp].IDHangHoa = [CF_HangHoa].ID AND [CF_ChiTietHoaDon_Temp].IDHoaDon = '{0}' AND [CF_ChiTietHoaDon_Temp].TrongLuong = 0 AND [CF_ChiTietHoaDon_Temp].IDChiNhanh = '" + IDChiNhanh + "'", IDHoaDon);
            DataTable data = new DataTable();
            data = DataProvider.TruyVanLayDuLieu(sTruyVan);
            foreach (DataRow item in data.Rows)
            {
                DTO_DanhSachMenu table = new DTO_DanhSachMenu(item);
                listMenu.Add(table);
            }
            return listMenu;
        }

        public List<DTO_DanhSachMenu> GetMonAnTuChon(int IDHoaDon,string IDChiNhanh)
        {
            List<DTO_DanhSachMenu> listMenu = new List<DTO_DanhSachMenu>();
            string sTruyVan = string.Format(@"SELECT [CF_NguyenLieu].MaNguyenLieu AS MaHangHoa, [CF_NguyenLieu].TenNguyenLieu AS TenHangHoa,[CF_DonViTinh].TenDonViTinh,[CF_ChiTietHoaDon_Temp].TrongLuong,[CF_ChiTietHoaDon_Temp].ID, [CF_ChiTietHoaDon_Temp].SoLuong,[CF_ChiTietHoaDon_Temp].DonGia,[CF_ChiTietHoaDon_Temp].ThanhTien FROM [CF_ChiTietHoaDon_Temp],[CF_NguyenLieu],[CF_DonViTinh] WHERE [CF_NguyenLieu].IDDonViTinh = [CF_DonViTinh].ID AND [CF_ChiTietHoaDon_Temp].IDHangHoa = [CF_NguyenLieu].ID AND [CF_ChiTietHoaDon_Temp].IDHoaDon = '{0}' AND [CF_ChiTietHoaDon_Temp].TrongLuong > 0 AND [CF_ChiTietHoaDon_Temp].IDChiNhanh= '" + IDChiNhanh + "'", IDHoaDon);
            DataTable data = new DataTable();
            data = DataProvider.TruyVanLayDuLieu(sTruyVan);
            foreach (DataRow item in data.Rows)
            {
                DTO_DanhSachMenu table = new DTO_DanhSachMenu(item);
                listMenu.Add(table);
            }
            return listMenu;
        }
    }
}
