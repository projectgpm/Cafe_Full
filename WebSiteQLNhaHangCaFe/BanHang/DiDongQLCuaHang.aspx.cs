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
    public partial class DiDongQLCuaHang : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                // Theo ngày
                txtNgayBD.Value = DateTime.Today;
                txtNgayKT.Value = DateTime.Today;

                DataTable daHienTai = new DataTable();
                daHienTai.Columns.Add("ThongKe", typeof(String));
                daHienTai.Columns.Add("NoiDung", typeof(String));

                string ngayBD = ""; string ngayKT = "";
                ngayBD = DateTime.Parse(txtNgayBD.Value + "").ToString("yyyy-MM-dd ");
                ngayKT = DateTime.Parse(txtNgayKT.Value + "").ToString("yyyy-MM-dd ");
                ngayBD = ngayBD + "00:00:0.000";
                ngayKT = ngayKT + "23:59:59.999";

                int SoLuongBan = dtQuanLyCuaHang.SoLuongBan(Session["IDChiNhanh"].ToString());
                DataTable da = dtQuanLyCuaHang.TongTienHienTai(ngayBD, ngayKT, Session["IDChiNhanh"].ToString());
                float TongTien = 0;
                float KhachCanTra = 0;
                float TongGiaMua = 0;
                try
                {
                    if (da.Rows.Count != 0)
                    {
                        TongTien = float.Parse(da.Rows[0]["TongTien"].ToString());
                        KhachCanTra = float.Parse(da.Rows[0]["KhachCanTra"].ToString());
                        TongGiaMua = dtQuanLyCuaHang.TongTienVonHienTai(ngayBD, ngayKT);
                    }
                }
                catch (Exception) { }

                daHienTai.Rows.Add("Số Bàn", SoLuongBan);
                daHienTai.Rows.Add("Tiền hàng", String.Format("{0:N0} VNĐ", TongGiaMua));
                daHienTai.Rows.Add("Doanh thu", String.Format("{0:N0} VNĐ", TongTien));
                daHienTai.Rows.Add("Giảm giá", String.Format("{0:N0} VNĐ", TongTien - KhachCanTra));
                daHienTai.Rows.Add("Tổng tiền", String.Format("{0:N0} VNĐ", KhachCanTra));
                daHienTai.Rows.Add("Lợi nhuận", String.Format("{0:N0} VNĐ", KhachCanTra - TongGiaMua));

                girdHienTai.DataSource = daHienTai;
                girdHienTai.DataBind();

                DataTable daThongKe = new DataTable();
                daThongKe.Columns.Add("ThongKe", typeof(String));
                daThongKe.Columns.Add("NoiDung", typeof(String));
                //// Theo tuần...
                ngayBD = DateTime.Parse(txtNgayBD.Value + "").AddDays(-7).ToString("yyyy-MM-dd ") + "00:00:0.000";
                ngayKT = DateTime.Today.ToString("yyyy-MM-dd ") + "23:59:59.999";
                da = dtQuanLyCuaHang.TongTienHienTai(ngayBD, ngayKT, Session["IDChiNhanh"].ToString());
                KhachCanTra = 0;
                try
                {
                    if (da.Rows.Count != 0)
                    {
                        KhachCanTra = float.Parse(da.Rows[0]["KhachCanTra"].ToString());
                    }
                }
                catch (Exception) { }
                daThongKe.Rows.Add("Doanh thu theo Tuần", String.Format("{0:N0} VNĐ", KhachCanTra));

                // ----------------------------------------
                int thang = DateTime.Parse(txtNgayBD.Value + "").Month;
                int nam = DateTime.Parse(txtNgayBD.Value + "").Year;

                //// Theo tháng...
                ngayBD = nam + "-" + thang + "-01 " + "00:00:0.000";
                ngayKT = DateTime.Today.ToString("yyyy-MM-dd ") + "23:59:59.999";
                da = dtQuanLyCuaHang.TongTienHienTai(ngayBD, ngayKT,Session["IDChiNhanh"].ToString());
                KhachCanTra = 0;
                try
                {
                    if (da.Rows.Count != 0)
                    {
                        KhachCanTra = float.Parse(da.Rows[0]["KhachCanTra"].ToString());
                    }
                }
                catch (Exception) { }
                daThongKe.Rows.Add("Doanh thu theo Tháng", String.Format("{0:N0} VNĐ", KhachCanTra));

                //// Theo năm...
                ngayBD = nam + "-" + "01" + "-01 " + "00:00:0.000";
                ngayKT = DateTime.Today.ToString("yyyy-MM-dd ") + "23:59:59.999";
                da = dtQuanLyCuaHang.TongTienHienTai(ngayBD, ngayKT,Session["IDChiNhanh"].ToString());
                KhachCanTra = 0;
                try
                {
                    if (da.Rows.Count != 0)
                    {
                        KhachCanTra = float.Parse(da.Rows[0]["KhachCanTra"].ToString());
                    }
                }
                catch (Exception) { }
                daThongKe.Rows.Add("Doanh thu theo Năm", String.Format("{0:N0} VNĐ", KhachCanTra));

                girdThongKe.DataSource = daThongKe;
                girdThongKe.DataBind();
            }
        }

        protected void btnXem_Click(object sender, EventArgs e)
        {
            DataTable da = new DataTable();
            da.Columns.Add("ThongKe", typeof(String));
            da.Columns.Add("NoiDung", typeof(String));

            TimeSpan Time = DateTime.Parse(txtNgayKT.Value + "") - DateTime.Parse(txtNgayBD.Value + "");
            int TongSoNgay = Time.Days;
            float Tong = 0;
            for (int i = 0; i <= TongSoNgay; i++)
            {
                string ngayBD = ""; string ngayKT = "";
                ngayBD = DateTime.Parse(txtNgayBD.Value + "").AddDays(i).ToString("yyyy-MM-dd ");
                ngayKT = DateTime.Parse(txtNgayBD.Value + "").AddDays(i).ToString("yyyy-MM-dd ");
                ngayBD = ngayBD + "00:00:0.000";
                ngayKT = ngayKT + "23:59:59.999";
                DataTable daTienGio = dtQuanLyCuaHang.TongTienHienTai(ngayBD, ngayKT, Session["IDChiNhanh"].ToString());
                float KhachCanTra = 0;
                try
                {
                    if (daTienGio.Rows.Count != 0)
                    {
                        KhachCanTra = float.Parse(daTienGio.Rows[0]["KhachCanTra"].ToString());
                        Tong = Tong + KhachCanTra;
                    }
                }
                catch (Exception) { }
                da.Rows.Add(DateTime.Parse(txtNgayBD.Value + "").AddDays(i).ToString("dd-MM-yyyy"), String.Format("{0:N0} VNĐ", KhachCanTra));
            }

            da.Rows.Add("Tổng tiền", String.Format("{0:N0} VNĐ", Tong));

            girdTuyChon.DataSource = da;
            girdTuyChon.DataBind();
        }

        protected void btnLamMoi_Click(object sender, EventArgs e)
        {
            Response.Redirect("DiDongQLCuaHang.aspx");
        }
    }
}