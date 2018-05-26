using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLCafe.DTO
{
    public class DTO_NguyenLieu
    {
        private int iDNguyenLieu;

        public int IDNguyenLieu
        {
            get { return iDNguyenLieu; }
            set { iDNguyenLieu = value; }
        }
        private int iDHangHoa;


        public int IDHangHoa
        {
            get { return iDHangHoa; }
            set { iDHangHoa = value; }
        }
        private double trongLuong;

        public double TrongLuong
        {
            get { return trongLuong; }
            set { trongLuong = value; }
        }
        public DTO_NguyenLieu(int getidNl, int getidHH, double getTL)
        {
            this.IDNguyenLieu = getidNl;
            this.IDHangHoa = getidHH;
            this.TrongLuong = getTL;
        }
        public DTO_NguyenLieu(DataRow dr)
        {
            this.IDNguyenLieu = Int32.Parse(dr["IDNguyenLieu"].ToString());
            this.IDHangHoa = Int32.Parse(dr["IDHangHoa"].ToString());
            this.TrongLuong = double.Parse(dr["TrongLuong"].ToString());
        }
    }
}
