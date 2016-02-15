namespace DAO
{
    using ETO;
    using System;
    using System.Data;
    using System.Data.SqlClient;

    public class PermissionDAO : BaseDAO
    {
        public void CreatePermission(Permission permission)
        {
            using (SqlConnection connection = base.GetConnection())
            {
                SqlCommand command = new SqlCommand("_PermissionUpdate", connection) {
                    CommandType = CommandType.StoredProcedure
                };
                command.Parameters.AddWithValue("@Type", 0);
                command.Parameters.AddWithValue("@PermissionID", 0);
                command.Parameters.AddWithValue("@PermissionName", permission.PermissionName);
                command.Parameters.AddWithValue("@Description", permission.Description);
                command.Parameters.AddWithValue("@Value", permission.Value);
                connection.Open();
                if (command.ExecuteNonQuery() <= 0)
                {
                    throw new DataAccessException("Khong them duoc");
                }
                command.Dispose();
            }
        }

        public void DeletePermission(int Id)
        {
            using (SqlConnection connection = base.GetConnection())
            {
                SqlCommand command = new SqlCommand("_PermissionDelete", connection) {
                    CommandType = CommandType.StoredProcedure
                };
                command.Parameters.AddWithValue("@PermissionID", Id);
                connection.Open();
                if (command.ExecuteNonQuery() <= 0)
                {
                    throw new DataAccessException("Khong xoa duoc quang cao");
                }
                command.Dispose();
            }
        }

        public DataTable GetPermissionAll()
        {
            DataTable datatable = new DataTable();
            using (SqlConnection connection = base.GetConnection())
            {
                SqlCommand command = new SqlCommand("_PermissionGetAll", connection) {
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

        public Permission GetPermissionById(int Id)
        {
            Permission permission = null;
            using (SqlConnection connection = base.GetConnection())
            {
                SqlCommand command = new SqlCommand("_PermissionGetById", connection) {
                    CommandType = CommandType.StoredProcedure
                };
                command.Parameters.AddWithValue("@PermissionID", Id);
                connection.Open();
                using (SqlDataReader reader = command.ExecuteReader(CommandBehavior.CloseConnection))
                {
                    if (!reader.Read())
                    {
                        throw new DataAccessException("Khong tim thay gia tri nao");
                    }
                    permission = this.PermissionReader(reader);
                    command.Dispose();
                }
            }
            return permission;
        }

        private Permission PermissionReader(SqlDataReader reader)
        {
            return new Permission { PermissionID = (int) reader["PermissionID"], PermissionName = (string) reader["PermissionName"], Description = (string) reader["Description"], Value = (string) reader["Value"] };
        }

        public void UpdatePermission(Permission permission)
        {
            using (SqlConnection connection = base.GetConnection())
            {
                SqlCommand command = new SqlCommand("_PermissionUpdate", connection) {
                    CommandType = CommandType.StoredProcedure
                };
                command.Parameters.AddWithValue("@Type", 1);
                command.Parameters.AddWithValue("@PermissionID", permission.PermissionID);
                command.Parameters.AddWithValue("@PermissionName", permission.PermissionName);
                command.Parameters.AddWithValue("@Description", permission.Description);
                command.Parameters.AddWithValue("@Value", permission.Value);
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

