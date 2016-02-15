namespace DAO
{
    using ETO;
    using System;
    using System.Data;
    using System.Data.SqlClient;
    public class Medi_PhieuXetNghiemDAO : BaseDAO
    {
        public void CreatePhieuXetNghiem(Medi_PhieuXetNghiem pxn)
        {
            using (SqlConnection connection = base.GetConnection())
            {
                SqlCommand command = new SqlCommand("_PhieuXetNghiemUpdate", connection)
                {
                    CommandType = CommandType.StoredProcedure
                };
                command.Parameters.AddWithValue("@MaPhieu", pxn.MaPhieu);
                command.Parameters.AddWithValue("@MaPin", pxn.MaPin);
                command.Parameters.AddWithValue("@HoTen", pxn.HoTen);
                command.Parameters.AddWithValue("@Tuoi", pxn.Tuoi);
                command.Parameters.AddWithValue("@GioiTinh", pxn.GioiTinh);
                command.Parameters.AddWithValue("@DiaChi", pxn.DiaChi);
                command.Parameters.AddWithValue("@ThoiGianToiKham", pxn.ThoiGianToiKham);
                command.Parameters.AddWithValue("@SoDienThoai", pxn.SoDienThoai);
                command.Parameters.AddWithValue("@State", pxn.State);
                command.Parameters.AddWithValue("@CreateDate", pxn.CreateDate);
                command.Parameters.AddWithValue("@Email", pxn.Email);
                command.Parameters.AddWithValue("@ID_DoiTuong", pxn.Id_DoiTuong);
                command.Parameters.AddWithValue("@Language", pxn.Language);
                connection.Open();
                if (command.ExecuteNonQuery() <= 0)
                {
                    throw new DataAccessException("Kiểm tra lại thông tin khách hàng");
                }
                command.Dispose();
            }
        }
        public void Update_PhieuXN(string maPhieu, string filePath, int state, DateTime lastUpdate, string lastUpdateBy)
        {
            using (SqlConnection connection = base.GetConnection())
            {
                SqlCommand command = new SqlCommand("_UddatePhieuXN", connection)
                {
                    CommandType = CommandType.StoredProcedure
                };
                command.Parameters.AddWithValue("@MaPhieu", maPhieu);
                command.Parameters.AddWithValue("@Filepath", filePath);
                command.Parameters.AddWithValue("@State", state);
                command.Parameters.AddWithValue("@LastUpdate", lastUpdate);
                command.Parameters.AddWithValue("@LastUpdateBy", lastUpdateBy);
                connection.Open();
                if (command.ExecuteNonQuery() <= 0)
                {
                    throw new DataAccessException("Kiểm tra lại thông tin khách hàng");
                }
                command.Dispose();
            }
        }
        #region Get value DAO
        public DataTable Get_PhieuXetNghiem(string language)
        {
            DataTable datatable = new DataTable();
            using (SqlConnection connection = base.GetConnection())
            {
                SqlCommand command = new SqlCommand("_Get_PhieuXetNghiem", connection)
                {
                    CommandType = CommandType.StoredProcedure
                };
                command.Parameters.AddWithValue("@Language", language);
                connection.Open();
                using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                {
                    adapter.Fill(datatable);
                    command.Dispose();
                }
            }
            return datatable;
        }
        public DataTable Get_ThongTinKhachHang(string maPhieu)
        {
            DataTable datatable = new DataTable();
            using (SqlConnection connection = base.GetConnection())
            {
                SqlCommand command = new SqlCommand("_Get_ThongTinKhachHang", connection)
                {
                    CommandType = CommandType.StoredProcedure
                };
                command.Parameters.AddWithValue("@MaPhieu", maPhieu);
                connection.Open();
                using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                {
                    adapter.Fill(datatable);
                    command.Dispose();
                }
            }
            return datatable;
        }
        public DataTable Get_DoiTuong()
        {
            DataTable datatable = new DataTable();
            using (SqlConnection connection = base.GetConnection())
            {
                SqlCommand command = new SqlCommand("_Get_DoiTuong", connection)
                {
                    CommandType = CommandType.StoredProcedure
                };
                connection.Open();
                using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                {
                    adapter.Fill(datatable);
                    command.Dispose();
                }
            }
            return datatable;
        }
        // lấy id kỳ áp giá mới nhất của đối tượng
        public DataTable Get_KyApGia( int iddoituong)
        {
            DataTable datatable = new DataTable();
            using (SqlConnection connection = base.GetConnection())
            {
                SqlCommand command = new SqlCommand("Get_IDKy", connection)
                {
                    CommandType = CommandType.StoredProcedure
                };
                command.Parameters.AddWithValue("@ID_DoiTuong", iddoituong);
                connection.Open();
                using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                {
                    adapter.Fill(datatable);
                    command.Dispose();
                }
            }
            return datatable;
        }
        public DataTable Get_Data_LoadTree_DoiTuong(int kyapdung)
        {
            DataTable datatable = new DataTable();
            using (SqlConnection connection = base.GetConnection())
            {
                SqlCommand command = new SqlCommand("_Get_Data_LoadTree_DoiTuong", connection)
                {
                    CommandType = CommandType.StoredProcedure
                };
                command.Parameters.AddWithValue("@ID_KyApDung", kyapdung);
                connection.Open();
                using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                {
                    adapter.Fill(datatable);
                    command.Dispose();
                }
            }
            return datatable;
        }
        public DataTable Get_Money_Cha(int idkyapdung, int id_Cha)
        {
            DataTable datatable = new DataTable();
            using (SqlConnection connection = base.GetConnection())
            {
                SqlCommand command = new SqlCommand("_Get_Money_Cha", connection)
                {
                    CommandType = CommandType.StoredProcedure
                };
                command.Parameters.AddWithValue("@ID_KyApDung", idkyapdung);
                command.Parameters.AddWithValue("@ID_Cha", id_Cha);
                connection.Open();
                using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                {
                    adapter.Fill(datatable);
                    command.Dispose();
                }
            }
            return datatable;
        }
        public DataTable Get_PXN_Money(int maDoiTuong, int id_LoaiXN)
        {
            DataTable datatable = new DataTable();
            using (SqlConnection connection = base.GetConnection())
            {
                SqlCommand command = new SqlCommand("_Get_PXN_Money", connection)
                {
                    CommandType = CommandType.StoredProcedure
                };
                command.Parameters.AddWithValue("@ID_DoiTuong", maDoiTuong);
                command.Parameters.AddWithValue("@ID_LoaiXN", id_LoaiXN);
                connection.Open();
                using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                {
                    adapter.Fill(datatable);
                    command.Dispose();
                }
            }
            return datatable;
        }
        //lay ky ap gia moi nhat

        public DataTable Get_KyApGiaMoiNhat(int idkyapdung)
        {
            DataTable datatable = new DataTable();
            using (SqlConnection connection = base.GetConnection())
            {
                SqlCommand command = new SqlCommand("_Get_KyApGiaMoiNhat", connection)
                {
                    CommandType = CommandType.StoredProcedure
                };
                command.Parameters.AddWithValue("@ID_DoiTuong", idkyapdung);
                connection.Open();
                using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                {
                    adapter.Fill(datatable);
                    command.Dispose();
                }
            }
            return datatable;
        }
        // lấy trạng thái theo mã phiếu
        public DataTable Get_TrangThai(string maphieu)
        {
            DataTable datatable = new DataTable();
            using (SqlConnection connection = base.GetConnection())
            {
                SqlCommand command = new SqlCommand("Get_TrangThai", connection)
                {
                    CommandType = CommandType.StoredProcedure
                };
                command.Parameters.AddWithValue("@MaPhieu", maphieu);
               
                connection.Open();
                using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                {
                    adapter.Fill(datatable);
                    command.Dispose();
                }
            }
            return datatable;
        }

        // lấy danh sách phiếu theo trạng thái chưa xác nhận
        public DataTable Get_DanhSachPhieuChuaXacNhan()
        {
            DataTable datatable = new DataTable();
            using (SqlConnection connection = base.GetConnection())
            {
                SqlCommand command = new SqlCommand("GetDanhSachPhieu_ChuaXacNhan", connection)
                {
                    CommandType = CommandType.StoredProcedure
                };
                connection.Open();
                using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                {
                    adapter.Fill(datatable);
                    command.Dispose();
                }
            }
            return datatable;
        }
        // lấy danh sách phiếu theo trạng thái chưa xác nhận
        public DataTable Get_PXN_Date_Now(string dateNow, string dateNext)
        {
            DataTable datatable = new DataTable();
            using (SqlConnection connection = base.GetConnection())
            {
                SqlCommand command = new SqlCommand("_PXN_Date_Now", connection)
                {
                    CommandType = CommandType.StoredProcedure
                };
                command.Parameters.AddWithValue("@DateNow", dateNow);
                command.Parameters.AddWithValue("@DateNext", dateNext);
                connection.Open();
                using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                {
                    adapter.Fill(datatable);
                    command.Dispose();
                }
            }
            return datatable;
        }
        #endregion
        #region Phần tra cứu 
        public DataTable GetKQ_XetNghiem(string maphieu, string mapin )
        {
            DataTable datatable = new DataTable();
            using (SqlConnection connection = base.GetConnection())
            {
                SqlCommand command = new SqlCommand("_GetKQ_XetNghiem", connection)
                {
                    CommandType = CommandType.StoredProcedure
                };
                command.Parameters.AddWithValue("@MaPhieu", maphieu);
                command.Parameters.AddWithValue("@MaPin", mapin);
                connection.Open();
                using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                {
                    adapter.Fill(datatable);
                    command.Dispose();
                }
            }
            return datatable;
        }
        #endregion

        #region get date service
        public DataTable Get_Data_Service()
        {
            DataTable datatable = new DataTable();
            using (SqlConnection connection = base.GetConnection())
            {
                SqlCommand command = new SqlCommand("_Get_Data_Service", connection)
                {
                    CommandType = CommandType.StoredProcedure
                };
                connection.Open();
                using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                {
                    adapter.Fill(datatable);          
                    command.Dispose();
                }
            } 
            return datatable;
        }
        #endregion
    }
}
