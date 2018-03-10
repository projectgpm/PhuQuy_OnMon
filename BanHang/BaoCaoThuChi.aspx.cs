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
                LoadGrid();
            }
        }

        protected void rbTheoNam_CheckedChanged(object sender, EventArgs e)
        {
            if (rbTheoNam.Checked == true)
            {
                rbTuyChon.Checked = false;
                rbTheoThang.Checked = false;
                dateNgayBD.Enabled = false;
                dateNgayKT.Enabled = false;
            }
        }

        protected void rbTheoThang_CheckedChanged(object sender, EventArgs e)
        {
            if (rbTheoThang.Checked == true)
            {
                rbTuyChon.Checked = false;
                rbTheoNam.Checked = false;
                dateNgayBD.Enabled = false;
                dateNgayKT.Enabled = false;
            }
        }

        protected void rbTuyChon_CheckedChanged(object sender, EventArgs e)
        {
            if (rbTuyChon.Checked == true)
            {
                rbTheoThang.Checked = false;
                rbTheoNam.Checked = false;
                dateNgayBD.Enabled = true;
                dateNgayKT.Enabled = true;
                dateNgayBD.Value = DateTime.Today;
                dateNgayKT.Value = DateTime.Today;
            }
        }

        protected void btnXemBaoCao_Click(object sender, EventArgs e)
        {
            LoadGrid();
        }

        public void LoadGrid()
        {
            if (rbTuyChon.Checked == true)
            {
                rbTheoThang.Checked = false;
                rbTheoNam.Checked = false;
                dateNgayBD.Enabled = true;
                dateNgayKT.Enabled = true;
                dateNgayBD.Value = DateTime.Today;
                dateNgayKT.Value = DateTime.Today;
            }
            DateTime date = DateTime.Now;
            int thang = date.Month;
            int nam = date.Year;
            string ngayBD = ""; string ngayKT = "";
            if (rbTheoNam.Checked == true)
            {
                ngayBD = nam + "-01-01 ";
                ngayKT = nam + "-12-31 ";
            }
            else if (rbTheoThang.Checked == true)
            {
                ngayBD = nam + "-" + thang + "-01 ";
                ngayKT = nam + "-" + thang + "-" + dtSetting.tinhSoNgay(thang, nam) + " ";
            }
            else if (rbTuyChon.Checked == true)
            {
                ngayBD = DateTime.Parse(dateNgayBD.Value + "").ToString("yyyy-MM-dd ");
                ngayKT = DateTime.Parse(dateNgayKT.Value + "").ToString("yyyy-MM-dd ");
            }
            else Response.Write("<script language='JavaScript'> alert('Hãy chọn 1 hình thức báo cáo.'); </script>");

            ngayBD = ngayBD + "00:00:0.000";
            ngayKT = ngayKT + "23:59:59.999";

            dtBaoCaoThuChi data = new dtBaoCaoThuChi();
            gridDanhSach.DataSource = data.LayDanhSach(ngayBD, ngayKT);
            gridDanhSach.DataBind();
        }
        protected void btnXuatExcel_Click(object sender, EventArgs e)
        {
            XuatExcel.WriteXlsToResponse();
        }
    }
}