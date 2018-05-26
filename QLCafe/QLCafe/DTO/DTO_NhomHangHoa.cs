using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLCafe.DTO
{
    public class DTO_NhomHangHoa
    {
        private int iD;

        public int ID
        {
            get { return iD; }
            set { iD = value; }
        }
        private string maNhom;

        public string MaNhom
        {
            get { return maNhom; }
            set { maNhom = value; }
        }
        private string tenNhom;

        public string TenNhom
        {
            get { return tenNhom; }
            set { tenNhom = value; }
        }
        public DTO_NhomHangHoa(int getID, string getMaNhom, string getTenNhom)
        {
            this.ID = getID;
            this.MaNhom = getMaNhom;
            this.TenNhom = getTenNhom;
        }
        public DTO_NhomHangHoa(DataRow dr)
        {
            this.ID = Int32.Parse(dr["ID"].ToString());
            this.MaNhom = dr["MaNhom"].ToString();
            this.TenNhom = dr["TenNhom"].ToString();
        }
    }
}
