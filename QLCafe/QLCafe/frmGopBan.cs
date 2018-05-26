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
using QLCafe.DAO;
using QLCafe.DTO;
using QLCafe.BUS;

namespace QLCafe
{
    public partial class frmGopBan : DevExpress.XtraEditors.XtraForm
    {
       // int IDBan = frmBanHang.IDBan;
        //int IDHoaDon = DAO_BanHang.IDHoaDon(frmBanHang.IDBan);
        string IDChiNhanh = frmDangNhap.NguoiDung.Idchinhanh;
        List<ChiTietHoaDonA1> listChiTietHoaDonA1 = new List<ChiTietHoaDonA1>();
        List<ChiTietHoaDonB1> listChiTietHoaDonB1 = new List<ChiTietHoaDonB1>();

        public delegate void GetKT(int KT, int IDBanA, int IDBanB, int IDHoaDonTinhTong);
        public GetKT MyGetDataGopBan;

        public frmGopBan()
        {
            InitializeComponent();
        }
        private void btnAB2_Click(object sender, EventArgs e)
        {
            ChuyenASangB();
        }
        private void btnBA1_Click(object sender, EventArgs e)
        {
            ChuyenBSangA();
        }
        public void ChuyenASangB()
        {
            int IDBanMoi = Int32.Parse(cmbBanB.EditValue.ToString());
            foreach (ChiTietHoaDonA1 item in listChiTietHoaDonA1)
            {
                listChiTietHoaDonB1.Add(new ChiTietHoaDonB1
                {
                    // nếu muốn kt trùng là ở đây
                    MaHangHoa = item.MaHangHoa,
                    TenHangHoa = item.TenHangHoa,
                    DonViTinh = item.DonViTinh,
                    DonGia = item.DonGia,
                    ThanhTien = item.ThanhTien,
                    SoLuong = item.SoLuong,
                    TrongLuong = item.TrongLuong,
                });
            }
            listChiTietHoaDonA1.Clear();
            gridControlB.DataSource = null;
            gridControlB.Refresh();
            gridControlB.DataSource = listChiTietHoaDonB1;

            gridControlA.DataSource = null;
            gridControlA.Refresh();
            gridControlA.DataSource = listChiTietHoaDonA1;
        }
        public void ChuyenBSangA()
        {
            int IDHoaDon = DAO_Setting.KiemtraGiaDien(frmDangNhap.NguoiDung.Idchinhanh) == 0 ? DAO_BanHang.IDHoaDon(frmBanHang.IDBan) : DAO_BanHang.IDHoaDon(frmBanHang2.IDBan);
            int IDBan = DAO_Setting.KiemtraGiaDien(frmDangNhap.NguoiDung.Idchinhanh) == 0 ? frmBanHang.IDBan : frmBanHang2.IDBan;
            int IDBanMoi = IDBan;// lấy lại IDBan của A
            foreach (ChiTietHoaDonB1 item in listChiTietHoaDonB1)
            {
                listChiTietHoaDonA1.Add(new ChiTietHoaDonA1
                {
                    MaHangHoa = item.MaHangHoa,
                    TenHangHoa = item.TenHangHoa,
                    DonViTinh = item.DonViTinh,
                    DonGia = item.DonGia,
                    ThanhTien = item.ThanhTien,
                    SoLuong = item.SoLuong,
                    TrongLuong = item.TrongLuong,
                });
            }
            listChiTietHoaDonB1.Clear();
            gridControlA.DataSource = null;
            gridControlA.Refresh();
            gridControlA.DataSource = listChiTietHoaDonA1;

            gridControlB.DataSource = null;
            gridControlB.Refresh();
            gridControlB.DataSource = listChiTietHoaDonB1;
        }
        private void cmbKhuVucB_EditValueChanged(object sender, EventArgs e)
        {
            cmbBanB.Enabled = true;
            btnBA1.Enabled = false;
            btnAB2.Enabled = false;
            btnThucHien.Enabled = false;
            int IDKhuVuc = Int32.Parse(cmbKhuVucB.EditValue.ToString());
            DanhSachBanTheoKhuVuc(IDKhuVuc);
            listChiTietHoaDonB1.Clear();
            gridControlB.DataSource = null;
            gridControlB.Refresh();
        }

        private void cmbBanB_EditValueChanged(object sender, EventArgs e)
        {
            listChiTietHoaDonB1.Clear(); 
            gridControlB.DataSource = null;
            gridControlB.Refresh();
            btnBA1.Enabled = true;
            btnAB2.Enabled = true;
            btnThucHien.Enabled = true;
            DanhSachHangHoaB(Int32.Parse(cmbBanB.EditValue.ToString()));
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            //if (MessageBox.Show("Bạn thật sự muốn thoát. Dữ liệu thay đổi không được lưu lại?", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.OK)
            //{
                this.Close();
            //}
        }

        private void frmGopBan_Load(object sender, EventArgs e)
        {
            LamMoi();
        }
        public void LamMoi()
        {
            int IDHoaDon = DAO_Setting.KiemtraGiaDien(frmDangNhap.NguoiDung.Idchinhanh) == 0 ? DAO_BanHang.IDHoaDon(frmBanHang.IDBan) : DAO_BanHang.IDHoaDon(frmBanHang2.IDBan);
            int IDBan = DAO_Setting.KiemtraGiaDien(frmDangNhap.NguoiDung.Idchinhanh) == 0 ? frmBanHang.IDBan : frmBanHang2.IDBan;
            DanhSachHangHoaA();
            cmbBanA.Properties.NullText = DAO_ChuyenBan.LayTenBan(IDBan);
            int IDkhuVuc = DAO_ChuyenBan.LayIDKhuVuc(IDBan);
            cmbKhuVucA.Properties.NullText = DAO_ChuyenBan.LayTenKhuVuc(IDkhuVuc).ToString();
            DataTable dt = BUS_KhuVuc.DanhSachBanTheoKhuVuc(IDChiNhanh);
            cmbKhuVucB.Properties.DataSource = dt;
            cmbKhuVucB.Properties.ValueMember = "ID";
            cmbKhuVucB.Properties.DisplayMember = "TenKhuVuc";
        }
        public void DanhSachBanTheoKhuVuc(int IDKhuVuc)
        {
            int IDHoaDon = DAO_Setting.KiemtraGiaDien(frmDangNhap.NguoiDung.Idchinhanh) == 0 ? DAO_BanHang.IDHoaDon(frmBanHang.IDBan) : DAO_BanHang.IDHoaDon(frmBanHang2.IDBan);
            int IDBan = DAO_Setting.KiemtraGiaDien(frmDangNhap.NguoiDung.Idchinhanh) == 0 ? frmBanHang.IDBan : frmBanHang2.IDBan;
            //danh sách bàn phải có người : 2
            List<DTO_BAN> ban = DAO_ChuyenBan.DanhSachBanTheoKhuVuc(IDKhuVuc, 2, IDBan);
            cmbBanB.Properties.DataSource = ban;
            cmbBanB.Properties.ValueMember = "Id";
            cmbBanB.Properties.DisplayMember = "Tenban";
        }
        public void DanhSachHangHoaB(int IDBanB)
        {
            listChiTietHoaDonB1.Clear();
            gridViewB.OptionsSelection.EnableAppearanceFocusedRow = false;// Ẩn dòng đầu...
            List<DTO_DanhSachMenu> MonAnThuong = DAO_DanhSachMonAn.Instance.GetMonAnThuong(DAO_BanHang.IDHoaDon(IDBanB), frmDangNhap.NguoiDung.Idchinhanh);
           // List<DTO_DanhSachMenu> MonAnTuChon = DAO_DanhSachMonAn.Instance.GetMonAnTuChon(DAO_BanHang.IDHoaDon(IDBanB), frmDangNhap.NguoiDung.Idchinhanh);
            foreach (DTO_DanhSachMenu item in MonAnThuong)
            {
                listChiTietHoaDonB1.Add(new ChiTietHoaDonB1
                {
                    MaHangHoa = item.MaHangHoa,
                    TenHangHoa = item.TenHangHoa,
                    DonViTinh = item.DonViTinh,
                    DonGia = item.DonGia,
                    ThanhTien = item.ThanhTien,
                    TrongLuong = item.TrongLuong,
                    SoLuong = item.SoLuong,
                });
            }
            //foreach (DTO_DanhSachMenu item in MonAnTuChon)
            //{
            //    listChiTietHoaDonB1.Add(new ChiTietHoaDonB1
            //    {
            //        MaHangHoa = item.MaHangHoa,
            //        TenHangHoa = item.TenHangHoa,
            //        DonViTinh = item.DonViTinh,
            //        DonGia = item.DonGia,
            //        ThanhTien = item.ThanhTien,
            //        TrongLuong = item.TrongLuong,
            //        SoLuong = item.SoLuong,
            //    });
            //}
            gridControlB.DataSource = null;
            gridControlB.Refresh();
            gridControlB.DataSource = listChiTietHoaDonB1;
        }
        public void DanhSachHangHoaA()
        {
            int IDHoaDon = DAO_Setting.KiemtraGiaDien(frmDangNhap.NguoiDung.Idchinhanh) == 0 ? DAO_BanHang.IDHoaDon(frmBanHang.IDBan) : DAO_BanHang.IDHoaDon(frmBanHang2.IDBan);
            int IDBan = DAO_Setting.KiemtraGiaDien(frmDangNhap.NguoiDung.Idchinhanh) == 0 ? frmBanHang.IDBan : frmBanHang2.IDBan;
            listChiTietHoaDonA1.Clear();
            gridViewA.OptionsSelection.EnableAppearanceFocusedRow = false;// Ẩn dòng đầu...
            // lấy món ăn theo IDBan
            List<DTO_DanhSachMenu> MonAnThuong = DAO_DanhSachMonAn.Instance.GetMonAnThuong(DAO_BanHang.IDHoaDon(IDBan), frmDangNhap.NguoiDung.Idchinhanh);
            //List<DTO_DanhSachMenu> MonAnTuChon = DAO_DanhSachMonAn.Instance.GetMonAnTuChon(DAO_BanHang.IDHoaDon(IDBan), frmDangNhap.NguoiDung.Idchinhanh);
            foreach (DTO_DanhSachMenu item in MonAnThuong)
            {
                listChiTietHoaDonA1.Add(new ChiTietHoaDonA1
                {
                    MaHangHoa = item.MaHangHoa,
                    TenHangHoa = item.TenHangHoa,
                    DonViTinh = item.DonViTinh,
                    DonGia = item.DonGia,
                    ThanhTien = item.ThanhTien,
                    TrongLuong = item.TrongLuong,
                    SoLuong = item.SoLuong,
                });
            }
            //foreach (DTO_DanhSachMenu item in MonAnTuChon)
            //{
            //    listChiTietHoaDonA1.Add(new ChiTietHoaDonA1
            //    {
            //        MaHangHoa = item.MaHangHoa,
            //        TenHangHoa = item.TenHangHoa,
            //        DonViTinh = item.DonViTinh,
            //        DonGia = item.DonGia,
            //        ThanhTien = item.ThanhTien,
            //        TrongLuong = item.TrongLuong,
            //        SoLuong = item.SoLuong,
            //    });
            //}
            gridControlA.DataSource = null;
            gridControlA.Refresh();
            gridControlA.DataSource = listChiTietHoaDonA1;
        }
        private void btnLamLai_Click(object sender, EventArgs e)
        {
            LamMoi();
            int IDBanMoi = 0;
            if (cmbBanB.EditValue != null)
            {
                IDBanMoi = Int32.Parse(cmbBanB.EditValue.ToString());
                DanhSachHangHoaB(IDBanMoi);
            }
        }

        private void btnThucHien_Click(object sender, EventArgs e)
        {
            GopBan();
        }
        public void GopBan()
        {
            int IDHoaDon = DAO_Setting.KiemtraGiaDien(frmDangNhap.NguoiDung.Idchinhanh) == 0 ? DAO_BanHang.IDHoaDon(frmBanHang.IDBan) : DAO_BanHang.IDHoaDon(frmBanHang2.IDBan);
            int IDBan = DAO_Setting.KiemtraGiaDien(frmDangNhap.NguoiDung.Idchinhanh) == 0 ? frmBanHang.IDBan : frmBanHang2.IDBan;
            if (listChiTietHoaDonA1.Count > 0 && listChiTietHoaDonB1.Count > 0)
            {
                MessageBox.Show("Bạn chưa gộp bàn. Vui lòng kiểm tra lại?", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (listChiTietHoaDonB1.Count > 0)
            {
                int IDBanA = IDBan;
                int IDBanB = Int32.Parse(cmbBanB.EditValue.ToString());
                int IDHoaDonB = DAO_BanHang.IDHoaDon(IDBanB);
                int IDHoaDonA = IDHoaDon;

                // A Chuyển sang B, xóa toàn bộ hóa đơn A, cập nhật hóa đơn B, đưa trạng thái bàn A về null, xóa chi tiết bàn B
                if (DAO_BAN.XoaBanVeMatDinh(IDBanA, frmDangNhap.NguoiDung.Idchinhanh) == true && DAO_ChuyenBan.XoaChiTietBanCu(IDHoaDonA, IDBanA) == true && DAO_GopBan.XoaHoaDonCu(IDHoaDonA, IDBanA) == true && DAO_ChuyenBan.XoaChiTietBanCu(IDHoaDonB, IDBanB) == true)
                {
                    //Thêm lại chi tiết bàn B,
                    foreach (ChiTietHoaDonB1 item in listChiTietHoaDonB1)
                    {
                        string MaHang = item.MaHangHoa;
                        float TrongLuong = item.TrongLuong;
                        int SL = item.SoLuong;
                        float DonGia = item.DonGia;
                        float ThanhTien = item.ThanhTien;
                        int IDHangHoa = TrongLuong > 0 ? DAO_Setting.LayIDHangHoaTuChon(MaHang) : DAO_Setting.LayIDHangHoa(MaHang);
                        int IDDonViTinh = TrongLuong > 0 ? DAO_Setting.LayIDDonViTinhTuChon(MaHang) : DAO_Setting.LayIDDonViTinh(MaHang);

                        if (DAO_ChiTietHoaDon.KiemTraHangHoa(IDHoaDonB, IDHangHoa, IDBanB, TrongLuong,IDChiNhanh) == false)
                        {
                            DAO_GoiMon.ThemChiTietHoaDon(IDHoaDonB, IDHangHoa, SL, DonGia, ThanhTien, IDBanB, MaHang, IDDonViTinh, TrongLuong, frmDangNhap.NguoiDung.Idchinhanh); // thêm chi tiết hóa đơn mới
                        }
                        else
                        {
                            DAO_GoiMon.CapNhatChiTietHoaDon(IDHoaDonB, SL, ThanhTien, IDHangHoa, IDBanB, IDChiNhanh);
                        }

                    }
                    if (MyGetDataGopBan != null)
                    {
                        MyGetDataGopBan(1, IDBanA, IDBanB, IDHoaDonB);
                        this.Close();
                    }
                }
            }
            else if (listChiTietHoaDonA1.Count > 0)
            {
                // B Chuyển sang A, xóa toàn bộ hóa đơn B, cập nhật hóa đơn A
                int IDBanA = IDBan;
                int IDBanB = Int32.Parse(cmbBanB.EditValue.ToString());
                int IDHoaDonB = DAO_BanHang.IDHoaDon(IDBanB);
                int IDHoaDonA = IDHoaDon;
                if (DAO_BAN.XoaBanVeMatDinh(IDBanB, frmDangNhap.NguoiDung.Idchinhanh) == true && DAO_ChuyenBan.XoaChiTietBanCu(IDBanB, IDBanB) && DAO_GopBan.XoaHoaDonCu(IDHoaDonB, IDBanB) && DAO_ChuyenBan.XoaChiTietBanCu(IDHoaDonA, IDBanA))
                {
                    foreach (ChiTietHoaDonA1 item in listChiTietHoaDonA1)
                    {
                        string MaHang = item.MaHangHoa;
                        float TrongLuong = item.TrongLuong;
                        int SL = item.SoLuong;
                        float DonGia = item.DonGia;
                        float ThanhTien = item.ThanhTien;
                        int IDHangHoa = TrongLuong > 0 ? DAO_Setting.LayIDHangHoaTuChon(MaHang) : DAO_Setting.LayIDHangHoa(MaHang);
                        int IDDonViTinh = TrongLuong > 0 ? DAO_Setting.LayIDDonViTinhTuChon(MaHang) : DAO_Setting.LayIDDonViTinh(MaHang);
                        if (DAO_ChiTietHoaDon.KiemTraHangHoa(IDHoaDonA, IDHangHoa, IDBanA, TrongLuong,IDChiNhanh) == false)
                        {
                            DAO_GoiMon.ThemChiTietHoaDon(IDHoaDonA, IDHangHoa, SL, DonGia, ThanhTien, IDBanA, MaHang, IDDonViTinh, TrongLuong, frmDangNhap.NguoiDung.Idchinhanh); // thêm chi tiết hóa đơn mới
                        }
                        else
                        {
                            DAO_GoiMon.CapNhatChiTietHoaDon(IDHoaDonA, SL, ThanhTien, IDHangHoa, IDBanA, IDChiNhanh);
                        }
                    }
                    if (MyGetDataGopBan != null)
                    {
                        MyGetDataGopBan(1, IDBanA, IDBanB, IDHoaDonA);
                        this.Close();
                    }
                }
            }
            else
            {
                MessageBox.Show("Gộp bàn thất bại. Vui lòng kiểm tra lại?", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        //--------------------------------------------
        public class ChiTietHoaDonA1
        {
            private float trongLuong;

            public float TrongLuong
            {
                get { return trongLuong; }
                set { trongLuong = value; }
            }
            private float thanhTien;

            public float ThanhTien
            {
                get { return thanhTien; }
                set { thanhTien = value; }
            }

            private float donGia;

            public float DonGia
            {
                get { return donGia; }
                set { donGia = value; }
            }
            private int soLuong;

            public int SoLuong
            {
                get { return soLuong; }
                set { soLuong = value; }
            }
            private string donViTinh;

            public string DonViTinh
            {
                get { return donViTinh; }
                set { donViTinh = value; }
            }
            private string tenHangHoa;

            public string TenHangHoa
            {
                get { return tenHangHoa; }
                set { tenHangHoa = value; }
            }
            private string maHangHoa;

            public string MaHangHoa
            {
                get { return maHangHoa; }
                set { maHangHoa = value; }
            }
        }
        //--------------------------------------------
        public class ChiTietHoaDonB1
        {
            private float trongLuong;

            public float TrongLuong
            {
                get { return trongLuong; }
                set { trongLuong = value; }
            }
            private float thanhTien;

            public float ThanhTien
            {
                get { return thanhTien; }
                set { thanhTien = value; }
            }

            private float donGia;

            public float DonGia
            {
                get { return donGia; }
                set { donGia = value; }
            }
            private int soLuong;

            public int SoLuong
            {
                get { return soLuong; }
                set { soLuong = value; }
            }
            private string donViTinh;

            public string DonViTinh
            {
                get { return donViTinh; }
                set { donViTinh = value; }
            }
            private string tenHangHoa;

            public string TenHangHoa
            {
                get { return tenHangHoa; }
                set { tenHangHoa = value; }
            }
            private string maHangHoa;

            public string MaHangHoa
            {
                get { return maHangHoa; }
                set { maHangHoa = value; }
            }
        }

        private void btnAB2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                GopBan();
        }

        private void btnBA1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                GopBan();
        }
    }
}