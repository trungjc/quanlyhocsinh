namespace DAO
{
    using ETO;
    using System;
    using System.Data;
    using System.Data.SqlClient;

    public class RelationDAO : BaseDAO
    {
        public void CreateRelation(Relation relation)
        {
            using (SqlConnection connection = base.GetConnection())
            {
                SqlCommand command = new SqlCommand("_RelationUpdate", connection) {
                    CommandType = CommandType.StoredProcedure
                };
                command.Parameters.AddWithValue("@Type", 0);
                command.Parameters.AddWithValue("@RelationID", 0);
                command.Parameters.AddWithValue("@NewsID", relation.NewsID);
                command.Parameters.AddWithValue("@Title", relation.Title);
                command.Parameters.AddWithValue("@ShortDescribe", relation.ShortDescribe);
                command.Parameters.AddWithValue("@FullDescribe", relation.FullDescribe);
                command.Parameters.AddWithValue("@ImageThumb", relation.ImageThumb);
                command.Parameters.AddWithValue("@ImageLarge", relation.ImageLarge);
                command.Parameters.AddWithValue("@Author", relation.Author);
                command.Parameters.AddWithValue("@PostDate", relation.PostDate);
                command.Parameters.AddWithValue("@Status", relation.Status);
                command.Parameters.AddWithValue("@Language", relation.Language);
                connection.Open();
                if (command.ExecuteNonQuery() <= 0)
                {
                    throw new DataAccessException("Kh\x00f4ng th\x00eam mới được tin li\x00ean quan");
                }
                command.Dispose();
            }
        }

        public void DeleteRelation(int Id)
        {
            using (SqlConnection connection = base.GetConnection())
            {
                SqlCommand command = new SqlCommand("_RelationDelete", connection) {
                    CommandType = CommandType.StoredProcedure
                };
                command.Parameters.AddWithValue("@RelationID", Id);
                connection.Open();
                if (command.ExecuteNonQuery() <= 0)
                {
                    throw new DataAccessException("Kh\x00f4ng x\x00f3a được tin li\x00ean quan");
                }
                command.Dispose();
            }
        }

        public Relation GetRelationById(int Id)
        {
            Relation relation = null;
            using (SqlConnection connection = base.GetConnection())
            {
                SqlCommand command = new SqlCommand("_RelationGetById", connection) {
                    CommandType = CommandType.StoredProcedure
                };
                command.Parameters.AddWithValue("@NewsID", 0);
                command.Parameters.AddWithValue("@RelationID", Id);
                connection.Open();
                using (SqlDataReader reader = command.ExecuteReader(CommandBehavior.CloseConnection))
                {
                    if (!reader.Read())
                    {
                        throw new DataAccessException("Kh\x00f4ng t\x00ecm thấy tin li\x00ean quan");
                    }
                    relation = this.RelationReader(reader);
                }
                command.Dispose();
            }
            return relation;
        }

        public DataTable GetRelationByNews(int nId)
        {
            DataTable datatable = new DataTable();
            using (SqlConnection connection = base.GetConnection())
            {
                SqlCommand command = new SqlCommand("_RelationGetById", connection) {
                    CommandType = CommandType.StoredProcedure
                };
                command.Parameters.AddWithValue("@NewsID", nId);
                command.Parameters.AddWithValue("@RelationID", 0);
                connection.Open();
                using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                {
                    adapter.Fill(datatable);
                    command.Dispose();
                }
            }
            return datatable;
        }

        public void RelationDeleteNews(int newsid)
        {
            using (SqlConnection connection = base.GetConnection())
            {
                SqlCommand command = new SqlCommand("_RelationUpdateNews", connection) {
                    CommandType = CommandType.StoredProcedure
                };
                command.Parameters.AddWithValue("@Flag", 1);
                command.Parameters.AddWithValue("@NewsID", newsid);
                connection.Open();
                if (command.ExecuteNonQuery() <= 0)
                {
                    throw new DataAccessException("Kh\x00f4ng bớt được news");
                }
                command.Dispose();
            }
        }

        private Relation RelationReader(SqlDataReader reader)
        {
            return new Relation { RelationID = (int) reader["RelationID"], NewsID = (int) reader["NewsID"], Title = (string) reader["Title"], ShortDescribe = (string) reader["ShortDescribe"], FullDescribe = (string) reader["FullDescribe"], ImageThumb = (string) reader["ImageThumb"], ImageLarge = (string) reader["ImageLarge"], Author = (string) reader["Author"], PostDate = (DateTime) reader["PostDate"], Status = (bool) reader["Status"], Language = (string) reader["Language"] };
        }

        public void RelationUpdateNews(int newsid)
        {
            using (SqlConnection connection = base.GetConnection())
            {
                SqlCommand command = new SqlCommand("_RelationUpdateNews", connection) {
                    CommandType = CommandType.StoredProcedure
                };
                command.Parameters.AddWithValue("@Flag", 0);
                command.Parameters.AddWithValue("@NewsID", newsid);
                connection.Open();
                if (command.ExecuteNonQuery() <= 0)
                {
                    throw new DataAccessException("Kh\x00f4ng cập nhật được news");
                }
                command.Dispose();
            }
        }

        public void UpdateRelation(Relation relation)
        {
            using (SqlConnection connection = base.GetConnection())
            {
                SqlCommand command = new SqlCommand("_RelationUpdate", connection) {
                    CommandType = CommandType.StoredProcedure
                };
                command.Parameters.AddWithValue("@Type", 1);
                command.Parameters.AddWithValue("@RelationID", relation.RelationID);
                command.Parameters.AddWithValue("@NewsID", relation.NewsID);
                command.Parameters.AddWithValue("@Title", relation.Title);
                command.Parameters.AddWithValue("@ShortDescribe", relation.ShortDescribe);
                command.Parameters.AddWithValue("@FullDescribe", relation.FullDescribe);
                command.Parameters.AddWithValue("@ImageThumb", relation.ImageThumb);
                command.Parameters.AddWithValue("@ImageLarge", relation.ImageLarge);
                command.Parameters.AddWithValue("@Author", relation.Author);
                command.Parameters.AddWithValue("@PostDate", relation.PostDate);
                command.Parameters.AddWithValue("@Status", relation.Status);
                command.Parameters.AddWithValue("@Language", relation.Language);
                connection.Open();
                if (command.ExecuteNonQuery() <= 0)
                {
                    throw new DataAccessException("Kh\x00f4ng cập nhật được tin li\x00ean quan");
                }
                command.Dispose();
            }
        }
    }
}

