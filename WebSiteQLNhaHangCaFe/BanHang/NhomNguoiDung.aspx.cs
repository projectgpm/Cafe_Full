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
    public partial class NhomNguoiDung : System.Web.UI.Page
    {
        dtNhomNguoiDung data = new dtNhomNguoiDung();
        protected void Page_Load(object sender, EventArgs e)
        {
           
             LoadGrid();
             if (!IsPostBack)
             {
                 if (Session["KTDangNhap"] != "GPM@2017")
                 {
                     Response.Redirect("DangNhap.aspx");
                 }
                 else
                 {
                     if (Int32.Parse(Session["IDNhanVien"].ToString()) != 1)
                         gridNhomNguoiDung.Columns["chucnang"].Visible = false;
                 }
             }
        }
        public void LoadGrid()
        {
            data = new dtNhomNguoiDung();
            gridNhomNguoiDung.DataSource = data.LayDanhSachNhomNguoiDung();
            gridNhomNguoiDung.DataBind();
        }

        protected void gridNhomNguoiDung_RowDeleting(object sender, DevExpress.Web.Data.ASPxDataDeletingEventArgs e)
        {
            int ID = Int32.Parse(e.Keys[0].ToString());
            data = new dtNhomNguoiDung();
            data.XoaNhomNguoiDung(ID);
            e.Cancel = true;
            gridNhomNguoiDung.CancelEdit();
            LoadGrid();

            dtLichSuTruyCap.ThemLichSu(Session["IDChiNhanh"].ToString(), Session["IDNhom"].ToString(), Session["IDNhanVien"].ToString(), "Nhóm người dùng", "Xóa nhóm người dùng: " + ID);
        }

        protected void gridNhomNguoiDung_RowInserting(object sender, DevExpress.Web.Data.ASPxDataInsertingEventArgs e)
        {
            data = new dtNhomNguoiDung();
            string MaNhom = e.NewValues["MaNhom"].ToString();
            string TenNhom = e.NewValues["TenNhom"].ToString();
            object IDNhomNguoiDung = data.ThemNhomNguoiDung(MaNhom,TenNhom);
            e.Cancel = true;
            gridNhomNguoiDung.CancelEdit();
            LoadGrid();

            dtLichSuTruyCap.ThemLichSu(Session["IDChiNhanh"].ToString(), Session["IDNhom"].ToString(), Session["IDNhanVien"].ToString(), "Nhóm người dùng", "Thêm nhóm người dùng: " + TenNhom);
         
        }

        protected void gridNhomNguoiDung_RowUpdating(object sender, DevExpress.Web.Data.ASPxDataUpdatingEventArgs e)
        {
            string ID = e.Keys["ID"].ToString();
            string MaNhom = e.NewValues["MaNhom"].ToString();
            string TenNhom = e.NewValues["TenNhom"].ToString();
            data.SuaThongTinNhomNguoiDung(Int32.Parse(ID),MaNhom, TenNhom);
            e.Cancel = true;
            gridNhomNguoiDung.CancelEdit();
            LoadGrid();

            dtLichSuTruyCap.ThemLichSu(Session["IDChiNhanh"].ToString(), Session["IDNhom"].ToString(), Session["IDNhanVien"].ToString(), "Nhóm người dùng", "Cập nhật nhóm người dùng: " + ID);
         
        }

        protected void gridNhomNguoiDung_InitNewRow(object sender, DevExpress.Web.Data.ASPxDataInitNewRowEventArgs e)
        {
            e.NewValues["MaNhom"] = dtNhomNguoiDung.Dem_Max();
        }
    }
}