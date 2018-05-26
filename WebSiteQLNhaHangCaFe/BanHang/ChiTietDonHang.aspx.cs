using BanHang.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BanHang
{
    public partial class ChiTietDonHang : System.Web.UI.Page
    {
        dtDanhSachNhapHang data = new dtDanhSachNhapHang();
        protected void Page_Load(object sender, EventArgs e)
        {
            string IDDonHang = Request.QueryString["IDDonHang"];
            if (IDDonHang != null)
            {
                LoadGrid(IDDonHang.ToString());
            }
        }

        private void LoadGrid(string p)
        {
            data = new dtDanhSachNhapHang();
            gridChiTiet.DataSource = data.DanhSachChiTiet(p);
            gridChiTiet.DataBind();
        }
    }
}