using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace BanHang.Data
{
    public class dtHangHoa
    {
        public static bool KiemTraNguyenLieu_ID(string IDNguyenLieu, string ID)
        {
            using (SqlConnection con = new SqlConnection(StaticContext.ConnectionString))
            {
                con.Open();
                string cmdText = "SELECT * FROM [CF_HangHoa_ChiTiet] WHERE [IDNguyenLieu] = '" + IDNguyenLieu + "' AND ID =  " + ID;
                using (SqlCommand command = new SqlCommand(cmdText, con))
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    DataTable tb = new DataTable();
                    tb.Load(reader);
                    if (tb.Rows.Count != 0)
                    {
                        return true;
                    }
                    return false;
                }
            }
        }
        public DataTable KT_NguyenLieu(object IDHangHoa, string IDNguyenLieu)
        {
            using (SqlConnection con = new SqlConnection(StaticContext.ConnectionString))
            {
                con.Open();
                string cmdText = "SELECT * FROM [CF_HangHoa_ChiTiet] WHERE [IDHangHoa]= '" + IDHangHoa + "' AND [IDNguyenLieu] = " + IDNguyenLieu;
                using (SqlCommand command = new SqlCommand(cmdText, con))
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    DataTable tb = new DataTable();
                    tb.Load(reader);
                    return tb;
                }
            }
        }
        public void XoaNguyenLieu(int ID)
        {
            using (SqlConnection myConnection = new SqlConnection(StaticContext.ConnectionString))
            {
                try
                {
                    myConnection.Open();
                    string cmdText = "DELETE FROM [CF_HangHoa_ChiTiet] WHERE [ID] = @ID";
                    using (SqlCommand myCommand = new SqlCommand(cmdText, myConnection))
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
        public void CapNhatNguyenLieu(int ID, object IDHangHoa, string IDNguyenLieu, string TrongLuong, string MaNguyenLieu, string NhaCungCap, string IDDonViTinh)
        {
            using (SqlConnection myConnection = new SqlConnection(StaticContext.ConnectionString))
            {
                try
                {
                    myConnection.Open();
                    string cmdText = "UPDATE [CF_HangHoa_ChiTiet] SET [IDHangHoa] = @IDHangHoa, [IDNguyenLieu] = @IDNguyenLieu,[TrongLuong] = @TrongLuong,[MaNguyenLieu] =@MaNguyenLieu,[NhaCungCap] = @NhaCungCap,[IDDonViTinh] = @IDDonViTinh  WHERE [ID] = @ID";
                    using (SqlCommand myCommand = new SqlCommand(cmdText, myConnection))
                    {
                        myCommand.Parameters.AddWithValue("@ID", ID);
                        myCommand.Parameters.AddWithValue("@IDNguyenLieu", IDNguyenLieu);
                        myCommand.Parameters.AddWithValue("@TrongLuong", TrongLuong);
                        myCommand.Parameters.AddWithValue("@MaNguyenLieu", MaNguyenLieu);
                        myCommand.Parameters.AddWithValue("@NhaCungCap", NhaCungCap);
                        myCommand.Parameters.AddWithValue("@IDDonViTinh", IDDonViTinh);
                        myCommand.Parameters.AddWithValue("@IDHangHoa", IDHangHoa);
                        myCommand.ExecuteNonQuery();
                    }
                }
                catch (Exception e)
                {
                    throw new Exception("Lỗi: Quá trình cập nhật dữ liệu gặp lỗi, hãy tải lại trang");
                }
            }
        }

        public float LaySoTienCu(string ID)
        {
            using (SqlConnection con = new SqlConnection(StaticContext.ConnectionString))
            {
                con.Open();
                string cmdText = " SELECT GiaBan FROM [CF_HangHoa] WHERE ID = '" + ID + "'";
                using (SqlCommand command = new SqlCommand(cmdText, con))
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    DataTable tb = new DataTable();
                    tb.Load(reader);
                    if (tb.Rows.Count != 0)
                        return float.Parse(tb.Rows[0]["GiaBan"].ToString());
                    return 0;
                }
            }
        }

        public float LaySoTienCu_ChiTietGia(string ID)
        {
            using (SqlConnection con = new SqlConnection(StaticContext.ConnectionString))
            {
                con.Open();
                string cmdText = " SELECT GiaMoi FROM [CF_ChiTietBangGia] WHERE ID = '" + ID + "'";
                using (SqlCommand command = new SqlCommand(cmdText, con))
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    DataTable tb = new DataTable();
                    tb.Load(reader);
                    if (tb.Rows.Count != 0)
                        return float.Parse(tb.Rows[0]["GiaMoi"].ToString());
                    return 0;
                }
            }
        }

        public void ThemNguyenLieu(object IDHangHoa, string IDNguyenLieu, string TrongLuong, string MaNguyenLieu, string NhaCungCap, string IDDonViTinh)
        {
            using (SqlConnection myConnection = new SqlConnection(StaticContext.ConnectionString))
            {
                try
                {
                    myConnection.Open();
                    string cmdText = "INSERT INTO [CF_HangHoa_ChiTiet] ([IDHangHoa],[IDNguyenLieu],[TrongLuong],[MaNguyenLieu],[NhaCungCap],[IDDonViTinh])" +
                             " VALUES(@IDHangHoa, @IDNguyenLieu, @TrongLuong,@MaNguyenLieu,@NhaCungCap,@IDDonViTinh)";
                    using (SqlCommand myCommand = new SqlCommand(cmdText, myConnection))
                    {
                        myCommand.Parameters.AddWithValue("@IDHangHoa", IDHangHoa);
                        myCommand.Parameters.AddWithValue("@IDNguyenLieu", IDNguyenLieu);
                        myCommand.Parameters.AddWithValue("@TrongLuong", TrongLuong);
                        myCommand.Parameters.AddWithValue("@MaNguyenLieu", MaNguyenLieu);
                        myCommand.Parameters.AddWithValue("@NhaCungCap", NhaCungCap);
                        myCommand.Parameters.AddWithValue("@IDDonViTinh", IDDonViTinh);
                        myCommand.ExecuteNonQuery();
                    }
                }
                catch (Exception e)
                {
                    throw new Exception("Lỗi: Quá trình cập nhật dữ liệu gặp lỗi, hãy tải lại trang");
                }
            }
        }
        public void SuaHangHoa(string ID, string MaHangHoa, string TenHangHoa, string GiaBan, string IDDonViTinh, string IDNhomHang, string GhiChu)
        {
            using (SqlConnection myConnection = new SqlConnection(StaticContext.ConnectionString))
            {
                try
                {
                    myConnection.Open();
                    string strSQL = "UPDATE [CF_HangHoa] SET [MaHangHoa] = @MaHangHoa,[TenHangHoa] = @TenHangHoa,[GiaBan] = @GiaBan,[IDDonViTinh] = @IDDonViTinh ,[IDNhomHang] =@IDNhomHang,[GhiChu] = @GhiChu,[NgayCapNhat] = getdate() WHERE [ID] = @ID";
                    using (SqlCommand myCommand = new SqlCommand(strSQL, myConnection))
                    {
                      
                        myCommand.Parameters.AddWithValue("@ID", ID);
                        myCommand.Parameters.AddWithValue("@MaHangHoa", MaHangHoa);

                        myCommand.Parameters.AddWithValue("@TenHangHoa", TenHangHoa);
                        myCommand.Parameters.AddWithValue("@GiaBan", GiaBan);
                        myCommand.Parameters.AddWithValue("@IDDonViTinh", IDDonViTinh);
                        myCommand.Parameters.AddWithValue("@IDNhomHang", IDNhomHang);
                        myCommand.Parameters.AddWithValue("@GhiChu", GhiChu);
                        myCommand.ExecuteNonQuery();
                    }
                }
                catch (Exception e)
                {
                    throw new Exception("Lỗi: Quá trình cập nhật dữ liệu gặp lỗi, hãy tải lại trang");
                }
            }
        }
        public void XoaHangHoa(string ID)
        {
            using (SqlConnection myConnection = new SqlConnection(StaticContext.ConnectionString))
            {
                try
                {
                    myConnection.Open();
                    string strSQL = "UPDATE [CF_HangHoa] SET [DAXOA] = 1 WHERE [ID] = @ID";
                    using (SqlCommand myCommand = new SqlCommand(strSQL, myConnection))
                    {
                        myCommand.Parameters.AddWithValue("@ID", ID);
                        myCommand.ExecuteNonQuery();
                    }
                    strSQL = "UPDATE [CF_ChiTietBangGia] SET [DAXOA] = 1 WHERE [IDHangHoa] = @ID";
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
        public object ThemHangHoa(string MaHangHoa, string TenHangHoa, string GiaBan, string IDDonViTinh, string IDNhomHang, string GhiChu, string IDChiNhanh)
        {
            using (SqlConnection myConnection = new SqlConnection(StaticContext.ConnectionString))
            {
                try
                {
                    myConnection.Open();
                    object ID = null;
                    string cmdText = "INSERT INTO [CF_HangHoa] ([MaHangHoa],[TenHangHoa],[GiaBan],[IDDonViTinh], [IDNhomHang],[GhiChu],[NgayCapNhat],[IDChiNhanh]) OUTPUT INSERTED.ID  VALUES (@MaHangHoa,@TenHangHoa,@GiaBan,@IDDonViTinh, @IDNhomHang,@GhiChu,getdate(),@IDChiNhanh)";
                    using (SqlCommand myCommand = new SqlCommand(cmdText, myConnection))
                    {
                        myCommand.Parameters.AddWithValue("@IDChiNhanh", IDChiNhanh);
                        myCommand.Parameters.AddWithValue("@MaHangHoa", MaHangHoa);
                        myCommand.Parameters.AddWithValue("@TenHangHoa", TenHangHoa);
                        myCommand.Parameters.AddWithValue("@GiaBan", GiaBan);
                        myCommand.Parameters.AddWithValue("@IDDonViTinh", IDDonViTinh);
                        myCommand.Parameters.AddWithValue("@IDNhomHang", IDNhomHang);
                        myCommand.Parameters.AddWithValue("@GhiChu", GhiChu);
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
        public DataTable GetListBarCode(object ID)
        {
            DataTable dt = new DataTable();
            using (SqlConnection con = new SqlConnection(StaticContext.ConnectionString))
            {
                con.Open();
                string cmdText = "SELECT * FROM [CF_HangHoa_ChiTiet] WHERE [IDHangHoa] = @IDHangHoa";
                using (SqlCommand command = new SqlCommand(cmdText, con))
                {
                    command.Parameters.AddWithValue("@IDHangHoa", ID);
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        dt.Load(reader);
                    }
                }
            }
            return dt;
        }
        public DataTable LayDanhSachHangHoa(string IDChiNhanh)
        {
            using (SqlConnection con = new SqlConnection(StaticContext.ConnectionString))
            {
                con.Open();
                string cmdText = "SELECT [CF_HangHoa].* FROM [CF_HangHoa] WHERE CF_HangHoa.[DAXOA] = 0 AND [MaHangHoa] is not null AND [TenHangHoa] is not null AND [IDChiNhanh] = '" + IDChiNhanh + "'";
                using (SqlCommand command = new SqlCommand(cmdText, con))
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    DataTable tb = new DataTable();
                    tb.Load(reader);
                    return tb;
                }
            }
        }
        public DataTable DanhSachHangHoa_IDnhomHang(string IDNhomHang,string IDChiNhanh)
        {
            using (SqlConnection con = new SqlConnection(StaticContext.ConnectionString))
            {
                con.Open();
                string cmdText = "SELECT [CF_HangHoa].* FROM [CF_HangHoa] WHERE CF_HangHoa.[DAXOA] = 0 AND [MaHangHoa] is not null AND [TenHangHoa] is not null AND [IDChiNhanh] = '" + IDChiNhanh + "' AND IDNhomHang ='" + IDNhomHang + "' ";
                using (SqlCommand command = new SqlCommand(cmdText, con))
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    DataTable tb = new DataTable();
                    tb.Load(reader);
                    return tb;
                }
            }
        }

        public DataTable LayDanhSachHangHoa_MaHang(string MaHang)
        {
            using (SqlConnection con = new SqlConnection(StaticContext.ConnectionString))
            {
                con.Open();
                string cmdText = "SELECT * FROM [CF_HangHoa] WHERE MaHangHoa = '" + MaHang + "'";
                using (SqlCommand command = new SqlCommand(cmdText, con))
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    DataTable tb = new DataTable();
                    tb.Load(reader);
                    return tb;
                }
            }
        }

        public string LayTenHangHoa(string ID)
        {
            using (SqlConnection con = new SqlConnection(StaticContext.ConnectionString))
            {
                con.Open();
                string cmdText = "SELECT TenNguyenLieu FROM [CF_NguyenLieu] WHERE ID = '" + ID + "'";
                using (SqlCommand command = new SqlCommand(cmdText, con))
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    DataTable tb = new DataTable();
                    tb.Load(reader);
                    return tb.Rows[0]["TenNguyenLieu"].ToString();
                }
            }
        }

        public DataTable DanhSachNguyenLieu_BK()
        {
            using (SqlConnection con = new SqlConnection(StaticContext.ConnectionString))
            {
                con.Open();
                string cmdText = "SELECT ID, TenNguyenLieu FROM CF_NguyenLieu";
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