using BanHang.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BanHang
{
    public partial class TonKhoBanDau : System.Web.UI.Page
    {
        dtTonKhoNguyenLieu data = new dtTonKhoNguyenLieu();
        protected void Page_Load(object sender, EventArgs e)
        {
            LoadGrid();
        }

        private void LoadGrid()
        {
            data = new dtTonKhoNguyenLieu();
            gridDanhSach.DataSource = data.DanhSachTonKhoNguyenLieu();
            gridDanhSach.DataBind();

            dtLichSuTruyCap.ThemLichSu(Session["IDChiNhanh"].ToString(), Session["IDNhom"].ToString(), Session["IDNhanVien"].ToString(), "Tồn kho", "Truy cập hàng hóa tồn kho");
        }

        protected void btnXuat_Click(object sender, EventArgs e)
        {
            popup.ContentUrl = "~/TonKhoBanDau_In.aspx";
            popup.ShowOnPageLoad = true;
        }
    }
}