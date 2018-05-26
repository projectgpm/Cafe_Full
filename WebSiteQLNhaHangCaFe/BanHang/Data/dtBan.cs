using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace BanHang.Data
{
    public class dtBan
    {
        public static bool KiemTra(string TenBan, string IDKhuVuc)
        {
            using (SqlConnection con = new SqlConnection(StaticContext.ConnectionString))
            {
                con.Open();
                string cmdText = "SELECT TenBan FROM [CF_Ban] WHERE [TenBan] = N'" + TenBan + "' AND IDKhuVuc = '" + IDKhuVuc + "'";
                using (SqlCommand command = new SqlCommand(cmdText, con))
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    DataTable tb = new DataTable();
                    tb.Load(reader);
                    if (tb.Rows.Count == 0)
                    {
                        return true;
                    }
                    else return false;
                }
            }
        }
        public static bool KiemTraSoBan(string IDChiNhanh)
        {
            using (SqlConnection con = new SqlConnection(StaticContext.ConnectionString))
            {
                con.Open();
                string cmdText = "SELECT TenBan FROM [CF_Ban] WHERE [DaXoa] = 0 AND [IDChiNhanh] = '" + IDChiNhanh + "'";
                using (SqlCommand command = new SqlCommand(cmdText, con))
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    DataTable tb = new DataTable();
                    tb.Load(reader);
                    if (tb.Rows.Count > 99)
                    {
                        return true;
                    }
                    else return false;
                }
            }
        }
        public static string LayKyHieu(string IDKhuVuc)
        {
            using (SqlConnection con = new SqlConnection(StaticContext.ConnectionString))
            {
                con.Open();
                string cmdText = "SELECT KyHieu FROM [CF_KhuVuc] WHERE [ID] = '" + IDKhuVuc + "'";
                using (SqlCommand command = new SqlCommand(cmdText, con))
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    DataTable tb = new DataTable();
                    tb.Load(reader);
                    if (tb.Rows.Count != 0)
                    {
                        DataRow dr = tb.Rows[0];
                        return dr["KyHieu"].ToString().Trim();
                    }
                    return null;
                }
            }
        }
        public static string LayIDChiNhanh(string IDKhuVuc)
        {
            using (SqlConnection con = new SqlConnection(StaticContext.ConnectionString))
            {
                con.Open();
                string cmdText = "SELECT IDChiNhanh FROM [CF_KhuVuc] WHERE [ID] = '" + IDKhuVuc + "'";
                using (SqlCommand command = new SqlCommand(cmdText, con))
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    DataTable tb = new DataTable();
                    tb.Load(reader);
                    if (tb.Rows.Count != 0)
                    {
                        DataRow dr = tb.Rows[0];
                        return dr["IDChiNhanh"].ToString().Trim();
                    }
                    return "1";
                }
            }
        }
        public static int TrangThai(string IDBan)
        {
            using (SqlConnection con = new SqlConnection(StaticContext.ConnectionString))
            {
                con.Open();
                string cmdText = "SELECT TrangThai FROM [CF_Ban] WHERE [ID] = " + IDBan;
                using (SqlCommand command = new SqlCommand(cmdText, con))
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    DataTable tb = new DataTable();
                    tb.Load(reader);
                    if (tb.Rows.Count != 0)
                    {
                        DataRow dr = tb.Rows[0];
                        return Int32.Parse(dr["TrangThai"].ToString().Trim());
                    }
                    return 0;
                }
            }
        }
        public void Sua(string ID, string TenBan, string IDKhuVuc)
        {
            using (SqlConnection myConnection = new SqlConnection(StaticContext.ConnectionString))
            {
                try
                {
                    myConnection.Open();
                    string strSQL = "UPDATE [CF_Ban] SET [TenBan] = @TenBan,[IDKhuVuc] = @IDKhuVuc, [NgayCapNhat] = getdate() WHERE [ID] = @ID";
                    using (SqlCommand myCommand = new SqlCommand(strSQL, myConnection))
                    {
                        myCommand.Parameters.AddWithValue("@ID", ID);
                        myCommand.Parameters.AddWithValue("@TenBan", TenBan);
                        myCommand.Parameters.AddWithValue("@IDKhuVuc", IDKhuVuc);
                    
                        myCommand.ExecuteNonQuery();
                    }
                }
                catch (Exception e)
                {
                    throw new Exception("Lỗi: Quá trình cập nhật dữ liệu gặp lỗi, hãy tải lại trang");
                }
            }
        }
        public void Xoa(string ID)
        {
            using (SqlConnection myConnection = new SqlConnection(StaticContext.ConnectionString))
            {
                try
                {
                    myConnection.Open();
                    //string strSQL = "DELETE FROM [CF_Ban] WHERE [ID] = @ID AND [TRANGTHAI] = 0";
                    string strSQL = "UPDATE [CF_Ban] SET DaXoa = 1 WHERE [ID] = @ID AND [TRANGTHAI] = 0";
                    using (SqlCommand myCommand = new SqlCommand(strSQL, myConnection))
                    {
                        myCommand.Parameters.AddWithValue("@ID", ID);
                        myCommand.ExecuteNonQuery();
                    }
                }
                catch (Exception e)
                {
                    throw new Exception("Lỗi: Quá trình Xóa dữ liệu gặp lỗi,Đã có món ăn trên bàn này.");
                }
            }
        }
        public void Them(string MaBan, string TenBan, string IDKhuVuc, string IDChiNhanh)
        {
            using (SqlConnection myConnection = new SqlConnection(StaticContext.ConnectionString))
            {
                try
                {
                    myConnection.Open();
                    string cmdText = "INSERT INTO [CF_Ban] ([MaBan],[TenBan],[IDKhuVuc],[NgayCapNhat],[IDChiNhanh]) VALUES (@MaBan,@TenBan,@IDKhuVuc, getdate(),@IDChiNhanh)";
                    using (SqlCommand myCommand = new SqlCommand(cmdText, myConnection))
                    {
                        myCommand.Parameters.AddWithValue("@IDChiNhanh", IDChiNhanh);
                        myCommand.Parameters.AddWithValue("@MaBan", MaBan);
                        myCommand.Parameters.AddWithValue("@TenBan", TenBan);
                        myCommand.Parameters.AddWithValue("@IDKhuVuc", IDKhuVuc);
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
        public DataTable DanhSach(string IDChiNhanh) 
        {
            using (SqlConnection con = new SqlConnection(StaticContext.ConnectionString))
            {
                con.Open();
                string cmdText = " SELECT * FROM [CF_Ban] WHERE [IDChiNhanh] = '" + IDChiNhanh + "'";
                using (SqlCommand command = new SqlCommand(cmdText, con))
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    DataTable tb = new DataTable();
                    tb.Load(reader);
                    return tb;
                }
            }
        }
        public static string Dem_Max(string IDKhuVuc)
        {
            using (SqlConnection con = new SqlConnection(StaticContext.ConnectionString))
            {
                con.Open();
                int STTV = 0;
                string SoVe;
                string GPM = "00000";
                string cmdText = "SELECT * FROM [CF_Ban] WHERE [IDKhuVuc] = '" + IDKhuVuc + "'";
                using (SqlCommand command = new SqlCommand(cmdText, con))
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    DataTable tb = new DataTable();
                    tb.Load(reader);
                    STTV = tb.Rows.Count + 1;
                    int DoDaiHT = STTV.ToString().Length;
                    string DoDaiGPM = GPM.Substring(0, 6 - DoDaiHT);
                    SoVe = DoDaiGPM + STTV;
                    return SoVe;
                }
            }
        }
    }
}