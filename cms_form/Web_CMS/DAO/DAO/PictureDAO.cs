namespace DAO
{
    using ETO;
    using System;
    using System.Data;
    using System.Data.SqlClient;

    public class PictureDAO : BaseDAO
    {
        public void CreatePicture(Picture picture)
        {
            using (SqlConnection connection = base.GetConnection())
            {
                SqlCommand command = new SqlCommand("_PictureUpdate", connection) {
                    CommandType = CommandType.StoredProcedure
                };
                command.Parameters.AddWithValue("@Type", 0);
                command.Parameters.AddWithValue("@PictureID", 0);
                command.Parameters.AddWithValue("@ProductID", picture.ProductID);
                command.Parameters.AddWithValue("@PictureThumb", picture.PictureThumb);
                command.Parameters.AddWithValue("@PictureLarge", picture.PictureLarge);
                connection.Open();
                if (command.ExecuteNonQuery() <= 0)
                {
                    throw new DataAccessException("Kh\x00f4ng thể th\x00eam h\x00ecnh ảnh");
                }
                command.Dispose();
            }
        }

        public void DeletePicture(int Id)
        {
            using (SqlConnection connection = base.GetConnection())
            {
                SqlCommand command = new SqlCommand("_PictureDelete", connection) {
                    CommandType = CommandType.StoredProcedure
                };
                command.Parameters.AddWithValue("@PictureID", Id);
                connection.Open();
                if (command.ExecuteNonQuery() <= 0)
                {
                    throw new DataAccessException("Lỗi kh\x00f4ng x\x00f3a được h\x00ecnh ảnh");
                }
                command.Dispose();
            }
        }

        public DataTable GetPictureByProduct(int pId)
        {
            DataTable datatable = new DataTable();
            using (SqlConnection connection = base.GetConnection())
            {
                SqlCommand command = new SqlCommand("_PictureGetByProduct", connection) {
                    CommandType = CommandType.StoredProcedure
                };
                command.Parameters.AddWithValue("@ProductID", pId);
                connection.Open();
                using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                {
                    adapter.Fill(datatable);
                    command.Dispose();
                }
            }
            return datatable;
        }

        private Picture PictureReader(SqlDataReader reader)
        {
            return new Picture { PictureID = (int) reader["PictureID"], ProductID = (int) reader["ProductID"], PictureThumb = (string) reader["PictureThumb"], PictureLarge = (string) reader["PictureLarge"] };
        }

        public void UpdatePicture(Picture picture)
        {
            using (SqlConnection connection = base.GetConnection())
            {
                SqlCommand command = new SqlCommand("_PictureUpdate", connection) {
                    CommandType = CommandType.StoredProcedure
                };
                command.Parameters.AddWithValue("@Type", 1);
                command.Parameters.AddWithValue("@PictureID", picture.PictureID);
                command.Parameters.AddWithValue("@ProductID", picture.ProductID);
                command.Parameters.AddWithValue("@PictureThumb", picture.PictureThumb);
                command.Parameters.AddWithValue("@PictureLarge", picture.PictureLarge);
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

