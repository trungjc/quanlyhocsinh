namespace DAO
{
    using ETO;
    using System;
    using System.Data;
    using System.Data.SqlClient;

    public class RSSDAO : BaseDAO
    {
        public void CreateRSS(RSS rss)
        {
            using (SqlConnection connection = base.GetConnection())
            {
                SqlCommand command = new SqlCommand("_RSSUpdate", connection) {
                    CommandType = CommandType.StoredProcedure
                };
                command.Parameters.AddWithValue("@Type", 0);
                command.Parameters.AddWithValue("@RSSID", 0);
                command.Parameters.AddWithValue("@RSSName", rss.RSSName);
                command.Parameters.AddWithValue("@RSSUrl", rss.RSSUrl);
                command.Parameters.AddWithValue("@Image", rss.Image);
                command.Parameters.AddWithValue("ShortDescribe", rss.ShortDescribe);
                command.Parameters.AddWithValue("@Author", rss.Author);
                connection.Open();
                if (command.ExecuteNonQuery() <= 0)
                {
                    throw new DataAccessException("khong them moi duoc rss");
                }
                command.Dispose();
            }
        }

        public void DeleteRSS(int Id)
        {
            using (SqlConnection connection = base.GetConnection())
            {
                SqlCommand command = new SqlCommand("_RSSDelete", connection) {
                    CommandType = CommandType.StoredProcedure
                };
                command.Parameters.AddWithValue("@RSSID", Id);
                connection.Open();
                if (command.ExecuteNonQuery() <= 0)
                {
                    throw new DataAccessException("Khong xoa duoc rss");
                }
                command.Dispose();
            }
        }

        public DataTable GetRSSAll()
        {
            DataTable datatable = new DataTable();
            using (SqlConnection connection = base.GetConnection())
            {
                SqlCommand command = new SqlCommand("_RSSGetAll", connection) {
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

        public RSS GetRSSById(int Id)
        {
            RSS rss = null;
            using (SqlConnection connection = base.GetConnection())
            {
                SqlCommand command = new SqlCommand("_RSSGetById", connection) {
                    CommandType = CommandType.StoredProcedure
                };
                command.Parameters.AddWithValue("@RSSID", Id);
                connection.Open();
                using (SqlDataReader reader = command.ExecuteReader(CommandBehavior.CloseConnection))
                {
                    if (!reader.Read())
                    {
                        throw new DataAccessException("Khong tim thay gia tri rss");
                    }
                    rss = this.RSSReader(reader);
                    command.Dispose();
                }
            }
            return rss;
        }

        private RSS RSSReader(SqlDataReader reader)
        {
            return new RSS { RSSID = (int) reader["RSSID"], RSSName = (string) reader["RSSName"], Image = (string) reader["Image"], ShortDescribe = (string) reader["ShortDescribe"], RSSUrl = (string) reader["RSSUrl"], Author = (string) reader["Author"] };
        }

        public void UpdateRSS(RSS rss)
        {
            using (SqlConnection connection = base.GetConnection())
            {
                SqlCommand command = new SqlCommand("_RSSUpdate", connection) {
                    CommandType = CommandType.StoredProcedure
                };
                command.Parameters.AddWithValue("@Type", 1);
                command.Parameters.AddWithValue("@RSSID", rss.RSSID);
                command.Parameters.AddWithValue("@RSSName", rss.RSSName);
                command.Parameters.AddWithValue("@RSSUrl", rss.RSSUrl);
                command.Parameters.AddWithValue("@Image", rss.Image);
                command.Parameters.AddWithValue("ShortDescribe", rss.ShortDescribe);
                command.Parameters.AddWithValue("@Author", rss.Author);
                connection.Open();
                if (command.ExecuteNonQuery() <= 0)
                {
                    throw new DataAccessException("khong cap nhat duoc rss");
                }
                command.Dispose();
            }
        }
    }
}

