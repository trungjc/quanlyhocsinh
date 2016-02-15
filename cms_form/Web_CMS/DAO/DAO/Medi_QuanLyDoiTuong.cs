
namespace DAO
{
    using ETO;
    using System;
    using System.Data;
    using System.Data.SqlClient;
    public class Medi_QuanLyDoiTuong : BaseDAO
    {
        public DataTable Get_ThongTin_DoiTuong()
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
        public void Update_doituong(int id, string tendoituong)
        {
            using (SqlConnection connection = base.GetConnection())
            {
                SqlCommand command = new SqlCommand("_UddateDoiTuong", connection)
                {
                    CommandType = CommandType.StoredProcedure
                };
                command.Parameters.AddWithValue("@ID", id);
                command.Parameters.AddWithValue("@TenDoiTuong", tendoituong);
                connection.Open();
                if (command.ExecuteNonQuery() <= 0)
                {
                    throw new DataAccessException("Kiểm tra lại thông tin đối tượng");
                }
                command.Dispose();
            }
        }

        //insert đối tượng mới
        public void Insert_doituong(string tendoituong)
        {
            using (SqlConnection connection = base.GetConnection())
            {
                SqlCommand command = new SqlCommand("_Insert_doituong", connection)
                {
                    CommandType = CommandType.StoredProcedure
                };
                command.Parameters.AddWithValue("@TenDoiTuong", tendoituong);
                connection.Open();
                if (command.ExecuteNonQuery() <= 0)
                {
                    throw new DataAccessException("Kiểm tra lại thông tin đối tượng");
                }
                command.Dispose();
            }
        }
        // xóa đối tượng
        public void Delete_doituong(int id)
        {
            using (SqlConnection connection = base.GetConnection())
            {
                SqlCommand command = new SqlCommand("_Delete_doituong", connection)
                {
                    CommandType = CommandType.StoredProcedure
                };
                command.Parameters.AddWithValue("@ID", id);

                connection.Open();
                if (command.ExecuteNonQuery() <= 0)
                {
                    throw new DataAccessException("Kiểm tra lại thông tin đối tượng");
                }
                command.Dispose();
            }
        }
        // lấy danh sách lịch sử áp giá
        public DataTable Get_Lichsu_apgia()
        {
            DataTable datatable = new DataTable();
            using (SqlConnection connection = base.GetConnection())
            {
                SqlCommand command = new SqlCommand("_Get_LichSuApGia", connection)
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
        // lấy giá tiền
        public DataTable Get_GiaTien(int ID)
        {
            DataTable datatable = new DataTable();
            using (SqlConnection connection = base.GetConnection())
            {
                SqlCommand command = new SqlCommand("_Get_GiaTien", connection)
                {
                    CommandType = CommandType.StoredProcedure
                };
                command.Parameters.AddWithValue("@ID", ID);
                connection.Open();
                using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                {
                    adapter.Fill(datatable);
                    command.Dispose();
                }
            }
            return datatable;
        }


        // lấy giá tiền khi tìm kiếm
        public DataTable Get_GiaTien_timKiem(int ID, string ten)
        {
            DataTable datatable = new DataTable();
            using (SqlConnection connection = base.GetConnection())
            {
                SqlCommand command = new SqlCommand("_Get_GiaTien_TimKiem", connection)
                {
                    CommandType = CommandType.StoredProcedure
                };
                command.Parameters.AddWithValue("@ID", ID);

                command.Parameters.AddWithValue("@Ten", ten);
                connection.Open();
                using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                {
                    adapter.Fill(datatable);
                    command.Dispose();
                }
            }
            return datatable;
        }
        public DataTable Get_ID_KY()
        {
            DataTable datatable = new DataTable();
            using (SqlConnection connection = base.GetConnection())
            {
                SqlCommand command = new SqlCommand("_Get_ID_New", connection)
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

        // Save đơn giá
        public DataTable Save_dongia(int idKyApDung, int idLoaiXetNghiem, int money)
        {
            DataTable datatable = new DataTable();
            using (SqlConnection connection = base.GetConnection())
            {
                SqlCommand command = new SqlCommand("insertApGia", connection)
                {
                    CommandType = CommandType.StoredProcedure
                };
                command.Parameters.AddWithValue("@ID_KyApDung", idKyApDung);
                command.Parameters.AddWithValue("@ID_LoaiXetNghiem", idLoaiXetNghiem);
                command.Parameters.AddWithValue("@Money", money);
                connection.Open();
                using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                {
                    adapter.Fill(datatable);
                    command.Dispose();
                }
            }
            return datatable;
        }
        public DataTable getKeysave_dongia(DateTime thoiGian, int ndID, string lydo, int idDoituong)
        {
            DataTable datatable = new DataTable();
            using (SqlConnection connection = base.GetConnection())
            {
                SqlCommand command = new SqlCommand("InsertKyBC", connection)
                {
                    CommandType = CommandType.StoredProcedure
                };
                command.Parameters.AddWithValue("@Thoi_Gian", thoiGian);
                command.Parameters.AddWithValue("@ND_ID", ndID);
                command.Parameters.AddWithValue("@Ly_Do", lydo);
                command.Parameters.AddWithValue("@ID_DoiTuong", idDoituong);
                connection.Open();
                using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                {
                    adapter.Fill(datatable);
                    command.Dispose();
                }
            }
            return datatable;
        }

        // lấy tên đối tượng
        public DataTable getTenDoiTuong(int iddoituong)
        {
            DataTable datatable = new DataTable();
            using (SqlConnection connection = base.GetConnection())
            {
                SqlCommand command = new SqlCommand("GetTenDoituong", connection)
                {
                    CommandType = CommandType.StoredProcedure
                };
                command.Parameters.AddWithValue("@ID", iddoituong);

                connection.Open();
                using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                {
                    adapter.Fill(datatable);
                    command.Dispose();
                }
            }
            return datatable;
        }

        // check dối tượng
        public DataTable checkDoiTuong(int ID)
        {
            DataTable datatable = new DataTable();
            using (SqlConnection connection = base.GetConnection())
            {
                SqlCommand command = new SqlCommand("Get_Doituong_ID", connection)
                {
                    CommandType = CommandType.StoredProcedure
                };
                command.Parameters.AddWithValue("@ID", ID);
                connection.Open();
                using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                {
                    adapter.Fill(datatable);
                    command.Dispose();
                }
            }
            return datatable;
        }

        // lấy danh sách phiếu
        public DataTable getDanhMucPhieu(int ID)
        {
            DataTable datatable = new DataTable();
            using (SqlConnection connection = base.GetConnection())
            {
                SqlCommand command = new SqlCommand("Get_DanhMucPhieu", connection)
                {
                    CommandType = CommandType.StoredProcedure
                };
                command.Parameters.AddWithValue("@ID", ID);
                connection.Open();
                using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                {
                    adapter.Fill(datatable);
                    command.Dispose();
                }
            }
            return datatable;
        }
        // lấy id nguoif dung
        public DataTable GetID(string ten)
        {
            DataTable datatable = new DataTable();
            using (SqlConnection connection = base.GetConnection())
            {
                SqlCommand command = new SqlCommand("GetIDAdminGetAll", connection)
                {
                    CommandType = CommandType.StoredProcedure
                };
                command.Parameters.AddWithValue("@Admin_Username", ten);
                connection.Open();
                using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                {
                    adapter.Fill(datatable);
                    command.Dispose();
                }
            }
            return datatable;
        }

        // lấy danh sách đối tượng
        public DataTable GetDanhSachDoiTuong()
        {
            DataTable datatable = new DataTable();
            using (SqlConnection connection = base.GetConnection())
            {
                SqlCommand command = new SqlCommand("GetDanhSachDoiTuong", connection)
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
        //Chức năng tìm kiếm mã phiếu cơ bản
        public DataTable TimKiemCoBan(string dauvao, int trangthai, int idDoiTuong)
        {
            DataTable datatable = new DataTable();
            using (SqlConnection connection = base.GetConnection())
            {
                SqlCommand command = new SqlCommand("TimKiemCoBan", connection)
                {
                    CommandType = CommandType.StoredProcedure
                };
                command.Parameters.AddWithValue("@DauVao", dauvao);
                command.Parameters.AddWithValue("@State", trangthai);
                command.Parameters.AddWithValue("@ID_DoiTuong", idDoiTuong);
                connection.Open();
                using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                {
                    adapter.Fill(datatable);
                    command.Dispose();
                }
            }
            return datatable;
        }
        // tìm kiếm nâng cao
        public DataTable TimKiemNangCao(string maphieu, string hoten, string mabacode, string sothebh, int iddt, string diachi, int state, DateTime ngaybatdau, DateTime ngayketthuc)
        {
            DataTable datatable = new DataTable();
            using (SqlConnection connection = base.GetConnection())
            {
                SqlCommand command = new SqlCommand("timKiemNgangCao", connection)
                {
                    CommandType = CommandType.StoredProcedure
                };
                command.Parameters.AddWithValue("@MaPhieu", maphieu);
                command.Parameters.AddWithValue("@HoTen", hoten);
                command.Parameters.AddWithValue("@MaBarCode", mabacode);
                command.Parameters.AddWithValue("@SoTheBaoHiem", sothebh);
                command.Parameters.AddWithValue("@ID_DoiTuong", iddt);
                command.Parameters.AddWithValue("@DiaChi", diachi);
                command.Parameters.AddWithValue("@State", state);
                command.Parameters.AddWithValue("@CreateDate", ngaybatdau);
                command.Parameters.AddWithValue("@LastUpdate", ngayketthuc);
                connection.Open();
                using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                {
                    adapter.Fill(datatable);
                    command.Dispose();
                }
            }
            return datatable;
        }

        // lấy số phiếu chưa xét nghiệm
        public DataTable GetPhieuChuaXetNghiem()
        {
            DataTable datatable = new DataTable();
            using (SqlConnection connection = base.GetConnection())
            {
                SqlCommand command = new SqlCommand("GetTongSoPhieuChuaXetNghiem", connection)
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
        // lấy tên đối tượng
        public DataTable GetTenDoiTuong(string tenDoiTuong)
        {
            DataTable datatable = new DataTable();
            using (SqlConnection connection = base.GetConnection())
            {
                SqlCommand command = new SqlCommand("Get_Id_DoiTuong", connection)
                {
                    CommandType = CommandType.StoredProcedure
                };
                command.Parameters.AddWithValue("@TenDoiTuong", tenDoiTuong);
                connection.Open();
                using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                {
                    adapter.Fill(datatable);
                    command.Dispose();
                }
            }
            return datatable;
        }
    }
}
