namespace BSO
{
    using DAO;
    using ETO;
    using System;
    using System.Data;

    public class CateNewsPermissionBSO
    {
        public bool CheckExitPermission(int rolesID, int cateNewsID)
        {
            CateNewsPermissionDAO cateNewsPermissionDAO = new CateNewsPermissionDAO();
            return cateNewsPermissionDAO.CheckExitPermission(rolesID, cateNewsID);
        }

        public void CreateCateNewsPermission(CateNewsPermission cateNewsPermission)
        {
            new CateNewsPermissionDAO().CreateCateNewsPermission(cateNewsPermission);
        }

        public void DeleteCateNewsPermission(int Id)
        {
            new CateNewsPermissionDAO().DeleteCateNewsPermission(Id);
        }

        public void DeleteCateNewsPermissionCateID(int Id)
        {
            new CateNewsPermissionDAO().DeleteCateNewsPermissionCateID(Id);
        }

        public void DeleteCateNewsPermissionRoles(int Id)
        {
            new CateNewsPermissionDAO().DeleteCateNewsPermissionRoles(Id);
        }

        public string GetCateNewsID(int rolesID)
        {
            CateNewsPermissionDAO cateNewsPermissionDAO = new CateNewsPermissionDAO();
            return cateNewsPermissionDAO.GetCateNewsID(rolesID);
        }

        public string GetCateNewsID(string strRoles)
        {
            CateNewsPermissionDAO cateNewsPermissionDAO = new CateNewsPermissionDAO();
            return cateNewsPermissionDAO.GetCateNewsID(strRoles);
        }

        public CateNewsPermission GetCateNewsPermission(int rolesId, int cateNewsID)
        {
            CateNewsPermissionDAO cateNewsPermissionDAO = new CateNewsPermissionDAO();
            return cateNewsPermissionDAO.GetCateNewsPermission(rolesId, cateNewsID);
        }

        public DataTable GetCateNewsPermissionAll()
        {
            CateNewsPermissionDAO cateNewsPermissionDAO = new CateNewsPermissionDAO();
            return cateNewsPermissionDAO.GetCateNewsPermissionAll();
        }

        public DataTable GetCateNewsPermissionByCateID(int cateID)
        {
            CateNewsPermissionDAO cateNewsPermissionDAO = new CateNewsPermissionDAO();
            return cateNewsPermissionDAO.GetCateNewsPermissionByCateID(cateID);
        }

        public CateNewsPermission GetCateNewsPermissionById(int Id)
        {
            CateNewsPermissionDAO cateNewsPermissionDAO = new CateNewsPermissionDAO();
            return cateNewsPermissionDAO.GetCateNewsPermissionById(Id);
        }

        public DataTable GetCateNewsPermissionByRoles(int rolesID)
        {
            CateNewsPermissionDAO cateNewsPermissionDAO = new CateNewsPermissionDAO();
            return cateNewsPermissionDAO.GetCateNewsPermissionByRoles(rolesID);
        }

        public string GetPermission(int rolesID, int cateNewsID)
        {
            CateNewsPermissionDAO cateNewsPermissionDAO = new CateNewsPermissionDAO();
            return cateNewsPermissionDAO.GetPermission(rolesID, cateNewsID);
        }

        public string GetRoles(int cateID)
        {
            CateNewsPermissionDAO cateNewsPermissionDAO = new CateNewsPermissionDAO();
            return cateNewsPermissionDAO.GetRoles(cateID);
        }

        public void UpdateCateNewsPermission(CateNewsPermission cateNewsPermission)
        {
            new CateNewsPermissionDAO().UpdateCateNewsPermission(cateNewsPermission);
        }
    }
}

