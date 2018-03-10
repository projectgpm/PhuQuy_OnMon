using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace BanHang.Data
{
    public class dtChiPhi
    {
        public DataTable DanhSach()
        {
            using (SqlConnection con = new SqlConnection(StaticContext.ConnectionString))
            {
                con.Open();
                string cmdText = "SELECT * FROM [GPM_ChiPhi] ORDER BY ID DESC";
                using (SqlCommand command = new SqlCommand(cmdText, con))
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    DataTable tb = new DataTable();
                    tb.Load(reader);
                    return tb;
                }
            }
        }
        public void CapNhatThongTin(string ID, string TenKhachHang, DateTime NgayChi, double TongChi, double DaChi, double ConLai, string GhiChu, string TrangThai)
        {
            using (SqlConnection myConnection = new SqlConnection(StaticContext.ConnectionString))
            {
                try
                {
                    myConnection.Open();
                    string strSQL = "UPDATE [GPM_ChiPhi] SET [TrangThai] =@TrangThai,[GhiChu] = @GhiChu,[ConLai] =@ConLai,[DaChi] = @DaChi,[TenKhachHang] = @TenKhachHang,[NgayChi] = @NgayChi,[TongChi] = @TongChi, [NgayCapNhat] = getdate() WHERE [ID] = @ID";
                    using (SqlCommand myCommand = new SqlCommand(strSQL, myConnection))
                    {
                        myCommand.Parameters.AddWithValue("@ID", ID);
                        myCommand.Parameters.AddWithValue("@TenKhachHang", TenKhachHang);
                        myCommand.Parameters.AddWithValue("@NgayChi", NgayChi);
                        myCommand.Parameters.AddWithValue("@TongChi", TongChi);
                        myCommand.Parameters.AddWithValue("@DaChi", DaChi);
                        myCommand.Parameters.AddWithValue("@ConLai", ConLai);
                        myCommand.Parameters.AddWithValue("@GhiChu", GhiChu);
                        myCommand.Parameters.AddWithValue("@TrangThai", TrangThai);
                        myCommand.ExecuteNonQuery();
                    }
                }
                catch (Exception e)
                {
                    throw new Exception("Lỗi: Quá trình cập nhật dữ liệu gặp lỗi, hãy tải lại trang");
                }
            }
        }
        public object ThemMoi(DateTime NgayLap, string IDNguoiLap, string NguoiNop, string NoiDung, string DuDau, string SoTien, string DuCuoi, string IDLoaiThuChi, string TenPhieu)
        {
            using (SqlConnection myConnection = new SqlConnection(StaticContext.ConnectionString))
            {
                try
                {
                    myConnection.Open();
                    object ID = null;
                    string cmdText = "INSERT INTO [GPM_ChiPhi] ([NgayLap],[IDNguoiLap],[NgayLuu],[NguoiNop],[NoiDung],[DuDau],[SoTien],[DuCuoi],[IDLoaiThuChi],[TenPhieu]) OUTPUT INSERTED.ID VALUES (@NgayLap,@IDNguoiLap, getdate(),@NguoiNop,@NoiDung,@DuDau,@SoTien,@DuCuoi,@IDLoaiThuChi,@TenPhieu)";
                    using (SqlCommand myCommand = new SqlCommand(cmdText, myConnection))
                    {
                        myCommand.Parameters.AddWithValue("@NgayLap", NgayLap);
                        myCommand.Parameters.AddWithValue("@IDNguoiLap", IDNguoiLap);
                        myCommand.Parameters.AddWithValue("@NguoiNop", NguoiNop);
                        myCommand.Parameters.AddWithValue("@NoiDung", NoiDung);
                        myCommand.Parameters.AddWithValue("@DuDau", DuDau);
                        myCommand.Parameters.AddWithValue("@SoTien", SoTien);
                        myCommand.Parameters.AddWithValue("@DuCuoi", DuCuoi);
                        myCommand.Parameters.AddWithValue("@IDLoaiThuChi", IDLoaiThuChi);
                        myCommand.Parameters.AddWithValue("@TenPhieu", TenPhieu);
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
        public void Xoa(string ID)
        {
            using (SqlConnection myConnection = new SqlConnection(StaticContext.ConnectionString))
            {
                try
                {
                    myConnection.Open();
                    string strSQL = "UPDATE [GPM_ChiPhi] SET [DAXOA] = 1 WHERE [ID] = @ID";
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

        /// <summary>
        /// cập nhật lại số quỹ thu
        /// </summary>
        /// <param name="ID"></param>
        public void CapNhatQuiThu(string SoTien)
        {
            using (SqlConnection myConnection = new SqlConnection(StaticContext.ConnectionString))
            {
                try
                {
                    myConnection.Open();
                    string strSQL = "UPDATE [Setting] SET [SoQuyThuChi] = [SoQuyThuChi] +  @SoTien WHERE [ID] = 1";
                    using (SqlCommand myCommand = new SqlCommand(strSQL, myConnection))
                    {
                        myCommand.Parameters.AddWithValue("@SoTien", SoTien);
                        myCommand.ExecuteNonQuery();
                    }
                }
                catch (Exception e)
                {
                    throw new Exception("Lỗi: Quá trình Xóa dữ liệu gặp lỗi, hãy tải lại trang");
                }
            }
        }
        /// <summary>
        /// cập nhật lại số quỹ chi
        /// </summary>
        /// <param name="ID"></param>
        public void CapNhatQuiChi(string SoTien)
        {
            using (SqlConnection myConnection = new SqlConnection(StaticContext.ConnectionString))
            {
                try
                {
                    myConnection.Open();
                    string strSQL = "UPDATE [Setting] SET [SoQuyThuChi] = [SoQuyThuChi] -  @SoTien WHERE [ID] = 1";
                    using (SqlCommand myCommand = new SqlCommand(strSQL, myConnection))
                    {
                        myCommand.Parameters.AddWithValue("@SoTien", SoTien);
                        myCommand.ExecuteNonQuery();
                    }
                }
                catch (Exception e)
                {
                    throw new Exception("Lỗi: Quá trình Xóa dữ liệu gặp lỗi, hãy tải lại trang");
                }
            }
        }
    }

}