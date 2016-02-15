namespace DAO
{
    using ETO;
    using System;
    using System.Data;
    using System.Data.SqlClient;

    public class Chart24hDAO : BaseDAO
    {
        private Chart24h Chart24hReader(SqlDataReader reader)
        {
            return new Chart24h { 
                ChartID = (int) reader["ChartID"], ChartName = (string) reader["ChartName"], Hour_1 = (int) reader["Hour_1"], Hour_2 = (int) reader["Hour_2"], Hour_3 = (int) reader["Hour_3"], Hour_4 = (int) reader["Hour_4"], Hour_5 = (int) reader["Hour_5"], Hour_6 = (int) reader["Hour_6"], Hour_7 = (int) reader["Hour_7"], Hour_8 = (int) reader["Hour_8"], Hour_9 = (int) reader["Hour_9"], Hour_10 = (int) reader["Hour_10"], Hour_11 = (int) reader["Hour_11"], Hour_12 = (int) reader["Hour_12"], Hour_13 = (int) reader["Hour_13"], Hour_14 = (int) reader["Hour_14"], 
                Hour_15 = (int) reader["Hour_15"], Hour_16 = (int) reader["Hour_16"], Hour_17 = (int) reader["Hour_17"], Hour_18 = (int) reader["Hour_18"], Hour_19 = (int) reader["Hour_19"], Hour_20 = (int) reader["Hour_20"], Hour_21 = (int) reader["Hour_21"], Hour_22 = (int) reader["Hour_22"], Hour_23 = (int) reader["Hour_23"], Hour_24 = (int) reader["Hour_24"], ChartPostDate = (DateTime) reader["ChartPostDate"], ChartStatus = (bool) reader["ChartStatus"]
             };
        }

        public void CreateChart24h(Chart24h chart24h)
        {
            using (SqlConnection connection = base.GetConnection())
            {
                SqlCommand command = new SqlCommand("_Chart24hUpdate", connection) {
                    CommandType = CommandType.StoredProcedure
                };
                command.Parameters.AddWithValue("@Type", 0);
                command.Parameters.AddWithValue("@ChartID", 0);
                command.Parameters.AddWithValue("@ChartName", chart24h.ChartName);
                command.Parameters.AddWithValue("@Hour_1", chart24h.Hour_1);
                command.Parameters.AddWithValue("@Hour_2", chart24h.Hour_2);
                command.Parameters.AddWithValue("@Hour_3", chart24h.Hour_3);
                command.Parameters.AddWithValue("@Hour_4", chart24h.Hour_4);
                command.Parameters.AddWithValue("@Hour_5", chart24h.Hour_5);
                command.Parameters.AddWithValue("@Hour_6", chart24h.Hour_6);
                command.Parameters.AddWithValue("@Hour_7", chart24h.Hour_7);
                command.Parameters.AddWithValue("@Hour_8", chart24h.Hour_8);
                command.Parameters.AddWithValue("@Hour_9", chart24h.Hour_9);
                command.Parameters.AddWithValue("@Hour_10", chart24h.Hour_10);
                command.Parameters.AddWithValue("@Hour_11", chart24h.Hour_11);
                command.Parameters.AddWithValue("@Hour_12", chart24h.Hour_12);
                command.Parameters.AddWithValue("@Hour_13", chart24h.Hour_13);
                command.Parameters.AddWithValue("@Hour_14", chart24h.Hour_14);
                command.Parameters.AddWithValue("@Hour_15", chart24h.Hour_15);
                command.Parameters.AddWithValue("@Hour_16", chart24h.Hour_16);
                command.Parameters.AddWithValue("@Hour_17", chart24h.Hour_17);
                command.Parameters.AddWithValue("@Hour_18", chart24h.Hour_18);
                command.Parameters.AddWithValue("@Hour_19", chart24h.Hour_19);
                command.Parameters.AddWithValue("@Hour_20", chart24h.Hour_20);
                command.Parameters.AddWithValue("@Hour_21", chart24h.Hour_21);
                command.Parameters.AddWithValue("@Hour_22", chart24h.Hour_22);
                command.Parameters.AddWithValue("@Hour_23", chart24h.Hour_23);
                command.Parameters.AddWithValue("@Hour_24", chart24h.Hour_24);
                command.Parameters.AddWithValue("@ChartPostDate", chart24h.ChartPostDate);
                command.Parameters.AddWithValue("@ChartStatus", chart24h.ChartStatus);
                connection.Open();
                if (command.ExecuteNonQuery() <= 0)
                {
                    throw new DataAccessException("Khong them duoc quang cao");
                }
                command.Dispose();
            }
        }

        public void DeleteChart24h(int Id)
        {
            using (SqlConnection connection = base.GetConnection())
            {
                SqlCommand command = new SqlCommand("_Chart24hDelete", connection) {
                    CommandType = CommandType.StoredProcedure
                };
                command.Parameters.AddWithValue("@ChartID", Id);
                connection.Open();
                if (command.ExecuteNonQuery() <= 0)
                {
                    throw new DataAccessException("Khong xoa duoc quang cao");
                }
                command.Dispose();
            }
        }

        public DataTable GetChart24hAll()
        {
            DataTable datatable = new DataTable();
            using (SqlConnection connection = base.GetConnection())
            {
                SqlCommand command = new SqlCommand("_Chart24hGetAll", connection) {
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

        public Chart24h GetChart24hById(int Id)
        {
            Chart24h chart24h = null;
            using (SqlConnection connection = base.GetConnection())
            {
                SqlCommand command = new SqlCommand("_Chart24hGetById", connection) {
                    CommandType = CommandType.StoredProcedure
                };
                command.Parameters.AddWithValue("@ChartID", Id);
                connection.Open();
                using (SqlDataReader reader = command.ExecuteReader(CommandBehavior.CloseConnection))
                {
                    if (!reader.Read())
                    {
                        throw new DataAccessException("Khong tim thay gia tri nao");
                    }
                    chart24h = this.Chart24hReader(reader);
                    command.Dispose();
                }
            }
            return chart24h;
        }

        public DataTable GetChart24hDraw()
        {
            DataTable datatable = new DataTable();
            using (SqlConnection connection = base.GetConnection())
            {
                SqlCommand command = new SqlCommand("_Chart24hGetDraw", connection) {
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

        public DataTable GetChart24hDraw(DateTime _postDate)
        {
            DataTable datatable = new DataTable();
            using (SqlConnection connection = base.GetConnection())
            {
                SqlCommand command = new SqlCommand("_Chart24hGetDrawbyDate", connection) {
                    CommandType = CommandType.StoredProcedure
                };
                command.Parameters.AddWithValue("@Date", _postDate);
                connection.Open();
                using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                {
                    adapter.Fill(datatable);
                    command.Dispose();
                }
            }
            return datatable;
        }

        public DataTable GetChart24hDraw3()
        {
            DataTable datatable = new DataTable();
            using (SqlConnection connection = base.GetConnection())
            {
                SqlCommand command = new SqlCommand("_Chart24hGetDraw3", connection) {
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

        public DataTable GetChart24hDraw3(DateTime _postDate)
        {
            DataTable datatable = new DataTable();
            using (SqlConnection connection = base.GetConnection())
            {
                SqlCommand command = new SqlCommand("_Chart24hGetDrawbyDate3", connection) {
                    CommandType = CommandType.StoredProcedure
                };
                command.Parameters.AddWithValue("@Date", _postDate);
                connection.Open();
                using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                {
                    adapter.Fill(datatable);
                    command.Dispose();
                }
            }
            return datatable;
        }

        public DataTable GetChart24hTop1()
        {
            DataTable datatable = new DataTable();
            using (SqlConnection connection = base.GetConnection())
            {
                SqlCommand command = new SqlCommand("_Chart24hGetTop1", connection) {
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

        public void UpdateChart24h(Chart24h chart24h)
        {
            using (SqlConnection connection = base.GetConnection())
            {
                SqlCommand command = new SqlCommand("_Chart24hUpdate", connection) {
                    CommandType = CommandType.StoredProcedure
                };
                command.Parameters.AddWithValue("@Type", 1);
                command.Parameters.AddWithValue("@ChartID", chart24h.ChartID);
                command.Parameters.AddWithValue("@ChartName", chart24h.ChartName);
                command.Parameters.AddWithValue("@Hour_1", chart24h.Hour_1);
                command.Parameters.AddWithValue("@Hour_2", chart24h.Hour_2);
                command.Parameters.AddWithValue("@Hour_3", chart24h.Hour_3);
                command.Parameters.AddWithValue("@Hour_4", chart24h.Hour_4);
                command.Parameters.AddWithValue("@Hour_5", chart24h.Hour_5);
                command.Parameters.AddWithValue("@Hour_6", chart24h.Hour_6);
                command.Parameters.AddWithValue("@Hour_7", chart24h.Hour_7);
                command.Parameters.AddWithValue("@Hour_8", chart24h.Hour_8);
                command.Parameters.AddWithValue("@Hour_9", chart24h.Hour_9);
                command.Parameters.AddWithValue("@Hour_10", chart24h.Hour_10);
                command.Parameters.AddWithValue("@Hour_11", chart24h.Hour_11);
                command.Parameters.AddWithValue("@Hour_12", chart24h.Hour_12);
                command.Parameters.AddWithValue("@Hour_13", chart24h.Hour_13);
                command.Parameters.AddWithValue("@Hour_14", chart24h.Hour_14);
                command.Parameters.AddWithValue("@Hour_15", chart24h.Hour_15);
                command.Parameters.AddWithValue("@Hour_16", chart24h.Hour_16);
                command.Parameters.AddWithValue("@Hour_17", chart24h.Hour_17);
                command.Parameters.AddWithValue("@Hour_18", chart24h.Hour_18);
                command.Parameters.AddWithValue("@Hour_19", chart24h.Hour_19);
                command.Parameters.AddWithValue("@Hour_20", chart24h.Hour_20);
                command.Parameters.AddWithValue("@Hour_21", chart24h.Hour_21);
                command.Parameters.AddWithValue("@Hour_22", chart24h.Hour_22);
                command.Parameters.AddWithValue("@Hour_23", chart24h.Hour_23);
                command.Parameters.AddWithValue("@Hour_24", chart24h.Hour_24);
                command.Parameters.AddWithValue("@ChartPostDate", chart24h.ChartPostDate);
                command.Parameters.AddWithValue("@ChartStatus", chart24h.ChartStatus);
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

