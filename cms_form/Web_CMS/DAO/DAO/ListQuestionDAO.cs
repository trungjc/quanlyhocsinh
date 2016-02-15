namespace DAO
{
    using ETO;
    using System;
    using System.Data;
    using System.Data.SqlClient;

    public class ListQuestionDAO : BaseDAO
    {
        public DataTable _GetListQuestionByParentID(int parentID)
        {
            DataTable datatable = new DataTable();
            using (SqlConnection connection = base.GetConnection())
            {
                SqlCommand command = new SqlCommand("_GetAllListQuestion", connection) {
                    CommandType = CommandType.StoredProcedure
                };
                command.Parameters.AddWithValue("@Question_ParentID", parentID);
                connection.Open();
                using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                {
                    adapter.Fill(datatable);
                    command.Dispose();
                }
            }
            return datatable;
        }

        public void CreatelistQuestion(ListQuestion listQuestion)
        {
            using (SqlConnection connection = base.GetConnection())
            {
                SqlCommand command = new SqlCommand("_UpdateListQuestion", connection) {
                    CommandType = CommandType.StoredProcedure
                };
                command.Parameters.AddWithValue("@Question_ID", 0);
                command.Parameters.AddWithValue("@Question_ParentID", listQuestion.Question_ParentID);
                command.Parameters.AddWithValue("@Question_Title", listQuestion.Question_Title);
                command.Parameters.AddWithValue("@Question_Content", listQuestion.Question_Content);
                command.Parameters.AddWithValue("@Question_FileAttach", listQuestion.Question_FileAttach);
                command.Parameters.AddWithValue("@Question_Image", listQuestion.Question_Image);
                command.Parameters.AddWithValue("@CreateUserName", listQuestion.CreateUserName);
                command.Parameters.AddWithValue("@CreateDate", listQuestion.CreateDate);
                command.Parameters.AddWithValue("@IsApproval", listQuestion.IsApproval);
                command.Parameters.AddWithValue("@ApprovalUserName", listQuestion.ApprovalUserName);
                command.Parameters.AddWithValue("@ApprovalDate", listQuestion.ApprovalDate);
                command.Parameters.AddWithValue("@CateNewsID", listQuestion.CateNewsID);
                command.Parameters.AddWithValue("@QuestionStatus", listQuestion.QuestionStatus);
                command.Parameters.AddWithValue("@Status", 0);
                connection.Open();
                if (command.ExecuteNonQuery() <= 0)
                {
                    throw new DataAccessException("Khong them moi duoc listquestion");
                }
                command.Dispose();
            }
        }

        public void deleteQuestionByID(int Id)
        {
            using (SqlConnection connection = base.GetConnection())
            {
                SqlCommand command = new SqlCommand("_deleteQuestionByID", connection) {
                    CommandType = CommandType.StoredProcedure
                };
                command.Parameters.AddWithValue("@Question_ID", Id);
                connection.Open();
                if (command.ExecuteNonQuery() <= 0)
                {
                    throw new DataAccessException("Khong xoa duoc lisQuestion");
                }
                command.Dispose();
            }
        }

        public DataTable GetAllPublishQuestion()
        {
            DataTable datatable = new DataTable();
            using (SqlConnection connection = base.GetConnection())
            {
                SqlCommand command = new SqlCommand("_GetAllPublishQuestion", connection) {
                    CommandType = CommandType.StoredProcedure
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

        public DataTable GetListPublishQuestionByProduct(int cateNewsID)
        {
            DataTable datatable = new DataTable();
            using (SqlConnection connection = base.GetConnection())
            {
                SqlCommand command = new SqlCommand("_GetListPublishQuestionByProduct", connection) {
                    CommandType = CommandType.StoredProcedure
                };
                command.Parameters.AddWithValue("@CateNewsID", cateNewsID);
                connection.Open();
                using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                {
                    adapter.Fill(datatable);
                    command.Dispose();
                }
            }
            return datatable;
        }

        public DataTable GetListQuestionAll()
        {
            DataTable datatable = new DataTable();
            using (SqlConnection connection = base.GetConnection())
            {
                SqlCommand command = new SqlCommand("_GetAllListQuestion", connection) {
                    CommandType = CommandType.StoredProcedure
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

        public ListQuestion GetListQuestionByID(int ID)
        {
            ListQuestion listQuestion = null;
            using (SqlConnection connection = base.GetConnection())
            {
                SqlCommand command = new SqlCommand("_GetListQuestionByID", connection) {
                    CommandType = CommandType.StoredProcedure
                };
                command.Parameters.AddWithValue("@Question_ID", ID);
                connection.Open();
                SqlDataReader reader = command.ExecuteReader(CommandBehavior.CloseConnection);
                try
                {
                    if (!reader.Read())
                    {
                        throw new DataAccessException("Kh\x00f4ng t\x00ecm thấy tin");
                    }
                    listQuestion = this.ListQuestionReader(reader);
                }
                catch
                {
                }
                finally
                {
                    if (reader != null)
                    {
                        reader.Dispose();
                    }
                }
                command.Dispose();
            }
            return listQuestion;
        }

        public DataTable GetListQuestionStausID(int status)
        {
            DataTable datatable = new DataTable();
            using (SqlConnection connection = base.GetConnection())
            {
                SqlCommand command = new SqlCommand("_GetListQuestionStausID", connection) {
                    CommandType = CommandType.StoredProcedure
                };
                command.Parameters.AddWithValue("@QuestionStatus", status);
                connection.Open();
                using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                {
                    adapter.Fill(datatable);
                    command.Dispose();
                }
            }
            return datatable;
        }

        public DataTable GetPublishQuestionByID(int parentID)
        {
            DataTable datatable = new DataTable();
            using (SqlConnection connection = base.GetConnection())
            {
                SqlCommand command = new SqlCommand("_GetPublishQuestionByID", connection) {
                    CommandType = CommandType.StoredProcedure
                };
                command.Parameters.AddWithValue("@Question_ID", parentID);
                connection.Open();
                using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                {
                    adapter.Fill(datatable);
                    command.Dispose();
                }
            }
            return datatable;
        }

        public DataTable GetQuestionByID(int ID)
        {
            DataTable datatable = new DataTable();
            using (SqlConnection connection = base.GetConnection())
            {
                SqlCommand command = new SqlCommand("_GetQuestionByID", connection) {
                    CommandType = CommandType.StoredProcedure
                };
                command.Parameters.AddWithValue("@Question_ID", ID);
                connection.Open();
                using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                {
                    adapter.Fill(datatable);
                    command.Dispose();
                }
            }
            return datatable;
        }

        public DataTable listChildQuestionByParentID(int ParentID)
        {
            DataTable datatable = new DataTable();
            using (SqlConnection connection = base.GetConnection())
            {
                SqlCommand command = new SqlCommand("_listQuestionByParentID", connection) {
                    CommandType = CommandType.StoredProcedure
                };
                command.Parameters.AddWithValue("@Question_ParentID", ParentID);
                connection.Open();
                using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                {
                    adapter.Fill(datatable);
                    command.Dispose();
                }
            }
            return datatable;
        }

        public DataTable listChildQuestionPublishByParentID(int ParentID)
        {
            DataTable datatable = new DataTable();
            using (SqlConnection connection = base.GetConnection())
            {
                SqlCommand command = new SqlCommand("_listChildQuestionPublishByParentID", connection) {
                    CommandType = CommandType.StoredProcedure
                };
                command.Parameters.AddWithValue("@Question_ParentID", ParentID);
                connection.Open();
                using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                {
                    adapter.Fill(datatable);
                    command.Dispose();
                }
            }
            return datatable;
        }

        public DataTable listParentQuestionByID(int id)
        {
            DataTable datatable = new DataTable();
            using (SqlConnection connection = base.GetConnection())
            {
                SqlCommand command = new SqlCommand("_GetListQuestionByID", connection) {
                    CommandType = CommandType.StoredProcedure
                };
                command.Parameters.AddWithValue("@Question_ID", id);
                connection.Open();
                using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                {
                    adapter.Fill(datatable);
                    command.Dispose();
                }
            }
            return datatable;
        }

        public DataTable listQuestionPublishByParentID(int parentID)
        {
            DataTable datatable = new DataTable();
            using (SqlConnection connection = base.GetConnection())
            {
                SqlCommand command = new SqlCommand("_listQuestionPublishByParentID", connection) {
                    CommandType = CommandType.StoredProcedure
                };
                command.Parameters.AddWithValue("@Question_ParentID", parentID);
                connection.Open();
                using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                {
                    adapter.Fill(datatable);
                    command.Dispose();
                }
            }
            return datatable;
        }

        private ListQuestion ListQuestionReader(SqlDataReader reader)
        {
            return new ListQuestion { CateNewsID = (int) reader["CateNewsID"], CreateDate = (DateTime) reader["CreateDate"], CreateUserName = (string) reader["CreateUserName"], IsApproval = (bool) reader["IsApproval"], ApprovalDate = (DateTime) reader["ApprovalDate"], ApprovalUserName = (string) reader["ApprovalUserName"], Question_Content = (string) reader["Question_Content"], Question_FileAttach = (string) reader["Question_FileAttach"], Question_ID = (int) reader["Question_ID"], Question_Image = (string) reader["Question_Image"], Question_ParentID = (int) reader["Question_ParentID"], Question_Title = (string) reader["Question_Title"], QuestionStatus = (int) reader["QuestionStatus"] };
        }

        public void UpdatelistQuestion(ListQuestion listQuestion)
        {
            using (SqlConnection connection = base.GetConnection())
            {
                SqlCommand command = new SqlCommand("_UpdateListQuestion", connection) {
                    CommandType = CommandType.StoredProcedure
                };
                command.Parameters.AddWithValue("@Question_ID", listQuestion.Question_ID);
                command.Parameters.AddWithValue("@Question_ParentID", listQuestion.Question_ParentID);
                command.Parameters.AddWithValue("@Question_Title", listQuestion.Question_Title);
                command.Parameters.AddWithValue("@Question_Content", listQuestion.Question_Content);
                command.Parameters.AddWithValue("@Question_FileAttach", listQuestion.Question_FileAttach);
                command.Parameters.AddWithValue("@Question_Image", listQuestion.Question_Image);
                command.Parameters.AddWithValue("@CreateUserName", listQuestion.CreateUserName);
                command.Parameters.AddWithValue("@CreateDate", listQuestion.CreateDate);
                command.Parameters.AddWithValue("@IsApproval", listQuestion.IsApproval);
                command.Parameters.AddWithValue("@ApprovalUserName", listQuestion.ApprovalUserName);
                command.Parameters.AddWithValue("@ApprovalDate", listQuestion.ApprovalDate);
                command.Parameters.AddWithValue("@CateNewsID", listQuestion.CateNewsID);
                command.Parameters.AddWithValue("@QuestionStatus", listQuestion.QuestionStatus);
                command.Parameters.AddWithValue("@Status", 1);
                connection.Open();
                if (command.ExecuteNonQuery() <= 0)
                {
                    throw new DataAccessException("Khong cap nhat duoc listquestion");
                }
                command.Dispose();
            }
        }

        public void UpdateQuestionStatus(string ArrQuestionID, int status)
        {
            using (SqlConnection connection = base.GetConnection())
            {
                string SQL = string.Concat(new object[] { "UPDATE tblQuestion SET QuestionStatus = ", status, " WHERE Question_ID IN('", ArrQuestionID, "')" });
                SqlCommand command = new SqlCommand(SQL, connection) {
                    CommandText = SQL
                };
                connection.Open();
                if (command.ExecuteNonQuery() <= 0)
                {
                    throw new DataAccessException("khong the cap nhat");
                }
                command.Dispose();
            }
        }

        public void updateStatusPublishQuestion(int questionID, int status)
        {
            using (SqlConnection connection = base.GetConnection())
            {
                SqlCommand command = new SqlCommand("_updateStatusPublishQuestion", connection) {
                    CommandType = CommandType.StoredProcedure
                };
                command.Parameters.AddWithValue("@Question_ID", questionID);
                command.Parameters.AddWithValue("@Status", status);
                connection.Open();
                if (command.ExecuteNonQuery() <= 0)
                {
                    throw new DataAccessException("Khong cap nhat duoc");
                }
                command.Dispose();
            }
        }

        public void UpdateSubQuestion(int questionID, string content, string image, string file)
        {
            using (SqlConnection connection = base.GetConnection())
            {
                SqlCommand command = new SqlCommand("_updateSubQuestion", connection) {
                    CommandType = CommandType.StoredProcedure
                };
                command.Parameters.AddWithValue("@Question_ID", questionID);
                command.Parameters.AddWithValue("@Question_Content", content);
                command.Parameters.AddWithValue("@Question_image", image);
                command.Parameters.AddWithValue("@Question_file", file);
                connection.Open();
                if (command.ExecuteNonQuery() <= 0)
                {
                    throw new DataAccessException("Khong cap nhat duoc listquestion");
                }
                command.Dispose();
            }
        }
    }
}

