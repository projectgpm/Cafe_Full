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
using QLCafe.DTO;
using QLCafe.BUS;
using QLCafe.DAO;
using System.IO;


namespace QLCafe
{
    public partial class frmCauHinhHeThong : DevExpress.XtraEditors.XtraForm
    {
        public frmCauHinhHeThong()
        {
            InitializeComponent();
        }
        private void linkLienHe_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start("https://gpm.vn/");
        }
        public bool KiemTraTxt(string x)
        {
            if (x.Length == 0) return false;
            for (int i = 0; i < x.Length; i++)
                if (x[i].ToString() == " ")
                    return false;
            return true;
        }
        private void btnLuuLai_Click(object sender, EventArgs e)
        {
            if (KiemTraTxt(txtDataSource.Text) == true && KiemTraTxt(txtDatabase.Text) == true && KiemTraTxt(txtUserName.Text) == true && KiemTraTxt(txtPassword.Text) == true)
            {

                DTO_WriteDataConnect write = new DTO_WriteDataConnect(txtDataSource.Text, txtDatabase.Text, txtUserName.Text, txtPassword.Text);
                //if (BUS_WriteDataConnect.Write(write) == true)
                //{
                //    MessageBox.Show("Lưu lại cấu hình server thành công? Vui lòng kiểm tra kết nối.", "Thông báo");
                //    //this.Close();
                //}
               // else MessageBox.Show("Lỗi cập nhật địa chỉ server", "Thông báo");
            }
            else
            {
                MessageBox.Show("Thông tin server không được có khoảng trắng hoặc bỏ trống", "Thông báo");
                txtDataSource.Focus();
            }
        }

        private void btnKiemTra_Click(object sender, EventArgs e)
        {

            bool KT = BUS_TestKetNoiServer.DanhSachKetNoi();
            if (KT == true)
            {
            
                MessageBox.Show("Kết nối tới server thành công.", "Thông báo");
                this.Close();
            }
            else
            {
                MessageBox.Show("Kết nối tới server không thành công.", "Thông báo",MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private string datasource;
        public string Datasource
        {
            get { return datasource; }
            set { datasource = value; }
        }
        private string database;

        public string Database
        {
            get { return database; }
            set { database = value; }
        }
        private string username;

        public string Username
        {
            get { return username; }
            set { username = value; }
        }
        private string password;

        public string Password
        {
            get { return password; }
            set { password = value; }
        }
        private void frmCauHinhHeThong_Load(object sender, EventArgs e)
        {
            this.ReadFileConnect();
            txtDataSource.Text = Datasource;
            txtDatabase.Text = Database;
            txtUserName.Text = Username;
            txtPassword.Text = Password;
           
        }
       
        public void ReadFileConnect()
        {
            FileStream fileStream = new FileStream("QLCafeGPM.dll", FileMode.Open, FileAccess.Read, FileShare.None);
            StreamReader sr = new StreamReader(fileStream);
            Datasource = sr.ReadLine();
            Database = sr.ReadLine();
            Username = sr.ReadLine();
            Password = sr.ReadLine();
            sr.Close();
            fileStream.Close();
        }
    }
}