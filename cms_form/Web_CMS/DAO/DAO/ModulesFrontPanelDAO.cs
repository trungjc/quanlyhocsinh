namespace DAO
{
    using ETO;
    using System;
    using System.Data;
    using System.Data.SqlClient;
    using System.Web;

    public class ModulesFrontPanelDAO : BaseDAO
    {
        public int CreateModulesFrontPanel(ModulesFrontPanel modulesFrontPanel)
        {
            using (SqlConnection connection = base.GetConnection())
            {
                SqlCommand command = new SqlCommand("_ModulesFrontPanelUpdate", connection)
                {
                    CommandType = CommandType.StoredProcedure
                };
                command.Parameters.AddWithValue("@Type", 0);
                command.Parameters.AddWithValue("@ModulesFrontPanel_ID", 1);
                command.Parameters.AddWithValue("@ModulesFrontPanel_Name", modulesFrontPanel.ModulesFrontPanelName);
                command.Parameters.AddWithValue("@ModulesFrontPanel_Parent", modulesFrontPanel.ModulesFrontPanelParent);
                command.Parameters.AddWithValue("@ModulesFrontPanel_Url", modulesFrontPanel.ModulesFrontPanelUrl);
                command.Parameters.AddWithValue("@ModulesFrontPanel_Order", modulesFrontPanel.ModulesFrontPanelOrder);
                command.Parameters.AddWithValue("@ModulesFrontPanel_Help", modulesFrontPanel.ModulesFrontPanelHelp);
                command.Parameters.AddWithValue("@ModulesFrontPanel_Icon", modulesFrontPanel.ModulesFrontPanelIcon);
                command.Parameters.AddWithValue("@ModulesFrontPanel_Title", modulesFrontPanel.ModulesFrontPanelTitle);
                command.Parameters.AddWithValue("@ModulesFrontPanel_Value", modulesFrontPanel.ModulesFrontPanelValue);
                command.Parameters.AddWithValue("@ModulesFrontPanel_Record", modulesFrontPanel.ModulesFrontPanelRecord);
                command.Parameters.AddWithValue("@ModulesFrontPanel_Status", modulesFrontPanel.ModulesFrontPanelStatus);
                command.Parameters.AddWithValue("@ModulesFrontPanel_Panel", modulesFrontPanel.ModulesFrontPanelPanel);
                command.Parameters.AddWithValue("@ModulesFontPanel_Content", modulesFrontPanel.ModulesFontPanelContent);
                command.Parameters.AddWithValue("@language", modulesFrontPanel.Language);
                connection.Open();
                return command.ExecuteNonQuery();
            }
        }

        public void DeleteModulesFrontPanel(int ID)
        {
            using (SqlConnection connection = base.GetConnection())
            {
                SqlCommand command = new SqlCommand("_ModulesFrontPanelDelete", connection)
                {
                    CommandType = CommandType.StoredProcedure
                };
                command.Parameters.AddWithValue("@ModulesFrontPanel_ID", ID);
                connection.Open();
                if (command.ExecuteNonQuery() <= 0)
                {
                    throw new DataAccessException("Loi he thong");
                }
            }
        }

        public DataTable GetAllModulesFrontPanel()
        {
            DataTable table = new DataTable();
            using (SqlConnection connection = base.GetConnection())
            {
                SqlCommand command = new SqlCommand("_ModulesFrontPanelGetAll", connection)
                {
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

        public ModulesFrontPanel GetModulesFrontPanelById(int ID)
        {
            using (SqlConnection connection = base.GetConnection())
            {
                SqlCommand command = new SqlCommand("_ModulesFrontPanelGetById", connection)
                {
                    CommandType = CommandType.StoredProcedure
                };
                command.Parameters.AddWithValue("@ModulesFrontPanel_ID", ID);
                connection.Open();
                using (SqlDataReader reader = command.ExecuteReader(CommandBehavior.CloseConnection))
                {
                    if (!reader.Read())
                    {
                        throw new DataAccessException("Lỗi : Kh\x00f4ng t\x00ecm thấy gi\x00e1 trị .. ");
                    }
                    return this.ModulesFrontPanelReader(reader);
                }
            }
        }

        public DataTable GetModulesFrontPanelByParent(int cID)
        {
            DataTable table = new DataTable();
            using (SqlConnection connection = base.GetConnection())
            {
                SqlCommand command = new SqlCommand("_ModulesFrontPanelGetByParent", connection)
                {
                    CommandType = CommandType.StoredProcedure
                };
                command.Parameters.AddWithValue("@ModulesFrontPanel_ID", cID);
                connection.Open();
                using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                {
                    adapter.Fill(table);
                    command.Dispose();
                }
                return table;
            }
        }

        public ModulesFrontPanel GetModulesFrontPanelByUrl(string url)
        {
            using (SqlConnection connection = base.GetConnection())
            {
                SqlCommand command = new SqlCommand("_ModulesFrontPanelGetByUrl", connection)
                {
                    CommandType = CommandType.StoredProcedure
                };
                command.Parameters.AddWithValue("@ModulesFrontPanel_Url", url);
                connection.Open();
                using (SqlDataReader reader = command.ExecuteReader(CommandBehavior.CloseConnection))
                {
                    if (!reader.Read())
                    {
                        throw new DataAccessException("Lỗi : Kh\x00f4ng t\x00ecm thấy gi\x00e1 trị .. ");
                    }
                    return this.ModulesFrontPanelReader(reader);
                }
            }
        }

        public DataTable MixModulesFrontPanel()
        {
            DataTable table1 = new DataTable();
            table1.Columns.Add("ModulesFrontPanel_ID");
            table1.Columns.Add("ModulesFrontPanel_Parent");
            table1.Columns.Add("ModulesFrontPanel_Name");
            table1.Columns.Add("ModulesFrontPanel_Url");
            table1.Columns.Add("ModulesFrontPanel_Order");
            table1.Columns.Add("ModulesFrontPanel_Help");
            table1.Columns.Add("ModulesFrontPanel_Icon");
            table1.Columns.Add("ModulesFrontPanel_Title");
            table1.Columns.Add("ModulesFrontPanel_Value");
            table1.Columns.Add("ModulesFrontPanel_Record");
            table1.Columns.Add("ModulesFrontPanel_Status");
            table1.Columns.Add("ModulesFrontPanel_Panel");

            DataTable table2 = this.GetModulesFrontPanelByParent(0);
            foreach (DataRow r2 in table2.Rows)
            {
                DataRow r1 = table1.NewRow();
                r1["ModulesFrontPanel_ID"] = r2["ModulesFrontPanel_ID"].ToString().Trim();
                r1["ModulesFrontPanel_Parent"] = r2["ModulesFrontPanel_Parent"].ToString().Trim();
                r1["ModulesFrontPanel_Name"] = r2["ModulesFrontPanel_Name"].ToString().Trim();
                r1["ModulesFrontPanel_Url"] = r2["ModulesFrontPanel_Url"].ToString().Trim();
                r1["ModulesFrontPanel_Order"] = r2["ModulesFrontPanel_Order"].ToString().Trim();
                r1["ModulesFrontPanel_Help"] = r2["ModulesFrontPanel_Help"].ToString().Trim();
                r1["ModulesFrontPanel_Icon"] = r2["ModulesFrontPanel_Icon"].ToString().Trim();
                r1["ModulesFrontPanel_Title"] = r2["ModulesFrontPanel_Title"].ToString().Trim();
                r1["ModulesFrontPanel_Value"] = r2["ModulesFrontPanel_Value"].ToString().Trim();
                r1["ModulesFrontPanel_Record"] = r2["ModulesFrontPanel_Record"].ToString().Trim();
                r1["ModulesFrontPanel_Status"] = r2["ModulesFrontPanel_Status"].ToString().Trim();
                r1["ModulesFrontPanel_Panel"] = r2["ModulesFrontPanel_Panel"].ToString().Trim();

                table1.Rows.Add(r1);
                this.SubMixModulesFrontPanel(table1, Convert.ToInt32(r1["ModulesFrontPanel_ID"]), "");
            }
            return table1;
        }
        public DataTable MixModulesFrontPanel_lag_vitri()
        {
            DataTable table1 = new DataTable();
            table1.Columns.Add("ModulesFrontPanel_ID");
            table1.Columns.Add("ModulesFrontPanel_Parent");
            table1.Columns.Add("ModulesFrontPanel_Name");
            table1.Columns.Add("ModulesFrontPanel_Url");
            table1.Columns.Add("ModulesFrontPanel_Order");
            table1.Columns.Add("ModulesFrontPanel_Help");
            table1.Columns.Add("ModulesFrontPanel_Icon");
            table1.Columns.Add("ModulesFrontPanel_Title");
            table1.Columns.Add("ModulesFrontPanel_Value");
            table1.Columns.Add("ModulesFrontPanel_Record");
            table1.Columns.Add("ModulesFrontPanel_Status");
            table1.Columns.Add("ModulesFrontPanel_Panel");
            table1.Columns.Add("language");
            //DataTable table2 = this.GetModulesFrontPanelByParent(0);
            DataTable table2 = this.GetAllModulesFrontPanel();
            foreach (DataRow r2 in table2.Rows)
            {
                DataRow r1 = table1.NewRow();
                r1["ModulesFrontPanel_ID"] = r2["ModulesFrontPanel_ID"].ToString().Trim();
                r1["ModulesFrontPanel_Parent"] = r2["ModulesFrontPanel_Parent"].ToString().Trim();
                r1["ModulesFrontPanel_Name"] = r2["ModulesFrontPanel_Name"].ToString().Trim();
                r1["ModulesFrontPanel_Url"] = r2["ModulesFrontPanel_Url"].ToString().Trim();
                r1["ModulesFrontPanel_Order"] = r2["ModulesFrontPanel_Order"].ToString().Trim();
                r1["ModulesFrontPanel_Help"] = r2["ModulesFrontPanel_Help"].ToString().Trim();
                r1["ModulesFrontPanel_Icon"] = r2["ModulesFrontPanel_Icon"].ToString().Trim();
                r1["ModulesFrontPanel_Title"] = r2["ModulesFrontPanel_Title"].ToString().Trim();
                r1["ModulesFrontPanel_Value"] = r2["ModulesFrontPanel_Value"].ToString().Trim();
                r1["ModulesFrontPanel_Record"] = r2["ModulesFrontPanel_Record"].ToString().Trim();
                r1["ModulesFrontPanel_Status"] = r2["ModulesFrontPanel_Status"].ToString().Trim();
                r1["ModulesFrontPanel_Panel"] = r2["ModulesFrontPanel_Panel"].ToString().Trim();
                r1["language"] = r2["language"].ToString().Trim();
                table1.Rows.Add(r1);
                this.SubMixModulesFrontPanel(table1, Convert.ToInt32(r1["ModulesFrontPanel_ID"]), "");
            }
            return table1;
        }

        private ModulesFrontPanel ModulesFrontPanelReader(SqlDataReader reader)
        {
            return new ModulesFrontPanel
            {
                ModulesFrontPanelID = (int)reader["ModulesFrontPanel_ID"],
                ModulesFrontPanelName = (string)reader["ModulesFrontPanel_Name"],
                ModulesFrontPanelOrder = (int)reader["ModulesFrontPanel_Order"],
                ModulesFrontPanelParent = (int)reader["ModulesFrontPanel_Parent"],
                ModulesFrontPanelUrl = (string)reader["ModulesFrontPanel_Url"],
                ModulesFrontPanelHelp = (string)reader["ModulesFrontPanel_Help"],
                ModulesFrontPanelIcon = (string)reader["ModulesFrontPanel_Icon"],
                ModulesFrontPanelTitle = (string)reader["ModulesFrontPanel_Title"],
                ModulesFrontPanelValue = (string)reader["ModulesFrontPanel_Value"],
                ModulesFrontPanelRecord = (int)reader["ModulesFrontPanel_Record"],
                ModulesFrontPanelStatus = (bool)reader["ModulesFrontPanel_Status"],
                ModulesFrontPanelPanel = (string)reader["ModulesFrontPanel_Panel"],
                ModulesFontPanelContent=(string)reader["ModulesFontPanel_Content"],
                Language = (string)reader["language"]
            };
        }

        public void ModulesFrontPanelUpOrder(int cId, int cOrder)
        {
            using (SqlConnection connection = base.GetConnection())
            {
                SqlCommand command = new SqlCommand("_ModulesFrontPanelUpOrder", connection)
                {
                    CommandType = CommandType.StoredProcedure
                };
                command.Parameters.AddWithValue("@ModulesFrontPanelID", cId);
                command.Parameters.AddWithValue("@ModulesFrontPanelOrder", cOrder);
                connection.Open();
                if (command.ExecuteNonQuery() <= 0)
                {
                    throw new DataAccessException("Kh\x00f4ng thể cập nhật danh mục tin");
                }
                command.Dispose();
            }
        }

        public void SubMixModulesFrontPanel(DataTable table, int mID, string sSpace)
        {
            string str = HttpUtility.HtmlDecode("&nbsp;&nbsp;&nbsp;--&nbsp;");
            sSpace = sSpace + str;
            DataTable subTable = new DataTable();
            using (SqlConnection connection = base.GetConnection())
            {
                SqlCommand command = new SqlCommand("_ModulesFrontPanelGetByParent", connection)
                {
                    CommandType = CommandType.StoredProcedure
                };
                command.Parameters.AddWithValue("@ModulesFrontPanel_ID", mID);
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
                        rs["ModulesFrontPanel_ID"] = subrow["ModulesFrontPanel_ID"].ToString().Trim();
                        rs["ModulesFrontPanel_Parent"] = subrow["ModulesFrontPanel_Parent"].ToString().Trim();
                        rs["ModulesFrontPanel_Name"] = sSpace + subrow["ModulesFrontPanel_Name"].ToString().Trim();
                        rs["ModulesFrontPanel_Url"] = subrow["ModulesFrontPanel_Url"].ToString().Trim();
                        rs["ModulesFrontPanel_Order"] = subrow["ModulesFrontPanel_Order"].ToString().Trim();
                        rs["ModulesFrontPanel_Help"] = subrow["ModulesFrontPanel_Help"].ToString().Trim();
                        rs["ModulesFrontPanel_Icon"] = subrow["ModulesFrontPanel_Icon"].ToString().Trim();
                        rs["ModulesFrontPanel_Title"] = subrow["ModulesFrontPanel_Title"].ToString().Trim();
                        rs["ModulesFrontPanel_Value"] = subrow["ModulesFrontPanel_Value"].ToString().Trim();
                        rs["ModulesFrontPanel_Record"] = subrow["ModulesFrontPanel_Record"].ToString().Trim();
                        rs["ModulesFrontPanel_Status"] = subrow["ModulesFrontPanel_Status"].ToString().Trim();
                        rs["ModulesFrontPanel_Panel"] = subrow["ModulesFrontPanel_Panel"].ToString().Trim();
                        table.Rows.Add(rs);
                        this.SubMixModulesFrontPanel(table, Convert.ToInt32(rs["ModulesFrontPanel_ID"]), "");
                    }
                }
            }
        }

        public int UpdateModulesFrontPanel(ModulesFrontPanel modulesFrontPanel)
        {
            using (SqlConnection connection = base.GetConnection())
            {
                SqlCommand command = new SqlCommand("_ModulesFrontPanelUpdate", connection)
                {
                    CommandType = CommandType.StoredProcedure
                };
                command.Parameters.AddWithValue("@Type", 1);
                command.Parameters.AddWithValue("@ModulesFrontPanel_ID", modulesFrontPanel.ModulesFrontPanelID);
                command.Parameters.AddWithValue("@ModulesFrontPanel_Name", modulesFrontPanel.ModulesFrontPanelName);
                command.Parameters.AddWithValue("@ModulesFrontPanel_Parent", modulesFrontPanel.ModulesFrontPanelParent);
                command.Parameters.AddWithValue("@ModulesFrontPanel_Url", modulesFrontPanel.ModulesFrontPanelUrl);
                command.Parameters.AddWithValue("@ModulesFrontPanel_Order", modulesFrontPanel.ModulesFrontPanelOrder);
                command.Parameters.AddWithValue("@ModulesFrontPanel_Help", modulesFrontPanel.ModulesFrontPanelHelp);
                command.Parameters.AddWithValue("@ModulesFrontPanel_Icon", modulesFrontPanel.ModulesFrontPanelIcon);
                command.Parameters.AddWithValue("@ModulesFrontPanel_Title", modulesFrontPanel.ModulesFrontPanelTitle);
                command.Parameters.AddWithValue("@ModulesFrontPanel_Value", modulesFrontPanel.ModulesFrontPanelValue);
                command.Parameters.AddWithValue("@ModulesFrontPanel_Record", modulesFrontPanel.ModulesFrontPanelRecord);
                command.Parameters.AddWithValue("@ModulesFrontPanel_Status", modulesFrontPanel.ModulesFrontPanelStatus);
                command.Parameters.AddWithValue("@ModulesFrontPanel_Panel", modulesFrontPanel.ModulesFrontPanelPanel);
                command.Parameters.AddWithValue("@ModulesFontPanel_Content", modulesFrontPanel.ModulesFontPanelContent);
                command.Parameters.AddWithValue("@language", modulesFrontPanel.Language);
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

