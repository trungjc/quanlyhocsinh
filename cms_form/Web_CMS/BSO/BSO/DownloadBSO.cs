namespace BSO
{
    using DAO;
    using ETO;
    using System;
    using System.Data;

    public class DownloadBSO
    {
        public void CreateDownload(Download download)
        {
            new DownloadDAO().CreateDownload(download);
        }

        public void DeleteDownload(int nId)
        {
            new DownloadDAO().DeleteDownload(nId);
        }

        public void DeleteDownload(string strId)
        {
            string restr = strId.Remove(strId.LastIndexOf(",")).Replace(",", "','");
            new DownloadDAO().DeleteDownload(restr);
        }

        public void DownloadClickUpdate(int nId)
        {
            new DownloadDAO().DownloadClickUpdate(nId);
        }

        public DataTable DownloadFollow(int Id, int cId)
        {
            DataTable dataTable = new DataTable();
            DateTime PostTime = this.GetDownloadById(Id).PostDate;
            DataTable table = this.GetDownloadAll(Language.language);
            if (table != null)
            {
                dataTable = new DataView(table) { RowFilter = string.Concat(new object[] { "DownloadID <> ", Id, "and CateNewsID = ", cId }), Sort = "PostDate DESC " }.ToTable();
            }
            return dataTable;
        }

        public DataTable DownloadFollow(int Id, int cId, int n)
        {
            DownloadDAO downloadDAO = new DownloadDAO();
            return downloadDAO.DownloadFollow(Id, cId, n);
        }

        public DataTable DownloadSearch(string keyword, int cId, string lang)
        {
            DownloadDAO downloadDAO = new DownloadDAO();
            return downloadDAO.DownloadSearch(keyword, cId, lang);
        }

        public DataTable GetDownloadAll(string lang)
        {
            DownloadDAO downloadDAO = new DownloadDAO();
            return downloadDAO.GetDownloadAll(lang);
        }

        public DataTable GetDownloadByCate(int iCateId, string lang)
        {
            DataTable dataTable = new DataTable();
            DataTable table = this.GetDownloadAll(lang);
            if (table != null)
            {
                dataTable = new DataView(table) { RowFilter = "CateDownloadID = " + iCateId + " and Status = 'True' ", Sort = "PostDate Desc " }.ToTable();
            }
            return dataTable;
        }

        public DataTable GetDownloadByCateAll(string strCate)
        {
            string restr = strCate.Remove(strCate.LastIndexOf(",")).Replace(",", "','");
            DownloadDAO downloadDAO = new DownloadDAO();
            return downloadDAO.GetDownloadByCateAll(restr);
        }

        public DataTable GetDownloadByCateHomeAll(string strCate)
        {
            string restr = strCate.Remove(strCate.LastIndexOf(",")).Replace(",", "','");
            DownloadDAO downloadDAO = new DownloadDAO();
            return downloadDAO.GetDownloadByCateHomeAll(restr);
        }

        public DataTable GetDownloadByCateHomeAll(int n, string strCate)
        {
            string restr = strCate.Remove(strCate.LastIndexOf(",")).Replace(",", "','");
            DownloadDAO downloadDAO = new DownloadDAO();
            return downloadDAO.GetDownloadByCateHomeAll(n, restr);
        }

        public DataTable GetDownloadByCateHomeAll(int n, string strCate, string approval)
        {
            string restr = strCate.Remove(strCate.LastIndexOf(",")).Replace(",", "','");
            DownloadDAO downloadDAO = new DownloadDAO();
            return downloadDAO.GetDownloadByCateHomeAll(n, restr, approval);
        }

        public DataTable GetDownloadByCateHomeList(string strCate)
        {
            string restr = strCate.Remove(strCate.LastIndexOf(",")).Replace(",", "','");
            DownloadDAO downloadDAO = new DownloadDAO();
            return downloadDAO.GetDownloadByCateHomeList(restr);
        }

        public DataTable GetDownloadByCateHomeList(string strCate, int num)
        {
            string restr = strCate.Remove(strCate.LastIndexOf(",")).Replace(",", "','");
            DownloadDAO downloadDAO = new DownloadDAO();
            return downloadDAO.GetDownloadByCateHomeList(restr, num);
        }

        public DataTable GetDownloadByCateHomeList(string strCate, int num, string approval)
        {
            string restr = strCate.Remove(strCate.LastIndexOf(",")).Replace(",", "','");
            DownloadDAO downloadDAO = new DownloadDAO();
            return downloadDAO.GetDownloadByCateHomeList(restr, num, approval);
        }

        public Download GetDownloadById(int nId)
        {
            DownloadDAO downloadDAO = new DownloadDAO();
            return downloadDAO.GetDownloadById(nId);
        }

        public DataTable GetDownloadHot(string lang)
        {
            DownloadDAO downloadDAO = new DownloadDAO();
            return downloadDAO.GetDownloadHot(lang);
        }

        public DataTable GetDownloadHot(string lang, int n)
        {
            DownloadDAO downloadDAO = new DownloadDAO();
            return downloadDAO.GetDownloadHot(lang, n);
        }

        public DataTable GetDownloadHot(string lang, int n, string approval)
        {
            DownloadDAO downloadDAO = new DownloadDAO();
            return downloadDAO.GetDownloadHot(lang, n, approval);
        }

        public DataTable GetDownloadView(string lang)
        {
            DownloadDAO downloadDAO = new DownloadDAO();
            return downloadDAO.GetDownloadView(lang);
        }

        public DataTable GetDownloadViewHome(string lang)
        {
            DownloadDAO downloadDAO = new DownloadDAO();
            return downloadDAO.GetDownloadViewHome(lang);
        }

        public DataTable GetDownloadViewHome(string lang, int n)
        {
            DownloadDAO downloadDAO = new DownloadDAO();
            return downloadDAO.GetDownloadViewHome(lang, n);
        }

        public DataTable GetDownloadViewHome(string lang, int n, string approval)
        {
            DownloadDAO downloadDAO = new DownloadDAO();
            return downloadDAO.GetDownloadViewHome(lang, n, approval);
        }

        public DataTable GetDownloadViewHome(string lang, string strCate, int n)
        {
            string restr = strCate.Remove(strCate.LastIndexOf(",")).Replace(",", "','");
            DownloadDAO downloadDAO = new DownloadDAO();
            return downloadDAO.GetDownloadViewHome(lang, restr, n);
        }

        public void UpdateDownload(Download download)
        {
            new DownloadDAO().UpdateDownload(download);
        }

        public void UpdateDownload(string strId, string value)
        {
            string restr = strId.Remove(strId.LastIndexOf(",")).Replace(",", "','");
            new DownloadDAO().UpdateDownload(restr, value);
        }

        public void UpdateDownloadApproval(int Id, string value, string username, DateTime date)
        {
            new DownloadDAO().UpdateDownloadApproval(Id, value, username, date);
        }

        public void UpdateDownloadApproval(string strId, string value, string username, DateTime date)
        {
            string restr = strId.Remove(strId.LastIndexOf(",")).Replace(",", "','");
            new DownloadDAO().UpdateDownloadApproval(restr, value, username, date);
        }
    }
}

