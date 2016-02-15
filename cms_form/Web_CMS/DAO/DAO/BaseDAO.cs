namespace DAO
{
    using System;
    using System.Data.SqlClient;
    using System.Web.Configuration;

    public class BaseDAO
    {
        public SqlConnection GetConnection()
        {
            SqlConnection sqlConnection = new SqlConnection();
            string sConnection = "";
            string sStrServer = WebConfigurationManager.ConnectionStrings["ServerName"].ConnectionString;
            string sStrDatabase = WebConfigurationManager.ConnectionStrings["DatabaseName"].ConnectionString;
            string sStrUser = WebConfigurationManager.ConnectionStrings["UserID"].ConnectionString;
            string sStrPass = WebConfigurationManager.ConnectionStrings["Password"].ConnectionString;
            sConnection = (((sConnection + "Data Source=" + sStrServer + ";") + " Initial Catalog=" + sStrDatabase + ";") + " User=" + sStrUser + ";") + " Password=" + sStrPass + ";";
            sqlConnection.ConnectionString = sConnection;
            return sqlConnection;
        }
    }
}

