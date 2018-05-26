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
    public partial class BCXuatKhac_In : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string NgayBD = Request.QueryString["ngayBD"];
            string NgayKT = Request.QueryString["NgayKT"];
            string IDLyDo = Request.QueryString["IDLyDo"];
            string strLyDo = "Tất cả";

            if (Int32.Parse(IDLyDo) != -1)
            {
                dtPhieuXuatKhac dt = new dtPhieuXuatKhac();
                strLyDo = dt.lyDoXuat(IDLyDo);
            }

            string strNgay = DateTime.Parse(NgayBD).ToString("dd-MM-yyyy") + " - " + DateTime.Parse(NgayKT).ToString("dd-MM-yyyy");
            rpBCXuatKhac rp = new rpBCXuatKhac();
            rp.Parameters["IDLyDo"].Value = IDLyDo;
            rp.Parameters["IDLyDo"].Visible = false;
            rp.Parameters["strLyDo"].Value = strLyDo;
            rp.Parameters["strLyDo"].Visible = false;
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