namespace BSO
{
    using DAO;
    using ETO;
    using System;
    using System.Data;
    using System.Data.SqlClient;

    public class PagesBSO
    {
        public void DeletePages(int Id)
        {
            new PagesDAO().DeletePages(Id);
        }

        public void DeletePages(string strId)
        {
            string restr = strId.Remove(strId.LastIndexOf(",")).Replace(",", "','");
            new PagesDAO().DeletePages(restr);
        }

        public DataTable GetAllPages(string lang)
        {
            PagesDAO pagesDAO = new PagesDAO();
            return pagesDAO.GetAllPages(lang);
        }

        public Pages GetPagesById(int Id)
        {
            PagesDAO pagesDAO = new PagesDAO();
            return pagesDAO.GetPagesById(Id);
        }

        public DataTable GetPagesByName(string pagename)
        {
            PagesDAO pagesDAO = new PagesDAO();
            return pagesDAO.GetPagesByName(pagename);
        }

        public DataTable GetPagesCate(string lang)
        {
            PagesDAO pagesDAO = new PagesDAO();
            return pagesDAO.GetPagesCate(lang);
        }

        public Pages GetPagesGroupTop1(int Group, string lang)
        {
            PagesDAO pagesDAO = new PagesDAO();
            return pagesDAO.GetPagesGroupTop1(Group, lang);
        }

        public void PageCreate(Pages pages)
        {
            new PagesDAO().PagesCreate(pages);
        }

        public DataTable PageFollow(int Id, string cId)
        {
            PagesDAO pagesDAO = new PagesDAO();
            return pagesDAO.PageFollow(Id, cId);
        }

        public DataTable PageFollow(int Id, string cId, int n)
        {
            PagesDAO pagesDAO = new PagesDAO();
            return pagesDAO.PageFollow(Id, cId, n);
        }

        public DataTable PageGetGroup(string group, string lang)
        {
            DataTable datatable = new DataTable();
            BaseDAO baseDAO = new BaseDAO();
            using (SqlConnection connection = baseDAO.GetConnection())
            {
                SqlCommand command = new SqlCommand("_PageGetGroup", connection) {
                    CommandType = CommandType.StoredProcedure
                };
                command.Parameters.AddWithValue("@Group", group);
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

        public DataTable PageGetGroupArticle(int group, string lang)
        {
            DataTable datatable = new DataTable();
            BaseDAO baseDAO = new BaseDAO();
            using (SqlConnection connection = baseDAO.GetConnection())
            {
                SqlCommand command = new SqlCommand("_PageGetGroupArticle", connection) {
                    CommandType = CommandType.StoredProcedure
                };
                command.Parameters.AddWithValue("@Group", group);
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

        public DataTable PageGetGroupArticle1(int group, string lang)
        {
            DataTable datatable = new DataTable();
            BaseDAO baseDAO = new BaseDAO();
            using (SqlConnection connection = baseDAO.GetConnection())
            {
                SqlCommand command = new SqlCommand("_PageGetGroupArticle1", connection) {
                    CommandType = CommandType.StoredProcedure
                };
                command.Parameters.AddWithValue("@Group", group);
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

        public DataTable PageGetGroupArticleHome(int group, string lang)
        {
            DataTable datatable = new DataTable();
            BaseDAO baseDAO = new BaseDAO();
            using (SqlConnection connection = baseDAO.GetConnection())
            {
                SqlCommand command = new SqlCommand("_PageGetGroupArticleHome", connection) {
                    CommandType = CommandType.StoredProcedure
                };
                command.Parameters.AddWithValue("@Group", group);
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

        public DataTable PageGetGroupArticleHome(int group, string lang, int num)
        {
            DataTable datatable = new DataTable();
            BaseDAO baseDAO = new BaseDAO();
            using (SqlConnection connection = baseDAO.GetConnection())
            {
                string SQL = string.Concat(new object[] { "select top ", Convert.ToString(num), " * from tblPage where icon=", group, " and Language='", lang, "' and Isview = 1 order by PageID Desc" });
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

        public DataTable PageGetGroupArticleHome(int group, string lang, int num, string approval)
        {
            DataTable datatable = new DataTable();
            BaseDAO baseDAO = new BaseDAO();
            using (SqlConnection connection = baseDAO.GetConnection())
            {
                string SQL = string.Concat(new object[] { "select top ", Convert.ToString(num), " * from tblPage where icon=", group, " and Language='", lang, "' and Isview = 1 and isapproval =", approval, " order by PageID Desc" });
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

        public DataTable PagesFull(string lang)
        {
            DataTable datatable = new DataTable();
            BaseDAO baseDAO = new BaseDAO();
            using (SqlConnection connection = baseDAO.GetConnection())
            {
                SqlCommand command = new SqlCommand("_PageFull", connection) {
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

        public DataTable PagesSearch(string keyword, string lang)
        {
            PagesDAO pagesDAO = new PagesDAO();
            return pagesDAO.PagesSearch(keyword, lang);
        }

        public DataTable PagesSearch(string keyword, string CateID, string lang)
        {
            PagesDAO pagesDAO = new PagesDAO();
            return pagesDAO.PagesSearch(keyword, CateID, lang);
        }

        public DataTable PagesSearchCate(string CateID, string lang)
        {
            PagesDAO pagesDAO = new PagesDAO();
            return pagesDAO.PagesSearchCate(CateID, lang);
        }

        public void PagesUpdate(Pages pages)
        {
            new PagesDAO().PagesUpdate(pages);
        }

        public void PagesUpdate(string strId, string value)
        {
            string restr = strId.Remove(strId.LastIndexOf(",")).Replace(",", "','");
            new PagesDAO().PagesUpdate(restr, value);
        }

        public void PagesUpdate(int Id, string value, string username, DateTime date)
        {
            new PagesDAO().PagesUpdate(Id, value, username, date);
        }

        public void PagesUpdate(string strId, string value, string username, DateTime date)
        {
            string restr = strId.Remove(strId.LastIndexOf(",")).Replace(",", "','");
            new PagesDAO().PagesUpdate(restr, value, username, date);
        }
    }
}

