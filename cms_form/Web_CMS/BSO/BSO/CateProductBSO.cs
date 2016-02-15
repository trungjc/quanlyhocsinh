namespace BSO
{
    using DAO;
    using ETO;
    using System;
    using System.Data;
    using System.Data.SqlClient;
    using System.Web;
    using System.Web.UI.WebControls;

    public class CateProductBSO
    {
        public void CateNavigator(ref string cate_navigator, int cateId, string url)
        {
            try
            {
                CateProduct cateproduct = this.GetCateProductById(cateId);
                if (!string.IsNullOrEmpty(cate_navigator))
                {
                    cate_navigator = " &raquo; " + cate_navigator;
                }
                cate_navigator = string.Concat(new object[] { "<a href='", url, cateId, "'>", cateproduct.CateProductName, "</a>", cate_navigator });
                if (cateproduct.ParentProductID != 0)
                {
                    this.CateNavigator(ref cate_navigator, cateproduct.CateProductID, url);
                }
            }
            catch (Exception ex)
            {
                throw new BusinessException(ex.Message.ToString());
            }
        }

        public void CateProductUpOrder(int cId, int cOrder)
        {
            new CateProductDAO().CateProductUpOrder(cId, cOrder);
        }

        public void CreateCateNew(CateProduct cateProduct)
        {
            new CateProductDAO().CreateCateProduct(cateProduct);
        }

        public void DeleteCateProduct(int icCate, string lang)
        {
            try
            {
                DataTable table = this.GetCateProduct(lang);
                for (int m = 0; m < table.Rows.Count; m++)
                {
                    int pParent = Convert.ToInt32(table.Rows[m]["ParentProductID"]);
                    int cCate = Convert.ToInt32(table.Rows[m]["CateProductID"]);
                    if (icCate == pParent)
                    {
                        this.DeleteCateProduct(cCate, lang);
                    }
                }
                new CateProductDAO().DeleteCateProduct(icCate);
            }
            catch (Exception ex)
            {
                throw new BusinessException(ex.Message.ToString());
            }
        }

        public bool ExistName(string catename)
        {
            bool ExistName;
            BaseDAO baseDAO = new BaseDAO();
            using (SqlConnection connection = baseDAO.GetConnection())
            {
                SqlCommand command = new SqlCommand("_CateProductCheck", connection) {
                    CommandType = CommandType.StoredProcedure
                };
                command.Parameters.AddWithValue("@CateProductID", 0);
                command.Parameters.AddWithValue("@CateProductName", catename);
                connection.Open();
                using (SqlDataReader reader = command.ExecuteReader(CommandBehavior.CloseConnection))
                {
                    ExistName = reader.HasRows;
                }
            }
            return ExistName;
        }

        public DataTable GetCateParentProduct(string lang)
        {
            CateProductDAO cateProductDAO = new CateProductDAO();
            return cateProductDAO.GetCateParentProduct(lang);
        }

        public DataTable GetCateParentProductMain(string lang)
        {
            CateProductDAO cateProductDAO = new CateProductDAO();
            return cateProductDAO.GetCateParentProductMain(lang);
        }

        public DataTable GetCateProduct(string lang)
        {
            CateProductDAO cateProductDAO = new CateProductDAO();
            return cateProductDAO.GetCateProduct(lang);
        }

        public CateProduct GetCateProductById(int cId)
        {
            CateProductDAO cateProductDAO = new CateProductDAO();
            return cateProductDAO.GetCateProductById(cId);
        }

        public DataTable getCateProductClient(int iCate, string lang)
        {
            DataTable table = new DataTable();
            BaseDAO baseDAO = new BaseDAO();
            using (SqlConnection connection = baseDAO.GetConnection())
            {
                SqlCommand command = new SqlCommand("_CateProductGetClient", connection) {
                    CommandType = CommandType.StoredProcedure
                };
                command.Parameters.AddWithValue("@CateProductID", iCate);
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

        public DataTable getCateProductLevel(int iCate, string lang)
        {
            DataTable table = new DataTable();
            BaseDAO baseDAO = new BaseDAO();
            using (SqlConnection connection = baseDAO.GetConnection())
            {
                SqlCommand command = new SqlCommand("_CateProductGet", connection) {
                    CommandType = CommandType.StoredProcedure
                };
                command.Parameters.AddWithValue("@CateProductID", iCate);
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

        public DataTable GetCateProductParentAll(int Id, string lang)
        {
            CateProductDAO cateProductDAO = new CateProductDAO();
            return cateProductDAO.GetCateProductParentAll(Id, lang);
        }

        private void GetSubCategory(MenuItem _parentNote, int iCate_ID, string language, string sSpace)
        {
            string str = HttpUtility.HtmlDecode("&nbsp;&nbsp;&nbsp;&nbsp;");
            sSpace = sSpace + str;
            BaseDAO baseDAO = new BaseDAO();
            DataTable datatable = new DataTable();
            using (SqlConnection connection = baseDAO.GetConnection())
            {
                SqlCommand command = new SqlCommand("_CateProductGetClient", connection) {
                    CommandType = CommandType.StoredProcedure
                };
                command.Parameters.AddWithValue("@CateProductID", iCate_ID);
                command.Parameters.AddWithValue("@Language", language);
                connection.Open();
                using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                {
                    adapter.Fill(datatable);
                    command.Dispose();
                }
            }
            if (datatable.Rows.Count > 0)
            {
                foreach (DataRow row in datatable.Rows)
                {
                    string Name = row["CateProductName"].ToString();
                    if (Name.Contains("-"))
                    {
                        Name = Name.Replace("&nbsp;", "").Replace("-", "");
                        Name = "<b>" + Name + "</b>";
                    }
                    else
                    {
                        Name = sSpace + row["CateProductName"].ToString();
                    }
                    MenuItem _childNote = new MenuItem(Name) {
                        NavigateUrl = "~/Default.aspx?go=list&id=" + row["CateProductID"].ToString()
                    };
                    _parentNote.ChildItems.Add(_childNote);
                    this.GetSubCategory(_childNote, Convert.ToInt32(row["CateProductID"].ToString()), language, "");
                }
            }
        }

        public void MenuProduct(Menu menu, int iCate, string lang)
        {
            DataTable table = new DataTable();
            BaseDAO baseDAO = new BaseDAO();
            using (SqlConnection connection = baseDAO.GetConnection())
            {
                SqlCommand command = new SqlCommand("_CateProductGetClient", connection) {
                    CommandType = CommandType.StoredProcedure
                };
                command.Parameters.AddWithValue("@CateProductID", iCate);
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
                    MenuItem menuitem = new MenuItem(row["CateProductName"].ToString()) {
                        NavigateUrl = "~/Default.aspx?go=list&id=" + row["CateProductID"].ToString()
                    };
                    this.GetSubCategory(menuitem, Convert.ToInt32(row["CateProductID"].ToString()), lang, "");
                    menu.Items.Add(menuitem);
                }
            }
        }

        public void UpdateCateProduct(CateProduct cateProduct)
        {
            new CateProductDAO().UpdateCateProduct(cateProduct);
        }
    }
}

