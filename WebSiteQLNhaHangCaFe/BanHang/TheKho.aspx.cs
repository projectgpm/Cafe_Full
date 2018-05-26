using BanHang.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BanHang
{
    public partial class TheKho : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            LoadGrid();
        }
        private void LoadGrid()
        {
            dtTheKho data = new dtTheKho();
            gridLichSuKho.DataSource = data.LayDanhSach();
            gridLichSuKho.DataBind();
        }
    }
}