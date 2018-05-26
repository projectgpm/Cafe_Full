using BanHang.Data;
using DevExpress.Web;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BanHang
{
    public partial class QuanLyGio : System.Web.UI.Page
    {
        dtGio data = new dtGio();
        protected void Page_Load(object sender, EventArgs e)
        {
            LoadGrid();
        }

        private void LoadGrid()
        {
            data = new dtGio();
            gridDanhSach.DataSource = data.DanhSach();
            gridDanhSach.DataBind();

            dtLichSuTruyCap.ThemLichSu(Session["IDChiNhanh"].ToString(), Session["IDNhom"].ToString(), Session["IDNhanVien"].ToString(), "Quản lý giờ", "Truy cập");
        }

        protected void gridDanhSach_InitNewRow(object sender, DevExpress.Web.Data.ASPxDataInitNewRowEventArgs e)
        {
            e.NewValues["MaGio"] = dtGio.Dem_Max();
        }

        protected void gridDanhSach_RowUpdating(object sender, DevExpress.Web.Data.ASPxDataUpdatingEventArgs e)
        {
            string ID = e.Keys[0].ToString();
            string GioBatDau = DateTime.Parse(e.NewValues["GioBatDau"].ToString()).ToString("hh:mm tt");
            string GioKetThuc = DateTime.Parse(e.NewValues["GioKetThuc"].ToString()).ToString("hh:mm tt");
            string TyLe = e.NewValues["TyLe"].ToString();
            data = new dtGio();
            data.Sua(ID,  DateTime.Parse(GioBatDau),  DateTime.Parse(GioKetThuc), TyLe);
            e.Cancel = true;
            gridDanhSach.CancelEdit();
            LoadGrid();

            
        }

        protected void gridDanhSach_RowInserting(object sender, DevExpress.Web.Data.ASPxDataInsertingEventArgs e)
        {
            string MaGio = dtGio.Dem_Max();
            string GioBatDau = DateTime.Parse(e.NewValues["GioBatDau"].ToString()).ToString("hh:mm tt");
            string GioKetThuc = DateTime.Parse(e.NewValues["GioKetThuc"].ToString()).ToString("hh:mm tt");
            string TyLe = e.NewValues["TyLe"].ToString();
            data = new dtGio();
            data.Them(MaGio, DateTime.Parse(GioBatDau),  DateTime.Parse(GioKetThuc), Int32.Parse(TyLe));
            e.Cancel = true;
            gridDanhSach.CancelEdit();
            LoadGrid();
        }

        protected void gridDanhSach_RowDeleting(object sender, DevExpress.Web.Data.ASPxDataDeletingEventArgs e)
        {
            string ID = e.Keys[0].ToString();
            data = new dtGio();
            data.Xoa(ID);
            e.Cancel = true;
            gridDanhSach.CancelEdit();
            LoadGrid();
        }

    }
}