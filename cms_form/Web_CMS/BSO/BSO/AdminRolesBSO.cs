namespace BSO
{
    using DAO;
    using ETO;
    using System;
    using System.Data;

    public class AdminRolesBSO
    {
        public bool CheckExitPermission(int rolesID, string username)
        {
            AdminRolesDAO adminRolesDAO = new AdminRolesDAO();
            return adminRolesDAO.CheckExitPermission(rolesID, username);
        }

        public bool CheckExitRolesUser(int rolesID, string username)
        {
            AdminRolesDAO adminRolesDAO = new AdminRolesDAO();
            return adminRolesDAO.CheckExitRolesUser(rolesID, username);
        }

        public void CreateAdminRoles(AdminRoles adminRoles)
        {
            new AdminRolesDAO().CreateAdminRoles(adminRoles);
        }

        public void DeleteAdminRoles(int Id)
        {
            new AdminRolesDAO().DeleteAdminRoles(Id);
        }

        public void DeleteAdminRolesRoles(int Id)
        {
            new AdminRolesDAO().DeleteAdminRolesRoles(Id);
        }

        public void DeleteAdminRolesUserName(string username)
        {
            new AdminRolesDAO().DeleteAdminRolesUserName(username);
        }

        public AdminRoles GetAdminRoles(int rolesId, string username)
        {
            AdminRolesDAO adminRolesDAO = new AdminRolesDAO();
            return adminRolesDAO.GetAdminRoles(rolesId, username);
        }

        public DataTable GetAdminRolesAll()
        {
            AdminRolesDAO adminRolesDAO = new AdminRolesDAO();
            return adminRolesDAO.GetAdminRolesAll();
        }

        public AdminRoles GetAdminRolesById(int Id)
        {
            AdminRolesDAO adminRolesDAO = new AdminRolesDAO();
            return adminRolesDAO.GetAdminRolesById(Id);
        }

        public DataTable GetAdminRolesByRoles(int rolesID)
        {
            AdminRolesDAO adminRolesDAO = new AdminRolesDAO();
            return adminRolesDAO.GetAdminRolesByRoles(rolesID);
        }

        public DataTable GetAdminRolesByUserName(string username)
        {
            AdminRolesDAO adminRolesDAO = new AdminRolesDAO();
            return adminRolesDAO.GetAdminRolesByUserName(username);
        }

        public string GetAdminUserName(int rolesID)
        {
            AdminRolesDAO adminRolesDAO = new AdminRolesDAO();
            return adminRolesDAO.GetAdminUserName(rolesID);
        }

        public string GetAdminUserName1(int rolesID)
        {
            AdminRolesDAO adminRolesDAO = new AdminRolesDAO();
            return adminRolesDAO.GetAdminUserName1(rolesID);
        }

        public string GetPermission(int rolesID, string username)
        {
            AdminRolesDAO adminRolesDAO = new AdminRolesDAO();
            return adminRolesDAO.GetPermission(rolesID, username);
        }

        public string GetRoles(string username)
        {
            AdminRolesDAO adminRolesDAO = new AdminRolesDAO();
            return adminRolesDAO.GetRoles(username);
        }

        public void UpdateAdminRoles(AdminRoles adminRoles)
        {
            new AdminRolesDAO().UpdateAdminRoles(adminRoles);
        }
    }
}

