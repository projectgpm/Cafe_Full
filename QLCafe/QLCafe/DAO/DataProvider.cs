using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLCafe.DAO
{
    class DataProvider
    {
        // Thực hiện truy vấn trả về bảng dữ liệu
        /// <summary>
        /// Datatable
        /// </summary>
        /// <param name="sTruyVan"></param>
        /// <returns></returns>
        public static DataTable TruyVanLayDuLieu(string sTruyVan)
        {
            SqlConnection conn = new SqlConnection();
            DAO_ConnectSQL connect = new DAO_ConnectSQL();
            conn = connect.Connect();
            if (conn == null)
                return null;
            SqlDataAdapter da = new SqlDataAdapter(sTruyVan, conn);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }
        // Thực hiện truy vấn không trả về dữ liệu
        /// <summary>
        /// insert,update,delete
        /// </summary>
        /// <param name="sTruyVan"></param>
        /// <returns></returns>
        public static bool TruyVanKhongLayDuLieu(string sTruyVan)
        {
            try
            {
                SqlConnection conn = new SqlConnection();
                DAO_ConnectSQL connect = new DAO_ConnectSQL();
                conn = connect.Connect();
                SqlCommand cm = new SqlCommand(sTruyVan, conn);
                cm.ExecuteNonQuery();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
