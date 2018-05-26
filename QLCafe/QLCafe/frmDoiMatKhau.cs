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
    public partial class frmDoiMatKhau : DevExpress.XtraEditors.XtraForm
    {
        public frmDoiMatKhau()
        {
            InitializeComponent();
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnLuuLai_Click(object sender, EventArgs e)
        {
            string TenDangNhap = txtTenDangNhap.Text.ToUpper();
            string MatKhau = txtMatKhau.Text.ToString();
            string MatKhauMoi = txtMatKhauMoi.Text.ToString();
            string XacNhanMatKhau = txtXacNhanMatKhau.Text.ToString();
            if (!String.IsNullOrEmpty(TenDangNhap) && !String.IsNullOrEmpty(MatKhau) && !String.IsNullOrEmpty(MatKhauMoi) && !String.IsNullOrEmpty(XacNhanMatKhau))
            {
                if (KiemTraMatKhauKhop() == true)
                {
                    bool KT = BUS_DangNhap.KiemTraDangNhap(TenDangNhap, DAO_Setting.GetSHA1HashData(MatKhau));
                    if (KT == true)
                    {
                        if (BUS_DangNhap.CapNhatMatKhau(TenDangNhap, DAO_Setting.GetSHA1HashData(MatKhau), DAO_Setting.GetSHA1HashData(XacNhanMatKhau)) == true)
                        {
                            MessageBox.Show("Thông tin tài khoản đã thay đổi thành công.", "Thông báo", MessageBoxButtons.OK);
                            this.Close();
                            frmDangNhap fr = new frmDangNhap();
                            fr.Show();
                        }
                        else
                        {
                            MessageBox.Show("Thông tin tài khoản chưa được thay đổi.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    else
                    {
                        MessageBox.Show("Thông tin tài khoản không chính xác.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            else
            {
                MessageBox.Show("Vui lòng điền đầy đủ thông tin.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public bool KiemTraMatKhauKhop()
        {
            if (txtMatKhauMoi.Text.ToString() != txtXacNhanMatKhau.Text.ToString())
            {
                MessageBox.Show("Mật khẩu xác nhận không khớp", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            return true;
        }
        private void linkLienHe_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start("https://gpm.vn/");
        }

        private void frmDoiMatKhau_Load(object sender, EventArgs e)
        {
            txtTenDangNhap.Select();
        }

        private void ckHienThi_CheckedChanged(object sender, EventArgs e)
        {
            if (ckHienThi.Checked == true)
            {
                txtMatKhau.Properties.UseSystemPasswordChar = false;
                txtMatKhauMoi.Properties.UseSystemPasswordChar = false;
                txtXacNhanMatKhau.Properties.UseSystemPasswordChar = false;
            }
            else
            {
                txtMatKhau.Properties.UseSystemPasswordChar = true;
                txtMatKhauMoi.Properties.UseSystemPasswordChar = true;
                txtXacNhanMatKhau.Properties.UseSystemPasswordChar = true;
            }
        }

    }
}