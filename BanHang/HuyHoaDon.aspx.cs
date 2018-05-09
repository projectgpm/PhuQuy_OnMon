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
    public partial class HuyHoaDon : System.Web.UI.Page
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
            gridDanhSach.DataSource = data.DanhSachHoaDon(DateTime.Now);
            gridDanhSach.DataBind();
        }

        protected void gridDanhSach_RowDeleting(object sender, DevExpress.Web.Data.ASPxDataDeletingEventArgs e)
        {
            data = new dtHuyHoaDon();
            string IDHoaDon = e.Keys[0].ToString();
            DataTable dsChiTietHoaDon = data.DanhSachHangHoa_IDHoaDon(IDHoaDon);
            if (dsChiTietHoaDon.Rows.Count > 0)
            {
                foreach (DataRow dr in dsChiTietHoaDon.Rows)
                {
                    int IDHangHoa = Int32.Parse(dr["IDHangHoa"].ToString());
                    double DoDayCu = dtHangHoa.LayDoDayHienTai(IDHangHoa);
                    double DoDayHoaDon = double.Parse(dr["DoDay"].ToString());
                    int TrangThaiGia = Int32.Parse(dr["TrangThaiGia"].ToString());
                    string SoLuong = dr["SoLuong"].ToString();
                    double HeSo = Double.Parse(dr["HeSo"].ToString());
                    // cộng lại tồn kho
                    if (DoDayHoaDon == DoDayCu)
                    {
                        if (TrangThaiGia == 1)
                        {
                            // bán lẻ
                            double SLCong = Double.Parse(SoLuong) / (double)HeSo;
                            dtCapNhatTonKho.CongTonKho(IDHangHoa.ToString(), SLCong.ToString(), Session["IDKho"].ToString());
                        }
                        else
                        {
                            // bán sỉ
                            dtCapNhatTonKho.CongTonKho(IDHangHoa.ToString(), SoLuong, Session["IDKho"].ToString());
                        }

                    }
                }
            }


            double CongNoKH = dtHuyHoaDon.CongNo_IDHoaDon(IDHoaDon);
            if (CongNoKH > 0)
            {
                int IDKhachHang = dtHuyHoaDon.IDKhachHang_IDHoaDon(IDHoaDon);
                if (dtKhachHang.LayIDNhomKH(IDKhachHang) != 1)//khách sỉ- có công nợ
                {
                    dtKhachHang dtkh = new dtKhachHang();
                    dtkh.CapNhatCongNo(IDKhachHang.ToString(), CongNoKH);
                }
            }
            data = new dtHuyHoaDon();
            data.CapNhatHoaDonHuy(IDHoaDon);
            e.Cancel = true;
            gridDanhSach.CancelEdit();
            LoadGrid();
        }


        protected void gridChiTietNhapKho_BeforePerformDataSelect(object sender, EventArgs e)
        {
            Session["IDHoaDon"] = (sender as ASPxGridView).GetMasterRowKeyValue();
        }
    }
}