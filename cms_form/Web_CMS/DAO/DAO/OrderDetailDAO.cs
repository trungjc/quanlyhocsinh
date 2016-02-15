namespace DAO
{
    using ETO;
    using System;
    using System.Data;
    using System.Data.SqlClient;

    public class OrderDetailDAO : BaseDAO
    {
        public void CreateOrderDetail(OrderDetail orderDetail)
        {
            using (SqlConnection connection = base.GetConnection())
            {
                SqlCommand command = new SqlCommand("_OrderDetailUpdate", connection) {
                    CommandType = CommandType.StoredProcedure
                };
                command.Parameters.AddWithValue("@Type", 0);
                command.Parameters.AddWithValue("@OrderDetailID", orderDetail.OrderDetailID);
                command.Parameters.AddWithValue("@OrderID", orderDetail.OrderID);
                command.Parameters.AddWithValue("@ProductID", orderDetail.ProductID);
                command.Parameters.AddWithValue("@Price", orderDetail.Price);
                command.Parameters.AddWithValue("@Quatity", orderDetail.Quatity);
                connection.Open();
                if (command.ExecuteNonQuery() <= 0)
                {
                    throw new DataAccessException("Lỗi kh\x00f4ng thể tao moi");
                }
                command.Dispose();
            }
        }

        public void DeleteOrderDetail(int orderDetailID)
        {
            using (SqlConnection connection = base.GetConnection())
            {
                SqlCommand command = new SqlCommand("_OrderDetailDelete", connection) {
                    CommandType = CommandType.StoredProcedure
                };
                command.Parameters.AddWithValue("@OrderDetailID", orderDetailID);
                connection.Open();
                if (command.ExecuteNonQuery() <= 0)
                {
                    throw new DataAccessException("Kh\x00f4ng thể x\x00f3a orderDetail");
                }
                command.Dispose();
            }
        }

        public void DeleteOrderDetailOrder(int orderID)
        {
            using (SqlConnection connection = base.GetConnection())
            {
                SqlCommand command = new SqlCommand("_OrderDetailDeleteOrder", connection) {
                    CommandType = CommandType.StoredProcedure
                };
                command.Parameters.AddWithValue("@OrderID", orderID);
                connection.Open();
                if (command.ExecuteNonQuery() <= 0)
                {
                    throw new DataAccessException("Kh\x00f4ng thể x\x00f3a orderDetail");
                }
                command.Dispose();
            }
        }

        public DataTable GetOrderDetailAll()
        {
            DataTable datatable = new DataTable();
            using (SqlConnection connection = base.GetConnection())
            {
                SqlCommand command = new SqlCommand("_OrderDetailGetAll", connection) {
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

        public OrderDetail GetOrderDetailById(int orderDetailID)
        {
            OrderDetail orderDetail = null;
            using (SqlConnection connection = base.GetConnection())
            {
                SqlCommand command = new SqlCommand("_OrderDetailGetById", connection) {
                    CommandType = CommandType.StoredProcedure
                };
                command.Parameters.AddWithValue("@OrderDetailID", orderDetailID);
                connection.Open();
                using (SqlDataReader reader = command.ExecuteReader(CommandBehavior.CloseConnection))
                {
                    if (!reader.Read())
                    {
                        throw new DataAccessException("khong ton tai orderDetail");
                    }
                    orderDetail = this.OrderDetailReader(reader);
                }
                command.Dispose();
            }
            return orderDetail;
        }

        public DataTable GetOrderDetailByOrderId(int orderID)
        {
            DataTable datatable = new DataTable();
            using (SqlConnection connection = base.GetConnection())
            {
                SqlCommand command = new SqlCommand("_OrderDetailGetByOrderId", connection) {
                    CommandType = CommandType.StoredProcedure
                };
                command.Parameters.AddWithValue("@OrderID", orderID);
                connection.Open();
                using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                {
                    adapter.Fill(datatable);
                    command.Dispose();
                }
                return datatable;
            }
        }

        private OrderDetail OrderDetailReader(SqlDataReader reader)
        {
            return new OrderDetail { OrderDetailID = (int) reader["OrderDetailID"], OrderID = (int) reader["OrderID"], ProductID = (int) reader["ProductID"], Price = (double) reader["Price"], Quatity = (int) reader["Quatity"] };
        }

        public void UpdateOrderDetail(OrderDetail orderDetail)
        {
            using (SqlConnection connection = base.GetConnection())
            {
                SqlCommand command = new SqlCommand("_OrderDetailUpdate", connection) {
                    CommandType = CommandType.StoredProcedure
                };
                command.Parameters.AddWithValue("@Type", 1);
                command.Parameters.AddWithValue("@OrderDetailID", orderDetail.OrderDetailID);
                command.Parameters.AddWithValue("@OrderID", orderDetail.OrderID);
                command.Parameters.AddWithValue("@ProductID", orderDetail.ProductID);
                command.Parameters.AddWithValue("@Price", orderDetail.Price);
                command.Parameters.AddWithValue("@Quatity", orderDetail.Quatity);
                connection.Open();
                if (command.ExecuteNonQuery() <= 0)
                {
                    throw new DataAccessException("Lỗi kh\x00f4ng thể tao moi");
                }
                command.Dispose();
            }
        }
    }
}

