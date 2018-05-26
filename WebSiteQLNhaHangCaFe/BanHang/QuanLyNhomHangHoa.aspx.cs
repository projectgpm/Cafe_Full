using BanHang.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BanHang
{
    public partial class QuanLyNhomHangHoa : System.Web.UI.Page
    {
        dtNhomHangHoa data = new dtNhomHangHoa();
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

        private void LoadGrid()
        {
            data = new dtNhomHangHoa();
            gridDanhSach.DataSource = data.DanhSach(Session["IDChiNhanh"].ToString());
            gridDanhSach.DataBind();
        }

        protected void gridDanhSach_InitNewRow(object sender, DevExpress.Web.Data.ASPxDataInitNewRowEventArgs e)
        {
           // e.NewValues["MaNhom"] = dtNhomHangHoa.Dem_Max();
        }

        protected void gridDanhSach_RowDeleting(object sender, DevExpress.Web.Data.ASPxDataDeletingEventArgs e)
        {
            string ID = e.Keys[0].ToString();
            data = new dtNhomHangHoa();
            data.Xoa(ID);
            e.Cancel = true;
            gridDanhSach.CancelEdit();
            LoadGrid();
            dtLichSuTruyCap.ThemLichSu(Session["IDChiNhanh"].ToString(), Session["IDNhom"].ToString(), Session["IDNhanVien"].ToString(), "Quản lý nhóm hàng hóa", "Xóa nhóm hàng hóa: " + ID);
        }

        protected void gridDanhSach_RowInserting(object sender, DevExpress.Web.Data.ASPxDataInsertingEventArgs e)
        {
            string MaNhom = "";
            string TenNhom = e.NewValues["TenNhom"].ToString();
            string GhiChu = e.NewValues["GhiChu"] == null ? "" : e.NewValues["GhiChu"].ToString();
            string IDChiNhanh = Session["IDChiNhanh"].ToString();
            data = new dtNhomHangHoa();
            data.Them(MaNhom, TenNhom, GhiChu, IDChiNhanh);
            e.Cancel = true;
            gridDanhSach.CancelEdit();
            LoadGrid();
            dtLichSuTruyCap.ThemLichSu(Session["IDChiNhanh"].ToString(), Session["IDNhom"].ToString(), Session["IDNhanVien"].ToString(), "Quản lý nhóm hàng hóa", "Thêm nhóm hàng hóa: " + TenNhom);
        }

        protected void gridDanhSach_RowUpdating(object sender, DevExpress.Web.Data.ASPxDataUpdatingEventArgs e)
        {
            string ID = e.Keys[0].ToString();
            string MaNhom = "";
            string TenNhom = e.NewValues["TenNhom"].ToString();
            string GhiChu = e.NewValues["GhiChu"] == null ? "" : e.NewValues["GhiChu"].ToString();
            data = new dtNhomHangHoa();
            data.Sua(ID,MaNhom, TenNhom, GhiChu);
            e.Cancel = true;
            gridDanhSach.CancelEdit();
            LoadGrid();
            dtLichSuTruyCap.ThemLichSu(Session["IDChiNhanh"].ToString(), Session["IDNhom"].ToString(), Session["IDNhanVien"].ToString(), "Quản lý nhóm hàng hóa", "Cập nhật nhóm: " + ID);
        }
    }
}