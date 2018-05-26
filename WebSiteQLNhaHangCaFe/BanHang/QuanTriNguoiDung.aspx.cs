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
    public partial class QuanTriNguoiDung : System.Web.UI.Page
    {
        dtQuanTriNguoiDung data = new dtQuanTriNguoiDung();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["KTDangNhap"] != "GPM@2017")
            {
                Response.Redirect("DangNhap.aspx");
            }
            else
            {
                LoadGrid(); 
            }
            
        }
        public void LoadGrid()
        {
            data = new dtQuanTriNguoiDung();
            gridQuanTriNguoiDung.DataSource = data.LayDanhSachNguoiDung(Session["IDChiNhanh"].ToString());
            gridQuanTriNguoiDung.DataBind();
        }
        protected void gridQuanTriNguoiDung_RowDeleting(object sender, DevExpress.Web.Data.ASPxDataDeletingEventArgs e)
        {
            string ID = e.Keys[0].ToString();
            data = new dtQuanTriNguoiDung();
            data.XoaNguoiDung(Int32.Parse(ID));
            e.Cancel = true;
            gridQuanTriNguoiDung.CancelEdit();
            LoadGrid();
            dtLichSuTruyCap.ThemLichSu(Session["IDChiNhanh"].ToString(), Session["IDNhom"].ToString(), Session["IDNhanVien"].ToString(), "Quản lý người dùng", "Xóa người dùng: " + ID);
        }

        protected void gridQuanTriNguoiDung_RowInserting(object sender, DevExpress.Web.Data.ASPxDataInsertingEventArgs e)
        {

            data = new dtQuanTriNguoiDung();
            string MaNhanVien = dtQuanTriNguoiDung.Dem_Max();
            string TenNguoiDung = e.NewValues["TenNguoiDung"].ToString();
            string IDChiNhanh = Session["IDChiNhanh"].ToString();
            int IDNhomNguoiDung = Int32.Parse(e.NewValues["IDNhomNguoiDung"].ToString());
            string Email = "";
            string SDT = e.NewValues["SDT"].ToString();
            string MatKhau = "1";
            MatKhau = dtSetting.GetSHA1HashData(MatKhau);
            string TenDangNhap = e.NewValues["TenDangNhap"].ToString().ToUpper();

            if (dtQuanTriNguoiDung.KiemTraNguoiDung(TenDangNhap.Trim()) != -1)
            {
                throw new Exception("Lỗi: Tên đăng nhập đã tồn tại");
            }
            else
            {
                data.ThemNguoiDung(MaNhanVien, TenNguoiDung, TenDangNhap, IDNhomNguoiDung, SDT, MatKhau, Email, IDChiNhanh);

            }
            e.Cancel = true;
            gridQuanTriNguoiDung.CancelEdit();
            LoadGrid();

            dtLichSuTruyCap.ThemLichSu(Session["IDChiNhanh"].ToString(), Session["IDNhom"].ToString(), Session["IDNhanVien"].ToString(), "Quản lý người dùng", "Thêm người dùng: " + TenNguoiDung);
        }

        protected void gridQuanTriNguoiDung_RowUpdating(object sender, DevExpress.Web.Data.ASPxDataUpdatingEventArgs e)
        {
            string ID = e.Keys["ID"].ToString();
            string TenNguoiDung = e.NewValues["TenNguoiDung"].ToString();
            int IDNhomNguoiDung = Int32.Parse(e.NewValues["IDNhomNguoiDung"].ToString());
            string IDChiNhanh = Session["IDChiNhanh"].ToString();
            string SDT = e.NewValues["SDT"].ToString();
            string Email = "";
            string TenDangNhap = e.NewValues["TenDangNhap"].ToString().ToUpper();
            if (dtQuanTriNguoiDung.KT_Tendangnhap_CapNhat(TenDangNhap.Trim(), ID) == -1)
            {
                if (dtQuanTriNguoiDung.KiemTraNguoiDung(TenDangNhap.Trim()) == 1)
                {
                    throw new Exception("Lỗi: Tên đăng nhập đã tồn tại");
                }
                else
                {
                    data.SuaNguoiDung(Int32.Parse(ID), TenNguoiDung, TenDangNhap, IDNhomNguoiDung, SDT, Email, IDChiNhanh);
                  
                }
            }
            else
            {
                data.SuaNguoiDung(Int32.Parse(ID), TenNguoiDung, TenDangNhap, IDNhomNguoiDung, SDT, Email, IDChiNhanh);
               
            }
            e.Cancel = true;
            gridQuanTriNguoiDung.CancelEdit();
            LoadGrid();

            dtLichSuTruyCap.ThemLichSu(Session["IDChiNhanh"].ToString(), Session["IDNhom"].ToString(), Session["IDNhanVien"].ToString(), "Quản lý người dùng", "Cập nhật người dùng: " + ID);
        }
    }
}