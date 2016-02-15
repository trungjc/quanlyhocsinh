namespace DAO
{
    using ETO;
    using System;
    using System.Data;
    using System.Data.SqlClient;

    public class LinkDAO : BaseDAO
    {
        public void CreateLink(Link link)
        {
            using (SqlConnection connection = base.GetConnection())
            {
                SqlCommand command = new SqlCommand("_LinkUpdate", connection) {
                    CommandType = CommandType.StoredProcedure
                };
                command.Parameters.AddWithValue("@Type", 0);
                command.Parameters.AddWithValue("@LinkID", 0);
                command.Parameters.AddWithValue("@LinkUrl", link.LinkUrl);
                command.Parameters.AddWithValue("@LinkImage", link.LinkImage);
                command.Parameters.AddWithValue("@LinkWidth", link.LinkWidth);
                command.Parameters.AddWithValue("@LinkHeight", link.LinkHeight);
                command.Parameters.AddWithValue("@LinkStatus", link.LinkStatus);
                command.Parameters.AddWithValue("@LinkType", link.LinkType);
                connection.Open();
                if (command.ExecuteNonQuery() <= 0)
                {
                    throw new DataAccessException("Khong them duoc quang cao");
                }
                command.Dispose();
            }
        }

        public void DeleteLink(int Id)
        {
            using (SqlConnection connection = base.GetConnection())
            {
                SqlCommand command = new SqlCommand("_LinkDelete", connection) {
                    CommandType = CommandType.StoredProcedure
                };
                command.Parameters.AddWithValue("@LinkID", Id);
                connection.Open();
                if (command.ExecuteNonQuery() <= 0)
                {
                    throw new DataAccessException("Khong xoa duoc quang cao");
                }
                command.Dispose();
            }
        }

        public DataTable GetLinkAll()
        {
            DataTable datatable = new DataTable();
            using (SqlConnection connection = base.GetConnection())
            {
                SqlCommand command = new SqlCommand("_LinkGetAll", connection) {
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

        public Link GetLinkById(int Id)
        {
            Link link = null;
            using (SqlConnection connection = base.GetConnection())
            {
                SqlCommand command = new SqlCommand("_LinkGetById", connection) {
                    CommandType = CommandType.StoredProcedure
                };
                command.Parameters.AddWithValue("@LinkID", Id);
                connection.Open();
                using (SqlDataReader reader = command.ExecuteReader(CommandBehavior.CloseConnection))
                {
                    if (!reader.Read())
                    {
                        throw new DataAccessException("Khong tim thay gia tri nao");
                    }
                    link = this.LinkReader(reader);
                    command.Dispose();
                }
            }
            return link;
        }

        private Link LinkReader(SqlDataReader reader)
        {
            return new Link { LinkID = (int) reader["LinkID"], LinkUrl = (string) reader["LinkUrl"], LinkImage = (string) reader["LinkImage"], LinkWidth = (int) reader["LinkWidth"], LinkHeight = (int) reader["LinkHeight"], LinkStatus = (bool) reader["LinkStatus"] };
        }

        public void UpdateLink(Link link)
        {
            using (SqlConnection connection = base.GetConnection())
            {
                SqlCommand command = new SqlCommand("_LinkUpdate", connection) {
                    CommandType = CommandType.StoredProcedure
                };
                command.Parameters.AddWithValue("@Type", 1);
                command.Parameters.AddWithValue("@LinkID", link.LinkID);
                command.Parameters.AddWithValue("@LinkUrl", link.LinkUrl);
                command.Parameters.AddWithValue("@LinkImage", link.LinkImage);
                command.Parameters.AddWithValue("@LinkWidth", link.LinkWidth);
                command.Parameters.AddWithValue("@LinkHeight", link.LinkHeight);
                command.Parameters.AddWithValue("@LinkStatus", link.LinkStatus);
                command.Parameters.AddWithValue("@LinkType", link.LinkType);
                connection.Open();
                if (command.ExecuteNonQuery() <= 0)
                {
                    throw new DataAccessException("Khong cap nhat duoc quang cao");
                }
                command.Dispose();
            }
        }
    }
}

