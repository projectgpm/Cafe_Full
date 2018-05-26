using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace BanHang.Data
{
    public class dtThemHangHoa
    {
        public void ThemChiTietNguyenLieu(object IDHangHoa, string IDNguyenLieu, string TrongLuong, string MaNguyenLieu, string NhaCungCap, string IDDonViTinh)
        {
            using (SqlConnection myConnection = new SqlConnection(StaticContext.ConnectionString))
            {
                try
                {
                    myConnection.Open();
                    string cmdText = "INSERT INTO [CF_HangHoa_ChiTiet] ([IDHangHoa],[IDNguyenLieu],[TrongLuong],[MaNguyenLieu],[NhaCungCap],[IDDonViTinh]) VALUES (@IDHangHoa,@IDNguyenLieu,@TrongLuong,@MaNguyenLieu,@NhaCungCap,@IDDonViTinh)";
                    using (SqlCommand myCommand = new SqlCommand(cmdText, myConnection))
                    {
                        myCommand.Parameters.AddWithValue("@IDDonViTinh", IDDonViTinh);
                        myCommand.Parameters.AddWithValue("@IDHangHoa", IDHangHoa);
                        myCommand.Parameters.AddWithValue("@IDNguyenLieu", IDNguyenLieu);
                        myCommand.Parameters.AddWithValue("@TrongLuong", TrongLuong);
                        myCommand.Parameters.AddWithValue("@MaNguyenLieu", MaNguyenLieu);
                        myCommand.Parameters.AddWithValue("@NhaCungCap", NhaCungCap);
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
        public void CapNhatHangHoa(object IDHangHoa, string MaHangHoa, string TenHangHoa, string GiaBan, string IDDonViTinh, string IDNhomHang, string GhiChu)
        {
            using (SqlConnection myConnection = new SqlConnection(StaticContext.ConnectionString))
            {
                try
                {
                    myConnection.Open();

                    string cmdText = "UPDATE [CF_HangHoa] SET [MaHangHoa] = @MaHangHoa,[TenHangHoa] = @TenHangHoa,[GiaBan] = @GiaBan,[IDDonViTinh] = @IDDonViTinh,[IDNhomHang] = @IDNhomHang,[GhiChu] = @GhiChu WHERE ID = @IDHangHoa";
                    using (SqlCommand myCommand = new SqlCommand(cmdText, myConnection))
                    {
                        myCommand.Parameters.AddWithValue("@IDHangHoa", IDHangHoa);
                        myCommand.Parameters.AddWithValue("@MaHangHoa", MaHangHoa);
                        myCommand.Parameters.AddWithValue("@TenHangHoa", TenHangHoa);
                        myCommand.Parameters.AddWithValue("@GiaBan", GiaBan);
                        myCommand.Parameters.AddWithValue("@IDDonViTinh", IDDonViTinh);
                        myCommand.Parameters.AddWithValue("@GhiChu", GhiChu);
                        myCommand.Parameters.AddWithValue("@IDNhomHang", IDNhomHang);
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
        public void XoaChiTiet_Temp_ID(string ID)
        {
            using (SqlConnection myConnection = new SqlConnection(StaticContext.ConnectionString))
            {
                try
                {
                    myConnection.Open();
                    string strSQL = "DELETE [CF_HangHoa_ChiTiet_Temp] WHERE [ID] = " + ID;
                    using (SqlCommand myCommand = new SqlCommand(strSQL, myConnection))
                    {
                        myCommand.ExecuteNonQuery();
                    }
                    
                }
                catch (Exception e)
                {
                    throw new Exception("Lỗi: Quá trình cập nhật dữ liệu gặp lỗi, hãy tải lại trang");
                }
            }
        }
        public void XoaChiTiet_Temp(string IDHangHoa)
        {
            using (SqlConnection myConnection = new SqlConnection(StaticContext.ConnectionString))
            {
                try
                {
                    myConnection.Open();
                    string strSQL = "DELETE [CF_HangHoa_ChiTiet_Temp] WHERE [IDHangHoa] = " + IDHangHoa;
                    using (SqlCommand myCommand = new SqlCommand(strSQL, myConnection))
                    {
                        myCommand.ExecuteNonQuery();
                    }
                    strSQL = "DELETE [CF_HangHoa] WHERE [ID] = " + IDHangHoa;
                    using (SqlCommand myCommand = new SqlCommand(strSQL, myConnection))
                    {
                        myCommand.ExecuteNonQuery();
                    }
                }
                catch (Exception e)
                {
                    throw new Exception("Lỗi: Quá trình cập nhật dữ liệu gặp lỗi, hãy tải lại trang");
                }
            }
        }
        public void CapNhatNguyenLieu_Temp(string IDHangHoa, string IDNguyenLieu, float TrongLuong)
        {
            using (SqlConnection myConnection = new SqlConnection(StaticContext.ConnectionString))
            {
                try
                {
                    myConnection.Open();
                    string cmdText = "UPDATE [CF_HangHoa_ChiTiet_Temp] SET [TrongLuong] = @TrongLuong WHERE [IDHangHoa] = @IDHangHoa AND [IDNguyenLieu] = @IDNguyenLieu";
                    using (SqlCommand myCommand = new SqlCommand(cmdText, myConnection))
                    {
                        myCommand.Parameters.AddWithValue("@IDHangHoa", IDHangHoa);
                        myCommand.Parameters.AddWithValue("@IDNguyenLieu", IDNguyenLieu);
                        myCommand.Parameters.AddWithValue("@TrongLuong", TrongLuong);
               
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
        public void ThemNguyenLieu_Temp(string IDHangHoa, string IDNguyenLieu, float TrongLuong, string MaNguyenLieu, string NhaCungCap, string IDDonViTinh)
        {
            using (SqlConnection myConnection = new SqlConnection(StaticContext.ConnectionString))
            {
                try
                {
                    myConnection.Open();
                    string cmdText = "INSERT INTO [CF_HangHoa_ChiTiet_Temp] ([IDHangHoa],[IDNguyenLieu],[TrongLuong],[MaNguyenLieu],[NhaCungCap],[IDDonViTinh]) VALUES (@IDHangHoa,@IDNguyenLieu,@TrongLuong,@MaNguyenLieu,@NhaCungCap,@IDDonViTinh)";
                    using (SqlCommand myCommand = new SqlCommand(cmdText, myConnection))
                    {
                        myCommand.Parameters.AddWithValue("@IDHangHoa", IDHangHoa);
                        myCommand.Parameters.AddWithValue("@IDDonViTinh", IDDonViTinh);
                        myCommand.Parameters.AddWithValue("@IDNguyenLieu", IDNguyenLieu);
                        myCommand.Parameters.AddWithValue("@TrongLuong", TrongLuong);
                        myCommand.Parameters.AddWithValue("@MaNguyenLieu", MaNguyenLieu);
                        myCommand.Parameters.AddWithValue("@NhaCungCap", NhaCungCap);
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
        public DataTable KTHangHoa_Temp(string IDHangHoa, string IDNguyenLieu)
        {
            using (SqlConnection con = new SqlConnection(StaticContext.ConnectionString))
            {
                con.Open();
                string cmdText = "SELECT * FROM [CF_HangHoa_ChiTiet_Temp] WHERE [IDHangHoa]= '" + IDHangHoa + "' AND [IDNguyenLieu] = " + IDNguyenLieu;
                using (SqlCommand command = new SqlCommand(cmdText, con))
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    DataTable tb = new DataTable();
                    tb.Load(reader);
                    return tb;
                }
            }
        }
        public static string LayMaNguyenLieu(string IDNguyenLieu)
        {
            using (SqlConnection con = new SqlConnection(StaticContext.ConnectionString))
            {
                con.Open();
                string cmdText = "SELECT MaNguyenLieu FROM [CF_NguyenLieu] WHERE [ID] = '" + IDNguyenLieu + "'";
                using (SqlCommand command = new SqlCommand(cmdText, con))
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    DataTable tb = new DataTable();
                    tb.Load(reader);
                    if (tb.Rows.Count != 0)
                    {
                        DataRow dr = tb.Rows[0];
                        string ID = dr["MaNguyenLieu"].ToString().Trim();
                        return ID;
                    }
                    return null;
                }
            }
        }
        public static string LayIDDonViTinh(string IDNguyenLieu)
        {
            using (SqlConnection con = new SqlConnection(StaticContext.ConnectionString))
            {
                con.Open();
                string cmdText = "SELECT IDDonViTinh FROM [CF_NguyenLieu] WHERE [ID] = '" + IDNguyenLieu + "'";
                using (SqlCommand command = new SqlCommand(cmdText, con))
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    DataTable tb = new DataTable();
                    tb.Load(reader);
                    if (tb.Rows.Count != 0)
                    {
                        DataRow dr = tb.Rows[0];
                        string ID = dr["IDDonViTinh"].ToString().Trim();
                        return ID;
                    }
                    return "1";
                }
            }
        }
        public static string LayNhaCungCap(string IDNguyenLieu)
        {
            using (SqlConnection con = new SqlConnection(StaticContext.ConnectionString))
            {
                con.Open();
                string cmdText = "SELECT NhaCungCap FROM [CF_NguyenLieu] WHERE [ID] = '" + IDNguyenLieu + "'";
                using (SqlCommand command = new SqlCommand(cmdText, con))
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    DataTable tb = new DataTable();
                    tb.Load(reader);
                    if (tb.Rows.Count != 0)
                    {
                        DataRow dr = tb.Rows[0];
                        string ID = dr["NhaCungCap"].ToString().Trim();
                        return ID;
                    }
                    return null;
                }
            }
        }
        public DataTable NguyenLieu_Temp(string IDHangHoa)
        {
            using (SqlConnection con = new SqlConnection(StaticContext.ConnectionString))
            {
                con.Open();
                string cmdText = "SELECT * FROM [CF_HangHoa_ChiTiet_Temp] WHERE [IDHangHoa] = " + IDHangHoa;
                using (SqlCommand command = new SqlCommand(cmdText, con))
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    DataTable tb = new DataTable();
                    tb.Load(reader);
                    return tb;
                }
            }
        }
        public static string Dem_Max()
        {
            using (SqlConnection con = new SqlConnection(StaticContext.ConnectionString))
            {
                con.Open();
                int STTV = 0;
                string SoVe;
                string GPM = "00000";
                string cmdText = "SELECT * FROM [CF_HangHoa] WHERE [MaHangHoa] is not null  AND [TenHangHoa] is not null";
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
        public object ThemHangHoa()
        {
            using (SqlConnection myConnection = new SqlConnection(StaticContext.ConnectionString))
            {
                try
                {
                    myConnection.Open();
                    object IDPhieuKiemKho = null;
                    string cmdText = "INSERT INTO [CF_HangHoa] ([NgayCapNhat]) OUTPUT INSERTED.ID VALUES (getdate())";
                    using (SqlCommand myCommand = new SqlCommand(cmdText, myConnection))
                    {
                        IDPhieuKiemKho = myCommand.ExecuteScalar();
                    }
                    myConnection.Close();
                    return IDPhieuKiemKho;
                }
                catch
                {
                    throw new Exception("Lỗi: Quá trình thêm dữ liệu gặp lỗi");
                }
            }
        }
    }
}