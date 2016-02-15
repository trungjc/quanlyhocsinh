namespace DAO
{
    using ETO;
    using System;
    using System.Data;
    using System.Data.SqlClient;
    using System.Web;

    public class ChartRoundDAO : BaseDAO
    {
        private ChartRound ChartRoundReader(SqlDataReader reader)
        {
            return new ChartRound { ChartRoundID = (int) reader["ChartRoundID"], ChartName = (string) reader["ChartName"], ChartRoundParentID = (int) reader["ChartRoundParentID"], Value = (int) reader["Value"], ChartPostDate = (DateTime) reader["ChartPostDate"], ChartStatus = (bool) reader["ChartStatus"] };
        }

        public int CreateChartRound(ChartRound chartRound)
        {
            using (SqlConnection connection = base.GetConnection())
            {
                SqlCommand command = new SqlCommand("_ChartRoundUpdate", connection) {
                    CommandType = CommandType.StoredProcedure
                };
                command.Parameters.AddWithValue("@Type", 0);
                command.Parameters.AddWithValue("@ChartRoundID", 1);
                command.Parameters.AddWithValue("@ChartName", chartRound.ChartName);
                command.Parameters.AddWithValue("@ChartRoundParentID", chartRound.ChartRoundParentID);
                command.Parameters.AddWithValue("@Value", chartRound.Value);
                command.Parameters.AddWithValue("@ChartPostDate", chartRound.ChartPostDate);
                command.Parameters.AddWithValue("@ChartStatus", chartRound.ChartStatus);
                connection.Open();
                return command.ExecuteNonQuery();
            }
        }

        public void DeleteChartRound(int ID)
        {
            using (SqlConnection connection = base.GetConnection())
            {
                SqlCommand command = new SqlCommand("_ChartRoundDelete", connection) {
                    CommandType = CommandType.StoredProcedure
                };
                command.Parameters.AddWithValue("@ChartRoundID", ID);
                connection.Open();
                if (command.ExecuteNonQuery() <= 0)
                {
                    throw new DataAccessException("Loi he thong");
                }
            }
        }

        public DataTable GetAllChartRound()
        {
            DataTable table = new DataTable();
            using (SqlConnection connection = base.GetConnection())
            {
                SqlCommand command = new SqlCommand("_ChartRoundGetAll", connection) {
                    CommandType = CommandType.StoredProcedure
                };
                connection.Open();
                using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                {
                    adapter.Fill(table);
                    command.Dispose();
                }
                return table;
            }
        }

        public ChartRound GetChartRoundById(int ID)
        {
            using (SqlConnection connection = base.GetConnection())
            {
                SqlCommand command = new SqlCommand("_ChartRoundGetById", connection) {
                    CommandType = CommandType.StoredProcedure
                };
                command.Parameters.AddWithValue("@ChartRoundID", ID);
                connection.Open();
                using (SqlDataReader reader = command.ExecuteReader(CommandBehavior.CloseConnection))
                {
                    if (!reader.Read())
                    {
                        throw new DataAccessException("Lỗi : Kh\x00f4ng t\x00ecm thấy gi\x00e1 trị .. ");
                    }
                    return this.ChartRoundReader(reader);
                }
            }
        }

        public DataTable GetChartRoundByParent(int cID)
        {
            DataTable table = new DataTable();
            using (SqlConnection connection = base.GetConnection())
            {
                SqlCommand command = new SqlCommand("_ChartRoundGetByParent", connection) {
                    CommandType = CommandType.StoredProcedure
                };
                command.Parameters.AddWithValue("@ChartRoundID", cID);
                connection.Open();
                using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                {
                    adapter.Fill(table);
                    command.Dispose();
                }
                return table;
            }
        }

        public DataTable GetChartRoundByParentValueSort(int cID)
        {
            DataTable table = new DataTable();
            using (SqlConnection connection = base.GetConnection())
            {
                SqlCommand command = new SqlCommand("_ChartRoundGetByParent_ValueSort", connection) {
                    CommandType = CommandType.StoredProcedure
                };
                command.Parameters.AddWithValue("@ChartRoundID", cID);
                connection.Open();
                using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                {
                    adapter.Fill(table);
                    command.Dispose();
                }
                return table;
            }
        }

        public DataTable GetTop1ChartRound()
        {
            DataTable table = new DataTable();
            using (SqlConnection connection = base.GetConnection())
            {
                SqlCommand command = new SqlCommand("_ChartRoundGetTop1", connection) {
                    CommandType = CommandType.StoredProcedure
                };
                connection.Open();
                using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                {
                    adapter.Fill(table);
                    command.Dispose();
                }
                return table;
            }
        }

        public DataTable MixChartRound()
        {
            DataTable table1 = new DataTable();
            table1.Columns.Add("ChartRoundID");
            table1.Columns.Add("ChartRoundParentID");
            table1.Columns.Add("ChartName");
            table1.Columns.Add("Value");
            table1.Columns.Add("ChartPostDate");
            table1.Columns.Add("ChartStatus");
            DataTable table2 = this.GetChartRoundByParent(0);
            foreach (DataRow r2 in table2.Rows)
            {
                DataRow r1 = table1.NewRow();
                r1["ChartRoundID"] = r2["ChartRoundID"].ToString().Trim();
                r1["ChartRoundParentID"] = r2["ChartRoundParentID"].ToString().Trim();
                r1["ChartName"] = r2["ChartName"].ToString().Trim();
                r1["Value"] = r2["Value"].ToString().Trim();
                r1["ChartPostDate"] = r2["ChartPostDate"].ToString().Trim();
                r1["ChartStatus"] = r2["ChartStatus"].ToString().Trim();
                table1.Rows.Add(r1);
                this.SubMixChartRound(table1, Convert.ToInt32(r1["ChartRoundID"]), "");
            }
            return table1;
        }

        public void SubMixChartRound(DataTable table, int mID, string sSpace)
        {
            string str = HttpUtility.HtmlDecode("&nbsp;&nbsp;&nbsp;--&nbsp;");
            sSpace = sSpace + str;
            DataTable subTable = new DataTable();
            using (SqlConnection connection = base.GetConnection())
            {
                SqlCommand command = new SqlCommand("_ChartRoundGetByParent", connection) {
                    CommandType = CommandType.StoredProcedure
                };
                command.Parameters.AddWithValue("@ChartRoundID", mID);
                connection.Open();
                using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                {
                    adapter.Fill(subTable);
                    command.Dispose();
                }
                if (subTable.Rows.Count > 0)
                {
                    foreach (DataRow subrow in subTable.Rows)
                    {
                        DataRow rs = table.NewRow();
                        rs["ChartRoundID"] = subrow["ChartRoundID"].ToString().Trim();
                        rs["ChartRoundParentID"] = subrow["ChartRoundParentID"].ToString().Trim();
                        rs["ChartName"] = sSpace + subrow["ChartName"].ToString().Trim();
                        rs["Value"] = subrow["Value"].ToString().Trim();
                        rs["ChartPostDate"] = subrow["ChartPostDate"].ToString().Trim();
                        rs["ChartStatus"] = subrow["ChartStatus"].ToString().Trim();
                        table.Rows.Add(rs);
                        this.SubMixChartRound(table, Convert.ToInt32(rs["ChartRoundID"]), "");
                    }
                }
            }
        }

        public int UpdateChartRound(ChartRound chartRound)
        {
            using (SqlConnection connection = base.GetConnection())
            {
                SqlCommand command = new SqlCommand("_ChartRoundUpdate", connection) {
                    CommandType = CommandType.StoredProcedure
                };
                command.Parameters.AddWithValue("@Type", 1);
                command.Parameters.AddWithValue("@ChartRoundID", chartRound.ChartRoundID);
                command.Parameters.AddWithValue("@ChartName", chartRound.ChartName);
                command.Parameters.AddWithValue("@ChartRoundParentID", chartRound.ChartRoundParentID);
                command.Parameters.AddWithValue("@Value", chartRound.Value);
                command.Parameters.AddWithValue("@ChartPostDate", chartRound.ChartPostDate);
                command.Parameters.AddWithValue("@ChartStatus", chartRound.ChartStatus);
                connection.Open();
                int i = command.ExecuteNonQuery();
                if (i <= 0)
                {
                    throw new DataAccessException("lỗi kh\x00f4ng thể cập nhật");
                }
                return i;
            }
        }
    }
}

