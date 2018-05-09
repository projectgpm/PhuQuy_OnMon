using BanHang.Data;
using DevExpress.Web;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BanHang
{
    public partial class DanhSachHoaDonDaHuy : System.Web.UI.Page
    {
        dtHuyHoaDon data = new dtHuyHoaDon();
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
            data = new dtHuyHoaDon();
            gridDanhSach.DataSource = data.DanhSachHoaDon_Huy();
            gridDanhSach.DataBind();
        }

        protected void gridDanhSach_RowDeleting(object sender, DevExpress.Web.Data.ASPxDataDeletingEventArgs e)
        {
           
        }


        protected void gridChiTietNhapKho_BeforePerformDataSelect(object sender, EventArgs e)
        {
            Session["IDHoaDon"] = (sender as ASPxGridView).GetMasterRowKeyValue();
        }
    }
}