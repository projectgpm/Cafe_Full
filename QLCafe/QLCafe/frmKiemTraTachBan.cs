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

namespace QLCafe
{
    public partial class frmKiemTraTachBan : DevExpress.XtraEditors.XtraForm
    {
        public delegate void GetString(int KT, int SoLuong);
        public GetString MyGetData;
        public frmKiemTraTachBan()
        {
            InitializeComponent();
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnXacNhan_Click(object sender, EventArgs e)
        {
            if (MyGetData != null)
            {
                MyGetData(1, Int32.Parse(txtSoLuong.Text.ToString()));
            }
            this.Close();
        }
    }
}