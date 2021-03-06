﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace BanHang.Data
{
    public class dtPhieuKhachHangTraHang
    {
        public DataTable DanhSachSoDonHang(string IDKhachHang)
        {
            using (SqlConnection con = new SqlConnection(StaticContext.ConnectionString))
            {
                con.Open();
                string cmdText = " SELECT * FROM [GPM_HoaDon] WHERE IDKhachHang = '" + IDKhachHang + "' AND TrangThaiCongNoKhachHang = 0 AND TrangThai = 0 AND DaXoa = 0";
                using (SqlCommand command = new SqlCommand(cmdText, con))
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    DataTable tb = new DataTable();
                    tb.Load(reader);
                    return tb;
                }
            }
        }
        public DataTable DanhSachPhieuKhachHangTraHang()
        {
            using (SqlConnection con = new SqlConnection(StaticContext.ConnectionString))
            {
                con.Open();
                string cmdText = "SELECT GPM_PhieuKhachHangTraHang.* FROM GPM_PhieuKhachHangTraHang ORDER BY GPM_PhieuKhachHangTraHang.ID DESC";
                using (SqlCommand command = new SqlCommand(cmdText, con))
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    DataTable tb = new DataTable();
                    tb.Load(reader);
                    return tb;
                }
            }
        }

        public DataTable ChiTietPhieuKhachHangTraHang_Temp(string IDPhhieuTraHang)
        {
            using (SqlConnection con = new SqlConnection(StaticContext.ConnectionString))
            {
                con.Open();
                string cmdText = "SELECT GPM_HangHoa.MaHang,GPM_HangHoa.IDDonViTinhSi,GPM_PhieuKhachHangTraHang_ChiTiet_Temp.* FROM GPM_PhieuKhachHangTraHang_ChiTiet_Temp, GPM_HangHoa WHERE GPM_HangHoa.ID = GPM_PhieuKhachHangTraHang_ChiTiet_Temp.IDHangHoa AND GPM_PhieuKhachHangTraHang_ChiTiet_Temp.IDPhieuKhachHangTraHang = '" + IDPhhieuTraHang + "'";
                using (SqlCommand command = new SqlCommand(cmdText, con))
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    DataTable tb = new DataTable();
                    tb.Load(reader);
                    return tb;
                }
            }
        }

        public DataTable ChiTietPhieuKhachHangTraHang(string IDPhhieuTraHang)
        {
            using (SqlConnection con = new SqlConnection(StaticContext.ConnectionString))
            {
                con.Open();
                string cmdText = "SELECT GPM_HangHoa.MaHang,GPM_PhieuKhachHangTraHang_ChiTiet.* FROM GPM_PhieuKhachHangTraHang_ChiTiet, GPM_HangHoa WHERE GPM_HangHoa.ID = GPM_PhieuKhachHangTraHang_ChiTiet.IDHangHoa AND GPM_PhieuKhachHangTraHang_ChiTiet.IDPhieuKhachHangTraHang = '" + IDPhhieuTraHang + "'";
                using (SqlCommand command = new SqlCommand(cmdText, con))
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    DataTable tb = new DataTable();
                    tb.Load(reader);
                    return tb;
                }
            }
        }

        public DataTable HoaDon_ID(string IDHoaDon)
        {
            using (SqlConnection con = new SqlConnection(StaticContext.ConnectionString))
            {
                con.Open();
                string cmdText = "select * from GPM_HoaDon where ID = '" + IDHoaDon + "'";
                using (SqlCommand command = new SqlCommand(cmdText, con))
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    DataTable tb = new DataTable();
                    tb.Load(reader);
                    return tb;
                }
            }
        }

        public static int LayIDHoaDon(string MaHoaDon)
        {
            using (SqlConnection con = new SqlConnection(StaticContext.ConnectionString))
            {
                con.Open();
                string cmdText = " SELECT ID FROM [GPM_HoaDon] WHERE [MaHoaDon] = '" + MaHoaDon + "'";
                using (SqlCommand command = new SqlCommand(cmdText, con))
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    DataTable tb = new DataTable();
                    tb.Load(reader);
                    if (tb.Rows.Count != 0)
                    {
                        DataRow dr = tb.Rows[0];
                        return Int32.Parse(dr["ID"].ToString());
                    }
                    else return 0;
                }
            }
        }
        /// <summary>
        /// thêm chi tiết hóa đơn
        /// </summary>
        /// <param name="IDCTHD"></param>
        /// <returns></returns>
        public static string LayID_HangHoa_CTHD(string IDCTHD)
        {
            using (SqlConnection con = new SqlConnection(StaticContext.ConnectionString))
            {
                con.Open();
                string cmdText = " SELECT IDHangHoa FROM [GPM_ChiTietHoaDon] WHERE [ID] = '" + IDCTHD + "'";
                using (SqlCommand command = new SqlCommand(cmdText, con))
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    DataTable tb = new DataTable();
                    tb.Load(reader);
                    if (tb.Rows.Count != 0)
                    {
                        DataRow dr = tb.Rows[0];
                        return dr["IDHangHoa"].ToString();
                    }
                    else return "0";
                }
            }
        }
        /// <summary>
        /// khách trả hàng, đọ dầy
        /// </summary>
        /// <param name="IDCTHD"></param>
        /// <returns></returns>
        public static double LayDoDay_TraHang(string IDCTHD)
        {
            using (SqlConnection con = new SqlConnection(StaticContext.ConnectionString))
            {
                con.Open();
                string cmdText = " SELECT DoDay FROM [GPM_ChiTietHoaDon] WHERE [ID] = '" + IDCTHD + "'";
                using (SqlCommand command = new SqlCommand(cmdText, con))
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    DataTable tb = new DataTable();
                    tb.Load(reader);
                    if (tb.Rows.Count != 0)
                    {
                        DataRow dr = tb.Rows[0];
                        return double.Parse(dr["DoDay"].ToString());
                    }
                    else return 0;
                }
            }
        }
        /// <summary>
        /// hệ số trả hàng
        /// </summary>
        /// <param name="IDCTHD"></param>
        /// <returns></returns>
        public static double LayHeSo_TraHang(string IDCTHD)
        {
            using (SqlConnection con = new SqlConnection(StaticContext.ConnectionString))
            {
                con.Open();
                string cmdText = " SELECT HeSo FROM [GPM_ChiTietHoaDon] WHERE [ID] = '" + IDCTHD + "'";
                using (SqlCommand command = new SqlCommand(cmdText, con))
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    DataTable tb = new DataTable();
                    tb.Load(reader);
                    if (tb.Rows.Count != 0)
                    {
                        DataRow dr = tb.Rows[0];
                        return double.Parse(dr["HeSo"].ToString());
                    }
                    else return 0;
                }
            }
        }
        /// <summary>
        /// Trạng thái giá
        /// </summary>
        /// <param name="IDCTHD"></param>
        /// <returns></returns>
        public static int LayTrangThaiGia_TraHang(string IDCTHD)
        {
            using (SqlConnection con = new SqlConnection(StaticContext.ConnectionString))
            {
                con.Open();
                string cmdText = " SELECT TrangThaiGia FROM [GPM_ChiTietHoaDon] WHERE [ID] = '" + IDCTHD + "'";
                using (SqlCommand command = new SqlCommand(cmdText, con))
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    DataTable tb = new DataTable();
                    tb.Load(reader);
                    if (tb.Rows.Count != 0)
                    {
                        DataRow dr = tb.Rows[0];
                        return Int32.Parse(dr["TrangThaiGia"].ToString());
                    }
                    else return 0;
                }
            }
        }
        public DataTable DanhSachHangHoa_HoaDon(string MaHoaDon)
        {
            using (SqlConnection con = new SqlConnection(StaticContext.ConnectionString))
            {
                con.Open();
                string cmdText = "select GPM_HangHoa.TenHangHoa, GPM_HangHoa.MaHang, GPM_ChiTietHoaDon.* from GPM_HangHoa,GPM_ChiTietHoaDon where  GPM_ChiTietHoaDon.IDHangHoa = GPM_HangHoa.ID and GPM_ChiTietHoaDon.IDHoaDon = '" + LayIDHoaDon(MaHoaDon) + "'";
                using (SqlCommand command = new SqlCommand(cmdText, con))
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    DataTable tb = new DataTable();
                    tb.Load(reader);
                    return tb;
                }
            }
        }

        public void XoaPhieu_(string IDPhieu)
        {
            using (SqlConnection con = new SqlConnection(StaticContext.ConnectionString))
            {
                con.Open();
                string cmdText = "delete from GPM_PhieuKhachHangTraHang where ID = '" + IDPhieu + "'";
                using (SqlCommand myCommand = new SqlCommand(cmdText, con))
                {
                    myCommand.ExecuteNonQuery();
                }
            }
        }

        public void XoaChiTiet_Temp(string IDPhieu)
        {
            using (SqlConnection con = new SqlConnection(StaticContext.ConnectionString))
            {
                con.Open();
                string cmdText = "delete from GPM_PhieuKhachHangTraHang_ChiTiet_Temp where IDPhieuKhachHangTraHang = '" + IDPhieu + "'";
                using (SqlCommand myCommand = new SqlCommand(cmdText, con))
                {
                    myCommand.ExecuteNonQuery();
                }
            }
        }

        public void XoaChiTiet_ID(string ID)
        {
            using (SqlConnection con = new SqlConnection(StaticContext.ConnectionString))
            {
                con.Open();
                string cmdText = "delete from GPM_PhieuKhachHangTraHang_ChiTiet_Temp where ID = '" + ID + "'";
                using (SqlCommand myCommand = new SqlCommand(cmdText, con))
                {
                    myCommand.ExecuteNonQuery();
                }
            }
        }

        public DataTable ChiTietHangHoa_ID(string IDCTHD, string IDPhieu)
        {
            using (SqlConnection con = new SqlConnection(StaticContext.ConnectionString))
            {
                con.Open();
                string cmdText = "select * from GPM_PhieuKhachHangTraHang_ChiTiet_Temp where IDCTHD = '" + IDCTHD + "' and IDPhieuKhachHangTraHang = '" + IDPhieu + "'";
                using (SqlCommand command = new SqlCommand(cmdText, con))
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    DataTable tb = new DataTable();
                    tb.Load(reader);
                    return tb;
                }
            }
        }
        public DataTable ChiTietTongSoLuongHangHoa(string IDPhieu)
        {
            using (SqlConnection con = new SqlConnection(StaticContext.ConnectionString))
            {
                con.Open();
                string cmdText = "select IDPhieuKhachHangTraHang, SUM(SoLuong) as TongSoLuong, SUM(ThanhTien) as TongTien from GPM_PhieuKhachHangTraHang_ChiTiet_Temp where IDPhieuKhachHangTraHang = '" + IDPhieu + "' group by IDPhieuKhachHangTraHang";
                using (SqlCommand command = new SqlCommand(cmdText, con))
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    DataTable tb = new DataTable();
                    tb.Load(reader);
                    return tb;
                }
            }
        }
        public DataTable ChiTietHangHoa(string ID, string IDHoaDon)
        {
            using (SqlConnection con = new SqlConnection(StaticContext.ConnectionString))
            {
                con.Open();
                string cmdText = "select GPM_ChiTietHoaDon.* from GPM_ChiTietHoaDon where GPM_ChiTietHoaDon.ID = '" + ID + "' AND IDHoaDon = '" + IDHoaDon + "'";
                using (SqlCommand command = new SqlCommand(cmdText, con))
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    DataTable tb = new DataTable();
                    tb.Load(reader);
                    return tb;
                }
            }
        }
        public DataTable DanhSachChiTietHoaDon(string IDHangHoa, string IDHoaDon)
        {
            using (SqlConnection con = new SqlConnection(StaticContext.ConnectionString))
            {
                con.Open();
                string cmdText = "select  GPM_ChiTietHoaDon.* from GPM_ChiTietHoaDon where IDHoaDon = '" + IDHoaDon + "' AND IDHangHoa = '" + IDHangHoa + "'";
                using (SqlCommand command = new SqlCommand(cmdText, con))
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    DataTable tb = new DataTable();
                    tb.Load(reader);
                    return tb;
                }
            }
        }
        public DataTable DanhSachChiTietHoaDon_IDCTHD(string IDCTHD, string IDHoaDon)
        {
            using (SqlConnection con = new SqlConnection(StaticContext.ConnectionString))
            {
                con.Open();
                string cmdText = "select  GPM_ChiTietHoaDon.* from GPM_ChiTietHoaDon where IDHoaDon = '" + IDHoaDon + "' AND ID = '" + IDCTHD + "'";
                using (SqlCommand command = new SqlCommand(cmdText, con))
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    DataTable tb = new DataTable();
                    tb.Load(reader);
                    return tb;
                }
            }
        }
        public DataTable LayPhieuTraHang_Null(string IDKho)
        {
            using (SqlConnection con = new SqlConnection(StaticContext.ConnectionString))
            {
                con.Open();
                string cmdText = "select * from GPM_PhieuKhachHangTraHang where IDKho = '" + IDKho + "' and IDHoaDon is null and IDNhanVien is null and IDKhachHang is null";
                using (SqlCommand command = new SqlCommand(cmdText, con))
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    DataTable tb = new DataTable();
                    tb.Load(reader);
                    return tb;
                }
            }
        }

        public object ThemPhieuKhachHangTraHang(string MaHoaDon, string IDNhanVien, string IDKhachHang, string TongTienTra, string GhiChu)
        {
            using (SqlConnection myConnection = new SqlConnection(StaticContext.ConnectionString))
            {
                try
                {
                    myConnection.Open();
                    object IDPhieuChuyenKho = null;
                    string cmdText = "INSERT INTO [GPM_PhieuKhachHangTraHang] ([MaHoaDon],[IDNhanVien],[IDKhachHang],[NgayDoi],[TongTienTra],[GhiChu]) OUTPUT INSERTED.ID VALUES (@MaHoaDon,@IDNhanVien,@IDKhachHang,getdate(),@TongTienTra,@GhiChu)";
                    using (SqlCommand myCommand = new SqlCommand(cmdText, myConnection))
                    {
                        myCommand.Parameters.AddWithValue("@MaHoaDon", MaHoaDon);
                        myCommand.Parameters.AddWithValue("@IDNhanVien", IDNhanVien);
                        myCommand.Parameters.AddWithValue("@IDKhachHang", IDKhachHang);
                        myCommand.Parameters.AddWithValue("@TongTienTra", TongTienTra);
                        myCommand.Parameters.AddWithValue("@GhiChu", GhiChu);
                        IDPhieuChuyenKho = myCommand.ExecuteScalar();
                    }
                    myConnection.Close();
                    return IDPhieuChuyenKho;
                }
                catch
                {
                    throw new Exception("Lỗi: Quá trình thêm dữ liệu gặp lỗi");
                }
            }
        }

        public object ThemChiTietPhieuKhachHangTraHang_Temp(string TenDonViTinh, string IDPhieuKhachHangTraHang, string IDHangHoa, string GiaBan, string SoLuong, string ThanhTien, string LyDoDoi, string DoDay, string TrangThaiGia, string HeSo, string IDCTHD)
        {
            using (SqlConnection myConnection = new SqlConnection(StaticContext.ConnectionString))
            {
                try
                {
                    myConnection.Open();
                    object IDPhieuChuyenKho = null;
                    string cmdText = "INSERT INTO [GPM_PhieuKhachHangTraHang_ChiTiet_Temp] ([TenDonViTinh],[IDPhieuKhachHangTraHang],[IDHangHoa],[GiaBan],[SoLuong],[ThanhTien],[LyDoDoi],[DoDay],[TrangThaiGia],[HeSo],[IDCTHD]) OUTPUT INSERTED.ID VALUES (@TenDonViTinh,@IDPhieuKhachHangTraHang,@IDHangHoa,@GiaBan,@SoLuong,@ThanhTien,@LyDoDoi,@DoDay,@TrangThaiGia,@HeSo,@IDCTHD)";
                    using (SqlCommand myCommand = new SqlCommand(cmdText, myConnection))
                    {
                        myCommand.Parameters.AddWithValue("@IDCTHD", IDCTHD);
                        myCommand.Parameters.AddWithValue("@IDPhieuKhachHangTraHang", IDPhieuKhachHangTraHang);
                        myCommand.Parameters.AddWithValue("@IDHangHoa", IDHangHoa);
                        myCommand.Parameters.AddWithValue("@HeSo", HeSo);
                        myCommand.Parameters.AddWithValue("@TenDonViTinh", TenDonViTinh);
                        myCommand.Parameters.AddWithValue("@GiaBan", GiaBan);
                        myCommand.Parameters.AddWithValue("@SoLuong", SoLuong);
                        myCommand.Parameters.AddWithValue("@ThanhTien", ThanhTien);
                        myCommand.Parameters.AddWithValue("@LyDoDoi", LyDoDoi);
                        myCommand.Parameters.AddWithValue("@DoDay", DoDay);
                        myCommand.Parameters.AddWithValue("@TrangThaiGia", TrangThaiGia);
                        IDPhieuChuyenKho = myCommand.ExecuteScalar();
                    }
                    myConnection.Close();
                    return IDPhieuChuyenKho;
                }
                catch
                {
                    throw new Exception("Lỗi: Quá trình thêm dữ liệu gặp lỗi");
                }
            }
        }

        public object ThemChiTietPhieuKhachHangTraHang(object IDPhieuKhachHangTraHang, string IDHangHoa, string GiaBan, string SoLuong, string ThanhTien, string LyDoDoi, string TenDonViTinh, string DoDay, string TrangThaiGia, string HeSo, string IDCTHD)
        {
            using (SqlConnection myConnection = new SqlConnection(StaticContext.ConnectionString))
            {
                try
                {
                    myConnection.Open();
                    object IDPhieuChuyenKho = null;
                    string cmdText = "INSERT INTO [GPM_PhieuKhachHangTraHang_ChiTiet] ([IDPhieuKhachHangTraHang],[IDHangHoa],[GiaBan],[SoLuong],[ThanhTien],[LyDoDoi],[TenDonViTinh],[DoDay],[TrangThaiGia],[HeSo],[IDCTHD]) OUTPUT INSERTED.ID VALUES (@IDPhieuKhachHangTraHang,@IDHangHoa,@GiaBan,@SoLuong,@ThanhTien,@LyDoDoi,@TenDonViTinh,@DoDay, @TrangThaiGia, @HeSo,@IDCTHD)";
                    using (SqlCommand myCommand = new SqlCommand(cmdText, myConnection))
                    {
                        myCommand.Parameters.AddWithValue("@IDCTHD", IDCTHD);
                        myCommand.Parameters.AddWithValue("@HeSo", HeSo);
                        myCommand.Parameters.AddWithValue("@DoDay", DoDay);
                        myCommand.Parameters.AddWithValue("@TrangThaiGia", TrangThaiGia);
                        myCommand.Parameters.AddWithValue("@IDPhieuKhachHangTraHang", IDPhieuKhachHangTraHang);
                        myCommand.Parameters.AddWithValue("@TenDonViTinh", TenDonViTinh);
                        myCommand.Parameters.AddWithValue("@IDHangHoa", IDHangHoa);
                        myCommand.Parameters.AddWithValue("@GiaBan", GiaBan);
                        myCommand.Parameters.AddWithValue("@SoLuong", SoLuong);
                        myCommand.Parameters.AddWithValue("@ThanhTien", ThanhTien);
                        myCommand.Parameters.AddWithValue("@LyDoDoi", LyDoDoi);
                        IDPhieuChuyenKho = myCommand.ExecuteScalar();
                    }
                    myConnection.Close();
                    return IDPhieuChuyenKho;
                }
                catch
                {
                    throw new Exception("Lỗi: Quá trình thêm dữ liệu gặp lỗi");
                }
            }
        }

        public void CapNhatChiTietPhieuKhachHangTraHang_Temp(string IDPhieuKhachHangTraHang, string IDHangHoa, string GiaBan, string SoLuong, string ThanhTien, string LyDoDoi)
        {
            using (SqlConnection myConnection = new SqlConnection(StaticContext.ConnectionString))
            {
                try
                {
                    myConnection.Open();
                    string cmdText = "update GPM_PhieuKhachHangTraHang_ChiTiet_Temp set GiaBan = @GiaBan, SoLuong = @SoLuong, ThanhTien = @ThanhTien, LyDoDoi = @LyDoDoi where IDPhieuKhachHangTraHang = @IDPhieuKhachHangTraHang and IDHangHoa =@IDHangHoa";
                    using (SqlCommand myCommand = new SqlCommand(cmdText, myConnection))
                    {
                        myCommand.Parameters.AddWithValue("@IDPhieuKhachHangTraHang", IDPhieuKhachHangTraHang);
                        myCommand.Parameters.AddWithValue("@IDHangHoa", IDHangHoa);
                        myCommand.Parameters.AddWithValue("@GiaBan", GiaBan);
                        myCommand.Parameters.AddWithValue("@SoLuong", SoLuong);
                        myCommand.Parameters.AddWithValue("@ThanhTien", ThanhTien);
                        myCommand.Parameters.AddWithValue("@LyDoDoi", LyDoDoi);
                        myCommand.ExecuteScalar();
                    }
                    myConnection.Close();
                }
                catch
                {
                    throw new Exception("Lỗi: Quá trình thêm dữ liệu gặp lỗi");
                }
            }
        }

        public void CapNhatPhieuKhachHangTraHang(string ID, string IDHoaDon, string IDNhanVien, string IDKhachHang, string TongHangHoaDoi, string TongTienTra, string GhiChu)
        {
            using (SqlConnection myConnection = new SqlConnection(StaticContext.ConnectionString))
            {
                try
                {
                    myConnection.Open();
                    string cmdText = "update GPM_PhieuKhachHangTraHang set IDHoaDon = '" + IDHoaDon + "', IDNhanVien = '" + IDNhanVien + "', IDKhachHang = '" + IDKhachHang + "', TongHangHoaDoi = '" + TongHangHoaDoi + "', TongTienTra = '" + TongTienTra + "', GhiChu = '" + GhiChu + "' where ID = '" + ID + "'";
                    using (SqlCommand myCommand = new SqlCommand(cmdText, myConnection))
                    {
                        myCommand.ExecuteScalar();
                    }
                    myConnection.Close();
                }
                catch
                {
                    throw new Exception("Lỗi: Quá trình thêm dữ liệu gặp lỗi");
                }
            }
        }
    }
}