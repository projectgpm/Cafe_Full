using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace BanHang.Data
{
    public class dtPhieuXuatKhac
    {
        public object ThemPhieuXuatKhac_Temp()
        {
            using (SqlConnection myConnection = new SqlConnection(StaticContext.ConnectionString))
            {
                try
                {
                    myConnection.Open();
                    object IDPhieuNhapSi = null;
                    string cmdText = "INSERT INTO [CF_PhieuXuatKhac] ([NgayCapNhat]) OUTPUT INSERTED.ID VALUES (getdate())";
                    using (SqlCommand myCommand = new SqlCommand(cmdText, myConnection))
                    {
                        IDPhieuNhapSi = myCommand.ExecuteScalar();
                    }
                    myConnection.Close();
                    return IDPhieuNhapSi;
                }
                catch
                {
                    throw new Exception("Lỗi: Quá trình thêm dữ liệu gặp lỗi");
                }
            }
        }
        public void XoaPhieuXuatKhac_Temp(int ID)
        {
            using (SqlConnection myConnection = new SqlConnection(StaticContext.ConnectionString))
            {
                try
                {
                    myConnection.Open();
                    string strSQL = "DELETE [CF_PhieuXuatKhac] WHERE [ID] = '" + ID + "'";
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
        public void XoaChiTietPhieuXuatKhac_Temp(string IDPhieuXuatKhac)
        {
            using (SqlConnection myConnection = new SqlConnection(StaticContext.ConnectionString))
            {
                try
                {
                    myConnection.Open();
                    string strSQL = "DELETE [CF_PhieuXuatKhac_ChiTiet_Temp] WHERE [IDPhieuXuatKhac] = '" + IDPhieuXuatKhac + "'";
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
        public DataTable KTChiTietPhieuXuatKhac_Temp(string IDNguyenLieu, string IDPhieuXuatKhac)
        {
            using (SqlConnection con = new SqlConnection(StaticContext.ConnectionString))
            {
                con.Open();
                string cmdText = "SELECT * FROM [CF_PhieuXuatKhac_ChiTiet_Temp] WHERE [IDNguyenLieu]= '" + IDNguyenLieu + "' AND [IDPhieuXuatKhac] = " + IDPhieuXuatKhac;
                using (SqlCommand command = new SqlCommand(cmdText, con))
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    DataTable tb = new DataTable();
                    tb.Load(reader);
                    return tb;
                }
            }
        }
        public void ThemPhieuXuatKhac_Temp1(string IDPhieuXuatKhac, string IDNguyenLieu, string TonKho, string IDDonViTinh, string SoLuongXuat, string MaNguyenLieu, string DonGia)
        {
            using (SqlConnection myConnection = new SqlConnection(StaticContext.ConnectionString))
            {
                try
                {
                    myConnection.Open();
                    string cmdText = "INSERT INTO [CF_PhieuXuatKhac_ChiTiet_Temp] ([IDPhieuXuatKhac],[IDNguyenLieu],[TonKho],[IDDonViTinh],[SoLuongXuat],[MaNguyenLieu],[DonGia]) VALUES (@IDPhieuXuatKhac,@IDNguyenLieu,@TonKho,@IDDonViTinh,@SoLuongXuat,@MaNguyenLieu,@DonGia)";
                    using (SqlCommand myCommand = new SqlCommand(cmdText, myConnection))
                    {
                        myCommand.Parameters.AddWithValue("@IDPhieuXuatKhac", IDPhieuXuatKhac);
                        myCommand.Parameters.AddWithValue("@IDNguyenLieu", IDNguyenLieu);
                        myCommand.Parameters.AddWithValue("@TonKho", TonKho);
                        myCommand.Parameters.AddWithValue("@IDDonViTinh", IDDonViTinh);
                        myCommand.Parameters.AddWithValue("@SoLuongXuat", SoLuongXuat);
                        myCommand.Parameters.AddWithValue("@MaNguyenLieu", MaNguyenLieu);
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
        public void UpdatePhieuXuatKhac_temp(string IDPhieuXuatKhac, string IDNguyenLieu, string SoLuongXuat)
        {
            using (SqlConnection myConnection = new SqlConnection(StaticContext.ConnectionString))
            {
                try
                {
                    myConnection.Open();
                    string cmdText = "UPDATE [CF_PhieuXuatKhac_ChiTiet_Temp] SET [SoLuongXuat] = @SoLuongXuat WHERE [IDNguyenLieu] = @IDNguyenLieu AND [IDPhieuXuatKhac] = @IDPhieuXuatKhac";
                    using (SqlCommand myCommand = new SqlCommand(cmdText, myConnection))
                    {
                        myCommand.Parameters.AddWithValue("@IDPhieuXuatKhac", IDPhieuXuatKhac);
                        myCommand.Parameters.AddWithValue("@IDNguyenLieu", IDNguyenLieu);
                        myCommand.Parameters.AddWithValue("@SoLuongXuat", SoLuongXuat);
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
        public DataTable LayDanhSachPhieuXuatKhac_Temp(string IDPhieuXuatKhac)
        {
            using (SqlConnection con = new SqlConnection(StaticContext.ConnectionString))
            {
                con.Open();
                string cmdText = " SELECT * FROM [CF_PhieuXuatKhac_ChiTiet_Temp] WHERE [IDPhieuXuatKhac] = '" + IDPhieuXuatKhac + "'";
                using (SqlCommand command = new SqlCommand(cmdText, con))
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    DataTable tb = new DataTable();
                    tb.Load(reader);
                    return tb;
                }
            }
        }
        public void CapNhatPhieuXuatKhac_ID(object ID, string IDNhanVien, string IDLyDoXuat, DateTime NgayLapPhieu, string GhiChu, string IDChiNhanh)
        {
            using (SqlConnection myConnection = new SqlConnection(StaticContext.ConnectionString))
            {
                try
                {
                    myConnection.Open();
                    string cmdText = "UPDATE [CF_PhieuXuatKhac] SET [IDChiNhanh] = @IDChiNhanh,[IDNhanVien] = @IDNhanVien, [IDLyDoXuat] = @IDLyDoXuat,[NgayLapPhieu] = @NgayLapPhieu,[GhiChu] = @GhiChu,[NgayCapNhat] = getdate() WHERE [ID] = @ID";
                    using (SqlCommand myCommand = new SqlCommand(cmdText, myConnection))
                    {
                        myCommand.Parameters.AddWithValue("@IDChiNhanh", IDChiNhanh);
                        myCommand.Parameters.AddWithValue("@IDNhanVien", IDNhanVien);
                        myCommand.Parameters.AddWithValue("@NgayLapPhieu", NgayLapPhieu);
                        myCommand.Parameters.AddWithValue("@IDLyDoXuat", IDLyDoXuat);
                        myCommand.Parameters.AddWithValue("@GhiChu", GhiChu);
                        myCommand.Parameters.AddWithValue("@ID", ID);
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
        public void ThemChiTietPhieuXuatKhac(object IDPhieuXuatKhac, string IDNguyenLieu, string TonKho, string IDDonViTinh, string SoLuongXuat, string MaNguyenLieu, string DonGia, string ThanhTien)
        {
            using (SqlConnection myConnection = new SqlConnection(StaticContext.ConnectionString))
            {
                try
                {
                    myConnection.Open();
                    string cmdText = "INSERT INTO [CF_PhieuXuatKhac_ChiTiet] ([IDPhieuXuatKhac],[IDNguyenLieu],[TonKho],[IDDonViTinh],[SoLuongXuat],[MaNguyenLieu],[DonGia],[ThanhTien]) VALUES (@IDPhieuXuatKhac,@IDNguyenLieu,@TonKho,@IDDonViTinh,@SoLuongXuat,@MaNguyenLieu,@DonGia,@ThanhTien)";
                    using (SqlCommand myCommand = new SqlCommand(cmdText, myConnection))
                    {
                        myCommand.Parameters.AddWithValue("@IDPhieuXuatKhac", IDPhieuXuatKhac);
                        myCommand.Parameters.AddWithValue("@IDNguyenLieu", IDNguyenLieu);
                        myCommand.Parameters.AddWithValue("@TonKho", TonKho);
                        myCommand.Parameters.AddWithValue("@IDDonViTinh", IDDonViTinh);
                        myCommand.Parameters.AddWithValue("@SoLuongXuat", SoLuongXuat);
                        myCommand.Parameters.AddWithValue("@MaNguyenLieu", MaNguyenLieu);
                        myCommand.Parameters.AddWithValue("@DonGia", DonGia);
                        myCommand.Parameters.AddWithValue("@ThanhTien", ThanhTien);
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

        public void XoaChiTietPhieuXuatKhac_Temp_ID(int ID)
        {
            using (SqlConnection myConnection = new SqlConnection(StaticContext.ConnectionString))
            {
                try
                {
                    myConnection.Open();
                    string strSQL = "DELETE [CF_PhieuXuatKhac_ChiTiet_Temp] WHERE ID = @ID";
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
        public DataTable DanhSachPhieuXuatKhac()
        {
            using (SqlConnection con = new SqlConnection(StaticContext.ConnectionString))
            {
                con.Open();
                string cmdText = " SELECT * FROM [CF_PhieuXuatKhac] WHERE IDLyDoXuat is not null  ORDER BY [ID] DESC";
                using (SqlCommand command = new SqlCommand(cmdText, con))
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    DataTable tb = new DataTable();
                    tb.Load(reader);
                    return tb;
                }
            }
        }
        public string lyDoXuat(string ID)
        {
            using (SqlConnection con = new SqlConnection(StaticContext.ConnectionString))
            {
                con.Open();
                string cmdText = "SELECT ID,TenTrangThai FROM CF_TrangThaiPhieuXuatKhac WHERE ID = " + ID;
                using (SqlCommand command = new SqlCommand(cmdText, con))
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    DataTable tb = new DataTable();
                    tb.Load(reader);
                    return tb.Rows[0]["TenTrangThai"].ToString();
                }
            }
        }
        public DataTable LayLyDoXuat()
        {
            using (SqlConnection con = new SqlConnection(StaticContext.ConnectionString))
            {
                con.Open();
                string cmdText = " SELECT * FROM [CF_TrangThaiPhieuXuatKhac]";
                using (SqlCommand command = new SqlCommand(cmdText, con))
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    DataTable tb = new DataTable();
                    tb.Load(reader);
                    return tb;
                }
            }
        }

        public DataTable DanhSachChiTietPhieuXuatKhac_ID(string IDPhieuXuatKhac)
        {
            using (SqlConnection con = new SqlConnection(StaticContext.ConnectionString))
            {
                con.Open();
                string cmdText = "SELECT * FROM [CF_PhieuXuatKhac_ChiTiet] WHERE [IDPhieuXuatKhac] = '" + IDPhieuXuatKhac + "'";
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