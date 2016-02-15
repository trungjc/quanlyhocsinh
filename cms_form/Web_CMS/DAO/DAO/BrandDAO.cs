namespace DAO
{
    using ETO;
    using System;
    using System.Data;
    using System.Data.SqlClient;

    public class BrandDAO : BaseDAO
    {
        private Brand BrandReader(SqlDataReader reader)
        {
            return new Brand { BrandID = (int) reader["BrandID"], BrandName = (string) reader["BrandName"], Image = (string) reader["Image"], ShortDescribe = (string) reader["ShortDescribe"], BrandUrl = (string) reader["BrandUrl"], Language = (string) reader["Language"] };
        }

        public void CreateBrand(Brand brand)
        {
            using (SqlConnection connection = base.GetConnection())
            {
                SqlCommand command = new SqlCommand("_BrandUpdate", connection) {
                    CommandType = CommandType.StoredProcedure
                };
                command.Parameters.AddWithValue("@Type", 0);
                command.Parameters.AddWithValue("@BrandID", 0);
                command.Parameters.AddWithValue("@BrandName", brand.BrandName);
                command.Parameters.AddWithValue("@BrandUrl", brand.BrandUrl);
                command.Parameters.AddWithValue("@Image", brand.Image);
                command.Parameters.AddWithValue("ShortDescribe", brand.ShortDescribe);
                command.Parameters.AddWithValue("@Language", brand.Language);
                connection.Open();
                if (command.ExecuteNonQuery() <= 0)
                {
                    throw new DataAccessException("khong them moi duoc brand");
                }
                command.Dispose();
            }
        }

        public void DeleteBrand(int Id)
        {
            using (SqlConnection connection = base.GetConnection())
            {
                SqlCommand command = new SqlCommand("_BrandDelete", connection) {
                    CommandType = CommandType.StoredProcedure
                };
                command.Parameters.AddWithValue("@BrandID", Id);
                connection.Open();
                if (command.ExecuteNonQuery() <= 0)
                {
                    throw new DataAccessException("Khong xoa duoc brand");
                }
                command.Dispose();
            }
        }

        public DataTable GetBrandAll(string lang)
        {
            DataTable datatable = new DataTable();
            using (SqlConnection connection = base.GetConnection())
            {
                SqlCommand command = new SqlCommand("_BrandGetAll", connection) {
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

        public Brand GetBrandById(int Id)
        {
            Brand brand = null;
            using (SqlConnection connection = base.GetConnection())
            {
                SqlCommand command = new SqlCommand("_BrandGetById", connection) {
                    CommandType = CommandType.StoredProcedure
                };
                command.Parameters.AddWithValue("@BrandID", Id);
                connection.Open();
                using (SqlDataReader reader = command.ExecuteReader(CommandBehavior.CloseConnection))
                {
                    if (!reader.Read())
                    {
                        throw new DataAccessException("Khong tim thay gia tri brand");
                    }
                    brand = this.BrandReader(reader);
                    command.Dispose();
                }
            }
            return brand;
        }

        public void UpdateBrand(Brand brand)
        {
            using (SqlConnection connection = base.GetConnection())
            {
                SqlCommand command = new SqlCommand("_BrandUpdate", connection) {
                    CommandType = CommandType.StoredProcedure
                };
                command.Parameters.AddWithValue("@Type", 1);
                command.Parameters.AddWithValue("@BrandID", brand.BrandID);
                command.Parameters.AddWithValue("@BrandName", brand.BrandName);
                command.Parameters.AddWithValue("@BrandUrl", brand.BrandUrl);
                command.Parameters.AddWithValue("@Image", brand.Image);
                command.Parameters.AddWithValue("ShortDescribe", brand.ShortDescribe);
                command.Parameters.AddWithValue("@Language", brand.Language);
                connection.Open();
                if (command.ExecuteNonQuery() <= 0)
                {
                    throw new DataAccessException("khong cap nhat duoc brand");
                }
                command.Dispose();
            }
        }
    }
}

