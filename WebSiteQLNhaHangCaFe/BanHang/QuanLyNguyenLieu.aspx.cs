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
    public partial class QuanLyNguyenLieu : System.Web.UI.Page
    {
        dtNguyenLieu data = new dtNguyenLieu();

        protected void Page_Load(object sender, EventArgs e)
        {
            LoadGrid();
        }

        private void LoadGrid()
        {
            data = new dtNguyenLieu();
            gridDanhSach.DataSource = data.DanhSach();
            gridDanhSach.DataBind();
        }

        protected void gridDanhSach_InitNewRow(object sender, DevExpress.Web.Data.ASPxDataInitNewRowEventArgs e)
        {
            e.NewValues["MaNguyenLieu"] = dtNguyenLieu.Dem_Max();
         //   e.NewValues["GiaMua"] = "0";
            e.NewValues["GiaBan"] = "0";
        }

        protected void gridDanhSach_RowDeleting(object sender, DevExpress.Web.Data.ASPxDataDeletingEventArgs e)
        {
            string ID = e.Keys[0].ToString();
            data = new dtNguyenLieu();
            data.Xoa(ID);
            e.Cancel = true;
            gridDanhSach.CancelEdit();
            LoadGrid();
            dtLichSuTruyCap.ThemLichSu(Session["IDChiNhanh"].ToString(), Session["IDNhom"].ToString(), Session["IDNhanVien"].ToString(), "Quản lý nguyên liệu", "Xóa nguyên liệu: " + ID);
        }

        protected void gridDanhSach_RowInserting(object sender, DevExpress.Web.Data.ASPxDataInsertingEventArgs e)
        {
            string MaNguyenLieu = e.NewValues["MaNguyenLieu"].ToString();
            string TenNguyenLieu = e.NewValues["TenNguyenLieu"].ToString();
            string GiaMua = "0";
            string NhaCungCap = "";
            string GhiChu = e.NewValues["GhiChu"] == null ? "" : e.NewValues["GhiChu"].ToString();
            string IDDonViTinh = e.NewValues["IDDonViTinh"].ToString();
            string TrangThai = "1";
            string GiaBan = e.NewValues["GiaBan"].ToString();
            data = new dtNguyenLieu();

            object ID = data.Them(MaNguyenLieu, TenNguyenLieu, NhaCungCap, GhiChu, IDDonViTinh, GiaMua, TrangThai, GiaBan);
            if (ID != null)
            {
                data = new dtNguyenLieu();
                DataTable dt = data.DanhSachChiNhanh();
                foreach (DataRow dr in dt.Rows)
                {
                    string IDChiNhanh = dr["ID"].ToString();
                    data = new dtNguyenLieu();
                    data.ThemNguyenLieuTonKho(ID.ToString(), IDChiNhanh, MaNguyenLieu);
                }
            }
            e.Cancel = true;
            gridDanhSach.CancelEdit();
            LoadGrid();

            dtLichSuTruyCap.ThemLichSu(Session["IDChiNhanh"].ToString(), Session["IDNhom"].ToString(), Session["IDNhanVien"].ToString(), "Quản lý nguyên liệu", "Thêm nguyên liệu: " + TenNguyenLieu);
        }

        protected void gridDanhSach_RowUpdating(object sender, DevExpress.Web.Data.ASPxDataUpdatingEventArgs e)
        {
            string ID = e.Keys[0].ToString();
            string MaNguyenLieu = e.NewValues["MaNguyenLieu"].ToString();
            string IDDonViTinh = e.NewValues["IDDonViTinh"].ToString();
            string TenNguyenLieu = e.NewValues["TenNguyenLieu"].ToString();
            string NhaCungCap = "" ;
            string GhiChu = e.NewValues["GhiChu"] == null ? "" : e.NewValues["GhiChu"].ToString();
            string GiaMua = "0";
            string GiaBan = e.NewValues["GiaBan"].ToString();
            string TrangThai = "1";
            data = new dtNguyenLieu();


            float GiaCu = data.LaySoTienCu(ID);
            if (GiaCu != float.Parse(GiaBan))
                dtThayDoiGia.ThemLichSu(Session["IDNhanVien"].ToString(), MaNguyenLieu, TenNguyenLieu, IDDonViTinh, GiaCu + "", GiaBan, Session["IDChiNhanh"].ToString());

            data.Sua(ID, MaNguyenLieu, TenNguyenLieu, NhaCungCap, GhiChu, IDDonViTinh, GiaMua, TrangThai, GiaBan);
            e.Cancel = true;
            gridDanhSach.CancelEdit();
            LoadGrid();

            dtLichSuTruyCap.ThemLichSu(Session["IDChiNhanh"].ToString(), Session["IDNhom"].ToString(), Session["IDNhanVien"].ToString(), "Quản lý nguyên liệu", "Cập nhật nguyên liệu: " + TenNguyenLieu);
        }
    }
}