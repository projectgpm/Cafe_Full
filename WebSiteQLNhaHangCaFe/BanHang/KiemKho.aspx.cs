using BanHang.Data;
using DevExpress.Web;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BanHang
{
    public partial class KiemKho : System.Web.UI.Page
    {
        dtKiemKho data = new dtKiemKho();
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
                    data = new dtKiemKho();
                    // object IDPhieuKiemKho = data.ThemPhieu_Temp();
                    IDPhieuKiemKho_Temp.Value = Session["IDNhanVien"].ToString();
                    txtChiNhanh.Text = Session["IDChiNhanh"].ToString();
                    txtNguoiLapPhieu.Text = Session["TenDangNhap"] == null ? "" : Session["TenDangNhap"].ToString();
                }
                LoadGrid(IDPhieuKiemKho_Temp.Value.ToString());
            }
        }

        protected void gridDanhSachHangHoa_Temp_RowDeleting(object sender, DevExpress.Web.Data.ASPxDataDeletingEventArgs e)
        {
            string ID = e.Keys[0].ToString();
            string IDPhieuKiemKho = IDPhieuKiemKho_Temp.Value.ToString();
            data = new dtKiemKho();
            data.XoaPhieuKiemKho_Temp_ID(ID);
            e.Cancel = true;
            gridDanhSachHangHoa_Temp.CancelEdit();
            LoadGrid(IDPhieuKiemKho);

        }
        protected void btnHuy_Click(object sender, EventArgs e)
        {
            data = new dtKiemKho();
            string IDPhieuKiemKho = IDPhieuKiemKho_Temp.Value.ToString();
            data.XoaPhieuKiemKho_Temp_IDPhieuKiemKho(IDPhieuKiemKho);
            Response.Redirect("DanhSachKiemKho.aspx");
        }
        public void LoadGrid(string IDPhieuKiemKho)
        {
            data = new dtKiemKho();
            gridDanhSachHangHoa_Temp.DataSource = data.DanhSachKiemKhoTemp_IDPhieuKiemKho(IDPhieuKiemKho);
            gridDanhSachHangHoa_Temp.DataBind();
        }
        protected void gridDanhSachHangHoa_Temp_RowUpdating(object sender, DevExpress.Web.Data.ASPxDataUpdatingEventArgs e)
        {
            string IDPhieuKiemKho = IDPhieuKiemKho_Temp.Value.ToString();
            string ID = e.Keys[0].ToString();
            float ThucTe = float.Parse(e.NewValues["ThucTe"].ToString());
            if (ThucTe >= 0)
            {

                float TonKho = float.Parse(e.NewValues["TonKho"].ToString());
                data = new dtKiemKho();
                data.CapNhatPhieuKiemKho_Temp(ID, ThucTe.ToString(), (ThucTe - TonKho).ToString());
                e.Cancel = true;
                gridDanhSachHangHoa_Temp.CancelEdit();
                LoadGrid(IDPhieuKiemKho);
            }
            else
            {
                throw new Exception("Lỗi: Số lượng thực tế phải  >= 0");
            }
        }

        protected void cmbHangHoa_ItemRequestedByValue(object source, DevExpress.Web.ListEditItemRequestedByValueEventArgs e)
        {
            long value = 0;
            if (e.Value == null || !Int64.TryParse(e.Value.ToString(), out value))
                return;
            ASPxComboBox comboBox = (ASPxComboBox)source;
            dsHangHoa.SelectCommand = @"SELECT CF_NguyenLieu.ID, CF_NguyenLieu.MaNguyenLieu, CF_NguyenLieu.TenNguyenLieu, CF_NguyenLieu.GiaMua, CF_DonViTinh.TenDonViTinh 
                                        FROM CF_DonViTinh INNER JOIN CF_NguyenLieu ON CF_DonViTinh.ID = CF_NguyenLieu.IDDonViTinh
                                        WHERE (CF_NguyenLieu.ID = @ID)";
            dsHangHoa.SelectParameters.Clear();
            dsHangHoa.SelectParameters.Add("ID", TypeCode.Int64, e.Value.ToString());
            comboBox.DataSource = dsHangHoa;
            comboBox.DataBind();
        }

        protected void cmbHangHoa_ItemsRequestedByFilterCondition(object source, DevExpress.Web.ListEditItemsRequestedByFilterConditionEventArgs e)
        {
            ASPxComboBox comboBox = (ASPxComboBox)source;

            dsHangHoa.SelectCommand = @"SELECT [ID],[MaNguyenLieu], [TenNguyenLieu], [GiaMua], [TenDonViTinh]
                                        FROM (
	                                        select CF_NguyenLieu.ID, CF_NguyenLieu.MaNguyenLieu, CF_NguyenLieu.TenNguyenLieu,CF_NguyenLieu.GiaMua, CF_DonViTinh.TenDonViTinh, 
	                                        row_number()over(order by CF_NguyenLieu.MaNguyenLieu) as [rn] 
	                                        FROM CF_DonViTinh INNER JOIN CF_NguyenLieu ON CF_DonViTinh.ID = CF_NguyenLieu.IDDonViTinh           
	                                        WHERE ((CF_NguyenLieu.TenNguyenLieu LIKE @TenHang) OR (CF_NguyenLieu.MaNguyenLieu LIKE @MaHang)) AND (CF_NguyenLieu.DaXoa = 0)
	                                        ) as st 
                                        where st.[rn] between @startIndex and @endIndex";

            dsHangHoa.SelectParameters.Clear();
            dsHangHoa.SelectParameters.Add("TenHang", TypeCode.String, string.Format("%{0}%", e.Filter));
            dsHangHoa.SelectParameters.Add("MaHang", TypeCode.String, string.Format("%{0}%", e.Filter));
            dsHangHoa.SelectParameters.Add("startIndex", TypeCode.Int64, (e.BeginIndex + 1).ToString());
            dsHangHoa.SelectParameters.Add("endIndex", TypeCode.Int64, (e.EndIndex + 1).ToString());
            comboBox.DataSource = dsHangHoa;
            comboBox.DataBind();
        }
        protected void txtNgayLapPhieu_Init(object sender, EventArgs e)
        {
            txtNgayLapPhieu.Date = DateTime.Today;
        }

        protected void btnLuu_Click(object sender, EventArgs e)
        {
            string IDPhieuKiemKho = IDPhieuKiemKho_Temp.Value.ToString();
            DataTable db = data.DanhSachKiemKhoTemp_IDPhieuKiemKho(IDPhieuKiemKho);
            if (db.Rows.Count > 0)
            {
                string IDNguoiDung = Session["IDNhanVien"].ToString();
                string IDChiNhanh = Session["IDChiNhanh"].ToString();
                DateTime NgayKiemKho = DateTime.Parse(txtNgayLapPhieu.Text.ToString());
                string GhiChu = txtGhiChu.Text == null ? "" : txtGhiChu.Text.ToString();
                data = new dtKiemKho();
                object ID = data.ThemPhieu_Temp();
                if (ID != null)
                {
                    data.CapNhatPhieuKiemKho(ID, IDNguoiDung, NgayKiemKho, GhiChu, IDChiNhanh);
                    foreach (DataRow dr in db.Rows)
                    {
                        string IDNguyenLieu = dr["IDNguyenLieu"].ToString();
                        string TonKho = dr["TonKho"].ToString();
                        string ChenhLech = dr["ChenhLech"].ToString();
                        string ThucTe = dr["ThucTe"].ToString();
                        string MaNguyenLieu = dr["MaNguyenLieu"].ToString();
                        string IDDonViTinh = dr["IDDonViTinh"].ToString();
                        data = new dtKiemKho();
                        data.ThemPhieuKiemKho(ID, IDNguyenLieu, TonKho, ChenhLech, ThucTe, MaNguyenLieu, IDDonViTinh);
                    }
                    data = new dtKiemKho();
                    data.XoaPhieuKiemKho_Temp_IDPhieuKiemKho2(IDPhieuKiemKho);
                    Response.Redirect("DanhSachKiemKho.aspx");
                }
            }
            else
            {
                cmbHangHoa.Focus();
                Response.Write("<script language='JavaScript'> alert('Danh sách kiểm kho rỗng.'); </script>");
            }

            dtLichSuTruyCap.ThemLichSu(Session["IDChiNhanh"].ToString(), Session["IDNhom"].ToString(), Session["IDNhanVien"].ToString(), "Kiểm kho", "Tạo phiếu kiểm kho");
        }
        protected void cmbHangHoa_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbHangHoa.Text != "")
            {
                string IDPhieuKiemKho = IDPhieuKiemKho_Temp.Value.ToString();
                string IDNguyenLieu = cmbHangHoa.Value.ToString();
                float TonKho = dtSetting.SoLuong_TonKho(IDNguyenLieu, Session["IDChiNhanh"].ToString());
                string MaNguyenLieu = dtThemHangHoa.LayMaNguyenLieu(IDNguyenLieu);
                string IDDonViTinh = dtThemHangHoa.LayIDDonViTinh(IDNguyenLieu);
                data = new dtKiemKho();
                DataTable dt = data.KTChiTietPhieuKiemKho_Temp(IDNguyenLieu, IDPhieuKiemKho);
                if (dt.Rows.Count == 0)
                {
                    data = new dtKiemKho();
                    data.ThemPhieuKiemKho_Temp(IDPhieuKiemKho, IDNguyenLieu, TonKho.ToString(), (-TonKho).ToString(), MaNguyenLieu, IDDonViTinh);
                    LoadGrid(IDPhieuKiemKho.ToString());
                    cmbHangHoa.Text = "";
                }
            }
            else
            {
                cmbHangHoa.Focus();
                ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('Vui lòng chọn nguyên liệu!!');", true);
            }
           
        }
    }
}