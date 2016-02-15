namespace DAO
{
    using ETO;
    using System;
    using System.Data;
    using System.Data.SqlClient;
    using System.Web;

    public class CateNewsDAO : BaseDAO
    {
        private CateNews CateNewsReader(SqlDataReader reader)
        {
            return new CateNews { CateNewsID = (int) reader["CateNewsID"], ParentNewsID = (int) reader["ParentNewsID"], CateNewsName = (string) reader["CateNewsName"], CateNewsTotal = (int) reader["CateNewsTotal"], CateNewsOrder = (int) reader["CateNewsOrder"], Language = (string) reader["Language"], GroupCate = (int) reader["GroupCate"], Icon = (string) reader["Icon"], Slogan = (string) reader["Slogan"], Roles = (string) reader["Roles"], UserName = (string) reader["UserName"], Created = (DateTime) reader["Created"], isUrl = (bool) reader["isUrl"], Url = (string) reader["Url"],Image=(string)reader["Image"] };
        }

        public void CateNewsUpOrder(int cId, int cOrder)
        {
            using (SqlConnection connection = base.GetConnection())
            {
                SqlCommand command = new SqlCommand("_CateNewsUpOrder", connection) {
                    CommandType = CommandType.StoredProcedure
                };
                command.Parameters.AddWithValue("@CateNewsID", cId);
                command.Parameters.AddWithValue("@CateNewsOrder", cOrder);
                connection.Open();
                if (command.ExecuteNonQuery() <= 0)
                {
                    throw new DataAccessException("Kh\x00f4ng thể cập nhật danh mục tin");
                }
                command.Dispose();
            }
        }

        public void CreateCateNews(CateNews catenews)
        {
            using (SqlConnection connection = base.GetConnection())
            {
                SqlCommand command = new SqlCommand("_CateNewsUpdate", connection) {
                    CommandType = CommandType.StoredProcedure
                };
                command.Parameters.AddWithValue("@Type", 0);
                command.Parameters.AddWithValue("@CateNewsID", 0);
                command.Parameters.AddWithValue("@ParentNewsID", catenews.ParentNewsID);
                command.Parameters.AddWithValue("@CateNewsName", catenews.CateNewsName);
                command.Parameters.AddWithValue("@CateNewsTotal", catenews.CateNewsTotal);
                command.Parameters.AddWithValue("@CateNewsOrder", catenews.CateNewsOrder);
                command.Parameters.AddWithValue("@Language", catenews.Language);
                command.Parameters.AddWithValue("@GroupCate", catenews.GroupCate);
                command.Parameters.AddWithValue("@Icon", catenews.Icon);
                command.Parameters.AddWithValue("@Slogan", catenews.Slogan);
                command.Parameters.AddWithValue("@Roles", catenews.Roles);
                command.Parameters.AddWithValue("@UserName", catenews.UserName);
                command.Parameters.AddWithValue("@Created", catenews.Created);
                command.Parameters.AddWithValue("@Url", catenews.Url);
                command.Parameters.AddWithValue("@isUrl", catenews.isUrl);
                connection.Open();
                if (command.ExecuteNonQuery() <= 0)
                {
                    throw new DataAccessException("Kh\x00f4ng thể tạo danh mục tin");
                }
                command.Dispose();
            }
        }

        public int CreateCateNewsGet(CateNews catenews)
        {
            using (SqlConnection connection = base.GetConnection())
            {
                SqlCommand command = new SqlCommand("_CateNewsInsert", connection) {
                    CommandType = CommandType.StoredProcedure
                };
                command.Parameters.AddWithValue("@ParentNewsID", catenews.ParentNewsID);
                command.Parameters.AddWithValue("@CateNewsName", catenews.CateNewsName);
                command.Parameters.AddWithValue("@CateNewsTotal", catenews.CateNewsTotal);
                command.Parameters.AddWithValue("@CateNewsOrder", catenews.CateNewsOrder);
                command.Parameters.AddWithValue("@Language", catenews.Language);
                command.Parameters.AddWithValue("@GroupCate", catenews.GroupCate);
                command.Parameters.AddWithValue("@Icon", catenews.Icon);
                command.Parameters.AddWithValue("@Slogan", catenews.Slogan);
                command.Parameters.AddWithValue("@Roles", catenews.Roles);
                command.Parameters.AddWithValue("@UserName", catenews.UserName);
                command.Parameters.AddWithValue("@Created", catenews.Created);
                command.Parameters.AddWithValue("@isUrl", catenews.isUrl);
                command.Parameters.AddWithValue("@Url", catenews.Url);
                command.Parameters.AddWithValue("@Image", catenews.Image);
                SqlParameter sp = new SqlParameter("@pReturnValue", SqlDbType.Int) {
                    Direction = ParameterDirection.Output
                };
                command.Parameters.Add(sp);
                connection.Open();
                command.ExecuteNonQuery();
                return Convert.ToInt32(sp.Value.ToString());
            }
        }

        public void DeleteCateNews(int cId)
        {
            using (SqlConnection connection = base.GetConnection())
            {
                SqlCommand command = new SqlCommand("_CateNewsDelete", connection) {
                    CommandType = CommandType.StoredProcedure
                };
                command.Parameters.AddWithValue("@CateNewsID", cId);
                connection.Open();
                if (command.ExecuteNonQuery() <= 0)
                {
                    throw new DataAccessException("Kh\x00f4ng thể x\x00f3a danh mục tin");
                }
                command.Dispose();
            }
        }

        public DataTable GetCateCompanyParentAll(int Id, string lang)
        {
            DataTable table = new DataTable();
            using (SqlConnection connection = base.GetConnection())
            {
                SqlCommand command = new SqlCommand("_CateNewsGetGroup", connection) {
                    CommandType = CommandType.StoredProcedure
                };
                command.Parameters.AddWithValue("@CateNewsID", Id);
                command.Parameters.AddWithValue("@Language", lang);
                command.Parameters.AddWithValue("@GroupCate", 2);
                connection.Open();
                using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                {
                    adapter.Fill(table);
                    command.Dispose();
                }
            }
            return table;
        }

        public DataTable GetCateGroup(string lang, int group)
        {
            DataTable datatable = new DataTable();
            datatable.Columns.Add("CateNewsID");
            datatable.Columns.Add("ParentNewsID");
            datatable.Columns.Add("CateNewsName");
            datatable.Columns.Add("CateNewsTotal");
            datatable.Columns.Add("CateNewsOrder");
            datatable.Columns.Add("Language");
            datatable.Columns.Add("GroupCate");
            datatable.Columns.Add("Icon");
            datatable.Columns.Add("Slogan");
            datatable.Columns.Add("Roles");
            datatable.Columns.Add("UserName");
            datatable.Columns.Add("Created");
            datatable.Columns.Add("Image");
            DataTable table = new DataTable();
            using (SqlConnection connection = base.GetConnection())
            {
                SqlCommand command = new SqlCommand("_CateGetGroup", connection) {
                    CommandType = CommandType.StoredProcedure
                };
                command.Parameters.AddWithValue("@CateNewsID", 0);
                command.Parameters.AddWithValue("@Language", lang);
                command.Parameters.AddWithValue("@GroupCate", group);
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
                    datarow["CateNewsID"] = row["CateNewsID"].ToString();
                    datarow["ParentNewsID"] = row["ParentNewsID"].ToString();
                    datarow["CateNewsName"] = row["CateNewsName"].ToString();
                    datarow["CateNewsTotal"] = row["CateNewsTotal"].ToString();
                    datarow["CateNewsOrder"] = row["CateNewsOrder"].ToString();
                    datarow["Language"] = row["Language"].ToString();
                    datarow["GroupCate"] = row["GroupCate"].ToString();
                    datarow["Icon"] = row["Icon"].ToString();
                    datarow["Slogan"] = row["Slogan"].ToString();
                    datarow["Roles"] = row["Roles"].ToString();
                    datarow["UserName"] = row["UserName"].ToString();
                    datarow["Created"] = row["Created"].ToString();
                    datarow["Image"] = row["Image"].ToString();
                    datatable.Rows.Add(datarow);
                    this.GetParentGroup(datatable, Convert.ToInt32(datarow["CateNewsID"]), lang, 1, "&nbsp;&nbsp;", group);
                }
            }
            return datatable;
        }

        public DataTable GetCateGroupBullet(string lang, int group, string bullet)
        {
            string sSpace = HttpUtility.HtmlDecode("<img src='/images/" + bullet + "' class='icon' style='width:13px' />&nbsp;<b>");
            string sSpace1 = HttpUtility.HtmlDecode("</b>");
            DataTable datatable = new DataTable();
            datatable.Columns.Add("CateNewsID");
            datatable.Columns.Add("ParentNewsID");
            datatable.Columns.Add("CateNewsName");
            datatable.Columns.Add("CateNewsTotal");
            datatable.Columns.Add("CateNewsOrder");
            datatable.Columns.Add("Language");
            datatable.Columns.Add("GroupCate");
            datatable.Columns.Add("Icon");
            datatable.Columns.Add("Slogan");
            datatable.Columns.Add("Roles");
            datatable.Columns.Add("UserName");
            datatable.Columns.Add("Created");
            DataTable table = new DataTable();
            using (SqlConnection connection = base.GetConnection())
            {
                SqlCommand command = new SqlCommand("_CateGetGroup", connection) {
                    CommandType = CommandType.StoredProcedure
                };
                command.Parameters.AddWithValue("@CateNewsID", 0);
                command.Parameters.AddWithValue("@Language", lang);
                command.Parameters.AddWithValue("@GroupCate", group);
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
                    datarow["CateNewsID"] = row["CateNewsID"].ToString();
                    datarow["ParentNewsID"] = row["ParentNewsID"].ToString();
                    datarow["CateNewsName"] = sSpace + row["CateNewsName"].ToString() + sSpace1;
                    datarow["CateNewsTotal"] = row["CateNewsTotal"].ToString();
                    datarow["CateNewsOrder"] = row["CateNewsOrder"].ToString();
                    datarow["Language"] = row["Language"].ToString();
                    datarow["GroupCate"] = row["GroupCate"].ToString();
                    datarow["Icon"] = row["Icon"].ToString();
                    datarow["Slogan"] = row["Slogan"].ToString();
                    datarow["Roles"] = row["Roles"].ToString();
                    datarow["UserName"] = row["UserName"].ToString();
                    datarow["Created"] = row["Created"].ToString();
                    datatable.Rows.Add(datarow);
                    this.GetParentGroupBullet(datatable, Convert.ToInt32(datarow["CateNewsID"]), lang, 1, "&nbsp;&nbsp;&nbsp;", group, bullet);
                }
            }
            return datatable;
        }

        public DataTable GetCateGroupRoles(string lang, int group, string username)
        {
            SqlConnection connection;
            SqlCommand command;
            SqlDataAdapter adapter;
            DataTable datatable = new DataTable();
            datatable.Columns.Add("CateNewsID");
            datatable.Columns.Add("ParentNewsID");
            datatable.Columns.Add("CateNewsName");
            datatable.Columns.Add("CateNewsTotal");
            datatable.Columns.Add("CateNewsOrder");
            datatable.Columns.Add("Language");
            datatable.Columns.Add("GroupCate");
            datatable.Columns.Add("Icon");
            datatable.Columns.Add("Slogan");
            datatable.Columns.Add("Roles");
            datatable.Columns.Add("UserName");
            datatable.Columns.Add("Created");
            DataTable table = new DataTable();
            if (username.Equals("administrator"))
            {
                using (connection = base.GetConnection())
                {
                    command = new SqlCommand {
                        CommandText = "_CateGetGroup",
                        Connection = connection,
                        CommandType = CommandType.StoredProcedure
                    };
                    command.Parameters.AddWithValue("@CateNewsID", 0);
                    command.Parameters.AddWithValue("@Language", lang);
                    command.Parameters.AddWithValue("@GroupCate", group);
                    connection.Open();
                    using (adapter = new SqlDataAdapter(command))
                    {
                        adapter.Fill(table);
                        command.Dispose();
                    }
                }
            }
            else
            {
                string strRoles = new AdminRolesDAO().GetRoles(username);
                string strCateID = new CateNewsPermissionDAO().GetCateNewsID(strRoles);
                using (connection = base.GetConnection())
                {
                    string SQL = "SELECT * FROM tblCateNews WHERE [ParentNewsID] = @CateNewsID AND [Language] = @Language  AND [GroupCate]=@GroupCate AND [CateNewsID] in('" + strCateID + "') AND [IsUrl] = 0 ORDER BY CateNewsOrder ASC";
                    command = new SqlCommand(SQL, connection) {
                        CommandText = SQL
                    };
                    command.Parameters.AddWithValue("@CateNewsID", 0);
                    command.Parameters.AddWithValue("@Language", lang);
                    command.Parameters.AddWithValue("@GroupCate", group);
                    connection.Open();
                    using (adapter = new SqlDataAdapter(command))
                    {
                        adapter.Fill(table);
                        command.Dispose();
                    }
                }
            }
            if (table.Rows.Count > 0)
            {
                foreach (DataRow row in table.Rows)
                {
                    DataRow datarow = datatable.NewRow();
                    datarow["CateNewsID"] = row["CateNewsID"].ToString();
                    datarow["ParentNewsID"] = row["ParentNewsID"].ToString();
                    datarow["CateNewsName"] = row["CateNewsName"].ToString();
                    datarow["CateNewsTotal"] = row["CateNewsTotal"].ToString();
                    datarow["CateNewsOrder"] = row["CateNewsOrder"].ToString();
                    datarow["Language"] = row["Language"].ToString();
                    datarow["GroupCate"] = row["GroupCate"].ToString();
                    datarow["Icon"] = row["Icon"].ToString();
                    datarow["Slogan"] = row["Slogan"].ToString();
                    datarow["Roles"] = row["Roles"].ToString();
                    datarow["UserName"] = row["UserName"].ToString();
                    datarow["Created"] = row["Created"].ToString();
                    datatable.Rows.Add(datarow);
                    this.GetParentGroupRoles(datatable, Convert.ToInt32(datarow["CateNewsID"]), lang, 1, "&nbsp;&nbsp;&nbsp;--&nbsp;", group, username);
                }
            }
            return datatable;
        }

        public DataTable GetCateGroupRolesUrl(string lang, int group, string username)
        {
            SqlConnection connection;
            SqlCommand command;
            SqlDataAdapter adapter;
            DataTable datatable = new DataTable();
            datatable.Columns.Add("CateNewsID");
            datatable.Columns.Add("ParentNewsID");
            datatable.Columns.Add("CateNewsName");
            datatable.Columns.Add("CateNewsTotal");
            datatable.Columns.Add("CateNewsOrder");
            datatable.Columns.Add("Language");
            datatable.Columns.Add("GroupCate");
            datatable.Columns.Add("Icon");
            datatable.Columns.Add("Slogan");
            datatable.Columns.Add("Roles");
            datatable.Columns.Add("UserName");
            datatable.Columns.Add("Created");
            datatable.Columns.Add("IsUrl");
            datatable.Columns.Add("Url");
            DataTable table = new DataTable();
            if (username.Equals("administrator"))
            {
                using (connection = base.GetConnection())
                {
                    command = new SqlCommand {
                        CommandText = "_CateGetGroupUrl",
                        Connection = connection,
                        CommandType = CommandType.StoredProcedure
                    };
                    command.Parameters.AddWithValue("@CateNewsID", 0);
                    command.Parameters.AddWithValue("@Language", lang);
                    command.Parameters.AddWithValue("@GroupCate", group);
                    connection.Open();
                    using (adapter = new SqlDataAdapter(command))
                    {
                        adapter.Fill(table);
                        command.Dispose();
                    }
                }
            }
            else
            {
                string strRoles = new AdminRolesDAO().GetRoles(username);
                string strCateID = new CateNewsPermissionDAO().GetCateNewsID(strRoles);
                using (connection = base.GetConnection())
                {
                    string SQL = "SELECT * FROM tblCateNews WHERE [ParentNewsID] = @CateNewsID AND [Language] = @Language  AND [GroupCate]=@GroupCate AND [CateNewsID] in('" + strCateID + "') ORDER BY CateNewsOrder ASC";
                    command = new SqlCommand(SQL, connection) {
                        CommandText = SQL
                    };
                    command.Parameters.AddWithValue("@CateNewsID", 0);
                    command.Parameters.AddWithValue("@Language", lang);
                    command.Parameters.AddWithValue("@GroupCate", group);
                    connection.Open();
                    using (adapter = new SqlDataAdapter(command))
                    {
                        adapter.Fill(table);
                        command.Dispose();
                    }
                }
            }
            if (table.Rows.Count > 0)
            {
                foreach (DataRow row in table.Rows)
                {
                    DataRow datarow = datatable.NewRow();
                    datarow["CateNewsID"] = row["CateNewsID"].ToString();
                    datarow["ParentNewsID"] = row["ParentNewsID"].ToString();
                    datarow["CateNewsName"] = row["CateNewsName"].ToString();
                    datarow["CateNewsTotal"] = row["CateNewsTotal"].ToString();
                    datarow["CateNewsOrder"] = row["CateNewsOrder"].ToString();
                    datarow["Language"] = row["Language"].ToString();
                    datarow["GroupCate"] = row["GroupCate"].ToString();
                    datarow["Icon"] = row["Icon"].ToString();
                    datarow["Slogan"] = row["Slogan"].ToString();
                    datarow["Roles"] = row["Roles"].ToString();
                    datarow["UserName"] = row["UserName"].ToString();
                    datarow["Created"] = row["Created"].ToString();
                    datarow["IsUrl"] = row["IsUrl"].ToString();
                    datarow["Url"] = row["Url"].ToString();
                    datatable.Rows.Add(datarow);
                    this.GetParentGroupRolesUrl(datatable, Convert.ToInt32(datarow["CateNewsID"]), lang, 1, "&nbsp;&nbsp;&nbsp;--&nbsp;", group, username);
                }
            }
            return datatable;
        }

        public DataTable GetCateNews(string lang)
        {
            DataTable datatable = new DataTable();
            datatable.Columns.Add("CateNewsID");
            datatable.Columns.Add("ParentNewsID");
            datatable.Columns.Add("CateNewsName");
            datatable.Columns.Add("CateNewsTotal");
            datatable.Columns.Add("CateNewsOrder");
            datatable.Columns.Add("Language");
            datatable.Columns.Add("GroupCate");
            datatable.Columns.Add("Icon");
            datatable.Columns.Add("Slogan");
            datatable.Columns.Add("Roles");
            datatable.Columns.Add("UserName");
            datatable.Columns.Add("Created");
            DataTable table = new DataTable();
            using (SqlConnection connection = base.GetConnection())
            {
                SqlCommand command = new SqlCommand("_CateNewsGet", connection) {
                    CommandType = CommandType.StoredProcedure
                };
                command.Parameters.AddWithValue("@CateNewsID", 0);
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
                    datarow["CateNewsID"] = row["CateNewsID"].ToString();
                    datarow["ParentNewsID"] = row["ParentNewsID"].ToString();
                    datarow["CateNewsName"] = row["CateNewsName"].ToString();
                    datarow["CateNewsTotal"] = row["CateNewsTotal"].ToString();
                    datarow["CateNewsOrder"] = row["CateNewsOrder"].ToString();
                    datarow["Language"] = row["Language"].ToString();
                    datarow["GroupCate"] = row["GroupCate"].ToString();
                    datarow["Icon"] = row["Icon"].ToString();
                    datarow["Slogan"] = row["Slogan"].ToString();
                    datarow["Roles"] = row["Roles"].ToString();
                    datarow["UserName"] = row["UserName"].ToString();
                    datarow["Created"] = row["Created"].ToString();
                    datatable.Rows.Add(datarow);
                    this.GetParentNews(datatable, Convert.ToInt32(datarow["CateNewsID"]), lang, 1, "&nbsp;&nbsp;");
                }
            }
            return datatable;
        }

        public CateNews GetCateNewsById(int cId)
        {
            CateNews catenews = null;
            using (SqlConnection connection = base.GetConnection())
            {
                SqlCommand command = new SqlCommand("_CateNewsById", connection) {
                    CommandType = CommandType.StoredProcedure
                };
                command.Parameters.AddWithValue("@CateNewsID", cId);
                connection.Open();
                using (SqlDataReader reader = command.ExecuteReader(CommandBehavior.CloseConnection))
                {
                    if (!reader.Read())
                    {
                        throw new DataAccessException("Kh\x00f4ng t\x00ecm thấy danh mục");
                    }
                    catenews = this.CateNewsReader(reader);
                    command.Dispose();
                }
            }
            return catenews;
        }

        public DataTable GetCateNewsName(string lang)
        {
            DataTable datatable = new DataTable();
            datatable.Columns.Add("CateNewsID");
            datatable.Columns.Add("ParentNewsID");
            datatable.Columns.Add("CateNewsName");
            datatable.Columns.Add("CateNewsTotal");
            datatable.Columns.Add("CateNewsOrder");
            datatable.Columns.Add("Language");
            datatable.Columns.Add("GroupCate");
            datatable.Columns.Add("Icon");
            datatable.Columns.Add("Slogan");
            datatable.Columns.Add("Roles");
            datatable.Columns.Add("UserName");
            datatable.Columns.Add("Created");
            datatable.Columns.Add("GroupCateName");
            DataTable table = new DataTable();
            using (SqlConnection connection = base.GetConnection())
            {
                SqlCommand command = new SqlCommand("_CateNewsGetNameDB", connection) {
                    CommandType = CommandType.StoredProcedure
                };
                command.Parameters.AddWithValue("@CateNewsID", 0);
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
                    datarow["CateNewsID"] = row["CateNewsID"].ToString();
                    datarow["ParentNewsID"] = row["ParentNewsID"].ToString();
                    datarow["CateNewsName"] = row["CateNewsName"].ToString();
                    datarow["CateNewsTotal"] = row["CateNewsTotal"].ToString();
                    datarow["CateNewsOrder"] = row["CateNewsOrder"].ToString();
                    datarow["Language"] = row["Language"].ToString();
                    datarow["GroupCate"] = row["GroupCate"].ToString();
                    datarow["Icon"] = row["Icon"].ToString();
                    datarow["Slogan"] = row["Slogan"].ToString();
                    datarow["Roles"] = row["Roles"].ToString();
                    datarow["UserName"] = row["UserName"].ToString();
                    datarow["Created"] = row["Created"].ToString();
                    datarow["GroupCateName"] = row["GroupCateName"].ToString();
                    datatable.Rows.Add(datarow);
                    this.GetParentNewsName(datatable, Convert.ToInt32(datarow["CateNewsID"]), lang, 1, "&nbsp;&nbsp;&nbsp;&nbsp;");
                }
            }
            return datatable;
        }

        public DataTable GetCateNewsName(string lang, string username)
        {
            SqlConnection connection;
            SqlCommand command;
            SqlDataAdapter adapter;
            DataTable datatable = new DataTable();
            datatable.Columns.Add("CateNewsID");
            datatable.Columns.Add("ParentNewsID");
            datatable.Columns.Add("CateNewsName");
            datatable.Columns.Add("CateNewsTotal");
            datatable.Columns.Add("CateNewsOrder");
            datatable.Columns.Add("Language");
            datatable.Columns.Add("GroupCate");
            datatable.Columns.Add("Icon");
            datatable.Columns.Add("Slogan");
            datatable.Columns.Add("Roles");
            datatable.Columns.Add("UserName");
            datatable.Columns.Add("Created");
            datatable.Columns.Add("GroupCateName");
            DataTable table = new DataTable();
            if (username.Equals("administrator"))
            {
                using (connection = base.GetConnection())
                {
                    command = new SqlCommand("_CateNewsGetNameDB", connection) {
                        CommandType = CommandType.StoredProcedure
                    };
                    command.Parameters.AddWithValue("@CateNewsID", 0);
                    command.Parameters.AddWithValue("@Language", lang);
                    connection.Open();
                    using (adapter = new SqlDataAdapter(command))
                    {
                        adapter.Fill(table);
                        command.Dispose();
                    }
                }
            }
            else
            {
                string strRoles = new AdminRolesDAO().GetRoles(username);
                string strCateID = new CateNewsPermissionDAO().GetCateNewsID(strRoles);
                using (connection = base.GetConnection())
                {
                    string SQL = "SELECT tblCateNews.*,tblCateNewsGroup.CateNewsGroupName AS GroupCateName FROM tblCateNews INNER JOIN tblCateNewsGroup ON tblCateNews.GroupCate = tblCateNewsGroup.GroupCate WHERE [ParentNewsID] = @CateNewsID AND [Language] = @Language  AND [CateNewsID] in('" + strCateID + "') AND tblCateNews.IsUrl=0 ORDER BY CateNewsOrder ASC";
                    command = new SqlCommand(SQL, connection) {
                        CommandText = SQL
                    };
                    command.Parameters.AddWithValue("@CateNewsID", 0);
                    command.Parameters.AddWithValue("@Language", lang);
                    connection.Open();
                    using (adapter = new SqlDataAdapter(command))
                    {
                        adapter.Fill(table);
                        command.Dispose();
                    }
                }
            }
            if (table.Rows.Count > 0)
            {
                foreach (DataRow row in table.Rows)
                {
                    DataRow datarow = datatable.NewRow();
                    datarow["CateNewsID"] = row["CateNewsID"].ToString();
                    datarow["ParentNewsID"] = row["ParentNewsID"].ToString();
                    datarow["CateNewsName"] = row["CateNewsName"].ToString();
                    datarow["CateNewsTotal"] = row["CateNewsTotal"].ToString();
                    datarow["CateNewsOrder"] = row["CateNewsOrder"].ToString();
                    datarow["Language"] = row["Language"].ToString();
                    datarow["GroupCate"] = row["GroupCate"].ToString();
                    datarow["Icon"] = row["Icon"].ToString();
                    datarow["Slogan"] = row["Slogan"].ToString();
                    datarow["Roles"] = row["Roles"].ToString();
                    datarow["UserName"] = row["UserName"].ToString();
                    datarow["Created"] = row["Created"].ToString();
                    datarow["GroupCateName"] = row["GroupCateName"].ToString();
                    datatable.Rows.Add(datarow);
                    this.GetParentNewsName(datatable, Convert.ToInt32(datarow["CateNewsID"]), lang, 1, "&nbsp;&nbsp;&nbsp;&nbsp;", username);
                }
            }
            return datatable;
        }

        public DataTable GetCateNewsParentAll(int Id, string lang)
        {
            DataTable table = new DataTable();
            using (SqlConnection connection = base.GetConnection())
            {
                SqlCommand command = new SqlCommand("_CateNewsGetGroup", connection) {
                    CommandType = CommandType.StoredProcedure
                };
                command.Parameters.AddWithValue("@CateNewsID", Id);
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

        public DataTable GetCateParentGroupAll(int Id, string lang, int group)
        {
            DataTable table = new DataTable();
            using (SqlConnection connection = base.GetConnection())
            {
                SqlCommand command = new SqlCommand("_CateNewsGetGroup", connection) {
                    CommandType = CommandType.StoredProcedure
                };
                command.Parameters.AddWithValue("@CateNewsID", Id);
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

        public DataTable GetCateParentGroupRolesAll(int Id, string lang, int group, string username)
        {
            DataTable table = new DataTable();
            using (SqlConnection connection = base.GetConnection())
            {
                SqlCommand command = new SqlCommand("_CateNewsGetGroupRoles", connection) {
                    CommandType = CommandType.StoredProcedure
                };
                command.Parameters.AddWithValue("@CateNewsID", Id);
                command.Parameters.AddWithValue("@Language", lang);
                command.Parameters.AddWithValue("@GroupCate", group);
                command.Parameters.AddWithValue("@UserName", username);
                connection.Open();
                using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                {
                    adapter.Fill(table);
                    command.Dispose();
                }
            }
            return table;
        }

        private void GetParentGroup(DataTable table, int cID, string language, int level, string sSpace, int group)
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
                SqlCommand command = new SqlCommand("_CateGetGroup", connection) {
                    CommandType = CommandType.StoredProcedure
                };
                command.Parameters.AddWithValue("@CateNewsID", cID);
                command.Parameters.AddWithValue("@Language", language);
                command.Parameters.AddWithValue("@GroupCate", group);
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
                        rs["CateNewsID"] = subrow["CateNewsID"].ToString();
                        rs["ParentNewsID"] = subrow["ParentNewsID"].ToString();
                        rs["CateNewsName"] = sStr + subrow["CateNewsName"].ToString();
                        rs["CateNewsTotal"] = subrow["CateNewsTotal"].ToString();
                        rs["CateNewsOrder"] = subrow["CateNewsOrder"].ToString();
                        rs["Language"] = subrow["Language"].ToString();
                        rs["GroupCate"] = subrow["GroupCate"].ToString();
                        rs["Icon"] = subrow["Icon"].ToString();
                        rs["Slogan"] = subrow["Slogan"].ToString();
                        rs["Roles"] = subrow["Roles"].ToString();
                        rs["UserName"] = subrow["UserName"].ToString();
                        rs["Created"] = subrow["Created"].ToString();
                        table.Rows.Add(rs);
                        this.GetParentGroup(table, Convert.ToInt32(rs["CateNewsID"]), language, level + 1, "&nbsp;&nbsp;", group);
                    }
                }
            }
        }

        private void GetParentGroupBullet(DataTable table, int cID, string language, int level, string sSpace, int group, string bullet)
        {
            string str = HttpUtility.HtmlDecode("&nbsp;&nbsp;<img src='images/" + bullet + "' class='icon' style='width:13px' />&nbsp;");
            string sStr = "";
            if (level > 0)
            {
                sSpace = HttpUtility.HtmlDecode(sSpace);
                for (int m = 0; m < level; m++)
                {
                    sStr = sStr + sSpace;
                }
            }
            sStr = sStr + str;
            DataTable subtable = new DataTable();
            using (SqlConnection connection = base.GetConnection())
            {
                SqlCommand command = new SqlCommand("_CateGetGroup", connection) {
                    CommandType = CommandType.StoredProcedure
                };
                command.Parameters.AddWithValue("@CateNewsID", cID);
                command.Parameters.AddWithValue("@Language", language);
                command.Parameters.AddWithValue("@GroupCate", group);
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
                        rs["CateNewsID"] = subrow["CateNewsID"].ToString();
                        rs["ParentNewsID"] = subrow["ParentNewsID"].ToString();
                        rs["CateNewsName"] = sStr + subrow["CateNewsName"].ToString();
                        rs["CateNewsTotal"] = subrow["CateNewsTotal"].ToString();
                        rs["CateNewsOrder"] = subrow["CateNewsOrder"].ToString();
                        rs["Language"] = subrow["Language"].ToString();
                        rs["GroupCate"] = subrow["GroupCate"].ToString();
                        rs["Icon"] = subrow["Icon"].ToString();
                        rs["Slogan"] = subrow["Slogan"].ToString();
                        rs["Roles"] = subrow["Roles"].ToString();
                        rs["UserName"] = subrow["UserName"].ToString();
                        rs["Created"] = subrow["Created"].ToString();
                        table.Rows.Add(rs);
                        this.GetParentGroupBullet(table, Convert.ToInt32(rs["CateNewsID"]), language, level + 1, "&nbsp;&nbsp;&nbsp;", group, bullet);
                    }
                }
            }
        }

        private void GetParentGroupRoles(DataTable table, int cID, string language, int level, string sSpace, int group, string username)
        {
            SqlConnection connection;
            SqlCommand command;
            SqlDataAdapter adapter;
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
            if (username.Equals("administrator"))
            {
                using (connection = base.GetConnection())
                {
                    command = new SqlCommand {
                        CommandText = "_CateGetGroup",
                        Connection = connection,
                        CommandType = CommandType.StoredProcedure
                    };
                    command.Parameters.AddWithValue("@CateNewsID", cID);
                    command.Parameters.AddWithValue("@Language", language);
                    command.Parameters.AddWithValue("@GroupCate", group);
                    connection.Open();
                    using (adapter = new SqlDataAdapter(command))
                    {
                        adapter.Fill(subtable);
                        command.Dispose();
                    }
                }
            }
            else
            {
                string strRoles = new AdminRolesDAO().GetRoles(username);
                string strCateID = new CateNewsPermissionDAO().GetCateNewsID(strRoles);
                using (connection = base.GetConnection())
                {
                    string SQL = "SELECT * FROM tblCateNews WHERE [ParentNewsID] = @CateNewsID AND [Language] = @Language  AND [GroupCate]=@GroupCate AND [CateNewsID] in('" + strCateID + "') AND [IsUrl] = 0 ORDER BY CateNewsOrder ASC";
                    command = new SqlCommand(SQL, connection) {
                        CommandText = SQL
                    };
                    command.Parameters.AddWithValue("@CateNewsID", cID);
                    command.Parameters.AddWithValue("@Language", language);
                    command.Parameters.AddWithValue("@GroupCate", group);
                    connection.Open();
                    using (adapter = new SqlDataAdapter(command))
                    {
                        adapter.Fill(subtable);
                        command.Dispose();
                    }
                }
            }
            if (subtable.Rows.Count > 0)
            {
                foreach (DataRow subrow in subtable.Rows)
                {
                    DataRow rs = table.NewRow();
                    rs["CateNewsID"] = subrow["CateNewsID"].ToString();
                    rs["ParentNewsID"] = subrow["ParentNewsID"].ToString();
                    rs["CateNewsName"] = sStr + subrow["CateNewsName"].ToString();
                    rs["CateNewsTotal"] = subrow["CateNewsTotal"].ToString();
                    rs["CateNewsOrder"] = subrow["CateNewsOrder"].ToString();
                    rs["Language"] = subrow["Language"].ToString();
                    rs["GroupCate"] = subrow["GroupCate"].ToString();
                    rs["Icon"] = subrow["Icon"].ToString();
                    rs["Slogan"] = subrow["Slogan"].ToString();
                    rs["Roles"] = subrow["Roles"].ToString();
                    rs["UserName"] = subrow["UserName"].ToString();
                    rs["Created"] = subrow["Created"].ToString();
                    table.Rows.Add(rs);
                    this.GetParentGroupRoles(table, Convert.ToInt32(rs["CateNewsID"]), language, level + 1, sSpace, group, username);
                }
            }
        }

        private void GetParentGroupRolesUrl(DataTable table, int cID, string language, int level, string sSpace, int group, string username)
        {
            SqlConnection connection;
            SqlCommand command;
            SqlDataAdapter adapter;
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
            if (username.Equals("administrator"))
            {
                using (connection = base.GetConnection())
                {
                    command = new SqlCommand {
                        CommandText = "_CateGetGroupUrl",
                        Connection = connection,
                        CommandType = CommandType.StoredProcedure
                    };
                    command.Parameters.AddWithValue("@CateNewsID", cID);
                    command.Parameters.AddWithValue("@Language", language);
                    command.Parameters.AddWithValue("@GroupCate", group);
                    connection.Open();
                    using (adapter = new SqlDataAdapter(command))
                    {
                        adapter.Fill(subtable);
                        command.Dispose();
                    }
                }
            }
            else
            {
                string strRoles = new AdminRolesDAO().GetRoles(username);
                string strCateID = new CateNewsPermissionDAO().GetCateNewsID(strRoles);
                using (connection = base.GetConnection())
                {
                    string SQL = "SELECT * FROM tblCateNews WHERE [ParentNewsID] = @CateNewsID AND [Language] = @Language  AND [GroupCate]=@GroupCate AND [CateNewsID] in('" + strCateID + "') ORDER BY CateNewsOrder ASC";
                    command = new SqlCommand(SQL, connection) {
                        CommandText = SQL
                    };
                    command.Parameters.AddWithValue("@CateNewsID", cID);
                    command.Parameters.AddWithValue("@Language", language);
                    command.Parameters.AddWithValue("@GroupCate", group);
                    connection.Open();
                    using (adapter = new SqlDataAdapter(command))
                    {
                        adapter.Fill(subtable);
                        command.Dispose();
                    }
                }
            }
            if (subtable.Rows.Count > 0)
            {
                foreach (DataRow subrow in subtable.Rows)
                {
                    DataRow rs = table.NewRow();
                    rs["CateNewsID"] = subrow["CateNewsID"].ToString();
                    rs["ParentNewsID"] = subrow["ParentNewsID"].ToString();
                    rs["CateNewsName"] = sStr + subrow["CateNewsName"].ToString();
                    rs["CateNewsTotal"] = subrow["CateNewsTotal"].ToString();
                    rs["CateNewsOrder"] = subrow["CateNewsOrder"].ToString();
                    rs["Language"] = subrow["Language"].ToString();
                    rs["GroupCate"] = subrow["GroupCate"].ToString();
                    rs["Icon"] = subrow["Icon"].ToString();
                    rs["Slogan"] = subrow["Slogan"].ToString();
                    rs["Roles"] = subrow["Roles"].ToString();
                    rs["UserName"] = subrow["UserName"].ToString();
                    rs["Created"] = subrow["Created"].ToString();
                    rs["IsUrl"] = subrow["IsUrl"].ToString();
                    rs["Url"] = subrow["Url"].ToString();
                    table.Rows.Add(rs);
                    this.GetParentGroupRoles(table, Convert.ToInt32(rs["CateNewsID"]), language, level + 1, sSpace, group, username);
                }
            }
        }

        private void GetParentNews(DataTable table, int cID, string language, int level, string sSpace)
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
                SqlCommand command = new SqlCommand("_CateNewsGet", connection) {
                    CommandType = CommandType.StoredProcedure
                };
                command.Parameters.AddWithValue("@CateNewsID", cID);
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
                        rs["CateNewsID"] = subrow["CateNewsID"].ToString();
                        rs["ParentNewsID"] = subrow["ParentNewsID"].ToString();
                        rs["CateNewsName"] = sStr + subrow["CateNewsName"].ToString();
                        rs["CateNewsTotal"] = subrow["CateNewsTotal"].ToString();
                        rs["CateNewsOrder"] = subrow["CateNewsOrder"].ToString();
                        rs["Language"] = subrow["Language"].ToString();
                        rs["GroupCate"] = subrow["GroupCate"].ToString();
                        rs["Icon"] = subrow["Icon"].ToString();
                        rs["Slogan"] = subrow["Slogan"].ToString();
                        rs["Roles"] = subrow["Roles"].ToString();
                        rs["UserName"] = subrow["UserName"].ToString();
                        rs["Created"] = subrow["Created"].ToString();
                        table.Rows.Add(rs);
                        this.GetParentNews(table, Convert.ToInt32(rs["CateNewsID"]), language, level + 1, "&nbsp;&nbsp;");
                    }
                }
            }
        }

        private void GetParentNewsName(DataTable table, int cID, string language, int level, string sSpace)
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
                SqlCommand command = new SqlCommand("_CateNewsGetNameDB", connection) {
                    CommandType = CommandType.StoredProcedure
                };
                command.Parameters.AddWithValue("@CateNewsID", cID);
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
                        rs["CateNewsID"] = subrow["CateNewsID"].ToString();
                        rs["ParentNewsID"] = subrow["ParentNewsID"].ToString();
                        rs["CateNewsName"] = sStr + subrow["CateNewsName"].ToString();
                        rs["CateNewsTotal"] = subrow["CateNewsTotal"].ToString();
                        rs["CateNewsOrder"] = subrow["CateNewsOrder"].ToString();
                        rs["Language"] = subrow["Language"].ToString();
                        rs["GroupCate"] = subrow["GroupCate"].ToString();
                        rs["Icon"] = subrow["Icon"].ToString();
                        rs["Slogan"] = subrow["Slogan"].ToString();
                        rs["Roles"] = subrow["Roles"].ToString();
                        rs["UserName"] = subrow["UserName"].ToString();
                        rs["Created"] = subrow["Created"].ToString();
                        rs["GroupCateName"] = subrow["GroupCateName"].ToString();
                        table.Rows.Add(rs);
                        this.GetParentNewsName(table, Convert.ToInt32(rs["CateNewsID"]), language, level + 1, "&nbsp;&nbsp;&nbsp;&nbsp;");
                    }
                }
            }
        }

        private void GetParentNewsName(DataTable table, int cID, string language, int level, string sSpace, string username)
        {
            SqlConnection connection;
            SqlCommand command;
            SqlDataAdapter adapter;
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
            if (username.Equals("administrator"))
            {
                using (connection = base.GetConnection())
                {
                    command = new SqlCommand("_CateNewsGetNameDB", connection) {
                        CommandType = CommandType.StoredProcedure
                    };
                    command.Parameters.AddWithValue("@CateNewsID", cID);
                    command.Parameters.AddWithValue("@Language", language);
                    connection.Open();
                    using (adapter = new SqlDataAdapter(command))
                    {
                        adapter.Fill(subtable);
                        command.Dispose();
                    }
                }
            }
            else
            {
                string strRoles = new AdminRolesDAO().GetRoles(username);
                string strCateID = new CateNewsPermissionDAO().GetCateNewsID(strRoles);
                using (connection = base.GetConnection())
                {
                    string SQL = "SELECT tblCateNews.*,tblCateNewsGroup.CateNewsGroupName AS GroupCateName FROM tblCateNews INNER JOIN tblCateNewsGroup ON tblCateNews.GroupCate = tblCateNewsGroup.GroupCate WHERE [ParentNewsID] = @CateNewsID AND [Language] = @Language  AND [CateNewsID] in('" + strCateID + "') AND tblCateNews.IsUrl=0 ORDER BY CateNewsOrder ASC";
                    command = new SqlCommand(SQL, connection) {
                        CommandText = SQL
                    };
                    command.Parameters.AddWithValue("@CateNewsID", cID);
                    command.Parameters.AddWithValue("@Language", language);
                    connection.Open();
                    using (adapter = new SqlDataAdapter(command))
                    {
                        adapter.Fill(subtable);
                        command.Dispose();
                    }
                }
            }
            if (subtable.Rows.Count > 0)
            {
                foreach (DataRow subrow in subtable.Rows)
                {
                    DataRow rs = table.NewRow();
                    rs["CateNewsID"] = subrow["CateNewsID"].ToString();
                    rs["ParentNewsID"] = subrow["ParentNewsID"].ToString();
                    rs["CateNewsName"] = sStr + subrow["CateNewsName"].ToString();
                    rs["CateNewsTotal"] = subrow["CateNewsTotal"].ToString();
                    rs["CateNewsOrder"] = subrow["CateNewsOrder"].ToString();
                    rs["Language"] = subrow["Language"].ToString();
                    rs["GroupCate"] = subrow["GroupCate"].ToString();
                    rs["Icon"] = subrow["Icon"].ToString();
                    rs["Slogan"] = subrow["Slogan"].ToString();
                    rs["Roles"] = subrow["Roles"].ToString();
                    rs["UserName"] = subrow["UserName"].ToString();
                    rs["Created"] = subrow["Created"].ToString();
                    rs["GroupCateName"] = subrow["GroupCateName"].ToString();
                    table.Rows.Add(rs);
                    this.GetParentNewsName(table, Convert.ToInt32(rs["CateNewsID"]), language, level + 1, "&nbsp;&nbsp;&nbsp;&nbsp;", username);
                }
            }
        }

        public void UpdateCateNews(CateNews catenews)
        {
            using (SqlConnection connection = base.GetConnection())
            {
                SqlCommand command = new SqlCommand("_CateNewsUpdate", connection) {
                    CommandType = CommandType.StoredProcedure
                };
                command.Parameters.AddWithValue("@Type", 1);
                command.Parameters.AddWithValue("@CateNewsID", catenews.CateNewsID);
                command.Parameters.AddWithValue("@ParentNewsID", catenews.ParentNewsID);
                command.Parameters.AddWithValue("@CateNewsName", catenews.CateNewsName);
                command.Parameters.AddWithValue("@CateNewsTotal", catenews.CateNewsTotal);
                command.Parameters.AddWithValue("@CateNewsOrder", catenews.CateNewsOrder);
                command.Parameters.AddWithValue("@Language", catenews.Language);
                command.Parameters.AddWithValue("@GroupCate", catenews.GroupCate);
                command.Parameters.AddWithValue("@Icon", catenews.Icon);
                command.Parameters.AddWithValue("@Slogan", catenews.Slogan);
                command.Parameters.AddWithValue("@Roles", catenews.Roles);
                command.Parameters.AddWithValue("@UserName", catenews.UserName);
                command.Parameters.AddWithValue("@Created", catenews.Created);
                command.Parameters.AddWithValue("@Url", catenews.Url);
                command.Parameters.AddWithValue("@isUrl", catenews.isUrl);
                command.Parameters.AddWithValue("@Image", catenews.Image);
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

