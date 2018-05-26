using BanHang.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BanHang
{
    public partial class QuanLyKhuVuc : System.Web.UI.Page
    {
        dtKhuVuc data = new dtKhuVuc();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["KTDangNhap"] != "GPM@2017")
            {
                Response.Redirect("DangNhap.aspx");
            }
            else
            {
               // if (Session["IDNhanVien"].ToString() != "1")
               // {
                    //gridDanhSach.Columns["chucnang"].Visible = false;
                    gridDanhSach.Columns["chucnangChiNhanh"].Visible = false;
                //}
                LoadGrid();
            }
        }

        private void LoadGrid()
        {
            data = new dtKhuVuc();
            gridDanhSach.DataSource = data.DanhSach(Session["IDChiNhanh"].ToString());
            gridDanhSach.DataBind();
        }

        protected void gridDanhSach_RowUpdating(object sender, DevExpress.Web.Data.ASPxDataUpdatingEventArgs e)
        {
            string ID = e.Keys[0].ToString();
            string TenKhuVuc = e.NewValues["TenKhuVuc"].ToString();
            string KyHieu = e.NewValues["KyHieu"].ToString();
            //string TyLe = e.NewValues["GiaKhuVuc"].ToString();
            string IDChiNhanh = Session["IDChiNhanh"].ToString();
            string IDBangGia = e.NewValues["IDBangGia"].ToString();
            string GhiChu = e.NewValues["GhiChu"] == null ? "" : e.NewValues["GhiChu"].ToString();
            data = new dtKhuVuc();
            data.Sua(ID, GhiChu, TenKhuVuc, "0", IDChiNhanh, KyHieu, IDBangGia);
            e.Cancel = true;
            gridDanhSach.CancelEdit();
            LoadGrid();
            dtLichSuTruyCap.ThemLichSu(Session["IDChiNhanh"].ToString(), Session["IDNhom"].ToString(), Session["IDNhanVien"].ToString(), "Quản lý khu vực", "Cập nhật khu vực: " + ID);
        }

        protected void gridDanhSach_RowInserting(object sender, DevExpress.Web.Data.ASPxDataInsertingEventArgs e)
        {
            string IDChiNhanh = Session["IDChiNhanh"].ToString();
            string KyHieu = e.NewValues["KyHieu"].ToString();
            string MaKhuVuc = "1";
            string TenKhuVuc = e.NewValues["TenKhuVuc"].ToString();
            string IDBangGia = e.NewValues["IDBangGia"].ToString();
            string GhiChu = e.NewValues["GhiChu"] == null ? "" : e.NewValues["GhiChu"].ToString();
            data = new dtKhuVuc();
            data.Them(MaKhuVuc, TenKhuVuc, "0", IDChiNhanh, GhiChu, KyHieu, IDBangGia);
            e.Cancel = true;
            gridDanhSach.CancelEdit();
            LoadGrid();
            dtLichSuTruyCap.ThemLichSu(Session["IDChiNhanh"].ToString(), Session["IDNhom"].ToString(), Session["IDNhanVien"].ToString(), "Quản lý khu vực", "Thêm khu vực: " + TenKhuVuc );
        }

        protected void gridDanhSach_RowDeleting(object sender, DevExpress.Web.Data.ASPxDataDeletingEventArgs e)
        {
            string ID = e.Keys[0].ToString();
            data = new dtKhuVuc();
            data.Xoa(ID);
            e.Cancel = true;
            gridDanhSach.CancelEdit();
            LoadGrid();
            dtLichSuTruyCap.ThemLichSu(Session["IDChiNhanh"].ToString(), Session["IDNhom"].ToString(), Session["IDNhanVien"].ToString(), "Quản lý khu vực", "Xóa khu vực: " + ID);
        }
    }
}