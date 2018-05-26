using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace BanHang.Data
{
    public class dataHangHoa
    {
        public static string Dem_Max()
        {
            using (SqlConnection con = new SqlConnection(StaticContext.ConnectionString))
            {
                con.Open();
                int STTV = 0;
                string So;
                string GPM = "000000";
                string cmdText = "SELECT * FROM [CF_NguyenLieu]";
                using (SqlCommand command = new SqlCommand(cmdText, con))
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    DataTable tb = new DataTable();
                    tb.Load(reader);
                    STTV = tb.Rows.Count + 1;
                    int DoDaiHT = STTV.ToString().Length;
                    string DoDaiGPM = GPM.Substring(0, 4 - DoDaiHT);
                    So = DoDaiGPM + STTV;
                    return So;
                }
            }
        }
        public static bool KiemTraBarcode(string Barcode)
        {
            using (SqlConnection con = new SqlConnection(StaticContext.ConnectionString))
            {
                con.Open();
                string cmdText = "SELECT * FROM [CF_NguyenLieu_Barcode] WHERE Barcode = N'" + Barcode + "'";
                using (SqlCommand command = new SqlCommand(cmdText, con))
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    DataTable tb = new DataTable();
                    tb.Load(reader);
                    if (tb.Rows.Count != 0)
                    {
                        return false;
                    }
                    else return true;
                }
            }
        }
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
        
        public DataTable LayDanhSachCuaHang()
        {
            using (SqlConnection con = new SqlConnection(StaticContext.ConnectionString))
            {
                con.Open();
                string cmdText = " SELECT * FROM [CF_ChiNhanh] WHERE [DAXOA] = 0";
                using (SqlCommand command = new SqlCommand(cmdText, con))
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    DataTable tb = new DataTable();
                    tb.Load(reader);
                    return tb;
                }
            }
        }
        public void SuaDanhSachBarCode(object ID, List<string> BarCode)
        {
            using (SqlConnection myConnection = new SqlConnection(StaticContext.ConnectionString))
            {
                try
                {
                    myConnection.Open();
                    string cmdText = "DELETE FROM [CF_NguyenLieu_Barcode] WHERE [IDHangHoa] = @IDHangHoa";
                    using (SqlCommand myCommand = new SqlCommand(cmdText, myConnection))
                    {
                        myCommand.Parameters.AddWithValue("@IDHangHoa", ID);
                        myCommand.ExecuteNonQuery();
                    }
                    int KT = 0;
                    foreach (string barCode in BarCode)
                    {
                        if (KiemTraBarcode(barCode) == false)
                        {
                            KT = 1;
                            throw new Exception("Lỗi:Barcode đã tồn tại !!");
                        }
                    }
                    if (KT == 0)
                    {
                        ThemDanhSachBarCode(ID, BarCode);
                    }
                }
                catch (Exception e)
                {
                    throw new Exception("Lỗi: Quá trình cập nhật dữ liệu gặp lỗi, hãy tải lại trang");
                }
            }
        }
        public void SuaThongTinHangHoa(string ID, string MaHang, string TenHangHoa, string IDDonViTinh, float GiaMua, float GiaBan, string GhiChu, string HinhAnh)
        {
            using (SqlConnection myConnection = new SqlConnection(StaticContext.ConnectionString))
            {
                try
                {
                    myConnection.Open();
                    string strSQL = "UPDATE [CF_NguyenLieu] SET  [MaNguyenLieu] = @MaNguyenLieu, [TenNguyenLieu] = @TenNguyenLieu, [IDDonViTinh] = @IDDonViTinh, [GiaMua] = @GiaMua, [GiaBan] = @GiaBan, [GhiChu] = @GhiChu, [NhaCungCap] = @NhaCungCap, [NgayCapNhat] = getdate() WHERE [ID] = @ID";
                    using (SqlCommand myCommand = new SqlCommand(strSQL, myConnection))
                    {
                        myCommand.Parameters.AddWithValue("@ID", ID);
                        myCommand.Parameters.AddWithValue("@MaNguyenLieu", MaHang);
                        myCommand.Parameters.AddWithValue("@TenNguyenLieu", TenHangHoa);
                        myCommand.Parameters.AddWithValue("@IDDonViTinh", IDDonViTinh);
                        myCommand.Parameters.AddWithValue("@GiaMua", GiaMua);
                        myCommand.Parameters.AddWithValue("@GiaBan", GiaBan);
                        myCommand.Parameters.AddWithValue("@GhiChu", GhiChu);
                        myCommand.Parameters.AddWithValue("@NhaCungCap", HinhAnh);
                        myCommand.ExecuteNonQuery();
                    }
                }
                catch (Exception e)
                {
                    throw new Exception("Lỗi: Quá trình cập nhật dữ liệu gặp lỗi, hãy tải lại trang");
                }
            }
        }
        public void SuaThongTinHangHoaKHinh(string ID, string MaHang, string TenHangHoa, string IDDonViTinh, float GiaMua, float GiaBan, string GhiChu)
        {
            using (SqlConnection myConnection = new SqlConnection(StaticContext.ConnectionString))
            {
                try
                {
                    myConnection.Open();
                    string strSQL = "UPDATE [CF_NguyenLieu] SET  [MaNguyenLieu] = @MaNguyenLieu, [TenNguyenLieu] = @TenNguyenLieu, [IDDonViTinh] = @IDDonViTinh, [GiaMua] = @GiaMua, [GiaBan] = @GiaBan, [GhiChu] = @GhiChu, [NgayCapNhat] = getdate() WHERE [ID] = @ID";
                    using (SqlCommand myCommand = new SqlCommand(strSQL, myConnection))
                    {
                        myCommand.Parameters.AddWithValue("@ID", ID);
                        myCommand.Parameters.AddWithValue("@MaNguyenLieu", MaHang);
                        myCommand.Parameters.AddWithValue("@TenNguyenLieu", TenHangHoa);
                        myCommand.Parameters.AddWithValue("@IDDonViTinh", IDDonViTinh);
                        myCommand.Parameters.AddWithValue("@GiaMua", GiaMua);
                        myCommand.Parameters.AddWithValue("@GiaBan", GiaBan);
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
        public void ThemDanhSachBarCode(object IDHangHoa, List<string> ListBarCode)
        {
            using (SqlConnection myConnection = new SqlConnection(StaticContext.ConnectionString))
            {
                try
                {
                    myConnection.Open();
                    string cmdText = "INSERT INTO [CF_NguyenLieu_Barcode] ([IDHangHoa],[Barcode],[NgayCapNhat])" +
                             " VALUES(@IDHangHoa, @BarCode, getdate())";
                    using (SqlCommand myCommand = new SqlCommand(cmdText, myConnection))
                    {
                        myCommand.Parameters.AddWithValue("@IDHangHoa", IDHangHoa);
                        myCommand.Parameters.AddWithValue("@BarCode", "");
                        foreach (string barCode in ListBarCode)
                        {
                            myCommand.Parameters["@BarCode"].Value = barCode;
                            myCommand.ExecuteNonQuery();
                        }
                    }
                }
                catch (Exception e)
                {
                    throw new Exception("Lỗi: Quá trình cập nhật dữ liệu gặp lỗi, hãy tải lại trang");
                }
            }
        }
        public object ThemHangHoa(string MaHang, string TenHangHoa, string IDDonViTinh, float GiaMua, float GiaBan, string GhiChu, string HinhAnh)
        {
            using (SqlConnection myConnection = new SqlConnection(StaticContext.ConnectionString))
            {
                try
                {
                    object IDHangHoa = null;
                    myConnection.Open();
                    string cmdText = "INSERT INTO [CF_NguyenLieu] ([MaNguyenLieu], [TenNguyenLieu], [IDDonViTinh], [GiaMua], [GiaBan], [GhiChu], [NhaCungCap], [NgayCapNhat],[TrangThai])" +
                                     " OUTPUT INSERTED.ID" +
                                                       "   VALUES (@MaNguyenLieu, @TenNguyenLieu, @IDDonViTinh, @GiaMua, @GiaBan, @GhiChu, @NhaCungCap, getdate(),2)";
                    using (SqlCommand myCommand = new SqlCommand(cmdText, myConnection))
                    {
                        myCommand.Parameters.AddWithValue("@MaNguyenLieu", MaHang);
                        myCommand.Parameters.AddWithValue("@TenNguyenLieu", TenHangHoa);
                        myCommand.Parameters.AddWithValue("@IDDonViTinh", IDDonViTinh);
                        myCommand.Parameters.AddWithValue("@GiaMua", GiaMua);
                        myCommand.Parameters.AddWithValue("@GiaBan", GiaBan);
                        myCommand.Parameters.AddWithValue("@GhiChu", GhiChu);
                        myCommand.Parameters.AddWithValue("@NhaCungCap", HinhAnh);
                        IDHangHoa = myCommand.ExecuteScalar();
                    }
                    myConnection.Close();

                    return IDHangHoa;
                }
                catch
                {
                    throw new Exception("Lỗi: Quá trình thêm dữ liệu gặp lỗi");
                }
            }
        }
        public DataTable KiemTraHangHoa(string MaHang)
        {
            using (SqlConnection con = new SqlConnection(StaticContext.ConnectionString))
            {
                con.Open();
                string cmdText = " SELECT ID FROM [CF_NguyenLieu] WHERE [MaNguyenLieu] = '" + MaHang + "'";
                using (SqlCommand command = new SqlCommand(cmdText, con))
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    DataTable tb = new DataTable();
                    tb.Load(reader);
                    return tb;
                }
            }
        }
        public void XoaBarCode(int ID)
        {
            using (SqlConnection myConnection = new SqlConnection(StaticContext.ConnectionString))
            {
                try
                {
                    myConnection.Open();
                    string cmdText = "DELETE FROM [CF_NguyenLieu_Barcode] WHERE [ID] = @ID";
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
        public void ThemBarCode(object IDHangHoa, string BarCode)
        {
            using (SqlConnection myConnection = new SqlConnection(StaticContext.ConnectionString))
            {
                try
                {
                    myConnection.Open();
                    string cmdText = "INSERT INTO [CF_NguyenLieu_Barcode] ([IDHangHoa],[Barcode],[NgayCapNhat])" +
                                                                  " VALUES(@IDHangHoa, @BarCode, getdate())";
                    using (SqlCommand myCommand = new SqlCommand(cmdText, myConnection))
                    {
                        myCommand.Parameters.AddWithValue("@IDHangHoa", IDHangHoa);
                        myCommand.Parameters.AddWithValue("@BarCode", BarCode);
                        myCommand.ExecuteNonQuery();
                    }
                }
                catch (Exception e)
                {
                    throw new Exception("Lỗi: Quá trình cập nhật dữ liệu gặp lỗi, hãy tải lại trang");
                }
            }
        }
        public void CapNhatBarCode(int ID, object IDHangHoa, string BarCode)
        {
            using (SqlConnection myConnection = new SqlConnection(StaticContext.ConnectionString))
            {
                try
                {
                    myConnection.Open();
                    string cmdText = "UPDATE [CF_NguyenLieu_Barcode] SET [IDHangHoa] = @IDHangHoa, [BarCode] = @BarCode,[NgayCapNhat] = getdate() WHERE [ID] = @ID";
                    using (SqlCommand myCommand = new SqlCommand(cmdText, myConnection))
                    {
                        myCommand.Parameters.AddWithValue("@ID", ID);
                        myCommand.Parameters.AddWithValue("@BarCode", BarCode);
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
        public DataTable GetListBarCode(object ID)
        {
            DataTable dt = new DataTable();
            using (SqlConnection con = new SqlConnection(StaticContext.ConnectionString))
            {
                con.Open();
                string cmdText = "SELECT [ID], [Barcode], [NgayCapNhat] FROM [CF_NguyenLieu_Barcode] WHERE [IDHangHoa] = @IDHangHoa";
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
        public void XoaHangHoa(string ID)
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
                    strSQL = "DELETE [CF_NguyenLieu_Barcode] WHERE [IDHangHoa] = @ID";
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
        public DataTable LayDanhSachHangHoa(string HienThi)
        {
            using (SqlConnection con = new SqlConnection(StaticContext.ConnectionString))
            {
                con.Open();
                string cmdText = "SELECT TOP " + HienThi + " [CF_NguyenLieu].* FROM [CF_NguyenLieu] WHERE  CF_NguyenLieu.[DAXOA] = 0 AND [TrangThai] = 2 ORDER BY ID DESC ";
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