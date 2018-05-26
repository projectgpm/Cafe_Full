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
    public partial class DangNhap : System.Web.UI.Page
    {
        dtCheckDangNhap data = new dtCheckDangNhap();
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void btnDangNhapQuanLy_Click(object sender, EventArgs e)
        {
            if (KiemTra() == true)
            {
                data = new dtCheckDangNhap();
                string TenDangNhap = txtDangNhap.Value.ToUpper();
                string MatKhau = dtSetting.GetSHA1HashData(txtMatKhau.Value.ToString());
                DataTable dt = data.KiemTraQuanLy(TenDangNhap, MatKhau);
                DataTable banhangdt = data.KiemTraBanHang(TenDangNhap, MatKhau);
                if (dt.Rows.Count > 0)
                {
                    DataRow dr = dt.Rows[0];
                    Session["TenDangNhap"] = dr["TenNguoiDung"].ToString();
                    Session["UserName"] = txtDangNhap.Value.ToUpper();
                    Session["IDNhanVien"] = dr["ID"].ToString();
                    Session["IDNhom"] = dr["IDNhomNguoiDung"].ToString();
                    Session["KTDangNhap"] = "GPM@2017";
                    Session["KTBanLe"] = "GPMBanLe";
                    Session["IDChiNhanh"] = dr["IDChiNhanh"].ToString();
                    Session["IDKho"] = dr["IDChiNhanh"].ToString();
                    dtLichSuTruyCap.ThemLichSu(Session["IDChiNhanh"].ToString(), Session["IDNhom"].ToString(), Session["IDNhanVien"].ToString(), "Đăng nhập", "Đăng nhập hệ thống");
                    Response.Redirect("QuanLyCuaHang.aspx");

                }
                else if (banhangdt.Rows.Count > 0)
                {
                    DataRow dr = banhangdt.Rows[0];
                    Session["TenDangNhap"] = dr["TenNguoiDung"].ToString();
                    Session["UserName"] = txtDangNhap.Value.ToUpper();
                    Session["IDNhanVien"] = dr["ID"].ToString();
                    Session["IDNhom"] = dr["IDNhomNguoiDung"].ToString();
                    Session["KTBanLe"] = "GPMBanLe";
                    Session["IDChiNhanh"] = dr["IDChiNhanh"].ToString();
                    Session["IDKho"] = dr["IDChiNhanh"].ToString();
                    dtLichSuTruyCap.ThemLichSu(Session["IDChiNhanh"].ToString(), Session["IDNhom"].ToString(), Session["IDNhanVien"].ToString(), "Đăng nhập", "Đăng nhập hệ thống");
                    Response.Redirect("BanHangLe.aspx");
                }
                else
                {
                    Response.Write("<script language='JavaScript'> alert('Đăng Nhập Không Thành Công.'); </script>");
                    txtDangNhap.Value = "";
                    txtMatKhau.Value = "";
                }
            }
        }
 
        public bool KiemTra()
        {
            if (txtDangNhap.Value.ToString() == "" || txtMatKhau.Value.ToString() == "")
            {
                Response.Write("<script language='JavaScript'> alert('Vui lòng điền đầy đủ thông tin đăng nhập.'); </script>");
                return false;
            }
            return true;
        }
    }
}