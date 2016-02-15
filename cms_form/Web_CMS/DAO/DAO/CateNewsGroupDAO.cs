namespace DAO
{
    using ETO;
    using System;
    using System.Data;
    using System.Data.SqlClient;

    public class CateNewsGroupDAO : BaseDAO
    {
        private CateNewsGroup CateNewsGroupReader(SqlDataReader reader)
        {
            return new CateNewsGroup { CateNewsGroupID = (int)reader["CateNewsGroupID"], GroupCate = (int)reader["GroupCate"], CateNewsGroupName = (string)reader["CateNewsGroupName"], Description = (string)reader["Description"], Order = (int)reader["Order"], IsView = (bool)reader["IsView"], IsHome = (bool)reader["IsHome"], IsMenu = (bool)reader["IsMenu"], IsNew = (bool)reader["IsNew"], IsPage = (bool)reader["IsPage"], IsUrl = (bool)reader["IsUrl"], Url = (string)reader["Url"], Icon = (string)reader["Icon"], Position = (int)reader["Position"], Language = (string)reader["language"] };
        }

        public void CateNewsGroupUpOrder(int cId, int cOrder)
        {
            using (SqlConnection connection = base.GetConnection())
            {
                SqlCommand command = new SqlCommand("_CateNewsGroupUpOrder", connection) {
                    CommandType = CommandType.StoredProcedure
                };
                command.Parameters.AddWithValue("@CateNewsGroupID", cId);
                command.Parameters.AddWithValue("@Order", cOrder);
                connection.Open();
                if (command.ExecuteNonQuery() <= 0)
                {
                    throw new DataAccessException("Kh\x00f4ng thể cập nhật danh mục tin");
                }
                command.Dispose();
            }
        }

        public void CreateCateNewsGroup(CateNewsGroup cateNewsGroup)
        {
            using (SqlConnection connection = base.GetConnection())
            {
                SqlCommand command = new SqlCommand("_CateNewsGroupUpdate", connection) {
                    CommandType = CommandType.StoredProcedure
                };
                command.Parameters.AddWithValue("@Type", 0);
                command.Parameters.AddWithValue("@CateNewsGroupID", 0);
                command.Parameters.AddWithValue("@GroupCate", cateNewsGroup.GroupCate);
                command.Parameters.AddWithValue("@CateNewsGroupName", cateNewsGroup.CateNewsGroupName);
                command.Parameters.AddWithValue("@Description", cateNewsGroup.Description);
                command.Parameters.AddWithValue("@Order", cateNewsGroup.Order);
                command.Parameters.AddWithValue("@IsView", cateNewsGroup.IsView);
                command.Parameters.AddWithValue("@IsHome", cateNewsGroup.IsHome);
                command.Parameters.AddWithValue("@IsMenu", cateNewsGroup.IsMenu);
                command.Parameters.AddWithValue("@IsNew", cateNewsGroup.IsNew);
                command.Parameters.AddWithValue("@IsPage", cateNewsGroup.IsPage);
                command.Parameters.AddWithValue("@IsUrl", cateNewsGroup.IsUrl);
                command.Parameters.AddWithValue("@Url", cateNewsGroup.Url);
                command.Parameters.AddWithValue("@Icon", cateNewsGroup.Icon);
                command.Parameters.AddWithValue("@Position", cateNewsGroup.Position);
                command.Parameters.AddWithValue("@language", cateNewsGroup.Language);
                connection.Open();
                if (command.ExecuteNonQuery() <= 0)
                {
                    throw new DataAccessException("Khong them duoc");
                }
                command.Dispose();
            }
        }

        public void DeleteCateNewsGroup(int Id)
        {
            using (SqlConnection connection = base.GetConnection())
            {
                SqlCommand command = new SqlCommand("_CateNewsGroupDelete", connection) {
                    CommandType = CommandType.StoredProcedure
                };
                command.Parameters.AddWithValue("@CateNewsGroupID", Id);
                connection.Open();
                if (command.ExecuteNonQuery() <= 0)
                {
                    throw new DataAccessException("Khong xoa duoc quang cao");
                }
                command.Dispose();
            }
        }

        public DataTable GetCateAll(string lang)
        {
            DataTable datatable = new DataTable();
            using (SqlConnection connection = base.GetConnection())
            {
                SqlCommand command = new SqlCommand("_CateGetLaguage", connection)
                {
                    CommandType = CommandType.StoredProcedure
                };
                command.Parameters.AddWithValue("@Language", lang);
                connection.Open();
                using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                {
                    adapter.Fill(datatable);
                    command.Dispose();
                }
            }
            return datatable;
        }

        public DataTable GetCateNewsGroupAll()
        {
            DataTable datatable = new DataTable();
            using (SqlConnection connection = base.GetConnection())
            {
                SqlCommand command = new SqlCommand("_CateNewsGroupGetAll", connection) {
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


        public DataTable CateNewsGetByMenuCap3(int cateID)
        {
            DataTable datatable = new DataTable();
            using (SqlConnection connection = base.GetConnection())
            {
                SqlCommand command = new SqlCommand("_CateNewsGetByMenuCap3", connection)
                {
                    CommandType = CommandType.StoredProcedure
                };
                command.Parameters.AddWithValue("@ParentNewsID", cateID);
                connection.Open();
                using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                {
                    adapter.Fill(datatable);
                    command.Dispose();
                }
            }
            return datatable;
        }
        public DataTable CateNewsGetByGroup(int groupcate)
        {
            DataTable datatable = new DataTable();
            using (SqlConnection connection = base.GetConnection())
            {
                SqlCommand command = new SqlCommand("_CateNewsGetByGroup", connection)
                {
                    CommandType = CommandType.StoredProcedure
                };
                command.Parameters.AddWithValue("@Group", groupcate);
                connection.Open();
                using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                {
                    adapter.Fill(datatable);
                    command.Dispose();
                }
            }
            return datatable;
        }

        public CateNewsGroup GetCateNewsGroupByGroupCate(int groupcate)
        {
            CateNewsGroup cateNewsGroup = null;
            using (SqlConnection connection = base.GetConnection())
            {
                SqlCommand command = new SqlCommand("_CateNewsGroupGetByGroupCate", connection) {
                    CommandType = CommandType.StoredProcedure
                };
                command.Parameters.AddWithValue("@GroupCate", groupcate);
                connection.Open();
                using (SqlDataReader reader = command.ExecuteReader(CommandBehavior.CloseConnection))
                {
                    if (reader.Read())
                    {
                        cateNewsGroup = this.CateNewsGroupReader(reader);
                    }
                    else
                    {
                        cateNewsGroup = null;
                    }
                    command.Dispose();
                }
            }
            return cateNewsGroup;
        }

        public CateNewsGroup GetCateNewsGroupById(int Id)
        {
            CateNewsGroup cateNewsGroup = null;
            using (SqlConnection connection = base.GetConnection())
            {
                SqlCommand command = new SqlCommand("_CateNewsGroupGetById", connection) {
                    CommandType = CommandType.StoredProcedure
                };
                command.Parameters.AddWithValue("@CateNewsGroupID", Id);
                connection.Open();
                using (SqlDataReader reader = command.ExecuteReader(CommandBehavior.CloseConnection))
                {
                    if (!reader.Read())
                    {
                        throw new DataAccessException("Khong tim thay gia tri nao");
                    }
                    cateNewsGroup = this.CateNewsGroupReader(reader);
                    command.Dispose();
                }
            }
            return cateNewsGroup;
        }

        public DataTable GetCateNewsGroupHomeAll()
        {
            DataTable datatable = new DataTable();
            using (SqlConnection connection = base.GetConnection())
            {
                SqlCommand command = new SqlCommand("_CateNewsGroupGetHomeAll", connection) {
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

        public DataTable GetCateNewsGroupMenuAll()
        {
            DataTable datatable = new DataTable();
            using (SqlConnection connection = base.GetConnection())
            {
                SqlCommand command = new SqlCommand("_CateNewsGroupGetMenuAll", connection) {
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

        public DataTable    GetCateNewsGroupNewAll()
        {
            DataTable datatable = new DataTable();
            using (SqlConnection connection = base.GetConnection())
            {
                SqlCommand command = new SqlCommand("_CateNewsGroupGetNewsAll", connection) {
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

        public DataTable GetCateNewsGroupPageAll()
        {
            DataTable datatable = new DataTable();
            using (SqlConnection connection = base.GetConnection())
            {
                SqlCommand command = new SqlCommand("_CateNewsGroupGetPageAll", connection) {
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

        public DataTable GetCateNewsGroupViewAll()
        {
            DataTable datatable = new DataTable();
            using (SqlConnection connection = base.GetConnection())
            {
                SqlCommand command = new SqlCommand("_CateNewsGroupGetViewAll", connection) {
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

        public void UpdateCateNewsGroup(CateNewsGroup cateNewsGroup)
        {
            using (SqlConnection connection = base.GetConnection())
            {
                SqlCommand command = new SqlCommand("_CateNewsGroupUpdate", connection) {
                    CommandType = CommandType.StoredProcedure
                };
                command.Parameters.AddWithValue("@Type", 1);
                command.Parameters.AddWithValue("@CateNewsGroupID", cateNewsGroup.CateNewsGroupID);
                command.Parameters.AddWithValue("@GroupCate", cateNewsGroup.GroupCate);
                command.Parameters.AddWithValue("@CateNewsGroupName", cateNewsGroup.CateNewsGroupName);
                command.Parameters.AddWithValue("@Description", cateNewsGroup.Description);
                command.Parameters.AddWithValue("@Order", cateNewsGroup.Order);
                command.Parameters.AddWithValue("@IsView", cateNewsGroup.IsView);
                command.Parameters.AddWithValue("@IsHome", cateNewsGroup.IsHome);
                command.Parameters.AddWithValue("@IsMenu", cateNewsGroup.IsMenu);
                command.Parameters.AddWithValue("@IsNew", cateNewsGroup.IsNew);
                command.Parameters.AddWithValue("@IsPage", cateNewsGroup.IsPage);
                command.Parameters.AddWithValue("@IsUrl", cateNewsGroup.IsUrl);
                command.Parameters.AddWithValue("@Url", cateNewsGroup.Url);
                command.Parameters.AddWithValue("@Icon", cateNewsGroup.Icon);
                command.Parameters.AddWithValue("@Position", cateNewsGroup.Position);
                command.Parameters.AddWithValue("@language", cateNewsGroup.Language);
                connection.Open();
                if (command.ExecuteNonQuery() <= 0)
                {
                    throw new DataAccessException("Khong cap nhat duoc quang cao");
                }
                command.Dispose();
            }
        }
    }
}

