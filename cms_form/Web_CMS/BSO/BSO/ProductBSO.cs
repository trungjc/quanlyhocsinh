namespace BSO
{
    using DAO;
    using ETO;
    using System;
    using System.Data;
    using System.Data.SqlClient;

    public class ProductBSO
    {
        public int CreateProduct(Product product)
        {
            ProductDAO productDAO = new ProductDAO();
            return productDAO.CreateProduct(product);
        }

        public void DeleteProduct(int pId)
        {
            new ProductDAO().DeleteProduct(pId);
        }

        public DataTable GetProduct10(string lang)
        {
            ProductDAO productDAO = new ProductDAO();
            return productDAO.GetProduct10(lang);
        }

        public DataTable GetProductAll(string lang)
        {
            ProductDAO productDAO = new ProductDAO();
            return productDAO.GetProductAll(lang);
        }

        public DataTable GetProductByCate(int cId)
        {
            ProductDAO productDAO = new ProductDAO();
            return productDAO.GetProductByCate(cId);
        }

        public DataTable GetProductByCateAll(string strCate)
        {
            string restr = strCate.Remove(strCate.LastIndexOf(",")).Replace(",", "','");
            ProductDAO productDAO = new ProductDAO();
            return productDAO.GetProductByCateAll(restr);
        }

        public DataTable GetProductByCateHome(int cId)
        {
            ProductDAO productDAO = new ProductDAO();
            return productDAO.GetProductByCateHome(cId);
        }

        public DataTable GetProductByCateHomeAll(string strCate)
        {
            string restr = strCate.Remove(strCate.LastIndexOf(",")).Replace(",", "','");
            ProductDAO productDAO = new ProductDAO();
            return productDAO.GetProductByCateHomeAll(restr);
        }

        public DataTable GetProductByCateHomeAll(int n, string strCate)
        {
            string restr = strCate.Remove(strCate.LastIndexOf(",")).Replace(",", "','");
            ProductDAO productDAO = new ProductDAO();
            return productDAO.GetProductByCateHomeAll(n, restr);
        }

        public DataTable GetProductByCateHomeList(string strCate, int num)
        {
            string restr = strCate.Remove(strCate.LastIndexOf(",")).Replace(",", "','");
            ProductDAO productDAO = new ProductDAO();
            return productDAO.GetProductByCateHomeList(restr, num);
        }

        public Product GetProductById(int Id)
        {
            ProductDAO productDAO = new ProductDAO();
            return productDAO.GetProductById(Id);
        }

        public DataTable GetProductByInStrId(string str)
        {
            ProductDAO productDAO = new ProductDAO();
            return productDAO.GetProductByInStrId(str);
        }

        public DataTable GetProductHot(string lang)
        {
            ProductDAO productDAO = new ProductDAO();
            return productDAO.GetProductHot(lang);
        }

        public DataTable ProductIsHome(string lang)
        {
            DataTable datatable = new DataTable();
            BaseDAO baseDAO = new BaseDAO();
            using (SqlConnection connection = baseDAO.GetConnection())
            {
                SqlCommand command = new SqlCommand("_ProductIsHome", connection) {
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

        public DataTable ProductIsHome18(string lang)
        {
            DataTable datatable = new DataTable();
            BaseDAO baseDAO = new BaseDAO();
            using (SqlConnection connection = baseDAO.GetConnection())
            {
                SqlCommand command = new SqlCommand("_ProductIsHome18", connection) {
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

        public DataTable ProductIsHome6(string lang)
        {
            DataTable datatable = new DataTable();
            BaseDAO baseDAO = new BaseDAO();
            using (SqlConnection connection = baseDAO.GetConnection())
            {
                SqlCommand command = new SqlCommand("_ProductIsHome6", connection) {
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

        public DataTable ProductIsHomeHot(string lang)
        {
            DataTable datatable = new DataTable();
            BaseDAO baseDAO = new BaseDAO();
            using (SqlConnection connection = baseDAO.GetConnection())
            {
                SqlCommand command = new SqlCommand("_ProductIsHomeHot", connection) {
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

        public DataTable ProductSearch(string keyword, int cId, string lang)
        {
            ProductDAO productDAO = new ProductDAO();
            return productDAO.ProductSearch(keyword, cId, lang);
        }

        public DataTable ProductSearchCate(int cId, string lang)
        {
            ProductDAO productDAO = new ProductDAO();
            return productDAO.ProductSearchCate(cId, lang);
        }

        public void UpdateProduct(Product product)
        {
            new ProductDAO().UpdateProduct(product);
        }

        public void UpdateProduct(string strId, string value)
        {
            string restr = strId.Remove(strId.LastIndexOf(",")).Replace(",", "','");
            new ProductDAO().UpdateProduct(restr, value);
        }
    }
}

