namespace DAO
{
    using ETO;
    using System;
    using System.Data;
    using System.Data.SqlClient;

    public class AdminRolesDAO : BaseDAO
    {
        private AdminRoles AdminRolesReader(SqlDataReader reader)
        {
            return new AdminRoles { AdminRolesID = (int) reader["AdminRolesID"], RolesID = (int) reader["RolesID"], AdminUserName = (string) reader["Admin_UserName"], Permission = (string) reader["Permission"], Created = (DateTime) reader["Created"], UserName = (string) reader["UserName"] };
        }

        public bool CheckExitPermission(int rolesID, string username)
        {
            bool check = false;
            DataTable dataTable = this.GetAdminRolesAll();
            if (dataTable != null)
            {
                DataView dataView = new DataView(dataTable) {
                    RowFilter = string.Concat(new object[] { "RolesID = ", rolesID, " AND Admin_UserName = '", username, "'" })
                };
                if (dataView.Count > 0)
                {
                    check = true;
                }
            }
            return check;
        }

        public bool CheckExitRolesUser(int rolesID, string username)
        {
            bool check = false;
            DataTable dataTable = this.GetAdminRolesAll();
            if (dataTable != null)
            {
                DataView dataView = new DataView(dataTable) {
                    RowFilter = string.Concat(new object[] { "RolesID = ", rolesID, " AND Admin_UserName = '", username, "'" })
                };
                if (dataView.Count > 0)
                {
                    check = true;
                }
            }
            return check;
        }

        public void CreateAdminRoles(AdminRoles adminRoles)
        {
            using (SqlConnection connection = base.GetConnection())
            {
                SqlCommand command = new SqlCommand("_AdminRolesUpdate", connection) {
                    CommandType = CommandType.StoredProcedure
                };
                command.Parameters.AddWithValue("@Type", 0);
                command.Parameters.AddWithValue("@AdminRolesID", 0);
                command.Parameters.AddWithValue("@RolesID", adminRoles.RolesID);
                command.Parameters.AddWithValue("@Admin_UserName", adminRoles.AdminUserName);
                command.Parameters.AddWithValue("@Permission", adminRoles.Permission);
                command.Parameters.AddWithValue("@Created", adminRoles.Created);
                command.Parameters.AddWithValue("@UserName", adminRoles.UserName);
                connection.Open();
                if (command.ExecuteNonQuery() <= 0)
                {
                    throw new DataAccessException("Khong them duoc quang cao");
                }
                command.Dispose();
            }
        }

        public void DeleteAdminRoles(int Id)
        {
            using (SqlConnection connection = base.GetConnection())
            {
                SqlCommand command = new SqlCommand("_AdminRolesDelete", connection) {
                    CommandType = CommandType.StoredProcedure
                };
                command.Parameters.AddWithValue("@AdminRolesID", Id);
                connection.Open();
                if (command.ExecuteNonQuery() <= 0)
                {
                    throw new DataAccessException("Kh\x00f4ng x\x00f3a được bản ghi");
                }
                command.Dispose();
            }
        }

        public void DeleteAdminRolesRoles(int Id)
        {
            using (SqlConnection connection = base.GetConnection())
            {
                SqlCommand command = new SqlCommand("_AdminRolesDeleteRoles", connection) {
                    CommandType = CommandType.StoredProcedure
                };
                command.Parameters.AddWithValue("@RolesID", Id);
                connection.Open();
                if (command.ExecuteNonQuery() <= 0)
                {
                    throw new DataAccessException("Kh\x00f4ng x\x00f3a được bản ghi");
                }
                command.Dispose();
            }
        }

        public void DeleteAdminRolesUserName(string username)
        {
            using (SqlConnection connection = base.GetConnection())
            {
                SqlCommand command = new SqlCommand("_AdminRolesDeleteUserName", connection) {
                    CommandType = CommandType.StoredProcedure
                };
                command.Parameters.AddWithValue("@Admin_UserName", username);
                connection.Open();
                if (command.ExecuteNonQuery() <= 0)
                {
                    throw new DataAccessException("Kh\x00f4ng x\x00f3a được bản ghi");
                }
                command.Dispose();
            }
        }

        public AdminRoles GetAdminRoles(int rolesId, string username)
        {
            AdminRoles adminRoles = null;
            using (SqlConnection connection = base.GetConnection())
            {
                SqlCommand command = new SqlCommand("_AdminRolesGet", connection) {
                    CommandType = CommandType.StoredProcedure
                };
                command.Parameters.AddWithValue("@RolesID", rolesId);
                command.Parameters.AddWithValue("@Admin_UserName", username);
                connection.Open();
                using (SqlDataReader reader = command.ExecuteReader(CommandBehavior.CloseConnection))
                {
                    if (!reader.Read())
                    {
                        throw new DataAccessException("Kh\x00f4ng t\x00ecm thấy gi\x00e1 trị");
                    }
                    adminRoles = this.AdminRolesReader(reader);
                    command.Dispose();
                }
            }
            return adminRoles;
        }

        public DataTable GetAdminRolesAll()
        {
            DataTable datatable = new DataTable();
            using (SqlConnection connection = base.GetConnection())
            {
                SqlCommand command = new SqlCommand("_AdminRolesGetAll", connection) {
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

        public AdminRoles GetAdminRolesById(int Id)
        {
            AdminRoles adminRoles = null;
            using (SqlConnection connection = base.GetConnection())
            {
                SqlCommand command = new SqlCommand("_AdminRolesGetById", connection) {
                    CommandType = CommandType.StoredProcedure
                };
                command.Parameters.AddWithValue("@AdminRolesID", Id);
                connection.Open();
                using (SqlDataReader reader = command.ExecuteReader(CommandBehavior.CloseConnection))
                {
                    if (!reader.Read())
                    {
                        throw new DataAccessException("Khong tim thay gia tri nao");
                    }
                    adminRoles = this.AdminRolesReader(reader);
                    command.Dispose();
                }
            }
            return adminRoles;
        }

        public DataTable GetAdminRolesByRoles(int rolesID)
        {
            DataTable datatable = new DataTable();
            using (SqlConnection connection = base.GetConnection())
            {
                SqlCommand command = new SqlCommand("_AdminRolesGetByRoles", connection) {
                    CommandType = CommandType.StoredProcedure
                };
                command.Parameters.AddWithValue("@RolesID", rolesID);
                connection.Open();
                using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                {
                    adapter.Fill(datatable);
                    command.Dispose();
                }
            }
            return datatable;
        }

        public DataTable GetAdminRolesByUserName(string username)
        {
            DataTable datatable = new DataTable();
            using (SqlConnection connection = base.GetConnection())
            {
                SqlCommand command = new SqlCommand("_AdminRolesGetByUserName", connection) {
                    CommandType = CommandType.StoredProcedure
                };
                command.Parameters.AddWithValue("@Admin_UserName", username);
                connection.Open();
                using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                {
                    adapter.Fill(datatable);
                    command.Dispose();
                }
            }
            return datatable;
        }

        public string GetAdminUserName(int rolesID)
        {
            DataTable table = this.GetAdminRolesByRoles(rolesID);
            string str = "";
            string restr = "";
            if (table.Rows.Count <= 0)
            {
                return restr;
            }
            foreach (DataRow row in table.Rows)
            {
                str = str + row["Admin_UserName"].ToString() + ",";
            }
            return str.Remove(str.LastIndexOf(",")).Replace(",", "','");
        }

        public string GetAdminUserName1(int rolesID)
        {
            DataTable table = this.GetAdminRolesByRoles(rolesID);
            string str = "";
            if (table.Rows.Count > 0)
            {
                foreach (DataRow row in table.Rows)
                {
                    str = str + row["Admin_UserName"].ToString() + ",";
                }
            }
            return "";
        }

        public string GetPermission(int rolesID, string username)
        {
            string permission = "";
            if (this.CheckExitPermission(rolesID, username))
            {
                permission = this.GetAdminRoles(rolesID, username).Permission;
            }
            return permission;
        }

        public string GetRoles(string username)
        {
            DataTable table = this.GetAdminRolesByUserName(username);
            string str = "";
            string restr = "";
            if (table.Rows.Count <= 0)
            {
                return restr;
            }
            foreach (DataRow row in table.Rows)
            {
                str = str + row["RolesID"].ToString() + ",";
            }
            return str.Remove(str.LastIndexOf(",")).Replace(",", "','");
        }

        public string GetRoles1(string username)
        {
            DataTable table = this.GetAdminRolesByUserName(username);
            string str = "";
            if (table.Rows.Count > 0)
            {
                foreach (DataRow row in table.Rows)
                {
                    str = str + row["RolesID"].ToString() + ",";
                }
            }
            return (str + "0");
        }

        public void UpdateAdminRoles(AdminRoles adminRoles)
        {
            using (SqlConnection connection = base.GetConnection())
            {
                SqlCommand command = new SqlCommand("_AdminRolesUpdate", connection) {
                    CommandType = CommandType.StoredProcedure
                };
                command.Parameters.AddWithValue("@Type", 1);
                command.Parameters.AddWithValue("@AdminRolesID", adminRoles.AdminRolesID);
                command.Parameters.AddWithValue("@RolesID", adminRoles.RolesID);
                command.Parameters.AddWithValue("@Admin_UserName", adminRoles.AdminUserName);
                command.Parameters.AddWithValue("@Permission", adminRoles.Permission);
                command.Parameters.AddWithValue("@Created", adminRoles.Created);
                command.Parameters.AddWithValue("@UserName", adminRoles.UserName);
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

