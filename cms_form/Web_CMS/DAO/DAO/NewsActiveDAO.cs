namespace DAO
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.Data;
    using ETO;
    using System.Data.SqlClient;

	public class NewsActiveDAO
	{
        public DataTable GetNewsActive(int num, string approval)
        {
            DataTable datatable = new DataTable();
            DAO.BaseDAO bs = new BaseDAO();
            using (SqlConnection connection = bs.GetConnection())
            {
                string SQL = "select top " + Convert.ToString(num) + " * from tblNewsGroup Where status = 1 AND IsApproval = " + approval + " AND GroupCate = " + num + " order by NewsGroupID Desc";
                SqlCommand command = new SqlCommand(SQL, connection)
                {
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
	}
}
