
namespace DAO
{
    using ETO;
    using System;
    using System.Data;
    using System.Data.SqlClient;
    using System.Globalization;
    public class Medi_LoaiXNDAO : BaseDAO
    {
        public void CreateLoaiXetNghiem(Medi_LoaiXN lxn)
        {
            using (SqlConnection connection = base.GetConnection())
            {
                SqlCommand command = new SqlCommand("_LoaiXetNghiemUpdate", connection)
                {
                    CommandType = CommandType.StoredProcedure
                };
                command.Parameters.AddWithValue("@TenLoaiXN", lxn.TenLoaiXN);
                command.Parameters.AddWithValue("@ID_Cha", lxn.Id_Cha);
                command.Parameters.AddWithValue("@Index", lxn.Index);
                connection.Open();
                if (command.ExecuteNonQuery() <= 0)
                {
                    throw new DataAccessException("Kiểm tra lại thông tin khách hàng");
                }
                command.Dispose();
            }
        }
        #region get value DAO
        public DataTable Get_Data_LoadTree()
        {
            DataTable datatable = new DataTable();
            using (SqlConnection connection = base.GetConnection())
            {
                SqlCommand command = new SqlCommand("_Get_Data_LoadTree", connection)
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
        //lấy bản ghi loại xét nghiệm theo mã loại xét nghiệm
        public DataTable Get_Item_LXN(int idLXN)
        {
            DataTable datatable = new DataTable();
            using (SqlConnection connection = base.GetConnection())
            {
                SqlCommand command = new SqlCommand("_Get_Item_LXN", connection)
                {
                    CommandType = CommandType.StoredProcedure
                };

                command.Parameters.AddWithValue("@ID", idLXN);
                connection.Open();
                using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                {
                    adapter.Fill(datatable);
                    command.Dispose();
                }
            }
            return datatable;
        }
        //lấy bản ghi đứng trước bản ghi có index hiện tại
        public DataTable Get_Before_Data(float index, int id_cha)
        {
            DataTable datatable = new DataTable();
            using (SqlConnection connection = base.GetConnection())
            {
                SqlCommand command = new SqlCommand("_Get_Before_Data", connection)
                {
                    CommandType = CommandType.StoredProcedure
                };

                command.Parameters.AddWithValue("@Index", index);
                command.Parameters.AddWithValue("@Id_Cha", id_cha);
                connection.Open();
                using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                {
                    adapter.Fill(datatable);
                    command.Dispose();
                }
            }
            return datatable;
        }
        //lấy bản ghi đứng sau bản ghi có index hiện tại
        public DataTable Get_Affter_Data(float index, int id_cha)
        {
            DataTable datatable = new DataTable();
            using (SqlConnection connection = base.GetConnection())
            {
                SqlCommand command = new SqlCommand("_Get_Affter_Data", connection)
                {
                    CommandType = CommandType.StoredProcedure
                };

                command.Parameters.AddWithValue("@Index", index);
                command.Parameters.AddWithValue("@Id_Cha", id_cha);
                connection.Open();
                using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                {
                    adapter.Fill(datatable);
                    command.Dispose();
                }
            }
            return datatable;
        }
        // lấy bản ghi cha của bản ghi hiện tại
        public DataTable Get_Parent_Data(int id_cha)
        {
            DataTable datatable = new DataTable();
            using (SqlConnection connection = base.GetConnection())
            {
                SqlCommand command = new SqlCommand("_Get_Parent_Data", connection)
                {
                    CommandType = CommandType.StoredProcedure
                };
                command.Parameters.AddWithValue("@ID_Cha", id_cha);
                connection.Open();
                using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                {
                    adapter.Fill(datatable);
                    command.Dispose();
                }
            }
            return datatable;
        }
        // lấy bản ghi cuối cùng của phần node con
        public DataTable Get_Affter_Data_NodeChild(int id_cha)
        {
            DataTable datatable = new DataTable();
            using (SqlConnection connection = base.GetConnection())
            {
                SqlCommand command = new SqlCommand("_Get_Affter_Data_NodeChild", connection)
                {
                    CommandType = CommandType.StoredProcedure
                };
                command.Parameters.AddWithValue("@ID", id_cha);
                connection.Open();
                using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                {
                    adapter.Fill(datatable);
                    command.Dispose();
                }
            }
            return datatable;
        }
        //update loại xét nghiệm
        public void Update_LXN(int id, string tenLXN)
        {
            using (SqlConnection connection = base.GetConnection())
            {
                SqlCommand command = new SqlCommand("_UpDate_LXN", connection)
                {
                    CommandType = CommandType.StoredProcedure
                };
                command.Parameters.AddWithValue("@TenLoaiXN", tenLXN);
                command.Parameters.AddWithValue("@ID", id);
                connection.Open();
                if (command.ExecuteNonQuery() <= 0)
                {
                    throw new DataAccessException("Chỉnh sủa không thành công");
                }
                command.Dispose();
            }
        }
        //update index loại xét nghiệm
        public void Update_Index_LXN(int id, float index)
        {
            using (SqlConnection connection = base.GetConnection())
            {
                SqlCommand command = new SqlCommand("_UpDate_Index_LXN", connection)
                {
                    CommandType = CommandType.StoredProcedure
                };
                command.Parameters.AddWithValue("@ID", id);
                command.Parameters.AddWithValue("@Index", index);
                connection.Open();
                if (command.ExecuteNonQuery() <= 0)
                {
                    throw new DataAccessException("Chỉnh sửa không thành công");
                }
                command.Dispose();
            }
        }
        //delete loại xét nghiệm
        public void Delete_LXN(int id)
        {
            using (SqlConnection connection = base.GetConnection())
            {
                SqlCommand command = new SqlCommand("_Delete_LXN", connection)
                {
                    CommandType = CommandType.StoredProcedure
                };
                command.Parameters.AddWithValue("@ID", id);
                connection.Open();
                if (command.ExecuteNonQuery() <= 0)
                {
                    throw new DataAccessException("Kh\x00f4ng thể x\x00f3a contact");
                }
                command.Dispose();

            }
        }
        //get những bản ghi có mã id truyền vào trong bảng giá loại xét nghiệm
        public DataTable Get_Data_LXN_TheoID(int id_LXN)
        {
            DataTable datatable = new DataTable();
            using (SqlConnection connection = base.GetConnection())
            {
                SqlCommand command = new SqlCommand("_Get_Data_LXN_TheoID", connection)
                {
                    CommandType = CommandType.StoredProcedure
                };
                command.Parameters.AddWithValue("@Id_LXN", id_LXN);
                connection.Open();
                using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                {
                    adapter.Fill(datatable);
                    command.Dispose();
                }
            }
            return datatable;
        }
        //delete bản ghi trong bảng giá loại xét nghiệm
        public void Delete_GiaLXN(int id)
        {
            using (SqlConnection connection = base.GetConnection())
            {
                SqlCommand command = new SqlCommand("_Delete_GiaLXN", connection)
                {
                    CommandType = CommandType.StoredProcedure
                };
                command.Parameters.AddWithValue("@ID", id);
                connection.Open();
                if (command.ExecuteNonQuery() <= 0)
                {
                    throw new DataAccessException("Kh\x00f4ng thể x\x00f3a contact");
                }
                command.Dispose();

            }
        }
        //Get danh sách loại xét nghiệm theo tìm kiếm
        public DataTable Get_List_LXN(string Key_value)
        {
            DataTable datatable = new DataTable();
            using (SqlConnection connection = base.GetConnection())
            {
                SqlCommand command = new SqlCommand("_Get_List_LXN", connection)
                {
                    CommandType = CommandType.StoredProcedure
                };
                command.Parameters.AddWithValue("@Key_value", Key_value);
                connection.Open();
                using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                {
                    adapter.Fill(datatable);
                    command.Dispose();
                }
            }
            return datatable;
        }
        //update lại các node khi kéo thả
        public void Update_Node_THop(int id, string tenloaiXN, int id_cha, float index)
        {
            using (SqlConnection connection = base.GetConnection())
            {
                SqlCommand command = new SqlCommand("BC_ChiTieu_THop_Update_Order", connection)
                {
                    CommandType = CommandType.StoredProcedure
                };
                command.Parameters.Add("@ID", SqlDbType.Int).Value = id;
                command.Parameters.Add("@TenLoaiXN", SqlDbType.NVarChar).Value = tenloaiXN;
                command.Parameters.Add("@ID_Cha", SqlDbType.Int).Value = id_cha;
                command.Parameters.Add("@Index", SqlDbType.Float).Value = index;
                connection.Open();
                if (command.ExecuteNonQuery() <= 0)
                {
                    throw new DataAccessException("Chỉnh sủa không thành công");
                }
                command.Dispose();
            }
        }
        //Get loại xét nghiệm vừa thêm mới
        public DataTable Get_LXN_New()
        {
            DataTable datatable = new DataTable();
            using (SqlConnection connection = base.GetConnection())
            {
                SqlCommand command = new SqlCommand("_Get_LXN_New", connection)
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
        // check trùng tên
        public DataTable Check_TrungTen(int idcha, string ten)
        {
            DataTable datatable = new DataTable();
            using (SqlConnection connection = base.GetConnection())
            {
                SqlCommand command = new SqlCommand("Get_IDCha", connection)
                {
                    CommandType = CommandType.StoredProcedure
                };
                command.Parameters.AddWithValue("@TenLoaiXN", ten);
                command.Parameters.AddWithValue("@ID_Cha", idcha);
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
