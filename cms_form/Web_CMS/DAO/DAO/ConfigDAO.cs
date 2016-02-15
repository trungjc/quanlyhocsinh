namespace DAO
{
    using ETO;
    using System;
    using System.Data;
    using System.Data.SqlClient;

    public class ConfigDAO : BaseDAO
    {
        private Config ConfigReader(SqlDataReader reader)
        {
            return new Config { 
                Titleweb = (string) reader["titleweb"], Google = (string) reader["google"], Introduction = (string) reader["introduction"], Infocompany = (string) reader["infocompany"], New_icon_w = (string) reader["new_icon_w"], New_icon_h = (string) reader["new_icon_h"], New_thumb_w = (string) reader["new_thumb_w"], New_thumb_h = (string) reader["new_thumb_h"], New_large_w = (string) reader["new_large_w"], New_large_h = (string) reader["new_large_h"], Product_icon_w = (string) reader["product_icon_w"], Product_icon_h = (string) reader["product_icon_h"], Product_thumb_w = (string) reader["product_thumb_w"], Product_thumb_h = (string) reader["product_thumb_h"], Product_large_w = (string) reader["product_large_w"], Product_large_h = (string) reader["product_large_h"], 
                ProductNo = (string) reader["productNo"], ProductNoPage = (string) reader["productNoPage"], Currency = (string) reader["currency"], Status = (bool) reader["status"], Closecomment = (string) reader["closecomment"], Language = (string) reader["language"], Support = (string) reader["support"], Contact = (string) reader["contact"], Intro_desc = (string) reader["intro_desc"], Email_from = (string) reader["email_from"], Email_to = (string) reader["email_to"], Counter = (string) reader["counter"], Info1 = (string) reader["info1"], Info2 = (string) reader["info2"], WebName = (string) reader["WebName"], WebServerIP = (string) reader["WebServerIP"], 
                WebMailServer = (string) reader["WebMailServer"], WebDomain = (string) reader["WebDomain"], IsPopup = (bool) reader["IsPopup"], Popup = (string) reader["Popup"], Popup2 = (string) reader["Popup2"]
             };
        }

        public Config GetAllConfig(string language)
        {
            Config config = null;
            using (SqlConnection connection = base.GetConnection())
            {
                SqlCommand command = new SqlCommand("_ConfigGetAll", connection) {
                    CommandType = CommandType.StoredProcedure
                };
                command.Parameters.AddWithValue("@Language", language);
                connection.Open();
                using (SqlDataReader reader = command.ExecuteReader(CommandBehavior.CloseConnection))
                {
                    while (reader.Read())
                    {
                        config = this.ConfigReader(reader);
                    }
                    command.Dispose();
                }
                return config;
            }
        }

        public void UpdateConfig(Config config)
        {
            using (SqlConnection connection = base.GetConnection())
            {
                SqlCommand command = new SqlCommand("_ConfigUpdate", connection) {
                    CommandType = CommandType.StoredProcedure
                };
                command.Parameters.AddWithValue("@Titleweb", config.Titleweb);
                command.Parameters.AddWithValue("@Google", config.Google);
                command.Parameters.AddWithValue("@Introduction", config.Introduction);
                command.Parameters.AddWithValue("@Infocompany", config.Infocompany);
                command.Parameters.AddWithValue("@New_icon_w", config.New_icon_w);
                command.Parameters.AddWithValue("@New_icon_h", config.New_icon_h);
                command.Parameters.AddWithValue("@New_thumb_w", config.New_thumb_w);
                command.Parameters.AddWithValue("@New_thumb_h", config.New_thumb_h);
                command.Parameters.AddWithValue("@New_large_w", config.New_large_w);
                command.Parameters.AddWithValue("@New_large_h", config.New_large_h);
                command.Parameters.AddWithValue("@Product_icon_w", config.Product_icon_w);
                command.Parameters.AddWithValue("@Product_icon_h", config.Product_icon_h);
                command.Parameters.AddWithValue("@Product_thumb_w", config.Product_thumb_w);
                command.Parameters.AddWithValue("@Product_thumb_h", config.Product_thumb_h);
                command.Parameters.AddWithValue("@Product_large_w", config.Product_large_w);
                command.Parameters.AddWithValue("@Product_large_h", config.Product_large_h);
                command.Parameters.AddWithValue("@ProductNo", config.ProductNo);
                command.Parameters.AddWithValue("@ProductNoPage", config.ProductNoPage);
                command.Parameters.AddWithValue("@Currency", config.Currency);
                command.Parameters.AddWithValue("@Status", config.Status);
                command.Parameters.AddWithValue("@Closecomment", config.Closecomment);
                command.Parameters.AddWithValue("@Language", config.Language);
                command.Parameters.AddWithValue("@Support", config.Support);
                command.Parameters.AddWithValue("@Contact", config.Contact);
                command.Parameters.AddWithValue("@Intro_desc", config.Intro_desc);
                command.Parameters.AddWithValue("@email_from", config.Email_from);
                command.Parameters.AddWithValue("@email_to", config.Email_to);
                command.Parameters.AddWithValue("@counter", config.Counter);
                command.Parameters.AddWithValue("@info1", config.Info1);
                command.Parameters.AddWithValue("@info2", config.Info2);
                command.Parameters.AddWithValue("@WebName", config.WebName);
                command.Parameters.AddWithValue("@WebServerIP", config.WebServerIP);
                command.Parameters.AddWithValue("@WebMailServer", config.WebMailServer);
                command.Parameters.AddWithValue("@WebDomain", config.WebDomain);
                command.Parameters.AddWithValue("@IsPopup", config.IsPopup);
                command.Parameters.AddWithValue("@Popup", config.Popup);
                command.Parameters.AddWithValue("@Popup2", config.Popup2);
                connection.Open();
                if (command.ExecuteNonQuery() <= 0)
                {
                    throw new DataAccessException("Loi cap nhat config");
                }
                command.Dispose();
            }
        }
    }
}

