using QLCafe.BUS;
using QLCafe.DAO;
using QLCafe.DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Windows.Forms;

namespace QLCafe
{
    public partial class frmDangNhap : DevExpress.XtraEditors.XtraForm
    {
        
        public frmDangNhap()
        {
           
            InitializeComponent();
            txtTenDangNhap.Focus();
        }
        public static DTO_DangNhap NguoiDung;
        private void linkLienHe_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start("https://gpm.vn/");
        }

        private void linkCauHinh_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmCauHinhHeThong fr = new frmCauHinhHeThong();
            this.Hide();
            fr.ShowDialog();
            this.Show();
        }

        private void linkDoiMatKhau_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmDoiMatKhau fr = new frmDoiMatKhau();
            this.Hide();
            fr.ShowDialog();
            this.Show();
        }

        private void btnDangNhap_Click(object sender, EventArgs e)
        {
            //if (DAO_TestKetNoi.IsConnectedToInternet("gpm.vn"))
            //{
                DangNhap();
            //}
            //else
            //{
            //    MessageBox.Show("Không có kết nối Internet. Vui lòng kiểm tra lại?", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //}
        }
        public void DangNhap()
        {
            if (DAO_Setting.TestDuKieu() != "")
            {
                // kiểm tra key
                if (DAO_Setting.getKeyCode() != -1)
                {
                    //linkCauHinh.Visible = false;
                    string TenDangNhap = txtTenDangNhap.Text.ToUpper();
                    string MatKhau = DAO_Setting.GetSHA1HashData(txtMatKhau.Text.ToString());
                    bool KT = BUS_DangNhap.KiemTraDangNhap(TenDangNhap, MatKhau);
                    if (KT == true)
                    {
                        DataTable dt = BUS_DangNhap.ThongTin(TenDangNhap, MatKhau);
                        if (dt.Rows.Count > 0)
                        {
                            DataRow dr = dt.Rows[0];
                            NguoiDung = new DTO_DangNhap();
                            NguoiDung.Id = Int32.Parse(dr["ID"].ToString());
                            NguoiDung.Tendangnhap = dr["TenDangNhap"].ToString();
                            NguoiDung.Idchinhanh = dr["IDChiNhanh"].ToString();
                            NguoiDung.Manhanvien = dr["MaNhanVien"].ToString();
                            NguoiDung.Tennguoidung = dr["TenNguoiDung"].ToString();
                            NguoiDung.Sdt = dr["SDT"].ToString();
                            NguoiDung.IDNhomNguoiDung = Int32.Parse(dr["IDNhomNguoiDung"].ToString());
                            DAO_Setting.ThemLichSuTruyCap(frmDangNhap.NguoiDung.Id, frmDangNhap.NguoiDung.IDNhomNguoiDung, frmDangNhap.NguoiDung.Idchinhanh, "Đăng Nhập", "Đăng Nhập Bán Hàng");


                            if (DAO_Setting.KiemtraGiaDien(dr["IDChiNhanh"].ToString()) == 0)
                            {
                                frmBanHang fr = new frmBanHang();
                                txtMatKhau.Text = "";
                                txtMatKhau.Select();
                                this.Hide();
                                fr.ShowDialog();
                                this.Show();
                            }
                            else
                            {
                                frmBanHang2 fr = new frmBanHang2();
                                txtMatKhau.Text = "";
                                txtMatKhau.Select();
                                this.Hide();
                                fr.ShowDialog();
                                this.Show();
                            }

                        }
                    }
                    else
                    {
                        MessageBox.Show("Đăng nhập không thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                   // linkCauHinh.Visible = true;
                    if (MessageBox.Show("Phần mềm chưa được kích hoạt bản quyền.", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Error) == System.Windows.Forms.DialogResult.OK)
                    {
                        frmKichHoat fr = new frmKichHoat();
                        fr.ShowDialog();
                    }
                }
            }
            else
            {
                if (MessageBox.Show("Phần mềm chưa được kích hoạt bản quyền.", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Error) == System.Windows.Forms.DialogResult.OK)
                {
                    frmKichHoat fr = new frmKichHoat();
                    fr.ShowDialog();
                }
            }
        }
       
        private void btnThoat_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void frmDangNhap_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show("Bạn thật sự muốn thoát chương trình?", "Thông báo", MessageBoxButtons.OKCancel,MessageBoxIcon.Question) != System.Windows.Forms.DialogResult.OK)
            {
                e.Cancel = true;
            }
        }
        private void frmDangNhap_Load(object sender, EventArgs e)
        {
            txtTenDangNhap.Select();
            //linkThongTin.Visible = false;
            //btnDangNhap.Enabled = false;
            // bool KT = BUS_TestKetNoiServer.DanhSachKetNoi();
            // if (KT == true)
            // {
            //     if (DAO_Setting.getKeyCode() != -1)
            //     {
            //         btnDangNhap.Enabled = true;
            //         linkThongTin.Visible = true;
            //         linkCauHinh.Visible = false;
            //     }
            //     else
            //     {
            //         btnDangNhap.Enabled = false;
            //         linkThongTin.Visible = false;
            //         linkCauHinh.Visible = true;
            //     }
            // }
        }

        private void ckeHienMatKhau_CheckedChanged(object sender, EventArgs e)
        {
            if (ckeHienMatKhau.Checked == true)
            {
                txtMatKhau.Properties.UseSystemPasswordChar = false;
            }
            else
            {
                txtMatKhau.Properties.UseSystemPasswordChar = true;
            }
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void txtMatKhau_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                DangNhap();

            }
        }

        private void txtTenDangNhap_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                DangNhap();

            }
        }

        private void linkThongTin_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmDangNhapThongTin fr = new frmDangNhapThongTin();
            this.Hide();
            fr.ShowDialog();
            this.Show();
        }

        private void label1_Click(object sender, EventArgs e)
        {
            //txtTenDangNhap.Select();
            //linkThongTin.Visible = false;
            //btnDangNhap.Enabled = false;
            //bool KT = BUS_TestKetNoiServer.DanhSachKetNoi();
            //if (KT == true)
            //{
            //    if (DAO_Setting.getKeyCode() != -1)
            //    {
            //        btnDangNhap.Enabled = true;
            //        linkThongTin.Visible = true;
            //        linkCauHinh.Visible = false;
            //    }
            //    else
            //    {
            //        btnDangNhap.Enabled = false;
            //        linkThongTin.Visible = false;
            //        linkCauHinh.Visible = true;
            //    }
            //}
        }

        private void labelCauHinhMayChu_Click(object sender, EventArgs e)
        {
            frmCauHinhHeThong fr = new frmCauHinhHeThong();
            this.Hide();
            fr.ShowDialog();
            this.Show();
        }

        private void label6_Click(object sender, EventArgs e)
        {
            frmCauHinhHeThong fr = new frmCauHinhHeThong();
            this.Hide();
            fr.ShowDialog();
            this.Show();
        }

    }
}
