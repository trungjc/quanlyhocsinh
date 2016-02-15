namespace BSO
{
    using DAO;
    using ETO;
    using System;

    public class ConfigBSO
    {
        public Config GetAllConfig(string language)
        {
            ConfigDAO configDAO = new ConfigDAO();
            return configDAO.GetAllConfig(language);
        }

        public void UpdateConfig(Config config)
        {
            new ConfigDAO().UpdateConfig(config);
        }
    }
}

