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
    public partial class PhieuXuatKhac : System.Web.UI.Page
    {
        dtPhieuXuatKhac data = new dtPhieuXuatKhac();
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
                   // data = new dtPhieuXuatKhac();
                    // object IDPhieuXuatKhac = data.ThemPhieuXuatKhac_Temp();
                    IDPhieuXuatKhac_Temp.Value = Session["IDNhanVien"].ToString();
                    cmbChiNhanh.Text = Session["IDChiNhanh"].ToString();
                    txtNguoiLapPhieu.Text = Session["TenDangNhap"].ToString();
                }
                LoadGrid(IDPhieuXuatKhac_Temp.Value.ToString());
            }
        }
       
        public void Clear()
        {
            cmbHangHoa.Text = "";
            txtSoLuong.Text = "";
            txtTonKho.Text = "";
            cmbDonViTinh.Text = "";
          
        }
        protected void cmbNgayLapPhieu_Init(object sender, EventArgs e)
        {
            cmbNgayLapPhieu.Date = DateTime.Today;
        }
        private void LoadGrid(string IDPhieuXuatKhac)
        {
            data = new dtPhieuXuatKhac();
            gridDanhSachHangHoa.DataSource = data.LayDanhSachPhieuXuatKhac_Temp(IDPhieuXuatKhac);
            gridDanhSachHangHoa.DataBind();
        }

        protected void cmbHangHoa_ItemRequestedByValue(object source, ListEditItemRequestedByValueEventArgs e)
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

        protected void cmbHangHoa_ItemsRequestedByFilterCondition(object source, ListEditItemsRequestedByFilterConditionEventArgs e)
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

        protected void cmbHangHoa_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbHangHoa.Text != "")
            {
                txtTonKho.Text = dtSetting.SoLuong_TonKho(cmbHangHoa.Value.ToString(), Session["IDChiNhanh"].ToString()) + "";
                cmbDonViTinh.Value = dtThemHangHoa.LayIDDonViTinh(cmbHangHoa.Value.ToString());
                txtSoLuong.Text = "0";
            }
        }

        protected void btnThem_Click(object sender, EventArgs e)
        {
            if (cmbHangHoa.Value != null && txtSoLuong.Text != "")
            {
                float SoLuong = float.Parse(txtSoLuong.Value.ToString());
                if (SoLuong > 0)
                {
                    string IDNguyenLieu = cmbHangHoa.Value.ToString();
                    string IDPhieuXuatKhac = IDPhieuXuatKhac_Temp.Value.ToString();
                    DataTable db = data.KTChiTietPhieuXuatKhac_Temp(IDNguyenLieu, IDPhieuXuatKhac);// kiểm tra hàng hóa
                    if (db.Rows.Count == 0)
                    {
                        data = new dtPhieuXuatKhac();
                        data.ThemPhieuXuatKhac_Temp1(IDPhieuXuatKhac,IDNguyenLieu,txtTonKho.Text,dtThemHangHoa.LayIDDonViTinh(IDNguyenLieu),txtSoLuong.Text,dtThemHangHoa.LayMaNguyenLieu(IDNguyenLieu),dtSetting.GiaMua(IDNguyenLieu).ToString());
                        Clear();
                    }
                    else
                    {
                        data = new dtPhieuXuatKhac();
                        data.UpdatePhieuXuatKhac_temp(IDPhieuXuatKhac, IDNguyenLieu, SoLuong.ToString());
                        Clear();
                    }
                    LoadGrid(IDPhieuXuatKhac);
                }
                else
                {
                    txtSoLuong.Focus();
                    Response.Write("<script language='JavaScript'> alert('Số Lượng phải > 0.'); </script>");
                }
            }
            else
            {
                cmbHangHoa.Focus();
                Response.Write("<script language='JavaScript'> alert('Bạn chưa chọn nguyên liệu.'); </script>");
            }
        }

        protected void btnThemPhieuXuatKhac_Click(object sender, EventArgs e)
        {
            if (cmbLyDoXuat.Text != "")
            {
                string IDPhieuXuatKhac = IDPhieuXuatKhac_Temp.Value.ToString();
                DataTable db = data.LayDanhSachPhieuXuatKhac_Temp(IDPhieuXuatKhac);
                if (db.Rows.Count != 0)
                {
                    string IDNguoiLapPhieu = Session["IDNhanVien"].ToString();
                    DateTime NgayLapPhieu = DateTime.Parse(cmbNgayLapPhieu.Text.ToString());
                    string IDLyDoXuat = cmbLyDoXuat.Value.ToString();
                    string GhiChu = txtGhiChu == null ? "" : txtGhiChu.Text.ToString();
                    string IDChiNhanh = Session["IDChiNhanh"].ToString();
                    data = new dtPhieuXuatKhac();
                    object ID = data.ThemPhieuXuatKhac_Temp();
                    if (ID != null)
                    {
                        data.CapNhatPhieuXuatKhac_ID(ID, IDNguoiLapPhieu, IDLyDoXuat, NgayLapPhieu, GhiChu, IDChiNhanh);
                        foreach (DataRow dr in db.Rows)
                        {
                            string IDNguyenLieu = dr["IDNguyenLieu"].ToString();
                            string TonKho = dr["TonKho"].ToString();
                            string IDDonViTinh = dr["IDDonViTinh"].ToString();
                            string SoLuongXuat = dr["SoLuongXuat"].ToString();
                            string MaNguyenLieu = dr["MaNguyenLieu"].ToString();
                            string DonGia = dr["DonGia"].ToString();
                            string ThanhTien = dr["ThanhTien"].ToString();
                            data = new dtPhieuXuatKhac();
                            data.ThemChiTietPhieuXuatKhac(ID, IDNguyenLieu, TonKho, IDDonViTinh, SoLuongXuat, MaNguyenLieu, DonGia, ThanhTien);

                            //dtLichSuKho.ThemLichSu(Session["IDChiNhanh"].ToString(), IDNguyenLieu, Session["IDNhanVien"].ToString(), dtLichSuKho.LaySoLuongTonKho(Session["IDChiNhanh"].ToString(), IDNguyenLieu), (Int32.Parse(dtLichSuKho.LaySoLuongTonKho(Session["IDChiNhanh"].ToString(), IDNguyenLieu)) - Int32.Parse(SoLuongXuat)) + "", "Phiếu xuất khác");
                            
                            dtSetting.TruTonKho(IDNguyenLieu, SoLuongXuat, IDChiNhanh);
                        }
                        data = new dtPhieuXuatKhac();
                        data.XoaChiTietPhieuXuatKhac_Temp(IDPhieuXuatKhac);

                        dtLichSuTruyCap.ThemLichSu(Session["IDChiNhanh"].ToString(), Session["IDNhom"].ToString(), Session["IDNhanVien"].ToString(), "Phiếu xuất khác", "Thêm phiếu xuất khác");
                        Response.Redirect("DanhSachPhieuXuatKhac.aspx");
                    }
                }
                else
                {
                    cmbHangHoa.Focus();
                    Response.Write("<script language='JavaScript'> alert('Danh sách hàng hóa rỗng.'); </script>");
                }
            }
            else
            {
                cmbLyDoXuat.Focus();
                Response.Write("<script language='JavaScript'> alert('Vui lòng chọn lý do để xuất.'); </script>");
            }

            
        }

        protected void btnHuyPhieuXuatKhac_Click(object sender, EventArgs e)
        {
            data = new dtPhieuXuatKhac();
            int ID = Int32.Parse(IDPhieuXuatKhac_Temp.Value.ToString());
            if (ID != null)
            {
                data.XoaPhieuXuatKhac_Temp(ID);
                data.XoaChiTietPhieuXuatKhac_Temp(IDPhieuXuatKhac_Temp.Value.ToString());
                Response.Redirect("DanhSachPhieuXuatKhac.aspx");
            }
        }

        protected void gridDanhSachHangHoa_RowDeleting(object sender, DevExpress.Web.Data.ASPxDataDeletingEventArgs e)
        {
            int ID = Int32.Parse(e.Keys[0].ToString());
            data = new dtPhieuXuatKhac();
            data.XoaChiTietPhieuXuatKhac_Temp_ID(ID);
            e.Cancel = true;
            gridDanhSachHangHoa.CancelEdit();
            LoadGrid(IDPhieuXuatKhac_Temp.Value.ToString());
        }
    }
}