using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;

namespace QLCafe.DAO
{
    class DAO_TestKetNoi
    {
        public static bool TestKetNoiServer()
        {
            try
            {
                string sTruyVan = "Select * from CF_NguoiDung";
                DataTable data = new DataTable();
                data = DataProvider.TruyVanLayDuLieu(sTruyVan);
                if (data.Rows.Count != 0)
                {
                    return true;
                }
                else
                    return false;
            }
            catch
            {
                return false;
            }
        }
        public static bool IsConnectedToInternet(string host)
        {
            Ping p = new Ping();
            try
            {
                PingReply pr = p.Send(host, 3000);
                if (pr.Status == IPStatus.Success)
                {
                    return true;
                }
            }
            catch (Exception)
            {


            }
            return false;
        }
    }
}
