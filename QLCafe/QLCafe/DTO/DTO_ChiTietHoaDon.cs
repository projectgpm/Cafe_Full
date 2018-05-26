using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLCafe.DTO
{
    public class DTO_ChiTietHoaDon
    {
        private int iD;

        public int ID
        {
            get { return iD; }
            set { iD = value; }
        }
        private int iDHoaDon;

        public int IDHoaDon
        {
            get { return iDHoaDon; }
            set { iDHoaDon = value; }
        }
        private int iDHangHoa;

        public int IDHangHoa
        {
            get { return iDHangHoa; }
            set { iDHangHoa = value; }
        }
        private int soLuong;

        public int SoLuong
        {
            get { return soLuong; }
            set { soLuong = value; }
        }
        private float donGia;

        public float DonGia
        {
            get { return donGia; }
            set { donGia = value; }
        }
        private float thanhTien;

        public float ThanhTien
        {
            get { return thanhTien; }
            set { thanhTien = value; }
        }
        private string maHangHoa;

        public string MaHangHoa
        {
            get { return maHangHoa; }
            set { maHangHoa = value; }
        }
        private int iDDonViTinh;

        public int IDDonViTinh
        {
            get { return iDDonViTinh; }
            set { iDDonViTinh = value; }
        }
        private int idBan;

        public int IdBan
        {
            get { return idBan; }
            set { idBan = value; }
        }

        private float trongLuong;

        public float TrongLuong
        {
            get { return trongLuong; }
            set { trongLuong = value; }
        }

        public DTO_ChiTietHoaDon() { }
        public DTO_ChiTietHoaDon(int getid, int getidhoadon, int getidhanghoa, int getsoluong, float getdongia, float getthanhtien, string getMaHangHoa, int getiddvt, int getidban, float getTrongLuong)
        {
            this.ID = getid;
            this.IDHoaDon = getidhoadon;
            this.IDHangHoa = getidhanghoa;
            this.SoLuong = getsoluong;
            this.DonGia = getdongia;
            this.ThanhTien = getthanhtien;
            this.MaHangHoa = getMaHangHoa;
            this.IDDonViTinh = getiddvt;
            this.IdBan = getidban;
            this.TrongLuong = getTrongLuong;
        }
        public DTO_ChiTietHoaDon(DataRow dr)
        {
            this.ID = Int32.Parse(dr["ID"].ToString());
            this.IDHoaDon = Int32.Parse(dr["IDHoaDon"].ToString()) ;
            this.IDHangHoa = Int32.Parse(dr["IDHangHoa"].ToString());
            this.SoLuong = Int32.Parse(dr["SoLuong"].ToString());
            this.DonGia = float.Parse(dr["DonGia"].ToString());
            this.ThanhTien = float.Parse(dr["ThanhTien"].ToString());
            this.MaHangHoa = dr["MaHangHoa"].ToString();
            this.IDDonViTinh = Int32.Parse(dr["IDDonViTinh"].ToString());
            this.IdBan = Int32.Parse(dr["IDBan"].ToString());
            this.TrongLuong = float.Parse(dr["TrongLuong"].ToString());
        }
    }
}
