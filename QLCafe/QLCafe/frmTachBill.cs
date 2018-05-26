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
using QLCafe.Report;
using DevExpress.DataAccess.Sql;
using DevExpress.XtraReports.UI;

namespace QLCafe
{
    public partial class frmTachBill : DevExpress.XtraEditors.XtraForm
    {
       // int IDBan = frmBanHang.IDBan;
        //int IDHoaDon = DAO_BanHang.IDHoaDon(frmBanHang.IDBan);
        List<ChiTietHoaDonA1> listChiTietMonAn = new List<ChiTietHoaDonA1>();
        List<ChiTietHoaDonB1> listChiTietMonAnThanhToan = new List<ChiTietHoaDonB1>();
        

        public delegate void GetString(int KT, int IDHoaDon, int IDBan);
        public GetString MyGetData;
        public frmTachBill()
        {
            InitializeComponent();
        }

        private void frmTachBill_Load(object sender, EventArgs e)
        {
            //gridViewA.OptionsSelection.EnableAppearanceFocusedRow = false;// Ẩn dòng đầu...
            gridViewB.OptionsSelection.EnableAppearanceFocusedRow = false;// Ẩn dòng đầu...
            //gridViewC.OptionsSelection.EnableAppearanceFocusedRow = false;// Ẩn dòng đầu...

            lblTenBan.Text = DAO_GoiMon.TenBan(DAO_Setting.KiemtraGiaDien(frmDangNhap.NguoiDung.Idchinhanh) == 0 ? frmBanHang.IDBan : frmBanHang2.IDBan);
            DanhSachHangHoaA();
           
        }

        private void LamMoi()
        {
            DanhSachHangHoaA();
            listChiTietMonAnThanhToan.Clear();
            gridControlB.DataSource = null;
            gridControlB.DataSource = listChiTietMonAnThanhToan;
        }

       
        private void DanhSachHangHoaA()
        {
            listChiTietMonAn.Clear();
            // lấy món ăn theo IDBan
            int IDBan = DAO_Setting.KiemtraGiaDien(frmDangNhap.NguoiDung.Idchinhanh) == 0 ? frmBanHang.IDBan : frmBanHang2.IDBan;
            List<DTO_DanhSachMenu> MonAnThuong = DAO_DanhSachMonAn.Instance.GetMonAnThuong(DAO_BanHang.IDHoaDon(IDBan), frmDangNhap.NguoiDung.Idchinhanh);
            //List<DTO_DanhSachMenu> MonAnTuChon = DAO_DanhSachMonAn.Instance.GetMonAnTuChon(DAO_BanHang.IDHoaDon(IDBan), frmDangNhap.NguoiDung.Idchinhanh);
            foreach (DTO_DanhSachMenu item in MonAnThuong)
            {
                listChiTietMonAn.Add(new ChiTietHoaDonA1
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
            //    listChiTietMonAn.Add(new ChiTietHoaDonA1
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
            gridControlA.DataSource = listChiTietMonAn;
            if (listChiTietMonAn.Count > 0)
            {
                btnABMonAn.Enabled = true;
                btnLamLaiABMonAn.Enabled = true;
            }
            else
            {
                btnABMonAn.Enabled = false;
                btnLamLaiABMonAn.Enabled = false;
            }
        }


        private void btnHuy_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnLamLaiABMonAn_Click(object sender, EventArgs e)
        {
            LamMoi();
        }

        private void btnABMonAn_Click(object sender, EventArgs e)
        {
            frmKiemTraTachBan fr = new frmKiemTraTachBan();
            fr.MyGetData = new frmKiemTraTachBan.GetString(GetValue);
            fr.ShowDialog();
        }

        private void GetValue(int KT, int SoLuong)
        {
            if (KT == 1 && listChiTietMonAn.Count > 0)
            {
                int SoLuongA = Int32.Parse(gridViewA.GetRowCellValue(gridViewA.FocusedRowHandle, gridViewA.Columns[3]).ToString());
                string TenHangHoa = gridViewA.GetRowCellValue(gridViewA.FocusedRowHandle, gridViewA.Columns[1]).ToString();
                string MaHangHoa = gridViewA.GetRowCellValue(gridViewA.FocusedRowHandle, gridViewA.Columns[0]).ToString();
                string DonViTinh = gridViewA.GetRowCellValue(gridViewA.FocusedRowHandle, gridViewA.Columns[2]).ToString();
                float DonGia = float.Parse(gridViewA.GetRowCellValue(gridViewA.FocusedRowHandle, gridViewA.Columns[4]).ToString());
                float TrongLuong = float.Parse(gridViewA.GetRowCellValue(gridViewA.FocusedRowHandle, gridViewA.Columns[6]).ToString());
                if (SoLuongA == SoLuong)
                {
                    int dongHienTai = gridViewA.FocusedRowHandle;
                    listChiTietMonAnThanhToan.Add(new ChiTietHoaDonB1
                    {
                        MaHangHoa = MaHangHoa,
                        TenHangHoa = TenHangHoa,
                        DonViTinh = DonViTinh,
                        DonGia = DonGia,
                        TrongLuong = TrongLuong,
                        ThanhTien = TrongLuong > 0 ? (SoLuongA * (TrongLuong * DonGia)) : SoLuongA * DonGia,
                        SoLuong = SoLuongA,
                    });
                    listChiTietMonAn.RemoveAt(dongHienTai);// xóa dòng hiện tại A1
                }
                else if (SoLuongA < SoLuong)
                {
                    MessageBox.Show("Số lượng thanh toán không đủ.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    int KiemTra = 0;
                    int SoLuongB = 0;
                    foreach (ChiTietHoaDonA1 item in listChiTietMonAn)
                    {
                        if (item.MaHangHoa == MaHangHoa)
                        {
                            item.SoLuong = item.SoLuong - SoLuong;
                            SoLuongB = SoLuong;
                            item.ThanhTien = TrongLuong > 0 ? (item.SoLuong * (TrongLuong * item.DonGia)) : item.SoLuong * item.DonGia;
                            KiemTra = 1;
                            break;
                        }
                    }
                    if (KiemTra == 1)
                    {
                        listChiTietMonAnThanhToan.Add(new ChiTietHoaDonB1
                        {
                            MaHangHoa = MaHangHoa,
                            TenHangHoa = TenHangHoa,
                            DonViTinh = DonViTinh,
                            DonGia = DonGia,
                            ThanhTien = TrongLuong > 0 ? (SoLuongB * (TrongLuong * DonGia)) : SoLuongB * DonGia,
                            SoLuong = SoLuongB,
                        });
                    }
                }
                gridControlB.DataSource = null;
                gridControlB.DataSource = listChiTietMonAnThanhToan;
                gridControlA.DataSource = null;
                gridControlA.DataSource = listChiTietMonAn;
            }
            else
            {
                MessageBox.Show("Danh sách món ăn không có.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
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

       

        private void btnThucHien_Click(object sender, EventArgs e)
        {
            ThanhToanBill();
        }
        public void ThanhToanBill()
        {
            // thanh toán... đưa dữ liệu lai from chính, laod lại món ăn, tiền giờ.OK
            if (MessageBox.Show("Thanh Toán", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.OK)
            {
                if (listChiTietMonAnThanhToan.Count > 0)
                {
                    bool KT = true;
                    int IDHoaDon = DAO_Setting.KiemtraGiaDien(frmDangNhap.NguoiDung.Idchinhanh) == 0 ? DAO_BanHang.IDHoaDon(frmBanHang.IDBan) : DAO_BanHang.IDHoaDon(frmBanHang2.IDBan);
                    int IDBan = DAO_Setting.KiemtraGiaDien(frmDangNhap.NguoiDung.Idchinhanh) == 0 ? frmBanHang.IDBan : frmBanHang2.IDBan;
                    int IDNhanVien = frmDangNhap.NguoiDung.Id;
                    DateTime GioVao = DAO_ChiTietHoaDonChinh.LayGioVao(IDHoaDon);
                    object ID = DAO_ChiTietHoaDonChinh.ThemMoiHoaDon(IDBan, IDNhanVien, GioVao,frmDangNhap.NguoiDung.Idchinhanh);
                    if (listChiTietMonAnThanhToan.Count > 0 && KT == true && ID != null)// thanh toán món ăn
                    {
                        double TongTien = 0;
                        foreach (ChiTietHoaDonB1 item in listChiTietMonAnThanhToan)
                        {
                            TongTien = TongTien + item.ThanhTien;
                            double TrongLuong = item.TrongLuong;
                            string MaHang = item.MaHangHoa;
                            int SoLuong = item.SoLuong;
                            int IDHangHoa = TrongLuong > 0 ? DAO_Setting.LayIDHangHoaTuChon(MaHang) : DAO_Setting.LayIDHangHoa(MaHang);
                            double DonGia = item.DonGia;
                            double ThanhTien = TrongLuong > 0 ? (SoLuong * (TrongLuong * DonGia)) : (SoLuong * DonGia);
                            int IDDonViTinh = TrongLuong > 0 ? DAO_Setting.LayIDDonViTinhTuChon(MaHang) : DAO_Setting.LayIDDonViTinh(MaHang);

                            //thêm vào chi tiết hóa đơn chính, cập nhật chi tiết hóa đơn củ, if  Sl = nhau xóa hóa đơn củ
                            // kiểm tra thêm chi tiết
                            if (DAO_ChiTietHoaDonChinh.KiemTraHangHoa(Int32.Parse(ID.ToString()), IDHangHoa, IDBan, float.Parse(TrongLuong.ToString()),frmDangNhap.NguoiDung.Idchinhanh) == false)
                            {
                                DAO_ChiTietHoaDonChinh.ThemChiTietHoaDonChinh(Int32.Parse(ID.ToString()), IDHangHoa, SoLuong, DonGia, ThanhTien, IDBan, MaHang, IDDonViTinh, float.Parse(TrongLuong.ToString()),frmDangNhap.NguoiDung.Idchinhanh);
                            }
                            else
                            {
                                DAO_ChiTietHoaDonChinh.CapNhatChiTietHoaDon(Int32.Parse(ID.ToString()), SoLuong, ThanhTien, IDHangHoa, IDBan,frmDangNhap.NguoiDung.Idchinhanh);
                            }
                            //if (TrongLuong == 0)
                            //{
                            //    List<DTO_NguyenLieu> ListNguyenLieu = DAO_NguyenLieu.Instance.LoadNguyenLieu(IDHangHoa);// trừ nguyên liệu tồn kho
                            //    if (ListNguyenLieu.Count > 0)
                            //    {
                            //        foreach (DTO_NguyenLieu itemNL in ListNguyenLieu)
                            //        {
                            //            double SLTru = (itemNL.TrongLuong * SoLuong);
                            //            DAO_Setting.TruTonKho(itemNL.IDNguyenLieu, frmDangNhap.NguoiDung.Idchinhanh, SLTru);
                            //            // trừ tồn kho
                            //        }
                            //    }
                            //}
                            //else if (TrongLuong > 0)
                            //{
                            //    DAO_Setting.TruTonKho(IDHangHoa, frmDangNhap.NguoiDung.Idchinhanh, SoLuong * TrongLuong);
                            //}
                        }
                        if (ID != null)
                        {
                            DAO_ChuyenBan.XoaChiTietBanCu(IDHoaDon, IDBan);
                            foreach (ChiTietHoaDonA1 item in listChiTietMonAn)
                            {
                                string MaHang = item.MaHangHoa;
                                int SoLuong = item.SoLuong;
                                float DonGia = item.DonGia;
                                float TrongLuong = item.TrongLuong;
                                float ThanhTien = TrongLuong > 0 ? (SoLuong * (TrongLuong * DonGia)) : (SoLuong * DonGia);
                                int IDHangHoa = TrongLuong > 0 ? DAO_Setting.LayIDHangHoaTuChon(MaHang) : DAO_Setting.LayIDHangHoa(MaHang);
                                int IDDonViTinh = TrongLuong > 0 ? DAO_Setting.LayIDDonViTinhTuChon(MaHang) : DAO_Setting.LayIDDonViTinh(MaHang);
                                DAO_GoiMon.ThemChiTietHoaDon(IDHoaDon, IDHangHoa, SoLuong, DonGia, ThanhTien, IDBan, MaHang, IDDonViTinh, TrongLuong, frmDangNhap.NguoiDung.Idchinhanh);
                            }

                            DAO_ChiTietHoaDonChinh.CapNhatTongTienHoaDonChinh(Int32.Parse(ID.ToString()), IDBan, TongTien,frmDangNhap.NguoiDung.Idchinhanh);
                        }

                    }

                    if (KT == true && ID != null)
                    {
                        if (MyGetData != null)
                        {
                            MyGetData(1, IDHoaDon, IDBan);
                            this.Close();
                        }

                        if (MessageBox.Show("In hóa đơn", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.OK)
                        {
                            // in hóa đớn, cập nhật hóa đơn
                            DAO_ConnectSQL connect = new DAO_ConnectSQL();

                            // Tên máy in
                            string NamePrinter = DAO_Setting.LayTenMayInBill(frmDangNhap.NguoiDung.Idchinhanh);

                            // Lấy máy in bill..
                            int IDBill = DAO_Setting.ReportBill(frmDangNhap.NguoiDung.Idchinhanh);
                            if (IDBill == 58)
                            {
                                rpHoaDonBanHang_581 rp = new rpHoaDonBanHang_581();
                                SqlDataSource sqlDataSource = rp.DataSource as SqlDataSource;
                                sqlDataSource.Connection.ConnectionString += connect.ConnectString();

                                rp.Parameters["ID"].Value = ID;
                                rp.Parameters["ID"].Visible = false;
                                rp.Parameters["IDChiNhanh"].Value = frmDangNhap.NguoiDung.Idchinhanh;
                                rp.Parameters["IDChiNhanh"].Visible = false;
                                //rp.ShowPreviewDialog();
                                rp.Print(NamePrinter);
                            }
                            else
                            {
                                rpHoaDonBanHang1 rp = new rpHoaDonBanHang1();
                                SqlDataSource sqlDataSource = rp.DataSource as SqlDataSource;
                                sqlDataSource.Connection.ConnectionString += connect.ConnectString();

                                rp.Parameters["ID"].Value = ID;
                                rp.Parameters["ID"].Visible = false;
                                rp.Parameters["IDChiNhanh"].Value = frmDangNhap.NguoiDung.Idchinhanh;
                                rp.Parameters["IDChiNhanh"].Visible = false;
                                //rp.ShowPreviewDialog();
                                rp.Print(NamePrinter);
                            }

                        }
                    }
                }
                else
                {
                    MessageBox.Show("Lỗi thanh toán. Danh sách hóa đơn trống?", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnABMonAn_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                ThanhToanBill();
        }
    }
}