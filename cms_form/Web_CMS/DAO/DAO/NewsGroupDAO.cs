namespace DAO
{
    using ETO;
    using System;
    using System.Data;
    using System.Data.SqlClient;

    public class NewsGroupDAO : BaseDAO
    {
        public void CreateNewsGroup(NewsGroup newsGroup)
        {
            using (SqlConnection connection = base.GetConnection())
            {
                SqlCommand command = new SqlCommand("_NewsGroupUpdate", connection) {
                    CommandType = CommandType.StoredProcedure
                };
                command.Parameters.AddWithValue("@Type", 0);
                command.Parameters.AddWithValue("@NewsGroupID", 0);
                command.Parameters.AddWithValue("@CateNewsID", newsGroup.CateNewsID);
                command.Parameters.AddWithValue("@ParentNewsID", newsGroup.ParentNewsID);
                command.Parameters.AddWithValue("@GroupCate", newsGroup.GroupCate);
                command.Parameters.AddWithValue("@Title", newsGroup.Title);
                command.Parameters.AddWithValue("@ShortDescribe", newsGroup.ShortDescribe);
                command.Parameters.AddWithValue("@FullDescribe", newsGroup.FullDescribe);
                command.Parameters.AddWithValue("@ImageThumb", newsGroup.ImageThumb);
                command.Parameters.AddWithValue("@ImageLarge", newsGroup.ImageLarge);
                command.Parameters.AddWithValue("@FileName", newsGroup.FileName);
                command.Parameters.AddWithValue("@Author", newsGroup.Author);
                command.Parameters.AddWithValue("@PostDate", newsGroup.PostDate);
                command.Parameters.AddWithValue("@RelationTotal", newsGroup.RelationTotal);
                command.Parameters.AddWithValue("@Status", newsGroup.Status);
                command.Parameters.AddWithValue("@Language", newsGroup.Language);
                command.Parameters.AddWithValue("@Ishot", newsGroup.Ishot);
                command.Parameters.AddWithValue("@Isview", newsGroup.Isview);
                command.Parameters.AddWithValue("@Ishome", newsGroup.Ishome);
                command.Parameters.AddWithValue("@TypeNews", newsGroup.TypeNews);
                command.Parameters.AddWithValue("@IsComment", newsGroup.IsComment);
                command.Parameters.AddWithValue("@ApprovalDate", newsGroup.ApprovalDate);
                command.Parameters.AddWithValue("@ApprovalUserName", newsGroup.ApprovalUserName);
                command.Parameters.AddWithValue("@IsApproval", newsGroup.IsApproval);
                command.Parameters.AddWithValue("@CreatedUserName", newsGroup.CreatedUserName);
                command.Parameters.AddWithValue("@CommentTotal", newsGroup.CommentTotal);
                connection.Open();
                if (command.ExecuteNonQuery() <= 0)
                {
                    throw new DataAccessException("Kh\x00f4ng thể th\x00eam mới tin");
                }
                command.Dispose();
            }
        }

        public void DeleteNewsGroup(int Id)
        {
            using (SqlConnection connection = base.GetConnection())
            {
                SqlCommand command = new SqlCommand("_NewsGroupDelete", connection) {
                    CommandType = CommandType.StoredProcedure
                };
                command.Parameters.AddWithValue("NewsGroupID", Id);
                connection.Open();
                if (command.ExecuteNonQuery() <= 0)
                {
                    throw new DataAccessException("Kh\x00f4ng x\x00f3a được tin");
                }
                command.Dispose();
            }
        }

        public void DeleteNewsGroup(string sId)
        {
            using (SqlConnection connection = base.GetConnection())
            {
                string SQL = "delete tblNewsGroup where NewsGroupID in('" + sId + "')";
                SqlCommand command = new SqlCommand(SQL, connection) {
                    CommandText = SQL
                };
                connection.Open();
                if (command.ExecuteNonQuery() <= 0)
                {
                    throw new DataAccessException("Kh\x00f4ng x\x00f3a được tin");
                }
                command.Dispose();
            }
        }

        public DataTable GetNewsGroupAll(string lang)
        {
            DataTable datatable = new DataTable();
            using (SqlConnection connection = base.GetConnection())
            {
                SqlCommand command = new SqlCommand("_NewsGroupGetAll", connection) {
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

        public DataTable GetNewsGroupAll(string lang, int group)
        {
            DataTable datatable = new DataTable();
            using (SqlConnection connection = base.GetConnection())
            {
                SqlCommand command = new SqlCommand("_NewsGroupGetAllGroup", connection) {
                    CommandType = CommandType.StoredProcedure
                };
                command.Parameters.AddWithValue("@Language", lang);
                command.Parameters.AddWithValue("@GroupCate", group);
                connection.Open();
                using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                {
                    adapter.Fill(datatable);
                    command.Dispose();
                }
            }
            return datatable;
        }

        public DataTable GetNewsGroupAll(string lang, int group, string strCate)
        {
            DataTable datatable = new DataTable();
            using (SqlConnection connection = base.GetConnection())
            {
                //string SQL = "select * from tblNewsGroup where Language=@Language And CateNewsID in('" + strCate + "') AND GroupCate = @GroupCate order by PostDate Desc";
                string SQL = "select * from tblNewsGroup where CateNewsID in('" + strCate + "') AND GroupCate = @GroupCate order by PostDate Desc";
                SqlCommand command = new SqlCommand(SQL, connection) {
                    CommandText = SQL
                };
                command.Parameters.AddWithValue("@GroupCate", group);
                //command.Parameters.AddWithValue("@Language", lang);
                connection.Open();
                using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                {
                    adapter.Fill(datatable);
                    command.Dispose();
                }
            }
            return datatable;
        }

        public DataTable GetNewsGroupByCateAll(string strCate)
        {
            DataTable datatable = new DataTable();
            using (SqlConnection connection = base.GetConnection())
            {
                string SQL = "select * from tblNewsGroup where CateNewsID in('" + strCate + "') order by PostDate desc";
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

        public DataTable GetNewsGroupByCateAll(string strCate, int group)
        {
            DataTable datatable = new DataTable();
            using (SqlConnection connection = base.GetConnection())
            {
                string SQL = "select * from tblNewsGroup where CateNewsID in('" + strCate + "') AND [GroupCate] = @GroupCate  order by PostDate desc";
                SqlCommand command = new SqlCommand(SQL, connection) {
                    CommandText = SQL
                };
                command.Parameters.AddWithValue("@GroupCate", group);
                connection.Open();
                using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                {
                    adapter.Fill(datatable);
                    command.Dispose();
                }
            }
            return datatable;
        }

        public DataTable GetNewsGroupByCateHomeAll(string strCate, int group)
        {
            DataTable datatable = new DataTable();
            using (SqlConnection connection = base.GetConnection())
            {
                string SQL = "select * from tblNewsGroup where status=1 and CateNewsID in('" + strCate + "') and GroupCate = @GroupCate order by PostDate Desc";
                SqlCommand command = new SqlCommand(SQL, connection) {
                    CommandText = SQL
                };
                command.Parameters.AddWithValue("@GroupCate", group);
                connection.Open();
                using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                {
                    adapter.Fill(datatable);
                    command.Dispose();
                }
            }
            return datatable;
        }

        public DataTable GetNewsGroupByCateHomeAll(int n, string strCate, int group)
        {
            DataTable datatable = new DataTable();
            using (SqlConnection connection = base.GetConnection())
            {
                string SQL = "select top " + n.ToString() + " * from tblNewsGroup where status=1 and CateNewsID in('" + strCate + "') and [GroupCate] = @GroupCate order by PostDate Desc";
                SqlCommand command = new SqlCommand(SQL, connection);
                command.Parameters.AddWithValue("@GroupCate", group);
                command.CommandText = SQL;
                connection.Open();
                using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                {
                    adapter.Fill(datatable);
                    command.Dispose();
                }
            }
            return datatable;
        }

        public DataTable GetNewsGroupByCateHomeAll(int n, string strCate, string approval, int group)
        {
            DataTable datatable = new DataTable();
            using (SqlConnection connection = base.GetConnection())
            {
                string SQL = "select top " + n.ToString() + " * from tblNewsGroup where status=1 and CateNewsID in('" + strCate + "')  AND [IsApproval] = " + approval + " and [GroupCate] = @GroupCate order by PostDate desc";
                SqlCommand command = new SqlCommand(SQL, connection) {
                    CommandText = SQL
                };
                command.Parameters.AddWithValue("@GroupCate", group);
                connection.Open();
                using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                {
                    adapter.Fill(datatable);
                    command.Dispose();
                }
            }
            return datatable;
        }

        public DataTable GetNewsGroupByCateHomeList(string strCate, int group)
        {
            DataTable datatable = new DataTable();
            using (SqlConnection connection = base.GetConnection())
            {
                string SQL = "select * from tblNewsGroup where CateNewsID in('" + strCate + "') AND GroupCate = @GroupCate AND Status = 1 order by PostDate Desc";
                SqlCommand command = new SqlCommand(SQL, connection) {
                    CommandText = SQL
                };
                command.Parameters.AddWithValue("@GroupCate", group);
                connection.Open();
                using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                {
                    adapter.Fill(datatable);
                    command.Dispose();
                }
            }
            return datatable;
        }

        public DataTable GetNewsGroupByCateHomeList(string strCate, int num, int group)
        {
            DataTable datatable = new DataTable();
            using (SqlConnection connection = base.GetConnection())
            {
                string SQL = "select top " + Convert.ToString(num) + " * from tblNewsGroup where CateNewsID in('" + strCate + "') And GroupCate = @GroupCate order by PostDate Desc";
                SqlCommand command = new SqlCommand(SQL, connection) {
                    CommandText = SQL
                };
                command.Parameters.AddWithValue("@GroupCate", group);
                connection.Open();
                using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                {
                    adapter.Fill(datatable);
                    command.Dispose();
                }
            }
            return datatable;
        }

        public DataTable GetNewsGroupByCateHomeList(string strCate, int group, string approval)
        {
            DataTable datatable = new DataTable();
            using (SqlConnection connection = base.GetConnection())
            {
                string SQL = "select * from tblNewsGroup where CateNewsID in('" + strCate + "') AND GroupCate = @GroupCate AND Status = 1 AND IsApproval = " + approval + " order by PostDate Desc";
                SqlCommand command = new SqlCommand(SQL, connection) {
                    CommandText = SQL
                };
                command.Parameters.AddWithValue("@GroupCate", group);
                connection.Open();
                using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                {
                    adapter.Fill(datatable);
                    command.Dispose();
                }
            }
            return datatable;
        }

        public DataTable GetNewsGroupByCateHomeList(string strCate, int num, string approval, int group)
        {
            DataTable datatable = new DataTable();
            using (SqlConnection connection = base.GetConnection())
            {
                string SQL = "select top " + Convert.ToString(num) + " * from tblNewsGroup where CateNewsID in('" + strCate + "')  AND [IsApproval] = " + approval + " AND [GroupCate] = @GroupCate AND Status = 1 order by PostDate Desc";
                SqlCommand command = new SqlCommand(SQL, connection) {
                    CommandText = SQL
                };
                command.Parameters.AddWithValue("@GroupCate", group);
                connection.Open();
                using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                {
                    adapter.Fill(datatable);
                    command.Dispose();
                }
            }
            return datatable;
        }

        public DataTable GetNewsGroupByCateIsHomeAll(string strCate, int group)
        {
            DataTable datatable = new DataTable();
            using (SqlConnection connection = base.GetConnection())
            {
                string SQL = "select * from tblNewsGroup where status=1 and IsHome = 1 and CateNewsID in('" + strCate + "') and GroupCate = @GroupCate order by PostDate Desc";
                SqlCommand command = new SqlCommand(SQL, connection) {
                    CommandText = SQL
                };
                command.Parameters.AddWithValue("@GroupCate", group);
                connection.Open();
                using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                {
                    adapter.Fill(datatable);
                    command.Dispose();
                }
            }
            return datatable;
        }

        public DataTable GetNewsGroupByCateIsHomeAll(int n, string strCate, int group)
        {
            DataTable datatable = new DataTable();
            using (SqlConnection connection = base.GetConnection())
            {
                string SQL = "select top " + n.ToString() + " * from tblNewsGroup where status=1 and IsHome = 1  and CateNewsID in('" + strCate + "') and [GroupCate] = @GroupCate order by PostDate Desc";
                SqlCommand command = new SqlCommand(SQL, connection);
                command.Parameters.AddWithValue("@GroupCate", group);
                command.CommandText = SQL;
                connection.Open();
                using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                {
                    adapter.Fill(datatable);
                    command.Dispose();
                }
            }
            return datatable;
        }

        public DataTable GetNewsGroupByCateIsHomeAll(int n, string strCate, string approval, int group)
        {
            DataTable datatable = new DataTable();
            using (SqlConnection connection = base.GetConnection())
            {
                string SQL = "select top " + n.ToString() + " * from tblNewsGroup where status=1 and IsHome = 1  and CateNewsID in('" + strCate + "')  AND [IsApproval] = " + approval + " and [GroupCate] = @GroupCate order by PostDate desc";
                SqlCommand command = new SqlCommand(SQL, connection) {
                    CommandText = SQL
                };
                command.Parameters.AddWithValue("@GroupCate", group);
                connection.Open();
                using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                {
                    adapter.Fill(datatable);
                    command.Dispose();
                }
            }
            return datatable;
        }

        public NewsGroup GetNewsGroupById(int Id)
        {
            NewsGroup newsGroup = null;
            using (SqlConnection connection = base.GetConnection())
            {
                SqlCommand command = new SqlCommand("_NewsGroupGetById", connection) {
                    CommandType = CommandType.StoredProcedure
                };
                command.Parameters.AddWithValue("@NewsGroupID", Id);
                connection.Open();
                using (SqlDataReader reader = command.ExecuteReader(CommandBehavior.CloseConnection))
                {
                    if (reader.Read())
                    {
                        newsGroup = this.NewsGroupReader(reader);
                    }
                    else
                    {
                        newsGroup = null;
                    }
                }
                command.Dispose();
            }
            return newsGroup;
        }

        public DataTable GetNewsGroupHot(string lang)
        {
            DataTable datatable = new DataTable();
            using (SqlConnection connection = base.GetConnection())
            {
                SqlCommand command = new SqlCommand("_NewsGroupHot", connection) {
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

        public DataTable GetNewsGroupHot(string lang, int group)
        {
            DataTable datatable = new DataTable();
            using (SqlConnection connection = base.GetConnection())
            {
                SqlCommand command = new SqlCommand("_NewsGroupHotGroup", connection) {
                    CommandType = CommandType.StoredProcedure
                };
                command.Parameters.AddWithValue("@Language", lang);
                command.Parameters.AddWithValue("@GroupCate", group);
                connection.Open();
                using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                {
                    adapter.Fill(datatable);
                    command.Dispose();
                }
            }
            return datatable;
        }

        public DataTable GetNewsGroupHot(string lang, int n, int group)
        {
            DataTable datatable = new DataTable();
            using (SqlConnection connection = base.GetConnection())
            {
                string SQL = "Select top " + n.ToString() + " * from tblNewsGroup where [Language] = '" + lang + "' AND [Ishot] = 1 AND [Status] = 1 AND [GroupCate] = @GroupCate ORDER BY [PostDate] DESC ";
                SqlCommand command = new SqlCommand(SQL, connection) {
                    CommandText = SQL
                };
                command.Parameters.AddWithValue("@GroupCate", group);
                connection.Open();
                using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                {
                    adapter.Fill(datatable);
                    command.Dispose();
                }
            }
            return datatable;
        }

        public DataTable GetNewsGroupHot(string lang, int n, string approval, int group)
        {
            DataTable datatable = new DataTable();
            using (SqlConnection connection = base.GetConnection())
            {
                string SQL = "Select top " + n.ToString() + " * from tblNewsGroup where Language = '" + lang + "' and Ishot = 1 AND Status = 1 AND IsApproval = " + approval + " and GroupCate=@GroupCate ORDER BY PostDate DESC ";
                SqlCommand command = new SqlCommand(SQL, connection) {
                    CommandText = SQL
                };
                command.Parameters.AddWithValue("@GroupCate", group);
                connection.Open();
                using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                {
                    adapter.Fill(datatable);
                    command.Dispose();
                }
            }
            return datatable;
        }

        public DataTable GetNewsGroupView(string lang)
        {
            DataTable datatable = new DataTable();
            using (SqlConnection connection = base.GetConnection())
            {
                SqlCommand command = new SqlCommand("_NewsGroupView", connection) {
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

        public DataTable GetNewsGroupView(string lang, int group)
        {
            DataTable datatable = new DataTable();
            using (SqlConnection connection = base.GetConnection())
            {
                SqlCommand command = new SqlCommand("_NewsGroupViewGroup", connection) {
                    CommandType = CommandType.StoredProcedure
                };
                command.Parameters.AddWithValue("@Language", lang);
                command.Parameters.AddWithValue("@GroupCate", group);
                connection.Open();
                using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                {
                    adapter.Fill(datatable);
                    command.Dispose();
                }
            }
            return datatable;
        }

        public DataTable GetNewsGroupViewAll(string lang, int n, int group)
        {
            DataTable datatable = new DataTable();
            using (SqlConnection connection = base.GetConnection())
            {
                string SQL = "Select top " + n.ToString() + " * from tblNewsGroup where [Language] = '" + lang + "' AND [Status] = 1 AND [GroupCate] = @GroupCate ORDER BY [PostDate] DESC ";
                SqlCommand command = new SqlCommand(SQL, connection) {
                    CommandText = SQL
                };
                command.Parameters.AddWithValue("@GroupCate", group);
                connection.Open();
                using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                {
                    adapter.Fill(datatable);
                    command.Dispose();
                }
            }
            return datatable;
        }

        public DataTable GetNewsGroupViewAll(string lang, int n, int group, string approval)
        {
            DataTable datatable = new DataTable();
            using (SqlConnection connection = base.GetConnection())
            {
                string SQL = "Select top " + n.ToString() + " * from tblNewsGroup where [Language] = '" + lang + "' AND [Status] = 1 AND [GroupCate] = @GroupCate AND IsApproval = " + approval + " ORDER BY [PostDate] DESC ";
                SqlCommand command = new SqlCommand(SQL, connection) {
                    CommandText = SQL
                };
                command.Parameters.AddWithValue("@GroupCate", group);
                connection.Open();
                using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                {
                    adapter.Fill(datatable);
                    command.Dispose();
                }
            }
            return datatable;
        }

        public DataTable GetNewsGroupViewHome(string lang)
        {
            DataTable datatable = new DataTable();
            using (SqlConnection connection = base.GetConnection())
            {
                SqlCommand command = new SqlCommand("_NewsGroupViewHome", connection) {
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

        public DataTable GetNewsGroupViewHome(string lang, int group)
        {
            DataTable datatable = new DataTable();
            using (SqlConnection connection = base.GetConnection())
            {
                SqlCommand command = new SqlCommand("_NewsGroupViewHomeGroup", connection) {
                    CommandType = CommandType.StoredProcedure
                };
                command.Parameters.AddWithValue("@Language", lang);
                command.Parameters.AddWithValue("@GroupCate", group);
                connection.Open();
                using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                {
                    adapter.Fill(datatable);
                    command.Dispose();
                }
            }
            return datatable;
        }

        public DataTable GetNewsGroupViewHome(string lang, int n, int group)
        {
            DataTable datatable = new DataTable();
            using (SqlConnection connection = base.GetConnection())
            {
                string SQL = "Select top " + n.ToString() + " * from tblNewsGroup where [Language] = '" + lang + "' AND [IsHome] = 1 AND [Status] = 1 AND [GroupCate] = @GroupCate ORDER BY [PostDate] DESC ";
                SqlCommand command = new SqlCommand(SQL, connection) {
                    CommandText = SQL
                };
                command.Parameters.AddWithValue("@GroupCate", group);
                connection.Open();
                using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                {
                    adapter.Fill(datatable);
                    command.Dispose();
                }
            }
            return datatable;
        }

        public DataTable GetNewsGroupViewHome(string lang, int n, int cID, int group)
        {
            DataTable datatable = new DataTable();
            using (SqlConnection connection = base.GetConnection())
            {
                string SQL = "Select top " + n.ToString() + " * from tblNewsGroup where [Language] = '" + lang + "' AND CateNewsID = @cateID AND [IsHome] = 1 AND [Status] = 1 AND [GroupCate] = @GroupCate ORDER BY [PostDate] DESC ";
                SqlCommand command = new SqlCommand(SQL, connection) {
                    CommandText = SQL
                };
                command.Parameters.AddWithValue("@cateID", cID);
                command.Parameters.AddWithValue("@GroupCate", group);
                connection.Open();
                using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                {
                    adapter.Fill(datatable);
                    command.Dispose();
                }
            }
            return datatable;
        }

        public DataTable GetNewsGroupViewHome(string lang, int n, string approval, int group)
        {
            DataTable datatable = new DataTable();
            using (SqlConnection connection = base.GetConnection())
            {
                string SQL = "Select top " + n.ToString() + " * from tblNewsGroup where [Language] = '" + lang + "' AND [IsHome] = 1 AND [Status] = 1 AND [IsApproval] = " + approval + " AND [GroupCate] = @GroupCate ORDER BY [PostDate] DESC ";
                SqlCommand command = new SqlCommand(SQL, connection) {
                    CommandText = SQL
                };
                command.Parameters.AddWithValue("@GroupCate", group);
                connection.Open();
                using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                {
                    adapter.Fill(datatable);
                    command.Dispose();
                }
            }
            return datatable;
        }

        public DataTable GetNewsGroupViewHome(string lang, string strCate, int n, int group)
        {
            DataTable datatable = new DataTable();
            using (SqlConnection connection = base.GetConnection())
            {
                string SQL = "Select top " + n.ToString() + " * from tblNewsGroup where [Language] = '" + lang + "' AND CateNewsID in('" + strCate + "') AND [IsHome] = 1 AND [Status] = 1 AND [GroupCate] = @GroupCate ORDER BY [PostDate] DESC ";
                SqlCommand command = new SqlCommand(SQL, connection) {
                    CommandText = SQL
                };
                command.Parameters.AddWithValue("@GroupCate", group);
                connection.Open();
                using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                {
                    adapter.Fill(datatable);
                    command.Dispose();
                }
            }
            return datatable;
        }

        public void NewsGroupClickUpdate(int nId)
        {
            using (SqlConnection connection = base.GetConnection())
            {
                SqlCommand command = new SqlCommand("_NewsGroupClickUpdate", connection) {
                    CommandType = CommandType.StoredProcedure
                };
                command.Parameters.AddWithValue("@NewsGroupID", nId);
                connection.Open();
                if (command.ExecuteNonQuery() <= 0)
                {
                    throw new DataAccessException("Kh\x00f4ng thể cập nhật số lần click");
                }
                command.Dispose();
            }
        }

        public DataTable NewsGroupFollow(int Id, int cId, int n)
        {
            DataTable datatable = new DataTable();
            using (SqlConnection connection = base.GetConnection())
            {
                string SQL = string.Concat(new object[] { "SELECT Top ", Convert.ToString(n), " * FROM tblNewsGroup WHERE CateNewsID = ", cId, " AND NewsGroupID < ", Id, " ORDER BY PostDate DESC" });
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

        public DataTable NewsGroupFollow(int Id, int cId, int n, string approval)
        {
            DataTable datatable = new DataTable();
            using (SqlConnection connection = base.GetConnection())
            {
                string SQL = string.Concat(new object[] { "SELECT Top ", Convert.ToString(n), " * FROM tblNewsGroup WHERE CateNewsID = ", cId, " AND NewsGroupID < ", Id, " AND status=1 AND IsApproval = ", approval, " ORDER BY PostDate DESC" });
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

        private NewsGroup NewsGroupReader(SqlDataReader reader)
        {
            return new NewsGroup { 
                NewsGroupID = (int) reader["NewsGroupID"], CateNewsID = (int) reader["CateNewsID"], ParentNewsID = (int) reader["ParentNewsID"], GroupCate = (int) reader["GroupCate"], Title = (string) reader["Title"], ShortDescribe = (string) reader["ShortDescribe"], FullDescribe = (string) reader["FullDescribe"], ImageThumb = (string) reader["ImageThumb"], ImageLarge = (string) reader["ImageLarge"], FileName = (string) reader["FileName"], Author = (string) reader["Author"], PostDate = (DateTime) reader["PostDate"], RelationTotal = (int) reader["RelationTotal"], Status = (bool) reader["Status"], Language = (string) reader["Language"], Ishot = (bool) reader["Ishot"], 
                Isview = (int) reader["Isview"], Ishome = (bool) reader["Ishome"], TypeNews = (bool) reader["TypeNews"], IsComment = (bool) reader["IsComment"], ApprovalDate = (DateTime) reader["ApprovalDate"], ApprovalUserName = (string) reader["ApprovalUserName"], IsApproval = (bool) reader["IsApproval"], CreatedUserName = (string) reader["CreatedUserName"], CommentTotal = (int) reader["CommentTotal"]
             };
        }

        public DataTable NewsGroupSearch(string finter)
        {
            DataTable datatable = new DataTable();
            using (SqlConnection connection = base.GetConnection())
            {
                SqlCommand command = new SqlCommand("_NewsSearchs", connection) {
                    CommandType = CommandType.StoredProcedure
                };
                command.Parameters.AddWithValue("@Finter", finter);
                connection.Open();
                using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                {
                    adapter.Fill(datatable);
                    command.Dispose();
                }
            }
            return datatable;
        }

        public DataTable NewsGroupSearch(string keyword, int cateid, string lang)
        {
            DataTable datatable = new DataTable();
            using (SqlConnection connection = base.GetConnection())
            {
                SqlCommand command = new SqlCommand("_NewsGroupSearch", connection) {
                    CommandType = CommandType.StoredProcedure
                };
                command.Parameters.AddWithValue("@Keyword", keyword);
                command.Parameters.AddWithValue("@CateNewsID", cateid);
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

        public void UpdateNewsGroup(NewsGroup newsGroup)
        {
            using (SqlConnection connection = base.GetConnection())
            {
                SqlCommand command = new SqlCommand("_NewsGroupUpdate", connection) {
                    CommandType = CommandType.StoredProcedure
                };
                command.Parameters.AddWithValue("@Type", 1);
                command.Parameters.AddWithValue("@NewsGroupID", newsGroup.NewsGroupID);
                command.Parameters.AddWithValue("@CateNewsID", newsGroup.CateNewsID);
                command.Parameters.AddWithValue("@ParentNewsID", newsGroup.ParentNewsID);
                command.Parameters.AddWithValue("@GroupCate", newsGroup.GroupCate);
                command.Parameters.AddWithValue("@Title", newsGroup.Title);
                command.Parameters.AddWithValue("@ShortDescribe", newsGroup.ShortDescribe);
                command.Parameters.AddWithValue("@FullDescribe", newsGroup.FullDescribe);
                command.Parameters.AddWithValue("@ImageThumb", newsGroup.ImageThumb);
                command.Parameters.AddWithValue("@ImageLarge", newsGroup.ImageLarge);
                command.Parameters.AddWithValue("@FileName", newsGroup.FileName);
                command.Parameters.AddWithValue("@Author", newsGroup.Author);
                command.Parameters.AddWithValue("@PostDate", newsGroup.PostDate);
                command.Parameters.AddWithValue("@RelationTotal", newsGroup.RelationTotal);
                command.Parameters.AddWithValue("@Status", newsGroup.Status);
                command.Parameters.AddWithValue("@Language", newsGroup.Language);
                command.Parameters.AddWithValue("@Ishot", newsGroup.Ishot);
                command.Parameters.AddWithValue("@Isview", newsGroup.Isview);
                command.Parameters.AddWithValue("@Ishome", newsGroup.Ishome);
                command.Parameters.AddWithValue("@TypeNews", newsGroup.TypeNews);
                command.Parameters.AddWithValue("@IsComment", newsGroup.IsComment);
                command.Parameters.AddWithValue("@ApprovalDate", newsGroup.ApprovalDate);
                command.Parameters.AddWithValue("@ApprovalUserName", newsGroup.ApprovalUserName);
                command.Parameters.AddWithValue("@IsApproval", newsGroup.IsApproval);
                command.Parameters.AddWithValue("@CreatedUserName", newsGroup.CreatedUserName);
                command.Parameters.AddWithValue("@CommentTotal", newsGroup.CommentTotal);
                connection.Open();
                if (command.ExecuteNonQuery() <= 0)
                {
                    throw new DataAccessException("Kh\x00f4ng thể cập nhật tin");
                }
                command.Dispose();
            }
        }

        public void UpdateNewsGroup(string strId, string value)
        {
            using (SqlConnection connection = base.GetConnection())
            {
                string SQL = "update tblNewsGroup set Status = " + value + " where NewsGroupID in('" + strId + "')";
                SqlCommand command = new SqlCommand(SQL, connection) {
                    CommandText = SQL
                };
                connection.Open();
                if (command.ExecuteNonQuery() <= 0)
                {
                    throw new DataAccessException("Kh\x00f4ng cập nhật được tin n\x00e0o");
                }
                command.Dispose();
            }
        }

        public void UpdateNewsGroupApproval(int Id, string value, string username, DateTime date)
        {
            using (SqlConnection connection = base.GetConnection())
            {
                string SQL = "update tblNewsGroup set IsApproval = " + value + ", ApprovalUserName = '" + username + "',ApprovalDate = @Date  where NewsGroupID = @NewsGroupID";
                SqlCommand command = new SqlCommand(SQL, connection) {
                    CommandText = SQL
                };
                command.Parameters.AddWithValue("@Date", date);
                command.Parameters.AddWithValue("@NewsGroupID", Id);
                connection.Open();
                if (command.ExecuteNonQuery() <= 0)
                {
                    throw new DataAccessException("Kh\x00f4ng cập nhật được tin n\x00e0o");
                }
                command.Dispose();
            }
        }

        public void UpdateNewsGroupApproval(string strId, string value, string username, DateTime date)
        {
            using (SqlConnection connection = base.GetConnection())
            {
                string SQL = "update tblNewsGroup set IsApproval = " + value + ", ApprovalUserName = '" + username + "',ApprovalDate = @Date  where NewsGroupID in('" + strId + "')";
                SqlCommand command = new SqlCommand(SQL, connection) {
                    CommandText = SQL
                };
                command.Parameters.AddWithValue("@Date", date);
                connection.Open();
                if (command.ExecuteNonQuery() <= 0)
                {
                    throw new DataAccessException("Kh\x00f4ng cập nhật được tin n\x00e0o");
                }
                command.Dispose();
            }
        }

        public void UpdateSetDefault(int id)
        {
            using (SqlConnection connection = base.GetConnection())
            {
                string SQL = "update tblNewsGroup set IsDefault = 1 where NewsGroupID = @NewsGroupID";
                SqlCommand command = new SqlCommand(SQL, connection)
                {
                    CommandText = SQL
                };
                command.Parameters.AddWithValue("@NewsGroupID", id);
                connection.Open();
                if (command.ExecuteNonQuery() <= 0)
                {
                    throw new DataAccessException("Kh\x00f4ng cập nhật được tin n\x00e0o");
                }
                command.Dispose();
            }
        }

        public void UpdateSetDefault(int id, int group)
        {
            using (SqlConnection connection = base.GetConnection())
            {
                string SQL = "update tblNewsGroup set IsDefault = 1 where NewsGroupID = @NewsGroupID and GroupCate = @Groupcate";
                SqlCommand command = new SqlCommand(SQL, connection)
                {
                    CommandText = SQL
                };
                command.Parameters.AddWithValue("@NewsGroupID", id);
                command.Parameters.AddWithValue("@GroupCate", group);
                connection.Open();
                if (command.ExecuteNonQuery() <= 0)
                {
                    throw new DataAccessException("Kh\x00f4ng cập nhật được tin n\x00e0o");
                }
                command.Dispose();
            }
        }

        public void UpdateSetNotDefault(int id)
        {
            using (SqlConnection connection = base.GetConnection())
            {
                string SQL = "update tblNewsGroup set IsDefault = 0 where NewsGroupID <> @NewsGroupID";
                SqlCommand command = new SqlCommand(SQL, connection)
                {
                    CommandText = SQL
                };
                command.Parameters.AddWithValue("@NewsGroupID", id);
                connection.Open();
                if (command.ExecuteNonQuery() <= 0)
                {
                    throw new DataAccessException("Kh\x00f4ng cập nhật được tin n\x00e0o");
                }
                command.Dispose();
            }
        }

        public void UpdateSetNotDefault(int id, int group)
        {
            using (SqlConnection connection = base.GetConnection())
            {
                string SQL = "update tblNewsGroup set IsDefault = 0 where NewsGroupID <> @NewsGroupID and GroupCate = @GroupCate";
                SqlCommand command = new SqlCommand(SQL, connection)
                {
                    CommandText = SQL
                };
                command.Parameters.AddWithValue("@NewsGroupID", id);
                command.Parameters.AddWithValue("@GroupCate", group);
                connection.Open();
                if (command.ExecuteNonQuery() <= 0)
                {
                    throw new DataAccessException("Kh\x00f4ng cập nhật được tin n\x00e0o");
                }
                command.Dispose();
            }
        }

        public DataTable NewsGroupMainHomeModule(string lang)
        {
            DataTable datatable = new DataTable();
            using (SqlConnection connection = base.GetConnection())
            {
                var SQL = "SELECT * FROM dbo.tblNewsGroup JOIN dbo.tblCateNewsGroup ON dbo.tblNewsGroup.GroupCate = dbo.tblCateNewsGroup.GroupCate WHERE isdefault=1 AND dbo.tblCateNewsGroup.[language]=@Language";
                var command = new SqlCommand("_NewsGroupSearch", connection)
                {
                    CommandText = SQL
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
    }
}

