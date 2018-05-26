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
    public partial class frmKichHoat : DevExpress.XtraEditors.XtraForm
    {
        public frmKichHoat()
        {
            InitializeComponent();
        }

        private void linkLienHe_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start("https://gpm.vn/");
        }

        private void frmKichHoat_Load(object sender, EventArgs e)
        {
            txtKey.Select();
        }
        private void btnHuy_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        int Dem = 0;
        private void btnKichHoat_Click(object sender, EventArgs e)
        {
            string Key = txtKey.Text.ToString();
            if (DAO_Setting.setKeyCode(Key, "") == -1)
            {
                Dem = Dem + 1;
                if (Dem == 5)
                {
                    this.Close();
                }
                else
                {
                    txtKey.Text = "";
                    txtKey.Select();
                    MessageBox.Show("Key nhập không chính xác hoặc đã quá số lần kích hoạt. Bạn còn " + (5 - Dem) + " lần kích hoạt", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
                }
            }
            else
            {
                MessageBox.Show("Kích hoạt key thành công !!! Quý khách còn " + DAO_Setting.KiemTraSoLanKichHoat(Key) + " lần kích hoạt.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                this.Close();
            }
        }

       

    
    }
}