namespace DAO
{
    using ETO;
    using System;
    using System.Data;
    using System.Data.SqlClient;

    public class AdminDAO : BaseDAO
    {
        public DataTable AdminGetAllRolesByID(int rolesID)
        {
            DataTable datatable = new DataTable();
            using (SqlConnection connection = base.GetConnection())
            {
                string SQL = "SELECT tblAdmin.*, tblRoles.* FROM tblAdmin INNER JOIN tblRoles ON tblAdmin.Roles_ID = tblRoles.Roles_ID WHERE tblAdmin.Roles_ID = @Roles_ID";
                SqlCommand command = new SqlCommand(SQL, connection) {
                    CommandText = SQL
                };
                command.Parameters.AddWithValue("@Roles_ID", rolesID);
                connection.Open();
                using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                {
                    adapter.Fill(datatable);
                    command.Dispose();
                }
            }
            return datatable;
        }

        public DataTable AdminGetRolesByID(int rolesID)
        {
            DataTable datatable = new DataTable();
            using (SqlConnection connection = base.GetConnection())
            {
                SqlCommand command = new SqlCommand("_AdminGetRolesByID", connection) {
                    CommandType = CommandType.StoredProcedure
                };
                command.Parameters.AddWithValue("@Roles_ID", rolesID);
                connection.Open();
                using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                {
                    adapter.Fill(datatable);
                    command.Dispose();
                }
            }
            return datatable;
        }

        private Admin AdminReader(SqlDataReader reader)
        {
            return new Admin { 
                AdminID = (int) reader["Admin_ID"], AdminName = (string) reader["Admin_Username"], AdminFullName = (string) reader["Admin_FullName"], AdminEmail = (string) reader["Admin_Email"], AdminPass = (string) reader["Admin_Password"], RolesID = (int) reader["Roles_ID"], AdminActive = (bool) reader["Admin_Actived"], AdminPermission = (string) reader["Admin_Permission"], AdminCreated = (DateTime) reader["Admin_Created"], AdminLog = (DateTime) reader["Admin_Log"], AdminPhone = (string) reader["Admin_Phone"], AdminAddress = (string) reader["Admin_Address"], AdminBirth = (DateTime) reader["Admin_Birth"], AdminSex = (bool) reader["Admin_Sex"], AdminNickYahoo = (string) reader["Admin_NickYahoo"], AdminNickSkype = (string) reader["Admin_NickSkype"], 
                AdminAvatar = (string) reader["Admin_Avatar"], AdminLoginType = (bool) reader["Admin_LoginType"]
             };
        }

        public void CreateAdmin(Admin admin)
        {
            using (SqlConnection connection = base.GetConnection())
            {
                SqlCommand command = new SqlCommand("_AdminUpdate", connection) {
                    CommandType = CommandType.StoredProcedure
                };
                command.Parameters.AddWithValue("@Type", 0);
                command.Parameters.AddWithValue("@Admin_ID", 1);
                command.Parameters.AddWithValue("@Admin_Username", admin.AdminName);
                command.Parameters.AddWithValue("@Admin_FullName", admin.AdminFullName);
                command.Parameters.AddWithValue("@Admin_Email", admin.AdminEmail);
                command.Parameters.AddWithValue("@Admin_Password", admin.AdminPass);
                command.Parameters.AddWithValue("@Roles_ID", admin.RolesID);
                command.Parameters.AddWithValue("@Admin_Actived", admin.AdminActive);
                command.Parameters.AddWithValue("@Admin_Permission", admin.AdminPermission);
                command.Parameters.AddWithValue("@Admin_Created", admin.AdminCreated);
                command.Parameters.AddWithValue("@Admin_Log", admin.AdminLog);
                command.Parameters.AddWithValue("@Admin_Phone", admin.AdminPhone);
                command.Parameters.AddWithValue("@Admin_Address", admin.AdminAddress);
                command.Parameters.AddWithValue("@Admin_Birth", admin.AdminBirth);
                command.Parameters.AddWithValue("@Admin_Sex", admin.AdminSex);
                command.Parameters.AddWithValue("@Admin_NickYahoo", admin.AdminNickYahoo);
                command.Parameters.AddWithValue("@Admin_NickSkype", admin.AdminNickSkype);
                command.Parameters.AddWithValue("@Admin_Avatar", admin.AdminAvatar);
                command.Parameters.AddWithValue("@Admin_LoginType", admin.AdminLoginType);
                connection.Open();
                if (command.ExecuteNonQuery() <= 0)
                {
                    throw new DataAccessException("Lỗi kh\x00f4ng thể tao moi");
                }
                command.Dispose();
            }
        }

        public void DeleteAdmin(string adminname)
        {
            using (SqlConnection connection = base.GetConnection())
            {
                SqlCommand command = new SqlCommand("_AdminDelete", connection) {
                    CommandType = CommandType.StoredProcedure
                };
                command.Parameters.AddWithValue("@Admin_Username", adminname);
                connection.Open();
                if (command.ExecuteNonQuery() <= 0)
                {
                    throw new DataAccessException("Kh\x00f4ng thể x\x00f3a admin");
                }
                command.Dispose();
            }
        }

        public DataTable GetAdminByCateHomeList(string strCate)
        {
            DataTable datatable = new DataTable();
            using (SqlConnection connection = base.GetConnection())
            {
                string SQL = "select * from tblAdmin where Roles_ID in('" + strCate + "') order by Admin_UserName Asc";
                SqlCommand command = new SqlCommand(SQL, connection) {
                    CommandText = SQL
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

        public Admin GetAdminById(string adminname)
        {
            Admin admin = null;
            using (SqlConnection connection = base.GetConnection())
            {
                SqlCommand command = new SqlCommand("_AdminGetById", connection) {
                    CommandType = CommandType.StoredProcedure
                };
                command.Parameters.AddWithValue("@Admin_Username", adminname);
                connection.Open();
                using (SqlDataReader reader = command.ExecuteReader(CommandBehavior.CloseConnection))
                {
                    if (!reader.Read())
                    {
                        throw new DataAccessException("khong ton tai admin");
                    }
                    admin = this.AdminReader(reader);
                }
                command.Dispose();
            }
            return admin;
        }

        public DataTable GetAdminByStrName(string strCate)
        {
            DataTable datatable = new DataTable();
            using (SqlConnection connection = base.GetConnection())
            {
                string SQL = "select * from tblAdmin where Admin_UserName in('" + strCate + "') order by Admin_UserName Asc";
                SqlCommand command = new SqlCommand(SQL, connection) {
                    CommandText = SQL
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

        public DataTable GetAllAdmin()
        {
            DataTable datatable = new DataTable();
            using (SqlConnection connection = base.GetConnection())
            {
                SqlCommand command = new SqlCommand("_AdminGetAll", connection) {
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

        public DataTable GetAllAdminRoles()
        {
            DataTable datatable = new DataTable();
            using (SqlConnection connection = base.GetConnection())
            {
                string SQL = "SELECT tblAdmin.*, tblRoles.* FROM tblAdmin INNER JOIN tblRoles ON tblAdmin.Roles_ID = tblRoles.Roles_ID ";
                SqlCommand command = new SqlCommand(SQL, connection) {
                    CommandText = SQL
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

        public void UpdateAdmin(Admin admin)
        {
            using (SqlConnection connection = base.GetConnection())
            {
                SqlCommand command = new SqlCommand("_AdminUpdate", connection) {
                    CommandType = CommandType.StoredProcedure
                };
                command.Parameters.AddWithValue("@Type", 1);
                command.Parameters.AddWithValue("@Admin_ID", 1);
                command.Parameters.AddWithValue("@Admin_Username", admin.AdminName);
                command.Parameters.AddWithValue("@Admin_FullName", admin.AdminFullName);
                command.Parameters.AddWithValue("@Admin_Email", admin.AdminEmail);
                command.Parameters.AddWithValue("@Admin_Password", admin.AdminPass);
                command.Parameters.AddWithValue("@Roles_ID", admin.RolesID);
                command.Parameters.AddWithValue("@Admin_Actived", admin.AdminActive);
                command.Parameters.AddWithValue("@Admin_Permission", admin.AdminPermission);
                command.Parameters.AddWithValue("@Admin_Created", admin.AdminCreated);
                command.Parameters.AddWithValue("@Admin_Log", admin.AdminLog);
                command.Parameters.AddWithValue("@Admin_Phone", admin.AdminPhone);
                command.Parameters.AddWithValue("@Admin_Address", admin.AdminAddress);
                command.Parameters.AddWithValue("@Admin_Birth", admin.AdminBirth);
                command.Parameters.AddWithValue("@Admin_Sex", admin.AdminSex);
                command.Parameters.AddWithValue("@Admin_NickYahoo", admin.AdminNickYahoo);
                command.Parameters.AddWithValue("@Admin_NickSkype", admin.AdminNickSkype);
                command.Parameters.AddWithValue("@Admin_Avatar", admin.AdminAvatar);
                command.Parameters.AddWithValue("@Admin_LoginType", admin.AdminLoginType);
                connection.Open();
                if (command.ExecuteNonQuery() <= 0)
                {
                    throw new DataAccessException("Lỗi kh\x00f4ng thể cập nhật");
                }
                command.Dispose();
            }
        }

        public void UpdateAdminLog(string name, DateTime log)
        {
            using (SqlConnection connection = base.GetConnection())
            {
                SqlCommand command = new SqlCommand("_AdminUpdateLog", connection) {
                    CommandType = CommandType.StoredProcedure
                };
                command.Parameters.AddWithValue("@Admin_Username", name);
                command.Parameters.AddWithValue("@Admin_Log", log);
                connection.Open();
                if (command.ExecuteNonQuery() <= 0)
                {
                    throw new DataAccessException("Lỗi kh\x00f4ng thể cập nhật");
                }
                command.Dispose();
            }
        }
    }
}

