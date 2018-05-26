using QLCafe.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLCafe.BUS
{
    class BUS_TestKetNoiServer
    {
        public static bool DanhSachKetNoi()
        {
            return DAO_TestKetNoi.TestKetNoiServer();
        }
    }
}
