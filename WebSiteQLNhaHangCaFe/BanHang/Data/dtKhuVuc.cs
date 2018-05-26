using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace BanHang.Data
{
    public class dtKhuVuc
    {
        public static bool KiemTra(string KyHieu)
        {
            using (SqlConnection con = new SqlConnection(StaticContext.ConnectionString))
            {
                con.Open();
                string cmdText = "SELECT * FROM [CF_KhuVuc] WHERE [KyHieu] = N'" + KyHieu + "'";
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
        public void Sua(string ID, string GhiChu, string TenKhuVuc, string GiaKhuVuc, string IDChiNhanh, string KyHieu, string IDBangGia)
        {
            using (SqlConnection myConnection = new SqlConnection(StaticContext.ConnectionString))
            {
                try
                {
                    myConnection.Open();
                    string strSQL = "UPDATE [CF_KhuVuc] SET [IDBangGia] = @IDBangGia,[KyHieu] = @KyHieu,[IDChiNhanh] = @IDChiNhanh,[GiaKhuVuc] = @GiaKhuVuc,[GhiChu] = @GhiChu,[TenKhuVuc] = @TenKhuVuc, [NgayCapNhat] = getdate() WHERE [ID] = @ID";
                    using (SqlCommand myCommand = new SqlCommand(strSQL, myConnection))
                    {
                        myCommand.Parameters.AddWithValue("@IDBangGia", IDBangGia);
                        myCommand.Parameters.AddWithValue("@ID", ID);
                        myCommand.Parameters.AddWithValue("@GhiChu", GhiChu);
                        myCommand.Parameters.AddWithValue("@KyHieu", KyHieu);
                        myCommand.Parameters.AddWithValue("@TenKhuVuc", TenKhuVuc);
                        myCommand.Parameters.AddWithValue("@IDChiNhanh", IDChiNhanh);
                        myCommand.Parameters.AddWithValue("@GiaKhuVuc", GiaKhuVuc);
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
                    string strSQL = "UPDATE [CF_KhuVuc] SET [DAXOA] = 1 WHERE [ID] = @ID";
                    using (SqlCommand myCommand = new SqlCommand(strSQL, myConnection))
                    {
                        myCommand.Parameters.AddWithValue("@ID", ID);
                        myCommand.ExecuteNonQuery();
                    }
                    strSQL = "UPDATE [CF_Ban] SET [DAXOA] = 1 WHERE [IDKhuVuc] = @ID";
                    using (SqlCommand myCommand = new SqlCommand(strSQL, myConnection))
                    {
                        myCommand.Parameters.AddWithValue("@ID", ID);
                        myCommand.ExecuteNonQuery();
                    }
                }
                catch (Exception e)
                {
                    throw new Exception("Lỗi: Quá trình Xóa dữ liệu gặp lỗi, hãy tải lại trang");
                }
            }
        }
        public object Them(string MaKhuVuc, string TenKhuVuc, string GiaKhuVuc, string IDChiNhanh, string GhiChu, string KyHieu, string IDBangGia)
        {
            using (SqlConnection myConnection = new SqlConnection(StaticContext.ConnectionString))
            {
                try
                {
                    myConnection.Open();
                    object ID = null;
                    string cmdText = "INSERT INTO [CF_KhuVuc] ([MaKhuVuc],[TenKhuVuc],[GiaKhuVuc],[IDChiNhanh], [NgayCapNhat],[GhiChu],[KyHieu],[IDBangGia]) OUTPUT INSERTED.ID VALUES (@MaKhuVuc,@TenKhuVuc,@GiaKhuVuc,@IDChiNhanh, getdate(),@GhiChu,@KyHieu,@IDBangGia)";
                    using (SqlCommand myCommand = new SqlCommand(cmdText, myConnection))
                    {
                        myCommand.Parameters.AddWithValue("@GhiChu", GhiChu);
                        myCommand.Parameters.AddWithValue("@IDBangGia", IDBangGia);
                        myCommand.Parameters.AddWithValue("@KyHieu", KyHieu);
                        myCommand.Parameters.AddWithValue("@IDChiNhanh", IDChiNhanh);
                        myCommand.Parameters.AddWithValue("@GiaKhuVuc", GiaKhuVuc);
                        myCommand.Parameters.AddWithValue("@MaKhuVuc", MaKhuVuc);
                        myCommand.Parameters.AddWithValue("@TenKhuVuc", TenKhuVuc);
                        ID = myCommand.ExecuteScalar();
                    }
                    myConnection.Close();
                    return ID;
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
                string cmdText = " SELECT * FROM [CF_KhuVuc] WHERE DaXoa = 0 AND ( '" + IDChiNhanh + "' = 1 OR [IDChiNhanh]='" + IDChiNhanh + "')";
                using (SqlCommand command = new SqlCommand(cmdText, con))
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    DataTable tb = new DataTable();
                    tb.Load(reader);
                    return tb;
                }
            }
        }
        public static string Dem_Max(string IDChiNhanh)
        {
            using (SqlConnection con = new SqlConnection(StaticContext.ConnectionString))
            {
                con.Open();
                int STTV = 0;
                string SoVe;
                string GPM = "000";
                string cmdText = "SELECT * FROM [CF_KhuVuc] WHERE [IDChiNhanh] = '" + IDChiNhanh + "'";
                using (SqlCommand command = new SqlCommand(cmdText, con))
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    DataTable tb = new DataTable();
                    tb.Load(reader);
                    STTV = tb.Rows.Count + 1;
                    int DoDaiHT = STTV.ToString().Length;
                    string DoDaiGPM = GPM.Substring(0, 4 - DoDaiHT);
                    SoVe = DoDaiGPM + STTV;
                    return SoVe;
                }
            }
        }
    }
}