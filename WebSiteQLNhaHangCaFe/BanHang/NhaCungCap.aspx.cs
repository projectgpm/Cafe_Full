using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using BanHang.Data;
using DevExpress.Web;

namespace BanHang
{
    public partial class NhaCungCap : System.Web.UI.Page
    {
        dtNhaCungCap data = new dtNhaCungCap();
        protected void Page_Load(object sender, EventArgs e)
        {
            
              LoadGrid();
        }
        public void LoadGrid()
        {
            data = new dtNhaCungCap();
            gridNhaCungCap.DataSource = data.LayDanhSachNhaCungCap();
            gridNhaCungCap.DataBind();
        }

        protected void gridNhaCungCap_RowDeleting(object sender, DevExpress.Web.Data.ASPxDataDeletingEventArgs e)
        {
            string ID = e.Keys[0].ToString();
            data = new dtNhaCungCap();
            data.XoaNhaCungCap(Int32.Parse(ID));
            e.Cancel = true;
            gridNhaCungCap.CancelEdit();
            LoadGrid();

            dtLichSuTruyCap.ThemLichSu(Session["IDChiNhanh"].ToString(), Session["IDNhom"].ToString(), Session["IDNhanVien"].ToString(), "Nhà cung cấp", "Xóa nhà cung cấp: " + ID);
        }

        protected void gridNhaCungCap_RowInserting(object sender, DevExpress.Web.Data.ASPxDataInsertingEventArgs e)
        {
            data = new dtNhaCungCap();
            string tenNhaCungCap = e.NewValues["TenNhaCungCap"].ToString();
            string dienThoai = e.NewValues["DienThoai"] == null ? "" : e.NewValues["DienThoai"].ToString();
            string fax = e.NewValues["Fax"] == null ? "" : e.NewValues["Fax"].ToString();
            string email = e.NewValues["Email"] == null ? "" : e.NewValues["Email"].ToString();
            string diaChi = e.NewValues["DiaChi"] == null ? "" : e.NewValues["DiaChi"].ToString();
            string nguoiLienHe = e.NewValues["NguoiLienHe"] == null ? "" : e.NewValues["NguoiLienHe"].ToString();
            string maSoThue = e.NewValues["MaSoThue"] == null ? "" : e.NewValues["MaSoThue"].ToString();
            string linhVucKinhDoanh = e.NewValues["LinhVucKinhDoanh"] == null ? "" : e.NewValues["LinhVucKinhDoanh"].ToString();
            //string loGo = ""; //e.NewValues["TenNganhHang"].ToString();
            DateTime NgayCapNhat = DateTime.Today.Date;
            string ghiChu = e.NewValues["GhiChu"] == null ? "" : e.NewValues["GhiChu"].ToString();
            data.ThemNhaCungCap(tenNhaCungCap, dienThoai, fax, email, diaChi, nguoiLienHe, maSoThue, linhVucKinhDoanh, NgayCapNhat, ghiChu);
            e.Cancel = true;
            gridNhaCungCap.CancelEdit();
            LoadGrid();

            dtLichSuTruyCap.ThemLichSu(Session["IDChiNhanh"].ToString(), Session["IDNhom"].ToString(), Session["IDNhanVien"].ToString(), "Nhà cung cấp", "Thêm nhà cung cấp: " + tenNhaCungCap);
        }

        protected void gridNhaCungCap_RowUpdating(object sender, DevExpress.Web.Data.ASPxDataUpdatingEventArgs e)
        {
            string ID = e.Keys["ID"].ToString();
            string tenNhaCungCap = e.NewValues["TenNhaCungCap"].ToString();
            string dienThoai = e.NewValues["DienThoai"] == null ? "" : e.NewValues["DienThoai"].ToString();
            string fax = e.NewValues["Fax"] == null ? "" : e.NewValues["Fax"].ToString();
            string email = e.NewValues["Email"] == null ? "" : e.NewValues["Email"].ToString();
            string diaChi = e.NewValues["DiaChi"] == null ? "" : e.NewValues["DiaChi"].ToString();
            string nguoiLienHe = e.NewValues["NguoiLienHe"] == null ? "" : e.NewValues["NguoiLienHe"].ToString();
            string maSoThue = e.NewValues["MaSoThue"] == null ? "" : e.NewValues["MaSoThue"].ToString();
            string linhVucKinhDoanh = e.NewValues["LinhVucKinhDoanh"] == null ? "" : e.NewValues["LinhVucKinhDoanh"].ToString();
            //string loGo = ""; //e.NewValues["TenNganhHang"].ToString();
            DateTime NgayCapNhat = DateTime.Today.Date;
            string ghiChu = e.NewValues["GhiChu"] == null ? "" : e.NewValues["GhiChu"].ToString();
            data.SuaThongTinNhaCungCap(Int32.Parse(ID), tenNhaCungCap, dienThoai, fax, email, diaChi, nguoiLienHe, maSoThue, linhVucKinhDoanh, NgayCapNhat, ghiChu);
            e.Cancel = true;
            gridNhaCungCap.CancelEdit();
            LoadGrid();

            dtLichSuTruyCap.ThemLichSu(Session["IDChiNhanh"].ToString(), Session["IDNhom"].ToString(), Session["IDNhanVien"].ToString(), "Nhà cung cấp", "Cập nhật nhà cung cấp: " + ID);
        }
    }
}