namespace BSO
{
    using DAO;
    using ETO;
    using System;
    using System.Data;
    using System.Data.SqlClient;
    using System.Web;
    using Telerik.Web.UI;

    public class MenuLinksBSO
    {
        public int AddMenuLinks(MenuLinks _menuLinks)
        {
            MenuLinksDAO menuLinksDAO = new MenuLinksDAO();
            return menuLinksDAO.CreateMenuLinks(_menuLinks);
        }

        public bool CheckExist(string menuLinksName)
        {
            bool name = false;
            DataTable dataTable = this.GetAllMenuLinks();
            if (dataTable != null)
            {
                DataView dataView = new DataView(dataTable) {
                    RowFilter = "MenuLinksUrl = '" + menuLinksName + "'"
                };
                if (dataView.Count > 0)
                {
                    name = true;
                }
            }
            return name;
        }

        public void DeleteMenuLinks(int mID)
        {
            new MenuLinksDAO().DeleteMenuLinks(mID);
        }

        public int EditMenuLinks(MenuLinks _menuLinks)
        {
            MenuLinksDAO menuLinksDAO = new MenuLinksDAO();
            return menuLinksDAO.UpdateMenuLinks(_menuLinks);
        }

        public DataTable GetAllMenuLinks()
        {
            MenuLinksDAO menuLinksDAO = new MenuLinksDAO();
            return menuLinksDAO.GetAllMenuLinks();
        }

        public DataTable getCateClient(int iCate)
        {
            BaseDAO baseDAO = new BaseDAO();
            DataTable table = new DataTable();
            using (SqlConnection connection = baseDAO.GetConnection())
            {
                SqlCommand command = new SqlCommand("_MenuLinksGetClient", connection) {
                    CommandType = CommandType.StoredProcedure
                };
                command.Parameters.AddWithValue("@MenuLinksParent", iCate);
                connection.Open();
                using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                {
                    adapter.Fill(table);
                    command.Dispose();
                }
            }
            return table;
        }

        public DataTable GetHotMenuLinks()
        {
            MenuLinksDAO menuLinksDAO = new MenuLinksDAO();
            return menuLinksDAO.GetHotMenuLinks();
        }

        public DataTable GetHotMenuLinks(int num)
        {
            MenuLinksDAO menuLinksDAO = new MenuLinksDAO();
            return menuLinksDAO.GetHotMenuLinks(num);
        }

        public MenuLinks GetMenuLinksById(int mID)
        {
            MenuLinksDAO menuLinksDAO = new MenuLinksDAO();
            return menuLinksDAO.GetMenuLinksById(mID);
        }

        public MenuLinks GetMenuLinksByUrl(string url)
        {
            MenuLinksDAO menuLinksDAO = new MenuLinksDAO();
            return menuLinksDAO.GetMenuLinksByUrl(url);
        }

        private void GetSubCategoryRadMenuCate(RadMenuItem _parentNote, int iCate_ID, string lang, string sSpace, string url)
        {
            string str = HttpUtility.HtmlDecode("&nbsp;&nbsp;");
            sSpace = sSpace + str;
            DataTable datatable = this.getCateClient(iCate_ID);
            if (datatable.Rows.Count > 0)
            {
                foreach (DataRow row in datatable.Rows)
                {
                    string Name = row["MenuLinksName"].ToString();
                    if (Name.Contains("-"))
                    {
                        Name = Name.Replace("&nbsp;", "").Replace("-", "");
                        Name = "<b>" + Name + "</b>";
                    }
                    else
                    {
                        Name = sSpace + row["MenuLinksName"].ToString();
                    }
                    RadMenuItem _childNote = new RadMenuItem(Name) {
                        NavigateUrl = url + row["MenuLinksID"].ToString()
                    };
                    _parentNote.Items.Add(_childNote);
                    this.GetSubCategoryRadMenuCate(_childNote, Convert.ToInt32(row["MenuLinksID"].ToString()), lang, "", url);
                }
            }
        }

        private void GetSubCategoryRadMenuCateURL(RadMenuItem _parentNote, int iCate_ID, string lang, string sSpace, string url)
        {
            string str = HttpUtility.HtmlDecode("&nbsp;&nbsp;");
            sSpace = sSpace + str;
            DataTable datatable = this.getCateClient(iCate_ID);
            if (datatable.Rows.Count > 0)
            {
                foreach (DataRow row in datatable.Rows)
                {
                    string Name = row["MenuLinksName"].ToString();
                    if (Name.Contains("-"))
                    {
                        Name = Name.Replace("&nbsp;", "").Replace("-", "");
                        Name = "<b>" + Name + "</b>";
                    }
                    else
                    {
                        Name = sSpace + row["MenuLinksName"].ToString();
                    }
                    RadMenuItem _childNote = new RadMenuItem(Name) {
                        NavigateUrl = url + row["MenuLinksURL"].ToString()
                    };
                    _parentNote.Items.Add(_childNote);
                    _childNote.Target = "blamk";
                    this.GetSubCategoryRadMenuCateURL(_childNote, Convert.ToInt32(row["MenuLinksID"].ToString()), lang, "", url);
                }
            }
        }

        public void MenuLinksUpOrder(int cId, int cOrder)
        {
            new MenuLinksDAO().MenuLinksUpOrder(cId, cOrder);
        }

        public DataTable MixMenuLinks()
        {
            MenuLinksDAO menuLinksDAO = new MenuLinksDAO();
            return menuLinksDAO.MixMenuLinks();
        }

        public DataTable MixMenuLinksBullet(string bullet)
        {
            MenuLinksDAO menuLinksDAO = new MenuLinksDAO();
            return menuLinksDAO.MixMenuLinksBullet(bullet);
        }

        public void RadMenuCate(RadMenu menu, int iCate, string lang, string url)
        {
            DataTable table = this.getCateClient(iCate);
            if (table.Rows.Count > 0)
            {
                foreach (DataRow row in table.Rows)
                {
                    RadMenuItem menuitem = new RadMenuItem(row["MenuLinksName"].ToString()) {
                        NavigateUrl = url + row["MenuLinksID"].ToString()
                    };
                    this.GetSubCategoryRadMenuCate(menuitem, Convert.ToInt32(row["MenuLinksID"].ToString()), lang, "", url);
                    menu.Items.Add(menuitem);
                }
            }
        }

        public void RadMenuCateURL(RadMenu menu, int iCate, string lang, string url)
        {
            DataTable table = this.getCateClient(iCate);
            if (table.Rows.Count > 0)
            {
                foreach (DataRow row in table.Rows)
                {
                    RadMenuItem menuitem = new RadMenuItem(row["MenuLinksName"].ToString()) {
                        NavigateUrl = url + row["MenuLinksURL"].ToString(),
                        Target = "blank"
                    };
                    this.GetSubCategoryRadMenuCateURL(menuitem, Convert.ToInt32(row["MenuLinksID"].ToString()), lang, "", url);
                    menu.Items.Add(menuitem);
                }
            }
        }
    }
}

