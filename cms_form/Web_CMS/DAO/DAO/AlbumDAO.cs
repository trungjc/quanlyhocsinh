namespace DAO
{
    using ETO;
    using System;
    using System.Data;
    using System.Data.SqlClient;

    public class AlbumDAO : BaseDAO
    {
        private Album AlbumReader(SqlDataReader reader)
        {
            return new Album { AlbumID = (int) reader["AlbumID"], CateNewsID = (int) reader["CateNewsID"], ImageLarge = (string) reader["ImageLarge"], ImageThumb = (string) reader["ImageThumb"], IsHome = (bool) reader["IsHome"], Order = (int) reader["Order"] };
        }

        public void AlbumUpOrder(int cId, int cOrder)
        {
            using (SqlConnection connection = base.GetConnection())
            {
                SqlCommand command = new SqlCommand("_AlbumUpOrder", connection) {
                    CommandType = CommandType.StoredProcedure
                };
                command.Parameters.AddWithValue("@AlbumID", cId);
                command.Parameters.AddWithValue("@Order", cOrder);
                connection.Open();
                if (command.ExecuteNonQuery() <= 0)
                {
                    throw new DataAccessException("Kh\x00f4ng thể cập nhật danh mục tin");
                }
                command.Dispose();
            }
        }

        public void CreateAlbum(Album album)
        {
            using (SqlConnection connection = base.GetConnection())
            {
                SqlCommand command = new SqlCommand("_AlbumUpdate", connection) {
                    CommandType = CommandType.StoredProcedure
                };
                command.Parameters.AddWithValue("@Type", 0);
                command.Parameters.AddWithValue("@AlbumID", 0);
                command.Parameters.AddWithValue("@CateNewsID", album.CateNewsID);
                command.Parameters.AddWithValue("@ImageThumb", album.ImageThumb);
                command.Parameters.AddWithValue("@ImageLarge", album.ImageLarge);
                command.Parameters.AddWithValue("@IsHome", album.IsHome);
                command.Parameters.AddWithValue("@Order", album.Order);
                connection.Open();
                if (command.ExecuteNonQuery() <= 0)
                {
                    throw new DataAccessException("Khong them moi duoc album");
                }
                command.Dispose();
            }
        }

        public void DeleteAlbum(int Id)
        {
            using (SqlConnection connection = base.GetConnection())
            {
                SqlCommand command = new SqlCommand("_AlbumDelete", connection) {
                    CommandType = CommandType.StoredProcedure
                };
                command.Parameters.AddWithValue("@AlbumID", Id);
                connection.Open();
                if (command.ExecuteNonQuery() <= 0)
                {
                    throw new DataAccessException("Khong xoa duoc album");
                }
                command.Dispose();
            }
        }

        public DataTable GetAlbumAll()
        {
            DataTable datatable = new DataTable();
            using (SqlConnection connection = base.GetConnection())
            {
                SqlCommand command = new SqlCommand("_AlbumGetAll", connection) {
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

        public DataTable GetAlbumByCate(int cId)
        {
            DataTable datatable = new DataTable();
            using (SqlConnection connection = base.GetConnection())
            {
                SqlCommand command = new SqlCommand("_AlbumGetByCate", connection) {
                    CommandType = CommandType.StoredProcedure
                };
                command.Parameters.AddWithValue("@CateNewsID", cId);
                connection.Open();
                using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                {
                    adapter.Fill(datatable);
                    command.Dispose();
                }
            }
            return datatable;
        }

        public Album GetAlbumById(int Id)
        {
            Album album = null;
            using (SqlConnection connection = base.GetConnection())
            {
                SqlCommand command = new SqlCommand("_AlbumGetById", connection) {
                    CommandType = CommandType.StoredProcedure
                };
                command.Parameters.AddWithValue("@AlbumID", Id);
                connection.Open();
                using (SqlDataReader reader = command.ExecuteReader(CommandBehavior.CloseConnection))
                {
                    if (!reader.Read())
                    {
                        throw new DataAccessException("Kh\x00f4ng t\x00ecm thấy gi\x00e1 trị n\x00e0o");
                    }
                    album = this.AlbumReader(reader);
                    command.Dispose();
                }
            }
            return album;
        }

        public DataTable GetAlbumIsHome()
        {
            DataTable datatable = new DataTable();
            using (SqlConnection connection = base.GetConnection())
            {
                SqlCommand command = new SqlCommand("_AlbumGetByCate", connection) {
                    CommandType = CommandType.StoredProcedure
                };
                command.Parameters.AddWithValue("@CateNewsID", 0);
                connection.Open();
                using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                {
                    adapter.Fill(datatable);
                    command.Dispose();
                }
            }
            return datatable;
        }

        public void UpdateAlbum(Album album)
        {
            using (SqlConnection connection = base.GetConnection())
            {
                SqlCommand command = new SqlCommand("_AlbumUpdate", connection) {
                    CommandType = CommandType.StoredProcedure
                };
                command.Parameters.AddWithValue("@Type", 1);
                command.Parameters.AddWithValue("@AlbumID", album.AlbumID);
                command.Parameters.AddWithValue("@CateNewsID", album.CateNewsID);
                command.Parameters.AddWithValue("@ImageThumb", album.ImageThumb);
                command.Parameters.AddWithValue("@ImageLarge", album.ImageLarge);
                command.Parameters.AddWithValue("@IsHome", album.IsHome);
                command.Parameters.AddWithValue("@Order", album.Order);
                connection.Open();
                if (command.ExecuteNonQuery() <= 0)
                {
                    throw new DataAccessException("Khong them moi duoc album");
                }
                command.Dispose();
            }
        }
    }
}

