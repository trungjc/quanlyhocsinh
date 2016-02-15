namespace BSO
{
    using DAO;
    using ETO;
    using System;
    using System.Data;

    public class RSSBSO
    {
        public void CreateRSS(RSS rss)
        {
            new RSSDAO().CreateRSS(rss);
        }

        public void DeleteRSS(int Id)
        {
            new RSSDAO().DeleteRSS(Id);
        }

        public DataTable GetRSSAll()
        {
            RSSDAO rssDAO = new RSSDAO();
            return rssDAO.GetRSSAll();
        }

        public RSS GetRSSById(int Id)
        {
            RSSDAO rssDAO = new RSSDAO();
            return rssDAO.GetRSSById(Id);
        }

        public void UpdateRSS(RSS rss)
        {
            new RSSDAO().UpdateRSS(rss);
        }
    }
}

