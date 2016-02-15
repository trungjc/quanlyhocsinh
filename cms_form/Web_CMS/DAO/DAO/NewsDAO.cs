namespace DAO
{
    using ETO;
    using System;
    using System.Data;
    using System.Data.SqlClient;

    public class NewsDAO : BaseDAO
    {
        public void CreateNews(News news)
        {
            using (SqlConnection connection = base.GetConnection())
            {
                SqlCommand command = new SqlCommand("_NewsUpdate", connection) {
                    CommandType = CommandType.StoredProcedure
                };
                command.Parameters.AddWithValue("@Type", 0);
                command.Parameters.AddWithValue("@NewsID", 0);
                command.Parameters.AddWithValue("@CateNewsID", news.CateNewsID);
                command.Parameters.AddWithValue("@ParentNewsID", news.ParentNewsID);
                command.Parameters.AddWithValue("@Title", news.Title);
                command.Parameters.AddWithValue("@ShortDescribe", news.ShortDescribe);
                command.Parameters.AddWithValue("@FullDescribe", news.FullDescribe);
                command.Parameters.AddWithValue("@ImageThumb", news.ImageThumb);
                command.Parameters.AddWithValue("@ImageLarge", news.ImageLarge);
                command.Parameters.AddWithValue("@Author", news.Author);
                command.Parameters.AddWithValue("@PostDate", news.PostDate);
                command.Parameters.AddWithValue("@RelationTotal", news.RelationTotal);
                command.Parameters.AddWithValue("@Status", news.Status);
                command.Parameters.AddWithValue("@Language", news.Language);
                command.Parameters.AddWithValue("@Ishot", news.Ishot);
                command.Parameters.AddWithValue("@Isview", news.Isview);
                command.Parameters.AddWithValue("@Ishome", news.Ishome);
                command.Parameters.AddWithValue("@IsComment", news.IsComment);
                command.Parameters.AddWithValue("@ApprovalDate", news.ApprovalDate);
                command.Parameters.AddWithValue("@ApprovalUserName", news.ApprovalUserName);
                command.Parameters.AddWithValue("@IsApproval", news.IsApproval);
                command.Parameters.AddWithValue("@CreatedUserName", news.CreatedUserName);
                command.Parameters.AddWithValue("@CommentTotal", news.CommentTotal);
                command.Parameters.AddWithValue("@GroupCate", news.GroupCate);
                connection.Open();
                if (command.ExecuteNonQuery() <= 0)
                {
                    throw new DataAccessException("Kh\x00f4ng thể th\x00eam mới tin");
                }
                command.Dispose();
            }
        }

        public void DeleteNews(int Id)
        {
            using (SqlConnection connection = base.GetConnection())
            {
                SqlCommand command = new SqlCommand("_NewsDelete", connection) {
                    CommandType = CommandType.StoredProcedure
                };
                command.Parameters.AddWithValue("NewsID", Id);
                connection.Open();
                if (command.ExecuteNonQuery() <= 0)
                {
                    throw new DataAccessException("Kh\x00f4ng x\x00f3a được tin");
                }
                command.Dispose();
            }
        }

        public void DeleteNews(string sId)
        {
            using (SqlConnection connection = base.GetConnection())
            {
                string SQL = "delete tblNews where NewsID in('" + sId + "')";
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

        public DataTable GetNewsAll(string lang)
        {
            DataTable datatable = new DataTable();
            using (SqlConnection connection = base.GetConnection())
            {
                SqlCommand command = new SqlCommand("_NewsGetAll", connection) {
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

        public DataTable GetNewsByCateAll(string strCate)
        {
            DataTable datatable = new DataTable();
            using (SqlConnection connection = base.GetConnection())
            {
                string SQL = "select * from tblNews where CateNewsID in('" + strCate + "') order by newsid desc";
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

        public DataTable GetNewsByCateHomeAll(string strCate)
        {
            DataTable datatable = new DataTable();
            using (SqlConnection connection = base.GetConnection())
            {
                string SQL = "select * from tblNews where status=1 and CateNewsID in('" + strCate + "') order by NewsID";
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

        public DataTable GetNewsByCateHomeAll(int n, string strCate)
        {
            DataTable datatable = new DataTable();
            using (SqlConnection connection = base.GetConnection())
            {
                string SQL = "select top " + n.ToString() + " * from tblNews where status=1 and CateNewsID in('" + strCate + "') order by NewsID";
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

        public DataTable GetNewsByCateHomeAll(int n, string strCate, string approval)
        {
            DataTable datatable = new DataTable();
            using (SqlConnection connection = base.GetConnection())
            {
                string SQL = "select top " + n.ToString() + " * from tblNews where status=1 and CateNewsID in('" + strCate + "')  AND [IsApproval] = " + approval + " order by NewsID desc";
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

        public DataTable GetNewsByCateHomeList(string strCate)
        {
            DataTable datatable = new DataTable();
            using (SqlConnection connection = base.GetConnection())
            {
                string SQL = "select * from tblNews where CateNewsID in('" + strCate + "') order by NewsID Desc";
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

        public DataTable GetNewsByCateHomeList(string strCate, int num)
        {
            DataTable datatable = new DataTable();
            using (SqlConnection connection = base.GetConnection())
            {
                string SQL = "select top " + Convert.ToString(num) + " * from tblNews where CateNewsID in('" + strCate + "') order by NewsID Desc";
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

        public DataTable GetNewsByCateHomeList(string strCate, int num, string approval)
        {
            DataTable datatable = new DataTable();
            using (SqlConnection connection = base.GetConnection())
            {
                string SQL = "select top " + Convert.ToString(num) + " * from tblNews where CateNewsID in('" + strCate + "')  AND [IsApproval] = " + approval + " order by NewsID Desc";
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

        public News GetNewsById(int Id)
        {
            News news = null;
            using (SqlConnection connection = base.GetConnection())
            {
                SqlCommand command = new SqlCommand("_NewsGetById", connection) {
                    CommandType = CommandType.StoredProcedure
                };
                command.Parameters.AddWithValue("@NewsID", Id);
                connection.Open();
                using (SqlDataReader reader = command.ExecuteReader(CommandBehavior.CloseConnection))
                {
                    if (!reader.Read())
                    {
                        throw new DataAccessException("Kh\x00f4ng t\x00ecm thấy tin");
                    }
                    news = this.NewsReader(reader);
                }
                command.Dispose();
            }
            return news;
        }

        public DataTable GetNewsHot(string lang)
        {
            DataTable datatable = new DataTable();
            using (SqlConnection connection = base.GetConnection())
            {
                SqlCommand command = new SqlCommand("_NewsHot", connection) {
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

        public DataTable GetNewsHot(string lang, int n)
        {
            DataTable datatable = new DataTable();
            using (SqlConnection connection = base.GetConnection())
            {
                string SQL = "Select top " + n.ToString() + " * from tblNews where [Language] = '" + lang + "' AND [Ishot] = 1 AND [Status] = 1 ORDER BY [NewsID] DESC ";
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

        public DataTable GetNewsHot(string lang, int n, string approval)
        {
            DataTable datatable = new DataTable();
            using (SqlConnection connection = base.GetConnection())
            {
                string SQL = "Select top " + n.ToString() + " * from tblNews where Language = '" + lang + "' and Ishot = 1 AND Status = 1 AND IsApproval = " + approval + " ORDER BY NewsID DESC ";
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

        public DataTable GetNewsView(string lang)
        {
            DataTable datatable = new DataTable();
            using (SqlConnection connection = base.GetConnection())
            {
                SqlCommand command = new SqlCommand("_NewsView", connection) {
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

        public DataTable GetNewsViewHome(string lang)
        {
            DataTable datatable = new DataTable();
            using (SqlConnection connection = base.GetConnection())
            {
                SqlCommand command = new SqlCommand("_NewsViewHome", connection) {
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

        public DataTable GetNewsViewHome(string lang, int n)
        {
            DataTable datatable = new DataTable();
            using (SqlConnection connection = base.GetConnection())
            {
                string SQL = "Select top " + n.ToString() + " * from tblNews where [Language] = '" + lang + "' AND [IsHome] = 1 AND [Status] = 1 ORDER BY [NewsID] DESC ";
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

        public DataTable GetNewsViewHome(string lang, int n, int cID)
        {
            DataTable datatable = new DataTable();
            using (SqlConnection connection = base.GetConnection())
            {
                string SQL = "Select top " + n.ToString() + " * from tblNews where [Language] = '" + lang + "' AND CateNewsID = @cateID AND [IsHome] = 1 AND [Status] = 1 ORDER BY [NewsID] DESC ";
                SqlCommand command = new SqlCommand(SQL, connection) {
                    CommandText = SQL
                };
                command.Parameters.AddWithValue("@cateID", cID);
                connection.Open();
                using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                {
                    adapter.Fill(datatable);
                    command.Dispose();
                }
            }
            return datatable;
        }

        public DataTable GetNewsViewHome(string lang, int n, string approval)
        {
            DataTable datatable = new DataTable();
            using (SqlConnection connection = base.GetConnection())
            {
                string SQL = "Select top " + n.ToString() + " * from tblNews where [Language] = '" + lang + "' AND [IsHome] = 1 AND [Status] = 1 AND [IsApproval] = " + approval + " ORDER BY [NewsID] DESC ";
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

        public DataTable GetNewsViewHome(string lang, string strCate, int n)
        {
            DataTable datatable = new DataTable();
            using (SqlConnection connection = base.GetConnection())
            {
                string SQL = "Select top " + n.ToString() + " * from tblNews where [Language] = '" + lang + "' AND CateNewsID in('" + strCate + "') AND [IsHome] = 1 AND [Status] = 1 ORDER BY [NewsID] DESC ";
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

        public void NewsClickUpdate(int nId)
        {
            using (SqlConnection connection = base.GetConnection())
            {
                SqlCommand command = new SqlCommand("_NewsClickUpdate", connection) {
                    CommandType = CommandType.StoredProcedure
                };
                command.Parameters.AddWithValue("@NewsID", nId);
                connection.Open();
                if (command.ExecuteNonQuery() <= 0)
                {
                    throw new DataAccessException("Kh\x00f4ng thể cập nhật số lần click");
                }
                command.Dispose();
            }
        }

        public DataTable NewsFollow(int Id, int cId, int n)
        {
            DataTable datatable = new DataTable();
            using (SqlConnection connection = base.GetConnection())
            {
                string SQL = string.Concat(new object[] { "SELECT Top ", Convert.ToString(n), " * FROM tblNews WHERE CateNewsID = ", cId, " AND NewsID < ", Id, " ORDER BY NewsID DESC" });
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

        private News NewsReader(SqlDataReader reader)
        {
            return new News { 
                NewsID = (int) reader["NewsID"], CateNewsID = (int) reader["CateNewsID"], ParentNewsID = (int) reader["ParentNewsID"], Title = (string) reader["Title"], ShortDescribe = (string) reader["ShortDescribe"], FullDescribe = (string) reader["FullDescribe"], ImageThumb = (string) reader["ImageThumb"], ImageLarge = (string) reader["ImageLarge"], Author = (string) reader["Author"], PostDate = (DateTime) reader["PostDate"], RelationTotal = (int) reader["RelationTotal"], Status = (bool) reader["Status"], Language = (string) reader["Language"], Ishot = (bool) reader["Ishot"], Isview = (int) reader["Isview"], Ishome = (bool) reader["Ishome"], 
                IsComment = (bool) reader["IsComment"], ApprovalDate = (DateTime) reader["ApprovalDate"], ApprovalUserName = (string) reader["ApprovalUserName"], IsApproval = (bool) reader["IsApproval"], CreatedUserName = (string) reader["CreatedUserName"], CommentTotal = (int) reader["CommentTotal"], GroupCate = (int) reader["GroupCate"]
             };
        }

        public DataTable NewsSearch(string keyword, int cateid, string lang)
        {
            DataTable datatable = new DataTable();
            using (SqlConnection connection = base.GetConnection())
            {
                SqlCommand command = new SqlCommand("_NewsSearch", connection) {
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

        public void UpdateNews(News news)
        {
            using (SqlConnection connection = base.GetConnection())
            {
                SqlCommand command = new SqlCommand("_NewsUpdate", connection) {
                    CommandType = CommandType.StoredProcedure
                };
                command.Parameters.AddWithValue("@Type", 1);
                command.Parameters.AddWithValue("@NewsID", news.NewsID);
                command.Parameters.AddWithValue("@CateNewsID", news.CateNewsID);
                command.Parameters.AddWithValue("@ParentNewsID", news.ParentNewsID);
                command.Parameters.AddWithValue("@Title", news.Title);
                command.Parameters.AddWithValue("@ShortDescribe", news.ShortDescribe);
                command.Parameters.AddWithValue("@FullDescribe", news.FullDescribe);
                command.Parameters.AddWithValue("@ImageThumb", news.ImageThumb);
                command.Parameters.AddWithValue("@ImageLarge", news.ImageLarge);
                command.Parameters.AddWithValue("@Author", news.Author);
                command.Parameters.AddWithValue("@PostDate", news.PostDate);
                command.Parameters.AddWithValue("@RelationTotal", news.RelationTotal);
                command.Parameters.AddWithValue("@Status", news.Status);
                command.Parameters.AddWithValue("@Language", news.Language);
                command.Parameters.AddWithValue("@Ishot", news.Ishot);
                command.Parameters.AddWithValue("@Isview", news.Isview);
                command.Parameters.AddWithValue("@Ishome", news.Ishome);
                command.Parameters.AddWithValue("@IsComment", news.IsComment);
                command.Parameters.AddWithValue("@ApprovalDate", news.ApprovalDate);
                command.Parameters.AddWithValue("@ApprovalUserName", news.ApprovalUserName);
                command.Parameters.AddWithValue("@IsApproval", news.IsApproval);
                command.Parameters.AddWithValue("@CreatedUserName", news.CreatedUserName);
                command.Parameters.AddWithValue("@CommentTotal", news.CommentTotal);
                command.Parameters.AddWithValue("@GroupCate", news.GroupCate);
                connection.Open();
                if (command.ExecuteNonQuery() <= 0)
                {
                    throw new DataAccessException("Kh\x00f4ng thể cập nhật tin");
                }
                command.Dispose();
            }
        }

        public void UpdateNews(string strId, string value)
        {
            using (SqlConnection connection = base.GetConnection())
            {
                string SQL = "update tblNews set Status = " + value + " where NewsID in('" + strId + "')";
                SqlCommand command = new SqlCommand(SQL, connection) {
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

        public void UpdateNewsApproval(int Id, string value, string username, DateTime date)
        {
            using (SqlConnection connection = base.GetConnection())
            {
                string SQL = "update tblNews set IsApproval = " + value + ", ApprovalUserName = '" + username + "',ApprovalDate = @Date  where NewsID = @NewsID";
                SqlCommand command = new SqlCommand(SQL, connection) {
                    CommandText = SQL
                };
                command.Parameters.AddWithValue("@Date", date);
                command.Parameters.AddWithValue("@NewsID", Id);
                connection.Open();
                if (command.ExecuteNonQuery() <= 0)
                {
                    throw new DataAccessException("Kh\x00f4ng cập nhật được tin n\x00e0o");
                }
                command.Dispose();
            }
        }

        public void UpdateNewsApproval(string strId, string value, string username, DateTime date)
        {
            using (SqlConnection connection = base.GetConnection())
            {
                string SQL = "update tblNews set IsApproval = " + value + ", ApprovalUserName = '" + username + "',ApprovalDate = @Date  where NewsID in('" + strId + "')";
                SqlCommand command = new SqlCommand(SQL, connection) {
                    CommandText = SQL
                };
                command.Parameters.AddWithValue("@Date", date);
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

