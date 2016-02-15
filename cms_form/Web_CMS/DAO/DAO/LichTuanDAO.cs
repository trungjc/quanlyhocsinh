namespace DAO
{
    using ETO;
    using System;
    using System.Data;
    using System.Data.SqlClient;

    public class LichTuanDAO : BaseDAO
    {
        public DataTable LichTuan_GetByDate(DateTime Ngay)
        {
            DataTable dtLichTuan = new DataTable();
            using (SqlConnection connection = base.GetConnection())
            {
                SqlCommand command = new SqlCommand("_LichTuan_GetByDate", connection)
                {
                    CommandType = CommandType.StoredProcedure
                };
                command.Parameters.AddWithValue("@Ngay", Ngay);
                connection.Open();
                using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                {
                    adapter.Fill(dtLichTuan);
                    command.Dispose();
                }
            }
            return dtLichTuan;
        }
    }
}
