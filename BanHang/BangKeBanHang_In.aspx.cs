using BanHang.Data;
using BanHang.Report;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BanHang
{
    public partial class BangKeBanHang_In : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string NgayBD = Request.QueryString["ngayBD"];
            string NgayKT = Request.QueryString["NgayKT"];
            string IDKhachHang = Request.QueryString["IDKhachHang"];
            string TenKhachHang = Request.QueryString["TenKhachHang"];      
            string strNgay = DateTime.Parse(NgayBD).ToString("dd-MM-yyyy") + " - " + DateTime.Parse(NgayKT).ToString("dd-MM-yyyy");

            rpBangKeBanHang rp = new rpBangKeBanHang();

            rp.Parameters["strNgay"].Value = strNgay;
            rp.Parameters["strNgay"].Visible = false;

            rp.Parameters["NgayBD"].Value = NgayBD;
            rp.Parameters["NgayBD"].Visible = false;
            rp.Parameters["NgayKT"].Value = NgayKT;
            rp.Parameters["NgayKT"].Visible = false;

            rp.Parameters["IDKhachHang"].Value = IDKhachHang;
            rp.Parameters["IDKhachHang"].Visible = false;

            rp.Parameters["TenKhachHang"].Value = TenKhachHang;
            rp.Parameters["TenKhachHang"].Visible = false;
            viewerReport.Report = rp;
        }
    }
}