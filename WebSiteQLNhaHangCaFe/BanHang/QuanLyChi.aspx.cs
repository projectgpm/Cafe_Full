using BanHang.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BanHang
{
    public partial class QuanLyChi : System.Web.UI.Page
    {
        dtQuanLyChi data = new dtQuanLyChi();
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
            data = new dtQuanLyChi();
            gridDanhSach.DataSource = data.DanhSach(Session["IDChiNhanh"].ToString());
            gridDanhSach.DataBind();
        }

        protected void gridDanhSach_InitNewRow(object sender, DevExpress.Web.Data.ASPxDataInitNewRowEventArgs e)
        {
            e.NewValues["TienChi"] = "0";
            //e.NewValues["NgayChi"] = DateTime.Now.ToString();
        }

        protected void gridDanhSach_RowUpdating(object sender, DevExpress.Web.Data.ASPxDataUpdatingEventArgs e)
        {
            string ID = e.Keys[0].ToString();
            string LoaiChi = e.NewValues["LoaiChi"].ToString();
            string TienChi = e.NewValues["TienChi"].ToString();
            DateTime NgayChi =DateTime.Parse(e.NewValues["NgayChi"].ToString());
            data = new dtQuanLyChi();
            data.SuaThongTin(ID, LoaiChi, TienChi, NgayChi);
            e.Cancel = true;
            gridDanhSach.CancelEdit();
            LoadGrid();
        }

        protected void gridDanhSach_RowInserting(object sender, DevExpress.Web.Data.ASPxDataInsertingEventArgs e)
        {
            
            string LoaiChi = e.NewValues["LoaiChi"].ToString();
            string TienChi = e.NewValues["TienChi"].ToString();
            string IDChiNhanh = Session["IDChiNhanh"].ToString();
            DateTime NgayChi = DateTime.Parse(e.NewValues["NgayChi"].ToString());
            data = new dtQuanLyChi();
            data.ThemMoi(LoaiChi, TienChi, NgayChi, IDChiNhanh);
            e.Cancel = true;
            gridDanhSach.CancelEdit();
            LoadGrid();
        }

        protected void gridDanhSach_RowDeleting(object sender, DevExpress.Web.Data.ASPxDataDeletingEventArgs e)
        {
            string ID = e.Keys[0].ToString();
            data = new dtQuanLyChi();
            data.Xoa(ID);
            e.Cancel = true;
            gridDanhSach.CancelEdit();
            LoadGrid();
        }
    }
}