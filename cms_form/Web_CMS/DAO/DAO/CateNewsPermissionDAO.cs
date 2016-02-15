namespace DAO
{
    using ETO;
    using System;
    using System.Data;
    using System.Data.SqlClient;

    public class CateNewsPermissionDAO : BaseDAO
    {
        private CateNewsPermission CateNewsPermissionReader(SqlDataReader reader)
        {
            return new CateNewsPermission { CateNewsPermissionID = (int) reader["CateNewsPermissionID"], RolesID = (int) reader["RolesID"], CateNewsID = (int) reader["CateNewsID"], Permission = (string) reader["Permission"], Created = (DateTime) reader["Created"], UserName = (string) reader["UserName"] };
        }

        public bool CheckExitPermission(int rolesID, int cateNewsID)
        {
            bool check = false;
            DataTable dataTable = this.GetCateNewsPermissionAll();
            if (dataTable != null)
            {
                DataView dataView = new DataView(dataTable) {
                    RowFilter = string.Concat(new object[] { "RolesID = ", rolesID, " AND CateNewsID = ", cateNewsID })
                };
                if (dataView.Count > 0)
                {
                    check = true;
                }
            }
            return check;
        }

        public void CreateCateNewsPermission(CateNewsPermission cateNewsPermission)
        {
            using (SqlConnection connection = base.GetConnection())
            {
                SqlCommand command = new SqlCommand("_CateNewsPermissionUpdate", connection) {
                    CommandType = CommandType.StoredProcedure
                };
                command.Parameters.AddWithValue("@Type", 0);
                command.Parameters.AddWithValue("@CateNewsPermissionID", 0);
                command.Parameters.AddWithValue("@RolesID", cateNewsPermission.RolesID);
                command.Parameters.AddWithValue("@CateNewsID", cateNewsPermission.CateNewsID);
                command.Parameters.AddWithValue("@Permission", cateNewsPermission.Permission);
                command.Parameters.AddWithValue("@Created", cateNewsPermission.Created);
                command.Parameters.AddWithValue("@UserName", cateNewsPermission.UserName);
                connection.Open();
                if (command.ExecuteNonQuery() <= 0)
                {
                    throw new DataAccessException("Khong them duoc quang cao");
                }
                command.Dispose();
            }
        }

        public void DeleteCateNewsPermission(int Id)
        {
            using (SqlConnection connection = base.GetConnection())
            {
                SqlCommand command = new SqlCommand("_CateNewsPermissionDelete", connection) {
                    CommandType = CommandType.StoredProcedure
                };
                command.Parameters.AddWithValue("@CateNewsPermissionID", Id);
                connection.Open();
                if (command.ExecuteNonQuery() <= 0)
                {
                    throw new DataAccessException("Kh\x00f4ng x\x00f3a được bản ghi");
                }
                command.Dispose();
            }
        }

        public void DeleteCateNewsPermissionCateID(int Id)
        {
            using (SqlConnection connection = base.GetConnection())
            {
                SqlCommand command = new SqlCommand("_CateNewsPermissionDeleteCateID", connection) {
                    CommandType = CommandType.StoredProcedure
                };
                command.Parameters.AddWithValue("@CateNewsID", Id);
                connection.Open();
                if (command.ExecuteNonQuery() <= 0)
                {
                    throw new DataAccessException("Kh\x00f4ng x\x00f3a được bản ghi");
                }
                command.Dispose();
            }
        }

        public void DeleteCateNewsPermissionRoles(int Id)
        {
            using (SqlConnection connection = base.GetConnection())
            {
                SqlCommand command = new SqlCommand("_CateNewsPermissionDeleteRoles", connection) {
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

        public string GetCateNewsID(int rolesID)
        {
            DataTable table = this.GetCateNewsPermissionByRoles(rolesID);
            string str = "";
            string restr = "";
            if (table.Rows.Count <= 0)
            {
                return restr;
            }
            foreach (DataRow row in table.Rows)
            {
                str = str + row["CateNewsID"].ToString() + ",";
            }
            return str.Remove(str.LastIndexOf(",")).Replace(",", "','");
        }

        public string GetCateNewsID(string strRoles)
        {
            DataTable table = new DataTable();
            using (SqlConnection connection = base.GetConnection())
            {
                string SQL = "Select * from tblCateNewsPermission where RolesID IN('" + strRoles + "')";
                SqlCommand command = new SqlCommand(SQL, connection) {
                    CommandText = SQL
                };
                connection.Open();
                using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                {
                    adapter.Fill(table);
                    command.Dispose();
                }
            }
            string str = "";
            string restr = "";
            if (table.Rows.Count <= 0)
            {
                return restr;
            }
            foreach (DataRow row in table.Rows)
            {
                str = str + row["CateNewsID"].ToString() + ",";
            }
            return str.Remove(str.LastIndexOf(",")).Replace(",", "','");
        }

        public CateNewsPermission GetCateNewsPermission(int rolesId, int cateNewsID)
        {
            CateNewsPermission cateNewsPermission = null;
            using (SqlConnection connection = base.GetConnection())
            {
                SqlCommand command = new SqlCommand("_CateNewsPermissionGet", connection) {
                    CommandType = CommandType.StoredProcedure
                };
                command.Parameters.AddWithValue("@RolesID", rolesId);
                command.Parameters.AddWithValue("@CateNewsID", cateNewsID);
                connection.Open();
                using (SqlDataReader reader = command.ExecuteReader(CommandBehavior.CloseConnection))
                {
                    if (!reader.Read())
                    {
                        throw new DataAccessException("Kh\x00f4ng t\x00ecm thấy gi\x00e1 trị");
                    }
                    cateNewsPermission = this.CateNewsPermissionReader(reader);
                    command.Dispose();
                }
            }
            return cateNewsPermission;
        }

        public DataTable GetCateNewsPermissionAll()
        {
            DataTable datatable = new DataTable();
            using (SqlConnection connection = base.GetConnection())
            {
                SqlCommand command = new SqlCommand("_CateNewsPermissionGetAll", connection) {
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

        public DataTable GetCateNewsPermissionByCateID(int cateID)
        {
            DataTable datatable = new DataTable();
            using (SqlConnection connection = base.GetConnection())
            {
                SqlCommand command = new SqlCommand("_CateNewsPermissionGetByCateID", connection) {
                    CommandType = CommandType.StoredProcedure
                };
                command.Parameters.AddWithValue("@CateNewsID", cateID);
                connection.Open();
                using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                {
                    adapter.Fill(datatable);
                    command.Dispose();
                }
            }
            return datatable;
        }

        public CateNewsPermission GetCateNewsPermissionById(int Id)
        {
            CateNewsPermission cateNewsPermission = null;
            using (SqlConnection connection = base.GetConnection())
            {
                SqlCommand command = new SqlCommand("_CateNewsPermissionGetById", connection) {
                    CommandType = CommandType.StoredProcedure
                };
                command.Parameters.AddWithValue("@CateNewsPermissionID", Id);
                connection.Open();
                using (SqlDataReader reader = command.ExecuteReader(CommandBehavior.CloseConnection))
                {
                    if (!reader.Read())
                    {
                        throw new DataAccessException("Khong tim thay gia tri nao");
                    }
                    cateNewsPermission = this.CateNewsPermissionReader(reader);
                    command.Dispose();
                }
            }
            return cateNewsPermission;
        }

        public DataTable GetCateNewsPermissionByRoles(int rolesID)
        {
            DataTable datatable = new DataTable();
            using (SqlConnection connection = base.GetConnection())
            {
                SqlCommand command = new SqlCommand("_CateNewsPermissionGetByRoles", connection) {
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

        public string GetPermission(int rolesID, int cateNewsID)
        {
            string permission = "";
            if (this.CheckExitPermission(rolesID, cateNewsID))
            {
                permission = this.GetCateNewsPermission(rolesID, cateNewsID).Permission;
            }
            return permission;
        }

        public string GetRoles(int cateID)
        {
            DataTable table = this.GetCateNewsPermissionByCateID(cateID);
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

        public void UpdateCateNewsPermission(CateNewsPermission cateNewsPermission)
        {
            using (SqlConnection connection = base.GetConnection())
            {
                SqlCommand command = new SqlCommand("_CateNewsPermissionUpdate", connection) {
                    CommandType = CommandType.StoredProcedure
                };
                command.Parameters.AddWithValue("@Type", 1);
                command.Parameters.AddWithValue("@CateNewsPermissionID", cateNewsPermission.CateNewsPermissionID);
                command.Parameters.AddWithValue("@RolesID", cateNewsPermission.RolesID);
                command.Parameters.AddWithValue("@CateNewsID", cateNewsPermission.CateNewsID);
                command.Parameters.AddWithValue("@Permission", cateNewsPermission.Permission);
                command.Parameters.AddWithValue("@Created", cateNewsPermission.Created);
                command.Parameters.AddWithValue("@UserName", cateNewsPermission.UserName);
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

