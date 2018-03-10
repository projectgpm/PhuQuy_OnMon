using BanHang.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BanHang
{
    public partial class BaoCaoThuChi : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                dateNgayBD.Value = DateTime.Today;
                dateNgayKT.Value = DateTime.Today;
            }
            LoadGrid();
           
        }

        protected void btnXemBaoCao_Click(object sender, EventArgs e)
        {
            if (dateNgayBD.Text != "" && dateNgayKT.Text != "")
            {
                DateTime date = DateTime.Now;
                int thang = date.Month;
                int nam = date.Year;
                string ngayBD = ""; string ngayKT = "";
                ngayBD = DateTime.Parse(dateNgayBD.Value + "").ToString("yyyy-MM-dd ");
                ngayKT = DateTime.Parse(dateNgayKT.Value + "").ToString("yyyy-MM-dd ");
                ngayBD = ngayBD + "00:00:0.000";
                ngayKT = ngayKT + "23:59:59.999";
                dtBaoCaoThuChi data = new dtBaoCaoThuChi();
                gridDanhSach.DataSource = data.LayDanhSach(ngayBD, ngayKT);
                gridDanhSach.DataBind();
            }
            else
            {
                Response.Write("<script language='JavaScript'> alert('Vui lòng nhập ngày bất đầu, ngày kết thúc.'); </script>");
            }
        }

        public void LoadGrid()
        {
            if (dateNgayBD.Text != "" && dateNgayKT.Text != "")
            {
                DateTime date = DateTime.Now;
                int thang = date.Month;
                int nam = date.Year;
                string ngayBD = ""; string ngayKT = "";
                ngayBD = DateTime.Parse(dateNgayBD.Value + "").ToString("yyyy-MM-dd ");
                ngayKT = DateTime.Parse(dateNgayKT.Value + "").ToString("yyyy-MM-dd ");
                ngayBD = ngayBD + "00:00:0.000";
                ngayKT = ngayKT + "23:59:59.999";
                dtBaoCaoThuChi data = new dtBaoCaoThuChi();
                gridDanhSach.DataSource = data.LayDanhSach(ngayBD, ngayKT);
                gridDanhSach.DataBind();
            }
            else
            {
                Response.Write("<script language='JavaScript'> alert('Vui lòng nhập ngày bất đầu, ngày kết thúc.'); </script>");
            }
        }
        protected void btnXuatExcel_Click(object sender, EventArgs e)
        {
            printf.WriteXlsToResponse();
        }
    }
}