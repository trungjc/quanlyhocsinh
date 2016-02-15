namespace DAO
{
    using ETO;
    using System;
    using System.Data;
    using System.Data.SqlClient;

    public class OrderDAO : BaseDAO
    {
        public void CreateOrder(Order order)
        {
            using (SqlConnection connection = base.GetConnection())
            {
                SqlCommand command = new SqlCommand("_OrderUpdate", connection) {
                    CommandType = CommandType.StoredProcedure
                };
                command.Parameters.AddWithValue("@Type", 0);
                command.Parameters.AddWithValue("@ID", 0);
                command.Parameters.AddWithValue("@OrderID", order.OrderID);
                command.Parameters.AddWithValue("@MemberID", order.MemberID);
                command.Parameters.AddWithValue("@Title", order.Title);
                command.Parameters.AddWithValue("@DateCreated", order.DateCreated);
                command.Parameters.AddWithValue("@IsActived", order.IsActived);
                command.Parameters.AddWithValue("@FullName", order.FullName);
                command.Parameters.AddWithValue("@Email", order.Email);
                command.Parameters.AddWithValue("@Phone", order.Phone);
                command.Parameters.AddWithValue("@Address", order.Address);
                command.Parameters.AddWithValue("@NickYahoo", order.NickYahoo);
                command.Parameters.AddWithValue("@NickSkype", order.NickSkype);
                command.Parameters.AddWithValue("@Require", order.Require);
                connection.Open();
                if (command.ExecuteNonQuery() <= 0)
                {
                    throw new DataAccessException("Lỗi kh\x00f4ng thể tao moi");
                }
                command.Dispose();
            }
        }

        public void DeleteOrder(int orderID)
        {
            using (SqlConnection connection = base.GetConnection())
            {
                SqlCommand command = new SqlCommand("_OrderDelete", connection) {
                    CommandType = CommandType.StoredProcedure
                };
                command.Parameters.AddWithValue("@OrderID", orderID);
                connection.Open();
                if (command.ExecuteNonQuery() <= 0)
                {
                    throw new DataAccessException("Kh\x00f4ng thể x\x00f3a order");
                }
                command.Dispose();
            }
        }

        public DataTable GetOrderAll()
        {
            DataTable datatable = new DataTable();
            using (SqlConnection connection = base.GetConnection())
            {
                SqlCommand command = new SqlCommand("_OrderGetAll", connection) {
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

        public Order GetOrderById(int orderID)
        {
            Order order = null;
            using (SqlConnection connection = base.GetConnection())
            {
                SqlCommand command = new SqlCommand("_OrderGetById", connection) {
                    CommandType = CommandType.StoredProcedure
                };
                command.Parameters.AddWithValue("@OrderID", orderID);
                connection.Open();
                using (SqlDataReader reader = command.ExecuteReader(CommandBehavior.CloseConnection))
                {
                    if (!reader.Read())
                    {
                        throw new DataAccessException("khong ton tai order");
                    }
                    order = this.OrderReader(reader);
                }
                command.Dispose();
            }
            return order;
        }

        public DataTable GetOrderByMemberId(int memberID)
        {
            DataTable datatable = new DataTable();
            using (SqlConnection connection = base.GetConnection())
            {
                SqlCommand command = new SqlCommand("_OrderGetByMemberId", connection) {
                    CommandType = CommandType.StoredProcedure
                };
                command.Parameters.AddWithValue("@MemberID", memberID);
                connection.Open();
                using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                {
                    adapter.Fill(datatable);
                    command.Dispose();
                }
            }
            return datatable;
        }

        public DataTable GetOrderMemberAll()
        {
            DataTable datatable = new DataTable();
            using (SqlConnection connection = base.GetConnection())
            {
                SqlCommand command = new SqlCommand("_OrderMemberGetAll", connection) {
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

        private Order OrderReader(SqlDataReader reader)
        {
            return new Order { ID = (int) reader["ID"], OrderID = (int) reader["OrderID"], MemberID = (int) reader["MemberID"], Title = (string) reader["Title"], DateCreated = (DateTime) reader["DateCreated"], IsActived = (bool) reader["IsActived"], FullName = (string) reader["FullName"], Email = (string) reader["Email"], Phone = (string) reader["Phone"], Address = (string) reader["Address"], NickYahoo = (string) reader["NickYahoo"], NickSkype = (string) reader["NickSkype"], Require = (string) reader["Require"] };
        }

        public DataTable OrderSearch(string keyword, int memberid)
        {
            DataTable datatable = new DataTable();
            using (SqlConnection connection = base.GetConnection())
            {
                SqlCommand command = new SqlCommand("_OrderSearch", connection) {
                    CommandType = CommandType.StoredProcedure
                };
                command.Parameters.AddWithValue("@Keyword", keyword);
                command.Parameters.AddWithValue("@MemberID", memberid);
                connection.Open();
                using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                {
                    adapter.Fill(datatable);
                    command.Dispose();
                }
            }
            return datatable;
        }

        public void UpdateOrder(Order order)
        {
            using (SqlConnection connection = base.GetConnection())
            {
                SqlCommand command = new SqlCommand("_OrderUpdate", connection) {
                    CommandType = CommandType.StoredProcedure
                };
                command.Parameters.AddWithValue("@Type", 1);
                command.Parameters.AddWithValue("@ID", order.OrderID);
                command.Parameters.AddWithValue("@OrderID", order.OrderID);
                command.Parameters.AddWithValue("@MemberID", order.MemberID);
                command.Parameters.AddWithValue("@Title", order.Title);
                command.Parameters.AddWithValue("@DateCreated", order.DateCreated);
                command.Parameters.AddWithValue("@IsActived", order.IsActived);
                command.Parameters.AddWithValue("@FullName", order.FullName);
                command.Parameters.AddWithValue("@Email", order.Email);
                command.Parameters.AddWithValue("@Phone", order.Phone);
                command.Parameters.AddWithValue("@Address", order.Address);
                command.Parameters.AddWithValue("@NickYahoo", order.NickYahoo);
                command.Parameters.AddWithValue("@NickSkype", order.NickSkype);
                command.Parameters.AddWithValue("@Require", order.Require);
                connection.Open();
                if (command.ExecuteNonQuery() <= 0)
                {
                    throw new DataAccessException("Lỗi kh\x00f4ng thể cập nhật");
                }
                command.Dispose();
            }
        }

        public void UpdateOrder(string strId, string value)
        {
            using (SqlConnection connection = base.GetConnection())
            {
                string SQL = "update tblOrder set IsActived =" + value + " where OrderID in('" + strId + "')";
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

