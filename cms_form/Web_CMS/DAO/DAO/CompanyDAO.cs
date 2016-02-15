namespace DAO
{
    using ETO;
    using System;
    using System.Data;
    using System.Data.SqlClient;

    public class CompanyDAO : BaseDAO
    {
        public void CompanyClickUpdate(int nId)
        {
            using (SqlConnection connection = base.GetConnection())
            {
                SqlCommand command = new SqlCommand("_CompanyClickUpdate", connection) {
                    CommandType = CommandType.StoredProcedure
                };
                command.Parameters.AddWithValue("@CompanyID", nId);
                connection.Open();
                if (command.ExecuteNonQuery() <= 0)
                {
                    throw new DataAccessException("Kh\x00f4ng thể cập nhật số lần click");
                }
                command.Dispose();
            }
        }

        public DataTable CompanyFollow(int Id, int cId)
        {
            DataTable datatable = new DataTable();
            using (SqlConnection connection = base.GetConnection())
            {
                string SQL = "SELECT * FROM tblCompany WHERE Categories = @Categories And CompanyID < " + Id + " ORDER BY CompanyID DESC";
                SqlCommand command = new SqlCommand(SQL, connection) {
                    CommandText = SQL
                };
                command.Parameters.AddWithValue("@Categories", cId);
                connection.Open();
                using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                {
                    adapter.Fill(datatable);
                    command.Dispose();
                }
            }
            return datatable;
        }

        public DataTable CompanyFollow(int Id, int cId, int n)
        {
            DataTable datatable = new DataTable();
            using (SqlConnection connection = base.GetConnection())
            {
                string SQL = string.Concat(new object[] { "SELECT Top ", n, " * FROM tblCompany WHERE Categories = @Categories And CompanyID < ", Id, " ORDER BY CompanyID DESC" });
                SqlCommand command = new SqlCommand(SQL, connection) {
                    CommandText = SQL
                };
                command.Parameters.AddWithValue("@Categories", cId);
                connection.Open();
                using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                {
                    adapter.Fill(datatable);
                    command.Dispose();
                }
            }
            return datatable;
        }

        public DataTable CompanyFollow(int Id, int cId, int n, int groupCate)
        {
            DataTable datatable = new DataTable();
            using (SqlConnection connection = base.GetConnection())
            {
                string SQL = string.Concat(new object[] { "SELECT Top ", n, " * FROM tblCompany WHERE Categories = @Categories And CompanyID < ", Id, " And GroupCate = ", groupCate, " ORDER BY CompanyID DESC" });
                SqlCommand command = new SqlCommand(SQL, connection) {
                    CommandText = SQL
                };
                command.Parameters.AddWithValue("@Categories", cId);
                connection.Open();
                using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                {
                    adapter.Fill(datatable);
                    command.Dispose();
                }
            }
            return datatable;
        }

        private Company CompanyReader(SqlDataReader reader)
        {
            return new Company { 
                CompanyID = (int) reader["CompanyID"], Categories = (int) reader["Categories"], Title = (string) reader["Title"], Description = (string) reader["Description"], Author = (string) reader["Author"], IsNormal = (bool) reader["IsNormal"], IsHot = (bool) reader["IsHot"], IsDefault = (bool) reader["IsDefault"], Language = (string) reader["Language"], IsComment = (bool) reader["IsComment"], ApprovalDate = (DateTime) reader["ApprovalDate"], ApprovalUserName = (string) reader["ApprovalUserName"], IsApproval = (bool) reader["IsApproval"], CreatedUserName = (string) reader["CreatedUserName"], CommentTotal = (int) reader["CommentTotal"], VisitTotal = (int) reader["VisitTotal"], 
                CreatedDate = (DateTime) reader["CreatedDate"], GroupCate = (int) reader["GroupCate"]
             };
        }

        public DataTable CompanySearch(string keyword, int cateid, string lang)
        {
            DataTable datatable = new DataTable();
            using (SqlConnection connection = base.GetConnection())
            {
                SqlCommand command = new SqlCommand("_CompanySearch", connection) {
                    CommandType = CommandType.StoredProcedure
                };
                command.Parameters.AddWithValue("@Keyword", keyword);
                command.Parameters.AddWithValue("@Categories", cateid);
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

        public DataTable CompanySearchCate(int cateid, string lang)
        {
            DataTable datatable = new DataTable();
            using (SqlConnection connection = base.GetConnection())
            {
                SqlCommand command = new SqlCommand("_CompanySearchCate", connection) {
                    CommandType = CommandType.StoredProcedure
                };
                command.Parameters.AddWithValue("@Categories", cateid);
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

        public void CreateCompany(Company company)
        {
            using (SqlConnection connection = base.GetConnection())
            {
                SqlCommand command = new SqlCommand("_CompanyUpdate", connection) {
                    CommandType = CommandType.StoredProcedure
                };
                command.Parameters.AddWithValue("@Type", 0);
                command.Parameters.AddWithValue("@CompanyID", 0);
                command.Parameters.AddWithValue("@Categories", company.Categories);
                command.Parameters.AddWithValue("@Title", company.Title);
                command.Parameters.AddWithValue("@Description", company.Description);
                command.Parameters.AddWithValue("@Author", company.Author);
                command.Parameters.AddWithValue("@IsNormal", company.IsNormal);
                command.Parameters.AddWithValue("@IsHot", company.IsHot);
                command.Parameters.AddWithValue("@IsDefault", company.IsDefault);
                command.Parameters.AddWithValue("@Language", company.Language);
                command.Parameters.AddWithValue("@IsComment", company.IsComment);
                command.Parameters.AddWithValue("@ApprovalDate", company.ApprovalDate);
                command.Parameters.AddWithValue("@ApprovalUserName", company.ApprovalUserName);
                command.Parameters.AddWithValue("@IsApproval", company.IsApproval);
                command.Parameters.AddWithValue("@CreatedUserName", company.CreatedUserName);
                command.Parameters.AddWithValue("@CommentTotal", company.CommentTotal);
                command.Parameters.AddWithValue("@VisitTotal", company.VisitTotal);
                command.Parameters.AddWithValue("@CreatedDate", company.CreatedDate);
                command.Parameters.AddWithValue("@GroupCate", company.GroupCate);
                connection.Open();
                if (command.ExecuteNonQuery() <= 0)
                {
                    throw new DataAccessException("Khong them moi duoc company");
                }
                command.Dispose();
            }
        }

        public void DeleteCompany(int Id)
        {
            using (SqlConnection connection = base.GetConnection())
            {
                SqlCommand command = new SqlCommand("_CompanyDelete", connection) {
                    CommandType = CommandType.StoredProcedure
                };
                command.Parameters.AddWithValue("@CompanyID", Id);
                connection.Open();
                if (command.ExecuteNonQuery() <= 0)
                {
                    throw new DataAccessException("Khong xoa duoc company");
                }
                command.Dispose();
            }
        }

        public void DeleteCompany(string sId)
        {
            using (SqlConnection connection = base.GetConnection())
            {
                string SQL = "delete tblCompany where CompanyID in('" + sId + "')";
                SqlCommand command = new SqlCommand(SQL, connection) {
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

        public DataTable GetCompanyAll(string lang)
        {
            DataTable datatable = new DataTable();
            using (SqlConnection connection = base.GetConnection())
            {
                SqlCommand command = new SqlCommand("_CompanyGetAll", connection) {
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

        public DataTable GetCompanyAll(string lang, int group)
        {
            DataTable datatable = new DataTable();
            using (SqlConnection connection = base.GetConnection())
            {
                string SQL = "select * from tblCompany where Language = @Language and GroupCate =" + group + " order by CompanyID Desc";
                SqlCommand command = new SqlCommand(SQL, connection) {
                    CommandText = SQL
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

        public DataTable GetCompanyAll(string lang, int group, int n)
        {
            DataTable datatable = new DataTable();
            using (SqlConnection connection = base.GetConnection())
            {
                string SQL = string.Concat(new object[] { "select top ", n, " * from tblCompany where Language = @Language and GroupCate =", group, " order by CompanyID Desc" });
                SqlCommand command = new SqlCommand(SQL, connection) {
                    CommandText = SQL
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

        public DataTable GetCompanyByCate(int cId)
        {
            DataTable datatable = new DataTable();
            using (SqlConnection connection = base.GetConnection())
            {
                SqlCommand command = new SqlCommand("_CompanyGetByCate", connection) {
                    CommandType = CommandType.StoredProcedure
                };
                command.Parameters.AddWithValue("@Categories", cId);
                connection.Open();
                using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                {
                    adapter.Fill(datatable);
                    command.Dispose();
                }
            }
            return datatable;
        }

        public DataTable GetCompanyByCateHomeList(string strCate)
        {
            DataTable datatable = new DataTable();
            using (SqlConnection connection = base.GetConnection())
            {
                string SQL = "select * from tblCompany where Categories in('" + strCate + "') order by CompanyID Desc";
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

        public DataTable GetCompanyByCateHomeList(int group, string strCate)
        {
            DataTable datatable = new DataTable();
            using (SqlConnection connection = base.GetConnection())
            {
                string SQL = string.Concat(new object[] { "select * from tblCompany where Categories in('", strCate, "') and GroupCate = ", group, " order by CompanyID Desc" });
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

        public DataTable GetCompanyByCateHomeList(string strCate, int num)
        {
            DataTable datatable = new DataTable();
            using (SqlConnection connection = base.GetConnection())
            {
                string SQL = "select top " + Convert.ToString(num) + " * from tblCompany where Categories in('" + strCate + "') order by CompanyID Desc";
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

        public DataTable GetCompanyByCateHomeList(string strCate, int num, int group)
        {
            DataTable datatable = new DataTable();
            using (SqlConnection connection = base.GetConnection())
            {
                string SQL = string.Concat(new object[] { "select top ", Convert.ToString(num), " * from tblCompany where Categories in('", strCate, "') and GroupCate = ", group, " order by CompanyID Desc" });
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

        public Company GetCompanyById(int Id)
        {
            Company company = null;
            using (SqlConnection connection = base.GetConnection())
            {
                SqlCommand command = new SqlCommand("_CompanyGetById", connection) {
                    CommandType = CommandType.StoredProcedure
                };
                command.Parameters.AddWithValue("@CompanyID", Id);
                connection.Open();
                using (SqlDataReader reader = command.ExecuteReader(CommandBehavior.CloseConnection))
                {
                    if (!reader.Read())
                    {
                        throw new DataAccessException("Khong tim thay gia tri nao");
                    }
                    company = this.CompanyReader(reader);
                    command.Dispose();
                }
            }
            return company;
        }

        public DataTable GetCompanyDefault(string lang)
        {
            DataTable datatable = new DataTable();
            using (SqlConnection connection = base.GetConnection())
            {
                SqlCommand command = new SqlCommand("_CompanyDefault", connection) {
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

        public DataTable GetCompanyDefault(string lang, int group)
        {
            DataTable datatable = new DataTable();
            using (SqlConnection connection = base.GetConnection())
            {
                SqlCommand command = new SqlCommand("_CompanyDefaultGroup", connection) {
                    CommandType = CommandType.StoredProcedure
                };
                command.Parameters.AddWithValue("@Language", lang);
                command.Parameters.AddWithValue("@GroupCate", group);
                connection.Open();
                using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                {
                    adapter.Fill(datatable);
                    command.Dispose();
                }
            }
            return datatable;
        }

        public DataTable GetCompanyHot(string lang)
        {
            DataTable datatable = new DataTable();
            using (SqlConnection connection = base.GetConnection())
            {
                SqlCommand command = new SqlCommand("_CompanyHot", connection) {
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

        public DataTable GetCompanyHot(string lang, int n)
        {
            DataTable datatable = new DataTable();
            using (SqlConnection connection = base.GetConnection())
            {
                string SQL = "SELECT Top " + n + " * FROM tblCompany WHERE [Language] = @Language AND IsHot=1 And IsNormal=1 ORDER BY CompanyID DESC";
                SqlCommand command = new SqlCommand(SQL, connection) {
                    CommandText = SQL
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

        public DataTable GetCompanyHot(string lang, int n, int groupcate)
        {
            DataTable datatable = new DataTable();
            using (SqlConnection connection = base.GetConnection())
            {
                string SQL = string.Concat(new object[] { "SELECT Top ", n, " * FROM tblCompany WHERE [Language] = @Language AND IsHot=1 And IsNormal=1 And GroupCate = ", groupcate, " ORDER BY CompanyID DESC" });
                SqlCommand command = new SqlCommand(SQL, connection) {
                    CommandText = SQL
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

        public DataTable GetCompanyTop10(string lang)
        {
            DataTable datatable = new DataTable();
            using (SqlConnection connection = base.GetConnection())
            {
                SqlCommand command = new SqlCommand("_CompanyGetTop10", connection) {
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

        public DataTable GetCompanyTop5(string lang)
        {
            DataTable datatable = new DataTable();
            using (SqlConnection connection = base.GetConnection())
            {
                SqlCommand command = new SqlCommand("_CompanyGetTop5", connection) {
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

        public void UpdateCompany(Company company)
        {
            using (SqlConnection connection = base.GetConnection())
            {
                SqlCommand command = new SqlCommand("_CompanyUpdate", connection) {
                    CommandType = CommandType.StoredProcedure
                };
                command.Parameters.AddWithValue("@Type", 1);
                command.Parameters.AddWithValue("@CompanyID", company.CompanyID);
                command.Parameters.AddWithValue("@Categories", company.Categories);
                command.Parameters.AddWithValue("@Title", company.Title);
                command.Parameters.AddWithValue("@Description", company.Description);
                command.Parameters.AddWithValue("@Author", company.Author);
                command.Parameters.AddWithValue("@IsNormal", company.IsNormal);
                command.Parameters.AddWithValue("@IsHot", company.IsHot);
                command.Parameters.AddWithValue("@IsDefault", company.IsDefault);
                command.Parameters.AddWithValue("@Language", company.Language);
                command.Parameters.AddWithValue("@IsComment", company.IsComment);
                command.Parameters.AddWithValue("@ApprovalDate", company.ApprovalDate);
                command.Parameters.AddWithValue("@ApprovalUserName", company.ApprovalUserName);
                command.Parameters.AddWithValue("@IsApproval", company.IsApproval);
                command.Parameters.AddWithValue("@CreatedUserName", company.CreatedUserName);
                command.Parameters.AddWithValue("@CommentTotal", company.CommentTotal);
                command.Parameters.AddWithValue("@VisitTotal", company.VisitTotal);
                command.Parameters.AddWithValue("@CreatedDate", company.CreatedDate);
                command.Parameters.AddWithValue("@GroupCate", company.GroupCate);
                connection.Open();
                if (command.ExecuteNonQuery() <= 0)
                {
                    throw new DataAccessException("Khong cap nhat duoc company");
                }
                command.Dispose();
            }
        }

        public void UpdateCompany(string strId, string value)
        {
            using (SqlConnection connection = base.GetConnection())
            {
                string SQL = "update tblCompany set IsNormal =" + value + " where CompanyID in('" + strId + "')";
                SqlCommand command = new SqlCommand(SQL, connection) {
                    CommandText = SQL
                };
                connection.Open();
                if (command.ExecuteNonQuery() <= 0)
                {
                    throw new DataAccessException("khong the cap nhat");
                }
                command.Dispose();
            }
        }

        public void UpdateCompany(int Id, string value, string username, DateTime date)
        {
            using (SqlConnection connection = base.GetConnection())
            {
                string SQL = "update tblCompany set IsApproval = " + value + ", ApprovalUserName = '" + username + "',ApprovalDate = @Date  where CompanyID = @CompanyID";
                SqlCommand command = new SqlCommand(SQL, connection) {
                    CommandText = SQL
                };
                command.Parameters.AddWithValue("@Date", date);
                command.Parameters.AddWithValue("@CompanyID", Id);
                connection.Open();
                if (command.ExecuteNonQuery() <= 0)
                {
                    throw new DataAccessException("Kh\x00f4ng cập nhật được tin n\x00e0o");
                }
                command.Dispose();
            }
        }

        public void UpdateCompany(string strId, string value, string username, DateTime date)
        {
            using (SqlConnection connection = base.GetConnection())
            {
                string SQL = "update tblCompany set IsApproval =" + value + ", ApprovalUserName = '" + username + "',ApprovalDate = @Date where CompanyID in('" + strId + "')";
                SqlCommand command = new SqlCommand(SQL, connection) {
                    CommandText = SQL
                };
                command.Parameters.AddWithValue("@Date", date);
                connection.Open();
                if (command.ExecuteNonQuery() <= 0)
                {
                    throw new DataAccessException("khong the cap nhat");
                }
                command.Dispose();
            }
        }

        public void UpdateSetDefault(int Id)
        {
            using (SqlConnection connection = base.GetConnection())
            {
                string SQL = "update tblCompany set IsDefault = 1 where CompanyID = @CompanyID";
                SqlCommand command = new SqlCommand(SQL, connection) {
                    CommandText = SQL
                };
                command.Parameters.AddWithValue("@CompanyID", Id);
                connection.Open();
                if (command.ExecuteNonQuery() <= 0)
                {
                    throw new DataAccessException("Kh\x00f4ng cập nhật được tin n\x00e0o");
                }
                command.Dispose();
            }
        }

        public void UpdateSetDefault(int Id, int group)
        {
            using (SqlConnection connection = base.GetConnection())
            {
                string SQL = "update tblCompany set IsDefault = 1 where CompanyID = @CompanyID and GroupCate = @Groupcate";
                SqlCommand command = new SqlCommand(SQL, connection) {
                    CommandText = SQL
                };
                command.Parameters.AddWithValue("@CompanyID", Id);
                command.Parameters.AddWithValue("@GroupCate", group);
                connection.Open();
                if (command.ExecuteNonQuery() <= 0)
                {
                    throw new DataAccessException("Kh\x00f4ng cập nhật được tin n\x00e0o");
                }
                command.Dispose();
            }
        }

        public void UpdateSetNotDefault(int Id)
        {
            using (SqlConnection connection = base.GetConnection())
            {
                string SQL = "update tblCompany set IsDefault = 0 where CompanyID <> @CompanyID";
                SqlCommand command = new SqlCommand(SQL, connection) {
                    CommandText = SQL
                };
                command.Parameters.AddWithValue("@CompanyID", Id);
                connection.Open();
                if (command.ExecuteNonQuery() <= 0)
                {
                    throw new DataAccessException("Kh\x00f4ng cập nhật được tin n\x00e0o");
                }
                command.Dispose();
            }
        }

        public void UpdateSetNotDefault(int Id, int group)
        {
            using (SqlConnection connection = base.GetConnection())
            {
                string SQL = "update tblCompany set IsDefault = 0 where CompanyID <> @CompanyID and GroupCate = @GroupCate";
                SqlCommand command = new SqlCommand(SQL, connection) {
                    CommandText = SQL
                };
                command.Parameters.AddWithValue("@CompanyID", Id);
                command.Parameters.AddWithValue("@GroupCate", group);
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

