namespace DAO
{
    using ETO;
    using System;
    using System.Data;
    using System.Data.SqlClient;

    public class HitCounterDAO : BaseDAO
    {
        public HitCounter GetHitCounter()
        {
            HitCounter hitcounter = null;
            using (SqlConnection connection = base.GetConnection())
            {
                SqlCommand command = new SqlCommand("_HitCounterGet", connection) {
                    CommandType = CommandType.StoredProcedure
                };
               connection.Open();
                using (SqlDataReader reader = command.ExecuteReader(CommandBehavior.CloseConnection))
                {
                    if (!reader.Read())
                    {
                        throw new DataAccessException("khong tim thay gia tri hitcoutter nao");
                    }
                    hitcounter = this.HitCounterReader(reader);
                    command.Dispose();
                }
            }
            return hitcounter;
        }

        private HitCounter HitCounterReader(SqlDataReader reader)
        {
            return new HitCounter { SiteHitCounter = (long) reader["HitCounter"] };
        }

        public void UpdateHitCounter(long hitcounter)
        {
            using (SqlConnection connection = base.GetConnection())
            {
                SqlCommand command = new SqlCommand("_HitCounter", connection) {
                    CommandType = CommandType.StoredProcedure
                };
                command.Parameters.AddWithValue("@HitCounter", hitcounter);
                connection.Open();
                if (command.ExecuteNonQuery() <= 0)
                {
                    throw new DataAccessException("Khong cap nhat duoc hitcounter");
                }
                command.Dispose();
            }
        }
    }
}

