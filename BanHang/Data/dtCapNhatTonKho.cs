using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace BanHang.Data
{
    public class dtCapNhatTonKho
    {
        public static void CapNhatKho(string IDHangHoa, string SoLuongMoi, string IDKho)
        {
            using (SqlConnection myConnection = new SqlConnection(StaticContext.ConnectionString))
            {
                try
                {
                    myConnection.Open();
                    string cmdText = "UPDATE [GPM_HangHoaTonKho] SET [SoLuongCon] = @SoLuongMoi, [NgayCapNhat] = getdate() WHERE [IDHangHoa] = @IDHangHoa AND [IDKho] = @IDKho";
                    using (SqlCommand myCommand = new SqlCommand(cmdText, myConnection))
                    {
                        myCommand.Parameters.AddWithValue("@IDHangHoa", IDHangHoa);
                        myCommand.Parameters.AddWithValue("@SoLuongMoi", SoLuongMoi);
                        myCommand.Parameters.AddWithValue("@IDKho", IDKho);
                        myCommand.ExecuteNonQuery();
                    }
                    myConnection.Close();
                }
                catch
                {
                    throw new Exception("Lỗi: Quá trình thêm dữ liệu gặp lỗi");
                }
            }
        }
        public static void CongTonKho(string IDHangHoa, string SoLuongCon, string IDKho)
        {
            using (SqlConnection myConnection = new SqlConnection(StaticContext.ConnectionString))
            {
                try
                {
                    myConnection.Open();
                    string cmdText = "UPDATE [GPM_HangHoaTonKho] SET [SoLuongCon] = [SoLuongCon] + @SoLuongCon, [NgayCapNhat] = getdate() WHERE [IDHangHoa] = @IDHangHoa AND [IDKho] = @IDKho";
                    using (SqlCommand myCommand = new SqlCommand(cmdText, myConnection))
                    {
                        myCommand.Parameters.AddWithValue("@IDHangHoa", IDHangHoa);
                        myCommand.Parameters.AddWithValue("@SoLuongCon", SoLuongCon);
                        myCommand.Parameters.AddWithValue("@IDKho", IDKho);
                        myCommand.ExecuteNonQuery();
                    }
                    myConnection.Close();
                }
                catch
                {
                    throw new Exception("Lỗi: Quá trình thêm dữ liệu gặp lỗi");
                }
            }
        }
        /// <summary>
        /// khách hàng trả hàng
        /// </summary>
        /// <param name="IDHangHoa"></param>
        /// <param name="IDHoaDon"></param>
        public static void Xoa_CTHD_KhachTraHang(string IDCTHD, string IDHoaDon)
        {
            using (SqlConnection myConnection = new SqlConnection(StaticContext.ConnectionString))
            {
                try
                {
                    myConnection.Open();
                    string cmdText = "DELETE [GPM_ChiTietHoaDon] WHERE [ID] = @IDCTHD AND [IDHoaDon] = @IDHoaDon";
                    using (SqlCommand myCommand = new SqlCommand(cmdText, myConnection))
                    {
                        myCommand.Parameters.AddWithValue("@IDCTHD", IDCTHD);
                        myCommand.Parameters.AddWithValue("@IDHoaDon", IDHoaDon);
                        myCommand.ExecuteNonQuery();
                    }
                    myConnection.Close();
                }
                catch
                {
                    throw new Exception("Lỗi: Quá trình thêm dữ liệu gặp lỗi");
                }
            }
        }
        /// <summary>
        /// khách hàng trả hàng
        /// </summary>
        /// <param name="IDHangHoa"></param>
        /// <param name="IDHoaDon"></param>
        /// <returns></returns>
        public static double SL_Trong_HoaDon(string IDCTHD, string IDHoaDon)
        {
            using (SqlConnection con = new SqlConnection(StaticContext.ConnectionString))
            {
                con.Open();
                string cmdText = " SELECT SoLuong FROM [GPM_ChiTietHoaDon] WHERE [ID] = '" + IDCTHD + "' AND IDHoaDon =" + IDHoaDon;
                using (SqlCommand command = new SqlCommand(cmdText, con))
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    DataTable tb = new DataTable();
                    tb.Load(reader);
                    if (tb.Rows.Count != 0)
                    {
                        DataRow dr = tb.Rows[0];
                        return double.Parse(dr["SoLuong"].ToString());
                    }
                    else return 0;
                }
            }
        }

        /// <summary>
        /// khách hàng trả hàng
        /// </summary>
        /// <param name="IDHangHoa"></param>
        /// <param name="SLTru"></param>
        /// <param name="IDHoaDon"></param>
        public static void TruSL_KhachTraHang(string IDCTHD, string SLTru, string IDHoaDon)
        {
            using (SqlConnection myConnection = new SqlConnection(StaticContext.ConnectionString))
            {
                try
                {
                    myConnection.Open();
                    string cmdText = "UPDATE [GPM_ChiTietHoaDon] SET [SoLuong] = [SoLuong] - @SLTru WHERE [ID] = @IDCTHD AND [IDHoaDon] = @IDHoaDon";
                    using (SqlCommand myCommand = new SqlCommand(cmdText, myConnection))
                    {
                        myCommand.Parameters.AddWithValue("@IDCTHD", IDCTHD);
                        myCommand.Parameters.AddWithValue("@SLTru", SLTru.ToString());
                        myCommand.Parameters.AddWithValue("@IDHoaDon", IDHoaDon);
                        myCommand.ExecuteNonQuery();
                    }
                    myConnection.Close();
                }
                catch
                {
                    throw new Exception("Lỗi: Quá trình thêm dữ liệu gặp lỗi");
                }
            }
        }
        /// <summary>
        /// khách hàng trả hàng. cập nhật lại hóa đơn cho đúng dữ liệu
        /// </summary>
        /// <param name="IDHoaDon"></param>
        /// <param name="TongTienGiam"></param>
        public static void CapNhat_HoaDon_KH_CongNo(string IDHoaDon,string TongTienGiam)
        {
            using (SqlConnection myConnection = new SqlConnection(StaticContext.ConnectionString))
            {
                try
                {
                    myConnection.Open();
                    string cmdText = "UPDATE [GPM_HoaDon] SET [TongTien] = [TongTien] - @TongTienGiam, [KhachCanTra] = [KhachCanTra] - @TongTienGiam, [CongNoMoiKhachHang] = [CongNoMoiKhachHang]- @TongTienGiam WHERE  [ID] = @IDHoaDon";
                    using (SqlCommand myCommand = new SqlCommand(cmdText, myConnection))
                    {
                        myCommand.Parameters.AddWithValue("@TongTienGiam", TongTienGiam.ToString());
                        myCommand.Parameters.AddWithValue("@IDHoaDon", IDHoaDon);
                        myCommand.ExecuteNonQuery();
                    }
                    myConnection.Close();
                }
                catch
                {
                    throw new Exception("Lỗi: Quá trình thêm dữ liệu gặp lỗi");
                }
            }
        }
        public static void CapNhat_HoaDon_KH_K_CongNo(string IDHoaDon, string TongTienGiam)
        {
            using (SqlConnection myConnection = new SqlConnection(StaticContext.ConnectionString))
            {
                try
                {
                    myConnection.Open();
                    string cmdText = "UPDATE [GPM_HoaDon] SET [TongTien] = [TongTien] - @TongTienGiam, [KhachCanTra] = [KhachCanTra] - @TongTienGiam WHERE  [ID] = @IDHoaDon";
                    using (SqlCommand myCommand = new SqlCommand(cmdText, myConnection))
                    {
                        myCommand.Parameters.AddWithValue("@TongTienGiam", TongTienGiam.ToString());
                        myCommand.Parameters.AddWithValue("@IDHoaDon", IDHoaDon);
                        myCommand.ExecuteNonQuery();
                    }
                    myConnection.Close();
                }
                catch
                {
                    throw new Exception("Lỗi: Quá trình thêm dữ liệu gặp lỗi");
                }
            }
        }
        public static void TruTonKho(string IDHangHoa, string SoLuong, string IDKho)
        {
            using (SqlConnection myConnection = new SqlConnection(StaticContext.ConnectionString))
            {
                try
                {
                    myConnection.Open();
                    string cmdText = "UPDATE [GPM_HangHoaTonKho] SET [SoLuongCon] = [SoLuongCon] - @SoLuongCon, [NgayCapNhat] = getdate() WHERE [IDHangHoa] = @IDHangHoa AND [IDKho] = @IDKho";
                    using (SqlCommand myCommand = new SqlCommand(cmdText, myConnection))
                    {
                        myCommand.Parameters.AddWithValue("@IDHangHoa", IDHangHoa);
                        myCommand.Parameters.AddWithValue("@SoLuongCon", SoLuong);
                        myCommand.Parameters.AddWithValue("@IDKho", IDKho);
                        myCommand.ExecuteNonQuery();
                    }
                    myConnection.Close();
                }
                catch
                {
                    throw new Exception("Lỗi: Quá trình thêm dữ liệu gặp lỗi");
                }
            }
        }

        public static double SoLuong_TonKho(string IDHangHoa, string IDKho)
        {
            using (SqlConnection con = new SqlConnection(StaticContext.ConnectionString))
            {
                con.Open();
                string cmdText = " SELECT SoLuongCon FROM [GPM_HangHoaTonKho] WHERE [IDHangHoa] = '" + IDHangHoa + "' AND IDKho =" + IDKho;
                using (SqlCommand command = new SqlCommand(cmdText, con))
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    DataTable tb = new DataTable();
                    tb.Load(reader);
                    if (tb.Rows.Count != 0)
                    {
                        DataRow dr = tb.Rows[0];
                        return double.Parse(dr["SoLuongCon"].ToString());
                    }
                    else return -1;
                }
            }
        }

        public static int LayIDHangHoa_HangHoaTonKho(string ID)
        {
            using (SqlConnection con = new SqlConnection(StaticContext.ConnectionString))
            {
                con.Open();
                string cmdText = " SELECT IDHangHoa FROM [GPM_HangHoaTonKho] WHERE [ID] = '" + ID + "'";
                using (SqlCommand command = new SqlCommand(cmdText, con))
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    DataTable tb = new DataTable();
                    tb.Load(reader);
                    if (tb.Rows.Count != 0)
                    {
                        DataRow dr = tb.Rows[0];
                        return Int32.Parse(dr["IDHangHoa"].ToString());
                    }
                    else return -1;
                }
            }
        }
        public static double GiaBan(string IDHangHoa)
        {
            using (SqlConnection con = new SqlConnection(StaticContext.ConnectionString))
            {
                con.Open();
                string cmdText = "SELECT GiaBan FROM [GPM_HangHoa] WHERE [ID] = '" + IDHangHoa + "'";
                using (SqlCommand command = new SqlCommand(cmdText, con))
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    DataTable tb = new DataTable();
                    tb.Load(reader);
                    if (tb.Rows.Count != 0)
                    {
                        DataRow dr = tb.Rows[0];
                        return double.Parse(dr["GiaBan"].ToString());
                    }
                    else return -1;
                }
            }
        }
        public static double GiaBan_KhoChiNhanh(string IDHangHoa, string IDKho)
        {
            using (SqlConnection con = new SqlConnection(StaticContext.ConnectionString))
            {
                con.Open();
                string cmdText = " SELECT GiaBan FROM [GPM_HangHoaTonKho] WHERE [IDHangHoa] = '" + IDHangHoa + "' AND [IDKho] = '" + IDKho + "'";
                using (SqlCommand command = new SqlCommand(cmdText, con))
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    DataTable tb = new DataTable();
                    tb.Load(reader);
                    if (tb.Rows.Count != 0)
                    {
                        DataRow dr = tb.Rows[0];
                        return double.Parse(dr["GiaBan"].ToString());
                    }
                    else return -1;
                }
            }
        }
        public static double GiaBaN2_KhoChiNhanh(string IDHangHoa, string IDKho)
        {
            using (SqlConnection con = new SqlConnection(StaticContext.ConnectionString))
            {
                con.Open();
                string cmdText = " SELECT GiaBaN2 FROM [GPM_HangHoaTonKho] WHERE [IDHangHoa] = '" + IDHangHoa + "' AND [IDKho] = '" + IDKho + "'";
                using (SqlCommand command = new SqlCommand(cmdText, con))
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    DataTable tb = new DataTable();
                    tb.Load(reader);
                    if (tb.Rows.Count != 0)
                    {
                        DataRow dr = tb.Rows[0];
                        return double.Parse(dr["GiaBaN2"].ToString());
                    }
                    else return -1;
                }
            }
        }
        public static double GiaBan2_KhoChiNhanh(string IDHangHoa, string IDKho)
        {
            using (SqlConnection con = new SqlConnection(StaticContext.ConnectionString))
            {
                con.Open();
                string cmdText = " SELECT GiaBan2 FROM [GPM_HangHoaTonKho] WHERE [IDHangHoa] = '" + IDHangHoa + "' AND [IDKho] = '" + IDKho + "'";
                using (SqlCommand command = new SqlCommand(cmdText, con))
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    DataTable tb = new DataTable();
                    tb.Load(reader);
                    if (tb.Rows.Count != 0)
                    {
                        DataRow dr = tb.Rows[0];
                        return double.Parse(dr["GiaBan2"].ToString());
                    }
                    else return -1;
                }
            }
        }
        public static double GiaBan3_KhoChiNhanh(string IDHangHoa, string IDKho)
        {
            using (SqlConnection con = new SqlConnection(StaticContext.ConnectionString))
            {
                con.Open();
                string cmdText = " SELECT GiaBan3 FROM [GPM_HangHoaTonKho] WHERE [IDHangHoa] = '" + IDHangHoa + "' AND [IDKho] = '" + IDKho + "'";
                using (SqlCommand command = new SqlCommand(cmdText, con))
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    DataTable tb = new DataTable();
                    tb.Load(reader);
                    if (tb.Rows.Count != 0)
                    {
                        DataRow dr = tb.Rows[0];
                        return double.Parse(dr["GiaBan3"].ToString());
                    }
                    else return -1;
                }
            }
        }
        public static double GiaBan4_KhoChiNhanh(string IDHangHoa, string IDKho)
        {
            using (SqlConnection con = new SqlConnection(StaticContext.ConnectionString))
            {
                con.Open();
                string cmdText = " SELECT GiaBan4 FROM [GPM_HangHoaTonKho] WHERE [IDHangHoa] = '" + IDHangHoa + "' AND [IDKho] = '" + IDKho + "'";
                using (SqlCommand command = new SqlCommand(cmdText, con))
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    DataTable tb = new DataTable();
                    tb.Load(reader);
                    if (tb.Rows.Count != 0)
                    {
                        DataRow dr = tb.Rows[0];
                        return double.Parse(dr["GiaBan4"].ToString());
                    }
                    else return -1;
                }
            }
        }
        public static double GiaBan5_KhoChiNhanh(string IDHangHoa, string IDKho)
        {
            using (SqlConnection con = new SqlConnection(StaticContext.ConnectionString))
            {
                con.Open();
                string cmdText = " SELECT GiaBan5 FROM [GPM_HangHoaTonKho] WHERE [IDHangHoa] = '" + IDHangHoa + "' AND [IDKho] = '" + IDKho + "'";
                using (SqlCommand command = new SqlCommand(cmdText, con))
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    DataTable tb = new DataTable();
                    tb.Load(reader);
                    if (tb.Rows.Count != 0)
                    {
                        DataRow dr = tb.Rows[0];
                        return double.Parse(dr["GiaBan5"].ToString());
                    }
                    else return -1;
                }
            }
        }
        public static double GiaMua(string IDHangHoa)
        {
            using (SqlConnection con = new SqlConnection(StaticContext.ConnectionString))
            {
                con.Open();
                string cmdText = " SELECT GiaMua FROM [GPM_HangHoa] WHERE [ID] = '" + IDHangHoa + "'";
                using (SqlCommand command = new SqlCommand(cmdText, con))
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    DataTable tb = new DataTable();
                    tb.Load(reader);
                    if (tb.Rows.Count != 0)
                    {
                        DataRow dr = tb.Rows[0];
                        return double.Parse(dr["GiaMua"].ToString());
                    }
                    else return -1;
                }
            }
        }
        
    }
}