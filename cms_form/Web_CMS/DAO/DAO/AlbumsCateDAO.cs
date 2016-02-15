namespace DAO
{
    using ETO;
    using System;
    using System.Data;
    using System.Data.SqlClient;
    using System.Web;

    public class AlbumsCateDAO : BaseDAO
    {
        private AlbumsCate AlbumsCateReader(SqlDataReader reader)
        {
            return new AlbumsCate { AlbumsCateID = (int) reader["AlbumsCateID"], ParentCateID = (int) reader["ParentCateID"], AlbumsCateName = (string) reader["AlbumsCateName"], AlbumsCateTotal = (int) reader["AlbumsCateTotal"], AlbumsCateOrder = (int) reader["AlbumsCateOrder"], ImageThumb = (string) reader["ImageThumb"], ImageLarge = (string) reader["ImageLarge"], Description = (string) reader["Description"], UserName = (string) reader["UserName"], Created = (DateTime) reader["Created"] };
        }

        public void AlbumsCateUpOrder(int cId, int cOrder)
        {
            using (SqlConnection connection = base.GetConnection())
            {
                SqlCommand command = new SqlCommand("_AlbumsCateUpOrder", connection) {
                    CommandType = CommandType.StoredProcedure
                };
                command.Parameters.AddWithValue("@AlbumsCateID", cId);
                command.Parameters.AddWithValue("@AlbumsCateOrder", cOrder);
                connection.Open();
                if (command.ExecuteNonQuery() <= 0)
                {
                    throw new DataAccessException("Kh\x00f4ng thể cập nhật danh mục tin");
                }
                command.Dispose();
            }
        }

        public void CreateAlbumsCate(AlbumsCate albumscate)
        {
            using (SqlConnection connection = base.GetConnection())
            {
                SqlCommand command = new SqlCommand("_AlbumsCateUpdate", connection) {
                    CommandType = CommandType.StoredProcedure
                };
                command.Parameters.AddWithValue("@Type", 0);
                command.Parameters.AddWithValue("@AlbumsCateID", 0);
                command.Parameters.AddWithValue("@ParentCateID", albumscate.ParentCateID);
                command.Parameters.AddWithValue("@AlbumsCateName", albumscate.AlbumsCateName);
                command.Parameters.AddWithValue("@AlbumsCateTotal", albumscate.AlbumsCateTotal);
                command.Parameters.AddWithValue("@AlbumsCateOrder", albumscate.AlbumsCateOrder);
                command.Parameters.AddWithValue("@ImageThumb", albumscate.ImageThumb);
                command.Parameters.AddWithValue("@ImageLarge", albumscate.ImageLarge);
                command.Parameters.AddWithValue("@Description", albumscate.Description);
                command.Parameters.AddWithValue("@UserName", albumscate.UserName);
                command.Parameters.AddWithValue("@Created", albumscate.Created);
                connection.Open();
                if (command.ExecuteNonQuery() <= 0)
                {
                    throw new DataAccessException("Kh\x00f4ng thể tạo danh mục tin");
                }
                command.Dispose();
            }
        }

        public void DeleteAlbumsCate(int cId)
        {
            using (SqlConnection connection = base.GetConnection())
            {
                SqlCommand command = new SqlCommand("_AlbumsCateDelete", connection) {
                    CommandType = CommandType.StoredProcedure
                };
                command.Parameters.AddWithValue("@AlbumsCateID", cId);
                connection.Open();
                if (command.ExecuteNonQuery() <= 0)
                {
                    throw new DataAccessException("Kh\x00f4ng thể x\x00f3a danh mục tin");
                }
                command.Dispose();
            }
        }

        public DataTable GetAlbumsCate()
        {
            DataTable datatable = new DataTable();
            datatable.Columns.Add("AlbumsCateID");
            datatable.Columns.Add("ParentCateID");
            datatable.Columns.Add("AlbumsCateName");
            datatable.Columns.Add("AlbumsCateTotal");
            datatable.Columns.Add("AlbumsCateOrder");
            datatable.Columns.Add("ImageThumb");
            datatable.Columns.Add("ImageLarge");
            datatable.Columns.Add("Description");
            datatable.Columns.Add("UserName");
            datatable.Columns.Add("Created");
            DataTable table = new DataTable();
            using (SqlConnection connection = base.GetConnection())
            {
                SqlCommand command = new SqlCommand("_AlbumsCateGet", connection) {
                    CommandType = CommandType.StoredProcedure
                };
                command.Parameters.AddWithValue("@AlbumsCateID", 0);
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
                    datarow["AlbumsCateID"] = row["AlbumsCateID"].ToString();
                    datarow["ParentCateID"] = row["ParentCateID"].ToString();
                    datarow["AlbumsCateName"] = row["AlbumsCateName"].ToString();
                    datarow["AlbumsCateTotal"] = row["AlbumsCateTotal"].ToString();
                    datarow["AlbumsCateOrder"] = row["AlbumsCateOrder"].ToString();
                    datarow["ImageThumb"] = row["ImageThumb"].ToString();
                    datarow["ImageLarge"] = row["ImageLarge"].ToString();
                    datarow["Description"] = row["Description"].ToString();
                    datarow["UserName"] = row["UserName"].ToString();
                    datarow["Created"] = row["Created"].ToString();
                    datatable.Rows.Add(datarow);
                    this.GetParentCate(datatable, Convert.ToInt32(datarow["AlbumsCateID"]), 1, "&nbsp;&nbsp;");
                }
            }
            return datatable;
        }

        public AlbumsCate GetAlbumsCateById(int cId)
        {
            AlbumsCate albumscate = null;
            using (SqlConnection connection = base.GetConnection())
            {
                SqlCommand command = new SqlCommand("_AlbumsCateById", connection) {
                    CommandType = CommandType.StoredProcedure
                };
                command.Parameters.AddWithValue("@AlbumsCateID", cId);
                connection.Open();
                using (SqlDataReader reader = command.ExecuteReader(CommandBehavior.CloseConnection))
                {
                    if (!reader.Read())
                    {
                        throw new DataAccessException("Kh\x00f4ng t\x00ecm thấy danh mục");
                    }
                    albumscate = this.AlbumsCateReader(reader);
                    command.Dispose();
                }
            }
            return albumscate;
        }

        public DataTable GetCateGroupBullet(string bullet)
        {
            string sSpace = HttpUtility.HtmlDecode("<img src='images/" + bullet + "' class='icon' style='width:13px' />&nbsp;<b>");
            string sSpace1 = HttpUtility.HtmlDecode("</b>");
            DataTable datatable = new DataTable();
            datatable.Columns.Add("AlbumsCateID");
            datatable.Columns.Add("ParentCateID");
            datatable.Columns.Add("AlbumsCateName");
            datatable.Columns.Add("AlbumsCateTotal");
            datatable.Columns.Add("AlbumsCateOrder");
            datatable.Columns.Add("ImageThumb");
            datatable.Columns.Add("ImageLarge");
            datatable.Columns.Add("Description");
            datatable.Columns.Add("UserName");
            datatable.Columns.Add("Created");
            DataTable table = new DataTable();
            using (SqlConnection connection = base.GetConnection())
            {
                SqlCommand command = new SqlCommand("_AlbumsCateGet", connection) {
                    CommandType = CommandType.StoredProcedure
                };
                command.Parameters.AddWithValue("@AlbumsCateID", 0);
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
                    datarow["AlbumsCateID"] = row["AlbumsCateID"].ToString();
                    datarow["ParentCateID"] = row["ParentCateID"].ToString();
                    datarow["AlbumsCateName"] = sSpace + row["AlbumsCateName"].ToString() + sSpace1;
                    datarow["AlbumsCateTotal"] = row["AlbumsCateTotal"].ToString();
                    datarow["AlbumsCateOrder"] = row["AlbumsCateOrder"].ToString();
                    datarow["ImageThumb"] = row["ImageThumb"].ToString();
                    datarow["ImageLarge"] = row["ImageLarge"].ToString();
                    datarow["Description"] = row["Description"].ToString();
                    datarow["UserName"] = row["UserName"].ToString();
                    datarow["Created"] = row["Created"].ToString();
                    datatable.Rows.Add(datarow);
                    this.GetParentGroupBullet(datatable, Convert.ToInt32(datarow["AlbumsCateID"]), 1, "&nbsp;&nbsp;&nbsp;", bullet);
                }
            }
            return datatable;
        }

        private void GetParentCate(DataTable table, int cID, int level, string sSpace)
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
                SqlCommand command = new SqlCommand("_AlbumsCateGet", connection) {
                    CommandType = CommandType.StoredProcedure
                };
                command.Parameters.AddWithValue("@AlbumsCateID", cID);
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
                        rs["AlbumsCateID"] = subrow["AlbumsCateID"].ToString();
                        rs["ParentCateID"] = subrow["ParentCateID"].ToString();
                        rs["AlbumsCateName"] = sStr + subrow["AlbumsCateName"].ToString();
                        rs["AlbumsCateTotal"] = subrow["AlbumsCateTotal"].ToString();
                        rs["AlbumsCateOrder"] = subrow["AlbumsCateOrder"].ToString();
                        rs["ImageThumb"] = subrow["ImageThumb"].ToString();
                        rs["ImageLarge"] = subrow["ImageLarge"].ToString();
                        rs["Description"] = subrow["Description"].ToString();
                        rs["UserName"] = subrow["UserName"].ToString();
                        rs["Created"] = subrow["Created"].ToString();
                        table.Rows.Add(rs);
                        this.GetParentCate(table, Convert.ToInt32(rs["AlbumsCateID"]), level + 1, "&nbsp;&nbsp;");
                    }
                }
            }
        }

        private void GetParentGroupBullet(DataTable table, int cID, int level, string sSpace, string bullet)
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
                SqlCommand command = new SqlCommand("_AlbumsCateGet", connection) {
                    CommandType = CommandType.StoredProcedure
                };
                command.Parameters.AddWithValue("@AlbumsCateID", cID);
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
                        rs["AlbumsCateID"] = subrow["AlbumsCateID"].ToString();
                        rs["ParentCateID"] = subrow["ParentCateID"].ToString();
                        rs["AlbumsCateName"] = sStr + subrow["AlbumsCateName"].ToString();
                        rs["AlbumsCateTotal"] = subrow["AlbumsCateTotal"].ToString();
                        rs["AlbumsCateOrder"] = subrow["AlbumsCateOrder"].ToString();
                        rs["ImageThumb"] = subrow["ImageThumb"].ToString();
                        rs["ImageLarge"] = subrow["ImageLarge"].ToString();
                        rs["Description"] = subrow["Description"].ToString();
                        rs["UserName"] = subrow["UserName"].ToString();
                        rs["Created"] = subrow["Created"].ToString();
                        table.Rows.Add(rs);
                        this.GetParentGroupBullet(table, Convert.ToInt32(rs["AlbumsCateID"]), level + 1, "&nbsp;&nbsp;&nbsp;", bullet);
                    }
                }
            }
        }

        public void UpdateAlbumsCate(AlbumsCate albumscate)
        {
            using (SqlConnection connection = base.GetConnection())
            {
                SqlCommand command = new SqlCommand("_AlbumsCateUpdate", connection) {
                    CommandType = CommandType.StoredProcedure
                };
                command.Parameters.AddWithValue("@Type", 1);
                command.Parameters.AddWithValue("@AlbumsCateID", albumscate.AlbumsCateID);
                command.Parameters.AddWithValue("@ParentCateID", albumscate.ParentCateID);
                command.Parameters.AddWithValue("@AlbumsCateName", albumscate.AlbumsCateName);
                command.Parameters.AddWithValue("@AlbumsCateTotal", albumscate.AlbumsCateTotal);
                command.Parameters.AddWithValue("@AlbumsCateOrder", albumscate.AlbumsCateOrder);
                command.Parameters.AddWithValue("@ImageThumb", albumscate.ImageThumb);
                command.Parameters.AddWithValue("@ImageLarge", albumscate.ImageLarge);
                command.Parameters.AddWithValue("@Description", albumscate.Description);
                command.Parameters.AddWithValue("@UserName", albumscate.UserName);
                command.Parameters.AddWithValue("@Created", albumscate.Created);
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

