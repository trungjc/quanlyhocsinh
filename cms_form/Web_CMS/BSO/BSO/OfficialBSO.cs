namespace BSO
{
    using DAO;
    using ETO;
    using System;
    using System.Data;

    public class OfficialBSO
    {
        public void CreateOfficial(Official official)
        {
            new OfficialDAO().CreateOfficial(official);
        }

        public void DeleteOfficial(int Id)
        {
            new OfficialDAO().DeleteOfficial(Id);
        }

        public void DeleteOfficial(string strId)
        {
            string restr = strId.Remove(strId.LastIndexOf(",")).Replace(",", "','");
            new OfficialDAO().DeleteOfficial(restr);
        }

        public DataTable GetOfficialAll()
        {
            OfficialDAO officialDAO = new OfficialDAO();
            return officialDAO.GetOfficialAll();
        }

        public DataTable GetOfficialByCate(int iCateId)
        {
            DataTable dataTable = new DataTable();
            DataTable table = this.GetOfficialAll();
            if (table != null)
            {
                dataTable = new DataView(table) { RowFilter = "CateOfficialID = " + iCateId + " and Status = 'True' ", Sort = "DatePublic Desc " }.ToTable();
            }
            return dataTable;
        }

        public DataTable GetOfficialByCate(int iCateId, string approval)
        {
            DataTable dataTable = new DataTable();
            DataTable table = this.GetOfficialAll();
            if (table != null)
            {
                dataTable = new DataView(table) { RowFilter = string.Concat(new object[] { "CateOfficialID = ", iCateId, " and Status = 'True' And IsApproval = ", approval }), Sort = "DatePublic Desc " }.ToTable();
            }
            return dataTable;
        }

        public DataTable GetOfficialByCateHomeList(string strCate)
        {
            string restr = strCate.Remove(strCate.LastIndexOf(",")).Replace(",", "','");
            OfficialDAO officialDAO = new OfficialDAO();
            return officialDAO.GetOfficialByCateHomeList(restr);
        }

        public DataTable GetOfficialByCateHomeList(string strCate, int num)
        {
            string restr = strCate.Remove(strCate.LastIndexOf(",")).Replace(",", "','");
            OfficialDAO officialDAO = new OfficialDAO();
            return officialDAO.GetOfficialByCateHomeList(restr, num);
        }

        public DataTable GetOfficialByCateHomeList(string strCate, int num, string approval)
        {
            string restr = strCate.Remove(strCate.LastIndexOf(",")).Replace(",", "','");
            OfficialDAO officialDAO = new OfficialDAO();
            return officialDAO.GetOfficialByCateHomeList(restr, num, approval);
        }

        public Official GetOfficialById(int Id)
        {
            OfficialDAO officialDAO = new OfficialDAO();
            return officialDAO.GetOfficialById(Id);
        }

        public DataTable GetOfficialNews(int num)
        {
            OfficialDAO officialDAO = new OfficialDAO();
            return officialDAO.GetOfficialNews(num);
        }

        public DataTable GetOfficialNews(int num, string approval)
        {
            OfficialDAO officialDAO = new OfficialDAO();
            return officialDAO.GetOfficialNews(num, approval);
        }

        public void OfficialClickUpdate(int nId)
        {
            new OfficialDAO().OfficialClickUpdate(nId);
        }

        public DataTable OfficialFollow(int Id, int cId)
        {
            DataTable dataTable = new DataTable();
            DateTime PostTime = this.GetOfficialById(Id).DatePublic;
            DataTable table = this.GetOfficialAll();
            if (table != null)
            {
                dataTable = new DataView(table) { RowFilter = string.Concat(new object[] { "OfficialID < ", Id, "and CateOfficialID = ", cId, " And  status = 'True'" }), Sort = "DatePublic DESC " }.ToTable();
            }
            return dataTable;
        }

        public DataTable OfficialFollow(int Id, int cId, string approval)
        {
            DataTable dataTable = new DataTable();
            DateTime PostTime = this.GetOfficialById(Id).DatePublic;
            DataTable table = this.GetOfficialAll();
            if (table != null)
            {
                dataTable = new DataView(table) { RowFilter = string.Concat(new object[] { "OfficialID < ", Id, "and CateOfficialID = ", cId, " and status =1 and IsApproval = ", approval }), Sort = "DatePublic DESC " }.ToTable();
            }
            return dataTable;
        }

        public DataTable OfficialSearch(string keyword, int cId, string lang)
        {
            OfficialBSO officialDAO = new OfficialBSO();
            return officialDAO.OfficialSearch(keyword, cId, lang);
        }

        public void UpdateOfficial(Official official)
        {
            new OfficialDAO().UpdateOfficial(official);
        }

        public void UpdateOfficial(string strId, string value)
        {
            string restr = strId.Remove(strId.LastIndexOf(",")).Replace(",", "','");
            new OfficialDAO().UpdateOfficial(restr, value);
        }

        public void UpdateOfficial(int Id, string value, string username, DateTime date)
        {
            new OfficialDAO().UpdateOfficial(Id, value, username, date);
        }

        public void UpdateOfficial(string strId, string value, string username, DateTime date)
        {
            string restr = strId.Remove(strId.LastIndexOf(",")).Replace(",", "','");
            new OfficialDAO().UpdateOfficial(restr, value, username, date);
        }
    }
}

