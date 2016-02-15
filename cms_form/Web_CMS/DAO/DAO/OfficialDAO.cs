namespace DAO
{
    using ETO;
    using System;
    using System.Data;
    using System.Data.SqlClient;

    public class OfficialDAO : BaseDAO
    {
        public void CreateOfficial(Official official)
        {
            using (SqlConnection connection = base.GetConnection())
            {
                SqlCommand command = new SqlCommand("_OfficialUpdate", connection) {
                    CommandType = CommandType.StoredProcedure
                };
                command.Parameters.AddWithValue("@Type", 0);
                command.Parameters.AddWithValue("@OfficialID", 0);
                command.Parameters.AddWithValue("@CateOfficialID", official.CateOfficialID);
                command.Parameters.AddWithValue("@NoCode", official.NoCode);
                command.Parameters.AddWithValue("@OfficialName", official.OfficialName);
                command.Parameters.AddWithValue("@DatePublic", official.DatePublic);
                command.Parameters.AddWithValue("@Company", official.Company);
                command.Parameters.AddWithValue("@Classify", official.Classify);
                command.Parameters.AddWithValue("@Writer", official.Writer);
                command.Parameters.AddWithValue("@Quote", official.Quote);
                command.Parameters.AddWithValue("@KeyShort", official.KeyShort);
                command.Parameters.AddWithValue("@Attached", official.Attached);
                command.Parameters.AddWithValue("@Status", official.Status);
                command.Parameters.AddWithValue("@ApprovalDate", official.ApprovalDate);
                command.Parameters.AddWithValue("@ApprovalUserName", official.ApprovalUserName);
                command.Parameters.AddWithValue("@IsApproval", official.IsApproval);
                command.Parameters.AddWithValue("@CreatedUserName", official.CreatedUserName);
                command.Parameters.AddWithValue("@CreatedDate", official.CreatedDate);
                connection.Open();
                if (command.ExecuteNonQuery() <= 0)
                {
                    throw new DataAccessException("Khong them moi duoc official");
                }
                command.Dispose();
            }
        }

        public void DeleteOfficial(int Id)
        {
            using (SqlConnection connection = base.GetConnection())
            {
                SqlCommand command = new SqlCommand("_OfficialDelete", connection) {
                    CommandType = CommandType.StoredProcedure
                };
                command.Parameters.AddWithValue("@OfficialID", Id);
                connection.Open();
                if (command.ExecuteNonQuery() <= 0)
                {
                    throw new DataAccessException("Khong xoa duoc official");
                }
                command.Dispose();
            }
        }

        public void DeleteOfficial(string sId)
        {
            using (SqlConnection connection = base.GetConnection())
            {
                string SQL = "delete tblOfficial where NewsGroupID in('" + sId + "')";
                SqlCommand command = new SqlCommand(SQL, connection)
                {
                    CommandText = SQL
                };
                connection.Open();
                if (command.ExecuteNonQuery() <= 0)
                {
                    throw new DataAccessException("Kh\x00f4ng x\x00f3a được tin");
                }
                command.Dispose();
            }
        }

        public DataTable GetOfficialAll()
        {
            DataTable datatable = new DataTable();
            using (SqlConnection connection = base.GetConnection())
            {
                SqlCommand command = new SqlCommand("_OfficialGetAll", connection) {
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

        public DataTable GetOfficialByCateHomeList(string strCate)
        {
            DataTable datatable = new DataTable();
            using (SqlConnection connection = base.GetConnection())
            {
                string SQL = "select * from tblOfficial where CateNewsID in('" + strCate + "') order by NewsGroupID Desc";
                SqlCommand command = new SqlCommand(SQL, connection)
                {
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

        public DataTable GetOfficialByCateHomeList(string strCate, int num)
        {
            DataTable datatable = new DataTable();
            using (SqlConnection connection = base.GetConnection())
            {
                string SQL = "select top " + Convert.ToString(num) + " * from tblOfficial where CateNewsID in('" + strCate + "') order by NewsGroupID Desc";
                SqlCommand command = new SqlCommand(SQL, connection)
                {
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

        public DataTable GetOfficialByCateHomeList(string strCate, int num, string approval)
        {
            DataTable datatable = new DataTable();
            using (SqlConnection connection = base.GetConnection())
            {
                string SQL = "select top " + Convert.ToString(num) + " * from tblOfficial where CateOfficialID in('" + strCate + "') AND status=1 AND IsApproval = " + approval + " order by OfficialID Desc";
                SqlCommand command = new SqlCommand(SQL, connection)
                {
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

        public Official GetOfficialById(int Id)
        {
            Official official = null;
            using (SqlConnection connection = base.GetConnection())
            {
                SqlCommand command = new SqlCommand("_OfficialGetById", connection) {
                    CommandType = CommandType.StoredProcedure
                };
                command.Parameters.AddWithValue("@OfficialID", Id);
                connection.Open();
                using (SqlDataReader reader = command.ExecuteReader(CommandBehavior.CloseConnection))
                {
                    if (!reader.Read())
                    {
                        throw new DataAccessException("Khong tim thay gia tri nao");
                    }
                    official = this.OfficialReader(reader);
                    command.Dispose();
                }
            }
            return official;
        }

        public DataTable GetOfficialNews(int num)
        {
            DataTable datatable = new DataTable();
            using (SqlConnection connection = base.GetConnection())
            {
                string SQL = "select top " + Convert.ToString(num) + " * from tblOfficial order by NewsGroupID Desc";
                SqlCommand command = new SqlCommand(SQL, connection)
                {
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

        public DataTable GetOfficialNews(int num, string approval)
        {
            DataTable datatable = new DataTable();
            using (SqlConnection connection = base.GetConnection())
            {
                string SQL = "select top " + Convert.ToString(num) + " * from tblOfficial Where status = 1 AND IsApproval = " + approval + " order by OfficialID Desc";
                SqlCommand command = new SqlCommand(SQL, connection)
                {
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

        public void OfficialClickUpdate(int nId)
        {
            using (SqlConnection connection = base.GetConnection())
            {
                SqlCommand command = new SqlCommand("_OfficialClickUpdate", connection) {
                    CommandType = CommandType.StoredProcedure
                };
                command.Parameters.AddWithValue("@OfficialID", nId);
                connection.Open();
                if (command.ExecuteNonQuery() <= 0)
                {
                    throw new DataAccessException("Kh\x00f4ng thể cập nhật số lần click");
                }
                command.Dispose();
            }
        }

        private Official OfficialReader(SqlDataReader reader)
        {
            return new Official { 
                OfficialID = (int) reader["OfficialID"], CateOfficialID = (int) reader["CateOfficialID"], NoCode = (string) reader["NoCode"], OfficialName = (string) reader["OfficialName"], DatePublic = (DateTime) reader["DatePublic"], Company = (string) reader["Company"], Classify = (string) reader["Classify"], Writer = (string) reader["Writer"], Quote = (string) reader["Quote"], KeyShort = (string) reader["KeyShort"], Attached = (string) reader["Attached"], Status = (bool) reader["Status"], ApprovalDate = (DateTime) reader["ApprovalDate"], ApprovalUserName = (string) reader["ApprovalUserName"], IsApproval = (bool) reader["IsApproval"], CreatedUserName = (string) reader["CreatedUserName"], 
                CreatedDate = (DateTime) reader["CreatedDate"]
             };
        }

        public DataTable OfficialSearch(string keyword, int cateid, string lang)
        {
            DataTable datatable = new DataTable();
            using (SqlConnection connection = base.GetConnection())
            {
                SqlCommand command = new SqlCommand("_OfficialSearch", connection) {
                    CommandType = CommandType.StoredProcedure
                };
                command.Parameters.AddWithValue("@Keyword", keyword);
                command.Parameters.AddWithValue("@CateNewsID", cateid);
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

        public void UpdateOfficial(Official official)
        {
            using (SqlConnection connection = base.GetConnection())
            {
                SqlCommand command = new SqlCommand("_OfficialUpdate", connection) {
                    CommandType = CommandType.StoredProcedure
                };
                command.Parameters.AddWithValue("@Type", 1);
                command.Parameters.AddWithValue("@OfficialID", official.OfficialID);
                command.Parameters.AddWithValue("@CateOfficialID", official.CateOfficialID);
                command.Parameters.AddWithValue("@NoCode", official.NoCode);
                command.Parameters.AddWithValue("@OfficialName", official.OfficialName);
                command.Parameters.AddWithValue("@DatePublic", official.DatePublic);
                command.Parameters.AddWithValue("@Company", official.Company);
                command.Parameters.AddWithValue("@Classify", official.Classify);
                command.Parameters.AddWithValue("@Writer", official.Writer);
                command.Parameters.AddWithValue("@Quote", official.Quote);
                command.Parameters.AddWithValue("@KeyShort", official.KeyShort);
                command.Parameters.AddWithValue("@Attached", official.Attached);
                command.Parameters.AddWithValue("@Status", official.Status);
                command.Parameters.AddWithValue("@ApprovalDate", official.ApprovalDate);
                command.Parameters.AddWithValue("@ApprovalUserName", official.ApprovalUserName);
                command.Parameters.AddWithValue("@IsApproval", official.IsApproval);
                command.Parameters.AddWithValue("@CreatedUserName", official.CreatedUserName);
                command.Parameters.AddWithValue("@CreatedDate", official.CreatedDate);
                connection.Open();
                if (command.ExecuteNonQuery() <= 0)
                {
                    throw new DataAccessException("Khong cap nhat duoc official");
                }
                command.Dispose();
            }
        }

        public void UpdateOfficial(string strId, string value)
        {
            using (SqlConnection connection = base.GetConnection())
            {
                string SQL = "update tblOfficial set Status = " + value + " where NewsGroupID in('" + strId + "')";
                SqlCommand command = new SqlCommand(SQL, connection)
                {
                    CommandText = SQL
                };
                connection.Open();
                if (command.ExecuteNonQuery() <= 0)
                {
                    throw new DataAccessException("Kh\x00f4ng cập nhật được tin n\x00e0o");
                }
                command.Dispose();
            }
        }

        public void UpdateOfficial(int Id, string value, string username, DateTime date)
        {
            using (SqlConnection connection = base.GetConnection())
            {
                string SQL = "update tblOfficial set IsApproval = " + value + ", ApprovalUserName = '" + username + "',ApprovalDate = @PostDate  where NewsGroupID = @NewsGroupID";
                SqlCommand command = new SqlCommand(SQL, connection)
                {
                    CommandText = SQL
                };
                command.Parameters.AddWithValue("@PostDate", date);
                command.Parameters.AddWithValue("@NewsGroupID", Id);
                connection.Open();
                if (command.ExecuteNonQuery() <= 0)
                {
                    throw new DataAccessException("Kh\x00f4ng cập nhật được tin n\x00e0o");
                }
                command.Dispose();
            }
        }

        public void UpdateOfficial(string strId, string value, string username, DateTime date)
        {
            using (SqlConnection connection = base.GetConnection())
            {
                string SQL = "update tblOfficial set IsApproval = " + value + ", ApprovalUserName = '" + username + "',ApprovalDate = @PostDate  where NewsGroupID in('" + strId + "')";
                SqlCommand command = new SqlCommand(SQL, connection)
                {
                    CommandText = SQL
                };
                command.Parameters.AddWithValue("@PostDate", date);
                connection.Open();
                if (command.ExecuteNonQuery() <= 0)
                {
                    throw new DataAccessException("Kh\x00f4ng cập nhật được tin n\x00e0o");
                }
                command.Dispose();
            }
        }
    }
}

