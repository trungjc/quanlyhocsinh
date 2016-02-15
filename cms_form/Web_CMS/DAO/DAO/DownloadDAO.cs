namespace DAO
{
    using ETO;
    using System;
    using System.Data;
    using System.Data.SqlClient;

    public class DownloadDAO : BaseDAO
    {
        public void CreateDownload(Download download)
        {
            using (SqlConnection connection = base.GetConnection())
            {
                SqlCommand command = new SqlCommand("_DownloadUpdate", connection) {
                    CommandType = CommandType.StoredProcedure
                };
                command.Parameters.AddWithValue("@Type", 0);
                command.Parameters.AddWithValue("@DownloadID", 0);
                command.Parameters.AddWithValue("@CateDownloadID", download.CateDownloadID);
                command.Parameters.AddWithValue("@Title", download.Title);
                command.Parameters.AddWithValue("@ShortDescribe", download.ShortDescribe);
                command.Parameters.AddWithValue("@FullDescribe", download.FullDescribe);
                command.Parameters.AddWithValue("@ImageThumb", download.ImageThumb);
                command.Parameters.AddWithValue("@FileName", download.FileName);
                command.Parameters.AddWithValue("@Author", download.Author);
                command.Parameters.AddWithValue("@PostDate", download.PostDate);
                command.Parameters.AddWithValue("@RelationTotal", download.RelationTotal);
                command.Parameters.AddWithValue("@Status", download.Status);
                command.Parameters.AddWithValue("@Language", download.Language);
                command.Parameters.AddWithValue("@Ishot", download.Ishot);
                command.Parameters.AddWithValue("@Isview", download.Isview);
                command.Parameters.AddWithValue("@Ishome", download.Ishome);
                command.Parameters.AddWithValue("@IsComment", download.IsComment);
                command.Parameters.AddWithValue("@ApprovalDate", download.ApprovalDate);
                command.Parameters.AddWithValue("@ApprovalUserName", download.ApprovalUserName);
                command.Parameters.AddWithValue("@IsApproval", download.IsApproval);
                command.Parameters.AddWithValue("@CreatedUserName", download.CreatedUserName);
                command.Parameters.AddWithValue("@CommentTotal", download.CommentTotal);
                connection.Open();
                if (command.ExecuteNonQuery() <= 0)
                {
                    throw new DataAccessException("Kh\x00f4ng thể th\x00eam mới tin");
                }
                command.Dispose();
            }
        }

        public void DeleteDownload(int Id)
        {
            using (SqlConnection connection = base.GetConnection())
            {
                SqlCommand command = new SqlCommand("_DownloadDelete", connection) {
                    CommandType = CommandType.StoredProcedure
                };
                command.Parameters.AddWithValue("DownloadID", Id);
                connection.Open();
                if (command.ExecuteNonQuery() <= 0)
                {
                    throw new DataAccessException("Kh\x00f4ng x\x00f3a được tin");
                }
                command.Dispose();
            }
        }

        public void DeleteDownload(string sId)
        {
            using (SqlConnection connection = base.GetConnection())
            {
                string SQL = "delete tblDownload where DownloadID in('" + sId + "')";
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

        public void DownloadClickUpdate(int nId)
        {
            using (SqlConnection connection = base.GetConnection())
            {
                SqlCommand command = new SqlCommand("_DownloadClickUpdate", connection) {
                    CommandType = CommandType.StoredProcedure
                };
                command.Parameters.AddWithValue("@DownloadID", nId);
                connection.Open();
                if (command.ExecuteNonQuery() <= 0)
                {
                    throw new DataAccessException("Kh\x00f4ng thể cập nhật số lần click");
                }
                command.Dispose();
            }
        }

        public DataTable DownloadFollow(int Id, int cId, int n)
        {
            DataTable datatable = new DataTable();
            using (SqlConnection connection = base.GetConnection())
            {
                string SQL = string.Concat(new object[] { "SELECT Top ", Convert.ToString(n), " * FROM tblDownload WHERE CateDownloadID = ", cId, " AND DownloadID < ", Id, " ORDER BY DownloadID DESC" });
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

        private Download DownloadReader(SqlDataReader reader)
        {
            return new Download { 
                DownloadID = (int) reader["DownloadID"], CateDownloadID = (int) reader["CateDownloadID"], Title = (string) reader["Title"], ShortDescribe = (string) reader["ShortDescribe"], FullDescribe = (string) reader["FullDescribe"], ImageThumb = (string) reader["ImageThumb"], FileName = (string) reader["FileName"], Author = (string) reader["Author"], PostDate = (DateTime) reader["PostDate"], RelationTotal = (int) reader["RelationTotal"], Status = (bool) reader["Status"], Language = (string) reader["Language"], Ishot = (bool) reader["Ishot"], Isview = (int) reader["Isview"], Ishome = (bool) reader["Ishome"], IsComment = (bool) reader["IsComment"], 
                ApprovalDate = (DateTime) reader["ApprovalDate"], ApprovalUserName = (string) reader["ApprovalUserName"], IsApproval = (bool) reader["IsApproval"], CreatedUserName = (string) reader["CreatedUserName"], CommentTotal = (int) reader["CommentTotal"]
             };
        }

        public DataTable DownloadSearch(string keyword, int cateid, string lang)
        {
            DataTable datatable = new DataTable();
            using (SqlConnection connection = base.GetConnection())
            {
                SqlCommand command = new SqlCommand("_DownloadSearch", connection) {
                    CommandType = CommandType.StoredProcedure
                };
                command.Parameters.AddWithValue("@Keyword", keyword);
                command.Parameters.AddWithValue("@CateDownloadID", cateid);
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

        public DataTable GetDownloadAll(string lang)
        {
            DataTable datatable = new DataTable();
            using (SqlConnection connection = base.GetConnection())
            {
                SqlCommand command = new SqlCommand("_DownloadGetAll", connection) {
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

        public DataTable GetDownloadByCateAll(string strCate)
        {
            DataTable datatable = new DataTable();
            using (SqlConnection connection = base.GetConnection())
            {
                string SQL = "select * from tblDownload where CateDownloadID in('" + strCate + "') order by downloadid desc";
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

        public DataTable GetDownloadByCateHomeAll(string strCate)
        {
            DataTable datatable = new DataTable();
            using (SqlConnection connection = base.GetConnection())
            {
                string SQL = "select * from tblDownload where status=1 and CateDownloadID in('" + strCate + "') order by DownloadID";
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

        public DataTable GetDownloadByCateHomeAll(int n, string strCate)
        {
            DataTable datatable = new DataTable();
            using (SqlConnection connection = base.GetConnection())
            {
                string SQL = "select top " + n.ToString() + " * from tblDownload where status=1 and CateDownloadID in('" + strCate + "') order by DownloadID";
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

        public DataTable GetDownloadByCateHomeAll(int n, string strCate, string approval)
        {
            DataTable datatable = new DataTable();
            using (SqlConnection connection = base.GetConnection())
            {
                string SQL = "select top " + n.ToString() + " * from tblDownload where status=1 and CateDownloadID in('" + strCate + "')  AND [IsApproval] = " + approval + " order by DownloadID";
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

        public DataTable GetDownloadByCateHomeList(string strCate)
        {
            DataTable datatable = new DataTable();
            using (SqlConnection connection = base.GetConnection())
            {
                string SQL = "select * from tblDownload where CateDownloadID in('" + strCate + "') order by DownloadID Desc";
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

        public DataTable GetDownloadByCateHomeList(string strCate, int num)
        {
            DataTable datatable = new DataTable();
            using (SqlConnection connection = base.GetConnection())
            {
                string SQL = "select top " + Convert.ToString(num) + " * from tblDownload where  CateDownloadID in('" + strCate + "') order by DownloadID Desc";
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

        public DataTable GetDownloadByCateHomeList(string strCate, int num, string approval)
        {
            DataTable datatable = new DataTable();
            using (SqlConnection connection = base.GetConnection())
            {
                string SQL = "select top " + Convert.ToString(num) + " * from tblDownload where  CateDownloadID in('" + strCate + "')  AND [IsApproval] = " + approval + " order by DownloadID Desc";
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

        public Download GetDownloadById(int Id)
        {
            Download download = null;
            using (SqlConnection connection = base.GetConnection())
            {
                SqlCommand command = new SqlCommand("_DownloadGetById", connection) {
                    CommandType = CommandType.StoredProcedure
                };
                command.Parameters.AddWithValue("@DownloadID", Id);
                connection.Open();
                using (SqlDataReader reader = command.ExecuteReader(CommandBehavior.CloseConnection))
                {
                    if (!reader.Read())
                    {
                        throw new DataAccessException("Kh\x00f4ng t\x00ecm thấy tin");
                    }
                    download = this.DownloadReader(reader);
                }
                command.Dispose();
            }
            return download;
        }

        public DataTable GetDownloadHot(string lang)
        {
            DataTable datatable = new DataTable();
            using (SqlConnection connection = base.GetConnection())
            {
                SqlCommand command = new SqlCommand("_DownloadHot", connection) {
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

        public DataTable GetDownloadHot(string lang, int n)
        {
            DataTable datatable = new DataTable();
            using (SqlConnection connection = base.GetConnection())
            {
                string SQL = "Select top " + n.ToString() + " * from tblDownload where [Language] = '" + lang + "' AND [Ishot] = 1 AND [Status] = 1 ORDER BY [DownloadID] DESC ";
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

        public DataTable GetDownloadHot(string lang, int n, string approval)
        {
            DataTable datatable = new DataTable();
            using (SqlConnection connection = base.GetConnection())
            {
                string SQL = "Select top " + n.ToString() + " * from tblDownload where [Language] = '" + lang + "' AND [Ishot] = 1 AND [Status] = 1 AND [IsApproval] = " + approval + " ORDER BY [DownloadID] DESC ";
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

        public DataTable GetDownloadView(string lang)
        {
            DataTable datatable = new DataTable();
            using (SqlConnection connection = base.GetConnection())
            {
                SqlCommand command = new SqlCommand("_DownloadView", connection) {
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

        public DataTable GetDownloadViewHome(string lang)
        {
            DataTable datatable = new DataTable();
            using (SqlConnection connection = base.GetConnection())
            {
                SqlCommand command = new SqlCommand("_DownloadViewHome", connection) {
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

        public DataTable GetDownloadViewHome(string lang, int n)
        {
            DataTable datatable = new DataTable();
            using (SqlConnection connection = base.GetConnection())
            {
                string SQL = "Select top " + n.ToString() + " * from tblDownload where [Language] = '" + lang + "' AND [Ishome] = 1 AND [Status] = 1 ORDER BY [DownloadID] DESC ";
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

        public DataTable GetDownloadViewHome(string lang, int n, string approval)
        {
            DataTable datatable = new DataTable();
            using (SqlConnection connection = base.GetConnection())
            {
                string SQL = "Select top " + n.ToString() + " * from tblDownload where [Language] = '" + lang + "' AND [Ishome] = 1 AND [Status] = 1 AND [IsApproval] = " + approval + " ORDER BY [DownloadID] DESC ";
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

        public DataTable GetDownloadViewHome(string lang, string strCate, int n)
        {
            DataTable datatable = new DataTable();
            using (SqlConnection connection = base.GetConnection())
            {
                string SQL = "Select top " + n.ToString() + " * from tblDownload where [Language] = '" + lang + "' AND CateDownloadID in('" + strCate + "') AND [IsHome] = 1 AND [Status] = 1 ORDER BY [DownloadID] DESC ";
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

        public void UpdateDownload(Download download)
        {
            using (SqlConnection connection = base.GetConnection())
            {
                SqlCommand command = new SqlCommand("_DownloadUpdate", connection) {
                    CommandType = CommandType.StoredProcedure
                };
                command.Parameters.AddWithValue("@Type", 1);
                command.Parameters.AddWithValue("@DownloadID", download.DownloadID);
                command.Parameters.AddWithValue("@CateDownloadID", download.CateDownloadID);
                command.Parameters.AddWithValue("@Title", download.Title);
                command.Parameters.AddWithValue("@ShortDescribe", download.ShortDescribe);
                command.Parameters.AddWithValue("@FullDescribe", download.FullDescribe);
                command.Parameters.AddWithValue("@ImageThumb", download.ImageThumb);
                command.Parameters.AddWithValue("@FileName", download.FileName);
                command.Parameters.AddWithValue("@Author", download.Author);
                command.Parameters.AddWithValue("@PostDate", download.PostDate);
                command.Parameters.AddWithValue("@RelationTotal", download.RelationTotal);
                command.Parameters.AddWithValue("@Status", download.Status);
                command.Parameters.AddWithValue("@Language", download.Language);
                command.Parameters.AddWithValue("@Ishot", download.Ishot);
                command.Parameters.AddWithValue("@Isview", download.Isview);
                command.Parameters.AddWithValue("@Ishome", download.Ishome);
                command.Parameters.AddWithValue("@IsComment", download.IsComment);
                command.Parameters.AddWithValue("@ApprovalDate", download.ApprovalDate);
                command.Parameters.AddWithValue("@ApprovalUserName", download.ApprovalUserName);
                command.Parameters.AddWithValue("@IsApproval", download.IsApproval);
                command.Parameters.AddWithValue("@CreatedUserName", download.CreatedUserName);
                command.Parameters.AddWithValue("@CommentTotal", download.CommentTotal);
                connection.Open();
                if (command.ExecuteNonQuery() <= 0)
                {
                    throw new DataAccessException("Kh\x00f4ng thể cập nhật tin");
                }
                command.Dispose();
            }
        }

        public void UpdateDownload(string strId, string value)
        {
            using (SqlConnection connection = base.GetConnection())
            {
                string SQL = "update tblDownload set Status = " + value + " where DownloadID in('" + strId + "')";
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

        public void UpdateDownloadApproval(int Id, string value, string username, DateTime date)
        {
            using (SqlConnection connection = base.GetConnection())
            {
                string SQL = "update tblDownload set IsApproval = " + value + ", ApprovalUserName = '" + username + "',ApprovalDate = @Date  where DownloadID = @DownloadID";
                SqlCommand command = new SqlCommand(SQL, connection) {
                    CommandText = SQL
                };
                command.Parameters.AddWithValue("@Date", date);
                command.Parameters.AddWithValue("@DownloadID", Id);
                connection.Open();
                if (command.ExecuteNonQuery() <= 0)
                {
                    throw new DataAccessException("Kh\x00f4ng cập nhật được tin n\x00e0o");
                }
                command.Dispose();
            }
        }

        public void UpdateDownloadApproval(string strId, string value, string username, DateTime date)
        {
            using (SqlConnection connection = base.GetConnection())
            {
                string SQL = "update tblDownload set IsApproval = " + value + ", ApprovalUserName = '" + username + "',ApprovalDate = @Date  where DownloadID in('" + strId + "')";
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

