using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DevExpress.Web;
using BanHang.Data;
using System.Data;

namespace BanHang
{
    public partial class BanHangLe1 : System.Web.UI.Page
    {
        public List<HoaDon> DanhSachHoaDon
        {
            get
            {
                if (ViewState["DanhSachHoaDon"] == null)
                    return new List<HoaDon>();
                else
                    return (List<HoaDon>)ViewState["DanhSachHoaDon"];
            }
            set
            {
                ViewState["DanhSachHoaDon"] = value;
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["KTBanLe"] == "GPMBanLe")
            {
                if (!IsPostBack)
                {
                    DanhSachHoaDon = new List<HoaDon>();
                    ThemHoaDonMoi();
                    btnNhanVien.Text = Session["TenDangNhap"].ToString();
                    txtBarcode.Focus();
                }
            }
            else
            {
                Response.Redirect("DangNhap.aspx");
            }
        }

        public void BindGridChiTietHoaDon()
        {
            int MaHoaDon = tabControlSoHoaDon.ActiveTabIndex;
            UpdateSTT(MaHoaDon);
            gridChiTietHoaDon.DataSource = DanhSachHoaDon[MaHoaDon].ListChiTietHoaDon;
            gridChiTietHoaDon.DataBind();
            formLayoutThanhToan.DataSource = DanhSachHoaDon[MaHoaDon];
            formLayoutThanhToan.DataBind();
        }

        public void ThemHoaDonMoi()
        {
            HoaDon hd = new HoaDon();
            DanhSachHoaDon.Add(hd);
            Tab tabHoaDonNew = new Tab();
            int SoHoaDon = DanhSachHoaDon.Count;
            tabHoaDonNew.Name = SoHoaDon.ToString();
            tabHoaDonNew.Text = "Hóa đơn " + SoHoaDon.ToString();
            tabHoaDonNew.Index = SoHoaDon - 1;
            tabControlSoHoaDon.Tabs.Add(tabHoaDonNew);
            tabControlSoHoaDon.ActiveTabIndex = SoHoaDon - 1;
            BindGridChiTietHoaDon();
        }
        public void HuyHoaDon()
        {
            int indexTabActive = tabControlSoHoaDon.ActiveTabIndex;
            DanhSachHoaDon.RemoveAt(indexTabActive);
            tabControlSoHoaDon.Tabs.RemoveAt(indexTabActive);
            for (int i = 0; i < tabControlSoHoaDon.Tabs.Count; i++)
            {
                tabControlSoHoaDon.Tabs[i].Text = "Hóa đơn " + (i + 1).ToString();
            }
            if (DanhSachHoaDon.Count == 0)
            {
                ThemHoaDonMoi();
            }
            else
            {
                BindGridChiTietHoaDon();
            }
        }
        public void ThemHangVaoChiTietHoaDon(DataTable tbThongTin)
        {
            
            string MaHang = tbThongTin.Rows[0]["MaNguyenLieu"].ToString();
            int IDHangHoa = Int32.Parse(tbThongTin.Rows[0]["ID"].ToString());
            int MaHoaDon = tabControlSoHoaDon.ActiveTabIndex;
            var exitHang = DanhSachHoaDon[MaHoaDon].ListChiTietHoaDon.FirstOrDefault(item => item.IDHangHoa == IDHangHoa);
            if (exitHang != null)
            {
                int SoLuong = exitHang.SoLuong + int.Parse(txtSoLuong.Text);
                double ThanhTienOld = exitHang.ThanhTien;
                exitHang.SoLuong = SoLuong;
                exitHang.HinhAnh = tbThongTin.Rows[0]["NhaCungCap"].ToString();
                exitHang.DonGia = double.Parse(tbThongTin.Rows[0]["GiaBan"].ToString());
                exitHang.GiaMua = double.Parse(tbThongTin.Rows[0]["GiaMua"].ToString());
                exitHang.TonKho = dtSetting.SoLuong_TonKho(IDHangHoa.ToString(), Session["IDKho"].ToString());
                exitHang.ThanhTien = SoLuong * double.Parse(tbThongTin.Rows[0]["GiaBan"].ToString());
                DanhSachHoaDon[MaHoaDon].TongTien += SoLuong * exitHang.DonGia - ThanhTienOld;
                DanhSachHoaDon[MaHoaDon].KhachCanTra = DanhSachHoaDon[MaHoaDon].TongTien - DanhSachHoaDon[MaHoaDon].GiamGia;
            }
            else
            {
                ChiTietHoaDon cthd = new ChiTietHoaDon();
                cthd.IDHangHoa = IDHangHoa;
                cthd.MaHang = MaHang;
                cthd.TonKho = dtSetting.SoLuong_TonKho(IDHangHoa.ToString(), Session["IDKho"].ToString());
                cthd.TenHang = tbThongTin.Rows[0]["TenNguyenLieu"].ToString();
                cthd.SoLuong = int.Parse(txtSoLuong.Text);
                cthd.DonViTinh = tbThongTin.Rows[0]["TenDonViTinh"].ToString();
                cthd.DonGia = double.Parse(tbThongTin.Rows[0]["GiaBan"].ToString());
                cthd.GiaMua = double.Parse(tbThongTin.Rows[0]["GiaMua"].ToString());
                cthd.HinhAnh = tbThongTin.Rows[0]["NhaCungCap"].ToString();
                cthd.ThanhTien = int.Parse(txtSoLuong.Text) * double.Parse(tbThongTin.Rows[0]["GiaBan"].ToString());
                DanhSachHoaDon[MaHoaDon].ListChiTietHoaDon.Add(cthd);
                DanhSachHoaDon[MaHoaDon].SoLuongHang++;
                DanhSachHoaDon[MaHoaDon].TongTien += cthd.ThanhTien;
                DanhSachHoaDon[MaHoaDon].KhachCanTra = DanhSachHoaDon[MaHoaDon].TongTien - DanhSachHoaDon[MaHoaDon].GiamGia;
            }
        }
        protected void btnInsertHang_Click(object sender, EventArgs e)
        {
            try
            {
                dtBanHangLe dt = new dtBanHangLe();
                if (txtBarcode.Text.Trim() != "")
                {
                    DataTable tbThongTin;
                    if (txtBarcode.Value == null)
                    {
                        tbThongTin = dt.LayThongTinHangHoa(txtBarcode.Text.ToString(), Session["IDKho"].ToString());
                    }
                    else
                    {
                        tbThongTin = dt.LayThongTinHangHoa(txtBarcode.Value.ToString(), Session["IDKho"].ToString());
                    }

                    if (tbThongTin.Rows.Count > 0)
                    {
                        ThemHangVaoChiTietHoaDon(tbThongTin);
                        BindGridChiTietHoaDon();
                    }
                    else
                        HienThiThongBao("Mã hàng không tồn tại!!");
                }
                txtBarcode.Focus();
                txtBarcode.Text = "";
                txtBarcode.Value = "";
                txtSoLuong.Text = "1";
            }
            catch (Exception ex)
            {
                HienThiThongBao("Error: " + ex);
            }
        }
        public void HienThiThongBao(string thongbao)
        {
            ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('" + thongbao + "');", true);
        }
        protected void btnUpdateGridHang_Click(object sender, EventArgs e)
        {
            BatchUpdate();
            BindGridChiTietHoaDon();
        }
        private void BatchUpdate()
        {
            int MaHoaDon = tabControlSoHoaDon.ActiveTabIndex;
            string IDKho = Session["IDKho"].ToString();
            for (int i = 0; i < gridChiTietHoaDon.VisibleRowCount; i++)
            {
                object SoLuong = gridChiTietHoaDon.GetRowValues(i, "SoLuong");
                ASPxSpinEdit spineditSoLuong = gridChiTietHoaDon.FindRowCellTemplateControl(i, (GridViewDataColumn)gridChiTietHoaDon.Columns["SoLuong"], "txtSoLuongChange") as ASPxSpinEdit;
                object SoLuongMoi = spineditSoLuong.Value;
                if (SoLuong != SoLuongMoi)
                {
                    int STT = Convert.ToInt32(gridChiTietHoaDon.GetRowValues(i, "STT"));
                    var exitHang = DanhSachHoaDon[MaHoaDon].ListChiTietHoaDon.FirstOrDefault(item => item.STT == STT);
                    int SoLuongOld = exitHang.SoLuong;
                    double ThanhTienOld = exitHang.ThanhTien;
                    exitHang.SoLuong = Convert.ToInt32(SoLuongMoi);
                    exitHang.ThanhTien = Convert.ToInt32(SoLuongMoi) * exitHang.DonGia;
                    DanhSachHoaDon[MaHoaDon].TongTien += exitHang.ThanhTien - ThanhTienOld;
                    DanhSachHoaDon[MaHoaDon].KhachCanTra = DanhSachHoaDon[MaHoaDon].TongTien - DanhSachHoaDon[MaHoaDon].GiamGia;
                }
            }
        }

        protected void txtKhachThanhToan_TextChanged(object sender, EventArgs e)
        {

            float TienKhachThanhToan;
            bool isNumeric = float.TryParse(txtKhachThanhToan.Text, out TienKhachThanhToan);
            if (!isNumeric)
            {
                txtKhachThanhToan.Text = "";
                txtKhachThanhToan.Focus();
                HienThiThongBao("Nhập không đúng số tiền !!"); return;
            }
            int MaHoaDon = tabControlSoHoaDon.ActiveTabIndex;
            DanhSachHoaDon[MaHoaDon].KhachThanhToan = TienKhachThanhToan;
            DanhSachHoaDon[MaHoaDon].TienThua = TienKhachThanhToan - DanhSachHoaDon[MaHoaDon].KhachCanTra;
            if (txtKhachThanhToan.Text != "0")
            {
                txtTienThua.Text = DanhSachHoaDon[MaHoaDon].TienThua.ToString();
            }
        }

        protected void BtnXoaHang_Click(object sender, EventArgs e)
        {
            try
            {
                int MaHoaDon = tabControlSoHoaDon.ActiveTabIndex;
                int STT = Convert.ToInt32(((ASPxButton)sender).CommandArgument);
                var itemToRemove =  DanhSachHoaDon[MaHoaDon].ListChiTietHoaDon.Single(r => r.STT == STT);
                DanhSachHoaDon[MaHoaDon].SoLuongHang--;
                DanhSachHoaDon[MaHoaDon].TongTien = DanhSachHoaDon[MaHoaDon].TongTien - itemToRemove.ThanhTien;
                DanhSachHoaDon[MaHoaDon].KhachCanTra = DanhSachHoaDon[MaHoaDon].TongTien - DanhSachHoaDon[MaHoaDon].GiamGia;
                DanhSachHoaDon[MaHoaDon].ListChiTietHoaDon.Remove(itemToRemove);
                BindGridChiTietHoaDon();
                txtBarcode.Text = "";
                txtBarcode.Focus();
            }
            catch (Exception ex)
            {
                Response.Write(ex.ToString());
            }
        }
        protected void UpdateSTT(int MaHoaDon)
        {
            for (int i = 1; i <= DanhSachHoaDon[MaHoaDon].ListChiTietHoaDon.Count; i++)
            {
                DanhSachHoaDon[MaHoaDon].ListChiTietHoaDon[i - 1].STT = i;
            }
        }
        protected void btnHuyHoaDon_Click(object sender, EventArgs e)
        {
            HuyHoaDon();
        }

        protected void btnThemHoaDon_Click(object sender, EventArgs e)
        {
            ThemHoaDonMoi();
        }

        protected void tabControlSoHoaDon_ActiveTabChanged(object source, TabControlEventArgs e)
        {
            BindGridChiTietHoaDon();
        }

        protected void btnThanhToan_Click(object sender, EventArgs e)
        {
            int MaHoaDon = tabControlSoHoaDon.ActiveTabIndex;
            if (DanhSachHoaDon[MaHoaDon].ListChiTietHoaDon.Count > 0)
            {
                float TienKhachThanhToan;
                bool isNumeric = float.TryParse(txtKhachThanhToan.Text, out TienKhachThanhToan);
                if (!isNumeric)
                {
                    HienThiThongBao("Nhập không đúng số tiền !!"); return;
                }

                DanhSachHoaDon[MaHoaDon].KhachThanhToan = TienKhachThanhToan;
                dtBanHangLe dt = new dtBanHangLe();
                string IDKho = Session["IDKho"].ToString();
                string IDNhanVien = Session["IDNhanVien"].ToString();
                int IDKhachHang = 1;
                if (IDKhachHang == 1)// khách lẻ
                {
                    if (TienKhachThanhToan < DanhSachHoaDon[MaHoaDon].KhachCanTra)
                    {
                        txtKhachThanhToan.Text = "";
                        txtKhachThanhToan.Focus();
                        HienThiThongBao("Thanh toán chưa đủ số tiền !!"); return;
                    }
                    string TrangThaiGiamGia = cmbHinhThucGiamGia.Text.ToString();
                    string TyLGiam = txtGiamGia.Text.ToString();
                    object IDHoaDon = dt.InsertHoaDon(IDKho, IDNhanVien, IDKhachHang.ToString(), DanhSachHoaDon[MaHoaDon], TrangThaiGiamGia, TyLGiam);
                    HuyHoaDon();
                    //chitietbuilInLai.ContentUrl = "~/BanHangLe_In.aspx?ID=" + IDHoaDon;
                    //chitietbuilInLai.ShowOnPageLoad = true;
                    string jsInHoaDon = "window.open(\"BanHangLe_In.aspx?ID=" + IDHoaDon + "\", \"PrintingFrame\");";
                    ClientScript.RegisterStartupScript(this.GetType(), "Print", jsInHoaDon, true);
                    txtBarcode.Focus();
                }
            }
            else
            {
                HienThiThongBao("Danh sách hàng hóa trống !!!");
                txtBarcode.Focus();
            }
        }

        protected void txtBarcode_ItemsRequestedByFilterCondition(object source, ListEditItemsRequestedByFilterConditionEventArgs e)
        {
            ASPxComboBox comboBox = (ASPxComboBox)source;
            dsHangHoa.SelectCommand = @"SELECT [ID], [MaNguyenLieu], [TenNguyenLieu], [GiaBan] , [TenDonViTinh],[NhaCungCap]
                                        FROM (
	                                        select CF_NguyenLieu.ID, CF_NguyenLieu.MaNguyenLieu,CF_NguyenLieu.NhaCungCap, CF_NguyenLieu.TenNguyenLieu, CF_NguyenLieu.GiaBan, CF_DonViTinh.TenDonViTinh, 
	                                        row_number()over(order by CF_NguyenLieu.MaNguyenLieu) as [rn] 
	                                        FROM CF_DonViTinh INNER JOIN CF_NguyenLieu ON CF_DonViTinh.ID = CF_NguyenLieu.IDDonViTinh 
                                                               INNER JOIN CF_TonKho ON CF_TonKho.IDNguyenLieu = CF_NguyenLieu.ID
	                                        WHERE ((CF_NguyenLieu.MaNguyenLieu LIKE @MaNguyenLieu) OR CF_NguyenLieu.TenNguyenLieu LIKE @TenHang)  AND (CF_TonKho.IDChiNhanh = @IDKho) AND (CF_TonKho.DaXoa = 0)	 AND [CF_NguyenLieu].TrangThai = 2
	                                        ) as st 
                                        where st.[rn] between @startIndex and @endIndex ORDER BY TenNguyenLieu ASC";
            dsHangHoa.SelectParameters.Clear();
            dsHangHoa.SelectParameters.Add("MaNguyenLieu", TypeCode.String, string.Format("%{0}%", e.Filter));
            dsHangHoa.SelectParameters.Add("TenHang", TypeCode.String, string.Format("%{0}%", e.Filter));
            dsHangHoa.SelectParameters.Add("IDKho", TypeCode.Int32, Session["IDKho"].ToString());
            dsHangHoa.SelectParameters.Add("startIndex", TypeCode.Int64, (e.BeginIndex + 1).ToString());
            dsHangHoa.SelectParameters.Add("endIndex", TypeCode.Int64, (e.EndIndex + 1).ToString());
            comboBox.DataSource = dsHangHoa;
            comboBox.DataBind();
        }

        protected void txtBarcode_ItemRequestedByValue(object source, ListEditItemRequestedByValueEventArgs e)
        {
            long value = 0;
            if (e.Value == null || !Int64.TryParse(e.Value.ToString(), out value))
                return;
            ASPxComboBox comboBox = (ASPxComboBox)source;
            dsHangHoa.SelectCommand = @"SELECT CF_NguyenLieu.ID, CF_NguyenLieu.MaNguyenLieu,CF_NguyenLieu.NhaCungCap, CF_NguyenLieu.TenNguyenLieu, CF_NguyenLieu.GiaBan, CF_DonViTinh.TenDonViTinh 
                                        FROM CF_DonViTinh INNER JOIN CF_NguyenLieu ON CF_DonViTinh.ID = CF_NguyenLieu.IDDonViTinh 
                                                           INNER JOIN CF_NguyenLieu_Barcode ON CF_NguyenLieu_Barcode.IDHangHoa = CF_NguyenLieu.ID 
                                        WHERE (CF_NguyenLieu.ID = @ID) ORDER BY TenNguyenLieu ASC";
            dsHangHoa.SelectParameters.Clear();
            dsHangHoa.SelectParameters.Add("ID", TypeCode.Int64, e.Value.ToString());
            comboBox.DataSource = dsHangHoa;
            comboBox.DataBind();
        }

        protected void btnTimKiem_Click(object sender, EventArgs e)
        {
            if (txtTimKiem.Text != "")
            {
                string TuKhoa = txtTimKiem.Text.ToString();
                dtBanHangLe dt = new dtBanHangLe();
                DataTable db = dt.LayThongHoaDon(TuKhoa);
                if (db.Rows.Count > 0)
                {
                    string IDKH = 1 + "";
                    if (Int32.Parse(db.Rows[0]["IDKhachHang"].ToString()) != 1)
                        IDKH = 0 + "";

                    chitietbuilInLai.ContentUrl = "~/InPhieuGiaoHang.aspx?IDHoaDon=" + db.Rows[0]["ID"].ToString() + "&KT=" + IDKH;
                    chitietbuilInLai.ShowOnPageLoad = true;
                }
                else
                {
                    txtTimKiem.Focus();
                    HienThiThongBao("Không tìm thấy dữ liệu cần tìm?");
                }
            }
            else
            {
                txtTimKiem.Focus();
                HienThiThongBao("Vui lòng nhập thông tin cần tìm?");
            }
        }

        protected void txtGiamGia_TextChanged(object sender, EventArgs e)
        {
            string TrangThaiGiamGia = cmbHinhThucGiamGia.Value.ToString();
            float TienGiam;
            bool isNumeric = float.TryParse(txtGiamGia.Text, out TienGiam);
            if (!isNumeric)
            {
                txtGiamGia.Text = "0";
                int MaHoaDon = tabControlSoHoaDon.ActiveTabIndex;
                DanhSachHoaDon[MaHoaDon].KhachCanTra = DanhSachHoaDon[MaHoaDon].TongTien - float.Parse(txtGiamGia.Text.ToString());
                txtKhachCanTra.Text = (DanhSachHoaDon[MaHoaDon].TongTien - float.Parse(txtGiamGia.Text.ToString())).ToString();
                HienThiThongBao("Nhập không đúng số tiền !!"); return;
            }
            else
            {
                int MaHoaDon = tabControlSoHoaDon.ActiveTabIndex;
                if (TrangThaiGiamGia == "0")
                {
                    //giảm theo %
                    double TyLeGiamGia = double.Parse(txtGiamGia.Text.ToString());
                    if (TyLeGiamGia <= 100 && TyLeGiamGia >= 0)
                    {
                        double TongTien = DanhSachHoaDon[MaHoaDon].TongTien;
                        double TienGiamGia = TongTien * (TyLeGiamGia / (double)100);
                        DanhSachHoaDon[MaHoaDon].KhachCanTra = DanhSachHoaDon[MaHoaDon].TongTien - TienGiamGia;
                        DanhSachHoaDon[MaHoaDon].GiamGia = TienGiamGia;
                        txtKhachCanTra.Text = (DanhSachHoaDon[MaHoaDon].TongTien - TienGiamGia).ToString();
                    }
                    else
                    {
                        txtGiamGia.Text = "0";
                        DanhSachHoaDon[MaHoaDon].GiamGia = 0;
                        DanhSachHoaDon[MaHoaDon].KhachCanTra = DanhSachHoaDon[MaHoaDon].TongTien - float.Parse(txtGiamGia.Text.ToString());
                        txtKhachCanTra.Text = DanhSachHoaDon[MaHoaDon].TongTien +"";
                        HienThiThongBao("Giảm giá theo phần trăm trong khoảng 0% đến 100% !!"); return;
                    }

                }
                else
                {
                    //giảm theo tiền
                    if (float.Parse(txtGiamGia.Text.ToString()) > DanhSachHoaDon[MaHoaDon].KhachCanTra)
                    {
                        txtGiamGia.Text = "0";
                        DanhSachHoaDon[MaHoaDon].GiamGia = 0;
                        DanhSachHoaDon[MaHoaDon].KhachCanTra = DanhSachHoaDon[MaHoaDon].TongTien - float.Parse(txtGiamGia.Text.ToString());
                        txtKhachCanTra.Text = (DanhSachHoaDon[MaHoaDon].TongTien - float.Parse(txtGiamGia.Text.ToString())).ToString();
                        HienThiThongBao("Tiền giảm giá không thể lớn hơn tiền khách cần trả !!"); return;
                    }
                    else
                    {
                        DanhSachHoaDon[MaHoaDon].KhachCanTra = DanhSachHoaDon[MaHoaDon].TongTien - float.Parse(txtGiamGia.Text.ToString());
                        DanhSachHoaDon[MaHoaDon].GiamGia = float.Parse(txtGiamGia.Text.ToString());
                        txtKhachCanTra.Text = (DanhSachHoaDon[MaHoaDon].TongTien - float.Parse(txtGiamGia.Text.ToString())).ToString();

                    }
                }
            }
        }
    }
    [Serializable]
    public class HoaDon
    {
        public int IDHoaDon { get; set; }
        public int IDKhachHang { get; set; }
        public int SoLuongHang { get; set; }
        public double TongTien { get; set; }
        public double GiamGia { get; set; }
        public double KhachCanTra { get; set; }
        public double KhachThanhToan { get; set; }
        public double TienThua { get; set; }
        public List<ChiTietHoaDon> ListChiTietHoaDon { get; set; }
        public HoaDon()
        {
            IDHoaDon = 0;
            IDKhachHang = 0;
            SoLuongHang = 0;
            TongTien = 0;
            GiamGia = 0;
            KhachCanTra = 0;
            KhachThanhToan = 0;
            TienThua = 0;
            ListChiTietHoaDon = new List<ChiTietHoaDon>();
        }
    }
    [Serializable]
    public class ChiTietHoaDon
    {
        public int STT { get; set; }
        public string MaHang { get; set; }
        public int IDHangHoa { get; set; }
        public string TenHang { get; set; }
        public int MaDonViTinh { get; set; }
        public float TonKho { get; set; }
        public string DonViTinh { get; set; }
        public int SoLuong { get; set; }
        public double DonGia { get; set; }
        public double GiaMua { get; set; }
        public double ThanhTien { get; set; }
        public string HinhAnh { get; set; }
        public ChiTietHoaDon()
        {
            STT = 0;
            MaHang = "0";
            IDHangHoa = 0;
            TenHang = " ";
            MaDonViTinh = 0;
            TonKho = 0;
            DonViTinh = "0";
            SoLuong = 0;
            DonGia = 0;
            GiaMua = 0;
            ThanhTien = 0;
            HinhAnh = "0";
        }
    }
}