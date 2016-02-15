namespace DAO
{
    using ETO;
    using System;
    using System.Data;
    using System.Data.SqlClient;

    public class ProductDAO : BaseDAO
    {
        public int CreateProduct(Product product)
        {
            int i = 0;
            using (SqlConnection connection = base.GetConnection())
            {
                SqlCommand command = new SqlCommand("_ProductUpdate", connection) {
                    CommandType = CommandType.StoredProcedure
                };
                command.Parameters.AddWithValue("@Type", 0);
                command.Parameters.AddWithValue("@ProductID", 0);
                command.Parameters.AddWithValue("@CateProductID", product.CateProductID);
                command.Parameters.AddWithValue("@ParentProductID", product.ParentProductID);
                command.Parameters.AddWithValue("@BrandID", product.BrandID);
                command.Parameters.AddWithValue("@ProductName", product.ProductName);
                command.Parameters.AddWithValue("@ShortDescribe", product.ShortDescribe);
                command.Parameters.AddWithValue("@FullDescribe", product.FullDescribe);
                command.Parameters.AddWithValue("@Detail", product.Detail);
                command.Parameters.AddWithValue("@ImageThumb", product.ImageThumb);
                command.Parameters.AddWithValue("@ImageLarge", product.ImageLarge);
                command.Parameters.AddWithValue("@Amount", product.Amount);
                command.Parameters.AddWithValue("@Store", product.Store);
                command.Parameters.AddWithValue("@OldPrice", product.OldPrice);
                command.Parameters.AddWithValue("@NewPrice", product.NewPrice);
                command.Parameters.AddWithValue("@Status", product.Status);
                command.Parameters.AddWithValue("@Ishot", product.Ishot);
                command.Parameters.AddWithValue("@Language", product.Language);
                command.Parameters.AddWithValue("@Field1", product.Field1);
                command.Parameters.AddWithValue("@Field2", product.Field2);
                command.Parameters.AddWithValue("@Field3", product.Field3);
                command.Parameters.AddWithValue("@Field4", product.Field4);
                command.Parameters.AddWithValue("@Field5", product.Field5);
                SqlParameter parameter = new SqlParameter("@ReturnId", SqlDbType.Int) {
                    Direction = ParameterDirection.ReturnValue
                };
                command.Parameters.Add(parameter);
                connection.Open();
                if (command.ExecuteNonQuery() <= 0)
                {
                    throw new DataAccessException("Khong them duoc san pham");
                }
                i = (int) parameter.Value;
                command.Dispose();
            }
            return i;
        }

        public void DeleteProduct(int Id)
        {
            using (SqlConnection connection = base.GetConnection())
            {
                SqlCommand command = new SqlCommand("_ProductDelete", connection) {
                    CommandType = CommandType.StoredProcedure
                };
                command.Parameters.AddWithValue("@ProductID", Id);
                connection.Open();
                if (command.ExecuteNonQuery() <= 0)
                {
                    throw new DataAccessException("Khong xoa duoc san pham");
                }
                command.Dispose();
            }
        }

        public DataTable GetProduct10(string lang)
        {
            DataTable datatable = new DataTable();
            using (SqlConnection connection = base.GetConnection())
            {
                SqlCommand command = new SqlCommand("_ProductGet10", connection) {
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

        public DataTable GetProductAll(string lang)
        {
            DataTable datatable = new DataTable();
            using (SqlConnection connection = base.GetConnection())
            {
                SqlCommand command = new SqlCommand("_ProductGetAll", connection) {
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

        public DataTable GetProductByCate(int cId)
        {
            DataTable datatable = new DataTable();
            using (SqlConnection connection = base.GetConnection())
            {
                SqlCommand command = new SqlCommand("_ProductGetById", connection) {
                    CommandType = CommandType.StoredProcedure
                };
                command.Parameters.AddWithValue("@CateProductID", cId);
                command.Parameters.AddWithValue("@ProductID", 0);
                connection.Open();
                using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                {
                    adapter.Fill(datatable);
                    command.Dispose();
                }
            }
            return datatable;
        }

        public DataTable GetProductByCateAll(string strCate)
        {
            DataTable datatable = new DataTable();
            using (SqlConnection connection = base.GetConnection())
            {
                string SQL = "select * from tblProduct where CateProductID in('" + strCate + "') order by ProductID Desc";
                SqlCommand command = new SqlCommand(SQL, connection) {
                    CommandText = SQL
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

        public DataTable GetProductByCateHome(int cId)
        {
            DataTable datatable = new DataTable();
            using (SqlConnection connection = base.GetConnection())
            {
                SqlCommand command = new SqlCommand("_ProductGetHomeById", connection) {
                    CommandType = CommandType.StoredProcedure
                };
                command.Parameters.AddWithValue("@CateProductID", cId);
                connection.Open();
                using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                {
                    adapter.Fill(datatable);
                    command.Dispose();
                }
            }
            return datatable;
        }

        public DataTable GetProductByCateHomeAll(string strCate)
        {
            DataTable datatable = new DataTable();
            using (SqlConnection connection = base.GetConnection())
            {
                string SQL = "select top 8 * from tblProduct where status=0 and CateProductID in('" + strCate + "') order by ProductID desc";
                SqlCommand command = new SqlCommand(SQL, connection) {
                    CommandText = SQL
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

        public DataTable GetProductByCateHomeAll(int n, string strCate)
        {
            DataTable datatable = new DataTable();
            using (SqlConnection connection = base.GetConnection())
            {
                string SQL = "select top " + n.ToString() + " * from tblProduct where status=0 and CateProductID in('" + strCate + "') order by ProductID desc";
                SqlCommand command = new SqlCommand(SQL, connection) {
                    CommandText = SQL
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

        public DataTable GetProductByCateHomeList(string strCate, int num)
        {
            DataTable datatable = new DataTable();
            using (SqlConnection connection = base.GetConnection())
            {
                string SQL = "select top " + Convert.ToString(num) + " * from tblProduct where CateProductID in('" + strCate + "') order by ProductID Desc";
                SqlCommand command = new SqlCommand(SQL, connection) {
                    CommandText = SQL
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

        public Product GetProductById(int Id)
        {
            Product product = null;
            using (SqlConnection connection = base.GetConnection())
            {
                SqlCommand command = new SqlCommand("_ProductGetById", connection) {
                    CommandType = CommandType.StoredProcedure
                };
                command.Parameters.AddWithValue("@CateProductID", 0);
                command.Parameters.AddWithValue("@ProductID", Id);
                connection.Open();
                using (SqlDataReader reader = command.ExecuteReader(CommandBehavior.CloseConnection))
                {
                    if (!reader.Read())
                    {
                        throw new DataAccessException("Khong tim thay san pham");
                    }
                    product = this.ProductReader(reader);
                    command.Dispose();
                }
            }
            return product;
        }

        public DataTable GetProductByInStrId(string str)
        {
            DataTable datatable = new DataTable();
            using (SqlConnection connection = base.GetConnection())
            {
                SqlCommand command = new SqlCommand("ProductGetByInStrId", connection) {
                    CommandType = CommandType.StoredProcedure
                };
                command.Parameters.AddWithValue("@Str", str);
                connection.Open();
                using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                {
                    adapter.Fill(datatable);
                    command.Dispose();
                }
            }
            return datatable;
        }

        public DataTable GetProductHot(string lang)
        {
            DataTable datatable = new DataTable();
            using (SqlConnection connection = base.GetConnection())
            {
                SqlCommand command = new SqlCommand("_ProductHot", connection) {
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

        private Product ProductReader(SqlDataReader reader)
        {
            return new Product { 
                ProductID = (int) reader["ProductID"], CateProductID = (int) reader["CateProductID"], ParentProductID = (int) reader["ParentProductID"], BrandID = (int) reader["BrandID"], ProductName = (string) reader["ProductName"], ShortDescribe = (string) reader["ShortDescribe"], FullDescribe = (string) reader["FullDescribe"], Detail = (string) reader["Detail"], ImageThumb = (string) reader["ImageThumb"], ImageLarge = (string) reader["ImageLarge"], Amount = (int) reader["Amount"], Store = (bool) reader["Store"], OldPrice = (double) reader["OldPrice"], NewPrice = (double) reader["NewPrice"], Language = (string) reader["Language"], Isview = (int) reader["Isview"], 
                Ishot = (bool) reader["Ishot"], Status = (bool) reader["Status"], Field1 = (string) reader["Field1"], Field2 = (string) reader["Field2"], Field3 = (string) reader["Field3"], Field4 = (string) reader["Field4"], Field5 = (string) reader["Field5"]
             };
        }

        public DataTable ProductSearch(string keyword, int cateid, string lang)
        {
            DataTable datatable = new DataTable();
            using (SqlConnection connection = base.GetConnection())
            {
                SqlCommand command = new SqlCommand("_ProductSearch", connection) {
                    CommandType = CommandType.StoredProcedure
                };
                command.Parameters.AddWithValue("@Keyword", keyword);
                command.Parameters.AddWithValue("@CateProductID", cateid);
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

        public DataTable ProductSearchCate(int cateid, string lang)
        {
            DataTable datatable = new DataTable();
            using (SqlConnection connection = base.GetConnection())
            {
                SqlCommand command = new SqlCommand("_ProductSearchCate", connection) {
                    CommandType = CommandType.StoredProcedure
                };
                command.Parameters.AddWithValue("@CateProductID", cateid);
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

        public void UpdateProduct(Product product)
        {
            using (SqlConnection connection = base.GetConnection())
            {
                SqlCommand command = new SqlCommand("_ProductUpdate", connection) {
                    CommandType = CommandType.StoredProcedure
                };
                command.Parameters.AddWithValue("@Type", 1);
                command.Parameters.AddWithValue("@ProductID", product.ProductID);
                command.Parameters.AddWithValue("@CateProductID", product.CateProductID);
                command.Parameters.AddWithValue("@ParentProductID", product.ParentProductID);
                command.Parameters.AddWithValue("@BrandID", product.BrandID);
                command.Parameters.AddWithValue("@ProductName", product.ProductName);
                command.Parameters.AddWithValue("@ShortDescribe", product.ShortDescribe);
                command.Parameters.AddWithValue("@FullDescribe", product.FullDescribe);
                command.Parameters.AddWithValue("@Detail", product.Detail);
                command.Parameters.AddWithValue("@ImageThumb", product.ImageThumb);
                command.Parameters.AddWithValue("@ImageLarge", product.ImageLarge);
                command.Parameters.AddWithValue("@Amount", product.Amount);
                command.Parameters.AddWithValue("@Store", product.Store);
                command.Parameters.AddWithValue("@OldPrice", product.OldPrice);
                command.Parameters.AddWithValue("@NewPrice", product.NewPrice);
                command.Parameters.AddWithValue("@Status", product.Status);
                command.Parameters.AddWithValue("@Ishot", product.Ishot);
                command.Parameters.AddWithValue("@Language", product.Language);
                command.Parameters.AddWithValue("@Field1", product.Field1);
                command.Parameters.AddWithValue("@Field2", product.Field2);
                command.Parameters.AddWithValue("@Field3", product.Field3);
                command.Parameters.AddWithValue("@Field4", product.Field4);
                command.Parameters.AddWithValue("@Field5", product.Field5);
                connection.Open();
                if (command.ExecuteNonQuery() <= 0)
                {
                    throw new DataAccessException("Khong cap nhat duoc san pham");
                }
                command.Dispose();
            }
        }

        public void UpdateProduct(string strId, string value)
        {
            using (SqlConnection connection = base.GetConnection())
            {
                string SQL = "update tblProduct set Status = " + value + " where ProductID in('" + strId + "')";
                SqlCommand command = new SqlCommand(SQL, connection) {
                    CommandText = SQL
                };
                connection.Open();
                if (command.ExecuteNonQuery() <= 0)
                {
                    throw new DataAccessException("Kh\x00f4ng cập nhật được tin n\x00e0o");
                }
                command.Dispose();
            }
        }
    }
}

