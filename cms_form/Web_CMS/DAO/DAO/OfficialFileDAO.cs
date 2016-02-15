namespace DAO
{
    using ETO;
    using System;
    using System.Data;
    using System.Data.SqlClient;

    public class OfficialFileDAO : BaseDAO
    {
        public void CreateOfficialFile(OfficialFile officialFile)
        {
            using (SqlConnection connection = base.GetConnection())
            {
                SqlCommand command = new SqlCommand("_OfficialFileUpdate", connection) {
                    CommandType = CommandType.StoredProcedure
                };
                command.Parameters.AddWithValue("@Type", 0);
                command.Parameters.AddWithValue("@OfficialFileID", 0);
                command.Parameters.AddWithValue("@OfficialID", officialFile.OfficialID);
                command.Parameters.AddWithValue("@FileName", officialFile.FileName);
                command.Parameters.AddWithValue("@Title", officialFile.Title);
                connection.Open();
                if (command.ExecuteNonQuery() <= 0)
                {
                    throw new DataAccessException("Kh\x00f4ng thể th\x00eam h\x00ecnh ảnh");
                }
                command.Dispose();
            }
        }

        public void DeleteOfficialFile(int Id)
        {
            using (SqlConnection connection = base.GetConnection())
            {
                SqlCommand command = new SqlCommand("_OfficialFileDelete", connection) {
                    CommandType = CommandType.StoredProcedure
                };
                command.Parameters.AddWithValue("@OfficialFileID", Id);
                connection.Open();
                if (command.ExecuteNonQuery() <= 0)
                {
                    throw new DataAccessException("Lỗi kh\x00f4ng x\x00f3a được h\x00ecnh ảnh");
                }
                command.Dispose();
            }
        }

        public void DeleteOfficialFile(string sId)
        {
            using (SqlConnection connection = base.GetConnection())
            {
                string SQL = "delete tblOfficialFile where OfficialFileID in('" + sId + "')";
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

        public DataTable GetOfficialFileAll()
        {
            DataTable datatable = new DataTable();
            using (SqlConnection connection = base.GetConnection())
            {
                SqlCommand command = new SqlCommand("_OfficialFileGetAll", connection) {
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

        public OfficialFile GetOfficialFileByID(int Id)
        {
            OfficialFile officialFile = null;
            using (SqlConnection connection = base.GetConnection())
            {
                SqlCommand command = new SqlCommand("_OfficialFileGetByID", connection) {
                    CommandType = CommandType.StoredProcedure
                };
                command.Parameters.AddWithValue("@OfficialFileID", Id);
                connection.Open();
                using (SqlDataReader reader = command.ExecuteReader(CommandBehavior.CloseConnection))
                {
                    if (!reader.Read())
                    {
                        throw new DataAccessException("Kh\x00f4ng t\x00ecm thấy tin");
                    }
                    officialFile = this.OfficialFileReader(reader);
                }
                command.Dispose();
            }
            return officialFile;
        }

        public DataTable GetOfficialFileByOfficial(int pId)
        {
            DataTable datatable = new DataTable();
            using (SqlConnection connection = base.GetConnection())
            {
                SqlCommand command = new SqlCommand("_OfficialFileGetByOfficial", connection) {
                    CommandType = CommandType.StoredProcedure
                };
                command.Parameters.AddWithValue("@OfficialID", pId);
                connection.Open();
                using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                {
                    adapter.Fill(datatable);
                    command.Dispose();
                }
            }
            return datatable;
        }

        private OfficialFile OfficialFileReader(SqlDataReader reader)
        {
            return new OfficialFile { OfficialFileID = (int) reader["OfficialFileID"], OfficialID = (int) reader["OfficialID"], FileName = (string) reader["FileName"], Title = (string) reader["Title"] };
        }

        public void UpdateOfficialFile(OfficialFile officialFile)
        {
            using (SqlConnection connection = base.GetConnection())
            {
                SqlCommand command = new SqlCommand("_OfficialFileUpdate", connection) {
                    CommandType = CommandType.StoredProcedure
                };
                command.Parameters.AddWithValue("@Type", 1);
                command.Parameters.AddWithValue("@OfficialFileID", officialFile.OfficialFileID);
                command.Parameters.AddWithValue("@OfficialID", officialFile.OfficialID);
                command.Parameters.AddWithValue("@FileName", officialFile.FileName);
                command.Parameters.AddWithValue("@Title", officialFile.Title);
                connection.Open();
                if (command.ExecuteNonQuery() <= 0)
                {
                    throw new DataAccessException("Kh\x00f4ng thể cập nhật h\x00ecnh ảnh");
                }
                command.Dispose();
            }
        }
    }
}

