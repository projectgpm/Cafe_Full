using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLCafe.DTO
{
    public class DTO_ChiTietGio
    {
        private int iD;

        public int ID
        {
            get { return iD; }
            set { iD = value; }
        }
        private DateTime gioBatDau;

        public DateTime GioBatDau
        {
            get { return gioBatDau; }
            set { gioBatDau = value; }
        }
        private DateTime gioKetThuc;

        public DateTime GioKetThuc
        {
            get { return gioKetThuc; }
            set { gioKetThuc = value; }
        }
        private string tongGioChoi;

        public string TongGioChoi
        {
            get { return tongGioChoi; }
            set { tongGioChoi = value; }
        }
        private double donGia;

        public double DonGia
        {
            get { return donGia; }
            set { donGia = value; }
        }
        private double thanhTien;

        public double ThanhTien
        {
            get { return thanhTien; }
            set { thanhTien = value; }
        }
        private int iDBan;

        public int IDBan
        {
            get { return iDBan; }
            set { iDBan = value; }
        }
        private int iDHoaDon;

        public int IDHoaDon
        {
            get { return iDHoaDon; }
            set { iDHoaDon = value; }
        }
        private int trangThai;

        public int TrangThai
        {
            get { return trangThai; }
            set { trangThai = value; }
        }
        private int thanhToan;

        public int ThanhToan
        {
            get { return thanhToan; }
            set { thanhToan = value; }
        }
        public DTO_ChiTietGio() { }
        public DTO_ChiTietGio(int getID, DateTime getGioBD, DateTime getGioKT, string getGioChoi, float getDonGia, float getThanhTien, int getIDBan, int getIDHoaDon, int getTrangThai, int getThanhToan)
        {
            this.ID = getID;
            this.GioBatDau = getGioBD;
            this.GioKetThuc = getGioKT;
            this.TongGioChoi = getGioChoi;
            this.DonGia = getDonGia;
            this.ThanhTien = getThanhTien;
            this.IDBan = getIDBan;
            this.IDHoaDon = getIDHoaDon;
            this.TrangThai = getTrangThai;
            this.ThanhToan = getThanhToan;
        }
        public DTO_ChiTietGio(DataRow dr)
        {
            this.ID = Int32.Parse(dr["ID"].ToString());
            this.GioBatDau = DateTime.Parse(dr["GioBatDau"].ToString());
            this.GioKetThuc = DateTime.Parse(dr["GioKetThuc"].ToString());
            this.TongGioChoi = dr["TongGioChoi"].ToString();
            this.DonGia = double.Parse(dr["DonGia"].ToString());
            this.ThanhTien = double.Parse(dr["ThanhTien"].ToString());
            this.IDBan = Int32.Parse(dr["IDBan"].ToString());
            this.IDHoaDon = Int32.Parse(dr["IDHoaDon"].ToString());
            this.TrangThai = Int32.Parse(dr["TrangThai"].ToString());
            this.ThanhToan = Int32.Parse(dr["ThanhToan"].ToString());
        }
    }
}
