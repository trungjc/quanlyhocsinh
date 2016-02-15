namespace BSO
{
    using DAO;
    using ETO;
    using System;
    using System.Data;

    public class NewsCommentBSO
    {
        public void CreateNewsComment(NewsComment newsComment)
        {
            new NewsCommentDAO().CreateNewsComment(newsComment);
        }

        public void DeleteNewsComment(int commentID)
        {
            new NewsCommentDAO().DeleteNewsComment(commentID);
        }

        public void DeleteNewsComment(string strId)
        {
            string restr = strId.Remove(strId.LastIndexOf(",")).Replace(",", "','");
            new NewsCommentDAO().DeleteNewsComment(restr);
        }

        public DataTable GetAllGroupCateNewsComment(int group)
        {
            NewsCommentDAO newsCommentDAO = new NewsCommentDAO();
            return newsCommentDAO.GetAllGroupCateNewsComment(group);
        }

        public DataTable GetAllNewsComment()
        {
            NewsCommentDAO newsCommentDAO = new NewsCommentDAO();
            return newsCommentDAO.GetAllNewsComment();
        }

        public DataTable GetAllNewsGroupComment(int group)
        {
            NewsCommentDAO newsCommentDAO = new NewsCommentDAO();
            return newsCommentDAO.GetAllNewsGroupComment(group);
        }

        public DataTable GetAllNewsGroupComment(int ID, int group)
        {
            NewsCommentDAO newsCommentDAO = new NewsCommentDAO();
            return newsCommentDAO.GetAllNewsGroupComment(ID, group);
        }

        public DataTable GetAllViewAnnounceComment()
        {
            NewsCommentDAO newsCommentDAO = new NewsCommentDAO();
            return newsCommentDAO.GetAllViewAnnounceComment();
        }

        public DataTable GetAllViewAnnounceComment(int ID)
        {
            NewsCommentDAO newsCommentDAO = new NewsCommentDAO();
            return newsCommentDAO.GetAllViewAnnounceComment(ID);
        }

        public DataTable GetAllViewCompanyComment()
        {
            NewsCommentDAO newsCommentDAO = new NewsCommentDAO();
            return newsCommentDAO.GetAllViewCompanyComment();
        }

        public DataTable GetAllViewCompanyComment(int ID)
        {
            NewsCommentDAO newsCommentDAO = new NewsCommentDAO();
            return newsCommentDAO.GetAllViewCompanyComment(ID);
        }

        public DataTable GetAllViewDownloadComment()
        {
            NewsCommentDAO newsCommentDAO = new NewsCommentDAO();
            return newsCommentDAO.GetAllViewDownloadComment();
        }

        public DataTable GetAllViewDownloadComment(int ID)
        {
            NewsCommentDAO newsCommentDAO = new NewsCommentDAO();
            return newsCommentDAO.GetAllViewDownloadComment(ID);
        }

        public DataTable GetAllViewNewsComment()
        {
            NewsCommentDAO newsCommentDAO = new NewsCommentDAO();
            return newsCommentDAO.GetAllViewNewsComment();
        }

        public DataTable GetAllViewNewsComment(int ID)
        {
            NewsCommentDAO newsCommentDAO = new NewsCommentDAO();
            return newsCommentDAO.GetAllViewNewsComment(ID);
        }

        public NewsComment GetNewsCommentById(int commentID)
        {
            NewsCommentDAO newsCommentDAO = new NewsCommentDAO();
            return newsCommentDAO.GetNewsCommentById(commentID);
        }

        public DataTable GetNewsCommentByNewsID(int newsID)
        {
            NewsCommentDAO newsCommentDAO = new NewsCommentDAO();
            return newsCommentDAO.GetNewsCommentByNewsID(newsID);
        }

        public void UpdateNewsComment(NewsComment newsComment)
        {
            new NewsCommentDAO().UpdateNewsComment(newsComment);
        }

        public void UpdateNewsComment(string strId, string value)
        {
            string restr = strId.Remove(strId.LastIndexOf(",")).Replace(",", "','");
            new NewsCommentDAO().UpdateNewsComment(restr, value);
        }

        public void UpdateNewsComment(int Id, string value, string username, DateTime date)
        {
            new NewsCommentDAO().UpdateNewsComment(Id, value, username, date);
        }

        public void UpdateNewsComment(string strId, string value, string username, DateTime date)
        {
            string restr = strId.Remove(strId.LastIndexOf(",")).Replace(",", "','");
            new NewsCommentDAO().UpdateNewsComment(restr, value, username, date);
        }
    }
}

