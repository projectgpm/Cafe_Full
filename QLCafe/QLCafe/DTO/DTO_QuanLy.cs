using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLCafe.DTO
{
    public class DTO_QuanLy
    {
        private int id;

        public int Id
        {
            get { return id; }
            set { id = value; }
        }
        private string tendangnhap;

        public string Tendangnhap
        {
            get { return tendangnhap; }
            set { tendangnhap = value; }
        }
        private string matkhau;

        public string Matkhau
        {
            get { return matkhau; }
            set { matkhau = value; }
        }
        private string tennguoidung;

        public string Tennguoidung
        {
            get { return tennguoidung; }
            set { tennguoidung = value; }
        }
        private string idchinhanh;

        public string Idchinhanh
        {
            get { return idchinhanh; }
            set { idchinhanh = value; }
        }
        private string manhanvien;

        public string Manhanvien
        {
            get { return manhanvien; }
            set { manhanvien = value; }
        }
        private string sdt;

        public string Sdt
        {
            get { return sdt; }
            set { sdt = value; }
        }
        private int iDNhomNguoiDung;

        public int IDNhomNguoiDung
        {
            get { return iDNhomNguoiDung; }
            set { iDNhomNguoiDung = value; }
        }
        public DTO_QuanLy()
        {

        }
        public DTO_QuanLy(int getid, string gettendangnhap, string getmatkhau, string gettennguoidung, string getidchinhanh, string getmanhanvien, string getsdt, int getIDNhomNguoiDung)
        {
            Id = getid;
            Tendangnhap = gettendangnhap.ToUpper();
            Matkhau = getmatkhau;
            Tennguoidung = gettennguoidung;
            Manhanvien = getmanhanvien;
            Sdt = getsdt;
            Idchinhanh = getidchinhanh;
            IDNhomNguoiDung = getIDNhomNguoiDung;
        }
    }
}
