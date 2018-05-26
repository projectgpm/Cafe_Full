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
    public partial class BangGia : System.Web.UI.Page
    {
        dtBangGia data = new dtBangGia();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["KTDangNhap"] != "GPM@2017")
            {
                Response.Redirect("DangNhap.aspx");
            }
            else
            {
                if (Session["IDNhanVien"].ToString() != "1")
                {
                    gridBangGia.Columns["chucnang"].Visible = false;
                    gridBangGia.Columns["ChiNhanh"].Visible = false;
                }
                LoadGrid();
            }
        }

        private void LoadGrid()
        {
            data = new dtBangGia();
            gridBangGia.DataSource = data.DanhSach(Session["IDChiNhanh"].ToString());
            gridBangGia.DataBind();
        }

        protected void gridBangGia_RowDeleting(object sender, DevExpress.Web.Data.ASPxDataDeletingEventArgs e)
        {
            string ID = e.Keys[0].ToString();
            data = new dtBangGia();
            data.XoaBangGia(ID);
            e.Cancel = true;
            gridBangGia.CancelEdit();
            LoadGrid();
        }

        protected void gridBangGia_RowInserting(object sender, DevExpress.Web.Data.ASPxDataInsertingEventArgs e)
        {
            string IDChiNhanh = e.NewValues["IDChiNhanh"].ToString();
            string TenBangGia = e.NewValues["TenBangGia"].ToString();
            data = new dtBangGia();
            object ID = data.ThemMoi(TenBangGia, IDChiNhanh);
            if (ID != null)
            {
                dtHangHoa hh = new dtHangHoa();
                DataTable db = hh.LayDanhSachHangHoa(IDChiNhanh);
                foreach (DataRow dr in db.Rows)
                {
                    string IDHangHoa = dr["ID"].ToString();
                    string GiaCu = dr["GiaBan"].ToString();
                    data = new dtBangGia();
                    data.ThemIDHangHoaVaoChiTietGia(IDHangHoa, ID, GiaCu, IDChiNhanh);
                }
            }
            e.Cancel = true;
            gridBangGia.CancelEdit();
            LoadGrid();
        }

        protected void gridBangGia_RowUpdating(object sender, DevExpress.Web.Data.ASPxDataUpdatingEventArgs e)
        {
            string ID = e.Keys[0].ToString();
            //chỉ sửa tên
            string TenBangGia = e.NewValues["TenBangGia"].ToString();
            data = new dtBangGia();
            data.SuaBangGia(ID, TenBangGia);
            e.Cancel = true;
            gridBangGia.CancelEdit();
            LoadGrid();
        }
    }
}