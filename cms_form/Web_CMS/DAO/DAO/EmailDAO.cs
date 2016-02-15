namespace DAO
{
    using ETO;
    using System;
    using System.Data;
    using System.Data.SqlClient;

    public class EmailDAO : BaseDAO
    {
        public void CreateEmail(Email email)
        {
            using (SqlConnection connection = base.GetConnection())
            {
                SqlCommand command = new SqlCommand("_EmailUpdate", connection) {
                    CommandType = CommandType.StoredProcedure
                };
                command.Parameters.AddWithValue("@Type", 0);
                command.Parameters.AddWithValue("@EmailID", 0);
                command.Parameters.AddWithValue("@EmailAddress", email.EmailAddress);
                command.Parameters.AddWithValue("@Name", email.Name);
                connection.Open();
                if (command.ExecuteNonQuery() <= 0)
                {
                    throw new DataAccessException("khong them moi duoc email");
                }
                command.Dispose();
            }
        }

        public void DeleteEmail(int Id)
        {
            using (SqlConnection connection = base.GetConnection())
            {
                SqlCommand command = new SqlCommand("_EmailDelete", connection) {
                    CommandType = CommandType.StoredProcedure
                };
                command.Parameters.AddWithValue("@EmailID", Id);
                connection.Open();
                if (command.ExecuteNonQuery() <= 0)
                {
                    throw new DataAccessException("Khong xoa duoc email");
                }
                command.Dispose();
            }
        }

        private Email EmailReader(SqlDataReader reader)
        {
            return new Email { EmailID = (int) reader["EmailID"], EmailAddress = (string) reader["EmailAddress"], Name = (string) reader["Name"] };
        }

        public DataTable GetEmailAll()
        {
            DataTable datatable = new DataTable();
            using (SqlConnection connection = base.GetConnection())
            {
                SqlCommand command = new SqlCommand("_EmailGetAll", connection) {
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

        public Email GetEmailById(int Id)
        {
            Email email = null;
            using (SqlConnection connection = base.GetConnection())
            {
                SqlCommand command = new SqlCommand("_EmailGetById", connection) {
                    CommandType = CommandType.StoredProcedure
                };
                command.Parameters.AddWithValue("@EmailID", Id);
                connection.Open();
                using (SqlDataReader reader = command.ExecuteReader(CommandBehavior.CloseConnection))
                {
                    if (!reader.Read())
                    {
                        throw new DataAccessException("Khong tim thay gia tri email");
                    }
                    email = this.EmailReader(reader);
                    command.Dispose();
                }
            }
            return email;
        }

        public void UpdateEmail(Email email)
        {
            using (SqlConnection connection = base.GetConnection())
            {
                SqlCommand command = new SqlCommand("_EmailUpdate", connection) {
                    CommandType = CommandType.StoredProcedure
                };
                command.Parameters.AddWithValue("@Type", 1);
                command.Parameters.AddWithValue("@EmailID", email.EmailID);
                command.Parameters.AddWithValue("@EmailAddress", email.EmailAddress);
                command.Parameters.AddWithValue("@Name", email.Name);
                connection.Open();
                if (command.ExecuteNonQuery() <= 0)
                {
                    throw new DataAccessException("khong cap nhat duoc email");
                }
                command.Dispose();
            }
        }
    }
}

