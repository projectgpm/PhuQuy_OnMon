using BanHang.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BanHang
{
    public partial class DanhSachChiPhi : System.Web.UI.Page
    {
        dtChiPhi data = new dtChiPhi();
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
            data = new dtChiPhi();
            gridDanhSach.DataSource = data.DanhSach();
            gridDanhSach.DataBind();
        }

        protected void gridDanhSach_InitNewRow(object sender, DevExpress.Web.Data.ASPxDataInitNewRowEventArgs e)
        {
            e.NewValues["NgayLap"] = DateTime.Today.ToString("dd/MM/yyyy");
            e.NewValues["SoTien"] = "0";
        }
        protected void gridDanhSach_RowInserting(object sender, DevExpress.Web.Data.ASPxDataInsertingEventArgs e)
        {
            
            DateTime NgayLap = DateTime.Parse(e.NewValues["NgayLap"].ToString());
            string IDNguoiLap = Session["IDNhanVien"].ToString();
            string NguoiNop = e.NewValues["NguoiNop"] == null ? "" : e.NewValues["NguoiNop"].ToString();
            string NoiDung = e.NewValues["NoiDung"] == null ? "" : e.NewValues["NoiDung"].ToString();
            string TenPhieu = e.NewValues["TenPhieu"].ToString();
            double DuDau = dtSetting.SoQuyThuChi();
            double SoTien = double.Parse(e.NewValues["SoTien"].ToString());
            double DuCuoi = 0;
            if (TenPhieu == "0")
            {
                //phiếu thu
                DuCuoi = DuDau + SoTien;
            }
            else
            {
                //phiếu chi
                DuCuoi = DuDau - SoTien;
            }
            string IDLoaiThuChi = e.NewValues["IDLoaiThuChi"].ToString();
            data = new dtChiPhi();
            object ID = data.ThemMoi(NgayLap, IDNguoiLap, NguoiNop, NoiDung, DuDau.ToString(), SoTien.ToString(), DuCuoi.ToString(), IDLoaiThuChi, TenPhieu);
            if (ID != null)
            {
                if (TenPhieu == "0")
                {
                    //phiếu thu
                    data.CapNhatQuiThu(SoTien.ToString());
                }
                else
                {
                    //phiếu chi
                    data.CapNhatQuiChi(SoTien.ToString());
                }
            }
            e.Cancel = true;
            gridDanhSach.CancelEdit();
            LoadGrid();
        }
    }
}