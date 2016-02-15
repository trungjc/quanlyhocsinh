namespace BSO
{
    using DAO;
    using ETO;
    using System;
    using System.Data;

    public class PermissionBSO
    {
        public void CreatePermission(Permission permission)
        {
            new PermissionDAO().CreatePermission(permission);
        }

        public void DeletePermission(int Id)
        {
            new PermissionDAO().DeletePermission(Id);
        }

        public DataTable GetPermissionAll()
        {
            PermissionDAO permissionDAO = new PermissionDAO();
            return permissionDAO.GetPermissionAll();
        }

        public Permission GetPermissionById(int Id)
        {
            PermissionDAO permissionDAO = new PermissionDAO();
            return permissionDAO.GetPermissionById(Id);
        }

        public void UpdatePermission(Permission permission)
        {
            new PermissionDAO().UpdatePermission(permission);
        }
    }
}

