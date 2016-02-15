namespace DAO
{
    using ETO;
    using System;
    using System.Data;
    using System.Data.SqlClient;

    public class AnnounceDAO : BaseDAO
    {
        public void AnnounceClickUpdate(int nId)
        {
            using (SqlConnection connection = base.GetConnection())
            {
                SqlCommand command = new SqlCommand("_AnnounceClickUpdate", connection) {
                    CommandType = CommandType.StoredProcedure
                };
                command.Parameters.AddWithValue("@AnnounceID", nId);
                connection.Open();
                if (command.ExecuteNonQuery() <= 0)
                {
                    throw new DataAccessException("Kh\x00f4ng thể cập nhật số lần click");
                }
                command.Dispose();
            }
        }

        public DataTable AnnounceFollow(int Id, int cId, int n)
        {
            DataTable datatable = new DataTable();
            using (SqlConnection connection = base.GetConnection())
            {
                string SQL = string.Concat(new object[] { "SELECT Top ", Convert.ToString(n), " * FROM tblAnnounce WHERE CateAnnounceID = ", cId, " AND AnnounceID < ", Id, " ORDER BY AnnounceID DESC" });
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

        private Announce AnnounceReader(SqlDataReader reader)
        {
            return new Announce { 
                AnnounceID = (int) reader["AnnounceID"], CateAnnounceID = (int) reader["CateAnnounceID"], Title = (string) reader["Title"], ShortDescribe = (string) reader["ShortDescribe"], FullDescribe = (string) reader["FullDescribe"], ImageThumb = (string) reader["ImageThumb"], FileName = (string) reader["FileName"], Author = (string) reader["Author"], PostDate = (DateTime) reader["PostDate"], RelationTotal = (int) reader["RelationTotal"], Status = (bool) reader["Status"], Language = (string) reader["Language"], Ishot = (bool) reader["Ishot"], Isview = (int) reader["Isview"], Ishome = (bool) reader["Ishome"], IsComment = (bool) reader["IsComment"], 
                ApprovalDate = (DateTime) reader["ApprovalDate"], ApprovalUserName = (string) reader["ApprovalUserName"], IsApproval = (bool) reader["IsApproval"], CreatedUserName = (string) reader["CreatedUserName"], CommentTotal = (int) reader["CommentTotal"]
             };
        }

        public DataTable AnnounceSearch(string keyword, int cateid, string lang)
        {
            DataTable datatable = new DataTable();
            using (SqlConnection connection = base.GetConnection())
            {
                SqlCommand command = new SqlCommand("_AnnounceSearch", connection) {
                    CommandType = CommandType.StoredProcedure
                };
                command.Parameters.AddWithValue("@Keyword", keyword);
                command.Parameters.AddWithValue("@CateAnnounceID", cateid);
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

        public void CreateAnnounce(Announce announce)
        {
            using (SqlConnection connection = base.GetConnection())
            {
                SqlCommand command = new SqlCommand("_AnnounceUpdate", connection) {
                    CommandType = CommandType.StoredProcedure
                };
                command.Parameters.AddWithValue("@Type", 0);
                command.Parameters.AddWithValue("@AnnounceID", 0);
                command.Parameters.AddWithValue("@CateAnnounceID", announce.CateAnnounceID);
                command.Parameters.AddWithValue("@Title", announce.Title);
                command.Parameters.AddWithValue("@ShortDescribe", announce.ShortDescribe);
                command.Parameters.AddWithValue("@FullDescribe", announce.FullDescribe);
                command.Parameters.AddWithValue("@ImageThumb", announce.ImageThumb);
                command.Parameters.AddWithValue("@FileName", announce.FileName);
                command.Parameters.AddWithValue("@Author", announce.Author);
                command.Parameters.AddWithValue("@PostDate", announce.PostDate);
                command.Parameters.AddWithValue("@RelationTotal", announce.RelationTotal);
                command.Parameters.AddWithValue("@Status", announce.Status);
                command.Parameters.AddWithValue("@Language", announce.Language);
                command.Parameters.AddWithValue("@Ishot", announce.Ishot);
                command.Parameters.AddWithValue("@Isview", announce.Isview);
                command.Parameters.AddWithValue("@Ishome", announce.Ishome);
                command.Parameters.AddWithValue("@IsComment", announce.IsComment);
                command.Parameters.AddWithValue("@ApprovalDate", announce.ApprovalDate);
                command.Parameters.AddWithValue("@ApprovalUserName", announce.ApprovalUserName);
                command.Parameters.AddWithValue("@IsApproval", announce.IsApproval);
                command.Parameters.AddWithValue("@CreatedUserName", announce.CreatedUserName);
                command.Parameters.AddWithValue("@CommentTotal", announce.CommentTotal);
                connection.Open();
                if (command.ExecuteNonQuery() <= 0)
                {
                    throw new DataAccessException("Kh\x00f4ng thể th\x00eam mới tin");
                }
                command.Dispose();
            }
        }

        public void DeleteAnnounce(int Id)
        {
            using (SqlConnection connection = base.GetConnection())
            {
                SqlCommand command = new SqlCommand("_AnnounceDelete", connection) {
                    CommandType = CommandType.StoredProcedure
                };
                command.Parameters.AddWithValue("AnnounceID", Id);
                connection.Open();
                if (command.ExecuteNonQuery() <= 0)
                {
                    throw new DataAccessException("Kh\x00f4ng x\x00f3a được tin");
                }
                command.Dispose();
            }
        }

        public void DeleteAnnounce(string sId)
        {
            using (SqlConnection connection = base.GetConnection())
            {
                string SQL = "delete tblAnnounce where AnnounceID in('" + sId + "')";
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

        public DataTable GetAnnounceAll(string lang)
        {
            DataTable datatable = new DataTable();
            using (SqlConnection connection = base.GetConnection())
            {
                SqlCommand command = new SqlCommand("_AnnounceGetAll", connection) {
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

        public DataTable GetAnnounceByCateAll(string strCate)
        {
            DataTable datatable = new DataTable();
            using (SqlConnection connection = base.GetConnection())
            {
                string SQL = "select * from tblAnnounce where CateAnnounceID in('" + strCate + "') order by announceid desc";
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

        public DataTable GetAnnounceByCateHomeAll(string strCate)
        {
            DataTable datatable = new DataTable();
            using (SqlConnection connection = base.GetConnection())
            {
                string SQL = "select * from tblAnnounce where status=1 and CateAnnounceID in('" + strCate + "') order by AnnounceID";
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

        public DataTable GetAnnounceByCateHomeAll(int n, string strCate)
        {
            DataTable datatable = new DataTable();
            using (SqlConnection connection = base.GetConnection())
            {
                string SQL = "select top " + n.ToString() + " * from tblAnnounce where status=1 and CateAnnounceID in('" + strCate + "') order by AnnounceID";
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

        public DataTable GetAnnounceByCateHomeAll(int n, string strCate, string approval)
        {
            DataTable datatable = new DataTable();
            using (SqlConnection connection = base.GetConnection())
            {
                string SQL = "select top " + n.ToString() + " * from tblAnnounce where status=1 and CateAnnounceID in('" + strCate + "')  AND [IsApproval] = " + approval + " order by AnnounceID";
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

        public DataTable GetAnnounceByCateHomeList(string strCate)
        {
            DataTable datatable = new DataTable();
            using (SqlConnection connection = base.GetConnection())
            {
                string SQL = "select * from tblAnnounce where CateAnnounceID in('" + strCate + "') order by AnnounceID Desc";
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

        public DataTable GetAnnounceByCateHomeList(string strCate, int num)
        {
            DataTable datatable = new DataTable();
            using (SqlConnection connection = base.GetConnection())
            {
                string SQL = "select top " + Convert.ToString(num) + " * from tblAnnounce where  CateAnnounceID in('" + strCate + "') order by AnnounceID Desc";
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

        public DataTable GetAnnounceByCateHomeList(string strCate, int num, string approval)
        {
            DataTable datatable = new DataTable();
            using (SqlConnection connection = base.GetConnection())
            {
                string SQL = "select top " + Convert.ToString(num) + " * from tblAnnounce where  CateAnnounceID in('" + strCate + "')  AND [IsApproval] = " + approval + " order by AnnounceID Desc";
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

        public DataTable GetAnnounceByCateIsHomeAll(string strCate)
        {
            DataTable datatable = new DataTable();
            using (SqlConnection connection = base.GetConnection())
            {
                string SQL = "select * from tblAnnounce where status=1 and isHome = 1 and CateAnnounceID in('" + strCate + "') order by AnnounceID";
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

        public DataTable GetAnnounceByCateIsHomeAll(int n, string strCate)
        {
            DataTable datatable = new DataTable();
            using (SqlConnection connection = base.GetConnection())
            {
                string SQL = "select top " + n.ToString() + " * from tblAnnounce where status=1 and isHome = 1 and CateAnnounceID in('" + strCate + "') order by AnnounceID";
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

        public DataTable GetAnnounceByCateIsHomeAll(int n, string strCate, string approval)
        {
            DataTable datatable = new DataTable();
            using (SqlConnection connection = base.GetConnection())
            {
                string SQL = "select top " + n.ToString() + " * from tblAnnounce where status=1 and isHome = 1 and CateAnnounceID in('" + strCate + "')  AND [IsApproval] = " + approval + " order by AnnounceID";
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

        public Announce GetAnnounceById(int Id)
        {
            Announce announce = null;
            using (SqlConnection connection = base.GetConnection())
            {
                SqlCommand command = new SqlCommand("_AnnounceGetById", connection) {
                    CommandType = CommandType.StoredProcedure
                };
                command.Parameters.AddWithValue("@AnnounceID", Id);
                connection.Open();
                using (SqlDataReader reader = command.ExecuteReader(CommandBehavior.CloseConnection))
                {
                    if (!reader.Read())
                    {
                        throw new DataAccessException("Kh\x00f4ng t\x00ecm thấy tin");
                    }
                    announce = this.AnnounceReader(reader);
                }
                command.Dispose();
            }
            return announce;
        }

        public DataTable GetAnnounceHot(string lang)
        {
            DataTable datatable = new DataTable();
            using (SqlConnection connection = base.GetConnection())
            {
                SqlCommand command = new SqlCommand("_AnnounceHot", connection) {
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

        public DataTable GetAnnounceHot(string lang, int n)
        {
            DataTable datatable = new DataTable();
            using (SqlConnection connection = base.GetConnection())
            {
                string SQL = "Select top " + n.ToString() + " * from tblAnnounce where [Language] = '" + lang + "' AND [Ishot] = 1 AND [Status] = 1 ORDER BY [AnnounceID] DESC ";
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

        public DataTable GetAnnounceHot(string lang, int n, string approval)
        {
            DataTable datatable = new DataTable();
            using (SqlConnection connection = base.GetConnection())
            {
                string SQL = "Select top " + n.ToString() + " * from tblAnnounce where [Language] = '" + lang + "' AND [Ishot] = 1 AND [Status] = 1 AND [IsApproval] = " + approval + " ORDER BY [AnnounceID] DESC ";
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

        public DataTable GetAnnounceNews(int num)
        {
            DataTable datatable = new DataTable();
            using (SqlConnection connection = base.GetConnection())
            {
                string SQL = "select top " + Convert.ToString(num) + " * from tblAnnounce order by AnnounceID Desc";
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

        public DataTable GetAnnounceView(string lang)
        {
            DataTable datatable = new DataTable();
            using (SqlConnection connection = base.GetConnection())
            {
                SqlCommand command = new SqlCommand("_AnnounceView", connection) {
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

        public DataTable GetAnnounceViewHome(string lang)
        {
            DataTable datatable = new DataTable();
            using (SqlConnection connection = base.GetConnection())
            {
                SqlCommand command = new SqlCommand("_AnnounceViewHome", connection) {
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

        public DataTable GetAnnounceViewHome(string lang, int n)
        {
            DataTable datatable = new DataTable();
            using (SqlConnection connection = base.GetConnection())
            {
                string SQL = "Select top " + n.ToString() + " * from tblAnnounce where [Language] = '" + lang + "' AND [Ishome] = 1 AND [Status] = 1 ORDER BY [AnnounceID] DESC ";
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

        public DataTable GetAnnounceViewHome(string lang, int n, string approval)
        {
            DataTable datatable = new DataTable();
            using (SqlConnection connection = base.GetConnection())
            {
                string SQL = "Select top " + n.ToString() + " * from tblAnnounce where [Language] = '" + lang + "' AND [Ishome] = 1 AND [Status] = 1 AND [IsApproval] = " + approval + " ORDER BY [AnnounceID] DESC ";
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

        public void UpdateAnnounce(Announce announce)
        {
            using (SqlConnection connection = base.GetConnection())
            {
                SqlCommand command = new SqlCommand("_AnnounceUpdate", connection) {
                    CommandType = CommandType.StoredProcedure
                };
                command.Parameters.AddWithValue("@Type", 1);
                command.Parameters.AddWithValue("@AnnounceID", announce.AnnounceID);
                command.Parameters.AddWithValue("@CateAnnounceID", announce.CateAnnounceID);
                command.Parameters.AddWithValue("@Title", announce.Title);
                command.Parameters.AddWithValue("@ShortDescribe", announce.ShortDescribe);
                command.Parameters.AddWithValue("@FullDescribe", announce.FullDescribe);
                command.Parameters.AddWithValue("@ImageThumb", announce.ImageThumb);
                command.Parameters.AddWithValue("@FileName", announce.FileName);
                command.Parameters.AddWithValue("@Author", announce.Author);
                command.Parameters.AddWithValue("@PostDate", announce.PostDate);
                command.Parameters.AddWithValue("@RelationTotal", announce.RelationTotal);
                command.Parameters.AddWithValue("@Status", announce.Status);
                command.Parameters.AddWithValue("@Language", announce.Language);
                command.Parameters.AddWithValue("@Ishot", announce.Ishot);
                command.Parameters.AddWithValue("@Isview", announce.Isview);
                command.Parameters.AddWithValue("@Ishome", announce.Ishome);
                command.Parameters.AddWithValue("@IsComment", announce.IsComment);
                command.Parameters.AddWithValue("@ApprovalDate", announce.ApprovalDate);
                command.Parameters.AddWithValue("@ApprovalUserName", announce.ApprovalUserName);
                command.Parameters.AddWithValue("@IsApproval", announce.IsApproval);
                command.Parameters.AddWithValue("@CreatedUserName", announce.CreatedUserName);
                command.Parameters.AddWithValue("@CommentTotal", announce.CommentTotal);
                connection.Open();
                if (command.ExecuteNonQuery() <= 0)
                {
                    throw new DataAccessException("Kh\x00f4ng thể cập nhật tin");
                }
                command.Dispose();
            }
        }

        public void UpdateAnnounce(string strId, string value)
        {
            using (SqlConnection connection = base.GetConnection())
            {
                string SQL = "update tblAnnounce set Status = " + value + " where AnnounceID in('" + strId + "')";
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

        public void UpdateAnnounceApproval(int Id, string value, string username, DateTime date)
        {
            using (SqlConnection connection = base.GetConnection())
            {
                string SQL = "update tblAnnounce set IsApproval = " + value + ", ApprovalUserName = '" + username + "',ApprovalDate = @Date  where AnnounceID = @AnnounceID";
                SqlCommand command = new SqlCommand(SQL, connection) {
                    CommandText = SQL
                };
                command.Parameters.AddWithValue("@Date", date);
                command.Parameters.AddWithValue("@AnnounceID", Id);
                connection.Open();
                if (command.ExecuteNonQuery() <= 0)
                {
                    throw new DataAccessException("Kh\x00f4ng cập nhật được tin n\x00e0o");
                }
                command.Dispose();
            }
        }

        public void UpdateAnnounceApproval(string strId, string value, string username, DateTime date)
        {
            using (SqlConnection connection = base.GetConnection())
            {
                string SQL = "update tblAnnounce set IsApproval = " + value + ", ApprovalUserName = '" + username + "',ApprovalDate = @Date  where AnnounceID in('" + strId + "')";
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

