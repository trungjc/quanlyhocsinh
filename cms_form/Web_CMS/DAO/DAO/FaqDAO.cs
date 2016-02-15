namespace DAO
{
    using ETO;
    using System;
    using System.Data;
    using System.Data.SqlClient;

    public class FaqDAO : BaseDAO
    {
        public void CreateFaq(Faq faq)
        {
            using (SqlConnection connection = base.GetConnection())
            {
                SqlCommand command = new SqlCommand("_FaqUpdate", connection) {
                    CommandType = CommandType.StoredProcedure
                };
                command.Parameters.AddWithValue("@Type", 0);
                command.Parameters.AddWithValue("@FaqID", 0);
                command.Parameters.AddWithValue("@Question", faq.Question);
                command.Parameters.AddWithValue("@Answer", faq.Answer);
                command.Parameters.AddWithValue("@PostDate", faq.PostDate);
                command.Parameters.AddWithValue("@Status", faq.Status);
                command.Parameters.AddWithValue("@Language",faq.Language);
                connection.Open();
                if (command.ExecuteNonQuery() <= 0)
                {
                    throw new DataAccessException("Khong them moi duoc faq");
                }
                command.Dispose();
            }
        }

        public void DeleteFaq(int Id)
        {
            using (SqlConnection connection = base.GetConnection())
            {
                SqlCommand command = new SqlCommand("_FaqDelete", connection) {
                    CommandType = CommandType.StoredProcedure
                };
                command.Parameters.AddWithValue("@FaqID", Id);
                connection.Open();
                if (command.ExecuteNonQuery() <= 0)
                {
                    throw new DataAccessException("Khong xoa duoc faq");
                }
                command.Dispose();
            }
        }

        private Faq FaqReader(SqlDataReader reader)
        {
            return new Faq { FaqID = (int) reader["FaqID"], Question = (string) reader["Question"], Answer = (string) reader["Answer"], PostDate = (DateTime) reader["PostDate"], Status = (bool) reader["Status"], Language = (string) reader["Language"], FaqOrder = (int) reader["FaqOrder"] };
        }

        public void FaqUpOrder(int cId, int cOrder)
        {
            using (SqlConnection connection = base.GetConnection())
            {
                SqlCommand command = new SqlCommand("_FaqUpOrder", connection) {
                    CommandType = CommandType.StoredProcedure
                };
                command.Parameters.AddWithValue("@FaqID", cId);
                command.Parameters.AddWithValue("@FaqOrder", cOrder);
                connection.Open();
                if (command.ExecuteNonQuery() <= 0)
                {
                    throw new DataAccessException("Kh\x00f4ng thể cập nhật danh mục tin");
                }
                command.Dispose();
            }
        }

        public DataTable GetFaqAll(string lang)
        {
            DataTable datatable = new DataTable();
            using (SqlConnection connection = base.GetConnection())
            {
                SqlCommand command = new SqlCommand("_FaqGetAll", connection) {
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

        public Faq GetFaqById(int Id)
        {
            Faq faq = null;
            using (SqlConnection connection = base.GetConnection())
            {
                SqlCommand command = new SqlCommand("_FaqGetById", connection) {
                    CommandType = CommandType.StoredProcedure
                };
                command.Parameters.AddWithValue("@FaqID", Id);
                connection.Open();
                using (SqlDataReader reader = command.ExecuteReader(CommandBehavior.CloseConnection))
                {
                    if (!reader.Read())
                    {
                        throw new DataAccessException("khong tin thay gia tri nao");
                    }
                    faq = this.FaqReader(reader);
                    command.Dispose();
                }
            }
            return faq;
        }

        public DataTable GetFaqOther(int Id, string lang)
        {
            DataTable datatable = new DataTable();
            using (SqlConnection connection = base.GetConnection())
            {
                SqlCommand command = new SqlCommand("_FaqGetOther", connection) {
                    CommandType = CommandType.StoredProcedure
                };
                command.Parameters.AddWithValue("@FaqID", Id);
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

        public void UpdateFaq(Faq faq)
        {
            using (SqlConnection connection = base.GetConnection())
            {
                SqlCommand command = new SqlCommand("_FaqUpdate", connection) {
                    CommandType = CommandType.StoredProcedure
                };
                command.Parameters.AddWithValue("@Type", 1);
                command.Parameters.AddWithValue("@FaqID", faq.FaqID);
                command.Parameters.AddWithValue("@Question", faq.Question);
                command.Parameters.AddWithValue("@Answer", faq.Answer);
                command.Parameters.AddWithValue("@PostDate", faq.PostDate);
                command.Parameters.AddWithValue("@Status", faq.Status);
                command.Parameters.AddWithValue("@Language", faq.Language);
                connection.Open();
                if (command.ExecuteNonQuery() <= 0)
                {
                    throw new DataAccessException("Khong cap nhat duoc faq");
                }
                command.Dispose();
            }
        }
    }
}

