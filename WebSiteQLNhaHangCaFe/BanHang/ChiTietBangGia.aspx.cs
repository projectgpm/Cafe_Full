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
    public partial class ChiTietBangGia : System.Web.UI.Page
    {
        dtBangGia data = new dtBangGia();
        protected void Page_Load(object sender, EventArgs e)
        {
            string IDBangGia = Request.QueryString["IDBangGia"];
            if (IDBangGia != null)
            {
                LoadGrid(IDBangGia);
            }
        }
        private void LoadGrid(string IDBangGia)
        {
            data = new dtBangGia();
            gridChiTietPhieuKiemKho.DataSource = data.DanhSachChiTiet(IDBangGia);
            gridChiTietPhieuKiemKho.DataBind();
        }
        protected void gridChiTietPhieuKiemKho_RowUpdating(object sender, DevExpress.Web.Data.ASPxDataUpdatingEventArgs e)
        {
            string ID = e.Keys[0].ToString();
            string GiaMoi = e.NewValues["GiaMoi"] == null ? "0" : e.NewValues["GiaMoi"].ToString();
            dtHangHoa dt = new dtHangHoa();
            data = new dtBangGia();

            DataTable da = dt.LayDanhSachHangHoa_MaHang(e.NewValues["MaHangHoa"].ToString());
            if (da.Rows.Count != 0)
            {

                DataRow dr = da.Rows[0];
                float GiaCu = dt.LaySoTienCu_ChiTietGia(ID);
                if (float.Parse(GiaMoi) != GiaCu)
                    dtThayDoiGia.ThemLichSu(Session["IDNhanVien"].ToString(), dr["MaHangHoa"].ToString(), dr["TenHangHoa"].ToString(), dr["IDDonViTinh"].ToString(), GiaCu + "", GiaMoi, Session["IDChiNhanh"].ToString());
            }
            
            data.CapNhatGiaChiTiet(ID, GiaMoi);
            e.Cancel = true;
            gridChiTietPhieuKiemKho.CancelEdit();
            string IDBangGia = Request.QueryString["IDBangGia"];
            if (IDBangGia != null)
            {
                LoadGrid(IDBangGia);
            }
        }
    }
}