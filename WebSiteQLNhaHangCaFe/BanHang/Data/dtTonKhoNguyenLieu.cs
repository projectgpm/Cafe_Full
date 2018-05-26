using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace BanHang.Data
{
    public class dtTonKhoNguyenLieu
    {
        public DataTable DanhSachTonKhoNguyenLieu()
        {
            using (SqlConnection con = new SqlConnection(StaticContext.ConnectionString))
            {
                con.Open();
                string cmdText = "SELECT [CF_TonKho].*,[CF_NguyenLieu].IDDonViTinh  FROM [CF_TonKho],[CF_NguyenLieu] WHERE [CF_TonKho].DaXoa = 0 AND [CF_NguyenLieu].ID = [CF_TonKho].IDNguyenLieu";
                using (SqlCommand command = new SqlCommand(cmdText, con))
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    DataTable tb = new DataTable();
                    tb.Load(reader);
                    return tb;
                }
            }
        }
    }
}