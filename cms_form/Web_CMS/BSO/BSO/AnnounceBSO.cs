namespace BSO
{
    using DAO;
    using ETO;
    using System;
    using System.Data;

    public class AnnounceBSO
    {
        public void AnnounceClickUpdate(int nId)
        {
            new AnnounceDAO().AnnounceClickUpdate(nId);
        }

        public DataTable AnnounceFollow(int Id, int cId)
        {
            DataTable dataTable = new DataTable();
            DateTime PostTime = this.GetAnnounceById(Id).PostDate;
            DataTable table = this.GetAnnounceAll(Language.language);
            if (table != null)
            {
                dataTable = new DataView(table) { RowFilter = string.Concat(new object[] { "AnnounceID <> ", Id, "and CateAnnounceID = ", cId }), Sort = "PostDate DESC " }.ToTable();
            }
            return dataTable;
        }

        public DataTable AnnounceFollow(int Id, int cId, int n)
        {
            AnnounceDAO announceDAO = new AnnounceDAO();
            return announceDAO.AnnounceFollow(Id, cId, n);
        }

        public DataTable AnnounceSearch(string keyword, int cId, string lang)
        {
            AnnounceDAO announceDAO = new AnnounceDAO();
            return announceDAO.AnnounceSearch(keyword, cId, lang);
        }

        public void CreateAnnounce(Announce announce)
        {
            new AnnounceDAO().CreateAnnounce(announce);
        }

        public void DeleteAnnounce(int nId)
        {
            new AnnounceDAO().DeleteAnnounce(nId);
        }

        public void DeleteAnnounce(string strId)
        {
            string restr = strId.Remove(strId.LastIndexOf(",")).Replace(",", "','");
            new AnnounceDAO().DeleteAnnounce(restr);
        }

        public DataTable GetAnnounceAll(string lang)
        {
            AnnounceDAO announceDAO = new AnnounceDAO();
            return announceDAO.GetAnnounceAll(lang);
        }

        public DataTable GetAnnounceByCate(int iCateId, string lang)
        {
            DataTable dataTable = new DataTable();
            DataTable table = this.GetAnnounceAll(lang);
            if (table != null)
            {
                dataTable = new DataView(table) { RowFilter = "CateAnnounceID = " + iCateId + " and Status = 'True' ", Sort = "PostDate Desc " }.ToTable();
            }
            return dataTable;
        }

        public DataTable GetAnnounceByCateAll(string strCate)
        {
            string restr = strCate.Remove(strCate.LastIndexOf(",")).Replace(",", "','");
            AnnounceDAO announceDAO = new AnnounceDAO();
            return announceDAO.GetAnnounceByCateAll(restr);
        }

        public DataTable GetAnnounceByCateHomeAll(string strCate)
        {
            string restr = strCate.Remove(strCate.LastIndexOf(",")).Replace(",", "','");
            AnnounceDAO announceDAO = new AnnounceDAO();
            return announceDAO.GetAnnounceByCateHomeAll(restr);
        }

        public DataTable GetAnnounceByCateHomeAll(int n, string strCate)
        {
            string restr = strCate.Remove(strCate.LastIndexOf(",")).Replace(",", "','");
            AnnounceDAO announceDAO = new AnnounceDAO();
            return announceDAO.GetAnnounceByCateHomeAll(n, restr);
        }

        public DataTable GetAnnounceByCateHomeAll(int n, string strCate, string approval)
        {
            string restr = strCate.Remove(strCate.LastIndexOf(",")).Replace(",", "','");
            AnnounceDAO announceDAO = new AnnounceDAO();
            return announceDAO.GetAnnounceByCateHomeAll(n, restr, approval);
        }

        public DataTable GetAnnounceByCateHomeList(string strCate)
        {
            string restr = strCate.Remove(strCate.LastIndexOf(",")).Replace(",", "','");
            AnnounceDAO announceDAO = new AnnounceDAO();
            return announceDAO.GetAnnounceByCateHomeList(restr);
        }

        public DataTable GetAnnounceByCateHomeList(string strCate, int num)
        {
            string restr = strCate.Remove(strCate.LastIndexOf(",")).Replace(",", "','");
            AnnounceDAO announceDAO = new AnnounceDAO();
            return announceDAO.GetAnnounceByCateHomeList(restr, num);
        }

        public DataTable GetAnnounceByCateHomeList(string strCate, int num, string approval)
        {
            string restr = strCate.Remove(strCate.LastIndexOf(",")).Replace(",", "','");
            AnnounceDAO announceDAO = new AnnounceDAO();
            return announceDAO.GetAnnounceByCateHomeList(restr, num, approval);
        }

        public DataTable GetAnnounceByCateIsHomeAll(string strCate)
        {
            string restr = strCate.Remove(strCate.LastIndexOf(",")).Replace(",", "','");
            AnnounceDAO announceDAO = new AnnounceDAO();
            return announceDAO.GetAnnounceByCateIsHomeAll(restr);
        }

        public DataTable GetAnnounceByCateIsHomeAll(int n, string strCate)
        {
            string restr = strCate.Remove(strCate.LastIndexOf(",")).Replace(",", "','");
            AnnounceDAO announceDAO = new AnnounceDAO();
            return announceDAO.GetAnnounceByCateIsHomeAll(n, restr);
        }

        public DataTable GetAnnounceByCateIsHomeAll(int n, string strCate, string approval)
        {
            string restr = strCate.Remove(strCate.LastIndexOf(",")).Replace(",", "','");
            AnnounceDAO announceDAO = new AnnounceDAO();
            return announceDAO.GetAnnounceByCateIsHomeAll(n, restr, approval);
        }

        public Announce GetAnnounceById(int nId)
        {
            AnnounceDAO announceDAO = new AnnounceDAO();
            return announceDAO.GetAnnounceById(nId);
        }

        public DataTable GetAnnounceHot(string lang)
        {
            AnnounceDAO announceDAO = new AnnounceDAO();
            return announceDAO.GetAnnounceHot(lang);
        }

        public DataTable GetAnnounceHot(string lang, int n)
        {
            AnnounceDAO announceDAO = new AnnounceDAO();
            return announceDAO.GetAnnounceHot(lang, n);
        }

        public DataTable GetAnnounceHot(string lang, int n, string approval)
        {
            AnnounceDAO announceDAO = new AnnounceDAO();
            return announceDAO.GetAnnounceHot(lang, n, approval);
        }

        public DataTable GetAnnounceNews(int num)
        {
            AnnounceDAO announceDAO = new AnnounceDAO();
            return announceDAO.GetAnnounceNews(num);
        }

        public DataTable GetAnnounceView(string lang)
        {
            AnnounceDAO announceDAO = new AnnounceDAO();
            return announceDAO.GetAnnounceView(lang);
        }

        public DataTable GetAnnounceViewHome(string lang)
        {
            AnnounceDAO announceDAO = new AnnounceDAO();
            return announceDAO.GetAnnounceViewHome(lang);
        }

        public DataTable GetAnnounceViewHome(string lang, int n)
        {
            AnnounceDAO announceDAO = new AnnounceDAO();
            return announceDAO.GetAnnounceViewHome(lang, n);
        }

        public DataTable GetAnnounceViewHome(string lang, int n, string approval)
        {
            AnnounceDAO announceDAO = new AnnounceDAO();
            return announceDAO.GetAnnounceViewHome(lang, n, approval);
        }

        public void UpdateAnnounce(Announce announce)
        {
            new AnnounceDAO().UpdateAnnounce(announce);
        }

        public void UpdateAnnounce(string strId, string value)
        {
            string restr = strId.Remove(strId.LastIndexOf(",")).Replace(",", "','");
            new AnnounceDAO().UpdateAnnounce(restr, value);
        }

        public void UpdateAnnounceApproval(int Id, string value, string username, DateTime date)
        {
            new AnnounceDAO().UpdateAnnounceApproval(Id, value, username, date);
        }

        public void UpdateAnnounceApproval(string strId, string value, string username, DateTime date)
        {
            string restr = strId.Remove(strId.LastIndexOf(",")).Replace(",", "','");
            new AnnounceDAO().UpdateAnnounceApproval(restr, value, username, date);
        }
    }
}

