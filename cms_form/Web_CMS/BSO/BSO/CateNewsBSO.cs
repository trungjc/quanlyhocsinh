namespace BSO
{
    using DAO;
    using ETO;
    using System;
    using System.Data;
    using System.Data.SqlClient;
    using System.Text;
    using System.Text.RegularExpressions;
    using System.Web;
    using System.Web.UI.WebControls;
    using Telerik.Web.UI;

    public class CateNewsBSO
    {
        public void CateNavigator(ref string cate_navigator, int cateId, string url)
        {
            try
            {
                CateNews catenews = this.GetCateNewsById(cateId);
                if (!string.IsNullOrEmpty(cate_navigator))
                {
                    cate_navigator = " &raquo; " + cate_navigator;
                }
                cate_navigator = string.Concat(new object[] { "<a href='", url, cateId, "'>", catenews.CateNewsName, "</a>", cate_navigator });
                if (catenews.ParentNewsID != 0)
                {
                    this.CateNavigator(ref cate_navigator, catenews.ParentNewsID, url);
                }
            }
            catch (Exception ex)
            {
                throw new BusinessException(ex.Message.ToString());
            }
        }

        public void CateNewsUpOrder(int cId, int cOrder)
        {
            new CateNewsDAO().CateNewsUpOrder(cId, cOrder);
        }

        private bool CheckParent(int cate, int group, string Language)
        {
            bool check = false;
            try
            {
                if (this.getCateClientGroupUrl(cate, Language, group).Rows.Count > 0)
                {
                    check = true;
                }
            }
            catch (Exception)
            {
            }
            return check;
        }

        public void CreateCateNew(CateNews catenews)
        {
            new CateNewsDAO().CreateCateNews(catenews);
        }

        public int CreateCateNewGet(CateNews catenews)
        {
            CateNewsDAO catenewsDAO = new CateNewsDAO();
            return catenewsDAO.CreateCateNewsGet(catenews);
        }

        public void DeleteCateNewsAll(int cateID, string lang)
        {
            try
            {
                DataTable table = this.GetCateNews(lang);
                for (int m = 0; m < table.Rows.Count; m++)
                {
                    int pParent = Convert.ToInt32(table.Rows[m]["ParentNewsID"]);
                    int cCate = Convert.ToInt32(table.Rows[m]["CateNewsID"]);
                    if (cateID == pParent)
                    {
                        this.DeleteCateNewsAll(cCate, lang);
                    }
                }
                new CateNewsDAO().DeleteCateNews(cateID);
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
                SqlCommand command = new SqlCommand("_CateNewsCheck", connection) {
                    CommandType = CommandType.StoredProcedure
                };
                command.Parameters.AddWithValue("@CateNewsName", catename);
                connection.Open();
                using (SqlDataReader reader = command.ExecuteReader(CommandBehavior.CloseConnection))
                {
                    ExistName = reader.HasRows;
                }
            }
            return ExistName;
        }

        public DataTable getCateClientGroup(int iCate, string lang, int group)
        {
            BaseDAO baseDAO = new BaseDAO();
            DataTable table = new DataTable();
            using (SqlConnection connection = baseDAO.GetConnection())
            {
                SqlCommand command = new SqlCommand("_CateNewsGetClient", connection) {
                    CommandType = CommandType.StoredProcedure
                };
                command.Parameters.AddWithValue("@CateNewsID", iCate);
                command.Parameters.AddWithValue("@Language", lang);
                command.Parameters.AddWithValue("@GroupCate", group);
                connection.Open();
                using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                {
                    adapter.Fill(table);
                    command.Dispose();
                }
            }
            return table;
        }

        public DataTable getCateClientGroup(int iCate, string lang, int group, int n)
        {
            BaseDAO baseDAO = new BaseDAO();
            DataTable table = new DataTable();
            using (SqlConnection connection = baseDAO.GetConnection())
            {
                string SQL = "select top " + n + " * from tblCateNews where ParentNewsID = @CateNewsID and Language = @Language and GroupCate = @GroupCate AND [IsUrl] = 0 order by CateNewsOrder ASC";
                SqlCommand command = new SqlCommand(SQL, connection) {
                    CommandText = SQL
                };
                command.Parameters.AddWithValue("@CateNewsID", iCate);
                command.Parameters.AddWithValue("@Language", lang);
                command.Parameters.AddWithValue("@GroupCate", group);
                connection.Open();
                using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                {
                    adapter.Fill(table);
                    command.Dispose();
                }
            }
            return table;
        }

        public DataTable getCateClientGroupUrl(int iCate, string lang, int group)
        {
            BaseDAO baseDAO = new BaseDAO();
            DataTable table = new DataTable();
            using (SqlConnection connection = baseDAO.GetConnection())
            {
                SqlCommand command = new SqlCommand("_CateNewsGetClientUrl", connection) {
                    CommandType = CommandType.StoredProcedure
                };
                command.Parameters.AddWithValue("@CateNewsID", iCate);
                command.Parameters.AddWithValue("@Language", lang);
                command.Parameters.AddWithValue("@GroupCate", group);
                connection.Open();
                using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                {
                    adapter.Fill(table);
                    command.Dispose();
                }
            }
            return table;
        }

        public DataTable getCateClientGroupUrl(int iCate, string lang, int group, int n)
        {
            BaseDAO baseDAO = new BaseDAO();
            DataTable table = new DataTable();
            using (SqlConnection connection = baseDAO.GetConnection())
            {
                string SQL = "select top " + n + " * from tblCateNews where ParentNewsID = @CateNewsID and Language = @Language and GroupCate = @GroupCate order by CateNewsOrder ASC";
                SqlCommand command = new SqlCommand(SQL, connection) {
                    CommandText = SQL
                };
                command.Parameters.AddWithValue("@CateNewsID", iCate);
                command.Parameters.AddWithValue("@Language", lang);
                command.Parameters.AddWithValue("@GroupCate", group);
                connection.Open();
                using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                {
                    adapter.Fill(table);
                    command.Dispose();
                }
            }
            return table;
        }

        public DataTable getCateCompanyClient(int iCate, string lang)
        {
            BaseDAO baseDAO = new BaseDAO();
            DataTable table = new DataTable();
            using (SqlConnection connection = baseDAO.GetConnection())
            {
                SqlCommand command = new SqlCommand("_CateNewsGetClient", connection) {
                    CommandType = CommandType.StoredProcedure
                };
                command.Parameters.AddWithValue("@CateNewsID", iCate);
                command.Parameters.AddWithValue("@Language", lang);
                command.Parameters.AddWithValue("@GroupCate", 0);
                connection.Open();
                using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                {
                    adapter.Fill(table);
                    command.Dispose();
                }
            }
            return table;
        }

        public DataTable GetCateCompanyParentAll(int Id, string lang)
        {
            CateNewsDAO cateNewsDAO = new CateNewsDAO();
            return cateNewsDAO.GetCateCompanyParentAll(Id, lang);
        }

        public DataTable GetCateGroup(string lang, int group)
        {
            CateNewsDAO catenewsDAO = new CateNewsDAO();
            return catenewsDAO.GetCateGroup(lang, group);
        }

        public DataTable GetCateGroupBullet(string lang, int group, string bullet)
        {
            CateNewsDAO catenewsDAO = new CateNewsDAO();
            return catenewsDAO.GetCateGroupBullet(lang, group, bullet);
        }

        public DataTable GetCateGroupRoles(string lang, int group, string username)
        {
            CateNewsDAO catenewsDAO = new CateNewsDAO();
            return catenewsDAO.GetCateGroupRoles(lang, group, username);
        }

        public DataTable GetCateGroupRolesUrl(string lang, int group, string username)
        {
            CateNewsDAO catenewsDAO = new CateNewsDAO();
            return catenewsDAO.GetCateGroupRolesUrl(lang, group, username);
        }

        public DataTable GetCateNews(string lang)
        {
            CateNewsDAO catenewsDAO = new CateNewsDAO();
            return catenewsDAO.GetCateNews(lang);
        }

        public CateNews GetCateNewsById(int cId)
        {
            CateNewsDAO catenewsDAO = new CateNewsDAO();
            return catenewsDAO.GetCateNewsById(cId);
        }

        public DataTable getCateNewsClient(int iCate, string lang)
        {
            BaseDAO baseDAO = new BaseDAO();
            DataTable table = new DataTable();
            using (SqlConnection connection = baseDAO.GetConnection())
            {
                SqlCommand command = new SqlCommand("_CateNewsGetClient", connection) {
                    CommandType = CommandType.StoredProcedure
                };
                command.Parameters.AddWithValue("@CateNewsID", iCate);
                command.Parameters.AddWithValue("@Language", lang);
                command.Parameters.AddWithValue("@GroupCate", 1);
                connection.Open();
                using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                {
                    adapter.Fill(table);
                    command.Dispose();
                }
            }
            return table;
        }

        public DataTable getCateNewsLevel(int iCate, string lang)
        {
            DataTable table = new DataTable();
            BaseDAO baseDAO = new BaseDAO();
            using (SqlConnection connection = baseDAO.GetConnection())
            {
                SqlCommand command = new SqlCommand("_CateNewsGet", connection) {
                    CommandType = CommandType.StoredProcedure
                };
                command.Parameters.AddWithValue("@CateNewsID", iCate);
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

        public DataTable GetCateNewsName(string lang)
        {
            CateNewsDAO catenewsDAO = new CateNewsDAO();
            return catenewsDAO.GetCateNewsName(lang);
        }

        public DataTable GetCateNewsName(string lang, string username)
        {
            CateNewsDAO catenewsDAO = new CateNewsDAO();
            return catenewsDAO.GetCateNewsName(lang, username);
        }

        public DataTable GetCateNewsParentAll(int Id, string lang)
        {
            CateNewsDAO cateNewsDAO = new CateNewsDAO();
            return cateNewsDAO.GetCateNewsParentAll(Id, lang);
        }

        public DataTable GetCateParentGroupAll(int Id, string lang, int group)
        {
            CateNewsDAO cateNewsDAO = new CateNewsDAO();
            return cateNewsDAO.GetCateParentGroupAll(Id, lang, group);
        }

        public DataTable GetCateParentGroupRolesAll(int Id, string lang, int group, string username)
        {
            CateNewsDAO cateNewsDAO = new CateNewsDAO();
            return cateNewsDAO.GetCateParentGroupRolesAll(Id, lang, group, username);
        }

        public string Getstring(string _txt)
        {
            Regex v_reg_regex = new Regex(@"\p{IsCombiningDiacriticalMarks}+");
            string v_str_FormD = _txt.Normalize(NormalizationForm.FormD);
            return this.RemoveExtraSpaces(UCS2Convert(v_reg_regex.Replace(v_str_FormD, string.Empty).Replace('đ', 'd').Replace('Đ', 'D').Replace(" ", "-").Replace(":", "")));
        }

        private void GetSubCategoryRadCompany(RadMenuItem _parentNote, int iCate_ID, string lang, string sSpace)
        {
            string str = HttpUtility.HtmlDecode("&nbsp;&nbsp;");
            sSpace = sSpace + str;
            DataTable datatable = this.getCateCompanyClient(iCate_ID, lang);
            if (datatable.Rows.Count > 0)
            {
                foreach (DataRow row in datatable.Rows)
                {
                    string Name = row["CateNewsName"].ToString();
                    if (Name.Contains("-"))
                    {
                        Name = Name.Replace("&nbsp;", "").Replace("-", "");
                        Name = "<b>" + Name + "</b>";
                    }
                    else
                    {
                        Name = sSpace + row["CateNewsName"].ToString();
                    }
                    RadMenuItem _childNote = new RadMenuItem(Name) {
                        NavigateUrl = "~/Default.aspx?go=catecompany&id=" + row["CateNewsID"].ToString()
                    };
                    _parentNote.Items.Add(_childNote);
                    this.GetSubCategoryRadCompany(_childNote, Convert.ToInt32(row["CateNewsID"].ToString()), lang, "");
                }
            }
        }

        private void GetSubCategoryRadMenuCateGroup(RadMenuItem _parentNote, int iCate_ID, string lang, string sSpace, int group, string url)
        {
            string str = HttpUtility.HtmlDecode("&nbsp;&nbsp;");
            sSpace = sSpace + str;
            DataTable datatable = this.getCateClientGroup(iCate_ID, lang, group);
            if (datatable.Rows.Count > 0)
            {
                foreach (DataRow row in datatable.Rows)
                {
                    string Name = row["CateNewsName"].ToString();
                    if (Name.Contains("-"))
                    {
                        Name = Name.Replace("&nbsp;", "").Replace("-", "");
                        Name = "<b>" + Name + "</b>";
                    }
                    else
                    {
                        Name = sSpace + row["CateNewsName"].ToString();
                    }
                    RadMenuItem _childNote = new RadMenuItem(Name) {
                        NavigateUrl = url + row["CateNewsID"].ToString()
                    };
                    _parentNote.Items.Add(_childNote);
                    this.GetSubCategoryRadMenuCateGroup(_childNote, Convert.ToInt32(row["CateNewsID"].ToString()), lang, "", group, url);
                }
            }
        }

        private void GetSubCategoryRadMenuCateGroupUrl(RadMenuItem _parentNote, int iCate_ID, string lang, string sSpace, int group, string url)
        {
            string str = HttpUtility.HtmlDecode("&nbsp;&nbsp;");
            sSpace = sSpace + str;
            DataTable datatable = this.getCateClientGroupUrl(iCate_ID, lang, group);
            if (datatable.Rows.Count > 0)
            {
                foreach (DataRow row in datatable.Rows)
                {
                    string Name = row["CateNewsName"].ToString();
                    if (Name.Contains("-"))
                    {
                        Name = Name.Replace("&nbsp;", "").Replace("-", "");
                        Name = "<b>" + Name + "</b>";
                    }
                    else
                    {
                        Name = sSpace + row["CateNewsName"].ToString();
                    }
                    RadMenuItem _childNote = new RadMenuItem(Name);
                    if (Convert.ToBoolean(row["IsUrl"].ToString()))
                    {
                        _childNote.NavigateUrl = row["Url"].ToString();
                    }
                    else
                    {
                        _childNote.NavigateUrl = url + row["CateNewsID"].ToString();
                    }
                    _parentNote.Items.Add(_childNote);
                    this.GetSubCategoryRadMenuCateGroupUrl(_childNote, Convert.ToInt32(row["CateNewsID"].ToString()), lang, "", group, url);
                }
            }
        }

        private void GetSubCategoryRadMenuCateGroupUrl(RadMenuItem _parentNote, int iCate_ID, string lang, string sSpace, int group, string url1, string url2)
        {
            string str = HttpUtility.HtmlDecode("&nbsp;&nbsp;");
            sSpace = sSpace + str;
            DataTable datatable = this.getCateClientGroupUrl(iCate_ID, lang, group);
            if (datatable.Rows.Count > 0)
            {
                foreach (DataRow row in datatable.Rows)
                {
                    string Name = row["CateNewsName"].ToString();
                    RadMenuItem _childNote = new RadMenuItem(sSpace + row["CateNewsName"].ToString());
                    if (Convert.ToBoolean(row["IsUrl"].ToString()))
                    {
                        _childNote.NavigateUrl = row["Url"].ToString();
                    }
                    else
                    {
                        _childNote.NavigateUrl = url1 + row["CateNewsID"].ToString() + "/" + this.Getstring(row["CateNewsName"].ToString()) + url2;
                    }
                    _parentNote.Items.Add(_childNote);
                    this.GetSubCategoryRadMenuCateGroupUrl(_childNote, Convert.ToInt32(row["CateNewsID"].ToString()), lang, "", group, url1, url2);
                }
            }
        }

        private void GetSubCategoryRadNews(RadMenuItem _parentNote, int iCate_ID, string lang, string sSpace)
        {
            string str = HttpUtility.HtmlDecode("&nbsp;&nbsp;");
            sSpace = sSpace + str;
            DataTable datatable = this.getCateNewsClient(iCate_ID, lang);
            if (datatable.Rows.Count > 0)
            {
                foreach (DataRow row in datatable.Rows)
                {
                    string Name = row["CateNewsName"].ToString();
                    if (Name.Contains("-"))
                    {
                        Name = Name.Replace("&nbsp;", "").Replace("-", "");
                        Name = "<b>" + Name + "</b>";
                    }
                    else
                    {
                        Name = sSpace + row["CateNewsName"].ToString();
                    }
                    RadMenuItem _childNote = new RadMenuItem(Name) {
                        NavigateUrl = "~/Default.aspx?go=catenews&id=" + row["CateNewsID"].ToString()
                    };
                    _parentNote.Items.Add(_childNote);
                    this.GetSubCategoryRadNews(_childNote, Convert.ToInt32(row["CateNewsID"].ToString()), lang, "");
                }
            }
        }

        public void MenuCompany(Menu menu, int iParentID, string lang)
        {
            try
            {
                DataTable table = new DataTable();
                BaseDAO baseDAO = new BaseDAO();
                using (SqlConnection connection = baseDAO.GetConnection())
                {
                    SqlCommand command = new SqlCommand("_CateNewsGetClient", connection) {
                        CommandType = CommandType.StoredProcedure
                    };
                    command.Parameters.AddWithValue("@CateNewsID", iParentID);
                    command.Parameters.AddWithValue("@Language", lang);
                    command.Parameters.AddWithValue("@GroupCate", 0);
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
                        MenuItem menuitem = new MenuItem(row["CateNewsName"].ToString()) {
                            NavigateUrl = "~/Default.aspx?go=catecompany&id=" + row["CateNewsID"].ToString()
                        };
                        this.SubMenuCompany(menuitem, Convert.ToInt32(row["CateNewsID"]), lang);
                        menu.Items.Add(menuitem);
                    }
                }
            }
            catch (Exception ex)
            {
                throw new DataAccessException(ex.Message.ToString());
            }
        }

        public void MenuJqueryCateGroupUrl(StringBuilder menubar, int cateID, string lang, string sSpace, int group, string url)
        {
            string str = HttpUtility.HtmlDecode("&nbsp;&nbsp;");
            sSpace = sSpace + str;
            DataTable datatable = this.getCateClientGroupUrl(cateID, lang, group);
            if (cateID == 0)
            {
                menubar.Append("<ul class='menu'>");
            }
            else
            {
                menubar.Append("<ul>");
            }
            if (datatable.Rows.Count > 0)
            {
                foreach (DataRow row in datatable.Rows)
                {
                    menubar.Append(" <li><a href='");
                    if (Convert.ToBoolean(row["IsUrl"].ToString()))
                    {
                        menubar.Append(row["Url"].ToString());
                    }
                    else
                    {
                        menubar.Append(url + row["CateNewsID"].ToString());
                    }
                    if (this.CheckParent(Convert.ToInt32(row["CateNewsID"].ToString()), Convert.ToInt32(row["GroupCate"].ToString()), lang))
                    {
                        menubar.Append("' class='parent'><span>");
                    }
                    else
                    {
                        menubar.Append("'><span>");
                    }
                    string Name = row["CateNewsName"].ToString();
                    Name = sSpace + row["CateNewsName"].ToString();
                    menubar.Append(Name);
                    menubar.Append("</span></a>");
                    if (this.CheckParent(Convert.ToInt32(row["CateNewsID"].ToString()), Convert.ToInt32(row["GroupCate"].ToString()), lang))
                    {
                        this.MenuJqueryCateGroupUrl(menubar, Convert.ToInt32(row["CateNewsID"].ToString()), lang, "", Convert.ToInt32(row["GroupCate"].ToString()), url);
                    }
                    menubar.Append("</li>");
                }
                menubar.Append("</ul>");
            }
        }

        public void MenuJqueryCateGroupUrl(StringBuilder menubar, int cateID, string lang, string sSpace, int group, string url1, string url2)
        {
            string str = HttpUtility.HtmlDecode("&nbsp;&nbsp;");
            sSpace = sSpace + str;
            DataTable datatable = this.getCateClientGroupUrl(cateID, lang, group);
            if (cateID == 0)
            {
                menubar.Append("<ul class='menu'>");
            }
            else
            {
                menubar.Append("<ul>");
            }
            if (datatable.Rows.Count > 0)
            {
                foreach (DataRow row in datatable.Rows)
                {
                    menubar.Append(" <li><a href='");
                    if (Convert.ToBoolean(row["IsUrl"].ToString()))
                    {
                        menubar.Append(row["Url"].ToString());
                    }
                    else
                    {
                        menubar.Append(url1 + row["CateNewsID"].ToString() + "/" + this.Getstring(row["CateNewsName"].ToString()) + url2);
                    }
                    if (this.CheckParent(Convert.ToInt32(row["CateNewsID"].ToString()), Convert.ToInt32(row["GroupCate"].ToString()), lang))
                    {
                        menubar.Append("' class='parent'><span>");
                    }
                    else
                    {
                        menubar.Append("'><span>");
                    }
                    string Name = row["CateNewsName"].ToString();
                    Name = sSpace + row["CateNewsName"].ToString();
                    menubar.Append(Name);
                    menubar.Append("</span></a>");
                    if (this.CheckParent(Convert.ToInt32(row["CateNewsID"].ToString()), Convert.ToInt32(row["GroupCate"].ToString()), lang))
                    {
                        this.MenuJqueryCateGroupUrl(menubar, Convert.ToInt32(row["CateNewsID"].ToString()), lang, "", Convert.ToInt32(row["GroupCate"].ToString()), url1, url2);
                    }
                    menubar.Append("</li>");
                }
                menubar.Append("</ul>");
            }
        }

        public void MenuNews(Menu menu, int iParentID, string lang)
        {
            try
            {
                DataTable table = new DataTable();
                BaseDAO baseDAO = new BaseDAO();
                using (SqlConnection connection = baseDAO.GetConnection())
                {
                    SqlCommand command = new SqlCommand("_CateNewsGetClient", connection) {
                        CommandType = CommandType.StoredProcedure
                    };
                    command.Parameters.AddWithValue("@CateNewsID", iParentID);
                    command.Parameters.AddWithValue("@Language", lang);
                    command.Parameters.AddWithValue("@GroupCate", 1);
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
                        MenuItem menuitem = new MenuItem(row["CateNewsName"].ToString()) {
                            NavigateUrl = "~/Default.aspx?go=catenews&id=" + row["CateNewsID"].ToString()
                        };
                        this.SubMenuNews(menuitem, Convert.ToInt32(row["CateNewsID"]), lang);
                        menu.Items.Add(menuitem);
                    }
                }
            }
            catch (Exception ex)
            {
                throw new DataAccessException(ex.Message.ToString());
            }
        }

        public void RadMenuCateGroup(RadMenu menu, int iCate, string lang, int group, string url)
        {
            DataTable table = this.getCateClientGroup(iCate, lang, group);
            if (table.Rows.Count > 0)
            {
                foreach (DataRow row in table.Rows)
                {
                    RadMenuItem menuitem = new RadMenuItem(row["CateNewsName"].ToString()) {
                        NavigateUrl = url + row["CateNewsID"].ToString()
                    };
                    this.GetSubCategoryRadMenuCateGroup(menuitem, Convert.ToInt32(row["CateNewsID"].ToString()), lang, "", group, url);
                    menu.Items.Add(menuitem);
                }
            }
        }

        public void RadMenuCateGroupUrl(RadMenu menu, int iCate, string lang, int group, string url)
        {
            DataTable table = this.getCateClientGroupUrl(iCate, lang, group);
            if (table.Rows.Count > 0)
            {
                foreach (DataRow row in table.Rows)
                {
                    RadMenuItem menuitem = new RadMenuItem(row["CateNewsName"].ToString());
                    if (Convert.ToBoolean(row["IsUrl"].ToString()))
                    {
                        menuitem.NavigateUrl = row["Url"].ToString();
                    }
                    else
                    {
                        menuitem.NavigateUrl = url + row["CateNewsID"].ToString();
                    }
                    this.GetSubCategoryRadMenuCateGroupUrl(menuitem, Convert.ToInt32(row["CateNewsID"].ToString()), lang, "", group, url);
                    menu.Items.Add(menuitem);
                }
            }
        }

        public void RadMenuCateGroupUrl(RadMenu menu, int iCate, string lang, int group, string url1, string url2)
        {
            DataTable table = this.getCateClientGroupUrl(iCate, lang, group);
            if (table.Rows.Count > 0)
            {
                foreach (DataRow row in table.Rows)
                {
                    RadMenuItem menuitem = new RadMenuItem(row["CateNewsName"].ToString());
                    if (Convert.ToBoolean(row["IsUrl"].ToString()))
                    {
                        menuitem.NavigateUrl = row["Url"].ToString();
                    }
                    else
                    {
                        menuitem.NavigateUrl = url1 + row["CateNewsID"].ToString() + "/" + this.Getstring(row["CateNewsName"].ToString()) + url2;
                    }
                    this.GetSubCategoryRadMenuCateGroupUrl(menuitem, Convert.ToInt32(row["CateNewsID"].ToString()), lang, "", group, url1, url2);
                    menu.Items.Add(menuitem);
                }
            }
        }

        public void RadMenuCompany(RadMenu menu, int iCate, string lang)
        {
            DataTable table = this.getCateCompanyClient(iCate, lang);
            if (table.Rows.Count > 0)
            {
                foreach (DataRow row in table.Rows)
                {
                    RadMenuItem menuitem = new RadMenuItem(row["CateNewsName"].ToString()) {
                        NavigateUrl = "~/Default.aspx?go=catecompany&id=" + row["CateNewsID"].ToString()
                    };
                    this.GetSubCategoryRadCompany(menuitem, Convert.ToInt32(row["CateNewsID"].ToString()), lang, "");
                    menu.Items.Add(menuitem);
                }
            }
        }

        public void RadMenuNews(RadMenu menu, int iCate, string lang)
        {
            DataTable table = this.getCateNewsClient(iCate, lang);
            if (table.Rows.Count > 0)
            {
                foreach (DataRow row in table.Rows)
                {
                    RadMenuItem menuitem = new RadMenuItem(row["CateNewsName"].ToString()) {
                        NavigateUrl = "~/Default.aspx?go=catenews&id=" + row["CateNewsID"].ToString()
                    };
                    this.GetSubCategoryRadNews(menuitem, Convert.ToInt32(row["CateNewsID"].ToString()), lang, "");
                    menu.Items.Add(menuitem);
                }
            }
        }

        private string RemoveExtraSpaces(string s)
        {
            if (!s.Contains("--"))
            {
                return s;
            }
            return this.RemoveExtraSpaces(s.Replace("--", "-"));
        }

        private void SubMenuCompany(MenuItem _parentNote, int iCate_ID, string language)
        {
            try
            {
                BaseDAO baseDAO = new BaseDAO();
                DataTable datatable = new DataTable();
                using (SqlConnection connection = baseDAO.GetConnection())
                {
                    SqlCommand command = new SqlCommand("_CateNewsGetClient", connection) {
                        CommandType = CommandType.StoredProcedure
                    };
                    command.Parameters.AddWithValue("@CateNewsID", iCate_ID);
                    command.Parameters.AddWithValue("@Language", language);
                    command.Parameters.AddWithValue("@GroupCate", 0);
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
                        MenuItem _childNote = new MenuItem(row["CateNewsName"].ToString()) {
                            NavigateUrl = "~/Default.aspx?go=catecompany&id=" + row["CateNewsID"].ToString()
                        };
                        _parentNote.ChildItems.Add(_childNote);
                        this.SubMenuCompany(_childNote, Convert.ToInt32(row["CateNewsID"]), language);
                    }
                }
            }
            catch (Exception ex)
            {
                throw new DataAccessException(ex.Message.ToString());
            }
        }

        private void SubMenuNews(MenuItem _parentNote, int iCate_ID, string language)
        {
            try
            {
                BaseDAO baseDAO = new BaseDAO();
                DataTable datatable = new DataTable();
                using (SqlConnection connection = baseDAO.GetConnection())
                {
                    SqlCommand command = new SqlCommand("_CateNewsGetClient", connection) {
                        CommandType = CommandType.StoredProcedure
                    };
                    command.Parameters.AddWithValue("@CateNewsID", iCate_ID);
                    command.Parameters.AddWithValue("@Language", language);
                    command.Parameters.AddWithValue("@GroupCate", 1);
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
                        MenuItem _childNote = new MenuItem(row["CateNewsName"].ToString()) {
                            NavigateUrl = "~/Default.aspx?go=catenews&id=" + row["CateNewsID"].ToString()
                        };
                        _parentNote.ChildItems.Add(_childNote);
                        this.SubMenuNews(_childNote, Convert.ToInt32(row["CateNewsID"]), language);
                    }
                }
            }
            catch (Exception ex)
            {
                throw new DataAccessException(ex.Message.ToString());
            }
        }

        private static string UCS2Convert(string sContent)
        {
            sContent = sContent.Trim();
            string sUTF8Lower = "a|\x00e1|\x00e0|ả|\x00e3|ạ|ă|ắ|ằ|ẳ|ẵ|ặ|\x00e2|ấ|ầ|ẩ|ẫ|ậ|đ|e|\x00e9|\x00e8|ẻ|ẽ|ẹ|\x00ea|ế|ề|ể|ễ|ệ|i|\x00ed|\x00ec|ỉ|ĩ|ị|o|\x00f3|\x00f2|ỏ|\x00f5|ọ|\x00f4|ố|ồ|ổ|ỗ|ộ|ơ|ớ|ờ|ở|ỡ|ợ|u|\x00fa|\x00f9|ủ|ũ|ụ|ư|ứ|ừ|ử|ữ|ự|y|\x00fd|ỳ|ỷ|ỹ|ỵ";
            string sUTF8Upper = "A|\x00c1|\x00c0|Ả|\x00c3|Ạ|Ă|Ắ|Ằ|Ẳ|Ẵ|Ặ|\x00c2|Ấ|Ầ|Ẩ|Ẫ|Ậ|Đ|E|\x00c9|\x00c8|Ẻ|Ẽ|Ẹ|\x00ca|Ế|Ề|Ể|Ễ|Ệ|I|\x00cd|\x00cc|Ỉ|Ĩ|Ị|O|\x00d3|\x00d2|Ỏ|\x00d5|Ọ|\x00d4|Ố|Ồ|Ổ|Ỗ|Ộ|Ơ|Ớ|Ờ|Ở|Ỡ|Ợ|U|\x00da|\x00d9|Ủ|Ũ|Ụ|Ư|Ứ|Ừ|Ử|Ữ|Ự|Y|\x00dd|Ỳ|Ỷ|Ỹ|Ỵ";
            string sUCS2Lower = "a|a|a|a|a|a|a|a|a|a|a|a|a|a|a|a|a|a|d|e|e|e|e|e|e|e|e|e|e|e|e|i|i|i|i|i|i|o|o|o|o|o|o|o|o|o|o|o|o|o|o|o|o|o|o|u|u|u|u|u|u|u|u|u|u|u|u|y|y|y|y|y|y";
            string sUCS2Upper = "A|A|A|A|A|A|A|A|A|A|A|A|A|A|A|A|A|A|D|E|E|E|E|E|E|E|E|E|E|E|E|I|I|I|I|I|I|O|O|O|O|O|O|O|O|O|O|O|O|O|O|O|O|O|O|U|U|U|U|U|U|U|U|U|U|U|U|Y|Y|Y|Y|Y|Y";
            string[] aUTF8Lower = sUTF8Lower.Split(new char[] { '|' });
            string[] aUTF8Upper = sUTF8Upper.Split(new char[] { '|' });
            string[] aUCS2Lower = sUCS2Lower.Split(new char[] { '|' });
            string[] aUCS2Upper = sUCS2Upper.Split(new char[] { '|' });
            int nLimitChar = aUTF8Lower.GetUpperBound(0);
            for (int i = 1; i <= nLimitChar; i++)
            {
                sContent = sContent.Replace(aUTF8Lower[i], aUCS2Lower[i]);
                sContent = sContent.Replace(aUTF8Upper[i], aUCS2Upper[i]);
            }
            string sUCS2regex = "[A-Za-z0-9- ]";
            string sEscaped = new Regex(sUCS2regex, RegexOptions.ExplicitCapture | RegexOptions.Multiline | RegexOptions.IgnoreCase).Replace(sContent, string.Empty);
            if (string.IsNullOrEmpty(sEscaped))
            {
                return sContent;
            }
            sEscaped = sEscaped.Replace("[", @"\[").Replace("]", @"\]").Replace("^", @"\^");
            return new Regex("[" + sEscaped + "]", RegexOptions.ExplicitCapture | RegexOptions.Multiline | RegexOptions.IgnoreCase).Replace(sContent, string.Empty);
        }

        public void UpdateCateNews(CateNews catenews)
        {
            new CateNewsDAO().UpdateCateNews(catenews);
        }
    }
}

