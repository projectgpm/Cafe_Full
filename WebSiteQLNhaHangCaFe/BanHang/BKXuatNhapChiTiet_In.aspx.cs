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
    public partial class BKXuatNhapChiTiet_In : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string NgayBD = Request.QueryString["ngayBD"];
            string NgayKT = Request.QueryString["NgayKT"];
            string IDHangHoa = Request.QueryString["IDHangHoa"];
            string strHangHoa = "Tất cả";

            if (Int32.Parse(IDHangHoa) != -1)
            {
                dtHangHoa dt = new dtHangHoa();
                strHangHoa = dt.LayTenHangHoa(IDHangHoa);
            }

            string strNgay = DateTime.Parse(NgayBD).ToString("dd-MM-yyyy") + " - " + DateTime.Parse(NgayKT).ToString("dd-MM-yyyy");
            rpBKXuatNhapChiTiet rp = new rpBKXuatNhapChiTiet();
            rp.Parameters["IDHangHoa"].Value = IDHangHoa;
            rp.Parameters["IDHangHoa"].Visible = false;
            rp.Parameters["strHangHoa"].Value = strHangHoa;
            rp.Parameters["strHangHoa"].Visible = false;
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