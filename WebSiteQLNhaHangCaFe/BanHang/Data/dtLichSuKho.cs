using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace BanHang.Data
{
    public class dtLichSuKho
    {
        public static void ThemLichSu(string IDKho, string IDHangHoa, string IDNhanVien, string SoLuong, string SoLuongMoi, string NoiDung)
        {
            using (SqlConnection myConnection = new SqlConnection(StaticContext.ConnectionString))
            {
                try
                {
                    myConnection.Open();
                    string cmdText = "INSERT INTO [GPM_LichSuKho] ([IDKho],[IDHangHoa],[IDNhanVien],[SoLuong],[SoLuongMoi],[NoiDung],[NgayCapNhat]) VALUES (@IDKho,@IDHangHoa,@IDNhanVien,@SoLuong,@SoLuongMoi,@NoiDung,getDATE())";
                    using (SqlCommand myCommand = new SqlCommand(cmdText, myConnection))
                    {
                        myCommand.Parameters.AddWithValue("@IDKho", IDKho);
                        myCommand.Parameters.AddWithValue("@IDHangHoa", IDHangHoa);
                        myCommand.Parameters.AddWithValue("@IDNhanVien", IDNhanVien);
                        myCommand.Parameters.AddWithValue("@SoLuong", SoLuong);
                        myCommand.Parameters.AddWithValue("@SoLuongMoi", SoLuongMoi);
                        myCommand.Parameters.AddWithValue("@NoiDung", NoiDung);
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

        public static string LaySoLuongTonKho(string IDKho, string IDHangHoa)
        {
            using (SqlConnection con = new SqlConnection(StaticContext.ConnectionString))
            {
                con.Open();
                string cmdText = "SELECT CF_TonKho.TrongLuong FROM CF_TonKho, CF_NguyenLieu WHERE CF_TonKho.IDNguyenLieu = CF_NguyenLieu.ID AND CF_TonKho.IDChiNhanh = '" + IDKho + "' AND CF_NguyenLieu.ID = '" + IDHangHoa + "'";
                using (SqlCommand command = new SqlCommand(cmdText, con))
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    DataTable tb = new DataTable();
                    tb.Load(reader);
                    return tb.Rows[0]["TrongLuong"].ToString();
                }
            }
        }
    }
}