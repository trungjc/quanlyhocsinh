namespace BSO
{
    using DAO;
    using ETO;
    using System;
    using System.Data;

    public class CateNewsGroupBSO
    {
        public void CateNewsGroupUpOrder(int cId, int cOrder)
        {
            new CateNewsGroupDAO().CateNewsGroupUpOrder(cId, cOrder);
        }

        public void CreateCateNewsGroup(CateNewsGroup cateNewsGroup)
        {
            new CateNewsGroupDAO().CreateCateNewsGroup(cateNewsGroup);
        }

        public void DeleteCateNewsGroup(int Id)
        {
            new CateNewsGroupDAO().DeleteCateNewsGroup(Id);
        }


        public DataTable GetCateLanguage(string lang)
        {
            CateNewsGroupDAO CateDAO = new CateNewsGroupDAO();
            return CateDAO.GetCateAll(lang);
        }


        public DataTable GetCateNewsGroupAll()
        {

            CateNewsGroupDAO cateNewsGroupDAO = new CateNewsGroupDAO();
            return cateNewsGroupDAO.GetCateNewsGroupAll();
        }

        public CateNewsGroup GetCateNewsGroupByGroupCate(int groupcate)
        {
            CateNewsGroupDAO cateNewsGroupDAO = new CateNewsGroupDAO();
            return cateNewsGroupDAO.GetCateNewsGroupByGroupCate(groupcate);
        }

        public DataTable CateNewsGetByGroup(int groupcate)
        {
            CateNewsGroupDAO cateNewsGroupDAO = new CateNewsGroupDAO();
            return cateNewsGroupDAO.CateNewsGetByGroup(groupcate);
        }

        //dungdq get menu cấp 3
        public DataTable CateNewsGetByMenuCap3(int cateID)
        {
            CateNewsGroupDAO cateNewsGroupDAO = new CateNewsGroupDAO();
            return cateNewsGroupDAO.CateNewsGetByMenuCap3(cateID);
        }
        //
        public CateNewsGroup GetCateNewsGroupById(int Id)
        {
            CateNewsGroupDAO cateNewsGroupDAO = new CateNewsGroupDAO();
            return cateNewsGroupDAO.GetCateNewsGroupById(Id);
        }

        public DataTable GetCateNewsGroupHomeAll()
        {
            CateNewsGroupDAO cateNewsGroupDAO = new CateNewsGroupDAO();
            return cateNewsGroupDAO.GetCateNewsGroupHomeAll();
        }

        public DataTable GetCateNewsGroupMenuAll()
        {
            CateNewsGroupDAO cateNewsGroupDAO = new CateNewsGroupDAO();
            return cateNewsGroupDAO.GetCateNewsGroupMenuAll();
        }

        public DataTable GetCateNewsGroupNewAll()
        {
            CateNewsGroupDAO cateNewsGroupDAO = new CateNewsGroupDAO();
            return cateNewsGroupDAO.GetCateNewsGroupNewAll();
        }

        public DataTable GetCateNewsGroupPageAll()
        {
            CateNewsGroupDAO cateNewsGroupDAO = new CateNewsGroupDAO();
            return cateNewsGroupDAO.GetCateNewsGroupPageAll();
        }

        public DataTable GetCateNewsGroupViewAll()
        {
            CateNewsGroupDAO cateNewsGroupDAO = new CateNewsGroupDAO();
            return cateNewsGroupDAO.GetCateNewsGroupViewAll();
        }

        public void UpdateCateNewsGroup(CateNewsGroup cateNewsGroup)
        {
            new CateNewsGroupDAO().UpdateCateNewsGroup(cateNewsGroup);
        }

    }
}

