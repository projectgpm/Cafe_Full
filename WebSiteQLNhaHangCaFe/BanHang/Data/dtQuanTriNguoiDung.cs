using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace BanHang.Data
{
    public class dtQuanTriNguoiDung
    {
        public static string Dem_Max()
        {
            using (SqlConnection con = new SqlConnection(StaticContext.ConnectionString))
            {
                con.Open();
                int STTV = 0;
                string SoVe;
                string GPM = "000000";
                string cmdText = "SELECT * FROM [CF_NguoiDung]";
                using (SqlCommand command = new SqlCommand(cmdText, con))
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    DataTable tb = new DataTable();
                    tb.Load(reader);
                    STTV = tb.Rows.Count + 1;
                    int DoDaiHT = STTV.ToString().Length;
                    string DoDaiGPM = GPM.Substring(0, 7 - DoDaiHT);
                    SoVe = DoDaiGPM + STTV;
                    return SoVe;
                }
            }
        }
        public static int KT_Tendangnhap_CapNhat(string TenDangNhap, string ID)
        {
            using (SqlConnection con = new SqlConnection(StaticContext.ConnectionString))
            {
                con.Open();
                string cmdText = "SELECT TenDangNhap FROM [CF_NguoiDung] WHERE [TenDangNhap] = '" + TenDangNhap + "' AND ID = " + ID;
                using (SqlCommand command = new SqlCommand(cmdText, con))
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    DataTable tb = new DataTable();
                    tb.Load(reader);
                    if (tb.Rows.Count != 0)
                    {
                        return 1;
                    }
                    else return -1;
                }
            }
        }
        public DataTable LayDanhSachNguoiDung(string IDChiNhanh)
        {
            using (SqlConnection con = new SqlConnection(StaticContext.ConnectionString))
            {
                con.Open();
                string cmdText = "SELECT *  FROM [CF_NguoiDung] WHERE DAXOA = 0 AND ID != 1 AND ( [IDChiNhanh] = '" + IDChiNhanh + "')";
                using (SqlCommand command = new SqlCommand(cmdText, con))
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    DataTable tb = new DataTable();
                    tb.Load(reader);
                    return tb;
                }
            }
        }
        public DataTable LayDanhSachNguoiDung_Full()
        {
            using (SqlConnection con = new SqlConnection(StaticContext.ConnectionString))
            {
                con.Open();
                string cmdText = "SELECT *  FROM [CF_NguoiDung] WHERE DAXOA = 0 AND ID != 1 ";
                using (SqlCommand command = new SqlCommand(cmdText, con))
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    DataTable tb = new DataTable();
                    tb.Load(reader);
                    return tb;
                }
            }
        }
        public DataTable LayDanhSachNguoiDung_BK(string IDChiNhanh)
        {
            using (SqlConnection con = new SqlConnection(StaticContext.ConnectionString))
            {
                con.Open();
                string cmdText = "SELECT ID,TenNguoiDung  FROM [CF_NguoiDung] WHERE DAXOA = 0 AND ID != 1 AND IDNhomNguoiDung = 2 AND [IDChiNhanh] = '" + IDChiNhanh + "'";
                using (SqlCommand command = new SqlCommand(cmdText, con))
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    DataTable tb = new DataTable();
                    tb.Load(reader);
                    return tb;
                }
            }
        }

        public static int KiemTraNguoiDung(string TenDangNhap)
        {
            using (SqlConnection con = new SqlConnection(StaticContext.ConnectionString))
            {
                con.Open();
                string cmdText = "SELECT TenDangNhap FROM [CF_NguoiDung] WHERE [TenDangNhap] = '" + TenDangNhap + "'";
                using (SqlCommand command = new SqlCommand(cmdText, con))
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    DataTable tb = new DataTable();
                    tb.Load(reader);
                    if (tb.Rows.Count != 0)
                    {
                        return 1;
                    }
                    else return -1;
                }
            }
        }


        public void ThemNguoiDung(string MaNhanVien, string TenNguoiDung, string TenDangNhap, int IDNhomNguoiDung, string SDT, string MatKhau, string Email, string IDChiNhanh)
        {
            using (SqlConnection myConnection = new SqlConnection(StaticContext.ConnectionString))
            {
                try
                {
                    myConnection.Open();
                    string cmdText = "INSERT INTO [CF_NguoiDung] ([TenNguoiDung],[TenDangNhap], [IDNhomNguoiDung], [SDT], [MatKhau], [NgayCapNhat],[Email],[MaNhanVien],[IDChiNhanh]) VALUES (@TenNguoiDung,@TenDangNhap, @IDNhomNguoiDung, @SDT, @MatKhau, getdate(),@Email,@MaNhanVien,@IDChiNhanh)";
                    using (SqlCommand myCommand = new SqlCommand(cmdText, myConnection))
                    {
                        myCommand.Parameters.AddWithValue("@IDChiNhanh", IDChiNhanh);
                        myCommand.Parameters.AddWithValue("@TenNguoiDung", TenNguoiDung);
                        myCommand.Parameters.AddWithValue("@MaNhanVien", MaNhanVien);
                        myCommand.Parameters.AddWithValue("@IDNhomNguoiDung", IDNhomNguoiDung);
                        myCommand.Parameters.AddWithValue("@TenDangNhap", TenDangNhap);
                        myCommand.Parameters.AddWithValue("@SDT", SDT);
                        myCommand.Parameters.AddWithValue("@Email", Email);
                        myCommand.Parameters.AddWithValue("@MatKhau", MatKhau);
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
        public void XoaNguoiDung(int ID)
        {
            using (SqlConnection myConnection = new SqlConnection(StaticContext.ConnectionString))
            {
                try
                {
                    myConnection.Open();
                    string strSQL = "UPDATE [CF_NguoiDung] SET [DaXoa] = 1 WHERE ID = @ID";
                    using (SqlCommand myCommand = new SqlCommand(strSQL, myConnection))
                    {
                        myCommand.Parameters.AddWithValue("@ID", ID);
                        myCommand.ExecuteNonQuery();
                    }
                }
                catch (Exception e)
                {
                    throw new Exception("Lỗi: Quá trình cập nhật dữ liệu gặp lỗi, hãy tải lại trang");
                }
            }
        }
        public void SuaNguoiDung_Admin(int ID, string TenNguoiDung, string TenDangNhap, int IDNhomNguoiDung, string SDT, string Email,string MatKhau)
        {
            using (SqlConnection myConnection = new SqlConnection(StaticContext.ConnectionString))
            {
                try
                {
                    myConnection.Open();
                    string strSQL = "UPDATE [CF_NguoiDung] SET [IDNhomNguoiDung] = @IDNhomNguoiDung,[TenDangNhap] = @TenDangNhap,[MatKhau] = @MatKhau,[TenNguoiDung] = @TenNguoiDung,[SDT] = @SDT, [NgayCapNhat] = getdate(),[Email] = @Email WHERE [ID] = @ID";
                    using (SqlCommand myCommand = new SqlCommand(strSQL, myConnection))
                    {
                        myCommand.Parameters.AddWithValue("@ID", ID);
                        myCommand.Parameters.AddWithValue("@IDNhomNguoiDung", IDNhomNguoiDung);
                        myCommand.Parameters.AddWithValue("@TenDangNhap", TenDangNhap);
                        myCommand.Parameters.AddWithValue("@TenNguoiDung", TenNguoiDung);
                        myCommand.Parameters.AddWithValue("@SDT", SDT);
                        myCommand.Parameters.AddWithValue("@Email", Email);
                        myCommand.Parameters.AddWithValue("@MatKhau", MatKhau);
                        myCommand.ExecuteNonQuery();
                    }
                }
                catch (Exception e)
                {
                    throw new Exception("Lỗi: Quá trình cập nhật dữ liệu gặp lỗi, hãy tải lại trang");
                }
            }
        }
        public void SuaNguoiDung(int ID, string TenNguoiDung, string TenDangNhap, int IDNhomNguoiDung, string SDT, string Email, string IDChiNhanh)
        {
            using (SqlConnection myConnection = new SqlConnection(StaticContext.ConnectionString))
            {
                try
                {
                    myConnection.Open();
                    string strSQL = "UPDATE [CF_NguoiDung] SET [IDChiNhanh] = @IDChiNhanh,[IDNhomNguoiDung] = @IDNhomNguoiDung,[TenDangNhap] = @TenDangNhap,[TenNguoiDung] = @TenNguoiDung,[SDT] = @SDT, [NgayCapNhat] = getdate(),[Email] = @Email WHERE [ID] = @ID";
                    using (SqlCommand myCommand = new SqlCommand(strSQL, myConnection))
                    {
                        myCommand.Parameters.AddWithValue("@ID", ID);
                        myCommand.Parameters.AddWithValue("@IDChiNhanh", IDChiNhanh);
                        myCommand.Parameters.AddWithValue("@IDNhomNguoiDung", IDNhomNguoiDung);
                        myCommand.Parameters.AddWithValue("@TenDangNhap", TenDangNhap);
                        myCommand.Parameters.AddWithValue("@TenNguoiDung", TenNguoiDung);
                        myCommand.Parameters.AddWithValue("@SDT", SDT);
                        myCommand.Parameters.AddWithValue("@Email", Email);
                       
                        myCommand.ExecuteNonQuery();
                    }
                }
                catch (Exception e)
                {
                    throw new Exception("Lỗi: Quá trình cập nhật dữ liệu gặp lỗi, hãy tải lại trang");
                }
            }
        }
    }
}