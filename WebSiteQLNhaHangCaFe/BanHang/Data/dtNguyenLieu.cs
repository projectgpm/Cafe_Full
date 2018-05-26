using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace BanHang.Data
{
    public class dtNguyenLieu
    {
        public void ThemNguyenLieuTonKho(string IDNguyenLieu, string IDChiNhanh, string MaNguyenLieu)
        {
            using (SqlConnection myConnection = new SqlConnection(StaticContext.ConnectionString))
            {
                try
                {
                    myConnection.Open();
                    string cmdText = "INSERT INTO [CF_TonKho] ([IDNguyenLieu],[IDChiNhanh],[MaNguyenLieu]) VALUES (@IDNguyenLieu,@IDChiNhanh,@MaNguyenLieu)";
                    using (SqlCommand myCommand = new SqlCommand(cmdText, myConnection))
                    {
                        myCommand.Parameters.AddWithValue("@IDNguyenLieu", IDNguyenLieu);
                        myCommand.Parameters.AddWithValue("@IDChiNhanh", IDChiNhanh);
                        myCommand.Parameters.AddWithValue("@MaNguyenLieu", MaNguyenLieu);
                       
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
        public DataTable DanhSachChiNhanh()
        {
            using (SqlConnection con = new SqlConnection(StaticContext.ConnectionString))
            {
                con.Open();
                string cmdText = "SELECT * FROM [CF_ChiNhanh]";
                using (SqlCommand command = new SqlCommand(cmdText, con))
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    DataTable tb = new DataTable();
                    tb.Load(reader);
                    return tb;
                }
            }
        }
        public void Sua(string ID, string MaNguyenLieu, string TenNguyenLieu, string NhaCungCap, string GhiChu, string IDDonViTinh, string GiaMua, string TrangThai, string GiaBan)
        {
            using (SqlConnection myConnection = new SqlConnection(StaticContext.ConnectionString))
            {
                try
                {
                    myConnection.Open();
                    string strSQL = "UPDATE [CF_NguyenLieu] SET [GiaBan] = @GiaBan,[TrangThai] = @TrangThai,[GiaMua] = @GiaMua,[IDDonViTinh] = @IDDonViTinh,[MaNguyenLieu] = @MaNguyenLieu,[TenNguyenLieu] = @TenNguyenLieu,[GhiChu] = @GhiChu,[NhaCungCap]=@NhaCungCap, [NgayCapNhat] = getdate() WHERE [ID] = @ID";
                    using (SqlCommand myCommand = new SqlCommand(strSQL, myConnection))
                    {
                        myCommand.Parameters.AddWithValue("@GiaBan", GiaBan);
                        myCommand.Parameters.AddWithValue("@TrangThai", TrangThai);
                        myCommand.Parameters.AddWithValue("@IDDonViTinh", IDDonViTinh);
                        myCommand.Parameters.AddWithValue("@ID", ID);
                        myCommand.Parameters.AddWithValue("@MaNguyenLieu", MaNguyenLieu);
                        myCommand.Parameters.AddWithValue("@TenNguyenLieu", TenNguyenLieu);
                        myCommand.Parameters.AddWithValue("@GiaMua", GiaMua);
                        myCommand.Parameters.AddWithValue("@NhaCungCap", NhaCungCap);
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
        public void Xoa(string ID)
        {
            using (SqlConnection myConnection = new SqlConnection(StaticContext.ConnectionString))
            {
                try
                {
                    myConnection.Open();
                    string strSQL = "UPDATE [CF_NguyenLieu] SET [DAXOA] = 1 WHERE [ID] = @ID";
                    using (SqlCommand myCommand = new SqlCommand(strSQL, myConnection))
                    {
                        myCommand.Parameters.AddWithValue("@ID", ID);
                        myCommand.ExecuteNonQuery();
                    }
                    strSQL = "UPDATE [CF_TonKho] SET [DAXOA] = 1 WHERE [IDNguyenLieu] = @ID";
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
        public object Them(string MaNguyenLieu, string TenNguyenLieu, string NhaCungCap, string GhiChu, string IDDonViTinh, string GiaMua, string TrangThai, string GiaBan)
        {
            using (SqlConnection myConnection = new SqlConnection(StaticContext.ConnectionString))
            {
                try
                {
                    myConnection.Open();
                    object ID = null;
                    string cmdText = "INSERT INTO [CF_NguyenLieu] ([MaNguyenLieu],[TenNguyenLieu],[NhaCungCap], [NgayCapNhat],[GhiChu],[IDDonViTinh],[GiaMua],[TrangThai],[GiaBan])  OUTPUT INSERTED.ID VALUES (@MaNguyenLieu,@TenNguyenLieu,@NhaCungCap, getdate(),@GhiChu,@IDDonViTinh,@GiaMua,@TrangThai,@GiaBan)";
                    using (SqlCommand myCommand = new SqlCommand(cmdText, myConnection))
                    {
                        myCommand.Parameters.AddWithValue("@GiaBan", GiaBan);
                        myCommand.Parameters.AddWithValue("@IDDonViTinh", IDDonViTinh);
                        myCommand.Parameters.AddWithValue("@MaNguyenLieu", MaNguyenLieu);
                        myCommand.Parameters.AddWithValue("@TenNguyenLieu", TenNguyenLieu);
                        myCommand.Parameters.AddWithValue("@GiaMua", GiaMua);
                        myCommand.Parameters.AddWithValue("@NhaCungCap", NhaCungCap);
                        myCommand.Parameters.AddWithValue("@GhiChu", GhiChu);
                        myCommand.Parameters.AddWithValue("@TrangThai", TrangThai);
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
                string GPM = "000000";
                string cmdText = "SELECT * FROM [CF_NguyenLieu] ";
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
        public DataTable DanhSach()
        {
            using (SqlConnection con = new SqlConnection(StaticContext.ConnectionString))
            {
                con.Open();
                string cmdText = " SELECT * FROM [CF_NguyenLieu] WHERE DaXoa = 0 AND TrangThai < 2";
                using (SqlCommand command = new SqlCommand(cmdText, con))
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    DataTable tb = new DataTable();
                    tb.Load(reader);
                    return tb;
                }
            }
        }

        public float LaySoTienCu(string ID)
        {
            using (SqlConnection con = new SqlConnection(StaticContext.ConnectionString))
            {
                con.Open();
                string cmdText = " SELECT GiaBan FROM [CF_NguyenLieu] WHERE ID = '" + ID + "'";
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
    }
}