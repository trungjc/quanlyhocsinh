namespace DAO
{
    using ETO;
    using System;
    using System.Data;
    using System.Data.SqlClient;
    using System.Web;

    public class MenuLinksDAO : BaseDAO
    {
        public int CreateMenuLinks(MenuLinks menuLinks)
        {
            using (SqlConnection connection = base.GetConnection())
            {
                SqlCommand command = new SqlCommand("_MenuLinksUpdate", connection) {
                    CommandType = CommandType.StoredProcedure
                };
                command.Parameters.AddWithValue("@Type", 0);
                command.Parameters.AddWithValue("@MenuLinksID", 1);
                command.Parameters.AddWithValue("@MenuLinksName", menuLinks.MenuLinksName);
                command.Parameters.AddWithValue("@MenuLinksParent", menuLinks.MenuLinksParent);
                command.Parameters.AddWithValue("@MenuLinksUrl", menuLinks.MenuLinksUrl);
                command.Parameters.AddWithValue("@MenuLinksOrder", menuLinks.MenuLinksOrder);
                command.Parameters.AddWithValue("@MenuLinksHelp", menuLinks.MenuLinksHelp);
                command.Parameters.AddWithValue("@MenuLinksIcon", menuLinks.MenuLinksIcon);
                command.Parameters.AddWithValue("@Status", menuLinks.Status);
                command.Parameters.AddWithValue("@IsView", menuLinks.IsView);
                command.Parameters.AddWithValue("@Target", menuLinks.Target);
                connection.Open();
                return command.ExecuteNonQuery();
            }
        }

        public void DeleteMenuLinks(int ID)
        {
            using (SqlConnection connection = base.GetConnection())
            {
                SqlCommand command = new SqlCommand("_MenuLinksDelete", connection) {
                    CommandType = CommandType.StoredProcedure
                };
                command.Parameters.AddWithValue("@MenuLinksID", ID);
                connection.Open();
                if (command.ExecuteNonQuery() <= 0)
                {
                    throw new DataAccessException("Loi he thong");
                }
                command.Dispose();
            }
        }

        public DataTable GetAllMenuLinks()
        {
            DataTable table = new DataTable();
            using (SqlConnection connection = base.GetConnection())
            {
                SqlCommand command = new SqlCommand("_MenuLinksGetAll", connection) {
                    CommandType = CommandType.StoredProcedure
                };
                connection.Open();
                using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                {
                    adapter.Fill(table);
                    command.Dispose();
                }
                return table;
            }
        }

        public DataTable GetHotMenuLinks()
        {
            DataTable table = new DataTable();
            using (SqlConnection connection = base.GetConnection())
            {
                SqlCommand command = new SqlCommand("_MenuLinksGetHot", connection) {
                    CommandType = CommandType.StoredProcedure
                };
                connection.Open();
                using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                {
                    adapter.Fill(table);
                    command.Dispose();
                }
                return table;
            }
        }

        public DataTable GetHotMenuLinks(int num)
        {
            DataTable datatable = new DataTable();
            using (SqlConnection connection = base.GetConnection())
            {
                string SQL = "select top " + Convert.ToString(num) + " * from tblMenuLinks Where IsView=1 and Status=1 order by MenuLinksOrder ASC";
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

        public MenuLinks GetMenuLinksById(int ID)
        {
            using (SqlConnection connection = base.GetConnection())
            {
                SqlCommand command = new SqlCommand("_MenuLinksGetById", connection) {
                    CommandType = CommandType.StoredProcedure
                };
                command.Parameters.AddWithValue("@MenuLinksID", ID);
                connection.Open();
                using (SqlDataReader reader = command.ExecuteReader(CommandBehavior.CloseConnection))
                {
                    if (!reader.Read())
                    {
                        throw new DataAccessException("Lỗi : Kh\x00f4ng t\x00ecm thấy gi\x00e1 trị .. ");
                    }
                    return this.MenuLinksReader(reader);
                }
            }
        }

        public MenuLinks GetMenuLinksByUrl(string url)
        {
            using (SqlConnection connection = base.GetConnection())
            {
                SqlCommand command = new SqlCommand("_MenuLinksGetByUrl", connection) {
                    CommandType = CommandType.StoredProcedure
                };
                command.Parameters.AddWithValue("@MenuLinksUrl", url);
                connection.Open();
                using (SqlDataReader reader = command.ExecuteReader(CommandBehavior.CloseConnection))
                {
                    if (!reader.Read())
                    {
                        throw new DataAccessException("Lỗi : Kh\x00f4ng t\x00ecm thấy gi\x00e1 trị .. ");
                    }
                    return this.MenuLinksReader(reader);
                }
            }
        }

        private MenuLinks MenuLinksReader(SqlDataReader reader)
        {
            return new MenuLinks { MenuLinksID = (int) reader["MenuLinksID"], MenuLinksName = (string) reader["MenuLinksName"], MenuLinksOrder = (int) reader["MenuLinksOrder"], MenuLinksParent = (int) reader["MenuLinksParent"], MenuLinksUrl = (string) reader["MenuLinksUrl"], MenuLinksHelp = (string) reader["MenuLinksHelp"], MenuLinksIcon = (string) reader["MenuLinksIcon"], Status = (bool) reader["Status"], IsView = (bool) reader["IsView"], Target = (string) reader["Target"] };
        }

        public void MenuLinksUpOrder(int cId, int cOrder)
        {
            using (SqlConnection connection = base.GetConnection())
            {
                SqlCommand command = new SqlCommand("_MenuLinksUpOrder", connection) {
                    CommandType = CommandType.StoredProcedure
                };
                command.Parameters.AddWithValue("@MenuLinksID", cId);
                command.Parameters.AddWithValue("@MenuLinksOrder", cOrder);
                connection.Open();
                if (command.ExecuteNonQuery() <= 0)
                {
                    throw new DataAccessException("Kh\x00f4ng thể cập nhật danh mục tin");
                }
                command.Dispose();
            }
        }

        public DataTable MixMenuLinks()
        {
            DataTable table1 = new DataTable();
            table1.Columns.Add("MenuLinksID");
            table1.Columns.Add("MenuLinksParent");
            table1.Columns.Add("MenuLinksName");
            table1.Columns.Add("MenuLinksUrl");
            table1.Columns.Add("MenuLinksOrder");
            table1.Columns.Add("MenuLinksHelp");
            table1.Columns.Add("MenuLinksIcon");
            table1.Columns.Add("Status");
            table1.Columns.Add("IsView");
            table1.Columns.Add("Target");
            DataTable table2 = this.GetAllMenuLinks();
            foreach (DataRow r2 in table2.Rows)
            {
                DataRow r1 = table1.NewRow();
                r1["MenuLinksID"] = r2["MenuLinksID"].ToString().Trim();
                r1["MenuLinksParent"] = r2["MenuLinksParent"].ToString().Trim();
                r1["MenuLinksName"] = r2["MenuLinksName"].ToString().Trim();
                r1["MenuLinksUrl"] = r2["MenuLinksUrl"].ToString().Trim();
                r1["MenuLinksOrder"] = r2["MenuLinksOrder"].ToString().Trim();
                r1["MenuLinksHelp"] = r2["MenuLinksHelp"].ToString().Trim();
                r1["MenuLinksIcon"] = r2["MenuLinksIcon"].ToString().Trim();
                r1["Status"] = r2["Status"].ToString().Trim();
                r1["IsView"] = r2["IsView"].ToString().Trim();
                r1["Target"] = r2["Target"].ToString().Trim();
                table1.Rows.Add(r1);
                this.SubMixMenuLinks(table1, Convert.ToInt32(r1["MenuLinksID"]), "");
            }
            return table1;
        }

        public DataTable MixMenuLinksBullet(string bullet)
        {
            string sSpace = HttpUtility.HtmlDecode("<img src='images/" + bullet + "' class='icon' style='width:13px' />&nbsp;<b>");
            string sSpace1 = HttpUtility.HtmlDecode("</b>");
            DataTable table1 = new DataTable();
            table1.Columns.Add("MenuLinksID");
            table1.Columns.Add("MenuLinksParent");
            table1.Columns.Add("MenuLinksName");
            table1.Columns.Add("MenuLinksUrl");
            table1.Columns.Add("MenuLinksOrder");
            table1.Columns.Add("MenuLinksHelp");
            table1.Columns.Add("MenuLinksIcon");
            table1.Columns.Add("Status");
            table1.Columns.Add("IsView");
            table1.Columns.Add("Target");
            DataTable table2 = this.GetAllMenuLinks();
            foreach (DataRow r2 in table2.Rows)
            {
                DataRow r1 = table1.NewRow();
                r1["MenuLinksID"] = r2["MenuLinksID"].ToString().Trim();
                r1["MenuLinksParent"] = r2["MenuLinksParent"].ToString().Trim();
                r1["MenuLinksName"] = sSpace + r2["MenuLinksName"].ToString().Trim() + sSpace1;
                r1["MenuLinksUrl"] = r2["MenuLinksUrl"].ToString().Trim();
                r1["MenuLinksOrder"] = r2["MenuLinksOrder"].ToString().Trim();
                r1["MenuLinksHelp"] = r2["MenuLinksHelp"].ToString().Trim();
                r1["MenuLinksIcon"] = r2["MenuLinksIcon"].ToString().Trim();
                r1["Status"] = r2["Status"].ToString().Trim();
                r1["IsView"] = r2["IsView"].ToString().Trim();
                r1["Target"] = r2["Target"].ToString().Trim();
                table1.Rows.Add(r1);
                this.SubMixMenuLinksBullet(table1, Convert.ToInt32(r1["MenuLinksID"]), "", bullet);
            }
            return table1;
        }

        public void SubMixMenuLinks(DataTable table, int mID, string sSpace)
        {
            string str = HttpUtility.HtmlDecode("&nbsp;&nbsp;&nbsp;--&nbsp;");
            sSpace = sSpace + str;
            DataTable subTable = new DataTable();
            using (SqlConnection connection = base.GetConnection())
            {
                SqlCommand command = new SqlCommand("_MenuLinksGetByParent", connection) {
                    CommandType = CommandType.StoredProcedure
                };
                command.Parameters.AddWithValue("@MenuLinksID", mID);
                connection.Open();
                using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                {
                    adapter.Fill(subTable);
                    command.Dispose();
                }
                if (subTable.Rows.Count > 0)
                {
                    foreach (DataRow subrow in subTable.Rows)
                    {
                        DataRow rs = table.NewRow();
                        rs["MenuLinksID"] = subrow["MenuLinksID"].ToString().Trim();
                        rs["MenuLinksParent"] = subrow["MenuLinksParent"].ToString().Trim();
                        rs["MenuLinksName"] = sSpace + subrow["MenuLinksName"].ToString().Trim();
                        rs["MenuLinksUrl"] = subrow["MenuLinksUrl"].ToString().Trim();
                        rs["MenuLinksOrder"] = subrow["MenuLinksOrder"].ToString().Trim();
                        rs["MenuLinksHelp"] = subrow["MenuLinksHelp"].ToString().Trim();
                        rs["MenuLinksIcon"] = subrow["MenuLinksIcon"].ToString().Trim();
                        rs["Status"] = subrow["Status"].ToString().Trim();
                        rs["IsView"] = subrow["IsView"].ToString().Trim();
                        rs["Target"] = subrow["Target"].ToString().Trim();
                        table.Rows.Add(rs);
                        this.SubMixMenuLinks(table, Convert.ToInt32(rs["MenuLinksID"]), "");
                    }
                }
            }
        }

        public void SubMixMenuLinksBullet(DataTable table, int mID, string sSpace, string bullet)
        {
            string str = HttpUtility.HtmlDecode("&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<img src='images/" + bullet + "' class='icon' style='width:13px' />&nbsp;");
            sSpace = sSpace + str;
            DataTable subTable = new DataTable();
            using (SqlConnection connection = base.GetConnection())
            {
                SqlCommand command = new SqlCommand("_MenuLinksGetByParent", connection) {
                    CommandType = CommandType.StoredProcedure
                };
                command.Parameters.AddWithValue("@MenuLinksID", mID);
                connection.Open();
                using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                {
                    adapter.Fill(subTable);
                    command.Dispose();
                }
                if (subTable.Rows.Count > 0)
                {
                    foreach (DataRow subrow in subTable.Rows)
                    {
                        DataRow rs = table.NewRow();
                        rs["MenuLinksID"] = subrow["MenuLinksID"].ToString().Trim();
                        rs["MenuLinksParent"] = subrow["MenuLinksParent"].ToString().Trim();
                        rs["MenuLinksName"] = sSpace + subrow["MenuLinksName"].ToString().Trim();
                        rs["MenuLinksUrl"] = subrow["MenuLinksUrl"].ToString().Trim();
                        rs["MenuLinksOrder"] = subrow["MenuLinksOrder"].ToString().Trim();
                        rs["MenuLinksHelp"] = subrow["MenuLinksHelp"].ToString().Trim();
                        rs["MenuLinksIcon"] = subrow["MenuLinksIcon"].ToString().Trim();
                        rs["Status"] = subrow["Status"].ToString().Trim();
                        rs["IsView"] = subrow["IsView"].ToString().Trim();
                        rs["Target"] = subrow["Target"].ToString().Trim();
                        table.Rows.Add(rs);
                        this.SubMixMenuLinksBullet(table, Convert.ToInt32(rs["MenuLinksID"]), "", bullet);
                    }
                }
            }
        }

        public int UpdateMenuLinks(MenuLinks menuLinks)
        {
            using (SqlConnection connection = base.GetConnection())
            {
                SqlCommand command = new SqlCommand("_MenuLinksUpdate", connection) {
                    CommandType = CommandType.StoredProcedure
                };
                command.Parameters.AddWithValue("@Type", 1);
                command.Parameters.AddWithValue("@MenuLinksID", menuLinks.MenuLinksID);
                command.Parameters.AddWithValue("@MenuLinksName", menuLinks.MenuLinksName);
                command.Parameters.AddWithValue("@MenuLinksParent", menuLinks.MenuLinksParent);
                command.Parameters.AddWithValue("@MenuLinksUrl", menuLinks.MenuLinksUrl);
                command.Parameters.AddWithValue("@MenuLinksOrder", menuLinks.MenuLinksOrder);
                command.Parameters.AddWithValue("@MenuLinksHelp", menuLinks.MenuLinksHelp);
                command.Parameters.AddWithValue("@MenuLinksIcon", menuLinks.MenuLinksIcon);
                command.Parameters.AddWithValue("@Status", menuLinks.Status);
                command.Parameters.AddWithValue("@IsView", menuLinks.IsView);
                command.Parameters.AddWithValue("@Target", menuLinks.Target);
                connection.Open();
                int i = command.ExecuteNonQuery();
                if (i <= 0)
                {
                    throw new DataAccessException("lỗi kh\x00f4ng thể cập nhật");
                }
                return i;
            }
        }
    }
}

