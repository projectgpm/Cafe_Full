using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLCafe.DTO
{
    public class DTO_HoaDon
    {
        private int iD;

        public int ID
        {
            get { return iD; }
            set { iD = value; }
        }
        private DateTime? gioVao;

        public DateTime? GioVao
        {
            get { return gioVao; }
            set { gioVao = value; }
        }
        private DateTime? gioRa;

        public DateTime? GioRa
        {
            get { return gioRa; }
            set { gioRa = value; }
        }
        private int iDBan;

        public int IDBan
        {
            get { return iDBan; }
            set { iDBan = value; }
        }
        private int trangThai;

        public int TrangThai
        {
            get { return trangThai; }
            set { trangThai = value; }
        }
        private int iDKhachHang;

        public int IDKhachHang
        {
            get { return iDKhachHang; }
            set { iDKhachHang = value; }
        }
        private string maHoaDon;

        public string MaHoaDon
        {
            get { return maHoaDon; }
            set { maHoaDon = value; }
        }
        private int iDNhanVien;

        public int IDNhanVien
        {
            get { return iDNhanVien; }
            set { iDNhanVien = value; }
        }
        private float tongTien;

        public float TongTien
        {
            get { return tongTien; }
            set { tongTien = value; }
        }
        private float giamGia;

        public float GiamGia
        {
            get { return giamGia; }
            set { giamGia = value; }
        }
        private float khachCanTra;

        public float KhachCanTra
        {
            get { return khachCanTra; }
            set { khachCanTra = value; }
        }
        private float khachThanhToan;

        public float KhachThanhToan
        {
            get { return khachThanhToan; }
            set { khachThanhToan = value; }
        }
        private float tienThua;

        public float TienThua
        {
            get { return tienThua; }
            set { tienThua = value; }
        }
        private float tienGio;

        public float TienGio
        {
            get { return tienGio; }
            set { tienGio = value; }
        }
        private string iDChiNhanh;

        public string IDChiNhanh
        {
            get { return iDChiNhanh; }
            set { iDChiNhanh = value; }
        }
        public DTO_HoaDon(int getid, DateTime? getgiovao, DateTime? getgiora, int getidban, int gettrangthai, float getTienGio, string getmahoadon, int getidnhanvien, float gettongtien, float getgiamgia, float getkhachcantra, float getkhachthanhtoan, float gettienthua, string getIDChiNhanh)
        {
            this.ID = getid;
            this.GioRa = getgiora;
            this.GioVao = getgiovao;
            this.IDBan = getidban;
            this.TrangThai = gettrangthai;
            this.TienGio = getTienGio;
            this.MaHoaDon = getmahoadon;
            this.IDNhanVien = getidnhanvien;
            this.TongTien = gettongtien;
            this.GiamGia = getgiamgia;
            this.KhachCanTra = getkhachcantra;
            this.KhachThanhToan = getkhachthanhtoan;
            this.TienThua = gettienthua;
            this.IDChiNhanh = getIDChiNhanh;
        }
        public DTO_HoaDon(DataRow dr)
        {
            this.ID = Int32.Parse(dr["ID"].ToString());

            var KT = dr["GioRa"];
            if(KT.ToString() != "")
                this.GioRa = (DateTime?)KT;
            this.GioVao = (DateTime?)dr["GioVao"];
            this.IDBan =Int32.Parse(dr["IDBan"].ToString());
            this.TrangThai = Int32.Parse(dr["TrangThai"].ToString());
            var MaHD = dr["MaHoaDon"];
            if(MaHD.ToString() !="")
                this.MaHoaDon = MaHD.ToString();
            var IDNV = dr["IDNhanVien"];
            if(IDNV.ToString() !="")
                this.IDNhanVien = Int32.Parse(IDNV.ToString());
            this.TongTien = float.Parse(dr["TongTien"].ToString());
            this.GiamGia = float.Parse(dr["GiamGia"].ToString());
            this.KhachCanTra = float.Parse(dr["KhachCanTra"].ToString());
            this.KhachThanhToan = float.Parse(dr["KhachThanhToan"].ToString());
            this.TienThua = float.Parse(dr["TienThua"].ToString());
            this.TienGio = float.Parse(dr["TienGio"].ToString());
            this.IDChiNhanh = dr["IDChiNhanh"].ToString();
        }
    }
}
