namespace BSO
{
    using DAO;
    using ETO;
    using System;
    using System.Data;

    public class CompanyBSO
    {
        public void CompanyClickUpdate(int nId)
        {
            new CompanyDAO().CompanyClickUpdate(nId);
        }

        public DataTable CompanyFollow(int Id, int cId)
        {
            CompanyDAO companyDAO = new CompanyDAO();
            return companyDAO.CompanyFollow(Id, cId);
        }

        public DataTable CompanyFollow(int Id, int cId, int n)
        {
            CompanyDAO companyDAO = new CompanyDAO();
            return companyDAO.CompanyFollow(Id, cId, n);
        }

        public DataTable CompanyFollow(int Id, int cId, int n, int group)
        {
            CompanyDAO companyDAO = new CompanyDAO();
            return companyDAO.CompanyFollow(Id, cId, n, group);
        }

        public DataTable CompanySearch(string keyword, int cId, string lang)
        {
            CompanyDAO companyDAO = new CompanyDAO();
            return companyDAO.CompanySearch(keyword, cId, lang);
        }

        public DataTable CompanySearchCate(int cId, string lang)
        {
            CompanyDAO companyDAO = new CompanyDAO();
            return companyDAO.CompanySearchCate(cId, lang);
        }

        public void CreateCompany(Company company)
        {
            new CompanyDAO().CreateCompany(company);
        }

        public void DeleteCompany(int Id)
        {
            new CompanyDAO().DeleteCompany(Id);
        }

        public void DeleteCompany(string strId)
        {
            string restr = strId.Remove(strId.LastIndexOf(",")).Replace(",", "','");
            new CompanyDAO().DeleteCompany(restr);
        }

        public DataTable GetCompanyAll(string lang)
        {
            CompanyDAO companyDAO = new CompanyDAO();
            return companyDAO.GetCompanyAll(lang);
        }

        public DataTable GetCompanyAll(string lang, int group)
        {
            CompanyDAO companyDAO = new CompanyDAO();
            return companyDAO.GetCompanyAll(lang, group);
        }

        public DataTable GetCompanyAll(string lang, int group, int n)
        {
            CompanyDAO companyDAO = new CompanyDAO();
            return companyDAO.GetCompanyAll(lang, group, n);
        }

        public DataTable GetCompanyByCate(int iCateCompany, string lang)
        {
            DataTable dataTable = new DataTable();
            DataTable table = this.GetCompanyAll(lang);
            if (table != null)
            {
                dataTable = new DataView(table) { RowFilter = "Categories = " + iCateCompany }.ToTable();
            }
            return dataTable;
        }

        public DataTable GetCompanyByCate(int iCateCompany, string lang, int groupcate)
        {
            DataTable dataTable = new DataTable();
            DataTable table = this.GetCompanyAll(lang, groupcate);
            if (table != null)
            {
                dataTable = new DataView(table) { RowFilter = "Categories = " + iCateCompany }.ToTable();
            }
            return dataTable;
        }

        public DataTable GetCompanyByCateHomeList(string strCate)
        {
            string restr = strCate.Remove(strCate.LastIndexOf(",")).Replace(",", "','");
            CompanyDAO companyDAO = new CompanyDAO();
            return companyDAO.GetCompanyByCateHomeList(restr);
        }

        public DataTable GetCompanyByCateHomeList(int groupcate, string strCate)
        {
            string restr = strCate.Remove(strCate.LastIndexOf(",")).Replace(",", "','");
            CompanyDAO companyDAO = new CompanyDAO();
            return companyDAO.GetCompanyByCateHomeList(groupcate, restr);
        }

        public DataTable GetCompanyByCateHomeList(string strCate, int num)
        {
            string restr = strCate.Remove(strCate.LastIndexOf(",")).Replace(",", "','");
            CompanyDAO companyDAO = new CompanyDAO();
            return companyDAO.GetCompanyByCateHomeList(restr, num);
        }

        public DataTable GetCompanyByCateHomeList(string strCate, int num, int groupcate)
        {
            string restr = strCate.Remove(strCate.LastIndexOf(",")).Replace(",", "','");
            CompanyDAO companyDAO = new CompanyDAO();
            return companyDAO.GetCompanyByCateHomeList(restr, num, groupcate);
        }

        public DataTable GetCompanyByCateHot(int iCateCompany, string lang)
        {
            DataTable dataTable = new DataTable();
            DataTable table = this.GetCompanyAll(lang);
            if (table != null)
            {
                dataTable = new DataView(table) { RowFilter = "Categories = " + iCateCompany + "and IsHot = True" }.ToTable();
            }
            return dataTable;
        }

        public DataTable GetCompanyByCateHot(int iCateCompany, string lang, int groupcate)
        {
            DataTable dataTable = new DataTable();
            DataTable table = this.GetCompanyAll(lang, groupcate);
            if (table != null)
            {
                dataTable = new DataView(table) { RowFilter = "Categories = " + iCateCompany + "and IsHot = True" }.ToTable();
            }
            return dataTable;
        }

        public DataTable GetCompanyByCateNotIsHot(int iCateCompany, string lang)
        {
            DataTable dataTable = new DataTable();
            DataTable table = this.GetCompanyAll(lang);
            if (table != null)
            {
                dataTable = new DataView(table) { RowFilter = "Categories = " + iCateCompany + "and IsHot = False" }.ToTable();
            }
            return dataTable;
        }

        public DataTable GetCompanyByCateNotIsHot(int iCateCompany, string lang, int group)
        {
            DataTable dataTable = new DataTable();
            DataTable table = this.GetCompanyAll(lang, group);
            if (table != null)
            {
                dataTable = new DataView(table) { RowFilter = "Categories = " + iCateCompany + "and IsHot = False" }.ToTable();
            }
            return dataTable;
        }

        public Company GetCompanyById(int Id)
        {
            CompanyDAO companyDAO = new CompanyDAO();
            return companyDAO.GetCompanyById(Id);
        }

        public DataTable GetCompanyDefault(string lang)
        {
            CompanyDAO companyDAO = new CompanyDAO();
            return companyDAO.GetCompanyDefault(lang);
        }

        public DataTable GetCompanyDefault(string lang, int groupcate)
        {
            CompanyDAO companyDAO = new CompanyDAO();
            return companyDAO.GetCompanyDefault(lang, groupcate);
        }

        public DataTable GetCompanyHot(string lang)
        {
            CompanyDAO companyDAO = new CompanyDAO();
            return companyDAO.GetCompanyHot(lang);
        }

        public DataTable GetCompanyHot(string lang, int n)
        {
            CompanyDAO companyDAO = new CompanyDAO();
            return companyDAO.GetCompanyHot(lang, n);
        }

        public DataTable GetCompanyHot(string lang, int n, int groupcate)
        {
            CompanyDAO companyDAO = new CompanyDAO();
            return companyDAO.GetCompanyHot(lang, n, groupcate);
        }

        public DataTable GetCompanyTop10(string lang)
        {
            CompanyDAO companyDAO = new CompanyDAO();
            return companyDAO.GetCompanyTop10(lang);
        }

        public DataTable GetCompanyTop5(string lang)
        {
            CompanyDAO companyDAO = new CompanyDAO();
            return companyDAO.GetCompanyTop5(lang);
        }

        public void UpdateCompany(Company company)
        {
            new CompanyDAO().UpdateCompany(company);
        }

        public void UpdateCompany(string strId, string value)
        {
            string restr = strId.Remove(strId.LastIndexOf(",")).Replace(",", "','");
            new CompanyDAO().UpdateCompany(restr, value);
        }

        public void UpdateCompany(int Id, string value, string username, DateTime date)
        {
            new CompanyDAO().UpdateCompany(Id, value, username, date);
        }

        public void UpdateCompany(string strId, string value, string username, DateTime date)
        {
            string restr = strId.Remove(strId.LastIndexOf(",")).Replace(",", "','");
            new CompanyDAO().UpdateCompany(restr, value, username, date);
        }

        public void UpdateSetDefault(int Id)
        {
            new CompanyDAO().UpdateSetDefault(Id);
        }

        public void UpdateSetDefault(int Id, int group)
        {
            new CompanyDAO().UpdateSetDefault(Id, group);
        }

        public void UpdateSetNotDefault(int Id)
        {
            new CompanyDAO().UpdateSetNotDefault(Id);
        }

        public void UpdateSetNotDefault(int Id, int group)
        {
            new CompanyDAO().UpdateSetNotDefault(Id, group);
        }
    }
}

