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
    public partial class ThemHangHoa : System.Web.UI.Page
    {
        dtThemHangHoa data = new dtThemHangHoa();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["KTDangNhap"] != "GPM@2017")
            {
                Response.Redirect("DangNhap.aspx");
            }
            else
            {
                if (!IsPostBack)
                {
                    //data = new dtThemHangHoa();
                    //object IDHangHoa = data.ThemHangHoa();
                    IDHangHoa_Temp.Value = Session["IDNhanVien"].ToString();//IDHangHoa.ToString();
                    txtMaHang.Text = dtThemHangHoa.Dem_Max().ToString();
                }
                LoadGrid(IDHangHoa_Temp.Value.ToString());
            }
        }

        private void LoadGrid(string p)
        {
            data = new dtThemHangHoa();
            gridNguyenLieu.DataSource = data.NguyenLieu_Temp(p);
            gridNguyenLieu.DataBind();
        }

        protected void btnThemTemp_Click(object sender, EventArgs e)
        {
            if (cmbNguyenLieu.Text != "" && txtTrongLuong.Text != "")
            {
                float TrongLuong = float.Parse(txtTrongLuong.Text);
                if (TrongLuong < 0)
                {
                    Response.Write("<script language='JavaScript'> alert('Trọng lượng pha chế phải >=0 .'); </script>");
                }
                else
                {
                    string IDNguyenLieu = cmbNguyenLieu.Value.ToString();
                    string MaNguyenLieu = dtThemHangHoa.LayMaNguyenLieu(IDNguyenLieu);
                    string NhaCungCap = dtThemHangHoa.LayNhaCungCap(IDNguyenLieu);
                    string IDDonViTinh = dtThemHangHoa.LayIDDonViTinh(IDNguyenLieu);
                    string IDHangHoa = IDHangHoa_Temp.Value.ToString();
                    data = new dtThemHangHoa();
                    DataTable db = data.KTHangHoa_Temp(IDHangHoa, IDNguyenLieu);// kiểm tra hàng hóa
                    if (db.Rows.Count == 0)
                    {
                        data = new dtThemHangHoa();
                        data.ThemNguyenLieu_Temp(IDHangHoa, IDNguyenLieu, TrongLuong, MaNguyenLieu, NhaCungCap, IDDonViTinh);
                        cmbNguyenLieu.Text = "";
                        cmbNguyenLieu.Focus();
                        txtTrongLuong.Text = "";
                    }
                    else
                    {
                        data = new dtThemHangHoa();
                        data.CapNhatNguyenLieu_Temp(IDHangHoa, IDNguyenLieu, TrongLuong);
                        cmbNguyenLieu.Text = "";
                        cmbNguyenLieu.Focus();
                        txtTrongLuong.Text = "";
                    }
                    LoadGrid(IDHangHoa);
                }
            }
            else
            {
                Response.Write("<script language='JavaScript'> alert('Vui lòng chọn nguyên liệu chế biến & trọng lượng(g) .'); </script>");
            }
        }

        protected void btnThem_Click(object sender, EventArgs e)
        {
            if (txtTenHangHoa.Text != "" && txtGiaBan.Text != "" && cmbDonViTinh.Text != "" && cmbNhomHang.Text != "")
            {
                string IDHangHoa = IDHangHoa_Temp.Value.ToString();
                string MaHangHoa = txtMaHang.Text.ToString();
                string TenHangHoa = txtTenHangHoa.Text.ToString();
                string GiaBan = txtGiaBan.Text.ToString();
                string IDDonViTinh = cmbDonViTinh.Value.ToString();
                string IDNhomHang = cmbNhomHang.Value.ToString();
                string GhiChu = txtGhiChu.Text == null ? "" : txtGhiChu.Text.ToString();
                data = new dtThemHangHoa();
                object ID = data.ThemHangHoa();
                if (ID != null)
                {
                    data.CapNhatHangHoa(ID, MaHangHoa, TenHangHoa, GiaBan, IDDonViTinh, IDNhomHang, GhiChu);
                    DataTable dt = data.NguyenLieu_Temp(IDHangHoa);
                    if (dt.Rows.Count > 0)
                    {
                        foreach (DataRow dr in dt.Rows)
                        {
                            string IDNguyenLieu = dr["IDNguyenLieu"].ToString();
                            string TrongLuong = dr["TrongLuong"].ToString();
                            string MaNguyenLieu = dr["MaNguyenLieu"].ToString();
                            string NhaCungCap = dr["NhaCungCap"].ToString();
                            string IDDonViTinh1 = dr["IDDonViTinh"].ToString();
                            data = new dtThemHangHoa();
                            data.ThemChiTietNguyenLieu(ID, IDNguyenLieu, TrongLuong, MaNguyenLieu, NhaCungCap, IDDonViTinh1);
                        }
                    }
                    data = new dtThemHangHoa();
                    data.XoaChiTiet_Temp_ID(IDHangHoa);
                    dtLichSuTruyCap.ThemLichSu(Session["IDChiNhanh"].ToString(), Session["IDNhom"].ToString(), Session["IDNhanVien"].ToString(), "Thêm hàng hóa", "Thêm hàng hóa có nguyên liệu");
                    Response.Redirect("QuanLyHangHoa.aspx");
                }
            }
            else
            {
                Response.Write("<script language='JavaScript'> alert('Trường  (*) không được bỏ trống .'); </script>");
            }


        }

        protected void btnHuy_Click(object sender, EventArgs e)
        {
            string IDHangHoa = IDHangHoa_Temp.Value.ToString();
            data = new dtThemHangHoa();
            data.XoaChiTiet_Temp(IDHangHoa);
            Response.Redirect("QuanLyHangHoa.aspx");
        }

        protected void gridNguyenLieu_RowDeleting(object sender, DevExpress.Web.Data.ASPxDataDeletingEventArgs e)
        {
            string ID = e.Keys[0].ToString();
            string IDHangHoa = IDHangHoa_Temp.Value.ToString();
            data = new dtThemHangHoa();
            data.XoaChiTiet_Temp_ID(ID);
            e.Cancel = true;
            gridNguyenLieu.CancelEdit();
            LoadGrid(IDHangHoa);
        }
    }
}