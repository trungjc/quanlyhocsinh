namespace DAO
{
    using ETO;
    using System;
    using System.Data;
    using System.Data.SqlClient;

    public class VideoDAO : BaseDAO
    {
        public void CreateVideo(Video Video)
        {
            using (SqlConnection connection = base.GetConnection())
            {
                SqlCommand command = new SqlCommand("_VideoUpdate", connection)
                {
                    CommandType = CommandType.StoredProcedure
                };
                command.Parameters.AddWithValue("@Type", 0);
                command.Parameters.AddWithValue("@VideoID", 0);
                command.Parameters.AddWithValue("@VideoName", Video.VideoName);
                command.Parameters.AddWithValue("@VideoUrl", Video.VideoUrl);
                command.Parameters.AddWithValue("@Image", Video.Image);
                command.Parameters.AddWithValue("ShortDescribe", Video.ShortDescribe);
                command.Parameters.AddWithValue("@Language", Video.Language);
                command.Parameters.AddWithValue("@PostDate", Video.PostDate);
                command.Parameters.AddWithValue("@IsHome", Video.IsHome);
                command.Parameters.AddWithValue("@FileName", Video.FileName);
                command.Parameters.AddWithValue("@VideoType", Video.VideoType);
                command.Parameters.AddWithValue("@VideoEmbed", Video.VideoEmbed);
                connection.Open();
                if (command.ExecuteNonQuery() <= 0)
                {
                    throw new DataAccessException("khong them moi duoc Video");
                }
                command.Dispose();
            }
        }

        public void DeleteVideo(int Id)
        {
            using (SqlConnection connection = base.GetConnection())
            {
                SqlCommand command = new SqlCommand("_VideoDelete", connection)
                {
                    CommandType = CommandType.StoredProcedure
                };
                command.Parameters.AddWithValue("@VideoID", Id);
                connection.Open();
                if (command.ExecuteNonQuery() <= 0)
                {
                    throw new DataAccessException("Khong xoa duoc Video");
                }
                command.Dispose();
            }
        }

        public DataTable GetVideoAll(string lang)
        {
            DataTable datatable = new DataTable();
            using (SqlConnection connection = base.GetConnection())
            {
                SqlCommand command = new SqlCommand("_VideoGetAll", connection)
                {
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

        public Video GetVideoById(int Id)
        {
            Video Video = null;
            using (SqlConnection connection = base.GetConnection())
            {
                SqlCommand command = new SqlCommand("_VideoGetById", connection)
                {
                    CommandType = CommandType.StoredProcedure
                };
                command.Parameters.AddWithValue("@VideoID", Id);
                connection.Open();
                using (SqlDataReader reader = command.ExecuteReader(CommandBehavior.CloseConnection))
                {
                    if (reader.Read())
                    {
                        Video = this.VideoReader(reader);
                    }
                    else
                    {
                        Video = null;
                    }
                    command.Dispose();
                }
            }
            return Video;
        }

        public Video GetVideoHot(string lang)
        {
            Video Video = null;
            using (SqlConnection connection = base.GetConnection())
            {
                SqlCommand command = new SqlCommand("_VideoHot", connection)
                {
                    CommandType = CommandType.StoredProcedure
                };
                command.Parameters.AddWithValue("@Language", lang);
                connection.Open();
                using (SqlDataReader reader = command.ExecuteReader(CommandBehavior.CloseConnection))
                {
                    if (!reader.Read())
                    {
                        throw new DataAccessException("Khong tim thay gia tri Video");
                    }
                    Video = this.VideoReader(reader);
                    command.Dispose();
                }
            }
            return Video;
        }

        public void UpdateVideo(Video Video)
        {
            using (SqlConnection connection = base.GetConnection())
            {
                SqlCommand command = new SqlCommand("_VideoUpdate", connection)
                {
                    CommandType = CommandType.StoredProcedure
                };
                command.Parameters.AddWithValue("@Type", 1);
                command.Parameters.AddWithValue("@VideoID", Video.VideoID);
                command.Parameters.AddWithValue("@VideoName", Video.VideoName);
                command.Parameters.AddWithValue("@VideoUrl", Video.VideoUrl);
                command.Parameters.AddWithValue("@Image", Video.Image);
                command.Parameters.AddWithValue("ShortDescribe", Video.ShortDescribe);
                command.Parameters.AddWithValue("@Language", Video.Language);
                command.Parameters.AddWithValue("@PostDate", Video.PostDate);
                command.Parameters.AddWithValue("@IsHome", Video.IsHome);
                command.Parameters.AddWithValue("@FileName", Video.FileName);
                command.Parameters.AddWithValue("@VideoType", Video.VideoType);
                command.Parameters.AddWithValue("@VideoEmbed", Video.VideoEmbed);

                connection.Open();
                if (command.ExecuteNonQuery() <= 0)
                {
                    throw new DataAccessException("khong cap nhat duoc Video");
                }
                command.Dispose();
            }
        }

        private Video VideoReader(SqlDataReader reader)
        {
            return new Video { VideoID = (int)reader["VideoID"], VideoName = (string)reader["VideoName"], Image = (string)reader["Image"], ShortDescribe = (string)reader["ShortDescribe"], VideoUrl = (string)reader["VideoUrl"], Language = (string)reader["Language"], PostDate = (DateTime)reader["PostDate"], IsHome = (bool)reader["IsHome"], FileName = (string)reader["FileName"], VideoType = (bool)reader["VideoType"], VideoEmbed = (string)reader["VideoEmbed"] };
        }
    }
}

