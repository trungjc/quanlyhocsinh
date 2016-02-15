namespace DAO
{
    using ETO;
    using System;
    using System.Data;
    using System.Data.SqlClient;

    public class AlbumsDAO : BaseDAO
    {
        public void AlbumsClickUpdate(int nId)
        {
            using (SqlConnection connection = base.GetConnection())
            {
                SqlCommand command = new SqlCommand("_AlbumsClickUpdate", connection) {
                    CommandType = CommandType.StoredProcedure
                };
                command.Parameters.AddWithValue("@AlbumsID", nId);
                connection.Open();
                if (command.ExecuteNonQuery() <= 0)
                {
                    throw new DataAccessException("Kh\x00f4ng thể cập nhật số lần click");
                }
                command.Dispose();
            }
        }

        public DataTable AlbumsFollow(int Id, int cId, int n)
        {
            DataTable datatable = new DataTable();
            using (SqlConnection connection = base.GetConnection())
            {
                string SQL = string.Concat(new object[] { "SELECT Top ", Convert.ToString(n), " * FROM tblAlbums WHERE AlbumsCateID = ", cId, " AND AlbumsID < ", Id, " ORDER BY AlbumsID DESC" });
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

        private Albums AlbumsReader(SqlDataReader reader)
        {
            return new Albums { 
                AlbumsID = (int) reader["AlbumsID"], AlbumsCateID = (int) reader["AlbumsCateID"], Title = (string) reader["Title"], Description = (string) reader["Description"], ImageThumb = (string) reader["ImageThumb"], ImageLarge = (string) reader["ImageLarge"], Author = (string) reader["Author"], PostDate = (DateTime) reader["PostDate"], Status = (bool) reader["Status"], Ishot = (bool) reader["Ishot"], Isview = (int) reader["Isview"], Ishome = (bool) reader["Ishome"], IsComment = (bool) reader["IsComment"], ApprovalDate = (DateTime) reader["ApprovalDate"], ApprovalUserName = (string) reader["ApprovalUserName"], IsApproval = (bool) reader["IsApproval"], 
                CreatedUserName = (string) reader["CreatedUserName"], CommentTotal = (int) reader["CommentTotal"]
             };
        }

        public DataTable AlbumsSearch(string keyword, int cateid)
        {
            DataTable datatable = new DataTable();
            using (SqlConnection connection = base.GetConnection())
            {
                SqlCommand command = new SqlCommand("_AlbumsSearch", connection) {
                    CommandType = CommandType.StoredProcedure
                };
                command.Parameters.AddWithValue("@Keyword", keyword);
                command.Parameters.AddWithValue("@AlbumsCateID", cateid);
                connection.Open();
                using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                {
                    adapter.Fill(datatable);
                    command.Dispose();
                }
            }
            return datatable;
        }

        public void CreateAlbums(Albums albums)
        {
            using (SqlConnection connection = base.GetConnection())
            {
                SqlCommand command = new SqlCommand("_AlbumsUpdate", connection) {
                    CommandType = CommandType.StoredProcedure
                };
                command.Parameters.AddWithValue("@Type", 0);
                command.Parameters.AddWithValue("@AlbumsID", 0);
                command.Parameters.AddWithValue("@AlbumsCateID", albums.AlbumsCateID);
                command.Parameters.AddWithValue("@Title", albums.Title);
                command.Parameters.AddWithValue("@Description", albums.Description);
                command.Parameters.AddWithValue("@ImageThumb", albums.ImageThumb);
                command.Parameters.AddWithValue("@ImageLarge", albums.ImageLarge);
                command.Parameters.AddWithValue("@Author", albums.Author);
                command.Parameters.AddWithValue("@PostDate", albums.PostDate);
                command.Parameters.AddWithValue("@Status", albums.Status);
                command.Parameters.AddWithValue("@Ishot", albums.Ishot);
                command.Parameters.AddWithValue("@Isview", albums.Isview);
                command.Parameters.AddWithValue("@Ishome", albums.Ishome);
                command.Parameters.AddWithValue("@IsComment", albums.IsComment);
                command.Parameters.AddWithValue("@ApprovalDate", albums.ApprovalDate);
                command.Parameters.AddWithValue("@ApprovalUserName", albums.ApprovalUserName);
                command.Parameters.AddWithValue("@IsApproval", albums.IsApproval);
                command.Parameters.AddWithValue("@CreatedUserName", albums.CreatedUserName);
                command.Parameters.AddWithValue("@CommentTotal", albums.CommentTotal);
                connection.Open();
                if (command.ExecuteNonQuery() <= 0)
                {
                    throw new DataAccessException("Kh\x00f4ng thể th\x00eam mới tin");
                }
                command.Dispose();
            }
        }

        public void DeleteAlbums(int Id)
        {
            using (SqlConnection connection = base.GetConnection())
            {
                SqlCommand command = new SqlCommand("_AlbumsDelete", connection) {
                    CommandType = CommandType.StoredProcedure
                };
                command.Parameters.AddWithValue("AlbumsID", Id);
                connection.Open();
                if (command.ExecuteNonQuery() <= 0)
                {
                    throw new DataAccessException("Kh\x00f4ng x\x00f3a được tin");
                }
                command.Dispose();
            }
        }

        public void DeleteAlbums(string sId)
        {
            using (SqlConnection connection = base.GetConnection())
            {
                string SQL = "delete tblAlbums where AlbumsID in('" + sId + "')";
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

        public DataTable GetAlbumsAll()
        {
            DataTable datatable = new DataTable();
            using (SqlConnection connection = base.GetConnection())
            {
                SqlCommand command = new SqlCommand("_AlbumsGetAll", connection) {
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

        public DataTable GetAlbumsByCateAll(string strCate)
        {
            DataTable datatable = new DataTable();
            using (SqlConnection connection = base.GetConnection())
            {
                string SQL = "select * from tblAlbums where AlbumsCateID in('" + strCate + "') order by albumsid desc";
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

        public DataTable GetAlbumsByCateHomeAll(string strCate)
        {
            DataTable datatable = new DataTable();
            using (SqlConnection connection = base.GetConnection())
            {
                string SQL = "select * from tblAlbums where status=1 and AlbumsCateID in('" + strCate + "') order by AlbumsID";
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

        public DataTable GetAlbumsByCateHomeAll(int n, string strCate)
        {
            DataTable datatable = new DataTable();
            using (SqlConnection connection = base.GetConnection())
            {
                string SQL = "select top " + n.ToString() + " * from tblAlbums where status=1 and AlbumsCateID in('" + strCate + "') order by AlbumsID";
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

        public DataTable GetAlbumsByCateHomeAll(int n, string strCate, string approval)
        {
            DataTable datatable = new DataTable();
            using (SqlConnection connection = base.GetConnection())
            {
                string SQL = "select top " + n.ToString() + " * from tblAlbums where status=1 and AlbumsCateID in('" + strCate + "')  AND [IsApproval] = " + approval + " order by AlbumsID desc";
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

        public DataTable GetAlbumsByCateHomeList(string strCate)
        {
            DataTable datatable = new DataTable();
            using (SqlConnection connection = base.GetConnection())
            {
                string SQL = "select * from tblAlbums where AlbumsCateID in('" + strCate + "') order by AlbumsID Desc";
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

        public DataTable GetAlbumsByCateHomeList(string strCate, int num)
        {
            DataTable datatable = new DataTable();
            using (SqlConnection connection = base.GetConnection())
            {
                string SQL = "select top " + Convert.ToString(num) + " * from tblAlbums where AlbumsCateID in('" + strCate + "') order by AlbumsID Desc";
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

        public DataTable GetAlbumsByCateHomeList(string strCate, int num, string approval)
        {
            DataTable datatable = new DataTable();
            using (SqlConnection connection = base.GetConnection())
            {
                string SQL = "select top " + Convert.ToString(num) + " * from tblAlbums where AlbumsCateID in('" + strCate + "')  AND [IsApproval] = " + approval + " order by AlbumsID Desc";
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

        public Albums GetAlbumsById(int Id)
        {
            Albums albums = null;
            using (SqlConnection connection = base.GetConnection())
            {
                SqlCommand command = new SqlCommand("_AlbumsGetById", connection) {
                    CommandType = CommandType.StoredProcedure
                };
                command.Parameters.AddWithValue("@AlbumsID", Id);
                connection.Open();
                using (SqlDataReader reader = command.ExecuteReader(CommandBehavior.CloseConnection))
                {
                    if (!reader.Read())
                    {
                        throw new DataAccessException("Kh\x00f4ng t\x00ecm thấy tin");
                    }
                    albums = this.AlbumsReader(reader);
                }
                command.Dispose();
            }
            return albums;
        }

        public DataTable GetAlbumsHot()
        {
            DataTable datatable = new DataTable();
            using (SqlConnection connection = base.GetConnection())
            {
                SqlCommand command = new SqlCommand("_AlbumsHot", connection) {
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

        public DataTable GetAlbumsHot(int n)
        {
            DataTable datatable = new DataTable();
            using (SqlConnection connection = base.GetConnection())
            {
                string SQL = "Select top " + n.ToString() + " * from tblAlbums where [Status] = 1 ORDER BY [AlbumsID] DESC ";
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

        public DataTable GetAlbumsHot(int n, string approval)
        {
            DataTable datatable = new DataTable();
            using (SqlConnection connection = base.GetConnection())
            {
                string SQL = "Select top " + n.ToString() + " * from tblAlbums where Ishot = 1 AND Status = 1 AND IsApproval = " + approval + " ORDER BY AlbumsID DESC ";
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

        public DataTable GetAlbumsView()
        {
            DataTable datatable = new DataTable();
            using (SqlConnection connection = base.GetConnection())
            {
                SqlCommand command = new SqlCommand("_AlbumsView", connection) {
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

        public DataTable GetAlbumsViewHome()
        {
            DataTable datatable = new DataTable();
            using (SqlConnection connection = base.GetConnection())
            {
                SqlCommand command = new SqlCommand("_AlbumsViewHome", connection) {
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

        public DataTable GetAlbumsViewHome(int n)
        {
            DataTable datatable = new DataTable();
            using (SqlConnection connection = base.GetConnection())
            {
                string SQL = "Select top " + n.ToString() + " * from tblAlbums where [IsHome] = 1 AND [Status] = 1 ORDER BY [AlbumsID] DESC ";
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

        public DataTable GetAlbumsViewHome(int n, string approval)
        {
            DataTable datatable = new DataTable();
            using (SqlConnection connection = base.GetConnection())
            {
                string SQL = "Select top " + n.ToString() + " * from tblAlbums where [IsHome] = 1 AND [Status] = 1 AND [IsApproval] = " + approval + " ORDER BY [AlbumsID] DESC ";
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

        public void UpdateAlbums(Albums albums)
        {
            using (SqlConnection connection = base.GetConnection())
            {
                SqlCommand command = new SqlCommand("_AlbumsUpdate", connection) {
                    CommandType = CommandType.StoredProcedure
                };
                command.Parameters.AddWithValue("@Type", 1);
                command.Parameters.AddWithValue("@AlbumsID", albums.AlbumsID);
                command.Parameters.AddWithValue("@AlbumsCateID", albums.AlbumsCateID);
                command.Parameters.AddWithValue("@Title", albums.Title);
                command.Parameters.AddWithValue("@Description", albums.Description);
                command.Parameters.AddWithValue("@ImageThumb", albums.ImageThumb);
                command.Parameters.AddWithValue("@ImageLarge", albums.ImageLarge);
                command.Parameters.AddWithValue("@Author", albums.Author);
                command.Parameters.AddWithValue("@PostDate", albums.PostDate);
                command.Parameters.AddWithValue("@Status", albums.Status);
                command.Parameters.AddWithValue("@Ishot", albums.Ishot);
                command.Parameters.AddWithValue("@Isview", albums.Isview);
                command.Parameters.AddWithValue("@Ishome", albums.Ishome);
                command.Parameters.AddWithValue("@IsComment", albums.IsComment);
                command.Parameters.AddWithValue("@CommentTotal", albums.CommentTotal);
                command.Parameters.AddWithValue("@CreatedUserName", albums.CreatedUserName);
                command.Parameters.AddWithValue("@ApprovalDate", albums.ApprovalDate);
                command.Parameters.AddWithValue("@IsApproval", albums.IsApproval);
                command.Parameters.AddWithValue("@ApprovalUserName", albums.ApprovalUserName);
                
                connection.Open();
                if (command.ExecuteNonQuery() <= 0)
                {
                    throw new DataAccessException("Kh\x00f4ng thể cập nhật tin");
                }
                command.Dispose();
            }
        }

        public void UpdateAlbums(string strId, string value)
        {
            using (SqlConnection connection = base.GetConnection())
            {
                string SQL = "update tblAlbums set Status = " + value + " where AlbumsID in('" + strId + "')";
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

        public void UpdateAlbumsApproval(int Id, string value, string username, DateTime date)
        {
            using (SqlConnection connection = base.GetConnection())
            {
                string SQL = "update tblAlbums set IsApproval = " + value + ", ApprovalUserName = '" + username + "',ApprovalDate = @Date  where AlbumsID = @AlbumsID";
                SqlCommand command = new SqlCommand(SQL, connection) {
                    CommandText = SQL
                };
                command.Parameters.AddWithValue("@Date", date);
                command.Parameters.AddWithValue("@AlbumsID", Id);
                connection.Open();
                if (command.ExecuteNonQuery() <= 0)
                {
                    throw new DataAccessException("Kh\x00f4ng cập nhật được tin n\x00e0o");
                }
                command.Dispose();
            }
        }

        public void UpdateAlbumsApproval(string strId, string value, string username, DateTime date)
        {
            using (SqlConnection connection = base.GetConnection())
            {
                string SQL = "update tblAlbums set IsApproval = " + value + ", ApprovalUserName = '" + username + "',ApprovalDate = @Date  where AlbumsID in('" + strId + "')";
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

