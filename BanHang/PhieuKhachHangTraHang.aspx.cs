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
    public partial class PhieuKhachHangTraHang : System.Web.UI.Page
    {
        dtPhieuKhachHangTraHang data = new dtPhieuKhachHangTraHang();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["KTDangNhap"] != "GPM")
            {
                Response.Redirect("DangNhap.aspx");
            }
            else
            {
                if (!IsPostBack)
                {
                    IDPhieuKhachHangTraHangTem_Temp.Value = Session["IDNhanVien"].ToString();
                    cmbNguoiLapPhieu.Text = Session["IDNhanVien"].ToString();
                }
                LoadGrid(IDPhieuKhachHangTraHangTem_Temp.Value.ToString());
            }
        }

        private void LoadGrid(string IDPhieuKhachHangTraHang)
        {
            data = new dtPhieuKhachHangTraHang();
            gridDanhSachHangHoa_Temp.DataSource = data.ChiTietPhieuKhachHangTraHang_Temp(IDPhieuKhachHangTraHang);
            gridDanhSachHangHoa_Temp.DataBind();
        }

        protected void btnThem_Click(object sender, EventArgs e)
        {
            string IDPhieuTraHang = IDPhieuKhachHangTraHangTem_Temp.Value + "";
            if (cmbHangHoa.Value != null && cmbLyDoTra.Value != null)
            {
                data = new dtPhieuKhachHangTraHang();
                double SoLuong = double.Parse(txtSoLuong.Text.ToString());
                if (SoLuong > 0)
                {
                    string IDHangHoa = dtPhieuKhachHangTraHang.LayID_HangHoa_CTHD(cmbHangHoa.Value.ToString());
                    string IDCTHD = cmbHangHoa.Value.ToString();

                    double DoDay = dtPhieuKhachHangTraHang.LayDoDay_TraHang(cmbHangHoa.Value.ToString());
                    int TrangThaiGia = dtPhieuKhachHangTraHang.LayTrangThaiGia_TraHang(cmbHangHoa.Value.ToString());
                    double HeSo = dtPhieuKhachHangTraHang.LayHeSo_TraHang(cmbHangHoa.Value.ToString());
                    DataTable tHH = data.ChiTietHangHoa_ID(IDCTHD, IDPhieuTraHang);
                    if (tHH.Rows.Count == 0)
                    {
                        string GiaBan = txtGiaBan.Text.ToString();
                        string lyDoTra = cmbLyDoTra.Text.ToString();
                        data.ThemChiTietPhieuKhachHangTraHang_Temp(txtDVT.Text.ToString(), IDPhieuTraHang, IDHangHoa, GiaBan, SoLuong.ToString(), (double.Parse(GiaBan) * SoLuong).ToString(), lyDoTra, DoDay.ToString(), TrangThaiGia.ToString(), HeSo.ToString(), IDCTHD.ToString());
                        Clear();
                    }
                    else
                    {
                        string GiaBan = txtGiaBan.Text.ToString();
                        string lyDoTra = cmbLyDoTra.Text.ToString();
                        data.CapNhatChiTietPhieuKhachHangTraHang_Temp(IDPhieuTraHang, IDHangHoa, GiaBan, SoLuong.ToString(), (double.Parse(GiaBan) * SoLuong).ToString(), lyDoTra);
                        Clear();
                    }
                }
                else
                {
                    Response.Write("<script language='JavaScript'> alert('Số lượng > 0.'); </script>");
                }
            }
            else
            {
                Response.Write("<script language='JavaScript'> alert('Chọn hàng hóa và lý do trả.'); </script>");
            }
           
            LoadGrid(IDPhieuTraHang);
        }
        public void Clear()
        {
            cmbHangHoa.Text = "";
            txtSoLuong.Text = "0";
            txtDVT.Text = "";
            txtGiaBan.Text = "";
            cmbLyDoTra.Text = "";
        }
        protected void cmbNgayLapPhieu_Init(object sender, EventArgs e)
        {
            cmbNgayLapPhieu.Date = DateTime.Now;
        }

        protected void cmbHangHoa_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (txtSoHoaDon.Text != "" && dtPhieuKhachHangTraHang.LayIDHoaDon(txtSoHoaDon.Text.Trim()) != 0)
            {
                string IDHangHoa = dtPhieuKhachHangTraHang.LayID_HangHoa_CTHD(cmbHangHoa.Value.ToString());
                string IDHoaDon = dtPhieuKhachHangTraHang.LayIDHoaDon(txtSoHoaDon.Text.Trim()).ToString();
                string IDCTHD = cmbHangHoa.Value.ToString();
                data = new dtPhieuKhachHangTraHang();
                DataTable dta = data.ChiTietHangHoa(IDCTHD, IDHoaDon);
                if (dta.Rows.Count != 0)
                {
                    DataRow dr = dta.Rows[0];
                    txtDVT.Text = dr["TenDonViTinh"].ToString();
                    txtGiaBan.Text = dr["GiaBan"].ToString();
                    txtSoLuong.Text = dr["SoLuong"].ToString();
                }
                txtSoLuong.Text = "0";
                txtGiaBan.Enabled = false;
            }
            else
            {
                txtSoLuong.Text = "0";
                txtGiaBan.Enabled = true;
                txtDVT.Text = dtHangHoa.LayTenDonViTinh(cmbHangHoa.Value.ToString());
                txtGiaBan.Text = dtCapNhatTonKho.GiaBan(cmbHangHoa.Value.ToString())+"";
            }
        }

        protected void txtSoLuong_NumberChanged(object sender, EventArgs e)
        {
            if (txtSoHoaDon.Text != "" && dtPhieuKhachHangTraHang.LayIDHoaDon(txtSoHoaDon.Text.Trim()) != 0)
            {
                string IDHoaDon = dtPhieuKhachHangTraHang.LayIDHoaDon(txtSoHoaDon.Text.Trim()).ToString();
                data = new dtPhieuKhachHangTraHang();
                cmbHangHoa.DataSource = data.DanhSachHangHoa_HoaDon(IDHoaDon);
                cmbHangHoa.DataBind();

                double SoLuongDoi = double.Parse(txtSoLuong.Value.ToString());
                string IDCTHD = cmbHangHoa.Value.ToString();

                data = new dtPhieuKhachHangTraHang();
                DataTable dta = data.DanhSachChiTietHoaDon_IDCTHD(IDCTHD, IDHoaDon);
                double soLuong2 = 0;
                double giaBan = 0;
                if (dta.Rows.Count != 0)
                {
                    DataRow dr = dta.Rows[0];
                    soLuong2 = double.Parse(dr["SoLuong"].ToString());
                    giaBan = double.Parse(dr["GiaBan"].ToString());
                }

                if (soLuong2 < SoLuongDoi)
                {
                    txtSoLuong.Value = soLuong2;
                    Response.Write("<script language='JavaScript'> alert('Không được vượt số lượng mua.'); </script>");
                }
            }
            else
            {
                txtSoHoaDon.Text = "";
                txtSoHoaDon.Focus();
                Response.Write("<script language='JavaScript'> alert('Vui lòng nhập mã hóa đơn bán hàng !!!'); </script>");
            }
        }

        

        protected void btnThemPhieuKhachHangTraHang_Click(object sender, EventArgs e)
        {
            string ID = IDPhieuKhachHangTraHangTem_Temp.Value.ToString();
            string IDNhanVien = Session["IDNhanVien"].ToString();
            string GhiChu = txtGhiChu.Text == null ? "" : txtGhiChu.Text.ToString();
            string IDKH = "0";
            if (txtSoHoaDon.Text != "" && dtPhieuKhachHangTraHang.LayIDHoaDon(txtSoHoaDon.Text.Trim()) != 0)
            {
                string MaHoaDon = txtSoHoaDon.Text.Trim();
                string IDHoaDon = dtPhieuKhachHangTraHang.LayIDHoaDon(MaHoaDon).ToString();
                DataTable da1 = data.HoaDon_ID(IDHoaDon);
                if (da1.Rows.Count != 0)
                {
                    DataRow dr1 = da1.Rows[0];
                    IDKH = dr1["IDKhachHang"].ToString();
                }










                // tính lại doanh thu hóa đơn, chiết khấu, giảm công nợ, cộng tồn kho
                DataTable da = data.ChiTietPhieuKhachHangTraHang_Temp(ID);
                if (da.Rows.Count != 0)
                {
                    //tính tổng tiền giảm
                    
                    double TongTien = 0;
                    foreach (DataRow dr in da.Rows)
                    {
                        double ThanhTien = double.Parse(dr["ThanhTien"].ToString());
                        TongTien = TongTien + ThanhTien;
                    }
                    object IDThem = data.ThemPhieuKhachHangTraHang(MaHoaDon, IDNhanVien, IDKH.ToString(), TongTien.ToString(), GhiChu);
                    if (IDThem != null)
                    {
                       
                        for (int i = 0; i < da.Rows.Count; i++)
                        {
                            DataRow dr = da.Rows[i];
                            string IDHangHoa = dr["IDHangHoa"].ToString();
                            string GiaBan = dr["GiaBan"].ToString();
                            string SoLuong = dr["SoLuong"].ToString();
                            string ThanhTien = dr["ThanhTien"].ToString();
                            string LyDoDoi = dr["LyDoDoi"].ToString();
                            string TenDonViTinh = dr["TenDonViTinh"].ToString();
                            double DoDay = Double.Parse(dr["DoDay"].ToString());
                            int TrangThaiGia = Int32.Parse(dr["TrangThaiGia"].ToString());
                            double HeSo = Double.Parse(dr["HeSo"].ToString());
                            string IDCTHD = dr["IDCTHD"].ToString();
                            data.ThemChiTietPhieuKhachHangTraHang(IDThem, IDHangHoa, GiaBan, SoLuong, ThanhTien, LyDoDoi, TenDonViTinh, DoDay.ToString(), TrangThaiGia.ToString(), HeSo.ToString(), IDCTHD);

                            // cộng tồn kho
                            double DoDayCu = dtHangHoa.LayDoDayHienTai(Int32.Parse(IDHangHoa));
                            if (DoDay == DoDayCu)
                            {
                                if (TrangThaiGia == 1)
                                {
                                    // bán lẻ
                                    double SLCong = Double.Parse(SoLuong) / (double)HeSo;
                                    dtCapNhatTonKho.CongTonKho(IDHangHoa, SLCong.ToString(), Session["IDKho"].ToString());
                                }
                                else
                                {
                                    // bán sỉ
                                    dtCapNhatTonKho.CongTonKho(IDHangHoa, SoLuong, Session["IDKho"].ToString());
                                }

                            }


                            // - Số lượng bán trong hóa đơn
                            if (dtCapNhatTonKho.SL_Trong_HoaDon(IDCTHD, IDHoaDon) - Double.Parse(SoLuong) > 0)
                            {
                                dtCapNhatTonKho.TruSL_KhachTraHang(IDCTHD, SoLuong, IDHoaDon);
                            }
                            else
                            {
                                dtCapNhatTonKho.Xoa_CTHD_KhachTraHang(IDCTHD, IDHoaDon);
                            }

                        }

                        if (ckGiamCongNo.Checked == true) // giảm công nợ KH
                        {
                            //giảm công nợ khách hàng; If khách hàng mua có công nợ, ngược lại ko trừ
                            if (dtKhachHang.LayIDNhomKH(Int32.Parse(IDKH)) != 1)//khách sỉ- có công nợ
                            {
                                dtKhachHang dtkh = new dtKhachHang();
                                dtkh.CapNhatCongNo(IDKH.ToString(), TongTien);
                                // cập nhật tổng tiền hóa đơn(tông tiền, khách cần trả, công nợ mới) - tổng tiền trả
                                dtCapNhatTonKho.CapNhat_HoaDon_KH_CongNo(IDHoaDon, TongTien.ToString());
                            }
                            else
                            {
                                // cập nhật tổng tiền hóa đơn(tông tiền, khách cần trả,) - tổng tiền trả
                                dtCapNhatTonKho.CapNhat_HoaDon_KH_K_CongNo(IDHoaDon, TongTien.ToString());
                            }
                        }
                        else
                        {

                            // cập nhật tổng tiền hóa đơn không công nợ
                            dtCapNhatTonKho.CapNhat_HoaDon_KH_K_CongNo(IDHoaDon, TongTien.ToString());
                        }

                        data.XoaChiTiet_Temp(ID);
                        dtLichSuTruyCap.ThemLichSu(Session["IDNhanVien"].ToString(), Session["IDNhom"].ToString(), "Phiếu khách hàng trả hàng", Session["IDKho"].ToString(), "Nhập xuất tồn", "Thêm");
                        Response.Redirect("DanhSachKhachHangTraHang.aspx");
                    }
                }
                else
                {
                    Clear();
                    cmbHangHoa.Focus();
                    Response.Write("<script language='JavaScript'> alert('Danh sách hàng hóa trả không được trống.'); </script>");
                }
            }
           
        }

        /// <summary>
        /// hủy phiếu
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnHuyPhieuKhachHangTraHang_Click(object sender, EventArgs e)
        {
            dtPhieuKhachHangTraHang dt = new dtPhieuKhachHangTraHang();
            string IDHoaDon = IDPhieuKhachHangTraHangTem_Temp.Value + "";
            dt.XoaPhieu_(IDHoaDon);
            dt.XoaChiTiet_Temp(IDHoaDon);
            Response.Redirect("DanhSachKhachHangTraHang.aspx");
        }
        /// <summary>
        /// xóa hàng
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void BtnXoaHang_Click(object sender, EventArgs e)
        {
            string IDHoaDon = dtPhieuKhachHangTraHang.LayIDHoaDon(txtSoHoaDon.Text.Trim()).ToString();
            dtPhieuKhachHangTraHang dt = new dtPhieuKhachHangTraHang();
            cmbHangHoa.DataSource = dt.DanhSachHangHoa_HoaDon(IDHoaDon);
            cmbHangHoa.DataBind();
            string ID = (((ASPxButton)sender).CommandArgument).ToString();
            dt.XoaChiTiet_ID(ID + "");
            LoadGrid(IDPhieuKhachHangTraHangTem_Temp.Value + "");
        }

        /// <summary>
        /// ID Chi tiết hóa đơn
        /// </summary>
        /// <param name="source"></param>
        /// <param name="e"></param>
        protected void cmbHangHoa_ItemRequestedByValue(object source, ListEditItemRequestedByValueEventArgs e)
        {
            if (txtSoHoaDon.Text != "" && dtPhieuKhachHangTraHang.LayIDHoaDon(txtSoHoaDon.Text.Trim()) != 0)
            {
                cmbHangHoa.DataSource = data.DanhSachHangHoa_HoaDon(txtSoHoaDon.Text.Trim().ToString());
                cmbHangHoa.ValueField = "ID"; // id CTHD
                cmbHangHoa.DataBind();
            }
        }
        protected void cmbHangHoa_ItemsRequestedByFilterCondition(object source, ListEditItemsRequestedByFilterConditionEventArgs e)
        {
            if (txtSoHoaDon.Text != "" && dtPhieuKhachHangTraHang.LayIDHoaDon(txtSoHoaDon.Text.Trim()) != 0)
            {
                cmbHangHoa.DataSource = data.DanhSachHangHoa_HoaDon(txtSoHoaDon.Text.Trim().ToString());
                cmbHangHoa.ValueField = "ID";// id CTHD
                cmbHangHoa.DataBind();
            }
        }

        /// <summary>
        /// lọc thông tin
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnLoc_Click(object sender, EventArgs e)
        {
            if (txtSoHoaDon.Text != "")
            {
                string MaHoaDon = txtSoHoaDon.Text.Trim();
                string IDHoaDon = dtPhieuKhachHangTraHang.LayIDHoaDon(MaHoaDon).ToString();
                if (IDHoaDon != "0")
                {
                    cmbHangHoa.Enabled = true;
                    txtSoLuong.Enabled = true;
                    data = new dtPhieuKhachHangTraHang();
                    DataTable da = data.HoaDon_ID(IDHoaDon);
                    if (da.Rows.Count != 0)
                    {
                        DataRow dr = da.Rows[0];
                        cmbNhanVienBanHang.Value = dr["IDNhanVien"].ToString();
                      
                        txtTenKhachHang.Text = dtKhachHang.LayTenKhachHang_ID(dr["IDKhachHang"].ToString());
                        cmbHangHoa.DataSource = data.DanhSachHangHoa_HoaDon(IDHoaDon);
                        cmbHangHoa.DataBind();
                        data.XoaChiTiet_Temp(IDHoaDon);
                    }
                    LoadGrid(IDPhieuKhachHangTraHangTem_Temp.Value.ToString());
                }
                else
                {
                    txtSoHoaDon.Text = "";
                    txtSoHoaDon.Focus();
                    Response.Write("<script language='JavaScript'> alert('Không tìm thấy mã hóa đơn bán hàng !!!'); </script>");
                }
            }
            else
            {
                dtPhieuKhachHangTraHang dt = new dtPhieuKhachHangTraHang();
                cmbHangHoa.Enabled = false;
                txtSoLuong.Enabled = false;
                string IDHoaDon = IDPhieuKhachHangTraHangTem_Temp.Value + "";
                dt.XoaPhieu_(IDHoaDon);
                dt.XoaChiTiet_Temp(IDHoaDon);
                txtSoHoaDon.Text = "";
                txtSoHoaDon.Focus();
                Response.Write("<script language='JavaScript'> alert('Vui lòng nhập mã hóa đơn bán hàng !!!'); </script>");
            }
        }
    }
}