using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;

namespace BanHang.Data
{
    public class dtDonViTinh
    {
        public static string Dem_Max()
        {
            using (SqlConnection con = new SqlConnection(StaticContext.ConnectionString))
            {
                con.Open();
                int STTV = 0;
                string SoVe;
                string GPM = "000";
                string cmdText = "SELECT * FROM [CF_DonViTinh]";
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
        public DataTable LayDanhSachDonViTinh(string IDChiNhanh)
        {
            using (SqlConnection con = new SqlConnection(StaticContext.ConnectionString))
            {
                con.Open();
                string cmdText = " SELECT * FROM [CF_DonViTinh] WHERE DaXoa = 0 AND [IDChiNhanh] = '" + IDChiNhanh + "'";
                using (SqlCommand command = new SqlCommand(cmdText, con))
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    DataTable tb = new DataTable();
                    tb.Load(reader);
                    return tb;
                }
            }
        }

        public static int KiemTra(string TenDonViTinh)
        {
            using (SqlConnection con = new SqlConnection(StaticContext.ConnectionString))
            {
                con.Open();
                string cmdText = "SELECT * FROM [CF_DonViTinh] WHERE [TenDonViTinh] = N'" + TenDonViTinh + "'";
                using (SqlCommand command = new SqlCommand(cmdText, con))
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    DataTable tb = new DataTable();
                    tb.Load(reader);
                    if (tb.Rows.Count == 0)
                    {

                        return 1;
                    }
                    else return -1;
                }
            }
        }

        public static string LayIDDVT_Moi(string IDDVTCu, string IDChiNhanhMoi)
        {
            using (SqlConnection con = new SqlConnection(StaticContext.ConnectionString))
            {
                string ID = "1";
                con.Open();
                string cmdText = "SELECT * FROM [CF_DonViTinh] WHERE [ID] = N'" + IDDVTCu + "'";
                using (SqlCommand command = new SqlCommand(cmdText, con))
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    DataTable tb = new DataTable();
                    tb.Load(reader);
                    if (tb.Rows.Count > 0)
                    {
                        DataRow dr = tb.Rows[0];
                        cmdText = "SELECT * FROM [CF_DonViTinh] WHERE [TenDonViTinh] = N'" + dr["TenDonViTinh"] + "' AND IDChiNhanh ='" + IDChiNhanhMoi + "'";
                        using (SqlCommand command1 = new SqlCommand(cmdText, con))
                        using (SqlDataReader reader1 = command1.ExecuteReader())
                        {
                            DataTable tb1 = new DataTable();
                            tb1.Load(reader1);
                            if (tb.Rows.Count > 0)
                            {
                                DataRow dr1 = tb1.Rows[0];
                                ID = dr1["ID"].ToString();
                            }
                        }
                        return ID;
                    }
                    else return ID;
                }
            }
        }
        public void ThemDonViTinh(string TenDonViTinh, string IDChiNhanh)
        {
            using (SqlConnection myConnection = new SqlConnection(StaticContext.ConnectionString))
            {
                try
                {
                    myConnection.Open();
                    string cmdText = "INSERT INTO [CF_DonViTinh] ([TenDonViTinh],[IDChiNhanh], [NgayCapNhat]) VALUES (@TenDonViTinh,@IDChiNhanh, getdate())";
                    using (SqlCommand myCommand = new SqlCommand(cmdText, myConnection))
                    {
                        myCommand.Parameters.AddWithValue("@TenDonViTinh", TenDonViTinh);
                        myCommand.Parameters.AddWithValue("@IDChiNhanh", IDChiNhanh);
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

        public void XoaDonViTinh(int ID)
        {
            using (SqlConnection myConnection = new SqlConnection(StaticContext.ConnectionString))
            {
                try
                {
                    myConnection.Open();
                    string strSQL = "UPDATE [CF_DonViTinh] SET [DAXOA] = 1 WHERE [ID] = @ID";
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

        public void SuaThongTinDonViTinh(int ID, string TenDonViTinh, string IDChiNhanh)
        {
            using (SqlConnection myConnection = new SqlConnection(StaticContext.ConnectionString))
            {
                try
                {
                    myConnection.Open();
                    string strSQL = "UPDATE [CF_DonViTinh] SET [TenDonViTinh] = @TenDonViTinh,[IDChiNhanh] = @IDChiNhanh, [NgayCapNhat] = getdate() WHERE [ID] = @ID";
                    using (SqlCommand myCommand = new SqlCommand(strSQL, myConnection))
                    {
                        myCommand.Parameters.AddWithValue("@ID", ID);
                        myCommand.Parameters.AddWithValue("@TenDonViTinh", TenDonViTinh);
                        myCommand.Parameters.AddWithValue("@IDChiNhanh", IDChiNhanh);

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