using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace BanHang.Data
{
    public class dtHuyHoaDon
    {

        public DataTable DanhSachHangHoa_IDHoaDon(string IDHoaDon)
        {
            using (SqlConnection con = new SqlConnection(StaticContext.ConnectionString))
            {
                con.Open();
                string cmdText = "SELECT * FROM GPM_ChiTietHoaDon WHERE GPM_ChiTietHoaDon.IDHoaDon = '" + IDHoaDon + "'";
                using (SqlCommand command = new SqlCommand(cmdText, con))
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    DataTable tb = new DataTable();
                    tb.Load(reader);
                    return tb;
                }
            }
        }
        /// <summary>
        /// danh sách hóa đơn trong 7 ngày
        /// </summary>
        /// <param name="NgayHomNay"></param>
        /// <returns></returns>
        public DataTable DanhSachHoaDon(DateTime NgayHomNay)
        {
            using (SqlConnection con = new SqlConnection(StaticContext.ConnectionString))
            {
                con.Open();
                string cmdText = "SELECT *,([CongNoMoiKhachHang] - [CongNoCuKhachHang]) as CongNoKhachHang FROM [GPM_HoaDon] WHERE [HuyHoaDon] = 0 and [NgayBan] > @NgayHomNay";
                using (SqlCommand command = new SqlCommand(cmdText, con))
                {
                    command.Parameters.AddWithValue("@NgayHomNay", NgayHomNay.AddDays(-1));
                    SqlDataReader reader = command.ExecuteReader();
                    DataTable tb = new DataTable();
                    tb.Load(reader);
                    return tb;
                }
            }
        }
        /// <summary>
        /// danh sách hóa đơn hủy
        /// </summary>
        /// <returns></returns>
        public DataTable DanhSachHoaDon_Huy()
        {
            using (SqlConnection con = new SqlConnection(StaticContext.ConnectionString))
            {
                con.Open();
                string cmdText = "SELECT *,([CongNoMoiKhachHang] - [CongNoCuKhachHang]) as CongNoKhachHang FROM [GPM_HoaDon] WHERE [HuyHoaDon] = 1";
                using (SqlCommand command = new SqlCommand(cmdText, con))
                {
                    SqlDataReader reader = command.ExecuteReader();
                    DataTable tb = new DataTable();
                    tb.Load(reader);
                    return tb;
                }
            }
        }
        /// <summary>
        /// công nợ khách hàng
        /// </summary>
        /// <param name="IDHoaDon"></param>
        /// <returns></returns>
        public static double CongNo_IDHoaDon(string IDHoaDon)
        {
            using (SqlConnection con = new SqlConnection(StaticContext.ConnectionString))
            {
                con.Open();
                string cmdText = "SELECT ([CongNoMoiKhachHang] - [CongNoCuKhachHang]) as CongNoKhachHang FROM [GPM_HoaDon] WHERE [ID] = '" + IDHoaDon + "'";
                using (SqlCommand command = new SqlCommand(cmdText, con))
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    DataTable tb = new DataTable();
                    tb.Load(reader);
                    if (tb.Rows.Count > 0)
                    {
                        DataRow dr = tb.Rows[0];
                        return double.Parse(dr["CongNoKhachHang"].ToString());
                    }
                    else return 0;
                }
            }
        }
        /// <summary>
        /// ID khách hàng
        /// </summary>
        /// <param name="IDHoaDon"></param>
        /// <returns></returns>
        public static int IDKhachHang_IDHoaDon(string IDHoaDon)
        {
            using (SqlConnection con = new SqlConnection(StaticContext.ConnectionString))
            {
                con.Open();
                string cmdText = "SELECT IDKhachHang FROM [GPM_HoaDon] WHERE [ID] = '" + IDHoaDon + "'";
                using (SqlCommand command = new SqlCommand(cmdText, con))
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    DataTable tb = new DataTable();
                    tb.Load(reader);
                    if (tb.Rows.Count > 0)
                    {
                        DataRow dr = tb.Rows[0];
                        return Int32.Parse(dr["IDKhachHang"].ToString());
                    }
                    else return 0;
                }
            }
        }

        /// <summary>
        /// Cập nhật hóa đơn hủy
        /// </summary>
        /// <param name="IDHoaDon"></param>
        public void CapNhatHoaDonHuy(string IDHoaDon)
        {
            using (SqlConnection myConnection = new SqlConnection(StaticContext.ConnectionString))
            {
                try
                {
                    myConnection.Open();
                    string strSQL = "UPDATE [GPM_HoaDon] SET [HuyHoaDon] = 1 WHERE [ID] = @IDHoaDon";
                    using (SqlCommand myCommand = new SqlCommand(strSQL, myConnection))
                    {
                        myCommand.Parameters.AddWithValue("@IDHoaDon", IDHoaDon);
                        myCommand.ExecuteNonQuery();
                    }
                }
                catch (Exception e)
                {
                    throw new Exception("Lỗi: Quá trình duyệt dữ liệu gặp lỗi, hãy tải lại trang");
                }
            }
        }
    }
}