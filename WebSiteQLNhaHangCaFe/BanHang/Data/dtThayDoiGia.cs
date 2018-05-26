using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace BanHang.Data
{
    public class dtThayDoiGia
    {
        public static void ThemLichSu(string IDNguoiDung, string MaHang, string TenHang, string DVT, string GiaCu, string GiaMoi, string IDChiNhanh)
        {
            using (SqlConnection myConnection = new SqlConnection(StaticContext.ConnectionString))
            {
                string myServer = Environment.MachineName; // tên máy tinh
                try
                {
                    myConnection.Open();
                    string cmdText = "INSERT INTO [CF_LichSuThayDoiGia] ([IDNguoiDung], [MaHang], [TenHang], [IDDVT], [GiaCu], [GiaMoi], [NgayThayDoi],[IDChiNhanh]) VALUES (@IDNguoiDung, @MaHang, @TenHang, @DVT, @GiaCu, @GiaMoi, getDATE(),@IDChiNhanh)";
                    using (SqlCommand myCommand = new SqlCommand(cmdText, myConnection))
                    {
                        myCommand.Parameters.AddWithValue("@IDNguoiDung", IDNguoiDung);
                        myCommand.Parameters.AddWithValue("@IDChiNhanh", IDChiNhanh);
                        myCommand.Parameters.AddWithValue("@MaHang", MaHang);
                        myCommand.Parameters.AddWithValue("@TenHang", TenHang);
                        myCommand.Parameters.AddWithValue("@DVT", DVT);
                        myCommand.Parameters.AddWithValue("@GiaCu", GiaCu);
                        myCommand.Parameters.AddWithValue("@GiaMoi", GiaMoi);
                        myCommand.ExecuteNonQuery();
                    }
                    myConnection.Close();
                }
                catch
                {
                    throw new Exception("Lỗi: Quá trình thêm dữ liệu gặp lỗi");
                }
            }
        }

        public DataTable LayDanhSach(string IDChiNhanh)
        {
            using (SqlConnection con = new SqlConnection(StaticContext.ConnectionString))
            {
                con.Open();
                string cmdText = " SELECT TOP 1000 CF_NguoiDung.TenNguoiDung,CF_LichSuThayDoiGia.MaHang, CF_LichSuThayDoiGia.TenHang, CF_DonViTinh.TenDonViTinh,CF_LichSuThayDoiGia.GiaCu,CF_LichSuThayDoiGia.GiaMoi,CF_LichSuThayDoiGia.NgayThayDoi FROM CF_NguoiDung,CF_LichSuThayDoiGia,CF_DonViTinh WHERE CF_NguoiDung.ID = CF_LichSuThayDoiGia.IDNguoiDung AND CF_DonViTinh.ID = CF_LichSuThayDoiGia.IDDVT AND [CF_LichSuThayDoiGia].[IDChiNhanh] = '" + IDChiNhanh + "' ORDER BY CF_LichSuThayDoiGia.ID DESC";
                using (SqlCommand command = new SqlCommand(cmdText, con))
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    DataTable tb = new DataTable();
                    tb.Load(reader);
                    return tb;
                }
            }
        }
    }
}