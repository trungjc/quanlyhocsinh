namespace BSO
{
    using DAO;
    using ETO;
    using System;
    using System.Data;

    public class NewsGroupBSO
    {
        public void CreateNewsGroup(NewsGroup newsGroup)
        {
            new NewsGroupDAO().CreateNewsGroup(newsGroup);
        }

        public void DeleteNewsGroup(int nId)
        {
            new NewsGroupDAO().DeleteNewsGroup(nId);
        }

        public void DeleteNewsGroup(string strId)
        {
            string restr = strId.Remove(strId.LastIndexOf(",")).Replace(",", "','");
            new NewsGroupDAO().DeleteNewsGroup(restr);
        }

        public DataTable GetNewsGroupAll(string lang)
        {
            NewsGroupDAO newsGroupDAO = new NewsGroupDAO();
            return newsGroupDAO.GetNewsGroupAll(lang);
        }

        public DataTable GetNewsGroupAll(string lang, int group)
        {
            NewsGroupDAO newsGroupDAO = new NewsGroupDAO();
            return newsGroupDAO.GetNewsGroupAll(lang, group);
        }

        public DataTable GetNewsGroupAll(string lang, int group, string strCate)
        {
            string restr = strCate.Remove(strCate.LastIndexOf(",")).Replace(",", "','");
            NewsGroupDAO newsGroupDAO = new NewsGroupDAO();
            return newsGroupDAO.GetNewsGroupAll(lang, group, restr);
        }

        public DataTable GetNewsGroupByCate(int iCateId, string lang)
        {
            DataTable dataTable = new DataTable();
            DataTable table = this.GetNewsGroupAll(lang);
            if (table != null)
            {
                dataTable = new DataView(table) { RowFilter = "CateNewsID = " + iCateId + " and Status = 'True' ", Sort = "PostDate Desc " }.ToTable();
            }
            return dataTable;
        }

        public DataTable GetNewsGroupByCate(int iCateId, string lang, string approval)
        {
            DataTable dataTable = new DataTable();
            DataTable table = this.GetNewsGroupAll(lang);
            if (table != null)
            {
                dataTable = new DataView(table) { RowFilter = string.Concat(new object[] { "CateNewsID = ", iCateId, " and Status = 'True' and IsApproval =", approval }), Sort = "PostDate Desc " }.ToTable();
            }
            return dataTable;
        }

        public DataTable GetNewsGroupByCateAll(string strCate)
        {
            string restr = strCate.Remove(strCate.LastIndexOf(",")).Replace(",", "','");
            NewsGroupDAO newsGroupDAO = new NewsGroupDAO();
            return newsGroupDAO.GetNewsGroupByCateAll(restr);
        }

        public DataTable GetNewsGroupByCateAll(string strCate, int group)
        {
            string restr = strCate.Remove(strCate.LastIndexOf(",")).Replace(",", "','");
            NewsGroupDAO newsGroupDAO = new NewsGroupDAO();
            return newsGroupDAO.GetNewsGroupByCateAll(restr, group);
        }

        public DataTable GetNewsGroupByCateHomeAll(string strCate, int group)
        {
            string restr = strCate.Remove(strCate.LastIndexOf(",")).Replace(",", "','");
            NewsGroupDAO newsGroupDAO = new NewsGroupDAO();
            return newsGroupDAO.GetNewsGroupByCateHomeAll(restr, group);
        }

        public DataTable GetNewsGroupByCateHomeAll(int n, string strCate, int group)
        {
            string restr = strCate.Remove(strCate.LastIndexOf(",")).Replace(",", "','");
            NewsGroupDAO newsGroupDAO = new NewsGroupDAO();
            return newsGroupDAO.GetNewsGroupByCateHomeAll(n, restr, group);
        }

        public DataTable GetNewsGroupByCateHomeAll(int n, string strCate, string approval, int group)
        {
            string restr = strCate.Remove(strCate.LastIndexOf(",")).Replace(",", "','");
            NewsGroupDAO newsGroupDAO = new NewsGroupDAO();
            return newsGroupDAO.GetNewsGroupByCateHomeAll(n, restr, approval, group);
        }

        public DataTable GetNewsGroupByCateHomeList(string strCate, int group)
        {
            string restr = strCate.Remove(strCate.LastIndexOf(",")).Replace(",", "','");
            NewsGroupDAO newsGroupDAO = new NewsGroupDAO();
            return newsGroupDAO.GetNewsGroupByCateHomeList(restr, group);
        }

        public DataTable GetNewsGroupByCateHomeList(string strCate, int num, int group)
        {
            string restr = strCate.Remove(strCate.LastIndexOf(",")).Replace(",", "','");
            NewsGroupDAO newsGroupDAO = new NewsGroupDAO();
            return newsGroupDAO.GetNewsGroupByCateHomeList(restr, num, group);
        }

        public DataTable GetNewsGroupByCateHomeList(string strCate, int group, string aproval)
        {
            string restr = strCate.Remove(strCate.LastIndexOf(",")).Replace(",", "','");
            NewsGroupDAO newsGroupDAO = new NewsGroupDAO();
            return newsGroupDAO.GetNewsGroupByCateHomeList(restr, group, aproval);
        }

        public DataTable GetNewsGroupByCateHomeList(string strCate, int num, string approval, int group)
        {
            string restr = strCate.Remove(strCate.LastIndexOf(",")).Replace(",", "','");
            NewsGroupDAO newsGroupDAO = new NewsGroupDAO();
            return newsGroupDAO.GetNewsGroupByCateHomeList(restr, num, approval, group);
        }

        public DataTable GetNewsGroupByCateIsHomeAll(string strCate, int group)
        {
            string restr = strCate.Remove(strCate.LastIndexOf(",")).Replace(",", "','");
            NewsGroupDAO newsGroupDAO = new NewsGroupDAO();
            return newsGroupDAO.GetNewsGroupByCateIsHomeAll(restr, group);
        }

        public DataTable GetNewsGroupByCateIsHomeAll(int n, string strCate, int group)
        {
            string restr = strCate.Remove(strCate.LastIndexOf(",")).Replace(",", "','");
            NewsGroupDAO newsGroupDAO = new NewsGroupDAO();
            return newsGroupDAO.GetNewsGroupByCateIsHomeAll(n, restr, group);
        }

        public DataTable GetNewsGroupByCateIsHomeAll(int n, string strCate, string approval, int group)
        {
            string restr = strCate.Remove(strCate.LastIndexOf(",")).Replace(",", "','");
            NewsGroupDAO newsGroupDAO = new NewsGroupDAO();
            return newsGroupDAO.GetNewsGroupByCateIsHomeAll(n, restr, approval, group);
        }

        public NewsGroup GetNewsGroupById(int nId)
        {
            NewsGroupDAO newsGroupDAO = new NewsGroupDAO();
            return newsGroupDAO.GetNewsGroupById(nId);
        }

        public DataTable GetNewsGroupHot(string lang)
        {
            NewsGroupDAO newsGroupDAO = new NewsGroupDAO();
            return newsGroupDAO.GetNewsGroupHot(lang);
        }

        public DataTable GetNewsGroupHot(string lang, int group)
        {
            NewsGroupDAO newsGroupDAO = new NewsGroupDAO();
            return newsGroupDAO.GetNewsGroupHot(lang, group);
        }

        public DataTable GetNewsGroupHot(string lang, int n, int group)
        {
            NewsGroupDAO newsGroupDAO = new NewsGroupDAO();
            return newsGroupDAO.GetNewsGroupHot(lang, n, group);
        }

        public DataTable GetNewsGroupHot(string lang, int n, string approval, int group)
        {
            NewsGroupDAO newsGroupDAO = new NewsGroupDAO();
            return newsGroupDAO.GetNewsGroupHot(lang, n, approval, group);
        }

        public DataTable GetNewsGroupView(string lang)
        {
            NewsGroupDAO newsGroupDAO = new NewsGroupDAO();
            return newsGroupDAO.GetNewsGroupView(lang);
        }

        public DataTable GetNewsGroupView(string lang, int group)
        {
            NewsGroupDAO newsGroupDAO = new NewsGroupDAO();
            return newsGroupDAO.GetNewsGroupView(lang, group);
        }

        public DataTable GetNewsGroupViewAll(string lang, int n, int group)
        {
            NewsGroupDAO newsGroupDAO = new NewsGroupDAO();
            return newsGroupDAO.GetNewsGroupViewAll(lang, n, group);
        }

        public DataTable GetNewsGroupViewAll(string lang, int n, int group, string approval)
        {
            NewsGroupDAO newsGroupDAO = new NewsGroupDAO();
            return newsGroupDAO.GetNewsGroupViewAll(lang, n, group, approval);
        }

        public DataTable GetNewsGroupViewHome(string lang)
        {
            NewsGroupDAO newsGroupDAO = new NewsGroupDAO();
            return newsGroupDAO.GetNewsGroupViewHome(lang);
        }

        public DataTable GetNewsGroupViewHome(string lang, int group)
        {
            NewsGroupDAO newsGroupDAO = new NewsGroupDAO();
            return newsGroupDAO.GetNewsGroupViewHome(lang, group);
        }

        public DataTable GetNewsGroupViewHome(string lang, int n, int group)
        {
            NewsGroupDAO newsGroupDAO = new NewsGroupDAO();
            return newsGroupDAO.GetNewsGroupViewHome(lang, n, group);
        }

        public DataTable GetNewsGroupViewHome(string lang, int n, int cID, int group)
        {
            NewsGroupDAO newsGroupDAO = new NewsGroupDAO();
            return newsGroupDAO.GetNewsGroupViewHome(lang, n, cID, group);
        }

        public DataTable GetNewsGroupViewHome(string lang, int n, string approval, int group)
        {
            NewsGroupDAO newsGroupDAO = new NewsGroupDAO();
            return newsGroupDAO.GetNewsGroupViewHome(lang, n, approval, group);
        }

        public DataTable GetNewsGroupViewHome(string lang, string strCate, int n, int group)
        {
            string restr = strCate.Remove(strCate.LastIndexOf(",")).Replace(",", "','");
            NewsGroupDAO newsGroupDAO = new NewsGroupDAO();
            return newsGroupDAO.GetNewsGroupViewHome(lang, restr, n, group);
        }

        public void NewsGroupClickUpdate(int nId)
        {
            new NewsGroupDAO().NewsGroupClickUpdate(nId);
        }

        public DataTable NewsGroupFollow(int Id, int cId)
        {
            DataTable dataTable = new DataTable();
            DateTime PostTime = this.GetNewsGroupById(Id).PostDate;
            DataTable table = this.GetNewsGroupAll(Language.language);
            if (table != null)
            {
                dataTable = new DataView(table) { RowFilter = string.Concat(new object[] { "NewsGroupID <> ", Id, "and CateNewsID = ", cId }), Sort = "PostDate DESC " }.ToTable();
            }
            return dataTable;
        }

        public DataTable NewsGroupFollow(int Id, int cId, int n)
        {
            NewsGroupDAO newsGroupDAO = new NewsGroupDAO();
            return newsGroupDAO.NewsGroupFollow(Id, cId, n);
        }

        public DataTable NewsGroupFollow(int Id, int cId, int n, string approval)
        {
            NewsGroupDAO newsGroupDAO = new NewsGroupDAO();
            return newsGroupDAO.NewsGroupFollow(Id, cId, n, approval);
        }


        public DataTable NewsGroupSearch(string keyword, int cId, string lang)
        {
            NewsGroupDAO newsGroupDAO = new NewsGroupDAO();
            return newsGroupDAO.NewsGroupSearch(keyword, cId, lang);
        }

        public DataTable NewsGroupMainHomeModule(string lang)
        {
            NewsGroupDAO newsGroupDao = new NewsGroupDAO();
            return newsGroupDao.NewsGroupMainHomeModule(lang);
        }

        public void UpdateNewsGroup(NewsGroup newsGroup)
        {
            new NewsGroupDAO().UpdateNewsGroup(newsGroup);
        }

        public void UpdateNewsGroup(string strId, string value)
        {
            string restr = strId.Remove(strId.LastIndexOf(",")).Replace(",", "','");
            new NewsGroupDAO().UpdateNewsGroup(restr, value);
        }

        public void UpdateNewsGroupApproval(int Id, string value, string username, DateTime date)
        {
            new NewsGroupDAO().UpdateNewsGroupApproval(Id, value, username, date);
        }

        public void UpdateNewsGroupApproval(string strId, string value, string username, DateTime date)
        {
            string restr = strId.Remove(strId.LastIndexOf(",")).Replace(",", "','");
            new NewsGroupDAO().UpdateNewsGroupApproval(restr, value, username, date);
        }

        public void UpdateSetDefault(int id, int group)
        {
            new NewsGroupDAO().UpdateSetDefault(id, group);
        }

        public void UpdateSetNotDefault(int id, int group)
        {
            new NewsGroupDAO().UpdateSetNotDefault(id, group);
        }
    }
}

