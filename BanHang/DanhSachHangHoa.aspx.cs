using BanHang.Data;
using DevExpress.Web;
using DevExpress.Web.Internal;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BanHang
{
    public partial class DanhSachHangHoa : System.Web.UI.Page
    {
        dataHangHoa data = new dataHangHoa();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["KTDangNhap"] != "GPM")
            {
                Response.Redirect("DangNhap.aspx");
            }
            else
            {
                LoadGrid(cmbSoLuongXem.Value.ToString());
            }
        }

        private void LoadGrid(string HienThi)
        {
            data = new dataHangHoa();
            gridHangHoa.DataSource = data.LayDanhSachHangHoa(HienThi);
            gridHangHoa.DataBind();
        }

        protected void gridHangHoa_RowDeleting(object sender, DevExpress.Web.Data.ASPxDataDeletingEventArgs e)
        {
            string ID = e.Keys[0].ToString();
            data = new dataHangHoa();
            data.XoaHangHoa(ID);
            e.Cancel = true;
            gridHangHoa.CancelEdit();
            LoadGrid(cmbSoLuongXem.Value.ToString());
        }

        protected void gridHangHoa_RowInserting(object sender, DevExpress.Web.Data.ASPxDataInsertingEventArgs e)
        {
            data = new dataHangHoa();
            string MaHang = e.NewValues["MaHang"].ToString();
            DataTable dd = data.KiemTraHangHoa(MaHang);
            if (dd.Rows.Count == 0)
            {
                string IDNhomHang = e.NewValues["IDNhomHang"].ToString();
                string TenHangHoa = e.NewValues["TenHangHoa"].ToString();
                string IDDonViTinh = e.NewValues["IDDonViTinh"].ToString();
                float GiaMua = float.Parse(e.NewValues["GiaMua"].ToString());
                float GiaBan = float.Parse(e.NewValues["GiaBan"].ToString());
                float DoDay = float.Parse(e.NewValues["DoDay"].ToString());
                float ChieuDai = float.Parse(e.NewValues["ChieuDai"].ToString());
                string GhiChu = e.NewValues["GhiChu"] != null ? e.NewValues["GhiChu"].ToString() : "";
                object IDHangHoa = data.ThemHangHoa(IDNhomHang, MaHang, TenHangHoa, IDDonViTinh, GiaMua, GiaBan, GhiChu, DoDay.ToString(), ChieuDai.ToString());
                if (IDHangHoa != null)
                {
                    //thêm vào tồn kho
                    DataTable dta = data.LayDanhSachCuaHang();
                    for (int i = 0; i < dta.Rows.Count; i++)
                    {
                        DataRow dr = dta.Rows[i];
                        int IDKho = Int32.Parse(dr["ID"].ToString());
                        data.ThemHangVaoTonKho(IDKho, (int)IDHangHoa, 0);
                    }

                    //thêm vào all bảng giá
                    dtBangGia bg = new dtBangGia();
                    DataTable dbt = bg.DanhSach();
                    foreach (DataRow dr in dbt.Rows)
                    {
                        string IDBangGia = dr["ID"].ToString();
                        bg.ThemIDHangHoaVaoChiTietGia(IDHangHoa, IDBangGia, GiaBan.ToString());
                    }

                   
                }
                e.Cancel = true;
                gridHangHoa.CancelEdit();
                LoadGrid(cmbSoLuongXem.Value.ToString());

            }
            else Response.Write("<script language='JavaScript'> alert('Mã hàng đã tồn tại.'); </script>");
        }

        protected void gridHangHoa_RowUpdating(object sender, DevExpress.Web.Data.ASPxDataUpdatingEventArgs e)
        {

            string ID = e.Keys[0].ToString();
            string MaHang = e.NewValues["MaHang"].ToString();
            string IDNhomHang = e.NewValues["IDNhomHang"].ToString();
            string TenHangHoa = e.NewValues["TenHangHoa"].ToString();
            string IDDonViTinh = e.NewValues["IDDonViTinh"].ToString();
            float GiaMua = float.Parse(e.NewValues["GiaMua"].ToString());
            float GiaBan = float.Parse(e.NewValues["GiaBan"].ToString());
            float DoDay = float.Parse(e.NewValues["DoDay"].ToString());
            float ChieuDai = float.Parse(e.NewValues["ChieuDai"].ToString());
            string GhiChu = e.NewValues["GhiChu"] != null ? e.NewValues["GhiChu"].ToString() : "";
            data = new dataHangHoa();
            float GiaCu = data.LaySoTienCu(ID);
            if (GiaCu != GiaBan)
            {
                dtThayDoiGia.ThemLichSu(MaHang, ID, IDDonViTinh, GiaCu.ToString(), GiaBan.ToString(), Session["IDNhanVien"].ToString(), "Thay đổi giá");
                dtBangGia bg = new dtBangGia();
                bg.CapNhatGiaCuTrongChiTietBangGia(ID, GiaBan.ToString());
            }
            data.SuaThongTinHangHoaNew(ID, IDNhomHang, MaHang, TenHangHoa, IDDonViTinh, GiaMua, GiaBan, GhiChu, DoDay.ToString(), ChieuDai.ToString());
            e.Cancel = true;
            gridHangHoa.CancelEdit();
            LoadGrid(cmbSoLuongXem.Value.ToString());
        }

        protected void gridHangHoa_InitNewRow(object sender, DevExpress.Web.Data.ASPxDataInitNewRowEventArgs e)
        {
            e.NewValues["MaHang"] = dataHangHoa.Dem_Max();
            e.NewValues["GiaMua"] = "0";
            e.NewValues["GiaBan"] = "0";
            e.NewValues["DoDay"] = "0";
            e.NewValues["ChieuDai"] = "0";
            //e.NewValues["IDDonViTinh"] = "BAO";
        }
        protected void UploadImages_FileUploadComplete(object sender, FileUploadCompleteEventArgs e)
        {
           
        }
        protected void cmbSoLuongXem_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadGrid(cmbSoLuongXem.Value.ToString());
        }
    }
}