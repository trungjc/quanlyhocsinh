namespace BSO
{
    using DAO;
    using ETO;
    using System;
    using System.Data;
    using System.Data.SqlClient;
    using System.Web;
    using System.Web.UI.WebControls;
    using Telerik.Web.UI;

    public class AlbumsCateBSO
    {
        public void AlbumsCateUpOrder(int cId, int cOrder)
        {
            new AlbumsCateDAO().AlbumsCateUpOrder(cId, cOrder);
        }

        public void CateNavigator(ref string cate_navigator, int cateId, string url)
        {
            try
            {
                AlbumsCate albumcate = this.GetAlbumsCateById(cateId);
                if (!string.IsNullOrEmpty(cate_navigator))
                {
                    cate_navigator = " &raquo; " + cate_navigator;
                }
                cate_navigator = string.Concat(new object[] { "<a href='", url, cateId, "'>", albumcate.AlbumsCateName, "</a>", cate_navigator });
                if (albumcate.ParentCateID != 0)
                {
                    this.CateNavigator(ref cate_navigator, albumcate.ParentCateID, url);
                }
            }
            catch (Exception ex)
            {
                throw new BusinessException(ex.Message.ToString());
            }
        }

        public void CreateCateNew(AlbumsCate albumcate)
        {
            new AlbumsCateDAO().CreateAlbumsCate(albumcate);
        }

        public void DeleteAlbumsCateAll(int cateID)
        {
            try
            {
                DataTable table = this.GetAlbumsCate();
                for (int m = 0; m < table.Rows.Count; m++)
                {
                    int pParent = Convert.ToInt32(table.Rows[m]["ParentCateID"]);
                    int cCate = Convert.ToInt32(table.Rows[m]["AlbumsCateID"]);
                    if (cateID == pParent)
                    {
                        this.DeleteAlbumsCateAll(cCate);
                    }
                }
                new AlbumsCateDAO().DeleteAlbumsCate(cateID);
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
                SqlCommand command = new SqlCommand("_AlbumsCateCheck", connection) {
                    CommandType = CommandType.StoredProcedure
                };
                command.Parameters.AddWithValue("@AlbumsCateName", catename);
                connection.Open();
                using (SqlDataReader reader = command.ExecuteReader(CommandBehavior.CloseConnection))
                {
                    ExistName= reader.HasRows;
                }
            }
            return ExistName;
        }

        public DataTable GetAlbumsCate()
        {
            AlbumsCateDAO albumcateDAO = new AlbumsCateDAO();
            return albumcateDAO.GetAlbumsCate();
        }

        public AlbumsCate GetAlbumsCateById(int cId)
        {
            AlbumsCateDAO albumcateDAO = new AlbumsCateDAO();
            return albumcateDAO.GetAlbumsCateById(cId);
        }

        public DataTable getAlbumsCateClient(int iCate)
        {
            BaseDAO baseDAO = new BaseDAO();
            DataTable table = new DataTable();
            using (SqlConnection connection = baseDAO.GetConnection())
            {
                SqlCommand command = new SqlCommand("_AlbumsCateGetClient", connection) {
                    CommandType = CommandType.StoredProcedure
                };
                command.Parameters.AddWithValue("@AlbumsCateID", iCate);
                connection.Open();
                using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                {
                    adapter.Fill(table);
                    command.Dispose();
                }
            }
            return table;
        }

        public DataTable getAlbumsCateLevel(int iCate)
        {
            DataTable table = new DataTable();
            BaseDAO baseDAO = new BaseDAO();
            using (SqlConnection connection = baseDAO.GetConnection())
            {
                SqlCommand command = new SqlCommand("_AlbumsCateGet", connection) {
                    CommandType = CommandType.StoredProcedure
                };
                command.Parameters.AddWithValue("@AlbumsCateID", iCate);
                connection.Open();
                using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                {
                    adapter.Fill(table);
                    command.Dispose();
                }
            }
            return table;
        }

        public DataTable GetCateGroupBullet(string bullet)
        {
            AlbumsCateDAO albumcateDAO = new AlbumsCateDAO();
            return albumcateDAO.GetCateGroupBullet(bullet);
        }

        private void GetSubCategoryRadMenuCateGroup(RadMenuItem _parentNote, int iCate_ID, string sSpace, string url)
        {
            string str = HttpUtility.HtmlDecode("&nbsp;&nbsp;");
            sSpace = sSpace + str;
            DataTable datatable = this.getAlbumsCateClient(iCate_ID);
            if (datatable.Rows.Count > 0)
            {
                foreach (DataRow row in datatable.Rows)
                {
                    string Name = row["AlbumsCateName"].ToString();
                    if (Name.Contains("-"))
                    {
                        Name = Name.Replace("&nbsp;", "").Replace("-", "");
                        Name = "<b>" + Name + "</b>";
                    }
                    else
                    {
                        Name = sSpace + row["AlbumsCateName"].ToString();
                    }
                    RadMenuItem _childNote = new RadMenuItem(Name) {
                        NavigateUrl = url + row["AlbumsCateID"].ToString()
                    };
                    _parentNote.Items.Add(_childNote);
                    this.GetSubCategoryRadMenuCateGroup(_childNote, Convert.ToInt32(row["AlbumsCateID"].ToString()), "", url);
                }
            }
        }

        public void MenuAlbums(Menu menu, int iParentID)
        {
            try
            {
                DataTable table = new DataTable();
                BaseDAO baseDAO = new BaseDAO();
                using (SqlConnection connection = baseDAO.GetConnection())
                {
                    SqlCommand command = new SqlCommand("_AlbumsCateGetClient", connection) {
                        CommandType = CommandType.StoredProcedure
                    };
                    command.Parameters.AddWithValue("@AlbumsCateID", iParentID);
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
                        MenuItem menuitem = new MenuItem(row["AlbumsCateName"].ToString()) {
                            NavigateUrl = "~/Default.aspx?go=albumcate&id=" + row["AlbumsCateID"].ToString()
                        };
                        this.SubMenuNews(menuitem, Convert.ToInt32(row["AlbumsCateID"]));
                        menu.Items.Add(menuitem);
                    }
                }
            }
            catch (Exception ex)
            {
                throw new DataAccessException(ex.Message.ToString());
            }
        }

        public void RadMenuAlbumsCate(RadMenu menu, int iCate, string url)
        {
            DataTable table = this.getAlbumsCateClient(iCate);
            if (table.Rows.Count > 0)
            {
                foreach (DataRow row in table.Rows)
                {
                    RadMenuItem menuitem = new RadMenuItem(row["AlbumsCateName"].ToString()) {
                        NavigateUrl = url + row["AlbumsCateID"].ToString()
                    };
                    this.GetSubCategoryRadMenuCateGroup(menuitem, Convert.ToInt32(row["AlbumsCateID"].ToString()), "", url);
                    menu.Items.Add(menuitem);
                }
            }
        }

        private void SubMenuNews(MenuItem _parentNote, int iCate_ID)
        {
            try
            {
                BaseDAO baseDAO = new BaseDAO();
                DataTable datatable = new DataTable();
                using (SqlConnection connection = baseDAO.GetConnection())
                {
                    SqlCommand command = new SqlCommand("_AlbumsCateGetClient", connection) {
                        CommandType = CommandType.StoredProcedure
                    };
                    command.Parameters.AddWithValue("@AlbumsCateID", iCate_ID);
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
                        MenuItem _childNote = new MenuItem(row["AlbumsCateName"].ToString()) {
                            NavigateUrl = "~/Default.aspx?go=albumcate&id=" + row["AlbumsCateID"].ToString()
                        };
                        _parentNote.ChildItems.Add(_childNote);
                        this.SubMenuNews(_childNote, Convert.ToInt32(row["AlbumsCateID"]));
                    }
                }
            }
            catch (Exception ex)
            {
                throw new DataAccessException(ex.Message.ToString());
            }
        }

        public void UpdateAlbumsCate(AlbumsCate albumcate)
        {
            new AlbumsCateDAO().UpdateAlbumsCate(albumcate);
        }
    }
}

