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

namespace QLCafe
{
    public partial class frmCaiDatThongTin : DevExpress.XtraEditors.XtraForm
    {
        public frmCaiDatThongTin()
        {
            InitializeComponent();
        }

        private void linkLienHe_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start("https://gpm.vn/");
        }

        private void frmCaiDatThongTin_Load(object sender, EventArgs e)
        {
            DanhSachMayIn();
            ThongTinCuaHang();
        }

        public void DanhSachMayIn()
        {
            foreach (string printer in System.Drawing.Printing.PrinterSettings.InstalledPrinters)
            {
                cmbMayIn.Properties.Items.Add(printer.ToString());
            }
        }

        private void btnLuuLai_Click(object sender, EventArgs e)
        {
            string IDChiNhanh = frmDangNhapThongTin.QuanLy.Idchinhanh;
            string MayIn = cmbMayIn.Text.ToString();
            string KhoGiay  =cmbKhoGiay.Text.ToString();
            string TenCuaHang = txtCuaHang.Text.ToString();
            string DiaChi = txtDiaChi.Text.ToString();
            string DienThoai = txtSoDienThoai.Text.ToString();
            string GiaoDien = cmbGiaoDien.SelectedIndex.ToString();
            bool KT = DAO_Setting.CapNhatMayInBill(MayIn, KhoGiay, TenCuaHang, DiaChi, DienThoai, GiaoDien, IDChiNhanh);
            if (KT == true)
            {
                MessageBox.Show("Cập nhật thông tin thành công.", "Thông báo");
                this.Close();
            }

        }

        public void ThongTinCuaHang()
        {
            DataTable thongtin = DAO_Setting.ThongTinCuaHang(frmDangNhapThongTin.QuanLy.Idchinhanh);
            DataRow dr = thongtin.Rows[0];
            txtCuaHang.Text = dr["TenChiNhanh"].ToString();
            txtSoDienThoai.Text = dr["DienThoai"].ToString();
            txtDiaChi.Text = dr["DiaChi"].ToString();
            int GiaoDienApDung = Int32.Parse(dr["GiaoDienApDung"].ToString());
            switch (GiaoDienApDung)
            {
                case 0:
                    cmbGiaoDien.SelectedIndex = 0;
                    break;
                case 1:
                    cmbGiaoDien.SelectedIndex = 1;
                    break;
                default:
                    cmbGiaoDien.SelectedIndex = 0;
                    break;
            }
            string MayIn = dr["MayIn"].ToString();
            cmbMayIn.EditValue = MayIn;

            int ReportBill = Int32.Parse(dr["ReportBill"].ToString());
            switch (ReportBill)
            {
                case 58:
                    cmbKhoGiay.SelectedIndex = 0;
                    break;
                case 80:
                    cmbKhoGiay.SelectedIndex = 1;
                    break;
                default:
                    cmbKhoGiay.SelectedIndex = 0;
                    break;
            }
        }

    
    }
}