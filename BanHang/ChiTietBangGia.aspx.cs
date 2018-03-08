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
    public partial class ChiTietBangGia : System.Web.UI.Page
    {
        dtBangGia data = new dtBangGia();
        protected void Page_Load(object sender, EventArgs e)
        {
            string IDBangGia = Request.QueryString["IDBangGia"];
            if (IDBangGia != null)
            {
                LoadGrid(IDBangGia);
            }
        }
        private void LoadGrid(string IDBangGia)
        {
            data = new dtBangGia();
            gridChiTietPhieuKiemKho.DataSource = data.DanhSachChiTiet(IDBangGia);
            gridChiTietPhieuKiemKho.DataBind();
        }
        protected void gridChiTietPhieuKiemKho_RowUpdating(object sender, DevExpress.Web.Data.ASPxDataUpdatingEventArgs e)
        {
            string ID = e.Keys[0].ToString();
            string GiaBanLe = e.NewValues["GiaBanLe"] == null ? "0" : e.NewValues["GiaBanLe"].ToString();
            string GiaBanSi = e.NewValues["GiaBanSi"] == null ? "0" : e.NewValues["GiaBanSi"].ToString();
            dtHangHoa dt = new dtHangHoa();
            data = new dtBangGia();

            DataTable da = dt.LayDanhSachHangHoa_MaHang(e.NewValues["MaHang"].ToString());
            if (da.Rows.Count != 0)
            {
                DataRow dr = da.Rows[0];
                float GiaBanSiCu = dt.LaySoTienCu_ChiTietGia_GiaBanSi(ID);
                float GiaBanLeCu = dt.LaySoTienCu_ChiTietGia_GiaBanLe(ID);
                if (float.Parse(GiaBanLe) != GiaBanLeCu)
                    //dtThayDoiGia.ThemLichSu(Session["IDNhanVien"].ToString(), dr["MaHang"].ToString(), dr["TenHangHoa"].ToString(), dr["IDDonViTinh"].ToString(), GiaCu + "", GiaMoi);
                    dtThayDoiGia.ThemLichSu(dr["MaHang"].ToString(),dr["TenHangHoa"].ToString(),dr["IDDonViTinh"].ToString(),GiaBanLeCu.ToString(),GiaBanLe,Session["IDNhanVien"].ToString(),"Thay đổi giá bán lẻ trong bảng giá");
                if (float.Parse(GiaBanSi) != GiaBanSiCu)
                    dtThayDoiGia.ThemLichSu(dr["MaHang"].ToString(), dr["TenHangHoa"].ToString(), dr["IDDonViTinh"].ToString(), GiaBanSiCu.ToString(), GiaBanSi, Session["IDNhanVien"].ToString(), "Thay đổi giá bán sỉ trong bảng giá");
            }

            data.CapNhatGiaChiTiet(ID, GiaBanLe, GiaBanSi);
            e.Cancel = true;
            gridChiTietPhieuKiemKho.CancelEdit();
            string IDBangGia = Request.QueryString["IDBangGia"];
            if (IDBangGia != null)
            {
                LoadGrid(IDBangGia);
            }
        }
    }
}