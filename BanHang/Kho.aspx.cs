using BanHang.Data;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BanHang
{
    public partial class Kho : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["KTDangNhap"] != "GPM")
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
            dtKho data = new dtKho();
            gridThongTinCuaHangKho.DataSource = data.LayDanhSachKho();
            gridThongTinCuaHangKho.DataBind();
        }

        protected void gridThongTinCuaHangKho_RowDeleting(object sender, DevExpress.Web.Data.ASPxDataDeletingEventArgs e)
        {
            int ID = Int32.Parse(e.Keys[0].ToString());
            dtKho data = new dtKho();
            data.Xoakho(ID);
            e.Cancel = true;
            gridThongTinCuaHangKho.CancelEdit();
            LoadGrid();
            dtLichSuTruyCap.ThemLichSu(Session["IDNhanVien"].ToString(), Session["IDNhom"].ToString(), "Thông tin kho:" + ID, Session["IDKho"].ToString(), "Hệ Thống", "Xóa");   
        }

        protected void gridThongTinCuaHangKho_RowInserting(object sender, DevExpress.Web.Data.ASPxDataInsertingEventArgs e)
        {
            string MaKho = e.NewValues["MaKho"].ToString();
            string TenCuaHang = e.NewValues["TenCuaHang"].ToString();
            string SoSerial = e.NewValues["SoSerial"] == null ? "" : e.NewValues["SoSerial"].ToString();
            string DiaChi = e.NewValues["DiaChi"] == null ? "" : e.NewValues["DiaChi"].ToString();
            string DienThoai = e.NewValues["DienThoai"] == null ? "" : e.NewValues["DienThoai"].ToString();
            DateTime NgayMo = DateTime.Parse(e.NewValues["NgayMo"].ToString());
            string IDVung = e.NewValues["IDVung"].ToString();
            string TrangThaiBanHang = e.NewValues["TrangThaiBanHang"] == null ? "0" : e.NewValues["TrangThaiBanHang"].ToString();
            string GiaApDung = e.NewValues["GiaApDung"].ToString();

            if (dtSetting.IsNumber(MaKho) == true)
            {
                dtKho data = new dtKho();
                object ID = data.ThemKho(MaKho, TenCuaHang, SoSerial, DiaChi, DienThoai, NgayMo, IDVung, TrangThaiBanHang, GiaApDung);

                if (ID != null)
                {
                    data = new dtKho();
                    DataTable dt = data.DanhSachHangHoaTonKhoTong();
                    foreach (DataRow dr in dt.Rows)
                    {
                        string IDHangHoa = dr["IDHangHoa"].ToString();
                        double GiaBan = double.Parse(dr["GiaBan"].ToString());
                        double GiaBaN2 = double.Parse(dr["GiaBaN2"].ToString());
                        double GiaBan2 = double.Parse(dr["GiaBan2"].ToString());
                        double GiaBan3 = double.Parse(dr["GiaBan3"].ToString());
                        double GiaBan4 = double.Parse(dr["GiaBan4"].ToString());
                        double GiaBan5 = double.Parse(dr["GiaBan5"].ToString());
                        data = new dtKho();
                        data.ThemHangHoaTonKho(IDHangHoa, GiaBan, GiaBaN2, GiaBan2, GiaBan3, GiaBan4, GiaBan5, ID.ToString());
                    }
                }
                e.Cancel = true;
                gridThongTinCuaHangKho.CancelEdit();
                LoadGrid();
                dtLichSuTruyCap.ThemLichSu(Session["IDNhanVien"].ToString(), Session["IDNhom"].ToString(), "Thông tin kho", Session["IDKho"].ToString(), "Hệ Thống", "Thêm"); 
            }
            else
            {
                throw new Exception("Lỗi: Mã kho phải là số");
            }
           
        }

        protected void gridThongTinCuaHangKho_RowUpdating(object sender, DevExpress.Web.Data.ASPxDataUpdatingEventArgs e)
        {
            string ID = e.Keys[0].ToString();
            string MaKho = e.NewValues["MaKho"].ToString();
            string TenCuaHang = e.NewValues["TenCuaHang"].ToString();
            string SoSerial = e.NewValues["SoSerial"] == null ? "" : e.NewValues["SoSerial"].ToString();
            string DiaChi = e.NewValues["DiaChi"] == null ? "" : e.NewValues["DiaChi"].ToString();
            string DienThoai = e.NewValues["DienThoai"] == null ? "" : e.NewValues["DienThoai"].ToString();
            DateTime NgayMo = DateTime.Parse(e.NewValues["NgayMo"].ToString());
            string IDVung = e.NewValues["IDVung"].ToString();
            string TrangThaiBanHang = e.NewValues["TrangThaiBanHang"] == null ? "0" : e.NewValues["TrangThaiBanHang"].ToString();
            string GiaApDung = e.NewValues["GiaApDung"].ToString();
            if (dtSetting.IsNumber(MaKho) == true)
            {
                dtKho data = new dtKho();
                data.CapNhatKho(ID, MaKho, TenCuaHang, SoSerial, DiaChi, DienThoai, NgayMo, IDVung, TrangThaiBanHang, GiaApDung);
                e.Cancel = true;
                gridThongTinCuaHangKho.CancelEdit();
                LoadGrid();

                dtLichSuTruyCap.ThemLichSu(Session["IDNhanVien"].ToString(), Session["IDNhom"].ToString(), "Thông tin kho", Session["IDKho"].ToString(), "Hệ Thống", "Cập nhật");
            }
            else
            {
                throw new Exception("Lỗi: Mã kho phải là số");
            }
        }

        protected void gridThongTinCuaHangKho_InitNewRow(object sender, DevExpress.Web.Data.ASPxDataInitNewRowEventArgs e)
        {
            int Max = dtKho.LayID_Max();
            e.NewValues["MaKho"] = ((Max + 1) * 0.0001).ToString().Replace(".", "");
            e.NewValues["NgayMo"] = DateTime.Now;
           
        }
    }
}