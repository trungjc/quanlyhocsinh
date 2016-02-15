namespace DAO
{
    using ETO;
    using System;
    using System.Data;
    using System.Data.SqlClient;

    public class RolesDAO : BaseDAO
    {
        public void CreateRoles(IRoles roles)
        {
            using (SqlConnection connection = base.GetConnection())
            {
                SqlCommand command = new SqlCommand("_RolesUpdate", connection) {
                    CommandType = CommandType.StoredProcedure
                };
                command.Parameters.AddWithValue("@Type", 0);
                command.Parameters.AddWithValue("@Roles_ID", 1);
                command.Parameters.AddWithValue("@Roles_Name", roles.RolesName);
                command.Parameters.AddWithValue("@Roles_Modules", roles.RolesModules);
                connection.Open();
                if (command.ExecuteNonQuery() <= 0)
                {
                    throw new DataAccessException("Lỗi kh\x00f4ng tao moi roles");
                }
                command.Dispose();
            }
        }

        public void DeleteRoles(int rId)
        {
            using (SqlConnection connection = base.GetConnection())
            {
                SqlCommand command = new SqlCommand("_RolesDelete", connection) {
                    CommandType = CommandType.StoredProcedure
                };
                command.Parameters.AddWithValue("@Roles_ID", rId);
                connection.Open();
                if (command.ExecuteNonQuery() < 0)
                {
                    throw new DataAccessException("Lỗi , kh\x00f4ng thể x\x00f3a");
                }
                command.Dispose();
            }
        }

        public DataTable GetAllRoles()
        {
            DataTable datatable = new DataTable();
            using (SqlConnection connection = base.GetConnection())
            {
                SqlCommand command = new SqlCommand("_RolesGetAll", connection) {
                    CommandType = CommandType.StoredProcedure
                };
                connection.Open();
                using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                {
                    adapter.Fill(datatable);
                    command.Dispose();
                }
                return datatable;
            }
        }

        public IRoles GetRolesById(int rId)
        {
            IRoles roles = null;
            using (SqlConnection connection = base.GetConnection())
            {
                SqlCommand command = new SqlCommand("_RolesGetById", connection);
                command.Parameters.AddWithValue("@Roles_ID", rId);
                command.CommandType = CommandType.StoredProcedure;
                connection.Open();
                using (SqlDataReader reader = command.ExecuteReader(CommandBehavior.CloseConnection))
                {
                    if (!reader.Read())
                    {
                        throw new DataAccessException("Khong tim thay");
                    }
                    roles = this.RolesReader(reader);
                }
                command.Dispose();
            }
            return roles;
        }

        public IRoles GetRolesByName(string name)
        {
            IRoles roles = null;
            using (SqlConnection connection = base.GetConnection())
            {
                SqlCommand command = new SqlCommand("_RolesGetByName", connection);
                command.Parameters.AddWithValue("@Roles_Name", name);
                command.CommandType = CommandType.StoredProcedure;
                connection.Open();
                using (SqlDataReader reader = command.ExecuteReader(CommandBehavior.CloseConnection))
                {
                    if (!reader.Read())
                    {
                        throw new DataAccessException("Khong tim thay");
                    }
                    roles = this.RolesReader(reader);
                }
                command.Dispose();
            }
            return roles;
        }

        public DataTable GetRolesbyStrRolesID(string strRolesID)
        {
            DataTable datatable = new DataTable();
            using (SqlConnection connection = base.GetConnection())
            {
                string SQL = "SELECT * FROM tblRoles WHERE [Roles_ID] in('" + strRolesID + "') ORDER BY Roles_ID ASC";
                SqlCommand command = new SqlCommand(SQL, connection) {
                    CommandText = SQL
                };
                connection.Open();
                using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                {
                    adapter.Fill(datatable);
                    command.Dispose();
                }
                return datatable;
            }
        }

        private IRoles RolesReader(SqlDataReader reader)
        {
            return new IRoles { RolesID = (int) reader["Roles_ID"], RolesName = (string) reader["Roles_Name"], RolesModules = (string) reader["Roles_Modules"] };
        }

        public void UpdateRoles(IRoles roles)
        {
            using (SqlConnection connection = base.GetConnection())
            {
                SqlCommand command = new SqlCommand("_RolesUpdate", connection) {
                    CommandType = CommandType.StoredProcedure
                };
                command.Parameters.AddWithValue("@Type", 1);
                command.Parameters.AddWithValue("@Roles_ID", roles.RolesID);
                command.Parameters.AddWithValue("@Roles_Name", roles.RolesName);
                command.Parameters.AddWithValue("@Roles_Modules", roles.RolesModules);
                connection.Open();
                if (command.ExecuteNonQuery() <= 0)
                {
                    throw new DataAccessException("Lỗi kh\x00f4ng cập nhật Roles");
                }
                command.Dispose();
            }
        }
    }
}

