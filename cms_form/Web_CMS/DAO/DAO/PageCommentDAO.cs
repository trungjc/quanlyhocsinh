namespace DAO
{
    using ETO;
    using System;
    using System.Data;
    using System.Data.SqlClient;

    public class PageCommentDAO : BaseDAO
    {
        public void CreatePageComment(PageComment pageComment)
        {
            using (SqlConnection connection = base.GetConnection())
            {
                SqlCommand command = new SqlCommand("_PageCommentUpdate", connection) {
                    CommandType = CommandType.StoredProcedure
                };
                command.Parameters.AddWithValue("@Type", 0);
                command.Parameters.AddWithValue("@CommentPageID", 0);
                command.Parameters.AddWithValue("@PageID", pageComment.PageID);
                command.Parameters.AddWithValue("@FullName", pageComment.FullName);
                command.Parameters.AddWithValue("@Email", pageComment.Email);
                command.Parameters.AddWithValue("@Title", pageComment.Title);
                command.Parameters.AddWithValue("@Content", pageComment.Content);
                command.Parameters.AddWithValue("@DateCreated", pageComment.DateCreated);
                command.Parameters.AddWithValue("@Actived", pageComment.Actived);
                command.Parameters.AddWithValue("@GroupCate", pageComment.GroupCate);
                command.Parameters.AddWithValue("@ApprovalUserName", pageComment.ApprovalUserName);
                command.Parameters.AddWithValue("@ApprovalDate", pageComment.ApprovalDate);
                connection.Open();
                if (command.ExecuteNonQuery() <= 0)
                {
                    throw new DataAccessException("Lỗi kh\x00f4ng thể tao moi");
                }
                command.Dispose();
            }
        }

        public void DeletePageComment(int commentID)
        {
            using (SqlConnection connection = base.GetConnection())
            {
                SqlCommand command = new SqlCommand("_PageCommentDelete", connection) {
                    CommandType = CommandType.StoredProcedure
                };
                command.Parameters.AddWithValue("@CommentPageID", commentID);
                connection.Open();
                if (command.ExecuteNonQuery() <= 0)
                {
                    throw new DataAccessException("Kh\x00f4ng thể x\x00f3a pageComment");
                }
                command.Dispose();
            }
        }

        public void DeletePageComment(string strId)
        {
            using (SqlConnection connection = base.GetConnection())
            {
                string SQL = "delete tblPageComment where CommentPageID in('" + strId + "')";
                SqlCommand command = new SqlCommand(SQL, connection) {
                    CommandText = SQL
                };
                connection.Open();
                if (command.ExecuteNonQuery() <= 0)
                {
                    throw new DataAccessException("khong the xoa đ\x00e1nh gi\x00e1");
                }
                command.Dispose();
            }
        }

        public DataTable GetAllGroupCatePageComment(string group)
        {
            DataTable datatable = new DataTable();
            using (SqlConnection connection = base.GetConnection())
            {
                SqlCommand command = new SqlCommand("_PageCommentGroupCateGetAll", connection) {
                    CommandType = CommandType.StoredProcedure
                };
                command.Parameters.AddWithValue("@GroupCate", group);
                connection.Open();
                using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                {
                    adapter.Fill(datatable);
                    command.Dispose();
                }
                return datatable;
            }
        }

        public DataTable GetAllGroupCateViewPageComment(string group)
        {
            DataTable datatable = new DataTable();
            using (SqlConnection connection = base.GetConnection())
            {
                SqlCommand command = new SqlCommand("_PageCommentViewGroupCateGetAll", connection) {
                    CommandType = CommandType.StoredProcedure
                };
                command.Parameters.AddWithValue("@GroupCate", group);
                connection.Open();
                using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                {
                    adapter.Fill(datatable);
                    command.Dispose();
                }
                return datatable;
            }
        }

        public DataTable GetAllPageComment()
        {
            DataTable datatable = new DataTable();
            using (SqlConnection connection = base.GetConnection())
            {
                SqlCommand command = new SqlCommand("_PageCommentGetAll", connection) {
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

        public DataTable GetAllViewPageComment()
        {
            DataTable datatable = new DataTable();
            using (SqlConnection connection = base.GetConnection())
            {
                SqlCommand command = new SqlCommand("_PageCommentViewGetAll", connection) {
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

        public PageComment GetPageCommentById(int commentID)
        {
            PageComment pageComment = null;
            using (SqlConnection connection = base.GetConnection())
            {
                SqlCommand command = new SqlCommand("_PageCommentGetById", connection) {
                    CommandType = CommandType.StoredProcedure
                };
                command.Parameters.AddWithValue("@CommentPageID", commentID);
                connection.Open();
                using (SqlDataReader reader = command.ExecuteReader(CommandBehavior.CloseConnection))
                {
                    if (!reader.Read())
                    {
                        throw new DataAccessException("khong ton tai pageComment");
                    }
                    pageComment = this.PageCommentReader(reader);
                }
                command.Dispose();
            }
            return pageComment;
        }

        public DataTable GetPageCommentByPageID(int pageID)
        {
            DataTable datatable = new DataTable();
            using (SqlConnection connection = base.GetConnection())
            {
                SqlCommand command = new SqlCommand("_PageCommentGetPageID", connection) {
                    CommandType = CommandType.StoredProcedure
                };
                command.Parameters.AddWithValue("@PageID", pageID);
                connection.Open();
                using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                {
                    adapter.Fill(datatable);
                    command.Dispose();
                }
                return datatable;
            }
        }

        private PageComment PageCommentReader(SqlDataReader reader)
        {
            return new PageComment { CommentPageID = (int) reader["CommentPageID"], PageID = (int) reader["PageID"], FullName = (string) reader["FullName"], Email = (string) reader["Email"], Title = (string) reader["Title"], Content = (string) reader["Content"], DateCreated = (DateTime) reader["DateCreated"], Actived = (bool) reader["Actived"], GroupCate = (string) reader["GroupCate"], ApprovalUserName = (string) reader["ApprovalUserName"], ApprovalDate = (DateTime) reader["ApprovalDate"] };
        }

        public void UpdatePageComment(PageComment pageComment)
        {
            using (SqlConnection connection = base.GetConnection())
            {
                SqlCommand command = new SqlCommand("_PageCommentUpdate", connection) {
                    CommandType = CommandType.StoredProcedure
                };
                command.Parameters.AddWithValue("@Type", 1);
                command.Parameters.AddWithValue("@CommentPageID", pageComment.CommentPageID);
                command.Parameters.AddWithValue("@PageID", pageComment.PageID);
                command.Parameters.AddWithValue("@FullName", pageComment.FullName);
                command.Parameters.AddWithValue("@Email", pageComment.Email);
                command.Parameters.AddWithValue("@Title", pageComment.Title);
                command.Parameters.AddWithValue("@Content", pageComment.Content);
                command.Parameters.AddWithValue("@DateCreated", pageComment.DateCreated);
                command.Parameters.AddWithValue("@Actived", pageComment.Actived);
                command.Parameters.AddWithValue("@GroupCate", pageComment.GroupCate);
                command.Parameters.AddWithValue("@ApprovalUserName", pageComment.ApprovalUserName);
                command.Parameters.AddWithValue("@ApprovalDate", pageComment.ApprovalDate);
                connection.Open();
                if (command.ExecuteNonQuery() <= 0)
                {
                    throw new DataAccessException("Lỗi kh\x00f4ng thể tao moi");
                }
                command.Dispose();
            }
        }

        public void UpdatePageComment(string strId, string value)
        {
            using (SqlConnection connection = base.GetConnection())
            {
                string SQL = "update tblPageComment set Actived =" + value + " where CommentPageID in('" + strId + "')";
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

        public void UpdatePageComment(int Id, string value, string username, DateTime date)
        {
            using (SqlConnection connection = base.GetConnection())
            {
                string SQL = "update tblPageComment set Actived = " + value + ", ApprovalUserName = '" + username + "',ApprovalDate = @Date  where CommentPageID = @CommentPageID";
                SqlCommand command = new SqlCommand(SQL, connection) {
                    CommandText = SQL
                };
                command.Parameters.AddWithValue("@Date", date);
                command.Parameters.AddWithValue("@CommentPageID", Id);
                connection.Open();
                if (command.ExecuteNonQuery() <= 0)
                {
                    throw new DataAccessException("Kh\x00f4ng cập nhật được tin n\x00e0o");
                }
                command.Dispose();
            }
        }

        public void UpdatePageComment(string strId, string value, string username, DateTime date)
        {
            using (SqlConnection connection = base.GetConnection())
            {
                string SQL = "update tblPageComment set Actived =" + value + ", ApprovalUserName = '" + username + "',ApprovalDate = @Date where CommentPageID in('" + strId + "')";
                SqlCommand command = new SqlCommand(SQL, connection);
                command.Parameters.AddWithValue("@Date", date);
                command.CommandText = SQL;
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

