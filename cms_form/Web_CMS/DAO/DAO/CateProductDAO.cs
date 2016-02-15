namespace DAO
{
    using ETO;
    using System;
    using System.Data;
    using System.Data.SqlClient;
    using System.Web;

    public class CateProductDAO : BaseDAO
    {
        private CateProduct CateProductReader(SqlDataReader reader)
        {
            return new CateProduct { CateProductID = (int) reader["CateProductID"], ParentProductID = (int) reader["ParentProductID"], CateProductName = (string) reader["CateProductName"], CateProductTotal = (int) reader["CateProductTotal"], CateProductOrder = (int) reader["CateProductOrder"], Language = (string) reader["Language"], Icon = (string) reader["Icon"], Slogan = (string) reader["Slogan"] };
        }

        public void CateProductUpOrder(int cId, int cOrder)
        {
            using (SqlConnection connection = base.GetConnection())
            {
                SqlCommand command = new SqlCommand("_CateProductUpOrder", connection) {
                    CommandType = CommandType.StoredProcedure
                };
                command.Parameters.AddWithValue("@CateProductID", cId);
                command.Parameters.AddWithValue("@CateProductOrder", cOrder);
                connection.Open();
                if (command.ExecuteNonQuery() <= 0)
                {
                    throw new DataAccessException("Kh\x00f4ng thể cập nhật danh mục san pham");
                }
                command.Dispose();
            }
        }

        public void CreateCateProduct(CateProduct cateproduct)
        {
            using (SqlConnection connection = base.GetConnection())
            {
                SqlCommand command = new SqlCommand("_CateProductUpdate", connection) {
                    CommandType = CommandType.StoredProcedure
                };
                command.Parameters.AddWithValue("@Type", 0);
                command.Parameters.AddWithValue("@CateProductID", 0);
                command.Parameters.AddWithValue("@ParentProductID", cateproduct.ParentProductID);
                command.Parameters.AddWithValue("@CateProductName", cateproduct.CateProductName);
                command.Parameters.AddWithValue("@CateProductTotal", cateproduct.CateProductTotal);
                command.Parameters.AddWithValue("@CateProductOrder", cateproduct.CateProductOrder);
                command.Parameters.AddWithValue("@Language", cateproduct.Language);
                command.Parameters.AddWithValue("@Icon", cateproduct.Icon);
                command.Parameters.AddWithValue("@Slogan", cateproduct.Slogan);
                connection.Open();
                if (command.ExecuteNonQuery() <= 0)
                {
                    throw new DataAccessException("Kh\x00f4ng thể tạo danh mục tin");
                }
                command.Dispose();
            }
        }

        public void DeleteCateProduct(int Id)
        {
            using (SqlConnection connection = base.GetConnection())
            {
                SqlCommand command = new SqlCommand("_CateProductDelete", connection) {
                    CommandType = CommandType.StoredProcedure
                };
                command.Parameters.AddWithValue("@CateProductID", Id);
                connection.Open();
                if (command.ExecuteNonQuery() <= 0)
                {
                    throw new DataAccessException("Kh\x00f4ng thể x\x00f3a danh mục tin");
                }
                command.Dispose();
            }
        }

        public DataTable GetCateParentProduct(string lang)
        {
            DataTable table = new DataTable();
            using (SqlConnection connection = base.GetConnection())
            {
                SqlCommand command = new SqlCommand("_CateProductGet", connection) {
                    CommandType = CommandType.StoredProcedure
                };
                command.Parameters.AddWithValue("@CateProductID", 0);
                command.Parameters.AddWithValue("@Language", lang);
                connection.Open();
                using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                {
                    adapter.Fill(table);
                    command.Dispose();
                }
            }
            return table;
        }

        public DataTable GetCateParentProductMain(string lang)
        {
            DataTable table = new DataTable();
            using (SqlConnection connection = base.GetConnection())
            {
                SqlCommand command = new SqlCommand("_CateProductGetMain", connection) {
                    CommandType = CommandType.StoredProcedure
                };
                command.Parameters.AddWithValue("@CateProductID", 0);
                command.Parameters.AddWithValue("@Language", lang);
                connection.Open();
                using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                {
                    adapter.Fill(table);
                    command.Dispose();
                }
            }
            return table;
        }

        public DataTable GetCateProduct(string lang)
        {
            DataTable datatable = new DataTable();
            datatable.Columns.Add("CateProductID");
            datatable.Columns.Add("ParentProductID");
            datatable.Columns.Add("CateProductName");
            datatable.Columns.Add("CateProductTotal");
            datatable.Columns.Add("CateProductOrder");
            datatable.Columns.Add("Language");
            DataTable table = new DataTable();
            using (SqlConnection connection = base.GetConnection())
            {
                SqlCommand command = new SqlCommand("_CateProductGet", connection) {
                    CommandType = CommandType.StoredProcedure
                };
                command.Parameters.AddWithValue("@CateProductID", 0);
                command.Parameters.AddWithValue("@Language", lang);
                connection.Open();
                using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                {
                    adapter.Fill(table);
                    command.Dispose();
                }
            }
            if (table.Rows.Count > 0)
            {
                foreach (DataRow row in table.Rows)
                {
                    DataRow datarow = datatable.NewRow();
                    datarow["CateProductID"] = row["CateProductID"].ToString();
                    datarow["ParentProductID"] = row["ParentProductID"].ToString();
                    datarow["CateProductName"] = row["CateProductName"].ToString();
                    datarow["CateProductTotal"] = row["CateProductTotal"].ToString();
                    datarow["CateProductOrder"] = row["CateProductOrder"].ToString();
                    datarow["Language"] = row["Language"].ToString();
                    datatable.Rows.Add(datarow);
                    this.GetParentProduct(datatable, Convert.ToInt32(datarow["CateProductID"]), lang, 1, "&nbsp;&nbsp;");
                }
            }
            return datatable;
        }

        public CateProduct GetCateProductById(int cId)
        {
            CateProduct cateProduct = null;
            using (SqlConnection connection = base.GetConnection())
            {
                SqlCommand command = new SqlCommand("_CateProductById", connection) {
                    CommandType = CommandType.StoredProcedure
                };
                command.Parameters.AddWithValue("@CateProductID", cId);
                connection.Open();
                using (SqlDataReader reader = command.ExecuteReader(CommandBehavior.CloseConnection))
                {
                    if (!reader.Read())
                    {
                        throw new DataAccessException("Kh\x00f4ng t\x00ecm thấy danh mục");
                    }
                    cateProduct = this.CateProductReader(reader);
                    command.Dispose();
                }
            }
            return cateProduct;
        }

        public DataTable GetCateProductParentAll(int Id, string lang)
        {
            DataTable table = new DataTable();
            using (SqlConnection connection = base.GetConnection())
            {
                SqlCommand command = new SqlCommand("_CateProductGet", connection) {
                    CommandType = CommandType.StoredProcedure
                };
                command.Parameters.AddWithValue("@CateProductID", Id);
                command.Parameters.AddWithValue("@Language", lang);
                connection.Open();
                using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                {
                    adapter.Fill(table);
                    command.Dispose();
                }
            }
            return table;
        }

        private void GetParentProduct(DataTable table, int cID, string language, int level, string sSpace)
        {
            string sStr = "";
            if (level > 0)
            {
                sSpace = HttpUtility.HtmlDecode(sSpace);
                for (int m = 0; m < level; m++)
                {
                    sStr = sStr + sSpace;
                }
            }
            DataTable subtable = new DataTable();
            using (SqlConnection connection = base.GetConnection())
            {
                SqlCommand command = new SqlCommand("_CateProductGet", connection) {
                    CommandType = CommandType.StoredProcedure
                };
                command.Parameters.AddWithValue("@CateProductID", cID);
                command.Parameters.AddWithValue("@Language", language);
                connection.Open();
                using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                {
                    adapter.Fill(subtable);
                    command.Dispose();
                }
                if (subtable.Rows.Count > 0)
                {
                    foreach (DataRow subrow in subtable.Rows)
                    {
                        DataRow rs = table.NewRow();
                        rs["CateProductID"] = subrow["CateProductID"].ToString();
                        rs["ParentProductID"] = subrow["ParentProductID"].ToString();
                        rs["CateProductName"] = sStr + subrow["CateProductName"].ToString();
                        rs["CateProductTotal"] = subrow["CateProductTotal"].ToString();
                        rs["CateProductOrder"] = subrow["CateProductOrder"].ToString();
                        rs["Language"] = subrow["Language"].ToString();
                        table.Rows.Add(rs);
                        this.GetParentProduct(table, Convert.ToInt32(rs["CateProductID"]), language, level + 1, "&nbsp;&nbsp;");
                    }
                }
            }
        }

        public void UpdateCateProduct(CateProduct cateProduct)
        {
            using (SqlConnection connection = base.GetConnection())
            {
                SqlCommand command = new SqlCommand("_CateProductUpdate", connection) {
                    CommandType = CommandType.StoredProcedure
                };
                command.Parameters.AddWithValue("@Type", 1);
                command.Parameters.AddWithValue("@CateProductID", cateProduct.CateProductID);
                command.Parameters.AddWithValue("@ParentProductID", cateProduct.ParentProductID);
                command.Parameters.AddWithValue("@CateProductName", cateProduct.CateProductName);
                command.Parameters.AddWithValue("@CateProductTotal", cateProduct.CateProductTotal);
                command.Parameters.AddWithValue("@CateProductOrder", cateProduct.CateProductOrder);
                command.Parameters.AddWithValue("@Language", cateProduct.Language);
                command.Parameters.AddWithValue("@Icon", cateProduct.Icon);
                command.Parameters.AddWithValue("@Slogan", cateProduct.Slogan);
                connection.Open();
                if (command.ExecuteNonQuery() <= 0)
                {
                    throw new DataAccessException("Kh\x00f4ng thể cập nhật danh mục tin");
                }
                command.Dispose();
            }
        }
    }
}

