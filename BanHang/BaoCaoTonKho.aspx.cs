using BanHang.Data;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BanHang
{
    public partial class BaoCaoTonKho : System.Web.UI.Page
    {
        dtKhoHang data = new dtKhoHang();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["KTDangNhap"] != "GPM")
            {
                Response.Redirect("DangNhap.aspx");
            }
            
        }
        
        protected void gridTonKhoBanDau_HtmlRowPrepared(object sender, DevExpress.Web.ASPxGridViewTableRowEventArgs e)
        {
           
        }

        protected void btnXuatFile_Click(object sender, EventArgs e)
        {
            printf.WriteXlsToResponse();
        }
    }
}