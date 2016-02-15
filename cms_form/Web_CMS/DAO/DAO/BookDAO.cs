namespace DAO
{
    using ETO;
    using System;
    using System.Data;
    using System.Data.SqlClient;

    public class BookDAO : BaseDAO
    {
        private Book BookReader(SqlDataReader reader)
        {
            return new Book { 
                BookID = (int) reader["BookID"], ProductID = (int) reader["ProductID"], FullName = (string) reader["FullName"], Address = (string) reader["Address"], Phone = (string) reader["Phone"], Email = (string) reader["Email"], FromAddress = (string) reader["FromAddress"], FromCity = (string) reader["FromCity"], FromDistrict = (string) reader["FromDistrict"], FromDate = (DateTime) reader["FromDate"], ToAddress = (string) reader["ToAddress"], ToCity = (string) reader["ToCity"], ToDistrict = (string) reader["ToDistrict"], ToDate = (DateTime) reader["ToDate"], Road = (string) reader["Road"], Other = (string) reader["Other"], 
                Actived = (bool) reader["Actived"]
             };
        }

        public DataTable BookSearch(string keyword, int memberid)
        {
            DataTable datatable = new DataTable();
            using (SqlConnection connection = base.GetConnection())
            {
                SqlCommand command = new SqlCommand("_BookSearch", connection) {
                    CommandType = CommandType.StoredProcedure
                };
                command.Parameters.AddWithValue("@Keyword", keyword);
                command.Parameters.AddWithValue("@ProductID", memberid);
                connection.Open();
                using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                {
                    adapter.Fill(datatable);
                    command.Dispose();
                }
            }
            return datatable;
        }

        public void CreateBook(Book book)
        {
            using (SqlConnection connection = base.GetConnection())
            {
                SqlCommand command = new SqlCommand("_BookUpdate", connection) {
                    CommandType = CommandType.StoredProcedure
                };
                command.Parameters.AddWithValue("@Type", 0);
                command.Parameters.AddWithValue("@BookID", 0);
                command.Parameters.AddWithValue("@ProductID", book.ProductID);
                command.Parameters.AddWithValue("@FromDate", book.FromDate);
                command.Parameters.AddWithValue("@ToDate", book.ToDate);
                command.Parameters.AddWithValue("@Actived", book.Actived);
                command.Parameters.AddWithValue("@FullName", book.FullName);
                command.Parameters.AddWithValue("@Email", book.Email);
                command.Parameters.AddWithValue("@Phone", book.Phone);
                command.Parameters.AddWithValue("@Address", book.Address);
                command.Parameters.AddWithValue("@Road", book.Road);
                command.Parameters.AddWithValue("@Other", book.Other);
                command.Parameters.AddWithValue("@FromCity", book.FromCity);
                command.Parameters.AddWithValue("@ToCity", book.ToCity);
                command.Parameters.AddWithValue("@FromDistrict", book.FromDistrict);
                command.Parameters.AddWithValue("@FromAddress", book.FromAddress);
                command.Parameters.AddWithValue("@ToDistrict", book.ToDistrict);
                command.Parameters.AddWithValue("@ToAddress", book.ToAddress);
                connection.Open();
                if (command.ExecuteNonQuery() <= 0)
                {
                    throw new DataAccessException("Lỗi kh\x00f4ng thể tao moi");
                }
                command.Dispose();
            }
        }

        public void DeleteBook(int bookID)
        {
            using (SqlConnection connection = base.GetConnection())
            {
                SqlCommand command = new SqlCommand("_BookDelete", connection) {
                    CommandType = CommandType.StoredProcedure
                };
                command.Parameters.AddWithValue("@BookID", bookID);
                connection.Open();
                if (command.ExecuteNonQuery() <= 0)
                {
                    throw new DataAccessException("Kh\x00f4ng thể x\x00f3a book");
                }
                command.Dispose();
            }
        }

        public DataTable GetBookAll()
        {
            DataTable datatable = new DataTable();
            using (SqlConnection connection = base.GetConnection())
            {
                SqlCommand command = new SqlCommand("_BookGetAll", connection) {
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

        public Book GetBookById(int bookID)
        {
            Book book = null;
            using (SqlConnection connection = base.GetConnection())
            {
                SqlCommand command = new SqlCommand("_BookGetById", connection) {
                    CommandType = CommandType.StoredProcedure
                };
                command.Parameters.AddWithValue("@BookID", bookID);
                connection.Open();
                using (SqlDataReader reader = command.ExecuteReader(CommandBehavior.CloseConnection))
                {
                    if (!reader.Read())
                    {
                        throw new DataAccessException("khong ton tai book");
                    }
                    book = this.BookReader(reader);
                }
                command.Dispose();
            }
            return book;
        }

        public DataTable GetBookByProductId(int memberID)
        {
            DataTable datatable = new DataTable();
            using (SqlConnection connection = base.GetConnection())
            {
                SqlCommand command = new SqlCommand("_BookGetByProductId", connection) {
                    CommandType = CommandType.StoredProcedure
                };
                command.Parameters.AddWithValue("@ProductID", memberID);
                connection.Open();
                using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                {
                    adapter.Fill(datatable);
                    command.Dispose();
                }
            }
            return datatable;
        }

        public DataTable GetBookProductAll()
        {
            DataTable datatable = new DataTable();
            using (SqlConnection connection = base.GetConnection())
            {
                SqlCommand command = new SqlCommand("_BookProductAll", connection) {
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

        public void UpdateBook(Book book)
        {
            using (SqlConnection connection = base.GetConnection())
            {
                SqlCommand command = new SqlCommand("_BookUpdate", connection) {
                    CommandType = CommandType.StoredProcedure
                };
                command.Parameters.AddWithValue("@Type", 1);
                command.Parameters.AddWithValue("@BookID", book.BookID);
                command.Parameters.AddWithValue("@ProductID", book.ProductID);
                command.Parameters.AddWithValue("@FromDate", book.FromDate);
                command.Parameters.AddWithValue("@ToDate", book.ToDate);
                command.Parameters.AddWithValue("@Actived", book.Actived);
                command.Parameters.AddWithValue("@FullName", book.FullName);
                command.Parameters.AddWithValue("@Email", book.Email);
                command.Parameters.AddWithValue("@Phone", book.Phone);
                command.Parameters.AddWithValue("@Address", book.Address);
                command.Parameters.AddWithValue("@Road", book.Road);
                command.Parameters.AddWithValue("@Other", book.Other);
                command.Parameters.AddWithValue("@FromCity", book.FromCity);
                command.Parameters.AddWithValue("@ToCity", book.ToCity);
                command.Parameters.AddWithValue("@FromDistrict", book.FromDistrict);
                command.Parameters.AddWithValue("@FromAddress", book.FromAddress);
                command.Parameters.AddWithValue("@ToDistrict", book.ToDistrict);
                command.Parameters.AddWithValue("@ToAddress", book.ToAddress);
                connection.Open();
                if (command.ExecuteNonQuery() <= 0)
                {
                    throw new DataAccessException("Lỗi kh\x00f4ng thể cập nhật");
                }
                command.Dispose();
            }
        }

        public void UpdateBook(string strId, string value)
        {
            using (SqlConnection connection = base.GetConnection())
            {
                string SQL = "update tblBook set Actived =" + value + " where BookID in('" + strId + "')";
                SqlCommand command = new SqlCommand(SQL, connection) {
                    CommandText = SQL
                };
                connection.Open();
                if (command.ExecuteNonQuery() <= 0)
                {
                    throw new DataAccessException("khong the cap nhat");
                }
                command.Dispose();
            }
        }
    }
}

