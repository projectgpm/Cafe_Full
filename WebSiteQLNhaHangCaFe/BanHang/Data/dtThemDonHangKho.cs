using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace BanHang.Data
{
    public class dtThemDonHangKho
    {
        public void ThemChiTietDonHang(object IDDonHang, string IDNguyenLieu, string MaNguyenLieu, string IDDonViTinh, string SoLuong, string DonGia)
        {
            using (SqlConnection myConnection = new SqlConnection(StaticContext.ConnectionString))
            {
                try
                {
                    myConnection.Open();
                    string cmdText = "INSERT INTO [CF_DonDatHang_ChiTiet] ([IDDonHang],[IDNguyenLieu],[MaNguyenLieu],[IDDonViTinh],[SoLuong],[DonGia]) VALUES (@IDDonHang,@IDNguyenLieu,@MaNguyenLieu,@IDDonViTinh,@SoLuong,@DonGia)";
                    using (SqlCommand myCommand = new SqlCommand(cmdText, myConnection))
                    {
                        myCommand.Parameters.AddWithValue("@IDDonHang", IDDonHang);
                        myCommand.Parameters.AddWithValue("@IDNguyenLieu", IDNguyenLieu);
                        myCommand.Parameters.AddWithValue("@MaNguyenLieu", MaNguyenLieu);
                        myCommand.Parameters.AddWithValue("@IDDonViTinh", IDDonViTinh);
                        myCommand.Parameters.AddWithValue("@SoLuong", SoLuong);
                        myCommand.Parameters.AddWithValue("@DonGia", DonGia);

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

        public void XoaChiTietDonHang_Nhap(string IDDonHang)
        {
            using (SqlConnection myConnection = new SqlConnection(StaticContext.ConnectionString))
            {
                try
                {
                    myConnection.Open();
                    string strSQL = "DELETE [CF_DonDatHang_ChiTiet_Temp] WHERE [IDDonHang] = " + IDDonHang;
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
        public void CongCongNoNCC(string ID, string CongNo)
        {
            using (SqlConnection myConnection = new SqlConnection(StaticContext.ConnectionString))
            {
                try
                {
                    myConnection.Open();
                    string cmdText = "UPDATE [CF_NhaCungCap] SET [CongNo] = [CongNo] + @CongNo WHERE ID = @ID";
                    using (SqlCommand myCommand = new SqlCommand(cmdText, myConnection))
                    {
                        myCommand.Parameters.AddWithValue("@ID", ID);
                        myCommand.Parameters.AddWithValue("@CongNo", CongNo);
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
        public void CapNhatDonDatHang(object ID, string SoDonHang, string IDNguoiLap, DateTime NgayLap, string TongTien, string GhiChu, string IDChiNhanh, string IDNhaCungCap, int TrangThaiCongNo)
        {
            using (SqlConnection myConnection = new SqlConnection(StaticContext.ConnectionString))
            {
                try
                {
                    myConnection.Open();

                    string cmdText = "UPDATE [CF_DonDatHang] SET [TrangThaiCongNo] = @TrangThaiCongNo,[IDNhaCungCap] = @IDNhaCungCap,[IDChiNhanh] = @IDChiNhanh, [SoDonHang] = @SoDonHang, [IDNguoiLap] = @IDNguoiLap,[NgayLap] = @NgayLap,[TongTien] = @TongTien,[GhiChu] = @GhiChu WHERE ID = @ID";
                    using (SqlCommand myCommand = new SqlCommand(cmdText, myConnection))
                    {
                        myCommand.Parameters.AddWithValue("@ID", ID);
                        myCommand.Parameters.AddWithValue("@TrangThaiCongNo", TrangThaiCongNo);
                        myCommand.Parameters.AddWithValue("@IDNhaCungCap", IDNhaCungCap);
                        myCommand.Parameters.AddWithValue("@IDChiNhanh", IDChiNhanh);
                        myCommand.Parameters.AddWithValue("@SoDonHang", SoDonHang);
                        myCommand.Parameters.AddWithValue("@IDNguoiLap", IDNguoiLap);
                        myCommand.Parameters.AddWithValue("@NgayLap", NgayLap);
                        myCommand.Parameters.AddWithValue("@TongTien", TongTien);
                        myCommand.Parameters.AddWithValue("@GhiChu", GhiChu);
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
        public object ThemPhieuDatHang()
        {
            using (SqlConnection myConnection = new SqlConnection(StaticContext.ConnectionString))
            {
                try
                {
                    myConnection.Open();
                    object IDPhieuKiemKho = null;
                    string cmdText = "INSERT INTO [CF_DonDatHang] ([NgayCapNhat]) OUTPUT INSERTED.ID VALUES (getdate())";
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
        public void XoaChiTietDonHang_Temp_ID(string ID)
        {
            using (SqlConnection myConnection = new SqlConnection(StaticContext.ConnectionString))
            {
                try
                {
                    myConnection.Open();
                    string strSQL = "DELETE [CF_DonDatHang_ChiTiet_Temp] WHERE ID = @ID";
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
        public void XoaChiTietDonHang_Temp(string IDDonHang)
        {
            using (SqlConnection myConnection = new SqlConnection(StaticContext.ConnectionString))
            {
                try
                {
                    myConnection.Open();
                    string strSQL = "DELETE [CF_DonDatHang_ChiTiet_Temp] WHERE [IDDonHang] = " + IDDonHang;
                    using (SqlCommand myCommand = new SqlCommand(strSQL, myConnection))
                    {
                        myCommand.ExecuteNonQuery();
                    }
                    strSQL = "DELETE [CF_DonDatHang] WHERE [ID] = " + IDDonHang;
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
        public DataTable DanhSachDonDatHang_Temp(string IDDonHang)
        {
            using (SqlConnection con = new SqlConnection(StaticContext.ConnectionString))
            {
                con.Open();
                string cmdText = "SELECT * FROM [CF_DonDatHang_ChiTiet_Temp] WHERE [IDDonHang] = '" + IDDonHang + "'";
                using (SqlCommand command = new SqlCommand(cmdText, con))
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    DataTable tb = new DataTable();
                    tb.Load(reader);
                    return tb;
                }
            }
        }
        public void CapNhatChiTietDonHang_temp(string IDDonHang, string IDNguyenLieu, float SoLuong, float DonGia)
        {
            using (SqlConnection myConnection = new SqlConnection(StaticContext.ConnectionString))
            {
                try
                {
                    myConnection.Open();
                    string cmdText = "UPDATE [CF_DonDatHang_ChiTiet_Temp] SET [ThanhTien] = @ThanhTien,[SoLuong] = @SoLuong,[DonGia] = @DonGia WHERE [IDNguyenLieu] = @IDNguyenLieu AND [IDNguyenLieu] = @IDNguyenLieu";
                    using (SqlCommand myCommand = new SqlCommand(cmdText, myConnection))
                    {
                        myCommand.Parameters.AddWithValue("@IDNguyenLieu", IDNguyenLieu);
                        myCommand.Parameters.AddWithValue("@IDDonHang", IDDonHang);
                        myCommand.Parameters.AddWithValue("@SoLuong", SoLuong);
                        myCommand.Parameters.AddWithValue("@DonGia", DonGia);
                        myCommand.Parameters.AddWithValue("@ThanhTien",SoLuong* DonGia);
                        myCommand.ExecuteNonQuery();
                    }
                    myConnection.Close();
                }
                catch
                {
                    throw new Exception("Lỗi: Quá trình cập nhật dữ liệu gặp lỗi");
                }
            }
        }
        public void ThemChiTietDonHang_Temp(string IDDonHang, string IDNguyenLieu, string MaNguyenLieu, string IDDonViTinh, float SoLuong, float DonGia)
        {
            using (SqlConnection myConnection = new SqlConnection(StaticContext.ConnectionString))
            {
                try
                {
                    myConnection.Open();
                    string cmdText = "INSERT INTO [CF_DonDatHang_ChiTiet_Temp] ([IDDonHang],[IDNguyenLieu],[MaNguyenLieu],[IDDonViTinh],[SoLuong],[DonGia],[ThanhTien]) VALUES (@IDDonHang,@IDNguyenLieu,@MaNguyenLieu,@IDDonViTinh,@SoLuong,@DonGia,@ThanhTien)";
                    using (SqlCommand myCommand = new SqlCommand(cmdText, myConnection))
                    {
                        myCommand.Parameters.AddWithValue("@IDDonHang", IDDonHang);
                        myCommand.Parameters.AddWithValue("@IDNguyenLieu", IDNguyenLieu);
                        myCommand.Parameters.AddWithValue("@MaNguyenLieu", MaNguyenLieu);
                        myCommand.Parameters.AddWithValue("@IDDonViTinh", IDDonViTinh);
                        myCommand.Parameters.AddWithValue("@SoLuong", SoLuong);
                        myCommand.Parameters.AddWithValue("@DonGia", DonGia);
                        myCommand.Parameters.AddWithValue("@ThanhTien",SoLuong* DonGia);
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
        public static DataTable KTChiTietDonHang_Temp(string IDNguyenLieu, string IDDonHang)
        {
            using (SqlConnection con = new SqlConnection(StaticContext.ConnectionString))
            {
                con.Open();
                string cmdText = "SELECT * FROM [CF_DonDatHang_ChiTiet_Temp] WHERE [IDNguyenLieu]= '" + IDNguyenLieu + "' AND [IDDonHang] = '" + IDDonHang + "' ";
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