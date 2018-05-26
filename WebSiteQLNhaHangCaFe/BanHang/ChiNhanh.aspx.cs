using BanHang.Data;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BanHang
{
    public partial class ChiNhanh : System.Web.UI.Page
    {
        dtChiNhanh data = new dtChiNhanh();
        private static Random random = new Random();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["KTDangNhap"] != "GPM@2017" || Session["IDNhanVien"].ToString() != "1")
                {
                    Response.Redirect("DangNhap.aspx");
                }
                else
                {
                    LoadGrid();
                }
            }
        }

        private void LoadGrid()
        {
            data = new dtChiNhanh();
            gridChiNhanh.DataSource = data.LayDanhSach();
            gridChiNhanh.DataBind();
        }

        protected void gridChiNhanh_InitNewRow(object sender, DevExpress.Web.Data.ASPxDataInitNewRowEventArgs e)
        {
            e.NewValues["MaChiNhanh"] = dtChiNhanh.Dem_Max();
        }

        protected void gridChiNhanh_RowDeleting(object sender, DevExpress.Web.Data.ASPxDataDeletingEventArgs e)
        {
            string ID = e.Keys[0].ToString();
            data = new dtChiNhanh();
            data.XoaChiNhanh(ID);// xóa all dữ liệu thuộc về chi nhánh
            e.Cancel = true;
            gridChiNhanh.CancelEdit();
            LoadGrid();

            dtLichSuTruyCap.ThemLichSu(Session["IDChiNhanh"].ToString(), Session["IDNhom"].ToString(), Session["IDNhanVien"].ToString(), "Chi nhánh", "Xóa chi nhánh ID: " + ID);
        }

        protected void gridChiNhanh_RowInserting(object sender, DevExpress.Web.Data.ASPxDataInsertingEventArgs e)
        {
            string MaChiNhanh = dtChiNhanh.Dem_Max();
            string TenChiNhanh = e.NewValues["TenChiNhanh"].ToString();
            string DienThoai = e.NewValues["DienThoai"] == null ? "" : e.NewValues["DienThoai"].ToString();
            string Email = e.NewValues["Email"] == null ? "" : e.NewValues["Email"].ToString();
            string DiaChi = e.NewValues["DiaChi"] == null ? "" : e.NewValues["DiaChi"].ToString();
            DateTime NgayMo = DateTime.Parse(e.NewValues["NgayMo"].ToString());
            string DuLieuMau = e.NewValues["DuLieuMau"] == null ? "0" : "1";
            string Key = RandomString(5) + "-" + RandomString(5) + "-" + RandomString(5) + "-" + RandomString(5) + "-" + RandomString(5);
            data = new dtChiNhanh();
            object ID = data.ThemChiNhanh(MaChiNhanh, TenChiNhanh, DienThoai, DiaChi, NgayMo, DuLieuMau, Key, Email);
            if (ID != null)
            {
                // tạo key kích hoạt
                data = new dtChiNhanh();
                data.ThemKeyKichHoat(Key,ID.ToString());

                // Tạo bảng giá
                dtBangGia dtBangGia = new dtBangGia();
                object IDBangGia = dtBangGia.ThemMoi("Bảng Giá Thường", ID.ToString());

                // tạo khu vực
                dtKhuVuc dtKhuVuc = new dtKhuVuc();
                object IDKhuVuc = dtKhuVuc.Them("", "Khu A", "0", ID.ToString(), TenChiNhanh, "A", IDBangGia.ToString());

                //tạo tài khoản
                dtQuanTriNguoiDung dtNguoiDung = new dtQuanTriNguoiDung();
                if (dtQuanTriNguoiDung.KiemTraNguoiDung(DienThoai.Trim()) != -1)
                {
                    throw new Exception("Lỗi: Tên đăng nhập đã tồn tại");
                }
                else
                {
                    dtNguoiDung.ThemNguoiDung(dtQuanTriNguoiDung.Dem_Max(), "Quản trị", DienThoai, 1, DienThoai, dtSetting.GetSHA1HashData(DienThoai), Email, ID.ToString());
                    dtNguoiDung.ThemNguoiDung(dtQuanTriNguoiDung.Dem_Max(), "Thu ngân", "BH." + DienThoai, 2, DienThoai, dtSetting.GetSHA1HashData(DienThoai), Email, ID.ToString());
                }


                if (DuLieuMau == "1")
                {
                    //tạo dữ liệu mẫu, lấy Chi Nhánh 1 ra làm

                    //thêm đVT
                    dtDonViTinh dtDVT = new dtDonViTinh();
                    DataTable tbdvt = dtDVT.LayDanhSachDonViTinh("1");
                    foreach (DataRow dr in tbdvt.Rows)
                    {
                        dtDVT.ThemDonViTinh(dr["TenDonViTinh"].ToString(), ID.ToString());
                    }

                    //Thêm nhóm hàng
                    dtNhomHangHoa dtNhomHang = new dtNhomHangHoa();
                    DataTable tbNhomHang = dtNhomHang.DanhSach("1");
                    foreach (DataRow dr1 in tbNhomHang.Rows)
                    {
                        object IDNhomHangMoi = dtNhomHang.Them(dtNhomHangHoa.Dem_Max(), dr1["TenNhom"].ToString(), "", ID.ToString());
                        //Thêm hàng hóa
                        dtHangHoa dtHH = new dtHangHoa();
                        DataTable tbHH = dtHH.DanhSachHangHoa_IDnhomHang(dr1["ID"].ToString(), "1");
                        foreach (DataRow dr in tbHH.Rows)
                        {
                            string IDDVTCU = dr["IDDonViTinh"].ToString();
                            
                            object IDHH = dtHH.ThemHangHoa(dtHangHoa.Dem_Max(), dr["TenHangHoa"].ToString(), dr["GiaBan"].ToString(), dtDonViTinh.LayIDDVT_Moi(IDDVTCU,ID.ToString()), IDNhomHangMoi.ToString(), dr["GhiChu"].ToString(), ID.ToString());
                            if (IDHH != null)
                            {
                                //thêm vào bảng giá
                                dtBangGia bg = new dtBangGia();
                                bg.ThemIDHangHoaVaoChiTietGia(IDHH.ToString(), IDBangGia, dr["GiaBan"].ToString(), ID.ToString());
                            }
                        }
                    }

                    //thêm  30 bàn mẫu
                    for (int i = 1; i <= 30; i++)
                    {
                        dtBan dtB = new dtBan();
                        dtB.Them("", "A - " + i, IDKhuVuc.ToString(), ID.ToString());
                    }
                }
            }
            e.Cancel = true;
            gridChiNhanh.CancelEdit();
            LoadGrid();

            dtLichSuTruyCap.ThemLichSu(Session["IDChiNhanh"].ToString(), Session["IDNhom"].ToString(), Session["IDNhanVien"].ToString(), "Chi nhánh", "Thêm chi nhánh: " + TenChiNhanh);
        }
        public static string RandomString(int length)
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            return new string(Enumerable.Repeat(chars, length)
              .Select(s => s[random.Next(s.Length)]).ToArray());
        }
        protected void gridChiNhanh_RowUpdating(object sender, DevExpress.Web.Data.ASPxDataUpdatingEventArgs e)
        {
            string ID = e.Keys[0].ToString();
            string MaChiNhanh = e.NewValues["MaChiNhanh"].ToString();
            string TenChiNhanh = e.NewValues["TenChiNhanh"].ToString();
            string DienThoai = e.NewValues["DienThoai"] == null ? "" : e.NewValues["DienThoai"].ToString();
            string DiaChi = e.NewValues["DiaChi"] == null ? "" : e.NewValues["DiaChi"].ToString();
            DateTime NgayMo = DateTime.Parse(e.NewValues["NgayMo"].ToString());
            string DuLieuMau = e.NewValues["DuLieuMau"] == null ? "0" : "1";
            string Email = e.NewValues["Email"] == null ? "" : e.NewValues["Email"].ToString();
            data = new dtChiNhanh();
            data.SuaChiNhanh(ID, MaChiNhanh, TenChiNhanh, DienThoai, DiaChi, NgayMo, Email, DuLieuMau);
            e.Cancel = true;
            gridChiNhanh.CancelEdit();
            LoadGrid();
            dtLichSuTruyCap.ThemLichSu(Session["IDChiNhanh"].ToString(), Session["IDNhom"].ToString(), Session["IDNhanVien"].ToString(), "Chi nhánh", "Cập nhật chi nhánh: " + ID);
        }
    }
}