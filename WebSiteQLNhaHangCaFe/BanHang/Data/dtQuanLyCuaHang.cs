using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace BanHang.Data
{
    public class dtQuanLyCuaHang
    {
        public static int SoKhachHienTai()
        {
            using (SqlConnection con = new SqlConnection(StaticContext.ConnectionString))
            {
                con.Open();
                string cmdText = "SELECT SUM(CF_ChiTietHoaDon_Temp.SoLuong) as Tong FROM CF_HoaDon, CF_ChiTietHoaDon_Temp WHERE CF_HoaDon.ID = CF_ChiTietHoaDon_Temp.IDHoaDon";
                using (SqlCommand command = new SqlCommand(cmdText, con))
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    DataTable tb = new DataTable();
                    tb.Load(reader);
                    if (tb.Rows.Count != 0)
                        try
                        {
                            return Int32.Parse(tb.Rows[0]["Tong"].ToString());
                        }catch(Exception){return 0;}
                    return 0;
                }
            }
        }

        public static int SoLuongBan(string IDChiNhanh)
        {
            using (SqlConnection con = new SqlConnection(StaticContext.ConnectionString))
            {
                con.Open();
                string cmdText = "SELECT COUNT(ID) as Tong FROM CF_Ban WHERE TrangThai > 0 AND [IDChiNhanh] = '" + IDChiNhanh + "'";
                using (SqlCommand command = new SqlCommand(cmdText, con))
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    DataTable tb = new DataTable();
                    tb.Load(reader);
                    if (tb.Rows.Count != 0)
                        try
                        {
                            return Int32.Parse(tb.Rows[0]["Tong"].ToString());
                        }
                        catch (Exception) { return 0; }
                    return 0;
                }
            }
        }

        public static DataTable TongTienHienTai(string GioBD, string GioKT, string IDChiNhanh)
        {
            using (SqlConnection con = new SqlConnection(StaticContext.ConnectionString))
            {
                con.Open();
                string cmdText = "SELECT SUM(TongTien) as TongTien, SUM(TienGiamGia) as GiamGia FROM CF_HoaDon WHERE GioVao >= '" + GioBD + "' AND GioVao <= '" + GioKT + "' AND TrangThai =1 AND [IDChiNhanh] = '" + IDChiNhanh + "'";
                using (SqlCommand command = new SqlCommand(cmdText, con))
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    DataTable tb = new DataTable();
                    tb.Load(reader);
                    return tb;
                }
            }
        }

        public static float TongTienVonHienTai(string GioBD, string GioKT)
        {
            using (SqlConnection con = new SqlConnection(StaticContext.ConnectionString))
            {
                con.Open();
                string cmdText = "SELECT SUM(CF_NguyenLieu.GiaMua * CF_ChiTietHoaDon.SoLuong * CF_ChiTietHoaDon.trongLuong) as TongGiaMua FROM CF_NguyenLieu, CF_ChiTietHoaDon, CF_HoaDon WHERE CF_NguyenLieu.ID = CF_ChiTietHoaDon.IDHangHoa AND CF_HoaDon.ID = CF_ChiTietHoaDon.IDHoaDon AND CF_HoaDon.GioVao >= '" + GioBD + "' AND CF_HoaDon.GioVao <= '" + GioKT + "' AND CF_HoaDon.GioRa is not null AND CF_ChiTietHoaDon.TrongLuong > 0";
                using (SqlCommand command = new SqlCommand(cmdText, con))
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    DataTable tb = new DataTable();
                    tb.Load(reader);
                    if (tb.Rows.Count != 0)
                        return float.Parse(tb.Rows[0]["TongGiaMua"].ToString());
                    return 0;
                }
            }
        }
    }
}