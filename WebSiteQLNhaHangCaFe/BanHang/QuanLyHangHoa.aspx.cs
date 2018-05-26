using BanHang.Data;
using DevExpress.Web;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BanHang
{
    public partial class QuanLyHangHoa : System.Web.UI.Page
    {
        dtHangHoa data = new dtHangHoa();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["KTDangNhap"] != "GPM@2017")
            {
                Response.Redirect("DangNhap.aspx");
            }
            else
            {
                LoadGrid();
            }
        }

        private void LoadGrid()
        {
            data = new dtHangHoa();
            gridHangHoa.DataSource = data.LayDanhSachHangHoa(Session["IDChiNhanh"].ToString());
            gridHangHoa.DataBind();
        }
        protected TokenCollection LoadListBarCode(object ID)
        {
            TokenCollection listBarCode = new TokenCollection();
            if (ID != null)
            {
                DataTable dt = data.GetListBarCode(ID);
                foreach (DataRow row in dt.Rows)
                {
                    listBarCode.Add(row["Barcode"].ToString());
                }
            }
            return listBarCode;
        }

        protected void gridBarCode_RowInserting(object sender, DevExpress.Web.Data.ASPxDataInsertingEventArgs e)
        {
            //data = new dtHangHoa();
            //ASPxGridView gridBarCode = sender as ASPxGridView;
            //object IDHangHoa = gridBarCode.GetMasterRowKeyValue();
            //string IDNguyenLieu = e.NewValues["IDNguyenLieu"].ToString();
            //string TrongLuong = e.NewValues["TrongLuong"].ToString();
            //string MaNguyenLieu = dtThemHangHoa.LayMaNguyenLieu(IDNguyenLieu);
            //string NhaCungCap = dtThemHangHoa.LayNhaCungCap(IDNguyenLieu);
            //string IDDonViTinh = dtThemHangHoa.LayIDDonViTinh(IDNguyenLieu);
            //DataTable dt = data.KT_NguyenLieu(IDHangHoa, IDNguyenLieu);
            //if (dt.Rows.Count == 0)
            //{
            //    data.ThemNguyenLieu(IDHangHoa, IDNguyenLieu, TrongLuong, MaNguyenLieu, NhaCungCap, IDDonViTinh);
            //}
            //else
            //{
            //    throw new Exception("Lỗi: Nguyên liệu chế biến đã tồn tại?");
            //}
            //e.Cancel = true;
            //gridBarCode.CancelEdit();
            //gridBarCode.DataSource = data.GetListBarCode(IDHangHoa);
            //gridBarCode.DataBind();

            //dtLichSuTruyCap.ThemLichSu(Session["IDChiNhanh"].ToString(), Session["IDNhom"].ToString(), Session["IDNhanVien"].ToString(), "Quản lý hàng hóa", "Thêm nguyên liệu: " + IDNguyenLieu);
        }

        protected void gridBarCode_RowDeleting(object sender, DevExpress.Web.Data.ASPxDataDeletingEventArgs e)
        {
            //data = new dtHangHoa();
            //int ID = Int32.Parse(e.Keys["ID"].ToString());
            //data.XoaNguyenLieu(ID);
            //e.Cancel = true;
            //ASPxGridView gridBarCode = sender as ASPxGridView;
            //object IDHangHoa = gridBarCode.GetMasterRowKeyValue();
            //gridBarCode.DataSource = data.GetListBarCode(IDHangHoa);
            //gridBarCode.DataBind();

            //dtLichSuTruyCap.ThemLichSu(Session["IDChiNhanh"].ToString(), Session["IDNhom"].ToString(), Session["IDNhanVien"].ToString(), "Quản lý hàng hóa", "Xóa nguyên liệu: " + ID);
        }
        protected void gridBarCode_RowUpdating(object sender, DevExpress.Web.Data.ASPxDataUpdatingEventArgs e)
        {
            //data = new dtHangHoa();
            //ASPxGridView gridBarCode = sender as ASPxGridView;
            //int ID = Int32.Parse(e.Keys["ID"].ToString());
            //object IDHangHoa = gridBarCode.GetMasterRowKeyValue();
            //string IDNguyenLieu = e.NewValues["IDNguyenLieu"].ToString();
            //string TrongLuong = e.NewValues["TrongLuong"].ToString();
            //string MaNguyenLieu = dtThemHangHoa.LayMaNguyenLieu(IDNguyenLieu);
            //string NhaCungCap = dtThemHangHoa.LayNhaCungCap(IDNguyenLieu);
            //string IDDonViTinh = dtThemHangHoa.LayIDDonViTinh(IDNguyenLieu);
            //if (dtHangHoa.KiemTraNguyenLieu_ID(IDNguyenLieu, ID.ToString()) == true)
            //{
            //    data.CapNhatNguyenLieu(ID, IDHangHoa, IDNguyenLieu, TrongLuong, MaNguyenLieu, NhaCungCap, IDDonViTinh);
            //    e.Cancel = true;
            //    gridBarCode.CancelEdit();
            //    gridBarCode.DataSource = data.GetListBarCode(IDHangHoa);
            //    gridBarCode.DataBind();
            //}
            //else
            //{
            //    DataTable dt = data.KT_NguyenLieu(IDHangHoa, IDNguyenLieu);
            //    if (dt.Rows.Count == 0)
            //    {
            //        data.CapNhatNguyenLieu(ID, IDHangHoa, IDNguyenLieu, TrongLuong, MaNguyenLieu, NhaCungCap, IDDonViTinh);
            //        e.Cancel = true;
            //        gridBarCode.CancelEdit();
            //        gridBarCode.DataSource = data.GetListBarCode(IDHangHoa);
            //        gridBarCode.DataBind();
            //    }
            //    else
            //    {
            //        throw new Exception("Lỗi: Nguyên liệu chế biến đã tồn tại?");
            //    }
            //}

            //dtLichSuTruyCap.ThemLichSu(Session["IDChiNhanh"].ToString(), Session["IDNhom"].ToString(), Session["IDNhanVien"].ToString(), "Quản lý hàng hóa", "Cập nhật nguyên liệu: " + IDNguyenLieu);
        }
        protected void gridBarCode_Init(object sender, EventArgs e)
        {
            //data = new dtHangHoa();
            //ASPxGridView gridBarCode = sender as ASPxGridView;
            //object IDHangHoa = gridBarCode.GetMasterRowKeyValue();
            //gridBarCode.DataSource = data.GetListBarCode(IDHangHoa);
            //gridBarCode.DataBind();
        }
        protected void gridHangHoa_RowDeleting(object sender, DevExpress.Web.Data.ASPxDataDeletingEventArgs e)
        {
            string ID = e.Keys[0].ToString();
            data = new dtHangHoa();
            data.XoaHangHoa(ID);
            e.Cancel = true;
            gridHangHoa.CancelEdit();
            LoadGrid();
            dtLichSuTruyCap.ThemLichSu(Session["IDChiNhanh"].ToString(), Session["IDNhom"].ToString(), Session["IDNhanVien"].ToString(), "Quản lý hàng hóa", "Xóa hàng hóa: " + ID);
        }

        protected void gridHangHoa_RowInserting(object sender, DevExpress.Web.Data.ASPxDataInsertingEventArgs e)
        {
            data = new dtHangHoa();
            string MaHangHoa = dtHangHoa.Dem_Max();
            string TenHangHoa = e.NewValues["TenHangHoa"].ToString();
            string GiaBan = e.NewValues["GiaBan"].ToString();
            string IDDonViTinh = e.NewValues["IDDonViTinh"].ToString();
            string IDNhomHang = e.NewValues["IDNhomHang"].ToString();
            string GhiChu = e.NewValues["GhiChu"] == null ? "" : e.NewValues["GhiChu"].ToString();
            string IDChiNhanh = Session["IDChiNhanh"].ToString();
            object ID = data.ThemHangHoa(MaHangHoa, TenHangHoa, GiaBan, IDDonViTinh, IDNhomHang, GhiChu, IDChiNhanh);
            if (ID != null)
            {
                //thêm vào all bảng giá
                dtBangGia bg = new dtBangGia();
                DataTable dbt = bg.DanhSach(IDChiNhanh);
                foreach (DataRow dr in dbt.Rows)
                {
                    string IDBangGia = dr["ID"].ToString();
                    bg.ThemIDHangHoaVaoChiTietGia(ID.ToString(), IDBangGia, GiaBan, IDChiNhanh);
                }
            }
            e.Cancel = true;
            gridHangHoa.CancelEdit();
            LoadGrid();

            dtLichSuTruyCap.ThemLichSu(Session["IDChiNhanh"].ToString(), Session["IDNhom"].ToString(), Session["IDNhanVien"].ToString(), "Quản lý hàng hóa", "Thêm hàng hóa: " + TenHangHoa);
        }

        protected void gridHangHoa_RowUpdating(object sender, DevExpress.Web.Data.ASPxDataUpdatingEventArgs e)
        {
            data = new dtHangHoa();
            string ID = e.Keys[0].ToString();
            string MaHangHoa = e.NewValues["MaHangHoa"].ToString();
            string TenHangHoa = e.NewValues["TenHangHoa"].ToString();
            string GiaBan = e.NewValues["GiaBan"].ToString();
            string IDDonViTinh = e.NewValues["IDDonViTinh"].ToString();
            string IDNhomHang = e.NewValues["IDNhomHang"].ToString();
            string GhiChu = e.NewValues["GhiChu"] == null ? "" : e.NewValues["GhiChu"].ToString();
            float GiaCu = data.LaySoTienCu(ID);
            if (GiaCu != float.Parse(GiaBan))
            {
                dtThayDoiGia.ThemLichSu(Session["IDNhanVien"].ToString(), MaHangHoa, TenHangHoa, IDDonViTinh, GiaCu + "", GiaBan, Session["IDChiNhanh"].ToString());
                dtBangGia bg = new dtBangGia();
                bg.CapNhatGiaCuTrongChiTietBangGia(ID, GiaBan);
            }
            data.SuaHangHoa(ID, MaHangHoa, TenHangHoa, GiaBan, IDDonViTinh, IDNhomHang, GhiChu);
            e.Cancel = true;
            gridHangHoa.CancelEdit();
            LoadGrid();

            dtLichSuTruyCap.ThemLichSu(Session["IDChiNhanh"].ToString(), Session["IDNhom"].ToString(), Session["IDNhanVien"].ToString(), "Quản lý hàng hóa", "Cập nhật hàng hóa: " + ID);
        }

        protected void gridHangHoa_InitNewRow(object sender, DevExpress.Web.Data.ASPxDataInitNewRowEventArgs e)
        {
            e.NewValues["MaHangHoa"] = dtHangHoa.Dem_Max();
        }
    }
}