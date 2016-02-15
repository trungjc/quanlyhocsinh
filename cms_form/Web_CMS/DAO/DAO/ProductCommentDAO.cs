namespace DAO
{
    using ETO;
    using System;
    using System.Data;
    using System.Data.SqlClient;

    public class ProductCommentDAO : BaseDAO
    {
        public void CreateProductComment(ProductComment productComment)
        {
            using (SqlConnection connection = base.GetConnection())
            {
                SqlCommand command = new SqlCommand("_ProductCommentUpdate", connection) {
                    CommandType = CommandType.StoredProcedure
                };
                command.Parameters.AddWithValue("@Type", 0);
                command.Parameters.AddWithValue("@CommentID", 0);
                command.Parameters.AddWithValue("@ProductID", productComment.ProductID);
                command.Parameters.AddWithValue("@FullName", productComment.FullName);
                command.Parameters.AddWithValue("@Email", productComment.Email);
                command.Parameters.AddWithValue("@Title", productComment.Title);
                command.Parameters.AddWithValue("@Content", productComment.Content);
                command.Parameters.AddWithValue("@DateCreated", productComment.DateCreated);
                command.Parameters.AddWithValue("@Actived", productComment.Actived);
                connection.Open();
                if (command.ExecuteNonQuery() <= 0)
                {
                    throw new DataAccessException("Lỗi kh\x00f4ng thể tao moi");
                }
                command.Dispose();
            }
        }

        public void DeleteProductComment(int commentID)
        {
            using (SqlConnection connection = base.GetConnection())
            {
                SqlCommand command = new SqlCommand("_ProductCommentDelete", connection) {
                    CommandType = CommandType.StoredProcedure
                };
                command.Parameters.AddWithValue("@CommentID", commentID);
                connection.Open();
                if (command.ExecuteNonQuery() <= 0)
                {
                    throw new DataAccessException("Kh\x00f4ng thể x\x00f3a productComment");
                }
                command.Dispose();
            }
        }

        public void DeleteProductComment(string strId)
        {
            using (SqlConnection connection = base.GetConnection())
            {
                string SQL = "delete tblProductComment where CommentID in('" + strId + "')";
                SqlCommand command = new SqlCommand(SQL, connection) {
                    CommandText = SQL
                };
                connection.Open();
                if (command.ExecuteNonQuery() <= 0)
                {
                    throw new DataAccessException("khong the xoa đ\x00e1nh gi\x00e1");
                }
                command.Dispose();
            }
        }

        public DataTable GetAllProductComment()
        {
            DataTable datatable = new DataTable();
            using (SqlConnection connection = base.GetConnection())
            {
                SqlCommand command = new SqlCommand("_ProductCommentGetAll", connection) {
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

        public DataTable GetAllViewProductComment()
        {
            DataTable datatable = new DataTable();
            using (SqlConnection connection = base.GetConnection())
            {
                SqlCommand command = new SqlCommand("_ProductCommentViewGetAll", connection) {
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

        public ProductComment GetProductCommentById(int commentID)
        {
            ProductComment productComment = null;
            using (SqlConnection connection = base.GetConnection())
            {
                SqlCommand command = new SqlCommand("_ProductCommentGetById", connection) {
                    CommandType = CommandType.StoredProcedure
                };
                command.Parameters.AddWithValue("@CommentID", commentID);
                connection.Open();
                using (SqlDataReader reader = command.ExecuteReader(CommandBehavior.CloseConnection))
                {
                    if (!reader.Read())
                    {
                        throw new DataAccessException("khong ton tai productComment");
                    }
                    productComment = this.ProductCommentReader(reader);
                }
                command.Dispose();
            }
            return productComment;
        }

        public DataTable GetProductCommentByProductID(int productID)
        {
            DataTable datatable = new DataTable();
            using (SqlConnection connection = base.GetConnection())
            {
                SqlCommand command = new SqlCommand("_ProductCommentGetProductID", connection) {
                    CommandType = CommandType.StoredProcedure
                };
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

        private ProductComment ProductCommentReader(SqlDataReader reader)
        {
            return new ProductComment { CommentID = (int) reader["CommentID"], ProductID = (int) reader["ProductID"], FullName = (string) reader["FullName"], Email = (string) reader["Email"], Title = (string) reader["Title"], Content = (string) reader["Content"], DateCreated = (DateTime) reader["DateCreated"], Actived = (bool) reader["Actived"] };
        }

        public void UpdateProductComment(ProductComment productComment)
        {
            using (SqlConnection connection = base.GetConnection())
            {
                SqlCommand command = new SqlCommand("_ProductCommentUpdate", connection) {
                    CommandType = CommandType.StoredProcedure
                };
                command.Parameters.AddWithValue("@Type", 1);
                command.Parameters.AddWithValue("@CommentID", productComment.CommentID);
                command.Parameters.AddWithValue("@ProductID", productComment.ProductID);
                command.Parameters.AddWithValue("@FullName", productComment.FullName);
                command.Parameters.AddWithValue("@Email", productComment.Email);
                command.Parameters.AddWithValue("@Title", productComment.Title);
                command.Parameters.AddWithValue("@Content", productComment.Content);
                command.Parameters.AddWithValue("@DateCreated", productComment.DateCreated);
                command.Parameters.AddWithValue("@Actived", productComment.Actived);
                connection.Open();
                if (command.ExecuteNonQuery() <= 0)
                {
                    throw new DataAccessException("Lỗi kh\x00f4ng thể tao moi");
                }
                command.Dispose();
            }
        }

        public void UpdateProductComment(string strId, string value)
        {
            using (SqlConnection connection = base.GetConnection())
            {
                string SQL = "update tblProductComment set Actived =" + value + " where CommentID in('" + strId + "')";
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

