using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace BanHang.Data
{
    public class dtBangGia
    {
        public void CapNhatGiaChiTiet(string ID, string GiaMoi)
        {
            using (SqlConnection myConnection = new SqlConnection(StaticContext.ConnectionString))
            {
                try
                {
                    myConnection.Open();
                    string cmdText = "UPDATE [GPM_ChiTietBangGia] SET [GiaMoi] = @GiaMoi WHERE [ID] = @ID";
                    using (SqlCommand myCommand = new SqlCommand(cmdText, myConnection))
                    {
                        myCommand.Parameters.AddWithValue("@ID", ID);
                        myCommand.Parameters.AddWithValue("@GiaMoi", GiaMoi);

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
        public DataTable DanhSachChiTiet(string IDBangGia)
        {
            using (SqlConnection con = new SqlConnection(StaticContext.ConnectionString))
            {
                con.Open();
                string cmdText = "SELECT [GPM_ChiTietBangGia].ID, [GPM_ChiTietBangGia].GiaCu,[GPM_ChiTietBangGia].GiaMoi,[C_HangHoa].MaHangHoa,[CF_HangHoa].TenHangHoa,[CF_DonViTinh].TenDonViTinh FROM [CF_ChiTietBangGia],[CF_HangHoa],[CF_DonViTinh] WHERE CF_ChiTietBangGia.IDBangGia = '" + IDBangGia + "' AND CF_ChiTietBangGia.DaXoa = 0 AND [CF_ChiTietBangGia].IDHangHoa = [CF_HangHoa].ID AND [CF_DonViTinh].ID = [CF_HangHoa].IDDonViTinh";
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
        /// thêm hàng hóa mới -> thêm vào bảng giá
        /// </summary>
        /// <param name="IDHangHoa"></param>
        /// <param name="IDBangGia"></param>
        /// <param name="GiaHeThong"></param>
        public void ThemIDHangHoaVaoChiTietGia(object IDHangHoa, object IDBangGia, string GiaHeThong)
        {
            using (SqlConnection myConnection = new SqlConnection(StaticContext.ConnectionString))
            {
                try
                {
                    myConnection.Open();
                    string cmdText = "INSERT INTO [GPM_ChiTietBangGia] ([IDBangGia],[IDHangHoa],[GiaHeThong],[GiaBanLe],[GiaBanSi]) VALUES (@IDBangGia,@IDHangHoa,@GiaHeThong,@GiaHeThong,@GiaHeThong)";
                    using (SqlCommand myCommand = new SqlCommand(cmdText, myConnection))
                    {
                        myCommand.Parameters.AddWithValue("@IDBangGia", IDBangGia);
                        myCommand.Parameters.AddWithValue("@IDHangHoa", IDHangHoa);
                        myCommand.Parameters.AddWithValue("@GiaHeThong", GiaHeThong);

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
        /// cập nhật bảng giá khi thay đổi giá ở hàng hóa
        /// </summary>
        /// <param name="IDHangHoa"></param>
        /// <param name="GiaHeThong"></param>
        public void CapNhatGiaCuTrongChiTietBangGia(string IDHangHoa, string GiaHeThong)
        {
            using (SqlConnection myConnection = new SqlConnection(StaticContext.ConnectionString))
            {
                try
                {
                    myConnection.Open();
                    string cmdText = "UPDATE [GPM_ChiTietBangGia] SET [GiaHeThong] = @GiaHeThong WHERE [IDHangHoa] = @IDHangHoa AND DaXoa = 0";
                    using (SqlCommand myCommand = new SqlCommand(cmdText, myConnection))
                    {
                        myCommand.Parameters.AddWithValue("@IDHangHoa", IDHangHoa);
                        myCommand.Parameters.AddWithValue("@GiaHeThong", GiaHeThong);

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
        public DataTable DanhSach()
        {
            using (SqlConnection con = new SqlConnection(StaticContext.ConnectionString))
            {
                con.Open();
                string cmdText = " SELECT * FROM [GPM_BangGia] WHERE DaXoa = 0";
                using (SqlCommand command = new SqlCommand(cmdText, con))
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    DataTable tb = new DataTable();
                    tb.Load(reader);
                    return tb;
                }
            }
        }
        public object ThemMoi(string TenBangGia)
        {
            using (SqlConnection myConnection = new SqlConnection(StaticContext.ConnectionString))
            {
                try
                {
                    myConnection.Open();
                    object ID = null;
                    string cmdText = "INSERT INTO [GPM_BangGia] ([TenBangGia], [NgayCapNhat]) OUTPUT INSERTED.ID VALUES (@TenBangGia, getdate())";
                    using (SqlCommand myCommand = new SqlCommand(cmdText, myConnection))
                    {
                        myCommand.Parameters.AddWithValue("@TenBangGia", TenBangGia);
                        ID = myCommand.ExecuteScalar();
                    }
                    myConnection.Close();
                    return ID;
                }
                catch
                {
                    throw new Exception("Lỗi: Quá trình thêm dữ liệu gặp lỗi");
                }
            }
        }
        public void XoaBangGia(string ID)
        {
            using (SqlConnection myConnection = new SqlConnection(StaticContext.ConnectionString))
            {
                try
                {
                    myConnection.Open();
                    string strSQL = "UPDATE [GPM_BangGia] SET [DAXOA] = 1 WHERE [ID] = @ID";
                    using (SqlCommand myCommand = new SqlCommand(strSQL, myConnection))
                    {
                        myCommand.Parameters.AddWithValue("@ID", ID);
                        myCommand.ExecuteNonQuery();
                    }
                    strSQL = "UPDATE [GPM_ChiTietBangGia] SET [DAXOA] = 1 WHERE [IDBangGia] = @ID";
                    using (SqlCommand myCommand = new SqlCommand(strSQL, myConnection))
                    {
                        myCommand.Parameters.AddWithValue("@ID", ID);
                        myCommand.ExecuteNonQuery();
                    }
                }
                catch (Exception e)
                {
                    throw new Exception("Lỗi: Quá trình Xóa dữ liệu gặp lỗi, hãy tải lại trang");
                }
            }
        }
        public void SuaBangGia(string ID, string TenBangGia)
        {
            using (SqlConnection myConnection = new SqlConnection(StaticContext.ConnectionString))
            {
                try
                {
                    myConnection.Open();
                    string strSQL = "UPDATE [GPM_BangGia] SET [TenBangGia] = @TenBangGia, [NgayCapNhat] = getdate() WHERE [ID] = @ID";
                    using (SqlCommand myCommand = new SqlCommand(strSQL, myConnection))
                    {
                        myCommand.Parameters.AddWithValue("@ID", ID);
                        myCommand.Parameters.AddWithValue("@TenBangGia", TenBangGia);
                        myCommand.ExecuteNonQuery();
                    }
                }
                catch (Exception e)
                {
                    throw new Exception("Lỗi: Quá trình cập nhật dữ liệu gặp lỗi, hãy tải lại trang");
                }
            }
        }
    }
}