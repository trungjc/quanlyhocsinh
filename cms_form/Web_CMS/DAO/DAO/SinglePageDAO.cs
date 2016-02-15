namespace DAO
{
    using ETO;
    using System;
    using System.Data;
    using System.Data.SqlClient;

    public class SinglePageDAO : BaseDAO
    {
        public void CreateSinglePage(SinglePage singlepage)
        {
            using (SqlConnection connection = base.GetConnection())
            {
                SqlCommand command = new SqlCommand("_SinglePageUpdate", connection) {
                    CommandType = CommandType.StoredProcedure
                };
                command.Parameters.AddWithValue("@Type", 0);
                command.Parameters.AddWithValue("@SinglePageID", singlepage.SinglePageID);
                command.Parameters.AddWithValue("@SinglePageName", singlepage.SinglePageName);
                command.Parameters.AddWithValue("@Icon", singlepage.Icon);
                command.Parameters.AddWithValue("@SinglePageDesc", singlepage.SinglePageDesc);
                command.Parameters.AddWithValue("@SinglePageContent", singlepage.SinglePageContent);
                command.Parameters.AddWithValue("@Language", singlepage.Language);
                command.Parameters.AddWithValue("@CreateDate", singlepage.CreateDate);
                command.Parameters.AddWithValue("@Status", singlepage.Status);
                command.Parameters.AddWithValue("@CreatedUserName", singlepage.CreatedUserName);
                connection.Open();
                if (command.ExecuteNonQuery() <= 0)
                {
                    throw new DataAccessException("Khong them moi duoc singlepage");
                }
                command.Dispose();
            }
        }

        public void DeleteSinglePage(int singleId)
        {
            using (SqlConnection connection = base.GetConnection())
            {
                SqlCommand command = new SqlCommand("_SinglePageDelete", connection) {
                    CommandType = CommandType.StoredProcedure
                };
                command.Parameters.AddWithValue("@SinglePageID", singleId);
                connection.Open();
                if (command.ExecuteNonQuery() <= 0)
                {
                    throw new DataAccessException("Khong xoa duoc singlepage");
                }
                command.Dispose();
            }
        }

        public DataTable GetSinglePageAll(int singleId, string language)
        {
            DataTable datatable = new DataTable();
            using (SqlConnection connection = base.GetConnection())
            {
                SqlCommand command = new SqlCommand("_SinglePageGet", connection) {
                    CommandType = CommandType.StoredProcedure
                };
                command.Parameters.AddWithValue("@SinglePageID", singleId);
                command.Parameters.AddWithValue("@Language", language);
                connection.Open();
                using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                {
                    adapter.Fill(datatable);
                    command.Dispose();
                }
            }
            return datatable;
        }

        public DataTable GetSinglePageAll(string language, int num)
        {
            DataTable datatable = new DataTable();
            using (SqlConnection connection = base.GetConnection())
            {
                string SQL = "select top " + Convert.ToString(num) + " * from tblSinglePage where status=1 and Language = @Language order by SinglePageID Desc";
                SqlCommand command = new SqlCommand(SQL, connection);
                command.Parameters.AddWithValue("@Language", language);
                command.CommandText = SQL;
                connection.Open();
                using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                {
                    adapter.Fill(datatable);
                    command.Dispose();
                }
            }
            return datatable;
        }

        public DataTable GetSinglePageAll(string language, int num, int day)
        {
            DataTable datatable = new DataTable();
            using (SqlConnection connection = base.GetConnection())
            {
                string SQL = "select top " + Convert.ToString(num) + " * from tblSinglePage where status=1 and Language = @Language and CAST(GETDATE() - CreateDate AS int) <= @Day order by SinglePageID Desc";
                SqlCommand command = new SqlCommand(SQL, connection);
                command.Parameters.AddWithValue("@Language", language);
                command.Parameters.AddWithValue("@Day", day);
                command.CommandText = SQL;
                connection.Open();
                using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                {
                    adapter.Fill(datatable);
                    command.Dispose();
                }
            }
            return datatable;
        }

        public SinglePage SinglePageGetById(int singleId, string language)
        {
            SinglePage singlepage = null;
            using (SqlConnection connection = base.GetConnection())
            {
                SqlCommand command = new SqlCommand("_SinglePageGet", connection) {
                    CommandType = CommandType.StoredProcedure
                };
                command.Parameters.AddWithValue("@SinglePageID", singleId);
                command.Parameters.AddWithValue("@Language", language);
                connection.Open();
                using (SqlDataReader reader = command.ExecuteReader(CommandBehavior.CloseConnection))
                {
                    if (!reader.Read())
                    {
                        throw new DataAccessException("Khong tim thay gia tri nao");
                    }
                    singlepage = this.SinglePageReader(reader);
                    command.Dispose();
                }
            }
            return singlepage;
        }

        private SinglePage SinglePageReader(SqlDataReader reader)
        {
            return new SinglePage { SinglePageID = (int) reader["SinglePageID"], SinglePageName = (string) reader["SinglePageName"], Icon = (string) reader["Icon"], SinglePageDesc = (string) reader["SinglePageDesc"], SinglePageContent = (string) reader["SinglePageContent"], Language = (string) reader["Language"], CreateDate = (DateTime) reader["CreateDate"], Status = (bool) reader["Status"], CreatedUserName = (string) reader["CreatedUserName"] };
        }

        public void UpdateSinglePage(SinglePage singlepage)
        {
            using (SqlConnection connection = base.GetConnection())
            {
                SqlCommand command = new SqlCommand("_SinglePageUpdate", connection) {
                    CommandType = CommandType.StoredProcedure
                };
                command.Parameters.AddWithValue("@Type", 1);
                command.Parameters.AddWithValue("@SinglePageID", singlepage.SinglePageID);
                command.Parameters.AddWithValue("@SinglePageName", singlepage.SinglePageName);
                command.Parameters.AddWithValue("@Icon", singlepage.Icon);
                command.Parameters.AddWithValue("@SinglePageDesc", singlepage.SinglePageDesc);
                command.Parameters.AddWithValue("@SinglePageContent", singlepage.SinglePageContent);
                command.Parameters.AddWithValue("@Language", singlepage.Language);
                command.Parameters.AddWithValue("@CreateDate", singlepage.CreateDate);
                command.Parameters.AddWithValue("@Status", singlepage.Status);
                command.Parameters.AddWithValue("@CreatedUserName", singlepage.CreatedUserName);
                connection.Open();
                if (command.ExecuteNonQuery() <= 0)
                {
                    throw new DataAccessException("Khong cap nhat duoc singlepage");
                }
                command.Dispose();
            }
        }
    }
}

