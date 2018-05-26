using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace BanHang.Data
{
    public class dtTheKho
    {
        public static void ThemLichSu(string IDNguoiDung, string IDHangHoa, string SLCu, string SLMoi)
        {
            using (SqlConnection myConnection = new SqlConnection(StaticContext.ConnectionString))
            {
                string myServer = Environment.MachineName; // tên máy tinh
                try
                {
                    myConnection.Open();
                    string cmdText = "INSERT INTO [CF_LichSuThayDoiGia] ([IDNguoiDung], [IDHangHoa], [SLCu], [SLMoi], [NgayThayDoi]) VALUES (@IDNguoiDung, @IDHangHoa, @SLCu, @SLMoi@, getDATE())";
                    using (SqlCommand myCommand = new SqlCommand(cmdText, myConnection))
                    {
                        myCommand.Parameters.AddWithValue("@IDNguoiDung", IDNguoiDung);
                        myCommand.Parameters.AddWithValue("@IDHangHoa", IDHangHoa);
                        myCommand.Parameters.AddWithValue("@SLCu", SLCu);
                        myCommand.Parameters.AddWithValue("@SLMoi", SLMoi);
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

        public DataTable LayDanhSach()
        {
            using (SqlConnection con = new SqlConnection(StaticContext.ConnectionString))
            {
                con.Open();
                string cmdText = " SELECT TOP 1000 CF_NguoiDung.TenNguoiDung,CF_HangHoa.MaHangHoa,CF_HangHoa.TenHangHoa,CF_DonViTinh.TenDonViTinh,CF_LichSuKho.SLCu,CF_LichSuKho.SLMoi,CF_LichSuKho.NgayThayDoi FROM CF_NguoiDung,CF_LichSuKho,CF_HangHoa,CF_DonViTinh WHERE CF_NguoiDung.ID = CF_LichSuKho.IDNguoiDung AND CF_LichSuKho.IDHangHoa = CF_HangHoa.ID AND CF_DonViTinh.ID = CF_HangHoa.IDDonViTinh ORDER BY CF_LichSuKho.ID DESC";
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