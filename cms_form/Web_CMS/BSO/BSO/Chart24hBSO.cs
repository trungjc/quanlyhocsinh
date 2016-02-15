namespace BSO
{
    using DAO;
    using ETO;
    using System;
    using System.Data;

    public class Chart24hBSO
    {
        public void CreateChart24h(Chart24h chart24h)
        {
            new Chart24hDAO().CreateChart24h(chart24h);
        }

        public void DeleteChart24h(int Id)
        {
            new Chart24hDAO().DeleteChart24h(Id);
        }

        public DataTable GetChart24hAll()
        {
            Chart24hDAO chart24hDAO = new Chart24hDAO();
            return chart24hDAO.GetChart24hAll();
        }

        public Chart24h GetChart24hById(int Id)
        {
            Chart24hDAO chart24hDAO = new Chart24hDAO();
            return chart24hDAO.GetChart24hById(Id);
        }

        public DataTable GetChart24hDraw()
        {
            Chart24hDAO chart24hDAO = new Chart24hDAO();
            return chart24hDAO.GetChart24hDraw();
        }

        public DataTable GetChart24hDraw(DateTime _postDate)
        {
            Chart24hDAO chart24hDAO = new Chart24hDAO();
            return chart24hDAO.GetChart24hDraw(_postDate);
        }

        public DataTable GetChart24hDraw3()
        {
            Chart24hDAO chart24hDAO = new Chart24hDAO();
            return chart24hDAO.GetChart24hDraw3();
        }

        public DataTable GetChart24hDraw3(DateTime _postDate)
        {
            Chart24hDAO chart24hDAO = new Chart24hDAO();
            return chart24hDAO.GetChart24hDraw3(_postDate);
        }

        public DataTable GetChart24hTop1()
        {
            Chart24hDAO chart24hDAO = new Chart24hDAO();
            return chart24hDAO.GetChart24hTop1();
        }

        public void UpdateChart24h(Chart24h chart24h)
        {
            new Chart24hDAO().UpdateChart24h(chart24h);
        }
    }
}

