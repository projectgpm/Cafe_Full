using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using QLCafe.BUS;
using QLCafe.DAO;
using QLCafe.DTO;
using DevExpress.XtraGrid.Views.Grid;

namespace QLCafe
{
    public partial class frmGoiMon : DevExpress.XtraEditors.XtraForm
    {
        //int IDBan = frmBanHang.IDBan;
       // int IDHoaDon = DAO_BanHang.IDHoaDon(frmBanHang.IDBan);
        List<ChiTietHoaDon> listChiTietHoaDon = new List<ChiTietHoaDon>();

        public delegate void GetKT(int KT, int IDHoaDon);
        public GetKT MyGetData;

        public frmGoiMon()
        {
            InitializeComponent();
        }
        private void btnHuy_Click(object sender, EventArgs e)
        {
            //if (MessageBox.Show("Xóa những món đã chọn?", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.OK)
            //{
                this.Close();
            //}
        }
        private void frmGoiMon_Load(object sender, EventArgs e)
        {
            int IDHoaDon = DAO_Setting.KiemtraGiaDien(frmDangNhap.NguoiDung.Idchinhanh) == 0 ? DAO_BanHang.IDHoaDon(frmBanHang.IDBan) : DAO_BanHang.IDHoaDon(frmBanHang2.IDBan);
            int IDBan = DAO_Setting.KiemtraGiaDien(frmDangNhap.NguoiDung.Idchinhanh) == 0 ? frmBanHang.IDBan : frmBanHang2.IDBan;
            DanhSachMonAnBanChay();
            listChiTietHoaDon.Clear();
            lblTenBan.Text = DAO_GoiMon.TenBan(IDBan);
          //  DataTable danhsachtuchon = DAO_HangHoa.DanhSachTuChon();
           
        }
        public void DanhSachMonAnBanChay()
        {
            tblTableMonAn.Controls.Clear();
            if (txtTimKiem.Text == "")
            {
                DataTable db = BUS_HangHoa.DSHangHoa_Full(frmDangNhap.NguoiDung.Idchinhanh);
                if (db.Rows.Count > 0)
                {
                    foreach (DataRow dr in db.Rows)
                    {
                        SimpleButton btn = new SimpleButton();
                        btn.Width = 108;
                        btn.Height = 60;
                        btn.Appearance.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
                        btn.Text = dr["TenHangHoa"].ToString();
                        btn.Click += btn_Click;
                        btn.KeyDown+=btn_KeyDown;
                        btn.Tag = dr["ID"].ToString();
                        btn.Appearance.Font = new Font("Tahoma", 11);
                        btn.ForeColor = Color.Black;
                        btn.StyleController = null;
                        btn.LookAndFeel.UseDefaultLookAndFeel = false;
                        tblTableMonAn.Controls.Add(btn);
                    }
                }
            }
            else
            {
                DataTable db = BUS_HangHoa.DSHangHoaTimKiem(txtTimKiem.Text.ToString(), frmDangNhap.NguoiDung.Idchinhanh);
                if (db.Rows.Count > 0)
                {
                    foreach (DataRow dr in db.Rows)
                    {
                        SimpleButton btn = new SimpleButton();
                        btn.Width = 108;
                        btn.Height = 60;
                        btn.Appearance.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
                        btn.Text = dr["TenHangHoa"].ToString();
                        btn.Click += btn_Click;
                        btn.KeyDown += btn_KeyDown;
                        btn.Tag = dr["ID"].ToString();
                        btn.Appearance.Font = new Font("Tahoma", 11);
                        btn.ForeColor = Color.Black;
                        btn.StyleController = null;
                        btn.LookAndFeel.UseDefaultLookAndFeel = false;
                        tblTableMonAn.Controls.Add(btn);
                    }
                }
            }
        }

        private void btn_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                GoiMon();
            }
        }

        private void btn_Click(object sender, EventArgs e)
        {
            string ID = (sender as SimpleButton).Tag.ToString();
            DataTable dt = DAO_HangHoa.DanhSachHangHoa_ID(Int32.Parse(ID));
            ThemMonAn(dt,0);
            BindGridChiTietHoaDon();
        }
        public void ThemMonAn(DataTable tbThongTin, float TrongLuong)
        {
            int IDHoaDon = DAO_Setting.KiemtraGiaDien(frmDangNhap.NguoiDung.Idchinhanh) == 0 ? DAO_BanHang.IDHoaDon(frmBanHang.IDBan) : DAO_BanHang.IDHoaDon(frmBanHang2.IDBan);
            int IDBan = DAO_Setting.KiemtraGiaDien(frmDangNhap.NguoiDung.Idchinhanh) == 0 ? frmBanHang.IDBan : frmBanHang2.IDBan;
            int IDBangGia = DAO_GoiMon.LayIDBanGia(IDBan);
            int IDHangHoa = Int32.Parse(tbThongTin.Rows[0]["ID"].ToString());
            string MaHangHoa = tbThongTin.Rows[0]["MaHangHoa"].ToString();
            string TenHangHoa = tbThongTin.Rows[0]["TenHangHoa"].ToString();
            string TenDonViTinh = tbThongTin.Rows[0]["TenDonViTinh"].ToString();
            float GiaBan = float.Parse(tbThongTin.Rows[0]["GiaBan"].ToString());
            if (IDBangGia != 0)
            {
                GiaBan = DAO_GoiMon.LayGiaBan(IDHangHoa, IDBangGia);
            }
           
            int IDDonViTinh = Int32.Parse(tbThongTin.Rows[0]["IDDonViTinh"].ToString());
            int idban = IDBan;
            int SL = 1;
            //-------------------------------------------
            int KT = 0;
            foreach (ChiTietHoaDon item in listChiTietHoaDon)
            {
                if (item.IDHangHoa == IDHangHoa)
                {
                    KT = 1;
                    item.SoLuong = item.SoLuong + SL;
                    item.ThanhTien = item.SoLuong * item.DonGia;
                    break;
                }
            }
            if (KT == 0)
            {
                listChiTietHoaDon.Add(new ChiTietHoaDon()
                {
                    IDHangHoa = IDHangHoa,
                    MaHangHoa = MaHangHoa,
                    IDDonViTinh = IDDonViTinh,
                    SoLuong = SL,
                    DonGia = GiaBan,
                    ThanhTien = GiaBan * SL,
                    IdBan = idban,
                    TenDonViTinh = TenDonViTinh,
                    TenHangHoa = TenHangHoa,
                    TrongLuong = TrongLuong
                });
            }
        }
        public void BindGridChiTietHoaDon()
        {
            gridViewHangHoa.OptionsSelection.EnableAppearanceFocusedRow = false;// Ẩn dòng đầu...
            gridControllHangHoa.DataSource = null;
            gridControllHangHoa.Refresh();
            gridControllHangHoa.DataSource = listChiTietHoaDon;
        }
        private void gridViewHangHoa_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
            {
                if (MessageBox.Show("Xóa Món Ăn?", "Thông Báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
                    return;
                GridView view = sender as GridView;
                view.DeleteRow(view.FocusedRowHandle);

            }
        }

        private void btnHoanTat_Click(object sender, EventArgs e)
        {
            GoiMon();
        }
        public void GoiMon()
        {
            int IDHoaDon = DAO_Setting.KiemtraGiaDien(frmDangNhap.NguoiDung.Idchinhanh) == 0 ? DAO_BanHang.IDHoaDon(frmBanHang.IDBan) : DAO_BanHang.IDHoaDon(frmBanHang2.IDBan);
            int IDBan = DAO_Setting.KiemtraGiaDien(frmDangNhap.NguoiDung.Idchinhanh) == 0 ? frmBanHang.IDBan : frmBanHang2.IDBan;
            if (listChiTietHoaDon.Count > 0)
            {
                if (IDHoaDon == 0)
                {
                    int IDNhanVien = frmDangNhap.NguoiDung.Id;
                    object ID = DAO_GoiMon.ThemHoaDon(IDBan, IDNhanVien,frmDangNhap.NguoiDung.Idchinhanh);
                    IDHoaDon = Int32.Parse(ID.ToString());
                    if (ID != null)
                    {
                        foreach (ChiTietHoaDon item in listChiTietHoaDon)
                        {
                            int IDHangHoa = item.IDHangHoa;
                            int SL = item.SoLuong;
                            float DonGia = item.DonGia;
                            float ThanhTien = item.ThanhTien;
                            int IdBan = item.IdBan;
                            string MaHangHoa = item.MaHangHoa;
                            int IDDonViTinh = item.IDDonViTinh;
                            float TrongLuong = item.TrongLuong;
                            DAO_GoiMon.ThemChiTietHoaDon(ID, IDHangHoa, SL, DonGia, ThanhTien, IDBan, MaHangHoa, IDDonViTinh, TrongLuong, frmDangNhap.NguoiDung.Idchinhanh);
                        }
                        DAO_BAN.DoiTrangThaiBanCoNguoi(IDBan);
                    }
                }
                else
                {
                    foreach (ChiTietHoaDon item in listChiTietHoaDon)
                    {
                        int IDHangHoa = item.IDHangHoa;
                        int IdBan = item.IdBan;
                        int SL = item.SoLuong;
                        float DonGia = item.DonGia;
                        float ThanhTien = item.ThanhTien;
                        string MaHangHoa = item.MaHangHoa;
                        int IDDonViTinh = item.IDDonViTinh;
                        float TrongLuong = item.TrongLuong;
                        if (DAO_ChiTietHoaDon.KiemTraHangHoa(IDHoaDon, IDHangHoa, IDBan, TrongLuong,frmDangNhap.NguoiDung.Idchinhanh) == false)
                        {
                            DAO_GoiMon.ThemChiTietHoaDon(IDHoaDon, IDHangHoa, SL, DonGia, ThanhTien, IDBan, MaHangHoa, IDDonViTinh, TrongLuong, frmDangNhap.NguoiDung.Idchinhanh);
                        }
                        else
                        {
                            DAO_GoiMon.CapNhatChiTietHoaDon(IDHoaDon, SL, ThanhTien, IDHangHoa, IdBan,frmDangNhap.NguoiDung.Idchinhanh);
                        }
                    }
                }
                if (MyGetData != null)
                {
                    MyGetData(1, IDHoaDon);
                    this.Close();
                }
            }
            else
            {
                MessageBox.Show("Danh sách món ăn rỗng?", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
           
        }
        //------------------------------------------
        public class ChiTietHoaDon
        {
            private float trongLuong;

            public float TrongLuong
            {
                get { return trongLuong; }
                set { trongLuong = value; }
            }
            private string tenHangHoa;
            public string TenHangHoa
            {
                get { return tenHangHoa; }
                set { tenHangHoa = value; }
            }
            private string tenDonViTinh;
            public string TenDonViTinh
            {
                get { return tenDonViTinh; }
                set { tenDonViTinh = value; }
            }
            private int iDHangHoa;
            public int IDHangHoa
            {
                get { return iDHangHoa; }
                set { iDHangHoa = value; }
            }
            private int soLuong;
            public int SoLuong
            {
                get { return soLuong; }
                set { soLuong = value; }
            }
            private float donGia;
            public float DonGia
            {
                get { return donGia; }
                set { donGia = value; }
            }
            private float thanhTien;
            public float ThanhTien
            {
                get { return thanhTien; }
                set { thanhTien = value; }
            }
            private string maHangHoa;
            public string MaHangHoa
            {
                get { return maHangHoa; }
                set { maHangHoa = value; }
            }
            private int iDDonViTinh;
            public int IDDonViTinh
            {
                get { return iDDonViTinh; }
                set { iDDonViTinh = value; }
            }
            private int idBan;
            public int IdBan
            {
                get { return idBan; }
                set { idBan = value; }
            }
        }



     

        private void txtTimKiem_EditValueChanged(object sender, EventArgs e)
        {
            DanhSachMonAnBanChay();
        }

      
    }
}