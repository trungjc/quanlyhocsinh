namespace DAO
{
    using ETO;
    using System;
    using System.Data;
    using System.Data.SqlClient;

    public class NewsCommentDAO : BaseDAO
    {
        public void CreateNewsComment(NewsComment newsComment)
        {
            using (SqlConnection connection = base.GetConnection())
            {
                SqlCommand command = new SqlCommand("_NewsCommentUpdate", connection) {
                    CommandType = CommandType.StoredProcedure
                };
                command.Parameters.AddWithValue("@Type", 0);
                command.Parameters.AddWithValue("@CommentNewsID", 0);
                command.Parameters.AddWithValue("@NewsID", newsComment.NewsID);
                command.Parameters.AddWithValue("@FullName", newsComment.FullName);
                command.Parameters.AddWithValue("@Email", newsComment.Email);
                command.Parameters.AddWithValue("@Title", newsComment.Title);
                command.Parameters.AddWithValue("@Content", newsComment.Content);
                command.Parameters.AddWithValue("@DateCreated", newsComment.DateCreated);
                command.Parameters.AddWithValue("@Actived", newsComment.Actived);
                command.Parameters.AddWithValue("@GroupCate", newsComment.GroupCate);
                command.Parameters.AddWithValue("@ApprovalUserName", newsComment.ApprovalUserName);
                command.Parameters.AddWithValue("@ApprovalDate", newsComment.ApprovalDate);
                connection.Open();
                if (command.ExecuteNonQuery() <= 0)
                {
                    throw new DataAccessException("Lỗi kh\x00f4ng thể tao moi");
                }
                command.Dispose();
            }
        }

        public void DeleteNewsComment(int commentID)
        {
            using (SqlConnection connection = base.GetConnection())
            {
                SqlCommand command = new SqlCommand("_NewsCommentDelete", connection) {
                    CommandType = CommandType.StoredProcedure
                };
                command.Parameters.AddWithValue("@CommentNewsID", commentID);
                connection.Open();
                if (command.ExecuteNonQuery() <= 0)
                {
                    throw new DataAccessException("Kh\x00f4ng thể x\x00f3a newsComment");
                }
                command.Dispose();
            }
        }

        public void DeleteNewsComment(string strId)
        {
            using (SqlConnection connection = base.GetConnection())
            {
                string SQL = "delete tblNewsComment where CommentNewsID in('" + strId + "')";
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

        public DataTable GetAllGroupCateNewsComment(int group)
        {
            DataTable datatable = new DataTable();
            using (SqlConnection connection = base.GetConnection())
            {
                SqlCommand command = new SqlCommand("_NewsCommentGroupCateGetAll", connection) {
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

        public DataTable GetAllNewsComment()
        {
            DataTable datatable = new DataTable();
            using (SqlConnection connection = base.GetConnection())
            {
                SqlCommand command = new SqlCommand("_NewsCommentGetAll", connection) {
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

        public DataTable GetAllNewsGroupComment(int group)
        {
            DataTable datatable = new DataTable();
            using (SqlConnection connection = base.GetConnection())
            {
                string SQL = "SELECT tblNewsGroup.Title AS NewsTitle, tblNewsComment.*  FROM tblNewsGroup INNER JOIN tblNewsComment ON tblNewsGroup.NewsGroupID = tblNewsComment.NewsID WHERE (tblNewsComment.GroupCate = @GroupCate) ORDER BY DateCreated Desc";
                SqlCommand command = new SqlCommand(SQL, connection) {
                    CommandText = SQL
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

        public DataTable GetAllNewsGroupComment(int Id, int group)
        {
            DataTable datatable = new DataTable();
            using (SqlConnection connection = base.GetConnection())
            {
                string SQL = "SELECT tblNewsGroup.Title AS NewsTitle, tblNewsComment.*  FROM tblNewsGroup INNER JOIN tblNewsComment ON tblNewsGroup.NewsGroupID = tblNewsComment.NewsID WHERE (tblNewsComment.GroupCate = @GroupCate AND NewsID=@NewsGroupID) ORDER BY DateCreated Desc";
                SqlCommand command = new SqlCommand(SQL, connection) {
                    CommandText = SQL
                };
                command.Parameters.AddWithValue("@NewsGroupID", Id);
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

        public DataTable GetAllViewAnnounceComment()
        {
            DataTable datatable = new DataTable();
            using (SqlConnection connection = base.GetConnection())
            {
                SqlCommand command = new SqlCommand("_AnnounceCommentViewGetAll", connection) {
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

        public DataTable GetAllViewAnnounceComment(int Id)
        {
            DataTable datatable = new DataTable();
            using (SqlConnection connection = base.GetConnection())
            {
                SqlCommand command = new SqlCommand("_AnnounceCommentViewGetbyID", connection) {
                    CommandType = CommandType.StoredProcedure
                };
                command.Parameters.AddWithValue("@NewsID", Id);
                connection.Open();
                using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                {
                    adapter.Fill(datatable);
                    command.Dispose();
                }
                return datatable;
            }
        }

        public DataTable GetAllViewCompanyComment()
        {
            DataTable datatable = new DataTable();
            using (SqlConnection connection = base.GetConnection())
            {
                SqlCommand command = new SqlCommand("_CompanyCommentViewGetAll", connection) {
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

        public DataTable GetAllViewCompanyComment(int Id)
        {
            DataTable datatable = new DataTable();
            using (SqlConnection connection = base.GetConnection())
            {
                SqlCommand command = new SqlCommand("_CompanyCommentViewGetbyID", connection) {
                    CommandType = CommandType.StoredProcedure
                };
                command.Parameters.AddWithValue("@NewsID", Id);
                connection.Open();
                using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                {
                    adapter.Fill(datatable);
                    command.Dispose();
                }
                return datatable;
            }
        }

        public DataTable GetAllViewDownloadComment()
        {
            DataTable datatable = new DataTable();
            using (SqlConnection connection = base.GetConnection())
            {
                SqlCommand command = new SqlCommand("_DownloadCommentViewGetAll", connection) {
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

        public DataTable GetAllViewDownloadComment(int Id)
        {
            DataTable datatable = new DataTable();
            using (SqlConnection connection = base.GetConnection())
            {
                SqlCommand command = new SqlCommand("_DownloadCommentViewGetbyID", connection) {
                    CommandType = CommandType.StoredProcedure
                };
                command.Parameters.AddWithValue("@NewsID", Id);
                connection.Open();
                using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                {
                    adapter.Fill(datatable);
                    command.Dispose();
                }
                return datatable;
            }
        }

        public DataTable GetAllViewNewsComment()
        {
            DataTable datatable = new DataTable();
            using (SqlConnection connection = base.GetConnection())
            {
                SqlCommand command = new SqlCommand("_NewsCommentViewGetAll", connection) {
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

        public DataTable GetAllViewNewsComment(int Id)
        {
            DataTable datatable = new DataTable();
            using (SqlConnection connection = base.GetConnection())
            {
                SqlCommand command = new SqlCommand("_NewsCommentViewGetbyID", connection) {
                    CommandType = CommandType.StoredProcedure
                };
                command.Parameters.AddWithValue("@NewsID", Id);
                connection.Open();
                using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                {
                    adapter.Fill(datatable);
                    command.Dispose();
                }
                return datatable;
            }
        }

        public NewsComment GetNewsCommentById(int commentID)
        {
            NewsComment newsComment = null;
            using (SqlConnection connection = base.GetConnection())
            {
                SqlCommand command = new SqlCommand("_NewsCommentGetById", connection) {
                    CommandType = CommandType.StoredProcedure
                };
                command.Parameters.AddWithValue("@CommentNewsID", commentID);
                connection.Open();
                using (SqlDataReader reader = command.ExecuteReader(CommandBehavior.CloseConnection))
                {
                    if (!reader.Read())
                    {
                        throw new DataAccessException("khong ton tai newsComment");
                    }
                    newsComment = this.NewsCommentReader(reader);
                }
                command.Dispose();
            }
            return newsComment;
        }

        public DataTable GetNewsCommentByNewsID(int newsID)
        {
            DataTable datatable = new DataTable();
            using (SqlConnection connection = base.GetConnection())
            {
                SqlCommand command = new SqlCommand("_NewsCommentGetNewsID", connection) {
                    CommandType = CommandType.StoredProcedure
                };
                command.Parameters.AddWithValue("@NewsID", newsID);
                connection.Open();
                using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                {
                    adapter.Fill(datatable);
                    command.Dispose();
                }
                return datatable;
            }
        }

        private NewsComment NewsCommentReader(SqlDataReader reader)
        {
            return new NewsComment { CommentNewsID = (int) reader["CommentNewsID"], NewsID = (int) reader["NewsID"], FullName = (string) reader["FullName"], Email = (string) reader["Email"], Title = (string) reader["Title"], Content = (string) reader["Content"], DateCreated = (DateTime) reader["DateCreated"], Actived = (bool) reader["Actived"], GroupCate = (int) reader["GroupCate"], ApprovalUserName = (string) reader["ApprovalUserName"], ApprovalDate = (DateTime) reader["ApprovalDate"] };
        }

        public void UpdateNewsComment(NewsComment newsComment)
        {
            using (SqlConnection connection = base.GetConnection())
            {
                SqlCommand command = new SqlCommand("_NewsCommentUpdate", connection) {
                    CommandType = CommandType.StoredProcedure
                };
                command.Parameters.AddWithValue("@Type", 1);
                command.Parameters.AddWithValue("@CommentNewsID", newsComment.CommentNewsID);
                command.Parameters.AddWithValue("@NewsID", newsComment.NewsID);
                command.Parameters.AddWithValue("@FullName", newsComment.FullName);
                command.Parameters.AddWithValue("@Email", newsComment.Email);
                command.Parameters.AddWithValue("@Title", newsComment.Title);
                command.Parameters.AddWithValue("@Content", newsComment.Content);
                command.Parameters.AddWithValue("@DateCreated", newsComment.DateCreated);
                command.Parameters.AddWithValue("@Actived", newsComment.Actived);
                command.Parameters.AddWithValue("@GroupCate", newsComment.GroupCate);
                command.Parameters.AddWithValue("@ApprovalUserName", newsComment.ApprovalUserName);
                command.Parameters.AddWithValue("@ApprovalDate", newsComment.ApprovalDate);
                connection.Open();
                if (command.ExecuteNonQuery() <= 0)
                {
                    throw new DataAccessException("Lỗi kh\x00f4ng thể tao moi");
                }
                command.Dispose();
            }
        }

        public void UpdateNewsComment(string strId, string value)
        {
            using (SqlConnection connection = base.GetConnection())
            {
                string SQL = "update tblNewsComment set Actived =" + value + " where CommentNewsID in('" + strId + "')";
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

        public void UpdateNewsComment(int Id, string value, string username, DateTime date)
        {
            using (SqlConnection connection = base.GetConnection())
            {
                string SQL = "update tblNewsComment set Actived = " + value + ", ApprovalUserName = '" + username + "',ApprovalDate = @Date  where NewsCommentID = @NewsCommentID";
                SqlCommand command = new SqlCommand(SQL, connection) {
                    CommandText = SQL
                };
                command.Parameters.AddWithValue("@Date", date);
                command.Parameters.AddWithValue("@NewsCommentID", Id);
                connection.Open();
                if (command.ExecuteNonQuery() <= 0)
                {
                    throw new DataAccessException("Kh\x00f4ng cập nhật được tin n\x00e0o");
                }
                command.Dispose();
            }
        }

        public void UpdateNewsComment(string strId, string value, string username, DateTime date)
        {
            using (SqlConnection connection = base.GetConnection())
            {
                string SQL = "update tblNewsComment set Actived =" + value + ",ApprovalUserName='" + username + "', ApprovalDate = @Date where CommentNewsID in('" + strId + "')";
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

