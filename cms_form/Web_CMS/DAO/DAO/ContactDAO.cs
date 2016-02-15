namespace DAO
{
    using ETO;
    using System;
    using System.Data;
    using System.Data.SqlClient;

    public class ContactDAO : BaseDAO
    {
        private Contact ContactReader(SqlDataReader reader)
        {
            return new Contact { ContactID = (int)reader["ContactID"], Name = (string)reader["Name"], Address = (string)reader["Address"], Tel = (string)reader["Tel"], Fax = (string)reader["Fax"], Email = (string)reader["Email"], City = (string)reader["City"], Date = (DateTime)reader["Date"], Require = (string)reader["Require"], Attact = (string)reader["Attact"], Sendmail = (bool)reader["SendMail"], Answer = (string)reader["Answer"] };
        }

        public void CreateContact(Contact contact)
        {
            using (SqlConnection connection = base.GetConnection())
            {
                SqlCommand command = new SqlCommand("_ContactUpdate", connection) {
                    CommandType = CommandType.StoredProcedure
                };
                command.Parameters.AddWithValue("@Type", 0);
                command.Parameters.AddWithValue("@ContactID", 0);
                command.Parameters.AddWithValue("@Date", contact.Date);
                command.Parameters.AddWithValue("@Name", contact.Name);
                command.Parameters.AddWithValue("@Company", contact.Company);
                command.Parameters.AddWithValue("@Email", contact.Email);
                command.Parameters.AddWithValue("@Tel", contact.Tel);
                command.Parameters.AddWithValue("@Address", contact.Address);
                command.Parameters.AddWithValue("@City", contact.City);
                command.Parameters.AddWithValue("@Fax", contact.Fax);
                command.Parameters.AddWithValue("@Require", contact.Require);
                command.Parameters.AddWithValue("@Attact", contact.Attact);
                command.Parameters.AddWithValue("@SendMail", contact.Sendmail);
                command.Parameters.AddWithValue("@Answer", contact.Answer);
                
                connection.Open();
                if (command.ExecuteNonQuery() <= 0)
                {
                    throw new DataAccessException("Lỗi kh\x00f4ng thể tao moi");
                }
                command.Dispose();
            }
        }

        public void DeleteContact(int contactID)
        {
            using (SqlConnection connection = base.GetConnection())
            {
                SqlCommand command = new SqlCommand("_ContactDelete", connection) {
                    CommandType = CommandType.StoredProcedure
                };
                command.Parameters.AddWithValue("@ContactID", contactID);
                connection.Open();
                if (command.ExecuteNonQuery() <= 0)
                {
                    throw new DataAccessException("Kh\x00f4ng thể x\x00f3a contact");
                }
                command.Dispose();
            }
        }

        public DataTable GetContactAll()
        {
            DataTable datatable = new DataTable();
            using (SqlConnection connection = base.GetConnection())
            {
                SqlCommand command = new SqlCommand("_ContactGetAll", connection) {
                    CommandType = CommandType.StoredProcedure
                };
                connection.Open();
                using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                {
                    adapter.Fill(datatable);
                    command.Dispose();
                }
                return datatable;
            }
        }

        public Contact GetContactById(int contactID)
        {
            Contact contact = null;
            using (SqlConnection connection = base.GetConnection())
            {
                SqlCommand command = new SqlCommand("_ContactGetById", connection) {
                    CommandType = CommandType.StoredProcedure
                };
                command.Parameters.AddWithValue("@ContactID", contactID);
                connection.Open();
                using (SqlDataReader reader = command.ExecuteReader(CommandBehavior.CloseConnection))
                {
                    if (!reader.Read())
                    {
                        throw new DataAccessException("khong ton tai contact");
                    }
                    contact = this.ContactReader(reader);
                }
                command.Dispose();
            }
            return contact;
        }

        public void UpdateContact(Contact contact)
        {
            using (SqlConnection connection = base.GetConnection())
            {
                SqlCommand command = new SqlCommand("_ContactUpdate", connection) {
                    CommandType = CommandType.StoredProcedure
                };
                command.Parameters.AddWithValue("@Type", 1);
                command.Parameters.AddWithValue("@ContactID", contact.ContactID);
                command.Parameters.AddWithValue("@Date", contact.Date);
                command.Parameters.AddWithValue("@Name", contact.Name);
                command.Parameters.AddWithValue("@Company", contact.Company);
                command.Parameters.AddWithValue("@Email", contact.Email);
                command.Parameters.AddWithValue("@Tel", contact.Tel);
                command.Parameters.AddWithValue("@Address", contact.Address);
                command.Parameters.AddWithValue("@City", contact.City);
                command.Parameters.AddWithValue("@Fax", contact.Fax);
                command.Parameters.AddWithValue("@Require", contact.Require);
                command.Parameters.AddWithValue("@Attact", contact.Attact);
                command.Parameters.AddWithValue("@SendMail", contact.Sendmail);
                command.Parameters.AddWithValue("@Answer", contact.Answer);
                connection.Open();
                if (command.ExecuteNonQuery() <= 0)
                {
                    throw new DataAccessException("Lỗi kh\x00f4ng thể cập nhật");
                }
                command.Dispose();
            }
        }
    }
}

