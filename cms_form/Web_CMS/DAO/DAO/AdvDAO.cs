namespace DAO
{
    using ETO;
    using System;
    using System.Data;
    using System.Data.SqlClient;

    public class AdvDAO : BaseDAO
    {
        private Adv AdvReader(SqlDataReader reader)
        {
            return new Adv { AdvID = (int) reader["AdvID"], AdvUrl = (string) reader["AdvUrl"], AdvImage = (string) reader["AdvImage"], AdvWidth = (int) reader["AdvWidth"], AdvHeight = (int) reader["AdvHeight"], AdvPostDate = (DateTime) reader["AdvPostDate"], AdvEndDate = (DateTime) reader["AdvEndDate"], AdvStatus = (bool) reader["AdvStatus"] };
        }

        public void CreateAdv(Adv adv)
        {
            using (SqlConnection connection = base.GetConnection())
            {
                SqlCommand command = new SqlCommand("_AdvUpdate", connection) {
                    CommandType = CommandType.StoredProcedure
                };
                command.Parameters.AddWithValue("@Type", 0);
                command.Parameters.AddWithValue("@AdvID", 0);
                command.Parameters.AddWithValue("@AdvUrl", adv.AdvUrl);
                command.Parameters.AddWithValue("@AdvImage", adv.AdvImage);
                command.Parameters.AddWithValue("@AdvWidth", adv.AdvWidth);
                command.Parameters.AddWithValue("@AdvHeight", adv.AdvHeight);
                command.Parameters.AddWithValue("@AdvPostDate", adv.AdvPostDate);
                command.Parameters.AddWithValue("@AdvEndDate", adv.AdvEndDate);
                command.Parameters.AddWithValue("@AdvStatus", adv.AdvStatus);
                connection.Open();
                if (command.ExecuteNonQuery() <= 0)
                {
                    throw new DataAccessException("Khong them duoc quang cao");
                }
                command.Dispose();
            }
        }

        public void DeleteAdv(int Id)
        {
            using (SqlConnection connection = base.GetConnection())
            {
                SqlCommand command = new SqlCommand("_AdvDelete", connection) {
                    CommandType = CommandType.StoredProcedure
                };
                command.Parameters.AddWithValue("@AdvID", Id);
                connection.Open();
                if (command.ExecuteNonQuery() <= 0)
                {
                    throw new DataAccessException("Khong xoa duoc quang cao");
                }
                command.Dispose();
            }
        }

        public DataTable GetAdvAll()
        {
            DataTable datatable = new DataTable();
            using (SqlConnection connection = base.GetConnection())
            {
                SqlCommand command = new SqlCommand("_AdvGetAll", connection) {
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

        public Adv GetAdvById(int Id)
        {
            Adv adv = null;
            using (SqlConnection connection = base.GetConnection())
            {
                SqlCommand command = new SqlCommand("_AdvGetById", connection) {
                    CommandType = CommandType.StoredProcedure
                };
                command.Parameters.AddWithValue("@AdvID", Id);
                connection.Open();
                using (SqlDataReader reader = command.ExecuteReader(CommandBehavior.CloseConnection))
                {
                    if (!reader.Read())
                    {
                        throw new DataAccessException("Khong tim thay gia tri nao");
                    }
                    adv = this.AdvReader(reader);
                    command.Dispose();
                }
            }
            return adv;
        }

        public void UpdateAdv(Adv adv)
        {
            using (SqlConnection connection = base.GetConnection())
            {
                SqlCommand command = new SqlCommand("_AdvUpdate", connection) {
                    CommandType = CommandType.StoredProcedure
                };
                command.Parameters.AddWithValue("@Type", 1);
                command.Parameters.AddWithValue("@AdvID", adv.AdvID);
                command.Parameters.AddWithValue("@AdvUrl", adv.AdvUrl);
                command.Parameters.AddWithValue("@AdvImage", adv.AdvImage);
                command.Parameters.AddWithValue("@AdvWidth", adv.AdvWidth);
                command.Parameters.AddWithValue("@AdvHeight", adv.AdvHeight);
                command.Parameters.AddWithValue("@AdvPostDate", adv.AdvPostDate);
                command.Parameters.AddWithValue("@AdvEndDate", adv.AdvEndDate);
                command.Parameters.AddWithValue("@AdvStatus", adv.AdvStatus);
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

