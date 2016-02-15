namespace DAO
{
    using ETO;
    using System;
    using System.Data;
    using System.Data.SqlClient;
    using System.Web;

    public class ModulesDAO : BaseDAO
    {
        public int CreateModules(Modules modules)
        {
            using (SqlConnection connection = base.GetConnection())
            {
                SqlCommand command = new SqlCommand("_ModulesUpdate", connection) {
                    CommandType = CommandType.StoredProcedure
                };
                command.Parameters.AddWithValue("@Type", 0);
                command.Parameters.AddWithValue("@Modules_ID", 1);
                command.Parameters.AddWithValue("@Modules_Name", modules.ModulesName);
                command.Parameters.AddWithValue("@Modules_Parent", modules.ModulesParent);
                command.Parameters.AddWithValue("@Modules_Url", modules.ModulesUrl);
                command.Parameters.AddWithValue("@Modules_Order", modules.ModulesOrder);
                command.Parameters.AddWithValue("@Modules_Help", modules.ModulesHelp);
                command.Parameters.AddWithValue("@Modules_Icon", modules.ModulesIcon);
                connection.Open();
                return command.ExecuteNonQuery();
            }
        }

        public void DeleteModules(int ID)
        {
            using (SqlConnection connection = base.GetConnection())
            {
                SqlCommand command = new SqlCommand("_ModulesDelete", connection) {
                    CommandType = CommandType.StoredProcedure
                };
                command.Parameters.AddWithValue("@Modules_ID", ID);
                connection.Open();
                if (command.ExecuteNonQuery() <= 0)
                {
                    throw new DataAccessException("Loi he thong");
                }
            }
        }

        public DataTable GetAllModules()
        {
            DataTable table = new DataTable();
            using (SqlConnection connection = base.GetConnection())
            {
                SqlCommand command = new SqlCommand("_ModulesGetAll", connection) {
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

        public Modules GetModulesById(int ID)
        {
            using (SqlConnection connection = base.GetConnection())
            {
                SqlCommand command = new SqlCommand("_ModulesGetById", connection) {
                    CommandType = CommandType.StoredProcedure
                };
                command.Parameters.AddWithValue("@Modules_ID", ID);
                connection.Open();
                using (SqlDataReader reader = command.ExecuteReader(CommandBehavior.CloseConnection))
                {
                    if (!reader.Read())
                    {
                        throw new DataAccessException("Lỗi : Kh\x00f4ng t\x00ecm thấy gi\x00e1 trị .. ");
                    }
                    return this.ModulesReader(reader);
                }
            }
        }

        public DataTable GetModulesByParent(int cID)
        {
            DataTable table = new DataTable();
            using (SqlConnection connection = base.GetConnection())
            {
                SqlCommand command = new SqlCommand("_ModulesGetByParent", connection) {
                    CommandType = CommandType.StoredProcedure
                };
                command.Parameters.AddWithValue("@Modules_ID", cID);
                connection.Open();
                using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                {
                    adapter.Fill(table);
                    command.Dispose();
                }
                return table;
            }
        }

        public Modules GetModulesByUrl(string url)
        {
            using (SqlConnection connection = base.GetConnection())
            {
                SqlCommand command = new SqlCommand("_ModulesGetByUrl", connection) {
                    CommandType = CommandType.StoredProcedure
                };
                command.Parameters.AddWithValue("@Modules_Url", url);
                connection.Open();
                using (SqlDataReader reader = command.ExecuteReader(CommandBehavior.CloseConnection))
                {
                    if (!reader.Read())
                    {
                        throw new DataAccessException("Lỗi : Kh\x00f4ng t\x00ecm thấy gi\x00e1 trị .. ");
                    }
                    return this.ModulesReader(reader);
                }
            }
        }

        public DataTable MixModules()
        {
            DataTable table1 = new DataTable();
            table1.Columns.Add("Modules_ID");
            table1.Columns.Add("Modules_Parent");
            table1.Columns.Add("Modules_Name");
            table1.Columns.Add("Modules_Url");
            table1.Columns.Add("Modules_Order");
            table1.Columns.Add("Modules_Help");
            table1.Columns.Add("Modules_Icon");
            DataTable table2 = this.GetModulesByParent(0);
            foreach (DataRow r2 in table2.Rows)
            {
                DataRow r1 = table1.NewRow();
                r1["Modules_ID"] = r2["Modules_ID"].ToString().Trim();
                r1["Modules_Parent"] = r2["Modules_Parent"].ToString().Trim();
                r1["Modules_Name"] = r2["Modules_Name"].ToString().Trim();
                r1["Modules_Url"] = r2["Modules_Url"].ToString().Trim();
                r1["Modules_Order"] = r2["Modules_Order"].ToString().Trim();
                r1["Modules_Help"] = r2["Modules_Help"].ToString().Trim();
                r1["Modules_Icon"] = r2["Modules_Icon"].ToString().Trim();
                table1.Rows.Add(r1);
                this.SubMixModules(table1, Convert.ToInt32(r1["Modules_ID"]), "");
            }
            return table1;
        }

        public DataTable MixModulesAdmin()
        {
            DataTable table1 = new DataTable();
            table1.Columns.Add("Modules_ID");
            table1.Columns.Add("Modules_Parent");
            table1.Columns.Add("Modules_Name");
            table1.Columns.Add("Modules_Url");
            table1.Columns.Add("Modules_Order");
            table1.Columns.Add("Modules_Help");
            table1.Columns.Add("Modules_Icon");
            DataTable table2 = this.GetModulesByParent(0);
            foreach (DataRow r2 in table2.Rows)
            {
                DataRow r1 = table1.NewRow();
                r1["Modules_ID"] = r2["Modules_ID"].ToString().Trim();
                r1["Modules_Parent"] = r2["Modules_Parent"].ToString().Trim();
                r1["Modules_Name"] = r2["Modules_Name"].ToString().Trim();
                r1["Modules_Url"] = r2["Modules_Url"].ToString().Trim();
                r1["Modules_Order"] = r2["Modules_Order"].ToString().Trim();
                r1["Modules_Help"] = r2["Modules_Help"].ToString().Trim();
                r1["Modules_Icon"] = r2["Modules_Icon"].ToString().Trim();
                table1.Rows.Add(r1);
                this.SubMixModulesAdmin(table1, Convert.ToInt32(r1["Modules_ID"]), "");
            }
            return table1;
        }

        private Modules ModulesReader(SqlDataReader reader)
        {
            return new Modules { ModulesID = (int) reader["Modules_ID"], ModulesName = (string) reader["Modules_Name"], ModulesOrder = (int) reader["Modules_Order"], ModulesParent = (int) reader["Modules_Parent"], ModulesUrl = (string) reader["Modules_Url"], ModulesHelp = (string) reader["Modules_Help"], ModulesIcon = (string) reader["Modules_Icon"] };
        }

        public void ModulesUpOrder(int cId, int cOrder)
        {
            using (SqlConnection connection = base.GetConnection())
            {
                SqlCommand command = new SqlCommand("_ModulesUpOrder", connection) {
                    CommandType = CommandType.StoredProcedure
                };
                command.Parameters.AddWithValue("@ModulesID", cId);
                command.Parameters.AddWithValue("@ModulesOrder", cOrder);
                connection.Open();
                if (command.ExecuteNonQuery() <= 0)
                {
                    throw new DataAccessException("Kh\x00f4ng thể cập nhật danh mục tin");
                }
                command.Dispose();
            }
        }

        public void SubMixModules(DataTable table, int mID, string sSpace)
        {
            string str = HttpUtility.HtmlDecode("&nbsp;&nbsp;&nbsp;--&nbsp;");
            sSpace = sSpace + str;
            DataTable subTable = new DataTable();
            using (SqlConnection connection = base.GetConnection())
            {
                SqlCommand command = new SqlCommand("_ModulesGetByParent", connection) {
                    CommandType = CommandType.StoredProcedure
                };
                command.Parameters.AddWithValue("@Modules_ID", mID);
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
                        rs["Modules_ID"] = subrow["Modules_ID"].ToString().Trim();
                        rs["Modules_Parent"] = subrow["Modules_Parent"].ToString().Trim();
                        rs["Modules_Name"] = sSpace + subrow["Modules_Name"].ToString().Trim();
                        rs["Modules_Url"] = subrow["Modules_Url"].ToString().Trim();
                        rs["Modules_Order"] = subrow["Modules_Order"].ToString().Trim();
                        rs["Modules_Help"] = subrow["Modules_Help"].ToString().Trim();
                        rs["Modules_Icon"] = subrow["Modules_Icon"].ToString().Trim();
                        table.Rows.Add(rs);
                        this.SubMixModules(table, Convert.ToInt32(rs["Modules_ID"]), HttpUtility.HtmlDecode("&nbsp;&nbsp;&nbsp;&nbsp;"));
                    }
                }
            }
        }

        public void SubMixModulesAdmin(DataTable table, int mID, string sSpace)
        {
            string str = HttpUtility.HtmlDecode("");
            sSpace = sSpace + str;
            DataTable subTable = new DataTable();
            using (SqlConnection connection = base.GetConnection())
            {
                SqlCommand command = new SqlCommand("_ModulesGetByParent", connection) {
                    CommandType = CommandType.StoredProcedure
                };
                command.Parameters.AddWithValue("@Modules_ID", mID);
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
                        rs["Modules_ID"] = subrow["Modules_ID"].ToString().Trim();
                        rs["Modules_Parent"] = subrow["Modules_Parent"].ToString().Trim();
                        rs["Modules_Name"] = sSpace + subrow["Modules_Name"].ToString().Trim();
                        rs["Modules_Url"] = subrow["Modules_Url"].ToString().Trim();
                        rs["Modules_Order"] = subrow["Modules_Order"].ToString().Trim();
                        rs["Modules_Help"] = subrow["Modules_Help"].ToString().Trim();
                        rs["Modules_Icon"] = subrow["Modules_Icon"].ToString().Trim();
                        table.Rows.Add(rs);
                        this.SubMixModulesAdmin(table, Convert.ToInt32(rs["Modules_ID"]), HttpUtility.HtmlDecode(""));
                    }
                }
            }
        }

        public int UpdateModules(Modules modules)
        {
            using (SqlConnection connection = base.GetConnection())
            {
                SqlCommand command = new SqlCommand("_ModulesUpdate", connection) {
                    CommandType = CommandType.StoredProcedure
                };
                command.Parameters.AddWithValue("@Type", 1);
                command.Parameters.AddWithValue("@Modules_ID", modules.ModulesID);
                command.Parameters.AddWithValue("@Modules_Name", modules.ModulesName);
                command.Parameters.AddWithValue("@Modules_Parent", modules.ModulesParent);
                command.Parameters.AddWithValue("@Modules_Url", modules.ModulesUrl);
                command.Parameters.AddWithValue("@Modules_Order", modules.ModulesOrder);
                command.Parameters.AddWithValue("@Modules_Help", modules.ModulesHelp);
                command.Parameters.AddWithValue("@Modules_Icon", modules.ModulesIcon);
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

