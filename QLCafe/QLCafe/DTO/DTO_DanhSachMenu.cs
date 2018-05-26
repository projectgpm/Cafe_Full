using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLCafe.DTO
{
    public class DTO_DanhSachMenu
    {
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
        private float trongLuong;

        public float TrongLuong
        {
            get { return trongLuong; }
            set { trongLuong = value; }
        }
        private int iD;

        public int ID
        {
            get { return iD; }
            set { iD = value; }
        }

        public DTO_DanhSachMenu(string getMaHangHoa, string getTenHangHoa, string getTenDonViTinh, int getSL, float getDonGia, float getThanhTien, float getTrongLuong, int getID)
        {
            this.MaHangHoa = getMaHangHoa;
            this.TenHangHoa = getTenHangHoa;
            this.DonViTinh = getTenDonViTinh;
            this.SoLuong = getSL;
            this.DonGia = getDonGia;
            this.ThanhTien = getThanhTien;
            this.TrongLuong = getTrongLuong;
            this.ID = getID;
        }
        public DTO_DanhSachMenu(DataRow dr)
        {
            this.MaHangHoa = dr["MaHangHoa"].ToString();
            this.TenHangHoa = dr["TenHangHoa"].ToString();
            this.DonViTinh = dr["TenDonViTinh"].ToString();
            this.SoLuong = Int32.Parse(dr["SoLuong"].ToString());
            this.DonGia = float.Parse(dr["DonGia"].ToString());
            this.ThanhTien = float.Parse(dr["ThanhTien"].ToString());
            this.TrongLuong = float.Parse(dr["TrongLuong"].ToString());
            this.ID = Int32.Parse(dr["ID"].ToString());
        }
    }
}
