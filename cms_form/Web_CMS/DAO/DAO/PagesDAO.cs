namespace DAO
{
    using ETO;
    using System;
    using System.Data;
    using System.Data.SqlClient;

    public class PagesDAO : BaseDAO
    {
        public void DeletePages(int Id)
        {
            using (SqlConnection connection = base.GetConnection())
            {
                SqlCommand command = new SqlCommand("_PageDelete", connection) {
                    CommandType = CommandType.StoredProcedure
                };
                command.Parameters.AddWithValue("@PageID", Id);
                connection.Open();
                if (command.ExecuteNonQuery() <= 0)
                {
                    throw new DataAccessException("khong the xoa pages");
                }
                command.Dispose();
            }
        }

        public void DeletePages(string strId)
        {
            using (SqlConnection connection = base.GetConnection())
            {
                string SQL = "delete tblPage where PageID in('" + strId + "')";
                SqlCommand command = new SqlCommand(SQL, connection) {
                    CommandText = SQL
                };
                connection.Open();
                if (command.ExecuteNonQuery() <= 0)
                {
                    throw new DataAccessException("khong the xoa pages");
                }
                command.Dispose();
            }
        }

        public DataTable GetAllPages(string lang)
        {
            DataTable datatable = new DataTable();
            using (SqlConnection connection = base.GetConnection())
            {
                SqlCommand command = new SqlCommand("_PageGet", connection) {
                    CommandType = CommandType.StoredProcedure
                };
                command.Parameters.AddWithValue("@Get", 2);
                command.Parameters.AddWithValue("@PageID", 0);
                command.Parameters.AddWithValue("@PageName", "");
                command.Parameters.AddWithValue("@Language", lang);
                connection.Open();
                using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                {
                    adapter.Fill(datatable);
                    command.Dispose();
                }
                return datatable;
            }
        }

        public Pages GetPagesById(int Id)
        {
            Pages pages = null;
            using (SqlConnection connection = base.GetConnection())
            {
                SqlCommand command = new SqlCommand("_PageGet", connection) {
                    CommandType = CommandType.StoredProcedure
                };
                command.Parameters.AddWithValue("@Get", 1);
                command.Parameters.AddWithValue("@PageID", Id);
                command.Parameters.AddWithValue("@PageName", "");
                command.Parameters.AddWithValue("@Language", "");
                connection.Open();
                using (SqlDataReader reader = command.ExecuteReader(CommandBehavior.CloseConnection))
                {
                    if (!reader.Read())
                    {
                        throw new DataAccessException("khong co gia tri nao");
                    }
                    pages = this.PagesReader(reader);
                    command.Dispose();
                }
                return pages;
            }
        }

        public DataTable GetPagesByName(string pagename)
        {
            DataTable table = new DataTable();
            using (SqlConnection connection = base.GetConnection())
            {
                SqlCommand command = new SqlCommand("_PageGet", connection) {
                    CommandType = CommandType.StoredProcedure
                };
                command.Parameters.AddWithValue("@Get", 0);
                command.Parameters.AddWithValue("@PageID", 0);
                command.Parameters.AddWithValue("@PageName", pagename);
                command.Parameters.AddWithValue("@Language", "");
                connection.Open();
                using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                {
                    adapter.Fill(table);
                    command.Dispose();
                }
                return table;
            }
        }

        public DataTable GetPagesCate(string lang)
        {
            DataTable table = new DataTable();
            using (SqlConnection connection = base.GetConnection())
            {
                SqlCommand command = new SqlCommand("_PageGetCate", connection) {
                    CommandType = CommandType.StoredProcedure
                };
                command.Parameters.AddWithValue("@Language", lang);
                connection.Open();
                using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                {
                    adapter.Fill(table);
                    command.Dispose();
                }
                return table;
            }
        }

        public Pages GetPagesGroupTop1(int Group, string lang)
        {
            Pages pages = null;
            using (SqlConnection connection = base.GetConnection())
            {
                SqlCommand command = new SqlCommand("_PageGetGroupArticle1", connection) {
                    CommandType = CommandType.StoredProcedure
                };
                command.Parameters.AddWithValue("@Group", Group);
                command.Parameters.AddWithValue("@Language", lang);
                connection.Open();
                using (SqlDataReader reader = command.ExecuteReader(CommandBehavior.CloseConnection))
                {
                    if (!reader.Read())
                    {
                        throw new DataAccessException("khong co gia tri nao");
                    }
                    pages = this.PagesReader(reader);
                    command.Dispose();
                }
                return pages;
            }
        }

        public void PageClickUpdate(int nId)
        {
            using (SqlConnection connection = base.GetConnection())
            {
                SqlCommand command = new SqlCommand("_PageClickUpdate", connection) {
                    CommandType = CommandType.StoredProcedure
                };
                command.Parameters.AddWithValue("@PageID", nId);
                connection.Open();
                if (command.ExecuteNonQuery() <= 0)
                {
                    throw new DataAccessException("Kh\x00f4ng thể cập nhật số lần click");
                }
                command.Dispose();
            }
        }

        public DataTable PageFollow(int Id, string cId)
        {
            DataTable datatable = new DataTable();
            using (SqlConnection connection = base.GetConnection())
            {
                SqlCommand command = new SqlCommand("_PageFollow", connection) {
                    CommandType = CommandType.StoredProcedure
                };
                command.Parameters.AddWithValue("@PageID", Id);
                command.Parameters.AddWithValue("@PageName", cId);
                connection.Open();
                using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                {
                    adapter.Fill(datatable);
                    command.Dispose();
                }
            }
            return datatable;
        }

        public DataTable PageFollow(int Id, string cId, int n)
        {
            DataTable datatable = new DataTable();
            using (SqlConnection connection = base.GetConnection())
            {
                string SQL = string.Concat(new object[] { "SELECT Top ", Convert.ToString(n), " * FROM tblPage WHERE PageName = '", cId, "' AND PageID < ", Id, " ORDER BY PageID DESC" });
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

        public void PagesCreate(Pages pages)
        {
            using (SqlConnection connection = base.GetConnection())
            {
                SqlCommand command = new SqlCommand("_PageUpdate", connection) {
                    CommandType = CommandType.StoredProcedure
                };
                command.Parameters.AddWithValue("@Type", 0);
                command.Parameters.AddWithValue("@PageID", 0);
                command.Parameters.AddWithValue("@PageName", pages.PageName);
                command.Parameters.AddWithValue("@PageTitle", pages.PageTitle);
                command.Parameters.AddWithValue("@PageType", pages.PageType);
                command.Parameters.AddWithValue("@Imagethumb", pages.Imagethumb);
                command.Parameters.AddWithValue("@Describe", pages.Describe);
                command.Parameters.AddWithValue("@PageContent", pages.PageContent);
                command.Parameters.AddWithValue("@PostDate", pages.PostDate);
                command.Parameters.AddWithValue("@Author", pages.Author);
                command.Parameters.AddWithValue("@Status", pages.Status);
                command.Parameters.AddWithValue("@IsView", pages.IsView);
                command.Parameters.AddWithValue("@Language", pages.Language);
                command.Parameters.AddWithValue("@Icon", pages.Icon);
                command.Parameters.AddWithValue("@IsComment", pages.IsComment);
                command.Parameters.AddWithValue("@ApprovalDate", pages.ApprovalDate);
                command.Parameters.AddWithValue("@ApprovalUserName", pages.ApprovalUserName);
                command.Parameters.AddWithValue("@IsApproval", pages.IsApproval);
                command.Parameters.AddWithValue("@CreatedUserName", pages.CreatedUserName);
                command.Parameters.AddWithValue("@CommentTotal", pages.CommentTotal);
                command.Parameters.AddWithValue("@VisitTotal", pages.VisitTotal);
                command.Parameters.AddWithValue("@ParentPageID", pages.ParentPageID);
                connection.Open();
                if (command.ExecuteNonQuery() <= 0)
                {
                    throw new DataAccessException("Khong the tao moi");
                }
                command.Dispose();
            }
        }

        private Pages PagesReader(SqlDataReader reader)
        {
            return new Pages { 
                PageID = (int) reader["PageID"], PageName = (string) reader["PageName"], PageTitle = (string) reader["PageTitle"], PageType = (bool) reader["PageType"], Imagethumb = (string) reader["Imagethumb"], Describe = (string) reader["Describe"], PageContent = (string) reader["PageContent"], PostDate = (DateTime) reader["PostDate"], Author = (string) reader["Author"], Status = (bool) reader["Status"], IsView = (bool) reader["IsView"], Language = (string) reader["Language"], Icon = (string) reader["Icon"], IsComment = (bool) reader["IsComment"], ApprovalDate = (DateTime) reader["ApprovalDate"], ApprovalUserName = (string) reader["ApprovalUserName"], 
                IsApproval = (bool) reader["IsApproval"], CreatedUserName = (string) reader["CreatedUserName"], CommentTotal = (int) reader["CommentTotal"], VisitTotal = (int) reader["VisitTotal"], ParentPageID = (int) reader["ParentPageID"]
             };
        }

        public DataTable PagesSearch(string keyword, string lang)
        {
            DataTable datatable = new DataTable();
            using (SqlConnection connection = base.GetConnection())
            {
                SqlCommand command = new SqlCommand("_PageSearch", connection) {
                    CommandType = CommandType.StoredProcedure
                };
                command.Parameters.AddWithValue("@Keyword", keyword);
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

        public DataTable PagesSearch(string keyword, string CateID, string lang)
        {
            DataTable datatable = new DataTable();
            using (SqlConnection connection = base.GetConnection())
            {
                SqlCommand command = new SqlCommand("_PageSearch1", connection) {
                    CommandType = CommandType.StoredProcedure
                };
                command.Parameters.AddWithValue("@Icon", CateID);
                command.Parameters.AddWithValue("@Keyword", keyword);
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

        public DataTable PagesSearchCate(string CateID, string lang)
        {
            DataTable datatable = new DataTable();
            using (SqlConnection connection = base.GetConnection())
            {
                SqlCommand command = new SqlCommand("_PageSearchCate", connection) {
                    CommandType = CommandType.StoredProcedure
                };
                command.Parameters.AddWithValue("@Icon", CateID);
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

        public void PagesUpdate(Pages pages)
        {
            using (SqlConnection connection = base.GetConnection())
            {
                SqlCommand command = new SqlCommand("_PageUpdate", connection) {
                    CommandType = CommandType.StoredProcedure
                };
                command.Parameters.AddWithValue("@Type", 1);
                command.Parameters.AddWithValue("@PageID", pages.PageID);
                command.Parameters.AddWithValue("@PageName", pages.PageName);
                command.Parameters.AddWithValue("@PageTitle", pages.PageTitle);
                command.Parameters.AddWithValue("@PageType", pages.PageType);
                command.Parameters.AddWithValue("@Imagethumb", pages.Imagethumb);
                command.Parameters.AddWithValue("@Describe", pages.Describe);
                command.Parameters.AddWithValue("@PageContent", pages.PageContent);
                command.Parameters.AddWithValue("@PostDate", pages.PostDate);
                command.Parameters.AddWithValue("@Author", pages.Author);
                command.Parameters.AddWithValue("@Status", pages.Status);
                command.Parameters.AddWithValue("@IsView", pages.IsView);
                command.Parameters.AddWithValue("@Language", pages.Language);
                command.Parameters.AddWithValue("@Icon", pages.Icon);
                command.Parameters.AddWithValue("@IsComment", pages.IsComment);
                command.Parameters.AddWithValue("@ApprovalDate", pages.ApprovalDate);
                command.Parameters.AddWithValue("@ApprovalUserName", pages.ApprovalUserName);
                command.Parameters.AddWithValue("@IsApproval", pages.IsApproval);
                command.Parameters.AddWithValue("@CreatedUserName", pages.CreatedUserName);
                command.Parameters.AddWithValue("@CommentTotal", pages.CommentTotal);
                command.Parameters.AddWithValue("@VisitTotal", pages.VisitTotal);
                command.Parameters.AddWithValue("@ParentPageID", pages.ParentPageID);
                connection.Open();
                if (command.ExecuteNonQuery() <= 0)
                {
                    throw new DataAccessException("Khong the cap nhat");
                }
                command.Dispose();
            }
        }

        public void PagesUpdate(string strId, string value)
        {
            using (SqlConnection connection = base.GetConnection())
            {
                string SQL = "update tblPage set Status =" + value + " where PageID in('" + strId + "')";
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

        public void PagesUpdate(int Id, string value, string username, DateTime date)
        {
            using (SqlConnection connection = base.GetConnection())
            {
                string SQL = "update tblPage set IsApproval = " + value + ", ApprovalUserName = '" + username + "',ApprovalDate = @Date  where PageID = @PageID";
                SqlCommand command = new SqlCommand(SQL, connection) {
                    CommandText = SQL
                };
                command.Parameters.AddWithValue("@Date", date);
                command.Parameters.AddWithValue("@PageID", Id);
                connection.Open();
                if (command.ExecuteNonQuery() <= 0)
                {
                    throw new DataAccessException("Kh\x00f4ng cập nhật được tin n\x00e0o");
                }
                command.Dispose();
            }
        }

        public void PagesUpdate(string strId, string value, string username, DateTime date)
        {
            using (SqlConnection connection = base.GetConnection())
            {
                string SQL = "update tblPage set IsApproval =" + value + ", ApprovalUserName = '" + username + "',ApprovalDate = @Date where PageID in('" + strId + "')";
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
    }
}

