namespace BSO
{
    using DAO;
    using ETO;
    using System;
    using System.Data;

    public class PageCommentBSO
    {
        public void CreatePageComment(PageComment pageComment)
        {
            new PageCommentDAO().CreatePageComment(pageComment);
        }

        public void DeletePageComment(int commentID)
        {
            new PageCommentDAO().DeletePageComment(commentID);
        }

        public void DeletePageComment(string strId)
        {
            string restr = strId.Remove(strId.LastIndexOf(",")).Replace(",", "','");
            new PageCommentDAO().DeletePageComment(restr);
        }

        public DataTable GetAllGroupCatePageComment(string group)
        {
            PageCommentDAO pageCommentDAO = new PageCommentDAO();
            return pageCommentDAO.GetAllGroupCatePageComment(group);
        }

        public DataTable GetAllGroupCateViewPageComment(string group)
        {
            PageCommentDAO pageCommentDAO = new PageCommentDAO();
            return pageCommentDAO.GetAllGroupCateViewPageComment(group);
        }

        public DataTable GetAllPageComment()
        {
            PageCommentDAO pageCommentDAO = new PageCommentDAO();
            return pageCommentDAO.GetAllPageComment();
        }

        public DataTable GetAllViewPageComment()
        {
            PageCommentDAO pageCommentDAO = new PageCommentDAO();
            return pageCommentDAO.GetAllViewPageComment();
        }

        public PageComment GetPageCommentById(int commentID)
        {
            PageCommentDAO pageCommentDAO = new PageCommentDAO();
            return pageCommentDAO.GetPageCommentById(commentID);
        }

        public DataTable GetPageCommentByPageID(int pageID)
        {
            PageCommentDAO pageCommentDAO = new PageCommentDAO();
            return pageCommentDAO.GetPageCommentByPageID(pageID);
        }

        public void UpdatePageComment(PageComment pageComment)
        {
            new PageCommentDAO().UpdatePageComment(pageComment);
        }

        public void UpdatePageComment(string strId, string value)
        {
            string restr = strId.Remove(strId.LastIndexOf(",")).Replace(",", "','");
            new PageCommentDAO().UpdatePageComment(restr, value);
        }

        public void UpdatePageComment(int Id, string value, string username, DateTime date)
        {
            new PageCommentDAO().UpdatePageComment(Id, value, username, date);
        }

        public void UpdatePageComment(string strId, string value, string username, DateTime date)
        {
            string restr = strId.Remove(strId.LastIndexOf(",")).Replace(",", "','");
            new PageCommentDAO().UpdatePageComment(restr, value, username, date);
        }
    }
}

