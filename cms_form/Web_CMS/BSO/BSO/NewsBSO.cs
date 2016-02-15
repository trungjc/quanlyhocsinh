namespace BSO
{
    using DAO;
    using ETO;
    using System;
    using System.Data;

    public class NewsBSO
    {
        public void CreateNews(News news)
        {
            new NewsDAO().CreateNews(news);
        }

        public void DeleteNews(int nId)
        {
            new NewsDAO().DeleteNews(nId);
        }

        public void DeleteNews(string strId)
        {
            string restr = strId.Remove(strId.LastIndexOf(",")).Replace(",", "','");
            new NewsDAO().DeleteNews(restr);
        }

        public DataTable GetNewsAll(string lang)
        {
            NewsDAO newsDAO = new NewsDAO();
            return newsDAO.GetNewsAll(lang);
        }

        public DataTable GetNewsByCate(int iCateId, string lang)
        {
            DataTable dataTable = new DataTable();
            DataTable table = this.GetNewsAll(lang);
            if (table != null)
            {
                dataTable = new DataView(table) { RowFilter = "CateNewsID = " + iCateId + " and Status = 'True' ", Sort = "PostDate Desc " }.ToTable();
            }
            return dataTable;
        }

        public DataTable GetNewsByCateAll(string strCate)
        {
            string restr = strCate.Remove(strCate.LastIndexOf(",")).Replace(",", "','");
            NewsDAO newsDAO = new NewsDAO();
            return newsDAO.GetNewsByCateAll(restr);
        }

        public DataTable GetNewsByCateHomeAll(string strCate)
        {
            string restr = strCate.Remove(strCate.LastIndexOf(",")).Replace(",", "','");
            NewsDAO newsDAO = new NewsDAO();
            return newsDAO.GetNewsByCateHomeAll(restr);
        }

        public DataTable GetNewsByCateHomeAll(int n, string strCate)
        {
            string restr = strCate.Remove(strCate.LastIndexOf(",")).Replace(",", "','");
            NewsDAO newsDAO = new NewsDAO();
            return newsDAO.GetNewsByCateHomeAll(n, restr);
        }

        public DataTable GetNewsByCateHomeAll(int n, string strCate, string approval)
        {
            string restr = strCate.Remove(strCate.LastIndexOf(",")).Replace(",", "','");
            NewsDAO newsDAO = new NewsDAO();
            return newsDAO.GetNewsByCateHomeAll(n, restr, approval);
        }

        public DataTable GetNewsByCateHomeList(string strCate)
        {
            string restr = strCate.Remove(strCate.LastIndexOf(",")).Replace(",", "','");
            NewsDAO newsDAO = new NewsDAO();
            return newsDAO.GetNewsByCateHomeList(restr);
        }

        public DataTable GetNewsByCateHomeList(string strCate, int num)
        {
            string restr = strCate.Remove(strCate.LastIndexOf(",")).Replace(",", "','");
            NewsDAO newsDAO = new NewsDAO();
            return newsDAO.GetNewsByCateHomeList(restr, num);
        }

        public DataTable GetNewsByCateHomeList(string strCate, int num, string approval)
        {
            string restr = strCate.Remove(strCate.LastIndexOf(",")).Replace(",", "','");
            NewsDAO newsDAO = new NewsDAO();
            return newsDAO.GetNewsByCateHomeList(restr, num, approval);
        }

        public News GetNewsById(int nId)
        {
            NewsDAO newsDAO = new NewsDAO();
            return newsDAO.GetNewsById(nId);
        }

        public DataTable GetNewsHot(string lang)
        {
            NewsDAO newsDAO = new NewsDAO();
            return newsDAO.GetNewsHot(lang);
        }

        public DataTable GetNewsHot(string lang, int n)
        {
            NewsDAO newsDAO = new NewsDAO();
            return newsDAO.GetNewsHot(lang, n);
        }

        public DataTable GetNewsHot(string lang, int n, string approval)
        {
            NewsDAO newsDAO = new NewsDAO();
            return newsDAO.GetNewsHot(lang, n, approval);
        }

        public DataTable GetNewsView(string lang)
        {
            NewsDAO newsDAO = new NewsDAO();
            return newsDAO.GetNewsView(lang);
        }

        public DataTable GetNewsViewHome(string lang)
        {
            NewsDAO newsDAO = new NewsDAO();
            return newsDAO.GetNewsViewHome(lang);
        }

        public DataTable GetNewsViewHome(string lang, int n)
        {
            NewsDAO newsDAO = new NewsDAO();
            return newsDAO.GetNewsViewHome(lang, n);
        }

        public DataTable GetNewsViewHome(string lang, int n, int cID)
        {
            NewsDAO newsDAO = new NewsDAO();
            return newsDAO.GetNewsViewHome(lang, n, cID);
        }

        public DataTable GetNewsViewHome(string lang, int n, string approval)
        {
            NewsDAO newsDAO = new NewsDAO();
            return newsDAO.GetNewsViewHome(lang, n, approval);
        }

        public DataTable GetNewsViewHome(string lang, string strCate, int n)
        {
            string restr = strCate.Remove(strCate.LastIndexOf(",")).Replace(",", "','");
            NewsDAO newsDAO = new NewsDAO();
            return newsDAO.GetNewsViewHome(lang, restr, n);
        }

        public void NewsClickUpdate(int nId)
        {
            new NewsDAO().NewsClickUpdate(nId);
        }

        public DataTable NewsFollow(int Id, int cId)
        {
            DataTable dataTable = new DataTable();
            DateTime PostTime = this.GetNewsById(Id).PostDate;
            DataTable table = this.GetNewsAll(Language.language);
            if (table != null)
            {
                dataTable = new DataView(table) { RowFilter = string.Concat(new object[] { "NewsID <> ", Id, "and CateNewsID = ", cId }), Sort = "PostDate DESC " }.ToTable();
            }
            return dataTable;
        }

        public DataTable NewsFollow(int Id, int cId, int n)
        {
            NewsDAO newsDAO = new NewsDAO();
            return newsDAO.NewsFollow(Id, cId, n);
        }

        public DataTable NewsSearch(string keyword, int cId, string lang)
        {
            NewsDAO newsDAO = new NewsDAO();
            return newsDAO.NewsSearch(keyword, cId, lang);
        }

        public void UpdateNews(News news)
        {
            new NewsDAO().UpdateNews(news);
        }

        public void UpdateNews(string strId, string value)
        {
            string restr = strId.Remove(strId.LastIndexOf(",")).Replace(",", "','");
            new NewsDAO().UpdateNews(restr, value);
        }

        public void UpdateNewsApproval(int Id, string value, string username, DateTime date)
        {
            new NewsDAO().UpdateNewsApproval(Id, value, username, date);
        }

        public void UpdateNewsApproval(string strId, string value, string username, DateTime date)
        {
            string restr = strId.Remove(strId.LastIndexOf(",")).Replace(",", "','");
            new NewsDAO().UpdateNewsApproval(restr, value, username, date);
        }
    }
}

