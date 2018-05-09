using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace BanHang.Data
{
    public class dtInTempHoaDon
    {
        public object InsertHoaDon_Temp(string IDKho, string IDNhanVien, string IDKhachHang, HoaDon hoaDon, string TienChietKhauKhachHang, string TienCongNoKhachHang, string TyLeChietKhauKhachHang, string TrangThaiCongNoKhachHang, string CongNoCuKhachHang, string CongNoMoiKhachHang)
        {
            object IDHoaDon = null;
            using (SqlConnection con = new SqlConnection(StaticContext.ConnectionString))
            {
                SqlTransaction trans = null;
                try
                {
                    con.Open();
                    trans = con.BeginTransaction();

                    string InsertHoaDon = "INSERT INTO [GPM_HoaDon_Temp] ([IDKho], [IDKhachHang],[IDNhanVien],[NgayBan],[SoLuongHang],[TongTien],[GiamGia],[KhachCanTra],[KhachThanhToan], [MaHoaDon],[TienChietKhauKhachHang],[TyLeChietKhauKhachHang],[TrangThaiCongNoKhachHang],[CongNoCuKhachHang],[CongNoMoiKhachHang]) " +
                                          "OUTPUT INSERTED.ID " +
                                                             "VALUES (@IDKho, @IDKhachHang, @IDNhanVien, getdate(), @SoLuongHang, @TongTien, @GiamGia, @KhachCanTra, @KhachThanhToan, @MaHoaDon,@TienChietKhauKhachHang,@TyLeChietKhauKhachHang,@TrangThaiCongNoKhachHang,@CongNoCuKhachHang,@CongNoMoiKhachHang)";
                    using (SqlCommand cmd = new SqlCommand(InsertHoaDon, con, trans))
                    {
                        cmd.Parameters.AddWithValue("@IDKho", IDKho);
                        cmd.Parameters.AddWithValue("@IDKhachHang", IDKhachHang);
                        cmd.Parameters.AddWithValue("@IDNhanVien", IDNhanVien);
                        cmd.Parameters.AddWithValue("@SoLuongHang", hoaDon.SoLuongHang);
                        cmd.Parameters.AddWithValue("@TongTien", hoaDon.TongTien);
                        cmd.Parameters.AddWithValue("@GiamGia", 0);
                        cmd.Parameters.AddWithValue("@KhachCanTra", hoaDon.KhachCanTra);
                        cmd.Parameters.AddWithValue("@KhachThanhToan", hoaDon.KhachThanhToan);
                        cmd.Parameters.AddWithValue("@MaHoaDon", "");
                        cmd.Parameters.AddWithValue("@TienChietKhauKhachHang", TienChietKhauKhachHang);
                        cmd.Parameters.AddWithValue("@TyLeChietKhauKhachHang", TyLeChietKhauKhachHang);
                        cmd.Parameters.AddWithValue("@TrangThaiCongNoKhachHang", TrangThaiCongNoKhachHang);
                        cmd.Parameters.AddWithValue("@CongNoCuKhachHang", CongNoCuKhachHang);
                        cmd.Parameters.AddWithValue("@CongNoMoiKhachHang", CongNoMoiKhachHang);
                        IDHoaDon = cmd.ExecuteScalar();
                    }
                    if (IDHoaDon != null)
                    {
                        foreach (ChiTietHoaDon cthd in hoaDon.ListChiTietHoaDon)
                        {

                            dtHangHoa dtHH = new dtHangHoa();
                            string InsertChiTietHoaDon = "INSERT INTO [GPM_ChiTietHoaDon_Temp] ([HeSo],[TenHangHoa],[TenDonViTinh],[DoDay],[IDHoaDon],[IDHangHoa],[GiaBan] ,[SoLuong],[ChietKhau],[ThanhTien],[NgayBan],[IDKho],[TrangThaiGia]) " +
                                                                                   "VALUES (@HeSo,@TenHangHoa,@TenDonViTinh,@DoDay,@IDHoaDon, @IDHangHoa, @GiaBan, @SoLuong, @ChietKhau, @ThanhTien,getdate(),@IDKho,@TrangThaiGia)";
                            using (SqlCommand cmd = new SqlCommand(InsertChiTietHoaDon, con, trans))
                            {
                                //thêm chi tiết hóa đơn
                                cmd.Parameters.AddWithValue("@IDHoaDon", IDHoaDon);
                                cmd.Parameters.AddWithValue("@IDHangHoa", cthd.IDHangHoa);
                                cmd.Parameters.AddWithValue("@GiaBan", cthd.DonGia);
                                cmd.Parameters.AddWithValue("@SoLuong", cthd.SoLuong);
                                cmd.Parameters.AddWithValue("@ChietKhau", 0.0);
                                cmd.Parameters.AddWithValue("@ThanhTien", cthd.ThanhTien);
                                cmd.Parameters.AddWithValue("@IDKho", IDKho);
                                cmd.Parameters.AddWithValue("@TrangThaiGia", cthd.TrangThaiGiaSiHayLe);
                                cmd.Parameters.AddWithValue("@DoDay", cthd.DoDay.ToString());
                                cmd.Parameters.AddWithValue("@TenDonViTinh", cthd.DonViTinh);
                                cmd.Parameters.AddWithValue("@TenHangHoa", cthd.TenHang);
                                cmd.Parameters.AddWithValue("@HeSo", cthd.HeSo);
                                cmd.ExecuteNonQuery();
                            }
                        }
                        //end foreach
                    }
                    trans.Commit();
                    con.Close();
                }
                catch (Exception ex)
                {
                    if (trans != null) trans.Rollback();
                    throw new Exception("Quá trình lưu dữ liệu có lỗi xảy ra, vui lòng tải lại trang và thanh toán lại !!");
                }
            }
            return IDHoaDon;
        }
    }
}