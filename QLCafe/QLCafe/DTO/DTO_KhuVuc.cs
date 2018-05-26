using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLCafe.DTO
{
    public class DTO_KhuVuc
    {
        private int iD;

        public int ID
        {
          get { return iD; }
          set { iD = value; }
        }
        private string makhuvuc;

        public string Makhuvuc
        {
            get { return makhuvuc; }
            set { makhuvuc = value; }
        }
        private string tenkhuvuc;

        public string Tenkhuvuc
        {
            get { return tenkhuvuc; }
            set { tenkhuvuc = value; }
        }
        private string tyle;

        public string Tyle
        {
            get { return tyle; }
            set { tyle = value; }
        }
        private string idchinhanh;

        public string Idchinhanh
        {
            get { return idchinhanh; }
            set { idchinhanh = value; }
        }
        private string ghichu;

        public string Ghichu
        {
            get { return ghichu; }
            set { ghichu = value; }
        }
        private string daxoa;

        public string Daxoa
        {
            get { return daxoa; }
            set { daxoa = value; }
        }
        
       
    }
}
