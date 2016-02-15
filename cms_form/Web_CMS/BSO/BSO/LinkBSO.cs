namespace BSO
{
    using DAO;
    using ETO;
    using System;
    using System.Data;

    public class LinkBSO
    {
        public void CreateLink(Link link)
        {
            new LinkDAO().CreateLink(link);
        }

        public void DeleteLink(int Id)
        {
            new LinkDAO().DeleteLink(Id);
        }

        public DataTable GetLinkAll()
        {
            LinkDAO linkDAO = new LinkDAO();
            return linkDAO.GetLinkAll();
        }

        public Link GetLinkById(int Id)
        {
            LinkDAO linkDAO = new LinkDAO();
            return linkDAO.GetLinkById(Id);
        }

        public void UpdateLink(Link link)
        {
            new LinkDAO().UpdateLink(link);
        }
    }
}

