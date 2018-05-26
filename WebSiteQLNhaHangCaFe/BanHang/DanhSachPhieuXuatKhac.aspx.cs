using BanHang.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BanHang
{
    public partial class DanhSachPhieuXuatKhac : System.Web.UI.Page
    {
        dtPhieuXuatKhac data = new dtPhieuXuatKhac();
        protected void Page_Load(object sender, EventArgs e)
        {
            LoadGrid();
        }

        private void LoadGrid()
        {
            data = new dtPhieuXuatKhac();
            gridPhieuXuatKhac.DataSource = data.DanhSachPhieuXuatKhac();
            gridPhieuXuatKhac.DataBind();

            dtLichSuTruyCap.ThemLichSu(Session["IDChiNhanh"].ToString(), Session["IDNhom"].ToString(), Session["IDNhanVien"].ToString(), "Danh sách phiếu xuất khác", "Truy cập");
        }
    }
}