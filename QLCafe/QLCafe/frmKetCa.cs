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

namespace QLCafe
{
    public partial class frmKetCa : DevExpress.XtraEditors.XtraForm
    {
        public frmKetCa()
        {
            InitializeComponent();
        }

        private void frmKetCa_Load(object sender, EventArgs e)
        {
            DanhSach();
        }
        public void DanhSach()
        {
            gridKetCa.DataSource = null;
            gridViewKetCa.OptionsSelection.EnableAppearanceFocusedRow = false;// Ẩn dòng đầu.
            List<DTO_KetCa> listKetCa = DAO_KetCa.Instance.DanhSachCaBan(DateTime.Now,frmDangNhap.NguoiDung.Idchinhanh);
            gridKetCa.DataSource = listKetCa;
            int IDNhanVien = frmDangNhap.NguoiDung.Id;
            txtTongTienHienTai.Text = DAO_KetCa.TongTienHienTai(IDNhanVien, frmDangNhap.NguoiDung.Idchinhanh).ToString();
            txtTienKhuyenMai.Text = DAO_KetCa.TongTienGiamGiaHienTai(IDNhanVien, frmDangNhap.NguoiDung.Idchinhanh).ToString();
        }
        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnKetCa_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn muốn kết ca", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.OK)
            {
                int IDNhanVien = frmDangNhap.NguoiDung.Id;
                double TongTien = DAO_KetCa.TongTienHienTai(IDNhanVien,frmDangNhap.NguoiDung.Idchinhanh);
                double GiamGia = DAO_KetCa.TongTienGiamGiaHienTai(IDNhanVien,frmDangNhap.NguoiDung.Idchinhanh);
                double ThanhTien = TongTien - GiamGia; 
                string GioVaoCa = DAO_KetCa.GioVaoCa(IDNhanVien);
                if (DAO_KetCa.ThemKetCa(IDNhanVien, GioVaoCa, ThanhTien, frmDangNhap.NguoiDung.Idchinhanh, TongTien, GiamGia) == true)
                {
                    // đổi trạng thái hóa đơn kết ca  = 1
                    DAO_Setting.ThemLichSuTruyCap(frmDangNhap.NguoiDung.Id, frmDangNhap.NguoiDung.IDNhomNguoiDung, frmDangNhap.NguoiDung.Idchinhanh, "Kết Ca", "Nhân Viên Kết Ca Bán Hàng");
                    DAO_KetCa.CapNhatKetCa(IDNhanVien);
                    DanhSach();
                }
            }
        }
    }
}