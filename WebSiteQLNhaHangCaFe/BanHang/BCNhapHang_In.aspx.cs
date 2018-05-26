using BanHang.Data;
using BanHang.Report;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BanHang
{
    public partial class BCNhapHang_In : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string NgayBD = Request.QueryString["ngayBD"];
            string NgayKT = Request.QueryString["NgayKT"];
            string IDNhaCC = Request.QueryString["IDNhaCC"];
            string strNhaCC = "Tất cả nhà cung cấp";

            if (Int32.Parse(IDNhaCC) != -1)
            {
                dtNhaCungCap dt = new dtNhaCungCap();
                strNhaCC = dt.LayTenNhaCungCap(IDNhaCC);
            }

            string strNgay = DateTime.Parse(NgayBD).ToString("dd-MM-yyyy") + " - " + DateTime.Parse(NgayKT).ToString("dd-MM-yyyy");
            rpBCNhapHang rp = new rpBCNhapHang();
            rp.Parameters["IDNhaCC"].Value = IDNhaCC;
            rp.Parameters["IDNhaCC"].Visible = false;
            rp.Parameters["strNhaCC"].Value = strNhaCC;
            rp.Parameters["strNhaCC"].Visible = false;
            rp.Parameters["strNgay"].Value = strNgay;
            rp.Parameters["strNgay"].Visible = false;
            rp.Parameters["NgayBD"].Value = NgayBD;
            rp.Parameters["NgayBD"].Visible = false;
            rp.Parameters["NgayKT"].Value = NgayKT;
            rp.Parameters["NgayKT"].Visible = false;
            viewerReport.Report = rp;
        }
    }
}