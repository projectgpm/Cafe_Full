using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLCafe.DTO
{
    public class DTO_HangHoa
    {
        private int iD;

        public int ID
        {
            get { return iD; }
            set { iD = value; }
        }
        private string maHangHoa;

        public string MaHangHoa
        {
            get { return maHangHoa; }
            set { maHangHoa = value; }
        }
        private string tenHangHoa;

        public string TenHangHoa
        {
            get { return tenHangHoa; }
            set { tenHangHoa = value; }
        }
        private float giaBan;

        public float GiaBan
        {
            get { return giaBan; }
            set { giaBan = value; }
        }
        private int iDDonViTinh;

        public int IDDonViTinh
        {
            get { return iDDonViTinh; }
            set { iDDonViTinh = value; }
        }
        private int iDNhomHang;

        public int IDNhomHang
        {
            get { return iDNhomHang; }
            set { iDNhomHang = value; }
        }

        public DTO_HangHoa(int getID, string getMaHangHoa, string getTenHangHoa, float getGiaBan, int getIDDVT, int getIDNhomHang)
        {
            this.ID = getID;
            this.MaHangHoa = getMaHangHoa;
            this.TenHangHoa = getTenHangHoa;
            this.GiaBan = getGiaBan;
            this.IDDonViTinh = getIDDVT;
            this.IDNhomHang = getIDNhomHang;
        }
        public DTO_HangHoa(DataRow dr)
        {
            this.ID = Int32.Parse(dr["ID"].ToString());
            this.MaHangHoa = dr["MaHangHoa"].ToString();
            this.TenHangHoa = dr["TenHangHoa"].ToString();
            this.GiaBan = float.Parse(dr["GiaBan"].ToString());
            this.IDDonViTinh = Int32.Parse(dr["IDDonViTinh"].ToString());
            this.IDNhomHang = Int32.Parse(dr["IDNhomHang"].ToString());
        }
    }
}
