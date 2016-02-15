namespace BSO
{
    using DAO;
    using ETO;
    using System;
    using System.Data;

    public class OfficialFileBSO
    {
        public void CreateOfficialFile(OfficialFile officialFile)
        {
            new OfficialFileDAO().CreateOfficialFile(officialFile);
        }

        public void DeleteOfficialFile(int Id)
        {
            new OfficialFileDAO().DeleteOfficialFile(Id);
        }

        public void DeleteOfficialFile(string strId)
        {
            string restr = strId.Remove(strId.LastIndexOf(",")).Replace(",", "','");
            new OfficialFileDAO().DeleteOfficialFile(restr);
        }

        public DataTable GetOfficialFileAll()
        {
            OfficialFileDAO officialFileDAO = new OfficialFileDAO();
            return officialFileDAO.GetOfficialFileAll();
        }

        public OfficialFile GetOfficialFileByID(int Id)
        {
            OfficialFileDAO officialFileDAO = new OfficialFileDAO();
            return officialFileDAO.GetOfficialFileByID(Id);
        }

        public DataTable GetOfficialFileByOfficial(int pId)
        {
            OfficialFileDAO officialFileDAO = new OfficialFileDAO();
            return officialFileDAO.GetOfficialFileByOfficial(pId);
        }

        public void UpdateOfficialFile(OfficialFile officialFile)
        {
            new OfficialFileDAO().UpdateOfficialFile(officialFile);
        }
    }
}

