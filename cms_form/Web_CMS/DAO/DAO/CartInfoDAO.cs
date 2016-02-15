namespace DAO
{
    using ETO;
    using System;
    using System.Data;
    using System.Data.SqlClient;

    public class CartInfoDAO : BaseDAO
    {
        private CartInfo CartInfoReader(SqlDataReader reader)
        {
            return new CartInfo { CartInfoID = (int) reader["CartInfoID"], OrderID = (int) reader["OrderID"], ProductID = (int) reader["ProductID"], Price = (double) reader["Price"], Quatity = (int) reader["Quatity"] };
        }

        public void CreateCartInfo(CartInfo cartInfo)
        {
            using (SqlConnection connection = base.GetConnection())
            {
                SqlCommand command = new SqlCommand("_CartInfoUpdate", connection) {
                    CommandType = CommandType.StoredProcedure
                };
                command.Parameters.AddWithValue("@Type", 0);
                command.Parameters.AddWithValue("@CartInfoID", cartInfo.CartInfoID);
                command.Parameters.AddWithValue("@OrderID", cartInfo.OrderID);
                command.Parameters.AddWithValue("@ProductID", cartInfo.ProductID);
                command.Parameters.AddWithValue("@Price", cartInfo.Price);
                command.Parameters.AddWithValue("@Quatity", cartInfo.Quatity);
                connection.Open();
                if (command.ExecuteNonQuery() <= 0)
                {
                    throw new DataAccessException("Lỗi kh\x00f4ng thể tao moi");
                }
                command.Dispose();
            }
        }

        public void DeleteCartInfo(int orderID)
        {
            using (SqlConnection connection = base.GetConnection())
            {
                SqlCommand command = new SqlCommand("_CartInfoDelete", connection) {
                    CommandType = CommandType.StoredProcedure
                };
                command.Parameters.AddWithValue("@OrderID", orderID);
                connection.Open();
                if (command.ExecuteNonQuery() <= 0)
                {
                    throw new DataAccessException("Kh\x00f4ng thể x\x00f3a cartInfo");
                }
                command.Dispose();
            }
        }

        public void DeleteCartInfoProduct(int orderID, int productID)
        {
            using (SqlConnection connection = base.GetConnection())
            {
                SqlCommand command = new SqlCommand("_CartInfoDeleteProduct", connection) {
                    CommandType = CommandType.StoredProcedure
                };
                command.Parameters.AddWithValue("@OrderID", orderID);
                command.Parameters.AddWithValue("@ProductID", productID);
                connection.Open();
                if (command.ExecuteNonQuery() <= 0)
                {
                    throw new DataAccessException("Kh\x00f4ng thể x\x00f3a cartInfo");
                }
                command.Dispose();
            }
        }

        public void DeleteCartInfoProduct(int orderID, string strId)
        {
            using (SqlConnection connection = base.GetConnection())
            {
                string SQL = string.Concat(new object[] { "delete tblCartInfo where OrderID = ", orderID, " and ProductID in('", strId, "')" });
                SqlCommand command = new SqlCommand(SQL, connection) {
                    CommandText = SQL
                };
                connection.Open();
                if (command.ExecuteNonQuery() <= 0)
                {
                    throw new DataAccessException("khong the xoa Cart");
                }
                command.Dispose();
            }
        }

        public DataTable GetCartInfoAll()
        {
            DataTable datatable = new DataTable();
            using (SqlConnection connection = base.GetConnection())
            {
                SqlCommand command = new SqlCommand("_CartInfoGetAll", connection) {
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

        public CartInfo GetCartInfoById(int cartInfoID)
        {
            CartInfo cartInfo = null;
            using (SqlConnection connection = base.GetConnection())
            {
                SqlCommand command = new SqlCommand("_CartInfoGetById", connection) {
                    CommandType = CommandType.StoredProcedure
                };
                command.Parameters.AddWithValue("@CartInfoID", cartInfoID);
                connection.Open();
                using (SqlDataReader reader = command.ExecuteReader(CommandBehavior.CloseConnection))
                {
                    if (!reader.Read())
                    {
                        throw new DataAccessException("khong ton tai cartInfo");
                    }
                    cartInfo = this.CartInfoReader(reader);
                }
                command.Dispose();
            }
            return cartInfo;
        }

        public DataTable GetCartInfoByOrderId(int orderID)
        {
            DataTable datatable = new DataTable();
            using (SqlConnection connection = base.GetConnection())
            {
                SqlCommand command = new SqlCommand("_CartInfoGetByOrderId", connection) {
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

        public CartInfo GetCartInfoByProductId(int orderID, int productID)
        {
            CartInfo cartInfo = null;
            using (SqlConnection connection = base.GetConnection())
            {
                SqlCommand command = new SqlCommand("_CartInfoGetByProductId", connection) {
                    CommandType = CommandType.StoredProcedure
                };
                command.Parameters.AddWithValue("@OrderID", orderID);
                command.Parameters.AddWithValue("@ProductID", productID);
                connection.Open();
                using (SqlDataReader reader = command.ExecuteReader(CommandBehavior.CloseConnection))
                {
                    if (!reader.Read())
                    {
                        throw new DataAccessException("khong ton tai cartInfo");
                    }
                    cartInfo = this.CartInfoReader(reader);
                }
                command.Dispose();
            }
            return cartInfo;
        }

        public DataTable GetTableCartInfoByProductId(int orderID, int productID)
        {
            DataTable datatable = new DataTable();
            using (SqlConnection connection = base.GetConnection())
            {
                SqlCommand command = new SqlCommand("_CartInfoGetByProductId", connection) {
                    CommandType = CommandType.StoredProcedure
                };
                command.Parameters.AddWithValue("@OrderID", orderID);
                command.Parameters.AddWithValue("@ProductID", productID);
                connection.Open();
                using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                {
                    adapter.Fill(datatable);
                    command.Dispose();
                }
                return datatable;
            }
        }

        public DataTable GetViewCartInfoByOrderId(int orderID)
        {
            DataTable datatable = new DataTable();
            using (SqlConnection connection = base.GetConnection())
            {
                SqlCommand command = new SqlCommand("_ViewCartInfoGetByOrderId", connection) {
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

        public void UpdateCartInfo(CartInfo cartInfo)
        {
            using (SqlConnection connection = base.GetConnection())
            {
                SqlCommand command = new SqlCommand("_CartInfoUpdate", connection) {
                    CommandType = CommandType.StoredProcedure
                };
                command.Parameters.AddWithValue("@Type", 1);
                command.Parameters.AddWithValue("@CartInfoID", cartInfo.CartInfoID);
                command.Parameters.AddWithValue("@OrderID", cartInfo.OrderID);
                command.Parameters.AddWithValue("@ProductID", cartInfo.ProductID);
                command.Parameters.AddWithValue("@Price", cartInfo.Price);
                command.Parameters.AddWithValue("@Quatity", cartInfo.Quatity);
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

