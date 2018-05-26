using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace BanHang.Data
{
    public class dtLichSuTruyCap
    {
        public DataTable LayDanhSach(string IDChiNhanh)
        {
            using (SqlConnection con = new SqlConnection(StaticContext.ConnectionString))
            {
                con.Open();
                string cmdText = "SELECT TOP 1000 * FROM [CF_LichSuTruyCap] WHERE [IDChiNhanh] = '" + IDChiNhanh + "' ORDER BY [ID] DESC ";
                using (SqlCommand command = new SqlCommand(cmdText, con))
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    DataTable tb = new DataTable();
                    tb.Load(reader);
                    return tb;
                }
            }
        }
        public static void ThemLichSu(string IDChiNhanh, string IDNhom, string IDNguoiDung, string Menu, string HanhDong)
        {
            using (SqlConnection myConnection = new SqlConnection(StaticContext.ConnectionString))
            {
                string myServer = Environment.MachineName; // tên máy tinh
                try
                {
                    myConnection.Open();
                    string cmdText = "INSERT INTO [CF_LichSuTruyCap] ([IDChiNhanh], [IDNhom], [IDNguoiDung], [Menu],[HanhDong],[ThoiGian]) VALUES (@IDChiNhanh, @IDNhom, @IDNguoiDung, @Menu,@HanhDong, getdate())";
                    using (SqlCommand myCommand = new SqlCommand(cmdText, myConnection))
                    {
                        myCommand.Parameters.AddWithValue("@IDChiNhanh", IDChiNhanh);
                        myCommand.Parameters.AddWithValue("@IDNhom", IDNhom);
                        myCommand.Parameters.AddWithValue("@IDNguoiDung", IDNguoiDung);
                        myCommand.Parameters.AddWithValue("@Menu", Menu);
                        myCommand.Parameters.AddWithValue("@HanhDong", HanhDong);
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
    }
}