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
using QLCafe.BUS;
using QLCafe.DTO;

namespace QLCafe
{
    public partial class frmChuyenBan : DevExpress.XtraEditors.XtraForm
    {
       // int GiaoDien = DAO_Setting.KiemtraGiaDien();
        //int IDBan = if(GiaoDien  == 0 )frmBanHang.IDBan else frmBanHang2.IDBan;
        //int IDHoaDon = DAO_BanHang.IDHoaDon(frmBanHang.IDBan);

        
        string IDChiNhanh = frmDangNhap.NguoiDung.Idchinhanh;
        public delegate void GetKT(int KT, int IDBanChuyen, int IDBanNhan,int IDHoaDonMoi);
        public GetKT MyGetData;
        public frmChuyenBan()
        {
            InitializeComponent();
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            //if (MessageBox.Show("Bạn thật sự muốn thoát. Dữ liệu thay đổi không được lưu lại?", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.OK)
            //{
                this.Close();
           // }
        }

        private void frmChuyenBan_Load(object sender, EventArgs e)
        {
            DanhSachHangHoaA();
            gridViewA.OptionsSelection.EnableAppearanceFocusedRow = false;// Ẩn dòng đầu...
            gridViewB.OptionsSelection.EnableAppearanceFocusedRow = false;// Ẩn dòng đầu...

            cmbBanA.Properties.NullText = DAO_ChuyenBan.LayTenBan(DAO_Setting.KiemtraGiaDien(frmDangNhap.NguoiDung.Idchinhanh) == 0 ? frmBanHang.IDBan : frmBanHang2.IDBan);
            int IDkhuVuc = DAO_ChuyenBan.LayIDKhuVuc(DAO_Setting.KiemtraGiaDien(frmDangNhap.NguoiDung.Idchinhanh) == 0 ? frmBanHang.IDBan : frmBanHang2.IDBan);
            cmbKhuVucA.Properties.NullText = DAO_ChuyenBan.LayTenKhuVuc(IDkhuVuc).ToString();
            DataTable dt = BUS_KhuVuc.DanhSachBanTheoKhuVuc(IDChiNhanh);
            cmbKhuVucB.Properties.DataSource = dt;
            cmbKhuVucB.Properties.ValueMember = "ID";
            cmbKhuVucB.Properties.DisplayMember = "TenKhuVuc";
           
        }
        public void DanhSachBanTheoKhuVuc(int IDKhuVuc)
        {
            //danh sách bàn phải trống
            List<DTO_BAN> ban = DAO_ChuyenBan.DanhSachBanTheoKhuVuc(IDKhuVuc, 0, DAO_Setting.KiemtraGiaDien(frmDangNhap.NguoiDung.Idchinhanh) == 0 ? frmBanHang.IDBan : frmBanHang2.IDBan);
            cmbBanB.Properties.DataSource = ban;
            cmbBanB.Properties.ValueMember = "Id";
            cmbBanB.Properties.DisplayMember = "Tenban";
        }

        private void cmbKhuVucB_EditValueChanged(object sender, EventArgs e)
        {
            cmbBanB.Enabled = true;
            btnAB2.Enabled = false;
            btnThucHien.Enabled = false;
            int IDKhuVuc = Int32.Parse(cmbKhuVucB.EditValue.ToString());
            DanhSachBanTheoKhuVuc(IDKhuVuc);
            gridControlB.DataSource = null;
            gridControlB.Refresh();
        }

        private void cmbBanB_EditValueChanged(object sender, EventArgs e)
        {
            DanhSachHangHoaA();
            gridControlB.DataSource = null;
            gridControlB.Refresh();
            btnAB2.Enabled = true;
            btnThucHien.Enabled = true;
        }

        private void btnAB2_Click(object sender, EventArgs e)
        {
            ChuyenASangB();
        }
        public void ChuyenASangB()
        {
            List<DTO_DanhSachMenu> MonAnThuong = DAO_DanhSachMonAn.Instance.GetMonAnThuong(DAO_BanHang.IDHoaDon(DAO_Setting.KiemtraGiaDien(frmDangNhap.NguoiDung.Idchinhanh) == 0 ? frmBanHang.IDBan : frmBanHang2.IDBan), frmDangNhap.NguoiDung.Idchinhanh);
           // List<DTO_DanhSachMenu> MonAnTuChon = DAO_DanhSachMonAn.Instance.GetMonAnTuChon(DAO_BanHang.IDHoaDon(DAO_Setting.KiemtraGiaDien(frmDangNhap.NguoiDung.Idchinhanh) == 0 ? frmBanHang.IDBan : frmBanHang2.IDBan), frmDangNhap.NguoiDung.Idchinhanh);

            DataTable db = new DataTable();
            db.Columns.Add("MaHangHoa", typeof(string));
            db.Columns.Add("TenHangHoa", typeof(string));
            db.Columns.Add("DonViTinh", typeof(string));
            db.Columns.Add("TrongLuong", typeof(float));
            db.Columns.Add("SoLuong", typeof(int));
            db.Columns.Add("DonGia", typeof(float));
            db.Columns.Add("ThanhTien", typeof(float));
            db.Columns.Add("ID", typeof(int));
            foreach (DTO_DanhSachMenu item in MonAnThuong)
            {
                db.Rows.Add(

                                 item.MaHangHoa,
                                 item.TenHangHoa,
                                 item.DonViTinh,
                                 item.TrongLuong,
                                 item.SoLuong,
                                 item.DonGia,
                                 item.ThanhTien,
                                 item.ID
                            );

            }
            //foreach (DTO_DanhSachMenu item in MonAnTuChon)
            //{
            //    db.Rows.Add(

            //                     item.MaHangHoa,
            //                     item.TenHangHoa,
            //                     item.DonViTinh,
            //                     item.TrongLuong,
            //                     item.SoLuong,
            //                     item.DonGia,
            //                     item.ThanhTien,
            //                     item.ID
            //                );

            //}
            gridControlB.DataSource = null;
            gridControlB.Refresh();
            gridControlB.DataSource = db;    
            gridControlA.DataSource = null;
            gridControlA.Refresh();
        }

        public void DanhSachHangHoaA()
        {
            List<DTO_DanhSachMenu> MonAnThuong = DAO_DanhSachMonAn.Instance.GetMonAnThuong(DAO_BanHang.IDHoaDon(DAO_Setting.KiemtraGiaDien(frmDangNhap.NguoiDung.Idchinhanh) == 0 ? frmBanHang.IDBan : frmBanHang2.IDBan), frmDangNhap.NguoiDung.Idchinhanh);
            //List<DTO_DanhSachMenu> MonAnTuChon = DAO_DanhSachMonAn.Instance.GetMonAnTuChon(DAO_BanHang.IDHoaDon(DAO_Setting.KiemtraGiaDien(frmDangNhap.NguoiDung.Idchinhanh) == 0 ? frmBanHang.IDBan : frmBanHang2.IDBan), frmDangNhap.NguoiDung.Idchinhanh);
            DataTable db = new DataTable();
            db.Columns.Add("MaHangHoa", typeof(string));
            db.Columns.Add("TenHangHoa", typeof(string));
            db.Columns.Add("DonViTinh", typeof(string));
            db.Columns.Add("TrongLuong", typeof(float));
            db.Columns.Add("SoLuong", typeof(int));
            db.Columns.Add("DonGia", typeof(float));
            db.Columns.Add("ThanhTien", typeof(float));
            db.Columns.Add("ID", typeof(int));
            foreach (DTO_DanhSachMenu item in MonAnThuong)
            {
                db.Rows.Add(

                                 item.MaHangHoa,
                                 item.TenHangHoa,
                                 item.DonViTinh,
                                 item.TrongLuong,
                                 item.SoLuong,
                                 item.DonGia,
                                 item.ThanhTien,
                                 item.ID
                            );

            }
            //foreach (DTO_DanhSachMenu item in MonAnTuChon)
            //{
            //    db.Rows.Add(

            //                     item.MaHangHoa,
            //                     item.TenHangHoa,
            //                     item.DonViTinh,
            //                     item.TrongLuong,
            //                     item.SoLuong,
            //                     item.DonGia,
            //                     item.ThanhTien,
            //                     item.ID
            //                );

            //}
            gridControlA.DataSource = null;
            gridControlA.Refresh();
            gridControlA.DataSource = db;
        }
        private void btnThucHien_Click(object sender, EventArgs e)
        {

            ChuyenBan();
        }

        public void ChuyenBan()
        {
            int IDBANMOI = Int32.Parse(cmbBanB.EditValue.ToString());
            int IDBANCU = DAO_Setting.KiemtraGiaDien(frmDangNhap.NguoiDung.Idchinhanh) == 0 ? frmBanHang.IDBan : frmBanHang2.IDBan;
            if (gridViewB.RowCount > 0)
            {
                List<DTO_DanhSachMenu> MonAnThuong = DAO_DanhSachMonAn.Instance.GetMonAnThuong(DAO_BanHang.IDHoaDon(IDBANCU), frmDangNhap.NguoiDung.Idchinhanh);
                //List<DTO_DanhSachMenu> MonAnTuChon = DAO_DanhSachMonAn.Instance.GetMonAnTuChon(DAO_BanHang.IDHoaDon(IDBANCU), frmDangNhap.NguoiDung.Idchinhanh);
                //foreach (DTO_DanhSachMenu item in MonAnTuChon)
                //{
                //    int ID = item.ID;
                //    DAO_ChuyenBan.CapNhatIDBanMoi(IDBANMOI, ID);
                //}
                foreach (DTO_DanhSachMenu item in MonAnThuong)
                {
                    int ID = item.ID;
                    DAO_ChuyenBan.CapNhatIDBanMoi(IDBANMOI, ID,frmDangNhap.NguoiDung.Idchinhanh);
                }

                if (DAO_BAN.DoiTrangThaiBanCoNguoi(IDBANMOI) == true && DAO_BAN.XoaBanVeMatDinh(IDBANCU, frmDangNhap.NguoiDung.Idchinhanh) == true && DAO_ChuyenBan.CapNhatHoaDon(DAO_Setting.KiemtraGiaDien(frmDangNhap.NguoiDung.Idchinhanh) == 0 ? DAO_BanHang.IDHoaDon(frmBanHang.IDBan) : DAO_BanHang.IDHoaDon(frmBanHang2.IDBan), IDBANMOI) == true)// xóa chi tiết hóa đơn củ
                {

                    if (MyGetData != null)
                    {
                        MyGetData(1, IDBANCU, IDBANMOI, DAO_Setting.KiemtraGiaDien(frmDangNhap.NguoiDung.Idchinhanh) == 0 ? DAO_BanHang.IDHoaDon(frmBanHang.IDBan) : DAO_BanHang.IDHoaDon(frmBanHang2.IDBan));
                        this.Close();
                    }
                }
            }
            else
            {
                MessageBox.Show("Danh sách trống? Vui lòng kiểm tra lại", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        //----------------------------------------------------
        private void btnLamLai_Click(object sender, EventArgs e)
        {
            DanhSachHangHoaA();
            gridControlB.DataSource = null;
            gridControlB.Refresh();
        }

        private void btnAB2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F4)
            {
                ChuyenBan();
            }
        }
    }
}